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

public class Weapon_AI : ActiveUnit_AI
{
	public enum _SnakeDirection : byte
	{
		Left,
		Right
	}

	protected _SnakeDirection? SnakeDirection;

	private bool composerReader;

	private float modelReader;

	private float _AdvisorReader;

	private Weapon customerReader;

	public Geopoint_Struct InterceptPointHistory;

	public bool TerminalDive
	{
		get
		{
			return composerReader;
		}
		set
		{
			composerReader = value;
		}
	}

	public override Contact PrimaryTarget
	{
		get
		{
			return _PrimaryTarget;
		}
		set
		{
			try
			{
				Contact primaryTarget = _PrimaryTarget;
				if (value != _PrimaryTarget)
				{
					if (!Information.IsNothing(_PrimaryTarget) && value == null)
					{
						_LastKnownTargetLocation = new GeoPoint(_PrimaryTarget.GetLongitude(), _PrimaryTarget.GetLatitude(), _PrimaryTarget.GetCurrentAltitude());
					}
					if (value == null)
					{
						if (!Information.IsNothing(_PrimaryTarget) && _PrimaryTarget.IsAir_Missile_Orbital_Contact && _PrimaryTarget.AltitudeIsKnown)
						{
							m_EventVal.DesiredAltitude = _PrimaryTarget.GetCurrentAltitude();
						}
					}
					else if (!IsTargetingThisContact(value) && myWeapon().ValidTargets.Radar)
					{
						m_EventVal.AI.TargetThisContact(value, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						if (!myWeapon().ARM_SpecifiedEmissionIsMandatory)
						{
							Weapon weapon = myWeapon();
							ObservableDictionary<int, EmissionContainer> detectedEmissions = value.DetectedEmissions;
							Side unitSide = myWeapon().GetUnitSide();
							LockRandom lockRandom_ = GameGeneral.LockRandom_0;
							if (weapon.ARM_DetermineEmissionToTrack(detectedEmissions, unitSide, value, bool_0: false, ref lockRandom_))
							{
								myWeapon().ARM_SpecifiedEmissionIsMandatory = true;
							}
						}
					}
				}
				if (myWeapon().IsAAW && myWeapon().HasTerminalGuidance)
				{
					_PrimaryTarget = value;
				}
				else if (value == null && !Information.IsNothing(_PrimaryTarget) && _PrimaryTarget.IsGroundContact && !myWeapon().ValidTargets.Radar && myWeapon().Comms_ReadOnly.Count() == 0)
				{
					myWeapon().GoDumb();
				}
				else if (value == null && !Information.IsNothing(_PrimaryTarget) && _PrimaryTarget.IsShipContact && !myWeapon().ValidTargets.Radar && myWeapon().Comms_ReadOnly.Count() == 0)
				{
					if (myWeapon().Guidance == Weapon.WeaponGuidanceType.SemiActive)
					{
						myWeapon().GoDumb();
					}
					else if (myWeapon().CruiseAltitude_AGL == 0f && myWeapon().CruiseAltitude_ASL == 0f && myWeapon().Comms_ReadOnly.Count() == 0)
					{
						myWeapon().GoDumb();
					}
					else
					{
						_PrimaryTarget = value;
					}
				}
				else if (Information.IsNothing(value) && !Information.IsNothing(primaryTarget) && primaryTarget.Type != Contact_Base.ContactType.ActivationPoint && !Information.IsNothing(_PrimaryTarget) && myWeapon().ValidTargets.Radar && myWeapon().Comms_ReadOnly.Count() == 0 && myWeapon().Flags.ARMTargetMemory)
				{
					myWeapon().GoDumb();
				}
				else
				{
					_PrimaryTarget = value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100965", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	protected Weapon myWeapon()
	{
		if (customerReader == null)
		{
			customerReader = (Weapon)m_EventVal;
		}
		return customerReader;
	}

	public static void FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Weapon weapon_0)
	{
		try
		{
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
					try
					{
						switch (xmlNode.Name)
						{
						case "PrimaryThreat":
							weapon_0.AI._PrimaryThreat = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
							break;
						case "SnakeAxis":
							weapon_0.AI.SnakeAxis = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
							break;
						case "PrimaryTarget":
							if (xmlNode.InnerText.Contains("Aimpoint"))
							{
								weapon_0.AI._PrimaryTarget = AimpointContact.FromString(xmlNode.InnerText);
							}
							else if (xmlNode.InnerText.Contains("ActivationPoint"))
							{
								weapon_0.AI._PrimaryTarget = ActivationPointContact.FromString(xmlNode.InnerText);
							}
							else if (xmlNode.ChildNodes.Count > 0 && Operators.CompareString(xmlNode.FirstChild.Name, "Contact", TextCompare: false) == 0)
							{
								Weapon_AI aI = weapon_0.AI;
								XmlNode xmlNode_ = xmlNode.FirstChild;
								aI._PrimaryTarget = Contact.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							}
							else
							{
								weapon_0.AI._PrimaryTarget = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
							}
							if (weapon_0.AI._PrimaryTarget == null && Debugger.IsAttached)
							{
								Debugger.Break();
							}
							break;
						case "VirtualTargetVelocity":
							weapon_0.AI._AdvisorReader = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "Threats":
							if (weapon_0.AI._Threats == null)
							{
								weapon_0.AI._Threats = new List<Contact>();
							}
							try
							{
								enumerator3 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode_3 = (XmlNode)enumerator3.Current;
									Contact contact = Contact.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
									if (contact != null)
									{
										weapon_0.AI._Threats.Add(contact);
									}
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
						case "VirtualTargetAltitude":
							weapon_0.AI.modelReader = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "IE":
							weapon_0.AI.IsEscort = true;
							break;
						case "TargetList":
							weapon_0.AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
									TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
									if (targetingEntry.Target != null)
									{
										weapon_0.AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
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
						case "PrimaryTarget_LastKnown_Lat":
							weapon_0.AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(xmlNode.InnerText);
							break;
						case "PrimaryTarget_LastKnown_Lon":
							weapon_0.AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(xmlNode.InnerText);
							break;
						case "PrimaryTargetOverrideExists":
						case "PTOE":
							weapon_0.AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "PrimaryTarget_LastKnown_Alt":
							weapon_0.AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "PrimaryTarget_Type":
							if (Versioned.IsNumeric(xmlNode.InnerText))
							{
								weapon_0.AI._PrimaryTarget_Type = (Contact_Base.ContactType)Conversions.ToByte(xmlNode.InnerText);
							}
							else
							{
								weapon_0.AI._PrimaryTarget_Type = (Contact_Base.ContactType)Enum.Parse(typeof(Contact_Base.ContactType), xmlNode.InnerText, ignoreCase: true);
							}
							break;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200049", exception_.Message);
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
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100964", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			if (PrimaryTarget != null)
			{
				if (PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
				{
					if (hashSet_0.Contains(PrimaryTarget.ObjectID))
					{
						xmlWriter_0.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
					}
					else
					{
						xmlWriter_0.WriteStartElement("PrimaryTarget");
						xmlWriter_0.WriteRaw(PrimaryTarget.ToXML(hashSet_0, m_EventVal.GetUnitSide()));
						xmlWriter_0.WriteEndElement();
					}
				}
				else
				{
					xmlWriter_0.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
				}
			}
			if (!Information.IsNothing(_PrimaryTarget_Type))
			{
				XmlWriter obj = xmlWriter_0;
				int primaryTarget_Type = (int)_PrimaryTarget_Type;
				obj.WriteElementString("PrimaryTarget_Type", primaryTarget_Type.ToString());
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
			if (modelReader != 0f)
			{
				xmlWriter_0.WriteElementString("VirtualTargetAltitude", XmlConvert.ToString(modelReader));
			}
			if (_AdvisorReader != 0f)
			{
				xmlWriter_0.WriteElementString("VirtualTargetVelocity", XmlConvert.ToString(_AdvisorReader));
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
			if (HoldPosition)
			{
				xmlWriter_0.WriteElementString("HPos", HoldPosition.ToString());
			}
			if (_FerryCycleLegIsOutbound)
			{
				xmlWriter_0.WriteElementString("FCLIO", _FerryCycleLegIsOutbound.ToString());
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
				foreach (TargetingEntry value in _TargetList.Values)
				{
					if (value.Target.ActualUnit != null)
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
			exception_?.Data.Add("Error at 100021", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Weapon_AI(Weapon weapon_0)
		: base(weapon_0)
	{
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
	}

	public override void EvaluateThreats()
	{
	}

	internal bool SelectDescriptor(Contact contact_0)
	{
		if (myWeapon().MaxSurfaceRange - m_EventVal.Journey.IncludeSpecification() <= Math2.VerifyClass(myWeapon().GetLatitude(), myWeapon().GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()))
		{
			return false;
		}
		return true;
	}

	public override void DeterminePrimaryTarget(float float_0, bool bool_0, bool bool_1)
	{
		if (!DeterminePrimaryTarget_Enabled || m_EventVal == null || myWeapon().Type == Weapon._WeaponType.Sonobuoy)
		{
			return;
		}
		myWeapon().DetermineGuidance();
		if (myWeapon().Guidance == Weapon.WeaponGuidanceType.Inertial && (m_EventVal.IsTorpedo || myWeapon().IsReEntryVehicle))
		{
			return;
		}
		try
		{
			if (PrimaryTarget != null)
			{
				PrimaryTarget_LastKnown_Lat = PrimaryTarget.GetLatitude();
				PrimaryTarget_LastKnown_Lon = PrimaryTarget.GetLongitude();
				if (PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint && myWeapon().Navigator.HasPlottedCourse())
				{
					PrimaryTarget_LastKnown_Altitude = myWeapon().Navigator.PlottedCourse[0].Altitude;
				}
				else
				{
					PrimaryTarget_LastKnown_Altitude = PrimaryTarget.GetCurrentAltitude();
				}
			}
			if (base.Targets_ReadOnly.Length == 0)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			list.AddRange(base.Targets_ReadOnly);
			if (myWeapon().Is_LOAL_capable)
			{
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					return;
				}
				if (Information.IsNothing(PrimaryTarget))
				{
					IEnumerable<Contact> source = from theC in list
						select (theC) into contact_0
						orderby Module_Unit.RangeToUnit_Horiz_Angular(contact_0, m_EventVal)
						select contact_0;
					if (source.Count() > 0)
					{
						PrimaryTarget = source.ElementAtOrDefault(0);
					}
					return;
				}
				if (myWeapon().ValidTargets.Radar && !myWeapon().Flags.ARMTargetMemory)
				{
					PrimaryTarget = null;
				}
				else
				{
					foreach (Contact item in list)
					{
						if (Information.IsNothing(PrimaryTarget.ActualUnit) || item.ActualUnit == PrimaryTarget.ActualUnit)
						{
							PrimaryTarget = item;
							return;
						}
					}
				}
				if (!myWeapon().HasManInTheLoop && !myWeapon().IsBrilliantWeapon && (Information.IsNothing(PrimaryTarget) || !PrimaryTarget.ActualUnit.IsFixedFacility))
				{
					foreach (Contact item2 in list.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(contact_0, m_EventVal)))
					{
						if (SelectDescriptor(item2))
						{
							PrimaryTarget = item2;
							break;
						}
					}
				}
				if (myWeapon().ValidTargets.Radar && Information.IsNothing(myWeapon().ARM_SpecifiedEMission))
				{
					Weapon weapon = myWeapon();
					ObservableDictionary<int, EmissionContainer> detectedEmissions = PrimaryTarget.DetectedEmissions;
					Side unitSide = m_EventVal.GetUnitSide();
					Contact primaryTarget = PrimaryTarget;
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					weapon.ARM_DetermineEmissionToTrack(detectedEmissions, unitSide, primaryTarget, bool_0: false, ref lockRandom_);
				}
				return;
			}
			switch (myWeapon().Guidance)
			{
			case Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
			{
				if (!Information.IsNothing(myWeapon().DataLinkParent) || list.Count <= 0)
				{
					break;
				}
				if (list.Count == 1)
				{
					PrimaryTarget = list[0];
					break;
				}
				if (!Information.IsNothing(PrimaryTarget))
				{
					foreach (Contact item3 in list)
					{
						if (item3?.ActualUnit != null && PrimaryTarget?.ActualUnit != null && ActiveUnit_Sensory.ContactsAreOfSameActualUnit(item3, PrimaryTarget))
						{
							return;
						}
					}
				}
				IEnumerable<Contact> source3 = list.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0));
				PrimaryTarget = source3.ElementAtOrDefault(0);
				break;
			}
			case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
			{
				if (!m_EventVal.Sensors_ReadOnly()[0].IsActive || list.Count <= 0)
				{
					break;
				}
				if (base.Targets_ReadOnly.Length == 1)
				{
					PrimaryTarget = list[0];
					break;
				}
				if (!Information.IsNothing(PrimaryTarget))
				{
					foreach (Contact item4 in list)
					{
						if (item4?.ActualUnit != null && PrimaryTarget?.ActualUnit != null && ActiveUnit_Sensory.ContactsAreOfSameActualUnit(item4, PrimaryTarget))
						{
							return;
						}
					}
				}
				IEnumerable<Contact> source4 = list.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0));
				PrimaryTarget = source4.ElementAtOrDefault(0);
				break;
			}
			case Weapon.WeaponGuidanceType.Passive:
			{
				if (!Information.IsNothing(PrimaryTarget) && myWeapon().ValidTargets.Radar && !myWeapon().Flags.ARMTargetMemory && list.Count > 1)
				{
					foreach (int key in PrimaryTarget.DetectedEmissions.Keys)
					{
						if (key == myWeapon().ARM_SpecifiedEMission.Key && !(myWeapon().ARM_SpecifiedEMission.Value.Age <= 20f))
						{
							DropTarget(PrimaryTarget);
							break;
						}
					}
				}
				if ((!Information.IsNothing(PrimaryTarget) && (!myWeapon().ValidTargets.Radar || list.Contains(PrimaryTarget))) || (!myWeapon().IsAAW && !myWeapon().ValidTargets.SurfaceVessel && !myWeapon().ValidTargets.Radar))
				{
					break;
				}
				if (myWeapon().ValidTargets.Radar)
				{
					if (!Information.IsNothing(myWeapon().ARM_SpecifiedEMission))
					{
						list = list.Where((Contact contact_0) => contact_0.DetectedEmissions.Keys.Contains(myWeapon().ARM_SpecifiedEMission.Key)).ToList();
					}
					if (list.Count > 0)
					{
						myWeapon().ARM_SpecifiedEMission.Value.Age = 0f;
					}
				}
				if (list.Count <= 0)
				{
					break;
				}
				if (list.Count == 1)
				{
					PrimaryTarget = list[0];
					break;
				}
				IEnumerable<Contact> source2 = list.OrderBy((Contact contact_0) => Module_Unit.BearingToUnit_True(m_EventVal, contact_0));
				PrimaryTarget = source2.ElementAtOrDefault(0);
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100967", "");
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
	}

	protected virtual void CircleSearch(float float_0)
	{
		m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(m_EventVal.DesiredHeading + 10f * float_0));
		if (m_EventVal.Kinematics.CanApplyLoiterThrottle())
		{
			m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
		}
		else
		{
			m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
	}

	protected virtual void SnakeSearch()
	{
		try
		{
			MaxSnakeAngle = 8;
			if (Information.IsNothing(SnakeAxis))
			{
				SnakeAxis = m_EventVal.CurrentHeading;
			}
			if (Information.IsNothing(SnakeDirection))
			{
				SnakeDirection = (_SnakeDirection)GameGeneral.LockRandom_0.Next(0, 1);
			}
			float float_ = Math2.UpdateClass(SnakeAxis.Value - (float)MaxSnakeAngle);
			float float_2 = Math2.UpdateClass(SnakeAxis.Value + (float)MaxSnakeAngle);
			_SnakeDirection? snakeDirection = SnakeDirection;
			byte? b = (byte?)snakeDirection;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, SnakeAxis.Value)) < (float)MaxSnakeAngle)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_);
					return;
				}
				SnakeDirection = _SnakeDirection.Right;
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_2);
				return;
			}
			b = (byte?)snakeDirection;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, SnakeAxis.Value)) < (float)MaxSnakeAngle)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_2);
					return;
				}
				SnakeDirection = _SnakeDirection.Left;
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100968", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DeterminePrimaryThreat()
	{
	}

	public override void ManouverTowardsTarget(float float_0)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			_ = m_EventVal.CurrentHeading;
			float num = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
			if (m_EventVal.CurrentHeading != num)
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()));
				if (!(315f <= relativeBearing) && !(relativeBearing <= 45f) && m_EventVal.CurrentSpeed > PrimaryTarget.CurrentSpeed)
				{
					Manouver_PurePursuit(float_0, 0f, 0f);
					return;
				}
				if (myWeapon().Guidance == Weapon.WeaponGuidanceType.BeamRiding)
				{
					Manouver_PurePursuit(float_0, 0f, 0f);
					return;
				}
				float? nullable_ = m_EventVal.DesiredSpeed;
				bool bool_ = false;
				Manouver_InterceptCourse(float_0, nullable_, ref bool_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100969", "");
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

	protected void SimulateGuidanceUpdatesFromDataLink(bool bool_0)
	{
		try
		{
			if (customerReader.DataLinkParent == null || !customerReader.GuidanceHasDataLink() || PrimaryTarget == null || PrimaryTarget.ActualUnit == null || PrimaryTarget.ActualUnit.IsFixedFacility)
			{
				return;
			}
			if (PrimaryTarget.IsBallisticTarget())
			{
				if (bool_0)
				{
					float float_ = m_EventVal.Kinematics.GetMaximumSpeed(customerReader.Navigator.PlottedCourse[0].Altitude, m_EventVal.MaxPossibleThrottleSetting, bool_0: false);
					customerReader.Navigator.CalculateDescriptor(float_, customerReader.DataLinkParent != null && customerReader.DataLinkParent.IsAircraft && customerReader.IsTorpedo);
				}
			}
			else if (bool_0)
			{
				float float_2 = m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.MaxPossibleThrottleSetting, bool_0: false);
				customerReader.Navigator.CalculateDescriptor(float_2, customerReader.DataLinkParent != null && customerReader.DataLinkParent.IsAircraft && customerReader.IsTorpedo);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 107973", "");
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
		Weapon weapon_ = myWeapon();
		try
		{
			if (weapon_.Type == Weapon._WeaponType.Sonobuoy || !(weapon_.AddDescriptor() <= 0f))
			{
				return;
			}
			if (weapon_.BlindTime <= 0f)
			{
				if (!weapon_._FacadeReader && !ReadClient(ref weapon_))
				{
					if (myWeapon().DataLinkParent != null)
					{
						SimulateGuidanceUpdatesFromDataLink(bool_0);
					}
					if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
						DetermineDesiredAltitude(float_0);
					}
					else
					{
						if (m_EventVal.IsTorpedo && weapon_.Guidance == Weapon.WeaponGuidanceType.Inertial)
						{
							return;
						}
						if (weapon_.IsAAW && weapon_.IsSemiAutonomous && !weapon_.HasGoneAutonomous)
						{
							weapon_.StopReponse(bool_0: true, bool_1: true);
						}
						if (!weapon_.Flags.SearchPattern && weapon_.SearchPatternType == Weapon.WeaponSearchPatternType.None)
						{
							if (weapon_.isLoiterCapable)
							{
								weapon_.Kinematics.Loiter(float_0);
							}
							else
							{
								m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
							}
						}
						else if (!Information.IsNothing(PrimaryTarget) && !Information.IsNothing(PrimaryTarget.ActualUnit) && !PrimaryTarget.ActualUnit.IsFixedFacility)
						{
							if (weapon_.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
							{
								CircleSearch(float_0);
							}
							else if (weapon_.SearchPatternType == Weapon.WeaponSearchPatternType.Snake)
							{
								SnakeSearch();
							}
							else
							{
								m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
							}
						}
						else if (!weapon_.Navigator.HasPlottedCourse() && weapon_.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
						{
							CircleSearch(float_0);
						}
						else if (PrimaryTarget != null && PrimaryTarget.ActualUnit != null && PrimaryTarget.ActualUnit.IsFixedFacility)
						{
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
						}
						else
						{
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
						}
						DetermineDesiredAltitude(float_0);
					}
					return;
				}
				if (weapon_.IsParachuteLoitering)
				{
					weapon_.ReleaseFromLoiterParachute();
				}
				if (PrimaryTarget != null && PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
				{
					PrimaryTarget_LastKnown_Lat = PrimaryTarget.GetLatitude();
					PrimaryTarget_LastKnown_Lon = PrimaryTarget.GetLongitude();
					PrimaryTarget_LastKnown_Altitude = PrimaryTarget.GetCurrentAltitude();
				}
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse() && weapon_.DataLinkParent != null)
				{
					SimulateGuidanceUpdatesFromDataLink(bool_0);
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else if (m_EventVal.Navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					if (PrimaryTarget != null && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
					{
						return;
					}
					if (PrimaryTarget == null)
					{
						if (weapon_.isLoiterCapable)
						{
							weapon_.Kinematics.Loiter(float_0);
						}
						else
						{
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
						}
					}
					else
					{
						switch (weapon_.Guidance)
						{
						default:
							if (PrimaryTarget.ActualUnit == null)
							{
								m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
							}
							else if (weapon_.clientReader)
							{
								m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
							}
							else if (PrimaryTarget.IsBallisticTarget())
							{
								Geopoint_Struct geopoint_Struct = weapon_.Navigator.RemoveDescriptor(PrimaryTarget);
								if (geopoint_Struct.HasZeroCoords)
								{
									m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToPoint_True(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()));
								}
								else
								{
									m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToPoint_True(geopoint_Struct.Latitude, geopoint_Struct.Longitude));
								}
							}
							else
							{
								bool bool_ = true;
								Manouver_InterceptCourse(float_0, null, ref bool_);
							}
							break;
						case Weapon.WeaponGuidanceType.Inertial:
							if (PrimaryTarget != null)
							{
								weapon_.Navigator.AddWaypoint(new Waypoint(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude(), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
							}
							break;
						case Weapon.WeaponGuidanceType.CommandGuided_Datalinked:
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
							break;
						}
					}
				}
				DetermineDesiredAltitude(float_0);
				if (weapon_.SupportsAttitude_Pitch || weapon_.GetCurrentAltitude() == weapon_.CruiseAltitude_ASL || PrimaryTarget == null)
				{
					return;
				}
				Contact_Base.ContactType type = PrimaryTarget.Type;
				if ((int)type <= 1 || type == Contact_Base.ContactType.Orbital || type == Contact_Base.ContactType.Decoy_Air)
				{
					float num = Math.Abs(PrimaryTarget.GetCurrentAltitude() - m_EventVal.GetCurrentAltitude());
					float num2 = ((PrimaryTarget.GetCurrentAltitude() < m_EventVal.GetCurrentAltitude()) ? m_EventVal.Kinematics.DiveRate_Nominal() : m_EventVal.Kinematics.GetClimbRate_Nominal());
					float num3 = num / num2;
					float num4 = Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, m_EventVal.CurrentSpeed, Module_Unit.BearingToUnit_True(m_EventVal, PrimaryTarget));
					float num5 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
					long num6 = ((num4 <= 0f) ? long.MaxValue : ((long)Math.Round(num5 / num4 * 3600f)));
					if ((float)num6 < num3)
					{
						float float_ = (float)((double)num / ((double)num6 + 0.001));
						weapon_.Kinematics.SetClimbRate_Nominal(bool_0: true, float_);
					}
				}
			}
			else
			{
				if (weapon_.Guidance == Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive)
				{
					DetermineDesiredAltitude(float_0);
				}
				if (!TerminalDive)
				{
					TerminalDive = true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100970", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float EstimateAverageSpeedToTarget(Contact contact_0)
	{
		float result = 0f;
		try
		{
			Scenario parentScen = myWeapon().ParentScen;
			int dBID = myWeapon().DBID;
			Weapon activeUnit_ = myWeapon();
			double longitude = myWeapon().GetLongitude();
			double latitude = myWeapon().GetLatitude();
			float currentAltitude = myWeapon().GetCurrentAltitude();
			int int_ = (int)Math.Round(myWeapon().CurrentSpeed);
			double longitude2 = contact_0.GetLongitude();
			double latitude2 = contact_0.GetLatitude();
			float currentHeading = contact_0.CurrentHeading;
			bool headingIsKnown = contact_0.HeadingIsKnown;
			int int_2 = (int)Math.Round(contact_0.CurrentSpeed);
			bool speedIsKnown = contact_0.SpeedIsKnown;
			float currentAltitude2 = contact_0.GetCurrentAltitude();
			bool altitudeIsKnown = contact_0.AltitudeIsKnown;
			float float_ = Module_Unit.RateTokenizer(contact_0, m_EventVal.ParentScen);
			Contact_Base.ContactType type = contact_0.Type;
			string string_ = string.Empty;
			GeoPoint geoPoint_ = null;
			float float_2 = 0f;
			_ = ActiveUnit_Weaponry.TargetIsWithinDLZ(parentScen, dBID, activeUnit_, longitude, latitude, currentAltitude, int_, longitude2, latitude2, currentHeading, headingIsKnown, int_2, speedIsKnown, currentAltitude2, altitudeIsKnown, float_, type, ref geoPoint_, ref string_, bool_4: false, 0f, ActiveUnit.Throttle.Cruise, 0, null, null, ref float_2).Item1;
			if (geoPoint_ == null)
			{
				result = m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.MaxPossibleThrottleSetting, bool_0: false);
				return result;
			}
			result = Module_Unit.RangeToPoint_Horiz(myWeapon(), geoPoint_) / (float_2 / 3600f);
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	protected void CalculateDesiredPitch(GeoPoint geoPoint_0, float float_0)
	{
		if (!myWeapon().SupportsAttitude_Pitch)
		{
			return;
		}
		if (geoPoint_0 == null)
		{
			float num = Math.Abs(myWeapon().DesiredAltitude - myWeapon().GetCurrentAltitude());
			if (m_EventVal.DesiredAltitude <= m_EventVal.GetCurrentAltitude())
			{
				if (num < 2000f)
				{
					m_EventVal.DesiredPitch = num / 2000f * -89f;
				}
				else
				{
					m_EventVal.DesiredPitch = -89f;
				}
			}
			else if (num < 2000f)
			{
				m_EventVal.DesiredPitch = num / 2000f * 89f;
			}
			else
			{
				m_EventVal.DesiredPitch = 89f;
			}
		}
		else
		{
			CalculateDesiredPitch(geoPoint_0.Latitude, geoPoint_0.Longitude, geoPoint_0.Altitude);
		}
	}

	protected void CalculateDesiredPitch_GPStruct(Geopoint_Struct geopoint_Struct_0, float float_0)
	{
		if (!myWeapon().SupportsAttitude_Pitch)
		{
			return;
		}
		if (geopoint_Struct_0.HasZeroCoords)
		{
			float num = Math.Abs(myWeapon().DesiredAltitude - myWeapon().GetCurrentAltitude());
			if (m_EventVal.DesiredAltitude <= m_EventVal.GetCurrentAltitude())
			{
				if (num < 2000f)
				{
					m_EventVal.DesiredPitch = num / 2000f * -89f;
				}
				else
				{
					m_EventVal.DesiredPitch = -89f;
				}
			}
			else if (num < 2000f)
			{
				m_EventVal.DesiredPitch = num / 2000f * 89f;
			}
			else
			{
				m_EventVal.DesiredPitch = 89f;
			}
		}
		else
		{
			CalculateDesiredPitch(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, geopoint_Struct_0.Altitude);
		}
	}

	protected void CalculateDesiredPitch(double double_0, double double_1)
	{
		if (myWeapon().SupportsAttitude_Pitch)
		{
			float num = Module_Unit.RangeToPoint_Horiz(myWeapon(), double_0, double_1);
			double num2 = Math.Atan2(myWeapon().GetCurrentAltitude() - myWeapon().DesiredAltitude, (double)num * 1852.0) * 57.2957795130823;
			if (num2 > 0.0 && myWeapon().GetCurrentAltitude() > myWeapon().DesiredAltitude)
			{
				num2 = 0.0 - num2;
			}
			if (num2 < 0.0 && myWeapon().GetCurrentAltitude() < myWeapon().DesiredAltitude)
			{
				num2 = 0.0 - num2;
			}
			myWeapon().DesiredPitch = (float)num2;
		}
	}

	private void CallDescriptor(float float_0)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		float num = 0f;
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		if (PrimaryTarget.CurrentSpeed == 0f)
		{
			num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
		}
		else if (PrimaryTarget.IsBallisticTarget())
		{
			geopoint_Struct = myWeapon().Navigator.RemoveDescriptor(PrimaryTarget);
		}
		else
		{
			float float_ = (myWeapon().SupportsAttitude_Pitch ? ((float)((double)myWeapon().Kinematics.GetMaximumSpeed() * 0.5)) : ((float)myWeapon().Kinematics.GetMaximumSpeed()));
			geopoint_Struct = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_, PrimaryTarget, null);
			num = (geopoint_Struct.HasZeroCoords ? Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) : Module_Unit.RangeToPoint_Horiz(myWeapon(), geopoint_Struct));
		}
		if (!geopoint_Struct.HasZeroCoords)
		{
			InterceptPointHistory = geopoint_Struct;
		}
		if ((PrimaryTarget.Type == Contact_Base.ContactType.Air || PrimaryTarget.Type == Contact_Base.ContactType.Missile) && !myWeapon().Flags.IlluminateAtLaunch)
		{
			m_EventVal.DesiredAltitude = myWeapon().ImpactAltitude;
			if (geopoint_Struct.HasZeroCoords)
			{
				CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
				return;
			}
			if (PrimaryTarget.IsBallisticTarget())
			{
				m_EventVal.DesiredAltitude = geopoint_Struct.Altitude;
			}
			CalculateDesiredPitch(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct.Altitude);
			return;
		}
		if (myWeapon().IsAAW)
		{
			float num2 = m_EventVal.CurrentSpeed * float_0 / 3600f;
			float num3 = myWeapon().ImpactAltitude - m_EventVal.GetCurrentAltitude();
			if ((PrimaryTarget.IsSubmarine || PrimaryTarget.IsLandContact) && !Information.IsNothing(myWeapon().LaunchPoint) && myWeapon().LaunchPoint.GetAltitude_AGL(m_EventVal.ParentScen) <= 50f && Math.Abs(num3) < num / 4f * 1852f)
			{
				if (!TerminalDive)
				{
					m_EventVal.DesiredAltitude = myWeapon().Kinematics.GetMaximumAltitude();
					if (geopoint_Struct.HasZeroCoords)
					{
						float float_2 = (myWeapon().SupportsAttitude_Pitch ? ((float)((double)myWeapon().Kinematics.GetMaximumSpeed() * 0.5)) : ((float)myWeapon().Kinematics.GetMaximumSpeed()));
						geopoint_Struct = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_2, PrimaryTarget, null);
					}
					CalculateDesiredPitch_GPStruct(geopoint_Struct, float_0);
				}
			}
			else if (myWeapon().SupportsAttitude_Pitch)
			{
				myWeapon().DesiredAltitude = myWeapon().ImpactAltitude;
				if (geopoint_Struct.HasZeroCoords)
				{
					CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
				}
				else
				{
					CalculateDesiredPitch(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct.Altitude);
				}
			}
			else if (num3 < 0f)
			{
				m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num2 * Math.Abs(num3) / num;
			}
			else
			{
				m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num2 * Math.Abs(num3) / num;
			}
			return;
		}
		float num4 = num / m_EventVal.CurrentSpeed * 3600f;
		float num5 = Math.Abs(m_EventVal.GetCurrentAltitude() - myWeapon().ImpactAltitude) / num4;
		float num6 = myWeapon().ImpactAltitude - m_EventVal.GetCurrentAltitude();
		if (myWeapon().SupportsAttitude_Pitch)
		{
			myWeapon().DesiredAltitude = myWeapon().ImpactAltitude;
			if (geopoint_Struct.HasZeroCoords)
			{
				CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
			}
			else
			{
				CalculateDesiredPitch(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct.Altitude);
			}
		}
		else if (num6 < 0f)
		{
			m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num5 * float_0;
			if (myWeapon().IsGuidedWeapon())
			{
				myWeapon().Kinematics.SetClimbRate_Nominal(bool_0: true, num5);
			}
		}
		else
		{
			m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num5;
			if (myWeapon().IsGuidedWeapon())
			{
				myWeapon().Kinematics.SetClimbRate_Nominal(bool_0: true, num5);
			}
		}
	}

	public virtual void DetermineDesiredImpactAltitude()
	{
		try
		{
			float num = 0f;
			if (myWeapon().AI.PrimaryTarget == null)
			{
				num = myWeapon().GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen);
			}
			else
			{
				if (myWeapon().AI.PrimaryTarget.IsAir_Missile_Orbital_Contact)
				{
					myWeapon().ImpactAltitude = PrimaryTarget.GetCurrentAltitude();
					return;
				}
				if (!Information.IsNothing(myWeapon().AI.PrimaryTarget_Type))
				{
					switch (myWeapon().AI.PrimaryTarget_Type)
					{
					case Contact_Base.ContactType.Surface:
						num = ((myWeapon().AI.PrimaryTarget.ActualUnit == null || !myWeapon().AI.PrimaryTarget.ActualUnit.IsShip) ? ((float)myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen)) : myWeapon().AI.PrimaryTarget.GetCurrentAltitude());
						break;
					case Contact_Base.ContactType.Submarine:
						num = Math.Max(myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen), -100);
						break;
					case Contact_Base.ContactType.Aimpoint:
						num = ((!((float)myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen) < 0f)) ? ((float)myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen)) : (myWeapon().IsASW ? ((float)Math.Max(myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen), -100)) : 0f));
						break;
					default:
						num = myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen);
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						num = myWeapon().AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen);
						break;
					}
				}
			}
			if ((myWeapon().Guidance == Weapon.WeaponGuidanceType.Inertial || (!Information.IsNothing(myWeapon().AI.PrimaryTarget) && (myWeapon().AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint || (myWeapon().Warheads.Count() > 0 && myWeapon().Warheads[0].GetIsAirburst(myWeapon(), m_EventVal.AI.PrimaryTarget.ActualUnit))))) && !myWeapon().IsTorpedo && myWeapon().Navigator.HasPlottedCourse())
			{
				myWeapon().ImpactAltitude = m_EventVal.Navigator.PlottedCourse[0].Altitude;
				if (Information.IsNothing(PrimaryTarget))
				{
					switch (myWeapon().Type)
					{
					case Weapon._WeaponType.GuidedWeapon:
					case Weapon._WeaponType.GuidedProjectile:
					case Weapon._WeaponType.BallisticMissile:
					case Weapon._WeaponType.RV:
					case Weapon._WeaponType.HGV:
						if (myWeapon().ImpactAltitude < num)
						{
							myWeapon().ImpactAltitude = num;
						}
						else if (num < 0f)
						{
							myWeapon().ImpactAltitude = 0f;
						}
						break;
					}
				}
				else if (myWeapon().ImpactAltitude < num)
				{
					if (num < 0f)
					{
						myWeapon().ImpactAltitude = myWeapon().GetOptimumBurstHeight_AGL(m_EventVal.AI.PrimaryTarget.ActualUnit);
					}
					else
					{
						myWeapon().ImpactAltitude = num + (float)myWeapon().GetOptimumBurstHeight_AGL(m_EventVal.AI.PrimaryTarget.ActualUnit);
					}
				}
				else if (myWeapon().Warheads.Count() > 0 && myWeapon().Warheads[0].GetIsAirburst(myWeapon(), myWeapon().AI.PrimaryTarget.ActualUnit))
				{
					myWeapon().ImpactAltitude = num + (float)myWeapon().GetOptimumBurstHeight_AGL(m_EventVal.AI.PrimaryTarget.ActualUnit);
				}
				return;
			}
			if (!Information.IsNothing(PrimaryTarget) && num < 0f)
			{
				switch (myWeapon().Type)
				{
				default:
					myWeapon().ImpactAltitude = num;
					break;
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.GuidedProjectile:
				case Weapon._WeaponType.BallisticMissile:
				case Weapon._WeaponType.RV:
				case Weapon._WeaponType.HGV:
					if (myWeapon().ImpactAltitude < num)
					{
						myWeapon().ImpactAltitude = num;
					}
					else if (num < 0f)
					{
						myWeapon().ImpactAltitude = 0f;
					}
					break;
				}
				return;
			}
			switch (myWeapon().Type)
			{
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.GuidedProjectile:
			case Weapon._WeaponType.BallisticMissile:
			case Weapon._WeaponType.RV:
			case Weapon._WeaponType.HGV:
				if (myWeapon().ImpactAltitude < num)
				{
					myWeapon().ImpactAltitude = num;
				}
				else if (num < 0f)
				{
					myWeapon().ImpactAltitude = 0f;
				}
				break;
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

	public virtual void DetermineDesiredAltitude(float float_0)
	{
		try
		{
			DetermineDesiredImpactAltitude();
			if (myWeapon().IsParachuteLoitering)
			{
				m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - 50f * float_0;
				m_EventVal.DesiredPitch = -85f;
				return;
			}
			if (myWeapon().IsReEntryVehicle && myWeapon().SupportsAttitude_Pitch && myWeapon().Navigator.HasPlottedCourse())
			{
				myWeapon().DesiredAltitude = myWeapon().Navigator.PlottedCourse.First().Altitude;
				CalculateDesiredPitch(myWeapon().Navigator.PlottedCourse.First(), float_0);
				return;
			}
			if (myWeapon().IsReEntryVehicle)
			{
				if (myWeapon().Navigator.HasPlottedCourse())
				{
					myWeapon().DesiredAltitude = myWeapon().Navigator.PlottedCourse.First().Altitude;
					CalculateDesiredPitch(myWeapon().Navigator.PlottedCourse.First(), float_0);
				}
				else if (myWeapon().SupportsAttitude_Pitch)
				{
					if (myWeapon().Sensors_Cached.Length == 0)
					{
						myWeapon().DesiredAltitude = myWeapon().AI.PrimaryTarget.GetCurrentAltitude();
						CalculateDesiredPitch(new GeoPoint(myWeapon().AI.PrimaryTarget.GetLongitude(), myWeapon().AI.PrimaryTarget.GetLatitude()), float_0);
					}
					else if (Information.IsNothing(PrimaryTarget))
					{
						myWeapon().DesiredPitch = myWeapon().Attitude_Pitch;
					}
					else
					{
						myWeapon().DesiredAltitude = myWeapon().ImpactAltitude;
						CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
					}
				}
				else
				{
					myWeapon().DesiredAltitude = 0f;
				}
				return;
			}
			if (!TerminalDive)
			{
				if (myWeapon().IsTorpedo)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					((Torpedo_AI)myWeapon().AI).DetermineDesiredAltitude(float_0);
				}
				else
				{
					if (myWeapon().Navigator.HasPlottedCourse() && !myWeapon().SupportsAttitude_Pitch)
					{
						Waypoint waypoint = myWeapon().Navigator.PlottedCourse[0];
						if (m_EventVal.GetCurrentAltitude() < waypoint.Altitude)
						{
							float num = Math.Abs(m_EventVal.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(m_EventVal, waypoint.Altitude));
							if ((double)Module_Unit.RangeToPoint_Horiz(myWeapon(), waypoint) < (double)num * 1.1)
							{
								m_EventVal.DesiredAltitude = waypoint.Altitude;
								CalculateDesiredPitch(null, float_0);
								return;
							}
						}
					}
					if (myWeapon().CruiseAltitude_AGL != 0f && myWeapon().GetCurrentAltitude() <= myWeapon().Kinematics.GetClimbRate_Nominal())
					{
						if (myWeapon().IsReEntryVehicle)
						{
							myWeapon().DesiredAltitude = 0f;
						}
						else
						{
							if (myWeapon().IsAAW)
							{
								myWeapon().DesiredAltitude = myWeapon().ImpactAltitude;
								CalculateDesiredPitch(null, float_0);
								return;
							}
							m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_AGL + (float)Math.Max(0, (int)Terrain.GetElevation(myWeapon().GetLatitude(), myWeapon().GetLongitude(), bool_0: false, myWeapon().ParentScen));
						}
						if (!PerformTerrainFollowingIfNecessary())
						{
							CalculateDesiredPitch(null, float_0);
						}
						return;
					}
				}
			}
			if (myWeapon().CruiseAltitude_AGL != 0f && myWeapon().GetCurrentAltitude() < 8850f)
			{
				int elevation = Terrain.GetElevation(myWeapon().GetLatitude(), myWeapon().GetLongitude(), bool_0: false, myWeapon().ParentScen);
				if (elevation > 0 && myWeapon().GetCurrentAltitude() - (float)elevation <= myWeapon().Kinematics.GetClimbRate_Nominal())
				{
					m_EventVal.DesiredAltitude = (float)elevation + myWeapon().CruiseAltitude_AGL;
					if (!PerformTerrainFollowingIfNecessary())
					{
						CalculateDesiredPitch(null, float_0);
					}
					return;
				}
			}
			if (PrimaryTarget == null && !myWeapon().IsMobileDecoy && !myWeapon().isUAV)
			{
				m_EventVal.DesiredAltitude = PrimaryTarget_LastKnown_Altitude;
				CalculateDesiredPitch(PrimaryTarget_LastKnown_Lat, PrimaryTarget_LastKnown_Lon, PrimaryTarget_LastKnown_Altitude);
			}
			else if (myWeapon().CruiseAltitude_AGL == 0f && myWeapon().CruiseAltitude_ASL == 0f && m_EventVal.GetCurrentAltitude() == myWeapon().ImpactAltitude && !myWeapon().IsMobileDecoy && !myWeapon().isUAV)
			{
				m_EventVal.DesiredAltitude = myWeapon().ImpactAltitude;
				CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
			}
			else if (myWeapon().CruiseAltitude_AGL == 0f && myWeapon().CruiseAltitude_ASL == 0f)
			{
				if (!myWeapon().IsMobileDecoy && !myWeapon().isUAV)
				{
					if (myWeapon().isLoiterCapable && PrimaryTarget != null && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
					{
						if (myWeapon().IsMissile && myWeapon().CanParachuteLoiter)
						{
							myWeapon().DesiredAltitude = myWeapon().MaxLaunchAlt_ASL * 0.7f;
						}
						else
						{
							myWeapon().DesiredAltitude = myWeapon().GetCurrentAltitude();
						}
						CalculateDesiredPitch(null, float_0);
					}
					else if (m_EventVal.GetCurrentAltitude() != myWeapon().ImpactAltitude)
					{
						CallDescriptor(float_0);
					}
				}
				else
				{
					if (!myWeapon().SupportsAltitude_Control)
					{
						myWeapon().DesiredAltitude = myWeapon().GetCurrentAltitude();
					}
					CalculateDesiredPitch(null, float_0);
				}
			}
			else if (PrimaryTarget != null && PrimaryTarget.IsBallisticTarget())
			{
				CallDescriptor(float_0);
			}
			else
			{
				Trajectory_LoftedFlight(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100971", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void PitchForLoftArc(float float_0, Geopoint_Struct geopoint_Struct_0)
	{
		float num = geopoint_Struct_0.Altitude - myWeapon().LaunchPoint.Altitude;
		float num5 = Module_Unit.RangeToPoint_Horiz(myWeapon(), geopoint_Struct_0);
		float num6 = Module_Unit.RangeToPoint_Horiz(myWeapon(), myWeapon().LaunchPoint);
		double x = (double)num5 * 1852.0;
		double num7 = (double)myWeapon().LaunchPoint.RangeToPoint_Horiz(geopoint_Struct_0.Longitude, geopoint_Struct_0.Latitude) * 1852.0;
		float num8 = 1f;
		double num9 = Math.Atan2(geopoint_Struct_0.Altitude - myWeapon().GetCurrentAltitude(), x) * 57.2957795130823;
		if (num6 > num5)
		{
			if (!(m_EventVal.GetCurrentAltitude() >= geopoint_Struct_0.Altitude) || !(num9 < (double)m_EventVal.Attitude_Pitch))
			{
				myWeapon().DesiredPitch = (float)num9;
				return;
			}
			num8 = -1f;
		}
		double num10 = Math.Atan((double)num / num7 + Math.Sqrt(Math.Pow(num, 2.0) / Math.Pow(num7, 2.0) + 1.0)) * 57.2957795130823;
		double num11 = (double)myWeapon().LaunchPoint.Altitude + num7 / 4.0;
		float maximumAltitude = myWeapon().Kinematics.GetMaximumAltitude();
		if (num11 > (double)maximumAltitude)
		{
			num11 = maximumAltitude - 1f;
		}
		double num12 = (double)(myWeapon().GetCurrentAltitude() - myWeapon().LaunchPoint.Altitude) / num11;
		if (num12 > 1.0 && num8 == -1f)
		{
			num8 = 1f;
		}
		double num2 = (num10 - num10 * num12) * (double)num8;
		bool flag = num2 < (double)myWeapon().Attitude_Pitch;
		if (!(num6 <= num5) && num9 > num2)
		{
			num2 = num9;
			return;
		}
		if (myWeapon().ImpactAltitude > myWeapon().GetCurrentAltitude() && num9 > num2)
		{
			num2 = num9;
			flag = false;
		}
		if (myWeapon().UsesBoostCoastModel.Value)
		{
			if (myWeapon().TimeSinceLaunch > (float)myWeapon().TotalBurnTime && num2 > 0.0 && geopoint_Struct_0.Altitude < myWeapon().GetCurrentAltitude())
			{
				double num3 = (double)myWeapon().Kinematics.GetMaximumSpeed() / 2.0;
				float currentSpeed = myWeapon().CurrentSpeed;
				if (currentSpeed <= (float)(num3 * 1.5))
				{
					if (currentSpeed <= (float)(num3 * 1.2))
					{
						num2 = 0.0 - Math.Abs(Math.Atan2(geopoint_Struct_0.Altitude - myWeapon().GetCurrentAltitude(), x) * 57.2957795130823);
						myWeapon().DesiredAltitude = geopoint_Struct_0.Altitude;
						flag = false;
					}
					else
					{
						num2 = Math.Min(num2, num2 / 2.0);
						flag = (double)myWeapon().Attitude_Pitch > num2 && (double)myWeapon().Attitude_Pitch < 2.0 * num2;
					}
				}
			}
			else if (myWeapon().TimeSinceLaunch > (float)myWeapon().TotalBurnTime && geopoint_Struct_0.Altitude > myWeapon().GetCurrentAltitude())
			{
				double num4 = (double)myWeapon().Kinematics.InitDescriptor(myWeapon().GetCurrentAltitude()) * 1.5;
				if ((double)myWeapon().CurrentSpeed < num4)
				{
					num2 = Math.Abs(Module_Unit.GrazingAngleToPoint(myWeapon(), geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, geopoint_Struct_0.Altitude));
					myWeapon().DesiredAltitude = geopoint_Struct_0.Altitude;
					flag = false;
				}
			}
			if (myWeapon().TimeSinceLaunch < (float)myWeapon().TotalBurnTime && num2 > 0.0)
			{
				num2 *= 1.2;
			}
		}
		myWeapon().DesiredPitch = (float)num2;
		if (flag)
		{
			myWeapon().Attitude_Pitch = myWeapon().DesiredPitch;
		}
	}

	protected void PitchForLoftArcApogeeAtPercentageOfShotRange(float float_0, float float_1, Geopoint_Struct geopoint_Struct_0)
	{
		float num = myWeapon().LaunchPoint.RangeToPoint_Horiz(geopoint_Struct_0.Longitude, geopoint_Struct_0.Latitude);
		float num2 = myWeapon().LaunchPoint.RangeToUnit_Horiz(m_EventVal);
		double double_ = MathFunctions.LogoutRequest(myWeapon().LaunchPoint.Latitude, myWeapon().LaunchPoint.Longitude, geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude);
		float float_2 = float_1 * num;
		GeoPoint launchPoint = myWeapon().LaunchPoint;
		double double_2 = launchPoint.Longitude;
		GeoPoint launchPoint2 = myWeapon().LaunchPoint;
		double double_3 = launchPoint2.Latitude;
		Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(ref double_2, ref double_3, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, ref float_2, ref double_);
		launchPoint2.Latitude = double_3;
		launchPoint.Longitude = double_2;
		geopoint_Struct_.Altitude = myWeapon().DesiredAltitude;
		float num3;
		float num4;
		if (num2 <= float_2)
		{
			num3 = Module_Unit.RangeToPoint_Horiz(m_EventVal, geopoint_Struct_);
			num4 = (float)(Math.Atan2(geopoint_Struct_.Altitude - m_EventVal.GetCurrentAltitude(), (double)num3 * 1852.0) * 57.2957795130823);
			if (num4 > 0f)
			{
				num4 += 10f * (1f - num2 / float_2);
			}
		}
		else
		{
			num3 = Module_Unit.RangeToPoint_Horiz(m_EventVal, geopoint_Struct_0);
			num4 = (float)(Math.Atan2(geopoint_Struct_0.Altitude - m_EventVal.GetCurrentAltitude(), (double)num3 * 1852.0) * 57.2957795130823);
		}
		num4 = Math.Max(-90f, Math.Min(90f, num4));
		float num5 = num4 - m_EventVal.Attitude_Pitch;
		if (num3 > 10f)
		{
			num5 = (float)Math.Max(-0.9, Math.Min(0.9, num5));
		}
		if (!float.IsNaN(num5))
		{
			m_EventVal.DesiredPitch = m_EventVal.Attitude_Pitch + num5;
		}
	}

	private bool LogoutDescriptor()
	{
		if (Information.IsNothing(PrimaryTarget))
		{
			return false;
		}
		Contact_Base.ContactType type = PrimaryTarget.Type;
		if (type != Contact_Base.ContactType.Aimpoint && type != Contact_Base.ContactType.ActivationPoint)
		{
			return false;
		}
		return true;
	}

	private void ViewDescriptor(float float_0)
	{
		try
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			float? nullable_ = null;
			Geopoint_Struct geopoint_Struct_;
			float num;
			if (myWeapon().Navigator.HasPlottedCourse())
			{
				geopoint_Struct_ = myWeapon().Navigator.PlottedCourse[0].ReadInvocation();
				num = Module_Unit.RangeToPoint_Horiz(myWeapon(), geopoint_Struct_);
			}
			else if (PrimaryTarget.CurrentSpeed == 0f)
			{
				num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
				geopoint_Struct_ = new Geopoint_Struct(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetCurrentAltitude());
			}
			else
			{
				float float_ = (myWeapon().SupportsAttitude_Pitch ? ((float)((double)myWeapon().Kinematics.GetMaximumSpeed() * 0.5)) : ((float)myWeapon().Kinematics.GetMaximumSpeed()));
				nullable_ = Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, Module_Unit.CalcTokenizer(myWeapon()), m_EventVal.CurrentHeading);
				if (PrimaryTarget.IsBallisticTarget())
				{
					Geopoint_Struct geopoint_Struct = myWeapon().Navigator.RemoveDescriptor(PrimaryTarget);
					geopoint_Struct_ = (geopoint_Struct.HasZeroCoords ? myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_, PrimaryTarget, nullable_) : geopoint_Struct);
				}
				else
				{
					geopoint_Struct_ = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_, PrimaryTarget, nullable_);
				}
				if (geopoint_Struct_.HasZeroCoords)
				{
					num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
					geopoint_Struct_ = new Geopoint_Struct(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude());
				}
				else
				{
					num = Module_Unit.RangeToPoint_Horiz(myWeapon(), geopoint_Struct_);
				}
			}
			int num2 = (myWeapon().Navigator.HasPlottedCourse() ? ((int)Math.Round(myWeapon().Navigator.PlottedCourse[0].Altitude)) : ((int)Math.Round(myWeapon().ImpactAltitude)));
			float num3 = (float)num2 - m_EventVal.GetCurrentAltitude();
			if (!nullable_.HasValue)
			{
				nullable_ = Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, Module_Unit.CalcTokenizer(myWeapon()), m_EventVal.CurrentHeading);
			}
			float float_2 = 0.5f + 0.49f * (1f - num / myWeapon().MaxAirRange);
			if (LogoutDescriptor() && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint && myWeapon().HasTerminalGuidance)
			{
				if (myWeapon().CruiseAltitude_AGL <= 0f)
				{
					m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_ASL;
				}
				else
				{
					m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_AGL + (float)Math.Max(0, myWeapon().GetLandElevation_next(bool_0: false, 1f));
				}
				if (m_EventVal.DesiredAltitude <= m_EventVal.GetCurrentAltitude() + 500f)
				{
					CalculateDesiredPitch(null, float_0);
					return;
				}
				myWeapon().DesiredAltitude = geopoint_Struct_.Altitude;
				PitchForLoftArcApogeeAtPercentageOfShotRange(float_0, float_2, geopoint_Struct_);
				return;
			}
			double num4 = Math.Atan2(num3, (double)num * 1852.0) * 57.2957795130823;
			bool flag = false;
			if (num4 < -10.0)
			{
				flag = true;
				if (nullable_.HasValue && num / nullable_.Value * Module_Unit.CalcTokenizer(m_EventVal) / 2f <= num)
				{
					flag = false;
				}
			}
			if (num3 < 0f && (flag || myWeapon().DesiredPitch < 0f))
			{
				LoginDescriptor(num3, float_0, nullable_.Value);
				return;
			}
			if (TerminalDive)
			{
				LoginDescriptor(num3, float_0, nullable_.Value);
				return;
			}
			if (myWeapon().CruiseAltitude_AGL <= 0f)
			{
				m_EventVal.DesiredAltitude = Math.Max(myWeapon().CruiseAltitude_ASL, num2);
			}
			else
			{
				if (myWeapon().IsAAW)
				{
					m_EventVal.DesiredAltitude = myWeapon().ImpactAltitude;
					CalculateDesiredPitch(null, float_0);
					return;
				}
				m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_AGL + (float)Math.Max(0, myWeapon().GetLandElevation_next(bool_0: false, 1f));
			}
			if (m_EventVal.DesiredAltitude <= m_EventVal.GetCurrentAltitude() + 500f)
			{
				if (myWeapon().SupportsAttitude_Pitch)
				{
					CalculateDesiredPitch(geopoint_Struct_.DisableInvocation(), float_0);
					if (myWeapon().DesiredPitch < 0f)
					{
						myWeapon().DesiredAltitude = geopoint_Struct_.Altitude;
					}
				}
			}
			else
			{
				PitchForLoftArcApogeeAtPercentageOfShotRange(float_0, float_2, geopoint_Struct_);
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
	}

	internal void ValidateDescriptor(float float_0)
	{
		try
		{
			float num = Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, Module_Unit.CalcTokenizer(myWeapon()), m_EventVal.CurrentHeading);
			if (PrimaryTarget == null)
			{
				return;
			}
			Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
			float num2;
			if (PrimaryTarget.CurrentSpeed == 0f)
			{
				num2 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			}
			else
			{
				float float_ = (myWeapon().SupportsAttitude_Pitch ? ((float)((double)myWeapon().Kinematics.GetMaximumSpeed() * 0.5)) : ((float)myWeapon().Kinematics.GetMaximumSpeed()));
				geopoint_Struct_ = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_, PrimaryTarget, num);
				num2 = (geopoint_Struct_.HasZeroCoords ? Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) : Module_Unit.RangeToPoint_Horiz(myWeapon(), geopoint_Struct_));
			}
			int num3 = (myWeapon().Navigator.HasPlottedCourse() ? ((int)Math.Round(myWeapon().Navigator.PlottedCourse[0].Altitude)) : ((int)Math.Round(myWeapon().ImpactAltitude)));
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (geopoint_Struct_.HasZeroCoords)
			{
				float float_2 = (myWeapon().SupportsAttitude_Pitch ? ((float)((double)myWeapon().Kinematics.GetMaximumSpeed() * 0.5)) : ((float)myWeapon().Kinematics.GetMaximumSpeed()));
				geopoint_Struct_ = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_2, PrimaryTarget, num);
			}
			float float_3 = (float)num3 - m_EventVal.GetCurrentAltitude();
			float num4 = Math.Abs(m_EventVal.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(m_EventVal, num3, num));
			if (myWeapon().IsReEntryVehicle)
			{
				if (myWeapon().Navigator.HasPlottedCourse())
				{
					if (myWeapon().Navigator.PlottedCourse.First().Altitude < m_EventVal.GetCurrentAltitude() && myWeapon().HasRVs.Value)
					{
						m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude();
						return;
					}
					m_EventVal.DesiredAltitude = myWeapon().Navigator.PlottedCourse.First().Altitude;
					CalculateDesiredPitch(myWeapon().Navigator.PlottedCourse.First(), float_0);
				}
				else
				{
					m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - float_0 * m_EventVal.Kinematics.DiveRate_Nominal();
					CalculateDesiredPitch(null, float_0);
				}
				return;
			}
			if (LogoutDescriptor() && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
			{
				if (myWeapon().CruiseAltitude_AGL <= 0f)
				{
					m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_ASL;
				}
				else
				{
					m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_AGL + (float)Math.Max(0, myWeapon().GetLandElevation_next(bool_0: false, 1f));
				}
				if (m_EventVal.DesiredAltitude <= m_EventVal.GetCurrentAltitude() + 500f)
				{
					CalculateDesiredPitch(null, float_0);
				}
				else
				{
					PitchForLoftArc(float_0, geopoint_Struct_);
				}
				return;
			}
			float num5 = (float)((double)myWeapon().MaxRange_NoTargetType * 0.25);
			if (num2 <= num4 && (num2 <= num5 || (PrimaryTarget.Type != 0 && PrimaryTarget.Type != Contact_Base.ContactType.Missile) || myWeapon().DataLinkParent != null))
			{
				LoginDescriptor(float_3, float_0, num);
				return;
			}
			if (TerminalDive)
			{
				LoginDescriptor(float_3, float_0, num);
				return;
			}
			if (myWeapon().CruiseAltitude_AGL <= 0f)
			{
				m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_ASL;
			}
			else
			{
				m_EventVal.DesiredAltitude = myWeapon().CruiseAltitude_AGL + (float)Math.Max(0, myWeapon().GetLandElevation_next(bool_0: false, 1f));
			}
			if (m_EventVal.DesiredAltitude <= m_EventVal.GetCurrentAltitude() + 500f)
			{
				CalculateDesiredPitch(null, float_0);
				if (m_EventVal.DesiredPitch < -45f)
				{
					m_EventVal.DesiredPitch = -45f;
				}
			}
			else
			{
				PitchForLoftArc(float_0, geopoint_Struct_);
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
	}

	protected virtual void Trajectory_LoftedFlight(float float_0)
	{
		if (PrimaryTarget != null)
		{
			if (PrimaryTarget.IsAir_Missile_Orbital_Contact)
			{
				ViewDescriptor(float_0);
			}
			else
			{
				ValidateDescriptor(float_0);
			}
		}
	}

	private void LoginDescriptor(float float_0, float float_1, float float_2)
	{
		TerminalDive = true;
		Geopoint_Struct geopoint_Struct_ = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(Module_Unit.CalcTokenizer(myWeapon()), PrimaryTarget, float_2);
		float num;
		if (geopoint_Struct_.HasZeroCoords)
		{
			num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			myWeapon().DesiredAltitude = myWeapon().ImpactAltitude;
		}
		else
		{
			num = Module_Unit.RangeToPoint_Horiz(m_EventVal, geopoint_Struct_);
			myWeapon().DesiredAltitude = geopoint_Struct_.Altitude;
		}
		if (float_0 < 0f)
		{
			if (myWeapon().SupportsAttitude_Pitch)
			{
				float_0 = myWeapon().DesiredAltitude - myWeapon().GetCurrentAltitude();
				float num2 = (float)(Math.Atan2(float_0, (double)num * 1852.0) * 57.2957795130823) - m_EventVal.Attitude_Pitch;
				if (num > 10f)
				{
					num2 = (float)Math.Max(-0.9, Math.Min(0.9, num2));
				}
				m_EventVal.DesiredPitch = m_EventVal.Attitude_Pitch + num2;
			}
			else
			{
				float num3 = m_EventVal.CurrentSpeed * float_1 / 3600f;
				m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num3 * Math.Abs(float_0) / num;
			}
		}
		else if (myWeapon().SupportsAttitude_Pitch)
		{
			m_EventVal.DesiredAltitude = myWeapon().ImpactAltitude;
			if (geopoint_Struct_.HasZeroCoords)
			{
				CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
			}
			else
			{
				CalculateDesiredPitch(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, geopoint_Struct_.Altitude);
			}
		}
		else
		{
			float num4 = m_EventVal.CurrentSpeed * float_1 / 3600f;
			m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num4 * Math.Abs(float_0) / num;
		}
	}

	[CompilerGenerated]
	private double GetDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(contact_0, m_EventVal);
	}

	[CompilerGenerated]
	private double WriteDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(contact_0, m_EventVal);
	}

	[CompilerGenerated]
	private bool NewDescriptor(Contact contact_0)
	{
		return contact_0.DetectedEmissions.Keys.Contains(myWeapon().ARM_SpecifiedEMission.Key);
	}

	[CompilerGenerated]
	private float PushDescriptor(Contact contact_0)
	{
		return Module_Unit.BearingToUnit_True(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private float InvokeDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private float SetupDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0);
	}
}
