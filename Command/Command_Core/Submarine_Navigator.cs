using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Navigator : ActiveUnit_Navigator
{
	private Submarine m_IndexerProxy;

	[SpecialName]
	private Submarine GetParentPlatform()
	{
		if (Information.IsNothing(m_IndexerProxy))
		{
			m_IndexerProxy = (Submarine)myUnit;
		}
		return m_IndexerProxy;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Submarine_Navigator");
			if (AvoidCavitation)
			{
				xmlWriter_0.WriteElementString("AvCav", AvoidCavitation.ToString());
			}
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
			xmlWriter_0.WriteElementString("MPO", ManualPlotOverride.ToString());
			if (!Information.IsNothing(TankerFollowsMe))
			{
				xmlWriter_0.WriteElementString("TankerFollowsMe", TankerFollowsMe.Value.ToString());
			}
			if (TankerFollowsMe_NumberOfWaypoints != 0)
			{
				xmlWriter_0.WriteElementString("TankerFollowsMe_NumberOfWaypoints", TankerFollowsMe_NumberOfWaypoints.ToString());
			}
			if (myUnit.IsGroupMember())
			{
				xmlWriter_0.WriteElementString("FS_B", XmlConvert.ToString(base.UnitFormationStation.Bearing));
				xmlWriter_0.WriteElementString("FS_D", XmlConvert.ToString(base.UnitFormationStation.Distance));
				xmlWriter_0.WriteElementString("FS_BT", XmlConvert.ToString((byte)base.UnitFormationStation.BearingType));
			}
			if (!Information.IsNothing(SupportMission_NextRefPoint))
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
			if (SprintDrift)
			{
				xmlWriter_0.WriteElementString("SD", "True");
				xmlWriter_0.WriteElementString("SD_Avg", XmlConvert.ToString(SprintDrift_AverageSpeed.Value));
				xmlWriter_0.WriteElementString("SD_M", XmlConvert.ToString(SprintDrift_Marker.Longitude) + "_" + XmlConvert.ToString(SprintDrift_Marker.Latitude));
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100837", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Submarine_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Submarine_Navigator submarine_Navigator = new Submarine_Navigator(ref activeUnit_0);
			submarine_Navigator.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TankerFollowsMe_NumberOfWaypoints":
						submarine_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						submarine_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "SD":
						submarine_Navigator.SprintDrift = true;
						break;
					case "AvCav":
						submarine_Navigator.AvoidCavitation = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SD_M":
					{
						string[] array = xmlNode.InnerText.Split('_');
						submarine_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
						break;
					}
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							submarine_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							submarine_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "FS_B":
					case "FormationStation_Bearing":
						submarine_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SD_Avg":
						submarine_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "MPO":
					case "ManualPlotOverride":
						submarine_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "FS_BT":
						submarine_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PC":
					case "PlottedCourse":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								Waypoint theAC = Waypoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref submarine_Navigator._PlottedCourse, theAC);
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
					case "FS_D":
					case "FormationStation_Distance":
						submarine_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TankerFollowsMe":
						submarine_Navigator.TankerFollowsMe = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SupportMission_NextRefPoint":
					case "SM_NRP":
					{
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						submarine_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
						break;
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
			return submarine_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100838", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Submarine_Navigator result = new Submarine_Navigator(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Submarine_Navigator(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		_ComposerWrapper = (int)Math.Round(Math.Min(((Submarine)myUnit).Length, 100f) * 2f);
		modelWrapper = 500;
	}

	public override bool HaveReachedPoint(double double_0, double double_1, float float_0, bool bool_1 = true, bool bool_2 = false, float? nullable_0 = null)
	{
		if (nullable_0.HasValue)
		{
			float num = 0.25f;
			num = nullable_0.Value;
			if (Math2.VerifyClass(double_0, double_1, myUnit.GetLatitude(), myUnit.GetLongitude()) < num)
			{
				return true;
			}
			return false;
		}
		return base.HaveReachedPoint(double_0, double_1, float_0, bool_1, bool_2);
	}

	public override void AddWaypoint(double double_0, double double_1, float float_0, Waypoint.WaypointType waypointType_0, Waypoint.WaypointCreator waypointCreator_0, Waypoint.WaypointCategory waypointCategory_0, bool bool_1 = true)
	{
		try
		{
			Waypoint waypoint;
			if (myUnit.IsGroupLead())
			{
				waypoint = new Waypoint(double_1, double_0, float_0, waypointType_0, waypointCreator_0, waypointCategory_0);
				myUnit.GetParentGroup().Navigator.AddWaypoint(waypoint);
			}
			else
			{
				waypoint = new Waypoint(double_1, double_0, float_0, waypointType_0, waypointCreator_0, waypointCategory_0);
				ArrayExtensions.Add(ref _PlottedCourse, waypoint);
			}
			waypoint.DepthPreset = GetParentPlatform().AI.DepthPreset;
			ManualPlotOverride = waypointType_0 == Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1002299", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void FollowPlottedCourse(float float_0)
	{
		if (!HasPlottedCourse())
		{
			return;
		}
		if (GetParentPlatform().IsTetheredROV)
		{
			ActiveUnit assignedHostUnit = myUnit.DockingOps.GetAssignedHostUnit();
			if (!Information.IsNothing(assignedHostUnit) && (double)Module_Unit.RangeToUnit_Horiz(assignedHostUnit, GetParentPlatform()) > (double)GetParentPlatform().ROVControlRadius_m / 1852.0 * 1.25)
			{
				ApplyWaypointSpeedAltToUnit(base.PlottedCourse[0]);
				ApplyWaypointDoctrineToUnit(base.PlottedCourse[0]);
				RemoveWaypoint_Soft(base.PlottedCourse[0], bool_1: false);
				return;
			}
		}
		base.FollowPlottedCourse(float_0);
	}

	public override void PlotCourseToStationArea(float float_0, bool bool_1)
	{
		if (GetParentPlatform().IsOnActiveMineClearingMission && (GetParentPlatform().Type == Submarine._SubmarineType.ROV || GetParentPlatform().Type == Submarine._SubmarineType.UUV))
		{
			float num = (GetParentPlatform().IsTetheredROV ? ((float)((double)GetParentPlatform().ROVControlRadius_m / 1852.0)) : ((GetParentPlatform().Sensors_Cached.Length == 0) ? 5f : GetParentPlatform().Sensors_Cached[0].maxRange));
			double latitude = GetParentPlatform().DockingOps.GetAssignedHostUnit().GetLatitude();
			double longitude = GetParentPlatform().DockingOps.GetAssignedHostUnit().GetLongitude();
			float currentHeading = GetParentPlatform().DockingOps.GetAssignedHostUnit().CurrentHeading;
			ReferencePoint referencePoint = new ReferencePoint();
			ReferencePoint referencePoint2 = new ReferencePoint();
			ReferencePoint referencePoint3 = new ReferencePoint();
			ReferencePoint referencePoint4 = new ReferencePoint();
			ReferencePoint referencePoint5 = new ReferencePoint();
			ReferencePoint referencePoint6 = new ReferencePoint();
			List<ReferencePoint> list = new List<ReferencePoint>(6);
			double double_ = referencePoint.Longitude;
			double double_2 = referencePoint.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, (float)((double)num * 0.1), Math2.UpdateClass(currentHeading - 45f));
			referencePoint.Latitude = double_2;
			referencePoint.Longitude = double_;
			list.Add(referencePoint);
			double_2 = referencePoint2.Longitude;
			double_ = referencePoint2.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_2, ref double_, num, Math2.UpdateClass(currentHeading - 45f));
			referencePoint2.Latitude = double_;
			referencePoint2.Longitude = double_2;
			list.Add(referencePoint2);
			double_ = referencePoint3.Longitude;
			double_2 = referencePoint3.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, num, currentHeading);
			referencePoint3.Latitude = double_2;
			referencePoint3.Longitude = double_;
			list.Add(referencePoint3);
			double_2 = referencePoint4.Longitude;
			double_ = referencePoint4.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_2, ref double_, num, Math2.UpdateClass(currentHeading + 45f));
			referencePoint4.Latitude = double_;
			referencePoint4.Longitude = double_2;
			list.Add(referencePoint4);
			double_ = referencePoint5.Longitude;
			double_2 = referencePoint5.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, (float)((double)num * 0.1), Math2.UpdateClass(currentHeading + 45f));
			referencePoint5.Latitude = double_2;
			referencePoint5.Longitude = double_;
			list.Add(referencePoint5);
			double_2 = referencePoint6.Longitude;
			double_ = referencePoint6.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_2, ref double_, (float)((double)num * 0.1), currentHeading);
			referencePoint6.Latitude = double_;
			referencePoint6.Longitude = double_2;
			list.Add(referencePoint6);
			PlotCourseToArea(list);
		}
		else
		{
			base.PlotCourseToStationArea(float_0, bool_1);
		}
		ResetTimeToNextPathfinderCheck();
	}

	public override void HeadToFormationStation(float float_0)
	{
		try
		{
			if (Information.IsNothing(myUnit.GetParentGroup().GroupLead))
			{
				myUnit.GetParentGroup().PrintInvocation();
				if (Information.IsNothing(myUnit.GetParentGroup().GroupLead))
				{
					return;
				}
			}
			if (myUnit.IsGroupMember() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead) && (myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling) && myUnit.GetParentGroup().GroupLead.DockingOps.UNREP_Destination == myUnit)
			{
				if (myUnit.GetParentGroup().GroupLead.Navigator.HasPlottedCourse())
				{
					Waypoint waypoint = myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse[0];
					myUnit.SetDesiredHeading(myUnit.GetParentGroup().GroupLead.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint.Latitude, waypoint.Longitude));
					Waypoint waypoint_ = null;
					ExtendIfNecessary(float_0, ref waypoint_, waypoint.Latitude, waypoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
				}
			}
			else
			{
				if (myUnit.IsGroupLead())
				{
					return;
				}
				if (base.HasPathfindingPlottedCourse)
				{
					FollowPlottedCourse(float_0);
					return;
				}
				if (myUnit.IsGroupMember() && !myUnit.Kinematics.DesiredAltitudeOverride && myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
				{
					myUnit.DesiredAltitude = myUnit.GetParentGroup().GroupLead.DesiredAltitude;
					myUnit.DesiredAltitude_AGL = myUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL;
				}
				ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
				if (Information.IsNothing(groupLead))
				{
					return;
				}
				Tuple<double, double> validatedLatitudeAndLongitude = base.UnitFormationStation.GetValidatedLatitudeAndLongitude(myUnit, groupLead);
				double num = validatedLatitudeAndLongitude.Item1;
				double num2 = validatedLatitudeAndLongitude.Item2;
				if (SprintDrift)
				{
					PerformSprintDrift(float_0);
				}
				else
				{
					if (HaveReachedPoint(num, num2, float_0))
					{
						float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
						if (relativeBearing > 90f && relativeBearing < 270f)
						{
							myUnit.SetDesiredHeading(groupLead.DesiredTurnRate, myUnit.GetParentGroup().DesiredHeading);
							myUnit.DesiredSpeed = myUnit.GetParentGroup().GroupLead.CurrentSpeed - 1f;
						}
						else
						{
							myUnit.SetDesiredHeading(groupLead.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
							myUnit.DesiredSpeed = myUnit.GetParentGroup().DesiredSpeed;
						}
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
						return;
					}
					myUnit.SetDesiredHeading(groupLead.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
					if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
						ActiveUnit activeUnit = myUnit;
						ActiveUnit.Throttle throttleSuitableForThisSpeed = myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
						float? desiredSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
						activeUnit.SetThrottle(throttleSuitableForThisSpeed, desiredSpeedOverride.HasValue ? new int?((int)Math.Round(desiredSpeedOverride.GetValueOrDefault())) : null);
					}
					else if (myUnit.IsGroupMember())
					{
						if ((int)myUnit.GetParentGroup().GroupLead.ThrottleSetting <= 3)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						}
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Full);
					}
				}
				if (groupLead.CurrentSpeed > 0f)
				{
					double double_ = 0.0;
					double double_2 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref double_, ref double_2, base.UnitFormationStation.Distance, groupLead.CurrentHeading);
					ActiveUnit activeUnit2 = myUnit;
					double double_3 = double_2;
					double double_4 = double_;
					int int_ = 0;
					bool bool_ = true;
					bool bool_2 = true;
					List<ActiveUnit> list_ = null;
					string string_ = "";
					bool bool_3 = false;
					if (!activeUnit2.CanMoveToThisLocation(double_3, double_4, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
					{
						num = groupLead.GetLatitude();
						num2 = groupLead.GetLongitude();
					}
				}
				myUnit.AI.NavDestination = new Geopoint_Struct(num2, num);
				if (base.HasPathfindingPlottedCourse || base.PathFindingInProgress)
				{
					return;
				}
				if (myUnit.Navigator.bool_0)
				{
					double latitude = myUnit.GetLatitude();
					double longitude = myUnit.GetLongitude();
					double double_5 = num;
					double double_6 = num2;
					float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
					int int_2 = 0;
					GeoPoint geoPoint_ = null;
					if (PathLineIsInterrupted(latitude, longitude, double_5, double_6, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: true, nullable_, ref int_2, ref geoPoint_))
					{
						TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, num, num2, myUnit.ParentScen, bool_2: false);
						return;
					}
				}
				if (!SprintDrift)
				{
					float relativeBearing2 = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
					if (relativeBearing2 > 90f && relativeBearing2 < 270f && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.GetParentGroup().CurrentHeading)) <= 30f)
					{
						myUnit.SetDesiredHeading(groupLead.DesiredTurnRate, myUnit.GetParentGroup().CurrentHeading);
						myUnit.DesiredSpeed = (float)((double)myUnit.GetParentGroup().CurrentSpeed * 0.2);
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
					}
					else
					{
						myUnit.SetDesiredHeading(groupLead.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
					}
				}
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
}
