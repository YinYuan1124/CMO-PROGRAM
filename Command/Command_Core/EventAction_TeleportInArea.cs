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

public sealed class EventAction_TeleportInArea : EventAction
{
	public HashSet<string> UnitIDs;

	public List<ReferencePoint> Area;

	public EventAction_TeleportInArea()
	{
		UnitIDs = new HashSet<string>();
		Area = new List<ReferencePoint>();
		Type = EventActionType.TeleportInArea;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventAction_TeleportInArea");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("UnitIDs");
			foreach (string unitID in UnitIDs)
			{
				xmlWriter_0.WriteElementString("ID", unitID);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100513", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_TeleportInArea FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventAction_TeleportInArea eventAction_TeleportInArea = new EventAction_TeleportInArea();
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
					case "UnitIDs":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
								eventAction_TeleportInArea.UnitIDs.Add(xmlNode2.InnerText);
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
					case "ID":
						eventAction_TeleportInArea.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventAction_TeleportInArea.Description = xmlNode.InnerText;
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								eventAction_TeleportInArea.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
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
			return eventAction_TeleportInArea;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100514", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventAction_TeleportInArea result = new EventAction_TeleportInArea();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Execute(Scenario scenario_0, SimEvent simEvent_0)
	{
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		try
		{
			List<ActiveUnit> list_ = null;
			foreach (string unitID in UnitIDs)
			{
				ActiveUnit activeUnit;
				try
				{
					activeUnit = scenario_0.ActiveUnits[unitID];
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200459", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					continue;
				}
				if (activeUnit == null)
				{
					continue;
				}
				int num = 0;
				while (num < 1000)
				{
					geopoint_Struct = Math2.RandomPointWithinThisArea(Area);
					if (!Information.IsNothing(geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
					{
						try
						{
							num++;
							double latitude = geopoint_Struct.Latitude;
							double longitude = geopoint_Struct.Longitude;
							int int_ = 0;
							bool bool_ = true;
							bool bool_2 = true;
							string string_ = "";
							bool bool_3 = false;
							if (activeUnit.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
							{
								activeUnit.Teleport(ref scenario_0, geopoint_Struct.Longitude, geopoint_Struct.Latitude);
								break;
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 200460", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						continue;
					}
					string text = "";
					if (activeUnit.IsAircraft && Operators.CompareString(activeUnit.Name, activeUnit.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + activeUnit.UnitClass + ")";
					}
					activeUnit.AddMessage(activeUnit.Name + text + "无法在参考点定义的区域内选择合适的点：" + string.Join(" - ", Area.Select((ReferencePoint theP) => theP.Name)), activeUnit.Name + " 无法选取合适的点", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
					return;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100515", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_TeleportInArea obj = (EventAction_TeleportInArea)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
