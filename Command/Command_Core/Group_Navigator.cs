using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Navigator : ActiveUnit_Navigator
{
	public override bool SprintDrift
	{
		get
		{
			Group group = (Group)myUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (Information.IsNothing(group.GroupLead))
			{
				return false;
			}
			return group.GroupLead.Navigator.SprintDrift;
		}
		set
		{
			Group group = (Group)myUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (!Information.IsNothing(group.GroupLead))
			{
				group.GroupLead.Navigator.SprintDrift = value;
			}
		}
	}

	public override float? SprintDrift_AverageSpeed
	{
		get
		{
			Group group = (Group)myUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (Information.IsNothing(group.GroupLead))
			{
				return 0f;
			}
			return group.GroupLead.Navigator.SprintDrift_AverageSpeed;
		}
		set
		{
			Group group = (Group)myUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (!Information.IsNothing(group.GroupLead))
			{
				group.GroupLead.Navigator.SprintDrift_AverageSpeed = value;
			}
		}
	}

	public override GeoPoint SprintDrift_Marker
	{
		get
		{
			Group group = (Group)myUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (Information.IsNothing(group.GroupLead))
			{
				return new GeoPoint();
			}
			return group.GroupLead.Navigator.SprintDrift_Marker;
		}
		set
		{
			Group group = (Group)myUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (!Information.IsNothing(group.GroupLead))
			{
				group.GroupLead.Navigator.SprintDrift_Marker = value;
			}
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Group_Navigator");
			xmlWriter_0.WriteStartElement("PlottedCourse");
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
			xmlWriter_0.WriteElementString("ManualPlotOverride", ManualPlotOverride.ToString());
			if (!Information.IsNothing(SupportMission_NextRefPoint))
			{
				xmlWriter_0.WriteStartElement("SupportMission_NextRefPoint");
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
			exception_?.Data.Add("Error at 100620", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Group_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		Group_Navigator result = null;
		try
		{
			Group_Navigator group_Navigator = new Group_Navigator(ref activeUnit_0);
			group_Navigator.myUnit = activeUnit_0;
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
					case "SupportMission_NextRefPoint":
					{
						XmlNode xmlNode_3 = xmlNode.ChildNodes[0];
						group_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
						break;
					}
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							group_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							group_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						group_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "PlottedCourse":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								Waypoint theAC2 = Waypoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref group_Navigator._PlottedCourse, theAC2);
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
					case "PC_PP":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								Waypoint theAC = Waypoint.FromXML(ref xmlNode_, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref group_Navigator._PlottedCourse_PrePlanned, theAC);
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
					case "ManualPlotOverride":
						group_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
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
			result = group_Navigator;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100621", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Group_Navigator(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void ClearPlottedCourse()
	{
		base.ClearPlottedCourse();
		try
		{
			if (!myUnit.IsGroup)
			{
				return;
			}
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				if (!value.IsGroupLead())
				{
					value.Navigator.ClearPlottedCourse();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100622", "");
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
	}

	public override void ResetTimeToNextPathfinderCheck()
	{
		try
		{
			if (!myUnit.IsGroup)
			{
				return;
			}
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				value.Navigator.ResetTimeToNextPathfinderCheck();
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

	public override void FollowSupportMissionCourse(float float_0, bool bool_1)
	{
	}

	public override void ExtendIfNecessary(float float_0, ref Waypoint waypoint_0, double double_0, double double_1, float float_1, float float_2, float float_3, Misc.ExtendPhase extendPhase_0 = Misc.ExtendPhase.Standard)
	{
	}
}
