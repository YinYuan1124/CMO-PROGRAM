using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command.Specifications;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Torpedo : Weapon
{
	private Torpedo_AI _ComparatorProxy;

	private Torpedo_Kinematics _ItemProxy;

	public float MaxKinematicRange_Cruise;

	public float MaxKinematicRange_Full;

	public override Weapon_AI AI => _ComparatorProxy;

	public override Weapon_Kinematics Kinematics => _ItemProxy;

	public Torpedo(ref Scenario scenario_0, int int_0, string string_0 = null)
	{
		_ComparatorProxy = new Torpedo_AI(this);
		ActiveUnit activeUnit_ = this;
		_ItemProxy = new Torpedo_Kinematics(ref activeUnit_);
		IsWeapon = true;
		Type = _WeaponType.Torpedo;
		IsTorpedo = true;
	}

	private Torpedo()
	{
		_ComparatorProxy = new Torpedo_AI(this);
		ActiveUnit activeUnit_ = this;
		_ItemProxy = new Torpedo_Kinematics(ref activeUnit_);
		IsWeapon = true;
		Type = _WeaponType.Torpedo;
		IsTorpedo = true;
	}

	public new static Torpedo FromXML_Private(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, bool bool_0)
	{
		try
		{
			Torpedo torpedo = new Torpedo();
			torpedo.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				return (Torpedo)concurrentDictionary_0[innerText];
			}
			torpedo.ObjectID_Set(innerText);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return torpedo;
			}
			concurrentDictionary_0.TryAdd(torpedo.ObjectID, torpedo);
			int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			DBFunctions.GetWeapon(scenario_0.DBConnection, torpedo, int_, scenario_0, bool_0);
			if (bool_0)
			{
				torpedo.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				Weapon.LoadSavedComponents(torpedo, scenario_0, xmlNode_0, concurrentDictionary_0);
			}
			Weapon.LoadMutableProperties(torpedo, scenario_0, xmlNode_0, concurrentDictionary_0);
			float maximumAltitude = torpedo.Kinematics.GetMaximumAltitude();
			float minimumAltitude = torpedo.Kinematics.GetMinimumAltitude();
			if (torpedo.GetCurrentAltitude() <= maximumAltitude)
			{
				if (torpedo.GetCurrentAltitude() < minimumAltitude)
				{
					torpedo.SetCurrentAltitude(bool_0: false, minimumAltitude);
				}
			}
			else
			{
				torpedo.SetCurrentAltitude(bool_0: false, maximumAltitude);
			}
			if (torpedo.DesiredAltitude <= maximumAltitude)
			{
				if (torpedo.DesiredAltitude < minimumAltitude)
				{
					torpedo.DesiredAltitude = minimumAltitude;
				}
			}
			else
			{
				torpedo.DesiredAltitude = maximumAltitude;
			}
			if (torpedo.Sensors_Cached.Count() > 0)
			{
				torpedo.Flags.ReAttack_Capability = true;
			}
			return torpedo;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Torpedo result = new Torpedo();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		try
		{
			if (GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen) >= 0)
			{
				Detonate(GetLatitude(), GetLongitude(), -1f, ref lockRandom_0, bool_0: true);
			}
			DestroyDescriptor(AddDescriptor() - float_0);
			if (!(AddDescriptor() <= 0f))
			{
				return;
			}
			if (AddDescriptor() < 0f)
			{
				DestroyDescriptor(0f);
			}
			switch (base.Guidance)
			{
			case WeaponGuidanceType.Passive:
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: true, float_0))
				{
					return;
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Passive:
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: false, float_0))
				{
					return;
				}
				break;
			case WeaponGuidanceType.DataLink_Plus_Passive:
				WeaponLogic_DatalinkedWeapons(float_0);
				break;
			case WeaponGuidanceType.Active:
			{
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: true, float_0))
				{
					return;
				}
				if (base.Navigator.HasNonPathfindPlottedCourse())
				{
					HandleReachingActivationPoint();
					break;
				}
				Sensor[] array = Sensors_ReadOnly();
				Sensor[] array4 = array;
				foreach (Sensor sensor in array4)
				{
					if (sensor.CanBeActive && !sensor.IsActive)
					{
						sensor.GoActive();
					}
				}
				break;
			}
			case WeaponGuidanceType.Datalink_Plus_Active:
				if (Sensors_ReadOnly().Length != 0 && Sensors_ReadOnly()[0].IsActive)
				{
					if (GuidanceLogic_DatalinkParentNotAvailable(float_0) || ((Torpedo_AI)AI).GuidanceLogic_DestroyedOrVanishedPrimaryTarget(float_0) || GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0))
					{
						return;
					}
				}
				else
				{
					WeaponLogic_DatalinkedWeapons(float_0);
					HandleReachingActivationPoint();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Active:
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: false, float_0))
				{
					return;
				}
				if (Sensors_ReadOnly().Length != 0 && !Sensors_ReadOnly()[0].IsActive)
				{
					HandleReachingActivationPoint();
				}
				break;
			case WeaponGuidanceType.CommandGuided_Datalinked:
				WeaponLogic_DatalinkedWeapons(float_0);
				break;
			case WeaponGuidanceType.Inertial:
				InitWatcher(float_0, ref lockRandom_0);
				break;
			case WeaponGuidanceType.TVM:
			case WeaponGuidanceType.BeamRiding:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100905", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (base.DatalinkRetargetTime > 0f && !Information.IsNothing(AI.PrimaryTarget))
		{
			base.DatalinkRetargetTime = 0f;
		}
		try
		{
			checked
			{
				if (ValidTargets.Mine && GetUnitSide().Contacts_NonAU.Count > 0 && !(AI.PrimaryTarget is ActivationPointContact) && !(AI.PrimaryTarget is AimpointContact))
				{
					Sensor[] array2 = Sensors_ReadOnly();
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].GoActive();
					}
					ObservableDictionary<string, UnguidedWeapon> unguidedWeapons = ParentScen.UnguidedWeapons;
					List<UnguidedWeapon> list = new List<UnguidedWeapon>();
					foreach (string item in GetUnitSide().Contacts_NonAU)
					{
						UnguidedWeapon unguidedWeapon = null;
						unguidedWeapons.TryGetValue(item, ref unguidedWeapon);
						if (!Information.IsNothing(unguidedWeapon) && unguidedWeapon.IsMine && Module_Unit.RangeToUnit_Horiz(this, unguidedWeapon) < MaxSubsurfaceRange)
						{
							list.Add(unguidedWeapon);
						}
					}
					UnguidedWeapon unguidedWeapon2 = null;
					if (list.Count <= 0)
					{
						ParentScen.MineAllocation.Remove(ObjectID);
					}
					else
					{
						while (list.Count > 0)
						{
							unguidedWeapon2 = (from theMine in list.ToList()
								where theMine != null
								select theMine into unguidedWeapon_0
								orderby Module_Unit.RangeToUnit_Horiz_Angular(this, unguidedWeapon_0)
								select unguidedWeapon_0).ElementAtOrDefault(0);
							if (unguidedWeapon2 == null)
							{
								break;
							}
							if (unguidedWeapon2._CandidateProxy == null)
							{
								float float_ = Module_Unit.RangeToUnit_Slant(this, unguidedWeapon2);
								if (unguidedWeapon2.GetCurrentAltitude() < -5f)
								{
									Sensor[] array3 = Sensors_ReadOnly();
									int num = 0;
									while (num < array3.Length)
									{
										Sensor sensor2 = array3[num];
										if (!sensor2.IsSonar || !sensor2.IsActive || !sensor2.IsOperating || (!sensor2.GetSearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar) && !sensor2.Capabilities.Mine_Obstacle_Search) || !sensor2.CanDetectTarget_NonAU(this, unguidedWeapon2, float_))
										{
											num++;
											continue;
										}
										goto IL_05f2;
									}
								}
								list.Remove(unguidedWeapon2);
								continue;
							}
							if (!unguidedWeapon2._CandidateProxy.Equals(this))
							{
								list.Remove(unguidedWeapon2);
								continue;
							}
							if (AI.PrimaryTarget == null)
							{
								unguidedWeapon2._CandidateProxy = null;
							}
							break;
							IL_05f2:
							AimpointContact aimpointContact = new AimpointContact(unguidedWeapon2.GetLatitude(), unguidedWeapon2.GetLongitude());
							aimpointContact.SetCurrentAltitude(bool_0: false, unguidedWeapon2.GetCurrentAltitude());
							AimpointContact aimpointContact2 = aimpointContact;
							AI.PrimaryTarget = aimpointContact2;
							unguidedWeapon2._CandidateProxy = this;
							base.Navigator.ClearPlottedCourse();
							Waypoint waypoint_ = new Waypoint(unguidedWeapon2.GetLongitude(), unguidedWeapon2.GetLatitude(), unguidedWeapon2.GetCurrentAltitude(), Waypoint.WaypointType.WeaponTarget, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
							base.Navigator.AddWaypoint(waypoint_);
							SetDesiredHeading(TurnRate.Max, Math2.PublishClass(GetLatitude(), GetLongitude(), aimpointContact2.GetLatitude(), aimpointContact2.GetLongitude()));
							DesiredSpeed = 2f;
							if (!ParentScen.MineAllocation.ContainsKey(ObjectID))
							{
								ParentScen.MineAllocation.Add(ObjectID, unguidedWeapon2);
							}
							break;
						}
					}
					if (m_ObserverReader > 0f)
					{
						m_ObserverReader -= float_0;
						if (m_ObserverReader <= 0f)
						{
							Detonate(GetLatitude(), GetLongitude(), GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen), ref lockRandom_0, bool_0: true);
						}
					}
					AI.DetermineDesiredAltitude(float_0);
					return;
				}
				if (ValidTargets.Mine && !base.Navigator.HasNonPathfindPlottedCourse())
				{
					AI.PrimaryTarget = null;
					SetDesiredHeading(TurnRate.Max, CurrentHeading);
					AI.DetermineDesiredAltitude(float_0);
				}
			}
			if (dicReader && ValidTargets.Mine)
			{
				UnguidedWeapon unguidedWeapon3 = null;
				if (ParentScen.MineAllocation.TryGetValue(ObjectID, ref unguidedWeapon3))
				{
					if ((int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, unguidedWeapon3) * 1852.0) < 20)
					{
						Detonate(GetLatitude(), GetLongitude(), GetCurrentAltitude(), ref lockRandom_0, bool_0: true);
						if (!_InvocationReader)
						{
							return;
						}
						unguidedWeapon3.DestroyMe(ref ParentScen, "Mine detonated");
						if (base.IsMine)
						{
							GetUnitSide().AAR.AddToLosses(unguidedWeapon3, bool_0: false);
						}
						List<EventTrigger> list2 = new List<EventTrigger>();
						foreach (EventTrigger value in ParentScen.EventTriggers.Values)
						{
							if (value.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value).GetIsFulfilled(unguidedWeapon3, this))
							{
								list2.Add(value);
							}
						}
						if (list2.Count > 0)
						{
							ParentScen.FireEvents(list2);
						}
						return;
					}
					if ((int)Math.Round((double)Module_Unit.RangeToUnit_Horiz(this, unguidedWeapon3) * 1852.0) < 500)
					{
						DesiredAltitude = GetCurrentAltitude();
					}
				}
			}
			else if ((AI.PrimaryTarget != null && clientReader) || dicReader)
			{
				double longitude;
				double latitude;
				float val;
				if (AI.PrimaryTarget == null)
				{
					longitude = GetLongitude();
					latitude = GetLatitude();
					val = GetCurrentAltitude();
				}
				else
				{
					val = ((AI.PrimaryTarget?.ActualUnit == null) ? Math.Max(AI.PrimaryTarget.GetCurrentAltitude(), -10f) : AI.PrimaryTarget.GetCurrentAltitude());
					longitude = AI.PrimaryTarget.GetLongitude();
					latitude = AI.PrimaryTarget.GetLatitude();
				}
				if (Warheads.Length != 0 && Warheads[0].GetIsNuclear(ParentScen))
				{
					if (Information.IsNothing(AI.PrimaryTarget.ActualUnit))
					{
						Detonate(latitude, longitude, Math.Max(val, -10f), ref lockRandom_0, bool_0: true);
						return;
					}
					ActiveUnit actualUnit = AI.PrimaryTarget.ActualUnit;
					Scenario parentScen = ParentScen;
					List<string> list_ = null;
					ResolveImpact(actualUnit, parentScen, bool_0: false, ref list_);
					return;
				}
				if (clientReader)
				{
					Contact primaryTarget = AI.PrimaryTarget;
					bool? flag = ((primaryTarget == null) ? null : new bool?(primaryTarget.Type == Contact_Base.ContactType.Aimpoint));
					bool? flag2 = (!flag) ?? flag;
					if (flag2.GetValueOrDefault(true))
					{
						Contact primaryTarget2 = AI.PrimaryTarget;
						flag = ((primaryTarget2 == null) ? null : new bool?(primaryTarget2.Type == Contact_Base.ContactType.ActivationPoint));
						if (((!flag) ?? flag).GetValueOrDefault() && flag2.HasValue)
						{
							if (AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.ActualUnit.Weaponry != null)
							{
								if (!AI.PrimaryTarget.ActualUnit.IsTorpedo || ValidTargets.Torpedo)
								{
									ActiveUnit_Weaponry weaponry = AI.PrimaryTarget.ActualUnit.Weaponry;
									Weapon weapon_ = this;
									weaponry.ResolvePointDefence(float_0, ref weapon_);
								}
							}
							else
							{
								ParentScen.DestroyThisUnit(this, "Point defense resolution", "Weapon Interaction");
							}
						}
					}
				}
				else
				{
					if (AI.PrimaryTarget == null || !AI.PrimaryTarget.IsGroundContact)
					{
						AI.DropTarget(AI.PrimaryTarget);
						if (ValidTargets.Mine)
						{
							ParentScen.MineAllocation.Remove(ObjectID);
						}
						return;
					}
					Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen), ref lockRandom_0, bool_0: true);
				}
			}
			if (m_ObserverReader > 0f)
			{
				m_ObserverReader -= float_0;
				if (m_ObserverReader <= 0f)
				{
					Detonate(GetLatitude(), GetLongitude(), AI.PrimaryTarget.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen), ref lockRandom_0, bool_0: true);
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100906", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float float_0)
	{
		try
		{
			float float_ = 60f;
			if (base.DataLinkParent != null)
			{
				float_ = 180f;
			}
			if (myTargetDoesNotExist())
			{
				AttemptRetargeting_Datalink(float_0, float_);
				return true;
			}
			if (!Information.IsNothing(AI.PrimaryTarget) && !AI.PrimaryTarget.GetIsDestroyed(ParentScen))
			{
				if (AI.PrimaryTarget.Age > 30f && AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && !base.Navigator.HasNonPathfindPlottedCourse())
				{
					if (!base.HasGoneAutonomous)
					{
						StopReponse(bool_0: true, bool_1: true);
						AddMessage("武器：" + Name + "没有收到来自父单元的确切目标更新...自主决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					return true;
				}
				return false;
			}
			AttemptRetargeting_Datalink(float_0, float_);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100935", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	protected override void WeaponLogic_DatalinkedWeapons(float float_0)
	{
		try
		{
			float float_ = 60f;
			if (base.DataLinkParent != null)
			{
				float_ = 180f;
			}
			if (!GuidanceLogic_DatalinkParentNotAvailable(float_0) && !GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float_0))
			{
				GuidanceLogic_Overshoot(float_, bool_0: true, bool_1: true, bool_2: true, float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100941", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void AttemptRetargeting_Datalink(float float_0, float float_1)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return;
			}
			Contact contact = null;
			if (AI.PrimaryTarget != null)
			{
				contact = AI.PrimaryTarget;
				Weapon_AI aI = AI;
				ActiveUnit activeUnit_ = this;
				aI.ClearAllTargets(ref activeUnit_);
				if (!base.Navigator.HasNonPathfindPlottedCourse())
				{
					SetDesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			base.DatalinkRetargetTime += float_0;
			if (!ParentScen.FifthSecondIsChangingOnThisPulse)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			List<Contact> list2 = new List<Contact>();
			if (AI.PrimaryTarget_Type == Contact_Base.ContactType.Air || AI.PrimaryTarget_Type == Contact_Base.ContactType.Missile || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Torpedo)
			{
				GetUnitSide().RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
			}
			if (base.DataLinkParent == null)
			{
				base.DatalinkRetargetTime = 0f;
				StopReponse(bool_0: true, bool_1: true);
				if (base.Guidance == WeaponGuidanceType.Datalink_Plus_Active)
				{
					AddMessage("武器：" + Name + "没有合适的替代目标被重定向到...自行决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					return;
				}
				AddMessage("武器：" + Name + "丢失数据链接...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				AI.PrimaryTarget = null;
				return;
			}
			string text = "";
			string right = TokenizerDefinitionSpec.ResolveTokenizer(ActiveUnit_Weaponry.DLZResultEnum.Fail_OutOfEnergy);
			Contact[] targets_ReadOnly = base.DataLinkParent.AI.Targets_ReadOnly;
			Contact[] array = targets_ReadOnly;
			foreach (Contact contact2 in array)
			{
				string string_ = "";
				if (Math.Abs(Module_Unit.PrintTokenizer(contact2, this, bool_0: true, ref string_)) > float_1 || contact == contact2)
				{
					continue;
				}
				bool? flag;
				if (contact2.GetStance(base.DataLinkParent.GetUnitSide()) == Misc.PostureStance.Hostile)
				{
					flag = false;
				}
				else
				{
					byte? b = (byte?)base.DataLinkParent.Doctrine.GetWeaponControlStatus_Air(base.DataLinkParent.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
					flag = (!flag2) ?? flag2;
				}
				bool? flag3 = flag;
				if ((!(!flag3).GetValueOrDefault() && !contact2.IsSubmergedContact && flag3.HasValue) || !base.DataLinkParent.AI.IsClearedToEngageThisTarget(contact2))
				{
					continue;
				}
				try
				{
					if (base.DataLinkParent != null)
					{
						text = base.DataLinkParent.Weaponry.CanThisWeaponEngageThisTarget_AttemptRetargeting(this, contact2);
						if (Operators.CompareString(text, "OK", TextCompare: false) == 0)
						{
							goto IL_0450;
						}
						if (Operators.CompareString(text, right, TextCompare: false) == 0)
						{
							list2.Add(contact2);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200048", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				continue;
				IL_0450:
				if (contact2.Type == AI.PrimaryTarget_Type)
				{
					list.Add(contact2);
				}
				else
				{
					list2.Add(contact2);
				}
			}
			Weapon weapon_;
			Contact contact_;
			switch (list.Count)
			{
			case 1:
			{
				base.BlindTime = 0f;
				base.DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = list[0];
				weapon_ = this;
				Weapon_AI aI4 = AI;
				contact_ = aI4.PrimaryTarget;
				CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
				aI4.PrimaryTarget = contact_;
				AddMessage("武器：" + Name + "只有一个替代目标可以重定向到：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				return;
			}
			case 0:
				AddMessage("武器：" + Name + "没有合格的替代目标可以重定向到...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				switch (list2.Count)
				{
				default:
				{
					base.BlindTime = 0f;
					base.DatalinkRetargetTime = 0f;
					IEnumerable<Contact> source = list2.OrderBy((Contact theC) => theC.IncomingGuidedWeapons.Length).ThenBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0));
					AI.PrimaryTarget = source.ElementAtOrDefault(0);
					weapon_ = this;
					Weapon_AI aI2 = AI;
					contact_ = aI2.PrimaryTarget;
					CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
					aI2.PrimaryTarget = contact_;
					if (!Information.IsNothing(contact) && contact == AI.PrimaryTarget)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						AddMessage("武器：" + Name + "已被重定向到新目标：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					break;
				}
				case 1:
				{
					base.BlindTime = 0f;
					base.DatalinkRetargetTime = 0f;
					AI.PrimaryTarget = list2[0];
					weapon_ = this;
					Weapon_AI aI3 = AI;
					contact_ = aI3.PrimaryTarget;
					CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
					aI3.PrimaryTarget = contact_;
					AddMessage("武器：" + Name + "只有一个备用（辅助）目标可以重定向到：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					break;
				}
				case 0:
					if (AI.PrimaryTarget_Type != Contact_Base.ContactType.Surface && AI.PrimaryTarget_Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Fixed && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Mobile)
					{
						if (base.DatalinkRetargetTime < 11f)
						{
							break;
						}
						if (base.IsAAW)
						{
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
							if (base.Guidance != WeaponGuidanceType.Active && base.Guidance != WeaponGuidanceType.Passive && base.Guidance != WeaponGuidanceType.SemiActive_Plus_Active && base.Guidance != WeaponGuidanceType.TimesharedSemiActive_Plus_Active && _Sensors.Length <= 1)
							{
								AddMessage("武器：" + Name + "没有合格的替代目标可以重定向到...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							}
							else
							{
								AddMessage("武器：" + Name + "没有合适的替代目标被重定向到...自行决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							}
						}
						else if (AI.PrimaryTarget_Type != Contact_Base.ContactType.ActivationPoint)
						{
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
							return;
						}
					}
					else
					{
						if (_Sensors.Length != 0 && ValidTargets.Radar && base.Is_LOAL_capable)
						{
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
							return;
						}
						GoDumb();
					}
					break;
				}
				if (!Information.IsNothing(AI.PrimaryTarget) && base.Navigator.HasNonPathfindPlottedCourse())
				{
					base.Navigator.CalculateDescriptor(Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false), bool_1: false);
					if (base.Navigator.HasNonPathfindPlottedCourse())
					{
						SetDesiredHeading(TurnRate.Max, Math2.PublishClass(GetLatitude(), GetLongitude(), base.Navigator.PlottedCourse[0].Latitude, base.Navigator.PlottedCourse[0].Longitude));
					}
				}
				return;
			}
			base.BlindTime = 0f;
			base.DatalinkRetargetTime = 0f;
			IEnumerable<Contact> source2 = list.OrderBy((Contact theC) => theC.IncomingGuidedWeapons.Length).ThenBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0));
			AI.PrimaryTarget = source2.ElementAtOrDefault(0);
			weapon_ = this;
			Weapon_AI aI5 = AI;
			contact_ = aI5.PrimaryTarget;
			CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
			aI5.PrimaryTarget = contact_;
			if (!Information.IsNothing(contact) && contact == AI.PrimaryTarget)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				AddMessage("武器：" + Name + "已被重定向到新目标：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100947T", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool AboutToImpact_ActualTarget(float float_0)
	{
		if (AI.PrimaryTarget == null)
		{
			return false;
		}
		if (AI.PrimaryTarget.ActualUnit == null)
		{
			return false;
		}
		float num = Module_Unit.BearingToPoint_Relative(this, AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude());
		if (num > 90f && num < 270f)
		{
			return false;
		}
		if (Math.Abs(GetCurrentAltitude() - AI.PrimaryTarget.ActualUnit.GetCurrentAltitude()) < 20f)
		{
			switch (AI.PrimaryTarget.ActualUnit.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				double num3 = (double)((Submarine)AI.PrimaryTarget.ActualUnit).Length * 0.000539957;
				if ((double)Module_Unit.RangeToUnit_Horiz(this, AI.PrimaryTarget.ActualUnit) < num3)
				{
					return true;
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Ship:
			{
				double num2 = (double)((Ship)AI.PrimaryTarget.ActualUnit).Length * 0.000539957;
				if ((double)Module_Unit.RangeToUnit_Horiz(this, AI.PrimaryTarget.ActualUnit) < num2)
				{
					return true;
				}
				break;
			}
			}
		}
		return base.AboutToImpact_ActualTarget(float_0);
	}

	private void InitWatcher(float float_0, ref LockRandom lockRandom_0)
	{
		try
		{
			if (IsNuke.Value)
			{
				if (!base.Navigator.HasNonPathfindPlottedCourse())
				{
					Detonate(GetLatitude(), GetLongitude(), GetCurrentAltitude(), ref lockRandom_0, bool_0: true);
					ParentScen.DestroyThisUnit(this, "Nuclear armed torpedo intentionally deonated.", "Impact / Detonation");
				}
			}
			else
			{
				if (!base.IsArmed)
				{
					return;
				}
				float num = CurrentSpeed / 3600f * float_0;
				List<ActiveUnit> list = new List<ActiveUnit>();
				float num2 = 0f;
				foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ == null || (!activeUnits_.IsShip && !activeUnits_.IsSubmarine && (!activeUnits_.IsFacility || Module_Unit.ResetTokenizer(activeUnits_))) || !(Math.Round(activeUnits_.GetCurrentAltitude()) >= -20.0))
					{
						continue;
					}
					float relativeBearing = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.PublishClass(GetLatitude(), GetLongitude(), activeUnits_.GetLatitude(), activeUnits_.GetLongitude()));
					if (270f <= relativeBearing || relativeBearing <= 90f)
					{
						if (activeUnits_.IsShip)
						{
							num2 = ((Ship)activeUnits_).Length / 2f;
						}
						else if (activeUnits_.IsSubmarine)
						{
							num2 = ((Submarine)activeUnits_).Length / 2f;
						}
						else if (activeUnits_.IsFacility)
						{
							num2 = (float)Math.Sqrt(((Facility)activeUnits_).Area / 3.14159265358979);
						}
						float num3 = num2 / 1852f;
						float num4 = Module_Unit.RangeToUnit_Horiz(this, activeUnits_);
						if (num4 <= num3)
						{
							list.Add(activeUnits_);
						}
						else if (num4 <= num)
						{
							list.Add(activeUnits_);
						}
					}
				}
				switch (list.Count)
				{
				case 1:
				{
					ActiveUnit activeUnit_2 = list[0];
					Scenario parentScen2 = ParentScen;
					List<string> list_2 = null;
					ResolveImpact(activeUnit_2, parentScen2, bool_0: false, ref list_2);
					break;
				}
				default:
				{
					ActiveUnit activeUnit_ = list[lockRandom_0.Next(list.Count - 1)];
					Scenario parentScen = ParentScen;
					List<string> list_ = null;
					ResolveImpact(activeUnit_, parentScen, bool_0: false, ref list_);
					break;
				}
				case 0:
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100940", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool ResolveImpact(ActiveUnit activeUnit_0, Scenario scenario_0, bool bool_0, ref List<string> list_0)
	{
		if (this == null)
		{
			return false;
		}
		if (ParentScen.MorituriUnits.Contains(this))
		{
			return false;
		}
		LockRandom lockRandom_ = GameGeneral.LockRandom_0;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			bool flag2 = false;
			float num = 0f;
			if (activeUnit_0.IsShip)
			{
				num = SurfPOK;
			}
			else if (activeUnit_0.IsSubmarine)
			{
				num = SubPOK;
				if (num == 0f && activeUnit_0.GetCurrentAltitude() == 0f)
				{
					num = SurfPOK;
				}
			}
			else
			{
				if (activeUnit_0.IsFacility)
				{
					bool result = Impact_CEP(activeUnit_0, ref scenario_0, ref lockRandom_);
					ParentScen.DestroyThisUnit(this, "Torpedo impacted facility " + activeUnit_0.Name, "Impact / Detonation");
					return result;
				}
				if (activeUnit_0.IsTorpedo)
				{
					num = SubPOK;
				}
			}
			if (!string.IsNullOrEmpty(Name))
			{
				_ = Name;
			}
			if (IsNuke.Value)
			{
				if ((float)lockRandom_.Next(1, 101) < num)
				{
					stringBuilder.Append("鱼雷" + Name + " 正在引爆其核弹头。");
					Detonate(GetLatitude(), GetLongitude(), ImpactAltitude, ref lockRandom_, bool_0: true);
				}
				else
				{
					stringBuilder.Append("鱼雷" + Name + " 未能引爆其核弹头（Dud！）");
				}
				CheckWatcher(this, activeUnit_0);
				ParentScen.DestroyThisUnit(this, "Nuclear torpedo intentionally detonated warhead.", "Impact / Detonation");
				return false;
			}
			string text = ((!activeUnit_0.IsAircraft || Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) == 0) ? activeUnit_0.Name : (activeUnit_0.Name + " (" + activeUnit_0.UnitClass + ")"));
			stringBuilder.Append("鱼雷" + Name + " 正在攻击" + text + " 基本PH为" + Conversions.ToString(Math.Round(num, 2)) + "%. ");
			float num2 = num;
			if (activeUnit_0.IsTorpedo)
			{
				stringBuilder.Append("目标是鱼雷 - 命中概率减半。");
				num2 = (float)((double)num2 * 0.5);
			}
			if (num2 < 0f)
			{
				num2 = 1f;
			}
			stringBuilder.Append("最终PH：" + Conversions.ToString((int)Math.Round(num2)) + "%. ");
			int num3 = lockRandom_.Next(1, 101);
			if ((float)num3 <= num2)
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num3) + " - 命中");
				flag = true;
			}
			else
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num3));
				if (Flags.ReAttack_Capability)
				{
					float num4 = num2 / 4f;
					if ((float)lockRandom_.Next(1, 101) < num4)
					{
						stringBuilder.Append(" - 未命中 - 不重新攻击（DUD）");
					}
					else
					{
						stringBuilder.Append(" - 未命中 - 重新攻击");
						PrepareForReattack(activeUnit_0);
						flag2 = true;
					}
				}
				else
				{
					stringBuilder.Append(" - 未命中");
					if (Warheads.Length != 0 && activeUnit_0.IsFacility && Warheads[0].IsExplosive)
					{
						float num5 = 0f;
						num5 = lockRandom_.Next(0, 359);
						float num6 = lockRandom_.Next(1, 50);
						stringBuilder.Append("（接近命中：" + Conversions.ToString(num6) + "m)");
						ActiveUnit_Damage damage = activeUnit_0.Damage;
						GeoPoint launchPoint = LaunchPoint;
						float float_ = num5;
						string string_ = "";
						damage.ResolveDamageFromWeapon(this, launchPoint, num6, float_, null, null, null, null, ref string_, bool_0: false);
					}
				}
			}
			string empty = string.Empty;
			empty = (flag ? (Name + " 命中" + activeUnit_0.Name) : (flag2 ? (Name + " 未命中将重新攻击") : (Name + " 未命中")));
			activeUnit_0.ParentScen.AddMessage(stringBuilder.ToString(), empty, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			if (list_0 != null)
			{
				list_0.Add(stringBuilder.ToString());
			}
			_InvocationReader = true;
			if (flag)
			{
				CheckWatcher(this, activeUnit_0);
				Impact(activeUnit_0, stringBuilder);
			}
			if (flag || !flag2)
			{
				ParentScen.DestroyThisUnit(this, "Torpedo impacted target " + activeUnit_0.Name, "Impact / Detonation");
			}
			return flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10032450394504329634901293", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void CheckWatcher(Weapon weapon_0, object object_0)
	{
		if (weapon_0.FiringParent == null || !weapon_0.FiringParent.IsSubmarine)
		{
			return;
		}
		bool flag = false;
		foreach (Contact contacts_ in ((ActiveUnit)object_0).GetUnitSide().Contacts_List)
		{
			if (contacts_.Type == Contact_Base.ContactType.Submarine && Module_Unit.RangeToUnit_Horiz((Module_Unit.Unit)object_0, contacts_) <= 15f && !(Math.Abs(MathFunctions.DeleteRequest(Math2.PublishClass(((ActiveUnit)object_0).GetLatitude(), ((ActiveUnit)object_0).GetLongitude(), contacts_.GetLatitude(), contacts_.GetLongitude()), Math2.PublishClass(((ActiveUnit)object_0).GetLatitude(), ((ActiveUnit)object_0).GetLongitude(), weapon_0.FiringParent.GetLatitude(), weapon_0.FiringParent.GetLongitude()))) >= 45f))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return;
		}
		bool flag2 = false;
		foreach (Contact contacts_2 in ((ActiveUnit)object_0).GetUnitSide().Contacts_List)
		{
			if (contacts_2.Type == Contact_Base.ContactType.Submarine && contacts_2.ActualUnit == weapon_0.FiringParent)
			{
				flag2 = true;
				break;
			}
		}
		if (!flag2)
		{
			Contact contact = new Contact(weapon_0.FiringParent);
			contact.SetLatitude(null, ((ActiveUnit)object_0).GetLatitude());
			contact.SetLongitude(null, ((ActiveUnit)object_0).GetLongitude());
			Geodesic_Vincenty.Point3D[] point3D_ = new Geodesic_Vincenty.Point3D[46];
			Geodesic_EdWilliams.CircleFromPoint(contact.GetLatitude(), contact.GetLongitude(), 15.0, 45, ref point3D_);
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(point3D_.Length);
			Geodesic_Vincenty.Point3D[] array = point3D_;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				Geodesic_Vincenty.Point3D point3D = array[i];
				list.Add(new Geopoint_Struct(point3D.X, point3D.Y));
			}
			contact.UncertaintyArea = list;
			((ActiveUnit)object_0).GetUnitSide().definitionProxy.Enqueue(new Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(contact, weapon_0.FiringParent, new List<Sensor>(), 0f, ActiveUnit_Sensory.SpecialDetectionMode.FlamingDatum, ((ActiveUnit)object_0).ParentScen.Time, new List<Geopoint_Struct>()));
		}
	}

	protected override void HandleReachingActivationPoint()
	{
		if (base.Guidance != WeaponGuidanceType.Inertial && !base.Navigator.HasNonPathfindPlottedCourse())
		{
			StopReponse(!Information.IsNothing(AI.PrimaryTarget) && AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint);
		}
	}

	[CompilerGenerated]
	private double ConcatWatcher(UnguidedWeapon unguidedWeapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, unguidedWeapon_0);
	}

	[CompilerGenerated]
	private double InterruptWatcher(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0);
	}

	[CompilerGenerated]
	private double RemoveWatcher(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0);
	}
}
