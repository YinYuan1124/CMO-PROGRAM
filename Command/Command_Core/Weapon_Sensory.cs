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
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Weapon_Sensory : ActiveUnit_Sensory
{
	private Weapon _ConfigurationReader;

	[SpecialName]
	private Weapon GetParentWeapon()
	{
		if (_ConfigurationReader == null)
		{
			_ConfigurationReader = (Weapon)strategyWrapper;
		}
		return _ConfigurationReader;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Weapon_Sensory");
			xmlWriter_0.WriteElementString("ObE", Boolean_0.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100988", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void PerformDetections(Sensor[] sensor_0, List<ActiveUnit> list_0, float float_0)
	{
		if (GetParentWeapon().AddDescriptor() <= 0f && (!GetParentWeapon().IsMissile || !GetParentWeapon().Navigator.HasPlottedCourse()))
		{
			base.PerformDetections(sensor_0, list_0, float_0);
		}
	}

	public new static Weapon_Sensory FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Weapon_Sensory weapon_Sensory = new Weapon_Sensory(ref activeUnit_0);
			weapon_Sensory.strategyWrapper = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string name = xmlNode.Name;
					if (Operators.CompareString(name, "ObeysEMCON", TextCompare: false) == 0 || Operators.CompareString(name, "ObE", TextCompare: false) == 0)
					{
						weapon_Sensory.Boolean_0 = Conversions.ToBoolean(xmlNode.InnerText);
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
			return weapon_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100990", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Weapon_Sensory result = new Weapon_Sensory(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Weapon_Sensory(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		Boolean_0 = false;
	}

	public void ActivateTerminalSensors()
	{
		Sensor[] sensors_Cached = GetParentWeapon().Sensors_Cached;
		Sensor[] array = sensors_Cached;
		foreach (Sensor sensor in array)
		{
			if (sensor.CanBeActive)
			{
				sensor.GoActive();
			}
		}
	}

	public override void HandleDetectedContact_OnGrid(ActiveUnit activeUnit_0, Side side_0, Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> tuple_0, bool bool_0 = false)
	{
		Contact item = tuple_0.Item1;
		ActiveUnit item3 = tuple_0.Item2;
		List<Sensor> item4 = tuple_0.Item3;
		float item5 = tuple_0.Item4;
		_ = tuple_0.Item5;
		try
		{
			if (((Weapon_CommStuff)activeUnit_0.CommStuff).CanSendDataToParent)
			{
				base.HandleDetectedContact_OnGrid(activeUnit_0, side_0, tuple_0, bool_0);
				return;
			}
			Contact contact_ = null;
			Contact[] targets_ReadOnly = activeUnit_0.AI.Targets_ReadOnly;
			Weapon weapon = (Weapon)activeUnit_0;
			ObservableDictionary<int, EmissionContainer> detectedEmissions = item.DetectedEmissions;
			bool flag = false;
			if (weapon.ValidTargets.Radar)
			{
				flag = true;
			}
			else
			{
				foreach (Sensor item6 in item4)
				{
					if (ActiveUnit_Sensory.DetectionIsPrecise(item6, Module_Unit.RangeToUnit_Horiz(item6.ParentPlatform, item)))
					{
						flag = true;
						break;
					}
				}
			}
			bool flag2 = false;
			for (int i = targets_ReadOnly.Count() - 1; i >= 0; i += -1)
			{
				if (targets_ReadOnly[i].ActualUnit == item3)
				{
					flag2 = true;
					if (flag || targets_ReadOnly[i].RemainingContinousTrackTime_Precise > 0f)
					{
						targets_ReadOnly[i].IsPreciselyLocatedOnThisPulse = true;
					}
					ActiveUnit_Sensory.UpdateContactData(ref strategyWrapper, ref targets_ReadOnly[i], item3, bool_0: false);
					ActiveUnit_Sensory.MergeDetectedEmissions(targets_ReadOnly[i], detectedEmissions);
					contact_ = targets_ReadOnly[i];
					break;
				}
			}
			if (!flag2)
			{
				contact_ = new Contact(item3);
				if (flag)
				{
					contact_.IsPreciselyLocatedOnThisPulse = true;
				}
				ActiveUnit_Sensory.UpdateContactData(ref strategyWrapper, ref contact_, item3, bool_0: true);
				if (detectedEmissions.Count > 0)
				{
					contact_.DetectedEmissions = detectedEmissions;
				}
			}
			Contact primaryTarget = strategyWrapper.AI.PrimaryTarget;
			if (!weapon.Is_LOAL_capable && primaryTarget != null && primaryTarget.ActualUnit != null && Operators.CompareString(primaryTarget.ActualUnit.ObjectID, contact_.ActualUnit.ObjectID, TextCompare: false) == 0 && !primaryTarget.ActualUnit.IsFixedFacility)
			{
				strategyWrapper.AI.PrimaryTarget = contact_;
			}
			if (item5 < 5f)
			{
				foreach (Sensor item7 in item4)
				{
					contact_.RemainingContinousTrackTime = Math.Max(contact_.RemainingContinousTrackTime, 15f);
				}
				if (primaryTarget != null && primaryTarget.ActualUnit != null && Operators.CompareString(primaryTarget.ActualUnit.ObjectID, contact_.ActualUnit.ObjectID, TextCompare: false) == 0)
				{
					foreach (Sensor item8 in item4)
					{
						contact_.RemainingContinousTrackTime = Math.Max(contact_.RemainingContinousTrackTime, 15f);
						if (ActiveUnit_Sensory.DetectionIsPrecise(item8, Module_Unit.RangeToUnit_Slant(item8.ParentPlatform, contact_)))
						{
							contact_.RemainingContinousTrackTime_Precise = Math.Max(contact_.RemainingContinousTrackTime_Precise, 15f);
						}
					}
				}
			}
			else
			{
				foreach (Sensor item9 in item4)
				{
					contact_.RemainingContinousTrackTime = Math.Max(contact_.RemainingContinousTrackTime, item9.ScanInterval);
				}
				if (primaryTarget != null && primaryTarget.ActualUnit != null && Operators.CompareString(primaryTarget.ActualUnit.ObjectID, contact_.ActualUnit.ObjectID, TextCompare: false) == 0)
				{
					foreach (Sensor item10 in item4)
					{
						contact_.RemainingContinousTrackTime = Math.Max(contact_.RemainingContinousTrackTime, item10.ScanInterval);
						if (ActiveUnit_Sensory.DetectionIsPrecise(item10, Module_Unit.RangeToUnit_Slant(item10.ParentPlatform, contact_)))
						{
							contact_.RemainingContinousTrackTime_Precise = Math.Max(contact_.RemainingContinousTrackTime_Precise, item10.ScanInterval);
						}
					}
				}
			}
			if (item4.Count != 0)
			{
				foreach (Sensor item2 in item4)
				{
					if (item2.Capabilities.HeadingInfo)
					{
						contact_.HeadingIsKnown = true;
					}
					if (item2.Capabilities.SpeedInfo)
					{
						contact_.SpeedIsKnown = true;
					}
					if (item2.Capabilities.AltitudeInfo || (item2.IsSonar && item2.IsActive))
					{
						contact_.AltitudeIsKnown = true;
					}
				}
			}
			if (primaryTarget != null && (primaryTarget.ActualUnit == null || ActiveUnit_Sensory.ContactsAreOfSameActualUnit(primaryTarget, contact_)) && activeUnit_0.Navigator.HasPlottedCourse())
			{
				activeUnit_0.Navigator.ClearPlottedCourse();
			}
			if (weapon.ValidTargets.Radar)
			{
				if (weapon.ARM_SpecifiedEmissionIsMandatory)
				{
					bool flag3 = false;
					foreach (int key in contact_.DetectedEmissions.Keys)
					{
						if (key == weapon.ARM_SpecifiedEMission.Key)
						{
							flag3 = true;
							if (!Information.IsNothing(primaryTarget) && contact_ == primaryTarget)
							{
								weapon.ARM_SpecifiedEMission.Value.Age = 0f;
								weapon.ARM_SpecifiedEMission.Value.IsIllumination = contact_.DetectedEmissions[key].IsIllumination;
							}
						}
					}
					if (flag3)
					{
						activeUnit_0.AI.TargetThisContact(contact_, bool_0: false, bool_1: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
				else
				{
					activeUnit_0.AI.TargetThisContact(contact_, bool_0: false, bool_1: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
					ObservableDictionary<int, EmissionContainer> detectedEmissions2 = item.DetectedEmissions;
					Side unitSide = weapon.GetUnitSide();
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					if (weapon.ARM_DetermineEmissionToTrack(detectedEmissions2, unitSide, item, bool_0: false, ref lockRandom_))
					{
						weapon.ARM_SpecifiedEmissionIsMandatory = true;
					}
				}
				return;
			}
			Weapon obj = (Weapon)strategyWrapper;
			ActiveUnit activeUnit_ = strategyWrapper;
			bool? nullable_ = null;
			if (obj.QueryReponse(activeUnit_, ref contact_, ref nullable_))
			{
				strategyWrapper.AI.TargetThisContact(contact_, bool_0: false, bool_1: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
				if (Operators.CompareString(strategyWrapper.Message, strategyWrapper.Name + " locked on target  " + item3.Name, TextCompare: false) != 0)
				{
					strategyWrapper.AddMessage(strategyWrapper.Name + " locked on target  " + item3.Name, strategyWrapper.Name + " targeted " + item3.Name, LoggedMessage.MessageType.WeaponLogic, 1, bool_0: false, new Geopoint_Struct(item3.GetLongitude(), contact_.GetLatitude()));
					strategyWrapper.Message = strategyWrapper.Name + " locked on target  " + item3.Name;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100989", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void HandleDetections_OnGrid()
	{
		bool flag = false;
		ActiveUnit activeUnit = null;
		if (strategyWrapper.IsWeapon)
		{
			activeUnit = ((Weapon)strategyWrapper).DataLinkParent;
			if (!Information.IsNothing(activeUnit) && !activeUnit.CommStuff.IsConnectedToSideNetwork)
			{
				flag = true;
			}
		}
		if (flag)
		{
			if (!Information.IsNothing(_TokenWrapper) && _TokenWrapper.Count > 0)
			{
				if (Information.IsNothing(activeUnit.Sensory._TokenWrapper))
				{
					activeUnit.Sensory._TokenWrapper = new ConcurrentQueue<Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>>>();
				}
				foreach (Tuple<Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>> item in _TokenWrapper)
				{
					if (!Information.IsNothing(item))
					{
						activeUnit.Sensory._TokenWrapper.Enqueue(item);
					}
				}
			}
			if (_IndexerWrapper != null && _IndexerWrapper.Count > 0)
			{
				if (activeUnit.Sensory._IndexerWrapper == null)
				{
					activeUnit.Sensory._IndexerWrapper = new ConcurrentQueue<string>();
				}
				foreach (string item2 in _IndexerWrapper)
				{
					if (item2 != null)
					{
						activeUnit.Sensory._IndexerWrapper.Enqueue(item2);
					}
				}
			}
			if (m_PublisherWrapper != null && m_PublisherWrapper.Count > 0)
			{
				if (activeUnit.Sensory.m_PublisherWrapper == null)
				{
					activeUnit.Sensory.m_PublisherWrapper = new TDictionary<long, LoggedMessage>();
				}
				foreach (KeyValuePair<long, LoggedMessage> item3 in m_PublisherWrapper)
				{
					activeUnit.Sensory.m_PublisherWrapper.Add(item3.Key, item3.Value);
				}
				m_PublisherWrapper.Clear();
			}
			activeUnit.Sensory.HandleDetections_OffGrid();
		}
		else
		{
			base.HandleDetections_OnGrid();
		}
	}
}
