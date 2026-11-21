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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Ship_AI : ActiveUnit_AI
{
	[CompilerGenerated]
	private sealed class RoleMerchantService
	{
		public Ship_AI Me;

		public ObservableDictionary<string, UnguidedWeapon> Local_WeaponsDic;

		public List<ReferencePoint> Local_MissionArea;

		public TList<UnguidedWeapon> Local_LegitTargets;

		public MineClearingMission Local_myMission;

		internal void AssetInterruptibleReg(string theUW_ObjectID)
		{
			if (theUW_ObjectID == null)
			{
				return;
			}
			UnguidedWeapon unguidedWeapon = null;
			Local_WeaponsDic.TryGetValue(theUW_ObjectID, ref unguidedWeapon);
			if (!Information.IsNothing(unguidedWeapon) && unguidedWeapon.IsMine)
			{
				if (unguidedWeapon.GetIsInsideThisArea(Local_MissionArea, Me.m_EventVal.ParentScen, bool_0: true))
				{
					Local_LegitTargets.Add(unguidedWeapon);
				}
				else if (Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && Me.m_EventVal.Navigator.DisableDic(ref Local_MissionArea, ref Local_myMission.Area_2nm_Buffered, ref Local_myMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
				{
					Local_LegitTargets.Add(unguidedWeapon);
				}
			}
		}
	}

	private bool _BroadcasterFacade;

	private HashSet<string> m_IdentifierFacade;

	public override bool ConsidersToBeUnderAttack
	{
		get
		{
			bool result = false;
			try
			{
				if (m_EventVal == null)
				{
					return result;
				}
				if (_Threats == null)
				{
					result = false;
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
									result = true;
									return true;
								}
							}
							continue;
						}
						result = true;
						return true;
					}
					result = true;
					return true;
				}
				return result;
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
				return result;
			}
		}
	}

	public static Ship_AI FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		Ship_AI result = null;
		try
		{
			Ship_AI ship_AI = new Ship_AI(ref activeUnit_0);
			ship_AI.m_EventVal = activeUnit_0;
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
						ship_AI._PrimaryTarget = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "Threats":
						if (ship_AI._Threats == null)
						{
							ship_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_, ref concurrentDictionary_0);
								ship_AI._Threats.Add(item);
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
					case "PrimaryThreat":
						ship_AI._PrimaryThreat = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "IE":
						ship_AI.IsEscort = true;
						break;
					case "DPT_E":
						ship_AI.DeterminePrimaryTarget_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lon":
						ship_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "TTNPTE":
						ship_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "FerryCycleLegIsOutbound":
					case "FCLIO":
						ship_AI._FerryCycleLegIsOutbound = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lat":
						ship_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "PrimaryPickupTarget":
						ship_AI._PrimaryPickupTarget = ActiveUnit.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						break;
					case "TargetList":
						ship_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								if (targetingEntry.Target == null)
								{
									continue;
								}
								try
								{
									ship_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception exception_ = ex;
									exception_?.Data.Add("Error at 200037", exception_.Message);
									GameGeneral.WriteExceptionsToLog(ref exception_);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
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
					case "PrimaryTargetOverrideExists":
					case "PTOE":
						ship_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						ship_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode.InnerText);
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
						ship_AI.EvaluateTargets_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
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
			result = ship_AI;
			return result;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100773", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Ship_AI(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		_BroadcasterFacade = false;
		m_IdentifierFacade = new HashSet<string>();
	}

	public override void Manouver_InterceptCourse(float float_0, float? nullable_0, ref bool bool_0)
	{
		try
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			if (m_EventVal.Navigator.PlottedCourse != null && m_EventVal.Navigator.PlottedCourse.Length != 0 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun)
			{
				if (PrimaryTarget.UncertaintyArea != null)
				{
					return;
				}
				m_EventVal.Navigator.ApplyWaypointSpeedAltToUnit(m_EventVal.Navigator.PlottedCourse[0]);
				m_EventVal.Navigator.ApplyWaypointDoctrineToUnit(m_EventVal.Navigator.PlottedCourse[0]);
				m_EventVal.Navigator.RemoveWaypoint_Soft(m_EventVal.Navigator.PlottedCourse[0], bool_1: false);
			}
			if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
			{
				float float_ = (nullable_0.HasValue ? nullable_0.Value : m_EventVal.CurrentSpeed);
				Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
				if (weapon != null)
				{
					if (weapon.MinAirRange > 0f && Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= weapon.MinAirRange)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(Module_Unit.BearingToUnit_True(m_EventVal, PrimaryTarget) + 90f));
						return;
					}
					if (weapon.Flags.RearAspect_AAM || weapon.Flags.SternChase_AAM)
					{
						double double_ = 0.0;
						double double_2 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude(), ref double_, ref double_2, weapon.MinAirRange + 1f, Math2.UpdateClass(PrimaryTarget.CurrentHeading + 180f));
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(m_EventVal, double_2, double_));
						return;
					}
				}
				double? num = ActiveUnit_Navigator.CalculateInterceptHeading(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.CurrentHeading, PrimaryTarget, float_);
				if (num.HasValue)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, (float)num.Value);
				}
				else if (m_EventVal.CurrentSpeed < PrimaryTarget.CurrentSpeed)
				{
					if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.DesiredHeading, Module_Unit.BearingToUnit_True(m_EventVal, PrimaryTarget))) > 15f)
					{
						Manouver_PurePursuit(float_0, 0f, 0f);
					}
					bool_0 = true;
				}
				else
				{
					Manouver_PurePursuit(float_0, 0f, 0f);
					bool_0 = true;
				}
			}
			else
			{
				Manouver_PurePursuit(float_0, 0f, 0f);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100052", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ManoueverTorpedoEvasion(float float_0, Contact contact_0)
	{
		if (contact_0 == null)
		{
			return;
		}
		float num = Module_Unit.RangeToPoint_Horiz(m_EventVal, contact_0.GetLatitude(), contact_0.GetLongitude());
		Weapon weapon_ = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
		if (weapon_ != null && weapon_.Type != Weapon._WeaponType.Decoy_Expendable && weapon_.Type != Weapon._WeaponType.Decoy_Towed && IsClearedToEngageThisTarget(contact_0) && num <= weapon_.GetMaxRangeForThisTarget(m_EventVal, contact_0, bool_0: true, m_EventVal.Doctrine, bool_1: false))
		{
			m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
			Tuple<Mount, float, bool> tuple_ = null;
			TurnToUnmaskPrimaryWeapon(ref weapon_, contact_0, ref tuple_);
			return;
		}
		if (EvasionManeuver != null)
		{
			if (contact_0 == EvasionManeuver.TargetContact && (num >= EvasionManeuver.OriginalRange || m_EventVal.CurrentHeading != EvasionManeuver.DesiredHeading || m_EventVal.CurrentSpeed != m_EventVal.DesiredSpeed))
			{
				if (!(num < ActiveUnit_AI.TorpedoEvasionEmergencyRange) || !(EvasionManeuver.OriginalRange > ActiveUnit_AI.TorpedoEvasionEmergencyRange))
				{
					ExecuteManeuver(EvasionManeuver);
					return;
				}
				EvasionManeuver = null;
			}
			else
			{
				EvasionManeuver = null;
			}
		}
		float num2 = (float)Math.Round(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()), 0);
		ActiveUnit eventVal = m_EventVal;
		string string_ = "";
		float num3 = Module_Unit.PrintTokenizer(contact_0, eventVal, bool_0: true, ref string_);
		bool flag;
		if (!(flag = num > ActiveUnit_AI.TorpedoEvasionCloseRange) && contact_0.ActualUnit != null && contact_0.ActualUnit.IsWeapon && contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && contact_0.HeadingIsKnown && ((Weapon)contact_0.ActualUnit).Guidance == Weapon.WeaponGuidanceType.Inertial)
		{
			flag = true;
		}
		if (flag)
		{
			float num4 = contact_0.CurrentHeading;
			bool flag2 = false;
			if (contact_0.HeadingIsKnown)
			{
				float num5 = Math.Abs(MathFunctions.DeleteRequest(num2, num4));
				flag2 = num5 < 2.5f || ((double)num5 > 177.5 && !((double)num5 >= 182.5)) || !MathFunctions.Intersection(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.DesiredHeading, contact_0.GetLatitude(), contact_0.GetLongitude(), num4).HasZeroCoords;
			}
			else
			{
				num4 = Math2.UpdateClass(num2 + 180f);
				flag2 = true;
			}
			if (!flag2)
			{
				return;
			}
			EvasionManeuver = new PersistentManeuver(m_EventVal, contact_0, num);
			EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
			if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(num4 + 90f);
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(num4 - 90f);
			}
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			if (num3 < 90f && num3 > -90f)
			{
				if (num3 < 0f)
				{
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
				}
			}
			else if (num3 > 0f)
			{
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
			return;
		}
		float num6 = 20f;
		float num7 = 20f;
		if (contact_0.SpeedIsKnown)
		{
			num6 = contact_0.CurrentSpeed;
			num7 = m_EventVal.Kinematics.GetMaximumSpeed();
		}
		if (num7 >= num6)
		{
			float num8 = Math.Abs(Math2.UpdateClass(num2 + 180f) - m_EventVal.CurrentHeading);
			if (num8 > 180f)
			{
				num8 = 360f - num8;
			}
			if (num8 < 1f || num8 / m_EventVal.Kinematics.TurnRate() < num / (num6 / 3600f))
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				int int_ = (int)Math.Round(num2);
				OutrunThreat(ref int_);
				return;
			}
		}
		float num9 = Math.Abs(num3);
		EvasionManeuver = new PersistentManeuver(m_EventVal, contact_0, num);
		EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
		if (num <= ActiveUnit_AI.TorpedoEvasionEmergencyRange)
		{
			if (num9 < 60f)
			{
				if (num3 < 0f)
				{
					EvasionManeuver.DesiredHeading = Math2.UpdateClass(m_EventVal.CurrentHeading - 90f);
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
				}
				else
				{
					EvasionManeuver.DesiredHeading = Math2.UpdateClass(m_EventVal.CurrentHeading + 90f);
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
				}
			}
			else if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(m_EventVal.CurrentHeading + 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(m_EventVal.CurrentHeading - 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
		}
		else if (num9 < 30f)
		{
			EvasionManeuver.DesiredHeading = num2;
		}
		else if (num9 < 60f)
		{
			if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(num2 - 30f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(num2 + 30f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
		}
		else if (num3 < 0f)
		{
			EvasionManeuver.DesiredHeading = Math2.UpdateClass(num2 - 30f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
		}
		else
		{
			EvasionManeuver.DesiredHeading = Math2.UpdateClass(num2 + 30f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
		}
	}

	public override void ManouverAgainstPrimaryThreat(float float_0)
	{
		try
		{
			if (Information.IsNothing(_PrimaryThreat))
			{
				return;
			}
			double num = Math.Round(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), _PrimaryThreat.GetLatitude(), _PrimaryThreat.GetLongitude()), 0);
			if (double.IsNaN(num))
			{
				return;
			}
			switch (_PrimaryThreat.Type)
			{
			case Contact_Base.ContactType.Torpedo:
				ManoueverTorpedoEvasion(float_0, _PrimaryThreat);
				break;
			case Contact_Base.ContactType.Missile:
			{
				BeamThreat((int)Math.Round(num));
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				Weapon weapon_ = null;
				if (!Information.IsNothing(PrimaryThreat))
				{
					weapon_ = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryThreat, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
				}
				if (!Information.IsNothing(weapon_) && IsClearedToEngageThisTarget(PrimaryThreat))
				{
					Contact primaryThreat = PrimaryThreat;
					Tuple<Mount, float, bool> tuple_ = null;
					TurnToUnmaskPrimaryWeapon(ref weapon_, primaryThreat, ref tuple_);
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100775", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] UpdateOrder()
	{
		return m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
		if (!EvaluateTargets_Enabled || m_EventVal == null || m_EventVal.IsDestroyed)
		{
			return;
		}
		Side unitSide = m_EventVal.GetUnitSide();
		try
		{
			Contact contact = null;
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
						contact = null;
					}
					return;
				}
			}
			base.EvaluateTargets(float_0, bool_0, bool_1);
			if (m_EventVal == null)
			{
				return;
			}
			Mission mission = m_EventVal.AssignedMissionOrPackage();
			Contact[] targets_ReadOnly2 = base.Targets_ReadOnly;
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			List<Contact> list2 = ChangeClient(targets_ReadOnly2);
			List<Weapon> list3 = new List<Weapon>();
			list3.AddRange(UpdateOrder());
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
			if (m_IdentifierFacade.Count > 0)
			{
				m_IdentifierFacade.Clear();
			}
			foreach (Contact item3 in PrintClient())
			{
				if (TargetingBehaviorForThisTarget(item3) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					m_IdentifierFacade.Add(item3.ObjectID);
				}
			}
			Misc.PostureStance value;
			int int_;
			if (mission != null && mission.IsActive)
			{
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					contact = PrintClient()[i];
					if (m_IdentifierFacade.Contains(contact.ObjectID) || list2.Contains(contact))
					{
						continue;
					}
					byte? b = (byte?)contact.BDA_StructuralIntegrity;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						continue;
					}
					string objectID = contact.ObjectID;
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
						if (contact.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PrepareWriter(contact.GetLongitude(), contact.GetLatitude()))
						{
							TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							m_IdentifierFacade.Add(contact.ObjectID);
						}
						break;
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
						if (!PopClient(contact) && (contact.Type != Contact_Base.ContactType.Submarine || (!contact.IsClassifiedFalseTarget && !SeaIceProvider.PrepareWriter(contact.GetLongitude(), contact.GetLatitude()))))
						{
							ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
							Contact contact_2 = contact;
							Doctrine doctrine = m_EventVal.Doctrine;
							string_ = "";
							int_ = 0;
							if (weaponry.PopConsumer(contact_2, bool_1: true, doctrine, ref string_, ref int_, list3))
							{
								TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								m_IdentifierFacade.Add(contact.ObjectID);
							}
						}
						break;
					}
				}
			}
			Weapon weapon_ = m_EventVal.Weaponry.RevertConsumer(contact);
			Weapon weapon_2 = m_EventVal.Weaponry.CloneFacade(contact);
			Weapon weapon_3 = null;
			Weapon weapon_4 = null;
			if (m_EventVal.IsOnActivePatrol)
			{
				Patrol patrol = (Patrol)mission;
				GlobalVariables.PatrolType type = patrol.Type;
				if ((int)type <= 1 || (int)(type - 3) <= 3)
				{
					if (patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
					{
						weapon_3 = m_EventVal.Weaponry.CountFacade(contact, bool_1: false);
						weapon_4 = m_EventVal.Weaponry.CustomizeFacade(contact, bool_1: false);
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
				weapon_3 = m_EventVal.Weaponry.CountFacade(contact, bool_1: false);
				weapon_4 = m_EventVal.Weaponry.CustomizeFacade(contact, bool_1: false);
			}
			bool flag = m_EventVal.IsOnActivePatrol && ((Patrol)mission).HasProsecutionArea;
			Doctrine._UseShootTourists useShootTourists = Doctrine._UseShootTourists.No;
			bool hasValue;
			if (hasValue = shootTourists.HasValue)
			{
				useShootTourists = shootTourists.Value;
			}
			int_ = count - 1;
			for (int j = 0; j <= int_; j++)
			{
				contact = PrintClient()[j];
				string objectID2 = contact.ObjectID;
				if (m_IdentifierFacade.Contains(contact.ObjectID) || list2.Contains(contact))
				{
					continue;
				}
				if (m_AccountVal[j] == null)
				{
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID2, out value))
					{
						value = contact.GetStance(m_EventVal.GetUnitSide());
					}
				}
				else
				{
					value = m_AccountVal[j].Item2;
				}
				if (value == Misc.PostureStance.Friendly || value == Misc.PostureStance.Neutral)
				{
					continue;
				}
				byte? b2 = (byte?)contact.BDA_StructuralIntegrity;
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					continue;
				}
				if (!flag && mission != null && mission.MissionClass == Mission._MissionClass.Patrol && !contact.IsAir_Missile_Submarine_Contact && !((Patrol)mission).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen))
				{
					Patrol patrol2 = (Patrol)mission;
					if (!contact.GetIsInsideThisArea(patrol2.PatrolArea, m_EventVal.ParentScen, bool_0: true) && TargetingBehaviorForThisTarget(contact) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !m_EventVal.Sensory.IsIlluminatingThisContact(contact) && (!hasValue || useShootTourists != Doctrine._UseShootTourists.Yes))
					{
						continue;
					}
				}
				if (!m_IdentifierFacade.Contains(contact.ObjectID))
				{
					ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
					Contact contact_3 = contact;
					Doctrine doctrine2 = m_EventVal.Doctrine;
					string string_2 = "";
					int int_2 = 0;
					if (weaponry2.PopConsumer(contact_3, bool_1: true, doctrine2, ref string_2, ref int_2, list3) && TargetIsEligibleBasedOnWeaponRange(contact, value, hasValue, useShootTourists, weapon_, weapon_3, weapon_4, weapon_2))
					{
						TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						m_IdentifierFacade.Add(contact.ObjectID);
					}
				}
			}
			if (PrimaryTarget != null && PrimaryTarget is AimpointContact)
			{
				ref ActiveUnit eventVal = ref m_EventVal;
				Contact contact_4 = PrimaryTarget;
				List<Weapon> list4 = unitSide.WeaponsLeftToFireAtThisTarget(ref eventVal, ref contact_4);
				PrimaryTarget = contact_4;
				List<Weapon> list5 = list4;
				bool flag2 = false;
				foreach (Mount mount in m_EventVal.Mounts)
				{
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						int int_3 = mountWeapon.int_0;
						foreach (Weapon item4 in list5)
						{
							if (item4.DBID == int_3)
							{
								flag2 = true;
								break;
							}
						}
						if (flag2)
						{
							break;
						}
					}
					if (flag2)
					{
						break;
					}
				}
				if (!flag2)
				{
					DropTarget(PrimaryTarget);
				}
			}
			if (base.MayTargetNonAUs)
			{
				TargetNonAUsRelevantToMission();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100776", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TargetNonAUsRelevantToMission()
	{
	}

	public override void EvaluateThreats()
	{
		if (m_EventVal == null || m_EventVal.IsDestroyed)
		{
			return;
		}
		try
		{
			ClearAllThreats();
			List<Weapon> list_ = m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual();
			if (PrintClient().Count == 0)
			{
				return;
			}
			int num = PrintClient().Count - 1;
			bool flag = false;
			for (int i = 0; i <= num; i++)
			{
				if (PrintClient()[i].ActualUnit == null || flag || !PrintClient()[i].ActualUnit.IsWeapon)
				{
					continue;
				}
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(PrintClient()[i].ObjectID, out var value))
				{
					value = PrintClient()[i].GetStance(m_EventVal.GetUnitSide());
				}
				if (value == Misc.PostureStance.Friendly || !((Weapon)PrintClient()[i].ActualUnit).ValidTargets.SurfaceVessel)
				{
					continue;
				}
				AddContactToThreatList(PrintClient()[i]);
				if (((Weapon)PrintClient()[i].ActualUnit).Type != Weapon._WeaponType.Torpedo)
				{
					continue;
				}
				Weapon weapon = m_EventVal.Weaponry.CloneFacade(PrintClient()[i]);
				if (weapon != null)
				{
					ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
					Contact contact_ = PrintClient()[i];
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = "";
					int int_ = 0;
					if (weaponry.PopConsumer(contact_, bool_1: true, doctrine, ref string_, ref int_, list_) && (double)Module_Unit.RangeToUnit_Slant(m_EventVal, PrintClient()[i]) < 1.5 * (double)weapon.MaxSubsurfaceRange)
					{
						TargetThisContact(PrintClient()[i], bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100777", "");
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
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			EvaluateUnitCargoStatus(float_0);
			WeaponThreat = null;
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
				else
				{
					double num = Module_Unit.RangeToUnit_Horiz(m_EventVal, _PrimaryThreat);
					switch (_PrimaryThreat.Type)
					{
					case Contact_Base.ContactType.Torpedo:
						if (num < 3.0)
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
							return;
						}
						if (num < 10.0 && AngleOffContactsBoresight(ref _PrimaryThreat) < 90f)
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
							return;
						}
						break;
					case Contact_Base.ContactType.Air:
					{
						if (Module_Unit.RangeToUnit_Slant(m_EventVal, _PrimaryThreat) < 50f)
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
							return;
						}
						Weapon weapon = m_EventVal.Weaponry.LongestRangedSuitableWeaponForThisTarget(_PrimaryThreat);
						if (!Information.IsNothing(weapon))
						{
							float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, _PrimaryThreat, bool_0: false, m_EventVal.Doctrine, bool_1: false);
							if (Module_Unit.RangeToUnit_Slant(m_EventVal, _PrimaryThreat) < maxRangeForThisTarget * 2f)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
								return;
							}
						}
						break;
					}
					}
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
			if (m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo || m_EventVal.IsRTB)
			{
				return;
			}
			if (m_EventVal.ParentScen.FifthSecondIsChangingOnThisPulse && !m_EventVal.IsRTB && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && InsertClient())
			{
				m_EventVal.Navigator.ResetTimeToNextPathfinderCheck();
				return;
			}
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
				if ((!flag).GetValueOrDefault() || Information.IsNothing(PrimaryTarget) || !flag.HasValue)
				{
					if (m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun && !Information.IsNothing(PrimaryTarget))
					{
						if (Information.IsNothing(PrimaryTarget.UncertaintyArea))
						{
							m_EventVal.Navigator.ClearPlottedCourse();
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else if (GeoPoint.IsInsideThisArea(m_EventVal.Navigator.PlottedCourse[0].Latitude, m_EventVal.Navigator.PlottedCourse[0].Longitude, PrimaryTarget.UncertaintyArea))
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
						else
						{
							m_EventVal.Navigator.ClearPlottedCourse();
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
					}
					else
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					}
					return;
				}
				bool flag2 = true;
				if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
					if (strike.MaxResponseRadius_Ship > 0 || strike.MinResponseRadius_Ship > 0)
					{
						float num2 = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
						if (num2 > (float)strike.MaxResponseRadius_Ship || num2 < (float)strike.MinResponseRadius_Ship)
						{
							flag2 = false;
						}
					}
				}
				if (flag2)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					return;
				}
			}
			if (!Information.IsNothing(PrimaryTarget))
			{
				if ((int)PrimaryTarget.Type <= 1)
				{
					if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
				}
				else
				{
					bool flag3 = true;
					if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike2 = (Strike)m_EventVal.AssignedMissionOrPackage();
						if (strike2.MaxResponseRadius_Ship > 0 || strike2.MinResponseRadius_Ship > 0)
						{
							float num3 = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
							if (num3 > (float)strike2.MaxResponseRadius_Ship || num3 < (float)strike2.MinResponseRadius_Ship)
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
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else
				{
					switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
					{
					case Mission._MissionClass.Strike:
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.Patrol:
						if (!Information.IsNothing(PrimaryTarget))
						{
							if ((int)PrimaryTarget.Type > 1)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
							if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
						}
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
						return;
					case Mission._MissionClass.Support:
						if (!Information.IsNothing(PrimaryTarget))
						{
							b = (byte?)m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
						}
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
						return;
					case Mission._MissionClass.Ferry:
						if (!Information.IsNothing(PrimaryTarget))
						{
							b = (byte?)m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
						}
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnFerryMission;
						return;
					case Mission._MissionClass.Mining:
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.MineClearing:
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.Cargo:
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					}
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker || m_EventVal.WeaponState == ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
			{
				return;
			}
			if (base.PrimaryPickupTarget != null)
			{
				if (m_EventVal.Navigator.HasPlottedCourse())
				{
					ActiveUnit_Navigator navigator = m_EventVal.Navigator;
					double latitude = m_EventVal.GetLatitude();
					double longitude = m_EventVal.GetLongitude();
					double latitude2 = m_EventVal.Navigator.PlottedCourse[0].Latitude;
					double longitude2 = m_EventVal.Navigator.PlottedCourse[0].Longitude;
					int int_ = 0;
					GeoPoint geoPoint_ = null;
					if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: true, null, ref int_, ref geoPoint_))
					{
						m_EventVal.Navigator.PlotCourseToPickupPoint();
						if (!m_EventVal.Navigator.HasPlottedCourse())
						{
							m_EventVal.AddMessage(m_EventVal.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							m_EventVal.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
						}
					}
				}
				else if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, base.PrimaryPickupTarget) <= 2.2)
				{
					m_EventVal.DockingOps.SettleForCargoTransfer();
				}
				else
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
			}
			if (m_EventVal.Status != 0)
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 200348", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InsertOrder()
	{
		if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
		{
			return;
		}
		if (PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
		{
			ActiveUnit_Sensory sensory = m_EventVal.Sensory;
			Sensor[] sensor_ = null;
			List<Sensor> list = sensory.WriteConsumer(bool_0: false, bool_1: false, bool_2: true, bool_3: false, ref sensor_, bool_4: true);
			float num = ((list.Count <= 0) ? 0f : list[0].maxRange);
			if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= Math.Max(3.0, (double)num * 1.1))
			{
				ActiveUnit_AI aI = m_EventVal.AI;
				Contact primaryTarget = PrimaryTarget;
				float currentHeading = m_EventVal.CurrentHeading;
				float? nullable_ = 0.1f;
				bool bool_ = false;
				if (aI.CanInterceptTarget(primaryTarget, null, 0f, null, currentHeading, ActiveUnit.Throttle.Loiter, nullable_, bool_0: false, bool_1: false, ref bool_))
				{
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
					return;
				}
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				m_EventVal.Kinematics.AdjustSpeedForCavitation();
			}
			else
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
			}
			return;
		}
		ActiveUnit_AI aI2 = m_EventVal.AI;
		Contact primaryTarget2 = PrimaryTarget;
		float currentHeading2 = m_EventVal.CurrentHeading;
		float? nullable_2 = 0.1f;
		bool bool_2 = false;
		if (aI2.CanInterceptTarget(primaryTarget2, null, 0f, null, currentHeading2, ActiveUnit.Throttle.Full, nullable_2, bool_0: false, bool_1: false, ref bool_2))
		{
			Weapon._WeaponType? weaponType = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine)?.Type;
			short? num2 = (short?)weaponType;
			bool? flag;
			bool? flag2 = (flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2011) : null));
			bool? flag3;
			bool? flag4;
			if (flag2.HasValue && flag.GetValueOrDefault())
			{
				flag3 = true;
			}
			else
			{
				num2 = (short?)weaponType;
				flag2 = (flag4 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2010) : null));
				flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
			}
			flag4 = flag3;
			if (flag4.GetValueOrDefault())
			{
				ActiveUnit_AI aI3 = m_EventVal.AI;
				Contact primaryTarget3 = PrimaryTarget;
				float currentHeading3 = m_EventVal.CurrentHeading;
				float? nullable_3 = 0.1f;
				bool_2 = false;
				if (aI3.CanInterceptTarget(primaryTarget3, null, 0f, null, currentHeading3, ActiveUnit.Throttle.Flank, nullable_3, bool_0: false, bool_1: false, ref bool_2))
				{
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					return;
				}
			}
			if (!_BroadcasterFacade && m_EventVal.ThrottleSetting != ActiveUnit.Throttle.Full)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
			}
		}
		else
		{
			m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		if (m_EventVal == null || m_EventVal.IsDestroyed)
		{
			return;
		}
		try
		{
			ActiveUnit._ActiveUnitStatus activeUnitStatus = m_EventVal.Status;
			m_EventVal.Kinematics.HasAdjustedSpeedForCavitation = false;
			if (m_EventVal.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo)
			{
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			}
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(float_0, WeaponThreat);
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			if ((int)activeUnitStatus <= 13)
			{
				switch (activeUnitStatus)
				{
				case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
				{
					bool flag = true;
					GeoPoint geoPoint_ = LoginClient();
					ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps;
					string string_ = "";
					List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(bool_0: true, null, ref string_, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
					if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse || Information.IsNothing(m_EventVal.DockingOps.UNREP_Destination))
					{
						if (m_EventVal.DockingOps.UNREP_Destination != null && potentialUNREPunits.Contains(m_EventVal.DockingOps.UNREP_Destination))
						{
							flag = m_EventVal.DockingOps.SearchDic(m_EventVal.DockingOps.UNREP_Destination) == ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success || m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
						}
						else if (potentialUNREPunits.Count <= 0)
						{
							if (!Information.IsNothing(m_EventVal.DockingOps.UNREP_Destination))
							{
								m_EventVal.DockingOps.DisconnectFromSupplier();
							}
							flag = false;
						}
						else
						{
							flag = m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false, 100).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
						}
					}
					if (m_EventVal.DockingOps.UNREP_Destination != null && flag)
					{
						ActiveUnit uNREP_Destination = m_EventVal.DockingOps.UNREP_Destination;
						if (m_EventVal.IsGroupLead() && uNREP_Destination.IsGroupMember() && m_EventVal.GetParentGroup() == uNREP_Destination.GetParentGroup())
						{
							uNREP_Destination.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(uNREP_Destination, m_EventVal));
							if (Module_Unit.RangeToUnit_Horiz(m_EventVal, uNREP_Destination) < 1f)
							{
								uNREP_Destination.DesiredSpeed = Math.Max(5f, m_EventVal.CurrentSpeed + 5f);
								return;
							}
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
					return;
				}
				case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					ManouverAgainstPrimaryThreat(float_0);
					return;
				}
			}
			else
			{
				switch (activeUnitStatus)
				{
				case ActiveUnit._ActiveUnitStatus.Refuelling:
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.DockingOps.UNREP_Destination.DesiredHeading);
					ActiveUnit uNREP_Destination2 = m_EventVal.DockingOps.UNREP_Destination;
					if (m_EventVal.IsGroupLead() && uNREP_Destination2.IsGroupMember() && m_EventVal.GetParentGroup() == uNREP_Destination2.GetParentGroup())
					{
						uNREP_Destination2.DesiredSpeed = m_EventVal.DesiredSpeed;
						return;
					}
					m_EventVal.DesiredSpeed = uNREP_Destination2.DesiredSpeed;
					m_EventVal.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
					return;
				}
				case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
					if (m_EventVal.DesiredSpeed != 0f)
					{
						m_EventVal.DesiredSpeed = 0f;
						m_EventVal.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
						return;
					}
					break;
				}
			}
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
				if (m_EventVal.IsOnActivePatrol && !m_EventVal.Navigator.NextWaypointIsManual)
				{
					if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && m_EventVal.Navigator.PlottedCourse.Length == 1 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
					{
						m_EventVal.Navigator.ClearPlottedCourse();
						break;
					}
					Patrol patrol4 = (Patrol)m_EventVal.AssignedMissionOrPackage();
					if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol4.PatrolArea, ref patrol4.PatrolArea_30nm_Buffered, ref patrol4.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
					{
						m_EventVal.Navigator.ClearPlottedCourse();
						m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
					}
				}
				if (m_EventVal.IsOnActiveMineClearingMission && m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
				{
					m_EventVal.Navigator.bool_0 = false;
					MineClearingMission mineClearingMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
					if (m_EventVal.Navigator.TimeToNextPathfinderCheck <= 0f && m_EventVal.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
					{
						m_EventVal.Navigator.TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(10, 20);
					}
				}
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				if (!m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Kinematics.ThrottlePreset != 0 && m_EventVal.DesiredSpeed != 0f)
				{
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					m_EventVal.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
					m_EventVal.Status = m_EventVal.m_SchemaVal;
					break;
				}
				if (m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun && !Information.IsNothing(PrimaryTarget) && !Information.IsNothing(PrimaryTarget.UncertaintyArea) && !m_EventVal.GetIsInsideThisArea(PrimaryTarget.UncertaintyArea, m_EventVal.ParentScen, bool_0: true))
				{
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
					if (!CanInterceptTargetAtCurrentAltSpeed(PrimaryTarget, Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget), 0f, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading, null, bool_0: true, bool_1: true, bool_2: false))
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					}
					if (m_EventVal.AI.MustSlowDownToAllowGroupFormUp())
					{
						float desiredSpeed2 = m_EventVal.GetParentGroup().Kinematics.GroupMaxSpeedForThisThrottleSetting(m_EventVal.ThrottleSetting);
						m_EventVal.DesiredSpeed = desiredSpeed2;
					}
					break;
				}
				if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && !m_EventVal.Navigator.SprintDrift)
				{
					if (m_EventVal.IsOnActivePatrol)
					{
						Patrol patrol5 = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (m_EventVal.Navigator.DisableDic(ref patrol5.PatrolArea, ref patrol5.PatrolArea_2nm_Buffered, ref patrol5.PatrolArea_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
						{
							if (!Information.IsNothing(patrol5.StationThrottle_Ship))
							{
								m_EventVal.SetThrottle(patrol5.StationThrottle_Ship);
							}
						}
						else if (!Information.IsNothing(patrol5.TransitThrottle_Ship))
						{
							m_EventVal.SetThrottle(patrol5.TransitThrottle_Ship);
						}
					}
					else if (m_EventVal.IsOnActiveMiningMission)
					{
						MiningMission miningMission = (MiningMission)m_EventVal.AssignedMissionOrPackage();
						if (m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
						{
							if (!Information.IsNothing(miningMission.StationThrottle_Ship))
							{
								m_EventVal.SetThrottle(miningMission.StationThrottle_Ship);
							}
						}
						else if (!Information.IsNothing(miningMission.TransitThrottle_Ship))
						{
							m_EventVal.SetThrottle(miningMission.TransitThrottle_Ship);
						}
					}
					else if (m_EventVal.IsOnActiveMineClearingMission)
					{
						MineClearingMission mineClearingMission2 = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
						bool flag2 = false;
						float num3 = 9999f;
						foreach (ActiveUnit assignedBoat in m_EventVal.DockingOps.AssignedBoats)
						{
							if (!assignedBoat.IsOperating() || !assignedBoat.IsOnActiveMineClearingMission)
							{
								continue;
							}
							if (assignedBoat.IsRTB)
							{
								if ((float)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false) >= 5f)
								{
									num3 = Math.Min(num3, (float)(0.5 * (double)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false)));
									flag2 = true;
								}
							}
							else if (((Submarine)assignedBoat).IsTetheredROV)
							{
								assignedBoat.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
								num3 = Math.Min(num3, Math.Max(1f, assignedBoat.DesiredSpeed - 1f));
								flag2 = true;
							}
						}
						bool flag3 = m_EventVal.Navigator.DisableDic(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false);
						if (flag2 && num3 > 0f && num3 < 9999f)
						{
							num3 = (flag3 ? Math.Min(num3, m_EventVal.Kinematics.GetMaximumSpeed(0f, mineClearingMission2.StationThrottle_Ship, bool_0: false)) : Math.Min(num3, m_EventVal.Kinematics.GetMaximumSpeed(0f, mineClearingMission2.TransitThrottle_Ship, bool_0: false)));
							m_EventVal.DesiredSpeed = num3;
						}
						else if (flag3)
						{
							m_EventVal.SetThrottle(mineClearingMission2.StationThrottle_Ship);
						}
						else
						{
							m_EventVal.SetThrottle(mineClearingMission2.TransitThrottle_Ship);
						}
					}
					else if (m_EventVal.IsOnActiveFerryMission)
					{
						FerryMission ferryMission = (FerryMission)m_EventVal.AssignedMissionOrPackage();
						if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
						{
							if (ferryMission.FerryThrottle_Ship.HasValue)
							{
								m_EventVal.SetThrottle(ferryMission.FerryThrottle_Ship.Value);
							}
							else
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
							}
						}
					}
					else
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				if (m_EventVal.AI.MustSlowDownToAllowGroupFormUp())
				{
					float num4 = float.MaxValue;
					foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
					{
						if (value.IsGroupLead() || value.Navigator.SprintDrift || value.Navigator.HaveReachedFormationStation() || value.DesiredSpeed <= 0f)
						{
							continue;
						}
						if (value.Kinematics.HasAdjustedSpeedForCavitation && !value.IsGroupLead())
						{
							if ((double)value.DesiredSpeed * 0.8 < (double)num4)
							{
								num4 = (float)((double)value.DesiredSpeed * 0.8);
							}
						}
						else if (value.DesiredSpeed / 2f < num4)
						{
							num4 = value.DesiredSpeed / 2f;
						}
					}
					if (m_EventVal.Navigator.SprintDrift)
					{
						m_EventVal.Navigator.SprintDrift_AverageSpeed = num4;
					}
					else
					{
						m_EventVal.DesiredSpeed = num4;
					}
				}
				else if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
				{
					m_EventVal.DesiredSpeed = m_EventVal.Kinematics.DesiredSpeedOverride.Value;
				}
				else if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.IsGroupLead())
					{
						float num5 = float.MaxValue;
						foreach (ActiveUnit value2 in m_EventVal.GetParentGroup().Units.Values)
						{
							if (value2.Kinematics.HasAdjustedSpeedForCavitation)
							{
								num5 = value2.DesiredSpeed;
								continue;
							}
							if (value2.Navigator.SprintDrift)
							{
								if (!Information.IsNothing(value2.Navigator.SprintDrift_AverageSpeed))
								{
									num5 = value2.Navigator.SprintDrift_AverageSpeed.Value;
								}
								continue;
							}
							float num6 = value2.Kinematics.GetMaximumSpeed(value2.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false);
							if (num6 < num5)
							{
								num5 = num6;
							}
						}
						if (m_EventVal.Navigator.SprintDrift)
						{
							m_EventVal.Navigator.SprintDrift_AverageSpeed = num5;
						}
						else
						{
							m_EventVal.DesiredSpeed = num5;
						}
					}
					else if (m_EventVal.GetParentGroup().Navigator.SprintDrift && !Information.IsNothing(m_EventVal.GetParentGroup().Navigator.SprintDrift_AverageSpeed))
					{
						if (m_EventVal.Navigator.SprintDrift)
						{
							m_EventVal.Navigator.SprintDrift_AverageSpeed = m_EventVal.GetParentGroup().Navigator.SprintDrift_AverageSpeed;
						}
						else
						{
							m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().Navigator.SprintDrift_AverageSpeed.Value;
						}
					}
					else if (m_EventVal.Navigator.SprintDrift)
					{
						m_EventVal.Navigator.SprintDrift_AverageSpeed = m_EventVal.GetParentGroup().DesiredSpeed;
					}
					else
					{
						m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().DesiredSpeed;
					}
				}
				if (m_EventVal.IsOnActiveMiningMission)
				{
					ReflectOrder(float_0);
				}
				if (m_EventVal.Navigator.SprintDrift)
				{
					m_EventVal.Navigator.PerformSprintDrift(float_0);
				}
				else
				{
					m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
				}
				if (m_EventVal.IsOnActiveMineClearingMission && m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse)
				{
					PrepareOrder(float_0);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				if (PrimaryTarget == null)
				{
					break;
				}
				if (m_EventVal.IsGroupMember())
				{
					if (m_EventVal.IsGroupLead())
					{
						Contact_Base.ContactType type2 = PrimaryTarget.Type;
						if ((int)type2 > 1 && type2 != Contact_Base.ContactType.Orbital)
						{
							ManouverTowardsTarget(float_0);
							InsertOrder();
						}
						else
						{
							m_EventVal.Navigator.FollowPlottedCourse(float_0);
						}
					}
					else if (m_EventVal.AssignedMissionOrPackage() == m_EventVal.GetParentGroup().AssignedMissionOrPackage())
					{
						if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							m_EventVal.Navigator.HeadToFormationStation(float_0);
						}
					}
					else
					{
						ManouverTowardsTarget(float_0);
						InsertOrder();
					}
				}
				else
				{
					ManouverTowardsTarget(float_0);
					InsertOrder();
				}
				if (!m_EventVal.IsGroupWingman() && !m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
				{
					float? num = null;
					float num2 = float.MaxValue;
					ActiveUnit.Throttle? throttle = null;
					if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol3 = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (!Information.IsNothing(patrol3.AttackThrottle_Ship))
						{
							num = patrol3.AttackDistance_Ship;
							if (Information.IsNothing(num))
							{
								throttle = patrol3.AttackThrottle_Ship;
							}
							else
							{
								num2 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
								throttle = ((num.HasValue ? new bool?(num2 > num.GetValueOrDefault()) : null).GetValueOrDefault() ? new ActiveUnit.Throttle?(patrol3.TransitThrottle_Ship) : patrol3.AttackThrottle_Ship);
							}
						}
					}
					if (Information.IsNothing(throttle))
					{
						InsertOrder();
					}
					else
					{
						m_EventVal.SetThrottle(throttle.Value);
					}
				}
				if (m_EventVal.AI.MustSlowDownToAllowGroupFormUp())
				{
					float desiredSpeed = m_EventVal.GetParentGroup().Kinematics.GroupMaxSpeedForThisThrottleSetting(m_EventVal.ThrottleSetting);
					m_EventVal.DesiredSpeed = desiredSpeed;
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnPatrol:
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
					if (Information.IsNothing(patrol))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
						break;
					}
					if (m_EventVal.IsGroupMember())
					{
						if (m_EventVal.IsGroupLead())
						{
							if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
							{
								if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_30nm_Buffered, ref patrol.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
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
						else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							m_EventVal.Navigator.HeadToFormationStation(float_0);
						}
					}
					else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_30nm_Buffered, ref patrol.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
						{
							m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
						}
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
					}
					if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
					{
						if (m_EventVal.Navigator.DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
						{
							if (!Information.IsNothing(patrol.StationThrottle_Ship))
							{
								m_EventVal.SetThrottle(patrol.StationThrottle_Ship);
							}
						}
						else if (!Information.IsNothing(patrol.TransitThrottle_Ship))
						{
							m_EventVal.SetThrottle(patrol.TransitThrottle_Ship);
						}
					}
					if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
					{
						GlobalVariables.PatrolType type = ((Patrol)m_EventVal.AssignedMissionOrPackage()).Type;
						if (type == GlobalVariables.PatrolType.ASW || type == GlobalVariables.PatrolType.SeaControl)
						{
							Patrol patrol2 = (Patrol)m_EventVal.AssignedMissionOrPackage();
							if (m_EventVal.Navigator.DisableDic(ref patrol2.PatrolArea, ref patrol2.PatrolArea_2nm_Buffered, ref patrol2.PatrolArea_2nm_ChangeCheck, 2, bool_1: false, bool_2: false) && (!m_EventVal.IsGroupMember() || m_EventVal.IsGroupLead() || m_EventVal.GetParentGroup().GroupLead == null || !m_EventVal.GetParentGroup().GroupLead.IsBoat || !((IBoat)m_EventVal.GetParentGroup().GroupLead).IsCavitating()))
							{
								m_EventVal.Kinematics.AdjustSpeedForCavitation();
							}
						}
					}
					if (m_EventVal.Navigator.SprintDrift)
					{
						m_EventVal.Navigator.PerformSprintDrift(float_0);
					}
					break;
				}
				goto default;
			default:
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnSupportMission)
				{
					if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
					{
						if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
						{
							activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						else
						{
							if (!m_EventVal.IsGroupMember())
							{
								m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
								break;
							}
							if (m_EventVal.IsGroupLead())
							{
								m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
								break;
							}
							if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
							{
								m_EventVal.Navigator.HeadToFormationStation(float_0);
								break;
							}
						}
					}
				}
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnFerryMission)
				{
					if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
					{
						FerryMission ferryMission2 = (FerryMission)m_EventVal.AssignedMissionOrPackage();
						if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && ferryMission2.FerryThrottle_Ship.HasValue)
						{
							_ = ferryMission2.FerryThrottle_Ship.Value;
						}
						if (m_EventVal.IsGroupWingman())
						{
							m_EventVal.Navigator.HeadToFormationStation(float_0);
						}
						else if (Information.IsNothing(m_EventVal.DockingOps.ActualDestinationHost))
						{
							string text = "";
							if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
							{
								text = " (" + m_EventVal.UnitClass + ")";
							}
							m_EventVal.ParentScen.AddMessage("舰船：" + m_EventVal.Name + text + "被分配到转场任务但它不能停靠在目的地。取消分配船只并返回最近的基地。", m_EventVal.Name + " 无法停靠到目标；取消转场", LoggedMessage.MessageType.DockingOps, 0, null, m_EventVal.GetUnitSide());
							ActiveUnit eventVal = m_EventVal;
							Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
							eventVal.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
							m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
						}
						else
						{
							ReturnToBase(float_0);
						}
					}
				}
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.Tasked)
				{
					if (IsEscort)
					{
						HeadToNearestEscortSubject();
						break;
					}
					if (m_EventVal.IsOnActiveMiningMission)
					{
						ReflectOrder(float_0);
						break;
					}
					if (m_EventVal.IsOnActiveCargoMission)
					{
						TestOrder(float_0);
						break;
					}
					if (m_EventVal.IsOnActiveMineClearingMission)
					{
						PrepareOrder(float_0);
						break;
					}
					if (Information.IsNothing(PrimaryTarget) && !m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
					}
				}
				if (m_EventVal.IsGroupMember())
				{
					if (!m_EventVal.IsGroupLead() && !Information.IsNothing(m_EventVal.GetParentGroup().GroupLead) && m_EventVal.GetParentGroup().GroupLead.DockingOps.UNREP_Destination == m_EventVal)
					{
						switch (m_EventVal.GetParentGroup().GroupLead.Status)
						{
						default:
							if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
							{
								m_EventVal.Navigator.HeadToFormationStation(float_0);
							}
							break;
						case ActiveUnit._ActiveUnitStatus.Refuelling:
							m_EventVal.SetDesiredHeading(m_EventVal.GetParentGroup().GroupLead.DesiredTurnRate, m_EventVal.GetParentGroup().GroupLead.DesiredHeading);
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
							break;
						case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
							m_EventVal.SetDesiredHeading(m_EventVal.GetParentGroup().GroupLead.DesiredTurnRate, Module_Unit.BearingToUnit_True(m_EventVal, m_EventVal.GetParentGroup().GroupLead));
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
							break;
						}
					}
					else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
					{
						m_EventVal.Navigator.HeadToFormationStation(float_0);
					}
				}
				else if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					byte? b = (byte?)m_EventVal.Doctrine.GetAutoEvade(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					bool? flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() != 0) : null);
					if ((Information.IsNothing(PrimaryThreat) ? new bool?(false) : flag4).GetValueOrDefault())
					{
						ManouverAgainstPrimaryThreat(float_0);
					}
					else
					{
						m_EventVal.DesiredSpeed = 0f;
					}
				}
				break;
			case ActiveUnit._ActiveUnitStatus.RTB:
			case ActiveUnit._ActiveUnitStatus.RTB_Manual:
			case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
			case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
				switch (m_EventVal.DockingOps.Condition)
				{
				case ActiveUnit_DockingOps._DockingOpsCondition.RTB:
					if (m_EventVal.IsGroupMember())
					{
						m_EventVal.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
					}
					ReturnToBase(float_0);
					break;
				case ActiveUnit_DockingOps._DockingOpsCondition.Underway:
					m_EventVal.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
					ReturnToBase(float_0);
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100780", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PrepareOrder(float float_0)
	{
		float num = 1f;
		try
		{
			MineClearingMission mineClearingMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
			bool flag;
			if (flag = m_EventVal.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_2nm_Buffered, ref mineClearingMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
			{
				bool flag2 = true;
				foreach (Sensor mineCountermeasure in m_EventVal.MineCountermeasures)
				{
					if (mineCountermeasure.IsActive)
					{
						flag2 = false;
						break;
					}
				}
				float num2 = 1f;
				MineClearingMission Local_myMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
				List<ReferencePoint> Local_MissionArea = Local_myMission.Area;
				TList<UnguidedWeapon> Local_LegitTargets = new TList<UnguidedWeapon>();
				ObservableDictionary<string, UnguidedWeapon> Local_WeaponsDic = new ObservableDictionary<string, UnguidedWeapon>();
				int num3 = m_EventVal.ParentScen.Mines.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					if (i < m_EventVal.ParentScen.Mines.Count)
					{
						num = 1.1f;
						Local_WeaponsDic.Add(m_EventVal.ParentScen.Mines[i].ObjectID, m_EventVal.ParentScen.Mines[i]);
					}
				}
				num = 1.2f;
				if (m_EventVal.HasMineCountermeasures() || m_EventVal.HasMineCounterWeapons())
				{
					try
					{
						Parallel.ForEach(m_EventVal.GetUnitSide().Contacts_NonAU, delegate(string theUW_ObjectID)
						{
							if (theUW_ObjectID != null)
							{
								UnguidedWeapon value = null;
								Local_WeaponsDic.TryGetValue(theUW_ObjectID, ref value);
								if (!Information.IsNothing(value) && value.IsMine)
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
							}
						});
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				TList<UnguidedWeapon> tList = new TList<UnguidedWeapon>();
				UnguidedWeapon unguidedWeapon = null;
				float num4 = 0f;
				num = 2f;
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = Local_LegitTargets.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						UnguidedWeapon unguidedWeapon2 = (UnguidedWeapon)enumerator2.Current;
						if (unguidedWeapon2 == null)
						{
							continue;
						}
						float num5 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon2);
						if (unguidedWeapon2 != null && unguidedWeapon2._CandidateProxy == null)
						{
							if (unguidedWeapon == null)
							{
								unguidedWeapon = unguidedWeapon2;
								num4 = num5;
							}
							else if (num5 > num4)
							{
								unguidedWeapon = unguidedWeapon2;
								num4 = num5;
							}
						}
						if (num5 <= num2)
						{
							if ((double)num5 * 1852.0 < 300.0)
							{
								continue;
							}
							if (unguidedWeapon2._CandidateProxy == null)
							{
								tList.Add(unguidedWeapon2);
								continue;
							}
							if (!m_EventVal.ParentScen.ActiveUnits.ContainsKey(unguidedWeapon2._CandidateProxy.ObjectID))
							{
								unguidedWeapon2._CandidateProxy = null;
							}
							if (m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon2._CandidateProxy.ObjectID) && !m_EventVal.ParentScen.MineAllocation.Contains(new KeyValuePair<string, UnguidedWeapon>(unguidedWeapon2._CandidateProxy.ObjectID, unguidedWeapon2)))
							{
								unguidedWeapon2._CandidateProxy = null;
							}
							if (unguidedWeapon2._CandidateProxy != null && !unguidedWeapon2._CandidateProxy.Equals(m_EventVal))
							{
								if (!unguidedWeapon2._CandidateProxy.IsWeapon)
								{
									if (m_EventVal.GetUnitSide().Units.Contains(unguidedWeapon2._CandidateProxy))
									{
										if (unguidedWeapon2._CandidateProxy.AssignedMissionOrPackage() != null && unguidedWeapon2._CandidateProxy.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
										{
											if (num5 < num2 / 2f && num5 < Module_Unit.RangeToUnit_Horiz(unguidedWeapon2._CandidateProxy, unguidedWeapon2) && m_EventVal.GetCanSweepMine(unguidedWeapon2) && unguidedWeapon2._CandidateProxy != null)
											{
												m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon2._CandidateProxy.ObjectID);
												if (unguidedWeapon2._CandidateProxy.Navigator.HasPlottedCourse() && unguidedWeapon2._CandidateProxy.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
												{
													unguidedWeapon2._CandidateProxy.Navigator.RemoveWaypoint_Soft(unguidedWeapon2._CandidateProxy.Navigator.PlottedCourse[0], bool_1: false);
												}
												else if (unguidedWeapon2._CandidateProxy.Navigator.PlottedCourse.Count() <= 1)
												{
													unguidedWeapon2._CandidateProxy.Navigator.ClearPlottedCourse();
													unguidedWeapon2._CandidateProxy.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
												}
												unguidedWeapon2._CandidateProxy = null;
											}
										}
										else
										{
											unguidedWeapon2._CandidateProxy = null;
										}
									}
									else
									{
										unguidedWeapon2._CandidateProxy = null;
									}
								}
							}
							else if (unguidedWeapon2._CandidateProxy != null && unguidedWeapon2._CandidateProxy.Equals(m_EventVal) && m_EventVal.GetCanSweepMine(unguidedWeapon2))
							{
								tList.Add(unguidedWeapon2);
								if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
								{
									m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon2);
								}
							}
							else if (unguidedWeapon2._CandidateProxy != null)
							{
								m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon2._CandidateProxy.ObjectID);
								if (unguidedWeapon2._CandidateProxy.Navigator.HasPlottedCourse() && unguidedWeapon2._CandidateProxy.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
								{
									unguidedWeapon2._CandidateProxy.Navigator.RemoveWaypoint_Soft(unguidedWeapon2._CandidateProxy.Navigator.PlottedCourse[0], bool_1: false);
								}
								else if (unguidedWeapon2._CandidateProxy.Navigator.PlottedCourse.Count() <= 1)
								{
									unguidedWeapon2._CandidateProxy.Navigator.ClearPlottedCourse();
									unguidedWeapon2._CandidateProxy.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
								}
								unguidedWeapon2._CandidateProxy = null;
							}
							if (unguidedWeapon2._CandidateProxy == null)
							{
								tList.Add(unguidedWeapon2);
							}
						}
						else if (unguidedWeapon2._CandidateProxy != null && Operators.CompareString(unguidedWeapon2._CandidateProxy.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
						{
							unguidedWeapon2._CandidateProxy = null;
							m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
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
				try
				{
					UnguidedWeapon unguidedWeapon3 = null;
					bool flag3 = false;
					num = 3f;
					int num6 = m_EventVal.ParentScen.MineAllocation.Count - 1;
					for (int j = 0; j <= num6; j++)
					{
						if (j < m_EventVal.ParentScen.MineAllocation.Count)
						{
							num = 3.2f;
							unguidedWeapon3 = m_EventVal.ParentScen.MineAllocation.Values.ElementAtOrDefault(j);
							if (unguidedWeapon3 != null && unguidedWeapon3._CandidateProxy != null && Operators.CompareString(unguidedWeapon3._CandidateProxy.ObjectID, m_EventVal.ObjectID, TextCompare: false) != 0 && ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon3._CandidateProxy) * 1852.0 < 1500.0 || !((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon3) * 1852.0 >= 1500.0)))
							{
								flag3 = true;
								break;
							}
						}
					}
					num = 3.3f;
					if (flag3)
					{
						if (m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref unguidedWeapon3))
						{
							if (unguidedWeapon3 != null)
							{
								unguidedWeapon3._CandidateProxy = null;
								m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
							}
							if (m_EventVal.Navigator.HasNonPathfindPlottedCourse() && m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse.Count() > 1 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
							{
								m_EventVal.Navigator.RemoveWaypoint_Soft(m_EventVal.Navigator.PlottedCourse[0], bool_1: true);
							}
						}
						foreach (Sensor mineCountermeasure2 in m_EventVal.MineCountermeasures)
						{
							if (mineCountermeasure2.IsActive)
							{
								mineCountermeasure2.TimeToNextScan = 360;
							}
						}
						tList.Clear();
					}
					UnguidedWeapon unguidedWeapon4 = null;
					num = 4f;
					if (tList.Count > 0 && (m_EventVal.HasMineCountermeasures() || m_EventVal.HasMineCounterWeapons()))
					{
						while (tList.Count > 0)
						{
							unguidedWeapon4 = (from unguidedWeapon_0 in tList.ToList()
								where unguidedWeapon_0 != null && m_EventVal.GetCanSweepMine(unguidedWeapon_0)
								orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0)
								select unguidedWeapon_0).ElementAtOrDefault(0);
							if (unguidedWeapon4 == null || unguidedWeapon4._CandidateProxy == null || unguidedWeapon4._CandidateProxy.Equals(m_EventVal))
							{
								break;
							}
							if (unguidedWeapon4.GetCurrentAltitude() < -5f)
							{
								tList.Remove(unguidedWeapon4);
							}
							else
							{
								tList.Remove(unguidedWeapon4);
							}
						}
					}
					else
					{
						m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
					}
					if (flag3)
					{
						unguidedWeapon4 = null;
					}
					if (unguidedWeapon4 != null && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
					{
						unguidedWeapon4 = null;
					}
					bool flag4 = false;
					if (m_EventVal.Weaponry != null && tList.Count > 0 && m_EventVal.HasMineCounterWeapons())
					{
						float num7 = 500f;
						if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
						{
							num7 = 1000f;
						}
						if ((unguidedWeapon4 == null) & (tList.Count > 0))
						{
							UnguidedWeapon unguidedWeapon5 = (from theMine in tList.ToList()
								where theMine != null
								select theMine into unguidedWeapon_0
								orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0)
								select unguidedWeapon_0).ElementAtOrDefault(0);
							if (unguidedWeapon5 != null && (double)Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon5) * 1852.0 > (double)num7 && (flag2 || unguidedWeapon5.Type == Weapon._WeaponType.BottomMine || unguidedWeapon5.Type == Weapon._WeaponType.RisingMine))
							{
								foreach (Mount mount in m_EventVal.Mounts)
								{
									if (mount.TimeToFire != 0f)
									{
										continue;
									}
									foreach (WeaponRec mountWeapon in mount.MountWeapons)
									{
										WeaponRec weaponRec_ = mountWeapon;
										if (weaponRec_.TimeToFire != 0f || weaponRec_.CurrentLoad < 1)
										{
											continue;
										}
										Weapon referenceWeapon = weaponRec_.GetReferenceWeapon(m_EventVal.ParentScen);
										if (referenceWeapon.Type != Weapon._WeaponType.Torpedo || !referenceWeapon.ValidTargets.Mine || unguidedWeapon5._CandidateProxy != null)
										{
											continue;
										}
										AimpointContact aimpointContact = new AimpointContact(unguidedWeapon5.GetLatitude(), unguidedWeapon5.GetLongitude());
										aimpointContact.SetCurrentAltitude(bool_0: false, unguidedWeapon5.GetCurrentAltitude());
										AimpointContact contact_ = aimpointContact;
										if (Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon5) >= referenceWeapon.MaxSubsurfaceRange / 2f)
										{
											continue;
										}
										ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
										int int_ = 1;
										WeaponSalvo weaponSalvo_ = null;
										List<Module_Unit.Unit> list = weaponry.ResetConsumer(float_0, ref weaponRec_, contact_, ref int_, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
										if (list.Count > 0)
										{
											Module_Unit.Unit unit = list.First();
											if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(unit.ObjectID))
											{
												m_EventVal.ParentScen.MineAllocation.Add(unit.ObjectID, unguidedWeapon5);
											}
											unguidedWeapon5._CandidateProxy = (ActiveUnit)unit;
											ActiveUnit obj = (ActiveUnit)unit;
											MineClearingMission mission_ = Local_myMission;
											Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
											obj.Set_AssignedMissionOrPackage(mission_, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_);
										}
										flag4 = true;
										break;
									}
									if (!flag4)
									{
										continue;
									}
									break;
								}
							}
						}
						else if (tList.Count > 0)
						{
							foreach (UnguidedWeapon item in tList.OrderBy((UnguidedWeapon unguidedWeapon_0) => Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0)))
							{
								if (item == null)
								{
									continue;
								}
								num7 = 500f;
								if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
								{
									num7 = 1000f;
								}
								if (!((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, item) * 1852.0 >= (double)num7) || (!flag2 && item.Type != Weapon._WeaponType.BottomMine && item.Type != Weapon._WeaponType.RisingMine))
								{
									continue;
								}
								foreach (Mount mount2 in m_EventVal.Mounts)
								{
									if (mount2.TimeToFire != 0f)
									{
										continue;
									}
									foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
									{
										WeaponRec weaponRec_2 = mountWeapon2;
										if (weaponRec_2.TimeToFire != 0f || weaponRec_2.CurrentLoad < 1)
										{
											continue;
										}
										Weapon referenceWeapon2 = weaponRec_2.GetReferenceWeapon(m_EventVal.ParentScen);
										if (referenceWeapon2.Type != Weapon._WeaponType.Torpedo || !referenceWeapon2.ValidTargets.Mine || item._CandidateProxy != null)
										{
											continue;
										}
										AimpointContact aimpointContact2 = new AimpointContact(item.GetLatitude(), item.GetLongitude());
										aimpointContact2.SetCurrentAltitude(bool_0: false, item.GetCurrentAltitude());
										AimpointContact contact_2 = aimpointContact2;
										if (Module_Unit.RangeToUnit_Horiz(m_EventVal, item) >= referenceWeapon2.MaxSubsurfaceRange / 2f)
										{
											continue;
										}
										ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
										int int_2 = 1;
										WeaponSalvo weaponSalvo_2 = null;
										List<Module_Unit.Unit> list2 = weaponry2.ResetConsumer(float_0, ref weaponRec_2, contact_2, ref int_2, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_2);
										if (list2.Count > 0)
										{
											Module_Unit.Unit unit2 = list2.First();
											if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(unit2.ObjectID))
											{
												m_EventVal.ParentScen.MineAllocation.Add(unit2.ObjectID, item);
											}
											item._CandidateProxy = (ActiveUnit)unit2;
											ActiveUnit obj2 = (ActiveUnit)unit2;
											Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
											obj2.Set_AssignedMissionOrPackage(Local_myMission, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_2);
										}
										flag4 = true;
										break;
									}
									if (!flag4)
									{
										continue;
									}
									break;
								}
							}
						}
					}
					num = 5f;
					if (unguidedWeapon4 == null)
					{
						if (m_EventVal.IsGroupMember())
						{
							if (m_EventVal.IsGroupLead())
							{
								if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
								{
									if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref Local_myMission.Area, ref Local_myMission.Area_30nm_Buffered, ref Local_myMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
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
							else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
							{
								m_EventVal.Navigator.HeadToFormationStation(float_0);
							}
						}
						else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
						{
							if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref Local_myMission.Area, ref Local_myMission.Area_30nm_Buffered, ref Local_myMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
							{
								m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
							}
							m_EventVal.Navigator.FollowPlottedCourse(float_0);
						}
						else
						{
							m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
						}
					}
					else
					{
						float num8 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon4);
						if (unguidedWeapon4._CandidateProxy == null && m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
						{
							unguidedWeapon3 = null;
							if (m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref unguidedWeapon3))
							{
								unguidedWeapon4 = unguidedWeapon3;
								num8 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon4);
							}
							else
							{
								unguidedWeapon3._CandidateProxy = null;
								m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
								if (m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
								{
									m_EventVal.Navigator.RemoveWaypoint_Soft(m_EventVal.Navigator.PlottedCourse[0], bool_1: true);
								}
							}
						}
						else if (unguidedWeapon4._CandidateProxy != null && unguidedWeapon4._CandidateProxy.Equals(m_EventVal) && m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
						{
							ManouverToSweepMine(unguidedWeapon4, num8, bool_0: true);
						}
						num = 6f;
						if (unguidedWeapon4 != null && unguidedWeapon4._CandidateProxy == null)
						{
							ManouverToSweepMine(unguidedWeapon4, num8, bool_0: true);
							unguidedWeapon4._CandidateProxy = m_EventVal;
							if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
							{
								UnguidedWeapon obj3 = null;
								if (!m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref obj3) || !unguidedWeapon4.Equals(obj3))
								{
									m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
									m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon4);
								}
							}
							else
							{
								m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon4);
							}
							if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
							{
								m_EventVal.Navigator.bool_0 = false;
								if (m_EventVal.Navigator.TimeToNextPathfinderCheck <= 0f && m_EventVal.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
								{
									m_EventVal.Navigator.TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(10, 16);
								}
							}
							m_EventVal.Navigator.FollowPlottedCourse(float_0);
							if (num8 < 3f)
							{
								m_EventVal.DesiredSpeed = num8 + 1f;
							}
						}
						else if (unguidedWeapon4 != null && unguidedWeapon4._CandidateProxy != null && Operators.CompareString(unguidedWeapon4._CandidateProxy.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
						{
							if ((double)num8 > 0.6)
							{
								ManouverToSweepMine(unguidedWeapon4, num8, bool_0: true);
							}
							if (m_EventVal.Navigator.PlottedCourse.Count() <= 0 || m_EventVal.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
							{
								unguidedWeapon4._CandidateProxy = null;
								m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
							}
						}
						else if (Information.IsNothing(m_EventVal.Kinematics.DesiredSpeedOverride))
						{
							m_EventVal.DesiredSpeed = 3f;
							m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 100780", "Nearest mine process");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
					{
						bool flag5 = false;
						float num9 = 9999f;
						foreach (ActiveUnit assignedBoat in m_EventVal.DockingOps.AssignedBoats)
						{
							if (!assignedBoat.IsOperating() || !assignedBoat.IsOnActiveMineClearingMission)
							{
								continue;
							}
							if (assignedBoat.IsRTB)
							{
								if ((float)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false) >= 5f)
								{
									num9 = Math.Min(num9, (float)(0.5 * (double)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false)));
									flag5 = true;
								}
							}
							else if (assignedBoat.IsSubmarine && ((Submarine)assignedBoat).IsTetheredROV)
							{
								assignedBoat.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
								num9 = Math.Min(num9, Math.Max(1f, assignedBoat.DesiredSpeed - 1f));
								flag5 = true;
							}
						}
						if (flag5 && num9 > 0f && num9 < 9999f)
						{
							num9 = (flag ? Math.Min(num9, m_EventVal.Kinematics.GetMaximumSpeed(0f, Local_myMission.StationThrottle_Ship, bool_0: false)) : Math.Min(num9, m_EventVal.Kinematics.GetMaximumSpeed(0f, Local_myMission.TransitThrottle_Ship, bool_0: false)));
							m_EventVal.DesiredSpeed = num9;
						}
						else if (flag)
						{
							m_EventVal.SetThrottle(Local_myMission.StationThrottle_Ship);
						}
						else
						{
							m_EventVal.SetThrottle(Local_myMission.TransitThrottle_Ship);
						}
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 100780", "Speed check");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					ActiveUnit[] array = Misc.ChangeRequest(m_EventVal.GetUnitSide().Units);
					ActiveUnit[] array2 = array;
					foreach (ActiveUnit activeUnit in array2)
					{
						if (activeUnit == null || !activeUnit.IsSubmarine || (((Submarine)activeUnit).Type != Submarine._SubmarineType.ROV && ((Submarine)activeUnit).Type != Submarine._SubmarineType.UUV) || !activeUnit.IsOperating() || activeUnit.DockingOps.GetAssignedHostUnit() != m_EventVal)
						{
							continue;
						}
						ActiveUnit._ActiveUnitFuelState isBingoOrJoker = activeUnit.GetIsBingoOrJoker(null, null);
						if (m_EventVal.IsRTB)
						{
							activeUnit.AI.ReturnToBase(float_0);
						}
						if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker)
						{
							if (activeUnit.IsRTB)
							{
								if ((float)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false) < 5f)
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
									m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, activeUnit));
								}
								else
								{
									m_EventVal.DesiredSpeed = (float)(0.5 * (double)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false));
								}
							}
						}
						else
						{
							if ((float)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false) < 5f)
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
							}
							else
							{
								m_EventVal.DesiredSpeed = (float)(0.5 * (double)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false));
							}
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, activeUnit));
						}
					}
					return;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 100780", "Rov check");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (m_EventVal.IsGroupMember())
			{
				if (m_EventVal.IsGroupLead())
				{
					if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_30nm_Buffered, ref mineClearingMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
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
				else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
				{
					m_EventVal.Navigator.HeadToFormationStation(float_0);
				}
			}
			else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_30nm_Buffered, ref mineClearingMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
				{
					m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
				}
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
			}
			else
			{
				m_EventVal.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 100780", "Full sub " + Conversions.ToString(num));
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_ = ((MineClearingMission)m_EventVal.AssignedMissionOrPackage()).Area;
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectOrder(float float_0)
	{
		MiningMission miningMission = (MiningMission)m_EventVal.AssignedMissionOrPackage();
		if (m_EventVal.Navigator.HasNonPathfindPlottedCourse() && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.ManualPlottedCourseWaypoint)
		{
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
				{
					m_EventVal.SetThrottle(miningMission.StationThrottle_Ship);
				}
				else
				{
					m_EventVal.SetThrottle(miningMission.TransitThrottle_Ship);
				}
			}
			return;
		}
		if (m_EventVal.IsGroupMember())
		{
			if (m_EventVal.IsGroupLead())
			{
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					if (!m_EventVal.GetParentGroup().Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
					{
						if (m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
						{
							m_EventVal.Navigator.FollowPlottedCourse(float_0);
						}
						else
						{
							m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(miningMission.Area);
							if (m_EventVal.AI.MiningInfo != null)
							{
								m_EventVal.AI.MiningInfo = null;
							}
						}
					}
				}
				else
				{
					m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(miningMission.Area);
					if (m_EventVal.AI.MiningInfo != null)
					{
						m_EventVal.AI.MiningInfo = null;
					}
				}
			}
			else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
			}
		}
		else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
		{
			if (!m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
			{
				if (m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					m_EventVal.Navigator.PlotCourseToArea(miningMission.Area);
					if (m_EventVal.AI.MiningInfo != null)
					{
						m_EventVal.AI.MiningInfo = null;
					}
				}
			}
		}
		else
		{
			m_EventVal.Navigator.PlotCourseToArea(miningMission.Area);
			if (m_EventVal.AI.MiningInfo != null)
			{
				m_EventVal.AI.MiningInfo = null;
			}
		}
		if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
		{
			if (m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
			{
				m_EventVal.SetThrottle(miningMission.StationThrottle_Ship);
			}
			else
			{
				m_EventVal.SetThrottle(miningMission.TransitThrottle_Ship);
			}
		}
	}

	private bool VisitOrder(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		return RestartOrder(geopoint_Struct_0, cargoMission_0)?.Any() ?? false;
	}

	private List<Geopoint_Struct> RestartOrder(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		List<Geopoint_Struct> list = new List<Geopoint_Struct>();
		if (cargoMission_0.DestinationUnit == null)
		{
			if ((cargoMission_0.Area_1nm_Buffered == null) ? GeoPoint.IsInsideThisArea(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, cargoMission_0.Area) : GeoPoint.IsInsideThisArea(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, cargoMission_0.Area_1nm_Buffered))
			{
				short num = 0;
				short num2 = -30;
				if (m_EventVal.SubType == 4002)
				{
					num = 50;
					num2 = 0;
				}
				short elevation = Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, bool_0: false, m_EventVal.ParentScen);
				if (elevation < num && elevation > num2)
				{
					int num3 = 1;
					do
					{
						float num4 = 0f;
						do
						{
							Geopoint_Struct item = default(Geopoint_Struct);
							Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct_0.Longitude, geopoint_Struct_0.Latitude, ref item.Longitude, ref item.Latitude, num4, num3);
							if (GeoPoint.IsInsideThisArea(item.Latitude, item.Longitude, cargoMission_0.Area))
							{
								short elevation2 = Terrain.GetElevation(item.Latitude, item.Longitude, bool_0: false, m_EventVal.ParentScen);
								if (elevation2 > 0 && elevation2 < 50)
								{
									list.Add(item);
								}
							}
							num4 += 0.1f;
						}
						while (num4 <= 2f);
						num3++;
					}
					while (num3 <= 360);
					return list;
				}
				return null;
			}
			return null;
		}
		Geopoint_Struct item2 = new Geopoint_Struct(cargoMission_0.DestinationUnit.GetLongitude(), cargoMission_0.DestinationUnit.GetLatitude());
		list.Add(item2);
		return list;
	}

	private void TestOrder(float float_0)
	{
		CargoMission cargoMission = (CargoMission)m_EventVal.AssignedMissionOrPackage();
		bool flag = true;
		if (m_EventVal.OnboardCargo.Count() == 0)
		{
			if (cargoMission.RTBUponCompletion)
			{
				if (!m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: true, bool_3: true))
				{
					if (m_EventVal.Navigator.HasPlottedCourse())
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
						return;
					}
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					m_EventVal.DesiredSpeed = 0f;
					m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") is unable to return to base during cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.DockingOps, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
			}
			else
			{
				ActiveUnit eventVal = m_EventVal;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				eventVal.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
				m_EventVal.AddMessage(m_EventVal.Name + " (" + m_EventVal.UnitClass + ") has completed cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", m_EventVal.Name + " has completed its cargo mission", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
			}
			return;
		}
		if (cargoMission.Type == CargoMission.CargoMissionType.Transfer)
		{
			if (m_EventVal.IsGroupWingman())
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
				return;
			}
			if (m_EventVal.DockingOps.ActualDestinationHost == null)
			{
				m_EventVal.ParentScen.AddMessage("单元" + m_EventVal.Name + " is assigned to a cargo mission but cannot dock at current destination. Unassigning unit and attempting to returning to base.", m_EventVal.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.DockingOps, 0, null, m_EventVal.GetUnitSide(), new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				ActiveUnit eventVal2 = m_EventVal;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
				eventVal2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
				m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
			}
			else
			{
				ReturnToBase(float_0);
			}
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && flag)
			{
				m_EventVal.SetThrottle(cargoMission.TransitThrottle_Ship);
			}
			return;
		}
		if (m_EventVal.Navigator.DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false) && m_EventVal.DockingOps.RegisterClient())
		{
			if ((Module_Unit.ResetTokenizer(m_EventVal) || Module_Unit.SortTokenizer(m_EventVal, float_0)) & VisitOrder(new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()), cargoMission))
			{
				m_EventVal.DockingOps.SettleForCargoTransfer();
				return;
			}
			if (VisitOrder(new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()), cargoMission))
			{
				m_EventVal.DockingOps.SettleForCargoTransfer();
				return;
			}
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			int num = 0;
			Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
			List<Geopoint_Struct> list = null;
			short num2 = 0;
			short num3 = -20;
			if (m_EventVal.SubType == 4002)
			{
				num2 = 50;
				num3 = 0;
			}
			int int_ = 0;
			while (true)
			{
				num++;
				geopoint_Struct = Math2.RandomPointWithinThisArea(cargoMission.Area);
				if (num > 1000)
				{
					break;
				}
				short elevation = Terrain.GetElevation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, bool_0: false, m_EventVal.ParentScen);
				if (elevation < 0)
				{
					continue;
				}
				GeoPoint geoPoint_ = new GeoPoint();
				if (m_EventVal.Navigator.PathLineIsInterrupted(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), geopoint_Struct.Latitude, geopoint_Struct.Longitude, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: false, Pathfinding.visitorConsumer.DegreeInterval_Finegrained, ref int_, ref geoPoint_))
				{
					if ((int_ & 3) == 0)
					{
						geopoint_Struct_.Latitude = geoPoint_.Latitude;
						geopoint_Struct_.Longitude = geoPoint_.Longitude;
						list = RestartOrder(geopoint_Struct_, cargoMission);
					}
				}
				else if (elevation >= num3 && elevation < num2)
				{
					list = RestartOrder(geopoint_Struct, cargoMission);
				}
				if (list == null || !list.Any())
				{
					continue;
				}
				geopoint_Struct_ = (from geopoint_Struct_0 in list
					orderby Math2.CancelClass(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude()), Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, bool_0: false, m_EventVal.ParentScen)
					select geopoint_Struct_0).First();
				m_EventVal.Navigator.ClearPlottedCourse();
				m_EventVal.Navigator.AddWaypoint(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), geopoint_Struct_.Latitude, geopoint_Struct_.Longitude));
				return;
			}
			m_EventVal.AddMessage(m_EventVal.Name + "无法在参考点定义的货物着陆区域内选择合适的点", m_EventVal.Name + " 无法拾取点", LoggedMessage.MessageType.DockingOps, 1, bool_0: true, geopoint_Struct);
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
					m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(cargoMission.Area);
				}
			}
			else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
				flag = false;
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
		else if (m_EventVal.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo)
		{
			m_EventVal.Navigator.PlotCourseToArea(cargoMission.Area, bool_1: false, Waypoint.WaypointType.DropOffPoint);
		}
		if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && flag)
		{
			if (m_EventVal.Navigator.DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
			{
				m_EventVal.SetThrottle(cargoMission.StationThrottle_Ship);
			}
			else
			{
				m_EventVal.SetThrottle(cargoMission.TransitThrottle_Ship);
			}
		}
	}

	public override void ManouverTowardsTarget(float float_0)
	{
		bool flag = false;
		if (IsClearedToEngageThisTarget(PrimaryTarget))
		{
			byte? b = (byte?)m_EventVal.Doctrine.GetMaintainStandoff(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				flag = StopOrder(float_0);
			}
		}
		bool flag2 = false;
		if (!flag)
		{
			Weapon weapon_ = null;
			if (!Information.IsNothing(PrimaryTarget))
			{
				weapon_ = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
			}
			if (!Information.IsNothing(weapon_) && IsClearedToEngageThisTarget(PrimaryTarget) && Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= weapon_.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, m_EventVal.Doctrine, bool_1: false))
			{
				Contact primaryTarget = PrimaryTarget;
				Tuple<Mount, float, bool> tuple_ = null;
				TurnToUnmaskPrimaryWeapon(ref weapon_, primaryTarget, ref tuple_);
				flag2 = true;
			}
		}
		if (!flag2 && !flag)
		{
			base.ManouverTowardsTarget(float_0);
		}
		if (PrimaryTarget.Type != Contact_Base.ContactType.Submarine || Information.IsNothing(PrimaryTarget.UncertaintyArea))
		{
			return;
		}
		if (m_EventVal.Weaponry.HaveSuitableWeaponForAmbigousTarget(PrimaryTarget, bool_1: false))
		{
			if (m_EventVal.Navigator.HasPlottedCourse())
			{
				byte? b2 = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
			}
		}
		else
		{
			m_EventVal.Navigator.PlotLocalizationCourse();
			m_EventVal.Navigator.FollowPlottedCourse(float_0);
		}
	}

	internal bool StopOrder(float float_0)
	{
		try
		{
			_BroadcasterFacade = false;
			if (PrimaryTarget == null)
			{
				return false;
			}
			if (PrimaryTarget.Type != 0 && PrimaryTarget.Type != Contact_Base.ContactType.Missile)
			{
				Doctrine doctrine = m_EventVal.Doctrine;
				Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, doctrine);
				if (Information.IsNothing(weapon))
				{
					return false;
				}
				float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, doctrine, bool_1: false);
				float? num = PrimaryTarget.MaxPotentialWeaponRange_ASuW_Naval();
				float num2 = (num.HasValue ? num.Value : 0f);
				if (num2 < maxRangeForThisTarget)
				{
					float num3 = num2 + (maxRangeForThisTarget - num2) / 4f;
					Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, num3, Math2.PublishClass(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), m_EventVal.GetLatitude(), m_EventVal.GetLongitude()));
					if (Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()) > num3)
					{
						byte? b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
						bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
						if (((!flag) ?? flag).GetValueOrDefault())
						{
							return true;
						}
					}
					if (Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), geopoint_Struct.Latitude, geopoint_Struct.Longitude) <= 1f)
					{
						m_EventVal.DesiredSpeed = 0f;
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
						ActiveUnit_Navigator navigator = m_EventVal.Navigator;
						Waypoint[] gparam_ = navigator.PlottedCourse;
						ArrayExtensions.Clear(ref gparam_);
						navigator.PlottedCourse = gparam_;
						_BroadcasterFacade = true;
					}
					else
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), geopoint_Struct.Latitude, geopoint_Struct.Longitude));
					}
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
			exception_?.Data.Add("Error at 100781", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[CompilerGenerated]
	private bool CancelOrder(UnguidedWeapon unguidedWeapon_0)
	{
		if (unguidedWeapon_0 != null)
		{
			return m_EventVal.GetCanSweepMine(unguidedWeapon_0);
		}
		return false;
	}

	[CompilerGenerated]
	private double VerifyOrder(UnguidedWeapon unguidedWeapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0);
	}

	[CompilerGenerated]
	private double ListOrder(UnguidedWeapon unguidedWeapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0);
	}

	[CompilerGenerated]
	private double ResolveOrder(UnguidedWeapon unguidedWeapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0);
	}

	[CompilerGenerated]
	private double PostOrder(Geopoint_Struct geopoint_Struct_0)
	{
		return Math2.CancelClass(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude());
	}

	[CompilerGenerated]
	private short RunOrder(Geopoint_Struct geopoint_Struct_0)
	{
		return Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, bool_0: false, m_EventVal.ParentScen);
	}
}
