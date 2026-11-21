using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_AI : ActiveUnit_AI
{
	public SubmarineDepthPreset DepthPreset
	{
		get
		{
			Group group = (Group)m_EventVal;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (Information.IsNothing(group.GroupLead))
			{
				return SubmarineDepthPreset.None;
			}
			return ((Submarine)group.GroupLead).AI.DepthPreset;
		}
		set
		{
			Group group = (Group)m_EventVal;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (!Information.IsNothing(group.GroupLead))
			{
				((Submarine)group.GroupLead).AI.DepthPreset = value;
				if (value != 0)
				{
					group.Kinematics.DesiredAltitudeOverride = true;
				}
			}
		}
	}

	public AircraftAltitudePreset AltitudePreset
	{
		get
		{
			Group group = (Group)m_EventVal;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (Information.IsNothing(group.GroupLead))
			{
				return AircraftAltitudePreset.None;
			}
			return ((Aircraft)group.GroupLead).AI.AltitudePreset;
		}
		set
		{
			Group group = (Group)m_EventVal;
			if (Information.IsNothing(group.GroupLead))
			{
				group.PrintInvocation();
			}
			if (!Information.IsNothing(group.GroupLead))
			{
				((Aircraft)group.GroupLead).AI.AltitudePreset = value;
				if (value != 0)
				{
					group.Kinematics.DesiredAltitudeOverride = true;
				}
			}
		}
	}

	public override Contact PrimaryTarget
	{
		get
		{
			if (Information.IsNothing(((Group)m_EventVal).GroupLead))
			{
				return null;
			}
			return ((Group)m_EventVal).GroupLead.AI.PrimaryTarget;
		}
		set
		{
			if (Information.IsNothing(((Group)m_EventVal).GroupLead))
			{
				((Group)m_EventVal).PrintInvocation();
			}
			if (!Information.IsNothing(((Group)m_EventVal).GroupLead))
			{
				((Group)m_EventVal).GroupLead.AI.PrimaryTarget = value;
			}
		}
	}

	public static Group_AI FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Group_AI group_AI = new Group_AI(ref activeUnit_0);
			group_AI.m_EventVal = activeUnit_0;
			if (Operators.CompareString(xmlNode_0.ChildNodes[0].Name, "ActiveUnit_AI", TextCompare: false) == 0)
			{
				xmlNode_0 = xmlNode_0.ChildNodes[0];
			}
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
					case "PrimaryThreat":
						group_AI._PrimaryThreat = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "PrimaryTarget":
						group_AI._PrimaryTarget = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "PrimaryTargetOverride":
						group_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Threats":
						if (group_AI._Threats == null)
						{
							group_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								group_AI._Threats.Add(item);
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
					case "IgnorePlottedCourse":
					case "IPC":
						if (!Information.IsNothing(activeUnit_0.Doctrine))
						{
							activeUnit_0.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, (Doctrine._UseIgnorePlottedCourse)(-(Conversions.ToBoolean(xmlNode.InnerText) ? 1 : 0)));
						}
						break;
					case "TargetList":
						group_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_, ref concurrentDictionary_0);
								if (targetingEntry.Target != null)
								{
									group_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
								}
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
			return group_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100603", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Group_AI result = new Group_AI(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			if (!Information.IsNothing(PrimaryTarget))
			{
				xmlWriter_0.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
			}
			if (!Information.IsNothing(_PrimaryThreat))
			{
				xmlWriter_0.WriteElementString("PrimaryThreat", _PrimaryThreat.ObjectID);
			}
			xmlWriter_0.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			xmlWriter_0.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			xmlWriter_0.WriteElementString("FCLIO", _FerryCycleLegIsOutbound.ToString());
			if (IsEscort)
			{
				xmlWriter_0.WriteElementString("IE", IsEscort.ToString());
			}
			if (!Information.IsNothing(_LastKnownTargetLocation))
			{
				xmlWriter_0.WriteStartElement("LKTL");
				xmlWriter_0.WriteRaw(_LastKnownTargetLocation.ToXML(hashSet_0));
				xmlWriter_0.WriteEndElement();
			}
			if (_TargetList != null && _TargetList.Count > 0)
			{
				xmlWriter_0.WriteStartElement("TargetList");
				foreach (TargetingEntry value in _TargetList.Values)
				{
					if (!Information.IsNothing(value.Target.ActualUnit))
					{
						xmlWriter_0.WriteRaw(value.ToXML(m_EventVal.GetUnitSide()));
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (_Threats != null && _Threats.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Threats");
				foreach (Contact item in new List<Contact>(_Threats))
				{
					if (item != null)
					{
						xmlWriter_0.WriteRaw(item.ToXML(hashSet_0, m_EventVal.GetUnitSide()));
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(SnakeAxis))
			{
				xmlWriter_0.WriteElementString("SnakeAxis", Conversions.ToString(SnakeAxis.Value));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100604", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
	}

	public Group_AI(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}

	public override void FollowAltitudePreset()
	{
		if (m_EventVal != null && m_EventVal.IsGroup)
		{
			((Group)m_EventVal).GroupLead.AI.FollowAltitudePreset();
		}
	}

	public static float OverLayerDepth(ActiveUnit activeUnit_0)
	{
		return SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen), activeUnit_0.ParentScen).Ceiling + 10;
	}

	public static float UnderLayerDepth(ActiveUnit activeUnit_0)
	{
		return SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen), activeUnit_0.ParentScen).Floor - 10;
	}

	public override void FollowDepthPreset(bool bool_0)
	{
		if (m_EventVal == null || !m_EventVal.IsGroup)
		{
			return;
		}
		switch (((Group)m_EventVal).GroupLead.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Submarine:
			((Group)m_EventVal).GroupLead.AI.FollowDepthPreset(bool_0);
			return;
		case GlobalVariables.ActiveUnitType.Aircraft:
			((Group)m_EventVal).GroupLead.AI.FollowAltitudePreset();
			return;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
			return;
		}
		throw new NotImplementedException();
	}

	public override void TargetThisContact(Contact contact_0, bool bool_0, bool bool_1, TargetingEntry._TargetingBehavior _TargetingBehavior_0)
	{
		try
		{
			if (contact_0.Type == Contact_Base.ContactType.Sonobuoy)
			{
				return;
			}
			if (contact_0.Type == Contact_Base.ContactType.Missile)
			{
				Weapon weapon = (Weapon)contact_0.ActualUnit;
				if (weapon.ValidTargets.Aircraft || weapon.ValidTargets.Missile)
				{
					if (bool_0)
					{
						m_EventVal.Message = "无法攻击AAW武器！";
					}
					return;
				}
			}
			foreach (ActiveUnit value in ((Group)m_EventVal).Units.Values)
			{
				if (value.CommStuff.IsConnectedToSideNetwork)
				{
					ActiveUnit_Weaponry weaponry = value.Weaponry;
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = "";
					int int_ = 0;
					if (weaponry.PopConsumer(contact_0, bool_1: true, doctrine, ref string_, ref int_))
					{
						value.AI.TargetThisContact(contact_0, bool_0: true, bool_1, _TargetingBehavior_0);
					}
					else
					{
						Notification_Bark.Create(m_EventVal, "No suitable weapons", Color.Red, bool_0: true, bool_1: true, 7f);
					}
				}
				else if (bool_0)
				{
					value.AddMessage(value.Name + "不能参与攻击（无法向单元下达命令）", "无法下达指令到单元" + value.Name, LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(value.GetLongitude(), value.GetLatitude()));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100606", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateUnitStatus(float float_0, bool bool_0, bool bool_1)
	{
	}

	public override void DropTarget(Contact contact_0, bool bool_0 = true)
	{
		foreach (ActiveUnit value in ((Group)m_EventVal).Units.Values)
		{
			value.AI.DropTarget(contact_0);
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
	}

	public override void DeterminePrimaryTarget(float float_0, bool bool_0, bool bool_1)
	{
	}
}
