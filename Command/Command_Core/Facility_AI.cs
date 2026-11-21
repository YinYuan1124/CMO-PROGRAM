using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_AI : ActiveUnit_AI
{
	private Facility m_PolicyClient;

	private HashSet<string> broadcasterClient;

	public override bool ConsidersToBeUnderAttack
	{
		get
		{
			try
			{
				if (m_EventVal == null)
				{
					return false;
				}
				if (_Threats == null)
				{
					return false;
				}
				if (m_EventVal.Sensors_ReadOnly().Count() < 1)
				{
					return false;
				}
				foreach (Contact threat in _Threats)
				{
					if (threat?.ActualUnit?.AI?.PrimaryTarget?.ActualUnit != m_EventVal)
					{
						if (!GetClient(threat))
						{
							if (!m_EventVal.IsGroupMember())
							{
								continue;
							}
							foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
							{
								if (value.AI.GetClient(threat))
								{
									return true;
								}
							}
							continue;
						}
						return true;
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100774", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return false;
		}
	}

	[SpecialName]
	private Facility GetParentPlatform()
	{
		if (m_PolicyClient == null)
		{
			m_PolicyClient = (Facility)m_EventVal;
		}
		return m_PolicyClient;
	}

	public static Facility_AI FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Facility_AI facility_AI = new Facility_AI(ref activeUnit_0);
			facility_AI.m_EventVal = activeUnit_0;
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
						facility_AI._PrimaryTarget = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "Threats":
						if (facility_AI._Threats == null)
						{
							facility_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_, ref concurrentDictionary_0);
								facility_AI._Threats.Add(item);
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
					case "DPT_E":
						facility_AI.DeterminePrimaryTarget_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryThreat":
					case "PThreat":
						facility_AI._PrimaryThreat = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "TTNPTE":
						facility_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "IE":
						facility_AI.IsEscort = true;
						break;
					case "PrimaryTarget_LastKnown_Lat":
						facility_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lon":
						facility_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "PrimaryPickupTarget":
						facility_AI._PrimaryPickupTarget = ActiveUnit.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "TargetList":
						facility_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								if (targetingEntry.Target != null && !facility_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
								{
									facility_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
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
					case "PTOE":
					case "PrimaryTargetOverrideExists":
						facility_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "HP":
					case "HPos":
						facility_AI.HoldPosition = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						facility_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "IgnorePlottedCourse":
					case "IPC":
					{
						bool num = Conversions.ToBoolean(xmlNode.InnerText);
						if (!Information.IsNothing(activeUnit_0.Doctrine))
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
					case "ET_E":
						facility_AI.EvaluateTargets_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
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
			return facility_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100545", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Facility_AI result = new Facility_AI(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Facility_AI(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		broadcasterClient = new HashSet<string>();
	}

	public override void EvaluateUnitStatus(float float_0, bool bool_0, bool bool_1)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			EvaluateUnitCargoStatus(float_0);
			byte? b = (byte?)m_EventVal.Doctrine.GetAutoEvade(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (_PrimaryThreat != null)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					m_EventVal.Status = m_EventVal._SingletonVal;
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
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
			if (m_EventVal.IsRTB)
			{
				return;
			}
			if (GetParentPlatform().RepresentsMobileGroundUnit && m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse && !m_EventVal.IsRTB && InsertClient())
			{
				m_EventVal.Navigator.ResetTimeToNextPathfinderCheck();
				return;
			}
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				bool? flag;
				if (Information.IsNothing(PrimaryTarget))
				{
					flag = false;
				}
				else
				{
					b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
				}
				bool? flag2 = flag;
				if (((!flag2) ?? flag2).GetValueOrDefault())
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					return;
				}
			}
			if (!Information.IsNothing(PrimaryTarget) && (int)PrimaryTarget.Type > 1)
			{
				bool flag3 = true;
				if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
					if (strike.MaxResponseRadius_Ship > 0 || strike.MinResponseRadius_Ship > 0)
					{
						float num = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
						if (num > (float)strike.MaxResponseRadius_Ship || num < (float)strike.MinResponseRadius_Ship)
						{
							flag3 = false;
						}
					}
				}
				if (flag3)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					return;
				}
			}
			if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup && m_EventVal.GetParentGroup().Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					EvaluateTargets(float_0, bool_0: false, bool_1: true);
				}
			}
			if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().IsActive)
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
					if (Information.IsNothing(PrimaryTarget))
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
					}
					else
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
					return;
				}
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			if (m_EventVal.FuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker && m_EventVal.WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun && m_EventVal.Status != 0)
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 200346", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] InstantiateBridge()
	{
		return m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
		if (!EvaluateTargets_Enabled || m_EventVal == null)
		{
			return;
		}
		try
		{
			if (m_EventVal.Mounts.Count == 0 && m_EventVal.Sensors_Cached.Length == 0)
			{
				if (PrimaryTarget != null)
				{
					DropTarget(PrimaryTarget);
				}
				if (base.Targets_ReadOnly.Length == 0)
				{
					return;
				}
				List<Contact> list = new List<Contact>();
				Contact[] targets_ReadOnly = base.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact item in array)
				{
					list.Add(item);
				}
				{
					foreach (Contact item2 in list)
					{
						DropTarget(item2);
					}
					return;
				}
			}
			base.EvaluateTargets(float_0, bool_0, bool_1: false);
			if (Information.IsNothing(m_EventVal) || (m_EventVal.IsFixedFacility && m_EventVal.Mounts.Count == 0))
			{
				return;
			}
			Mission mission = m_EventVal.AssignedMissionOrPackage();
			List<Weapon> list2 = m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual();
			Weapon weapon = null;
			Weapon weapon2 = null;
			Weapon weapon3 = null;
			Weapon weapon4 = null;
			foreach (Weapon item3 in list2)
			{
				if (Information.IsNothing(weapon))
				{
					if (item3.MaxAirRange > 0f)
					{
						weapon = item3;
					}
				}
				else if (item3.MaxAirRange > weapon.MaxAirRange)
				{
					weapon = item3;
				}
				if (Information.IsNothing(weapon2))
				{
					if (item3.MaxSurfaceRange > 0f)
					{
						weapon2 = item3;
					}
				}
				else if (item3.MaxSurfaceRange > weapon2.MaxSurfaceRange)
				{
					weapon2 = item3;
				}
				if (Information.IsNothing(weapon3))
				{
					if (item3.MaxLandRange > 0f)
					{
						weapon3 = item3;
					}
				}
				else if (item3.MaxLandRange > weapon3.MaxLandRange)
				{
					weapon3 = item3;
				}
				if (Information.IsNothing(weapon4))
				{
					if (item3.MaxSubsurfaceRange > 0f)
					{
						weapon4 = item3;
					}
				}
				else if (item3.MaxSubsurfaceRange > weapon4.MaxSubsurfaceRange)
				{
					weapon4 = item3;
				}
			}
			if (Information.IsNothing(weapon) && Information.IsNothing(weapon2) && Information.IsNothing(weapon4) && Information.IsNothing(weapon3) && (m_EventVal.IsFixedFacility || HoldPosition))
			{
				return;
			}
			Contact[] targets_ReadOnly2 = base.Targets_ReadOnly;
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			List<Contact> list3 = ChangeClient(targets_ReadOnly2);
			List<Weapon> list4 = new List<Weapon>();
			list4.AddRange(InstantiateBridge());
			Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if (PrintClient() == null)
			{
				DefineClient(Module_ActiveUnit_Sensory.ListTokenizer(m_EventVal.Sensory));
			}
			int count = PrintClient().Count;
			if (m_AccountVal == null)
			{
				m_AccountVal = new Tuple<Contact, Misc.PostureStance>[count - 1 + 1];
			}
			if (broadcasterClient.Count > 0)
			{
				broadcasterClient.Clear();
			}
			foreach (Contact item4 in PrintClient())
			{
				if (TargetingBehaviorForThisTarget(item4) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					broadcasterClient.Add(item4.ObjectID);
				}
			}
			Contact contact = null;
			Misc.PostureStance value;
			int int_;
			if (mission != null && mission.IsActive)
			{
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					contact = PrintClient()[i];
					string objectID = contact.ObjectID;
					if (broadcasterClient.Contains(objectID) || list3.Contains(contact))
					{
						continue;
					}
					byte? b = (byte?)contact.BDA_StructuralIntegrity;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						continue;
					}
					if (m_AccountVal[i] == null)
					{
						if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out value))
						{
							value = contact.GetStance(m_EventVal.GetUnitSide());
						}
						m_AccountVal[i] = new Tuple<Contact, Misc.PostureStance>(contact, value);
					}
					else
					{
						value = m_AccountVal[i].Item2;
					}
					Contact contact_ = contact;
					Doctrine._UseShootTourists? nullable_ = shootTourists;
					Misc.PostureStance? nullable_2 = value;
					string string_ = "";
					int_ = 0;
					if (!ContactIsRelevantToMission(contact_, mission, nullable_, bool_0, isInsidePatrolArea_10nmBuffer, bool_2: true, nullable_2, ref string_, ref int_))
					{
						continue;
					}
					switch (value)
					{
					case Misc.PostureStance.Unknown:
						TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						broadcasterClient.Add(contact.ObjectID);
						break;
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
						if (!PopClient(contact) && (contact.Type != Contact_Base.ContactType.Submarine || (!contact.IsClassifiedFalseTarget && !SeaIceProvider.PrepareWriter(contact.GetLongitude(), contact.GetLatitude()) && InterruptClient(contact, 100f) != 0)))
						{
							ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
							Contact contact_2 = contact;
							Doctrine doctrine = m_EventVal.Doctrine;
							string_ = "";
							int_ = 0;
							if (weaponry.PopConsumer(contact_2, bool_1: true, doctrine, ref string_, ref int_, list4))
							{
								TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								broadcasterClient.Add(contact.ObjectID);
							}
						}
						break;
					}
				}
			}
			if (m_EventVal.IsOnActivePatrol)
			{
				Patrol patrol = (Patrol)mission;
				GlobalVariables.PatrolType type = patrol.Type;
				if ((int)type <= 1 || (int)(type - 3) <= 3)
				{
					if (patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
					{
						weapon2 = m_EventVal.Weaponry.CountFacade(contact, bool_1: false);
						weapon3 = m_EventVal.Weaponry.CustomizeFacade(contact, bool_1: false);
					}
					else
					{
						weapon2 = null;
						weapon3 = null;
					}
				}
			}
			if (m_EventVal.IsOnActivePatrol)
			{
				_ = ((Patrol)mission).HasProsecutionArea;
			}
			Doctrine._UseShootTourists useShootTourists = Doctrine._UseShootTourists.No;
			bool hasValue;
			if (hasValue = shootTourists.HasValue)
			{
				useShootTourists = shootTourists.Value;
			}
			int_ = count - 1;
			for (int j = 0; j <= int_; j++)
			{
				try
				{
					contact = PrintClient()[j];
					string objectID2 = contact.ObjectID;
					if (broadcasterClient.Contains(objectID2) || list3.Contains(contact))
					{
						continue;
					}
					if (m_AccountVal[j] == null)
					{
						if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID2, out value))
						{
							value = contact.GetStance(m_EventVal.GetUnitSide());
						}
						m_AccountVal[j] = new Tuple<Contact, Misc.PostureStance>(contact, value);
					}
					else
					{
						value = m_AccountVal[j].Item2;
					}
					if (value == Misc.PostureStance.Neutral || value == Misc.PostureStance.Friendly)
					{
						continue;
					}
					byte? b2 = (byte?)contact.BDA_StructuralIntegrity;
					if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						if (mission == null || mission.MissionClass != Mission._MissionClass.Patrol || ((Patrol)mission).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen))
						{
							goto IL_096d;
						}
						Patrol patrol2 = (Patrol)mission;
						if (contact.GetIsInsideThisArea(patrol2.PatrolArea, m_EventVal.ParentScen, bool_0: true) || TargetingBehaviorForThisTarget(contact) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc || m_EventVal.Sensory.IsIlluminatingThisContact(contact) || (hasValue && useShootTourists == Doctrine._UseShootTourists.Yes))
						{
							goto IL_096d;
						}
					}
					goto end_IL_07ac;
					IL_096d:
					if (!broadcasterClient.Contains(contact.ObjectID))
					{
						ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
						Contact contact_3 = contact;
						Doctrine doctrine2 = m_EventVal.Doctrine;
						string string_2 = "";
						int int_2 = 0;
						if (weaponry2.PopConsumer(contact_3, bool_1: true, doctrine2, ref string_2, ref int_2, list4) && TargetIsEligibleBasedOnWeaponRange(contact, value, hasValue, useShootTourists, weapon, weapon2, weapon3, weapon4))
						{
							TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							broadcasterClient.Add(contact.ObjectID);
						}
					}
					end_IL_07ac:;
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
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100547", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool CreateBridge(Weapon weapon_0)
	{
		if (weapon_0 == null)
		{
			return false;
		}
		if (GetParentPlatform().Category == Facility._FacilityCategory.Underwater)
		{
			return weapon_0.ValidTargets.UnderwaterStructure;
		}
		IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = GetParentPlatform().EnableBridge();
		if ((mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM) || (!weapon_0.ValidTargets.MobileTarget_Hard && !weapon_0.ValidTargets.MobileTarget_Soft && !weapon_0.ValidTargets.MobileTarget_Personnel && !weapon_0.ValidTargets.LandStructure_Hard && !weapon_0.ValidTargets.LandStructure_Soft))
		{
			if (GetParentPlatform().RepresentsMobileGroundUnit)
			{
				if (GetParentPlatform().IsHardTarget)
				{
					if (weapon_0.ValidTargets.MobileTarget_Hard)
					{
						return true;
					}
				}
				else if (weapon_0.ValidTargets.MobileTarget_Hard || weapon_0.ValidTargets.MobileTarget_Soft || weapon_0.ValidTargets.MobileTarget_Personnel)
				{
					return true;
				}
			}
			else if (GetParentPlatform().Category == Facility._FacilityCategory.Runway)
			{
				if (weapon_0.ValidTargets.Runway)
				{
					return true;
				}
			}
			else if (GetParentPlatform().IsHardTarget)
			{
				if (weapon_0.ValidTargets.LandStructure_Hard)
				{
					return true;
				}
			}
			else if (weapon_0.ValidTargets.LandStructure_Hard || weapon_0.ValidTargets.LandStructure_Soft)
			{
				return true;
			}
			if (weapon_0.ValidTargets.Radar && m_EventVal.HasRadarSensor)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public override void EvaluateThreats()
	{
		if (m_EventVal == null || m_EventVal.IsFixedFacility || HoldPosition)
		{
			return;
		}
		try
		{
			ClearAllThreats();
			bool flag = false;
			int num = PrintClient().Count - 1;
			List<Weapon> list_ = null;
			Contact contact;
			ActiveUnit actualUnit;
			Misc.PostureStance value;
			Weapon weapon;
			for (int i = 0; i <= num; i++)
			{
				contact = PrintClient()[i];
				if (contact == null)
				{
					continue;
				}
				actualUnit = contact.ActualUnit;
				if (actualUnit == null || !actualUnit.IsWeapon)
				{
					continue;
				}
				if (m_AccountVal[i] == null)
				{
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
					{
						value = contact.GetStance(m_EventVal.GetUnitSide());
					}
				}
				else
				{
					value = m_AccountVal[i].Item2;
				}
				if (value == Misc.PostureStance.Friendly || !CreateBridge((Weapon)actualUnit))
				{
					continue;
				}
				AddContactToThreatList(contact);
				if ((_TargetList != null && _TargetList.ContainsKey(contact.ObjectID)) || ((Weapon)actualUnit).Type != Weapon._WeaponType.GuidedWeapon)
				{
					continue;
				}
				weapon = m_EventVal.Weaponry.RevertConsumer(contact);
				if (weapon != null)
				{
					if (!flag)
					{
						list_ = m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual();
						flag = true;
					}
					ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
					Contact contact_ = contact;
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = "";
					int int_ = 0;
					if (weaponry.PopConsumer(contact_, bool_1: true, doctrine, ref string_, ref int_, list_) && (double)Module_Unit.RangeToUnit_Slant(m_EventVal, contact) < 1.5 * (double)weapon.MaxAirRange)
					{
						TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			list_ = null;
			contact = null;
			actualUnit = null;
			value = Misc.PostureStance.Neutral;
			weapon = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100548", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EngageTargets(float float_0)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			if (GetParentPlatform().CanFireOnTheMove || (int)Math.Round(GetParentPlatform().CurrentSpeed) <= 0)
			{
				base.EngageTargets(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100549", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void MaintainStandoff(float float_0)
	{
		try
		{
			Doctrine doctrine = m_EventVal.Doctrine;
			Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, doctrine);
			if (weapon == null)
			{
				return;
			}
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, doctrine, bool_1: false);
			float num2 = num / maxRangeForThisTarget;
			float num3 = 0.8f;
			switch (GetParentPlatform().EnableBridge())
			{
			case IMobileGroundUnit._MobileUnitCategory.Infantry:
			case IMobileGroundUnit._MobileUnitCategory.Armor:
			case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
				num3 = 0.5f;
				break;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
				num3 = 0.95f;
				break;
			}
			if (num2 <= num3)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			}
			m_EventVal.Kinematics.DesiredSpeedOverride = null;
			if ((int)m_EventVal.ThrottleSetting < 3)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
			}
			ManouverTowardsTarget(float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100550", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool CompareBridge()
	{
		if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && !GetParentPlatform().CanFireOnTheMove && _TargetList != null)
		{
			Doctrine._UseShootTourists? shootTourists = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if (shootTourists.HasValue)
			{
				byte? b = (byte?)shootTourists;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					foreach (KeyValuePair<string, TargetingEntry> target in _TargetList)
					{
						if (m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(target.Value.Target, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine) != null)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		return false;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			if (m_EventVal.IsFixedFacility || HoldPosition)
			{
				return;
			}
			ActiveUnit._ActiveUnitStatus status = m_EventVal.Status;
			if (status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
			{
				if (status == ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					if (m_EventVal.DockingOps.UNREP_Destination != null)
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						return;
					}
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
				}
				switch (m_EventVal.Status)
				{
				case ActiveUnit._ActiveUnitStatus.OnSupportMission:
					if (CompareBridge())
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						return;
					}
					if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
					{
						if (!m_EventVal.IsGroupMember())
						{
							m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
							return;
						}
						if (m_EventVal.IsGroupLead())
						{
							m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
							return;
						}
						if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							m_EventVal.Navigator.HeadToFormationStation(float_0);
							return;
						}
					}
					break;
				case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
					if (CompareBridge())
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						return;
					}
					if (m_EventVal.IsOnActivePatrol && !m_EventVal.Navigator.NextWaypointIsManual)
					{
						if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && m_EventVal.Navigator.PlottedCourse.Length == 1 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
						{
							m_EventVal.Navigator.ClearPlottedCourse();
							return;
						}
						Patrol patrol2 = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea, ref patrol2.PatrolArea_ChangeCheck, 0f, bool_1: false))
						{
							m_EventVal.Navigator.ClearPlottedCourse();
							m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
						}
					}
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
					if (!m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Kinematics.ThrottlePreset != 0 && m_EventVal.DesiredSpeed != 0f)
					{
						m_EventVal.Kinematics.DesiredSpeedOverride = null;
						m_EventVal.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						return;
					}
					if (m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.DesiredSpeed == 0f)
					{
						if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
						{
							m_EventVal.DesiredSpeed = m_EventVal.Kinematics.DesiredSpeedOverride.Value;
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise, (int)Math.Round(m_EventVal.DesiredSpeed));
						}
						else
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
					}
					if (m_EventVal.AI.MustSlowDownToAllowGroupFormUp())
					{
						float num = float.MaxValue;
						foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
						{
							if (!value.IsGroupLead() && !value.Navigator.HaveReachedFormationStation() && value.DesiredSpeed > 0f && value.DesiredSpeed / 2f < num)
							{
								num = value.DesiredSpeed / 2f;
							}
						}
						m_EventVal.DesiredSpeed = Math.Min(m_EventVal.DesiredSpeed, num);
					}
					else if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
					{
						m_EventVal.DesiredSpeed = m_EventVal.Kinematics.DesiredSpeedOverride.Value;
					}
					else
					{
						if (!m_EventVal.IsGroupMember() || !m_EventVal.IsGroupLead())
						{
							return;
						}
						float num2 = float.MaxValue;
						foreach (ActiveUnit value2 in m_EventVal.GetParentGroup().Units.Values)
						{
							if (value2 != m_EventVal)
							{
								float num3 = value2.Kinematics.GetMaximumSpeed(value2.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false);
								if (num3 < num2)
								{
									num2 = num3;
								}
							}
						}
						m_EventVal.DesiredSpeed = num2;
					}
					return;
				case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
					if (Information.IsNothing(PrimaryTarget))
					{
						return;
					}
					if (PrimaryTarget.IsAir_Missile_Orbital_Contact)
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
					}
					else if (m_EventVal.IsGroupMember())
					{
						if (m_EventVal.IsGroupLead())
						{
							ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
							Contact primaryTarget = PrimaryTarget;
							Doctrine doctrine = m_EventVal.Doctrine;
							string string_ = "";
							int int_ = 0;
							if (weaponry.PopConsumer(primaryTarget, bool_1: true, doctrine, ref string_, ref int_))
							{
								MaintainStandoff(float_0);
							}
							else if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= 0.05)
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
							}
							else
							{
								ManouverTowardsTarget(float_0);
							}
						}
						else if (m_EventVal.AssignedMissionOrPackage() == m_EventVal.GetParentGroup().AssignedMissionOrPackage() && m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							bool flag = false;
							ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
							Contact primaryTarget2 = PrimaryTarget;
							Doctrine doctrine2 = m_EventVal.Doctrine;
							string string_2 = "";
							int int_2 = 0;
							if (weaponry2.PopConsumer(primaryTarget2, bool_1: true, doctrine2, ref string_2, ref int_2))
							{
								Weapon weapon = m_EventVal.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget);
								if (weapon != null)
								{
									float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, m_EventVal.Doctrine, bool_1: false);
									if (PrimaryTarget == m_EventVal.GetParentGroup().AI.PrimaryTarget)
									{
										foreach (ActiveUnit value3 in m_EventVal.GetParentGroup().Units.Values)
										{
											if (!(maxRangeForThisTarget <= Module_Unit.RangeToUnit_Horiz(value3, PrimaryTarget)))
											{
												flag = true;
												break;
											}
										}
									}
									else
									{
										flag = maxRangeForThisTarget > Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
									}
								}
							}
							if (flag)
							{
								MaintainStandoff(float_0);
							}
							else
							{
								m_EventVal.Navigator.HeadToFormationStation(float_0);
							}
						}
						else
						{
							MaintainStandoff(float_0);
						}
					}
					else
					{
						MaintainStandoff(float_0);
					}
					return;
				case ActiveUnit._ActiveUnitStatus.OnPatrol:
				{
					if (CompareBridge())
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
						return;
					}
					Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
					if (Information.IsNothing(patrol))
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						break;
					}
					if (m_EventVal.IsGroupMember())
					{
						if (m_EventVal.IsGroupLead())
						{
							if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
							{
								ActiveUnit_Navigator navigator = m_EventVal.GetParentGroup().Navigator;
								ref List<ReferencePoint> patrolArea = ref patrol.PatrolArea;
								List<ReferencePoint> list_ = null;
								List<ReferencePoint> list_2 = null;
								if (!navigator.PlottedCourseLeadsToMissionArea(ref patrolArea, ref list_, ref list_2, 0f, bool_1: false))
								{
									m_EventVal.GetParentGroup().Navigator.PlotCourseToStationArea(float_0, bool_1: false);
								}
								m_EventVal.Navigator.FollowPlottedCourse(float_0);
							}
							else
							{
								m_EventVal.GetParentGroup().Navigator.PlotCourseToStationArea(float_0, bool_1: false);
							}
							return;
						}
						if (!m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							break;
						}
						m_EventVal.Navigator.HeadToFormationStation(float_0);
						return;
					}
					if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						ActiveUnit_Navigator navigator2 = m_EventVal.Navigator;
						ref List<ReferencePoint> patrolArea2 = ref patrol.PatrolArea;
						List<ReferencePoint> list_3 = null;
						List<ReferencePoint> list_4 = null;
						if (!navigator2.PlottedCourseLeadsToMissionArea(ref patrolArea2, ref list_3, ref list_4, 30f, bool_1: false))
						{
							m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
					}
					return;
				}
				case ActiveUnit._ActiveUnitStatus.Tasked:
					if (IsEscort)
					{
						HeadToNearestEscortSubject();
					}
					break;
				}
				if (m_EventVal.IsGroupMember() && m_EventVal.CommStuff.IsConnectedToSideNetwork)
				{
					if (CompareBridge())
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
					}
					else
					{
						m_EventVal.Navigator.HeadToFormationStation(float_0);
					}
				}
				else if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					m_EventVal.DesiredSpeed = 0f;
				}
				return;
			}
			bool flag2 = true;
			GeoPoint geoPoint_ = LoginClient();
			ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps;
			string string_3 = "";
			List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(bool_0: true, null, ref string_3, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
			if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse || m_EventVal.DockingOps.UNREP_Destination == null)
			{
				if (m_EventVal.DockingOps.UNREP_Destination != null && potentialUNREPunits.Contains(m_EventVal.DockingOps.UNREP_Destination))
				{
					flag2 = m_EventVal.DockingOps.SearchDic(m_EventVal.DockingOps.UNREP_Destination) == ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success || m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
				}
				else if (potentialUNREPunits.Count <= 0)
				{
					if (m_EventVal.DockingOps.UNREP_Destination != null)
					{
						m_EventVal.DockingOps.DisconnectFromSupplier();
					}
					flag2 = false;
				}
				else
				{
					flag2 = m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false, 100).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
				}
			}
			if (m_EventVal.DockingOps.UNREP_Destination != null && flag2)
			{
				ActiveUnit uNREP_Destination = m_EventVal.DockingOps.UNREP_Destination;
				if (m_EventVal.IsGroupLead() && uNREP_Destination.IsGroupMember() && m_EventVal.GetParentGroup() == uNREP_Destination.GetParentGroup())
				{
					uNREP_Destination.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(uNREP_Destination, m_EventVal));
					uNREP_Destination.SetThrottle(ActiveUnit.Throttle.Full);
					m_EventVal.DesiredSpeed = Math.Max(5f, uNREP_Destination.CurrentSpeed - 10f);
					m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
					return;
				}
				if (uNREP_Destination.CommStuff.IsConnectedToSideNetwork)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(m_EventVal, uNREP_Destination));
				}
				else
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToPoint_True(m_EventVal, uNREP_Destination.Latitude_LastReported.Value, uNREP_Destination.Longitude_LastReported.Value));
				}
				if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, uNREP_Destination) < 0.1)
				{
					m_EventVal.DesiredSpeed = uNREP_Destination.CurrentSpeed;
					m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
				}
				else if ((float)(m_EventVal.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Cruise, bool_0: false) - 5) < uNREP_Destination.DesiredSpeed)
				{
					int maximumSpeed = m_EventVal.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Full, bool_0: false);
					ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.Full;
					if ((float)(maximumSpeed - 5) < uNREP_Destination.DesiredSpeed)
					{
						throttle_ = ActiveUnit.Throttle.Flank;
					}
					m_EventVal.SetThrottle(throttle_);
				}
				else
				{
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else
			{
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					m_EventVal.Status = m_EventVal.predicateVal;
				}
				if (m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.ManoeuveringToRefuel || m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Replenishing)
				{
					m_EventVal.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100551", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
