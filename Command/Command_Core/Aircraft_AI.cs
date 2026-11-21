using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using CSMaterial;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Aircraft_AI : ActiveUnit_AI
{
	[CompilerGenerated]
	private sealed class AttributeProcessResolver
	{
		public ActiveUnit dataLinkParent;

		internal bool ChangeInterruptibleTag(Contact theC)
		{
			return Operators.CompareString(theC.ActualUnit.ObjectID, dataLinkParent?.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ContextDispatcherList
	{
		public ActiveUnit parentPlatform;

		internal bool InitInterruptibleTag(Contact theC)
		{
			return Operators.CompareString(theC.ActualUnit.ObjectID, parentPlatform?.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ComparatorCallbackCandidate
	{
		public Strike Local_myStrike;

		public Aircraft_AI Me;

		internal bool CheckInterruptibleTag(Contact theC)
		{
			if (theC.GetIsSpecificTargetForThisStrike(Local_myStrike))
			{
				ActiveUnit_Weaponry weaponry = Me.m_EventVal.Weaponry;
				Doctrine doctrine = Me.m_EventVal.Doctrine;
				string string_ = "";
				int int_ = 0;
				return weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_);
			}
			return false;
		}

		internal bool ConcatInterruptibleTag(Contact theC)
		{
			if (theC.GetIsSpecificTargetForThisStrike(Local_myStrike))
			{
				ActiveUnit_Weaponry weaponry = Me.m_EventVal.Weaponry;
				Doctrine doctrine = Me.m_EventVal.Doctrine;
				string string_ = "";
				int int_ = 0;
				return weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class EventProcessResolver
	{
		public Contact Local_theT0;

		internal double InterruptInterruptibleTag(ActiveUnit theAU)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theAU, Local_theT0);
		}
	}

	[CompilerGenerated]
	private sealed class IssuerParameterMessage
	{
		public Contact Local_theT;

		internal double RemoveInterruptibleTag(ActiveUnit theAU)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theAU, Local_theT);
		}
	}

	[CompilerGenerated]
	private sealed class WatcherComparator
	{
		public Strike Local_theStrikeMission;

		internal bool FindInterruptibleTag(Contact theC)
		{
			return theC.GetIsSpecificTargetForThisStrike(Local_theStrikeMission);
		}
	}

	[CompilerGenerated]
	private sealed class TestCollectionRecord
	{
		public Aircraft_AI Me;

		public bool Local_IgnoreContacStance;

		public Contact[] Local_myTargets;

		public List<Contact> Local_ContactsInsideNoNavZones;

		public Mission Local_myMission;

		public Doctrine._UseShootTourists? Local_Doctrine_ShootTourists;

		public bool Local_MyUnitIsInsidePatrolArea;

		public List<Weapon> Local_myAvailableWeapons;

		internal void SetInterruptibleTag(Contact thisContact)
		{
			string objectID = thisContact.ObjectID;
			if (Local_myTargets.Contains(thisContact) || Local_ContactsInsideNoNavZones.Contains(thisContact))
			{
				return;
			}
			byte? b = (byte?)thisContact.BDA_StructuralIntegrity;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
			{
				return;
			}
			if (!Me.m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out var value))
			{
				value = thisContact.GetStance(Me.m_EventVal.GetUnitSide());
			}
			switch (value)
			{
			case Misc.PostureStance.Unfriendly:
			case Misc.PostureStance.Hostile:
			{
				Aircraft_AI me = Me;
				Mission local_myMission = Local_myMission;
				Doctrine._UseShootTourists? local_Doctrine_ShootTourists = Local_Doctrine_ShootTourists;
				bool local_IgnoreContacStance = Local_IgnoreContacStance;
				bool local_MyUnitIsInsidePatrolArea = Local_MyUnitIsInsidePatrolArea;
				Misc.PostureStance? nullable_2 = value;
				string string_2 = "";
				int int_2 = 0;
				if (!me.ContactIsRelevantToMission(thisContact, local_myMission, local_Doctrine_ShootTourists, local_IgnoreContacStance, local_MyUnitIsInsidePatrolArea, bool_2: true, nullable_2, ref string_2, ref int_2) || Me.PopClient(thisContact))
				{
					break;
				}
				if (thisContact.Type == Contact_Base.ContactType.Submarine)
				{
					if (!thisContact.IsClassifiedFalseTarget && !SeaIceProvider.PrepareWriter(thisContact.GetLongitude(), thisContact.GetLatitude()))
					{
						Me.TargetThisContact(thisContact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						Me.m_ValObserver.Add(thisContact.ObjectID);
					}
					break;
				}
				ActiveUnit_Weaponry weaponry = Me.m_EventVal.Weaponry;
				Doctrine doctrine = Me.m_EventVal.Doctrine;
				string_2 = "";
				int_2 = 0;
				if (weaponry.PopConsumer(thisContact, bool_1: true, doctrine, ref string_2, ref int_2, Local_myAvailableWeapons))
				{
					Me.TargetThisContact(thisContact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					Me.m_ValObserver.Add(thisContact.ObjectID);
				}
				break;
			}
			case Misc.PostureStance.Unknown:
			{
				Misc.PostureStance? nullable_ = value;
				string string_ = "";
				int int_ = 0;
				if (Me.ContactIsRelevantToMission(thisContact, Local_myMission, Local_Doctrine_ShootTourists, Local_IgnoreContacStance, Local_MyUnitIsInsidePatrolArea, bool_2: true, nullable_, ref string_, ref int_) && (thisContact.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PrepareWriter(thisContact.GetLongitude(), thisContact.GetLatitude())))
				{
					Me.TargetThisContact(thisContact, bool_0: false, bool_1: true, TargetingEntry._TargetingBehavior.AutoTargeted);
				}
				break;
			}
			case Misc.PostureStance.Neutral:
			case Misc.PostureStance.Friendly:
				break;
			}
		}
	}

	[CompilerGenerated]
	private sealed class ComparatorThreadBridge
	{
		public Aircraft_AI _003C_003E4__this;

		public float elapsedTime;

		internal void FillInterruptibleTag()
		{
			_003C_003E4__this.QueryFacade(elapsedTime, bool_0: true);
		}
	}

	[CompilerGenerated]
	private sealed class AdvisorObjectListener
	{
		public Aircraft_AI Me;

		public Doctrine Local_theDoc;

		internal float CalculateInterruptibleTag(Weapon theWeapon)
		{
			return theWeapon.GetMaxRangeForThisTarget(Me.m_EventVal, Me.PrimaryTarget, bool_0: true, Local_theDoc, bool_1: false);
		}
	}

	[CompilerGenerated]
	private sealed class ReponseComparator
	{
		public List<Waypoint> list;

		internal int PopInterruptibleTag(Waypoint theWP)
		{
			return list.IndexOf(theWP);
		}
	}

	[CompilerGenerated]
	private sealed class InterceptorMerchantService
	{
		public Aircraft_AI Me;

		public MineClearingMission Local_myMission;

		public Aircraft_AI _003C_003E4__this;

		public Func<UnguidedWeapon, bool> _003C_003E9__1;

		public Func<UnguidedWeapon, double> _003C_003E9__2;

		internal bool InstantiateInterruptibleTag(UnguidedWeapon theMine)
		{
			if (theMine != null)
			{
				return _003C_003E4__this.m_EventVal.GetCanSweepMine(theMine);
			}
			return false;
		}

		internal double CreateInterruptibleTag(UnguidedWeapon theMine)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(_003C_003E4__this.m_EventVal, theMine);
		}

		internal double CompareInterruptibleTag(UnguidedWeapon theMine)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(_003C_003E4__this.m_EventVal, theMine);
		}
	}

	[CompilerGenerated]
	private sealed class DefinitionCollectionTask
	{
		public Dictionary<string, UnguidedWeapon> Local_WeaponsDic;

		public List<ReferencePoint> Local_MissionArea;

		public TList<UnguidedWeapon> Local_LegitTargets;

		public InterceptorMerchantService CS_0024_003C_003E8__locals1;

		internal void ReadInterruptibleTag(string theUW_ObjectID)
		{
			Local_WeaponsDic.TryGetValue(theUW_ObjectID, out var value);
			if (value != null && value.IsMine)
			{
				if (value.GetIsInsideThisArea(Local_MissionArea, CS_0024_003C_003E8__locals1.Me.m_EventVal.ParentScen, bool_0: true))
				{
					Local_LegitTargets.Add(value);
				}
				else if (CS_0024_003C_003E8__locals1.Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && CS_0024_003C_003E8__locals1.Me.m_EventVal.Navigator.DisableDic(ref Local_MissionArea, ref CS_0024_003C_003E8__locals1.Local_myMission.Area_2nm_Buffered, ref CS_0024_003C_003E8__locals1.Local_myMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
				{
					Local_LegitTargets.Add(value);
				}
			}
		}
	}

	private Aircraft processObserver;

	private AircraftAltitudePreset m_ThreadObserver;

	private int m_RuleObserver;

	private int m_CollectionObserver;

	private int m_InstanceObserver;

	private int m_ObjectObserver;

	private Tuple<Mount, float, bool> _ParameterObserver;

	[ThreadStatic]
	private List<Contact> m_ExpressionObserver;

	[ThreadStatic]
	private List<Contact> dispatcherObserver;

	[ThreadStatic]
	private List<ActiveUnit> _ListenerObserver;

	[ThreadStatic]
	private List<ActiveUnit> _ConfigObserver;

	[ThreadStatic]
	private List<Contact> m_RegistryObserver;

	private ConcurrentHashSet<string> m_ValObserver;

	[ThreadStatic]
	private List<Contact> _WrapperObserver;

	[ThreadStatic]
	private Weapon[] m_ObserverObserver;

	public AircraftAltitudePreset AltitudePreset
	{
		get
		{
			return m_ThreadObserver;
		}
		set
		{
			m_ThreadObserver = value;
			if (value != 0)
			{
				m_EventVal.Kinematics.DesiredAltitudeOverride = true;
			}
		}
	}

	public bool RefueledInThisLeg { get; set; }

	[SpecialName]
	private Aircraft GetAircraft()
	{
		if (processObserver == null)
		{
			processObserver = (Aircraft)m_EventVal;
		}
		return processObserver;
	}

	public static Aircraft_AI FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Aircraft_AI aircraft_AI = new Aircraft_AI(ref activeUnit_0);
			aircraft_AI.m_EventVal = activeUnit_0;
			if (xmlNode_0.ChildNodes.Count == 0)
			{
				return aircraft_AI;
			}
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
					case "PrimaryTarget":
					case "PTarget":
						aircraft_AI._PrimaryTarget = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "SpeedAdjustmentToT_OriginalThrottle":
						aircraft_AI.SpeedAdjustmentToT_OriginalThrottle = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PrimaryThreat":
					case "PThreat":
						aircraft_AI._PrimaryThreat = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "Threats":
						if (aircraft_AI._Threats == null)
						{
							aircraft_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_, ref concurrentDictionary_0);
								aircraft_AI._Threats.Add(item);
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
					case "LeadMustSlowDownDueToBingo":
						aircraft_AI.LeadMustSlowDownDueToBingo = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AP":
						aircraft_AI.AltitudePreset = (AircraftAltitudePreset)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "DPT_E":
						aircraft_AI.DeterminePrimaryTarget_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "TTNPTE":
						aircraft_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "IE":
						aircraft_AI.IsEscort = true;
						break;
					case "PrimaryTarget_LastKnown_Lon":
						aircraft_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "FerryCycleLegIsOutbound":
					case "FCLIO":
						aircraft_AI._FerryCycleLegIsOutbound = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "TimeToNextSpeedAdjustmentForToTEvaluation":
						aircraft_AI.TimeToNextSpeedAdjustmentForToTEvaluation = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lat":
						aircraft_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "SpeedAdjustmentToT_OriginalSpeed":
						aircraft_AI.SpeedAdjustmentToT_OriginalSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TargetList":
						aircraft_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								if (targetingEntry.Target != null && !aircraft_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
								{
									aircraft_AI.AddTargetList_Threadsafe(targetingEntry.Target.ObjectID, targetingEntry);
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
					case "SpeedAdjustmentToT_OriginalThrottlePreset":
						aircraft_AI.SpeedAdjustmentToT_OriginalThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PrimaryPickupTarget":
						aircraft_AI._PrimaryPickupTarget = ActiveUnit.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "IsPerformingSpeedAdjustmentToT":
						aircraft_AI.IsPerformingSpeedAdjustmentToT = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SpeedAdjustmentToT_OriginalSpeedOverride":
						aircraft_AI.SpeedAdjustmentToT_OriginalSpeedOverride = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "ET_E":
						aircraft_AI.EvaluateTargets_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PTOE":
					case "PrimaryTargetOverrideExists":
						aircraft_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						aircraft_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "IgnorePlottedCourse":
					case "IPC":
					{
						bool num = Conversions.ToBoolean(xmlNode.InnerText);
						if (activeUnit_0.Doctrine != null)
						{
							activeUnit_0.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, (Doctrine._UseIgnorePlottedCourse)(-(Conversions.ToBoolean(xmlNode.InnerText) ? 1 : 0)));
						}
						if (num && !Information.IsNothing(activeUnit_0.AssignedMissionOrPackage()))
						{
							Mission mission = activeUnit_0.AssignedMissionOrPackage();
							if (mission.MissionClass == Mission._MissionClass.Patrol)
							{
								mission.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
							}
						}
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
			return aircraft_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100375", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Aircraft_AI result = new Aircraft_AI(ref activeUnit_0);
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
			if (PrimaryTarget_LastKnown_Lat != 0.0)
			{
				xmlWriter_0.WriteElementString("PrimaryTarget_LastKnown_Lat", XmlConvert.ToString(PrimaryTarget_LastKnown_Lat));
			}
			if (PrimaryTarget_LastKnown_Lon != 0.0)
			{
				xmlWriter_0.WriteElementString("PrimaryTarget_LastKnown_Lon", XmlConvert.ToString(PrimaryTarget_LastKnown_Lon));
			}
			if (PrimaryTarget_LastKnown_Altitude != 0f)
			{
				xmlWriter_0.WriteElementString("PrimaryTarget_LastKnown_Alt", XmlConvert.ToString(PrimaryTarget_LastKnown_Altitude));
			}
			if (TimeToNextTargetsEvaluation != 0f)
			{
				xmlWriter_0.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			}
			if (PrimaryTargetOverrideExists)
			{
				xmlWriter_0.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			}
			if (_FerryCycleLegIsOutbound)
			{
				xmlWriter_0.WriteElementString("FCLIO", _FerryCycleLegIsOutbound.ToString());
			}
			if (!EvaluateTargets_Enabled)
			{
				xmlWriter_0.WriteElementString("ET_E", "False");
			}
			if (!DeterminePrimaryTarget_Enabled)
			{
				xmlWriter_0.WriteElementString("DPT_E", "False");
			}
			if (AltitudePreset != 0)
			{
				xmlWriter_0.WriteElementString("AP", ((byte)AltitudePreset).ToString());
			}
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
				try
				{
					foreach (TargetingEntry value in _TargetList.Values)
					{
						if (!Information.IsNothing(value.Target.ActualUnit))
						{
							xmlWriter_0.WriteRaw(value.ToXML(m_EventVal.GetUnitSide()));
						}
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
				finally
				{
					xmlWriter_0.WriteEndElement();
				}
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
			if (!Information.IsNothing(TimeToNextSpeedAdjustmentForToTEvaluation))
			{
				xmlWriter_0.WriteElementString("TimeToNextSpeedAdjustmentForToTEvaluation", XmlConvert.ToString(TimeToNextSpeedAdjustmentForToTEvaluation.Value));
			}
			if (!Information.IsNothing(SpeedAdjustmentToT_OriginalSpeed))
			{
				xmlWriter_0.WriteElementString("SpeedAdjustmentToT_OriginalSpeed", XmlConvert.ToString(SpeedAdjustmentToT_OriginalSpeed.Value));
			}
			if (!Information.IsNothing(SpeedAdjustmentToT_OriginalSpeedOverride))
			{
				xmlWriter_0.WriteElementString("SpeedAdjustmentToT_OriginalSpeedOverride", XmlConvert.ToString(SpeedAdjustmentToT_OriginalSpeedOverride.Value));
			}
			if (!Information.IsNothing(SpeedAdjustmentToT_OriginalThrottle))
			{
				xmlWriter_0.WriteElementString("SpeedAdjustmentToT_OriginalThrottle", Conversions.ToString((byte)SpeedAdjustmentToT_OriginalThrottle.Value));
			}
			if (!Information.IsNothing(SpeedAdjustmentToT_OriginalThrottlePreset))
			{
				xmlWriter_0.WriteElementString("SpeedAdjustmentToT_OriginalThrottlePreset", Conversions.ToString((byte)SpeedAdjustmentToT_OriginalThrottlePreset.Value));
			}
			if (IsPerformingSpeedAdjustmentToT)
			{
				xmlWriter_0.WriteElementString("IsPerformingSpeedAdjustmentToT", IsPerformingSpeedAdjustmentToT.ToString());
			}
			if (LeadMustSlowDownDueToBingo)
			{
				xmlWriter_0.WriteElementString("LeadMustSlowDownDueToBingo", LeadMustSlowDownDueToBingo.ToString());
			}
			if (base.PrimaryPickupTarget != null)
			{
				xmlWriter_0.WriteElementString("PrimaryPickupTarget", _PrimaryPickupTarget.ObjectID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100374", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Aircraft_AI(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		_ParameterObserver = new Tuple<Mount, float, bool>(null, -1f, item3: false);
		m_ValObserver = new ConcurrentHashSet<string>();
	}

	private void FillFacade(Contact contact_0)
	{
		double num = Module_Unit.GrazingAngleToUnit(contact_0, m_EventVal);
		m_EventVal.DesiredPitch = (float)num;
	}

	private void CalculateFacade(Contact contact_0)
	{
		double num = Module_Unit.GrazingAngleToUnit(m_EventVal, contact_0);
		m_EventVal.DesiredPitch = (float)num;
	}

	public override void ManouverAgainstPrimaryThreat(float float_0)
	{
		if (GetAircraft().Crew == 0 && !GetAircraft().CommStuff.IsConnectedToSideNetwork && !GetAircraft().IsRTB)
		{
			return;
		}
		try
		{
			double num = Math.Round(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), _PrimaryThreat.GetLatitude(), _PrimaryThreat.GetLongitude()), 0);
			if (double.IsNaN(num))
			{
				return;
			}
			if (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				GetAircraft().AirOps.DisconnectFromTanker();
			}
			switch (_PrimaryThreat.Type)
			{
			case Contact_Base.ContactType.Missile:
				if (m_EventVal.ETA_To_Unit(PrimaryThreat) < 15f)
				{
					bool flag = false;
					if (_PrimaryThreat.ActualUnit != null && _PrimaryThreat.ActualUnit.IsMissile)
					{
						Weapon weapon = (Weapon)_PrimaryThreat.ActualUnit;
						if (weapon.SensorProvidingFireControlForMe == null)
						{
							if (weapon.DataLinkParent != null)
							{
								ActiveUnit dataLinkParent = weapon.DataLinkParent;
								IEnumerable<Contact> source = from theC in Module_ActiveUnit_Sensory.ListTokenizer(GetAircraft().Sensory)
									where Operators.CompareString(theC.ActualUnit.ObjectID, dataLinkParent?.ObjectID, TextCompare: false) == 0
									select theC;
								if (source.Count() > 0)
								{
									BeamThreat((int)Math.Round(Module_Unit.BearingToUnit_True(GetAircraft(), source.ElementAtOrDefault(0))));
									CalculateFacade(PrimaryThreat);
								}
								flag = true;
							}
						}
						else
						{
							Sensor sensorProvidingFireControlForMe = weapon.SensorProvidingFireControlForMe;
							if ((sensorProvidingFireControlForMe.Codes.Doppler_LDSD_Full || sensorProvidingFireControlForMe.Codes.Doppler_LDSD_Limited) && !sensorProvidingFireControlForMe.Codes.PESA && !sensorProvidingFireControlForMe.Codes.AESA && !sensorProvidingFireControlForMe.Codes.FrequencyAgile)
							{
								ActiveUnit parentPlatform = sensorProvidingFireControlForMe.ParentPlatform;
								IEnumerable<Contact> source2 = from theC in Module_ActiveUnit_Sensory.ListTokenizer(GetAircraft().Sensory)
									where Operators.CompareString(theC.ActualUnit.ObjectID, parentPlatform?.ObjectID, TextCompare: false) == 0
									select theC;
								if (source2.Count() > 0)
								{
									BeamThreat((int)Math.Round(Module_Unit.BearingToUnit_True(GetAircraft(), source2.ElementAtOrDefault(0))));
									CalculateFacade(PrimaryThreat);
								}
								flag = true;
							}
						}
					}
					if (!flag)
					{
						BeamThreat((int)Math.Round(num));
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
						CalculateFacade(PrimaryThreat);
					}
				}
				else
				{
					int int_2 = (int)Math.Round(num);
					OutrunThreat(ref int_2);
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					FillFacade(PrimaryThreat);
				}
				break;
			case Contact_Base.ContactType.Air:
				if (IsTargetingThisContact(_PrimaryThreat))
				{
					Contact primaryThreat = _PrimaryThreat;
					bool? nullable_ = null;
					double double_ = primaryThreat.GetLongitude(nullable_);
					Contact primaryThreat2 = _PrimaryThreat;
					bool? nullable_2 = null;
					double double_2 = primaryThreat2.GetLatitude(nullable_2);
					double double_3 = 0.5;
					float float_ = Math2.UpdateClass(_PrimaryThreat.CurrentHeading + 180f);
					double double_4 = 0.0;
					double double_5 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_4, ref double_5, ref double_3, ref float_);
					primaryThreat2.SetLatitude(nullable_2, double_2);
					primaryThreat.SetLongitude(nullable_, double_);
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(m_EventVal, double_5, double_4));
				}
				else
				{
					float num2 = 2f;
					if (Module_Unit.RangeToUnit_Horiz(GetAircraft(), _PrimaryThreat) <= num2)
					{
						BeamThreat((int)Math.Round(num));
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					}
					else
					{
						int int_ = (int)Math.Round(num);
						OutrunThreat(ref int_);
					}
				}
				break;
			}
			byte? b = (byte?)GetAircraft().Doctrine.GetJettison(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				GetAircraft().Weaponry.JettisonOrdnance(bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: false, bool_6: false, bool_7: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100376", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DeterminePrimaryTarget(float float_0, bool bool_0, bool bool_1)
	{
		if (RunFacade(float_0) || !DeterminePrimaryTarget_Enabled)
		{
			return;
		}
		try
		{
			if (m_EventVal == null)
			{
				return;
			}
			Contact closestWeaponTarget = m_EventVal.ClosestWeaponTarget;
			if (closestWeaponTarget != null)
			{
				PrimaryTarget = closestWeaponTarget;
				return;
			}
			if (!m_EventVal.IsRTB_Or_CalledOff)
			{
				if (GetAircraft().WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || GetAircraft().WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun)
				{
					if (!GetAircraft().IsGroupLead())
					{
						PrimaryTarget = null;
						return;
					}
					ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = GetAircraft().GetParentGroup().Weaponry.IsWinchesterOrShotgun();
					if (activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun)
					{
						PrimaryTarget = null;
						return;
					}
				}
				if (PrimaryTarget != null && TargetIsWasteOfAmmo(PrimaryTarget))
				{
					PrimaryTarget = null;
				}
				if (m_ExpressionObserver == null)
				{
					m_ExpressionObserver = new List<Contact>();
				}
				else
				{
					m_ExpressionObserver.Clear();
				}
				Contact[] targets_ReadOnly = base.Targets_ReadOnly;
				if (GetAircraft().Loadout != null && GetAircraft().Loadout.Role == Loadout.LoadoutRole.AntiSatellite_Intercept)
				{
					m_ExpressionObserver = targets_ReadOnly.Where((Contact theC) => theC.Type == Contact_Base.ContactType.Orbital).ToList();
				}
				else
				{
					Contact[] array = targets_ReadOnly;
					Contact[] array2 = array;
					foreach (Contact contact in array2)
					{
						if (contact.IsAir_GuidedWeapon_Contact || contact.IsShipContact || contact.IsSubmergedContact || contact.IsGroundContact)
						{
							m_ExpressionObserver.Add(contact);
						}
					}
				}
				for (int i = m_ExpressionObserver.Count - 1; i >= 0; i += -1)
				{
					if ((m_ExpressionObserver[i].GetStance(m_EventVal.GetUnitSide()) == Misc.PostureStance.Friendly || m_ExpressionObserver[i].GetStance(m_EventVal.GetUnitSide()) == Misc.PostureStance.Neutral) && (m_ExpressionObserver[i].IDStatus == Contact_Base.IdentificationStatus.PreciseID || m_ExpressionObserver[i].IDStatus == Contact_Base.IdentificationStatus.KnownClass))
					{
						m_ExpressionObserver.RemoveAt(i);
					}
				}
				if (m_ExpressionObserver.Count == 0)
				{
					PrimaryTarget = null;
					return;
				}
				if (dispatcherObserver == null)
				{
					dispatcherObserver = new List<Contact>();
				}
				else
				{
					dispatcherObserver.Clear();
				}
				if (GetAircraft().Loadout != null && GetAircraft().Loadout.Role == Loadout.LoadoutRole.AntiSatellite_Intercept)
				{
					foreach (Contact item in m_ExpressionObserver)
					{
						Contact contact_ = item;
						switch (TargetingBehaviorForThisTarget(contact_))
						{
						case TargetingEntry._TargetingBehavior.ManualTargeted:
							if (contact_.Type == Contact_Base.ContactType.Orbital)
							{
								dispatcherObserver.Add(contact_);
							}
							break;
						case TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
							if (contact_.Type == Contact_Base.ContactType.Orbital && CalculateClient(ref contact_))
							{
								dispatcherObserver.Add(contact_);
							}
							break;
						}
					}
				}
				else
				{
					foreach (Contact item2 in m_ExpressionObserver)
					{
						Contact contact_2 = item2;
						switch (TargetingBehaviorForThisTarget(contact_2))
						{
						case TargetingEntry._TargetingBehavior.ManualTargeted:
							if (contact_2.IsAir_GuidedWeapon_Contact || contact_2.IsShipContact || contact_2.IsSubmergedContact || contact_2.IsGroundContact)
							{
								dispatcherObserver.Add(contact_2);
							}
							break;
						case TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
							if ((contact_2.IsAir_GuidedWeapon_Contact || contact_2.IsShipContact || contact_2.IsSubmergedContact || contact_2.IsGroundContact) && CalculateClient(ref contact_2))
							{
								dispatcherObserver.Add(contact_2);
							}
							break;
						}
					}
				}
				if (dispatcherObserver.Count <= 0)
				{
					if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && !m_EventVal.Weaponry.IsGuidingWeaponsInAir())
					{
						PrimaryTarget = null;
						return;
					}
					if (m_EventVal.IsOnActiveStrike)
					{
						if (m_EventVal.AI.IsEscort)
						{
							Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
							ActiveUnit eventVal = m_EventVal;
							List<Contact> expressionObserver = m_ExpressionObserver;
							Mission._FlightSize _FlightSize_ = 1;
							int int_ = strike.ExcludeValue(ref _FlightSize_, ref strike.Escort_NumberOfFlights_Engage);
							_FlightSize_ = 1;
							ActiveUnit_AI.DeterminePrimaryTarget_PatrolAndEscortLogic(eventVal, expressionObserver, int_, strike.ExcludeValue(ref _FlightSize_, ref strike.Escort_NumberOfFlights_Investigate), strike.Escort_WingmanEngageDistance, float_0);
						}
						else
						{
							Strike Local_myStrike = (Strike)m_EventVal.AssignedMissionOrPackage();
							if (Local_myStrike.TargetCount <= 0)
							{
								if (Local_myStrike.RTB_When_Target_Destroyed && Local_myStrike.TargetCount == 0)
								{
									PrimaryTarget = null;
									return;
								}
							}
							else if (PrimaryTarget == null || (!Local_myStrike.SpecificTargets.Contains(PrimaryTarget) && Local_myStrike.FocusEntirelyOnStrikeTargets))
							{
								List<Contact> list;
								if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
								{
									new List<Contact>();
									list = (from contact_0 in m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, m_ExpressionObserver).Where(delegate(Contact theC)
										{
											if (theC.GetIsSpecificTargetForThisStrike(Local_myStrike))
											{
												ActiveUnit_Weaponry weaponry4 = m_EventVal.Weaponry;
												Doctrine doctrine4 = m_EventVal.Doctrine;
												string string_6 = "";
												int int_7 = 0;
												return weaponry4.PopConsumer(theC, bool_1: true, doctrine4, ref string_6, ref int_7);
											}
											return false;
										})
										orderby contact_0.GetApparentSize(m_EventVal.ParentScen) descending
										select contact_0).ToList();
								}
								else
								{
									list = (from contact_0 in m_ExpressionObserver.Where(delegate(Contact theC)
										{
											if (theC.GetIsSpecificTargetForThisStrike(Local_myStrike))
											{
												ActiveUnit_Weaponry weaponry3 = m_EventVal.Weaponry;
												Doctrine doctrine3 = m_EventVal.Doctrine;
												string string_5 = "";
												int int_6 = 0;
												return weaponry3.PopConsumer(theC, bool_1: true, doctrine3, ref string_5, ref int_6);
											}
											return false;
										})
										orderby contact_0.GetApparentSize(m_EventVal.ParentScen) descending
										select contact_0).ToList();
								}
								int num = list.Count - 1;
								for (int j = 0; j <= num; j++)
								{
									if (!TargetIsWasteOfAmmo(list[j]))
									{
										PrimaryTarget = list[j];
										if (((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All) | ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit) & m_EventVal.GetUnitSide().SelectedUnits.Contains(m_EventVal))) && m_EventVal.GetUnitSide() != null && m_EventVal.GetUnitSide().IsHumanControlled)
										{
											Notification_Bark.Create(m_EventVal, "Switching to opportunity target: " + list[j].Name, Color.Red, bool_0: true, bool_1: true, 2f);
										}
										return;
									}
								}
							}
							if (Local_myStrike.Type == Strike.StrikeType.Air_Intercept)
							{
								Contact contact2 = null;
								Contact contact3 = null;
								if (_ListenerObserver == null)
								{
									_ListenerObserver = new List<ActiveUnit>();
								}
								else
								{
									_ListenerObserver.Clear();
								}
								foreach (ActiveUnit item3 in Misc.EnableRequest(m_EventVal.GetUnitSide().Units))
								{
									if (!item3.IsGroup && item3.IsOperating())
									{
										_ListenerObserver.Add(item3);
									}
								}
								List<Contact> source = m_ExpressionObserver;
								Contact contact4 = null;
								if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
								{
									source = m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, m_ExpressionObserver);
									contact4 = m_ExpressionObserver.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)).First();
								}
								foreach (Contact Local_theT2 in source.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)).ToList())
								{
									if ((Local_myStrike.MinResponseRadius_Aircraft > 0 && !(Module_Unit.RangeToUnit_Horiz(m_EventVal, Local_theT2) >= (float)Local_myStrike.MinResponseRadius_Aircraft)) || (Local_myStrike.MaxResponseRadius_Aircraft > 0 && !(Module_Unit.RangeToUnit_Horiz(m_EventVal, Local_theT2) <= (float)Local_myStrike.MaxResponseRadius_Aircraft)))
									{
										continue;
									}
									if (contact3 == null)
									{
										ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
										Contact contact_3 = Local_theT2;
										Doctrine doctrine = m_EventVal.Doctrine;
										string string_ = "";
										int int_2 = 0;
										if (weaponry.PopConsumer(contact_3, bool_1: true, doctrine, ref string_, ref int_2))
										{
											contact3 = Local_theT2;
										}
									}
									if (_ConfigObserver == null)
									{
										_ConfigObserver = new List<ActiveUnit>();
									}
									else
									{
										_ConfigObserver.Clear();
									}
									foreach (ActiveUnit item4 in _ListenerObserver)
									{
										if (item4.AI.IsTargetingThisContact(Local_theT2))
										{
											_ConfigObserver.Add(item4);
										}
									}
									if (_ConfigObserver.Count != 0)
									{
										_ConfigObserver = _ConfigObserver.OrderBy((ActiveUnit theAU) => Module_Unit.RangeToUnit_Horiz_Angular(theAU, Local_theT2)).ToList();
										if (_ConfigObserver[0] == m_EventVal)
										{
											contact2 = Local_theT2;
											break;
										}
										continue;
									}
									contact2 = Local_theT2;
									break;
								}
								if (contact2 == null)
								{
									if ((Local_myStrike.MinResponseRadius_Aircraft > 0 || Local_myStrike.MaxResponseRadius_Aircraft > 0) && contact3 == null && contact4 == null)
									{
										PrimaryTarget = null;
									}
									else
									{
										source = m_ExpressionObserver;
										if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
										{
											source = m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, m_ExpressionObserver);
										}
										List<Contact> list2 = ((!m_EventVal.CommStuff.IsConnectedToSideNetwork) ? (from theC0 in source
											select (theC0) into contact_0
											orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
											select contact_0).ToList() : (GameGeneral.infoClient ? (from theC0 in source
											select (theC0) into contact_0
											orderby (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal, bool_1: false)
												where theAC.IsAircraft
												select theAC).Count(), Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
											select contact_0).ToList() : (from theC0 in source.AsParallel()
											select (theC0) into contact_0
											orderby (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal)
												where theAC.IsAircraft
												select theAC).Count(), Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
											select contact_0).ToList()));
										PrimaryTarget = list2[0];
									}
								}
								else
								{
									PrimaryTarget = contact2;
								}
							}
							else
							{
								if (PrimaryTarget != null)
								{
									Contact primaryTarget = PrimaryTarget;
									Mission mission_ = GetAircraft().AssignedMissionOrPackage();
									Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									string string_2 = "";
									int int_3 = 0;
									if (ContactIsRelevantToMission(primaryTarget, mission_, shootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_2, ref int_3))
									{
										goto IL_187d;
									}
								}
								if (GetAircraft().Navigator.HasFlightPlan && !GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
								{
									PrimaryTarget = null;
								}
								else
								{
									List<Contact> list3 = (from contact_0 in m_ExpressionObserver.Where(delegate(Contact contact_0)
										{
											if (!contact_0.IsAir_Missile_Orbital_Contact)
											{
												Mission mission_3 = GetAircraft().AssignedMissionOrPackage();
												Doctrine._UseShootTourists? shootTourists2 = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
												string string_4 = "";
												int int_5 = 0;
												if (ContactIsRelevantToMission(contact_0, mission_3, shootTourists2, bool_0: false, bool_1: false, bool_2: true, null, ref string_4, ref int_5))
												{
													ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
													Doctrine doctrine2 = m_EventVal.Doctrine;
													string_4 = "";
													int_5 = 0;
													return weaponry2.PopConsumer(contact_0, bool_1: true, doctrine2, ref string_4, ref int_5);
												}
											}
											return false;
										})
										orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
										select contact_0).ToList();
									if (list3.Count > 0)
									{
										if ((Local_myStrike.Type == Strike.StrikeType.Land_Strike || Local_myStrike.Type == Strike.StrikeType.Maritime_Strike) && bool_1 && GetAircraft().Navigator.HasFlight)
										{
											if (GetAircraft().Navigator.HasFlightPlan)
											{
												if (GetAircraft().Doctrine.CallRepository(GetAircraft().ParentScen))
												{
													list3 = GetAircraft().Doctrine.ValidateRepository(GetAircraft().ParentScen, list3);
												}
												Aircraft obj = (GetAircraft().IsGroupMember() ? ((Aircraft)GetAircraft().GetParentGroup().GroupLead) : GetAircraft());
												Mission mission_2 = m_EventVal.AssignedMissionOrPackage();
												Aircraft_AI aI = obj.AI;
												ref Scenario parentScen = ref m_EventVal.ParentScen;
												ActiveUnit eventVal2;
												Side side_ = (eventVal2 = m_EventVal).GetUnitSide();
												Aircraft_Navigator navigator;
												Mission.Flight flight_ = (navigator = obj.Navigator).GetFlight();
												List<Contact> list4;
												Contact contact_4 = (list4 = list3)[0];
												int minResponseRadius_Aircraft = Local_myStrike.MinResponseRadius_Aircraft;
												int maxResponseRadius_Aircraft = Local_myStrike.MaxResponseRadius_Aircraft;
												Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = Local_myStrike.Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
												bool launchMissionWithoutTankersInPlace = m_EventVal.AssignedMissionOrPackage().LaunchMissionWithoutTankersInPlace;
												Mission._RadarBehaviour radarBehaviour = Local_myStrike.RadarBehaviour;
												bool usePlanner = Local_myStrike.UsePlanner;
												float float_ = 0f;
												bool bool_2 = true;
												float float_2 = 0f;
												float float_3 = 0f;
												string string_3 = null;
												bool num2 = aI.SetupClient(ref parentScen, ref side_, ref mission_2, ref flight_, ref contact_4, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, useReplenishment, launchMissionWithoutTankersInPlace, radarBehaviour, bool_1: true, bool_2: true, bool_3: true, usePlanner, ref float_, ref string_3, bool_5: false, ref bool_2, bool_7: false, ref float_2, ref float_3, bool_8: false, list3[0], bool_9: true, mission_2.TakeOffTime, mission_2.TimeOnTarget, bool_10: false, bool_11: true);
												list4[0] = contact_4;
												navigator.SetFlight(bool_1: true, flight_);
												eventVal2.SetUnitSide(bool_0: false, side_);
												if (num2)
												{
													PrimaryTarget = list3[0];
												}
												else
												{
													if (!string.IsNullOrEmpty(string_3))
													{
														string text = "";
														if (GetAircraft().IsAircraft && Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
														{
															text = " (" + GetAircraft().UnitClass + ")";
														}
														GetAircraft().ParentScen.AddMessage("飞机" + GetAircraft().Name + text + "与挂载" + GetAircraft().LoadoutName + "不允许攻击新目标。原因：" + string_3, GetAircraft().Name + " 不允许交战", LoggedMessage.MessageType.AirOps, 0, null, GetAircraft().GetUnitSide(), new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
													}
													PrimaryTarget = null;
												}
											}
											else
											{
												if (GetAircraft().Doctrine.CallRepository(GetAircraft().ParentScen))
												{
													list3 = (from contact_0 in GetAircraft().Doctrine.ViewRepository(GetAircraft().ParentScen, list3)
														orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
														select contact_0).ToList();
												}
												PrimaryTarget = list3[0];
											}
										}
										else
										{
											if (GetAircraft().Doctrine.CallRepository(GetAircraft().ParentScen))
											{
												list3 = (from contact_0 in GetAircraft().Doctrine.ViewRepository(GetAircraft().ParentScen, list3)
													orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
													select contact_0).ToList();
											}
											PrimaryTarget = list3[0];
										}
									}
								}
							}
						}
					}
					else if (m_EventVal.IsOnActivePatrol)
					{
						Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (((Patrol)m_EventVal.AssignedMissionOrPackage()).Type == GlobalVariables.PatrolType.SEAD)
						{
							List<Contact> expressionObserver2 = m_ExpressionObserver;
							Mission._FlightSize _FlightSize_2 = 1;
							DeterminePrimaryTarget_SEAD_Prioritize(expressionObserver2, patrol.ExcludeValue(ref _FlightSize_2, ref patrol.NumberOfFlights_Engage), patrol.WingmanEngageDistance, float_0);
						}
						else
						{
							ActiveUnit eventVal3 = m_EventVal;
							List<Contact> expressionObserver3 = m_ExpressionObserver;
							Mission._FlightSize _FlightSize_3 = 1;
							int int_4 = patrol.ExcludeValue(ref _FlightSize_3, ref patrol.NumberOfFlights_Engage);
							_FlightSize_3 = 1;
							ActiveUnit_AI.DeterminePrimaryTarget_PatrolAndEscortLogic(eventVal3, expressionObserver3, int_4, patrol.ExcludeValue(ref _FlightSize_3, ref patrol.NumberOfFlights_Investigate), patrol.WingmanEngageDistance, float_0);
						}
					}
					else if (GetAircraft().Loadout != null)
					{
						if (GetAircraft().Loadout.IsAAW)
						{
							Contact contact5 = null;
							if (_ListenerObserver == null)
							{
								_ListenerObserver = new List<ActiveUnit>();
							}
							else
							{
								_ListenerObserver.Clear();
							}
							foreach (ActiveUnit unit in m_EventVal.GetUnitSide().Units)
							{
								if (!unit.IsGroup && unit.IsOperating())
								{
									_ListenerObserver.Add(unit);
								}
							}
							List<Contact> list5 = m_ExpressionObserver;
							if (GetAircraft().Doctrine.CallRepository(GetAircraft().ParentScen))
							{
								list5 = GetAircraft().Doctrine.ValidateRepository(GetAircraft().ParentScen, m_ExpressionObserver);
							}
							foreach (Contact Local_theT in list5)
							{
								List<ActiveUnit> list6 = new List<ActiveUnit>();
								foreach (ActiveUnit item5 in _ListenerObserver)
								{
									if (item5.AI.IsTargetingThisContact(Local_theT))
									{
										list6.Add(item5);
									}
								}
								if (list6.Count != 0)
								{
									list6 = list6.OrderBy((ActiveUnit theAU) => Module_Unit.RangeToUnit_Horiz_Angular(theAU, Local_theT)).ToList();
									if (list6[0] == m_EventVal)
									{
										contact5 = Local_theT;
										break;
									}
									continue;
								}
								contact5 = Local_theT;
								break;
							}
							if (contact5 == null)
							{
								list5 = m_ExpressionObserver;
								if (GetAircraft().Doctrine.CallRepository(GetAircraft().ParentScen))
								{
									list5 = GetAircraft().Doctrine.ViewRepository(GetAircraft().ParentScen, m_ExpressionObserver);
								}
								List<Contact> list7 = (m_EventVal.CommStuff.IsConnectedToSideNetwork ? (GameGeneral.infoClient ? (from theC in list5
									select (theC) into contact_0
									orderby (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal, bool_1: false)
										where theAC.IsAircraft
										select theAC).Count(), Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
									select contact_0).ToList() : (from theC in list5.AsParallel()
									select (theC) into contact_0
									orderby (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal)
										where theAC.IsAircraft
										select theAC).Count(), Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
									select contact_0).ToList()) : (GameGeneral.infoClient ? (from theC in list5
									select (theC) into contact_0
									orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
									select contact_0).ToList() : (from theC in list5.AsParallel()
									select (theC) into contact_0
									orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
									select contact_0).ToList()));
								PrimaryTarget = list7[0];
							}
							else
							{
								PrimaryTarget = contact5;
							}
						}
						else
						{
							List<Contact> list8 = (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen) ? (from theC in m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, m_ExpressionObserver)
								where !theC.IsAir_Missile_Orbital_Contact
								select theC into contact_0
								orderby contact_0.GetApparentSize(m_EventVal.ParentScen) descending
								select contact_0).ToList() : (from theC in m_ExpressionObserver
								where !theC.IsAir_Missile_Orbital_Contact
								select theC into contact_0
								orderby contact_0.GetApparentSize(m_EventVal.ParentScen) descending
								select contact_0).ToList());
							if (list8.Count > 0)
							{
								PrimaryTarget = list8[0];
							}
						}
					}
					goto IL_187d;
				}
				if (dispatcherObserver.Count == 1)
				{
					PrimaryTarget = dispatcherObserver[0];
					return;
				}
				List<Contact> list9 = (from theC in dispatcherObserver
					select (theC) into contact_0
					orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
					select contact_0).ToList();
				PrimaryTarget = list9[0];
				return;
			}
			PrimaryTarget = null;
			return;
			IL_187d:
			if (m_EventVal == null)
			{
				return;
			}
			if (m_RegistryObserver == null)
			{
				m_RegistryObserver = new List<Contact>();
			}
			else
			{
				m_RegistryObserver.Clear();
			}
			foreach (Contact item6 in m_ExpressionObserver)
			{
				if (m_EventVal == null)
				{
					break;
				}
				if (_Threats != null && _Threats.Contains(item6) && Module_Unit.RangeToUnit_Slant(m_EventVal, item6) < 5f)
				{
					m_RegistryObserver.Add(item6);
				}
				if (m_RegistryObserver.Count == 1)
				{
					PrimaryTarget = m_RegistryObserver[0];
				}
				double num3 = 20000.0;
				foreach (Contact item7 in m_RegistryObserver)
				{
					double num4 = Module_Unit.RangeToUnit_Slant(m_EventVal, item7);
					if (num4 < num3)
					{
						PrimaryTarget = item7;
						num3 = num4;
					}
				}
			}
			m_RegistryObserver = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100377", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private void PopFacade(double double_0, Doctrine._UnderwayRefuelAndReplenishmentSelection _UnderwayRefuelAndReplenishmentSelection_0)
	{
		if (GetAircraft().IsGroupWingman() || (!GetAircraft().BoomRefuelling && !GetAircraft().ProbeRefuelling))
		{
			return;
		}
		byte? b = (byte?)GetAircraft().Doctrine.GetUseReplenishment(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			return;
		}
		try
		{
			float num = float.MaxValue;
			ActiveUnit activeUnit = m_EventVal;
			if (m_EventVal.IsGroupMember())
			{
				foreach (ActiveUnit item in new List<ActiveUnit>(m_EventVal.GetParentGroup().Units.Values))
				{
					if ((float)item.FuelCapacityCurrent < num)
					{
						num = item.FuelCapacityCurrent;
						activeUnit = item;
					}
				}
			}
			ActiveUnit activeUnit2 = activeUnit;
			double double_ = 0.0;
			double double_2 = 0.0;
			if (activeUnit2.FuelPercent(ref double_, ref double_2, bool_0: true) < double_0)
			{
				GeoPoint geoPoint_ = LoginClient();
				bool bool_ = false;
				Aircraft_AirOps airOps = GetAircraft().AirOps;
				bool bool_2 = false;
				ActiveUnit activeUnit_ = null;
				List<Mission> list_ = null;
				string string_ = "";
				bool bool_3 = false;
				airOps.AssetProxy(geoPoint_, _UnderwayRefuelAndReplenishmentSelection_0, ref bool_2, bool_1: false, ref activeUnit_, ref list_, ref string_, ref bool_3, ref bool_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100378", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InstantiateFacade(Doctrine._UnderwayRefuelAndReplenishmentSelection _UnderwayRefuelAndReplenishmentSelection_0)
	{
		byte? b = (byte?)GetAircraft().Doctrine.GetUseReplenishment(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault() || (!GetAircraft().BoomRefuelling && !GetAircraft().ProbeRefuelling))
		{
			return;
		}
		try
		{
			Aircraft_AirOps airOps = GetAircraft().AirOps;
			ActiveUnit actualDestinationHost = airOps.ActualDestinationHost;
			if (!Information.IsNothing(actualDestinationHost))
			{
				ActiveUnit._ActiveUnitFuelState isBingoTowardsThisDestination = GetAircraft().GetIsBingoTowardsThisDestination(actualDestinationHost, null, GetAircraft().Doctrine.GetBingoJoker(GetAircraft().ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
				if (isBingoTowardsThisDestination == ActiveUnit._ActiveUnitFuelState.IsBingo || isBingoTowardsThisDestination == ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					bool bool_ = false;
					bool bool_2 = false;
					ActiveUnit activeUnit_ = null;
					List<Mission> list_ = null;
					string string_ = "";
					bool bool_3 = true;
					airOps.AssetProxy(null, _UnderwayRefuelAndReplenishmentSelection_0, ref bool_2, bool_1: false, ref activeUnit_, ref list_, ref string_, ref bool_3, ref bool_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100379", "");
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
		try
		{
			if (m_EventVal == null)
			{
				return;
			}
			EvaluateUnitCargoStatus(float_0);
			WeaponThreat = null;
			Aircraft_AirOps airOps = GetAircraft().AirOps;
			if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.EmergencyLanding)
			{
				return;
			}
			if (airOps.A2AR_Destination != null && ((airOps.A2AR_Destination.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo) | (airOps.A2AR_Destination.FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker) | airOps.A2AR_Destination.IsRTB))
			{
				ActiveUnit_Navigator navigator = m_EventVal.Navigator;
				Waypoint[] gparam_ = navigator.PlottedCourse;
				ArrayExtensions.Clear(ref gparam_);
				navigator.PlottedCourse = gparam_;
				m_EventVal.Status = m_EventVal.predicateVal;
				return;
			}
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			bool flag = false;
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				flag = true;
			}
			else if (m_EventVal.IsGroupWingman() && m_EventVal.GetParentGroup().GroupLead != null)
			{
				m_EventVal.GetParentGroup().GroupLead.Navigator.HasNonPathfindPlottedCourse();
			}
			byte? b = (byte?)m_EventVal.Doctrine.GetAutoEvade(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (m_EventVal.ParentScen.AnyActiveWeaponEffectThreats)
				{
					Module_Unit.Unit unit = DetermineWeaponEffectThreat();
					if (unit != null)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects;
						WeaponThreat = unit;
						return;
					}
				}
				if (_PrimaryThreat == null)
				{
					if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
					{
						m_EventVal.Status = m_EventVal._SingletonVal;
					}
				}
				else if (m_EventVal.AssignedMissionOrPackage() == null || m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (!GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun && (!m_EventVal.IsGroupWingman() || Information.IsNothing(m_EventVal.IsGroupLead()) || !m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun)))
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || airOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel)
			{
				if (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && m_EventVal.GetParentGroup().GroupLead.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					m_EventVal.Status = m_EventVal.predicateVal;
					airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					return;
				}
				if (m_EventVal.GetIsBingoOrJoker(null, m_EventVal.Doctrine.GetBingoJoker(m_EventVal.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false)) == ActiveUnit._ActiveUnitFuelState.IsBingo)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					return;
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Refuelling && airOps.Condition == Aircraft_AirOps._AirOpsCondition.Refuelling)
			{
				return;
			}
			if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_Manual;
				return;
			}
			ActiveUnit eventVal = m_EventVal;
			Exception exception_ = null;
			if (Pathfinding.FindStub(eventVal, null, ref exception_))
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
				return;
			}
			if (m_EventVal.Navigator.HasPathfindingPlottedCourse && m_EventVal.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
			{
				m_EventVal.Status = m_EventVal._ExceptionVal;
			}
			if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse)
			{
				ActiveUnit eventVal2 = m_EventVal;
				double latitude = m_EventVal.GetLatitude();
				double longitude = m_EventVal.GetLongitude();
				int int_ = 0;
				bool bool_12 = true;
				bool bool_23 = true;
				List<ActiveUnit> list_ = null;
				string string_ = "";
				bool bool_25 = false;
				if (!eventVal2.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_12, bool_4: true, ref bool_23, null, null, ref list_, 0f, bool_6: false, bool_7: true, ref string_, ref bool_25))
				{
					if (m_EventVal.Navigator.HasPlottedCourse())
					{
						Waypoint waypoint = m_EventVal.Navigator.PlottedCourse[0];
						if (waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							ActiveUnit_Navigator navigator2 = m_EventVal.Navigator;
							double latitude2 = m_EventVal.GetLatitude();
							double longitude2 = m_EventVal.GetLongitude();
							list_ = null;
							Waypoint nearestAccessibleSpot = navigator2.GetNearestAccessibleSpot(latitude2, longitude2, ref list_);
							ActiveUnit eventVal3 = m_EventVal;
							double latitude3 = waypoint.Latitude;
							double longitude3 = waypoint.Longitude;
							int_ = 0;
							bool_25 = true;
							bool_23 = true;
							list_ = null;
							string_ = "";
							bool_12 = false;
							if (eventVal3.CanMoveToThisLocation(latitude3, longitude3, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_25, bool_4: true, ref bool_23, null, null, ref list_, 0f, bool_6: false, bool_7: true, ref string_, ref bool_12))
							{
								if (Module_Unit.RangeToPoint_Horiz_Angular(m_EventVal, nearestAccessibleSpot) + 0.2 < Module_Unit.RangeToPoint_Horiz_Angular(m_EventVal, waypoint))
								{
									ActiveUnit_Navigator navigator3 = m_EventVal.Navigator;
									Waypoint[] gparam_2 = navigator3.PlottedCourse;
									ArrayExtensions.Insert(ref gparam_2, 0, nearestAccessibleSpot);
									navigator3.PlottedCourse = gparam_2;
								}
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							}
							else
							{
								ActiveUnit_Navigator navigator4 = m_EventVal.Navigator;
								Waypoint[] gparam_3 = navigator4.PlottedCourse;
								ArrayExtensions.Insert(ref gparam_3, 0, nearestAccessibleSpot);
								navigator4.PlottedCourse = gparam_3;
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							}
							return;
						}
					}
					else
					{
						ActiveUnit_Navigator navigator5 = m_EventVal.Navigator;
						double latitude4 = m_EventVal.GetLatitude();
						double longitude4 = m_EventVal.GetLongitude();
						list_ = null;
						Waypoint nearestAccessibleSpot2 = navigator5.GetNearestAccessibleSpot(latitude4, longitude4, ref list_);
						if (!Information.IsNothing(nearestAccessibleSpot2))
						{
							ActiveUnit_Navigator navigator6 = m_EventVal.Navigator;
							Waypoint[] gparam_4 = navigator6.PlottedCourse;
							ArrayExtensions.Insert(ref gparam_4, 0, nearestAccessibleSpot2);
							navigator6.PlottedCourse = gparam_4;
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							return;
						}
					}
				}
			}
			if (m_EventVal.IsRTB_Or_CalledOff && (GetAircraft().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || GetAircraft().FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker) && (m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse || bool_0) && airOps.Condition != Aircraft_AirOps._AirOpsCondition.EmergencyLanding && airOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue && GetAircraft().FuelState_Destination != null && !GetAircraft().FuelState_Destination.IsAircraft)
			{
				float num = (float)GetAircraft().GetFuelEndurance(GetAircraft().ThrottleSetting, null, GetAircraft().DesiredSpeed, GetAircraft().GetCurrentAltitude()) * GetAircraft().DesiredSpeed / 3600f;
				if (GetAircraft().FuelState_DistanceToBase > Aircraft.EMERGENCY_LANDING_DISTANCE_NM && GetAircraft().FuelState_DistanceToBase > num && GetAircraft().RemoveFacade())
				{
					return;
				}
			}
			if (m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse || bool_0)
			{
				if (GetAircraft().FuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker)
				{
					ActiveUnit._ActiveUnitFuelState isBingoOrJoker = GetAircraft().GetIsBingoOrJoker(null, GetAircraft().Doctrine.GetBingoJoker(GetAircraft().ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
					if (((isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo || isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsJoker) && airOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue) | (m_EventVal.Navigator.HasFlightPlan && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Refuel))
					{
						bool flag12 = GetAircraft().Status == ActiveUnit._ActiveUnitStatus.RTB_Exhaustion || GetAircraft().Status == ActiveUnit._ActiveUnitStatus.RTB_Manual || GetAircraft().Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.RTB && m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.None) || GetAircraft().predicateVal == ActiveUnit._ActiveUnitStatus.RTB_Manual || GetAircraft().predicateVal == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || (GetAircraft().predicateVal == ActiveUnit._ActiveUnitStatus.RTB && m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.None);
						bool bool_26 = false;
						if (GetAircraft().FuelState != isBingoOrJoker)
						{
							GetAircraft().DisconnectTankerClients();
						}
						GetAircraft().FuelState = isBingoOrJoker;
						if (!m_EventVal.IsPaintingATarget && !m_EventVal.WillNeedToPaintATarget && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
						{
							GeoPoint geoPoint = LoginClient();
							if (flag12 | ((m_EventVal.Navigator.HasFlightPlan && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Refuel) & !RefueledInThisLeg))
							{
								bool bool_27 = false;
								ActiveUnit activeUnit_ = null;
								List<Mission> list_2 = null;
								string string_5 = "";
								bool bool_28 = true;
								if (airOps.AssetProxy(geoPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref bool_27, bool_1: false, ref activeUnit_, ref list_2, ref string_5, ref bool_28, ref bool_26))
								{
									return;
								}
							}
							else if (Information.IsNothing(geoPoint))
							{
								if (GetAircraft().Status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion && GetAircraft().Status != ActiveUnit._ActiveUnitStatus.RTB_Manual && GetAircraft().Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && GetAircraft().Status != ActiveUnit._ActiveUnitStatus.RTB && GetAircraft().predicateVal != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && GetAircraft().predicateVal != ActiveUnit._ActiveUnitStatus.RTB && GetAircraft().FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && GetAircraft().FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
								{
									Doctrine._UnderwayRefuelAndReplenishmentSelection value = m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
									bool bool_29 = false;
									ActiveUnit activeUnit_2 = null;
									List<Mission> list_3 = null;
									string string_6 = "";
									bool bool_30 = false;
									if (airOps.AssetProxy(null, value, ref bool_29, bool_1: false, ref activeUnit_2, ref list_3, ref string_6, ref bool_30, ref bool_26))
									{
										return;
									}
								}
								else
								{
									bool bool_2 = false;
									ActiveUnit activeUnit_3 = null;
									List<Mission> list_4 = null;
									string string_7 = "";
									bool bool_3 = true;
									if (airOps.AssetProxy(null, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref bool_2, bool_1: false, ref activeUnit_3, ref list_4, ref string_7, ref bool_3, ref bool_26))
									{
										return;
									}
								}
								if (!bool_26 && m_EventVal.Navigator.HasFlightPlan && m_EventVal.Navigator.PlottedCourse.Count() > 0 && (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (m_EventVal.Navigator.HasFlight && m_EventVal.Navigator.GetFlight().GetStatus(m_EventVal.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol || m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)) || m_EventVal.AI.IsEscort))))
								{
									m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
									Doctrine doctrine = m_EventVal.Doctrine;
									Scenario parentScen = m_EventVal.ParentScen;
									bool bool_4 = true;
									Doctrine parentDoctrine = doctrine.GetParentDoctrine(parentScen, ref bool_4);
									m_EventVal.Doctrine.SetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, parentDoctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
									return;
								}
							}
							else
							{
								bool? flag23;
								bool? flag28;
								if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry && m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0)
								{
									b = (byte?)m_EventVal.Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
									flag23 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
									flag28 = (!flag23) ?? flag23;
									if (flag28.GetValueOrDefault(true))
									{
										bool? flag29;
										if (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead))
										{
											b = (byte?)m_EventVal.GetParentGroup().GroupLead.Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
											flag29 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
										}
										else
										{
											flag29 = false;
										}
										flag23 = flag29;
										if (((!flag23) ?? flag23).GetValueOrDefault() && flag28.HasValue)
										{
											float num12 = float.MaxValue;
											ActiveUnit activeUnit = m_EventVal;
											if (m_EventVal.IsGroupMember())
											{
												foreach (ActiveUnit value7 in m_EventVal.GetParentGroup().Units.Values)
												{
													if ((float)value7.FuelCapacityCurrent < num12)
													{
														num12 = value7.FuelCapacityCurrent;
														activeUnit = value7;
													}
												}
											}
											ActiveUnit activeUnit2 = activeUnit;
											double double_ = 0.0;
											double double_2 = 0.0;
											if (activeUnit2.FuelPercent(ref double_, ref double_2, bool_0: true) > (double)(float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0))
											{
												return;
											}
										}
									}
								}
								b = (byte?)m_EventVal.Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
								flag23 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
								flag28 = (!flag23) ?? flag23;
								if (flag28.GetValueOrDefault(true))
								{
									bool? flag30;
									if (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead))
									{
										b = (byte?)m_EventVal.GetParentGroup().GroupLead.Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
										flag30 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
									}
									else
									{
										flag30 = false;
									}
									flag23 = flag30;
									if (((!flag23) ?? flag23).GetValueOrDefault() && flag28.HasValue)
									{
										Doctrine._UnderwayRefuelAndReplenishmentSelection value4 = m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
										bool bool_5 = false;
										ActiveUnit activeUnit_4 = null;
										List<Mission> list_5 = null;
										string string_8 = "";
										bool bool_6 = false;
										if (airOps.AssetProxy(geoPoint, value4, ref bool_5, bool_1: false, ref activeUnit_4, ref list_5, ref string_8, ref bool_6, ref bool_26))
										{
											return;
										}
									}
								}
								if (!bool_26)
								{
									if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
									{
										if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (m_EventVal.Navigator.HasFlight && m_EventVal.Navigator.GetFlight().GetStatus(m_EventVal.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg))
										{
											bool flag31 = false;
											Doctrine._FuelStateRTB? bingoJokerRTB = m_EventVal.Doctrine.GetBingoJokerRTB(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
											if (m_EventVal.IsGroupMember())
											{
												b = (byte?)bingoJokerRTB;
												if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
												{
													m_EventVal.DetachUnit(bool_0: false, bool_1: false, bool_2: true);
													flag31 = true;
												}
												else
												{
													b = (byte?)bingoJokerRTB;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
													{
														flag31 = true;
													}
													else
													{
														b = (byte?)bingoJokerRTB;
														if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
														{
															bool flag32 = true;
															foreach (ActiveUnit value8 in m_EventVal.GetParentGroup().Units.Values)
															{
																if (value8.FuelState == ActiveUnit._ActiveUnitFuelState.None)
																{
																	flag32 = false;
																	break;
																}
															}
															if (flag32)
															{
																flag31 = true;
															}
														}
													}
												}
											}
											else
											{
												b = (byte?)bingoJokerRTB;
												flag28 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
												if (((!flag28) ?? flag28).GetValueOrDefault() && GetAircraft().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
												{
													flag31 = true;
												}
											}
											if (flag31)
											{
												Waypoint[] plottedCourse = m_EventVal.Navigator.PlottedCourse;
												double num15 = 0.0;
												Waypoint[] array2 = plottedCourse;
												Waypoint[] array4 = array2;
												foreach (Waypoint waypoint2 in array4)
												{
													if (waypoint2.Type >= Waypoint.WaypointType.StrikeEgress)
													{
														num15 += (double)waypoint2.Leg_FuelRequired * 1.1;
													}
												}
												bool flag33 = false;
												if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
												{
													Mission mission = m_EventVal.AssignedMissionOrPackage();
													if ((mission.TankerMinNumber_Airborne > 0) | mission.LaunchMissionWithoutTankersInPlace)
													{
														flag33 = true;
													}
													else if (mission.MissionClass == Mission._MissionClass.Strike)
													{
														Module_Unit.Unit unit2 = ((Strike)mission).SpecificTargets.First();
														if (unit2 != null)
														{
															Aircraft_Navigator navigator7 = GetAircraft().Navigator;
															bool bool_7 = false;
															float value5 = navigator7.OrderProxy(ref bool_7);
															if (WriteClient(unit2.GetLatitude(), unit2.GetLongitude(), GetAircraft().Loadout.CombatRadius, value5))
															{
																flag33 = true;
															}
														}
													}
												}
												if (num15 <= (double)GetAircraft().FuelCapacityCurrent || flag33)
												{
													if (!flag33)
													{
														m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
														m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
														Doctrine doctrine2 = m_EventVal.Doctrine;
														Scenario parentScen2 = m_EventVal.ParentScen;
														bool bool_8 = true;
														Doctrine parentDoctrine2 = doctrine2.GetParentDoctrine(parentScen2, ref bool_8);
														m_EventVal.Doctrine.SetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, parentDoctrine2.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
													}
												}
												else
												{
													IssueImmediateReturnToBase();
												}
												return;
											}
										}
									}
									else if (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse && (m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (m_EventVal.Navigator.HasFlight && m_EventVal.Navigator.GetFlight().GetStatus(m_EventVal.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol || m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)) || m_EventVal.AI.IsEscort))))
									{
										bool flag2 = false;
										Doctrine._FuelStateRTB? bingoJokerRTB2 = m_EventVal.Doctrine.GetBingoJokerRTB(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
										b = (byte?)bingoJokerRTB2;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
										{
											m_EventVal.DetachUnit(bool_0: false, bool_1: false, bool_2: true);
											flag2 = true;
										}
										else
										{
											b = (byte?)bingoJokerRTB2;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
											{
												if (m_EventVal.GetParentGroup().GroupLead.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
												{
													m_EventVal.GetParentGroup().GroupLead.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
													m_EventVal.GetParentGroup().GroupLead.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
													Doctrine doctrine3 = m_EventVal.GetParentGroup().GroupLead.Doctrine;
													Scenario parentScen3 = m_EventVal.ParentScen;
													bool bool_9 = true;
													Doctrine parentDoctrine3 = doctrine3.GetParentDoctrine(parentScen3, ref bool_9);
													m_EventVal.GetParentGroup().GroupLead.Doctrine.SetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, parentDoctrine3.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
												}
												flag2 = true;
											}
										}
										if (flag2)
										{
											m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
											m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
											Doctrine doctrine4 = m_EventVal.Doctrine;
											Scenario parentScen4 = m_EventVal.ParentScen;
											bool bool_10 = true;
											Doctrine parentDoctrine4 = doctrine4.GetParentDoctrine(parentScen4, ref bool_10);
											m_EventVal.Doctrine.SetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, parentDoctrine4.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
											return;
										}
									}
								}
								if ((m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse || (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)) && m_EventVal.Navigator.EgressToRejoinPoint_CallOff(float_0))
								{
									return;
								}
							}
							if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB || !m_EventVal.IsRTB)
							{
								if (!m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse && (!m_EventVal.IsGroupWingman() || Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) || !m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))
								{
									Doctrine._FuelStateRTB? bingoJokerRTB3 = m_EventVal.Doctrine.GetBingoJokerRTB(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									if (m_EventVal.IsGroupMember())
									{
										b = (byte?)bingoJokerRTB3;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
										{
											if (!GetAircraft().Weaponry.IsGuidingWeaponsInAir())
											{
												GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
											}
											return;
										}
										b = (byte?)bingoJokerRTB3;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
										{
											if (!GetAircraft().Weaponry.IsGuidingWeaponsInAir())
											{
												GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: false, bool_3: true);
											}
											return;
										}
										b = (byte?)bingoJokerRTB3;
										if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
										{
											return;
										}
										bool flag3 = true;
										foreach (ActiveUnit value9 in m_EventVal.GetParentGroup().Units.Values)
										{
											if (value9.FuelState == ActiveUnit._ActiveUnitFuelState.None || value9.Weaponry.IsGuidingWeaponsInAir())
											{
												flag3 = false;
												break;
											}
										}
										if (flag3)
										{
											GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: false, bool_3: true);
										}
									}
									else
									{
										b = (byte?)bingoJokerRTB3;
										bool? flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
										if (((!flag4) ?? flag4).GetValueOrDefault() && !GetAircraft().Weaponry.IsGuidingWeaponsInAir())
										{
											GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
										}
									}
									return;
								}
								if (!bool_26 && m_EventVal.Navigator.HasFlightPlan && m_EventVal.Navigator.PlottedCourse.Count() > 0 && (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (m_EventVal.Navigator.HasFlight && m_EventVal.Navigator.GetFlight().GetStatus(m_EventVal.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol || m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)) || m_EventVal.AI.IsEscort))))
								{
									m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
									return;
								}
							}
						}
					}
					else if (GetAircraft().FuelState != isBingoOrJoker)
					{
						GetAircraft().FuelState = isBingoOrJoker;
					}
				}
				if (GetAircraft().Navigator.HasPlottedCourse())
				{
					if (GetAircraft().ParentScen.MinuteIsChangingOnThisPulse)
					{
						if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
						{
							float num16;
							if (GetAircraft().AssignedMissionOrPackage() == null)
							{
								num16 = m_EventVal.Doctrine.ReflectRepository(m_EventVal) * 1.25f;
								if ((double)num16 > 0.85)
								{
									num16 = 0.85f;
								}
							}
							else
							{
								num16 = ((m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0)));
							}
							PopFacade(num16, m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
						}
						else
						{
							Waypoint waypoint3 = GetAircraft().Navigator.PlottedCourse[0];
							if (waypoint3 != null && waypoint3.Type == Waypoint.WaypointType.PatrolStation)
							{
								float num17 = ((GetAircraft().AssignedMissionOrPackage() == null) ? m_EventVal.Doctrine.ReflectRepository(m_EventVal) : ((m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0))));
								if (num17 > 0f)
								{
									PopFacade(num17, m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
								}
							}
							else
							{
								PopFacade(m_EventVal.Doctrine.ReflectRepository(m_EventVal), m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
							}
						}
					}
				}
				else
				{
					PopFacade(m_EventVal.Doctrine.ReflectRepository(m_EventVal), m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
				}
				if (IsEscort && m_EventVal.IsRTB)
				{
					bool flag5 = false;
					bool flag6 = false;
					List<ActiveUnit> list = m_EventVal.GetUnitSide().Units.ToList();
					if (!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						foreach (ActiveUnit item5 in list)
						{
							if (item5.IsGroup || Information.IsNothing(item5.AssignedMissionOrPackage()) || item5.AssignedMissionOrPackage() != m_EventVal.AssignedMissionOrPackage())
							{
								continue;
							}
							if (item5.IsOperating())
							{
								if (!item5.AI.IsEscort)
								{
									flag5 = true;
									break;
								}
							}
							else if (!item5.AI.IsEscort)
							{
								Aircraft_AirOps airOps2 = ((Aircraft)item5).AirOps;
								if (airOps2.Condition != Aircraft_AirOps._AirOpsCondition.Readying && airOps2.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToPark && airOps2.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown && airOps2.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
								{
									flag6 = true;
								}
							}
						}
					}
					if (!flag6 && !flag5)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
						ReturnToBase(float_0);
					}
				}
			}
			if (m_EventVal.IsRTB)
			{
				if (m_EventVal.IsPaintingATarget)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					return;
				}
				if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue && (airOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo) && airOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB)
				{
					airOps.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
				}
			}
			if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || airOps.Condition == Aircraft_AirOps._AirOpsCondition.TransferringCargo)
			{
				return;
			}
			if (GetAircraft().WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
			{
				ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = GetAircraft().Weaponry.IsWinchesterOrShotgun();
				if (activeUnitWeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester && activeUnitWeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun)
				{
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse && m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
					{
						b = (byte?)GetAircraft().Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						bool? flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						if (((!flag7) ?? flag7).GetValueOrDefault())
						{
							Aircraft_Navigator obj = (Aircraft_Navigator)m_EventVal.Navigator;
							ActiveUnit.Throttle throttle_ = obj.CollectProxy();
							bool bool_11 = false;
							float num18 = obj.OrderProxy(ref bool_11);
							float num19 = float.MaxValue;
							ActiveUnit activeUnit3 = m_EventVal;
							if (m_EventVal.IsGroupMember())
							{
								foreach (ActiveUnit item6 in new List<ActiveUnit>(m_EventVal.GetParentGroup().Units.Values))
								{
									if ((float)item6.FuelCapacityCurrent < num19)
									{
										num19 = item6.FuelCapacityCurrent;
										activeUnit3 = item6;
									}
								}
							}
							ActiveUnit actualDestinationHost = ((Aircraft_AirOps)activeUnit3.AirOps).ActualDestinationHost;
							if (!Information.IsNothing(actualDestinationHost) && (double)activeUnit3.Kinematics.InterruptDic(Module_Unit.RangeToUnit_Horiz(activeUnit3, actualDestinationHost), throttle_, num18, activeUnit3.Kinematics.GetMaximumSpeed(num18, throttle_, bool_0: false), bool_0: false, bool_1: false, bool_2: false) > (double)((float)activeUnit3.FuelCapacityCurrent - activeUnit3.Kinematics.ReserveFuel) * 0.9)
							{
								float num20 = (Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) ? 0.85f : ((m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0))));
								if (num20 > 0f)
								{
									PopFacade(num20, m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
								}
							}
						}
					}
					if (GetAircraft().WeaponState != activeUnitWeaponState)
					{
						GetAircraft().WeaponState = activeUnitWeaponState;
					}
				}
				else
				{
					m_EventVal.WeaponState = activeUnitWeaponState;
					if (!m_EventVal.IsPaintingATarget && !m_EventVal.WillNeedToPaintATarget && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
					{
						if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
						{
							Mission mission2 = m_EventVal.AssignedMissionOrPackage();
							if (Information.IsNothing(mission2) || mission2.FlightPlanPreventShotgunRTB || activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
							{
								if (m_EventVal.GetUnitSide().IsHumanControlled)
								{
									Notification_Bark.Create(m_EventVal, "Winchester or Shotgun: Proceeding to Egress path", Color.Red, bool_0: true, bool_1: true, 2f);
								}
								m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								if (!m_EventVal.IsGroupLead())
								{
									return;
								}
								{
									foreach (KeyValuePair<string, ActiveUnit> unit3 in m_EventVal.GetParentGroup().Units)
									{
										if (unit3.Value.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
										{
											unit3.Value.Status = ActiveUnit._ActiveUnitStatus.Tasked;
											unit3.Value.Navigator.HeadToFormationStation(float_0);
										}
									}
									return;
								}
							}
						}
						else
						{
							if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
							{
								if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
								{
									b = (byte?)GetAircraft().Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
									bool? flag8 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
									if (((!flag8) ?? flag8).GetValueOrDefault())
									{
										ActiveUnit.Throttle throttle_2 = GetAircraft().Navigator.CollectProxy();
										Aircraft_Navigator navigator8 = GetAircraft().Navigator;
										bool bool_13 = false;
										float num21 = navigator8.OrderProxy(ref bool_13);
										float num2 = float.MaxValue;
										Aircraft aircraft = GetAircraft();
										if (m_EventVal.IsGroupMember())
										{
											foreach (ActiveUnit value10 in m_EventVal.GetParentGroup().Units.Values)
											{
												if ((float)value10.FuelCapacityCurrent < num2)
												{
													num2 = value10.FuelCapacityCurrent;
													aircraft = (Aircraft)value10;
												}
											}
										}
										ActiveUnit actualDestinationHost2 = aircraft.AirOps.ActualDestinationHost;
										if (!Information.IsNothing(actualDestinationHost2) && (double)aircraft.Kinematics.InterruptDic(Module_Unit.RangeToUnit_Horiz(aircraft, actualDestinationHost2), throttle_2, num21, aircraft.Kinematics.GetMaximumSpeed(num21, throttle_2, bool_0: false), bool_0: false, bool_1: false, bool_2: false) > (double)((float)aircraft.FuelCapacityCurrent - aircraft.Kinematics.ReserveFuel) * 0.9)
										{
											GeoPoint geoPoint_ = LoginClient();
											bool bool_14 = false;
											Doctrine._UnderwayRefuelAndReplenishmentSelection value6 = m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
											bool_13 = false;
											ActiveUnit activeUnit_5 = null;
											List<Mission> list_6 = null;
											string string_9 = "";
											bool bool_15 = true;
											if (airOps.AssetProxy(geoPoint_, value6, ref bool_13, bool_1: false, ref activeUnit_5, ref list_6, ref string_9, ref bool_15, ref bool_14))
											{
												return;
											}
										}
									}
								}
								if ((m_EventVal.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) & (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.Refuelling))
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								}
								return;
							}
							if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
							{
								if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (m_EventVal.Navigator.HasFlight && m_EventVal.Navigator.GetFlight().GetStatus(m_EventVal.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol || m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)) || m_EventVal.AI.IsEscort)))
								{
									bool flag9 = false;
									Doctrine._WeaponStateRTB? winchesterShotgunRTB = m_EventVal.Doctrine.GetWinchesterShotgunRTB(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									if (m_EventVal.IsGroupMember())
									{
										b = (byte?)winchesterShotgunRTB;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
										{
											m_EventVal.DetachUnit(bool_0: false, bool_1: false, bool_2: true);
											flag9 = true;
										}
										else
										{
											b = (byte?)winchesterShotgunRTB;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
											{
												flag9 = true;
											}
											else
											{
												b = (byte?)winchesterShotgunRTB;
												if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
												{
													bool flag10 = true;
													foreach (ActiveUnit value11 in m_EventVal.GetParentGroup().Units.Values)
													{
														if (value11.WeaponState == ActiveUnit._ActiveUnitWeaponState.None || value11.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO || value11.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO)
														{
															flag10 = false;
															break;
														}
													}
													if (flag10)
													{
														flag9 = true;
													}
												}
											}
										}
									}
									else
									{
										b = (byte?)winchesterShotgunRTB;
										bool? flag11 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
										if (((!flag11) ?? flag11).GetValueOrDefault() && GetAircraft().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
										{
											flag9 = true;
										}
									}
									if (flag9)
									{
										m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
										m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										return;
									}
								}
							}
							else if (m_EventVal.GetParentGroup() != null && m_EventVal.IsGroupWingman() && m_EventVal.GetParentGroup().GroupLead != null && m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
							{
								if (m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (m_EventVal.Navigator.HasFlight && m_EventVal.Navigator.GetFlight().GetStatus(m_EventVal.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol || m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)) || m_EventVal.AI.IsEscort)))
								{
									bool flag13 = false;
									Doctrine._WeaponStateRTB? winchesterShotgunRTB2 = m_EventVal.Doctrine.GetWinchesterShotgunRTB(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									b = (byte?)winchesterShotgunRTB2;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
									{
										m_EventVal.DetachUnit(bool_0: false, bool_1: false, bool_2: true);
										flag13 = true;
									}
									else
									{
										b = (byte?)winchesterShotgunRTB2;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
										{
											m_EventVal.GetParentGroup().GroupLead.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
											m_EventVal.GetParentGroup().GroupLead.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										}
									}
									if (flag13)
									{
										m_EventVal.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
										m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										return;
									}
									if (!Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride))
									{
										m_EventVal.Kinematics.DesiredSpeedOverride = null;
									}
									if (m_EventVal.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
									{
										m_EventVal.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
									}
									if ((Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) || m_EventVal.GetParentGroup().GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) && !Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
									{
										switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
										{
										case Mission._MissionClass.Strike:
											m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
											return;
										case Mission._MissionClass.Patrol:
											m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
											return;
										case Mission._MissionClass.Support:
											m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
											return;
										}
									}
								}
							}
							else if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB || (!m_EventVal.IsRTB && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.Refuelling))
							{
								Doctrine._WeaponStateRTB? winchesterShotgunRTB3 = m_EventVal.Doctrine.GetWinchesterShotgunRTB(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
								if (m_EventVal.IsGroupMember())
								{
									b = (byte?)winchesterShotgunRTB3;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
									{
										if (!GetAircraft().Weaponry.IsGuidingWeaponsInAir() && GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true))
										{
											return;
										}
									}
									else
									{
										b = (byte?)winchesterShotgunRTB3;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
										{
											if (!GetAircraft().Weaponry.IsGuidingWeaponsInAir() && GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: false, bool_3: true))
											{
												return;
											}
										}
										else
										{
											b = (byte?)winchesterShotgunRTB3;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
											{
												bool flag14 = true;
												foreach (ActiveUnit value2 in m_EventVal.GetParentGroup().Units.Values)
												{
													if (value2.WeaponState == ActiveUnit._ActiveUnitWeaponState.None || value2.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO || value2.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO || value2.Weaponry.IsGuidingWeaponsInAir())
													{
														flag14 = false;
														break;
													}
												}
												if (flag14 && GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: false, bool_3: true))
												{
													return;
												}
											}
										}
									}
								}
								else
								{
									b = (byte?)winchesterShotgunRTB3;
									bool? flag15 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
									if (((!flag15) ?? flag15).GetValueOrDefault() && GetAircraft().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue && !GetAircraft().Weaponry.IsGuidingWeaponsInAir())
									{
										if (m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse[0].Category == Waypoint.WaypointCategory.PlottedCourse)
										{
											m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
											return;
										}
										if (GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true))
										{
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			if (m_EventVal.IsRTB)
			{
				return;
			}
			if (m_EventVal.AI.PrimaryTarget == null && airOps.Condition == Aircraft_AirOps._AirOpsCondition.const_19)
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
			if (PrimaryTarget == null && !m_EventVal.AI.IsEscort && m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
				if (strike.SpecificTargets != null && strike.SpecificTargets.Count > 0)
				{
					foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
					{
						if (PrimaryTarget != null)
						{
							break;
						}
						foreach (Contact item7 in new List<Contact>(m_EventVal.GetUnitSide().Contacts.Values))
						{
							if (Operators.CompareString(item7.ActualUnit.ObjectID, specificTarget.ObjectID, TextCompare: false) == 0)
							{
								PrimaryTarget = item7;
								break;
							}
						}
					}
				}
			}
			int? nullable_2;
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
				{
					return;
				}
				if (!Information.IsNothing(PrimaryTarget))
				{
					b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
						Contact primaryTarget = PrimaryTarget;
						Doctrine doctrine5 = m_EventVal.Doctrine;
						string string_10 = "";
						int int_2 = 0;
						if (weaponry.PopConsumer(primaryTarget, bool_1: true, doctrine5, ref string_10, ref int_2))
						{
							if (GetAircraft().IsOnActivePatrol && TargetingBehaviorForThisTarget(PrimaryTarget) == TargetingEntry._TargetingBehavior.AutoTargeted)
							{
								Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
								Contact primaryTarget2 = PrimaryTarget;
								Mission mission_ = GetAircraft().AssignedMissionOrPackage();
								string_10 = "";
								int_2 = 0;
								if (ContactIsRelevantToMission(primaryTarget2, mission_, shootTourists, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_10, ref int_2))
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								}
								else if (m_EventVal.Navigator.HasFlightPlan)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								}
								else
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
								}
								return;
							}
							bool flag16 = true;
							if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
							{
								flag16 = true;
							}
							if (m_EventVal.GetUnitSide().WeaponSalvos != null)
							{
								if (m_EventVal.GetUnitSide().WeaponSalvos.Count() == 0)
								{
									flag16 = true;
								}
								bool flag17 = false;
								WeaponSalvo[] weaponSalvos = m_EventVal.GetUnitSide().WeaponSalvos;
								WeaponSalvo[] array5 = weaponSalvos;
								foreach (WeaponSalvo weaponSalvo in array5)
								{
									WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
									WeaponSalvo.Shooter[] array6 = shootersList;
									foreach (WeaponSalvo.Shooter shooter in array6)
									{
										if (Operators.CompareString(shooter.ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
										{
											if (shooter.QuantityFired < shooter.QuantityAssigned && m_EventVal.Weaponry.HowManyOfThisWeapon(weaponSalvo.int_0) != 0)
											{
												flag16 = true;
												flag17 = true;
												break;
											}
											flag16 = false;
										}
									}
									if (flag17)
									{
										break;
									}
								}
							}
							Aircraft aircraft2 = (GetAircraft().IsGroupWingman() ? ((Aircraft)GetAircraft().GetParentGroup().GroupLead) : GetAircraft());
							bool flag18 = true;
							if (aircraft2.AI.PrimaryTarget == null && aircraft2.IsGroupWingman())
							{
								aircraft2.AI.PrimaryTarget = aircraft2.GetParentGroup().GroupLead.AI.PrimaryTarget;
							}
							TargetingEntry._TargetingBehavior targetingBehavior = aircraft2.AI.TargetingBehaviorForThisTarget(aircraft2.AI.PrimaryTarget);
							Weapon weapon_ = null;
							if (aircraft2.Navigator.HasFlightPlan)
							{
								Waypoint[] array = aircraft2.Navigator.GetFlight().FlightPlan;
								Waypoint[] array7 = array;
								foreach (Waypoint waypoint4 in array7)
								{
									if (waypoint4.ReferenceWeapon_ID != 0)
									{
										weapon_ = Weapon.GetNewWeapon(ref GetAircraft().ParentScen, waypoint4.ReferenceWeapon_ID, bool_0: false);
									}
								}
							}
							else if (aircraft2.AI.PrimaryTarget != null)
							{
								if (targetingBehavior == TargetingEntry._TargetingBehavior.ManualWeaponAlloc || targetingBehavior == TargetingEntry._TargetingBehavior.ManualTargeted)
								{
									flag16 = true;
									flag18 = false;
								}
								weapon_ = aircraft2.Weaponry.MostSuitableWeaponForThisTarget(aircraft2.AI.PrimaryTarget, bool_1: false, bool_2: false, targetingBehavior != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && targetingBehavior != TargetingEntry._TargetingBehavior.ManualTargeted, aircraft2.Doctrine);
							}
							if (weapon_ != null && targetingBehavior != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && targetingBehavior != TargetingEntry._TargetingBehavior.ManualTargeted && GetAircraft().AssignedMissionOrPackage() != null && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
							{
								foreach (Module_Unit.Unit item8 in ((Strike)m_EventVal.AssignedMissionOrPackage()).SpecificTargets.OrderBy((Module_Unit.Unit unit_0) => Module_Unit.RangeToUnit_Horiz(unit_0, GetAircraft())))
								{
									Contact contact_ = (item8.DisableWriter() ? ((Contact)item8) : new Contact((ActiveUnit)item8, 0, bool_0: true));
									Weapon weapon_2 = weapon_;
									bool? nullable_ = null;
									Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_2, ref nullable_);
									Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_, ref _WRA_WeaponTargetType_, m_EventVal.GetUnitSide().ObjectID);
									Doctrine doctrine6 = m_EventVal.Doctrine;
									Scenario parentScen5 = m_EventVal.ParentScen;
									Weapon weapon_3 = weapon_;
									nullable_2 = null;
									int? nullable_3 = null;
									int? num3 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine6, parentScen5, weapon_3, wRA_WeaponTargetType_, bool_0: false, ref nullable_2, ref nullable_3);
									nullable_3 = num3;
									if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == -99) : null).GetValueOrDefault())
									{
										num3 = int.MaxValue;
									}
									else
									{
										nullable_3 = num3;
										if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() < 0) : null).GetValueOrDefault())
										{
											num3 = m_EventVal.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num3, ref m_EventVal, ref contact_, ref weapon_);
										}
									}
									int num4 = contact_.IncomingGuidedWeapons.Count();
									if (!(num3.HasValue ? new bool?(num4 < num3.GetValueOrDefault()) : null).GetValueOrDefault())
									{
										Doctrine doctrine7 = m_EventVal.Doctrine;
										Scenario parentScen6 = m_EventVal.ParentScen;
										Weapon weapon_4 = weapon_;
										nullable_3 = null;
										nullable_2 = null;
										int? num5 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine7, parentScen6, weapon_4, wRA_WeaponTargetType_, bool_0: false, ref nullable_3, ref nullable_2);
										nullable_2 = num5;
										if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() == -99) : null).GetValueOrDefault())
										{
											num5 = int.MaxValue;
										}
										double? num6 = (double?)num3 / (double?)num5;
										double? num7 = num3;
										if (((num6.HasValue & num7.HasValue) ? new bool?(num6.GetValueOrDefault() >= num7.GetValueOrDefault()) : null).GetValueOrDefault())
										{
											flag16 = false;
										}
										continue;
									}
									flag18 = false;
									PrimaryTarget = contact_;
									flag16 = true;
									break;
								}
							}
							if (flag18)
							{
								flag16 = false;
							}
							if (flag16)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								if (m_EventVal.IsGroupLead() && !flag18)
								{
									foreach (KeyValuePair<string, ActiveUnit> unit4 in m_EventVal.GetParentGroup().Units)
									{
										if (unit4.Value.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
										{
											unit4.Value.Status = ActiveUnit._ActiveUnitStatus.Tasked;
											unit4.Value.Navigator.HeadToFormationStation(float_0);
										}
										else
										{
											unit4.Value.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
										}
									}
								}
								Doctrine._UseShootTourists? shootTourists2 = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
								Contact primaryTarget3 = PrimaryTarget;
								Mission mission_2 = GetAircraft().AssignedMissionOrPackage();
								string_10 = "";
								int int_3 = 0;
								if (!ContactIsRelevantToMission(primaryTarget3, mission_2, shootTourists2, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_10, ref int_3) || !aircraft2.Navigator.HasFlightPlan)
								{
									return;
								}
								Waypoint[] flightPlan = aircraft2.Navigator.GetFlight().FlightPlan;
								Waypoint[] array8 = flightPlan;
								foreach (Waypoint waypoint5 in array8)
								{
									if (waypoint5.ReferenceWeapon_ID != 0)
									{
										if (waypoint5.DesiredAltitude_TerrainFollowing.HasValue)
										{
											GetAircraft().DesiredAltitude = waypoint5.DesiredAltitude_TerrainFollowing.Value;
										}
										break;
									}
								}
							}
							else
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							}
						}
						else
						{
							if (!GetAircraft().IsOnActivePatrol)
							{
								return;
							}
							if (PrimaryTarget.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							}
							else if (!m_EventVal.IsPaintingATarget && !m_EventVal.WillNeedToPaintATarget)
							{
								if (m_EventVal.Navigator.HasFlightPlan)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								}
								else
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
								}
							}
							else
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							}
						}
						return;
					}
				}
				if (!Information.IsNothing(PrimaryTarget) && (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun || m_EventVal.Navigator.IsOnLocalizationRun))
				{
					if ((PrimaryTarget == null || !m_EventVal.Navigator.IsOnLocalizationRun || Module_Unit.RangeToPoint_Horiz(m_EventVal, m_EventVal.Navigator.PlottedCourse[0].Latitude, m_EventVal.Navigator.PlottedCourse[0].Longitude) >= 30f) && !GeoPoint.IsInsideThisArea(m_EventVal.Navigator.PlottedCourse[0].Latitude, m_EventVal.Navigator.PlottedCourse[0].Longitude, m_EventVal.AI.PrimaryTarget.UncertaintyArea))
					{
						m_EventVal.Navigator.ClearPlottedCourse();
					}
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				}
				else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && !Information.IsNothing(PrimaryTarget))
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				}
				else if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
				}
				else if (m_EventVal.Navigator.HasPlottedCourse() && (m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Assemble || m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldStart || m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldEnd) && m_EventVal.IsGroupMember() && m_EventVal.GetParentGroup().IsFormingUp)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
				}
				else if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && ((Strike)m_EventVal.AssignedMissionOrPackage()).SpecificTargets.Count == 0)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
					m_EventVal.Navigator.HeadToFormationStation(float_0);
				}
				else
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				return;
			}
			Aircraft aircraft3 = (GetAircraft().IsGroupWingman() ? ((Aircraft)GetAircraft().GetParentGroup().GroupLead) : GetAircraft());
			Weapon weapon_5 = null;
			if (aircraft3 != null)
			{
				Aircraft_Navigator navigator9 = aircraft3.Navigator;
				if (navigator9 != null && navigator9.HasFlightPlan)
				{
					Waypoint[] array3 = aircraft3.Navigator.GetFlight().FlightPlan;
					Waypoint[] array9 = array3;
					foreach (Waypoint waypoint6 in array9)
					{
						if (waypoint6.ReferenceWeapon_ID != 0)
						{
							weapon_5 = Weapon.GetNewWeapon(ref GetAircraft().ParentScen, waypoint6.ReferenceWeapon_ID, bool_0: false);
						}
					}
				}
			}
			bool flag19 = true;
			nullable_2 = (int?)m_EventVal.Doctrine.GetWinchesterShotgun(m_EventVal.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			bool? obj2 = (nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() != 0) : null);
			if (((m_EventVal.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester) & obj2).GetValueOrDefault())
			{
				flag19 = true;
				if (m_EventVal.IsGroupLead())
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
					return;
				}
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
				m_EventVal.Navigator.HeadToFormationStation(float_0);
				return;
			}
			if (weapon_5 == null)
			{
				flag19 = false;
			}
			else if (GetAircraft().AssignedMissionOrPackage() != null && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				foreach (Module_Unit.Unit specificTarget2 in ((Strike)m_EventVal.AssignedMissionOrPackage()).SpecificTargets)
				{
					Contact contact_2 = (specificTarget2.DisableWriter() ? ((Contact)specificTarget2) : new Contact((ActiveUnit)specificTarget2, 0, bool_0: true));
					Weapon weapon_6 = weapon_5;
					bool? nullable_4 = null;
					Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_2 = Doctrine.WRA_DetermineTargetType(ref contact_2, weapon_6, ref nullable_4);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_5, ref contact_2, ref _WRA_WeaponTargetType_2, m_EventVal.GetUnitSide().ObjectID);
					Doctrine doctrine8 = m_EventVal.Doctrine;
					Scenario parentScen7 = m_EventVal.ParentScen;
					Weapon weapon_7 = weapon_5;
					nullable_2 = null;
					int? nullable_5 = null;
					int? num8 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine8, parentScen7, weapon_7, wRA_WeaponTargetType_2, bool_0: false, ref nullable_2, ref nullable_5);
					nullable_5 = num8;
					nullable_4 = (nullable_5.HasValue ? new bool?(nullable_5.GetValueOrDefault() == -99) : null);
					nullable_5 = num8;
					bool? flag20 = (nullable_5.HasValue ? new bool?(nullable_5.GetValueOrDefault() == -100) : null);
					if ((nullable_4.GetValueOrDefault() ? new bool?(true) : ((!flag20.HasValue) ? null : (flag20.GetValueOrDefault() | nullable_4))).GetValueOrDefault())
					{
						num8 = int.MaxValue;
					}
					else
					{
						nullable_5 = num8;
						if ((nullable_5.HasValue ? new bool?(nullable_5.GetValueOrDefault() < 0) : null).GetValueOrDefault())
						{
							num8 = m_EventVal.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num8, ref m_EventVal, ref contact_2, ref weapon_5);
						}
					}
					if (!num8.HasValue)
					{
						flag19 = false;
					}
					int num9 = contact_2.IncomingGuidedWeapons.Count();
					if ((num8.HasValue ? new bool?(num9 < num8.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						flag19 = false;
					}
				}
			}
			if (GetAircraft().AssignedMissionOrPackage() != null)
			{
				if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !((Strike)GetAircraft().AssignedMissionOrPackage()).RTB_When_Target_Destroyed)
				{
					flag19 = false;
				}
				if (flag19)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
					return;
				}
			}
			if (m_EventVal.IsGroupMember() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead))
			{
				if (m_EventVal.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					}
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && m_EventVal.GetParentGroup().GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					m_EventVal.Status = m_EventVal.predicateVal;
				}
				else if (m_EventVal.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || m_EventVal.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						ActiveUnit eventVal4 = m_EventVal;
						double double_3 = 0.0;
						double double_4 = 0.0;
						if (eventVal4.FuelPercent(ref double_3, ref double_4, bool_0: false) < 0.95)
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						}
					}
					return;
				}
			}
			if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup && m_EventVal.GetParentGroup().IsFormingUp)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					EvaluateTargets(float_0, bool_0: false, bool_1: true);
				}
			}
			if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && m_EventVal.AssignedMissionOrPackage().IsActive)
			{
				switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Strike:
					if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
					{
						bool flag21 = true;
						if (m_EventVal.AssignedMissionOrPackage() == null || m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
						{
							if (m_EventVal.AI.IsEscort)
							{
								foreach (ActiveUnit item9 in Module_Mission.AssetTokenizer(m_EventVal.AssignedMissionOrPackage(), m_EventVal.ParentScen))
								{
									if (item9 != null && !item9.IsDestroyed && !item9.IsGroup && !item9.AI.IsEscort)
									{
										flag21 = false;
										break;
									}
								}
							}
							else
							{
								bool? flag22;
								if (_TargetList == null)
								{
									ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
									flag22 = ((targetList == null) ? null : new bool?(targetList.Count == 0));
								}
								else
								{
									flag22 = true;
								}
								bool? flag24 = flag22;
								if (((((Strike)m_EventVal.AssignedMissionOrPackage()).SpecificTargets != null && ((Strike)m_EventVal.AssignedMissionOrPackage()).TargetCount > 0) & flag24).GetValueOrDefault())
								{
									flag21 = false;
								}
							}
						}
						if (flag21)
						{
							if (!IsEscort && (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse || (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))
							{
								if (flag)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
								}
								else
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
								}
							}
							else
							{
								List<Aircraft> list2 = new List<Aircraft>();
								foreach (ActiveUnit item10 in m_EventVal.GetUnitSide().Units.ToList())
								{
									if (item10.IsAircraft && item10.AssignedMissionOrPackage() != null && item10.AssignedMissionOrPackage() == GetAircraft().AssignedMissionOrPackage() && !item10.AI.IsEscort)
									{
										if (item10.IsOperating())
										{
											list2.Add((Aircraft)item10);
										}
										else if (((Aircraft)item10).AirOps.IsTakingOff)
										{
											list2.Add((Aircraft)item10);
										}
									}
								}
								if (list2.Count <= 0)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
								}
								else
								{
									if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse)
									{
										Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround;
										bool flag25 = false;
										GeoPoint geoPoint2 = null;
										foreach (Aircraft item11 in list2)
										{
											if (item11.AI.IsEscort)
											{
												continue;
											}
											if (item11.IsGroupLead() || !item11.IsGroupMember())
											{
												if (item11.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
												{
													underwayRefuelAndReplenishmentSelection = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly;
													if (Information.IsNothing(geoPoint2))
													{
														geoPoint2 = item11.AI.LoginClient();
													}
												}
												if (item11.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || item11.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
												{
													flag25 = true;
												}
											}
											if (!flag25 || underwayRefuelAndReplenishmentSelection != Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
											{
												continue;
											}
											break;
										}
										if (flag25)
										{
											float num10 = ((m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0)));
											if (GetAircraft().Doctrine.GetUseReplenishment(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value != Doctrine._UseUnderwayRefuelAndReplenishment.Never)
											{
												bool bool_16 = false;
												try
												{
													float num11 = float.MaxValue;
													ActiveUnit activeUnit4 = m_EventVal;
													if (m_EventVal.IsGroupMember())
													{
														foreach (ActiveUnit value3 in m_EventVal.GetParentGroup().Units.Values)
														{
															if ((float)value3.FuelCapacityCurrent < num11)
															{
																num11 = value3.FuelCapacityCurrent;
																activeUnit4 = value3;
															}
														}
													}
													ActiveUnit activeUnit5 = activeUnit4;
													double double_5 = 0.0;
													double double_6 = 0.0;
													if (activeUnit5.FuelPercent(ref double_5, ref double_6, bool_0: true) < (double)num10)
													{
														GeoPoint geoPoint_2 = geoPoint2;
														Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection_ = underwayRefuelAndReplenishmentSelection;
														bool bool_17 = false;
														ActiveUnit activeUnit_6 = null;
														List<Mission> list_7 = null;
														string string_12 = "";
														bool bool_18 = false;
														if (airOps.AssetProxy(geoPoint_2, underwayRefuelAndReplenishmentSelection_, ref bool_17, bool_1: false, ref activeUnit_6, ref list_7, ref string_12, ref bool_18, ref bool_16))
														{
															return;
														}
													}
												}
												catch (Exception projectError)
												{
													ProjectData.SetProjectError(projectError);
													GeoPoint geoPoint_3 = geoPoint2;
													Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection_2 = underwayRefuelAndReplenishmentSelection;
													bool bool_19 = false;
													ActiveUnit activeUnit_7 = null;
													List<Mission> list_8 = null;
													string string_2 = "";
													bool bool_20 = false;
													if (airOps.AssetProxy(geoPoint_3, underwayRefuelAndReplenishmentSelection_2, ref bool_19, bool_1: false, ref activeUnit_7, ref list_8, ref string_2, ref bool_20, ref bool_16))
													{
														ProjectData.ClearProjectError();
														return;
													}
													ProjectData.ClearProjectError();
												}
											}
										}
									}
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
									Aircraft aircraft4 = (GetAircraft().IsGroupWingman() ? ((Aircraft)GetAircraft().GetParentGroup().GroupLead) : GetAircraft());
									if (aircraft4.AI.IsEscort && aircraft4.AssignedMissionOrPackage() != null)
									{
										foreach (Mission.Flight flight in aircraft4.AssignedMissionOrPackage().FlightList)
										{
											foreach (ActiveUnit item12 in flight.GetAUCurrentlyAssigned(aircraft4.AssignedMissionOrPackage(), aircraft4.ParentScen))
											{
												if (!item12.AI.IsEscort)
												{
													HeadToNearestEscortSubject();
												}
											}
										}
									}
								}
							}
						}
						else if (IsEscort)
						{
							if (PrimaryTarget == null)
							{
								List<Aircraft> list3 = new List<Aircraft>();
								List<ActiveUnit> list4;
								try
								{
									list4 = new List<ActiveUnit>(m_EventVal.GetUnitSide().Units);
								}
								catch (Exception projectError2)
								{
									ProjectData.SetProjectError(projectError2);
									list4 = new List<ActiveUnit>(m_EventVal.GetUnitSide().Units);
									ProjectData.ClearProjectError();
								}
								foreach (ActiveUnit item2 in list4)
								{
									if (item2.IsAircraft && item2 != GetAircraft() && item2.AssignedMissionOrPackage() != null && item2.AssignedMissionOrPackage() == GetAircraft().AssignedMissionOrPackage() && !item2.AI.IsEscort)
									{
										if (item2.IsOperating())
										{
											list3.Add((Aircraft)item2);
										}
										else if (((Aircraft)item2).AirOps.IsTakingOff)
										{
											list3.Add((Aircraft)item2);
										}
									}
								}
								if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse)
								{
									Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection2 = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround;
									bool bool_21 = false;
									GeoPoint geoPoint3 = null;
									foreach (Aircraft item3 in list3)
									{
										if (item3.AI.IsEscort)
										{
											continue;
										}
										if (item3.IsGroupLead() || !item3.IsGroupMember())
										{
											if (item3.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
											{
												underwayRefuelAndReplenishmentSelection2 = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly;
												if (Information.IsNothing(geoPoint3))
												{
													geoPoint3 = item3.AI.LoginClient();
												}
											}
											if (item3.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || item3.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
											{
												bool_21 = true;
											}
										}
										if (!bool_21 || underwayRefuelAndReplenishmentSelection2 != Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
										{
											continue;
										}
										break;
									}
									if (bool_21 && GetAircraft().Doctrine.GetUseReplenishment(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value != Doctrine._UseUnderwayRefuelAndReplenishment.Never)
									{
										GeoPoint geoPoint_4 = geoPoint3;
										Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection_3 = underwayRefuelAndReplenishmentSelection2;
										bool bool_22 = false;
										ActiveUnit activeUnit_8 = null;
										List<Mission> list_9 = null;
										string string_3 = "";
										bool bool_24 = false;
										if (airOps.AssetProxy(geoPoint_4, underwayRefuelAndReplenishmentSelection_3, ref bool_22, bool_1: false, ref activeUnit_8, ref list_9, ref string_3, ref bool_24, ref bool_21))
										{
											return;
										}
									}
								}
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
							}
							else
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							}
						}
						else if (flag)
						{
							if (!Information.IsNothing(PrimaryTarget) && GetAircraft().IsGroupMember() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && (GetAircraft().GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun || GetAircraft().GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun) && !GetAircraft().GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_HasLeftTargetArea)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							}
							else
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
							}
						}
						else
						{
							Strike Local_theStrikeMission = (Strike)m_EventVal.AssignedMissionOrPackage();
							if (Local_theStrikeMission.TargetCount <= 0)
							{
								if (Local_theStrikeMission.RTB_When_Target_Destroyed && Local_theStrikeMission.TargetCount == 0)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
									return;
								}
								if (PrimaryTarget != null && m_EventVal.ParentScen.SecondIsChangingOnThisPulse)
								{
									bool flag26 = false;
									Doctrine._UseShootTourists? shootTourists4 = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
									Contact primaryTarget6 = PrimaryTarget;
									Mission mission_4 = GetAircraft().AssignedMissionOrPackage();
									string string_4 = "";
									int int_5 = 0;
									if (ContactIsRelevantToMission(primaryTarget6, mission_4, shootTourists4, bool_0: true, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_4, ref int_5))
									{
										flag26 = true;
									}
									else
									{
										foreach (Contact item4 in base.Targets_ReadOnly.ToList())
										{
											Mission mission_5 = GetAircraft().AssignedMissionOrPackage();
											string_4 = "";
											int_5 = 0;
											if (ContactIsRelevantToMission(item4, mission_5, shootTourists4, bool_0: true, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_4, ref int_5))
											{
												flag26 = true;
												break;
											}
										}
									}
									if (!flag26)
									{
										m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
										return;
									}
								}
							}
							else
							{
								List<Contact> list5 = new List<Contact>();
								list5.AddRange(base.Targets_ReadOnly);
								foreach (Module_Unit.Unit specificTarget3 in Local_theStrikeMission.SpecificTargets)
								{
									if (specificTarget3.IsActiveUnit)
									{
										Contact item = new Contact((ActiveUnit)specificTarget3, 0, bool_0: true);
										list5.Add(item);
									}
									else if (specificTarget3.DisableWriter())
									{
										list5.Add((Contact)specificTarget3);
									}
								}
								if (list5.Where((Contact theC) => theC.GetIsSpecificTargetForThisStrike(Local_theStrikeMission)).ToList().Count == 0)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
									return;
								}
							}
							Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
							if (!Information.IsNothing(weapon))
							{
								double num13 = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: false, null, bool_1: false);
								double num14 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
								if (num13 * 2.0 > num14)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
									return;
								}
							}
							Aircraft aircraft5 = (GetAircraft().IsGroupWingman() ? ((Aircraft)GetAircraft().GetParentGroup().GroupLead) : GetAircraft());
							bool? flag27 = ((aircraft5 == null) ? null : new bool?(aircraft5.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive));
							if (!((m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive) ? new bool?(false) : flag27).GetValueOrDefault())
							{
								if (m_EventVal.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								}
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
							if ((m_EventVal.IsGroupLead() | !m_EventVal.IsGroupMember()) && Local_theStrikeMission.SpecificTargets != null)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								return;
							}
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						}
					}
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse && m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0)
					{
						PopFacade((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0), m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
					}
					return;
				case Mission._MissionClass.Patrol:
					if ((m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff) & !m_EventVal.Navigator.HasPathfindingPlottedCourse)
					{
						if (!Information.IsNothing(PrimaryTarget))
						{
							Contact primaryTarget4 = PrimaryTarget;
							Mission mission_3 = m_EventVal.AssignedMissionOrPackage();
							Doctrine._UseShootTourists? shootTourists3 = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							string string_11 = "";
							int int_4 = 0;
							if (ContactIsRelevantToMission(primaryTarget4, mission_3, shootTourists3, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_11, ref int_4))
							{
								ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
								Contact primaryTarget5 = PrimaryTarget;
								Doctrine doctrine9 = m_EventVal.Doctrine;
								string_11 = "";
								int_4 = 0;
								if (weaponry2.PopConsumer(primaryTarget5, bool_1: true, doctrine9, ref string_11, ref int_4))
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								}
								else if (!m_EventVal.IsPaintingATarget && !m_EventVal.WillNeedToPaintATarget)
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
								}
								else
								{
									m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								}
								goto IL_75c8;
							}
						}
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
					}
					else if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					goto IL_75c8;
				case Mission._MissionClass.Support:
					if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
					{
						if (!Information.IsNothing(PrimaryTarget))
						{
							b = (byte?)m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
						}
						if (m_EventVal.Navigator.IsFinishingSupportMissionCourse(float_0))
						{
							if (!GetAircraft().Weaponry.IsGuidingWeaponsInAir())
							{
								GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: false, bool_3: true);
							}
						}
						else if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
						}
					}
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse && m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0)
					{
						PopFacade((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0), m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
					}
					return;
				case Mission._MissionClass.Ferry:
				{
					if (!Information.IsNothing(PrimaryTarget))
					{
						b = (byte?)m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							return;
						}
					}
					ActiveUnit actualDestinationHost3 = GetAircraft().AirOps.ActualDestinationHost;
					if (GetAircraft().Navigator.HasReachedLandingAssemblyPoint(actualDestinationHost3))
					{
						if (!GetAircraft().Weaponry.IsGuidingWeaponsInAir())
						{
							GetAircraft().AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
						}
					}
					else
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnFerryMission;
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					return;
				}
				case Mission._MissionClass.Mining:
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.MineClearing:
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.Cargo:
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					}
					IL_75c8:
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse && m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0)
					{
						PopFacade((float)((double)m_EventVal.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0), m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value);
					}
					return;
				}
			}
			if (PrimaryTarget == null)
			{
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
				{
					return;
				}
				if (base.PrimaryPickupTarget != null && !m_EventVal.Navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.PlotCourseToPickupPoint();
					if (m_EventVal.Navigator.HasPlottedCourse())
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						return;
					}
					m_EventVal.AddMessage(m_EventVal.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
					m_EventVal.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
				}
				if (m_EventVal.Status != 0)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
			}
			else
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 200344", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void IssueImmediateReturnToBase()
	{
		GetAircraft().FuelState = GetAircraft().GetIsBingoOrJoker(null, GetAircraft().Doctrine.GetBingoJoker(GetAircraft().ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
		GetAircraft().WeaponState = GetAircraft().Weaponry.IsWinchesterOrShotgun();
		GetAircraft().AirOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
		string text = "";
		if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
		{
			text = " (" + GetAircraft().UnitClass + ")";
		}
		string text2 = "";
		ActiveUnit actualDestinationHost = GetAircraft().AirOps.ActualDestinationHost;
		if (!Information.IsNothing(actualDestinationHost))
		{
			text2 = " (" + actualDestinationHost.Name + ")";
		}
		GetAircraft().Navigator.ResetTimeToNextPathfinderCheck();
		GetAircraft().ParentScen.AddMessage(GetAircraft().Name + text + " Is returning to base following the shortest path possible (plotted course was too long for remaining fuel)" + text2, "单元返回基地", LoggedMessage.MessageType.AirOps, 5, GetAircraft().ObjectID, GetAircraft().GetUnitSide(), new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
	}

	public override void EvaluateThreats()
	{
		if (m_EventVal == null || m_EventVal.GetUnitSide() == null)
		{
			return;
		}
		ClearAllThreats();
		List<Contact> list = new List<Contact>(PrintClient());
		try
		{
			foreach (Contact item in list)
			{
				try
				{
					if (ReadFacade(item))
					{
						AddContactToThreatList(item);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 100381", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100382", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] CreateFacade()
	{
		return m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
		if (!EvaluateTargets_Enabled || GetAircraft().HasLostControlPulse_CACHED || m_EventVal == null)
		{
			return;
		}
		m_EventVal.GetUnitSide();
		try
		{
			Contact[] Local_myTargets = null;
			Contact contact_ = null;
			if (m_EventVal.Mounts.Count == 0 && m_EventVal.Sensors_Cached.Length == 0 && (GetAircraft().Loadout == null || GetAircraft().Loadout.Weapons.Length == 0))
			{
				if (PrimaryTarget != null)
				{
					DropTarget(PrimaryTarget);
				}
				Local_myTargets = base.Targets_ReadOnly;
				if (Local_myTargets.Length == 0)
				{
					return;
				}
				List<Contact> list = new List<Contact>();
				Contact[] array = Local_myTargets;
				Contact[] array2 = array;
				foreach (Contact item in array2)
				{
					list.Add(item);
				}
				{
					foreach (Contact item2 in list)
					{
						DropTarget(item2);
						contact_ = null;
					}
					return;
				}
			}
			base.EvaluateTargets(float_0, bool_0, bool_1);
			if (m_EventVal == null)
			{
				return;
			}
			Mission Local_myMission = m_EventVal.AssignedMissionOrPackage();
			Local_myTargets = base.Targets_ReadOnly;
			bool Local_MyUnitIsInsidePatrolArea = base.IsInsidePatrolArea_10nmBuffer;
			List<Contact> Local_ContactsInsideNoNavZones = ChangeClient(Local_myTargets);
			List<Weapon> Local_myAvailableWeapons = new List<Weapon>();
			Local_myAvailableWeapons.AddRange(CreateFacade());
			Doctrine._UseShootTourists? Local_Doctrine_ShootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if (PrintClient() == null)
			{
				DefineClient(Module_ActiveUnit_Sensory.ListTokenizer(m_EventVal.Sensory));
			}
			int count = PrintClient().Count;
			if (m_AccountVal == null)
			{
				m_AccountVal = new Tuple<Contact, Misc.PostureStance>[count - 1 + 1];
			}
			if (m_ValObserver.Count > 0)
			{
				m_ValObserver.Clear();
			}
			foreach (Contact item3 in PrintClient())
			{
				if (TargetingBehaviorForThisTarget(item3) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					m_ValObserver.Add(item3.ObjectID);
				}
			}
			if (Local_myMission != null && Local_myMission.IsActive)
			{
				Parallel.ForEach(PrintClient(), delegate(Contact thisContact)
				{
					string objectID2 = thisContact.ObjectID;
					if (!Local_myTargets.Contains(thisContact) && !Local_ContactsInsideNoNavZones.Contains(thisContact))
					{
						byte? b2 = (byte?)thisContact.BDA_StructuralIntegrity;
						if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
						{
							if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID2, out var value2))
							{
								value2 = thisContact.GetStance(m_EventVal.GetUnitSide());
							}
							switch (value2)
							{
							case Misc.PostureStance.Unfriendly:
							case Misc.PostureStance.Hostile:
							{
								Aircraft_AI aircraft_AI = this;
								Mission mission_ = Local_myMission;
								Doctrine._UseShootTourists? nullable_2 = Local_Doctrine_ShootTourists;
								bool bool_2 = bool_0;
								bool bool_3 = Local_MyUnitIsInsidePatrolArea;
								Misc.PostureStance? nullable_3 = value2;
								string string_3 = "";
								int int_3 = 0;
								if (aircraft_AI.ContactIsRelevantToMission(thisContact, mission_, nullable_2, bool_2, bool_3, bool_2: true, nullable_3, ref string_3, ref int_3) && !PopClient(thisContact))
								{
									if (thisContact.Type == Contact_Base.ContactType.Submarine)
									{
										if (!thisContact.IsClassifiedFalseTarget && !SeaIceProvider.PrepareWriter(thisContact.GetLongitude(), thisContact.GetLatitude()))
										{
											TargetThisContact(thisContact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
											m_ValObserver.Add(thisContact.ObjectID);
										}
									}
									else
									{
										ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
										Doctrine doctrine2 = m_EventVal.Doctrine;
										string_3 = "";
										int_3 = 0;
										if (weaponry2.PopConsumer(thisContact, bool_1: true, doctrine2, ref string_3, ref int_3, Local_myAvailableWeapons))
										{
											TargetThisContact(thisContact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
											m_ValObserver.Add(thisContact.ObjectID);
										}
									}
								}
								break;
							}
							case Misc.PostureStance.Unknown:
							{
								Misc.PostureStance? nullable_ = value2;
								string string_2 = "";
								int int_2 = 0;
								if (ContactIsRelevantToMission(thisContact, Local_myMission, Local_Doctrine_ShootTourists, bool_0, Local_MyUnitIsInsidePatrolArea, bool_2: true, nullable_, ref string_2, ref int_2) && (thisContact.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PrepareWriter(thisContact.GetLongitude(), thisContact.GetLatitude())))
								{
									TargetThisContact(thisContact, bool_0: false, bool_1: true, TargetingEntry._TargetingBehavior.AutoTargeted);
								}
								break;
							}
							case Misc.PostureStance.Neutral:
							case Misc.PostureStance.Friendly:
								break;
							}
						}
					}
				});
			}
			Weapon weapon_ = m_EventVal.Weaponry.RevertConsumer(contact_);
			Weapon weapon_2 = m_EventVal.Weaponry.CloneFacade(contact_);
			Weapon weapon_3 = null;
			Weapon weapon_4 = null;
			if (m_EventVal.IsOnActivePatrol)
			{
				Patrol patrol = (Patrol)Local_myMission;
				GlobalVariables.PatrolType type = patrol.Type;
				if ((int)type <= 1 || (int)(type - 3) <= 3)
				{
					if (patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
					{
						weapon_3 = m_EventVal.Weaponry.CountFacade(contact_, bool_1: false);
						weapon_4 = m_EventVal.Weaponry.CustomizeFacade(contact_, bool_1: false);
					}
					else
					{
						weapon_3 = null;
						weapon_4 = null;
					}
				}
			}
			else
			{
				weapon_3 = m_EventVal.Weaponry.CountFacade(contact_, bool_1: false);
				weapon_4 = m_EventVal.Weaponry.CustomizeFacade(contact_, bool_1: false);
			}
			bool flag = m_EventVal.IsOnActivePatrol && ((Patrol)Local_myMission).HasProsecutionArea;
			Doctrine._UseShootTourists useShootTourists = Doctrine._UseShootTourists.No;
			bool hasValue;
			if (hasValue = Local_Doctrine_ShootTourists.HasValue)
			{
				useShootTourists = Local_Doctrine_ShootTourists.Value;
			}
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				contact_ = PrintClient()[i];
				string objectID = contact_.ObjectID;
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out var value))
				{
					if (m_AccountVal[i] == null)
					{
						if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out value))
						{
							value = contact_.GetStance(m_EventVal.GetUnitSide());
						}
						m_AccountVal[i] = new Tuple<Contact, Misc.PostureStance>(contact_, value);
					}
					else
					{
						value = m_AccountVal[i].Item2;
					}
				}
				if (value == Misc.PostureStance.Friendly || value == Misc.PostureStance.Neutral)
				{
					continue;
				}
				contact_.GetIsDestroyed(m_EventVal.ParentScen);
				if (m_ValObserver.Contains(objectID) || Local_ContactsInsideNoNavZones.Contains(contact_))
				{
					continue;
				}
				byte? b = (byte?)contact_.BDA_StructuralIntegrity;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					continue;
				}
				if (!flag && Local_myMission != null && Local_myMission.MissionClass == Mission._MissionClass.Patrol && !contact_.IsAir_Missile_Submarine_Contact && !((Patrol)Local_myMission).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen))
				{
					Patrol patrol2 = (Patrol)Local_myMission;
					if (!contact_.GetIsInsideThisArea(patrol2.PatrolArea, m_EventVal.ParentScen, bool_0: true) && TargetingBehaviorForThisTarget(contact_) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !m_EventVal.Sensory.IsIlluminatingThisContact(contact_) && (!hasValue || useShootTourists != Doctrine._UseShootTourists.Yes))
					{
						continue;
					}
				}
				if (!m_ValObserver.Contains(objectID))
				{
					ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
					Contact contact_2 = contact_;
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = "";
					int int_ = 0;
					if (weaponry.PopConsumer(contact_2, bool_1: true, doctrine, ref string_, ref int_, Local_myAvailableWeapons) && TargetIsEligibleBasedOnWeaponRange(contact_, value, hasValue, useShootTourists, weapon_, weapon_3, weapon_4, weapon_2))
					{
						TargetThisContact(contact_, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						m_ValObserver.Add(contact_.ObjectID);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100383", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool CompareFacade(Contact contact_0)
	{
		if (GetAircraft().Loadout == null)
		{
			return false;
		}
		switch (GetAircraft().Loadout.Role)
		{
		case Loadout.LoadoutRole.Intercept_BVR:
		case Loadout.LoadoutRole.Intercept_WVR:
		case Loadout.LoadoutRole.AirSuperiority_BVR:
		case Loadout.LoadoutRole.AirSuperiority_WVR:
		case Loadout.LoadoutRole.PointDefence_BVR:
		case Loadout.LoadoutRole.PointDefence_WVR:
		case Loadout.LoadoutRole.AntiSatellite_Intercept:
		{
			Contact_Base.ContactType type = contact_0.Type;
			if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
			{
				return false;
			}
			return true;
		}
		case Loadout.LoadoutRole.NavalOnly_Strike:
		case Loadout.LoadoutRole.NavalOnly_Standoff:
		case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
		case Loadout.LoadoutRole.NavalOnly_SEAD_TALD:
		case Loadout.LoadoutRole.NavalOnly_DEAD:
			if (contact_0.Type == Contact_Base.ContactType.Surface)
			{
				return true;
			}
			return false;
		default:
			return false;
		case Loadout.LoadoutRole.LandNaval_Strike:
		case Loadout.LoadoutRole.LandNaval_Standoff:
		case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
		case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
		case Loadout.LoadoutRole.LandNaval_DEAD:
		case Loadout.LoadoutRole.Armed_Recon:
		{
			Contact_Base.ContactType type2 = contact_0.Type;
			if (type2 != Contact_Base.ContactType.Surface && (int)(type2 - 7) > 1)
			{
				return false;
			}
			return true;
		}
		case Loadout.LoadoutRole.LandOnly_Strike:
		case Loadout.LoadoutRole.LandOnly_Standoff:
		case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
		case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
		case Loadout.LoadoutRole.LandOnly_DEAD:
		case Loadout.LoadoutRole.BAI_CAS:
			if ((int)(contact_0.Type - 7) <= 1)
			{
				return true;
			}
			return false;
		}
	}

	private bool ReadFacade(Contact contact_0)
	{
		if (contact_0 == null)
		{
			return false;
		}
		if (contact_0.IsWeaponContact)
		{
			if (contact_0.ActualUnit == null)
			{
				return false;
			}
			if (contact_0.GetIsDestroyed(m_EventVal.ParentScen))
			{
				return false;
			}
			if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact_0.ObjectID, out var value))
			{
				value = contact_0.GetStance(m_EventVal.GetUnitSide());
			}
			if (value == Misc.PostureStance.Friendly)
			{
				return false;
			}
			Weapon weapon = (Weapon)contact_0.ActualUnit;
			if (weapon.ValidTargets.Aircraft)
			{
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle)
				{
					return false;
				}
				if (Math.Abs(AngleOffContactsBoresight(ref contact_0)) <= 90f)
				{
					if (Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) <= 15f)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		if (contact_0.IsAircraftContact)
		{
			if (contact_0.ActualUnit == null)
			{
				return false;
			}
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
			{
				if (!(contact_0.ActualUnit is Aircraft))
				{
					return false;
				}
				Aircraft._AircraftType type = ((Aircraft)contact_0.ActualUnit).Type;
				if ((uint)(type - 2001) > 1u && (uint)(type - 3001) > 1u)
				{
					return false;
				}
			}
			if (Math.Abs(AngleOffContactsBoresight(ref contact_0)) <= 90f)
			{
				if (Math.Abs(MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, Module_Unit.BearingToUnit_True(GetAircraft(), contact_0))) < 20f)
				{
					return false;
				}
				float num = 0f;
				foreach (Weapon item in contact_0.ActualUnit.Weaponry.AllDistinctWeaponsAboard_Actual())
				{
					if (item.Type == Weapon._WeaponType.Gun && item.MaxAirRange > num)
					{
						num = item.MaxAirRange;
					}
				}
				if ((double)Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) <= (double)num * 1.1)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private void DisableFacade(float float_0)
	{
		if (Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget.ActualUnit) > 4f)
		{
			Contact primaryTarget = PrimaryTarget;
			ActiveUnit eventVal = m_EventVal;
			string string_ = "";
			if (Math.Abs(Module_Unit.PrintTokenizer(primaryTarget, eventVal, bool_0: true, ref string_)) < 90f)
			{
				UpdateFacade(float_0);
				return;
			}
		}
		InsertFacade(float_0);
	}

	private void UpdateFacade(float float_0)
	{
		try
		{
			if (m_EventVal.Kinematics.DesiredAltitudeOverride && !Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride) && !m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				return;
			}
			Aircraft_AirOps airOps = GetAircraft().AirOps;
			airOps.Condition = Aircraft_AirOps._AirOpsCondition.const_19;
			Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
			if (Information.IsNothing(weapon))
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			}
			else if (weapon.ReadReponse())
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.const_19;
			}
			else
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			}
			Weapon weapon2 = m_EventVal.Weaponry.RevertConsumer(PrimaryTarget);
			ActiveUnit_Sensory sensory = m_EventVal.Sensory;
			Sensor[] sensor_ = null;
			Sensor sensor = sensory.ViewConsumer(bool_0: true, bool_1: true, bool_2: true, bool_3: false, ref sensor_).FirstOrDefault();
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			float num6 = (Information.IsNothing(weapon2) ? 0f : weapon2.MaxAirRange);
			float? num7 = null;
			ActiveUnit.Throttle? throttle = null;
			float? num8 = null;
			Patrol patrol = null;
			float num9;
			if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				num8 = patrol.AttackDistance_Aircraft;
				num9 = (Information.IsNothing(num8) ? ((float)Math.Max(10f + num6, (double)num6 * 1.2)) : (num8 + num6).Value);
			}
			else
			{
				num9 = (float)Math.Max(10f + num6, (double)num6 * 1.2);
			}
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				_ = m_EventVal.DesiredAltitude;
				if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					if (Information.IsNothing(patrol))
					{
						patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
					}
					num7 = ((Information.IsNothing(num8) || num <= num9) ? patrol.AttackAltitude_Aircraft : patrol.TransitAltitude_Aircraft);
				}
				if (Information.IsNothing(num7))
				{
					if (num <= num9)
					{
						if (PrimaryTarget.AltitudeIsKnown && PrimaryTarget.GetCurrentAltitude() < GetAircraft().GetCurrentAltitude() && !GetAircraft().Sensory.HasLDSDRadar && !Information.IsNothing(sensor) && num < sensor.maxRange)
						{
							if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
							{
								m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude() - 30.48f;
							}
						}
						else if (PrimaryTarget.AltitudeIsKnown && num < (float)Math.Max((double)num6 * 0.75, 10.0) && !m_EventVal.Kinematics.DesiredAltitudeOverride)
						{
							float num10 = Math.Abs(GetAircraft().GetCurrentAltitude() - PrimaryTarget.GetCurrentAltitude());
							if (num10 == 0f)
							{
								m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
							}
							else if (PrimaryTarget.GetCurrentAltitude() <= GetAircraft().GetCurrentAltitude())
							{
								float num11 = GetAircraft().ETA_To_Unit(PrimaryTarget);
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num10 / num11 * float_0;
							}
							else
							{
								float num12 = GetAircraft().ETA_To_Unit(PrimaryTarget);
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num10 / num12 * float_0;
							}
						}
					}
				}
				else
				{
					m_EventVal.DesiredAltitude = num7.Value;
				}
				if (!Information.IsNothing(weapon2) && weapon2.Type == Weapon._WeaponType.GuidedWeapon)
				{
					float val = PrimaryTarget.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen);
					float val2 = m_EventVal.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen);
					float val3 = m_EventVal.GetLandElevation_next(bool_0: true, float_0);
					float num13 = Math.Max(Math.Max(val2, val), val3);
					float num2 = 0f;
					float num3 = 0f;
					if (weapon2.MaxLaunchAlt_AGL != 0f && weapon2.MaxLaunchAlt_ASL == 0f)
					{
						num2 = weapon2.MaxLaunchAlt_AGL + num13;
						num3 = weapon2.MaxLaunchAlt_AGL;
					}
					else if (weapon2.MaxLaunchAlt_AGL == 0f && weapon2.MaxLaunchAlt_ASL != 0f)
					{
						num2 = weapon2.MaxLaunchAlt_ASL;
						num3 = weapon2.MaxLaunchAlt_ASL - num13;
					}
					else if (weapon2.MaxLaunchAlt_AGL != 0f && weapon2.MaxLaunchAlt_ASL != 0f)
					{
						num2 = Math.Min(weapon2.MaxLaunchAlt_AGL + num13, weapon2.MaxLaunchAlt_ASL);
						num3 = Math.Min(weapon2.MaxLaunchAlt_ASL - num13, weapon2.MaxLaunchAlt_AGL);
					}
					float num4 = 0f;
					float num5 = 0f;
					if (weapon2.MinLaunchAlt_AGL != 0f && weapon2.MinLaunchAlt_ASL == 0f)
					{
						num4 = weapon2.MinLaunchAlt_AGL + num13;
						num5 = weapon2.MinLaunchAlt_AGL;
					}
					else if (weapon2.MinLaunchAlt_AGL == 0f && weapon2.MinLaunchAlt_ASL != 0f)
					{
						num4 = weapon2.MinLaunchAlt_ASL;
						num5 = weapon2.MinLaunchAlt_ASL - num13;
					}
					else if (weapon2.MinLaunchAlt_AGL != 0f && weapon2.MinLaunchAlt_ASL != 0f)
					{
						num4 = Math.Max(weapon2.MinLaunchAlt_AGL + num13, weapon2.MinLaunchAlt_ASL);
						num5 = Math.Max(weapon2.MinLaunchAlt_ASL - num13, weapon2.MinLaunchAlt_AGL);
					}
					if (num4 <= m_EventVal.DesiredAltitude)
					{
						if (num2 < m_EventVal.DesiredAltitude)
						{
							m_EventVal.DesiredAltitude = num2;
						}
						else
						{
							if (m_EventVal.DesiredAltitude > num2)
							{
								m_EventVal.DesiredAltitude = num2;
							}
							if (m_EventVal.DesiredAltitude < num4)
							{
								m_EventVal.DesiredAltitude = num4;
							}
						}
					}
					else
					{
						m_EventVal.DesiredAltitude = num4;
					}
					if (num5 <= m_EventVal.DesiredAltitude_AGL)
					{
						if (num3 < m_EventVal.DesiredAltitude_AGL)
						{
							m_EventVal.DesiredAltitude_AGL = num3;
						}
						else
						{
							if (m_EventVal.DesiredAltitude_AGL > num3)
							{
								m_EventVal.DesiredAltitude_AGL = num3;
							}
							if (m_EventVal.DesiredAltitude_AGL < num5)
							{
								m_EventVal.DesiredAltitude_AGL = num5;
							}
						}
					}
					else
					{
						m_EventVal.DesiredAltitude_AGL = num5;
					}
				}
			}
			if (!Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride) && !m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				return;
			}
			if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				if (Information.IsNothing(patrol))
				{
					patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				}
				throttle = ((Information.IsNothing(num8) || num <= num9) ? patrol.AttackThrottle_Aircraft : patrol.TransitThrottle_Aircraft);
			}
			if (Information.IsNothing(throttle))
			{
				GetAircraft().Navigator.SetInterceptThrottle(m_EventVal.DesiredAltitude, null, bool_1: true, airOps.Condition);
			}
			else
			{
				m_EventVal.SetThrottle(throttle.Value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100384", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InsertFacade(float float_0)
	{
		try
		{
			Manouver_PurePursuit(float_0, 0f, 0f);
			Doctrine doctrine = null;
			Weapon weapon = null;
			if (Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride))
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, BearingToUnit_True(PrimaryTarget));
				if (relativeBearing <= 330f && relativeBearing >= 30f)
				{
					float num = GetAircraft().Kinematics.CornerVelocity;
					if (m_EventVal.CurrentSpeed < num)
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					}
					else
					{
						m_EventVal.DesiredSpeed = num;
					}
				}
				else
				{
					doctrine = m_EventVal.Doctrine;
					weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, doctrine);
					if (weapon != null)
					{
						ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
						Weapon weapon_ = weapon;
						Contact primaryTarget = PrimaryTarget;
						Sensor sensor_ = null;
						short? nullable_ = null;
						if (weaponry.CanThisWeaponEngageThisTarget(weapon_, primaryTarget, ref nullable_, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
						{
							if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= (double)weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, doctrine, bool_1: false) * 0.5)
							{
								bool flag = false;
								if (PrimaryTarget.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
								{
									foreach (Mount mount in PrimaryTarget.ActualUnit.Mounts)
									{
										if (mount.HasGuns && mount.TargetIsWithinCoverageArc(m_EventVal, PrimaryTarget.CurrentHeading))
										{
											flag = true;
											break;
										}
									}
								}
								if (flag)
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
								}
								else
								{
									m_EventVal.DesiredSpeed = PrimaryTarget.CurrentSpeed;
								}
							}
							else
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
							}
							goto IL_0299;
						}
					}
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				}
			}
			goto IL_0299;
			IL_0299:
			if (m_EventVal.Kinematics.DesiredAltitudeOverride || !PrimaryTarget.AltitudeIsKnown)
			{
				return;
			}
			if (GetAircraft().SupportsAttitude_Pitch)
			{
				m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
				CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), m_EventVal.DesiredAltitude);
			}
			else
			{
				float num6 = Math.Abs(GetAircraft().GetCurrentAltitude() - PrimaryTarget.GetCurrentAltitude());
				if (num6 == 0f)
				{
					m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
				}
				else if (PrimaryTarget.GetCurrentAltitude() <= GetAircraft().GetCurrentAltitude())
				{
					float num7 = GetAircraft().ETA_To_Unit(PrimaryTarget);
					if (num7 <= 0f)
					{
						float num8 = m_EventVal.CurrentSpeed * float_0 / 3600f;
						float num9 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
						m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num8 * Math.Abs(num6) / num9;
					}
					else
					{
						m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num6 / num7 * float_0;
					}
				}
				else
				{
					float num10 = GetAircraft().ETA_To_Unit(PrimaryTarget);
					if (num10 <= 0f)
					{
						float num11 = m_EventVal.CurrentSpeed * float_0 / 3600f;
						float num12 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
						m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num11 * Math.Abs(num6) / num12;
					}
					else
					{
						m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num6 / num10 * float_0;
					}
				}
			}
			if (Information.IsNothing(doctrine))
			{
				doctrine = m_EventVal.Doctrine;
			}
			if (Information.IsNothing(weapon))
			{
				weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, doctrine);
			}
			if (Information.IsNothing(weapon) || weapon.Type != Weapon._WeaponType.GuidedWeapon)
			{
				return;
			}
			float val = PrimaryTarget.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen);
			float val2 = m_EventVal.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen);
			float val3 = m_EventVal.GetLandElevation_next(bool_0: true, float_0);
			float num13 = Math.Max(Math.Max(val2, val), val3);
			float num2 = 0f;
			float num3 = 0f;
			if (weapon.MaxLaunchAlt_AGL != 0f && weapon.MaxLaunchAlt_ASL == 0f)
			{
				num2 = weapon.MaxLaunchAlt_AGL + num13;
				num3 = weapon.MaxLaunchAlt_AGL;
			}
			else if (weapon.MaxLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_ASL != 0f)
			{
				num2 = weapon.MaxLaunchAlt_ASL;
				num3 = weapon.MaxLaunchAlt_ASL - num13;
			}
			else if (weapon.MaxLaunchAlt_AGL != 0f && weapon.MaxLaunchAlt_ASL != 0f)
			{
				num2 = Math.Min(weapon.MaxLaunchAlt_AGL + num13, weapon.MaxLaunchAlt_ASL);
				num3 = Math.Min(weapon.MaxLaunchAlt_ASL - num13, weapon.MaxLaunchAlt_AGL);
			}
			float num4 = 0f;
			float num5 = 0f;
			if (weapon.MinLaunchAlt_AGL != 0f && weapon.MinLaunchAlt_ASL == 0f)
			{
				num4 = weapon.MinLaunchAlt_AGL + num13;
				num5 = weapon.MinLaunchAlt_AGL;
			}
			else if (weapon.MinLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_ASL != 0f)
			{
				num4 = weapon.MinLaunchAlt_ASL;
				num5 = weapon.MinLaunchAlt_ASL - num13;
			}
			else if (weapon.MinLaunchAlt_AGL != 0f && weapon.MinLaunchAlt_ASL != 0f)
			{
				num4 = Math.Max(weapon.MinLaunchAlt_AGL + num13, weapon.MinLaunchAlt_ASL);
				num5 = Math.Max(weapon.MinLaunchAlt_ASL - num13, weapon.MinLaunchAlt_AGL);
			}
			if (num4 <= m_EventVal.DesiredAltitude)
			{
				if (num2 < m_EventVal.DesiredAltitude)
				{
					m_EventVal.DesiredAltitude = num2;
				}
				else
				{
					if (m_EventVal.DesiredAltitude > num2)
					{
						m_EventVal.DesiredAltitude = num2;
					}
					if (m_EventVal.DesiredAltitude < num4)
					{
						m_EventVal.DesiredAltitude = num4;
					}
				}
			}
			else
			{
				m_EventVal.DesiredAltitude = num4;
			}
			if (num5 > m_EventVal.DesiredAltitude_AGL)
			{
				m_EventVal.DesiredAltitude_AGL = num5;
				return;
			}
			if (num3 < m_EventVal.DesiredAltitude_AGL)
			{
				m_EventVal.DesiredAltitude_AGL = num3;
				return;
			}
			if (m_EventVal.DesiredAltitude_AGL > num3)
			{
				m_EventVal.DesiredAltitude_AGL = num3;
			}
			if (m_EventVal.DesiredAltitude_AGL < num5)
			{
				m_EventVal.DesiredAltitude_AGL = num5;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100385", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float PrepareFacade(float float_0)
	{
		try
		{
			if (float_0 == m_EventVal.Attitude_Pitch)
			{
				return 0f;
			}
			float num = 0f;
			float num2 = m_EventVal.Attitude_Pitch;
			if (num2 <= 0f)
			{
				for (; num2 < float_0; num2 += m_EventVal.Kinematics.PitchRate_Positive())
				{
					num += (float)((double)m_EventVal.CurrentSpeed * 0.514444 * Math2.FillClass(num2));
				}
			}
			else
			{
				while (!(num2 <= float_0))
				{
					num += (float)((double)m_EventVal.CurrentSpeed * 0.514444 * Math2.FillClass(num2));
					num2 -= m_EventVal.Kinematics.PitchRate_Negative();
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at \u00a89083476587346", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal void ReflectFacade(float float_0, float float_1)
	{
		float num;
		if (!GetAircraft().HasLostControlPulse_CACHED && GetAircraft().GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation)
		{
			float? minimumSafeHeight = GetAircraft().MinimumSafeHeight;
			float desiredAltitude = GetAircraft().DesiredAltitude;
			num = ((minimumSafeHeight.HasValue ? new bool?(desiredAltitude < minimumSafeHeight.GetValueOrDefault()) : null).GetValueOrDefault() ? minimumSafeHeight.Value : float_1);
		}
		else
		{
			num = float_1;
		}
		float num2 = num - GetAircraft().GetCurrentAltitude();
		if (num2 == 0f)
		{
			m_EventVal.DesiredPitch = 0f;
		}
		else if (num2 <= 0f)
		{
			if (PrepareFacade(0f) <= num2)
			{
				if (!(num2 <= -10f) && (double)m_EventVal.Attitude_Pitch > -0.5)
				{
					m_EventVal.DesiredPitch = m_EventVal.Attitude_Pitch;
				}
				else
				{
					m_EventVal.DesiredPitch = 0f;
				}
				return;
			}
			if (m_EventVal.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
			{
				float num3 = (float)((double)m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false) * 0.514444);
				float num4 = m_EventVal.Kinematics.DiveRate_Nominal();
				float val = num4 / (0f - num2) * float_0 * 2f;
				val = Math.Max(1f, val);
				if (num4 <= num3)
				{
					if (num3 > 0f)
					{
						m_ObjectObserver = -(int)Math.Round(Math2.CreateClass(num4 / num3) / (double)val);
						if (m_ObjectObserver < -89)
						{
							m_ObjectObserver = -89;
						}
					}
				}
				else
				{
					m_ObjectObserver = -89;
				}
			}
			else
			{
				m_ObjectObserver = -80;
			}
			m_EventVal.DesiredPitch = m_ObjectObserver;
		}
		else if (m_EventVal.Attitude_Pitch < 0f)
		{
			m_EventVal.DesiredPitch = 0f;
		}
		else if (PrepareFacade(0f) < num2)
		{
			if (m_EventVal.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
			{
				float num5 = (float)((double)m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false) * 0.514444);
				float climbRate_Nominal = m_EventVal.Kinematics.GetClimbRate_Nominal();
				float val2 = climbRate_Nominal / num2 * float_0 * 2f;
				val2 = Math.Max(1f, val2);
				if (climbRate_Nominal <= num5)
				{
					if (num5 > 0f)
					{
						m_InstanceObserver = (int)Math.Round(Math2.CreateClass(climbRate_Nominal / num5) / (double)val2);
						if (m_InstanceObserver > 89)
						{
							m_InstanceObserver = 89;
						}
					}
				}
				else
				{
					m_InstanceObserver = 89;
				}
			}
			else
			{
				m_InstanceObserver = GetAircraft().Kinematics.MaxPositivePitchAngle;
			}
			m_EventVal.DesiredPitch = m_InstanceObserver;
		}
		else if (num2 < 10f && (double)m_EventVal.Attitude_Pitch < 0.5)
		{
			m_EventVal.DesiredPitch = m_EventVal.Attitude_Pitch;
		}
		else
		{
			m_EventVal.DesiredPitch = 0f;
		}
	}

	internal void VisitFacade(GeoPoint geoPoint_0, float float_0, float float_1)
	{
		try
		{
			if (GetAircraft().SupportsAttitude_Pitch)
			{
				if (geoPoint_0 == null)
				{
					ReflectFacade(float_0, float_1);
				}
				else
				{
					CalculateDesiredPitch(geoPoint_0.Latitude, geoPoint_0.Longitude);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 9876434676783", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void CalculateDesiredPitch(double double_0, double double_1)
	{
		if (m_EventVal.SupportsAttitude_Pitch)
		{
			float num;
			if (GetAircraft().GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation)
			{
				float? minimumSafeHeight = GetAircraft().MinimumSafeHeight;
				float desiredAltitude = GetAircraft().DesiredAltitude;
				num = ((minimumSafeHeight.HasValue ? new bool?(desiredAltitude < minimumSafeHeight.GetValueOrDefault()) : null).GetValueOrDefault() ? minimumSafeHeight.Value : GetAircraft().DesiredAltitude);
			}
			else
			{
				num = GetAircraft().DesiredAltitude;
			}
			CalculateDesiredPitch(double_0, double_1, num);
		}
	}

	public override void ReturnToBase(float float_0)
	{
		if (m_EventVal == null || m_EventVal.Navigator == null)
		{
			return;
		}
		try
		{
			if (GetAircraft().AssignedMissionOrPackage() != null && GetAircraft().AssignedMissionOrPackage().SecondaryAirBase != null)
			{
				GetAircraft().AirOps.SetAssignedHostUnit(bool_0: false, GetAircraft().AssignedMissionOrPackage().SecondaryAirBase);
			}
			if (m_EventVal.ParentScen.FifthMinuteIsChangingOnThisPulse)
			{
				RestartFacade(float_0);
			}
			if (m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker)
			{
				m_EventVal.FuelState = ActiveUnit._ActiveUnitFuelState.None;
			}
			ActiveUnit actualDestinationHost = GetAircraft().AirOps.ActualDestinationHost;
			if (actualDestinationHost == null)
			{
				if (GetAircraft().Navigator.HasPlottedCourse())
				{
					GetAircraft().Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					GetAircraft().Kinematics.Loiter(float_0);
				}
				return;
			}
			Aircraft_Navigator navigator = GetAircraft().Navigator;
			if (navigator.bool_0 && !navigator.HasPathfindingPlottedCourse && !navigator.PathFindingInProgress)
			{
				double latitude = m_EventVal.GetLatitude();
				double longitude = m_EventVal.GetLongitude();
				double latitude2 = actualDestinationHost.GetLatitude();
				double longitude2 = actualDestinationHost.GetLongitude();
				int int_ = 0;
				GeoPoint geoPoint_ = null;
				if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: false, null, ref int_, ref geoPoint_))
				{
					navigator.TriggerPathfinderThread(null, m_EventVal, null, bool_1: false, 0.15f, latitude2, longitude2, m_EventVal.ParentScen, bool_2: false);
				}
			}
			bool bool_ = false;
			if (navigator.HasReachedLandingAssemblyPoint(actualDestinationHost))
			{
				if (m_EventVal.IsGroupMember())
				{
					m_EventVal.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
				}
				GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
				GetAircraft().DesiredSpeed = GetAircraft().Kinematics.GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
				GetAircraft().SetDesiredAltitude_UseTerrainFollowing(GetAircraft(), bool_1: false);
				GetAircraft().AirOps.EnterLandingQueue(actualDestinationHost);
			}
			else if (m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
			{
				if (!Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride) || m_EventVal.Kinematics.DesiredAltitudeOverride)
				{
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					m_EventVal.Kinematics.DesiredAltitudeOverride = false;
					string text = "";
					if (GetAircraft().IsAircraft && Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
					{
						text = " (" + GetAircraft().UnitClass + ")";
					}
					GetAircraft().AddMessage(GetAircraft().Name + text + "已达到Bingo燃料并取消高度和速度覆盖。如果您想手动控制该飞机的速度或高度，请将其从当前Bingo燃料状态（U热键）中取消分配。请注意，如果您这样做，所有安全措施都将被禁用，您有责任将飞机安全地带回基地。", GetAircraft().Name + " 取消油门/高度设置(Bingo油量)", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
				}
				float num = navigator.OrderProxy(ref bool_);
				float num2 = m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false);
				if (navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
					m_EventVal.DesiredSpeed = num2;
					m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)));
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_);
					if (bool_)
					{
						m_EventVal.DesiredAltitude_AGL = num;
					}
					else
					{
						m_EventVal.DesiredAltitude = num;
					}
				}
				else
				{
					navigator.HeadToLandingAssemblyPoint(float_0, actualDestinationHost, num2, num, ref bool_);
				}
			}
			else if (GetAircraft().IsGroupWingman())
			{
				GetAircraft().Navigator.HeadToFormationStation(float_0);
			}
			else
			{
				float float_ = (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue ? m_EventVal.Kinematics.DesiredSpeedOverride.Value : ((float)m_EventVal.Kinematics.GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), ActiveUnit.Throttle.Full, bool_0: false)));
				float float_2 = (m_EventVal.Kinematics.DesiredAltitudeOverride ? m_EventVal.DesiredAltitude : navigator.OrderProxy(ref bool_));
				if (navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					navigator.HeadToLandingAssemblyPoint(float_0, actualDestinationHost, float_, float_2, ref bool_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100386", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RestartFacade(float float_0)
	{
		try
		{
			ActiveUnit actualDestinationHost = GetAircraft().AirOps.ActualDestinationHost;
			if (Information.IsNothing(actualDestinationHost))
			{
				GetAircraft().AirOps.PickNewAssignedHost_Nearest();
				return;
			}
			string text = GetAircraft().AirOps.ThisUnitCanHostMe(actualDestinationHost);
			if (actualDestinationHost.IsDestroyed || Operators.CompareString(text, "OK", TextCompare: false) != 0)
			{
				string text2 = "";
				if (GetAircraft().IsAircraft && Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
				{
					text2 = " (" + GetAircraft().UnitClass + ")";
				}
				GetAircraft().AddMessage(GetAircraft().Name + text2 + "不能由其当前分配的基地托管（" + actualDestinationHost.Name + "）。原因：" + text, GetAircraft().Name + " 无法停靠到当前基地", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
				GetAircraft().AirOps.PickNewAssignedHost_NearestToThisUnit(actualDestinationHost);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100387", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void TestFacade(float float_0, ref Weapon weapon_0)
	{
		try
		{
			if (Information.IsNothing(PrimaryTarget) || (!PrimaryTarget.IsLandContact && !PrimaryTarget.IsShipContact))
			{
				return;
			}
			if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).UpdateReponse() && weaponRec_0.CurrentLoad > 0).Count() > 0)
			{
				float num = 50f;
				IEnumerable<Weapon> enumerable = from theW in GetAircraft().Weaponry.AllDistinctWeaponsAboard_Actual()
					where theW.IsMissile && theW.UpdateReponse()
					select theW;
				if (!Information.IsNothing(enumerable) && enumerable.Count() > 0)
				{
					float num2 = enumerable.Select((Weapon weapon_0) => weapon_0.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, m_EventVal.Doctrine, bool_1: false)).Max();
					float num3 = Module_Unit.RangeToUnit_Horiz(GetAircraft(), PrimaryTarget);
					if (num3 > num || (double)num3 > (double)num2 * 0.75)
					{
						return;
					}
				}
			}
			List<Weapon> list = new List<Weapon>();
			foreach (Weapon item in m_EventVal.ParentScen.GuidedWeaponsInAir)
			{
				if (item.AI.PrimaryTarget != PrimaryTarget)
				{
					continue;
				}
				if (item.FiringParent != GetAircraft())
				{
					if (GetAircraft().IsGroupMember() && item.FiringParent.IsGroupMember() && item.FiringParent.GetParentGroup() == GetAircraft().GetParentGroup())
					{
						list.Add(item);
					}
					continue;
				}
				list.Add(item);
				if (!item.Flags.TerminalIllumination && !item.Flags.IlluminateAtLaunch)
				{
					if (item.Guidance == Weapon.WeaponGuidanceType.CommandGuided_Datalinked)
					{
						weapon_0 = item;
					}
				}
				else
				{
					weapon_0 = item;
				}
				break;
			}
			if (list.Count == 0)
			{
				return;
			}
			bool flag = false;
			WeaponSalvo[] weaponSalvos = m_EventVal.GetUnitSide().WeaponSalvos;
			for (int i = 0; i < weaponSalvos.Length; i = checked(i + 1))
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvos[i].ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							flag = true;
						}
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag && GetAircraft().Weaponry.CanPhysicallyAttackThisTargetRightNow(PrimaryTarget, bool_1: true, bool_2: true))
			{
				return;
			}
			if (list.Count > 0)
			{
				foreach (Weapon item2 in list)
				{
					Weapon weapon_ = item2;
					if ((!weapon_.Flags.TerminalIllumination && !weapon_.Flags.IlluminateAtLaunch) || m_EventVal.Sensory.IsIlluminatingThisContact(weapon_.AI.PrimaryTarget) || (weapon_.Flags.SupportsBuddyIllumination && weapon_.AttemptBuddyIllumination()))
					{
						continue;
					}
					Module_Unit.Unit.LOSCheckResult? nullable_ = null;
					bool? nullable_2 = null;
					bool? nullable_3 = null;
					bool? nullable_4 = null;
					ActiveUnit_Sensory sensory = m_EventVal.Sensory;
					Contact primaryTarget = weapon_.AI.PrimaryTarget;
					Weapon weapon_2 = weapon_;
					Sensor sensor_ = null;
					if (sensory.CanIlluminateThisContactForThisWeapon(primaryTarget, weapon_2, ref sensor_, ref nullable_2, ref nullable_3, ref nullable_, ref nullable_4))
					{
						continue;
					}
					ActiveUnit actualUnit = weapon_.AI.PrimaryTarget.ActualUnit;
					if (Information.IsNothing(actualUnit))
					{
						continue;
					}
					List<ActiveUnit> list2 = null;
					Sensor[] sensors_Cached = m_EventVal.Sensors_Cached;
					Sensor[] array2 = sensors_Cached;
					foreach (Sensor sensor in array2)
					{
						if (sensor.Status != 0 || !sensor.CanIlluminateForThisWeapon(ref weapon_) || !sensor.HasFireControlChannelAvailable())
						{
							continue;
						}
						if (sensor.Type == Sensor.Sensor_Type.Radar && Information.IsNothing(list2))
						{
							list2 = m_EventVal.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
						}
						switch (sensor.CanIlluminateTarget(m_EventVal, actualUnit, Module_Unit.RangeToUnit_Slant(m_EventVal, weapon_.AI.PrimaryTarget), list2, m_EventVal.IsShip, bool_1: false, ref nullable_2, ref nullable_3, ref nullable_, ref nullable_4))
						{
						case Sensor.SensorDetectionCheckResult.Fail_NoLOS_Terrain:
						case Sensor.SensorDetectionCheckResult.Fail_NoLOS_Horizon:
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, weapon_.AI.PrimaryTarget));
							if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
							{
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + m_EventVal.Kinematics.ClimbRate_Actual(GetAircraft().Attitude_Pitch) * float_0 * 2f;
							}
							return;
						case Sensor.SensorDetectionCheckResult.Fail_OutsideCoverageArc:
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, weapon_.AI.PrimaryTarget));
							return;
						case Sensor.SensorDetectionCheckResult.Fail_OutOfRange:
						case Sensor.SensorDetectionCheckResult.Fail_NotEnoughReturn:
						case Sensor.SensorDetectionCheckResult.Fail_Other:
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, weapon_.AI.PrimaryTarget));
							return;
						}
					}
				}
			}
			float num4 = Module_Unit.BearingToUnit_True(PrimaryTarget, GetAircraft());
			float num5 = Math2.UpdateClass(num4 + 90f);
			float num6 = Math2.UpdateClass(num4 - 90f);
			if (!m_EventVal.Navigator.HasPlottedCourse() && (!m_EventVal.IsGroupMember() || !m_EventVal.GetParentGroup().Navigator.HasPlottedCourse()))
			{
				if (Math.Abs(MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, num5)) < Math.Abs(MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, num6)))
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num5);
				}
				else
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num6);
				}
				return;
			}
			Waypoint waypoint = (m_EventVal.Navigator.HasPlottedCourse() ? ((m_EventVal.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.Target && m_EventVal.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.WeaponTarget) ? m_EventVal.Navigator.PlottedCourse[0] : ((m_EventVal.Navigator.PlottedCourse.Count() <= 1) ? m_EventVal.Navigator.PlottedCourse[0] : m_EventVal.Navigator.PlottedCourse[1])) : ((m_EventVal.GetParentGroup().Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.Target && m_EventVal.GetParentGroup().Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.WeaponTarget) ? m_EventVal.GetParentGroup().Navigator.PlottedCourse[0] : ((m_EventVal.GetParentGroup().Navigator.PlottedCourse.Count() <= 1) ? m_EventVal.GetParentGroup().Navigator.PlottedCourse[0] : m_EventVal.GetParentGroup().Navigator.PlottedCourse[1])));
			float num7 = MathFunctions.DeleteRequest(Math2.PublishClass(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), waypoint.Latitude, waypoint.Longitude), num4);
			if (num7 <= 0f)
			{
				if (num7 <= -60f)
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num5);
				}
				else if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, num6)) < 90f)
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num6);
				}
				else
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num5);
				}
			}
			else if (num7 < 60f)
			{
				if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, num5)) < 90f)
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num5);
				}
				else
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num6);
				}
			}
			else
			{
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num6);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1007843634777711", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void CalculateDesiredRoll()
	{
		if (m_EventVal == null)
		{
			return;
		}
		float relativeBearing = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, m_EventVal.DesiredHeading);
		bool flag = (!(m_EventVal.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation) || !(m_EventVal.CurrentAltitude_AGL < 500f)) && (int)(m_EventVal.Status - 2) <= 1;
		float num = 89f;
		if (GetAircraft().IsHelicopter)
		{
			num = 60f;
		}
		else
		{
			switch (GetAircraft().VisualSizeClass)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
			case GlobalVariables.TargetVisualSizeClass.Small:
			case GlobalVariables.TargetVisualSizeClass.Medium:
				num = 89f;
				break;
			case GlobalVariables.TargetVisualSizeClass.Large:
				num = 70f;
				break;
			case GlobalVariables.TargetVisualSizeClass.VLarge:
				num = 45f;
				break;
			}
		}
		if (relativeBearing == 0f)
		{
			m_EventVal.DesiredRoll = 0f;
		}
		else if (relativeBearing > 0f && relativeBearing <= 40f)
		{
			m_EventVal.DesiredRoll = 4f * relativeBearing;
		}
		else if (relativeBearing > 40f && relativeBearing <= 180f)
		{
			m_EventVal.DesiredRoll = (flag ? 90f : num);
		}
		else if (relativeBearing > 180f && relativeBearing <= 320f)
		{
			m_EventVal.DesiredRoll = (flag ? (-90f) : (0f - num));
		}
		else
		{
			m_EventVal.DesiredRoll = -4f * (360f - relativeBearing);
		}
		if (GetAircraft().Kinematics._FilterObserver == Aircraft_Kinematics.G_Straining_Mode.Recovering)
		{
			num = 45f;
		}
		if (m_EventVal.DesiredRoll > num)
		{
			m_EventVal.DesiredRoll = num;
		}
		if (m_EventVal.DesiredRoll < 0f - num)
		{
			m_EventVal.DesiredRoll = 0f - num;
		}
	}

	public override void ManouverTowardsTarget(float float_0)
	{
		try
		{
			if (PrimaryTarget == null || InterruptClient(PrimaryTarget, 50f) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return;
			}
			if (PrimaryTarget.Type == Contact_Base.ContactType.Air)
			{
				if (ResolveFacade())
				{
					MapFacade();
					return;
				}
				if (ListFacade())
				{
					ResetFacade();
					return;
				}
				if (VerifyFacade(PrimaryTarget))
				{
					ResetFacade(bool_0: true);
					return;
				}
			}
			if (StopFacade())
			{
				return;
			}
			Weapon weapon_ = null;
			float float_ = 0f;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			Misc.PostureStance postureStance = Misc.PostureStance.Unknown;
			Sensor sensor = null;
			bool bool_ = false;
			if (PrimaryTarget != null)
			{
				weapon_ = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
				if (weapon_ != null)
				{
					float_ = weapon_.SortReponse(PrimaryTarget);
					num = weapon_.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: false, null, bool_1: false);
				}
				ActiveUnit_Sensory sensory = m_EventVal.Sensory;
				Contact primaryTarget = PrimaryTarget;
				Sensor[] sensor_ = null;
				sensor = sensory.CallConsumer(primaryTarget, bool_0: true, bool_1: true, bool_2: true, bool_3: false, ref sensor_).FirstOrDefault();
				if (sensor != null)
				{
					num2 = sensor.maxRange;
				}
				num3 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
				postureStance = PrimaryTarget.GetStance(m_EventVal.GetUnitSide());
			}
			if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.CurrentSpeed > 0f)
			{
				if (Math.Abs(Math.Abs(MathFunctions.DeleteRequest(PrimaryTarget.CurrentHeading, Module_Unit.BearingToUnit_True(PrimaryTarget, m_EventVal)))) <= 90f)
				{
					if (GetAircraft().Weaponry.IsGuidingWeaponsOntoThisContact(PrimaryTarget))
					{
						Manouver_PurePursuit(float_0, 10f, float_);
					}
					else if (PrimaryTarget?.ActualUnit?.AI?.PrimaryTarget?.ActualUnit == GetAircraft())
					{
						Manouver_PurePursuit(float_0, 10f, float_);
					}
					else if ((postureStance != Misc.PostureStance.Unfriendly && postureStance != Misc.PostureStance.Hostile) || (!(num > num3) && num2 <= num3))
					{
						Manouver_InterceptCourse(float_0, null, ref bool_);
					}
					else
					{
						Manouver_PurePursuit(float_0, 10f, float_);
					}
				}
				else
				{
					Manouver_PurePursuit(float_0, 10f, float_);
				}
			}
			else
			{
				Manouver_PurePursuit(float_0, 10f, float_);
			}
			_ParameterObserver = new Tuple<Mount, float, bool>(null, -1f, item3: false);
			TurnToUnmaskPrimaryWeapon(ref weapon_, PrimaryTarget, ref _ParameterObserver);
			Weapon weapon_2 = null;
			if (IsClearedToEngageThisTarget(PrimaryTarget))
			{
				byte? b = (byte?)m_EventVal.Doctrine.GetMaintainStandoff(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					TestFacade(float_0, ref weapon_2);
				}
			}
			if (m_EventVal.Navigator.bool_0 && !PathBlockCheckInProgress)
			{
				PathBlockCheckInProgress = true;
				Task.Factory.StartNew(delegate
				{
					QueryFacade(float_0, bool_0: true);
				});
			}
			else if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
			{
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
			}
			if (PrimaryTarget.Type == Contact_Base.ContactType.Submarine && !Information.IsNothing(PrimaryTarget.UncertaintyArea))
			{
				if (!GetAircraft().Weaponry.HaveSuitableWeaponForAmbigousTarget(PrimaryTarget, bool_1: false))
				{
					if (!GetAircraft().Navigator.IsOnLocalizationRun)
					{
						if (GetAircraft().Navigator.HasPlottedCourse())
						{
							byte? b2 = (byte?)GetAircraft().Doctrine.GetIgnorePlottedCourse(GetAircraft().ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								goto IL_075a;
							}
						}
						GetAircraft().Navigator.PlotLocalizationCourse();
					}
					goto IL_075a;
				}
				if (GetAircraft().Navigator.HasPlottedCourse())
				{
					byte? b3 = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						GetAircraft().Navigator.FollowPlottedCourse(float_0);
					}
				}
			}
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
			{
				if (IsClearedToEngageThisTarget(PrimaryTarget))
				{
					OptimizeAltSpeedForNextEngagement(float_0, ref weapon_2);
				}
				else if (PrimaryTarget.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
				{
					PostFacade(bool_);
				}
			}
			if (Math.Abs(MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, GetAircraft().DesiredHeading)) > 90f)
			{
				int cornerVelocity = GetAircraft().Kinematics.CornerVelocity;
				if (GetAircraft().CurrentSpeed > (float)cornerVelocity)
				{
					GetAircraft().DesiredSpeed = cornerVelocity;
					GetAircraft().SetThrottle(GetAircraft().Kinematics.GetThrottleSuitableForThisSpeed(GetAircraft().GetCurrentAltitude(), cornerVelocity));
				}
			}
			return;
			IL_075a:
			GetAircraft().Navigator.FollowPlottedCourse(float_0);
			Aircraft_AirOps airOps = GetAircraft().AirOps;
			if (Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride) && airOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				GetAircraft().SetThrottle(ActiveUnit.Throttle.Full);
			}
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
			{
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
				{
					GetAircraft().Navigator.SetStrikeMissionOrUnassignedAltitude();
				}
				else if (m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol && m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Mining && m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
				{
					GetAircraft().Navigator.SetStrikeMissionOrUnassignedAltitude();
				}
				else
				{
					GetAircraft().Navigator.SetPatrolAltitude(bool_1: true, airOps.Condition);
				}
			}
			OptimizeAltSpeedForNextEngagement(float_0, ref weapon_2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100388", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool StopFacade()
	{
		try
		{
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive)
			{
				if ((m_EventVal.Navigator.HasFlightPlan && m_EventVal.Navigator.HasPlottedCourse()) || (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.Navigator.HasFlightPlan && m_EventVal.GetParentGroup().GroupLead.Navigator.HasPlottedCourse()))
				{
					Waypoint waypoint_;
					DateTime? previousWaypointTime;
					if (m_EventVal.Navigator.HasPlottedCourse())
					{
						waypoint_ = m_EventVal.Navigator.PlottedCourse[0];
						previousWaypointTime = m_EventVal.Navigator.PreviousWaypointTime;
					}
					else
					{
						waypoint_ = m_EventVal.GetParentGroup().GroupLead.Navigator.PlottedCourse[0];
						previousWaypointTime = m_EventVal.GetParentGroup().GroupLead.Navigator.PreviousWaypointTime;
					}
					if ((waypoint_.Type == Waypoint.WaypointType.Target || waypoint_.Type == Waypoint.WaypointType.WeaponTarget) && (waypoint_.AttackMethod == Mission._AttackMethod.EchelonAtActionPoint || waypoint_.AttackMethod == Mission._AttackMethod.SplitAtActionPoint) && ((waypoint_.Separation_Time > 0f) & (waypoint_.SpacingManeuver_Time > 0f)))
					{
						DateTime? dateTime = null;
						if (Information.IsNothing(previousWaypointTime))
						{
							if (!Information.IsNothing(waypoint_.Time_Zulu))
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								dateTime = waypoint_.Time_Zulu;
							}
						}
						else
						{
							dateTime = previousWaypointTime.Value.AddSeconds(waypoint_.Leg_Time_Straight + waypoint_.Leg_Time_Turn + waypoint_.Hold_Time + waypoint_.Station_Time + waypoint_.SpacingManeuver_Time);
						}
						if (Information.IsNothing(dateTime))
						{
							return false;
						}
						switch (m_EventVal.FlightRole)
						{
						case Mission.Flight.FlightElement.LeadElement:
							if (m_EventVal.IsGroupLead())
							{
								dateTime = dateTime.Value.AddSeconds((float)(m_EventVal.GetParentGroup().Units.Count - 1) * waypoint_.Separation_Time);
							}
							break;
						case Mission.Flight.FlightElement.LeadElementWingman:
							if (m_EventVal.IsGroupLead())
							{
								dateTime = dateTime.Value.AddSeconds((float)(m_EventVal.GetParentGroup().Units.Count - 1) * waypoint_.Separation_Time);
							}
							else
							{
								if (!m_EventVal.IsGroupMember())
								{
									break;
								}
								int num4 = 0;
								for (int l = m_EventVal.GetParentGroup().Units.Count - 1; l >= 0; l += -1)
								{
									ActiveUnit activeUnit4 = m_EventVal.GetParentGroup().Units.Values.ElementAtOrDefault(l);
									if (!activeUnit4.IsGroupLead())
									{
										if (activeUnit4 == m_EventVal)
										{
											dateTime = dateTime.Value.AddSeconds((float)num4 * waypoint_.Separation_Time);
											break;
										}
										num4++;
									}
								}
							}
							break;
						case Mission.Flight.FlightElement.SecondElement:
							if (m_EventVal.IsGroupLead())
							{
								dateTime = dateTime.Value.AddSeconds((float)(m_EventVal.GetParentGroup().Units.Count - 1) * waypoint_.Separation_Time);
							}
							else
							{
								if (!m_EventVal.IsGroupMember())
								{
									break;
								}
								int num3 = 0;
								for (int k = m_EventVal.GetParentGroup().Units.Count - 1; k >= 0; k += -1)
								{
									ActiveUnit activeUnit3 = m_EventVal.GetParentGroup().Units.Values.ElementAtOrDefault(k);
									if (!activeUnit3.IsGroupLead())
									{
										if (activeUnit3 == m_EventVal)
										{
											dateTime = dateTime.Value.AddSeconds((float)num3 * waypoint_.Separation_Time);
											break;
										}
										num3++;
									}
								}
							}
							break;
						case Mission.Flight.FlightElement.SecondElementWingman:
							if (m_EventVal.IsGroupLead())
							{
								dateTime = dateTime.Value.AddSeconds((float)(m_EventVal.GetParentGroup().Units.Count - 1) * waypoint_.Separation_Time);
							}
							else
							{
								if (!m_EventVal.IsGroupMember())
								{
									break;
								}
								int num2 = 0;
								for (int j = m_EventVal.GetParentGroup().Units.Count - 1; j >= 0; j += -1)
								{
									ActiveUnit activeUnit2 = m_EventVal.GetParentGroup().Units.Values.ElementAtOrDefault(j);
									if (!activeUnit2.IsGroupLead())
									{
										if (activeUnit2 == m_EventVal)
										{
											dateTime = dateTime.Value.AddSeconds((float)num2 * waypoint_.Separation_Time);
											break;
										}
										num2++;
									}
								}
							}
							break;
						case Mission.Flight.FlightElement.ThirdElement:
							if (m_EventVal.IsGroupLead())
							{
								dateTime = dateTime.Value.AddSeconds((float)(m_EventVal.GetParentGroup().Units.Count - 1) * waypoint_.Separation_Time);
							}
							else
							{
								if (!m_EventVal.IsGroupMember())
								{
									break;
								}
								int num5 = 0;
								for (int m = m_EventVal.GetParentGroup().Units.Count - 1; m >= 0; m += -1)
								{
									ActiveUnit activeUnit5 = m_EventVal.GetParentGroup().Units.Values.ElementAtOrDefault(m);
									if (!activeUnit5.IsGroupLead())
									{
										if (activeUnit5 == m_EventVal)
										{
											dateTime = dateTime.Value.AddSeconds((float)num5 * waypoint_.Separation_Time);
											break;
										}
										num5++;
									}
								}
							}
							break;
						case Mission.Flight.FlightElement.ThirdElementWingman:
							if (m_EventVal.IsGroupLead())
							{
								dateTime = dateTime.Value.AddSeconds((float)(m_EventVal.GetParentGroup().Units.Count - 1) * waypoint_.Separation_Time);
							}
							else
							{
								if (!m_EventVal.IsGroupMember())
								{
									break;
								}
								int num = 0;
								for (int i = m_EventVal.GetParentGroup().Units.Count - 1; i >= 0; i += -1)
								{
									ActiveUnit activeUnit = m_EventVal.GetParentGroup().Units.Values.ElementAtOrDefault(i);
									if (!activeUnit.IsGroupLead())
									{
										if (activeUnit == m_EventVal)
										{
											dateTime = dateTime.Value.AddSeconds((float)num * waypoint_.Separation_Time);
											break;
										}
										num++;
									}
								}
							}
							break;
						}
						return m_EventVal.AI.ManouverForSpace(dateTime, ref waypoint_, bool_0: false);
					}
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101373", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override bool ManouverForSpace(DateTime? nullable_0, ref Waypoint waypoint_0, bool bool_0)
	{
		try
		{
			if (m_EventVal.CurrentSpeed == 0f)
			{
				return false;
			}
			if (Information.IsNothing(waypoint_0))
			{
				return false;
			}
			if (Information.IsNothing(nullable_0))
			{
				if (Information.IsNothing(m_EventVal.Navigator.PreviousWaypointTime))
				{
					return false;
				}
				nullable_0 = m_EventVal.Navigator.PreviousWaypointTime.Value.AddSeconds(waypoint_0.Leg_Time_Straight + waypoint_0.Leg_Time_Turn + waypoint_0.Hold_Time + waypoint_0.Station_Time + waypoint_0.SpacingManeuver_Time);
			}
			double num = CancelFacade(ref m_EventVal.ParentScen, ref nullable_0, ref waypoint_0, bool_0);
			if (num <= 0.0 && (num != -3.4028234663852886E+38 || (nullable_0.Value - m_EventVal.ParentScen.Time).TotalSeconds <= 60.0))
			{
				return false;
			}
			float num2 = ((Information.IsNothing(m_EventVal.Navigator.PreviousWaypointLatitude) || Information.IsNothing(m_EventVal.Navigator.PreviousWaypointLongitude)) ? Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint_0.Latitude, waypoint_0.Longitude) : Math2.PublishClass(m_EventVal.Navigator.PreviousWaypointLatitude.Value, m_EventVal.Navigator.PreviousWaypointLongitude.Value, waypoint_0.Latitude, waypoint_0.Longitude));
			if (bool_0)
			{
				if (Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint_0.Latitude, waypoint_0.Longitude) <= Weapon.StandOffMaxRange)
				{
					if (num % 120.0 <= 60.0)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
						return true;
					}
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 + 90f));
					return true;
				}
				return false;
			}
			if (waypoint_0.Type == Waypoint.WaypointType.Target || waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
			{
				switch (m_EventVal.FlightRole)
				{
				case Mission.Flight.FlightElement.LeadElement:
					if (waypoint_0.AttackMethod == Mission._AttackMethod.SplitAtActionPoint)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 + 90f));
						return true;
					}
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
					return true;
				case Mission.Flight.FlightElement.LeadElementWingman:
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
					return true;
				case Mission.Flight.FlightElement.SecondElement:
					if (waypoint_0.AttackMethod == Mission._AttackMethod.SplitAtActionPoint)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 + 90f));
						return true;
					}
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
					return true;
				case Mission.Flight.FlightElement.SecondElementWingman:
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
					return true;
				case Mission.Flight.FlightElement.ThirdElement:
					if (waypoint_0.AttackMethod == Mission._AttackMethod.SplitAtActionPoint)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 + 90f));
						return true;
					}
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
					return true;
				case Mission.Flight.FlightElement.ThirdElementWingman:
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
					return true;
				}
			}
			float num3 = (float)(nullable_0.Value - m_EventVal.ParentScen.Time).TotalSeconds;
			if (num3 >= 90f && num / (double)num3 <= 0.1 && num != -3.4028234663852886E+38)
			{
				if (num % 60.0 < 30.0)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 + 45f));
					return true;
				}
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 45f));
				return true;
			}
			if (num % 240.0 <= 120.0)
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 - 90f));
				return true;
			}
			m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(num2 + 90f));
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101374", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override bool ManouverRaceTrack(ref Scenario scenario_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1)
	{
		try
		{
			if (m_EventVal.CurrentSpeed == 0f)
			{
				RaceTrackPoint = null;
				return false;
			}
			if (Information.IsNothing(waypoint_0))
			{
				RaceTrackPoint = null;
				return false;
			}
			if (Information.IsNothing(waypoint_1))
			{
				RaceTrackPoint = null;
				return false;
			}
			if (Information.IsNothing(waypoint_1.Time_Zulu))
			{
				RaceTrackPoint = null;
				return false;
			}
			if (Information.IsNothing(RaceTrackPoint))
			{
				RaceTrackPoint = new GeoPoint(waypoint_0.Longitude, waypoint_0.Latitude);
			}
			if (m_EventVal.Navigator.HaveReachedPoint(RaceTrackPoint.Latitude, RaceTrackPoint.Longitude, 1f))
			{
				if (waypoint_0.Longitude == RaceTrackPoint.Longitude && waypoint_0.Latitude == RaceTrackPoint.Latitude)
				{
					if (waypoint_0.CheckReponse() && !Information.IsNothing(waypoint_0.RaceTrackHelperPoint))
					{
						RaceTrackPoint.Longitude = waypoint_0.RaceTrackHelperPoint.Longitude;
						RaceTrackPoint.Latitude = waypoint_0.RaceTrackHelperPoint.Latitude;
					}
					else
					{
						if (Information.IsNothing(m_EventVal.Navigator.PreviousWaypointLatitude) || Information.IsNothing(m_EventVal.Navigator.PreviousWaypointLongitude))
						{
							RaceTrackPoint = null;
							return false;
						}
						RaceTrackPoint.Longitude = m_EventVal.Navigator.PreviousWaypointLongitude.Value;
						RaceTrackPoint.Latitude = m_EventVal.Navigator.PreviousWaypointLatitude.Value;
					}
				}
				else
				{
					RaceTrackPoint.Longitude = waypoint_0.Longitude;
					RaceTrackPoint.Latitude = waypoint_0.Latitude;
				}
			}
			DateTime value = waypoint_1.Time_Zulu.Value;
			float num = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint_1.Latitude, waypoint_1.Longitude);
			Misc.TurnDirection turnDirection = Misc.CountValue(m_EventVal.CurrentHeading, num);
			float float_ = 0f;
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_ = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_ = -9f;
				break;
			}
			float float_2 = m_EventVal.CurrentHeading;
			float float_3 = (Information.IsNothing(waypoint_0.DesiredSpeed) ? m_EventVal.CurrentSpeed : waypoint_0.DesiredSpeed.Value);
			if (!Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.DesiredAltitude.HasValue)
			{
				DateTime? time_Zulu = waypoint_0.Time_Zulu;
				DateTime time = m_EventVal.ParentScen.Time;
				if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(time_Zulu.GetValueOrDefault(), time) < 0) : null).GetValueOrDefault())
				{
					float? desiredAltitude = waypoint_0.DesiredAltitude;
					float desiredAltitude2 = m_EventVal.DesiredAltitude;
					if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() > desiredAltitude2) : null).GetValueOrDefault())
					{
						m_EventVal.DesiredAltitude = waypoint_0.DesiredAltitude.Value;
						float maximumAltitude = m_EventVal.Kinematics.GetMaximumAltitude();
						float minimumAltitude = m_EventVal.Kinematics.GetMinimumAltitude();
						if (m_EventVal.DesiredAltitude <= maximumAltitude)
						{
							if (m_EventVal.DesiredAltitude < minimumAltitude)
							{
								m_EventVal.DesiredAltitude = minimumAltitude;
							}
						}
						else
						{
							m_EventVal.DesiredAltitude = maximumAltitude;
						}
					}
				}
			}
			float currentSpeed = m_EventVal.CurrentSpeed;
			List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
			bool bool_ = false;
			Waypoint[] gparam_ = new Waypoint[0];
			ref Scenario parentScen = ref m_EventVal.ParentScen;
			Doctrine doctrine_ = null;
			Waypoint waypoint_2 = Waypoint.CopyWaypoint(ref parentScen, ref waypoint_1, bool_0: false, bool_1: false, ref doctrine_);
			ref Scenario parentScen2 = ref m_EventVal.ParentScen;
			doctrine_ = null;
			Waypoint waypoint_3 = Waypoint.CopyWaypoint(ref parentScen2, ref waypoint_0, bool_0: false, bool_1: false, ref doctrine_);
			waypoint_3.Latitude = m_EventVal.GetLatitude();
			waypoint_3.Longitude = m_EventVal.GetLongitude();
			ArrayExtensions.Add(ref gparam_, waypoint_3);
			ArrayExtensions.Add(ref gparam_, waypoint_2);
			Waypoint waypoint_4 = null;
			Mission.Flight flight_ = null;
			MissionPlanner.CreateFlightPlanCurve(ref float_2, ref list_, ref waypoint_2, ref waypoint_4, ref waypoint_3, ref float_3, currentSpeed, ref flight_, float_, turnDirection, num, ref bool_, bool_1: true, "", m_EventVal.Navigator.PlottedCourse);
			float num2;
			if (bool_)
			{
				num2 = float.MinValue;
			}
			else
			{
				Mission mission_ = null;
				flight_ = null;
				ref ActiveUnit eventVal = ref m_EventVal;
				float float_4 = 0f;
				float float_5 = 0f;
				bool bool_2 = false;
				MissionPlanner.DetermineTimesAndFuelQty(ref scenario_0, ref mission_, ref flight_, ref gparam_, ref eventVal, ref float_4, ref float_5, ref bool_2, bool_1: false, bool_2: false, "", bool_3: true);
				float num3 = waypoint_2.Leg_Time_Turn + waypoint_2.Leg_Time_Straight;
				DateTime dateTime = m_EventVal.ParentScen.Time.AddSeconds(num3);
				num2 = (float)(value - dateTime).TotalSeconds;
			}
			if (num2 <= 0f && (num2 != float.MinValue || (value - m_EventVal.ParentScen.Time).TotalSeconds <= 60.0))
			{
				RaceTrackPoint = null;
				Aircraft_Navigator navigator = GetAircraft().Navigator;
				bool bool_3 = true;
				bool bool_4 = false;
				navigator.CheckIfReachedWaypoint(1f, ref bool_3, ref bool_4);
				return false;
			}
			m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), RaceTrackPoint.Latitude, RaceTrackPoint.Longitude));
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 098234572876", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			RaceTrackPoint = null;
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private double CancelFacade(ref Scenario scenario_0, ref DateTime? nullable_0, ref Waypoint waypoint_0, bool bool_0)
	{
		try
		{
			if (Information.IsNothing(waypoint_0))
			{
				return 0.0;
			}
			if (Information.IsNothing(nullable_0))
			{
				return 0.0;
			}
			DateTime time = m_EventVal.ParentScen.Time;
			DateTime? dateTime = nullable_0;
			if ((dateTime.HasValue ? new bool?(DateTime.Compare(time, dateTime.GetValueOrDefault()) >= 0) : null).GetValueOrDefault())
			{
				return -1.0;
			}
			if (!bool_0 && !Information.IsNothing(waypoint_0) && !Information.IsNothing(waypoint_0.Time_Zulu) && !Information.IsNothing(m_EventVal.Navigator.PreviousWaypointTime) && DateTime.Compare(m_EventVal.Navigator.PreviousWaypointTime.Value.AddSeconds(waypoint_0.Leg_Time_Straight + waypoint_0.Leg_Time_Turn), nullable_0.Value) >= 0)
			{
				return -1.0;
			}
			DateTime dateTime2 = default(DateTime);
			if (m_EventVal.Navigator.HasPlottedCourse())
			{
				if (!m_EventVal.Navigator.HasFlightPlan)
				{
					return -1.0;
				}
				m_EventVal.Navigator.GetFlight();
				if (!bool_0)
				{
					if (Information.IsNothing(m_EventVal.Navigator.PreviousWaypointTime))
					{
						return -1.0;
					}
					dateTime2 = m_EventVal.Navigator.PreviousWaypointTime.Value;
				}
			}
			else
			{
				if (!m_EventVal.IsGroupWingman() || Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) || !m_EventVal.GetParentGroup().GroupLead.Navigator.HasPlottedCourse())
				{
					return -1.0;
				}
				if (!m_EventVal.GetParentGroup().GroupLead.Navigator.HasFlightPlan)
				{
					return -1.0;
				}
				m_EventVal.GetParentGroup().GroupLead.Navigator.GetFlight();
				if (!bool_0)
				{
					if (Information.IsNothing(m_EventVal.GetParentGroup().GroupLead.Navigator.PreviousWaypointTime))
					{
						return -1.0;
					}
					dateTime2 = m_EventVal.GetParentGroup().GroupLead.Navigator.PreviousWaypointTime.Value;
				}
			}
			int num = m_EventVal.Navigator.GetFlight().FlightPlan.Count() - 1;
			Waypoint waypoint_ = null;
			Waypoint waypoint_2 = null;
			for (int i = 1; i <= num; i++)
			{
				waypoint_ = m_EventVal.Navigator.GetFlight().FlightPlan[i];
				if (waypoint_ != waypoint_0)
				{
					if (Information.IsNothing(waypoint_.Waypoint_LeadElementWingman) || waypoint_.Waypoint_LeadElementWingman != waypoint_0)
					{
						if (Information.IsNothing(waypoint_.Waypoint_SecondElement) || waypoint_.Waypoint_SecondElement != waypoint_0)
						{
							if (Information.IsNothing(waypoint_.Waypoint_SecondElementWingman) || waypoint_.Waypoint_SecondElementWingman != waypoint_0)
							{
								if (Information.IsNothing(waypoint_.Waypoint_ThirdElement) || waypoint_.Waypoint_ThirdElement != waypoint_0)
								{
									if (!Information.IsNothing(waypoint_.Waypoint_ThirdElementWingman) && waypoint_.Waypoint_ThirdElementWingman == waypoint_0)
									{
										waypoint_2 = (Information.IsNothing(m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_ThirdElementWingman) ? m_EventVal.Navigator.GetFlight().FlightPlan[i - 1] : m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_ThirdElementWingman);
										waypoint_ = waypoint_.Waypoint_ThirdElement;
										break;
									}
									continue;
								}
								waypoint_2 = (Information.IsNothing(m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_ThirdElement) ? m_EventVal.Navigator.GetFlight().FlightPlan[i - 1] : m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_ThirdElement);
								waypoint_ = waypoint_.Waypoint_ThirdElement;
								break;
							}
							waypoint_2 = (Information.IsNothing(m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_SecondElementWingman) ? m_EventVal.Navigator.GetFlight().FlightPlan[i - 1] : m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_SecondElementWingman);
							waypoint_ = waypoint_.Waypoint_SecondElementWingman;
							break;
						}
						waypoint_2 = (Information.IsNothing(m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_SecondElement) ? m_EventVal.Navigator.GetFlight().FlightPlan[i - 1] : m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_SecondElement);
						waypoint_ = waypoint_.Waypoint_SecondElement;
						break;
					}
					waypoint_2 = (Information.IsNothing(m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_LeadElementWingman) ? m_EventVal.Navigator.GetFlight().FlightPlan[i - 1] : m_EventVal.Navigator.GetFlight().FlightPlan[i - 1].Waypoint_LeadElementWingman);
					waypoint_ = waypoint_.Waypoint_LeadElementWingman;
					break;
				}
				waypoint_2 = m_EventVal.Navigator.GetFlight().FlightPlan[i - 1];
				break;
			}
			if (!Information.IsNothing(waypoint_) && !Information.IsNothing(waypoint_2))
			{
				if (!bool_0 && !Information.IsNothing(nullable_0) && !Information.IsNothing(waypoint_2.Time_Zulu))
				{
					time = dateTime2;
					dateTime = waypoint_2.Time_Zulu;
					if ((dateTime.HasValue ? new bool?(DateTime.Compare(time, dateTime.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
					{
						nullable_0 = nullable_0.Value.AddSeconds((dateTime2 - waypoint_2.Time_Zulu.Value).TotalSeconds);
					}
				}
				float num2 = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint_.Latitude, waypoint_.Longitude);
				Misc.TurnDirection turnDirection = Misc.CountValue(m_EventVal.CurrentHeading, num2);
				float float_ = 0f;
				switch (turnDirection)
				{
				case Misc.TurnDirection.TurnRight:
					float_ = 9f;
					break;
				case Misc.TurnDirection.TurnLeft:
					float_ = -9f;
					break;
				}
				float float_2 = m_EventVal.CurrentHeading;
				float float_3 = m_EventVal.DesiredSpeed;
				float currentSpeed = m_EventVal.CurrentSpeed;
				List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
				bool bool_ = false;
				Waypoint[] gparam_ = new Waypoint[0];
				ref Scenario parentScen = ref m_EventVal.ParentScen;
				Doctrine doctrine_ = null;
				waypoint_ = Waypoint.CopyWaypoint(ref parentScen, ref waypoint_, bool_0: false, bool_1: false, ref doctrine_);
				ref Scenario parentScen2 = ref m_EventVal.ParentScen;
				doctrine_ = null;
				waypoint_2 = Waypoint.CopyWaypoint(ref parentScen2, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_);
				waypoint_.Type = Waypoint.WaypointType.TurningPoint;
				waypoint_2.Type = Waypoint.WaypointType.TurningPoint;
				waypoint_2.Latitude = m_EventVal.GetLatitude();
				waypoint_2.Longitude = m_EventVal.GetLongitude();
				ArrayExtensions.Add(ref gparam_, waypoint_2);
				ArrayExtensions.Add(ref gparam_, waypoint_);
				Waypoint waypoint_3 = null;
				Mission.Flight flight_ = null;
				MissionPlanner.CreateFlightPlanCurve(ref float_2, ref list_, ref waypoint_, ref waypoint_2, ref waypoint_3, ref float_3, currentSpeed, ref flight_, float_, turnDirection, num2, ref bool_, bool_1: true, "", m_EventVal.Navigator.PlottedCourse);
				if (bool_)
				{
					return -3.4028234663852886E+38;
				}
				Mission mission_ = null;
				flight_ = null;
				ref ActiveUnit eventVal = ref m_EventVal;
				float float_4 = 0f;
				float float_5 = 0f;
				bool bool_2 = false;
				MissionPlanner.DetermineTimesAndFuelQty(ref scenario_0, ref mission_, ref flight_, ref gparam_, ref eventVal, ref float_4, ref float_5, ref bool_2, bool_1: false, bool_2: false, "", bool_3: true);
				float num3 = waypoint_.Leg_Time_Turn + waypoint_.Leg_Time_Straight;
				DateTime dateTime3 = m_EventVal.ParentScen.Time.AddSeconds(num3);
				return (float)(nullable_0.Value - dateTime3).TotalSeconds;
			}
			return -1.0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101375", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return -1.0;
		}
	}

	public bool ContactIsRelevantToEscortsLoadout(Contact contact_0)
	{
		if (!Information.IsNothing(contact_0.ActualUnit))
		{
			if (Information.IsNothing(GetAircraft().Loadout))
			{
				return false;
			}
			Loadout loadout = GetAircraft().Loadout;
			switch (contact_0.Type)
			{
			case Contact_Base.ContactType.Air:
				if ((uint)(loadout.Role - 2001) <= 6u)
				{
					return true;
				}
				return false;
			case Contact_Base.ContactType.Surface:
				switch (loadout.Role)
				{
				default:
					return false;
				case Loadout.LoadoutRole.LandNaval_Strike:
				case Loadout.LoadoutRole.LandNaval_Standoff:
				case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
				case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
				case Loadout.LoadoutRole.LandNaval_DEAD:
				case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
				case Loadout.LoadoutRole.NavalOnly_Strike:
				case Loadout.LoadoutRole.NavalOnly_Standoff:
				case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
				case Loadout.LoadoutRole.NavalOnly_DEAD:
				case Loadout.LoadoutRole.BAI_CAS:
				case Loadout.LoadoutRole.Forward_Observer:
					return true;
				}
			case Contact_Base.ContactType.Submarine:
				if ((uint)(loadout.Role - 6001) <= 1u)
				{
					return true;
				}
				return false;
			default:
				return false;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				switch (loadout.Role)
				{
				default:
					return false;
				case Loadout.LoadoutRole.LandNaval_Standoff:
				case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
				case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
				case Loadout.LoadoutRole.LandNaval_DEAD:
				case Loadout.LoadoutRole.LandOnly_Strike:
				case Loadout.LoadoutRole.LandOnly_Standoff:
				case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
				case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
				case Loadout.LoadoutRole.LandOnly_DEAD:
				case Loadout.LoadoutRole.BAI_CAS:
				case Loadout.LoadoutRole.Forward_Observer:
					return true;
				}
			}
		}
		return false;
	}

	private bool VerifyFacade(Contact contact_0)
	{
		if (m_EventVal.IsGroupMember())
		{
			foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
			{
				if (value == m_EventVal || !value.IsAircraft)
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)value;
				if (aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.BVRCrank || !aircraft.Weaponry.IsGuidingWeaponsOntoThisContact(contact_0) || !(Module_Unit.RangeToUnit_Horiz(m_EventVal, value) < 50f))
				{
					continue;
				}
				if (IsClearedToEngageThisTarget(contact_0))
				{
					Side unitSide = m_EventVal.GetUnitSide();
					ref ActiveUnit eventVal = ref m_EventVal;
					TargetingEntry._TargetingBehavior _TargetingBehavior_ = TargetingEntry._TargetingBehavior.AutoTargeted;
					if (unitSide.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref eventVal, ref contact_0, ref _TargetingBehavior_) >= 1)
					{
						continue;
					}
				}
				return true;
			}
		}
		return false;
	}

	private bool ListFacade()
	{
		byte? b = (byte?)GetAircraft().Doctrine.method_0(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return false;
		}
		try
		{
			if (base.Targets_ReadOnly.Length == 0)
			{
				return false;
			}
			if (GetAircraft().ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return false;
			}
			if ((from theW in GetAircraft().Weaponry.IsGuidingWeaponsInAir_List()
				where theW.ReadReponse()
				select theW).ToList().Count == 0)
			{
				return false;
			}
			bool flag = false;
			foreach (Contact contacts_ in m_EventVal.GetUnitSide().Contacts_List)
			{
				if (contacts_.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Friendly && contacts_.GetStance(m_EventVal.GetUnitSide()) != 0 && contacts_.Type == Contact_Base.ContactType.Air)
				{
					ActiveUnit eventVal = m_EventVal;
					string string_ = "";
					if (Math.Abs(Module_Unit.PrintTokenizer(eventVal, contacts_, bool_0: true, ref string_)) < 70f)
					{
						ActiveUnit eventVal2 = m_EventVal;
						string_ = "";
						Math.Abs(Module_Unit.PrintTokenizer(contacts_, eventVal2, bool_0: true, ref string_));
						Sensor[] sensors_Cached = GetAircraft().Sensors_Cached;
						Sensor[] array = sensors_Cached;
						foreach (Sensor sensor in array)
						{
							if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.TargetIsWithinCoverageArc(contacts_))
							{
								flag = true;
								break;
							}
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).ReadReponse() && weaponRec_0.CurrentLoad > 0).Count() == 0 && flag)
			{
				return true;
			}
			List<Weapon> list = (from theW in GetAircraft().Weaponry.AllDistinctWeaponsAboard_Actual()
				where theW.IsAAW && !theW.ReadReponse()
				select theW).ToList();
			if (list.Count == 0)
			{
				return true;
			}
			float num = list.Select((Weapon theW) => theW.MaxAirRange).Max();
			WeaponSalvo[] weaponSalvos = m_EventVal.GetUnitSide().WeaponSalvos;
			WeaponSalvo[] array2 = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array2)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				WeaponSalvo.Shooter[] array3 = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array3)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
					{
						if (!(Module_Unit.RangeToUnit_Horiz(GetAircraft(), weaponSalvo.Target) >= num))
						{
							return false;
						}
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							return false;
						}
					}
				}
			}
			if (flag)
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100389", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ResolveFacade()
	{
		Doctrine._BVRLogicEnum? bVRLogicEnum = GetAircraft().Doctrine.method_0(GetAircraft().ParentScen, bool_0: false, bool_1: false, bool_2: false);
		byte? b = (byte?)bVRLogicEnum;
		bool? flag;
		bool? flag2 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null));
		bool? flag3;
		bool? flag4;
		if (flag2.HasValue && flag.GetValueOrDefault())
		{
			flag3 = true;
		}
		else
		{
			b = (byte?)bVRLogicEnum;
			flag2 = (flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
			flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
		}
		flag4 = flag3;
		if (flag4.GetValueOrDefault())
		{
			return false;
		}
		b = (byte?)bVRLogicEnum;
		bool result = false;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			try
			{
				if (base.Targets_ReadOnly.Length == 0)
				{
					return false;
				}
				if (GetAircraft().ParentScen.GuidedWeaponsInAir.Count == 0)
				{
					return false;
				}
				if (GetAircraft().ParentScen.GuidedWeaponsInAir.Where((Weapon weapon_0) => weapon_0.FiringParent == GetAircraft() && weapon_0.ReadReponse()).ToList().Count == 0)
				{
					return false;
				}
				foreach (Weapon item in (from theW in GetAircraft().Weaponry.IsGuidingWeaponsInAir_List()
					where theW.ReadReponse()
					select theW).ToList())
				{
					Sensor[] sensors_Cached = GetAircraft().Sensors_Cached;
					for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
					{
						if (sensors_Cached[i].SemiActiveWeaponsGuided.Contains(item))
						{
							return false;
						}
					}
				}
				bool flag5 = false;
				foreach (Contact contacts_ in m_EventVal.GetUnitSide().Contacts_List)
				{
					if (contacts_.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Friendly && contacts_.GetStance(m_EventVal.GetUnitSide()) != 0 && contacts_.Type == Contact_Base.ContactType.Air)
					{
						ActiveUnit eventVal = m_EventVal;
						string string_ = "";
						if (!(Math.Abs(Module_Unit.PrintTokenizer(eventVal, contacts_, bool_0: true, ref string_)) >= 70f))
						{
							flag5 = true;
							break;
						}
					}
					if (flag5)
					{
						break;
					}
				}
				if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).ReadReponse() && weaponRec_0.CurrentLoad > 0).Count() == 0 && flag5)
				{
					return true;
				}
				IEnumerable<Weapon> source = from theW in GetAircraft().Weaponry.AllDistinctWeaponsAboard_Actual()
					where theW.IsAAW && !theW.ReadReponse()
					select theW;
				if (source.Count() == 0)
				{
					return true;
				}
				float num = source.Select((Weapon theW) => theW.MaxAirRange).Max();
				WeaponSalvo[] weaponSalvos = m_EventVal.GetUnitSide().WeaponSalvos;
				WeaponSalvo[] array = weaponSalvos;
				foreach (WeaponSalvo weaponSalvo in array)
				{
					WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
					WeaponSalvo.Shooter[] array2 = shootersList;
					foreach (WeaponSalvo.Shooter shooter in array2)
					{
						if (Operators.CompareString(shooter.ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
						{
							if (!(Module_Unit.RangeToUnit_Horiz(GetAircraft(), weaponSalvo.Target) >= num))
							{
								return false;
							}
							if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
							{
								return false;
							}
						}
					}
				}
				if (flag5)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100389", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = false;
				ProjectData.ClearProjectError();
				return false;
			}
		}
		b = (byte?)bVRLogicEnum;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
		{
			try
			{
				if (base.Targets_ReadOnly.Length == 0)
				{
					return false;
				}
				if (GetAircraft().ParentScen.GuidedWeaponsInAir.Count == 0)
				{
					return false;
				}
				if (GetAircraft().ParentScen.GuidedWeaponsInAir.Where((Weapon weapon_0) => weapon_0.FiringParent == GetAircraft() && weapon_0.ReadReponse()).ToList().Count == 0)
				{
					return false;
				}
				foreach (Weapon item2 in (from theW in GetAircraft().Weaponry.IsGuidingWeaponsInAir_List()
					where theW.ReadReponse()
					select theW).ToList())
				{
					Sensor[] sensors_Cached2 = GetAircraft().Sensors_Cached;
					for (int j = 0; j < sensors_Cached2.Length; j = checked(j + 1))
					{
						if (sensors_Cached2[j].SemiActiveWeaponsGuided.Contains(item2))
						{
							return false;
						}
					}
				}
				bool flag6 = false;
				foreach (Contact contacts_2 in m_EventVal.GetUnitSide().Contacts_List)
				{
					if (contacts_2.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Friendly && contacts_2.GetStance(m_EventVal.GetUnitSide()) != 0 && contacts_2.Type == Contact_Base.ContactType.Air)
					{
						ActiveUnit eventVal2 = m_EventVal;
						string string_2 = "";
						if (!(Math.Abs(Module_Unit.PrintTokenizer(eventVal2, contacts_2, bool_0: true, ref string_2)) >= 70f))
						{
							flag6 = true;
							break;
						}
					}
					if (flag6)
					{
						break;
					}
				}
				if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).ReadReponse() && weaponRec_0.CurrentLoad > 0).Count() == 0 && flag6)
				{
					return true;
				}
				IEnumerable<Weapon> source2 = from theW in GetAircraft().Weaponry.AllDistinctWeaponsAboard_Actual()
					where theW.IsAAW && !theW.ReadReponse()
					select theW;
				if (source2.Count() == 0)
				{
					return true;
				}
				float num2 = source2.Select((Weapon theW) => theW.MaxAirRange).Max();
				WeaponSalvo[] weaponSalvos2 = m_EventVal.GetUnitSide().WeaponSalvos;
				WeaponSalvo[] array3 = weaponSalvos2;
				foreach (WeaponSalvo weaponSalvo2 in array3)
				{
					WeaponSalvo.Shooter[] shootersList2 = weaponSalvo2.ShootersList;
					WeaponSalvo.Shooter[] array4 = shootersList2;
					foreach (WeaponSalvo.Shooter shooter2 in array4)
					{
						if (Operators.CompareString(shooter2.ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
						{
							if (!(Module_Unit.RangeToUnit_Horiz(GetAircraft(), weaponSalvo2.Target) >= num2))
							{
								return false;
							}
							if (shooter2.QuantityAssigned - shooter2.QuantityFired > 0)
							{
								return false;
							}
						}
					}
				}
				if (flag6)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100389", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = false;
				ProjectData.ClearProjectError();
				return false;
			}
		}
		return result;
	}

	private void PostFacade(bool bool_0)
	{
		try
		{
			if (Information.IsNothing(PrimaryTarget.ActualUnit))
			{
				ActiveUnit eventVal = m_EventVal;
				Aircraft aircraft_ = GetAircraft();
				ActiveUnit eventVal2 = m_EventVal;
				ActiveUnit eventVal3;
				bool bool_ = eventVal2.GetDesiredAltitude_UseTerrainFollowing(eventVal3 = m_EventVal);
				float desiredAltitude = MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_);
				eventVal2.SetDesiredAltitude_UseTerrainFollowing(eventVal3, bool_);
				eventVal.DesiredAltitude = desiredAltitude;
				return;
			}
			IEnumerable<Sensor> source = from sensor_0 in GetAircraft().Sensors_ReadOnly()
				where sensor_0.Codes.Classification && sensor_0.GetIsSuitableForThisTarget(PrimaryTarget.ActualUnit)
				orderby sensor_0.MaxIDRangeOnThisTarget(GetAircraft(), PrimaryTarget.ActualUnit) descending
				select sensor_0;
			if (source.Count() != 0)
			{
				float num = source.ElementAtOrDefault(0).MaxIDRangeOnThisTarget(GetAircraft(), PrimaryTarget.ActualUnit);
				if (num > 20f)
				{
					num = 20f;
				}
				float num2 = Module_Unit.RangeToUnit_Horiz(GetAircraft(), PrimaryTarget);
				if (PrimaryTarget.AltitudeIsKnown && num2 < 2f * num)
				{
					GetAircraft().DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_0: false);
				}
				else if ((!PrimaryTarget.IsSurfaceContact && !PrimaryTarget.IsSubmergedContact) || !(num2 < num))
				{
					GetAircraft().Navigator.SetInterceptThrottle(_AirOpsCondition_0: GetAircraft().AirOps.Condition, float_0: m_EventVal.DesiredAltitude, nullable_0: m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.DesiredAltitude, ActiveUnit.Throttle.Cruise, bool_0: false), bool_1: bool_0);
				}
				else
				{
					GetAircraft().DesiredAltitude = 304.80002f;
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_0: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100391", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		if (m_EventVal == null || RunFacade(float_0))
		{
			return;
		}
		if (GetAircraft().HasLostControl())
		{
			GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter, 0f);
			float num = 100f + Math.Abs(GetAircraft().Attitude_Pitch * 0.01f) + Math.Abs(GetAircraft().Attitude_Roll * 0.01f);
			if (GetAircraft().Proficiency.HasValue)
			{
				switch (GetAircraft().Proficiency.Value)
				{
				case GlobalVariables.ProficiencyLevel.Cadet:
					num *= 0.75f;
					break;
				case GlobalVariables.ProficiencyLevel.Regular:
					num *= 0.65f;
					break;
				case GlobalVariables.ProficiencyLevel.Veteran:
					num *= 0.55f;
					break;
				case GlobalVariables.ProficiencyLevel.Ace:
					num *= 0.45f;
					break;
				}
			}
			if (num <= 1f)
			{
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, GetAircraft().CurrentHeading);
				GetAircraft().DesiredAltitude = GetAircraft().GetCurrentAltitude();
				GetAircraft().DesiredAltitude_AGL = GetAircraft().CurrentAltitude_AGL;
			}
			else if (new LockRandom((int)Math.Round(GetAircraft().Span * 1000f)).Next(100) <= 50)
			{
				GetAircraft().DesiredAltitude = GetAircraft().GetCurrentAltitude() + 100f;
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(GetAircraft().CurrentHeading - 10f));
			}
			else
			{
				GetAircraft().DesiredAltitude = GetAircraft().GetCurrentAltitude() - 100f;
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(GetAircraft().CurrentHeading + 10f));
			}
			return;
		}
		m_EventVal.Navigator.m_ErrorWrapper = false;
		try
		{
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(float_0, WeaponThreat);
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().GetStatus(m_EventVal.ParentScen) == Mission.MissionStatus.Active)
			{
				switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Strike:
				{
					Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
					if (strike == null || strike == null || strike.Type != 0 || !((GetAircraft().Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse) | (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Tasked)))
					{
						break;
					}
					GetAircraft().DesiredAltitude = GetAircraft().Loadout.GetMissionProfile(GetAircraft().ParentScen).CruiseAltitudeIngress;
					if (GetAircraft().AI.PrimaryTarget == null)
					{
						break;
					}
					float num8 = BearingToUnit_True(GetAircraft().AI.PrimaryTarget);
					Aircraft_AI aI = GetAircraft().AI;
					Contact primaryTarget = PrimaryTarget;
					ActiveUnit.Throttle cruiseThrottleSettingIngress = GetAircraft().Loadout.GetMissionProfile(GetAircraft().ParentScen).CruiseThrottleSettingIngress;
					float? nullable_ = 0.1f;
					bool bool_ = false;
					if (!aI.CanInterceptTarget(primaryTarget, null, 0f, null, num8, cruiseThrottleSettingIngress, nullable_, bool_0: false, bool_1: false, ref bool_))
					{
						break;
					}
					if (m_EventVal.IsGroupMember())
					{
						foreach (ActiveUnit value3 in m_EventVal.GetParentGroup().Units.Values)
						{
							if (value3 != null && !value3.Kinematics.DesiredSpeedOverride.HasValue)
							{
								value3.SetThrottle(((Aircraft)value3).Loadout.GetMissionProfile(value3.ParentScen).CruiseThrottleSettingIngress);
							}
						}
					}
					else if (!GetAircraft().Kinematics.DesiredSpeedOverride.HasValue)
					{
						GetAircraft().SetThrottle(GetAircraft().Loadout.GetMissionProfile(GetAircraft().ParentScen).CruiseThrottleSettingIngress);
					}
					GetAircraft().SetDesiredHeading(GetAircraft().DesiredTurnRate, num8);
					break;
				}
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
					if (patrol != null)
					{
						if (patrol.UseStationAltitude_Preset.GetValueOrDefault())
						{
							patrol.StationAltitude_Aircraft = DisableClient(patrol.StationAltitude_Preset.Value);
						}
						if (patrol.UseTransitAltitude_Preset.GetValueOrDefault())
						{
							patrol.TransitAltitude_Aircraft = DisableClient(patrol.TransitAltitude_Preset.Value);
						}
						if (patrol.UseAttackAltitude_Preset.GetValueOrDefault())
						{
							patrol.AttackAltitude_Aircraft = DisableClient(patrol.AttackAltitude_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.Support:
				{
					SupportMission supportMission = (SupportMission)m_EventVal.AssignedMissionOrPackage();
					if (supportMission != null && supportMission != null)
					{
						if (supportMission.UseStationAltitude_Preset.GetValueOrDefault())
						{
							supportMission.StationAltitude_Aircraft = DisableClient(supportMission.StationAltitude_Preset.Value);
						}
						if (supportMission.UseTransitAltitude_Preset.GetValueOrDefault())
						{
							supportMission.TransitAltitude_Aircraft = DisableClient(supportMission.TransitAltitude_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					MiningMission miningMission = (MiningMission)m_EventVal.AssignedMissionOrPackage();
					if (miningMission != null && miningMission != null)
					{
						if (miningMission.UseStationAltitude_Preset.GetValueOrDefault())
						{
							miningMission.StationAltitude_Aircraft = DisableClient(miningMission.StationAltitude_Preset.Value);
						}
						if (miningMission.UseTransitAltitude_Preset.GetValueOrDefault())
						{
							miningMission.TransitAltitude_Aircraft = DisableClient(miningMission.TransitAltitude_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
				{
					MineClearingMission mineClearingMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
					if (mineClearingMission != null && mineClearingMission != null)
					{
						mineClearingMission.StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
						if (mineClearingMission.UseStationAltitude_Preset.GetValueOrDefault())
						{
							mineClearingMission.StationAltitude_Aircraft = 76.200005f;
						}
						if (mineClearingMission.UseTransitAltitude_Preset.GetValueOrDefault())
						{
							mineClearingMission.TransitAltitude_Aircraft = DisableClient(mineClearingMission.TransitAltitude_Preset.Value);
						}
					}
					break;
				}
				}
			}
			Aircraft_AirOps aircraft_AirOps_ = GetAircraft().AirOps;
			ActiveUnit._ActiveUnitStatus activeUnitStatus = m_EventVal.Status;
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
				GetAircraft().DesiredSpeed = GetAircraft().Kinematics.GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
				GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
				return;
			case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
				if (GetAircraft().IsGroupWingman() && GetAircraft().GetParentGroup().GroupLead != null && GetAircraft().GetParentGroup().GroupLead.Navigator.HasPlottedCourse())
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Tasked;
				}
				else if (GetAircraft().Navigator.HasPlottedCourse())
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				break;
			case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
				if (GetAircraft().GetUnitSide().NoNavZones.Count <= 0 || aircraft_AirOps_.A2AR_Destination == null || ((!GetAircraft().IsGroupWingman() || GetAircraft().GetParentGroup().GroupLead == null || !GetAircraft().GetParentGroup().GroupLead.Navigator.HasPlottedCourse()) && !GetAircraft().Navigator.HasPlottedCourse()))
				{
					break;
				}
				if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse)
				{
					ActiveUnit_Navigator navigator = m_EventVal.Navigator;
					double latitude = m_EventVal.GetLatitude();
					double longitude = m_EventVal.GetLongitude();
					double latitude2 = aircraft_AirOps_.A2AR_Destination.GetLatitude();
					double longitude2 = aircraft_AirOps_.A2AR_Destination.GetLongitude();
					int int_ = 0;
					GeoPoint geoPoint_ = null;
					if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: false, 0f, bool_2: false, null, bool_3: true, bool_4: false, bool_5: true, null, ref int_, ref geoPoint_))
					{
						GetAircraft().Navigator.TankerIsBlockedByNoNavZone = true;
						if (m_EventVal.ParentScen.FifthMinuteIsChangingOnThisPulse)
						{
							string text = "";
							if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
							{
								text = " (" + GetAircraft().UnitClass + ")";
							}
							string text2 = "";
							if (Operators.CompareString(aircraft_AirOps_.A2AR_Destination.Name, aircraft_AirOps_.A2AR_Destination.UnitClass, TextCompare: false) != 0)
							{
								text2 = " (" + aircraft_AirOps_.A2AR_Destination.UnitClass + ")";
							}
							GetAircraft().AddMessage(GetAircraft().Name + text + "已被命令从加油机加油" + aircraft_AirOps_.A2AR_Destination.Name + text2 + "但是加油机被禁航区阻挡。继续执行指定的任务，一旦有明确的路径，将立即前往加油机。", GetAircraft().Name + " 无法连接到加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
						}
					}
					else
					{
						GetAircraft().Navigator.TankerIsBlockedByNoNavZone = false;
					}
				}
				if (GetAircraft().Navigator.TankerIsBlockedByNoNavZone)
				{
					activeUnitStatus = m_EventVal.StatusBeforeNeedToRefuel;
				}
				break;
			}
			switch (aircraft_AirOps_.Condition)
			{
			case Aircraft_AirOps._AirOpsCondition.TransferringCargo:
				if ((GetAircraft().Loadout != null) & (GetAircraft().Loadout.Role == Loadout.LoadoutRole.SearchAndRescue || GetAircraft().Loadout.Role == Loadout.LoadoutRole.CombatSearchAndRescue))
				{
					if (GetAircraft().AI.PrimaryPickupTarget != null && (double)Module_Unit.RangeToUnit_Horiz(m_EventVal, GetAircraft().AI.PrimaryPickupTarget) > 0.1)
					{
						aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
						aircraft_AirOps_.ConditionTimer = 0f;
						GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
						GetAircraft().Navigator.PlotCourseToPickupPoint();
						return;
					}
					if (m_EventVal.CurrentAltitude_AGL > 45.72f || m_EventVal.CurrentSpeed > 10f)
					{
						aircraft_AirOps_.ConditionTimer = 120f;
					}
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					GetAircraft().SetThrottle(ActiveUnit.Throttle.FullStop);
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, GetAircraft().CurrentHeading);
					GetAircraft().DesiredAltitude = 0f;
					GetAircraft().DesiredAltitude_AGL = 0f;
					return;
				}
				if (GetAircraft().IsOnActiveCargoMission)
				{
					CargoMission cargoMission = (CargoMission)GetAircraft().AssignedMissionOrPackage();
					if (!m_EventVal.Navigator.DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
					{
						aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
						aircraft_AirOps_.ConditionTimer = 0f;
						return;
					}
				}
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				GetAircraft().SetThrottle(ActiveUnit.Throttle.FullStop);
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, GetAircraft().CurrentHeading);
				GetAircraft().DesiredAltitude = 0f;
				GetAircraft().DesiredAltitude_AGL = 0f;
				if (Module_Unit.ResetTokenizer(GetAircraft()))
				{
					if (m_EventVal.CurrentAltitude_AGL > 45.72f || m_EventVal.CurrentSpeed > 10f)
					{
						aircraft_AirOps_.ConditionTimer = 120f;
					}
				}
				else
				{
					aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					aircraft_AirOps_.ConditionTimer = 0f;
				}
				return;
			case Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar:
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				GetAircraft().SetThrottle(ActiveUnit.Throttle.FullStop);
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, GetAircraft().CurrentHeading);
				GetAircraft().DesiredAltitude = 45.72f;
				if (!Module_Unit.ResetTokenizer(GetAircraft()) && !SeaIceProvider.PrepareWriter(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()))
				{
					if (m_EventVal.GetCurrentAltitude() > 45.72f)
					{
						aircraft_AirOps_.ConditionTimer = 240f;
					}
				}
				else
				{
					aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					aircraft_AirOps_.ConditionTimer = 0f;
				}
				return;
			}
			if (GetAircraft().Crew == 0 && !GetAircraft().CommStuff.IsConnectedToSideNetwork && !GetAircraft().IsRTB)
			{
				GetAircraft().Kinematics.Loiter(float_0);
				return;
			}
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.Unassigned:
				if (m_EventVal.IsGroupLead())
				{
					GetAircraft().Kinematics.Loiter(float_0);
				}
				else if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup)
					{
						m_EventVal.Navigator.HeadToFormationStation(float_0);
					}
					else
					{
						GetAircraft().Kinematics.Loiter(float_0);
					}
				}
				else
				{
					bool? flag3;
					if (GetAircraft().IsHelicopter && m_EventVal.Sensory.HasAvailableDippingSonar && m_EventVal.GetCurrentAltitude() <= 45.72f && m_EventVal.DesiredAltitude <= 45.72f && m_EventVal.GetLandElevation_next(bool_0: false, float_0) < 0)
					{
						byte? b4 = (byte?)m_EventVal.Doctrine.GetDippingSonar(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						flag3 = (b4.HasValue ? new bool?(b4.GetValueOrDefault() == 0) : null);
					}
					else
					{
						flag3 = false;
					}
					bool? flag4 = flag3;
					bool? flag5 = flag3;
					bool? flag6 = ((flag5.HasValue && !flag4.GetValueOrDefault()) ? new bool?(false) : ((PrimaryTarget != null) & flag4));
					if (!(!flag6).GetValueOrDefault() && !m_EventVal.Navigator.HasPlottedCourse() && flag6.HasValue)
					{
						m_EventVal.Kinematics.DesiredSpeedOverride = null;
						m_EventVal.DesiredSpeed = 0f;
						aircraft_AirOps_.ConditionTimer = 240f;
						aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar;
					}
					else if (!GetAircraft().IsHelicopter || m_EventVal.DesiredSpeed != 0f)
					{
						GetAircraft().Kinematics.Loiter(float_0);
					}
				}
				PerformTerrainFollowingIfNecessary();
				if (GetAircraft().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
				if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
				{
					if (m_EventVal.IsOnActivePatrol)
					{
						Patrol patrol3 = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (!m_EventVal.Navigator.HasFlightPlan)
						{
							if (m_EventVal.Navigator.HasPlottedCourse())
							{
								bool? flag7;
								if (m_EventVal.Navigator.NextWaypointIsManual)
								{
									flag7 = true;
								}
								else
								{
									Waypoint waypoint3 = m_EventVal.Navigator.PlottedCourse.FirstOrDefault();
									flag7 = ((waypoint3 == null) ? null : new bool?(waypoint3.Type == Waypoint.WaypointType.LocalizationRun));
								}
								bool? flag8 = flag7;
								if (((!flag8) ?? flag8).GetValueOrDefault())
								{
									if (m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol3.PatrolArea, ref patrol3.PatrolArea_30nm_Buffered, ref patrol3.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
									{
										if (m_EventVal.m_SchemaVal == ActiveUnit._ActiveUnitStatus.EngagedOffensive && patrol3.PatrolArea[0].BearingType == ReferencePoint.OrientationType.Fixed && !m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol3.PatrolArea, ref patrol3.PatrolArea, ref patrol3.PatrolArea_ChangeCheck, 0f, bool_1: false))
										{
											m_EventVal.Navigator.ClearPlottedCourse();
											m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
										}
									}
									else
									{
										m_EventVal.Navigator.ClearPlottedCourse();
										m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
									}
									if (m_EventVal.AI.PrimaryTarget == null)
									{
										byte? b5 = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
										if ((b5.HasValue ? new bool?(b5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
										{
											if (m_EventVal.Doctrine.IgnorePlottedCourse_Inherits() == patrol3.Doctrine.IgnorePlottedCourse_Inherits())
											{
												b5 = (byte?)patrol3.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
												flag8 = (b5.HasValue ? new bool?(b5.GetValueOrDefault() == 1) : null);
												if (((!flag8) ?? flag8).GetValueOrDefault())
												{
													m_EventVal.Doctrine.SetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
												}
											}
											else
											{
												m_EventVal.Doctrine.SetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, patrol3.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, false, bool_1: false, bool_2: false));
											}
										}
									}
								}
							}
							else if (m_EventVal.IsGroupWingman())
							{
								GetAircraft().Navigator.HeadToFormationStation(float_0);
							}
							else
							{
								m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
							}
						}
					}
					else if (m_EventVal.IsOnActiveMineClearingMission)
					{
						SortFacade(float_0);
					}
				}
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				if (m_EventVal.AssignedMissionOrPackage() == null)
				{
					if (m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.AI.PrimaryTarget != null && (m_EventVal.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || m_EventVal.AI.PrimaryTarget.Type == Contact_Base.ContactType.Surface) && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun)
					{
						Aircraft_Navigator navigator4 = GetAircraft().Navigator;
						navigator4.SetPatrolThrottle(bool_1: false, aircraft_AirOps_.Condition);
						navigator4.SetPatrolAltitude(bool_1: false, aircraft_AirOps_.Condition);
					}
				}
				else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse)
					{
						if (m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
						{
							LeadMustSlowDownDueToBingo = false;
							if (m_EventVal.IsGroupMember())
							{
								foreach (ActiveUnit value4 in m_EventVal.GetParentGroup().Units.Values)
								{
									if (value4.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo)
									{
										continue;
									}
									if ((int)m_EventVal.ThrottleSetting <= 2)
									{
										LeadMustSlowDownDueToBingo = true;
										continue;
									}
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
									if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
									{
										m_EventVal.Kinematics.DesiredSpeedOverride = null;
									}
									m_EventVal.ParentScen.AddMessage("其中一架飞机" + m_EventVal.GetParentGroup().Name + "已达到Bingo燃料，所以飞行前往巡航速度，以防止任何僚门干！", m_EventVal.GetParentGroup().Name + " 减到巡航速度（成员油量问题）", LoggedMessage.MessageType.AirOps, 0, null, m_EventVal.GetUnitSide(), new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
									break;
								}
							}
							else if (m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
							{
								if ((int)m_EventVal.ThrottleSetting > 2)
								{
									string text4 = "";
									if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
									{
										text4 = " (" + m_EventVal.UnitClass + ")";
									}
									m_EventVal.ParentScen.AddMessage("飞机" + m_EventVal.Name + text4 + "已达到Bingo燃料，因此飞机前往巡航速度以防止干涸", m_EventVal.Name + " 减到巡航速度（Bingo油量）", LoggedMessage.MessageType.AirOps, 0, null, m_EventVal.GetUnitSide(), new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
								}
								LeadMustSlowDownDueToBingo = true;
							}
						}
						else
						{
							LeadMustSlowDownDueToBingo = false;
						}
					}
				}
				else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
				{
					FerryMission ferryMission2 = (FerryMission)m_EventVal.AssignedMissionOrPackage();
					if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
					{
						m_EventVal.SetThrottle(m_EventVal.ThrottleSetting);
					}
					else if (GetAircraft().Loadout == null)
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					else if (ferryMission2.FerryThrottle_Aircraft.HasValue)
					{
						m_EventVal.SetThrottle(ferryMission2.FerryThrottle_Aircraft.Value);
					}
					else
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					if (m_EventVal.Kinematics.DesiredAltitudeOverride)
					{
						m_EventVal.DesiredAltitude = m_EventVal.DesiredAltitude;
					}
					else if (GetAircraft().Loadout == null)
					{
						ActiveUnit eventVal10 = m_EventVal;
						Aircraft aircraft_5 = GetAircraft();
						ActiveUnit.Throttle throttleSetting = m_EventVal.ThrottleSetting;
						ActiveUnit eventVal11 = m_EventVal;
						ActiveUnit eventVal12;
						bool bool_10 = eventVal11.GetDesiredAltitude_UseTerrainFollowing(eventVal12 = m_EventVal);
						float desiredAltitude3 = MostRealisticOptimumAltitude(ref aircraft_5, throttleSetting, ref bool_10);
						eventVal11.SetDesiredAltitude_UseTerrainFollowing(eventVal12, bool_10);
						eventVal10.DesiredAltitude = desiredAltitude3;
					}
					else if (ferryMission2.FerryAltitude_Aircraft.HasValue)
					{
						m_EventVal.DesiredAltitude = ferryMission2.FerryAltitude_Aircraft.Value;
					}
					else
					{
						ActiveUnit eventVal2 = m_EventVal;
						Aircraft aircraft_6 = GetAircraft();
						ActiveUnit.Throttle throttleSetting2 = m_EventVal.ThrottleSetting;
						ActiveUnit eventVal3 = m_EventVal;
						ActiveUnit eventVal4;
						bool bool_11 = eventVal3.GetDesiredAltitude_UseTerrainFollowing(eventVal4 = m_EventVal);
						float desiredAltitude4 = MostRealisticOptimumAltitude(ref aircraft_6, throttleSetting2, ref bool_11);
						eventVal3.SetDesiredAltitude_UseTerrainFollowing(eventVal4, bool_11);
						eventVal2.DesiredAltitude = desiredAltitude4;
					}
					if (GetAircraft().IsTanker)
					{
						AssistRefuellingClients();
					}
				}
				else if (!m_EventVal.IsGroupWingman())
				{
					_ = GetAircraft().Navigator;
					if (m_EventVal.IsOnActiveMiningMission)
					{
						if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
						{
							MiningMission miningMission3 = (MiningMission)m_EventVal.AssignedMissionOrPackage();
							if (m_EventVal.IsAircraft)
							{
								if (m_EventVal.Navigator.DisableDic(ref miningMission3.Area, ref miningMission3.Area_5nm_Buffered, ref miningMission3.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
								{
									SetClient();
								}
							}
							else if (m_EventVal.Navigator.DisableDic(ref miningMission3.Area, ref miningMission3.Area_2nm_Buffered, ref miningMission3.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
							{
								SetClient();
							}
						}
					}
					else if (m_EventVal.IsOnActiveCargoMission)
					{
						CargoMission cargoMission_ = (CargoMission)m_EventVal.AssignedMissionOrPackage();
						CalcFacade(cargoMission_);
					}
					else if (m_EventVal.IsOnActivePatrol)
					{
						Patrol patrol4 = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (m_EventVal.AI.IsInsidePatrolArea_2nmBuffer)
						{
							if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && patrol4.StationThrottle_Aircraft.HasValue)
							{
								m_EventVal.SetThrottle(patrol4.StationThrottle_Aircraft.Value);
							}
							if (!m_EventVal.Kinematics.DesiredAltitudeOverride && patrol4.StationAltitude_Aircraft.HasValue)
							{
								m_EventVal.DesiredAltitude = patrol4.StationAltitude_Aircraft.Value;
							}
						}
						else
						{
							if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && patrol4.TransitThrottle_Aircraft.HasValue)
							{
								m_EventVal.SetThrottle(patrol4.TransitThrottle_Aircraft.Value);
							}
							if (!m_EventVal.Kinematics.DesiredAltitudeOverride && patrol4.TransitAltitude_Aircraft.HasValue)
							{
								m_EventVal.DesiredAltitude = patrol4.TransitAltitude_Aircraft.Value;
							}
						}
					}
				}
				if (m_EventVal.Navigator.PlottedCourse.Count() != 0 && m_EventVal.Navigator.PlottedCourse.First().Type == Waypoint.WaypointType.LocalizationRun && m_EventVal.UnitType == GlobalVariables.ActiveUnitType.Aircraft && PrimaryTarget != null && PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
				{
					if (PrimaryTarget.UncertaintyArea == null)
					{
						m_EventVal.Navigator.ClearPlottedCourse();
					}
					else if (!GeoPoint.IsInsideThisArea(m_EventVal.Navigator.PlottedCourse[0].Latitude, m_EventVal.Navigator.PlottedCourse[0].Longitude, PrimaryTarget.UncertaintyArea))
					{
						m_EventVal.Navigator.ClearPlottedCourse();
					}
				}
				AssetFacade(float_0);
				PerformTerrainFollowingIfNecessary();
				if (GetAircraft().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				if (PrimaryTarget == null)
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Tasked;
					break;
				}
				if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.GetParentGroup().Navigator.HasNonPathfindPlottedCourse())
					{
						if (m_EventVal.IsGroupLead())
						{
							byte? b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								ManouverTowardsTarget(float_0);
							}
							else
							{
								GetAircraft().Navigator.FollowPlottedCourse(float_0);
							}
						}
						else if (!m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun && !m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
						{
							byte? b2 = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
							if (!(!flag2).GetValueOrDefault() && (m_EventVal.WeaponState == ActiveUnit._ActiveUnitWeaponState.None || m_EventVal.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO || m_EventVal.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO) && flag2.HasValue)
							{
								ManouverTowardsTarget(float_0);
							}
							else
							{
								GetAircraft().Navigator.HeadToFormationStation(float_0);
							}
						}
						else
						{
							ManouverTowardsTarget(float_0);
						}
						break;
					}
					ManouverTowardsTarget(float_0);
					if (!m_EventVal.IsGroupLead())
					{
						if (m_EventVal.GetParentGroup().Kinematics.DesiredSpeedOverride.HasValue)
						{
							m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().Kinematics.DesiredSpeedOverride.Value;
							if (m_EventVal.ThrottleSetting != m_EventVal.GetParentGroup().ThrottleSetting)
							{
								m_EventVal.SetThrottle(m_EventVal.GetParentGroup().ThrottleSetting, m_EventVal.DesiredSpeed);
							}
						}
						if (m_EventVal.GetParentGroup().Kinematics.DesiredAltitudeOverride)
						{
							m_EventVal.DesiredAltitude = m_EventVal.GetParentGroup().DesiredAltitude;
						}
					}
				}
				else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					byte? b3 = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						ManouverTowardsTarget(float_0);
					}
					else
					{
						GetAircraft().Navigator.FollowPlottedCourse(float_0);
					}
				}
				else
				{
					ManouverTowardsTarget(float_0);
				}
				PerformTerrainFollowingIfNecessary();
				break;
			case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
				if (_PrimaryThreat != null)
				{
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					ManouverAgainstPrimaryThreat(float_0);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnPatrol:
			{
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					break;
				}
				Patrol patrol2 = (Patrol)m_EventVal.AssignedMissionOrPackage();
				if (aircraft_AirOps_.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
				{
					GetAircraft().Navigator.ClearPlottedCourse();
					aircraft_AirOps_.HoverForDippingSonar();
				}
				else if (patrol2 == null)
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.IsGroupLead())
					{
						if (m_EventVal.Navigator.HasFlightPlan)
						{
							break;
						}
						if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
						{
							if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_30nm_Buffered, ref patrol2.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
							{
								m_EventVal.GetParentGroup().Navigator.PlotCourseToStationArea(float_0, bool_1: false);
							}
							m_EventVal.Navigator.FollowPlottedCourse(float_0);
						}
						else
						{
							m_EventVal.GetParentGroup().Navigator.PlotCourseToStationArea(float_0, bool_1: false);
						}
					}
					else
					{
						GetAircraft().Navigator.HeadToFormationStation(float_0);
					}
				}
				else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					if (m_EventVal.Navigator.HasFlightPlan)
					{
						break;
					}
					if (m_EventVal.Navigator.NextWaypointIsManual)
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else if (m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
					{
						if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_30nm_Buffered, ref patrol2.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
						{
							m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
				}
				else
				{
					m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
				}
				break;
			}
			case ActiveUnit._ActiveUnitStatus.Tasked:
				if (m_EventVal.IsOnActiveCargoMission)
				{
					RateFacade(float_0);
					break;
				}
				if (m_EventVal.AssignedMissionOrPackage() == null)
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
				{
					MiningMission miningMission2 = (MiningMission)m_EventVal.AssignedMissionOrPackage();
					if (m_EventVal.IsGroupMember())
					{
						if (m_EventVal.IsGroupLead())
						{
							if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
							{
								if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref miningMission2.Area, ref miningMission2.Area_30nm_Buffered, ref miningMission2.Area_30nm_ChangeCheck, 30f, bool_1: false))
								{
									m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(miningMission2.Area);
									if (m_EventVal.AI.MiningInfo != null)
									{
										m_EventVal.AI.MiningInfo = null;
									}
								}
								m_EventVal.Navigator.FollowPlottedCourse(float_0);
							}
							else
							{
								m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(miningMission2.Area);
								if (m_EventVal.AI.MiningInfo != null)
								{
									m_EventVal.AI.MiningInfo = null;
								}
							}
						}
						else
						{
							GetAircraft().Navigator.HeadToFormationStation(float_0);
						}
					}
					else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref miningMission2.Area, ref miningMission2.Area_30nm_Buffered, ref miningMission2.Area_30nm_ChangeCheck, 30f, bool_1: false))
						{
							m_EventVal.Navigator.PlotCourseToArea(miningMission2.Area);
							if (m_EventVal.AI.MiningInfo != null)
							{
								m_EventVal.AI.MiningInfo = null;
							}
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						m_EventVal.Navigator.PlotCourseToArea(miningMission2.Area);
						if (m_EventVal.AI.MiningInfo != null)
						{
							m_EventVal.AI.MiningInfo = null;
						}
					}
					if (!m_EventVal.Kinematics.DesiredAltitudeOverride && m_EventVal.Navigator.DisableDic(ref miningMission2.Area, ref miningMission2.Area_5nm_Buffered, ref miningMission2.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
					{
						float? num11 = SetClient();
						if (num11.HasValue)
						{
							m_EventVal.DesiredAltitude = num11.Value;
						}
					}
					break;
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
				{
					SortFacade(float_0);
					break;
				}
				if (PrimaryTarget == null && !m_EventVal.AI.IsEscort && !m_EventVal.IsGroupWingman() && !m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
				{
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					switch (((Strike)m_EventVal.AssignedMissionOrPackage()).Type)
					{
					case Strike.StrikeType.Land_Strike:
					case Strike.StrikeType.Maritime_Strike:
					case Strike.StrikeType.Sub_Strike:
						if (PrimaryTarget == null)
						{
							bool bool_2 = false;
							if (StartFacade(ref bool_2))
							{
								break;
							}
							if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
							{
								ActiveUnit eventVal5 = m_EventVal;
								Aircraft aircraft_2 = GetAircraft();
								ActiveUnit eventVal6 = m_EventVal;
								ActiveUnit eventVal7;
								bool_2 = eventVal6.GetDesiredAltitude_UseTerrainFollowing(eventVal7 = m_EventVal);
								float desiredAltitude2 = MostRealisticOptimumAltitude(ref aircraft_2, ActiveUnit.Throttle.Loiter, ref bool_2);
								eventVal6.SetDesiredAltitude_UseTerrainFollowing(eventVal7, bool_2);
								eventVal5.DesiredAltitude = desiredAltitude2;
							}
							m_EventVal.Kinematics.Loiter(float_0);
							if (IsEscort)
							{
								if (GetAircraft().IsGroupWingman() && Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), GetAircraft().GetParentGroup().GroupLead.GetLatitude(), GetAircraft().GetParentGroup().GroupLead.GetLongitude()) > (float)((Strike)m_EventVal.AssignedMissionOrPackage()).Escort_WingmanEngageDistance)
								{
									GetAircraft().Navigator.HeadToFormationStation(float_0);
								}
							}
							else if (GetAircraft().IsGroupWingman() && Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), GetAircraft().GetParentGroup().GroupLead.GetLatitude(), GetAircraft().GetParentGroup().GroupLead.GetLongitude()) > (float)((Strike)m_EventVal.AssignedMissionOrPackage()).SplitDistance)
							{
								GetAircraft().Navigator.HeadToFormationStation(float_0);
							}
						}
						else if (m_EventVal.IsGroupMember())
						{
							if (m_EventVal.IsGroupLead())
							{
								ManouverTowardsTarget(float_0);
								break;
							}
							if (m_EventVal.AI.PrimaryTarget != null && m_EventVal.GetParentGroup().GroupLead.Navigator.HasFlightPlan)
							{
								Waypoint[] flightPlan = m_EventVal.GetParentGroup().GroupLead.Navigator.GetFlight().FlightPlan;
								Waypoint waypoint = null;
								Waypoint[] array = flightPlan;
								Waypoint[] array2 = array;
								foreach (Waypoint waypoint2 in array2)
								{
									if (waypoint2.Type == Waypoint.WaypointType.InitialPoint)
									{
										waypoint = waypoint2;
										break;
									}
								}
								if (waypoint != null)
								{
									float num12 = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.AI.PrimaryTarget.GetLatitude(), m_EventVal.AI.PrimaryTarget.GetLongitude());
									float num13 = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint.Latitude, waypoint.Longitude);
									if (num12 < num13)
									{
										bool flag = false;
										Weapon weapon_ = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
										if (weapon_ != null)
										{
											ActiveUnit_AI aI2;
											Contact contact_ = (aI2 = m_EventVal.AI).PrimaryTarget;
											ActiveUnit_AI aI3;
											Contact contact_2 = (aI3 = m_EventVal.AI).PrimaryTarget;
											Weapon weapon_2 = weapon_;
											bool? nullable_2 = null;
											Doctrine._WRA_WeaponTargetType num14 = Doctrine.WRA_DetermineTargetType(ref contact_2, weapon_2, ref nullable_2);
											aI3.PrimaryTarget = contact_2;
											Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = num14;
											Doctrine._WRA_WeaponTargetType num15 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_, ref _WRA_WeaponTargetType_, m_EventVal.GetUnitSide().ObjectID);
											aI2.PrimaryTarget = contact_;
											Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = num15;
											Doctrine doctrine = m_EventVal.Doctrine;
											Scenario parentScen = m_EventVal.ParentScen;
											Weapon weapon_3 = weapon_;
											int? nullable_3 = null;
											int? nullable_4 = null;
											int? num2 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, weapon_3, wRA_WeaponTargetType_, bool_0: false, ref nullable_3, ref nullable_4);
											nullable_4 = num2;
											if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -99) : null).GetValueOrDefault())
											{
												num2 = int.MaxValue;
											}
											else
											{
												nullable_4 = num2;
												if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() < 0) : null).GetValueOrDefault())
												{
													Side unitSide = m_EventVal.GetUnitSide();
													int? nullable_5 = num2;
													ref ActiveUnit eventVal8 = ref m_EventVal;
													contact_ = (aI2 = m_EventVal.AI).PrimaryTarget;
													int? num3 = unitSide.ConvertSalvoWeaponQty_To_ActualQuantity(nullable_5, ref eventVal8, ref contact_, ref weapon_);
													aI2.PrimaryTarget = contact_;
													num2 = num3;
												}
											}
											int num4 = m_EventVal.AI.PrimaryTarget.IncomingGuidedWeapons.Count();
											if ((num2.HasValue ? new bool?(num4 < num2.GetValueOrDefault()) : null).GetValueOrDefault())
											{
												flag = false;
											}
											if (!flag & !StopFacade())
											{
												ManouverTowardsTarget(float_0);
												m_EventVal.AI.TargetThisContact(m_EventVal.AI.PrimaryTarget, bool_0: false, bool_1: true, TargetingEntry._TargetingBehavior.AutoTargeted);
												break;
											}
										}
									}
								}
							}
							GetAircraft().Navigator.HeadToFormationStation(float_0);
						}
						else if (!StopFacade())
						{
							ManouverTowardsTarget(float_0);
						}
						break;
					case Strike.StrikeType.Air_Intercept:
						if (PrimaryTarget == null)
						{
							if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
							{
								ActiveUnit eventVal = m_EventVal;
								Aircraft aircraft_ = GetAircraft();
								Aircraft aircraft = GetAircraft();
								ActiveUnit aircraft2;
								bool bool_19 = aircraft.GetDesiredAltitude_UseTerrainFollowing(aircraft2 = GetAircraft());
								float desiredAltitude = MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_19);
								aircraft.SetDesiredAltitude_UseTerrainFollowing(aircraft2, bool_19);
								eventVal.DesiredAltitude = desiredAltitude;
							}
							m_EventVal.Kinematics.Loiter(float_0);
						}
						else
						{
							ManouverTowardsTarget(float_0);
						}
						break;
					}
				}
				else if (m_EventVal.IsGroupWingman())
				{
					GetAircraft().Navigator.HeadToFormationStation(float_0);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.FormingUp:
				if (m_EventVal.IsGroupLead())
				{
					if (m_EventVal.Navigator.HasPlottedCourse())
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						GetAircraft().Kinematics.Loiter(float_0);
					}
				}
				else if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup)
					{
						GetAircraft().Navigator.HeadToFormationStation(float_0);
					}
					else
					{
						GetAircraft().Kinematics.Loiter(float_0);
					}
				}
				else
				{
					GetAircraft().Kinematics.Loiter(float_0, bool_0: true);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnSupportMission:
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Support)
				{
					break;
				}
				if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.IsGroupLead())
					{
						m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
					}
					else
					{
						GetAircraft().Navigator.HeadToFormationStation(float_0);
					}
					break;
				}
				m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
				if (GetAircraft().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnFerryMission:
			{
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Ferry)
				{
					break;
				}
				FerryMission ferryMission = (FerryMission)m_EventVal.AssignedMissionOrPackage();
				ActiveUnit.Throttle throttle_2 = (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue ? m_EventVal.ThrottleSetting : (Information.IsNothing(GetAircraft().Loadout) ? ActiveUnit.Throttle.Cruise : (Information.IsNothing(ferryMission.FerryThrottle_Aircraft) ? ActiveUnit.Throttle.Cruise : ferryMission.FerryThrottle_Aircraft.Value)));
				float num5;
				if (m_EventVal.Kinematics.DesiredAltitudeOverride)
				{
					num5 = m_EventVal.DesiredAltitude;
				}
				else if (GetAircraft().Loadout == null)
				{
					Aircraft aircraft_3 = GetAircraft();
					Aircraft aircraft3;
					ActiveUnit aircraft4;
					bool bool_7 = (aircraft3 = GetAircraft()).GetDesiredAltitude_UseTerrainFollowing(aircraft4 = GetAircraft());
					float num6 = MostRealisticOptimumAltitude(ref aircraft_3, throttle_2, ref bool_7);
					aircraft3.SetDesiredAltitude_UseTerrainFollowing(aircraft4, bool_7);
					num5 = num6;
				}
				else if (ferryMission.FerryAltitude_Aircraft.HasValue)
				{
					num5 = ferryMission.FerryAltitude_Aircraft.Value;
				}
				else
				{
					Aircraft aircraft_4 = GetAircraft();
					Aircraft aircraft5;
					ActiveUnit aircraft6;
					bool bool_8 = (aircraft5 = GetAircraft()).GetDesiredAltitude_UseTerrainFollowing(aircraft6 = GetAircraft());
					float num7 = MostRealisticOptimumAltitude(ref aircraft_4, throttle_2, ref bool_8);
					aircraft5.SetDesiredAltitude_UseTerrainFollowing(aircraft6, bool_8);
					num5 = num7;
				}
				if (m_EventVal.IsGroupWingman())
				{
					GetAircraft().Navigator.HeadToFormationStation(float_0);
				}
				else if (aircraft_AirOps_.ActualDestinationHost == null)
				{
					string text3 = "";
					if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
					{
						text3 = " (" + m_EventVal.UnitClass + ")";
					}
					m_EventVal.ParentScen.AddMessage("飞机" + m_EventVal.Name + text3 + "被分配到转场任务，但它不能降落在所需的目的地。取消分配飞机并返回最近的基地。", m_EventVal.Name + " 无法执行转场任务；取消", LoggedMessage.MessageType.AirOps, 0, null, m_EventVal.GetUnitSide(), new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
					ActiveUnit eventVal9 = m_EventVal;
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
					eventVal9.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
					m_EventVal.AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
				else
				{
					Aircraft_Navigator navigator3 = GetAircraft().Navigator;
					ActiveUnit actualDestinationHost = aircraft_AirOps_.ActualDestinationHost;
					float float_ = m_EventVal.Kinematics.GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), throttle_2, bool_0: false);
					float float_2 = num5;
					bool bool_9 = false;
					navigator3.HeadToLandingAssemblyPoint(float_0, actualDestinationHost, float_, float_2, ref bool_9);
				}
				if (GetAircraft().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			}
			case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
				if (GetAircraft().IsGroupWingman() && GetAircraft().GetParentGroup().Type == Group.GroupType.AirGroup && GetAircraft().GetParentGroup().GroupLead != null)
				{
					ActiveUnit groupLead = GetAircraft().GetParentGroup().GroupLead;
					if (groupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || groupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						HeadToGroupLead(float_0, ref aircraft_AirOps_);
						break;
					}
				}
				if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse || aircraft_AirOps_.A2AR_Destination == null)
				{
					GeoPoint geoPoint_2 = LoginClient();
					Aircraft_AirOps aircraft_AirOps3 = aircraft_AirOps_;
					bool bool_3 = false;
					ActiveUnit activeUnit_3 = null;
					string string_3 = "";
					List<Aircraft> potentialTankers = aircraft_AirOps3.GetPotentialTankers(ref bool_3, ref activeUnit_3, bool_1: true, null, ref string_3);
					bool bool_4 = false;
					if (aircraft_AirOps_.A2AR_Destination != null && potentialTankers.Contains(aircraft_AirOps_.A2AR_Destination))
					{
						if (!aircraft_AirOps_.ListProxy(aircraft_AirOps_.A2AR_Destination, ref bool_4, bool_1: true, bool_2: false))
						{
							Aircraft_AirOps aircraft_AirOps4 = aircraft_AirOps_;
							Doctrine._UnderwayRefuelAndReplenishmentSelection value = m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
							bool_3 = false;
							activeUnit_3 = null;
							List<Mission> list_3 = null;
							string_3 = "";
							bool bool_5 = false;
							aircraft_AirOps4.AssetProxy(geoPoint_2, value, ref bool_3, bool_1: false, ref activeUnit_3, ref list_3, ref string_3, ref bool_5, ref bool_4);
						}
					}
					else if (potentialTankers.Count <= 0)
					{
						if (!Information.IsNothing(aircraft_AirOps_.A2AR_Destination))
						{
							aircraft_AirOps_.DisconnectFromTanker();
						}
					}
					else
					{
						Aircraft_AirOps aircraft_AirOps5 = aircraft_AirOps_;
						Doctrine._UnderwayRefuelAndReplenishmentSelection value2 = m_EventVal.Doctrine.GetReplenishmentSelection(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
						bool bool_6 = false;
						activeUnit_3 = null;
						List<Mission> list_4 = null;
						string_3 = "";
						bool_3 = false;
						aircraft_AirOps5.AssetProxy(geoPoint_2, value2, ref bool_6, bool_1: false, ref activeUnit_3, ref list_4, ref string_3, ref bool_3, ref bool_4);
					}
				}
				PerformScheduledRefuel();
				break;
			case ActiveUnit._ActiveUnitStatus.Refuelling:
				if (m_EventVal.AI.IsEscort)
				{
					if (m_EventVal.AssignedMissionOrPackage() == null)
					{
						break;
					}
					if (m_EventVal.Navigator.TankerFollowsMe.HasValue)
					{
						if (m_EventVal.Navigator.TankerFollowsMe.GetValueOrDefault() && m_EventVal.AssignedMissionOrPackage().TankerFollowsReceivers)
						{
							bool bool_17 = true;
							StartFacade(ref bool_17);
						}
					}
					else if (m_EventVal.AssignedMissionOrPackage().TankerFollowsReceivers)
					{
						bool bool_18 = true;
						StartFacade(ref bool_18);
					}
					break;
				}
				if (m_EventVal.IsGroupWingman() || m_EventVal.AssignedMissionOrPackage() == null)
				{
					break;
				}
				if (m_EventVal.Navigator.TankerFollowsMe.HasValue)
				{
					if (m_EventVal.Navigator.TankerFollowsMe.GetValueOrDefault() && m_EventVal.Navigator.HasPlottedCourse())
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
				}
				else if (m_EventVal.AssignedMissionOrPackage().TankerFollowsReceivers && m_EventVal.Navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.RTB:
			case ActiveUnit._ActiveUnitStatus.RTB_Manual:
			case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
			case ActiveUnit._ActiveUnitStatus.RTB_Group:
			case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
			case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
				switch (aircraft_AirOps_.Condition)
				{
				case Aircraft_AirOps._AirOpsCondition.Airborne:
					aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
					break;
				case Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown:
				case Aircraft_AirOps._AirOpsCondition.EmergencyLanding:
					if (GetAircraft().Navigator.AboutToLand(float_0))
					{
						aircraft_AirOps_.ConditionTimer = 0f;
					}
					else
					{
						GetAircraft().Navigator.GlideToHomeBase(float_0);
					}
					break;
				case Aircraft_AirOps._AirOpsCondition.RTB:
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse)
					{
						bool bool_12 = false;
						if (aircraft_AirOps_.ActualDestinationHost != null)
						{
							if (m_EventVal.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && m_EventVal.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
							{
								Aircraft_Navigator navigator2 = GetAircraft().Navigator;
								ActiveUnit.Throttle throttle_ = navigator2.CollectProxy();
								bool bool_13 = false;
								float num9 = navigator2.OrderProxy(ref bool_13);
								if ((double)GetAircraft().Kinematics.InterruptDic(Module_Unit.RangeToUnit_Horiz(GetAircraft(), aircraft_AirOps_.ActualDestinationHost), throttle_, num9, GetAircraft().Kinematics.GetMaximumSpeed(num9, throttle_, bool_0: false), bool_0: false, bool_1: false, bool_2: false) > (double)GetAircraft().FuelCapacityCurrent * 0.9)
								{
									Aircraft_AirOps aircraft_AirOps = aircraft_AirOps_;
									bool_13 = false;
									ActiveUnit activeUnit_ = null;
									List<Mission> list_ = null;
									string string_ = "";
									bool bool_14 = true;
									if (aircraft_AirOps.AssetProxy(null, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref bool_13, bool_1: false, ref activeUnit_, ref list_, ref string_, ref bool_14, ref bool_12))
									{
										break;
									}
								}
							}
							else
							{
								Aircraft_AirOps aircraft_AirOps2 = aircraft_AirOps_;
								bool bool_15 = false;
								ActiveUnit activeUnit_2 = null;
								List<Mission> list_2 = null;
								string string_2 = "";
								bool bool_16 = true;
								if (aircraft_AirOps2.AssetProxy(null, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref bool_15, bool_1: false, ref activeUnit_2, ref list_2, ref string_2, ref bool_16, ref bool_12))
								{
									break;
								}
							}
						}
					}
					if (m_EventVal.Navigator.HasPlottedCourse() && !m_EventVal.IsRTB)
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						ReturnToBase(float_0);
					}
					if (m_EventVal.IsGroupMember() && m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup)
					{
						int? num10 = (int?)m_EventVal.Doctrine.GetWinchesterShotgun(m_EventVal.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
						if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							m_EventVal.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
						}
					}
					break;
				case Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue:
					ReturnToBase(float_0);
					GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100392", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PerformScheduledRefuel()
	{
		Aircraft_AirOps airOps = GetAircraft().AirOps;
		if (airOps.A2AR_Destination == null)
		{
			if (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				GetAircraft().Status = GetAircraft().predicateVal;
			}
			if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel || airOps.Condition == Aircraft_AirOps._AirOpsCondition.Refuelling)
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			}
		}
		else
		{
			Aircraft a2AR_Destination = airOps.A2AR_Destination;
			float num = Module_Unit.RangeToUnit_Horiz(GetAircraft(), a2AR_Destination);
			if (a2AR_Destination.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, a2AR_Destination));
			}
			else
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(m_EventVal, a2AR_Destination.Latitude_LastReported.Value, a2AR_Destination.Longitude_LastReported.Value));
			}
			if ((double)num < 0.1)
			{
				GetAircraft().DesiredSpeed = a2AR_Destination.CurrentSpeed;
				GetAircraft().DesiredAltitude = a2AR_Destination.GetCurrentAltitude();
				GetAircraft().SetThrottle(GetAircraft().Kinematics.GetThrottleSuitableForThisSpeed(a2AR_Destination.GetCurrentAltitude(), (int)Math.Round(GetAircraft().DesiredSpeed)));
			}
			else
			{
				GetAircraft().DesiredSpeed = GetAircraft().Kinematics.GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false);
				GetAircraft().SetThrottle(ActiveUnit.Throttle.Cruise);
				if (num <= 10f)
				{
					GetAircraft().DesiredAltitude = a2AR_Destination.GetCurrentAltitude();
					GetAircraft().SetDesiredAltitude_UseTerrainFollowing(GetAircraft(), bool_1: false);
				}
				else if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
				{
					if (GetAircraft().GetDesiredAltitude_UseTerrainFollowing(GetAircraft()))
					{
						Aircraft aircraft = GetAircraft();
						Aircraft_Navigator navigator = GetAircraft().Navigator;
						bool bool_ = false;
						aircraft.DesiredAltitude_AGL = navigator.OrderProxy(ref bool_);
					}
					else
					{
						Aircraft aircraft2 = GetAircraft();
						Aircraft_Navigator navigator2 = GetAircraft().Navigator;
						bool bool_2 = false;
						aircraft2.DesiredAltitude = navigator2.OrderProxy(ref bool_2);
					}
				}
			}
		}
		RefueledInThisLeg = true;
	}

	private bool RunFacade(float float_0)
	{
		try
		{
			if ((m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive) | (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.RTB_Exhaustion) | (m_EventVal.IsRTB_Or_CalledOff && (GetAircraft().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || GetAircraft().FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker)))
			{
				return false;
			}
			if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				if (IsEscort)
				{
					if (GetAircraft().IsGroupWingman())
					{
						if (Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), GetAircraft().GetParentGroup().GroupLead.GetLatitude(), GetAircraft().GetParentGroup().GroupLead.GetLongitude()) > (float)((Strike)m_EventVal.AssignedMissionOrPackage()).Escort_WingmanEngageDistance)
						{
							GetAircraft().Navigator.HeadToFormationStation(float_0);
							return true;
						}
					}
					else
					{
						HeadToNearestEscortSubject();
					}
				}
				else if (GetAircraft().IsGroupWingman() && GetAircraft().GetParentGroup() != null && Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), GetAircraft().GetParentGroup().GroupLead.GetLatitude(), GetAircraft().GetParentGroup().GroupLead.GetLongitude()) > (float)((Strike)m_EventVal.AssignedMissionOrPackage()).SplitDistance)
				{
					GetAircraft().Navigator.HeadToFormationStation(float_0);
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100398657547", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private bool StartFacade(ref bool bool_0)
	{
		try
		{
			List<Aircraft> list = new List<Aircraft>();
			ActiveUnit[] array;
			try
			{
				array = Misc.ChangeRequest(m_EventVal.GetUnitSide().Units);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				array = Misc.ChangeRequest(m_EventVal.GetUnitSide().Units);
				ProjectData.ClearProjectError();
			}
			List<Aircraft> list2 = new List<Aircraft>();
			ActiveUnit[] array2 = array;
			int num = 0;
			float num3 = 0f;
			int num4 = 0;
			float num5 = 0f;
			ActiveUnit[] array3 = array2;
			ActiveUnit[] array4 = array3;
			foreach (ActiveUnit activeUnit in array4)
			{
				if (activeUnit.IsAircraft && activeUnit.IsOperating() && activeUnit != GetAircraft() && activeUnit.AssignedMissionOrPackage() == GetAircraft().AssignedMissionOrPackage() && !activeUnit.AI.IsEscort)
				{
					Aircraft aircraft = (Aircraft)activeUnit;
					list.Add(aircraft);
					num += (int)Math.Round(aircraft.CurrentSpeed);
					num3 += aircraft.GetCurrentAltitude();
					if (aircraft.AirOps.GetAssignedHostUnit() == GetAircraft().AirOps.GetAssignedHostUnit())
					{
						list2.Add(aircraft);
						num4 += (int)Math.Round(aircraft.CurrentSpeed);
						num5 += aircraft.GetCurrentAltitude();
					}
				}
			}
			if (list2.Count > 0)
			{
				list = list2;
				num = num4;
				num3 = num5;
			}
			if (list.Count == 0)
			{
				return false;
			}
			GeoPoint geoPoint = new GeoPoint();
			if (list.Count == 1)
			{
				geoPoint.Longitude = list[0].GetLongitude();
				geoPoint.Latitude = list[0].GetLatitude();
			}
			else
			{
				geoPoint.Longitude = list.Select((Aircraft theAU) => theAU.GetLongitude()).Sum() / (double)list.Count;
				geoPoint.Latitude = list.Select((Aircraft theAU) => theAU.GetLatitude()).Sum() / (double)list.Count;
			}
			GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), geoPoint.Latitude, geoPoint.Longitude));
			if (!bool_0)
			{
				if (!GetAircraft().Kinematics.DesiredSpeedOverride.HasValue)
				{
					float num6 = (float)((double)num / (double)list.Count);
					GetAircraft().SetThrottle(GetAircraft().Kinematics.GetThrottleSuitableForThisSpeed(GetAircraft().GetCurrentAltitude(), (int)Math.Round(num6)));
					GetAircraft().DesiredSpeed = num6;
				}
				if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
				{
					float num7 = 0f;
					float num8 = 9999999f;
					foreach (Mount mount in m_EventVal.Mounts)
					{
						if (mount.Status != 0)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount.MountWeapons)
						{
							WeaponRec current2;
							Weapon referenceWeapon = (current2 = mountWeapon).GetReferenceWeapon(m_EventVal.ParentScen);
							if (referenceWeapon.IsSoftKill || referenceWeapon.IsFuelTank || referenceWeapon.IsSensorPod || current2.CurrentLoad == 0)
							{
								continue;
							}
							if (referenceWeapon.IsNuke.Value)
							{
								byte? b = (byte?)m_EventVal.Doctrine.GetNukesAllowed(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
								bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
								if (((!flag) ?? flag).GetValueOrDefault())
								{
									continue;
								}
							}
							if (referenceWeapon.MinLaunchAlt_AGL != 0f && referenceWeapon.MinLaunchAlt_AGL > num7)
							{
								num7 = referenceWeapon.MinLaunchAlt_AGL;
							}
							if (referenceWeapon.MaxLaunchAlt_AGL != 0f && referenceWeapon.MaxLaunchAlt_AGL < num8)
							{
								num8 = referenceWeapon.MaxLaunchAlt_AGL;
							}
							current2 = null;
						}
					}
					if (m_EventVal.IsAircraft && !Information.IsNothing(((Aircraft)m_EventVal).Loadout))
					{
						WeaponRec[] weapons = ((Aircraft)m_EventVal).Loadout.Weapons;
						for (int i = 0; i < weapons.Length; i = checked(i + 1))
						{
							WeaponRec weaponRec;
							Weapon referenceWeapon2 = (weaponRec = weapons[i]).GetReferenceWeapon(m_EventVal.ParentScen);
							if (referenceWeapon2.IsSoftKill || referenceWeapon2.IsFuelTank || referenceWeapon2.IsSensorPod || weaponRec.CurrentLoad == 0)
							{
								continue;
							}
							if (referenceWeapon2.IsNuke.Value)
							{
								byte? b2 = (byte?)m_EventVal.Doctrine.GetNukesAllowed(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
								bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
								if (((!flag2) ?? flag2).GetValueOrDefault())
								{
									continue;
								}
							}
							if (referenceWeapon2.MinLaunchAlt_AGL != 0f && referenceWeapon2.MinLaunchAlt_AGL > num7)
							{
								num7 = referenceWeapon2.MinLaunchAlt_AGL;
							}
							if (referenceWeapon2.MaxLaunchAlt_AGL != 0f && referenceWeapon2.MaxLaunchAlt_AGL < num8)
							{
								num8 = referenceWeapon2.MaxLaunchAlt_AGL;
							}
							weaponRec = null;
						}
					}
					float num9 = num3 / (float)list.Count;
					if (num7 <= num8)
					{
						if (num9 < num7)
						{
							num9 = num7;
							float num10 = Math.Max(0, m_EventVal.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen));
							if (num10 > 0f)
							{
								num9 += num10;
							}
						}
						if (num9 < num7)
						{
							num9 = num7;
						}
					}
					else if (num9 < num7)
					{
						num9 = num7;
						float num2 = Math.Max(0, m_EventVal.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen));
						if (num2 > 0f)
						{
							num9 += num2;
						}
					}
					m_EventVal.DesiredAltitude = num9;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10023409582340958", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return true;
		}
	}

	private void AssetFacade(float float_0)
	{
		try
		{
			if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && m_EventVal.Navigator.HasFlight)
			{
				Waypoint[] flightPlan = m_EventVal.Navigator.GetFlight().FlightPlan;
				Waypoint waypoint = null;
				Waypoint[] array = flightPlan;
				Waypoint[] array2 = array;
				foreach (Waypoint waypoint2 in array2)
				{
					if (Operators.CompareString(waypoint2.Name, GetAircraft().Navigator.PlottedCourse.FirstOrDefault()?.Name, TextCompare: false) == 0 && waypoint != null)
					{
						float? desiredSpeedOverride = waypoint.DesiredSpeedOverride;
						float? desiredSpeedOverride2 = m_EventVal.Kinematics.DesiredSpeedOverride;
						bool? flag = ((desiredSpeedOverride.HasValue & desiredSpeedOverride2.HasValue) ? new bool?(desiredSpeedOverride.GetValueOrDefault() == desiredSpeedOverride2.GetValueOrDefault()) : null);
						if (((!flag) ?? flag).GetValueOrDefault())
						{
							return;
						}
					}
					waypoint = waypoint2;
				}
			}
			if (GetAircraft().Navigator.HasNonPathfindPlottedCourse() && Information.IsNothing(GetAircraft().Navigator.PlottedCourse[0].Time_Zulu))
			{
				float? timeToNextSpeedAdjustmentForToTEvaluation = TimeToNextSpeedAdjustmentForToTEvaluation;
				if ((timeToNextSpeedAdjustmentForToTEvaluation.HasValue ? new bool?(timeToNextSpeedAdjustmentForToTEvaluation.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
				{
					SpeedAdjustmentToT_OriginalSpeed = null;
					SpeedAdjustmentToT_OriginalSpeedOverride = null;
					SpeedAdjustmentToT_OriginalThrottle = null;
					SpeedAdjustmentToT_OriginalThrottlePreset = null;
				}
				return;
			}
			if (!Information.IsNothing(TimeToNextSpeedAdjustmentForToTEvaluation))
			{
				TimeToNextSpeedAdjustmentForToTEvaluation -= float_0;
				float? timeToNextSpeedAdjustmentForToTEvaluation2 = TimeToNextSpeedAdjustmentForToTEvaluation;
				if ((timeToNextSpeedAdjustmentForToTEvaluation2.HasValue ? new bool?(timeToNextSpeedAdjustmentForToTEvaluation2.GetValueOrDefault() < 0f) : null).GetValueOrDefault() || m_EventVal.IsRTB_Or_CalledOff || m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
				{
					TimeToNextSpeedAdjustmentForToTEvaluation = null;
					if (IsPerformingSpeedAdjustmentToT)
					{
						if (GetAircraft().Navigator.HasFlightPlan)
						{
							m_EventVal.DesiredSpeed = SpeedAdjustmentToT_OriginalSpeed.Value;
							m_EventVal.Kinematics.DesiredSpeedOverride = SpeedAdjustmentToT_OriginalSpeedOverride;
							m_EventVal.SetThrottle(SpeedAdjustmentToT_OriginalThrottle.Value);
							m_EventVal.Kinematics.ThrottlePreset = SpeedAdjustmentToT_OriginalThrottlePreset.Value;
						}
						SpeedAdjustmentToT_OriginalSpeed = null;
						SpeedAdjustmentToT_OriginalSpeedOverride = null;
						SpeedAdjustmentToT_OriginalThrottle = null;
						SpeedAdjustmentToT_OriginalThrottlePreset = null;
						IsPerformingSpeedAdjustmentToT = false;
					}
				}
			}
			if (!Information.IsNothing(TimeToNextSpeedAdjustmentForToTEvaluation))
			{
				return;
			}
			if (GetAircraft().CurrentSpeed > 0f && GetAircraft().Navigator.HasFlightPlan && GetAircraft().Navigator.HasNonPathfindPlottedCourse() && !Information.IsNothing(GetAircraft().Navigator.PlottedCourse[0].Time_Zulu) && GetAircraft().Navigator.PlottedCourse[0].SpeedAdjustmentToT > Waypoint.SpeedToT.No)
			{
				Waypoint waypoint3 = GetAircraft().Navigator.PlottedCourse[0];
				float float_ = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint3.Latitude, waypoint3.Longitude);
				if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, float_)) < 5f)
				{
					float desiredSpeed = m_EventVal.DesiredSpeed;
					float num = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint3.Latitude, waypoint3.Longitude) / desiredSpeed * 3600f;
					DateTime? time_Zulu = waypoint3.Time_Zulu;
					DateTime? dateTime = m_EventVal.ParentScen.Time.AddSeconds(num);
					double totalSeconds = (time_Zulu.Value - dateTime.Value).TotalSeconds;
					if (Math.Abs(totalSeconds) <= 5.0)
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
						return;
					}
					if (totalSeconds < 0.0 && LeadMustSlowDownDueToBingo)
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
						return;
					}
					if (totalSeconds < 0.0 && waypoint3.SpeedAdjustmentToT == Waypoint.SpeedToT.Yes_DownOnly)
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
						return;
					}
					ActiveUnit.Throttle throttle = ActiveUnit.Throttle.FullStop;
					bool flag2 = false;
					if (totalSeconds < 0.0)
					{
						switch (m_EventVal.ThrottleSetting)
						{
						case ActiveUnit.Throttle.FullStop:
							flag2 = true;
							break;
						case ActiveUnit.Throttle.Loiter:
							throttle = ActiveUnit.Throttle.Cruise;
							break;
						case ActiveUnit.Throttle.Cruise:
							throttle = ActiveUnit.Throttle.Full;
							break;
						case ActiveUnit.Throttle.Full:
							if (waypoint3.SpeedAdjustmentToT == Waypoint.SpeedToT.Yes_UpOrDown_Afterburner)
							{
								throttle = ActiveUnit.Throttle.Flank;
							}
							else if (m_EventVal.DesiredSpeed < (float)m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false))
							{
								throttle = ActiveUnit.Throttle.Full;
							}
							else
							{
								flag2 = true;
							}
							break;
						case ActiveUnit.Throttle.Flank:
							if (m_EventVal.DesiredSpeed < (float)m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false))
							{
								throttle = ActiveUnit.Throttle.Flank;
							}
							else
							{
								flag2 = true;
							}
							break;
						}
					}
					else
					{
						if (!(waypoint3.Hold_Time <= 0f))
						{
							TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
							return;
						}
						switch (m_EventVal.ThrottleSetting)
						{
						case ActiveUnit.Throttle.FullStop:
						case ActiveUnit.Throttle.Loiter:
							flag2 = true;
							break;
						case ActiveUnit.Throttle.Cruise:
							throttle = ActiveUnit.Throttle.Loiter;
							break;
						case ActiveUnit.Throttle.Full:
							throttle = ActiveUnit.Throttle.Cruise;
							break;
						case ActiveUnit.Throttle.Flank:
							throttle = ActiveUnit.Throttle.Full;
							break;
						}
					}
					if (flag2)
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
						return;
					}
					float num2 = (float)GetAircraft().Kinematics.GetMaximumSpeed(m_EventVal.DesiredAltitude, throttle, bool_0: false) - m_EventVal.DesiredSpeed;
					float value = (float)((double)m_EventVal.DesiredSpeed * totalSeconds / 3600.0) / num2 * 3600f;
					SpeedAdjustmentToT_OriginalSpeed = m_EventVal.DesiredSpeed;
					SpeedAdjustmentToT_OriginalSpeedOverride = m_EventVal.Kinematics.DesiredSpeedOverride;
					SpeedAdjustmentToT_OriginalThrottle = m_EventVal.ThrottleSetting;
					SpeedAdjustmentToT_OriginalThrottlePreset = m_EventVal.Kinematics.ThrottlePreset;
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					m_EventVal.Kinematics.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)throttle;
					m_EventVal.SetThrottle(throttle);
					IsPerformingSpeedAdjustmentToT = true;
					if (Math.Abs(value) <= 75f)
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = Math.Max(Math.Abs(value) - 5f, 5f);
					}
					else
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
					}
				}
				else
				{
					TimeToNextSpeedAdjustmentForToTEvaluation = 30f;
				}
			}
			else
			{
				TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
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

	public static float MostRealisticOptimumAltitude(ref Aircraft aircraft_0, ActiveUnit.Throttle throttle_0, ref bool bool_0)
	{
		try
		{
			float maximumAltitude = aircraft_0.Kinematics.GetMaximumAltitude();
			bool_0 = false;
			if (aircraft_0.Propulsion[0].AltBands.Length < 4)
			{
				if (aircraft_0.Propulsion[0].AltBands.Length != 1 && !aircraft_0.IsHelicopter)
				{
					if (Information.IsNothing(throttle_0))
					{
						return maximumAltitude;
					}
					return aircraft_0.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle_0).MaxAlt;
				}
				if (maximumAltitude < 609.60004f)
				{
					return maximumAltitude;
				}
				return 609.60004f;
			}
			if (maximumAltitude * 3.28084f <= 60001f)
			{
				if (Information.IsNothing(throttle_0))
				{
					return 10972.8f;
				}
				return aircraft_0.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle_0).MinAlt;
			}
			if (Information.IsNothing(throttle_0))
			{
				return maximumAltitude;
			}
			return aircraft_0.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle_0).MaxAlt;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101362", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal float PrintFacade(ref Aircraft aircraft_0, ActiveUnit.Throttle throttle_0, bool bool_0, ref bool bool_1)
	{
		Weapon weapon = null;
		if (PrimaryTarget != null)
		{
			weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
		}
		if (weapon != null)
		{
			if (aircraft_0.DesiredAltitude < weapon.MinLaunchAlt_AGL)
			{
				return weapon.MinLaunchAlt_AGL;
			}
			if (aircraft_0.DesiredAltitude > weapon.MaxLaunchAlt_AGL && Math.Max(weapon.MaxLaunchAlt_AGL, weapon.MaxLaunchAlt_ASL) == 0f)
			{
				return weapon.MinLaunchAlt_AGL;
			}
		}
		return aircraft_0.DesiredAltitude;
	}

	internal bool DefineFacade()
	{
		try
		{
			if (m_EventVal == null)
			{
				return false;
			}
			if (GetAircraft().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				return false;
			}
			if (GetAircraft().IsRTB)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			if (!Information.IsNothing(PrimaryTarget) && !PrimaryTarget.IsSubmergedContact)
			{
				return false;
			}
			bool flag3 = false;
			CommDevice[] comms_ReadOnly = m_EventVal.Comms_ReadOnly;
			CommDevice[] array = comms_ReadOnly;
			foreach (CommDevice commDevice in array)
			{
				if (commDevice.IsSonobuoyLink && commDevice.OccupiedChannels < commDevice.MaxChannels)
				{
					flag3 = true;
					break;
				}
			}
			if (flag3)
			{
				foreach (Weapon item2 in GetAircraft().Weaponry.AllDistinctWeaponsAboard_Actual())
				{
					if (item2.Type == Weapon._WeaponType.Sonobuoy && GetAircraft().Weaponry.TotalAvailableInventoryForThisWeapon(item2.DBID, bool_1: false) > 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					bool item = Terrain.ExcludeWatcher(m_EventVal.GetLatitude(), m_EventVal.GetLongitude()).IsOverland;
					if ((float)m_EventVal.GetLandElevation(item, bool_1: false, bool_2: false, m_EventVal.ParentScen) <= -20f)
					{
						if (SeaIceProvider.PrepareWriter(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()))
						{
							flag2 = false;
						}
						else
						{
							Contact primaryTarget = PrimaryTarget;
							if (!Information.IsNothing(primaryTarget))
							{
								if (Information.IsNothing(primaryTarget.UncertaintyArea))
								{
									if (!primaryTarget.IsPreciselyLocatedOnThisPulse && Module_Unit.RangeToUnit_Horiz(GetAircraft(), primaryTarget) < 2f)
									{
										flag2 = true;
									}
								}
								else
								{
									ActiveUnit_Navigator navigator = m_EventVal.Navigator;
									Contact contact;
									List<Geopoint_Struct> list_ = (contact = primaryTarget).UncertaintyArea;
									bool num = navigator.IsInsideUncertaintryArea(ref list_, 1f);
									contact.UncertaintyArea = list_;
									if (num)
									{
										flag2 = true;
									}
								}
							}
							if (!flag2)
							{
								Mission mission = GetAircraft().AssignedMissionOrPackage();
								if (!Information.IsNothing(mission) && mission.MissionClass == Mission._MissionClass.Patrol)
								{
									Patrol patrol = (Patrol)mission;
									GlobalVariables.PatrolType type = patrol.Type;
									if (type != 0 && type != GlobalVariables.PatrolType.SeaControl)
									{
										flag2 = false;
									}
									else if (!Information.IsNothing(patrol.PatrolArea))
									{
										if (Information.IsNothing(primaryTarget))
										{
											if (patrol.MovementStyle != Patrol.PatrolMovementStyle.RepeatableLoop && patrol.PatrolArea.Count >= 3)
											{
												if (GetAircraft().AI.IsInsidePatrolArea_NoBuffer)
												{
													flag2 = true;
												}
											}
											else if (GetAircraft().AI.EnableClient(new GeoPoint(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()), patrol.PatrolArea, 2f))
											{
												flag2 = true;
											}
										}
										else if (!Information.IsNothing(primaryTarget.UncertaintyArea))
										{
											ActiveUnit_Navigator navigator2 = m_EventVal.Navigator;
											Contact contact2;
											List<Geopoint_Struct> list_2 = (contact2 = primaryTarget).UncertaintyArea;
											bool num2 = navigator2.IsInsideUncertaintryArea(ref list_2, 5f);
											contact2.UncertaintyArea = list_2;
											if (num2)
											{
												flag2 = true;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						flag2 = false;
					}
				}
				return flag2;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100393", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void EmployUntargetedWeapons(float float_0)
	{
		if (!GetAircraft().ParentScen.SecondIsChangingOnThisPulse)
		{
			return;
		}
		Loadout.LoadoutRole? loadoutRole = GetAircraft().Loadout?.Role;
		int? num = (int?)loadoutRole;
		bool? flag;
		bool? flag2 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 3104) : null));
		bool? flag3;
		bool? flag4;
		if (flag2.HasValue && flag.GetValueOrDefault())
		{
			flag3 = true;
		}
		else
		{
			num = (int?)loadoutRole;
			flag2 = (flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 3004) : null));
			flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
		}
		bool? flag5 = flag3;
		flag4 = flag3;
		bool? flag6;
		bool? flag7;
		if (flag4.HasValue && flag5.GetValueOrDefault())
		{
			flag6 = true;
		}
		else
		{
			num = (int?)loadoutRole;
			flag4 = (flag7 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 3204) : null));
			flag6 = ((!flag4.HasValue) ? null : (flag7.GetValueOrDefault() | flag5));
		}
		flag7 = flag6;
		if (!flag7.GetValueOrDefault())
		{
			return;
		}
		List<ReferencePoint> list = null;
		if (GetAircraft().AssignedMissionOrPackage() != null && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
		{
			Doctrine._WCS? weaponControlStatus_Land = GetAircraft().Doctrine.GetWeaponControlStatus_Land(GetAircraft().ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
			if (!weaponControlStatus_Land.HasValue || weaponControlStatus_Land.Value != Doctrine._WCS.Hold)
			{
				list = ((Patrol)GetAircraft().AssignedMissionOrPackage()).PatrolArea;
			}
		}
		if (list == null)
		{
			return;
		}
		List<Weapon> source = GetAircraft().Weaponry.AllDistinctWeaponsAboard_Actual();
		source = source.Where((Weapon x) => x.IsMobileDecoy_Air).ToList();
		if (source.Count <= 0)
		{
			return;
		}
		Geopoint_Struct geopoint_Struct_ = Math2.RandomPointWithinThisArea(list);
		foreach (Weapon item in source)
		{
			if (item.MaxLandRange > Module_Unit.RangeToPoint_Horiz(GetAircraft(), geopoint_Struct_) && !GetAircraft().CountClient(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, 0f))
			{
				Contact contact_ = new ActivationPointContact(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude);
				Aircraft_Weaponry weaponry = GetAircraft().Weaponry;
				int dBID = item.DBID;
				Doctrine._GunStrafeGroundTargets? nullable_ = null;
				weaponry.CreateSalvo(contact_, dBID, 1, bool_1: true, ref nullable_, DateTime.MinValue);
			}
		}
	}

	public override void EngageTargets(float float_0)
	{
		try
		{
			if (GetAircraft().Crew == 0 && !GetAircraft().CommStuff.IsConnectedToSideNetwork && !GetAircraft().IsRTB)
			{
				return;
			}
			if (GetAircraft().ShouldDropSonobuoysOnThisPulse)
			{
				Aircraft_Weaponry weaponry = GetAircraft().Weaponry;
				string string_ = null;
				weaponry.DropSonobuoy(float_0, bool_1: false, ref string_);
			}
			bool flag = false;
			if (!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support && !Information.IsNothing(GetAircraft().Loadout) && GetAircraft().Loadout.Role == Loadout.LoadoutRole.ChaffLaying && !GetAircraft().Navigator.IsInSupportTransit)
			{
				flag = true;
			}
			if ((GetAircraft().Weaponry.LayChaffStream || flag) && GetAircraft().Weaponry.HasChaffBundles)
			{
				bool flag2 = false;
				foreach (ChaffCorridorCloud chaffCloud in m_EventVal.ParentScen.ChaffClouds)
				{
					if (!((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, chaffCloud) > 3.2397419999999997))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					GetAircraft().Weaponry.FireChaffBundle(float_0);
				}
			}
			base.EngageTargets(float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100395", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool ClosingWithinWeaponRangeOfPrimaryTarget()
	{
		try
		{
			Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
			if (Information.IsNothing(weapon))
			{
				return false;
			}
			double num = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: false, null, bool_1: false);
			if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= num * 1.5)
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100396", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void OptimizeAltSpeedForNextEngagement(float float_0, ref Weapon weapon_0)
	{
		if (GetAircraft().Navigator.HasFlightPlan)
		{
			ActiveUnit_Navigator activeUnit_Navigator = ((m_EventVal.GetParentGroup() == null || m_EventVal.GetParentGroup().GroupLead.Navigator == null) ? m_EventVal.Navigator : m_EventVal.GetParentGroup().GroupLead.Navigator);
			bool flag = false;
			if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && ((Strike)m_EventVal.AssignedMissionOrPackage()).TargetCount > 0)
			{
				flag = true;
			}
			Waypoint[] flightPlan = m_EventVal.Navigator.GetFlight().FlightPlan;
			Waypoint waypoint = null;
			Waypoint[] array = flightPlan;
			Waypoint[] array2 = array;
			foreach (Waypoint waypoint2 in array2)
			{
				if (!(flag | activeUnit_Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun) || waypoint2.Type != Waypoint.WaypointType.Target)
				{
					if (activeUnit_Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun && waypoint2.Type == Waypoint.WaypointType.StrikeEgress)
					{
						waypoint = waypoint2;
						break;
					}
					continue;
				}
				waypoint = waypoint2;
				break;
			}
			if (waypoint == null && m_EventVal.Navigator.PlottedCourse != null && m_EventVal.Navigator.PlottedCourse.Length != 0)
			{
				waypoint = m_EventVal.Navigator.PlottedCourse[0];
			}
			if (waypoint != null && m_EventVal.IsAircraft)
			{
				if (waypoint.DesiredAltitude_TerrainFollowing.HasValue && waypoint.DesiredAltitude_TerrainFollowing.Value > 0f)
				{
					((Aircraft)m_EventVal).DesiredAltitude = waypoint.DesiredAltitude_TerrainFollowing.Value;
					return;
				}
				if (waypoint.DesiredAltitude.HasValue && waypoint.DesiredAltitude.Value > 0f)
				{
					((Aircraft)m_EventVal).DesiredAltitude = waypoint.DesiredAltitude.Value;
					return;
				}
			}
			if (PrimaryTarget.ActualUnit == null)
			{
				ActiveUnit eventVal = m_EventVal;
				Aircraft aircraft_ = GetAircraft();
				ActiveUnit eventVal2 = m_EventVal;
				ActiveUnit eventVal3;
				bool bool_ = eventVal2.GetDesiredAltitude_UseTerrainFollowing(eventVal3 = m_EventVal);
				float desiredAltitude = MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_);
				eventVal2.SetDesiredAltitude_UseTerrainFollowing(eventVal3, bool_);
				eventVal.DesiredAltitude = desiredAltitude;
				return;
			}
		}
		try
		{
			switch (PrimaryTarget.Type)
			{
			default:
				throw new NotImplementedException();
			case Contact_Base.ContactType.Air:
			case Contact_Base.ContactType.Missile:
			case Contact_Base.ContactType.Orbital:
			case Contact_Base.ContactType.Decoy_Air:
				if (PrimaryTarget.ActualUnit.IsAircraft && ((Aircraft)PrimaryTarget.ActualUnit).IsAerostat)
				{
					PublishFacade(float_0, PrimaryTarget.Type, weapon_0);
				}
				else
				{
					DisableFacade(float_0);
				}
				break;
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Torpedo:
			case Contact_Base.ContactType.Decoy_Sub:
				PublishFacade(float_0, PrimaryTarget.Type, weapon_0);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.UndeterminedNaval:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.Mine:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Sonobuoy:
			case Contact_Base.ContactType.Installation:
			case Contact_Base.ContactType.AirBase:
			case Contact_Base.ContactType.NavalBase:
			case Contact_Base.ContactType.MobileGroup:
			case Contact_Base.ContactType.ActivationPoint:
				PublishFacade(float_0, PrimaryTarget.Type, weapon_0);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100397", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PublishFacade(float float_0, Contact_Base.ContactType contactType_0, Weapon weapon_0)
	{
		if (PrimaryTarget == null)
		{
			ActiveUnit eventVal = m_EventVal;
			Aircraft aircraft_ = GetAircraft();
			bool bool_ = false;
			eventVal.DesiredAltitude = PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: false, ref bool_);
			if (!m_EventVal.IsGroupWingman())
			{
				m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_);
			}
			return;
		}
		float desiredAltitude = GetAircraft().DesiredAltitude;
		try
		{
			Doctrine Local_theDoc = m_EventVal.Doctrine;
			Weapon weapon = weapon_0;
			if (weapon == null)
			{
				Side unitSide = m_EventVal.GetUnitSide();
				ref ActiveUnit eventVal10 = ref m_EventVal;
				Contact contact_ = PrimaryTarget;
				List<Weapon> list = unitSide.WeaponsLeftToFireAtThisTarget(ref eventVal10, ref contact_);
				PrimaryTarget = contact_;
				List<Weapon> list2 = list;
				weapon = ((list2.Count <= 0) ? m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, Local_theDoc) : list2.OrderByDescending((Weapon theWeapon) => theWeapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, Local_theDoc, bool_1: false)).ElementAtOrDefault(0));
			}
			if (weapon == null)
			{
				weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, Local_theDoc);
			}
			if (weapon == null)
			{
				ActiveUnit eventVal11 = m_EventVal;
				Aircraft aircraft_2 = GetAircraft();
				bool bool_3 = false;
				eventVal11.DesiredAltitude = PrintFacade(ref aircraft_2, ActiveUnit.Throttle.Cruise, bool_0: false, ref bool_3);
				if (!m_EventVal.IsGroupWingman())
				{
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_3);
				}
				return;
			}
			float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, Local_theDoc, bool_1: false);
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			float? num12 = null;
			bool flag = false;
			ActiveUnit.Throttle? throttle = null;
			float? num19 = null;
			Mission mission = m_EventVal.AssignedMissionOrPackage();
			Patrol patrol = null;
			float num20;
			if (mission != null && mission.MissionClass == Mission._MissionClass.Patrol)
			{
				patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				num19 = patrol.AttackDistance_Aircraft;
				num20 = (num19.HasValue ? (num19 + maxRangeForThisTarget).Value : ((float)Math.Max(10f + maxRangeForThisTarget, (double)maxRangeForThisTarget * 1.2)));
			}
			else
			{
				num20 = (float)Math.Max(10f + maxRangeForThisTarget, (double)maxRangeForThisTarget * 1.2);
			}
			Aircraft_Navigator aircraft_Navigator = null;
			Aircraft_AirOps aircraft_AirOps = null;
			if (!m_EventVal.IsPaintingATarget)
			{
				float val = PrimaryTarget.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen);
				float val2 = m_EventVal.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, m_EventVal.ParentScen);
				float val3 = m_EventVal.GetLandElevation_next(bool_0: true, float_0);
				float num21 = Math.Max(Math.Max(val2, val), val3);
				float num22 = m_EventVal.DesiredAltitude;
				float num23 = m_EventVal.DesiredAltitude_AGL;
				bool bool_4 = false;
				if (!m_EventVal.Kinematics.DesiredAltitudeOverride || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					Mission mission2 = m_EventVal.AssignedMissionOrPackage();
					if (mission2 != null && mission2.MissionClass == Mission._MissionClass.Patrol)
					{
						if (patrol == null)
						{
							patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
						}
						if (num19.HasValue && num > num20)
						{
							num12 = patrol.TransitAltitude_Aircraft;
							flag = patrol.TransitTerrainFollowing_Aircraft;
						}
						else
						{
							num12 = patrol.AttackAltitude_Aircraft;
							flag = patrol.AttackTerrainFollowing_Aircraft;
						}
					}
				}
				bool bool_5 = false;
				float num24 = 0f;
				float num25;
				float num2;
				if (num12.HasValue)
				{
					num25 = num12.Value;
					num2 = num12.Value;
					if (bool_5 = flag)
					{
						num24 = num25;
					}
					if (bool_5)
					{
						num2 += num21;
					}
				}
				else
				{
					Aircraft aircraft_3 = GetAircraft();
					num25 = PrintFacade(ref aircraft_3, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_5);
					num2 = num25;
					if (bool_5)
					{
						num24 = num25;
					}
					if (bool_5)
					{
						num2 += num21;
					}
				}
				if (num19.HasValue && num > num20)
				{
					m_EventVal.DesiredAltitude = num2;
					m_EventVal.DesiredAltitude_AGL = num24;
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_5);
					return;
				}
				float? num3 = null;
				Weapon._WeaponType type = weapon.Type;
				float num4 = 0f;
				float num5 = 0f;
				if (type != Weapon._WeaponType.Rocket && type != Weapon._WeaponType.Gun)
				{
					if (weapon.MaxLaunchAlt_AGL > 0f && weapon.MaxLaunchAlt_ASL == 0f)
					{
						num4 = weapon.MaxLaunchAlt_AGL + num21;
						num5 = weapon.MaxLaunchAlt_AGL;
					}
					else if (weapon.MaxLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_ASL > 0f)
					{
						num4 = weapon.MaxLaunchAlt_ASL;
						num5 = weapon.MaxLaunchAlt_ASL - num21;
					}
					else if (!(weapon.MaxLaunchAlt_AGL <= 0f) && weapon.MaxLaunchAlt_ASL > 0f)
					{
						num4 = Math.Min(weapon.MaxLaunchAlt_AGL + num21, weapon.MaxLaunchAlt_ASL);
						num5 = Math.Min(weapon.MaxLaunchAlt_ASL - num21, weapon.MaxLaunchAlt_AGL);
					}
					else if (!weapon.IsTorpedo && weapon.MaxLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_ASL == 0f)
					{
						num4 = num2;
						num5 = num24;
					}
				}
				else
				{
					if (Module_Unit.RangeToUnit_Slant(m_EventVal, PrimaryTarget) <= maxRangeForThisTarget)
					{
						num4 = weapon.MaxLaunchAlt_AGL + num21;
						num5 = weapon.MaxLaunchAlt_AGL;
					}
					else
					{
						num4 = (float)(Math.Sqrt(2.0) / 2.0 * (double)maxRangeForThisTarget * 1852.0 + (double)num21);
						num5 = (float)(Math.Sqrt(2.0) / 2.0 * (double)maxRangeForThisTarget * 1852.0);
					}
					if (num5 > weapon.MaxLaunchAlt_AGL)
					{
						num4 = weapon.MaxLaunchAlt_AGL + num21;
						num5 = weapon.MaxLaunchAlt_AGL;
					}
				}
				float num6 = 0f;
				float num7 = 0f;
				if (weapon.MinLaunchAlt_AGL > 0f && weapon.MinLaunchAlt_ASL == 0f)
				{
					num6 = weapon.MinLaunchAlt_AGL + num21;
					num7 = weapon.MinLaunchAlt_AGL;
				}
				else if (weapon.MinLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_ASL > 0f)
				{
					num6 = weapon.MinLaunchAlt_ASL;
					num7 = weapon.MinLaunchAlt_ASL - num21;
				}
				else if (!(weapon.MinLaunchAlt_AGL <= 0f) && weapon.MinLaunchAlt_ASL > 0f)
				{
					num6 = Math.Max(weapon.MinLaunchAlt_AGL + num21, weapon.MinLaunchAlt_ASL);
					num7 = Math.Max(weapon.MinLaunchAlt_ASL - num21, weapon.MinLaunchAlt_AGL);
				}
				else if (weapon.MinLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_ASL < 0f)
				{
					num6 = weapon.MinLaunchAlt_AGL + num21;
					num7 = weapon.MinLaunchAlt_AGL;
				}
				bool flag2 = false;
				if (Information.IsNothing(num12))
				{
					if (num2 > 0f)
					{
						if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
						{
							if (m_EventVal.IsGroupMember() && m_EventVal.GetParentGroup().GroupLead != null)
							{
								if (m_EventVal.IsGroupLead())
								{
									Waypoint[] plottedCourse = m_EventVal.Navigator.PlottedCourse;
									Waypoint[] array = plottedCourse;
									foreach (Waypoint waypoint in array)
									{
										if (waypoint.Type == Waypoint.WaypointType.Target && !waypoint.DesiredAltitudeOverride)
										{
											flag2 = true;
											break;
										}
									}
								}
								else
								{
									flag2 = m_EventVal.GetParentGroup().GroupLead.DesiredAltitude != num22;
								}
							}
						}
						else if (m_EventVal.Navigator.HasPlottedCourse())
						{
							if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal) == bool_5)
							{
								if (bool_5)
								{
									if (m_EventVal.DesiredAltitude_AGL == num24)
									{
										flag2 = true;
									}
								}
								else if (m_EventVal.DesiredAltitude == num25)
								{
									flag2 = true;
								}
							}
						}
						else
						{
							flag2 = true;
						}
					}
				}
				else
				{
					flag2 = true;
				}
				if (flag2)
				{
					num22 = num2;
					num23 = num24;
					bool_4 = bool_5;
					if (!Information.IsNothing(weapon_0))
					{
						float num8 = num22;
						float? num9 = num21 + GetAircraft().MinimumSafeHeight;
						if ((num9.HasValue ? new bool?(num8 < num9.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num22 += num21;
						}
						num8 = num23;
						num9 = num21 + GetAircraft().MinimumSafeHeight;
						if ((num9.HasValue ? new bool?(num8 < num9.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num23 += num21;
						}
					}
					if (num2 <= 0f && num24 <= 0f)
					{
						if (num22 > num4)
						{
							num22 = num4;
						}
						if (num22 < num6)
						{
							num22 = num6;
						}
						if (num23 > num5)
						{
							num23 = num5;
						}
						if (num23 < num7)
						{
							num23 = num7;
						}
					}
					else
					{
						if (num6 <= num22)
						{
							if (num4 < num22)
							{
								num22 = num4;
							}
							else
							{
								if (num22 > num4)
								{
									num22 = num4;
								}
								if (num22 < num6)
								{
									num22 = num6;
								}
							}
						}
						else
						{
							num22 = num6;
						}
						if (num7 <= num23)
						{
							if (num5 < num23)
							{
								num23 = num5;
							}
							else
							{
								if (num23 > num5)
								{
									num23 = num5;
								}
								if (num23 < num7)
								{
									num23 = num7;
								}
							}
						}
						else
						{
							num23 = num7;
						}
					}
					if (weapon.GetNeedsVisualLOSBeforeLaunch(PrimaryTarget.IsSurfaceContact))
					{
						num3 = AwakeFacade(2.1474836E+09f);
					}
					if (!Information.IsNothing(num3))
					{
						if ((num3.HasValue ? new bool?(num6 > num3.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							if (m_EventVal.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
							{
								string text = "";
								if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
								{
									text = " (" + GetAircraft().UnitClass + ")";
								}
								GetAircraft().AddMessage(GetAircraft().Name + text + "因为云层太低而无法攻击地面目标。没有足够的高度间隙来部署武器。", GetAircraft().Name + " 无法攻击目标", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
							}
						}
						else if ((num3.HasValue ? new bool?(num22 > num3.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num22 = num3.Value;
							num23 = (num3 - num21).Value;
							num4 = num22;
							num5 = num23;
						}
					}
					if (m_EventVal.Kinematics.DesiredAltitudeOverride)
					{
						if (m_EventVal.DesiredAltitude > num4)
						{
							m_EventVal.DesiredAltitude = num4;
						}
						if (m_EventVal.DesiredAltitude < num6)
						{
							m_EventVal.DesiredAltitude = num6;
						}
						if (m_EventVal.DesiredAltitude_AGL > num5)
						{
							m_EventVal.DesiredAltitude_AGL = num5;
						}
						if (m_EventVal.DesiredAltitude_AGL < num7)
						{
							m_EventVal.DesiredAltitude_AGL = num7;
						}
					}
					else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && (GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse || (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.IsGroupLead()) && m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))
					{
						if (num22 == m_EventVal.GetCurrentAltitude())
						{
							m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude();
							m_EventVal.DesiredAltitude_AGL = num23;
						}
						else
						{
							m_EventVal.DesiredAltitude = num22;
							m_EventVal.DesiredAltitude_AGL = num23;
						}
					}
					else if (Information.IsNothing(num12))
					{
						float num10 = Math.Abs(m_EventVal.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(m_EventVal, num22));
						if (num <= num20 + num10)
						{
							if (num22 == m_EventVal.GetCurrentAltitude())
							{
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude();
								m_EventVal.DesiredAltitude_AGL = num23;
							}
							else
							{
								m_EventVal.DesiredAltitude = num22;
								m_EventVal.DesiredAltitude_AGL = num23;
							}
						}
						else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
						{
							ActiveUnit eventVal12 = m_EventVal;
							Aircraft aircraft_4 = GetAircraft();
							ActiveUnit eventVal13 = m_EventVal;
							ActiveUnit eventVal14;
							bool bool_6 = eventVal13.GetDesiredAltitude_UseTerrainFollowing(eventVal14 = m_EventVal);
							float desiredAltitude2 = MostRealisticOptimumAltitude(ref aircraft_4, ActiveUnit.Throttle.Cruise, ref bool_6);
							eventVal13.SetDesiredAltitude_UseTerrainFollowing(eventVal14, bool_6);
							eventVal12.DesiredAltitude = desiredAltitude2;
						}
						else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							if (!Information.IsNothing(num19) && num > num20)
							{
								if (Information.IsNothing(aircraft_Navigator))
								{
									aircraft_Navigator = GetAircraft().Navigator;
								}
								if (Information.IsNothing(aircraft_AirOps))
								{
									aircraft_AirOps = GetAircraft().AirOps;
								}
								aircraft_Navigator.SetPatrolAltitude(bool_1: false, aircraft_AirOps.Condition);
							}
							else
							{
								Aircraft aircraft_5 = GetAircraft();
								ActiveUnit eventVal15;
								ActiveUnit eventVal16;
								bool bool_7 = (eventVal15 = m_EventVal).GetDesiredAltitude_UseTerrainFollowing(eventVal16 = m_EventVal);
								float num11 = PrintFacade(ref aircraft_5, ActiveUnit.Throttle.Cruise, bool_0: false, ref bool_7);
								eventVal15.SetDesiredAltitude_UseTerrainFollowing(eventVal16, bool_7);
								num22 = num11;
								m_EventVal.DesiredAltitude = num22;
								m_EventVal.DesiredAltitude_AGL = num22;
							}
						}
						else
						{
							if (Information.IsNothing(aircraft_Navigator))
							{
								aircraft_Navigator = GetAircraft().Navigator;
							}
							Aircraft_Navigator aircraft_Navigator2 = aircraft_Navigator;
							ActiveUnit eventVal17;
							ActiveUnit eventVal2;
							bool bool_8 = (eventVal17 = m_EventVal).GetDesiredAltitude_UseTerrainFollowing(eventVal2 = m_EventVal);
							float num13 = aircraft_Navigator2.OrderProxy(ref bool_8);
							eventVal17.SetDesiredAltitude_UseTerrainFollowing(eventVal2, bool_8);
							num22 = num13;
							m_EventVal.DesiredAltitude = num22;
						}
					}
					else
					{
						m_EventVal.DesiredAltitude = num22;
						m_EventVal.DesiredAltitude_AGL = num23;
						m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_4);
					}
				}
				else
				{
					if (!Information.IsNothing(weapon_0))
					{
						float num14 = num22;
						float? num15 = num21 + GetAircraft().MinimumSafeHeight;
						if ((num15.HasValue ? new bool?(num14 < num15.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num22 += num21;
						}
						num14 = num23;
						num15 = num21 + GetAircraft().MinimumSafeHeight;
						if ((num15.HasValue ? new bool?(num14 < num15.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num23 += num21;
						}
					}
					if (num22 > num4)
					{
						num22 = num4;
					}
					if (num22 < num6)
					{
						num22 = num6;
					}
					if (num23 > num5)
					{
						num23 = num5;
					}
					if (num23 < num7)
					{
						num23 = num7;
					}
					if (weapon.GetNeedsVisualLOSBeforeLaunch(PrimaryTarget.IsSurfaceContact))
					{
						num3 = AwakeFacade(2.1474836E+09f);
					}
					if (!Information.IsNothing(num3))
					{
						if ((num3.HasValue ? new bool?(num6 > num3.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							if (m_EventVal.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
							{
								string text2 = "";
								if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
								{
									text2 = " (" + GetAircraft().UnitClass + ")";
								}
								GetAircraft().AddMessage(GetAircraft().Name + text2 + "因为云层太低而无法攻击地面目标。没有足够的高度间隙来部署武器。", GetAircraft().Name + " 无法攻击目标", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
							}
						}
						else if ((num3.HasValue ? new bool?(num22 > num3.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num22 = (num3 - 10f).Value;
							num23 = (num3 - num21).Value;
							num4 = num22;
							num5 = num23;
						}
					}
					if (m_EventVal.Kinematics.DesiredAltitudeOverride)
					{
						if (m_EventVal.DesiredAltitude > num4)
						{
							m_EventVal.DesiredAltitude = num4;
						}
						if (m_EventVal.DesiredAltitude < num6)
						{
							m_EventVal.DesiredAltitude = num6;
						}
						if (m_EventVal.DesiredAltitude_AGL > num5)
						{
							m_EventVal.DesiredAltitude_AGL = num5;
						}
						if (m_EventVal.DesiredAltitude_AGL < num7)
						{
							m_EventVal.DesiredAltitude_AGL = num7;
						}
					}
					else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && (GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse || (m_EventVal.IsGroupWingman() && !Information.IsNothing(m_EventVal.IsGroupLead()) && m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))
					{
						if (num22 == m_EventVal.GetCurrentAltitude())
						{
							m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude();
							m_EventVal.DesiredAltitude_AGL = num23;
						}
						else
						{
							m_EventVal.DesiredAltitude = num22;
							m_EventVal.DesiredAltitude_AGL = num23;
						}
					}
					else if (Information.IsNothing(num12))
					{
						float num16 = Math.Abs(m_EventVal.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(m_EventVal, num22));
						if (num <= num20 + num16)
						{
							if (num22 == m_EventVal.GetCurrentAltitude())
							{
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude();
								m_EventVal.DesiredAltitude_AGL = num23;
							}
							else
							{
								m_EventVal.DesiredAltitude = num22;
								m_EventVal.DesiredAltitude_AGL = num23;
							}
						}
						else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
						{
							ActiveUnit eventVal3 = m_EventVal;
							Aircraft aircraft_6 = GetAircraft();
							ActiveUnit eventVal4 = m_EventVal;
							ActiveUnit eventVal5;
							bool bool_9 = eventVal4.GetDesiredAltitude_UseTerrainFollowing(eventVal5 = m_EventVal);
							float desiredAltitude3 = MostRealisticOptimumAltitude(ref aircraft_6, ActiveUnit.Throttle.Cruise, ref bool_9);
							eventVal4.SetDesiredAltitude_UseTerrainFollowing(eventVal5, bool_9);
							eventVal3.DesiredAltitude = desiredAltitude3;
						}
						else if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							if (!Information.IsNothing(num19) && num > num20)
							{
								if (Information.IsNothing(aircraft_Navigator))
								{
									aircraft_Navigator = GetAircraft().Navigator;
								}
								if (Information.IsNothing(aircraft_AirOps))
								{
									aircraft_AirOps = GetAircraft().AirOps;
								}
								aircraft_Navigator.SetPatrolAltitude(bool_1: false, aircraft_AirOps.Condition);
							}
							else
							{
								Aircraft aircraft_7 = GetAircraft();
								ActiveUnit eventVal6;
								ActiveUnit eventVal7;
								bool bool_10 = (eventVal6 = m_EventVal).GetDesiredAltitude_UseTerrainFollowing(eventVal7 = m_EventVal);
								float num17 = PrintFacade(ref aircraft_7, ActiveUnit.Throttle.Cruise, bool_0: false, ref bool_10);
								eventVal6.SetDesiredAltitude_UseTerrainFollowing(eventVal7, bool_10);
								num22 = num17;
								m_EventVal.DesiredAltitude = num22;
								m_EventVal.DesiredAltitude_AGL = num23;
							}
						}
						else
						{
							if (Information.IsNothing(aircraft_Navigator))
							{
								aircraft_Navigator = GetAircraft().Navigator;
							}
							Aircraft_Navigator aircraft_Navigator3 = aircraft_Navigator;
							ActiveUnit eventVal8;
							ActiveUnit eventVal9;
							bool bool_2 = (eventVal8 = m_EventVal).GetDesiredAltitude_UseTerrainFollowing(eventVal9 = m_EventVal);
							float num18 = aircraft_Navigator3.OrderProxy(ref bool_2);
							eventVal8.SetDesiredAltitude_UseTerrainFollowing(eventVal9, bool_2);
							num22 = num18;
							m_EventVal.DesiredAltitude = num22;
							m_EventVal.DesiredAltitude_AGL = num23;
							m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_4);
						}
					}
					else
					{
						m_EventVal.DesiredAltitude = num22;
						m_EventVal.DesiredAltitude_AGL = num23;
						m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, bool_4);
					}
				}
			}
			if (!GetAircraft().Kinematics.DesiredSpeedOverride.HasValue || m_EventVal.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					if (Information.IsNothing(patrol))
					{
						patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
					}
					throttle = ((Information.IsNothing(num19) || num <= num20) ? patrol.AttackThrottle_Aircraft : patrol.TransitThrottle_Aircraft);
				}
				if (Information.IsNothing(throttle))
				{
					if (num <= num20)
					{
						if (Information.IsNothing(aircraft_Navigator))
						{
							aircraft_Navigator = GetAircraft().Navigator;
						}
						if (Information.IsNothing(aircraft_AirOps))
						{
							aircraft_AirOps = GetAircraft().AirOps;
						}
						aircraft_Navigator.SetInterceptThrottle(m_EventVal.DesiredAltitude, m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.DesiredAltitude, ActiveUnit.Throttle.Cruise, bool_0: false), bool_1: false, aircraft_AirOps.Condition);
						if (weapon.MaxLaunchSpeed != 0 && (float)weapon.MaxLaunchSpeed < m_EventVal.DesiredSpeed)
						{
							m_EventVal.DesiredSpeed = weapon.MaxLaunchSpeed;
						}
						if (weapon.MinLaunchSpeed != 0 && (float)weapon.MinLaunchSpeed > m_EventVal.DesiredSpeed)
						{
							m_EventVal.DesiredSpeed = weapon.MinLaunchSpeed;
						}
					}
					else
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else
				{
					m_EventVal.SetThrottle(throttle.Value);
				}
			}
			if (weapon_0 == null && m_EventVal.DesiredAltitude == desiredAltitude && weapon != null)
			{
				Mount mount = null;
				if (_ParameterObserver != null)
				{
					mount = _ParameterObserver.Item1;
				}
				Aircraft_Weaponry weaponry = GetAircraft().Weaponry;
				Weapon weapon_ = weapon;
				Contact primaryTarget = PrimaryTarget;
				short? nullable_ = null;
				Mount mount_ = mount;
				Sensor sensor_ = null;
				if (weaponry.CanThisWeaponEngageThisTarget(weapon_, primaryTarget, ref nullable_, bool_1: false, bool_2: false, bool_3: false, mount_, ref sensor_).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OutsideBoresightLimits)
				{
					m_EventVal.AI.CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200351", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private float? AwakeFacade(float float_0)
	{
		Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(m_EventVal.ParentScen, m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), (int)Math.Round(m_EventVal.GetCurrentAltitude()));
		float? num = null;
		if (weatherAtThisTimeAndPlace.CloudInfo.HighCloudCoverThickness > 0 && float_0 >= (float)weatherAtThisTimeAndPlace.CloudInfo.HighCloudBase_m)
		{
			if (!((float)weatherAtThisTimeAndPlace.CloudInfo.HighCloudTop_m <= float_0))
			{
				return num;
			}
			num = weatherAtThisTimeAndPlace.CloudInfo.HighCloudBase_m;
		}
		if (weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudCoverThickness > 0 && float_0 >= (float)weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudBase_m)
		{
			num = ((!Information.IsNothing(num) || (float)weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudTop_m <= float_0) ? new float?(weatherAtThisTimeAndPlace.CloudInfo.MiddleCloudBase_m) : null);
		}
		if (weatherAtThisTimeAndPlace.CloudInfo.LowCloudCoverThickness > 0 && float_0 >= (float)weatherAtThisTimeAndPlace.CloudInfo.LowCloudBase_m)
		{
			num = ((!Information.IsNothing(num) || (float)weatherAtThisTimeAndPlace.CloudInfo.LowCloudTop_m <= float_0) ? new float?(weatherAtThisTimeAndPlace.CloudInfo.LowCloudBase_m) : null);
		}
		return num;
	}

	public void AssistRefuellingClients()
	{
		try
		{
			List<Aircraft> list = new List<Aircraft>();
			if (GetAircraft().AirOps.RefuellingQueue.Count > 0)
			{
				double double_ = 0.0;
				foreach (string key2 in GetAircraft().AirOps.RefuellingQueue.Keys)
				{
					if (string.IsNullOrEmpty(key2))
					{
						ConcurrentDictionary<string, byte> refuellingQueue = GetAircraft().AirOps.RefuellingQueue;
						byte value = 0;
						refuellingQueue.TryRemove(key2, out value);
						continue;
					}
					Aircraft aircraft = (Aircraft)GetAircraft().ParentScen.ActiveUnits[key2];
					if (aircraft == null)
					{
						ConcurrentDictionary<string, byte> refuellingQueue2 = GetAircraft().AirOps.RefuellingQueue;
						byte value2 = 0;
						refuellingQueue2.TryRemove(key2, out value2);
					}
					else if (!aircraft.Navigator.TankerIsBlockedByNoNavZone && aircraft != null)
					{
						double double_2 = 0.0;
						if (aircraft.FuelPercent(ref double_, ref double_2, bool_0: false) < 0.15)
						{
							list.Add(aircraft);
						}
						else if (aircraft.AssignedMissionOrPackage() != null && aircraft.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && aircraft.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
						{
							list.Add(aircraft);
						}
					}
				}
			}
			if (list.Count <= 0)
			{
				if (GetAircraft().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel)
				{
					List<KeyValuePair<string, Aircraft_AirOps.GEnum6>> list2 = new List<KeyValuePair<string, Aircraft_AirOps.GEnum6>>();
					ActiveUnit activeUnit = null;
					ActiveUnit activeUnit2 = null;
					list2.AddRange(GetAircraft().AirOps.A2AR_Connections);
					foreach (KeyValuePair<string, Aircraft_AirOps.GEnum6> item in list2)
					{
						if (GetAircraft().ParentScen.ActiveUnits.ContainsKey(item.Key))
						{
							Aircraft aircraft2 = (Aircraft)GetAircraft().ParentScen.ActiveUnits[item.Key];
							if (aircraft2.AI.IsEscort)
							{
								if (activeUnit2 != null || aircraft2.AssignedMissionOrPackage() == null)
								{
									continue;
								}
								if (aircraft2.Navigator.TankerFollowsMe.HasValue)
								{
									if (aircraft2.Navigator.TankerFollowsMe.GetValueOrDefault() && aircraft2.AssignedMissionOrPackage().TankerFollowsReceivers)
									{
										activeUnit2 = aircraft2;
									}
								}
								else if (aircraft2.AssignedMissionOrPackage().TankerFollowsReceivers)
								{
									activeUnit2 = aircraft2;
								}
							}
							else
							{
								if (aircraft2.IsGroupWingman() || aircraft2.AssignedMissionOrPackage() == null)
								{
									continue;
								}
								if (aircraft2.Navigator.TankerFollowsMe.HasValue)
								{
									if (aircraft2.Navigator.TankerFollowsMe.GetValueOrDefault() && aircraft2.Navigator.HasPlottedCourse())
									{
										activeUnit = aircraft2;
										break;
									}
								}
								else if (aircraft2.AssignedMissionOrPackage().TankerFollowsReceivers && aircraft2.Navigator.HasPlottedCourse())
								{
									activeUnit = aircraft2;
									break;
								}
							}
						}
						else
						{
							ConcurrentDictionary<string, Aircraft_AirOps.GEnum6> a2AR_Connections = GetAircraft().AirOps.A2AR_Connections;
							string key = item.Key;
							Aircraft_AirOps.GEnum6 value3 = Aircraft_AirOps.GEnum6.Drogue;
							a2AR_Connections.TryRemove(key, out value3);
						}
					}
					if (activeUnit == null)
					{
						if (!Information.IsNothing(activeUnit2))
						{
							GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Navigation, activeUnit2.DesiredHeading);
							GetAircraft().DesiredTurnRate_Navigation = activeUnit2.DesiredTurnRate_Navigation;
						}
					}
					else
					{
						GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Navigation, activeUnit.DesiredHeading);
						GetAircraft().DesiredTurnRate_Navigation = activeUnit.DesiredTurnRate_Navigation;
					}
				}
			}
			else
			{
				if (Module_Unit.RangeToUnit_Horiz(GetAircraft(), list[0]) > 10f)
				{
					GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), list[0].GetLatitude(), list[0].GetLongitude()));
				}
				if (GetAircraft().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.OffloadingFuel && (int)GetAircraft().ThrottleSetting < 2)
				{
					GetAircraft().SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			if (GetAircraft().AirOps.RefuellingQueue.Count > 0)
			{
				foreach (string key3 in GetAircraft().AirOps.RefuellingQueue.Keys)
				{
					if (string.IsNullOrEmpty(key3))
					{
						ConcurrentDictionary<string, byte> refuellingQueue3 = GetAircraft().AirOps.RefuellingQueue;
						byte value4 = 0;
						refuellingQueue3.TryRemove(key3, out value4);
						continue;
					}
					Aircraft aircraft3 = (Aircraft)GetAircraft().ParentScen.ActiveUnits[key3];
					if (aircraft3 == null)
					{
						ConcurrentDictionary<string, byte> refuellingQueue4 = GetAircraft().AirOps.RefuellingQueue;
						byte value5 = 0;
						refuellingQueue4.TryRemove(key3, out value5);
						continue;
					}
					if (GetAircraft().GetCurrentAltitude() > aircraft3.Kinematics.GetMaximumAltitude())
					{
						GetAircraft().DesiredAltitude = aircraft3.Kinematics.GetMaximumAltitude() - 100f;
					}
					if ((int)GetAircraft().ThrottleSetting <= 1)
					{
						continue;
					}
					Aircraft aircraft4 = GetAircraft();
					string string_ = "";
					float num = Module_Unit.PrintTokenizer(aircraft3, aircraft4, bool_0: false, ref string_);
					if (num <= 315f && num >= 135f)
					{
						if (Module_Unit.RangeToUnit_Horiz(GetAircraft(), aircraft3) < 25f)
						{
							GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
						}
						else if (aircraft3.Navigator.IsOnAutoPlannerPlottedCourse)
						{
							GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
						}
						else if (GetAircraft().AssignedMissionOrPackage() != null && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
						{
							GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
						}
					}
				}
			}
			if (GetAircraft().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel && (int)GetAircraft().ThrottleSetting > 1)
			{
				GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100401", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void QueryFacade(float float_0, bool bool_0)
	{
		PathBlockCheckInProgress = true;
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			if (!m_EventVal.Navigator.PathFindingInProgress)
			{
				ActiveUnit_Navigator navigator = m_EventVal.Navigator;
				double latitude = m_EventVal.GetLatitude();
				double longitude = m_EventVal.GetLongitude();
				double latitude2 = PrimaryTarget.GetLatitude();
				double longitude2 = PrimaryTarget.GetLongitude();
				int int_ = 0;
				GeoPoint geoPoint_ = null;
				if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: true, 0f, bool_2: false, null, bool_3: true, bool_4: false, bool_5: false, null, ref int_, ref geoPoint_))
				{
					List<Waypoint> list = new List<Waypoint>();
					list.AddRange(m_EventVal.Navigator.PlottedCourse);
					if (!m_EventVal.Navigator.PathFindingInProgress)
					{
						if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
						{
							Waypoint waypoint = (from theWP in list
								where theWP.Type == Waypoint.WaypointType.PathfindingPoint
								orderby list.IndexOf(theWP) descending
								select theWP).ElementAtOrDefault(0);
							float num = m_EventVal.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget)?.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: false, null, bool_1: false) ?? 1f;
							if (Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()) <= num)
							{
								m_EventVal.Navigator.FollowPlottedCourse(float_0);
							}
							else
							{
								m_EventVal.Navigator.TriggerPathfinderThread(waypoint, m_EventVal, null, bool_1: false, 0.15f, PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), m_EventVal.ParentScen, bool_0);
							}
						}
						else
						{
							m_EventVal.Navigator.TriggerPathfinderThread(null, m_EventVal, null, bool_1: false, 0.15f, PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), m_EventVal.ParentScen, bool_0);
						}
					}
				}
				else if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
				{
					m_EventVal.Navigator.ClearPathfindingWaypoints();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100402", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		PathBlockCheckInProgress = false;
	}

	private void ResetFacade(bool bool_0 = false)
	{
		try
		{
			if (base.Targets_ReadOnly.Length == 0 || GetAircraft().ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return;
			}
			List<Weapon> list = GetAircraft().Weaponry.IsGuidingWeaponsInAir_List();
			if (list.Count == 0 && !bool_0)
			{
				return;
			}
			if (_WrapperObserver == null)
			{
				_WrapperObserver = new List<Contact>();
			}
			else
			{
				_WrapperObserver.Clear();
			}
			Contact[] targets_ReadOnly = base.Targets_ReadOnly;
			Contact[] array = targets_ReadOnly;
			foreach (Contact contact in array)
			{
				m_ObserverObserver = contact.IncomingGuidedWeapons;
				if (list.Intersect(m_ObserverObserver).Count() > 0)
				{
					_WrapperObserver.Add(contact);
				}
			}
			if (bool_0 && _WrapperObserver.Count == 0)
			{
				_WrapperObserver.Add(PrimaryTarget);
			}
			if (_WrapperObserver.Count == 0)
			{
				return;
			}
			GetAircraft().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.BVRCrank;
			Contact contact2 = ((PrimaryTarget == null) ? base.Targets_ReadOnly[0] : PrimaryTarget);
			int num = (int)Math.Round(Math2.PublishClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), contact2.GetLatitude(), contact2.GetLongitude()));
			int num2 = num;
			int num3 = 5;
			do
			{
				int num4 = Math2.InsertClass(num - num3);
				int num5 = 0;
				foreach (Contact item in _WrapperObserver)
				{
					Sensor[] sensors_Cached = GetAircraft().Sensors_Cached;
					Sensor[] array2 = sensors_Cached;
					foreach (Sensor sensor in array2)
					{
						if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.TargetIsWithinCoverageArc(item, num4))
						{
							num5++;
							break;
						}
					}
				}
				if (num5 != _WrapperObserver.Count)
				{
					break;
				}
				num2 = num4;
				num3 += 5;
			}
			while (num3 <= 360);
			Sensor sensor2 = GetAircraft().Sensors_Cached.Where((Sensor theS) => theS.Type == Sensor.Sensor_Type.Radar).FirstOrDefault();
			num2 = ((sensor2 == null || (!sensor2.Codes.PESA && !sensor2.Codes.AESA)) ? Math2.InsertClass(num2 + 1) : Math2.InsertClass(num2 + 20));
			GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, num2);
			if (!GetAircraft().Kinematics.DesiredSpeedOverride.HasValue)
			{
				GetAircraft().SetThrottle(ActiveUnit.Throttle.Loiter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100403", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void MapFacade()
	{
		try
		{
			if (base.Targets_ReadOnly.Length == 0 || GetAircraft().ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return;
			}
			List<Weapon> first = GetAircraft().ParentScen.GuidedWeaponsInAir.Where((Weapon weapon_0) => weapon_0.FiringParent == GetAircraft() && weapon_0.ReadReponse()).ToList();
			List<Contact> list = new List<Contact>();
			Contact[] targets_ReadOnly = base.Targets_ReadOnly;
			Contact[] array = targets_ReadOnly;
			foreach (Contact contact in array)
			{
				Weapon[] incomingGuidedWeapons = contact.IncomingGuidedWeapons;
				if (first.Intersect(incomingGuidedWeapons).Count() > 0)
				{
					list.Add(contact);
				}
			}
			if (list.Count != 0)
			{
				GetAircraft().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.BVRDrag;
				Contact unit_ = list.OrderByDescending((Contact contact_0) => Module_Unit.RangeToUnit_Horiz(contact_0, GetAircraft())).ElementAtOrDefault(0);
				GetAircraft().SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(Module_Unit.BearingToUnit_True(GetAircraft(), unit_) + 180f));
				if (Information.IsNothing(GetAircraft().Kinematics.DesiredSpeedOverride))
				{
					GetAircraft().SetThrottle(ActiveUnit.Throttle.Flank);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10324523409589238590238095", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SortFacade(float float_0)
	{
		float num = 2f;
		MineClearingMission Local_myMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
		bool flag = m_EventVal.Navigator.DisableDic(ref Local_myMission.Area, ref Local_myMission.Area_2nm_Buffered, ref Local_myMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false);
		Aircraft_AirOps airOps = GetAircraft().AirOps;
		GetAircraft().Navigator.SetPatrolThrottle(bool_1: false, airOps.Condition);
		GetAircraft().Navigator.SetPatrolAltitude(bool_1: false, airOps.Condition);
		try
		{
			if (flag)
			{
				TList<UnguidedWeapon> Local_LegitTargets = new TList<UnguidedWeapon>();
				List<ReferencePoint> Local_MissionArea = Local_myMission.Area;
				Dictionary<string, UnguidedWeapon> Local_WeaponsDic = new Dictionary<string, UnguidedWeapon>();
				int num2 = m_EventVal.ParentScen.Mines.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (i < m_EventVal.ParentScen.Mines.Count)
					{
						try
						{
							Local_WeaponsDic.Add(m_EventVal.ParentScen.Mines[i].ObjectID, m_EventVal.ParentScen.Mines[i]);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
				}
				if (GetAircraft().HasMineCountermeasures() || GetAircraft().HasMineCounterWeapons())
				{
					try
					{
						Parallel.ForEach(m_EventVal.GetUnitSide().Contacts_NonAU, delegate(string theUW_ObjectID)
						{
							Local_WeaponsDic.TryGetValue(theUW_ObjectID, out var value);
							if (value != null && value.IsMine)
							{
								if (value.GetIsInsideThisArea(Local_MissionArea, m_EventVal.ParentScen, bool_0: true))
								{
									Local_LegitTargets.Add(value);
								}
								else if (Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && m_EventVal.Navigator.DisableDic(ref Local_MissionArea, ref Local_myMission.Area_2nm_Buffered, ref Local_myMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
								{
									Local_LegitTargets.Add(value);
								}
							}
						});
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
				}
				TList<UnguidedWeapon> tList = new TList<UnguidedWeapon>();
				UnguidedWeapon unguidedWeapon = null;
				UnguidedWeapon unguidedWeapon2 = null;
				IEnumerator enumerator = null;
				try
				{
					enumerator = Local_LegitTargets.GetEnumerator();
					while (enumerator.MoveNext())
					{
						UnguidedWeapon unguidedWeapon3 = (UnguidedWeapon)enumerator.Current;
						if (unguidedWeapon3 == null)
						{
							continue;
						}
						float num3 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon3);
						if (!(num3 <= num) || !((double)num3 * 1852.0 >= 500.0))
						{
							continue;
						}
						if (unguidedWeapon3._CandidateProxy == null)
						{
							tList.Add(unguidedWeapon3);
							continue;
						}
						if (m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon3._CandidateProxy.ObjectID) && !m_EventVal.ParentScen.MineAllocation.Contains(new KeyValuePair<string, UnguidedWeapon>(unguidedWeapon3._CandidateProxy.ObjectID, unguidedWeapon3)))
						{
							unguidedWeapon3._CandidateProxy = null;
						}
						if (unguidedWeapon3._CandidateProxy != null && !unguidedWeapon3._CandidateProxy.Equals(m_EventVal))
						{
							if (!unguidedWeapon3._CandidateProxy.IsWeapon)
							{
								if (m_EventVal.GetUnitSide().Units.Contains(unguidedWeapon3._CandidateProxy))
								{
									if (unguidedWeapon3._CandidateProxy.AssignedMissionOrPackage() != null && unguidedWeapon3._CandidateProxy.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
									{
										if (num3 < Module_Unit.RangeToUnit_Horiz(unguidedWeapon3._CandidateProxy, unguidedWeapon3) && m_EventVal.GetCanSweepMine(unguidedWeapon3) && m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
										{
										}
									}
									else
									{
										unguidedWeapon3._CandidateProxy = null;
									}
								}
								else
								{
									unguidedWeapon3._CandidateProxy = null;
								}
							}
						}
						else if (unguidedWeapon3._CandidateProxy != null && unguidedWeapon3._CandidateProxy.Equals(m_EventVal))
						{
							tList.Add(unguidedWeapon3);
							if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
							{
								m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon3);
							}
						}
						if (unguidedWeapon3._CandidateProxy == null)
						{
							tList.Add(unguidedWeapon3);
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
				Local_LegitTargets = tList;
				if (Local_LegitTargets.Count <= 0)
				{
					m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
				}
				else
				{
					while (Local_LegitTargets.Count > 0)
					{
						unguidedWeapon2 = (from theMine in Local_LegitTargets.ToList()
							where theMine != null && m_EventVal.GetCanSweepMine(theMine)
							orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, theMine)
							select theMine).ElementAtOrDefault(0);
						if (unguidedWeapon2 == null || unguidedWeapon2._CandidateProxy == null || unguidedWeapon2._CandidateProxy.Equals(m_EventVal))
						{
							break;
						}
						if (unguidedWeapon2.GetCurrentAltitude() < -5f)
						{
							Local_LegitTargets.Remove(unguidedWeapon2);
						}
						else
						{
							Local_LegitTargets.Remove(unguidedWeapon2);
						}
					}
				}
				if (unguidedWeapon2 != null && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
				{
					unguidedWeapon = null;
					m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref unguidedWeapon);
					unguidedWeapon2 = null;
				}
				if ((unguidedWeapon2 == null) & (Local_LegitTargets.Count > 0))
				{
					UnguidedWeapon unguidedWeapon4 = (from theMine in Local_LegitTargets.ToList()
						where theMine != null && theMine.GetCurrentAltitude() < -5f
						orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, theMine)
						select theMine).ElementAtOrDefault(0);
					if (unguidedWeapon4 != null && ((Aircraft)m_EventVal).Loadout != null && (unguidedWeapon4.Type == Weapon._WeaponType.BottomMine || unguidedWeapon4.Type == Weapon._WeaponType.RisingMine))
					{
						WeaponRec[] weapons = ((Aircraft)m_EventVal).Loadout.Weapons;
						for (int j = 0; j < weapons.Length; j = checked(j + 1))
						{
							WeaponRec weaponRec_ = weapons[j];
							if (weaponRec_.TimeToFire != 0f || weaponRec_.CurrentLoad <= 0)
							{
								continue;
							}
							Weapon referenceWeapon = weaponRec_.GetReferenceWeapon(m_EventVal.ParentScen);
							if (referenceWeapon.Type != Weapon._WeaponType.Torpedo || weaponRec_.CurrentLoad < 1 || !referenceWeapon.ValidTargets.Mine || unguidedWeapon4._CandidateProxy != null)
							{
								continue;
							}
							AimpointContact aimpointContact = new AimpointContact(unguidedWeapon4.GetLatitude(), unguidedWeapon4.GetLongitude());
							aimpointContact.SetCurrentAltitude(bool_0: false, unguidedWeapon4.GetCurrentAltitude());
							if (Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon4) >= referenceWeapon.MaxSubsurfaceRange / 2f)
							{
								continue;
							}
							ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
							int int_ = 1;
							WeaponSalvo weaponSalvo_ = null;
							List<Module_Unit.Unit> list = weaponry.ResetConsumer(float_0, ref weaponRec_, aimpointContact, ref int_, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
							if (list.Count > 0)
							{
								Module_Unit.Unit unit = list.First();
								if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(unit.ObjectID))
								{
									m_EventVal.ParentScen.MineAllocation.Add(unit.ObjectID, unguidedWeapon4);
								}
								unguidedWeapon4._CandidateProxy = (ActiveUnit)unit;
								ActiveUnit obj = (ActiveUnit)unit;
								Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
								obj.Set_AssignedMissionOrPackage(Local_myMission, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_);
							}
							break;
						}
					}
				}
				if (unguidedWeapon2 == null)
				{
					if (m_EventVal.IsGroupMember())
					{
						if (m_EventVal.IsGroupLead())
						{
							if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
							{
								if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref Local_myMission.Area, ref Local_myMission.Area_30nm_Buffered, ref Local_myMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
								{
									m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(Local_myMission.Area);
								}
								m_EventVal.Navigator.FollowPlottedCourse(float_0);
							}
							else
							{
								m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(Local_myMission.Area);
							}
						}
						else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							m_EventVal.Navigator.HeadToFormationStation(float_0);
						}
					}
					else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref Local_myMission.Area, ref Local_myMission.Area_30nm_Buffered, ref Local_myMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
						{
							m_EventVal.Navigator.PlotCourseToArea(Local_myMission.Area);
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
						GetAircraft().Navigator.SetPatrolThrottle(bool_1: false, airOps.Condition);
						GetAircraft().Navigator.SetPatrolAltitude(bool_1: false, airOps.Condition);
					}
					else
					{
						m_EventVal.Navigator.PlotCourseToArea(Local_myMission.Area);
					}
					return;
				}
				float num4 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon2);
				if (unguidedWeapon2._CandidateProxy == null && m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
				{
					unguidedWeapon = null;
					if (m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref unguidedWeapon))
					{
						unguidedWeapon2 = unguidedWeapon;
						num4 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon2);
					}
					else
					{
						unguidedWeapon._CandidateProxy = null;
						m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
						if (m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
						{
							m_EventVal.Navigator.RemoveWaypoint_Soft(m_EventVal.Navigator.PlottedCourse[0], bool_1: true);
						}
					}
				}
				else if (unguidedWeapon2._CandidateProxy != null && unguidedWeapon2._CandidateProxy.Equals(m_EventVal) && m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
				{
					ManouverToSweepMine(unguidedWeapon2, num4, bool_0: true);
				}
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				if (unguidedWeapon2 != null && unguidedWeapon2._CandidateProxy == null)
				{
					ManouverToSweepMine(unguidedWeapon2, num4, bool_0: true);
					unguidedWeapon2._CandidateProxy = m_EventVal;
					if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
					{
						UnguidedWeapon obj2 = null;
						if (!m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref obj2) || !unguidedWeapon2.Equals(obj2))
						{
							m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
							m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon2);
						}
					}
					else
					{
						m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon2);
					}
					if (m_EventVal.IsOnActiveMineClearingMission && m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
					{
						m_EventVal.Navigator.bool_0 = false;
						if (m_EventVal.Navigator.TimeToNextPathfinderCheck <= 0f && m_EventVal.Navigator.DisableDic(ref Local_myMission.Area, ref Local_myMission.Area_5nm_Buffered, ref Local_myMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
						{
							m_EventVal.Navigator.TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(10, 16);
						}
					}
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else if (unguidedWeapon2 != null && unguidedWeapon2._CandidateProxy != null && Operators.CompareString(unguidedWeapon2._CandidateProxy.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
				{
					if ((double)num4 > 0.6)
					{
						ManouverToSweepMine(unguidedWeapon2, num4, bool_0: true);
					}
					if (m_EventVal.Navigator.PlottedCourse.Count() <= 0 || m_EventVal.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
					{
						unguidedWeapon2._CandidateProxy = null;
						m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
					}
				}
			}
			else if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.IsGroupLead())
				{
					if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref Local_myMission.Area, ref Local_myMission.Area_30nm_Buffered, ref Local_myMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
						{
							m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(Local_myMission.Area);
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(Local_myMission.Area);
					}
				}
				else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
				{
					m_EventVal.Navigator.HeadToFormationStation(float_0);
				}
			}
			else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref Local_myMission.Area, ref Local_myMission.Area_30nm_Buffered, ref Local_myMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
				{
					m_EventVal.Navigator.PlotCourseToArea(Local_myMission.Area);
				}
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
			}
			else
			{
				m_EventVal.Navigator.PlotCourseToArea(Local_myMission.Area);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100780", "Full sub ");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalcFacade(CargoMission cargoMission_0)
	{
		switch (cargoMission_0.Type)
		{
		case CargoMission.CargoMissionType.Transfer:
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
			{
				m_EventVal.SetThrottle(cargoMission_0.TransitThrottle_Aircraft);
			}
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride && cargoMission_0.TransitAltitude_Aircraft > 0f)
			{
				m_EventVal.DesiredAltitude = cargoMission_0.TransitAltitude_Aircraft;
			}
			break;
		case CargoMission.CargoMissionType.Delivery:
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (m_EventVal.Navigator.DisableDic(ref cargoMission_0.Area, ref cargoMission_0.Area_1nm_Buffered, ref cargoMission_0.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
				{
					m_EventVal.SetThrottle(cargoMission_0.StationThrottle_Aircraft);
				}
				else
				{
					m_EventVal.SetThrottle(cargoMission_0.TransitThrottle_Aircraft);
				}
			}
			if (m_EventVal.Kinematics.DesiredAltitudeOverride)
			{
				break;
			}
			if (m_EventVal.Navigator.DisableDic(ref cargoMission_0.Area, ref cargoMission_0.Area_1nm_Buffered, ref cargoMission_0.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
			{
				if (cargoMission_0.StationAltitude_Aircraft > 0f)
				{
					m_EventVal.DesiredAltitude = cargoMission_0.StationAltitude_Aircraft;
				}
			}
			else if (cargoMission_0.TransitAltitude_Aircraft > 0f)
			{
				m_EventVal.DesiredAltitude = cargoMission_0.TransitAltitude_Aircraft;
			}
			break;
		}
	}

	private void RateFacade(float float_0)
	{
		CargoMission cargoMission = (CargoMission)m_EventVal.AssignedMissionOrPackage();
		Aircraft aircraft = (Aircraft)m_EventVal;
		if (cargoMission.Type == CargoMission.CargoMissionType.Transfer)
		{
			if (m_EventVal.IsGroupWingman())
			{
				aircraft.Navigator.HeadToFormationStation(float_0);
			}
			else if (aircraft.AirOps.ActualDestinationHost == null)
			{
				string text = "";
				if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + m_EventVal.UnitClass + ")";
				}
				if (cargoMission.DestinationUnit == null)
				{
					m_EventVal.ParentScen.AddMessage("飞机" + m_EventVal.Name + text + " is assigned to a cargo mission but has no destination set. Unassigning aircraft and returning to nearest base.", m_EventVal.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.AirOps, 0, null, m_EventVal.GetUnitSide(), new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				else
				{
					m_EventVal.ParentScen.AddMessage("飞机" + m_EventVal.Name + text + " is assigned to a cargo mission but cannot land at " + cargoMission.DestinationUnit.Name + ". Unassigning aircraft and returning to nearest base.", m_EventVal.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.AirOps, 0, null, m_EventVal.GetUnitSide(), new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				ActiveUnit eventVal = m_EventVal;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				eventVal.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				m_EventVal.AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
			}
			else
			{
				ReturnToBase(float_0);
				CalcFacade(cargoMission);
			}
			if (aircraft.IsTanker)
			{
				AssistRefuellingClients();
			}
			return;
		}
		if (m_EventVal.OnboardCargo.Count() == 0)
		{
			if (cargoMission.RTBUponCompletion)
			{
				if (aircraft.AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: true, bool_3: true))
				{
					CalcFacade(cargoMission);
					return;
				}
				ActiveUnit eventVal2 = m_EventVal;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
				eventVal2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_2);
				m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") is unable to return to base during cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.AirOps, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
			}
			else
			{
				ActiveUnit eventVal3 = m_EventVal;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_3 = Mission.MissionAssignmentAttemptResult.None;
				eventVal3.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_3);
				m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") has completed cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " has completed its cargo mission", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
			}
			return;
		}
		if (m_EventVal.Navigator.DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
		{
			if (!Module_Unit.ResetTokenizer(m_EventVal) && !Module_Unit.SortTokenizer(m_EventVal, float_0))
			{
				int num = 0;
				Geopoint_Struct geopoint_Struct_;
				do
				{
					num++;
					geopoint_Struct_ = Math2.RandomPointWithinThisArea(cargoMission.Area);
					if (num > 1000)
					{
						m_EventVal.AddMessage(m_EventVal.Name + "无法在参考点定义的货物着陆区域内选择合适的点", m_EventVal.Name + " 无法拾取点", LoggedMessage.MessageType.DockingOps, 1, bool_0: true, geopoint_Struct_);
						return;
					}
				}
				while (Terrain.GetElevation(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, bool_0: false, m_EventVal.ParentScen) <= 0);
				m_EventVal.Navigator.ClearPlottedCourse();
				m_EventVal.Navigator.AddWaypoint(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), geopoint_Struct_.Latitude, geopoint_Struct_.Longitude));
				return;
			}
			if (aircraft.Loadout.Cargo_ParadropCapable)
			{
				aircraft.AirOps.UnloadCargoParadrop();
			}
			if (aircraft.OnboardCargo.Count() != 0)
			{
				if (aircraft.IsHelicopter)
				{
					aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.TransferringCargo;
					aircraft.AirOps.ConditionTimer = Math.Max(120, ActiveUnit_DockingOps.TimeToUnloadCargo(aircraft, aircraft.OnboardCargo.ToList()));
					return;
				}
				aircraft.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
				m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") was unable to unload all cargo for mission: " + cargoMission.Name + " (Some onboard cargo could not be air dropped.) The unit will return to base.", m_EventVal.Name + " unable to unload all cargo; returning to base", LoggedMessage.MessageType.AirOps, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
			}
			return;
		}
		if (m_EventVal.IsGroupMember())
		{
			if (m_EventVal.IsGroupLead())
			{
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
					{
						m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(cargoMission.Area);
					}
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(cargoMission.Area, bool_1: false, Waypoint.WaypointType.DropOffPoint);
				}
			}
			else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
			}
		}
		else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
		{
			if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
			{
				m_EventVal.Navigator.PlotCourseToArea(cargoMission.Area);
			}
			m_EventVal.Navigator.FollowPlottedCourse(float_0);
		}
		else if (aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TransferringCargo)
		{
			m_EventVal.Navigator.PlotCourseToArea(cargoMission.Area, bool_1: false, Waypoint.WaypointType.DropOffPoint);
		}
		CalcFacade(cargoMission);
	}

	[CompilerGenerated]
	private GlobalVariables.TargetVisualSizeClass FlushFacade(Contact contact_0)
	{
		return contact_0.GetApparentSize(m_EventVal.ParentScen);
	}

	[CompilerGenerated]
	private GlobalVariables.TargetVisualSizeClass ForgotFacade(Contact contact_0)
	{
		return contact_0.GetApparentSize(m_EventVal.ParentScen);
	}

	[CompilerGenerated]
	private double CollectFacade(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double OrderFacade(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private int RegisterFacade(Contact contact_0)
	{
		return (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal, bool_1: false)
			where theAC.IsAircraft
			select theAC).Count();
	}

	[CompilerGenerated]
	private double ManageFacade(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private int RevertFacade(Contact contact_0)
	{
		return (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal)
			where theAC.IsAircraft
			select theAC).Count();
	}

	[CompilerGenerated]
	private double CountProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double CustomizeProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private bool CloneProxy(Contact contact_0)
	{
		if (!contact_0.IsAir_Missile_Orbital_Contact)
		{
			Mission mission_ = GetAircraft().AssignedMissionOrPackage();
			Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			string string_ = "";
			int int_ = 0;
			if (ContactIsRelevantToMission(contact_0, mission_, shootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_))
			{
				ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
				Doctrine doctrine = m_EventVal.Doctrine;
				string_ = "";
				int_ = 0;
				return weaponry.PopConsumer(contact_0, bool_1: true, doctrine, ref string_, ref int_);
			}
		}
		return false;
	}

	[CompilerGenerated]
	private double ConnectProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double MoveProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double DeleteProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private int AddProxy(Contact contact_0)
	{
		return (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal, bool_1: false)
			where theAC.IsAircraft
			select theAC).Count();
	}

	[CompilerGenerated]
	private double DestroyProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private int ComputeProxy(Contact contact_0)
	{
		return (from theAC in Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: false, m_EventVal)
			where theAC.IsAircraft
			select theAC).Count();
	}

	[CompilerGenerated]
	private double PatchProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double SelectProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double CallProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private GlobalVariables.TargetVisualSizeClass LogoutProxy(Contact contact_0)
	{
		return contact_0.GetApparentSize(m_EventVal.ParentScen);
	}

	[CompilerGenerated]
	private GlobalVariables.TargetVisualSizeClass ViewProxy(Contact contact_0)
	{
		return contact_0.GetApparentSize(m_EventVal.ParentScen);
	}

	[CompilerGenerated]
	private double ValidateProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private float LoginProxy(Module_Unit.Unit unit_0)
	{
		return Module_Unit.RangeToUnit_Horiz(unit_0, GetAircraft());
	}

	[CompilerGenerated]
	private bool GetProxy(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).UpdateReponse())
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private float WriteProxy(Weapon weapon_0)
	{
		return weapon_0.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, m_EventVal.Doctrine, bool_1: false);
	}

	[CompilerGenerated]
	private bool NewProxy(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).ReadReponse())
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool PushProxy(Weapon weapon_0)
	{
		if (weapon_0.FiringParent == GetAircraft())
		{
			return weapon_0.ReadReponse();
		}
		return false;
	}

	[CompilerGenerated]
	private bool InvokeProxy(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).ReadReponse())
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool SetupProxy(Weapon weapon_0)
	{
		if (weapon_0.FiringParent == GetAircraft())
		{
			return weapon_0.ReadReponse();
		}
		return false;
	}

	[CompilerGenerated]
	private bool ExcludeProxy(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(m_EventVal.ParentScen).ReadReponse())
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool IncludeProxy(Sensor sensor_0)
	{
		if (sensor_0.Codes.Classification)
		{
			return sensor_0.GetIsSuitableForThisTarget(PrimaryTarget.ActualUnit);
		}
		return false;
	}

	[CompilerGenerated]
	private float SearchProxy(Sensor sensor_0)
	{
		return sensor_0.MaxIDRangeOnThisTarget(GetAircraft(), PrimaryTarget.ActualUnit);
	}

	[CompilerGenerated]
	private bool EnableProxy(Weapon weapon_0)
	{
		if (weapon_0.FiringParent == GetAircraft())
		{
			return weapon_0.ReadReponse();
		}
		return false;
	}

	[CompilerGenerated]
	private float ChangeProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz(contact_0, GetAircraft());
	}
}
