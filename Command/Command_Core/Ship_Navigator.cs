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

public sealed class Ship_Navigator : ActiveUnit_Navigator
{
	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Ship_Navigator");
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
			exception_?.Data.Add("Error at 100791", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Ship_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Ship_Navigator ship_Navigator = new Ship_Navigator(ref activeUnit_0);
			ship_Navigator.myUnit = activeUnit_0;
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
						ship_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						ship_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "SD":
						ship_Navigator.SprintDrift = true;
						break;
					case "AvCav":
						ship_Navigator.AvoidCavitation = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SD_M":
					{
						string[] array = xmlNode.InnerText.Split('_');
						ship_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
						break;
					}
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							ship_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							ship_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "FS_B":
					case "FormationStation_Bearing":
						ship_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SD_Avg":
						ship_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "MPO":
					case "ManualPlotOverride":
						ship_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "FS_BT":
						ship_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(xmlNode.InnerText);
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
								ArrayExtensions.Add(ref ship_Navigator._PlottedCourse, theAC);
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
						ship_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TankerFollowsMe":
						ship_Navigator.TankerFollowsMe = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SupportMission_NextRefPoint":
					case "SM_NRP":
					{
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						ship_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
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
			return ship_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100792", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Ship_Navigator result = new Ship_Navigator(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Ship_Navigator(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		_ComposerWrapper = (int)Math.Round(Math.Min(((Ship)myUnit).Length, 100f) * 2f);
		modelWrapper = 1000;
	}

	public override void PlotCourseToStationArea(float float_0, bool bool_1)
	{
		base.PlotCourseToStationArea(float_0, bool_1);
		if (Information.IsNothing(myUnit.Kinematics.DesiredSpeedOverride))
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
	}

	public override bool HaveReachedPoint(double double_0, double double_1, float float_0, bool bool_1 = true, bool bool_2 = false, float? nullable_0 = null)
	{
		try
		{
			float num = Math2.VerifyClass(double_0, double_1, myUnit.GetLatitude(), myUnit.GetLongitude());
			if (num <= 3f)
			{
				double num2 = 0.0;
				if (!myUnit.IsMCMPlatform && !myUnit.IsMineLayingPlatform)
				{
					if (bool_1)
					{
						num2 = 0.2;
					}
					else
					{
						double num3 = myUnit.CurrentSpeed;
						while (num3 > 0.1)
						{
							double num4 = myUnit.Kinematics.GetDecelerationCapacity(myUnit.GetCurrentAltitude(), (float)num3, 0.1f) * 1.333;
							num2 += num3 / 36000.0;
							num3 -= num4;
						}
					}
				}
				else
				{
					num2 = 0.05;
				}
				if ((double)num < num2)
				{
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
			exception_?.Data.Add("Error at 100793", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}
}
