using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_Navigator : ActiveUnit_Navigator
{
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
			if (ManualPlotOverride)
			{
				xmlWriter_0.WriteElementString("MPO", "True");
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
			exception_?.Data.Add("Error at 100561", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Vehicle_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Vehicle_Navigator vehicle_Navigator = new Vehicle_Navigator(ref activeUnit_0);
			vehicle_Navigator.myUnit = activeUnit_0;
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
					case "SD_M":
					{
						string[] array = xmlNode.InnerText.Split('_');
						vehicle_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
						break;
					}
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						vehicle_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							vehicle_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							vehicle_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "SD":
						vehicle_Navigator.SprintDrift = true;
						break;
					case "MPO":
					case "ManualPlotOverride":
						vehicle_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "FS_B":
					case "FormationStation_Bearing":
						vehicle_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SD_Avg":
						vehicle_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "FS_BT":
						vehicle_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(xmlNode.InnerText);
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
								ArrayExtensions.Add(ref vehicle_Navigator._PlottedCourse, theAC);
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
						vehicle_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SupportMission_NextRefPoint":
					case "SM_NRP":
					{
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						vehicle_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
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
			return vehicle_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100562", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Vehicle_Navigator result = new Vehicle_Navigator(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Vehicle_Navigator(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		try
		{
			_ComposerWrapper = (int)Math.Round(Math.Min(Math.Sqrt(((Vehicle)myUnit).Area), 10.0) * 2.0);
			modelWrapper = 2000;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100563", "");
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
		base.PlotCourseToStationArea(float_0, bool_1);
		try
		{
			float? desiredSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
			long? num = (desiredSpeedOverride.HasValue ? new long?((long)Math.Round(desiredSpeedOverride.GetValueOrDefault())) : null);
			long? num2 = (~num) ?? num;
			if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() != 0) : null).GetValueOrDefault())
			{
				return;
			}
			if (myUnit.GetParentGroup() != null)
			{
				if (myUnit.GetParentGroup().ThrottleSetting == ActiveUnit.Throttle.Flank)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				}
			}
			myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(0f, myUnit.ThrottleSetting, bool_0: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100564", "");
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
		double num = 0.02;
		if (m_ErrorWrapper)
		{
			num = 0.01;
		}
		if ((double)Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item, item2) < num)
		{
			return true;
		}
		if ((double)Math.Abs(new Geopoint_Struct(item2, item).UpdateInvocation(myUnit)) > 90.0 && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.GetParentGroup().GroupLead.CurrentHeading)) < 20f)
		{
			return true;
		}
		return false;
	}

	protected override void PerformPathfinding(Waypoint waypoint_0, ActiveUnit activeUnit_0, Mission.Flight flight_0, bool bool_1, float float_0, double double_0, double double_1, bool bool_2)
	{
		try
		{
			bool bool_3 = false;
			double latitude;
			double longitude;
			float num;
			if (waypoint_0 == null)
			{
				latitude = activeUnit_0.GetLatitude();
				longitude = activeUnit_0.GetLongitude();
				num = activeUnit_0.CurrentHeading;
			}
			else
			{
				latitude = waypoint_0.Latitude;
				longitude = waypoint_0.Longitude;
				num = Math2.PublishClass(latitude, longitude, double_0, double_1);
			}
			int int_ = 0;
			bool bool_4 = true;
			bool bool_5 = true;
			List<ActiveUnit> list_ = null;
			string string_ = "";
			bool bool_6 = false;
			if (activeUnit_0.CanMoveToThisLocation(double_0, double_1, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_4, bool_4: true, ref bool_5, null, null, ref list_, float_0, bool_2, bool_7: false, ref string_, ref bool_6))
			{
				activeUnit_0.AI.NavDestination = new Geopoint_Struct(double_1, double_0);
				double double_2 = latitude;
				double double_3 = longitude;
				float float_ = num;
				list_ = new List<ActiveUnit>();
				PF_GeneratedCourse = PathfindingCourse(double_2, double_3, double_0, double_1, float_, bool_1: true, float_0, ref list_, bool_3);
				if (PF_GeneratedCourse == null)
				{
					myUnit.AddMessage(myUnit.Name + " has cleared its plotted course (Reason: The destination is unreachable or the destination is beyond the navigator's maximum distance.)", myUnit.Name + " clearing plotted course.", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					ClearPlottedCourse();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100565", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override List<Waypoint> PathfindingCourse(double double_0, double double_1, double double_2, double double_3, float float_0, bool bool_1, float float_1, ref List<ActiveUnit> list_0, bool bool_2)
	{
		List<Waypoint> list = new List<Waypoint>();
		try
		{
			if (myUnit.ParentScen.ThreadedOpsMustStop)
			{
				base.PathFindingInProgress = false;
				return null;
			}
			list = Pathfinding.exporterConsumer.SolvePF_Finegrained(myUnit, double_0, double_1, double_2, double_3, float_0, 2f, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2);
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10022324059230495134123498", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Waypoint> result = list;
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
