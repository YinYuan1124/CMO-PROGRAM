using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using CSMaterial;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_AI
{
	public enum SubmarineDepthPreset : byte
	{
		None,
		Periscope,
		Shallow,
		OverLayer,
		UnderLayer,
		MaxDepth,
		Surface,
		Custom
	}

	public enum AircraftAltitudePreset : byte
	{
		None,
		MinAltitude,
		Low1000,
		Low2000,
		const_4,
		const_5,
		const_6,
		MaxAltitude,
		Custom
	}

	public enum WithdrawReason
	{
		HighDamage,
		LowFuel,
		LowAttackAmmo,
		LowDefenceAmmo
	}

	public sealed class TargetingEntry
	{
		public enum _TargetingBehavior : short
		{
			NotTargeted = -1,
			AutoTargeted,
			ManualWeaponAlloc,
			ManualTargeted
		}

		private _TargetingBehavior _ValComparator;

		public Contact Target;

		public double RangeToTarget_Angular;

		public float TimeSinceRangeEvaluation;

		public double TargetLatitude_LastRangeEvaluation;

		public double TargetLongitude_LastRangeEvaluation;

		public _TargetingBehavior Behavior
		{
			get
			{
				return _ValComparator;
			}
			set
			{
				_ValComparator = value;
			}
		}

		public string ToXML(Side side_0)
		{
			try
			{
				if (Target == null)
				{
					return null;
				}
				if (_CollectionWrapper == null)
				{
					_CollectionWrapper = new StringBuilder();
				}
				else
				{
					_CollectionWrapper.Clear();
				}
				_CollectionWrapper.Append("<TE>");
				if (_ValComparator != 0)
				{
					StringBuilder stringBuilder = _CollectionWrapper.Append("<BHVR>");
					short valComparator = (short)_ValComparator;
					stringBuilder.Append(valComparator.ToString()).Append("</BHVR>");
				}
				if (Target.ActualUnit != null && side_0 != null && side_0.Contacts.ContainsKey(Target.ActualUnit.ObjectID))
				{
					_CollectionWrapper.Append("<TGT>").Append(Target.ObjectID).Append("</TGT>");
				}
				else
				{
					_CollectionWrapper.Append("<TGT>");
					_CollectionWrapper.Append(Target.ToXML(null, side_0));
					_CollectionWrapper.Append("</TGT>");
				}
				_CollectionWrapper.Append("</TE>");
				return _CollectionWrapper.ToString();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100069", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}

		public static TargetingEntry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
		{
			try
			{
				TargetingEntry targetingEntry = new TargetingEntry();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode_ = (XmlNode)enumerator.Current;
						switch (xmlNode_.Name)
						{
						case "Target":
						case "TGT":
							if (xmlNode_.InnerText.StartsWith("ActivationPoint_"))
							{
								targetingEntry.Target = ActivationPointContact.FromString(xmlNode_.ChildNodes[0].ChildNodes[0].InnerText);
							}
							else if (xmlNode_.InnerText.StartsWith("Aimpoint_"))
							{
								targetingEntry.Target = AimpointContact.FromString(xmlNode_.ChildNodes[0].ChildNodes[0].InnerText);
							}
							else if (xmlNode_.ChildNodes.Count <= 1)
							{
								targetingEntry.Target = Contact.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
							}
							else
							{
								targetingEntry.Target = Contact.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							}
							break;
						case "Behavior":
						case "BHVR":
							if (Versioned.IsNumeric(xmlNode_.InnerText))
							{
								targetingEntry._ValComparator = (_TargetingBehavior)Conversions.ToShort(xmlNode_.InnerText);
							}
							else
							{
								targetingEntry._ValComparator = (_TargetingBehavior)Enum.Parse(typeof(_TargetingBehavior), xmlNode_.InnerText, ignoreCase: true);
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
				return targetingEntry;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100070", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				TargetingEntry result = new TargetingEntry();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	protected class PersistentManeuver
	{
		public enum TurnDirection : byte
		{
			Nearest = 0,
			Left = 1,
			Right = 2,
			Port = 1,
			Starboard = 2
		}

		public ActiveUnit MyUnit;

		public Contact TargetContact;

		public float OriginalRange;

		public float DesiredHeading;

		public float DesiredAltitude;

		public ActiveUnit.Throttle DesiredThrottle;

		public TurnDirection Direction;

		public PersistentManeuver()
		{
		}

		public PersistentManeuver(ActiveUnit activeUnit_0, Contact contact_0, float float_0)
		{
			MyUnit = activeUnit_0;
			TargetContact = contact_0;
			OriginalRange = float_0;
		}
	}

	[CompilerGenerated]
	private sealed class PoolDecoratorEntry
	{
		public Aircraft Local_theTanker;

		public Func<Aircraft, bool> _003C_003E9__0;

		internal bool EnableInterruptibleMock(Aircraft theAC)
		{
			return theAC != Local_theTanker;
		}
	}

	[CompilerGenerated]
	private sealed class PublisherRegistryFilter
	{
		public List<Contact> Local_tempList;

		internal bool ChangeInterruptibleMock(Tuple<int, Contact> theContact)
		{
			return Local_tempList.Contains(theContact.Item2);
		}
	}

	[CompilerGenerated]
	private sealed class ServerRegistryFilter
	{
		public ActiveUnit myUnit;

		internal double InitInterruptibleMock(Contact theC0)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC0);
		}

		internal double CheckInterruptibleMock(Contact theC0)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC0);
		}

		internal double ConcatInterruptibleMock(Contact theC0)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC0);
		}

		internal double InterruptInterruptibleMock(Contact theC0)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC0);
		}

		internal double RemoveInterruptibleMock(Contact theC0)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC0);
		}

		internal double FindInterruptibleMock(Contact theC0)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC0);
		}
	}

	[CompilerGenerated]
	private sealed class ModelObjectListener
	{
		public bool isInsidePatrolArea_10nmBuffer;

		public ConcurrentQueue<Contact> concurrentQueue;

		public ServerRegistryFilter CS_0024_003C_003E8__locals1;

		internal void SetInterruptibleMock(Contact theC)
		{
			if (theC == null)
			{
				return;
			}
			ActiveUnit_AI aI = CS_0024_003C_003E8__locals1.myUnit.AI;
			Mission mission_ = CS_0024_003C_003E8__locals1.myUnit.AssignedMissionOrPackage();
			Doctrine._UseShootTourists? shootTourists = CS_0024_003C_003E8__locals1.myUnit.Doctrine.GetShootTourists(CS_0024_003C_003E8__locals1.myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			bool bool_ = isInsidePatrolArea_10nmBuffer;
			string string_ = "";
			int int_ = 0;
			if (aI.ContactIsRelevantToMission(theC, mission_, shootTourists, bool_0: false, bool_, bool_2: true, null, ref string_, ref int_) && CS_0024_003C_003E8__locals1.myUnit.AI.IsClearedToEngageThisTarget(theC))
			{
				ActiveUnit_Weaponry weaponry = CS_0024_003C_003E8__locals1.myUnit.Weaponry;
				Doctrine doctrine = CS_0024_003C_003E8__locals1.myUnit.Doctrine;
				string_ = "";
				int_ = 0;
				if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_))
				{
					concurrentQueue.Enqueue(theC);
				}
			}
		}

		internal void FillInterruptibleMock(Contact theC)
		{
			if (theC != null)
			{
				ActiveUnit_Weaponry weaponry = CS_0024_003C_003E8__locals1.myUnit.Weaponry;
				Doctrine doctrine = CS_0024_003C_003E8__locals1.myUnit.Doctrine;
				string string_ = "";
				int int_ = 0;
				if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_) && CS_0024_003C_003E8__locals1.myUnit.AI.ContactIsThreatToMissionUnits(theC))
				{
					concurrentQueue.Enqueue(theC);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class TaskRuleWatcher
	{
		public ConcurrentQueue<Contact> concurrentQueue2;

		public ModelObjectListener CS_0024_003C_003E8__locals2;

		internal void CalculateInterruptibleMock(Contact theC)
		{
			if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
			{
				ActiveUnit_AI aI = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.AI;
				Mission mission_ = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.AssignedMissionOrPackage();
				Doctrine._UseShootTourists? shootTourists = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.Doctrine.GetShootTourists(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool isInsidePatrolArea_10nmBuffer = CS_0024_003C_003E8__locals2.isInsidePatrolArea_10nmBuffer;
				string string_ = "";
				int int_ = 0;
				if (aI.ContactIsRelevantToMission(theC, mission_, shootTourists, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_, ref int_))
				{
					concurrentQueue2.Enqueue(theC);
				}
			}
		}

		internal void PopInterruptibleMock(Contact theC)
		{
			if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
			{
				ActiveUnit_Weaponry weaponry = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.Weaponry;
				Doctrine doctrine = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.Doctrine;
				string string_ = "";
				int int_ = 0;
				if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_) && CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.AI.ContactIsThreatToMissionUnits(theC))
				{
					concurrentQueue2.Enqueue(theC);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class WrapperComparator
	{
		public TList<Contact> tList;

		public ModelObjectListener CS_0024_003C_003E8__locals3;

		internal void InstantiateInterruptibleMock(Contact theC)
		{
			if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
			{
				ActiveUnit_AI aI = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.AI;
				Mission mission_ = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.AssignedMissionOrPackage();
				Doctrine._UseShootTourists? shootTourists = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.Doctrine.GetShootTourists(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool isInsidePatrolArea_10nmBuffer = CS_0024_003C_003E8__locals3.isInsidePatrolArea_10nmBuffer;
				string string_ = "";
				int int_ = 0;
				if (aI.ContactIsRelevantToMission(theC, mission_, shootTourists, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_, ref int_))
				{
					tList.Add(theC);
				}
			}
		}

		internal void CreateInterruptibleMock(Contact theC)
		{
			ActiveUnit_Weaponry weaponry = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.Weaponry;
			Doctrine doctrine = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.Doctrine;
			string string_ = "";
			int int_ = 0;
			if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_) && CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.myUnit.AI.ContactIsThreatToMissionUnits(theC))
			{
				tList.Add(theC);
			}
		}
	}

	[CompilerGenerated]
	private sealed class ObserverComparator
	{
		public ConcurrentQueue<Contact> concurrentQueue3;

		public ModelObjectListener CS_0024_003C_003E8__locals4;

		internal void CompareInterruptibleMock(Contact theC)
		{
			if (theC.GetStance(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.GetUnitSide()) == Misc.PostureStance.Unfriendly)
			{
				ActiveUnit_AI aI = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.AI;
				Mission mission_ = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.AssignedMissionOrPackage();
				Doctrine._UseShootTourists? shootTourists = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.Doctrine.GetShootTourists(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool isInsidePatrolArea_10nmBuffer = CS_0024_003C_003E8__locals4.isInsidePatrolArea_10nmBuffer;
				string string_ = "";
				int int_ = 0;
				if (aI.ContactIsRelevantToMission(theC, mission_, shootTourists, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_, ref int_))
				{
					concurrentQueue3.Enqueue(theC);
				}
			}
		}

		internal void ReadInterruptibleMock(Contact theC)
		{
			if (theC.GetStance(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.GetUnitSide()) == Misc.PostureStance.Unfriendly)
			{
				ActiveUnit_Weaponry weaponry = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.Weaponry;
				Doctrine doctrine = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.Doctrine;
				string string_ = "";
				int int_ = 0;
				if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_) && CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.myUnit.AI.ContactIsThreatToMissionUnits(theC))
				{
					concurrentQueue3.Enqueue(theC);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class MethodConfigObject
	{
		public TList<Contact> tList2;

		public ModelObjectListener CS_0024_003C_003E8__locals5;

		internal void DisableInterruptibleMock(Contact theC)
		{
			if (theC.GetStance(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.GetUnitSide()) == Misc.PostureStance.Unfriendly)
			{
				ActiveUnit_AI aI = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.AI;
				Mission mission_ = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.AssignedMissionOrPackage();
				Doctrine._UseShootTourists? shootTourists = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.Doctrine.GetShootTourists(CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool isInsidePatrolArea_10nmBuffer = CS_0024_003C_003E8__locals5.isInsidePatrolArea_10nmBuffer;
				string string_ = "";
				int int_ = 0;
				if (aI.ContactIsRelevantToMission(theC, mission_, shootTourists, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_, ref int_))
				{
					tList2.Add(theC);
				}
			}
		}

		internal void UpdateInterruptibleMock(Contact theC)
		{
			ActiveUnit_Weaponry weaponry = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.Weaponry;
			Doctrine doctrine = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.Doctrine;
			string string_ = "";
			int int_ = 0;
			if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_) && CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1.myUnit.AI.ContactIsThreatToMissionUnits(theC))
			{
				tList2.Add(theC);
			}
		}
	}

	[CompilerGenerated]
	private sealed class IssuerComparator
	{
		public ActiveUnit myUnit;

		public float theWingmanEngageDistance;

		internal double InsertInterruptibleMock(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC);
		}
	}

	[CompilerGenerated]
	private sealed class TaskDecoratorEntry
	{
		public ActiveUnit activeUnit;

		public IssuerComparator CS_0024_003C_003E8__locals1;

		internal bool PrepareInterruptibleMock(Contact theC)
		{
			if (theC != null)
			{
				return activeUnit != null;
			}
			return false;
		}

		internal double ReflectInterruptibleMock(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(activeUnit, theC);
		}

		internal bool VisitInterruptibleMock(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz(activeUnit, theC) <= CS_0024_003C_003E8__locals1.theWingmanEngageDistance;
		}
	}

	[CompilerGenerated]
	private sealed class DecoratorConfigManager
	{
		public List<ActiveUnit> otherUnits;

		public Contact contact;

		public TaskDecoratorEntry CS_0024_003C_003E8__locals2;

		internal void RestartInterruptibleMock(Contact theContact, ParallelLoopState loopstate)
		{
			Weapon weapon = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(theContact);
			if (weapon != null && CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.AI.PatrolAndEscortLogic_Wingman_ShouldEngage(theContact, otherUnits))
			{
				float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit, theContact, bool_0: true, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.myUnit.Doctrine, bool_1: false);
				if (Math.Max((double)maxRangeForThisTarget * 1.2, maxRangeForThisTarget + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.theWingmanEngageDistance) > (double)Math2.VerifyClass(CS_0024_003C_003E8__locals2.activeUnit.GetLatitude(), CS_0024_003C_003E8__locals2.activeUnit.GetLongitude(), theContact.GetLatitude(), theContact.GetLongitude()))
				{
					contact = theContact;
					loopstate.Stop();
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class ClientComparator
	{
		public ActiveUnit_AI _003C_003E4__this;

		public float elapsedTime;

		internal void TestInterruptibleMock()
		{
			_003C_003E4__this.InstantiateClient(elapsedTime, bool_0: true);
		}
	}

	[CompilerGenerated]
	private sealed class ServiceConfigObject
	{
		public ActiveUnit_AI _003C_003E4__this;

		public ActiveUnit_AI Me;

		public Func<Module_Unit.Unit, float> _003C_003E9__3;

		internal bool StopInterruptibleMock(UnguidedWeapon theW)
		{
			if (theW.GetUnitSide() != _003C_003E4__this.m_EventVal.GetUnitSide())
			{
				return Module_Side.IsAlliedWithThisSide(_003C_003E4__this.m_EventVal.GetUnitSide(), theW.GetUnitSide());
			}
			return true;
		}

		internal float CancelInterruptibleMock(Module_Unit.Unit x)
		{
			return Module_Unit.RangeToPoint_Slant(_003C_003E4__this.m_EventVal, x.GetLatitude(), x.GetLongitude(), x.GetCurrentAltitude());
		}
	}

	[CompilerGenerated]
	private sealed class DicComparator
	{
		public Contact Local_theTarget;

		public ServiceConfigObject CS_0024_003C_003E8__locals1;

		public Func<KeyValuePair<string, FiringProposal>, bool> _003C_003E9__6;

		internal bool VerifyInterruptibleMock(KeyValuePair<string, FiringProposal> x)
		{
			return (Operators.CompareString(x.Value.FiringUnit.ObjectID, CS_0024_003C_003E8__locals1.Me.m_EventVal.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(x.Value.Target.ObjectID, Local_theTarget.ObjectID, TextCompare: false) == 0);
		}
	}

	[CompilerGenerated]
	private sealed class ProcessConfigManager
	{
		public bool Local_ShouldDropMines;

		public DicComparator CS_0024_003C_003E8__locals2;

		internal void ListInterruptibleMock(UnguidedWeapon theMine, ParallelLoopState loopstate)
		{
			if ((double)Module_Unit.RangeToUnit_Horiz(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.m_EventVal, theMine) < (double)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.m_EventVal.GetSafeDistanceAgainstKnownMineType_meters(theMine.Type, bool_0: false) / 1852.0)
			{
				Local_ShouldDropMines = false;
				loopstate.Stop();
				return;
			}
			if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo == null)
			{
				return;
			}
			double num;
			double? num2;
			if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo.LastMineLocal != null)
			{
				num = Module_Unit.RangeToPoint_Horiz(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.m_EventVal, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo.LastMineLocal);
				num2 = (double?)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo.Spacing / 1852.0;
				if ((num2.HasValue ? new bool?(num < num2.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					goto IL_0248;
				}
			}
			if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo.LastMineSet == null)
			{
				return;
			}
			num = Module_Unit.RangeToPoint_Horiz(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.m_EventVal, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo.LastMineSet);
			num2 = (double?)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.MiningInfo.SpacingSet / 1852.0;
			if (!(num2.HasValue ? new bool?(num < num2.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				return;
			}
			goto IL_0248;
			IL_0248:
			Local_ShouldDropMines = false;
			loopstate.Stop();
		}
	}

	[CompilerGenerated]
	private sealed class ObjectMerchantPage
	{
		public Weapon Local_theWeaponCANDIDATE;

		public Func<Weapon, bool> _003C_003E9__5;

		internal bool ResolveInterruptibleMock(Weapon x)
		{
			return x.DBID == Local_theWeaponCANDIDATE.DBID;
		}
	}

	[CompilerGenerated]
	private sealed class FilterDecoratorEntry
	{
		public ActiveUnit_AI _003C_003E4__this;

		public Doctrine doctrine;

		internal float PostInterruptibleMock(Weapon theWeapon)
		{
			return theWeapon.GetMaxRangeForThisTarget(_003C_003E4__this.m_EventVal, _003C_003E4__this.PrimaryTarget, bool_0: true, doctrine, bool_1: false);
		}
	}

	internal ActiveUnit m_EventVal;

	protected Contact _PrimaryTarget;

	protected Contact_Base.ContactType _PrimaryTarget_Type;

	public double PrimaryTarget_LastKnown_Lat;

	public double PrimaryTarget_LastKnown_Lon;

	public float PrimaryTarget_LastKnown_Altitude;

	protected Contact _PrimaryThreat;

	protected HashSet<string> PickupTargets;

	public string EscortTargetID;

	public float TimeToNextTargetsEvaluation;

	public float TimeToNextThreatEvaluation;

	public float? TimeToNextSpeedAdjustmentForToTEvaluation;

	protected bool PrimaryTargetOverrideExists;

	[CompilerGenerated]
	[AccessedThroughProperty("_TargetList")]
	private ObservableDictionary<string, TargetingEntry> globalVal;

	protected List<Contact> _Threats;

	protected bool _FerryCycleLegIsOutbound;

	protected GeoPoint _LastKnownTargetLocation;

	protected bool _TerrainFollowing;

	protected float? SnakeAxis;

	protected int MaxSnakeAngle;

	public Geopoint_Struct NavDestination;

	public bool IsEscort;

	public bool HasCaughtUpWithGroup;

	public bool HoldPosition;

	public GeoPoint RaceTrackPoint;

	protected bool PathBlockCheckInProgress;

	public bool CalculatedDesiredPitchThisPulse;

	private List<Contact> m_WorkerVal;

	internal Tuple<Contact, Misc.PostureStance>[] m_AccountVal;

	public TargetingEntry[] TargetsSortedByRange;

	public bool IsPerformingSpeedAdjustmentToT;

	public float? SpeedAdjustmentToT_OriginalSpeed;

	public float? SpeedAdjustmentToT_OriginalSpeedOverride;

	public ActiveUnit.Throttle? SpeedAdjustmentToT_OriginalThrottle;

	public ActiveUnit_Kinematics.UnitThrottlePreset? SpeedAdjustmentToT_OriginalThrottlePreset;

	public bool LeadMustSlowDownDueToBingo;

	public bool EvaluateTargets_Enabled;

	public bool DeterminePrimaryTarget_Enabled;

	public bool CheckPossibleABMOrASATEngagement;

	public Module_Unit.Unit WeaponThreat;

	public MiningMission.MiningInformation MiningInfo;

	protected PersistentManeuver EvasionManeuver;

	private object _StateVal;

	protected ActiveUnit _PrimaryPickupTarget;

	private Contact[] _AuthenticationVal;

	private TargetingEntry[] _ParamsVal;

	private double infoVal;

	private double helperVal;

	private Contact m_MapperVal;

	private Contact m_ManagerVal;

	private Contact getterVal;

	private Contact _ProducerVal;

	private float? procVal;

	private float? structWrapper;

	private float? m_MerchantWrapper;

	private float? callbackWrapper;

	private List<TargetingEntry> m_DecoratorWrapper;

	private List<TargetingEntry> processWrapper;

	private TargetingEntry m_ThreadWrapper;

	[ThreadStatic]
	private Dictionary<Contact, int> _RuleWrapper;

	[ThreadStatic]
	private static StringBuilder _CollectionWrapper;

	private List<(double, double, float, short)> m_InstanceWrapper;

	public static float TorpedoEvasionEmergencyRange;

	public static float TorpedoEvasionCloseRange;

	protected virtual ObservableDictionary<string, TargetingEntry> _TargetList
	{
		[CompilerGenerated]
		get
		{
			return globalVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, TargetingEntry>.DictionaryChangedEventHandler val = ReflectClient;
			ObservableDictionary<string, TargetingEntry> val2 = globalVal;
			if (val2 != null)
			{
				val2.DictionaryChanged -= val;
			}
			globalVal = value;
			val2 = globalVal;
			if (val2 != null)
			{
				val2.DictionaryChanged += val;
			}
		}
	}

	public GeoPoint LastKnownTargetLocation => _LastKnownTargetLocation;

	public virtual Contact PrimaryTarget
	{
		get
		{
			return _PrimaryTarget;
		}
		set
		{
			try
			{
				if (m_EventVal == null)
				{
					return;
				}
				if (value != _PrimaryTarget)
				{
					Contact primaryTarget = _PrimaryTarget;
					if (value != null)
					{
						try
						{
							if (m_EventVal == null)
							{
								return;
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 101190", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (m_EventVal != null && m_EventVal.Navigator != null && m_EventVal.Navigator.HasPathfindingPlottedCourse)
					{
						m_EventVal.Navigator.ClearPathfindingWaypoints();
					}
					_PrimaryTarget = value;
					if (value != null)
					{
						_PrimaryTarget_Type = value.Type;
					}
					if (primaryTarget != null)
					{
						m_EventVal.ParentScen.Cache_PrimaryTargetForWhichPlatforms.Remove(primaryTarget.ObjectID);
					}
					if (value != null)
					{
						m_EventVal.ParentScen.Cache_PrimaryTargetForWhichPlatforms.Remove(value.ObjectID);
					}
				}
				if (value != null)
				{
					PrimaryTarget_LastKnown_Lat = value.GetLatitude();
					PrimaryTarget_LastKnown_Lon = value.GetLongitude();
					PrimaryTarget_LastKnown_Altitude = value.GetCurrentAltitude();
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100023", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual Contact PrimaryThreat
	{
		get
		{
			return _PrimaryThreat;
		}
		set
		{
			_PrimaryThreat = value;
		}
	}

	public virtual Contact_Base.ContactType PrimaryTarget_Type
	{
		get
		{
			return _PrimaryTarget_Type;
		}
		set
		{
			_PrimaryTarget_Type = value;
		}
	}

	internal ActiveUnit PrimaryPickupTarget
	{
		get
		{
			return _PrimaryPickupTarget;
		}
		set
		{
			try
			{
				_PrimaryPickupTarget = value;
				if (value == null && m_EventVal != null && m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.Navigator.PlottedCourse.Last().Type == Waypoint.WaypointType.PickupPoint)
				{
					m_EventVal.Navigator.ClearPlottedCourse();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 098764534", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual bool ConsidersToBeUnderAttack => false;

	public Contact[] Targets_ReadOnly
	{
		get
		{
			try
			{
				if (_AuthenticationVal == null || _AuthenticationVal.Count() == 0)
				{
					Contact[] authenticationVal = new Contact[0];
					if (_TargetList != null && _TargetList.Count > 0)
					{
						List<Contact> list = new List<Contact>();
						IEnumerator<KeyValuePair<string, TargetingEntry>> enumerator = _TargetList.GetEnumerator();
						while (enumerator.MoveNext())
						{
							TargetingEntry value = enumerator.Current.Value;
							if (value.Target != null)
							{
								list.Add(value.Target);
							}
						}
						authenticationVal = list.ToArray();
					}
					_AuthenticationVal = authenticationVal;
				}
				return _AuthenticationVal;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100024", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				_AuthenticationVal = new Contact[0];
				Contact[] authenticationVal2 = _AuthenticationVal;
				ProjectData.ClearProjectError();
				return authenticationVal2;
			}
		}
	}

	public TargetingEntry[] SortTargetsByRange_ReadOnly
	{
		get
		{
			TargetingEntry[] result = null;
			try
			{
				if (_TargetList != null)
				{
					_ParamsVal = CreateClient(_TargetList);
					m_MapperVal = null;
					m_ManagerVal = null;
					getterVal = null;
					_ProducerVal = null;
					procVal = null;
					structWrapper = null;
					m_MerchantWrapper = null;
					callbackWrapper = null;
					TargetingEntry[] paramsVal = _ParamsVal;
					TargetingEntry[] array = paramsVal;
					foreach (TargetingEntry targetingEntry in array)
					{
						if (targetingEntry.Target == null)
						{
							continue;
						}
						if (targetingEntry.Target.IsAir_Missile_Orbital_Contact)
						{
							if (m_MapperVal == null)
							{
								m_MapperVal = targetingEntry.Target;
							}
						}
						else if (targetingEntry.Target.IsShipContact)
						{
							if (Information.IsNothing(m_ManagerVal))
							{
								m_ManagerVal = targetingEntry.Target;
							}
						}
						else if (targetingEntry.Target.ActualUnit != null && targetingEntry.Target.ActualUnit.IsFacility && ((Facility)targetingEntry.Target.ActualUnit).Category == Facility._FacilityCategory.Water_Surface)
						{
							if (Information.IsNothing(m_ManagerVal))
							{
								m_ManagerVal = targetingEntry.Target;
							}
						}
						else if (targetingEntry.Target.IsSubmergedContact)
						{
							if (getterVal == null)
							{
								getterVal = targetingEntry.Target;
							}
						}
						else if (targetingEntry.Target.IsLandContact && _ProducerVal == null)
						{
							_ProducerVal = targetingEntry.Target;
						}
						targetingEntry.TargetLatitude_LastRangeEvaluation = targetingEntry.Target.GetLatitude();
						targetingEntry.TargetLongitude_LastRangeEvaluation = targetingEntry.Target.GetLongitude();
					}
					infoVal = m_EventVal.GetLatitude();
					helperVal = m_EventVal.GetLongitude();
				}
				if (m_MapperVal != null)
				{
					procVal = Module_Unit.RangeToUnit_Slant(m_EventVal, m_MapperVal);
				}
				if (m_ManagerVal != null)
				{
					structWrapper = Module_Unit.RangeToUnit_Slant(m_EventVal, m_ManagerVal);
				}
				if (getterVal != null)
				{
					m_MerchantWrapper = Module_Unit.RangeToUnit_Slant(m_EventVal, getterVal);
				}
				if (_ProducerVal != null)
				{
					callbackWrapper = Module_Unit.RangeToUnit_Slant(m_EventVal, _ProducerVal);
				}
				result = _ParamsVal;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101271", "");
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

	public List<Contact> Threats_ReadOnly => _Threats;

	public bool IsAssignedToMission
	{
		get
		{
			if (m_EventVal.AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (m_EventVal.AssignedTaskPool == null)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsInsidePatrolArea_2nmBuffer
	{
		get
		{
			if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
			{
				return false;
			}
			if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				if (m_EventVal.Navigator.DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsInsidePatrolArea_10nmBuffer
	{
		get
		{
			if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
			{
				return false;
			}
			if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				if (m_EventVal.Navigator.DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_10nm_Buffered, ref patrol.PatrolArea_10nm_ChangeCheck, 10, bool_1: false, bool_2: false))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsInsidePatrolArea_NoBuffer
	{
		get
		{
			if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
			{
				return false;
			}
			if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				ActiveUnit_Navigator navigator = m_EventVal.Navigator;
				ref List<ReferencePoint> patrolArea = ref patrol.PatrolArea;
				List<ReferencePoint> list_ = null;
				if (navigator.DisableDic(ref patrolArea, ref list_, ref patrol.PatrolArea_ChangeCheck, 0, bool_1: false, bool_2: false))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool MayTargetNonAUs
	{
		get
		{
			if (m_EventVal.IsMCMPlatform)
			{
				return true;
			}
			return false;
		}
	}

	public bool FerryCycleLegIsOutbound => _FerryCycleLegIsOutbound;

	public bool IsAllowedToRedeploy_Damage
	{
		get
		{
			Doctrine._DamageThreshold? redeployDamageThreshold = m_EventVal.Doctrine.GetRedeployDamageThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			short? num = (short?)redeployDamageThreshold;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num = (short?)redeployDamageThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					if (m_EventVal.Damage.DamagePercent >= 5f)
					{
						return false;
					}
				}
				else
				{
					num = (short?)redeployDamageThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						if (m_EventVal.Damage.DamagePercent >= 25f)
						{
							return false;
						}
					}
					else
					{
						num = (short?)redeployDamageThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							if (m_EventVal.Damage.DamagePercent >= 50f)
							{
								return false;
							}
						}
						else
						{
							num = (short?)redeployDamageThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault() && m_EventVal.Damage.DamagePercent >= 75f)
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}
	}

	public bool IsAllowedToRedeploy_Fuel
	{
		get
		{
			Doctrine._FuelQuantityThreshold? redeployFuelThreshold = m_EventVal.Doctrine.GetRedeployFuelThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			short? num = (short?)redeployFuelThreshold;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num = (short?)redeployFuelThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					if (m_EventVal.GetIsBingoOrJoker(null, null) == ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						return false;
					}
				}
				else
				{
					num = (short?)redeployFuelThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						double double_ = 0.0;
						double double_2 = 0.0;
						if ((int)Math.Round(m_EventVal.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0) < 25)
						{
							return false;
						}
					}
					else
					{
						num = (short?)redeployFuelThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							double double_3 = 0.0;
							double double_4 = 0.0;
							if ((int)Math.Round(m_EventVal.FuelPercent(ref double_3, ref double_4, bool_0: false) * 100.0) < 50)
							{
								return false;
							}
						}
						else
						{
							num = (short?)redeployFuelThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								double double_5 = 0.0;
								double double_6 = 0.0;
								if ((int)Math.Round(m_EventVal.FuelPercent(ref double_5, ref double_6, bool_0: false) * 100.0) < 75)
								{
									return false;
								}
							}
							else
							{
								num = (short?)redeployFuelThreshold;
								double double_7 = 0.0;
								double double_8 = 0.0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault() && (int)Math.Round(m_EventVal.FuelPercent(ref double_7, ref double_8, bool_0: false) * 100.0) < 100)
								{
									return false;
								}
							}
						}
					}
				}
			}
			return true;
		}
	}

	public bool IsAllowedToRedeploy_AttackWeapon
	{
		get
		{
			try
			{
				Doctrine._WeaponQuantityThreshold? redeployAttackThreshold = m_EventVal.Doctrine.GetRedeployAttackThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				short? num = (short?)redeployAttackThreshold;
				if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					num = (short?)redeployAttackThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						Weapon primaryAttackWeapon_Default = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
						if (!Information.IsNothing(primaryAttackWeapon_Default) && m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default.DBID, bool_1: false) == 0)
						{
							return false;
						}
					}
					else
					{
						num = (short?)redeployAttackThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							Weapon primaryAttackWeapon_Default2 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
							if (!Information.IsNothing(primaryAttackWeapon_Default2))
							{
								int num4 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default2.DBID, bool_1: false);
								int num5 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default2.DBID);
								if (num4 == 0 || (double)num4 / (double)num5 < 0.25)
								{
									return false;
								}
							}
						}
						else
						{
							num = (short?)redeployAttackThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								Weapon primaryAttackWeapon_Default3 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
								if (!Information.IsNothing(primaryAttackWeapon_Default3))
								{
									int num6 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default3.DBID, bool_1: false);
									int num7 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default3.DBID);
									if (num6 == 0 || (double)num6 / (double)num7 < 0.5)
									{
										return false;
									}
								}
							}
							else
							{
								num = (short?)redeployAttackThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									Weapon primaryAttackWeapon_Default4 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
									if (!Information.IsNothing(primaryAttackWeapon_Default4))
									{
										int num8 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default4.DBID, bool_1: false);
										int num9 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default4.DBID);
										if (num8 == 0 || (double)num8 / (double)num9 < 0.75)
										{
											return false;
										}
									}
								}
								else
								{
									num = (short?)redeployAttackThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
									{
										Weapon primaryAttackWeapon_Default5 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
										if (!Information.IsNothing(primaryAttackWeapon_Default5))
										{
											int num10 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default5.DBID, bool_1: false);
											int num11 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default5.DBID);
											if (num10 == 0 || num10 != num11)
											{
												return false;
											}
										}
									}
									else
									{
										num = (short?)redeployAttackThreshold;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
										{
											foreach (WeaponRec item in m_EventVal.Weaponry.AllDistinctWeaponsAboard_Default_WeaponRecs(bool_1: false))
											{
												if (item.DefaultLoad == 0)
												{
													continue;
												}
												Weapon referenceWeapon = item.GetReferenceWeapon(m_EventVal.ParentScen);
												if (referenceWeapon.IsASuW_Land || referenceWeapon.IsASuW_Naval)
												{
													int num2 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(referenceWeapon.DBID, bool_1: false);
													int num3 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(referenceWeapon.DBID);
													if (num2 == 0 || num2 != num3)
													{
														return false;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101356", "");
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

	public bool IsAllowedToRedeploy_DefenceWeapon
	{
		get
		{
			try
			{
				Doctrine._WeaponQuantityThreshold? redeployDefenceThreshold = m_EventVal.Doctrine.GetRedeployDefenceThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				short? num = (short?)redeployDefenceThreshold;
				if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					num = (short?)redeployDefenceThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						Weapon primaryDefenceWeapon_Actual = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
						if (!Information.IsNothing(primaryDefenceWeapon_Actual) && m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual.DBID, bool_1: false) == 0)
						{
							return false;
						}
					}
					else
					{
						num = (short?)redeployDefenceThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							Weapon primaryDefenceWeapon_Actual2 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
							if (!Information.IsNothing(primaryDefenceWeapon_Actual2))
							{
								int num4 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual2.DBID, bool_1: false);
								int num5 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual2.DBID);
								if (num4 == 0 || (double)num4 / (double)num5 < 0.25)
								{
									return false;
								}
							}
						}
						else
						{
							num = (short?)redeployDefenceThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								Weapon primaryDefenceWeapon_Actual3 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
								if (!Information.IsNothing(primaryDefenceWeapon_Actual3))
								{
									int num6 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual3.DBID, bool_1: false);
									int num7 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual3.DBID);
									if (num6 == 0 || (double)num6 / (double)num7 < 0.5)
									{
										return false;
									}
								}
							}
							else
							{
								num = (short?)redeployDefenceThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									Weapon primaryDefenceWeapon_Actual4 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
									if (!Information.IsNothing(primaryDefenceWeapon_Actual4))
									{
										int num8 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual4.DBID, bool_1: false);
										int num9 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual4.DBID);
										if (num8 == 0 || (double)num8 / (double)num9 < 0.75)
										{
											return false;
										}
									}
								}
								else
								{
									num = (short?)redeployDefenceThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
									{
										Weapon primaryDefenceWeapon_Actual5 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
										if (!Information.IsNothing(primaryDefenceWeapon_Actual5))
										{
											int num10 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual5.DBID, bool_1: false);
											int num11 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual5.DBID);
											if (num10 == 0 || num10 != num11)
											{
												return false;
											}
										}
									}
									else
									{
										num = (short?)redeployDefenceThreshold;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
										{
											foreach (WeaponRec item in m_EventVal.Weaponry.AllDistinctWeaponsAboard_Default_WeaponRecs(bool_1: false))
											{
												if (item.DefaultLoad == 0)
												{
													continue;
												}
												Weapon referenceWeapon = item.GetReferenceWeapon(m_EventVal.ParentScen);
												if (referenceWeapon.IsAAW || referenceWeapon.IsASW)
												{
													int num2 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(referenceWeapon.DBID, bool_1: false);
													int num3 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(referenceWeapon.DBID);
													if (num2 == 0 || num2 != num3)
													{
														return false;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101357", "");
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

	public bool IsAllowedToRedeploy_AllChecks
	{
		get
		{
			if (IsAllowedToRedeploy_Damage)
			{
				if (IsAllowedToRedeploy_Fuel)
				{
					if (IsAllowedToRedeploy_AttackWeapon)
					{
						if (IsAllowedToRedeploy_DefenceWeapon)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	[SpecialName]
	internal List<Contact> PrintClient()
	{
		return m_WorkerVal;
	}

	[SpecialName]
	internal void DefineClient(List<Contact> list_0)
	{
		m_WorkerVal = list_0;
	}

	static ActiveUnit_AI()
	{
		TorpedoEvasionEmergencyRange = 2.5f;
		TorpedoEvasionCloseRange = 5f;
	}

	public void AddTargetList_Threadsafe(string string_0, TargetingEntry targetingEntry_0)
	{
		object stateVal = _StateVal;
		ObjectFlowControl.CheckForSyncLockOnValueType(stateVal);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(stateVal, ref lockTaken);
			_TargetList.Add(string_0, targetingEntry_0);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(stateVal);
			}
		}
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			if (PrimaryTarget != null)
			{
				xmlWriter_0.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
			}
			XmlWriter obj = xmlWriter_0;
			int primaryTarget_Type = (int)_PrimaryTarget_Type;
			obj.WriteElementString("PrimaryTarget_Type", primaryTarget_Type.ToString());
			if (_PrimaryThreat != null)
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
			xmlWriter_0.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			xmlWriter_0.WriteElementString("HPos", HoldPosition.ToString());
			xmlWriter_0.WriteElementString("FCLIO", _FerryCycleLegIsOutbound.ToString());
			if (!EvaluateTargets_Enabled)
			{
				xmlWriter_0.WriteElementString("ET_E", "False");
			}
			if (!DeterminePrimaryTarget_Enabled)
			{
				xmlWriter_0.WriteElementString("DPT_E", "False");
			}
			if (IsEscort)
			{
				xmlWriter_0.WriteElementString("IE", IsEscort.ToString());
			}
			if (_LastKnownTargetLocation != null)
			{
				xmlWriter_0.WriteStartElement("LKTL");
				xmlWriter_0.WriteRaw(_LastKnownTargetLocation.ToXML(hashSet_0));
				xmlWriter_0.WriteEndElement();
			}
			if (PrimaryPickupTarget != null)
			{
				xmlWriter_0.WriteElementString("PrimaryPickupTarget", _PrimaryPickupTarget.ObjectID);
			}
			if (_TargetList != null && _TargetList.Count > 0)
			{
				xmlWriter_0.WriteStartElement("TargetList");
				try
				{
					foreach (TargetingEntry value in _TargetList.Values)
					{
						xmlWriter_0.WriteRaw(value.ToXML(m_EventVal.GetUnitSide()));
						xmlWriter_0.Flush();
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
						xmlWriter_0.Flush();
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (SnakeAxis.HasValue)
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

	public static void FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_AI activeUnit_AI = new ActiveUnit_AI();
			activeUnit_AI.m_EventVal = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "PrimaryTarget":
						activeUnit_AI._PrimaryTarget = Contact.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						break;
					case "Threats":
						if (activeUnit_AI._Threats == null)
						{
							activeUnit_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								activeUnit_AI._Threats.Add(item);
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
						activeUnit_AI._PrimaryThreat = Contact.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						break;
					case "SnakeAxis":
						activeUnit_AI.SnakeAxis = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "IE":
						activeUnit_AI.IsEscort = true;
						break;
					case "LKTL":
						activeUnit_AI._LastKnownTargetLocation = GeoPoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
						break;
					case "DPT_E":
						activeUnit_AI.DeterminePrimaryTarget_Enabled = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TTNPTE":
						activeUnit_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "FerryCycleLegIsOutbound":
					case "FCLIO":
						activeUnit_AI._FerryCycleLegIsOutbound = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lat":
						FastDoubleParse.FastTryParseDouble(xmlNode_.InnerText, out activeUnit_AI.PrimaryTarget_LastKnown_Lat);
						break;
					case "PrimaryTarget_LastKnown_Lon":
						FastDoubleParse.FastTryParseDouble(xmlNode_.InnerText, out activeUnit_AI.PrimaryTarget_LastKnown_Lon);
						break;
					case "PrimaryPickupTarget":
						activeUnit_AI._PrimaryPickupTarget = ActiveUnit.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						break;
					case "TargetList":
						activeUnit_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
								activeUnit_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
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
					case "ET_E":
						activeUnit_AI.EvaluateTargets_Enabled = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "PTOE":
					case "PrimaryTargetOverrideExists":
						activeUnit_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "HP":
					case "HPos":
						activeUnit_AI.HoldPosition = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						activeUnit_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode_.InnerText);
						break;
					case "PrimaryTarget_Type":
						if (Versioned.IsNumeric(xmlNode_.InnerText))
						{
							activeUnit_AI._PrimaryTarget_Type = (Contact_Base.ContactType)Conversions.ToByte(xmlNode_.InnerText);
						}
						else
						{
							activeUnit_AI._PrimaryTarget_Type = (Contact_Base.ContactType)Enum.Parse(typeof(Contact_Base.ContactType), xmlNode_.InnerText, ignoreCase: true);
						}
						break;
					case "IgnorePlottedCourse":
					case "IPC":
					{
						bool num = Conversions.ToBoolean(xmlNode_.InnerText);
						if (!Information.IsNothing(activeUnit_0.Doctrine))
						{
							activeUnit_0.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, (Doctrine._UseIgnorePlottedCourse)(-(Conversions.ToBoolean(xmlNode_.InnerText) ? 1 : 0)));
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100022", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private ActiveUnit_AI()
	{
		NavDestination = default(Geopoint_Struct);
		HasCaughtUpWithGroup = false;
		m_WorkerVal = new List<Contact>();
		TargetsSortedByRange = new TargetingEntry[0];
		LeadMustSlowDownDueToBingo = false;
		EvaluateTargets_Enabled = true;
		DeterminePrimaryTarget_Enabled = true;
		CheckPossibleABMOrASATEngagement = false;
		WeaponThreat = null;
		MiningInfo = null;
		EvasionManeuver = null;
		_StateVal = RuntimeHelpers.GetObjectValue(new object());
		infoVal = 0.0;
		helperVal = 0.0;
		m_DecoratorWrapper = new List<TargetingEntry>();
		processWrapper = new List<TargetingEntry>();
		m_InstanceWrapper = new List<(double, double, float, short)>();
	}

	public bool IsTargetingThisContact(Contact contact_0)
	{
		if (PrimaryTarget != null && PrimaryTarget == contact_0)
		{
			return true;
		}
		if (_TargetList != null)
		{
			return _TargetList.ContainsKey(contact_0.ObjectID);
		}
		return false;
	}

	public void EvaluateMissionStatus(Scenario scenario_0)
	{
		Mission mission = m_EventVal.AssignedMissionOrPackage();
		if (mission == null)
		{
			if (m_EventVal.AssignedMissionsQueue.Count <= 0)
			{
				return;
			}
			int num = int.MaxValue;
			Mission mission2 = null;
			foreach (KeyValuePair<Mission, Mission> item in m_EventVal.AssignedMissionsQueue)
			{
				if (item.Key.PriorityWeight < num && item.Value.GetPhase(scenario_0, m_EventVal.GetUnitSide()) == MissionPhase.Active)
				{
					mission2 = item.Key;
					num = item.Key.PriorityWeight;
				}
			}
			if (mission == null || (mission != null && mission2 != null && mission2.PriorityWeight < mission.PriorityWeight))
			{
				ActiveUnit eventVal = m_EventVal;
				Mission mission_ = mission2;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				eventVal.Set_AssignedMissionOrPackage(mission_, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_);
				if (mission2 != null)
				{
					m_EventVal.AssignedMissionsQueue.Remove(mission2);
				}
			}
		}
		else
		{
			if (mission.GetPhase(scenario_0, m_EventVal.GetUnitSide()) != MissionPhase.Completed || m_EventVal.AssignedMissionsQueue.Count <= 0)
			{
				return;
			}
			Dictionary<int, List<Mission>> dictionary = new Dictionary<int, List<Mission>>();
			int num2 = int.MaxValue;
			Mission mission3 = mission;
			foreach (KeyValuePair<Mission, Mission> item2 in m_EventVal.AssignedMissionsQueue)
			{
				if (!dictionary.ContainsKey(item2.Key.PriorityWeight))
				{
					dictionary.Add(item2.Key.PriorityWeight, new List<Mission>());
				}
				dictionary[item2.Key.PriorityWeight].Add(item2.Key);
				if (item2.Key.PriorityWeight < num2 && (item2.Value.GetPhase(scenario_0, m_EventVal.GetUnitSide()) == MissionPhase.Active || item2.Value.GetPhase(scenario_0, m_EventVal.GetUnitSide()) == MissionPhase.Completed))
				{
					mission3 = item2.Key;
					num2 = item2.Key.PriorityWeight;
				}
			}
			if (mission == null || (mission != null && mission3 != null && mission3.PriorityWeight < mission.PriorityWeight))
			{
				List<Mission> list = dictionary[mission3.PriorityWeight];
				Mission mission4 = list.ElementAt(0);
				if (list.Count > 1)
				{
					mission4 = list.ElementAt(GlobalSingleton.GetInstance().Random.Next(0, list.Count));
				}
				ActiveUnit eventVal2 = m_EventVal;
				Mission mission_2 = mission4;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
				eventVal2.Set_AssignedMissionOrPackage(mission_2, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_2);
				if (mission3 != null)
				{
					m_EventVal.UnassignMissionInQueue(mission3);
				}
				m_EventVal.AssignMissionInQueue(mission);
			}
		}
	}

	internal void ViewClient()
	{
		try
		{
			if (_PrimaryPickupTarget != null)
			{
				return;
			}
			if (PickupTargets != null && PickupTargets.Count != 0)
			{
				bool flag = m_EventVal.IsAircraft && ((Aircraft)m_EventVal).Loadout != null && (((Aircraft)m_EventVal).Loadout.Role == Loadout.LoadoutRole.SearchAndRescue || ((Aircraft)m_EventVal).Loadout.Role == Loadout.LoadoutRole.CombatSearchAndRescue);
				List<ActiveUnit> list = new List<ActiveUnit>();
				int num = PickupTargets.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = PickupTargets.ElementAtOrDefault(i);
					if (!text.StartsWith("ActiveUnit_"))
					{
						continue;
					}
					string text2 = text.Split('_')[1];
					if (m_EventVal.ParentScen.ActiveUnits.ContainsKey(text2))
					{
						ActiveUnit activeUnit = m_EventVal.ParentScen.ActiveUnits[text2];
						if (activeUnit.IsDestroyed | m_EventVal.ObjectID.Equals(text2))
						{
							PickupTargets.Remove(text);
							if (activeUnit == PrimaryPickupTarget)
							{
								PrimaryPickupTarget = null;
							}
							continue;
						}
						if (activeUnit.EligibleForSAR && flag)
						{
							list.Add(activeUnit);
							continue;
						}
						if (m_EventVal.IsAircraft && (m_EventVal.Kinematics.GetMinimumAltitude() > 150f || m_EventVal.MinPossibleThrottleSetting != 0))
						{
							string text3 = " (Reason: Can't satisfy pickup requirements for min speed (stop) or altitude (150m))";
							m_EventVal.AddMessage(m_EventVal.Name + "正在中止拾取" + activeUnit.Name + text3, m_EventVal.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							PickupTargets.Remove(text);
							if (activeUnit == PrimaryPickupTarget)
							{
								PrimaryPickupTarget = null;
							}
							continue;
						}
						if (activeUnit.IsAircraft && (activeUnit.CurrentAltitude_AGL > 150f || activeUnit.ThrottleSetting != 0))
						{
							string text4 = " (Reason: Target does not meet pickup requirements for min speed (stop) or altitude (150m))";
							m_EventVal.AddMessage(m_EventVal.Name + "正在中止拾取" + activeUnit.Name + text4, m_EventVal.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							PickupTargets.Remove(text);
							if (activeUnit == PrimaryPickupTarget)
							{
								PrimaryPickupTarget = null;
							}
							continue;
						}
						List<CargoManifestItem> list2 = Cargo.GenerateCargoManifest(activeUnit);
						if (list2.Count == 0)
						{
							string text5 = "（原因：转移来源没有要获取的任何货物）";
							if (flag)
							{
								text5 = " (Reason: The transfer source is not eligible for C/SAR)";
							}
							m_EventVal.AddMessage(m_EventVal.Name + "正在中止拾取" + activeUnit.Name + text5, m_EventVal.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							PickupTargets.Remove(text);
							if (activeUnit == PrimaryPickupTarget)
							{
								PrimaryPickupTarget = null;
							}
						}
						else if (ActiveUnit_DockingOps.DetermineFeasibleCargoTransferManifest((ICargoHost)activeUnit, (ICargoHost)m_EventVal, list2).Count == 0)
						{
							m_EventVal.AddMessage(m_EventVal.Name + "正在中止拾取" + activeUnit.Name + "（原因：不能转移任何可用的货物）", m_EventVal.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							PickupTargets.Remove(text);
							if (activeUnit == PrimaryPickupTarget)
							{
								PrimaryPickupTarget = null;
							}
						}
						else
						{
							list.Add(activeUnit);
						}
					}
					else
					{
						PickupTargets.Remove(text);
						if (!Information.IsNothing(PrimaryPickupTarget) && PrimaryPickupTarget.IsActiveUnit && Operators.CompareString(PrimaryPickupTarget.ObjectID, text2, TextCompare: false) == 0)
						{
							PrimaryPickupTarget = null;
						}
					}
				}
				switch (list.Count)
				{
				case 1:
					PrimaryPickupTarget = list[0];
					return;
				case 0:
					PrimaryPickupTarget = null;
					return;
				}
				PrimaryPickupTarget = list.OrderBy((ActiveUnit activeUnit_0) => Module_Unit.RangeToUnit_Horiz(m_EventVal, activeUnit_0)).ElementAtOrDefault(0);
			}
			else
			{
				PrimaryPickupTarget = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 56785678599", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void ClearManualOrders()
	{
		PrimaryPickupTarget = null;
		if (PickupTargets != null)
		{
			PickupTargets.Clear();
		}
	}

	internal bool ValidateClient()
	{
		if (PickupTargets == null)
		{
			return false;
		}
		return PickupTargets.Count > 0;
	}

	public void AddPickupTarget(string string_0)
	{
		if (PickupTargets == null)
		{
			PickupTargets = new HashSet<string>();
		}
		PickupTargets.Add(string_0);
	}

	public void RemovePickupTarget(string string_0)
	{
		string[] array = string_0.Split('_');
		string right = null;
		if (PickupTargets != null)
		{
			if (Operators.CompareString(array[0], "ActiveUnit", TextCompare: false) != 0 && Operators.CompareString(array[0], "Contact", TextCompare: false) != 0)
			{
				right = string_0;
				PickupTargets.Remove("ActiveUnit_" + string_0);
			}
			else
			{
				right = array[1];
				PickupTargets.Remove(string_0);
			}
		}
		if (PickupTargets == null)
		{
			PrimaryPickupTarget = null;
		}
		if (PrimaryPickupTarget != null && Operators.CompareString(PrimaryPickupTarget.ObjectID, right, TextCompare: false) == 0)
		{
			PrimaryPickupTarget = null;
		}
	}

	internal GeoPoint LoginClient()
	{
		try
		{
			GeoPoint result = null;
			ActiveUnit._ActiveUnitStatus status = m_EventVal.Status;
			if ((int)status <= 10)
			{
				if (status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
				{
					result = (m_EventVal.Navigator.HasPlottedCourse() ? m_EventVal.Navigator.PlottedCourse.Last() : new GeoPoint(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				else if (status == ActiveUnit._ActiveUnitStatus.RTB || status == ActiveUnit._ActiveUnitStatus.RTB_Manual)
				{
					goto IL_0331;
				}
			}
			else if ((int)status <= 15)
			{
				if (status == ActiveUnit._ActiveUnitStatus.OnFerryMission)
				{
					ActiveUnit activeUnit = (m_EventVal.IsAircraft ? ((Aircraft)m_EventVal).AirOps.ActualDestinationHost : m_EventVal.DockingOps.ActualDestinationHost);
					if (activeUnit != null)
					{
						result = new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude());
					}
				}
				else if (status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
				{
					goto IL_0331;
				}
			}
			else if ((int)(status - 19) <= 1 || status == ActiveUnit._ActiveUnitStatus.RTB_Exhaustion)
			{
				goto IL_0331;
			}
			if (m_EventVal.Navigator.HasPlottedCourse())
			{
				result = m_EventVal.Navigator.PlottedCourse.Last();
			}
			if (m_EventVal.AssignedMissionOrPackage() != null)
			{
				switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Strike:
					if (PrimaryTarget == null)
					{
						if (m_EventVal.Navigator.PlottedCourse.Count() <= 0)
						{
							break;
						}
						Waypoint[] plottedCourse = m_EventVal.Navigator.PlottedCourse;
						Waypoint[] array = plottedCourse;
						foreach (Waypoint waypoint in array)
						{
							if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponLaunch)
							{
								result = new GeoPoint(waypoint.Longitude, waypoint.Latitude);
								break;
							}
						}
					}
					else if ((PrimaryTarget.Type != 0 && PrimaryTarget.Type != Contact_Base.ContactType.Missile) || Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) >= 150f)
					{
						result = new GeoPoint(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude());
					}
					break;
				case Mission._MissionClass.Patrol:
					result = Misc.Center(((Patrol)m_EventVal.AssignedMissionOrPackage()).PatrolArea).DisableInvocation();
					break;
				case Mission._MissionClass.Support:
					result = m_EventVal.Navigator.SupportMission_NextRefPoint;
					break;
				}
			}
			return result;
			IL_0331:
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100025", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public ActiveUnit_AI(ActiveUnit activeUnit_0)
	{
		NavDestination = default(Geopoint_Struct);
		HasCaughtUpWithGroup = false;
		m_WorkerVal = new List<Contact>();
		TargetsSortedByRange = new TargetingEntry[0];
		LeadMustSlowDownDueToBingo = false;
		EvaluateTargets_Enabled = true;
		DeterminePrimaryTarget_Enabled = true;
		CheckPossibleABMOrASATEngagement = false;
		WeaponThreat = null;
		MiningInfo = null;
		EvasionManeuver = null;
		_StateVal = RuntimeHelpers.GetObjectValue(new object());
		infoVal = 0.0;
		helperVal = 0.0;
		m_DecoratorWrapper = new List<TargetingEntry>();
		processWrapper = new List<TargetingEntry>();
		m_InstanceWrapper = new List<(double, double, float, short)>();
		m_EventVal = activeUnit_0;
	}

	public float TargetingDelayForThisTarget(Contact contact_0)
	{
		try
		{
			if (contact_0 == null)
			{
				return 30f;
			}
			if (m_EventVal == null)
			{
				return 30f;
			}
			if (contact_0.Type == Contact_Base.ContactType.ActivationPoint)
			{
				return 0f;
			}
			float num = 0f;
			if (contact_0.ActualUnit != null)
			{
				if (contact_0.ActualUnit.GetIsAutoDetectable(m_EventVal.GetUnitSide()))
				{
					num = contact_0.TimeSinceDetection;
				}
				if (num == 0f && contact_0.ActualUnit.IsFixedFacility)
				{
					num = contact_0.TimeSinceDetection;
				}
				if (num == 0f && m_EventVal.IsAircraft && !contact_0.IsAir_Missile_Orbital_Contact)
				{
					num = contact_0.TimeSinceDetection;
				}
			}
			if (num == 0f)
			{
				float? num2 = m_EventVal.Sensory.SearchConsumer(ref contact_0);
				num = (num2.HasValue ? num2.Value : contact_0.TimeSinceDetection);
			}
			if (num < contact_0.TimeSinceDetection && m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				num = contact_0.TimeSinceDetection;
			}
			return Math.Max((float)m_EventVal.OODA_Targeting_Actual() - num, 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100026", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 30f;
		}
	}

	public TargetingEntry._TargetingBehavior TargetingBehaviorForThisTarget(Contact contact_0)
	{
		try
		{
			if (contact_0 == null)
			{
				return TargetingEntry._TargetingBehavior.NotTargeted;
			}
			TargetingEntry targetingEntry = null;
			if (_TargetList != null && _TargetList.TryGetValue(contact_0.ObjectID, ref targetingEntry))
			{
				return targetingEntry.Behavior;
			}
			return TargetingEntry._TargetingBehavior.NotTargeted;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100027", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return TargetingEntry._TargetingBehavior.NotTargeted;
		}
	}

	internal bool GetClient(Contact contact_0)
	{
		if (m_EventVal != null && !Information.IsNothing(contact_0))
		{
			if (contact_0.HeadingIsKnown && Math.Abs(MathFunctions.DeleteRequest(contact_0.CurrentHeading, Module_Unit.BearingToUnit_True(contact_0, m_EventVal))) < 5f)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public void HeadToNearestEscortSubject()
	{
		try
		{
			ActiveUnit[] array = m_EventVal.GetUnitSide().Units.ToArray();
			List<ActiveUnit> list = new List<ActiveUnit>();
			ActiveUnit[] array2 = array;
			ActiveUnit[] array3 = array2;
			foreach (ActiveUnit activeUnit in array3)
			{
				if (activeUnit.IsOperating() && !activeUnit.IsGroup && !Information.IsNothing(activeUnit.AssignedMissionOrPackage()) && activeUnit.AssignedMissionOrPackage() == m_EventVal.AssignedMissionOrPackage() && !activeUnit.AI.IsEscort)
				{
					list.Add(activeUnit);
				}
			}
			if (list.Count != 0)
			{
				ActiveUnit activeUnit2 = list.OrderBy((ActiveUnit activeUnit_0) => Module_Unit.RangeToUnit_Horiz(activeUnit_0, m_EventVal)).ToList()[0];
				float num = (from theW in m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual()
					select theW.MaxRange_NoTargetType).Max();
				float num2 = Math.Min(5f, num / 3f);
				if (Module_Unit.RangeToUnit_Horiz(m_EventVal, activeUnit2) <= num2)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, activeUnit2.CurrentHeading);
					m_EventVal.DesiredSpeed = activeUnit2.CurrentSpeed;
				}
				else
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(m_EventVal, activeUnit2));
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101347", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HeadToGroupLead(float float_0, ref Aircraft_AirOps aircraft_AirOps_0)
	{
		try
		{
			if (m_EventVal.GetParentGroup().GroupLead == null)
			{
				HasCaughtUpWithGroup = false;
				return;
			}
			ActiveUnit groupLead = m_EventVal.GetParentGroup().GroupLead;
			bool flag;
			if (!m_EventVal.IsGroupLead() && ((m_EventVal.Navigator.HasPlottedCourse() && (m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Assemble || m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldStart || m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldEnd)) || (m_EventVal.IsGroupWingman() && m_EventVal.GetParentGroup() != null && m_EventVal.GetParentGroup().GroupLead != null && m_EventVal.GetParentGroup().GroupLead.Navigator.HasPlottedCourse() && (m_EventVal.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Assemble || m_EventVal.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldStart || m_EventVal.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldEnd))))
			{
				flag = true;
			}
			else
			{
				if (!m_EventVal.Navigator.HasPlottedCourse() && m_EventVal.IsGroupWingman() && m_EventVal.GetParentGroup() != null && m_EventVal.GetParentGroup().GroupLead != null && m_EventVal.GetParentGroup().GroupLead.Navigator.HasPlottedCourse() && m_EventVal.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].InvokeReponse())
				{
					((Aircraft)m_EventVal).Kinematics.Loiter(float_0);
					return;
				}
				flag = false;
			}
			if (((m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || aircraft_AirOps_0.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel) && aircraft_AirOps_0.A2AR_Destination != null && Module_Unit.RangeToUnit_Horiz(m_EventVal, aircraft_AirOps_0.A2AR_Destination) < aircraft_AirOps_0.TankerHookUpDistance_Wingmen) || (aircraft_AirOps_0.A2AR_Destination == null && groupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling && Module_Unit.RangeToUnit_Horiz(m_EventVal, ((Aircraft)groupLead).AirOps.A2AR_Destination) < aircraft_AirOps_0.TankerHookUpDistance_Wingmen))
			{
				if (aircraft_AirOps_0.A2AR_Destination == null && ((Aircraft)groupLead).AirOps.A2AR_Destination != null && m_EventVal != ((Aircraft)m_EventVal.GetParentGroup().GroupLead).AirOps.A2AR_Destination)
				{
					aircraft_AirOps_0.A2AR_Destination = ((Aircraft)m_EventVal.GetParentGroup().GroupLead).AirOps.A2AR_Destination;
				}
				aircraft_AirOps_0.AttemptToConnectToTanker(bool_0: true);
				HasCaughtUpWithGroup = false;
			}
			else if ((m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || aircraft_AirOps_0.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel) && aircraft_AirOps_0.A2AR_Destination == null && m_EventVal.IsAircraft && ((Aircraft)m_EventVal).IsTanker)
			{
				((Aircraft)m_EventVal).AI.AssistRefuellingClients();
				HasCaughtUpWithGroup = false;
			}
			else if (!(Module_Unit.RangeToUnit_Horiz(m_EventVal, groupLead) < 1f) && (!flag || Module_Unit.RangeToUnit_Horiz(m_EventVal, groupLead) >= 4f))
			{
				HasCaughtUpWithGroup = false;
				if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
				{
					m_EventVal.DesiredAltitude = groupLead.DesiredAltitude;
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, groupLead.GetDesiredAltitude_UseTerrainFollowing(m_EventVal));
				}
				if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
				{
					if (Module_Unit.RangeToUnit_Horiz(m_EventVal, groupLead) <= 50f)
					{
						m_EventVal.Navigator.ClearPathfindingWaypoints();
					}
					else
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
				}
				else if (m_EventVal.CurrentSpeed <= 0f || flag)
				{
					m_EventVal.SetDesiredHeading(groupLead.DesiredTurnRate, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), groupLead.GetLatitude(), groupLead.GetLongitude()));
				}
				else
				{
					float num = Module_Unit.BearingToUnit_Relative(groupLead, m_EventVal);
					if (num >= 90f && num <= 270f)
					{
						float num2 = m_EventVal.ETA_To_Location(m_EventVal.CurrentSpeed, Module_Unit.RangeToPoint_Horiz(m_EventVal, groupLead.GetLatitude(), groupLead.GetLongitude()));
						float float_ = m_EventVal.CurrentSpeed * num2 / 3600f;
						double double_ = 0.0;
						double double_2 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(groupLead.GetLongitude(), groupLead.GetLatitude(), ref double_, ref double_2, float_, groupLead.CurrentHeading);
						m_EventVal.SetDesiredHeading(groupLead.DesiredTurnRate, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), double_2, double_));
					}
					else
					{
						m_EventVal.SetDesiredHeading(groupLead.DesiredTurnRate, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), groupLead.GetLatitude(), groupLead.GetLongitude()));
					}
					if (m_EventVal.Navigator.bool_0 && !m_EventVal.Navigator.HasPathfindingPlottedCourse && !m_EventVal.Navigator.PathFindingInProgress && Module_Unit.RangeToUnit_Horiz(m_EventVal, groupLead) > 50f)
					{
						double latitude = m_EventVal.GetLatitude();
						double longitude = m_EventVal.GetLongitude();
						double latitude2 = groupLead.GetLatitude();
						double longitude2 = groupLead.GetLongitude();
						ActiveUnit_Navigator navigator = m_EventVal.Navigator;
						float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
						int int_ = 0;
						GeoPoint geoPoint_ = null;
						if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: false, nullable_, ref int_, ref geoPoint_))
						{
							m_EventVal.Navigator.TriggerPathfinderThread(null, m_EventVal, null, bool_1: false, 0.15f, latitude2, longitude2, m_EventVal.ParentScen, bool_2: false);
						}
					}
				}
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				if (groupLead.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					return;
				}
				if (m_EventVal.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
				{
					if (m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
					{
						m_EventVal.SetThrottle(groupLead.ThrottleSetting);
					}
					else if ((int)groupLead.ThrottleSetting <= 2)
					{
						m_EventVal.SetThrottle(groupLead.ThrottleSetting);
					}
					else
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else if (m_EventVal.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					if ((int)groupLead.ThrottleSetting <= 2)
					{
						m_EventVal.SetThrottle(groupLead.ThrottleSetting + 1);
					}
					else
					{
						m_EventVal.SetThrottle(groupLead.ThrottleSetting);
					}
				}
				else
				{
					m_EventVal.SetThrottle(groupLead.ThrottleSetting + 1);
				}
			}
			else
			{
				MatchGroupLead();
				HasCaughtUpWithGroup = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200334", exception_.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
		}
	}

	public void MatchGroupLead()
	{
		try
		{
			if (Information.IsNothing(m_EventVal.GetParentGroup().GroupLead))
			{
				return;
			}
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride && !m_EventVal.GetParentGroup().GroupLead.IsShip)
			{
				if (m_EventVal.DesiredAltitude != m_EventVal.GetParentGroup().GroupLead.DesiredAltitude)
				{
					m_EventVal.DesiredAltitude = m_EventVal.GetParentGroup().GroupLead.DesiredAltitude;
				}
				if (m_EventVal.DesiredAltitude_AGL != m_EventVal.GetParentGroup().GroupLead.DesiredAltitude_AGL)
				{
					m_EventVal.DesiredAltitude_AGL = m_EventVal.GetParentGroup().GroupLead.DesiredAltitude_AGL;
				}
				if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal) != m_EventVal.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(m_EventVal.GetParentGroup().GroupLead))
				{
					m_EventVal.SetDesiredAltitude_UseTerrainFollowing(m_EventVal, m_EventVal.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(m_EventVal.GetParentGroup().GroupLead));
				}
			}
			m_EventVal.SetDesiredHeading(m_EventVal.GetParentGroup().GroupLead.DesiredTurnRate, m_EventVal.GetParentGroup().GroupLead.DesiredHeading);
			if (m_EventVal.GetParentGroup().GroupLead.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
			{
				m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().GroupLead.CurrentSpeed;
			}
			else
			{
				m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().GroupLead.DesiredSpeed;
			}
			if (m_EventVal.ThrottleSetting != m_EventVal.GetParentGroup().GroupLead.ThrottleSetting)
			{
				m_EventVal.SetThrottle(m_EventVal.GetParentGroup().GroupLead.ThrottleSetting, m_EventVal.DesiredSpeed);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100029", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateSpeedAlt_MatchGroupLead()
	{
		try
		{
			if (m_EventVal.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)m_EventVal).Units.Values)
				{
					if (!value.IsGroupLead())
					{
						value.AI.MatchGroupLead();
					}
				}
				return;
			}
			if (m_EventVal.IsGroupWingman())
			{
				m_EventVal.AI.MatchGroupLead();
			}
			else
			{
				if (!m_EventVal.IsGroupLead())
				{
					return;
				}
				{
					foreach (ActiveUnit value2 in m_EventVal.GetParentGroup().Units.Values)
					{
						if (!value2.IsGroupLead())
						{
							value2.AI.MatchGroupLead();
						}
					}
					return;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101348", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool WriteClient(double double_0, double double_1, float float_0, float? nullable_0)
	{
		try
		{
			Aircraft aircraft = (Aircraft)m_EventVal;
			Aircraft_AirOps airOps = aircraft.AirOps;
			bool bool_ = false;
			ActiveUnit activeUnit_ = null;
			string string_ = "";
			List<Aircraft> potentialTankers = airOps.GetPotentialTankers(ref bool_, ref activeUnit_, bool_1: false, null, ref string_);
			float num = aircraft.Kinematics.MaxRange(bool_0: false, null, nullable_0);
			if (potentialTankers.Count > 1)
			{
				List<Aircraft> list = new List<Aircraft>();
				foreach (Aircraft Local_theTanker in potentialTankers)
				{
					bool flag = false;
					foreach (Aircraft item in potentialTankers.Where((Aircraft theAC) => theAC != Local_theTanker).ToList())
					{
						if (!(Module_Unit.RangeToUnit_Horiz(Local_theTanker, item) >= num))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(Local_theTanker);
					}
				}
				foreach (Aircraft item2 in list)
				{
					potentialTankers.Remove(item2);
				}
			}
			bool flag2 = false;
			foreach (Aircraft item3 in potentialTankers)
			{
				if (!(Module_Unit.RangeToUnit_Horiz(item3, m_EventVal) >= num))
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				bool flag3 = false;
				foreach (Aircraft item4 in potentialTankers)
				{
					if (!(Module_Unit.RangeToPoint_Horiz(item4, double_0, double_1) >= float_0))
					{
						flag3 = true;
						break;
					}
				}
				if (flag3)
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
			exception_?.Data.Add("Error at 101349", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool NewClient(Contact contact_0, int int_0, int int_1, Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_0, ref string string_0)
	{
		try
		{
			if (Information.IsNothing(contact_0))
			{
				string_0 = "目标不存在！";
				return false;
			}
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0);
			if (int_1 != 0 && num > (float)int_1)
			{
				string_0 = "该任务被配置为不攻击超出" + Conversions.ToString(int_1) + "海里的目标而与目标的距离是" + Conversions.ToString((int)Math.Round(num)) + "海里。";
				return false;
			}
			if (int_0 != 0 && num < (float)int_0)
			{
				string_0 = "该任务被配置为不攻击距离小于" + Conversions.ToString(int_0) + "海里的目标而与目标的距离是" + Conversions.ToString((int)Math.Round(num)) + "海里。";
				return false;
			}
			Aircraft aircraft = (Aircraft)m_EventVal;
			float num2 = aircraft.Kinematics.TacticalRadius();
			Weapon weapon = aircraft.Weaponry.RevertConsumer(null);
			if (!Information.IsNothing(weapon))
			{
				num2 += weapon.MaxAirRange;
			}
			if (num < num2)
			{
				return true;
			}
			if (!aircraft.BoomRefuelling && !aircraft.ProbeRefuelling)
			{
				string_0 = "目标超出范围。";
				return false;
			}
			byte? b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				string_0 = "任务配置为不使用空对空加油，目标超出范围。";
				return false;
			}
			float value = 0f;
			if (!bool_0)
			{
				Aircraft_Navigator navigator = aircraft.Navigator;
				bool bool_ = false;
				value = navigator.OrderProxy(ref bool_);
			}
			if (!bool_0 && !WriteClient(contact_0.GetLatitude(), contact_0.GetLongitude(), aircraft.Loadout.CombatRadius, value))
			{
				string_0 = "该任务配置为使用空对空加油。但是，在合理范围内没有加油机可用。加油机必须位于拦截器的起飞位置和目标之间，在目标的战术半径范围内（" + Conversions.ToString(aircraft.Loadout.CombatRadius) + "海里），或在拦截者的起飞位置范围内（" + Conversions.ToString(aircraft.Kinematics.MaxRange(bool_0: false, null, value)) + "nm).";
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101249", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal float PushClient(ref Strike.StrikeType strikeType_0)
	{
		try
		{
			Aircraft aircraft = (Aircraft)m_EventVal;
			switch (strikeType_0)
			{
			case Strike.StrikeType.Land_Strike:
			{
				Weapon weapon2 = aircraft.Weaponry.CustomizeFacade(null, bool_1: false);
				if (!Information.IsNothing(weapon2))
				{
					return weapon2.MaxLandRange;
				}
				break;
			}
			case Strike.StrikeType.Maritime_Strike:
			{
				Weapon weapon3 = aircraft.Weaponry.CountFacade(null, bool_1: false);
				if (!Information.IsNothing(weapon3))
				{
					return weapon3.MaxSurfaceRange;
				}
				break;
			}
			case Strike.StrikeType.Sub_Strike:
			{
				Weapon weapon = aircraft.Weaponry.CloneFacade(null);
				if (!Information.IsNothing(weapon))
				{
					return weapon.MaxSubsurfaceRange;
				}
				break;
			}
			}
			return 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101350", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal bool InvokeClient(ref Mission.Flight flight_0, ref float float_0, Contact contact_0, ref string string_0)
	{
		if (!Information.IsNothing(flight_0) && !Information.IsNothing(flight_0.FlightPlan))
		{
			Waypoint[] waypoint_ = new Waypoint[0];
			Waypoint[] flightPlan = flight_0.FlightPlan;
			for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
			{
				Waypoint waypoint_2 = flightPlan[i];
				if (waypoint_2.Type != Waypoint.WaypointType.InitialPoint && waypoint_2.Type != Waypoint.WaypointType.WeaponLaunch)
				{
					ref Scenario parentScen = ref m_EventVal.ParentScen;
					Doctrine doctrine_ = null;
					Waypoint waypoint = Waypoint.CopyWaypoint(ref parentScen, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_);
					if (waypoint.Type == Waypoint.WaypointType.Target || waypoint_2.Type == Waypoint.WaypointType.WeaponTarget)
					{
						waypoint.Latitude = contact_0.GetLatitude();
						waypoint.Longitude = contact_0.GetLongitude();
					}
					ArrayExtensions.Add(ref waypoint_, waypoint);
				}
			}
			Aircraft aircraft = (Aircraft)m_EventVal;
			float float_ = 0f;
			if (MissionPlanner.ConnectTokenizer(aircraft.ParentScen, aircraft.AssignedMissionOrPackage(), aircraft, aircraft.Navigator.GetFlight(), ref waypoint_, ref float_0, ref float_, bool_0: true, bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: false, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: true))
			{
				return true;
			}
			string_0 = "没有足够的燃料到达目标。任务编队燃料（不包括储备）为" + Conversions.ToString((int)Math.Round(float_)) + "千克，而飞行计划的燃料需求是" + Conversions.ToString((int)Math.Round(float_0)) + "千克。";
			return false;
		}
		string_0 = "没有找到飞行计划！";
		return false;
	}

	internal bool SetupClient(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Contact contact_0, int int_0, int int_1, Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_0, Mission._RadarBehaviour _RadarBehaviour_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, ref float float_0, ref string string_0, bool bool_5, ref bool bool_6, bool bool_7, ref float float_1, ref float float_2, bool bool_8, Contact contact_1, bool bool_9, DateTime? nullable_1, DateTime? nullable_2, bool bool_10, bool bool_11)
	{
		if (m_EventVal == null)
		{
			return false;
		}
		Aircraft aircraft_ = (Aircraft)m_EventVal;
		try
		{
			if (Information.IsNothing(contact_0))
			{
				string_0 = "目标不存在！";
				return false;
			}
			float num = (Information.IsNothing(aircraft_.AirOps.ActualDestinationHost) ? Module_Unit.RangeToUnit_Horiz(aircraft_, contact_0) : Module_Unit.RangeToUnit_Horiz(aircraft_.AirOps.ActualDestinationHost, contact_0));
			if (int_1 != 0 && num > (float)int_1)
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj = flight_0;
					Waypoint[] gparam_ = obj.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_);
					obj.FlightPlan_Pathfinder_Ingress_1 = gparam_;
				}
				string_0 = "该任务被配置为不会攻击目标距离超过" + Conversions.ToString(int_1) + "海里，而从基地到目标的距离是" + Conversions.ToString((int)Math.Round(num)) + "海里。没有生成飞行计划，任务也无法启动。";
				return false;
			}
			if (int_0 != 0 && num < (float)int_0)
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj2 = flight_0;
					Waypoint[] gparam_2 = obj2.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_2);
					obj2.FlightPlan_Pathfinder_Ingress_1 = gparam_2;
				}
				string_0 = "该任务被配置为不会更接近目标" + Conversions.ToString(int_0) + "海里，而从基地到目标的距离是" + Conversions.ToString((int)Math.Round(num)) + "海里。没有生成飞行计划，任务也无法启动。";
				return false;
			}
			Weapon weapon_ = aircraft_.Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: false, bool_2: false, bool_3: true, aircraft_.Doctrine);
			if (Information.IsNothing(weapon_))
			{
				string_0 = "无法确定最合适的武器。飞机是否挂载了适合任务类型的正确武器？没有创建飞行计划。";
				return false;
			}
			float num2 = weapon_.GetMaxRangeForThisTarget(aircraft_, contact_0, bool_0: true, aircraft_.Doctrine, bool_1: false) * 0.9f;
			bool flag = false;
			int? num3 = aircraft_?.Loadout?.CombatRadius;
			bool? flag2 = (num3.HasValue ? new bool?(num3.GetValueOrDefault() > 0) : null);
			if (flag2.GetValueOrDefault(true))
			{
				num3 = aircraft_?.Loadout?.TimeOnStation_Minutes;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault() && flag2.HasValue)
				{
					flag = true;
				}
			}
			float num4 = (flag ? ((float)aircraft_.Loadout.CombatRadius) : aircraft_.Kinematics.TacticalRadius());
			if (num <= num4 + num2)
			{
				if (bool_8)
				{
					return MissionPlanner.GenerateFlightPlan_Strike(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref aircraft_, null, contact_0, _RadarBehaviour_0, ref bool_1, bool_2, bool_3, bool_4, ref float_0, ref string_0, bool_5, ref bool_6, bool_7, ref float_1, ref float_2, bool_7: false, num, ref weapon_, num2, bool_9, nullable_1, nullable_2, bool_11);
				}
				if (contact_1 == null)
				{
					return true;
				}
				return InvokeClient(ref flight_0, ref float_0, contact_1, ref string_0);
			}
			if (!aircraft_.BoomRefuelling && !aircraft_.ProbeRefuelling)
			{
				string_0 = "目标超出范围。到目标的距离是" + Conversions.ToString((int)Math.Round(num)) + "海里，而战斗半径是" + Conversions.ToString(num4) + "海里，且最大武器范围是" + Conversions.ToString(num2) + "海里。";
				return false;
			}
			byte? b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj3 = flight_0;
					Waypoint[] gparam_3 = obj3.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_3);
					obj3.FlightPlan_Pathfinder_Ingress_1 = gparam_3;
				}
				string_0 = "任务配置为不使用空对空加油，目标超出范围。没有生成飞行计划，任务也无法启动。";
				return false;
			}
			b = (byte?)m_EventVal.Doctrine.GetUseReplenishment(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj4 = flight_0;
					Waypoint[] gparam_4 = obj4.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_4);
					obj4.FlightPlan_Pathfinder_Ingress_1 = gparam_4;
				}
				string text = "";
				if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + m_EventVal.UnitClass + ")";
				}
				string_0 = m_EventVal.Name + text + "有一个条令设置，禁止空对空加油，目标超出范围。没有生成飞行计划，任务也无法启动。";
				return false;
			}
			float value = 0f;
			if (!bool_0)
			{
				Aircraft_Navigator navigator = aircraft_.Navigator;
				bool bool_12 = false;
				value = navigator.OrderProxy(ref bool_12);
			}
			if (!bool_0 && !WriteClient(contact_0.GetLatitude(), contact_0.GetLongitude(), num4, value))
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj5 = flight_0;
					Waypoint[] gparam_5 = obj5.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_5);
					obj5.FlightPlan_Pathfinder_Ingress_1 = gparam_5;
				}
				string_0 = "该任务配置为使用空对空加油。但是，在合理范围内没有加油机可用。加油机必须位于攻击机的起飞位置和目标之间，在目标的战术半径范围内（" + Conversions.ToString(num4) + "海里），并且在攻击机的当前位置范围内（" + Conversions.ToString((int)Math.Round(aircraft_.Kinematics.MaxRange(bool_0: false, null, value))) + " nm). No flightplan has been generated and the mission will not launch. This security check might be ignored by checking the relative option from Mission Setting --> Tanker --> Configure";
				return false;
			}
			if (bool_8)
			{
				return MissionPlanner.GenerateFlightPlan_Strike(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref aircraft_, true, contact_0, _RadarBehaviour_0, ref bool_1, bool_2, bool_3, bool_4, ref float_0, ref string_0, bool_5, ref bool_6, bool_7, ref float_1, ref float_2, bool_7: true, num, ref weapon_, num2, bool_9, nullable_1, nullable_2, bool_11);
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100399", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool ExcludeClient(ref Mission.Flight flight_0, Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref float float_0, ref string string_0, bool bool_4, bool bool_5, double double_0, double double_1, double double_2, double double_3, Waypoint.WaypointType waypointType_0, Waypoint.TurnRateCategory turnRateCategory_0, bool bool_6, DateTime? nullable_1, DateTime? nullable_2, bool bool_7, bool bool_8)
	{
		try
		{
			Aircraft aircraft_ = (Aircraft)m_EventVal;
			float num = (Information.IsNothing(aircraft_.AirOps.ActualDestinationHost) ? Module_Unit.RangeToPoint_Horiz(aircraft_, double_0, double_1) : Module_Unit.RangeToPoint_Horiz(aircraft_.AirOps.ActualDestinationHost, double_0, double_1));
			bool flag = false;
			if (aircraft_.Loadout.CombatRadius > 0 && aircraft_.Loadout.TimeOnStation_Minutes == 0)
			{
				flag = true;
			}
			float num2 = (flag ? ((float)aircraft_.Loadout.CombatRadius) : aircraft_.Kinematics.TacticalRadius());
			if (num <= num2)
			{
				if (bool_5)
				{
					ref Scenario parentScen = ref m_EventVal.ParentScen;
					ActiveUnit eventVal;
					Side side_ = (eventVal = m_EventVal).GetUnitSide();
					Mission mission_ = m_EventVal.AssignedMissionOrPackage();
					bool result = MissionPlanner.GenerateFlightPlan_Station(ref parentScen, ref side_, ref mission_, ref flight_0, ref aircraft_, null, ref bool_1, bool_2, bool_3, ref float_0, ref string_0, bool_4, Information.IsNothing(nullable_0) || nullable_0.Value != Doctrine._UseUnderwayRefuelAndReplenishment.Never, num, double_0, double_1, double_2, double_3, waypointType_0, turnRateCategory_0, bool_6, nullable_1, nullable_2, bool_8);
					eventVal.SetUnitSide(bool_0: false, side_);
					return result;
				}
				return true;
			}
			if (!aircraft_.BoomRefuelling && !aircraft_.ProbeRefuelling)
			{
				string_0 = "The station area is out of range. Distance to target is " + Conversions.ToString((int)Math.Round(num)) + "海里，而战斗半径是" + Conversions.ToString(num2) + "海里。";
				return false;
			}
			byte? b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj = flight_0;
					Waypoint[] gparam_ = obj.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_);
					obj.FlightPlan_Pathfinder_Ingress_1 = gparam_;
				}
				string_0 = "任务配置为不使用空对空加油，目标超出范围。没有生成飞行计划，任务也无法启动。";
				return false;
			}
			float value = 0f;
			if (!bool_0)
			{
				Aircraft_Navigator navigator = aircraft_.Navigator;
				bool bool_9 = false;
				value = navigator.OrderProxy(ref bool_9);
			}
			if (!bool_0 && !WriteClient(double_0, double_1, num2, value))
			{
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
				{
					Mission.Flight obj2 = flight_0;
					Waypoint[] gparam_2 = obj2.FlightPlan_Pathfinder_Ingress_1;
					ArrayExtensions.Clear(ref gparam_2);
					obj2.FlightPlan_Pathfinder_Ingress_1 = gparam_2;
				}
				string_0 = "The mission is configured to use air-to-air refuelling. However there is no tanker available within reasonable reach. The tanker must be located between the patrol aircraft's take-off location and the station area, within tactical radius of the station area (" + Conversions.ToString(num2) + " nm), and within range of the patrol aircraft's take-off location (" + Conversions.ToString((int)Math.Round(aircraft_.Kinematics.MaxRange(bool_0: false, null, value))) + "海里）。没有生成飞行计划，任务也无法启动。";
				return false;
			}
			if (bool_5)
			{
				ref Scenario parentScen2 = ref m_EventVal.ParentScen;
				ActiveUnit eventVal2;
				Side side_2 = (eventVal2 = m_EventVal).GetUnitSide();
				Mission mission_2 = m_EventVal.AssignedMissionOrPackage();
				bool result2 = MissionPlanner.GenerateFlightPlan_Station(ref parentScen2, ref side_2, ref mission_2, ref flight_0, ref aircraft_, null, ref bool_1, bool_2, bool_3, ref float_0, ref string_0, bool_4, bool_4: true, num, double_0, double_1, double_2, double_3, waypointType_0, turnRateCategory_0, bool_6, nullable_1, nullable_2, bool_8);
				eventVal2.SetUnitSide(bool_0: false, side_2);
				return result2;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 098653434765", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool IncludeClient(ref Strike strike_0, Misc.PostureStance postureStance_0)
	{
		if (!Information.IsNothing(postureStance_0))
		{
			switch (strike_0.MinimumContactStanceToTrigger)
			{
			default:
				return false;
			case Misc.PostureStance.Unfriendly:
				if (postureStance_0 != Misc.PostureStance.Hostile && postureStance_0 != Misc.PostureStance.Unfriendly)
				{
					return false;
				}
				return true;
			case Misc.PostureStance.Hostile:
				if (postureStance_0 == Misc.PostureStance.Hostile)
				{
					return true;
				}
				return false;
			case Misc.PostureStance.Unknown:
				return true;
			}
		}
		return false;
	}

	public void HandleContactBeingDropped(ref Contact contact_0, ref Side side_0)
	{
		try
		{
			if (m_EventVal == null || side_0 == m_EventVal.GetUnitSide())
			{
				if (_TargetList != null && _TargetList.ContainsKey(contact_0.ObjectID))
				{
					DropTarget(contact_0);
				}
				if (_Threats != null && _Threats.Contains(contact_0))
				{
					DropThreat(contact_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100031", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAllTargets(ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (m_EventVal == null)
			{
				return;
			}
			object stateVal = _StateVal;
			ObjectFlowControl.CheckForSyncLockOnValueType(stateVal);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(stateVal, ref lockTaken);
				if (!activeUnit_0.IsWeapon)
				{
					Side unitSide = m_EventVal.GetUnitSide();
					ref Scenario parentScen = ref m_EventVal.ParentScen;
					ref ActiveUnit eventVal = ref m_EventVal;
					Contact contact_ = null;
					WeaponSalvo weaponSalvo_ = null;
					unitSide.StopShootingSalvo(ref parentScen, ref eventVal, ref contact_, ref weaponSalvo_);
				}
				if (_TargetList != null)
				{
					_TargetList.Clear();
				}
				PrimaryTarget = null;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(stateVal);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200327", exception_.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAllThreats()
	{
		if (_Threats != null)
		{
			_Threats.Clear();
		}
	}

	public virtual bool ClosingWithinWeaponRangeOfPrimaryTarget()
	{
		return false;
	}

	public virtual void InterceptPrimaryTarget()
	{
	}

	public bool ContactIsThreatToUnit(Contact contact_0, ActiveUnit activeUnit_0, int int_0)
	{
		try
		{
			if (contact_0.Type != Contact_Base.ContactType.Aimpoint && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
			{
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact_0.ObjectID, out var value))
				{
					value = contact_0.GetStance(m_EventVal.GetUnitSide());
				}
				if (value != Misc.PostureStance.Friendly && value != 0)
				{
					float num = Module_Unit.RangeToUnit_Horiz(activeUnit_0, contact_0);
					float num2 = 0f;
					switch (activeUnit_0.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Ship:
						num2 = (float)Math.Min(1.5 * (double)contact_0.MaxPotentialWeaponRange_ASuW_Naval().GetValueOrDefault(), int_0);
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						num2 = (float)Math.Min(1.5 * (double)contact_0.MaxPotentialWeaponRange_ASW().GetValueOrDefault(), int_0);
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						num2 = (float)Math.Min(1.5 * (double)contact_0.MaxPotentialWeaponRange_ASuW_Land().GetValueOrDefault(), int_0);
						break;
					case GlobalVariables.ActiveUnitType.Aimpoint:
						return false;
					case GlobalVariables.ActiveUnitType.Aircraft:
					case GlobalVariables.ActiveUnitType.Weapon:
						num2 = (float)Math.Min(1.5 * (double)contact_0.MaxPotentialWeaponRange_AAW().GetValueOrDefault(), int_0);
						break;
					}
					if (num < num2)
					{
						return true;
					}
					if (contact_0.Type == Contact_Base.ContactType.Air)
					{
						if (int_0 <= 0)
						{
							if (num < 30f && Module_Unit.ClosureSpeed(activeUnit_0, contact_0, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading) > 0f)
							{
								return true;
							}
						}
						else if (num < (float)int_0 && Module_Unit.ClosureSpeed(activeUnit_0, contact_0, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading) > 0f)
						{
							return true;
						}
					}
					try
					{
						if ((contact_0.IsLandContact || contact_0.IsShipContact) && num < (float)int_0 && contact_0.HasDetectedEmissions)
						{
							foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_0.DetectedEmissions)
							{
								Sensor associatedSensor = detectedEmission.Value.GetAssociatedSensor(detectedEmission.Key, m_EventVal.ParentScen);
								if (associatedSensor.IsPureIlluminator || associatedSensor.IsFireControlRadar)
								{
									return true;
								}
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200275", exception_.Message);
						_ = Debugger.IsAttached;
						GameGeneral.WriteExceptionsToLog(ref exception_);
						ProjectData.ClearProjectError();
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100033", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool ContactIsThreatToMissionUnits(Contact contact_0)
	{
		try
		{
			if (m_EventVal.AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (contact_0.ActualUnit == null)
			{
				return false;
			}
			if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				if (m_EventVal.IsAircraft && !((Aircraft)m_EventVal).AI.ContactIsRelevantToEscortsLoadout(contact_0))
				{
					return false;
				}
				Weapon weapon = m_EventVal.Weaponry.RevertConsumer(contact_0);
				Weapon weapon2 = m_EventVal.Weaponry.CustomizeFacade(contact_0, bool_1: false);
				Weapon weapon3 = m_EventVal.Weaponry.CountFacade(contact_0, bool_1: false);
				Weapon weapon4 = m_EventVal.Weaponry.CloneFacade(contact_0);
				Mission mission = m_EventVal.AssignedMissionOrPackage();
				int num = 0;
				if (mission.MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)mission;
					num = strike.Escort_ResponseRadius;
					if (m_EventVal.IsAircraft)
					{
						Aircraft aircraft = (Aircraft)m_EventVal;
						if (aircraft.Loadout.Role == Loadout.LoadoutRole.NavalOnly_SEAD_ARM || aircraft.Loadout.Role == Loadout.LoadoutRole.NavalOnly_SEAD_TALD || aircraft.Loadout.Role == Loadout.LoadoutRole.LandOnly_SEAD_TALD || aircraft.Loadout.Role == Loadout.LoadoutRole.LandOnly_SEAD_ARM || aircraft.Loadout.Role == Loadout.LoadoutRole.LandNaval_SEAD_TALD || aircraft.Loadout.Role == Loadout.LoadoutRole.LandNaval_SEAD_ARM)
						{
							num = strike.Escort_ResponseRadius_SEAD;
						}
					}
				}
				ActiveUnit[] array = m_EventVal.GetUnitSide().Units.ToArray();
				if (m_EventVal.Navigator.HasFlightPlan)
				{
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
						if (weapon != null && Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon.MaxAirRange), num))
						{
							return true;
						}
						break;
					case Contact_Base.ContactType.Submarine:
						if (weapon4 != null && Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon4.MaxSubsurfaceRange), num))
						{
							return true;
						}
						break;
					case Contact_Base.ContactType.Aimpoint:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						if (weapon2 != null && Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon2.MaxLandRange), num))
						{
							return true;
						}
						break;
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.UndeterminedNaval:
					case Contact_Base.ContactType.Mine:
						if (weapon3 != null && Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon3.MaxSurfaceRange), num))
						{
							return true;
						}
						break;
					}
				}
				ActiveUnit[] array2 = array;
				ActiveUnit[] array3 = array2;
				foreach (ActiveUnit activeUnit in array3)
				{
					if (!activeUnit.IsOperating() || activeUnit.IsGroup || activeUnit.AssignedMissionOrPackage() == null || activeUnit.AssignedMissionOrPackage() != m_EventVal.AssignedMissionOrPackage() || activeUnit.AI.IsEscort)
					{
						continue;
					}
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
						if (weapon == null)
						{
							break;
						}
						if (m_EventVal.Navigator.HasFlightPlan)
						{
							if (Module_Unit.RangeToUnit_Slant(activeUnit, contact_0) < (float)num)
							{
								return true;
							}
						}
						else if (Module_Unit.RangeToUnit_Slant(activeUnit, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon.MaxAirRange), num))
						{
							return true;
						}
						break;
					case Contact_Base.ContactType.Submarine:
						if (weapon4 == null)
						{
							break;
						}
						if (m_EventVal.Navigator.HasFlightPlan)
						{
							if (Module_Unit.RangeToUnit_Horiz(activeUnit, contact_0) < (float)num)
							{
								return true;
							}
						}
						else if (Module_Unit.RangeToUnit_Horiz(activeUnit, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon4.MaxSubsurfaceRange), num))
						{
							return true;
						}
						break;
					case Contact_Base.ContactType.Aimpoint:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						if (weapon2 == null)
						{
							break;
						}
						if (m_EventVal.Navigator.HasFlightPlan)
						{
							if (Module_Unit.RangeToUnit_Horiz(activeUnit, contact_0) < (float)num)
							{
								return true;
							}
						}
						else if (Module_Unit.RangeToUnit_Horiz(activeUnit, contact_0) < Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon2.MaxLandRange), num))
						{
							return true;
						}
						break;
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.UndeterminedNaval:
					case Contact_Base.ContactType.Mine:
						if (weapon3 == null)
						{
							break;
						}
						if (m_EventVal.Navigator.HasFlightPlan)
						{
							if (Module_Unit.RangeToUnit_Horiz(activeUnit, contact_0) < (float)num)
							{
								return true;
							}
						}
						else if (!(Module_Unit.RangeToUnit_Horiz(activeUnit, contact_0) >= Math.Min(Math.Max(5f, contact_0.ChangeImporter() * weapon3.MaxSurfaceRange), num)))
						{
							return true;
						}
						break;
					}
					if (ContactIsThreatToUnit(contact_0, activeUnit, num))
					{
						return true;
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
			exception_?.Data.Add("Error at 101352", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool SearchClient(GeoPoint geoPoint_0, GeoPoint geoPoint_1, GeoPoint geoPoint_2, float float_0)
	{
		PointF pointF_ = default(PointF);
		MathFunctions.CountRequest(new PointF((float)geoPoint_0.Latitude, (float)geoPoint_0.Longitude), new PointF((float)geoPoint_1.Latitude, (float)geoPoint_1.Longitude), new PointF((float)geoPoint_2.Latitude, (float)geoPoint_2.Longitude), ref pointF_);
		return (double)float_0 > MathFunctions.ViewRequest(geoPoint_0.Latitude, geoPoint_0.Longitude, pointF_.X, pointF_.Y);
	}

	internal bool EnableClient(GeoPoint geoPoint_0, List<ReferencePoint> list_0, float float_0)
	{
		if (list_0.Count <= 1)
		{
			return false;
		}
		int num = list_0.Count - 2;
		for (int i = 0; i <= num; i++)
		{
			if (SearchClient(geoPoint_0, new GeoPoint(list_0[i].Longitude, list_0[i].Latitude), new GeoPoint(list_0[i + 1].Longitude, list_0[i + 1].Latitude), float_0))
			{
				return true;
			}
		}
		return false;
	}

	internal List<Contact> ChangeClient(Contact[] contact_0)
	{
		try
		{
			List<Contact> list = new List<Contact>();
			if (m_EventVal.GetUnitSide().NoNavZones.Count > 0)
			{
				for (int i = 0; i < contact_0.Length; i = checked(i + 1))
				{
					Contact contact_ = contact_0[i];
					if (m_EventVal.GetUnitSide().ruleProxy.TryGetValue_NoLock(contact_.ObjectID, out var gparam_))
					{
						if (gparam_)
						{
							list.Add(contact_);
						}
					}
					else
					{
						if (contact_ == null)
						{
							continue;
						}
						Side unitSide = m_EventVal.GetUnitSide();
						ref ActiveUnit eventVal = ref m_EventVal;
						TargetingEntry._TargetingBehavior _TargetingBehavior_ = TargetingEntry._TargetingBehavior.AutoTargeted;
						if (unitSide.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref eventVal, ref contact_, ref _TargetingBehavior_) > 0 && TargetingBehaviorForThisTarget(contact_) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
						{
							continue;
						}
						foreach (NoNavZone noNavZone in m_EventVal.GetUnitSide().NoNavZones)
						{
							if (noNavZone.GetAffectsThisUnit(m_EventVal) && noNavZone.Area.Count != 0 && noNavZone.NoFireZone && contact_.GetIsInsideThisArea(noNavZone.Area, m_EventVal.ParentScen, bool_0: true))
							{
								list.Add(contact_);
								m_EventVal.GetUnitSide().ruleProxy.AddIfNotExistsElseUpdate(contact_.ObjectID, value: true);
							}
						}
						m_EventVal.GetUnitSide().ruleProxy.AddIfNotExistsElseUpdate(contact_.ObjectID, value: false);
					}
				}
				if (list.Count > 0)
				{
					foreach (Contact item in list)
					{
						DropTarget(item);
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 2345092384590283", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Contact> result = new List<Contact>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal List<Contact> InitClient(Contact contact_0)
	{
		Contact[] contact_ = new Contact[1] { contact_0 };
		return ChangeClient(contact_);
	}

	public bool ContactIsRelevantToMission(Contact contact_0, Mission mission_0, Doctrine._UseShootTourists? nullable_0, bool bool_0, bool bool_1, bool bool_2, Misc.PostureStance? nullable_1, ref string string_0, ref int int_0)
	{
		if (m_EventVal == null)
		{
			return false;
		}
		try
		{
			if (mission_0 == null)
			{
				if (int_0 < 1)
				{
					string_0 = "未找到任务！";
					int_0 = 1;
				}
				return false;
			}
			if (contact_0.ActualUnit == null)
			{
				if (int_0 < 1)
				{
					string_0 = "目标单元不存在！";
					int_0 = 1;
				}
				return false;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Patrol && !((Patrol)mission_0).PopStub(contact_0))
			{
				return false;
			}
			Side unitSide = m_EventVal.GetUnitSide();
			Misc.PostureStance value;
			if (nullable_1.HasValue)
			{
				value = nullable_1.Value;
			}
			else
			{
				string objectID = contact_0.ObjectID;
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out value))
				{
					value = contact_0.GetStance(m_EventVal.GetUnitSide());
				}
			}
			if (value == Misc.PostureStance.Friendly)
			{
				if (int_0 < 2)
				{
					string_0 = "目标是友方。";
					int_0 = 2;
				}
				return false;
			}
			if (bool_2 && value == Misc.PostureStance.Neutral)
			{
				if (int_0 < 3)
				{
					string_0 = "目标是中立的。";
					int_0 = 3;
				}
				return false;
			}
			if (InitClient(contact_0).Contains(contact_0))
			{
				if (int_0 < 4)
				{
					string_0 = "目标位于禁航区域内。";
					int_0 = 4;
				}
				return false;
			}
			switch (mission_0.MissionClass)
			{
			case Mission._MissionClass.Patrol:
			{
				byte? b5 = (byte?)nullable_0;
				if ((b5.HasValue ? new bool?(b5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					switch (((Patrol)mission_0).Type)
					{
					case GlobalVariables.PatrolType.ASW:
						if ((int)(contact_0.Type - 3) <= 1)
						{
							ActiveUnit_Weaponry weaponry12 = m_EventVal.Weaponry;
							Contact contact_12 = contact_0;
							Doctrine doctrine9 = m_EventVal.Doctrine;
							string string_8 = "";
							int int_10 = 0;
							if (!weaponry12.PopConsumer(contact_12, bool_1: true, doctrine9, ref string_8, ref int_10) && contact_0.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Unknown)
							{
								return false;
							}
							break;
						}
						if (int_0 < 5)
						{
							string_0 = "未找到相关的目标类型。";
							int_0 = 5;
						}
						return false;
					case GlobalVariables.PatrolType.ASuW_Naval:
					{
						Contact_Base.ContactType type3 = contact_0.Type;
						if (type3 != Contact_Base.ContactType.Surface && type3 != Contact_Base.ContactType.UndeterminedNaval)
						{
							if (int_0 < 5)
							{
								string_0 = "未找到相关的目标类型。";
								int_0 = 5;
							}
							return false;
						}
						ActiveUnit_Weaponry weaponry11 = m_EventVal.Weaponry;
						Contact contact_11 = contact_0;
						Doctrine doctrine8 = m_EventVal.Doctrine;
						string string_7 = "";
						int int_9 = 0;
						if (!weaponry11.PopConsumer(contact_11, bool_1: true, doctrine8, ref string_7, ref int_9) && contact_0.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Unknown)
						{
							return false;
						}
						break;
					}
					case GlobalVariables.PatrolType.AAW:
						switch (contact_0.Type)
						{
						default:
							if (int_0 < 5)
							{
								string_0 = "未找到相关的目标类型。";
								int_0 = 5;
							}
							return false;
						case Contact_Base.ContactType.Orbital:
							if (m_EventVal.IsAircraft && ((Aircraft)m_EventVal).Loadout.Role != Loadout.LoadoutRole.AntiSatellite_Intercept)
							{
								return false;
							}
							break;
						case Contact_Base.ContactType.Missile:
							if (((Weapon)contact_0.ActualUnit).IsAAW)
							{
								if (int_0 < 5)
								{
									string_0 = "未找到相关的目标类型。";
									int_0 = 5;
								}
								return false;
							}
							break;
						case Contact_Base.ContactType.Air:
							break;
						}
						break;
					case GlobalVariables.PatrolType.ASuW_Land:
					{
						Contact_Base.ContactType type4 = contact_0.Type;
						if (type4 != Contact_Base.ContactType.Aimpoint && (int)(type4 - 7) > 1)
						{
							if (int_0 < 5)
							{
								string_0 = "未找到相关的目标类型。";
								int_0 = 5;
							}
							return false;
						}
						break;
					}
					case GlobalVariables.PatrolType.ASuW_Mixed:
						switch (contact_0.Type)
						{
						case Contact_Base.ContactType.Surface:
						{
							ActiveUnit_Weaponry weaponry10 = m_EventVal.Weaponry;
							Contact contact_10 = contact_0;
							Doctrine doctrine7 = m_EventVal.Doctrine;
							string string_6 = "";
							int int_8 = 0;
							if (!weaponry10.PopConsumer(contact_10, bool_1: true, doctrine7, ref string_6, ref int_8) && contact_0.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Unknown)
							{
								return false;
							}
							break;
						}
						default:
							if (int_0 < 5)
							{
								string_0 = "未找到相关的目标类型。";
								int_0 = 5;
							}
							return false;
						case Contact_Base.ContactType.UndeterminedNaval:
						case Contact_Base.ContactType.Aimpoint:
						case Contact_Base.ContactType.Facility_Fixed:
						case Contact_Base.ContactType.Facility_Mobile:
							break;
						}
						break;
					case GlobalVariables.PatrolType.SEAD:
					{
						float? num = contact_0.MaxPotentialActiveSensorRange_AAW();
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() < 10f) : null).GetValueOrDefault())
						{
							if (int_0 < 5)
							{
								string_0 = "未找到相关的目标类型（范围大于10海里的空中搜索雷达）。";
								int_0 = 5;
							}
							return false;
						}
						switch (contact_0.IDStatus)
						{
						case Contact_Base.IdentificationStatus.Unknown:
						case Contact_Base.IdentificationStatus.KnownDomain:
						{
							bool flag6 = false;
							List<KeyValuePair<int, EmissionContainer>> list = new List<KeyValuePair<int, EmissionContainer>>(contact_0.DetectedEmissions.Count);
							foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_0.DetectedEmissions)
							{
								list.Add(detectedEmission);
							}
							foreach (KeyValuePair<int, EmissionContainer> item in list)
							{
								if (item.Value.Age <= 30f)
								{
									Sensor associatedSensor = item.Value.GetAssociatedSensor(item.Key, m_EventVal.ParentScen);
									if (associatedSensor.IsPureIlluminator || associatedSensor.IsFireControlRadar)
									{
										flag6 = true;
										break;
									}
								}
							}
							if (!flag6)
							{
								if (int_0 < 6)
								{
									string_0 = "未找到相关的目标类型。";
									int_0 = 6;
								}
								return false;
							}
							break;
						}
						case Contact_Base.IdentificationStatus.KnownType:
						{
							if (contact_0.ActualUnit.IsFacility)
							{
								IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = ((Facility)contact_0.ActualUnit).EnableBridge();
								if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
								{
									if (int_0 < 6)
									{
										string_0 = "未找到相关的目标类型。";
										int_0 = 6;
									}
									return false;
								}
							}
							bool flag5 = false;
							ActiveUnit_Weaponry weaponry9 = m_EventVal.Weaponry;
							Contact contact_9 = contact_0;
							Doctrine._GunStrafeGroundTargets? nullable_3 = null;
							foreach (Weapon item2 in (IEnumerable<Weapon>)weaponry9.PrepareConsumer(contact_9, ref nullable_3))
							{
								if (!item2.IsAntiradar)
								{
									flag5 = true;
									break;
								}
							}
							if (!flag5 && contact_0.DetectedEmissions.Count == 0)
							{
								if (int_0 < 6)
								{
									string_0 = "未找到相关的目标类型。";
									int_0 = 6;
								}
								return false;
							}
							break;
						}
						case Contact_Base.IdentificationStatus.KnownClass:
						case Contact_Base.IdentificationStatus.PreciseID:
						{
							num = contact_0.MaxPotentialWeaponRange_AAW();
							bool? flag3 = (num.HasValue ? new bool?(num.GetValueOrDefault() < 1f) : null);
							if (flag3.GetValueOrDefault(true))
							{
								num = contact_0.MaxPotentialActiveSensorRange_AAW();
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() < 10f) : null).GetValueOrDefault() && flag3.HasValue)
								{
									if (int_0 < 6)
									{
										string_0 = "未找到相关的目标类型。";
										int_0 = 6;
									}
									return false;
								}
							}
							bool flag4 = false;
							ActiveUnit_Weaponry weaponry8 = m_EventVal.Weaponry;
							Contact contact_8 = contact_0;
							Doctrine._GunStrafeGroundTargets? nullable_2 = null;
							foreach (Weapon item3 in (IEnumerable<Weapon>)weaponry8.PrepareConsumer(contact_8, ref nullable_2))
							{
								if (!item3.IsAntiradar)
								{
									flag4 = true;
									break;
								}
							}
							if (!flag4 && contact_0.DetectedEmissions.Count == 0)
							{
								if (int_0 < 6)
								{
									string_0 = "未找到相关的目标类型。";
									int_0 = 6;
								}
								return false;
							}
							break;
						}
						}
						break;
					}
					case GlobalVariables.PatrolType.SeaControl:
						if ((int)(contact_0.Type - 2) <= 2)
						{
							ActiveUnit_Weaponry weaponry7 = m_EventVal.Weaponry;
							Contact contact_7 = contact_0;
							Doctrine doctrine6 = m_EventVal.Doctrine;
							string string_5 = "";
							int int_7 = 0;
							if (!weaponry7.PopConsumer(contact_7, bool_1: true, doctrine6, ref string_5, ref int_7) && contact_0.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Unknown)
							{
								return false;
							}
							break;
						}
						if (int_0 < 5)
						{
							string_0 = "未找到相关的目标类型。";
							int_0 = 5;
						}
						return false;
					}
				}
				else
				{
					ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
					Contact contact_2 = contact_0;
					Doctrine doctrine10 = m_EventVal.Doctrine;
					string string_9 = "";
					int int_11 = 0;
					if (!weaponry2.PopConsumer(contact_2, bool_1: true, doctrine10, ref string_9, ref int_11))
					{
						if (!m_EventVal.IsAircraft)
						{
							if (int_0 < 5)
							{
								string_0 = "可用武器不能攻击任何相关目标。";
								int_0 = 5;
							}
							return false;
						}
						Aircraft aircraft2 = (Aircraft)m_EventVal;
						if (Information.IsNothing(aircraft2.Loadout))
						{
							if (int_0 < 6)
							{
								string_0 = "未找到相关的目标类型。";
								int_0 = 6;
							}
							return false;
						}
						if ((aircraft2.Loadout.Role != Loadout.LoadoutRole.Maritime_Surveillance || contact_0.Type != Contact_Base.ContactType.Surface) && (aircraft2.Loadout.Role != Loadout.LoadoutRole.ASW_Patrol || contact_0.Type != Contact_Base.ContactType.Surface) && (aircraft2.Loadout.Role != Loadout.LoadoutRole.Area_Surveillance || !contact_0.IsLandContact))
						{
							if (int_0 < 6)
							{
								string_0 = "未找到相关的目标类型。";
								int_0 = 6;
							}
							return false;
						}
					}
				}
				Patrol patrol = (Patrol)mission_0;
				bool flag7 = false;
				if (patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
				{
					Weapon weapon_ = m_EventVal.Weaponry.RevertConsumer(contact_0);
					Weapon weapon_2 = m_EventVal.Weaponry.CloneFacade(contact_0);
					Weapon weapon_3 = m_EventVal.Weaponry.CountFacade(contact_0, bool_1: true);
					Weapon weapon_4 = m_EventVal.Weaponry.CustomizeFacade(contact_0, bool_1: true);
					ActiveUnit_Weaponry weaponry3 = m_EventVal.Weaponry;
					Contact contact_3 = contact_0;
					Doctrine doctrine11 = m_EventVal.Doctrine;
					string string_10 = "";
					int int_2 = 0;
					if (weaponry3.PopConsumer(contact_3, bool_1: true, doctrine11, ref string_10, ref int_2) && TargetIsEligibleBasedOnWeaponRange(contact_0, value, bool_0: true, Doctrine._UseShootTourists.No, weapon_, weapon_3, weapon_4, weapon_2))
					{
						flag7 = true;
					}
				}
				if (!flag7)
				{
					if (!bool_1 && (!patrol.HasProsecutionArea || !m_EventVal.GetIsInsideThisArea(patrol.ProsecutionArea, m_EventVal.ParentScen, bool_0: true)))
					{
						if (value == Misc.PostureStance.Unfriendly)
						{
							if (int_0 < 7)
							{
								string_0 = "Unit not on station.";
								int_0 = 7;
							}
							return false;
						}
						float num2 = 0f;
						float num3 = 0f;
						ActiveUnit_Weaponry weaponry4 = m_EventVal.Weaponry;
						Contact contact_4 = contact_0;
						Doctrine doctrine2 = m_EventVal.Doctrine;
						string string_2 = "";
						int int_3 = 0;
						if (!weaponry4.PopConsumer(contact_4, bool_1: true, doctrine2, ref string_2, ref int_3))
						{
							if (int_0 < 7)
							{
								string_0 = "Unit not on station.";
								int_0 = 7;
							}
							return false;
						}
						num3 = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine)?.GetMaxRangeForThisTarget(m_EventVal, contact_0, bool_0: true, m_EventVal.Doctrine, bool_1: false) ?? 0f;
						float? attackDistance_Aircraft = patrol.AttackDistance_Aircraft;
						num2 = (attackDistance_Aircraft.HasValue ? ((float)((double?)attackDistance_Aircraft + (double)num3 * 0.8).Value) : ((float)Math.Max(10f + num3, (double)num3 * 1.2)));
						if (Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0) > num2)
						{
							if (int_0 < 7)
							{
								string_0 = "Unit not on station.";
								int_0 = 7;
							}
							return false;
						}
					}
					bool flag8 = false;
					if (patrol.HasProsecutionArea)
					{
						if (!contact_0.GetIsInsideThisArea(patrol.PatrolArea, m_EventVal.ParentScen, bool_0: true) && !contact_0.GetIsInsideThisArea(patrol.ProsecutionArea, m_EventVal.ParentScen, bool_0: true))
						{
							if (int_0 < 7)
							{
								string_0 = "警戒区域内未发现相关的目标类型。";
								int_0 = 7;
							}
							return false;
						}
						flag8 = true;
					}
					else if (!((Patrol)mission_0).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen) && !flag8 && !contact_0.GetIsInsideThisArea(patrol.PatrolArea, m_EventVal.ParentScen, bool_0: true))
					{
						if (int_0 < 7)
						{
							string_0 = "No relevant contact types found inside the patrol area.";
							int_0 = 7;
						}
						return false;
					}
				}
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact_0.ObjectID, out var value2))
				{
					value2 = contact_0.GetStance(m_EventVal.GetUnitSide());
				}
				if (value2 != 0 && value2 != Misc.PostureStance.Unknown)
				{
					Weapon weapon_5 = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine, bool_4: true);
					if (weapon_5 == null)
					{
						return false;
					}
					Weapon weapon_6 = weapon_5;
					bool? nullable_4 = null;
					Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_6, ref nullable_4);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_5, ref contact_0, ref _WRA_WeaponTargetType_, m_EventVal.GetUnitSide().ObjectID);
					Doctrine doctrine3 = m_EventVal.Doctrine;
					Scenario parentScen = weapon_5.ParentScen;
					Weapon weapon_7 = weapon_5;
					int? nullable_5 = null;
					int? nullable_6 = null;
					nullable_6 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, parentScen, weapon_7, wRA_WeaponTargetType_, bool_0: false, ref nullable_5, ref nullable_6);
					if ((nullable_6.HasValue ? new bool?(nullable_6.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						return false;
					}
				}
				return true;
			}
			case Mission._MissionClass.Strike:
			{
				if (IsEscort)
				{
					if (m_EventVal.IsAircraft)
					{
						bool flag = ((Aircraft)m_EventVal).AI.ContactIsRelevantToEscortsLoadout(contact_0);
						byte? b = (byte?)nullable_0;
						bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						if (flag2.GetValueOrDefault(true) && flag && flag2.HasValue)
						{
							return true;
						}
						if (!flag)
						{
							if (int_0 < 5)
							{
								string_0 = "没有任何与护航飞机挂载相关的目标。";
								int_0 = 5;
							}
							return false;
						}
					}
					for (int i = unitSide.Units.Count - 1; i >= 0; i += -1)
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = unitSide.Units[i];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							continue;
						}
						if (activeUnit.IsGroup || activeUnit.AI.IsEscort)
						{
							continue;
						}
						Mission mission = activeUnit.AssignedMissionOrPackage();
						if (mission == null || mission != mission_0 || !activeUnit.IsOperating())
						{
							continue;
						}
						Strike strike = (Strike)mission_0;
						int int_ = strike.Escort_ResponseRadius;
						if (activeUnit.IsAircraft)
						{
							Aircraft aircraft = (Aircraft)activeUnit;
							if (aircraft.Loadout.Role == Loadout.LoadoutRole.NavalOnly_SEAD_ARM || aircraft.Loadout.Role == Loadout.LoadoutRole.NavalOnly_SEAD_TALD || aircraft.Loadout.Role == Loadout.LoadoutRole.LandOnly_SEAD_TALD || aircraft.Loadout.Role == Loadout.LoadoutRole.LandOnly_SEAD_ARM || aircraft.Loadout.Role == Loadout.LoadoutRole.LandNaval_SEAD_TALD || aircraft.Loadout.Role == Loadout.LoadoutRole.LandNaval_SEAD_ARM)
							{
								int_ = strike.Escort_ResponseRadius_SEAD;
							}
						}
						if (!ContactIsThreatToUnit(contact_0, activeUnit, int_))
						{
							continue;
						}
						return true;
					}
					break;
				}
				Strike strike_ = (Strike)mission_0;
				if (!bool_0 && !IncludeClient(ref strike_, value))
				{
					if (int_0 < 6)
					{
						string_0 = "没有找到与对战关系相关的目标。";
						int_0 = 6;
					}
					return false;
				}
				switch (((Strike)mission_0).Type)
				{
				case Strike.StrikeType.Air_Intercept:
					switch (contact_0.Type)
					{
					default:
						if (int_0 < 7)
						{
							string_0 = "没有找到此任务类型的相关目标（空中拦截）。";
							int_0 = 7;
						}
						return false;
					case Contact_Base.ContactType.Missile:
						return !((Weapon)contact_0.ActualUnit).IsAAW;
					case Contact_Base.ContactType.Air:
						return true;
					case Contact_Base.ContactType.Orbital:
						break;
					}
					if (m_EventVal.IsAircraft && ((Aircraft)m_EventVal).Loadout.Role != Loadout.LoadoutRole.AntiSatellite_Intercept)
					{
						return false;
					}
					break;
				case Strike.StrikeType.Land_Strike:
				{
					Contact_Base.ContactType type = contact_0.Type;
					if (type != Contact_Base.ContactType.Aimpoint && (int)(type - 7) > 1)
					{
						if (int_0 < 7)
						{
							string_0 = "未找到相关的目标类型。";
							int_0 = 7;
						}
						return false;
					}
					if (strike_.TargetCount <= 0)
					{
						if (strike_.RTB_When_Target_Destroyed && strike_.TargetCount == 0)
						{
							if (int_0 < 9)
							{
								string_0 = "该任务只能针对预先计划好的目标，而目标清单为空。";
								int_0 = 9;
							}
							return false;
						}
						return true;
					}
					if (contact_0.GetIsSpecificTargetForThisStrike(strike_))
					{
						return true;
					}
					if (strike_.RTB_When_Target_Destroyed)
					{
						break;
					}
					byte? b3 = (byte?)nullable_0;
					if (!(b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						break;
					}
					ActiveUnit_Weaponry weaponry5 = m_EventVal.Weaponry;
					Contact contact_5 = contact_0;
					Doctrine doctrine4 = m_EventVal.Doctrine;
					string string_3 = "";
					int int_5 = 0;
					if (weaponry5.PopConsumer(contact_5, bool_1: true, doctrine4, ref string_3, ref int_5))
					{
						b3 = (byte?)nullable_0;
						if (!(b3.HasValue ? new bool?(b3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							break;
						}
						return true;
					}
					if (int_0 < 8)
					{
						string_0 = "可用武器不能攻击任何相关目标。";
						int_0 = 8;
					}
					return false;
				}
				case Strike.StrikeType.Maritime_Strike:
				{
					Contact_Base.ContactType type2 = contact_0.Type;
					if (type2 != Contact_Base.ContactType.Surface && (int)(type2 - 4) > 1)
					{
						if (int_0 < 7)
						{
							string_0 = "未找到相关的目标类型。";
							int_0 = 7;
						}
						return false;
					}
					if (strike_.TargetCount <= 0)
					{
						if (strike_.RTB_When_Target_Destroyed && strike_.TargetCount == 0)
						{
							if (int_0 < 9)
							{
								string_0 = "该任务只能针对预先计划好的目标，而目标清单为空。";
								int_0 = 9;
							}
							return false;
						}
						return true;
					}
					if (contact_0.GetIsSpecificTargetForThisStrike(strike_))
					{
						return true;
					}
					if (strike_.RTB_When_Target_Destroyed)
					{
						break;
					}
					byte? b4 = (byte?)nullable_0;
					if (!(b4.HasValue ? new bool?(b4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						break;
					}
					ActiveUnit_Weaponry weaponry6 = m_EventVal.Weaponry;
					Contact contact_6 = contact_0;
					Doctrine doctrine5 = m_EventVal.Doctrine;
					string string_4 = "";
					int int_6 = 0;
					if (weaponry6.PopConsumer(contact_6, bool_1: true, doctrine5, ref string_4, ref int_6))
					{
						b4 = (byte?)nullable_0;
						if (!(b4.HasValue ? new bool?(b4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							break;
						}
						return true;
					}
					if (int_0 < 8)
					{
						string_0 = "可用武器不能攻击任何相关目标。";
						int_0 = 8;
					}
					return false;
				}
				case Strike.StrikeType.Sub_Strike:
					if ((int)(contact_0.Type - 3) <= 1)
					{
						if (strike_.TargetCount <= 0)
						{
							if (strike_.RTB_When_Target_Destroyed && strike_.TargetCount == 0)
							{
								if (int_0 < 9)
								{
									string_0 = "该任务只能针对预先计划好的目标，而目标清单为空。";
									int_0 = 9;
								}
								return false;
							}
							return true;
						}
						if (contact_0.GetIsSpecificTargetForThisStrike(strike_))
						{
							return true;
						}
						if (strike_.RTB_When_Target_Destroyed)
						{
							break;
						}
						byte? b2 = (byte?)nullable_0;
						if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							break;
						}
						ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
						Contact contact_ = contact_0;
						Doctrine doctrine = m_EventVal.Doctrine;
						string string_ = "";
						int int_4 = 0;
						if (weaponry.PopConsumer(contact_, bool_1: true, doctrine, ref string_, ref int_4))
						{
							b2 = (byte?)nullable_0;
							if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								break;
							}
							return true;
						}
						if (int_0 < 8)
						{
							string_0 = "可用武器不能攻击任何相关目标。";
							int_0 = 8;
						}
						return false;
					}
					if (int_0 < 7)
					{
						string_0 = "未找到相关的目标类型。";
						int_0 = 7;
					}
					return false;
				}
				break;
			}
			}
			if (int_0 < 1)
			{
				string_0 = "未找到相关的目标类型。";
				int_0 = 1;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100034", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void InitializeCycleFerry()
	{
		_FerryCycleLegIsOutbound = true;
	}

	public void ChangeCycleLeg()
	{
		_FerryCycleLegIsOutbound = !_FerryCycleLegIsOutbound;
	}

	public void DeterminePrimaryTarget_SEAD_Prioritize(List<Contact> list_0, int int_0, float float_0, float float_1)
	{
		try
		{
			if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
			{
				return;
			}
			List<Contact> list = (from theC0 in list_0.Where(delegate(Contact theC)
				{
					bool? flag5;
					bool? flag8;
					if (theC.IsAir_Missile_Orbital_Contact)
					{
						flag5 = false;
					}
					else
					{
						float? num2 = theC.MaxPotentialActiveSensorRange_AAW();
						bool? flag6;
						bool? flag7 = (flag6 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() > 0f) : null));
						if (flag7.HasValue && flag6.GetValueOrDefault())
						{
							flag5 = true;
						}
						else
						{
							num2 = theC.MaxPotentialWeaponRange_AAW();
							flag7 = (flag8 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() > 0f) : null));
							flag5 = ((!flag7.HasValue) ? null : (flag8.GetValueOrDefault() | flag6));
						}
					}
					flag8 = flag5;
					return flag8.GetValueOrDefault();
				})
				orderby theC0.MaxPotentialWeaponRange_AAW() * 2f + theC0.MaxPotentialActiveSensorRange_AAW() descending
				select theC0).ToList();
			if (!Information.IsNothing(list) && list.Count > 0)
			{
				if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
				{
					if (m_EventVal.IsGroupWingman())
					{
						DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(m_EventVal, list, float_0, float_1);
					}
					else
					{
						DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(list, int_0);
					}
					return;
				}
				if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
				{
					list = (from theC0 in m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, list_0).Where(delegate(Contact theC)
						{
							bool? flag;
							bool? flag4;
							if (theC.IsAir_Missile_Orbital_Contact)
							{
								flag = false;
							}
							else
							{
								float? num = theC.MaxPotentialActiveSensorRange_AAW();
								bool? flag2;
								bool? flag3 = (flag2 = (num.HasValue ? new bool?(num.GetValueOrDefault() > 0f) : null));
								if (flag3.HasValue && flag2.GetValueOrDefault())
								{
									flag = true;
								}
								else
								{
									num = theC.MaxPotentialWeaponRange_AAW();
									flag3 = (flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() > 0f) : null));
									flag = ((!flag3.HasValue) ? null : (flag4.GetValueOrDefault() | flag2));
								}
							}
							flag4 = flag;
							return flag4.GetValueOrDefault();
						})
						orderby theC0.MaxPotentialWeaponRange_AAW() * 2f + theC0.MaxPotentialActiveSensorRange_AAW() descending
						select theC0).ToList();
				}
				PrimaryTarget = list[0];
			}
			else
			{
				PrimaryTarget = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100035", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private HashSet<Contact> CheckClient()
	{
		return new HashSet<Contact>(Targets_ReadOnly);
	}

	private void ConcatClient()
	{
		try
		{
			int num = m_EventVal.GetUnitSide().WeaponSalvos.Length;
			if (num <= 0)
			{
				return;
			}
			Lazy<HashSet<Contact>> lazy = new Lazy<HashSet<Contact>>(CheckClient);
			for (int i = num - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo;
				try
				{
					if (m_EventVal.GetUnitSide().WeaponSalvos.Length != 0)
					{
						if (m_EventVal.GetUnitSide().WeaponSalvos.Length - 1 < i)
						{
							i = m_EventVal.GetUnitSide().WeaponSalvos.Length - 1;
						}
						weaponSalvo = m_EventVal.GetUnitSide().WeaponSalvos[i];
						goto IL_010a;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200425", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				continue;
				IL_010a:
				if (weaponSalvo == null || weaponSalvo.ShootersList == null)
				{
					continue;
				}
				int num2 = weaponSalvo.ShootersList.Length;
				if (num2 <= 0)
				{
					continue;
				}
				for (int j = num2 - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter;
					try
					{
						if (weaponSalvo.ShootersList.Length == 0)
						{
							continue;
						}
						if (weaponSalvo.ShootersList.Length - 1 < j)
						{
							j = weaponSalvo.ShootersList.Length - 1;
						}
						if (j < 0)
						{
							break;
						}
						shooter = weaponSalvo.ShootersList[j];
						goto IL_0208;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200426", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					continue;
					IL_0208:
					if (shooter != null && Operators.CompareString(shooter.ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0 && shooter.QuantityAssigned > shooter.QuantityFired && !lazy.Value.Contains(weaponSalvo.Target))
					{
						TargetingEntry targetingEntry = new TargetingEntry();
						targetingEntry.Target = weaponSalvo.Target;
						targetingEntry.Behavior = TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
						if (_TargetList == null)
						{
							_TargetList = new ObservableDictionary<string, TargetingEntry>();
						}
						if (!_TargetList.ContainsKey(targetingEntry.Target.ObjectID))
						{
							AddTargetList_Threadsafe(targetingEntry.Target.ObjectID, targetingEntry);
						}
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 200640", exception_3.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal AmbiguityLevel InterruptClient(Contact contact_0, float float_0)
	{
		if (contact_0.UncertaintyArea != null && contact_0.UncertaintyArea.Count != 0)
		{
			float num = Module_Contact.StartTokenizer(contact_0, m_EventVal);
			float num2 = Module_Contact.RunTokenizer(contact_0, m_EventVal.GetLatitude(), m_EventVal.GetLongitude());
			if ((num > float_0 || num2 > float_0) && contact_0.HeldFor < 15f)
			{
				return AmbiguityLevel.ExtremelyAmbiguous;
			}
			if (num <= float_0 / 3f && num2 <= float_0 / 3f)
			{
				if (num <= float_0 / 9f && num2 <= float_0 / 9f)
				{
					if (num <= float_0 / 27f && num2 <= float_0 / 27f)
					{
						if (num <= 0f && num2 <= 0f)
						{
							return AmbiguityLevel.NoAmbiguity;
						}
						return AmbiguityLevel.VeryAccuratePosition;
					}
					return AmbiguityLevel.AccuratePosition;
				}
				return AmbiguityLevel.QuiteAmbiguous;
			}
			return AmbiguityLevel.VeryAmbiguous;
		}
		return AmbiguityLevel.NoAmbiguity;
	}

	public virtual void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
		if (!EvaluateTargets_Enabled)
		{
			return;
		}
		try
		{
			CheckPossibleABMOrASATEngagement = false;
			if (m_EventVal == null)
			{
				return;
			}
			ConcatClient();
			_ = IsInsidePatrolArea_10nmBuffer;
			if (PrimaryTarget != null)
			{
				if (PrimaryTarget.GetIsDestroyed(m_EventVal.ParentScen))
				{
					DropTarget(PrimaryTarget);
				}
				else if (PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint || PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
				{
					Side unitSide = m_EventVal.GetUnitSide();
					ref ActiveUnit eventVal = ref m_EventVal;
					Contact contact_ = PrimaryTarget;
					TargetingEntry._TargetingBehavior _TargetingBehavior_ = TargetingEntry._TargetingBehavior.AutoTargeted;
					int num = unitSide.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref eventVal, ref contact_, ref _TargetingBehavior_);
					PrimaryTarget = contact_;
					if (num == 0)
					{
						DropTarget(PrimaryTarget);
					}
				}
			}
			bool flag = m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && ((Patrol)m_EventVal.AssignedMissionOrPackage()).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen);
			bool flag2 = m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && ((Patrol)m_EventVal.AssignedMissionOrPackage()).GetInvestigateWithinWeaponRange(m_EventVal.ParentScen);
			if (Targets_ReadOnly.Length == 0)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			Doctrine._UseShootTourists useShootTourists_ = Doctrine._UseShootTourists.No;
			bool hasValue;
			if (hasValue = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).HasValue)
			{
				useShootTourists_ = m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
			}
			Contact[] targets_ReadOnly = Targets_ReadOnly;
			Weapon expression = null;
			Weapon expression2 = null;
			for (int i = 0; i < targets_ReadOnly.Length; i = checked(i + 1))
			{
				Contact contact_2 = targets_ReadOnly[i];
				if (contact_2 == null)
				{
					continue;
				}
				TargetingEntry._TargetingBehavior? targetingBehavior = null;
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact_2.ObjectID, out var value))
				{
					value = contact_2.GetStance(m_EventVal.GetUnitSide());
				}
				if (value == Misc.PostureStance.Friendly)
				{
					list.Add(contact_2);
					continue;
				}
				if (contact_2.GetIsDestroyed(m_EventVal.ParentScen))
				{
					if (!m_EventVal.Sensory.IsIlluminatingThisContact(contact_2))
					{
						list.Add(contact_2);
						continue;
					}
				}
				else if ((bool_1 || m_EventVal.ParentScen.FifthSecondIsChangingOnThisPulse) && m_EventVal.IsAircraft)
				{
					if (contact_2.Type == Contact_Base.ContactType.Submarine)
					{
						ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
						Contact contact_3 = contact_2;
						Doctrine doctrine = m_EventVal.Doctrine;
						string string_ = "";
						int int_ = 0;
						if (!weaponry.PopConsumer(contact_3, bool_1: true, doctrine, ref string_, ref int_) && value != Misc.PostureStance.Unknown && !m_EventVal.Sensory.IsIlluminatingThisContact(contact_2))
						{
							list.Add(contact_2);
							if (Information.IsNothing(targetingBehavior))
							{
								targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
							}
							short? num2 = (short?)targetingBehavior;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								string text = "";
								if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
								{
									text = " (" + m_EventVal.UnitClass + ")";
								}
								m_EventVal.AddMessage(m_EventVal.Name + text + "正在丢弃" + contact_2.Name + "从目标清单移除（原因：没有合适的武器）。", "选择目标事件", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							}
							continue;
						}
					}
					else if (contact_2.IsSurfaceContact)
					{
						if (Information.IsNothing(targetingBehavior))
						{
							targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
						}
						short? num3 = (short?)targetingBehavior;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
							Contact contact_4 = contact_2;
							Doctrine doctrine2 = m_EventVal.Doctrine;
							string string_2 = "";
							int int_2 = 0;
							if (!weaponry2.PopConsumer(contact_4, bool_1: true, doctrine2, ref string_2, ref int_2) && value != Misc.PostureStance.Unknown && !m_EventVal.IsPaintingATarget && !m_EventVal.WillNeedToPaintATarget)
							{
								list.Add(contact_2);
								string text2 = "";
								if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
								{
									text2 = " (" + m_EventVal.UnitClass + ")";
								}
								m_EventVal.AddMessage(m_EventVal.Name + text2 + "正在丢弃" + contact_2.Name + "从目标清单移除（原因：没有合适的武器）。", "选择目标事件", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
								continue;
							}
						}
					}
				}
				if ((bool_1 || m_EventVal.ParentScen.FifthSecondIsChangingOnThisPulse) && (!m_EventVal.Navigator.HasFlightPlan || Targets_ReadOnly.Count() > 1) && TargetIsWasteOfAmmo(contact_2))
				{
					if (Information.IsNothing(targetingBehavior))
					{
						targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
					}
					short? num4 = (short?)targetingBehavior;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						string text3 = "";
						if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
						{
							text3 = " (" + m_EventVal.UnitClass + ")";
						}
						m_EventVal.AddMessage(m_EventVal.Name + text3 + "正在丢弃" + contact_2.Name + "从目标清单移除（原因：目标是浪费弹药）。", "选择目标事件", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
						list.Add(contact_2);
						continue;
					}
				}
				switch (contact_2.Type)
				{
				case Contact_Base.ContactType.Installation:
				case Contact_Base.ContactType.AirBase:
				case Contact_Base.ContactType.NavalBase:
				case Contact_Base.ContactType.MobileGroup:
					list.Add(contact_2);
					continue;
				case Contact_Base.ContactType.Sonobuoy:
					list.Add(contact_2);
					continue;
				}
				if (contact_2.IsClassifiedFalseTarget)
				{
					list.Add(contact_2);
					continue;
				}
				if (contact_2.IsSubmergedContact && (m_EventVal.IsShip || m_EventVal.IsAircraft) && SeaIceProvider.PrepareWriter(contact_2.GetLongitude(), contact_2.GetLatitude()))
				{
					list.Add(contact_2);
					continue;
				}
				if ((bool_1 || m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse) && (int)value <= 1)
				{
					if (Information.IsNothing(targetingBehavior))
					{
						targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
					}
					TargetingEntry._TargetingBehavior? targetingBehavior2 = targetingBehavior;
					short? num5 = (short?)targetingBehavior2;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						list.Add(contact_2);
					}
					else
					{
						num5 = (short?)targetingBehavior2;
						if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							list.Add(contact_2);
						}
						else
						{
							num5 = (short?)targetingBehavior2;
							(num5.HasValue ? new bool?(num5.GetValueOrDefault() == 1) : null).GetValueOrDefault();
						}
					}
				}
				if (m_EventVal.IsOnActiveStrike && (Strike)m_EventVal.AssignedMissionOrPackage() != null)
				{
					Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
					if (strike.TargetCount > 0 && !contact_2.GetIsSpecificTargetForThisStrike(strike) && strike.FocusEntirelyOnStrikeTargets && !IsEscort)
					{
						list.Add(contact_2);
						continue;
					}
				}
				if ((bool_1 || m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse) && m_EventVal.IsOnActivePatrol)
				{
					if (!contact_2.IsAir_Missile_Submarine_Contact)
					{
						Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (patrol.HasProsecutionArea)
						{
							if (!contact_2.GetIsInsideThisArea(patrol.PatrolArea, m_EventVal.ParentScen, bool_0: true) && !contact_2.GetIsInsideThisArea(patrol.ProsecutionArea, m_EventVal.ParentScen, bool_0: true))
							{
								if (Information.IsNothing(targetingBehavior))
								{
									targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
								}
								short? num6 = (short?)targetingBehavior;
								bool? flag3 = (num6.HasValue ? new bool?(num6.GetValueOrDefault() != 1) : null);
								if (flag3.GetValueOrDefault(true) && !m_EventVal.Sensory.IsIlluminatingThisContact(contact_2) && flag3.HasValue)
								{
									if (!patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
									{
										list.Add(contact_2);
										string text4 = "";
										if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
										{
											text4 = " (" + m_EventVal.UnitClass + ")";
										}
										m_EventVal.AddMessage(m_EventVal.Name + text4 + "正在丢弃" + contact_2.Name + " 丢弃（原因：目标在单元警戒、巡逻区域之外）", m_EventVal.Name + " 从其目标列表" + contact_2.Name, LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
										continue;
									}
									if (Information.IsNothing(expression))
									{
										expression = m_EventVal.Weaponry.CountFacade(contact_2, bool_1: false);
									}
									if (Information.IsNothing(expression2))
									{
										expression2 = m_EventVal.Weaponry.CustomizeFacade(contact_2, bool_1: false);
									}
									if (!TargetIsEligibleBasedOnWeaponRange(contact_2, value, hasValue, useShootTourists_, m_EventVal.Weaponry.RevertConsumer(contact_2), m_EventVal.Weaponry.CountFacade(contact_2, bool_1: false), m_EventVal.Weaponry.CustomizeFacade(contact_2, bool_1: false), m_EventVal.Weaponry.CloneFacade(contact_2)))
									{
										list.Add(contact_2);
										string text5 = "";
										if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
										{
											text5 = " (" + m_EventVal.UnitClass + ")";
										}
										m_EventVal.AddMessage(m_EventVal.Name + text5 + "正在丢弃" + contact_2.Name + " 丢弃（原因：目标在单元警戒、巡逻区域和武器射程之外）", m_EventVal.Name + " 从其目标列表" + contact_2.Name, LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
										continue;
									}
								}
							}
						}
						else if (!flag && contact_2.Type != Contact_Base.ContactType.Missile && !contact_2.GetIsInsideThisArea(patrol.PatrolArea, m_EventVal.ParentScen, bool_0: true))
						{
							if (Information.IsNothing(targetingBehavior))
							{
								targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
							}
							short? num7 = (short?)targetingBehavior;
							bool? flag4 = (num7.HasValue ? new bool?(num7.GetValueOrDefault() != 1) : null);
							if (flag4.GetValueOrDefault(true) && !m_EventVal.Sensory.IsIlluminatingThisContact(contact_2) && flag4.HasValue)
							{
								if (!patrol.GetInvestigateWithinWeaponRange(m_EventVal.ParentScen))
								{
									list.Add(contact_2);
									string text6 = "";
									if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
									{
										text6 = " (" + m_EventVal.UnitClass + ")";
									}
									m_EventVal.AddMessage(m_EventVal.Name + text6 + "正在丢弃" + contact_2.Name + "来自其目标清单（原因：目标位于单元的巡逻区域之外，并且该单元未被授权在该区域外行动）。", m_EventVal.Name + " 从其目标列表" + contact_2.Name, LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
									continue;
								}
								if (Information.IsNothing(expression))
								{
									expression = m_EventVal.Weaponry.CountFacade(contact_2, bool_1: false);
								}
								if (Information.IsNothing(expression2))
								{
									expression2 = m_EventVal.Weaponry.CustomizeFacade(contact_2, bool_1: false);
								}
								if (!TargetIsEligibleBasedOnWeaponRange(contact_2, value, hasValue, useShootTourists_, m_EventVal.Weaponry.RevertConsumer(contact_2), m_EventVal.Weaponry.CountFacade(contact_2, bool_1: false), m_EventVal.Weaponry.CustomizeFacade(contact_2, bool_1: false), m_EventVal.Weaponry.CloneFacade(contact_2)))
								{
									list.Add(contact_2);
									string text7 = "";
									if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
									{
										text7 = " (" + m_EventVal.UnitClass + ")";
									}
									m_EventVal.AddMessage(m_EventVal.Name + text7 + "正在丢弃" + contact_2.Name + "从目标清单移除（原因：目标位于单元的巡逻区域和武器范围之外，并且该单元未被授权在该区域外行动）。", m_EventVal.Name + " 从其目标列表" + contact_2.Name, LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
									continue;
								}
							}
						}
					}
					if (((flag || flag2) & (contact_2.GetStance(m_EventVal.GetUnitSide()) == Misc.PostureStance.Unknown)) && TargetIsEligibleBasedOnWeaponRange(contact_2, value, hasValue, useShootTourists_, m_EventVal.Weaponry.RevertConsumer(contact_2), m_EventVal.Weaponry.CountFacade(contact_2, bool_1: false), m_EventVal.Weaponry.CustomizeFacade(contact_2, bool_1: false), m_EventVal.Weaponry.CloneFacade(contact_2)))
					{
						m_EventVal.AI.PrimaryTarget = contact_2;
						m_EventVal.Navigator.ClearPlottedCourse();
						if (flag)
						{
							m_EventVal.Navigator.AddWaypoint(new Waypoint(contact_2.GetLongitude(), contact_2.GetLatitude(), contact_2.GetCurrentAltitude(), Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
						else
						{
							Patrol patrol2 = (Patrol)m_EventVal.AssignedMissionOrPackage();
							Geopoint_Struct geopoint_Struct = Math2.FindClosestPoint(contact_2.GetLatitude(), contact_2.GetLongitude(), patrol2.PatrolArea);
							m_EventVal.Navigator.AddWaypoint(new Waypoint(geopoint_Struct.Longitude, geopoint_Struct.Latitude, contact_2.GetCurrentAltitude(), Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
					}
				}
				if (bool_1 || m_EventVal.ParentScen.FifthSecondIsChangingOnThisPulse)
				{
					if (!targetingBehavior.HasValue)
					{
						targetingBehavior = TargetingBehaviorForThisTarget(contact_2);
					}
					short? num8 = (short?)targetingBehavior;
					if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						Side unitSide2 = m_EventVal.GetUnitSide();
						ref ActiveUnit eventVal2 = ref m_EventVal;
						TargetingEntry._TargetingBehavior _TargetingBehavior_2 = TargetingEntry._TargetingBehavior.AutoTargeted;
						if (unitSide2.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref eventVal2, ref contact_2, ref _TargetingBehavior_2) == 0 && contact_2.IncomingGuidedWeapons.Length == 0)
						{
							list.Add(contact_2);
							string text8 = "";
							if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
							{
								text8 = " (" + m_EventVal.UnitClass + ")";
							}
							if (contact_2.Type != Contact_Base.ContactType.Aimpoint && contact_2.Type != Contact_Base.ContactType.ActivationPoint)
							{
								m_EventVal.AddMessage(m_EventVal.Name + text8 + "正在丢弃" + contact_2.Name + "从目标清单移除（原因：目标不是自动交战目标，并且不存在任何针对该目标的武器或任务）。", "选择目标事件", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							}
							else
							{
								m_EventVal.AddMessage(m_EventVal.Name + text8 + "已完成射击" + contact_2.Name + ".", "选择目标事件", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
							}
							continue;
						}
					}
				}
				byte? b = (byte?)contact_2.BDA_StructuralIntegrity;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					list.Add(contact_2);
					continue;
				}
				if ((bool_1 || m_EventVal.ParentScen.FifthSecondIsChangingOnThisPulse) && IsEscort)
				{
					ActiveUnit_Weaponry weaponry3 = m_EventVal.Weaponry;
					Contact contact_5 = contact_2;
					Doctrine doctrine3 = m_EventVal.Doctrine;
					string string_3 = "";
					int int_3 = 0;
					if (!weaponry3.PopConsumer(contact_5, bool_1: true, doctrine3, ref string_3, ref int_3))
					{
						list.Add(contact_2);
						continue;
					}
					if (TargetingBehaviorForThisTarget(contact_2) == TargetingEntry._TargetingBehavior.AutoTargeted && value == Misc.PostureStance.Friendly)
					{
						list.Add(contact_2);
						continue;
					}
				}
				if ((bool_1 || m_EventVal.ParentScen.MinuteIsChangingOnThisPulse) && m_EventVal.IsSubmarine && contact_2.HeadingIsKnown && contact_2.SpeedIsKnown && !RemoveClient(contact_2, bool_0: false))
				{
					list.Add(contact_2);
					string text9 = "";
					if (m_EventVal.IsAircraft && Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
					{
						text9 = " (" + m_EventVal.UnitClass + ")";
					}
					m_EventVal.AddMessage(m_EventVal.Name + text9 + "正在丢弃" + contact_2.Name + "从目标清单移除（原因：无法在当前深度以最大速度拦截目标）。", "选择目标事件", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				else if (InterruptClient(contact_2, 100f) == AmbiguityLevel.ExtremelyAmbiguous)
				{
					list.Add(contact_2);
				}
				else if (!CheckPossibleABMOrASATEngagement && (contact_2.IsBallisticTarget() || contact_2.IsSatellite))
				{
					ActiveUnit_Weaponry weaponry4 = m_EventVal.Weaponry;
					Contact contact_6 = contact_2;
					Doctrine doctrine4 = m_EventVal.Doctrine;
					string string_4 = "";
					int int_4 = 0;
					if (weaponry4.PopConsumer(contact_6, bool_1: true, doctrine4, ref string_4, ref int_4))
					{
						CheckPossibleABMOrASATEngagement = true;
					}
				}
			}
			foreach (Contact item in list)
			{
				DropTarget(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200328", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected bool TargetIsEligibleBasedOnWeaponRange(Contact contact_0, Misc.PostureStance postureStance_0, bool bool_0, Doctrine._UseShootTourists _UseShootTourists_0, Weapon weapon_0, Weapon weapon_1, Weapon weapon_2, Weapon weapon_3)
	{
		try
		{
			switch (contact_0.Type)
			{
			case Contact_Base.ContactType.Air:
				if (m_EventVal.IsSubmarine)
				{
					if (contact_0.ActualUnit != null && contact_0.ActualUnit.IsAircraft && contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownType && (uint)(((Aircraft)contact_0.ActualUnit).Type - 6001) <= 1u && (postureStance_0 == Misc.PostureStance.Hostile || postureStance_0 == Misc.PostureStance.Unfriendly) && weapon_0 != null)
					{
						float float_4 = contact_0.ChangeImporter() * weapon_0.MaxAirRange;
						if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), float_4))
						{
							return true;
						}
					}
				}
				else if (weapon_0 != null && Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) < contact_0.ChangeImporter() * weapon_0.MaxAirRange)
				{
					return true;
				}
				break;
			case Contact_Base.ContactType.Missile:
				if (m_EventVal.IsSubmarine)
				{
					return false;
				}
				if (weapon_0 != null && Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) < contact_0.ChangeImporter() * weapon_0.MaxAirRange)
				{
					return true;
				}
				break;
			case Contact_Base.ContactType.Submarine:
				if (weapon_3 == null)
				{
					break;
				}
				if (contact_0.IsClassifiedFalseTarget)
				{
					return false;
				}
				if (m_EventVal.IsSubmarine)
				{
					float maxSubsurfaceRange = weapon_3.MaxSubsurfaceRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), maxSubsurfaceRange))
					{
						return true;
					}
				}
				else if (!m_EventVal.IsFacility && !m_EventVal.IsShip)
				{
					if (SeaIceProvider.PrepareWriter(contact_0.GetLongitude(), contact_0.GetLatitude()))
					{
						return false;
					}
					float float_ = contact_0.ChangeImporter() * weapon_3.MaxSubsurfaceRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), float_))
					{
						return true;
					}
				}
				else
				{
					if (SeaIceProvider.PrepareWriter(contact_0.GetLongitude(), contact_0.GetLatitude()))
					{
						return false;
					}
					float maxSubsurfaceRange2 = weapon_3.MaxSubsurfaceRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), maxSubsurfaceRange2))
					{
						return true;
					}
				}
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.UndeterminedNaval:
				if (!bool_0 || _UseShootTourists_0 != Doctrine._UseShootTourists.Yes || weapon_1 == null)
				{
					break;
				}
				if (m_EventVal.IsSubmarine)
				{
					float maxSurfaceRange = weapon_1.MaxSurfaceRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), maxSurfaceRange))
					{
						return true;
					}
				}
				else if (!m_EventVal.IsFacility && !m_EventVal.IsShip)
				{
					float float_3 = contact_0.ChangeImporter() * weapon_1.MaxSurfaceRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), float_3))
					{
						return true;
					}
				}
				else
				{
					float maxSurfaceRange2 = weapon_1.MaxSurfaceRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), maxSurfaceRange2))
					{
						return true;
					}
				}
				break;
			case Contact_Base.ContactType.Orbital:
				if (bool_0 && _UseShootTourists_0 == Doctrine._UseShootTourists.Yes)
				{
					ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = "";
					int int_ = 0;
					if (weaponry.PopConsumer(contact_0, bool_1: true, doctrine, ref string_, ref int_) && weapon_0 != null && Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) < contact_0.ChangeImporter() * weapon_0.MaxAirRange)
					{
						return true;
					}
				}
				break;
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				if (!bool_0 || _UseShootTourists_0 != Doctrine._UseShootTourists.Yes || weapon_2 == null)
				{
					break;
				}
				if (!m_EventVal.IsSubmarine && !m_EventVal.IsFacility && !m_EventVal.IsShip)
				{
					float float_2 = weapon_2.MaxLandRange * contact_0.ChangeImporter();
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), float_2))
					{
						return true;
					}
				}
				else
				{
					float maxLandRange = weapon_2.MaxLandRange;
					if (Geodesic_Haversine.PointIsWithinDistanceFromPoint(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude(), maxLandRange))
					{
						return true;
					}
				}
				break;
			case Contact_Base.ContactType.Torpedo:
				if (m_EventVal.IsShip && weapon_3 != null && Module_Unit.RangeToUnit_Slant(m_EventVal, contact_0) < weapon_3.MaxSubsurfaceRange * 2f)
				{
					return true;
				}
				break;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 341165438765", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool RemoveClient(Contact contact_0, bool bool_0)
	{
		try
		{
			Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
			double double_ = 0.0;
			double double_2 = 0.0;
			if (Information.IsNothing(weapon))
			{
				double_ = contact_0.GetLatitude();
				double_2 = contact_0.GetLongitude();
			}
			else
			{
				float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0);
				if (num < weapon.GetMaxRangeForThisTarget(m_EventVal, contact_0, bool_0: false, m_EventVal.Doctrine, bool_1: false))
				{
					return true;
				}
				Weapon._WeaponType type = weapon.Type;
				if ((uint)(type - 2001) > 1u && type != Weapon._WeaponType.Gun && (uint)(type - 6001) > 2u)
				{
					double_ = contact_0.GetLatitude();
					double_2 = contact_0.GetLongitude();
				}
				else
				{
					float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, contact_0, bool_0: true, m_EventVal.Doctrine, bool_1: false);
					if (num <= maxRangeForThisTarget)
					{
						return true;
					}
					Geodesic_EdWilliams.CalcPoint_Williams(m_EventVal.GetLongitude(), m_EventVal.GetLatitude(), ref double_2, ref double_, num - maxRangeForThisTarget, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()));
				}
			}
			if (CanInterceptTargetAtCurrentAltSpeed(double_, double_2, contact_0.CurrentHeading, contact_0.CurrentSpeed, m_EventVal.GetCurrentAltitude(), m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude()), m_EventVal.CurrentHeading, null, bool_0: false, bool_0))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200591", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void EvaluateUnitCargoStatus(float float_0)
	{
		if (!m_EventVal.ParentScen.ThirtiethSecondIsChangingOnThisPulse || m_EventVal.IsAircraft || !(m_EventVal is ICargoHost) || m_EventVal.OnboardCargo.Count() <= 0)
		{
			return;
		}
		bool flag = false;
		List<CargoMission> list = new List<CargoMission>();
		Cargo[] gparam_ = m_EventVal.OnboardCargo;
		Cargo[] gparam_2 = new Cargo[0];
		if (m_EventVal.HasDockFacilities || m_EventVal.HasAirFacilities)
		{
			foreach (Mission mission in m_EventVal.GetUnitSide().Missions)
			{
				if (mission.MissionClass != Mission._MissionClass.Cargo)
				{
					continue;
				}
				bool flag2 = false;
				CargoMission cargoMission = (CargoMission)mission;
				foreach (ActiveUnit item in cargoMission.GetAssignedUnits_Cached(m_EventVal.ParentScen))
				{
					if (item.IsAircraft)
					{
						if (((Aircraft)item).AirOps.GetAssignedHostUnit() == m_EventVal)
						{
							flag2 = true;
						}
					}
					else if (item == m_EventVal || item.DockingOps.GetAssignedHostUnit() == m_EventVal)
					{
						flag2 = true;
					}
					if (flag2)
					{
						list.Add(cargoMission);
						break;
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (CargoMission item2 in list)
				{
					foreach (CargoManifestItem item3 in item2.CargoToUnload)
					{
						if (item3.quantity == 0)
						{
							continue;
						}
						int num = item3.quantity;
						for (int i = gparam_.Count() - 1; i >= 0; i += -1)
						{
							Cargo cargo = gparam_[i];
							if (Operators.CompareString(cargo.CargoObjectID, item3.ObjectID, TextCompare: false) == 0)
							{
								if ((item2.AllowSelfDeliveryFromCargo || item2.AllowAllSelfDelivery) && cargo.CargoObjectActiveUnit != null && cargo.CargoObjectActiveUnit.IsVehicle && cargo.CargoObjectActiveUnit.AssignedMissionOrPackage() == item2)
								{
									ArrayExtensions.Add(ref gparam_2, cargo);
								}
								ArrayExtensions.Remove(ref gparam_, cargo);
								num--;
								if (num < 1)
								{
									break;
								}
							}
						}
					}
				}
			}
		}
		Cargo[] array = gparam_2;
		Cargo[] array2 = array;
		foreach (Cargo theAC in array2)
		{
			ArrayExtensions.Add(ref gparam_, theAC);
		}
		array = gparam_;
		Cargo[] array3 = array;
		foreach (Cargo cargo2 in array3)
		{
			if (!cargo2.RestartProperty())
			{
				continue;
			}
			ActiveUnit cargoObjectActiveUnit = cargo2.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit == null)
			{
				continue;
			}
			if (!m_EventVal.IsShip && !m_EventVal.IsSubmarine)
			{
				if (m_EventVal.IsFixedFacility && ((Platform)cargoObjectActiveUnit).RepresentsMobileGroundUnit)
				{
					Cargo.UnloadSingleCargoAtLocation(m_EventVal, ref m_EventVal.OnboardCargo, cargo2, m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.ParentScen, m_EventVal.GetUnitSide(), bool_0: false);
					flag = true;
				}
			}
			else if (cargoObjectActiveUnit.IsVehicle && ((Vehicle)cargoObjectActiveUnit).IsOutOfFuel)
			{
				ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps;
				DockFacility dockFacility_ = null;
				if (dockingOps.CanHostThisBoat(cargoObjectActiveUnit, ref dockFacility_))
				{
					ArrayExtensions.Remove(ref m_EventVal.OnboardCargo, cargo2);
					cargoObjectActiveUnit.DockingOps.UnloadFromCargo();
					m_EventVal.DockingOps.AddThisBoat(cargoObjectActiveUnit);
					flag = true;
				}
				else if (m_EventVal.IsShip && ((Ship)m_EventVal).Flags.CanLaunchCargoDirectlyToSea)
				{
					Cargo.UnloadSingleCargoAtLocation(m_EventVal, ref m_EventVal.OnboardCargo, cargo2, m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.ParentScen, m_EventVal.GetUnitSide(), bool_0: false);
					flag = true;
				}
			}
			if (flag)
			{
				break;
			}
		}
	}

	public virtual void EvaluateUnitStatus(float float_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (m_EventVal == null)
			{
				return;
			}
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
				if (!Information.IsNothing(_PrimaryThreat))
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
				if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					m_EventVal.Status = m_EventVal._SingletonVal;
				}
			}
			ActiveUnit eventVal = m_EventVal;
			Exception exception_ = null;
			if (Pathfinding.FindStub(eventVal, null, ref exception_))
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
			}
			else
			{
				if (m_EventVal.IsRTB)
				{
					return;
				}
				if (m_EventVal.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester && m_EventVal.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun)
				{
					ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = m_EventVal.Weaponry.IsWinchesterOrShotgun();
					if ((activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun) && m_EventVal.IsAircraft && ((Aircraft)m_EventVal).AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true))
					{
						return;
					}
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
				if (Information.IsNothing(PrimaryTarget))
				{
					if (m_EventVal.IsGroupMember() && m_EventVal.GetParentGroup().Type == Group.GroupType.AirGroup && m_EventVal.GetParentGroup().Status == ActiveUnit._ActiveUnitStatus.FormingUp)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
						return;
					}
					if (!m_EventVal.IsGroup && !m_EventVal.IsWeapon && m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
					{
						if (m_EventVal.AssignedMissionOrPackage().IsActive)
						{
							if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
								return;
							}
							if (!m_EventVal.IsPaintingATarget && !m_EventVal.WillNeedToPaintATarget)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
								return;
							}
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
					}
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 200345", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Contact FindClient(List<Contact> list_0)
	{
		try
		{
			Contact result = null;
			double num = 20000.0;
			foreach (Contact item in list_0)
			{
				double num2 = Module_Unit.RangeToUnit_Slant(m_EventVal, item);
				if (num2 < num)
				{
					result = item;
					num = num2;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100038", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal float? SetClient(float? nullable_0 = null)
	{
		float? result = null;
		try
		{
			Weapon[] array = (from theW in m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual()
				where theW.IsMine
				select theW).ToArray();
			if (array.Count() == 0)
			{
				return null;
			}
			float num = 0f;
			float num2 = 0f;
			Weapon[] array2 = array;
			Weapon[] array3 = array2;
			foreach (Weapon weapon in array3)
			{
				if (m_EventVal.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(m_EventVal.ParentScen.DBConnection) && weapon.MaxLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_AGL == 0f)
				{
					num = weapon.MaxLaunchAlt_ASL;
					num2 = weapon.MinLaunchAlt_ASL;
				}
				else
				{
					num = weapon.MaxLaunchAlt_AGL;
					num2 = weapon.MinLaunchAlt_AGL;
				}
			}
			if (nullable_0.HasValue)
			{
				float? num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() > num) : null).GetValueOrDefault())
				{
					result = num - 10f;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() < num2) : null).GetValueOrDefault())
				{
					result = num2 + 10f;
				}
			}
			else
			{
				if (m_EventVal.GetCurrentAltitude() > num || m_EventVal.DesiredAltitude > num)
				{
					result = num - 10f;
				}
				if (m_EventVal.GetCurrentAltitude() < num2 || m_EventVal.DesiredAltitude < num2)
				{
					result = num2 + 10f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100039", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsOnMiningRun(float float_0)
	{
		try
		{
			if (m_EventVal == null)
			{
				return false;
			}
			if (m_EventVal.IsMineLayingPlatform)
			{
				if (m_EventVal.AssignedMissionOrPackage() == null)
				{
					return false;
				}
				if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
				{
					if (m_EventVal.AssignedMissionOrPackage().IsActive)
					{
						bool result = false;
						if ((from theW in m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual()
							where theW.IsMine
							select theW).ToArray().Count() > 0)
						{
							if (Module_Unit.ResetTokenizer(m_EventVal))
							{
								result = false;
							}
							else if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
							{
								MiningMission miningMission = (MiningMission)m_EventVal.AssignedMissionOrPackage();
								if (miningMission.Area.Count <= 2)
								{
									Waypoint waypoint = ((m_EventVal.Navigator.PlottedCourse.Count() <= 0) ? null : m_EventVal.Navigator.PlottedCourse[0]);
									if (m_EventVal.Navigator.PreviousWaypointType.HasValue)
									{
										result = true;
									}
									else if (waypoint != null)
									{
										if (m_EventVal.Navigator.HaveReachedPoint(waypoint, float_0, waypoint.OvershootWaypoint))
										{
											if (m_EventVal.Navigator.PreviousWaypointType.HasValue || (m_EventVal.IsGroupMember() && m_EventVal.GetParentGroup() != null && m_EventVal.GetParentGroup().GroupLead.Navigator.PreviousWaypointType.HasValue))
											{
												result = true;
											}
										}
										else
										{
											m_EventVal.Navigator.PreviousWaypointTime = null;
											m_EventVal.Navigator.PreviousWaypointLatitude = null;
											m_EventVal.Navigator.PreviousWaypointLongitude = null;
											m_EventVal.Navigator.PreviousWaypointType = null;
										}
									}
								}
								else if (m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area, ref miningMission.Area_ChangeCheck, 0, bool_1: true, bool_2: false))
								{
									if ((m_EventVal.Navigator.PlottedCourse.Count() > 0 || m_EventVal.IsGroupMember()) && (m_EventVal.Navigator.PreviousWaypointType.HasValue || (m_EventVal.IsGroupMember() && m_EventVal.GetParentGroup() != null && m_EventVal.GetParentGroup().GroupLead.Navigator.PreviousWaypointType.HasValue)))
									{
										result = true;
									}
								}
								else
								{
									m_EventVal.Navigator.PreviousWaypointTime = null;
									m_EventVal.Navigator.PreviousWaypointLatitude = null;
									m_EventVal.Navigator.PreviousWaypointLongitude = null;
									m_EventVal.Navigator.PreviousWaypointType = null;
								}
							}
						}
						return result;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100040", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void TurnToUnmaskPrimaryWeapon(ref Weapon weapon_0, Contact contact_0, ref Tuple<Mount, float, bool> tuple_0)
	{
		try
		{
			if (contact_0 == null || weapon_0 == null)
			{
				return;
			}
			Mount mount = null;
			foreach (Mount mount2 in m_EventVal.Mounts)
			{
				if (mount != null)
				{
					break;
				}
				if ((m_EventVal.IsAircraft && !mount2.IsTrainable) || mount2.Status != 0 || mount2.ReloadStatus != 0)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount2.MountWeapons)
				{
					if (mountWeapon.int_0 == weapon_0.DBID && mountWeapon.CurrentLoad > 0)
					{
						mount = mount2;
						break;
					}
				}
			}
			if (mount == null)
			{
				return;
			}
			if (mount.TargetIsWithinCoverageArc(contact_0))
			{
				if (tuple_0 != null)
				{
					tuple_0 = new Tuple<Mount, float, bool>(mount, -1f, item3: false);
				}
				return;
			}
			if (weapon_0.Type == Weapon._WeaponType.DepthCharge)
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(m_EventVal, contact_0));
				if (tuple_0 != null)
				{
					tuple_0 = new Tuple<Mount, float, bool>(mount, Module_Unit.BearingToUnit_True(m_EventVal, contact_0), item3: true);
				}
				return;
			}
			int num = 1;
			do
			{
				int num2 = Math2.InsertClass((int)Math.Round(m_EventVal.CurrentHeading + (float)num));
				if (!mount.TargetIsWithinCoverageArc(contact_0, num2))
				{
					num2 = Math2.InsertClass((int)Math.Round(m_EventVal.CurrentHeading - (float)num));
					if (!mount.TargetIsWithinCoverageArc(contact_0, num2))
					{
						num += 10;
						continue;
					}
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, num2);
					if (tuple_0 != null)
					{
						tuple_0 = new Tuple<Mount, float, bool>(mount, num2, item3: true);
					}
					break;
				}
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, num2);
				if (tuple_0 != null)
				{
					tuple_0 = new Tuple<Mount, float, bool>(mount, num2, item3: true);
				}
				break;
			}
			while (num <= 180);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101353", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ManuallyMarkTargetHostile(ref Contact contact_0, bool bool_0)
	{
		if (bool_0 && contact_0.Type != Contact_Base.ContactType.Aimpoint && contact_0.Type != Contact_Base.ContactType.ActivationPoint && contact_0.GetStance(m_EventVal.GetUnitSide()) != Misc.PostureStance.Hostile)
		{
			contact_0.SetStance(m_EventVal.GetUnitSide(), bool_0: true, Misc.PostureStance.Hostile);
			m_EventVal.AddMessage("目标：" + contact_0.Name + "已被手动标记为敌对！", "手动目标分类", LoggedMessage.MessageType.ContactChange, 0, bool_0: false, default(Geopoint_Struct));
		}
	}

	public virtual void TargetThisContact(Contact contact_0, bool bool_0, bool bool_1, TargetingEntry._TargetingBehavior _TargetingBehavior_0)
	{
		try
		{
			if (m_EventVal == null || contact_0.Type == Contact_Base.ContactType.Sonobuoy || contact_0.GetIsDestroyed(m_EventVal.ParentScen) || (!bool_0 && TargetIsWasteOfAmmo(contact_0)))
			{
				return;
			}
			if (contact_0.Type == Contact_Base.ContactType.Missile)
			{
				Weapon weapon = (Weapon)contact_0.ActualUnit;
				if (weapon.IsAAW)
				{
					ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
					Contact contact_ = contact_0;
					Doctrine doctrine = m_EventVal.Doctrine;
					string string_ = string.Empty;
					int int_ = 0;
					if (!weaponry.PopConsumer(contact_, bool_1: false, doctrine, ref string_, ref int_))
					{
						if (Information.IsNothing(weapon.AI.PrimaryTarget) || Information.IsNothing(weapon.AI.PrimaryTarget.ActualUnit))
						{
							if (bool_0)
							{
								m_EventVal.Message = "无法攻击AAW武器！";
							}
							return;
						}
						if (!weapon.AI.PrimaryTarget.ActualUnit.IsShip && (!weapon.AI.PrimaryTarget.ActualUnit.IsSubmarine || !((Submarine)weapon.AI.PrimaryTarget.ActualUnit).IsSurfaced))
						{
							if (bool_0)
							{
								m_EventVal.Message = "无法攻击AAW武器！";
							}
							return;
						}
					}
				}
			}
			if (m_EventVal.IsWeapon && bool_1)
			{
				ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
				Weapon weapon_ = (Weapon)m_EventVal;
				Contact contact_2 = contact_0;
				short? nullable_ = (short)Math.Max(0, m_EventVal.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen));
				Sensor sensor_ = null;
				(string, ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation) tuple = weaponry2.CanThisWeaponEngageThisTarget(weapon_, contact_2, ref nullable_, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_);
				if (tuple.Item2 != 0)
				{
					m_EventVal.AddMessage("武器" + m_EventVal.Name + "不能针对这种目标类型！原因：" + tuple.Item1, "武器无法针对此目标！", LoggedMessage.MessageType.WeaponLogic, 0, bool_0: false, default(Geopoint_Struct));
					return;
				}
			}
			ManuallyMarkTargetHostile(ref contact_0, bool_0);
			if (_TargetList != null && _TargetList.ContainsKey(contact_0.ObjectID))
			{
				if (_TargetList[contact_0.ObjectID].Behavior != _TargetingBehavior_0)
				{
					_TargetList[contact_0.ObjectID].Behavior = _TargetingBehavior_0;
				}
			}
			else
			{
				TargetingEntry targetingEntry = new TargetingEntry();
				targetingEntry.Target = contact_0;
				targetingEntry.Behavior = _TargetingBehavior_0;
				if (_TargetList == null)
				{
					_TargetList = new ObservableDictionary<string, TargetingEntry>();
				}
				AddTargetList_Threadsafe(contact_0.ObjectID, targetingEntry);
			}
			if (bool_1 || (bool_0 && m_EventVal.IsWeapon))
			{
				PrimaryTarget = contact_0;
				PrimaryTargetOverrideExists = true;
			}
			TimeToNextTargetsEvaluation = 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100041", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void AddContactToThreatList(Contact contact_0)
	{
		if (_Threats == null)
		{
			_Threats = new List<Contact>();
		}
		else if (_Threats.Contains(contact_0))
		{
			return;
		}
		_Threats.Add(contact_0);
	}

	public virtual void DropThreat(Contact contact_0)
	{
		if (_Threats != null)
		{
			if (!_Threats.Contains(contact_0))
			{
				return;
			}
			_Threats.Remove(contact_0);
		}
		if (contact_0 == _PrimaryThreat)
		{
			_PrimaryThreat = null;
		}
	}

	public virtual void DropTarget(Contact contact_0, bool bool_0 = true)
	{
		try
		{
			if (contact_0 == null || m_EventVal == null || m_EventVal.IsDestroyed || (m_EventVal.IsShip && ((Ship)m_EventVal).IsSinking) || (!bool_0 && m_EventVal.GetIsPaintingThisTarget(contact_0)))
			{
				return;
			}
			if (contact_0 == PrimaryTarget)
			{
				PrimaryTarget = null;
				PrimaryTargetOverrideExists = false;
			}
			FillClient(contact_0);
			if (m_EventVal == null)
			{
				return;
			}
			if (!m_EventVal.IsWeapon)
			{
				Side unitSide = m_EventVal.GetUnitSide();
				ref Scenario parentScen = ref m_EventVal.ParentScen;
				ref ActiveUnit eventVal = ref m_EventVal;
				WeaponSalvo weaponSalvo_ = null;
				unitSide.StopShootingSalvo(ref parentScen, ref eventVal, ref contact_0, ref weaponSalvo_);
			}
			if (m_EventVal == null)
			{
				return;
			}
			if (m_EventVal != null)
			{
				Sensor[] array = m_EventVal.Sensors_Cached.ToArray();
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (sensor.IsTrackingThisTargetForFireControl(ref contact_0))
					{
						sensor.StopTrackingTarget(contact_0);
					}
					if (m_EventVal == null)
					{
						return;
					}
				}
			}
			m_EventVal.GetUnitSide().RemoveFireProposal(m_EventVal, contact_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200326", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FillClient(Contact contact_0)
	{
		if (contact_0 == null)
		{
			return;
		}
		object stateVal = _StateVal;
		ObjectFlowControl.CheckForSyncLockOnValueType(stateVal);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(stateVal, ref lockTaken);
			if (_TargetList != null && _TargetList.ContainsKey(contact_0.ObjectID))
			{
				_TargetList.Remove(contact_0.ObjectID);
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(stateVal);
			}
		}
	}

	internal bool CalculateClient(ref Contact contact_0)
	{
		try
		{
			WeaponSalvo[] weaponSalvos = m_EventVal.GetUnitSide().WeaponSalvos;
			WeaponSalvo[] array2 = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array2)
			{
				if (!weaponSalvo.ManualFire || weaponSalvo.Target != contact_0 || weaponSalvo.WpnQuantityAssigned == weaponSalvo.WpnQuantityFired)
				{
					continue;
				}
				WeaponSalvo.Shooter[] array = weaponSalvo.ShootersList.ToArray();
				WeaponSalvo.Shooter[] array3 = array;
				foreach (WeaponSalvo.Shooter shooter in array3)
				{
					if (Operators.CompareString(m_EventVal.ObjectID, shooter.ShooterObjectID, TextCompare: false) == 0 && shooter.QuantityFired < shooter.QuantityAssigned && shooter.WeaponIsReadyToFire && shooter.Timeout > 0)
					{
						return true;
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101354", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void CalculateDesiredRoll()
	{
	}

	public virtual void DeterminePrimaryTarget(float float_0, bool bool_0, bool bool_1)
	{
		if (!DeterminePrimaryTarget_Enabled)
		{
			return;
		}
		lock (m_EventVal)
		{
			try
			{
				if (m_EventVal == null)
				{
					return;
				}
				if (m_EventVal.IsRTB_Or_CalledOff)
				{
					PrimaryTarget = null;
				}
				else
				{
					if ((PrimaryTargetOverrideExists && _PrimaryThreat == null) || m_EventVal.IsWeapon || _TargetList == null || _TargetList.Count <= 0)
					{
						return;
					}
					m_DecoratorWrapper.Clear();
					foreach (KeyValuePair<string, TargetingEntry> target3 in _TargetList)
					{
						m_DecoratorWrapper.Add(target3.Value);
					}
					processWrapper.Clear();
					if (m_EventVal.IsShip)
					{
						foreach (TargetingEntry item in m_DecoratorWrapper)
						{
							m_ThreadWrapper = item;
							Contact target = m_ThreadWrapper.Target;
							if (target.IsShipContact || target.IsSubmergedContact || target.IsGroundContact)
							{
								processWrapper.Add(m_ThreadWrapper);
							}
						}
					}
					else if (m_EventVal.IsSubmarine)
					{
						foreach (TargetingEntry item2 in m_DecoratorWrapper)
						{
							m_ThreadWrapper = item2;
							Contact target2 = m_ThreadWrapper.Target;
							if (target2.ActualUnit != null && !target2.ActualUnit.IsMissile && !target2.ActualUnit.IsTorpedo && (target2.IsShipContact || target2.IsSubmergedContact || (target2.IsGroundContact && m_EventVal.AI.IsClearedToEngageThisTarget(target2))))
							{
								processWrapper.Add(m_ThreadWrapper);
							}
						}
					}
					else if (m_EventVal.IsFacility)
					{
						foreach (TargetingEntry item3 in m_DecoratorWrapper)
						{
							m_ThreadWrapper = item3;
							if (m_ThreadWrapper.Target.IsGroundContact)
							{
								processWrapper.Add(m_ThreadWrapper);
							}
						}
					}
					else if (!m_EventVal.IsSatellite)
					{
						processWrapper = m_DecoratorWrapper.ToList();
					}
					if (processWrapper.Count == 0)
					{
						PrimaryTarget = null;
						return;
					}
					List<Contact> list = new List<Contact>();
					foreach (TargetingEntry item4 in processWrapper)
					{
						Contact contact_ = item4.Target;
						switch (item4.Behavior)
						{
						case TargetingEntry._TargetingBehavior.ManualTargeted:
							if (m_EventVal.IsShip)
							{
								if (contact_.IsShipContact || contact_.IsSubmergedContact || contact_.IsGroundContact)
								{
									list.Add(contact_);
								}
							}
							else if (m_EventVal.IsSubmarine)
							{
								if (contact_.IsShipContact || contact_.IsSubmergedContact)
								{
									list.Add(contact_);
								}
							}
							else if (m_EventVal.IsFacility)
							{
								if (contact_.IsGroundContact)
								{
									list.Add(contact_);
								}
							}
							else if (!m_EventVal.IsSatellite)
							{
								list.Add(contact_);
							}
							break;
						case TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
							if (m_EventVal.IsShip)
							{
								if ((contact_.IsShipContact || contact_.IsSubmergedContact || contact_.IsGroundContact) && CalculateClient(ref contact_))
								{
									list.Add(contact_);
								}
							}
							else if (m_EventVal.IsSubmarine)
							{
								if ((contact_.IsShipContact || contact_.IsSubmergedContact) && CalculateClient(ref contact_))
								{
									list.Add(contact_);
								}
							}
							else if (m_EventVal.IsFacility)
							{
								if (contact_.IsGroundContact && CalculateClient(ref contact_))
								{
									list.Add(contact_);
								}
							}
							else if (!m_EventVal.IsSatellite && CalculateClient(ref contact_))
							{
								list.Add(contact_);
							}
							break;
						}
					}
					if (list.Count <= 0)
					{
						if (m_EventVal.AssignedMissionOrPackage() == null)
						{
							PrimaryTarget = null;
							return;
						}
						List<Contact> list2 = processWrapper.Select((TargetingEntry theTE) => theTE.Target).ToList();
						if (IsEscort)
						{
							if (!m_EventVal.IsShip && !m_EventVal.IsSubmarine)
							{
								List<Contact> list3 = (from contact_0 in list2.Where(delegate(Contact contact_0)
									{
										ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
										Doctrine doctrine = m_EventVal.Doctrine;
										string string_ = "";
										int int_3 = 0;
										return weaponry.PopConsumer(contact_0, bool_1: true, doctrine, ref string_, ref int_3) && ContactIsThreatToMissionUnits(contact_0);
									})
									orderby Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0)
									select contact_0).ToList();
								if (list3.Count <= 0)
								{
									PrimaryTarget = null;
								}
								else
								{
									PrimaryTarget = list3[0];
								}
							}
							else
							{
								Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
								ActiveUnit eventVal = m_EventVal;
								List<Contact> list_ = list2;
								Mission._GroupSize _GroupSize_ = 1;
								int int_ = strike.PrepareValue(ref _GroupSize_, ref strike.Escort_NumberOfBoats_Engage);
								_GroupSize_ = 1;
								DeterminePrimaryTarget_PatrolAndEscortLogic(eventVal, list_, int_, strike.PrepareValue(ref _GroupSize_, ref strike.Escort_NumberOfBoats_Investigate), strike.Escort_GroupMemberEngageDistance, float_0);
							}
						}
						else if (m_EventVal.IsOnActivePatrol && (m_EventVal.IsShip || m_EventVal.IsSubmarine))
						{
							Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
							if (((Patrol)m_EventVal.AssignedMissionOrPackage()).Type == GlobalVariables.PatrolType.SEAD)
							{
								DeterminePrimaryTarget_SEAD_Prioritize(list2, (int)patrol.NumberOfFlights_Engage, patrol.WingmanEngageDistance, float_0);
							}
							else if (m_EventVal.IsShip || m_EventVal.IsSubmarine)
							{
								ActiveUnit eventVal2 = m_EventVal;
								List<Contact> list_2 = list2;
								Mission._GroupSize _GroupSize_2 = 1;
								int int_2 = patrol.PrepareValue(ref _GroupSize_2, ref patrol.NumberOfBoats_Engage);
								_GroupSize_2 = 1;
								DeterminePrimaryTarget_PatrolAndEscortLogic(eventVal2, list_2, int_2, patrol.PrepareValue(ref _GroupSize_2, ref patrol.NumberOfBoats_Investigate), patrol.GroupMemberEngageDistance, float_0);
							}
						}
						else if (m_EventVal.IsOnActiveStrike && ((Strike)m_EventVal.AssignedMissionOrPackage()).RTB_When_Target_Destroyed && ((Strike)m_EventVal.AssignedMissionOrPackage()).TargetCount > 0)
						{
							Strike strike2 = (Strike)m_EventVal.AssignedMissionOrPackage();
							if (strike2.TargetCount > 0)
							{
								List<Tuple<int, Contact>> list4 = new List<Tuple<int, Contact>>();
								int num = 0;
								foreach (Contact item5 in list2)
								{
									if (item5.GetIsSpecificTargetForThisStrike(strike2))
									{
										list4.Add(new Tuple<int, Contact>(num, item5));
									}
									num++;
								}
								if (list4.Count <= 0)
								{
									PrimaryTarget = null;
								}
								else
								{
									if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
									{
										List<Contact> Local_tempList = new List<Contact>();
										foreach (Tuple<int, Contact> item6 in list4)
										{
											Local_tempList.Add(item6.Item2);
										}
										Local_tempList = m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, Local_tempList);
										list4 = list4.Where((Tuple<int, Contact> theContact) => Local_tempList.Contains(theContact.Item2)).ToList();
									}
									List<Tuple<int, Contact>> list5 = (from theContact in list4
										select (theContact) into theContact
										orderby theContact.Item1
										select theContact).ToList();
									PrimaryTarget = list5[0].Item2;
								}
							}
						}
						else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
						{
							foreach (Contact item7 in list2)
							{
								if (!m_EventVal.GetUnitSide().processProxy.ContainsKey(item7.ObjectID))
								{
									m_EventVal.GetUnitSide().processProxy.TryAdd(item7.ObjectID, item7.IncomingGuidedWeapons.Length);
								}
							}
							if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
							{
								list2 = m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, list2);
							}
							List<IGrouping<int, Contact>> list6 = (from theContact in list2
								select (theContact) into contact_0
								group contact_0 by m_EventVal.GetUnitSide().processProxy[contact_0.ObjectID]).ToList();
							PrimaryTarget = list6[0].OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0)).ToList()[0];
						}
						else
						{
							if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
							{
								list2 = m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, list2);
							}
							PrimaryTarget = list2.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0)).ToList()[0];
						}
						List<Contact> list7 = new List<Contact>();
						if (m_EventVal == null)
						{
							return;
						}
						foreach (Contact item8 in list2)
						{
							if (_Threats != null && _Threats.Contains(item8) && Module_Unit.RangeToUnit_Slant(m_EventVal, item8) < 10f)
							{
								list7.Add(item8);
							}
							if (list7.Count == 1)
							{
								PrimaryTarget = list7[0];
							}
							double num2 = 20000.0;
							foreach (Contact item9 in list7)
							{
								double num3 = Module_Unit.RangeToUnit_Slant(m_EventVal, item9);
								if (num3 < num2)
								{
									PrimaryTarget = item9;
									num2 = num3;
								}
							}
						}
						list7 = null;
					}
					else if (list.Count == 1)
					{
						PrimaryTarget = list[0];
					}
					else
					{
						Contact[] array = (from theCon in list
							select (theCon) into contact_0
							orderby Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0)
							select contact_0).ToArray();
						PrimaryTarget = array[0];
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100043", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	internal bool PopClient(Contact contact_0, float float_0 = 1f)
	{
		switch (contact_0.Type)
		{
		case Contact_Base.ContactType.Air:
			if (InterruptClient(contact_0, 30f * float_0) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			break;
		case Contact_Base.ContactType.Missile:
			if (InterruptClient(contact_0, 30f * float_0) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			break;
		default:
			if (InterruptClient(contact_0, 500f * float_0) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			break;
		case Contact_Base.ContactType.Submarine:
			if (InterruptClient(contact_0, 50f * float_0) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			break;
		case Contact_Base.ContactType.UndeterminedNaval:
			if (InterruptClient(contact_0, 50f * float_0) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			break;
		}
		return false;
	}

	public static void DeterminePrimaryTarget_PatrolAndEscortLogic(ActiveUnit activeUnit_0, List<Contact> list_0, int int_0, int int_1, float float_0, float float_1)
	{
		try
		{
			if (activeUnit_0 == null || activeUnit_0.AssignedMissionOrPackage() == null)
			{
				return;
			}
			ConcurrentQueue<Contact> concurrentQueue = new ConcurrentQueue<Contact>();
			bool isInsidePatrolArea_10nmBuffer = false;
			if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				isInsidePatrolArea_10nmBuffer = activeUnit_0.AI.IsInsidePatrolArea_10nmBuffer;
				Parallel.ForEach(list_0, delegate(Contact theC)
				{
					if (theC != null)
					{
						ActiveUnit_AI aI5 = activeUnit_0.AI;
						Mission mission_5 = activeUnit_0.AssignedMissionOrPackage();
						Doctrine._UseShootTourists? shootTourists5 = activeUnit_0.Doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						bool bool_5 = isInsidePatrolArea_10nmBuffer;
						string string_10 = "";
						int int_11 = 0;
						if (aI5.ContactIsRelevantToMission(theC, mission_5, shootTourists5, bool_0: false, bool_5, bool_2: true, null, ref string_10, ref int_11) && activeUnit_0.AI.IsClearedToEngageThisTarget(theC))
						{
							ActiveUnit_Weaponry weaponry6 = activeUnit_0.Weaponry;
							Doctrine doctrine6 = activeUnit_0.Doctrine;
							string_10 = "";
							int_11 = 0;
							if (weaponry6.PopConsumer(theC, bool_1: true, doctrine6, ref string_10, ref int_11))
							{
								concurrentQueue.Enqueue(theC);
							}
						}
					}
				});
			}
			else if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Parallel.ForEach(list_0, delegate(Contact theC)
				{
					if (theC != null)
					{
						ActiveUnit_Weaponry weaponry5 = activeUnit_0.Weaponry;
						Doctrine doctrine5 = activeUnit_0.Doctrine;
						string string_9 = "";
						int int_10 = 0;
						if (weaponry5.PopConsumer(theC, bool_1: true, doctrine5, ref string_9, ref int_10) && activeUnit_0.AI.ContactIsThreatToMissionUnits(theC))
						{
							concurrentQueue.Enqueue(theC);
						}
					}
				});
			}
			if (concurrentQueue.Count > 0)
			{
				if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
				{
					if (activeUnit_0.IsGroupWingman())
					{
						DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(activeUnit_0, concurrentQueue, float_0, float_1);
					}
					else
					{
						activeUnit_0.AI.DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(concurrentQueue.ToList(), int_0);
					}
				}
				else if (concurrentQueue.Count == 1)
				{
					activeUnit_0.AI.PrimaryTarget = concurrentQueue.ElementAtOrDefault(0);
				}
				else if (activeUnit_0.Doctrine.CallRepository(activeUnit_0.ParentScen))
				{
					List<Contact> list = (from theC0 in activeUnit_0.Doctrine.ViewRepository(activeUnit_0.ParentScen, concurrentQueue.ToList())
						orderby Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC0)
						select theC0).ToList();
					activeUnit_0.AI.PrimaryTarget = list[0];
				}
				else
				{
					List<Contact> list2 = concurrentQueue.OrderBy((Contact theC0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC0)).ToList();
					activeUnit_0.AI.PrimaryTarget = list2[0];
				}
			}
			if (concurrentQueue.Count != 0 && (concurrentQueue.Count <= 0 || activeUnit_0.AI.PrimaryTarget != null))
			{
				return;
			}
			if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
			{
				ConcurrentQueue<Contact> concurrentQueue2 = new ConcurrentQueue<Contact>();
				if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Parallel.ForEach(list_0, delegate(Contact theC)
					{
						if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							ActiveUnit_AI aI4 = activeUnit_0.AI;
							Mission mission_4 = activeUnit_0.AssignedMissionOrPackage();
							Doctrine._UseShootTourists? shootTourists4 = activeUnit_0.Doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool bool_4 = isInsidePatrolArea_10nmBuffer;
							string string_8 = "";
							int int_9 = 0;
							if (aI4.ContactIsRelevantToMission(theC, mission_4, shootTourists4, bool_0: false, bool_4, bool_2: true, null, ref string_8, ref int_9))
							{
								concurrentQueue2.Enqueue(theC);
							}
						}
					});
				}
				else if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Parallel.ForEach(list_0, delegate(Contact theC)
					{
						if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							ActiveUnit_Weaponry weaponry4 = activeUnit_0.Weaponry;
							Doctrine doctrine4 = activeUnit_0.Doctrine;
							string string_7 = "";
							int int_8 = 0;
							if (weaponry4.PopConsumer(theC, bool_1: true, doctrine4, ref string_7, ref int_8) && activeUnit_0.AI.ContactIsThreatToMissionUnits(theC))
							{
								concurrentQueue2.Enqueue(theC);
							}
						}
					});
				}
				if (concurrentQueue2 != null && concurrentQueue2.Count > 0)
				{
					if (activeUnit_0.IsGroupWingman())
					{
						DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(activeUnit_0, concurrentQueue2, float_0, float_1);
					}
					else
					{
						activeUnit_0.AI.DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(concurrentQueue2.ToList(), int_1);
					}
				}
				else
				{
					activeUnit_0.AI.PrimaryTarget = null;
				}
			}
			else
			{
				TList<Contact> tList = new TList<Contact>();
				if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Parallel.ForEach(list_0, delegate(Contact theC)
					{
						if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							ActiveUnit_AI aI3 = activeUnit_0.AI;
							Mission mission_3 = activeUnit_0.AssignedMissionOrPackage();
							Doctrine._UseShootTourists? shootTourists3 = activeUnit_0.Doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool bool_3 = isInsidePatrolArea_10nmBuffer;
							string string_6 = "";
							int int_7 = 0;
							if (aI3.ContactIsRelevantToMission(theC, mission_3, shootTourists3, bool_0: false, bool_3, bool_2: true, null, ref string_6, ref int_7))
							{
								tList.Add(theC);
							}
						}
					});
				}
				else if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Parallel.ForEach(list_0, delegate(Contact theC)
					{
						ActiveUnit_Weaponry weaponry3 = activeUnit_0.Weaponry;
						Doctrine doctrine3 = activeUnit_0.Doctrine;
						string string_5 = "";
						int int_6 = 0;
						if (weaponry3.PopConsumer(theC, bool_1: true, doctrine3, ref string_5, ref int_6) && activeUnit_0.AI.ContactIsThreatToMissionUnits(theC))
						{
							tList.Add(theC);
						}
					});
				}
				switch (tList.Count)
				{
				default:
					if (activeUnit_0.Doctrine.CallRepository(activeUnit_0.ParentScen))
					{
						List<Contact> source = activeUnit_0.Doctrine.ViewRepository(activeUnit_0.ParentScen, tList.ToList());
						activeUnit_0.AI.PrimaryTarget = source.OrderBy((Contact theC0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC0)).ElementAtOrDefault(0);
					}
					else
					{
						activeUnit_0.AI.PrimaryTarget = tList.OrderBy((Contact theC0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC0)).ElementAtOrDefault(0);
					}
					break;
				case 1:
					activeUnit_0.AI.PrimaryTarget = tList[0];
					break;
				case 0:
					activeUnit_0.AI.PrimaryTarget = null;
					break;
				}
			}
			if (activeUnit_0.AI.PrimaryTarget != null)
			{
				return;
			}
			if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
			{
				ConcurrentQueue<Contact> concurrentQueue3 = new ConcurrentQueue<Contact>();
				if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Parallel.ForEach(list_0, delegate(Contact theC)
					{
						if (theC.GetStance(activeUnit_0.GetUnitSide()) == Misc.PostureStance.Unfriendly)
						{
							ActiveUnit_AI aI2 = activeUnit_0.AI;
							Mission mission_2 = activeUnit_0.AssignedMissionOrPackage();
							Doctrine._UseShootTourists? shootTourists2 = activeUnit_0.Doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
							bool bool_2 = isInsidePatrolArea_10nmBuffer;
							string string_4 = "";
							int int_5 = 0;
							if (aI2.ContactIsRelevantToMission(theC, mission_2, shootTourists2, bool_0: false, bool_2, bool_2: true, null, ref string_4, ref int_5))
							{
								concurrentQueue3.Enqueue(theC);
							}
						}
					});
				}
				else if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Parallel.ForEach(list_0, delegate(Contact theC)
					{
						if (theC.GetStance(activeUnit_0.GetUnitSide()) == Misc.PostureStance.Unfriendly)
						{
							ActiveUnit_Weaponry weaponry2 = activeUnit_0.Weaponry;
							Doctrine doctrine2 = activeUnit_0.Doctrine;
							string string_3 = "";
							int int_4 = 0;
							if (weaponry2.PopConsumer(theC, bool_1: true, doctrine2, ref string_3, ref int_4) && activeUnit_0.AI.ContactIsThreatToMissionUnits(theC))
							{
								concurrentQueue3.Enqueue(theC);
							}
						}
					});
				}
				if (concurrentQueue3.Count == 0)
				{
					activeUnit_0.AI.PrimaryTarget = null;
				}
				else if (activeUnit_0.IsGroupWingman())
				{
					DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(activeUnit_0, concurrentQueue3, float_0, float_1);
				}
				else
				{
					activeUnit_0.AI.DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(concurrentQueue3.ToList(), int_1);
				}
				return;
			}
			TList<Contact> tList2 = new TList<Contact>();
			if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Parallel.ForEach(list_0, delegate(Contact theC)
				{
					if (theC.GetStance(activeUnit_0.GetUnitSide()) == Misc.PostureStance.Unfriendly)
					{
						ActiveUnit_AI aI = activeUnit_0.AI;
						Mission mission_ = activeUnit_0.AssignedMissionOrPackage();
						Doctrine._UseShootTourists? shootTourists = activeUnit_0.Doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						bool bool_ = isInsidePatrolArea_10nmBuffer;
						string string_2 = "";
						int int_3 = 0;
						if (aI.ContactIsRelevantToMission(theC, mission_, shootTourists, bool_0: false, bool_, bool_2: true, null, ref string_2, ref int_3))
						{
							tList2.Add(theC);
						}
					}
				});
			}
			else if (activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Parallel.ForEach(list_0, delegate(Contact theC)
				{
					ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
					Doctrine doctrine = activeUnit_0.Doctrine;
					string string_ = "";
					int int_2 = 0;
					if (weaponry.PopConsumer(theC, bool_1: true, doctrine, ref string_, ref int_2) && activeUnit_0.AI.ContactIsThreatToMissionUnits(theC))
					{
						tList2.Add(theC);
					}
				});
			}
			switch (tList2.Count)
			{
			case 1:
				activeUnit_0.AI.PrimaryTarget = tList2[0];
				return;
			case 0:
				activeUnit_0.AI.PrimaryTarget = null;
				return;
			}
			if (activeUnit_0.Doctrine.CallRepository(activeUnit_0.ParentScen))
			{
				List<Contact> source2 = activeUnit_0.Doctrine.ViewRepository(activeUnit_0.ParentScen, tList2.ToList());
				activeUnit_0.AI.PrimaryTarget = source2.OrderBy((Contact theC0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC0)).ElementAtOrDefault(0);
			}
			else
			{
				activeUnit_0.AI.PrimaryTarget = tList2.OrderBy((Contact theC0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC0)).ElementAtOrDefault(0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 567876978", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool PatrolAndEscortLogic_Wingman_ShouldEngage(Contact contact_0, List<ActiveUnit> list_0 = null)
	{
		if (contact_0 == null)
		{
			return false;
		}
		if (contact_0.GetStance(m_EventVal.GetUnitSide()) == Misc.PostureStance.Hostile)
		{
			return true;
		}
		if (m_EventVal.AssignedMissionOrPackage() != null)
		{
			if (list_0 == null)
			{
				list_0 = Module_Mission.AssetTokenizer(m_EventVal.AssignedMissionOrPackage(), m_EventVal.ParentScen);
			}
			foreach (ActiveUnit item in list_0)
			{
				if (item != null && item != m_EventVal && item.IsAircraft && item.AI.PrimaryTarget == contact_0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public static void DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(ActiveUnit activeUnit_0, IEnumerable<Contact> ienumerable_0, float float_0, float float_1)
	{
		try
		{
			ActiveUnit activeUnit;
			if (Information.IsNothing(activeUnit_0.GetParentGroup()))
			{
				activeUnit = activeUnit_0;
			}
			else
			{
				activeUnit = activeUnit_0.GetParentGroup().GroupLead;
			}
			if (float_0 <= 0f || ienumerable_0 == null || ienumerable_0.Count() <= 0)
			{
				return;
			}
			if (activeUnit_0.Doctrine.CallRepository(activeUnit_0.ParentScen))
			{
				ienumerable_0 = activeUnit_0.Doctrine.ViewRepository(activeUnit_0.ParentScen, ienumerable_0.ToList());
			}
			List<Contact> list = (from theC in ienumerable_0
				where theC != null && activeUnit != null
				orderby Module_Unit.RangeToUnit_Horiz_Angular(activeUnit, theC)
				select theC).ToList();
			if (list != null && list.Count > 0)
			{
				float num = Math2.VerifyClass(activeUnit.GetLatitude(), activeUnit.GetLongitude(), list[0].GetLatitude(), list[0].GetLongitude());
				if (float_0 <= num)
				{
					Contact contact = null;
					List<ActiveUnit> otherUnits = Module_Mission.AssetTokenizer(activeUnit_0.AssignedMissionOrPackage(), activeUnit_0.ParentScen);
					Parallel.ForEach(list, delegate(Contact theContact, ParallelLoopState loopstate)
					{
						Weapon weapon = activeUnit_0.Weaponry.LongestRangedSuitableWeaponForThisTarget(theContact);
						if (weapon != null && activeUnit_0.AI.PatrolAndEscortLogic_Wingman_ShouldEngage(theContact, otherUnits))
						{
							float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(activeUnit_0, theContact, bool_0: true, activeUnit_0.Doctrine, bool_1: false);
							if (Math.Max((double)maxRangeForThisTarget * 1.2, maxRangeForThisTarget + float_0) > (double)Math2.VerifyClass(activeUnit.GetLatitude(), activeUnit.GetLongitude(), theContact.GetLatitude(), theContact.GetLongitude()))
							{
								contact = theContact;
								loopstate.Stop();
							}
						}
					});
					if (contact == null)
					{
						if (activeUnit != activeUnit_0 && !Information.IsNothing(activeUnit.AI.PrimaryTarget) && (activeUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive || activeUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive) && ienumerable_0.Contains(activeUnit.AI.PrimaryTarget))
						{
							Contact primaryTarget = activeUnit.AI.PrimaryTarget;
							activeUnit_0.AI.PrimaryTarget = primaryTarget;
						}
						else
						{
							activeUnit_0.AI.PrimaryTarget = null;
						}
						activeUnit_0.Navigator.HeadToFormationStation(float_1);
					}
					else
					{
						activeUnit_0.AI.PrimaryTarget = contact;
					}
				}
				else if (activeUnit != activeUnit_0 && !Information.IsNothing(activeUnit.AI.PrimaryTarget) && ienumerable_0.Contains(activeUnit.AI.PrimaryTarget))
				{
					List<Contact> list2 = (from theC in ienumerable_0
						where Module_Unit.RangeToUnit_Horiz(activeUnit, theC) <= float_0
						orderby Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, theC)
						select theC).ToList();
					if (list2.Count == 0)
					{
						activeUnit_0.AI.PrimaryTarget = null;
						return;
					}
					if (list2.Count == 1)
					{
						activeUnit_0.AI.PrimaryTarget = list2[0];
						return;
					}
					list2.Remove(activeUnit.AI.PrimaryTarget);
					activeUnit_0.AI.PrimaryTarget = list2[0];
				}
				else
				{
					activeUnit_0.AI.PrimaryTarget = list[0];
				}
			}
			else if (activeUnit != activeUnit_0)
			{
				if (activeUnit != null && Information.IsNothing(activeUnit.AI.PrimaryTarget) && ienumerable_0.Contains(activeUnit.AI.PrimaryTarget))
				{
					Contact primaryTarget2 = activeUnit.AI.PrimaryTarget;
					activeUnit_0.AI.PrimaryTarget = primaryTarget2;
				}
				else
				{
					activeUnit_0.AI.PrimaryTarget = null;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 592384765238475", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(List<Contact> list_0, int int_0)
	{
		try
		{
			int count = list_0.Count;
			double num = double.MaxValue;
			double num2 = double.MaxValue;
			double num3 = double.MaxValue;
			if (_RuleWrapper == null)
			{
				_RuleWrapper = new Dictionary<Contact, int>();
			}
			else
			{
				_RuleWrapper.Clear();
			}
			foreach (Contact item in list_0)
			{
				_RuleWrapper.Add(item, 0);
			}
			if (GameGeneral.infoClient)
			{
				foreach (Contact item2 in list_0)
				{
					int count2 = Module_Contact.PostTokenizer(item2, m_EventVal.GetUnitSide(), bool_0: true, m_EventVal, bool_1: false).Count;
					_RuleWrapper[item2] = count2;
				}
			}
			else
			{
				Parallel.ForEach(list_0, delegate(Contact contact_0)
				{
					int count3 = Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: true, m_EventVal, bool_1: false).Count;
					_RuleWrapper[contact_0] = count3;
				});
			}
			if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen))
			{
				list_0 = m_EventVal.Doctrine.ViewRepository(m_EventVal.ParentScen, list_0);
				count = list_0.Count;
			}
			Contact contact = null;
			Contact contact2 = null;
			Contact contact3 = null;
			for (int i = count - 1; i >= 0; i += -1)
			{
				Contact contact4 = list_0[i];
				int num4 = _RuleWrapper[contact4];
				double num5 = Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact4);
				if (num4 < int_0)
				{
					if (num4 <= 0)
					{
						if (num5 < num)
						{
							contact2 = contact4;
							num = num5;
						}
					}
					else if (num5 < num2)
					{
						contact = contact4;
						num2 = num5;
					}
					if (num5 < num3)
					{
						contact3 = contact4;
						num3 = num5;
					}
				}
				else if (PrimaryTarget != null)
				{
					PrimaryTarget = null;
				}
			}
			Contact contact5 = null;
			if (contact3 != null)
			{
				Weapon weapon = m_EventVal.Weaponry.LongestRangedSuitableWeaponForThisTarget(contact3);
				if (weapon == null)
				{
					contact5 = null;
				}
				else
				{
					float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(m_EventVal, contact3, bool_0: true, m_EventVal.Doctrine, bool_1: false);
					contact5 = ((Math.Max((double)maxRangeForThisTarget * 1.2, maxRangeForThisTarget + 5f) <= (double)Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), contact3.GetLatitude(), contact3.GetLongitude())) ? null : contact3);
				}
			}
			if (contact5 == null)
			{
				if (contact2 == null)
				{
					if (contact == null)
					{
						PrimaryTarget = null;
					}
					else
					{
						PrimaryTarget = contact;
					}
				}
				else
				{
					PrimaryTarget = contact2;
				}
			}
			else
			{
				PrimaryTarget = contact5;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 31241234125", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual Module_Unit.Unit DetermineWeaponEffectThreat()
	{
		List<Module_Unit.Unit> knownActiveNuclearWeapons = m_EventVal.GetUnitSide().GetKnownActiveNuclearWeapons(m_EventVal.ParentScen);
		Module_Unit.Unit result = null;
		if (knownActiveNuclearWeapons != null && knownActiveNuclearWeapons.Count > 0)
		{
			double num = double.MaxValue;
			float num2 = 0f;
			foreach (Module_Unit.Unit item in knownActiveNuclearWeapons)
			{
				if (item == null)
				{
					continue;
				}
				Weapon weapon;
				Contact contact2;
				if (item.DisableWriter())
				{
					Contact contact = (Contact)item;
					if (contact == PrimaryTarget || (!m_EventVal.CommStuff.IsConnectedToSideNetwork && !m_EventVal.Sensory.RunDic(contact, 30f, Sensor.Sensor_Type.None)) || !contact.IsWeaponContact)
					{
						continue;
					}
					weapon = (Weapon)contact.ActualUnit;
					contact2 = weapon.AI.PrimaryTarget;
				}
				else if (item.IsWeapon)
				{
					weapon = (Weapon)item;
					if (!m_EventVal.CommStuff.IsConnectedToSideNetwork && weapon.FiringParent != m_EventVal)
					{
						continue;
					}
					contact2 = weapon.AI.PrimaryTarget;
				}
				else
				{
					if ((object)item.GetType() != typeof(UnguidedWeapon))
					{
						if ((object)item.GetType() == typeof(Explosion))
						{
							Explosion explosion = (Explosion)item;
							double num3 = Module_Unit.RangeToPoint_Slant(m_EventVal, explosion.GetLatitude(), explosion.GetLongitude(), explosion.GetCurrentAltitude());
							double num4 = Math.Pow(explosion.ExpYield / 1000000.0, 0.33);
							if (num3 < num4 && num3 < num)
							{
								result = item;
								num = num3;
							}
						}
						continue;
					}
					UnguidedWeapon unguidedWeapon = (UnguidedWeapon)item;
					if (!m_EventVal.CommStuff.IsConnectedToSideNetwork && unguidedWeapon.FiringParent != m_EventVal)
					{
						continue;
					}
					weapon = unguidedWeapon.ReferenceWeapon;
					contact2 = unguidedWeapon.Target;
					num2 = unguidedWeapon.TimeToDetonate;
				}
				if (contact2 != null && weapon.Warheads.Count() > 0)
				{
					double num5 = Module_Unit.RangeToPoint_Slant(m_EventVal, contact2.GetLatitude(), contact2.GetLongitude(), contact2.GetCurrentAltitude());
					double num6 = Math.Pow(weapon.Warheads[0].DP / 1000000f, 0.33);
					if (m_EventVal.IsSubmarine && weapon.IsUnderwater)
					{
						num6 *= 2.0;
					}
					if (num2 == 0f && weapon.CurrentSpeed > 0f)
					{
						num2 = Module_Unit.RangeToPoint_Horiz(weapon, contact2.GetLatitude(), contact2.GetLongitude()) / weapon.CurrentSpeed * 3600f;
					}
					if ((double)(m_EventVal.MaxSpeed * num2 / 3600f) * 0.8 <= num6 && num5 < num6 && num5 < num)
					{
						result = item;
						num = num5;
					}
				}
			}
			return result;
		}
		return result;
	}

	public virtual void DeterminePrimaryThreat()
	{
		try
		{
			if (m_EventVal == null || m_EventVal.IsWeapon)
			{
				return;
			}
			_PrimaryThreat = null;
			if (_Threats == null)
			{
				return;
			}
			switch (_Threats.Count)
			{
			case 1:
				_PrimaryThreat = _Threats[0];
				return;
			case 0:
				_PrimaryThreat = null;
				return;
			}
			float num = 20000f;
			foreach (Contact threat in _Threats)
			{
				Contact contact_ = threat;
				if (contact_.GetLongitude() == 0.0 || contact_.GetLatitude() == 0.0 || contact_.CurrentSpeed == 0f)
				{
					continue;
				}
				float num2 = Module_Unit.ClosureSpeed(m_EventVal, contact_, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading);
				if (num2 > 0f)
				{
					float num3 = m_EventVal.ETA_To_Location(num2, DistanceFromThreat(m_EventVal, ref contact_));
					if (num3 < num)
					{
						_PrimaryThreat = contact_;
						num = num3;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100044", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void ManouverTowardsTarget(float float_0)
	{
		try
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
			{
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				return;
			}
			if (PrimaryTarget.HeadingIsKnown)
			{
				double num = Math.Abs(MathFunctions.DeleteRequest(Module_Unit.BearingToUnit_True(PrimaryTarget, m_EventVal), PrimaryTarget.CurrentHeading));
				if ((num > 60.0 && !(num >= 120.0)) ? true : false)
				{
					Manouver_PurePursuit(float_0, 0f, 0f);
				}
				else
				{
					float float_ = float_0;
					float? nullable_ = m_EventVal.DesiredSpeed;
					bool bool_ = false;
					Manouver_InterceptCourse(float_, nullable_, ref bool_);
				}
			}
			else
			{
				Manouver_PurePursuit(float_0, 0f, 0f);
			}
			if (m_EventVal.Navigator.bool_0 && !PathBlockCheckInProgress)
			{
				PathBlockCheckInProgress = true;
				Task.Factory.StartNew(delegate
				{
					InstantiateClient(float_0, bool_0: true);
				});
			}
			if (Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) < 1f && PrimaryTarget.UncertaintyArea != null && !m_EventVal.Weaponry.HaveSuitableWeaponForAmbigousTarget(PrimaryTarget, bool_1: true))
			{
				m_EventVal.Navigator.PlotLocalizationCourse();
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100045", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InstantiateClient(float float_0, bool bool_0)
	{
		if (m_EventVal.AI.HoldPosition)
		{
			return;
		}
		PathBlockCheckInProgress = true;
		try
		{
			if (!m_EventVal.Navigator.PathFindingInProgress)
			{
				ActiveUnit_Navigator navigator = m_EventVal.Navigator;
				double latitude = m_EventVal.GetLatitude();
				double longitude = m_EventVal.GetLongitude();
				double latitude2 = PrimaryTarget.GetLatitude();
				double longitude2 = PrimaryTarget.GetLongitude();
				float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
				int int_ = 0;
				GeoPoint geoPoint_ = null;
				if (navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: true, nullable_, ref int_, ref geoPoint_))
				{
					Waypoint[] source = m_EventVal.Navigator.PlottedCourse.ToArray();
					if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
					{
						Waypoint waypoint = source.Where((Waypoint theWP) => !Information.IsNothing(theWP) && theWP.Type == Waypoint.WaypointType.PathfindingPoint).Last();
						Weapon weapon = m_EventVal.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget);
						float num = (Information.IsNothing(weapon) ? 1f : weapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: false, null, bool_1: false));
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
			exception_?.Data.Add("Error at 100046", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		PathBlockCheckInProgress = false;
	}

	public virtual bool CanInterceptTargetAtCurrentAltSpeed(double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float? nullable_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (Information.IsNothing(nullable_0))
			{
				nullable_0 = 0.1f;
			}
			float num = Module_Unit.RangeToPoint_Horiz(m_EventVal, double_0, double_1);
			if (float.IsNaN(num))
			{
				return true;
			}
			float num2;
			if (bool_0)
			{
				num2 = float_3;
				if (float_3 <= 0f || double.IsNaN(float_3))
				{
					return false;
				}
			}
			else
			{
				if (bool_1)
				{
					num2 = Module_Unit.ClosureSpeed(m_EventVal, double_0, double_1, float_0, float_1, float_3, float_4);
				}
				else
				{
					float float_5 = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryThreat.GetLatitude(), PrimaryThreat.GetLongitude());
					num2 = Module_Unit.ClosureSpeed(m_EventVal, double_0, double_1, float_0, float_1, float_3, float_5);
				}
				if (num2 <= 0f || double.IsNaN(num2))
				{
					return false;
				}
			}
			long num3 = (long)Math.Round(num / num2 * 3600f);
			float? num4 = (float)m_EventVal.Kinematics.RemainingEndurance(float_3, float_2, !m_EventVal.IsAircraft, m_EventVal.IsAircraft) * (1f + nullable_0);
			float num5 = num3;
			if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() > num5) : null).GetValueOrDefault())
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100047", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool CanInterceptTargetAtCurrentAltSpeed(Module_Unit.Unit unit_0, float? nullable_0, float float_0, float float_1, float float_2, float? nullable_1, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (Information.IsNothing(nullable_1))
			{
				nullable_1 = 0.1f;
			}
			if (Information.IsNothing(nullable_0))
			{
				nullable_0 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unit_0);
			}
			if (Information.IsNothing(nullable_0))
			{
				return true;
			}
			float num;
			if (bool_0)
			{
				num = float_1;
				if (float_1 <= 0f || double.IsNaN(float_1))
				{
					return false;
				}
			}
			else
			{
				num = Module_Unit.ClosureSpeed(m_EventVal, unit_0, float_1, float_2);
				if (num <= 0f || double.IsNaN(num))
				{
					return false;
				}
			}
			long num2 = (long)Math.Round((nullable_0 / num * 3600f).Value);
			float? num3 = (float)m_EventVal.Kinematics.RemainingEndurance(float_1, float_0, bool_1, bool_2) * (1f + nullable_1);
			float num4 = num2;
			if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() > num4) : null).GetValueOrDefault())
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100047", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool CanInterceptTarget(Module_Unit.Unit unit_0, float? nullable_0, float float_0, float? nullable_1, float float_1, ActiveUnit.Throttle throttle_0, float? nullable_2, bool bool_0, bool bool_1, ref bool bool_2)
	{
		try
		{
			if (m_EventVal == null)
			{
				return false;
			}
			if (!nullable_1.HasValue)
			{
				nullable_1 = m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), throttle_0, bool_0: false);
			}
			return CanInterceptTargetAtCurrentAltSpeed(unit_0, nullable_0, float_0, nullable_1.Value, float_1, nullable_2, bool_0, bool_1, bool_2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100048", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public int? MinimumSpeedToInterceptTarget(ActiveUnit activeUnit_0)
	{
		int? result = null;
		try
		{
			int maximumSpeed = m_EventVal.Kinematics.GetMaximumSpeed();
			int num = Math.Max(1, (int)Math.Round((double)maximumSpeed / 100.0));
			int num2 = maximumSpeed;
			int num3 = num;
			for (int i = 1; ((num3 >> 31) ^ i) <= ((num3 >> 31) ^ num2); i += num3)
			{
				if (ActiveUnit_Navigator.CalculateInterceptHeading(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.CurrentHeading, activeUnit_0, i).HasValue)
				{
					result = i;
					return result;
				}
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100049", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void Manouver_PurePursuit(float float_0, float float_1, float float_2)
	{
		try
		{
			if (!Information.IsNothing(m_EventVal.Navigator.PlottedCourse) && m_EventVal.Navigator.PlottedCourse.Count() > 0 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun)
			{
				if (!Information.IsNothing(PrimaryTarget.UncertaintyArea))
				{
					return;
				}
				m_EventVal.Navigator.RemoveWaypoint_Soft(m_EventVal.Navigator.PlottedCourse[0], bool_1: false);
			}
			if (PrimaryTarget.IsAircraftContact)
			{
				Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
				if (!Information.IsNothing(weapon))
				{
					if (weapon.MinAirRange > 0f && Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) <= weapon.MinAirRange)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(Module_Unit.BearingToUnit_True(m_EventVal, PrimaryTarget) + 90f));
						return;
					}
					if (weapon.Flags.RearAspect_AAM || weapon.Flags.SternChase_AAM)
					{
						Contact primaryTarget = PrimaryTarget;
						bool? nullable_ = null;
						double double_ = primaryTarget.GetLongitude(nullable_);
						Contact primaryTarget2 = PrimaryTarget;
						bool? nullable_2 = null;
						double double_2 = primaryTarget2.GetLatitude(nullable_2);
						double double_3 = (double)weapon.MinAirRange + 0.5;
						float float_3 = Math2.UpdateClass(PrimaryTarget.CurrentHeading + 180f);
						double double_4 = 0.0;
						double double_5 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_4, ref double_5, ref double_3, ref float_3);
						primaryTarget2.SetLatitude(nullable_2, double_2);
						primaryTarget.SetLongitude(nullable_, double_);
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(m_EventVal, double_5, double_4));
						return;
					}
				}
			}
			float float_4 = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
			if (PrimaryTarget.CurrentSpeed <= m_EventVal.CurrentSpeed / 2f)
			{
				Misc.ExtendPhase extendPhase_ = Misc.ExtendPhase.Standard;
				Waypoint waypoint_;
				if (m_EventVal.IsAircraft)
				{
					double double_6 = 0.0;
					double double_7 = 0.0;
					float value = Module_Unit.DefineTokenizer(PrimaryTarget, m_EventVal, ref double_6, ref double_7);
					Weapon weapon_ = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, m_EventVal.Doctrine);
					bool? flag;
					bool? flag2 = (flag = ((weapon_ == null) ? null : new bool?(weapon_.Type == Weapon._WeaponType.Gun)));
					bool? flag3;
					bool? flag4;
					if (flag2.HasValue && flag.GetValueOrDefault())
					{
						flag3 = true;
					}
					else
					{
						flag2 = (flag4 = ((weapon_ == null) ? null : new bool?(weapon_.Type == Weapon._WeaponType.IronBomb)));
						flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
					}
					bool? flag5 = flag3;
					flag4 = flag3;
					bool? flag6;
					if (flag4.HasValue && !flag5.GetValueOrDefault())
					{
						flag6 = false;
					}
					else
					{
						bool? flag7;
						flag4 = (flag7 = ((weapon_ == null) ? null : new bool?(weapon_.MaxLandRange > 0f)));
						flag6 = ((!flag4.HasValue) ? null : (flag7.GetValueOrDefault() & flag5));
					}
					bool? flag8 = flag6;
					if (flag8.GetValueOrDefault(true) && weapon_ != null && weapon_.MaxLandRange < 5f && flag8.HasValue)
					{
						float desiredHeading = m_EventVal.DesiredHeading;
						Tuple<Mount, float, bool> tuple_ = new Tuple<Mount, float, bool>(null, -1f, item3: false);
						TurnToUnmaskPrimaryWeapon(ref weapon_, PrimaryTarget, ref tuple_);
						float num = Module_Unit.RangeToUnit_Slant(m_EventVal, PrimaryTarget);
						if (tuple_.Item1 != null && tuple_.Item3)
						{
							if (num <= weapon_.MaxLandRange)
							{
								float_4 = (tuple_.Item3 ? tuple_.Item2 : m_EventVal.DesiredHeading);
							}
							else
							{
								m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, desiredHeading);
							}
						}
						else
						{
							if (tuple_.Item1 == null || tuple_.Item2 != -1f)
							{
								float num2 = 60f;
								if (Math.Abs(value) <= num2)
								{
									extendPhase_ = Misc.ExtendPhase.FinalApproach;
								}
								else if (num < 4f)
								{
									float_2 = 4f;
									extendPhase_ = Misc.ExtendPhase.Extending;
								}
								else
								{
									extendPhase_ = Misc.ExtendPhase.LiningUp;
								}
								m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_4);
								ActiveUnit_Navigator navigator = m_EventVal.Navigator;
								waypoint_ = null;
								navigator.ExtendIfNecessary(float_0, ref waypoint_, PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), float_1, float_2, m_EventVal.Kinematics.TurnRate(), extendPhase_);
								return;
							}
							float_4 = m_EventVal.DesiredHeading;
						}
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_4);
						return;
					}
				}
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_4);
				ActiveUnit_Navigator navigator2 = m_EventVal.Navigator;
				waypoint_ = null;
				navigator2.ExtendIfNecessary(float_0, ref waypoint_, PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), float_1, float_2, m_EventVal.Kinematics.TurnRate(), extendPhase_);
			}
			else
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_4);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100050", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Manouver_CollisionCourse(float float_0)
	{
		try
		{
			double num = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()));
			if (!(270.0 <= num) && num > 90.0)
			{
				Manouver_PurePursuit(float_0, 0f, 0f);
				return;
			}
			float num2 = m_EventVal.ETA_To_Location(Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading), Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget));
			float float_ = PrimaryTarget.CurrentSpeed / 3600f * num2;
			Waypoint waypoint = new Waypoint();
			double longitude = PrimaryTarget.GetLongitude();
			double latitude = PrimaryTarget.GetLatitude();
			double double_ = waypoint.Longitude;
			double double_2 = waypoint.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, float_, PrimaryTarget.CurrentHeading);
			waypoint.Latitude = double_2;
			waypoint.Longitude = double_;
			m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), waypoint.Latitude, waypoint.Longitude)));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100051", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Manouver_InterceptCourse(float float_0, float? nullable_0, ref bool bool_0)
	{
		try
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			Waypoint[] plottedCourse = m_EventVal.Navigator.PlottedCourse;
			if (plottedCourse != null && plottedCourse.Length != 0 && plottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun)
			{
				if (PrimaryTarget.UncertaintyArea != null)
				{
					return;
				}
				m_EventVal.Navigator.RemoveWaypoint_Soft(plottedCourse[0], bool_1: false);
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
				double? num = ActiveUnit_Navigator.CalculateInterceptHeading(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), m_EventVal.CurrentHeading, PrimaryTarget, float_, 0.05f);
				if (!num.HasValue)
				{
					(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(m_EventVal, float_, PrimaryTarget);
					if (!Information.IsNothing(tuple))
					{
						num = Module_Unit.BearingToPoint_True(m_EventVal, tuple.Item1.Latitude, tuple.Item1.Longitude);
					}
				}
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

	public void Manouver_ProportionalNavigation(float float_0)
	{
		try
		{
			float num2;
			if (m_EventVal.IsWeapon)
			{
				float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
				num2 = Math.Min(64f, num / (m_EventVal.CurrentSpeed / 3600f));
			}
			else
			{
				num2 = 1f;
			}
			float num3 = Module_Unit.BearingToUnit_Relative(m_EventVal, PrimaryTarget);
			if (!(270f <= num3) && num3 > 90f)
			{
				Manouver_PurePursuit(float_0, 0f, 0f);
				return;
			}
			float num4 = PrimaryTarget.FindImporter(m_EventVal);
			if (float.IsNaN(num4))
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, num3);
				return;
			}
			switch (PrimaryTarget.ResolveInterruptibleQueue(m_EventVal))
			{
			case Misc.TurnDirection.TurnRight:
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(num3 + num2 * num4));
				break;
			case Misc.TurnDirection.TurnLeft:
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(num3 - num2 * num4));
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100053", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void EmployUntargetedWeapons(float float_0)
	{
	}

	public bool TargetIsWasteOfAmmo(Contact contact_0)
	{
		try
		{
			if (contact_0.ActualUnit != null && m_EventVal.GetUnitSide() != null && contact_0.ActualUnit.GetisTaggedAsDecoyByThisSide(m_EventVal.GetUnitSide().ObjectID))
			{
				return true;
			}
			if ((contact_0.Type != Contact_Base.ContactType.ActivationPoint || contact_0.Type == Contact_Base.ContactType.Aimpoint) && Information.IsNothing(contact_0.ActualUnit))
			{
				return true;
			}
			ActiveUnit actualUnit = contact_0.ActualUnit;
			if (Information.IsNothing(actualUnit))
			{
				if (contact_0.Type != Contact_Base.ContactType.Aimpoint && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
				{
					return true;
				}
				return false;
			}
			if (actualUnit.IsFacility && contact_0.BDA_StructuralIntegrity.HasValue && contact_0.BDA_StructuralIntegrity.Value == Contact.BDA_StructuralIntegrityLevel.HeavyDamage && actualUnit.AirFacilities_ReadOnly.Length != 0 && actualUnit.AirFacilities_ReadOnly.Length == actualUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Count())
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101355", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void EngageTargets(float float_0)
	{
		try
		{
			if (m_EventVal == null)
			{
				return;
			}
			Mission mission = m_EventVal.AssignedMissionOrPackage();
			if (mission != null && mission.IsActive && mission.MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)mission;
				if (strike.FocusEntirelyOnStrikeTargets && ((strike.SpecificTargets == null) | (strike.TargetCount == 0)))
				{
					PrimaryTarget = null;
					if (m_EventVal.IsAircraft)
					{
						((Aircraft)m_EventVal).Navigator.ClearPlottedCourse();
					}
					if (strike.RTB_When_Target_Destroyed)
					{
						ReturnToBase(float_0);
					}
					if (mission.IsActive)
					{
						mission.SetStatus(m_EventVal.ParentScen, Mission.MissionStatus.Inactive);
					}
					return;
				}
			}
			if (IsOnMiningRun(float_0))
			{
				bool Local_ShouldDropMines = true;
				List<UnguidedWeapon> mines = m_EventVal.ParentScen.Mines;
				if (mines != null && mines.Count > 0)
				{
					Parallel.ForEach(m_EventVal.ParentScen.Mines.Where((UnguidedWeapon theW) => theW.GetUnitSide() == m_EventVal.GetUnitSide() || Module_Side.IsAlliedWithThisSide(m_EventVal.GetUnitSide(), theW.GetUnitSide())).ToArray(), delegate(UnguidedWeapon theMine, ParallelLoopState loopstate)
					{
						if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, theMine) < (double)m_EventVal.GetSafeDistanceAgainstKnownMineType_meters(theMine.Type, bool_0: false) / 1852.0)
						{
							Local_ShouldDropMines = false;
							loopstate.Stop();
							return;
						}
						if (MiningInfo == null)
						{
							return;
						}
						double num27;
						double? num28;
						if (MiningInfo.LastMineLocal != null)
						{
							num27 = Module_Unit.RangeToPoint_Horiz(m_EventVal, MiningInfo.LastMineLocal);
							num28 = (double?)MiningInfo.Spacing / 1852.0;
							if ((num28.HasValue ? new bool?(num27 < num28.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								goto IL_0211;
							}
						}
						if (MiningInfo.LastMineSet == null)
						{
							return;
						}
						num27 = Module_Unit.RangeToPoint_Horiz(m_EventVal, MiningInfo.LastMineSet);
						num28 = (double?)MiningInfo.SpacingSet / 1852.0;
						if (!(num28.HasValue ? new bool?(num27 < num28.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							return;
						}
						goto IL_0211;
						IL_0211:
						Local_ShouldDropMines = false;
						loopstate.Stop();
					});
				}
				if (Local_ShouldDropMines)
				{
					Mission mission2 = m_EventVal.AssignedMissionOrPackage();
					long long_ = ((mission2 != null && mission2.MissionClass == Mission._MissionClass.Mining) ? ((MiningMission)m_EventVal.AssignedMissionOrPackage()).ArmDelay : (m_EventVal.IsAircraft ? 0 : 3600));
					m_EventVal.Weaponry.AttemptToLayMine(float_0, long_);
				}
			}
			if (Targets_ReadOnly.Length == 0)
			{
				EmployUntargetedWeapons(float_0);
			}
			if (Targets_ReadOnly.Length == 0)
			{
				return;
			}
			Doctrine._WCS? wCS = m_EventVal.Doctrine.GetWeaponControlStatus_Air(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
			Doctrine._WCS? wCS2 = m_EventVal.Doctrine.GetWeaponControlStatus_Surface(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
			Doctrine._WCS? wCS3 = m_EventVal.Doctrine.GetWeaponControlStatus_Submarine(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
			Doctrine._WCS? wCS4 = m_EventVal.Doctrine.GetWeaponControlStatus_Land(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false).Value;
			byte? b = (byte?)wCS;
			bool? flag;
			bool? flag8 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null));
			bool? flag9;
			bool? flag10;
			if (flag8.HasValue && !flag.GetValueOrDefault())
			{
				flag9 = false;
			}
			else
			{
				b = (byte?)wCS2;
				flag8 = (flag10 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null));
				flag9 = ((!flag8.HasValue) ? null : (flag10.GetValueOrDefault() & flag));
			}
			bool? flag11 = flag9;
			flag10 = flag9;
			bool? flag12;
			if (flag10.HasValue && !flag11.GetValueOrDefault())
			{
				flag12 = false;
			}
			else
			{
				b = (byte?)wCS3;
				bool? flag13;
				flag10 = (flag13 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null));
				flag12 = ((!flag10.HasValue) ? null : (flag13.GetValueOrDefault() & flag11));
			}
			bool? flag14 = flag12;
			if (flag14.GetValueOrDefault(true))
			{
				b = (byte?)wCS4;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault() && flag14.HasValue)
				{
					return;
				}
			}
			if (TargetsSortedByRange == null)
			{
				return;
			}
			List<int> list_ = new List<int>();
			TargetingEntry[] array = new TargetingEntry[TargetsSortedByRange.Length - 1 + 1];
			Array.Copy(TargetsSortedByRange, array, TargetsSortedByRange.Length);
			if (PrimaryTarget != null)
			{
				TargetingEntry[] array2 = array;
				TargetingEntry[] array4 = array2;
				foreach (TargetingEntry targetingEntry in array4)
				{
					if (string.CompareOrdinal(targetingEntry.Target.ObjectID, PrimaryTarget.ObjectID) == 0)
					{
						ArrayExtensions.Clear(ref TargetsSortedByRange);
						ArrayExtensions.Add(ref TargetsSortedByRange, targetingEntry);
						break;
					}
				}
			}
			bool flag15 = false;
			Contact primaryTarget = null;
			WeaponSalvo weaponSalvo = null;
			WeaponSalvo weaponSalvo2 = null;
			ActiveUnit activeUnit = null;
			int? num = null;
			Contact Local_theTarget = null;
			Doctrine._GunStrafeGroundTargets? nullable_ = null;
			while (true)
			{
				Weapon Local_theWeaponCANDIDATE = null;
				if (flag15)
				{
					return;
				}
				bool flag2 = true;
				bool flag3 = true;
				bool flag4 = true;
				bool flag5 = true;
				Weapon weapon = m_EventVal.Weaponry.ManageConsumer(Local_theTarget, ref list_);
				if (weapon != null && procVal.HasValue)
				{
					if (!CheckPossibleABMOrASATEngagement)
					{
						float? num12 = procVal;
						if (!(num12.HasValue ? new bool?(num12.GetValueOrDefault() < 15f) : null).GetValueOrDefault())
						{
							try
							{
								TargetingEntry targetingEntry2 = TargetsSortedByRange.Where((TargetingEntry theT) => theT.Target != null && theT.Target.IsAir_Missile_Orbital_Contact).FirstOrDefault();
								if (targetingEntry2 != null)
								{
									Weapon weapon2 = m_EventVal.Weaponry.ManageConsumer(targetingEntry2.Target, ref list_);
									if (weapon2 == null)
									{
										goto IL_07b5;
									}
									double? num18 = procVal;
									double num19 = (double)weapon2.MaxAirRange * 1.5;
									if (!(num18.HasValue ? new bool?(num18.GetValueOrDefault() < num19) : null).GetValueOrDefault())
									{
										goto IL_07b5;
									}
									flag2 = false;
								}
								goto end_IL_06c5;
								IL_07b5:
								if (mission != null && mission.MissionClass == Mission._MissionClass.Strike)
								{
									Strike strike2 = (Strike)mission;
									if (strike2.Type == Strike.StrikeType.Air_Intercept && !strike2.TestValue() && strike2.SpecificTargets != null && strike2.SpecificTargets.Count > 0 && strike2.SpecificTargets != null && strike2.SpecificTargets.Count > 0 && (m_EventVal.IsGroupLead() || !m_EventVal.IsGroupMember()))
									{
										Module_Unit.Unit unit = strike2.SpecificTargets.OrderBy((Module_Unit.Unit x) => Module_Unit.RangeToPoint_Slant(m_EventVal, x.GetLatitude(), x.GetLongitude(), x.GetCurrentAltitude())).FirstOrDefault();
										if (unit != null && m_EventVal.GetUnitSide().Contacts.TryGetValue(unit.ObjectID, ref primaryTarget))
										{
											PrimaryTarget = primaryTarget;
										}
									}
								}
								end_IL_06c5:;
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception exception_ = ex;
								exception_?.Data.Add("Error at 100021345254", "");
								GameGeneral.WriteExceptionsToLog(ref exception_);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							goto IL_257d;
						}
					}
					flag2 = false;
				}
				goto IL_257d;
				IL_0900:
				if (weapon != null && !flag5)
				{
					Local_theWeaponCANDIDATE = weapon;
				}
				goto IL_0920;
				IL_0920:
				if (Local_theWeaponCANDIDATE == null)
				{
					weapon = m_EventVal.Weaponry.CustomizeFacade(Local_theTarget, m_EventVal.Doctrine.GetNukesAllowed(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value == Doctrine._UseNukesAllowed.No);
					if (weapon != null && callbackWrapper.HasValue)
					{
						float? num20 = callbackWrapper;
						if ((num20.HasValue ? new bool?(num20.GetValueOrDefault() < 15f) : null).GetValueOrDefault())
						{
							flag4 = false;
						}
						else if (TargetsSortedByRange.Where((TargetingEntry theT) => theT.Target.IsLandContact).FirstOrDefault() != null)
						{
							double? num21 = callbackWrapper;
							double num22 = (double)weapon.MaxLandRange * 1.2;
							if ((num21.HasValue ? new bool?(num21.GetValueOrDefault() < num22) : null).GetValueOrDefault())
							{
								flag4 = false;
							}
						}
					}
					if (weapon != null && !flag4)
					{
						Local_theWeaponCANDIDATE = weapon;
					}
				}
				if (Local_theWeaponCANDIDATE == null)
				{
					break;
				}
				TargetingEntry[] array3 = array;
				TargetingEntry[] array5 = array3;
				foreach (TargetingEntry targetingEntry3 in array5)
				{
					Local_theTarget = targetingEntry3.Target;
					if (m_EventVal != null && m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (patrol.HasProsecutionArea && !Local_theTarget.GetIsInsideThisArea(patrol.ProsecutionArea, m_EventVal.ParentScen, bool_0: true))
						{
							continue;
						}
					}
					int? num23 = 0;
					float num24 = Module_Unit.RangeToUnit_Slant(m_EventVal, Local_theTarget);
					checked
					{
						if (Local_theTarget.IsWeaponContact && (double)Local_theWeaponCANDIDATE.MinAirRange * 1.5 > (double)num24)
						{
							DropTarget(Local_theTarget);
							bool flag6 = false;
							WeaponSalvo[] weaponSalvos = m_EventVal.GetUnitSide().WeaponSalvos;
							WeaponSalvo[] array6 = weaponSalvos;
							foreach (WeaponSalvo weaponSalvo3 in array6)
							{
								if (Operators.CompareString(weaponSalvo3.Target.ObjectID, Local_theTarget.ObjectID, TextCompare: false) != 0)
								{
									continue;
								}
								WeaponSalvo.Shooter[] shootersList = weaponSalvo3.ShootersList;
								for (int i = 0; i < shootersList.Length; i++)
								{
									if (Operators.CompareString(shootersList[i].ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
									{
										flag6 = true;
									}
									if (weaponSalvo != null && weaponSalvo.ShootersList.Count() == 1)
									{
										weaponSalvo2 = weaponSalvo3;
									}
								}
								if (flag6 && weaponSalvo2 == null && m_EventVal.GetUnitSide().callbackProxy != null)
								{
									ArrayExtensions.Remove(ref weaponSalvo3.ShootersList, new WeaponSalvo.Shooter(m_EventVal.ObjectID));
									KeyValuePair<string, FiringProposal> keyValuePair = m_EventVal.GetUnitSide().callbackProxy.Where((KeyValuePair<string, FiringProposal> x) => (Operators.CompareString(x.Value.FiringUnit.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0) & (Operators.CompareString(x.Value.Target.ObjectID, Local_theTarget.ObjectID, TextCompare: false) == 0)).FirstOrDefault();
									if (!(keyValuePair.Equals(default(KeyValuePair<string, FiringProposal>)) | keyValuePair.Equals(new KeyValuePair<string, FiringProposal>(null, null))))
									{
										ConcurrentDictionary<string, FiringProposal> callbackProxy = m_EventVal.GetUnitSide().callbackProxy;
										string key = keyValuePair.Key;
										FiringProposal value = keyValuePair.Value;
										callbackProxy.TryRemove(key, out value);
									}
								}
							}
							if (weaponSalvo2 != null)
							{
								ArrayExtensions.Remove(ref m_EventVal.GetUnitSide().WeaponSalvos, weaponSalvo2);
							}
							continue;
						}
						ref Contact contact_ = ref Local_theTarget;
						Weapon weapon_ = Local_theWeaponCANDIDATE;
						flag14 = null;
						Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_, ref flag14);
						Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref Local_theWeaponCANDIDATE, ref Local_theTarget, ref _WRA_WeaponTargetType_, m_EventVal.GetUnitSide().ObjectID);
						Doctrine doctrine = m_EventVal.Doctrine;
						Scenario parentScen = m_EventVal.ParentScen;
						Weapon weapon_2 = Local_theWeaponCANDIDATE;
						int? nullable_2 = null;
						int? nullable_3 = null;
						int? num2 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine, parentScen, weapon_2, wRA_WeaponTargetType_, bool_0: false, ref nullable_2, ref nullable_3);
						Doctrine doctrine2 = m_EventVal.Doctrine;
						Scenario parentScen2 = m_EventVal.ParentScen;
						Weapon weapon_3 = Local_theWeaponCANDIDATE;
						nullable_3 = null;
						nullable_2 = null;
						int? num3 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine2, parentScen2, weapon_3, wRA_WeaponTargetType_, bool_0: false, ref nullable_3, ref nullable_2);
						nullable_2 = num3;
						if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() == -99) : null).GetValueOrDefault())
						{
							num3 = int.MaxValue;
						}
						else
						{
							nullable_2 = num3;
							if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() < 0) : null).GetValueOrDefault())
							{
								num3 = m_EventVal.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num3, ref m_EventVal, ref Local_theTarget, ref Local_theWeaponCANDIDATE);
							}
						}
						if (((num3.HasValue & num23.HasValue) ? new bool?(num3.GetValueOrDefault() > num23.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							Side unitSide = m_EventVal.GetUnitSide();
							int? nullable_4 = num3;
							ActiveUnit activeUnit_ = m_EventVal;
							num23 = unitSide.ConvertSalvoWeaponQty_To_ActualQuantity(nullable_4, ref activeUnit_, ref Local_theTarget, ref Local_theWeaponCANDIDATE);
						}
						int num4 = Local_theTarget.IncomingGuidedWeapons.Where((Weapon x) => x.DBID == Local_theWeaponCANDIDATE.DBID).Count();
						if (num4 > 0 && (num3.HasValue ? new bool?(num4 >= num3.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							continue;
						}
						int num5 = 0;
						if (m_EventVal.GetUnitSide().WeaponSalvos != null && m_EventVal.GetUnitSide().WeaponSalvos.Count() > 0)
						{
							WeaponSalvo[] weaponSalvos2 = m_EventVal.GetUnitSide().WeaponSalvos;
							for (int j = 0; j < weaponSalvos2.Length; j++)
							{
								weaponSalvo = weaponSalvos2[j];
								if (Operators.CompareString(weaponSalvo.Target.ObjectID, Local_theTarget.ObjectID, TextCompare: false) != 0 || weaponSalvo.int_0 != Local_theWeaponCANDIDATE.DBID)
								{
									continue;
								}
								WeaponSalvo.Shooter[] shootersList2;
								unchecked
								{
									if (weaponSalvo.WpnQuantityAssigned == int.MaxValue)
									{
										if (m_EventVal.ParentScen.ActiveUnits.TryGetValue(weaponSalvo.ShootersList[0].ShooterObjectID, ref activeUnit))
										{
											num5 += activeUnit.Weaponry.HowManyOfThisWeapon(Local_theWeaponCANDIDATE.DBID);
										}
									}
									else
									{
										num5 += weaponSalvo.WpnQuantityAssigned;
									}
									if (PrimaryTarget != null)
									{
										continue;
									}
									shootersList2 = weaponSalvo.ShootersList;
								}
								for (int k = 0; k < shootersList2.Length; k++)
								{
									if (Operators.CompareString(shootersList2[k].ShooterObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
									{
										PrimaryTarget = weaponSalvo.Target;
										flag15 = true;
									}
								}
							}
						}
						if ((num3.HasValue ? new bool?(num5 >= num3.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							continue;
						}
						nullable_2 = num2;
						if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() == -99) : null).GetValueOrDefault())
						{
							num2 = int.MaxValue;
						}
						int num6 = 0;
						nullable_2 = num2;
						if ((nullable_2.HasValue ? new bool?(nullable_2.GetValueOrDefault() != int.MaxValue) : null).GetValueOrDefault())
						{
							WeaponSalvo[] weaponSalvos3 = m_EventVal.GetUnitSide().WeaponSalvos;
							for (int l = 0; l < weaponSalvos3.Length; l++)
							{
								weaponSalvo = weaponSalvos3[l];
								if (Operators.CompareString(weaponSalvo.Target?.ActualUnit?.ObjectID, Local_theTarget.ActualUnit.ObjectID, TextCompare: false) == 0 && weaponSalvo.int_0 == Local_theWeaponCANDIDATE.DBID)
								{
									num6 = unchecked(num6 + weaponSalvo.ShootersList.Count());
								}
							}
						}
						if ((num2.HasValue ? new bool?(num6 >= num2.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							continue;
						}
						TargetingEntry._TargetingBehavior behavior = targetingEntry3.Behavior;
						if (behavior != 0 && behavior != TargetingEntry._TargetingBehavior.ManualTargeted)
						{
							continue;
						}
					}
					if (!Local_theTarget.IsBallisticTarget() && !Local_theTarget.IsOrbitalContact)
					{
						if (Local_theTarget.IsAir_Missile_Orbital_Contact)
						{
							if (flag2)
							{
								continue;
							}
							b = (byte?)wCS;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								if (m_EventVal.GetUnitSide() != null && m_EventVal.GetUnitSide().IsHumanControlled && ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All) | ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit) & m_EventVal.GetUnitSide().SelectedUnits.Contains(m_EventVal))))
								{
									Notification_Bark.Create(m_EventVal, Local_theWeaponCANDIDATE.Name + "is on HOLD against air targets", Color.Red, bool_0: true, bool_1: true, 2f);
								}
								continue;
							}
						}
						else if (Local_theTarget.IsShipContact)
						{
							if (flag3)
							{
								continue;
							}
							b = (byte?)wCS2;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								if (m_EventVal.GetUnitSide() != null && m_EventVal.GetUnitSide().IsHumanControlled && ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All) | ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit) & m_EventVal.GetUnitSide().SelectedUnits.Contains(m_EventVal))))
								{
									Notification_Bark.Create(m_EventVal, Local_theWeaponCANDIDATE.Name + "is on HOLD against surface targets", Color.Red, bool_0: true, bool_1: true, 2f);
								}
								continue;
							}
						}
						else if (Local_theTarget.IsSubmergedContact)
						{
							if (flag5)
							{
								continue;
							}
							b = (byte?)wCS3;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								if (m_EventVal.GetUnitSide() != null && m_EventVal.GetUnitSide().IsHumanControlled && ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All) | ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit) & m_EventVal.GetUnitSide().SelectedUnits.Contains(m_EventVal))))
								{
									Notification_Bark.Create(m_EventVal, Local_theWeaponCANDIDATE.Name + "is on HOLD against submerged targets", Color.Red, bool_0: true, bool_1: true, 2f);
								}
								continue;
							}
						}
						else if (Local_theTarget.IsLandContact)
						{
							if (flag4)
							{
								continue;
							}
							b = (byte?)wCS4;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								if (m_EventVal.GetUnitSide() != null && m_EventVal.GetUnitSide().IsHumanControlled && ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All) | ((SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit) & m_EventVal.GetUnitSide().SelectedUnits.Contains(m_EventVal))))
								{
									Notification_Bark.Create(m_EventVal, Local_theWeaponCANDIDATE.Name + "is on HOLD against land targets", Color.Red, bool_0: true, bool_1: true, 2f);
								}
								continue;
							}
						}
					}
					else
					{
						b = (byte?)wCS;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							continue;
						}
					}
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(Local_theTarget.ObjectID, out var value2))
					{
						value2 = Local_theTarget.GetStance(m_EventVal.GetUnitSide());
					}
					if (value2 != Misc.PostureStance.Hostile)
					{
						if (Local_theTarget.IsAir_Missile_Orbital_Contact)
						{
							b = (byte?)wCS;
							flag14 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
							if (((!flag14) ?? flag14).GetValueOrDefault())
							{
								continue;
							}
						}
						else if (Local_theTarget.IsShipContact)
						{
							b = (byte?)wCS2;
							flag14 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
							if (((!flag14) ?? flag14).GetValueOrDefault())
							{
								continue;
							}
						}
						else if (Local_theTarget.IsSubmergedContact)
						{
							if (Local_theTarget.Type != Contact_Base.ContactType.Torpedo)
							{
								b = (byte?)wCS3;
								flag14 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
								if (((!flag14) ?? flag14).GetValueOrDefault())
								{
									continue;
								}
							}
						}
						else
						{
							b = (byte?)wCS4;
							flag14 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
							if (((!flag14) ?? flag14).GetValueOrDefault())
							{
								continue;
							}
						}
					}
					if (m_EventVal.Doctrine.CallRepository(m_EventVal.ParentScen) && Local_theTarget != PrimaryTarget)
					{
						b = (byte?)m_EventVal.Doctrine.GetShootTourists(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() != 1) : null).GetValueOrDefault())
						{
							continue;
						}
					}
					if (!IsClearedToEngageThisTarget(Local_theTarget))
					{
						continue;
					}
					bool flag7 = false;
					if (m_EventVal.IsAircraft && ((Aircraft)m_EventVal).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)m_EventVal).Loadout.Weapons;
						WeaponRec[] array7 = weapons;
						foreach (WeaponRec weaponRec in array7)
						{
							if (!weaponRec.GetReferenceWeapon(m_EventVal.ParentScen).IsPalletWeapon)
							{
								continue;
							}
							if (weaponRec.GetReferenceWeapon(m_EventVal.ParentScen).WeaponWeapons.Count == 0)
							{
								weaponRec.GetReferenceWeapon(m_EventVal.ParentScen).InitializeWeaponWeaponsPallet();
							}
							int value3 = 0;
							Weapon weapon_4 = new Weapon(ref m_EventVal.ParentScen);
							int num7 = 0;
							foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(m_EventVal.ParentScen).WeaponWeapons)
							{
								if (weaponWeapon.CurrentLoad > 0)
								{
									num7 = weaponWeapon.CurrentLoad;
									weapon_4 = weaponWeapon.GetReferenceWeapon(m_EventVal.ParentScen);
									value3 = weaponWeapon.CurrentLoad * weaponRec.CurrentLoad;
									break;
								}
							}
							if (m_EventVal.Doctrine.InsertRepository(ref weapon_4))
							{
								ref Contact contact_2 = ref Local_theTarget;
								Weapon weapon_5 = weapon_4;
								flag14 = null;
								Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_2 = Doctrine.WRA_DetermineTargetType(ref contact_2, weapon_5, ref flag14);
								Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_4, ref Local_theTarget, ref _WRA_WeaponTargetType_2, m_EventVal.GetUnitSide().ObjectID);
								Doctrine doctrine3 = m_EventVal.Doctrine;
								Scenario parentScen3 = m_EventVal.ParentScen;
								Weapon weapon_6 = weapon_4;
								int? nullable_5 = null;
								int? nullable_6 = null;
								num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, parentScen3, weapon_6, wRA_WeaponTargetType_2, bool_0: false, ref nullable_5, ref nullable_6);
								nullable_6 = num;
								if ((nullable_6.HasValue ? new bool?(nullable_6.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									continue;
								}
								nullable_6 = num;
								if ((nullable_6.HasValue ? new bool?(nullable_6.GetValueOrDefault() == -99) : null).GetValueOrDefault())
								{
									num = value3;
								}
								nullable_6 = num;
								if ((nullable_6.HasValue ? new bool?(nullable_6.GetValueOrDefault() < 0) : null).GetValueOrDefault())
								{
									num = m_EventVal.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num, ref m_EventVal, ref Local_theTarget, ref Local_theWeaponCANDIDATE);
								}
								if (!num.HasValue)
								{
									continue;
								}
								Doctrine doctrine4 = m_EventVal.Doctrine;
								Doctrine doctrine5 = m_EventVal.Doctrine;
								Scenario parentScen4 = m_EventVal.ParentScen;
								int dBID = weapon_4.DBID;
								float? nullable_7 = null;
								float? nullable_8 = null;
								float? num8 = doctrine4.IncludeRepository(doctrine5, parentScen4, dBID, wRA_WeaponTargetType_2, bool_0: false, ref nullable_7, ref nullable_8);
								if (Information.IsNothing(num8))
								{
									num8 = -99f;
								}
								nullable_8 = num8;
								if ((nullable_8.HasValue ? new bool?(nullable_8.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
								{
									continue;
								}
								nullable_8 = num8;
								flag14 = (nullable_8.HasValue ? new bool?(nullable_8.GetValueOrDefault() == -99f) : null);
								if (((!flag14) ?? flag14).GetValueOrDefault() && weapon_4.GetMaxRangeForThisTarget(m_EventVal, Local_theTarget, bool_0: true, m_EventVal.Doctrine, bool_1: false) < Module_Unit.RangeToUnit_Horiz(m_EventVal, Local_theTarget))
								{
									continue;
								}
							}
							foreach (WeaponRec weaponWeapon2 in weaponRec.GetReferenceWeapon(m_EventVal.ParentScen).WeaponWeapons)
							{
								if (weaponWeapon2.GetReferenceWeapon(Local_theTarget.ActualUnit.ParentScen).DBID != weapon_4.DBID)
								{
									continue;
								}
								m_EventVal.Weaponry.CreateSalvo(Local_theTarget, weaponWeapon2.int_0, num.Value, bool_1: true, ref nullable_, DateTime.MaxValue, bool_2: true);
								int val = 0;
								int currentLoad = weaponRec.CurrentLoad;
								for (int num9 = 0; num9 <= currentLoad; num9++)
								{
									int num10 = num9 * num7;
									if ((num.HasValue ? new bool?(num10 >= num.GetValueOrDefault()) : null).GetValueOrDefault())
									{
										val = num9;
										break;
									}
								}
								int int_ = Math.Min(val, weaponRec.CurrentLoad);
								m_EventVal.Weaponry.CreateSalvo(Local_theTarget, weaponRec.GetReferenceWeapon(m_EventVal.ParentScen).DBID, int_, bool_1: true, ref nullable_, DateTime.MinValue, bool_2: false, bool_3: false, bool_4: true, bool_5: true);
								flag7 = true;
								flag15 = true;
								break;
							}
						}
					}
					if (flag7)
					{
						continue;
					}
					if (Local_theTarget.ActualUnit != null && (m_EventVal.IsAerospaceUnit || Local_theTarget.ActualUnit.IsAerospaceUnit))
					{
						float num11 = Local_theTarget.ActualUnit.MaxSpeed + m_EventVal.MaxSpeed;
						if (num11 > 0f && num24 / num11 * 3600f < 20f)
						{
							GameGeneral.HighIntensityResolution = 4f;
						}
					}
					if (!m_EventVal.Weaponry.CreateSalvo(Local_theTarget, 0, 0, bool_1: false, ref nullable_, DateTime.MinValue))
					{
						continue;
					}
					flag15 = true;
					break;
				}
				list_.Add(Local_theWeaponCANDIDATE.DBID);
				if (HasDuplicates(list_))
				{
					flag15 = true;
				}
				try
				{
					if (list_.Count > 1000)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						flag15 = true;
						throw new Exception("Weapon firing loop issue");
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 321324432", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (flag2 && flag4 && flag5 && flag3)
				{
					flag15 = true;
				}
				continue;
				IL_257d:
				if (weapon != null && !flag2)
				{
					Local_theWeaponCANDIDATE = weapon;
				}
				if (Local_theWeaponCANDIDATE == null)
				{
					weapon = m_EventVal.Weaponry.CountFacade(Local_theTarget, m_EventVal.Doctrine.GetNukesAllowed(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value == Doctrine._UseNukesAllowed.No);
					if (weapon != null && structWrapper.HasValue)
					{
						float? num13 = structWrapper;
						if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() < 15f) : null).GetValueOrDefault())
						{
							flag3 = false;
						}
						else
						{
							TargetingEntry targetingEntry4 = TargetsSortedByRange.Where((TargetingEntry theT) => theT.Target.IsShipContact).FirstOrDefault();
							if (targetingEntry4 != null)
							{
								Weapon weapon3 = m_EventVal.Weaponry.CountFacade(targetingEntry4.Target, bool_1: false);
								if (weapon3 != null)
								{
									if (!weapon3.IsTorpedo)
									{
										double? num14 = structWrapper;
										double num15 = (double)weapon3.MaxSurfaceRange * 1.2;
										if (!(num14.HasValue ? new bool?(num14.GetValueOrDefault() < num15) : null).GetValueOrDefault())
										{
											goto IL_27d9;
										}
									}
									flag3 = false;
								}
							}
						}
					}
					goto IL_27d9;
				}
				goto IL_0920;
				IL_27d9:
				if (weapon != null && !flag3)
				{
					Local_theWeaponCANDIDATE = weapon;
				}
				weapon = m_EventVal.Weaponry.CloneFacade(Local_theTarget);
				if (weapon != null && m_MerchantWrapper.HasValue)
				{
					float? merchantWrapper = m_MerchantWrapper;
					if ((merchantWrapper.HasValue ? new bool?(merchantWrapper.GetValueOrDefault() < 15f) : null).GetValueOrDefault())
					{
						flag5 = false;
					}
					else
					{
						if (!weapon.IsTorpedo)
						{
							double? num16 = m_MerchantWrapper;
							double num17 = (double)weapon.MaxSubsurfaceRange * 1.2;
							if (!(num16.HasValue ? new bool?(num16.GetValueOrDefault() < num17) : null).GetValueOrDefault())
							{
								goto IL_0900;
							}
						}
						flag5 = false;
					}
				}
				goto IL_0900;
			}
			if (PrimaryTarget != null && m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
				Contact primaryTarget2 = PrimaryTarget;
				Doctrine doctrine6 = m_EventVal.Doctrine;
				string string_ = "";
				int int_2 = 0;
				if (!weaponry.PopConsumer(primaryTarget2, bool_1: true, doctrine6, ref string_, ref int_2))
				{
					m_EventVal.AI.DropTarget(PrimaryTarget);
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100054", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HasDuplicates(List<int> list_0)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int item in list_0)
		{
			if (!hashSet.Contains(item))
			{
				hashSet.Add(item);
				continue;
			}
			return true;
		}
		return false;
	}

	private TargetingEntry[] CreateClient(ObservableDictionary<string, TargetingEntry> observableDictionary_0)
	{
		if (m_EventVal != null && observableDictionary_0.Count != 0)
		{
			if (observableDictionary_0.Count == 1)
			{
				return new TargetingEntry[1] { observableDictionary_0.Values.ElementAtOrDefault(0) };
			}
			return (from theTE in observableDictionary_0.Values
				select (theTE) into targetingEntry_0
				orderby Module_Unit.RangeToUnit_Horiz(m_EventVal, targetingEntry_0.Target)
				select targetingEntry_0).ToArray();
		}
		return new TargetingEntry[0];
	}

	private void CompareClient(ref List<Contact> list_0)
	{
		int count = list_0.Count;
		LockRandom lockRandom = new LockRandom();
		int num = count;
		do
		{
			double num2 = lockRandom.NextDouble();
			int num3 = (int)Math.Round(Math.Floor((double)num * num2) + 1.0);
			Contact value = list_0[num3 - 1];
			list_0[num3 - 1] = list_0[num - 1];
			list_0[num - 1] = value;
			num--;
		}
		while (num > 1);
	}

	public virtual void ManouverAgainstPrimaryThreat(float float_0)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	public virtual void ManouverAwayFromWeaponEffects(float float_0, Module_Unit.Unit unit_0)
	{
		double latitude = unit_0.GetLatitude();
		double longitude = unit_0.GetLongitude();
		if (unit_0.IsWeapon)
		{
			Weapon weapon = (Weapon)unit_0;
			if (weapon.AI.PrimaryTarget != null && weapon.AI.PrimaryTarget.ActualUnit != m_EventVal)
			{
				latitude = weapon.AI.PrimaryTarget.GetLatitude();
				longitude = weapon.AI.PrimaryTarget.GetLongitude();
			}
		}
		else if ((object)unit_0.GetType() == typeof(UnguidedWeapon))
		{
			UnguidedWeapon unguidedWeapon = (UnguidedWeapon)unit_0;
			if (unguidedWeapon.Target != null && unguidedWeapon.Target.ActualUnit != m_EventVal)
			{
				latitude = unguidedWeapon.Target.GetLatitude();
				longitude = unguidedWeapon.Target.GetLongitude();
			}
		}
		float num = (float)Math.Round(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), latitude, longitude), 0);
		if (!float.IsNegativeInfinity(num))
		{
			int int_ = (int)Math.Round(num);
			OutrunThreat(ref int_);
		}
	}

	public float AngleOffContactsBoresight(ref Contact contact_0)
	{
		try
		{
			float currentHeading = contact_0.CurrentHeading;
			float num = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), m_EventVal.GetLatitude(), m_EventVal.GetLongitude());
			num = Math2.UpdateClass(num - currentHeading);
			currentHeading = 0f;
			if (num <= 180f)
			{
				return num;
			}
			return 0f - (360f - num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100056", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public float BearingToUnit_True(Module_Unit.Unit unit_0)
	{
		return Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
	}

	internal bool ReadClient(ref Weapon weapon_0)
	{
		try
		{
			if (PrimaryTarget != null)
			{
				if ((weapon_0.Is_LOAL_capable && weapon_0.HasGoneAutonomous) || weapon_0.IsFullyAutonomous)
				{
					Contact[] targets_ReadOnly = Targets_ReadOnly;
					Contact[] array = targets_ReadOnly;
					foreach (Contact contact in array)
					{
						if (contact != null && contact.ActualUnit != null && PrimaryTarget != null && ActiveUnit_Sensory.ContactsAreOfSameActualUnit(PrimaryTarget, contact))
						{
							return true;
						}
					}
				}
				if (weapon_0.DataLinkParent != null)
				{
					if (weapon_0.IsAAW && PrimaryTarget.IsAir_GuidedWeapon_Contact && weapon_0.IsSemiAutonomous)
					{
						if (weapon_0.DataLinkParent.Sensory.PostDic(weapon_0.AI.PrimaryTarget))
						{
							return true;
						}
						return false;
					}
					if (weapon_0.IsAAW && PrimaryTarget.IsAir_Missile_Orbital_Contact)
					{
						if (weapon_0.DataLinkParent.Sensory.PostDic(weapon_0.AI.PrimaryTarget))
						{
							return true;
						}
						if (weapon_0.CalculateReponse() && weapon_0.Navigator.HasPlottedCourse() && PrimaryTarget.IsBallisticTarget() && PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown && PrimaryTarget.AltitudeIsKnown)
						{
							return true;
						}
						if (weapon_0.DataLinkParent != null && weapon_0.BlindTime == 0f)
						{
							return true;
						}
						return false;
					}
				}
				switch (weapon_0.Guidance)
				{
				case Weapon.WeaponGuidanceType.Datalink_Plus_Active:
					if (m_EventVal.IsTorpedo)
					{
						return weapon_0.BlindTime == 0f;
					}
					goto default;
				case Weapon.WeaponGuidanceType.CommandGuided_Datalinked:
					if (weapon_0.DataLinkParent != null && weapon_0.BlindTime == 0f)
					{
						return true;
					}
					goto default;
				default:
					return false;
				case Weapon.WeaponGuidanceType.SemiActive:
				case Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive:
				case Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive:
				case Weapon.WeaponGuidanceType.TVM:
				case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
				case Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
					return weapon_0.BlindTime == 0f;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100057", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public float BearingToUnit_NextSecond(Module_Unit.Unit unit_0)
	{
		try
		{
			float horizMovementDistanceOnThisTime = unit_0.GetHorizMovementDistanceOnThisTime(1f);
			float horizMovementDistanceOnThisTime2 = m_EventVal.GetHorizMovementDistanceOnThisTime(1f);
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_, ref double_2, horizMovementDistanceOnThisTime, unit_0.CurrentHeading);
			float float_ = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), double_2, double_);
			double double_3 = 0.0;
			double double_4 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(m_EventVal.GetLongitude(), m_EventVal.GetLatitude(), ref double_3, ref double_4, horizMovementDistanceOnThisTime2, float_);
			return Math2.PublishClass(double_4, double_3, double_2, double_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100058", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public float BearingToUnit_Relative(Module_Unit.Unit unit_0)
	{
		try
		{
			float currentHeading = m_EventVal.CurrentHeading;
			float num = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
			num = Math2.UpdateClass(num - currentHeading);
			currentHeading = 0f;
			if (num <= 180f)
			{
				return num;
			}
			return 0f - (360f - num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100059", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public float BearingToPoint_True(double double_0, double double_1)
	{
		return Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), double_0, double_1);
	}

	public float BearingToPoint_Relative(double double_0, double double_1)
	{
		try
		{
			float currentHeading = m_EventVal.CurrentHeading;
			float num = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), double_0, double_1);
			num = Math2.UpdateClass(num - currentHeading);
			currentHeading = 0f;
			if (num <= 180f)
			{
				return num;
			}
			return 0f - (360f - num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100060", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public float DistanceFromThreat(Module_Unit.Unit unit_0, ref Contact contact_0)
	{
		return Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude());
	}

	public void OutrunThreat(ref int int_0)
	{
		try
		{
			float num = Math2.InsertClass(int_0 + 180);
			if (m_EventVal.IsShip || m_EventVal.IsSubmarine)
			{
				float float_ = 2f;
				bool flag = false;
				int num2 = 0;
				double double_ = 0.0;
				double double_2 = 0.0;
				while (!flag && num2 < 72)
				{
					num2++;
					Geodesic_EdWilliams.CalcPoint_Williams(m_EventVal.GetLongitude(), m_EventVal.GetLatitude(), ref double_, ref double_2, float_, num);
					ActiveUnit_Navigator navigator = m_EventVal.Navigator;
					double latitude = m_EventVal.GetLatitude();
					double longitude = m_EventVal.GetLongitude();
					double double_3 = double_2;
					double double_4 = double_;
					float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
					int int_ = 0;
					GeoPoint geoPoint_ = null;
					if (navigator.PathLineIsInterrupted(latitude, longitude, double_3, double_4, bool_1: true, 0f, bool_2: false, null, bool_3: true, bool_4: false, bool_5: true, nullable_, ref int_, ref geoPoint_))
					{
						num += 5f;
					}
					else
					{
						flag = true;
					}
				}
			}
			m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100061", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsClearedToEngageThisTarget(Contact contact_0)
	{
		if (m_EventVal == null)
		{
			return false;
		}
		try
		{
			if (m_EventVal.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)m_EventVal;
				if (aircraft.AssignedMissionOrPackage() != null && aircraft.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)aircraft.AssignedMissionOrPackage();
					if ((strike.SpecificTargets.Contains(contact_0) || strike.SpecificTargets.Contains(contact_0.ActualUnit)) && aircraft.Navigator.HasFlightPlan && aircraft.Navigator.CurrentFlightHasStandoffWeaponFiringPoint() && !aircraft.Navigator.HasReachedStandoffWeaponFiringPoint())
					{
						return false;
					}
				}
			}
			if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact_0.ObjectID, out var value))
			{
				value = contact_0.GetStance(m_EventVal.GetUnitSide());
			}
			if (contact_0.Type != Contact_Base.ContactType.Aimpoint && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
			{
				if (TargetingBehaviorForThisTarget(contact_0) != TargetingEntry._TargetingBehavior.ManualTargeted)
				{
					switch (value)
					{
					case Misc.PostureStance.Hostile:
						if (contact_0.IsAir_Missile_Orbital_Contact)
						{
							byte? b5 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Air(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b5.HasValue ? new bool?(b5.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								return false;
							}
						}
						else if (contact_0.IsShipContact)
						{
							byte? b6 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Surface(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b6.HasValue ? new bool?(b6.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								return false;
							}
						}
						else if (contact_0.IsSubmergedContact)
						{
							byte? b7 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Submarine(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b7.HasValue ? new bool?(b7.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								return false;
							}
						}
						else
						{
							byte? b8 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Land(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b8.HasValue ? new bool?(b8.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								return false;
							}
						}
						return true;
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Unknown:
						if (contact_0.IsAir_Missile_Orbital_Contact)
						{
							byte? b = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Air(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								return true;
							}
						}
						else if (contact_0.IsShipContact)
						{
							byte? b2 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Surface(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								return true;
							}
						}
						else if (contact_0.IsSubmergedContact)
						{
							if (contact_0.Type == Contact_Base.ContactType.Torpedo)
							{
								return true;
							}
							byte? b3 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Submarine(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								return true;
							}
						}
						else
						{
							byte? b4 = (byte?)m_EventVal.Doctrine.GetWeaponControlStatus_Land(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
							if ((b4.HasValue ? new bool?(b4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								return true;
							}
						}
						break;
					}
					Side unitSide = m_EventVal.GetUnitSide();
					ref ActiveUnit eventVal = ref m_EventVal;
					TargetingEntry._TargetingBehavior _TargetingBehavior_ = TargetingEntry._TargetingBehavior.AutoTargeted;
					if (unitSide.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref eventVal, ref contact_0, ref _TargetingBehavior_) <= 0)
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100062", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void OptimizeAltSpeedForNextEngagement(float float_0, ref Weapon weapon_0)
	{
		try
		{
			if (Information.IsNothing(PrimaryTarget))
			{
				return;
			}
			Doctrine doctrine = m_EventVal.Doctrine;
			if (Information.IsNothing(weapon_0))
			{
				Side unitSide = m_EventVal.GetUnitSide();
				ref ActiveUnit eventVal = ref m_EventVal;
				Contact contact_ = PrimaryTarget;
				List<Weapon> list = unitSide.WeaponsLeftToFireAtThisTarget(ref eventVal, ref contact_);
				PrimaryTarget = contact_;
				List<Weapon> list2 = list;
				if (list2.Count <= 0)
				{
					weapon_0 = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, doctrine);
				}
				else
				{
					weapon_0 = list2.OrderByDescending((Weapon theWeapon) => theWeapon.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, doctrine, bool_1: false)).ElementAtOrDefault(0);
				}
			}
			if (Information.IsNothing(weapon_0))
			{
				return;
			}
			float maxRangeForThisTarget = weapon_0.GetMaxRangeForThisTarget(m_EventVal, PrimaryTarget, bool_0: true, doctrine, bool_1: false);
			float float_ = ((PrimaryTarget.CurrentSpeed == 0f) ? m_EventVal.CurrentSpeed : Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading));
			Weapon._WeaponType type = weapon_0.Type;
			float num = 0f;
			if (type != Weapon._WeaponType.Rocket && type != Weapon._WeaponType.Gun)
			{
				num = weapon_0.MaxLaunchAlt_AGL;
			}
			else if (Module_Unit.RangeToUnit_Slant(m_EventVal, PrimaryTarget) > maxRangeForThisTarget)
			{
				num = (float)(Math.Sqrt(2.0) / 2.0 * (double)maxRangeForThisTarget * 1852.0);
			}
			float num2 = 0f;
			if (num < m_EventVal.DesiredAltitude)
			{
				num2 = (m_EventVal.DesiredAltitude - num) / m_EventVal.Kinematics.DiveRate_Nominal();
			}
			if (weapon_0.MinLaunchAlt_AGL > m_EventVal.DesiredAltitude)
			{
				num2 = (weapon_0.MinLaunchAlt_AGL - m_EventVal.DesiredAltitude) / m_EventVal.Kinematics.GetClimbRate_Nominal();
			}
			float num3 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			float num4;
			if (num3 <= maxRangeForThisTarget)
			{
				num4 = 0f;
			}
			else
			{
				float float_2 = num3 - maxRangeForThisTarget;
				num4 = m_EventVal.ETA_To_Location(float_, float_2);
			}
			if (num4 < 0f)
			{
				return;
			}
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
			{
				bool flag = false;
				if (num2 >= num4)
				{
					if (num < m_EventVal.DesiredAltitude)
					{
						m_EventVal.DesiredAltitude = num - 100f;
						flag = true;
					}
					if (weapon_0.MinLaunchAlt_AGL > m_EventVal.DesiredAltitude)
					{
						m_EventVal.DesiredAltitude = weapon_0.MinLaunchAlt_AGL + 100f;
						flag = true;
					}
					if (!flag)
					{
						m_EventVal.DesiredAltitude = m_EventVal.DesiredAltitude;
					}
				}
			}
			if ((double)maxRangeForThisTarget * 1.2 < (double)num3)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
				return;
			}
			if (weapon_0.MaxLaunchSpeed != 0 && (float)weapon_0.MaxLaunchSpeed < m_EventVal.CurrentSpeed)
			{
				m_EventVal.DesiredSpeed = weapon_0.MaxLaunchSpeed - 10;
			}
			if (weapon_0.MinLaunchSpeed != 0 && (float)weapon_0.MinLaunchSpeed > m_EventVal.CurrentSpeed)
			{
				m_EventVal.DesiredSpeed = weapon_0.MinLaunchSpeed + 10;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100063", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void BeamThreat(int int_0)
	{
		try
		{
			int num = (int)Math.Round(m_EventVal.CurrentHeading);
			int num2 = 0;
			int num3 = 0;
			int num4 = num;
			while (!MathFunctions.AddRequest(num4, int_0))
			{
				num4 = Math2.InsertClass(num4 - 1);
				num2++;
			}
			int num5 = num;
			while (!MathFunctions.AddRequest(num5, int_0))
			{
				num5 = Math2.InsertClass(num5 + 1);
				num3++;
			}
			if (num2 < num3)
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, num4);
			}
			else
			{
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, num5);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100064", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void EvaluateThreats()
	{
	}

	protected void ManouverToNeutralizeMine(UnguidedWeapon unguidedWeapon_0, float float_0)
	{
		try
		{
			if (m_EventVal.MineCountermeasures.Count == 0)
			{
				return;
			}
			if ((double)float_0 * 1852.0 < 20.0)
			{
				foreach (Sensor mineCountermeasure in m_EventVal.MineCountermeasures)
				{
					if (!mineCountermeasure.GetCanSweepThisMine(unguidedWeapon_0) || !mineCountermeasure.IsActive)
					{
						continue;
					}
					if (unguidedWeapon_0.TimeToDetonate <= 0f)
					{
						if (m_EventVal.HasMineDisposalCharges && m_EventVal.MineCountermeasures.Count > 1 && (double)float_0 * 1852.0 > 10.0)
						{
							break;
						}
						if (!mineCountermeasure.IsExplosiveMineNeutralizer && mineCountermeasure.Status == PlatformComponent._ComponentStatus.Operational)
						{
							m_EventVal.NeutralizeMine(unguidedWeapon_0, mineCountermeasure);
							return;
						}
						if (mineCountermeasure.IsExplosiveMineNeutralizer && mineCountermeasure.Status == PlatformComponent._ComponentStatus.Operational)
						{
							m_EventVal.NeutralizeMine(unguidedWeapon_0, mineCountermeasure);
							return;
						}
					}
					else
					{
						Sensor.Sensor_Type type = mineCountermeasure.Type;
						if ((type == Sensor.Sensor_Type.MineSweep_MechanicalCableCutter || type == Sensor.Sensor_Type.MineNeutralization_MooredMineCableCutter) && unguidedWeapon_0.Type != Weapon._WeaponType.MooredMine)
						{
							_ = unguidedWeapon_0.Type;
						}
					}
				}
			}
			GeoPoint geoPoint = new GeoPoint();
			if ((double)float_0 <= 0.6)
			{
				if (m_EventVal.Navigator.HasPlottedCourse())
				{
					if ((float)((double)Math2.VerifyClass(m_EventVal.Navigator.PlottedCourse[0].Latitude, m_EventVal.Navigator.PlottedCourse[0].Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude()) + 0.1) > float_0)
					{
						double longitude = m_EventVal.GetLongitude();
						double latitude = m_EventVal.GetLatitude();
						GeoPoint geoPoint2;
						double double_ = (geoPoint2 = geoPoint).Longitude;
						GeoPoint geoPoint3;
						double double_2 = (geoPoint3 = geoPoint).Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, float_0 / 2f, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unguidedWeapon_0.GetLatitude(), unguidedWeapon_0.GetLongitude()));
						geoPoint3.Latitude = double_2;
						geoPoint2.Longitude = double_;
						m_EventVal.Navigator.PlottedCourse[0].Latitude = geoPoint.Latitude;
						m_EventVal.Navigator.PlottedCourse[0].Longitude = geoPoint.Longitude;
					}
				}
				else
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unguidedWeapon_0.GetLatitude(), unguidedWeapon_0.GetLongitude()));
				}
			}
			else
			{
				double longitude2 = m_EventVal.GetLongitude();
				double latitude2 = m_EventVal.GetLatitude();
				GeoPoint geoPoint4;
				double double_3 = (geoPoint4 = geoPoint).Longitude;
				GeoPoint geoPoint5;
				double double_4 = (geoPoint5 = geoPoint).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_3, ref double_4, float_0 / 2f, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unguidedWeapon_0.GetLatitude(), unguidedWeapon_0.GetLongitude()));
				geoPoint5.Latitude = double_4;
				geoPoint4.Longitude = double_3;
				if (m_EventVal.Navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.PlottedCourse[0].Latitude = geoPoint.Latitude;
					m_EventVal.Navigator.PlottedCourse[0].Longitude = geoPoint.Longitude;
				}
				else
				{
					m_EventVal.Navigator.AddWaypoint(new Waypoint(geoPoint.Longitude, geoPoint.Latitude, geoPoint.Altitude, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				}
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unguidedWeapon_0.GetLatitude(), unguidedWeapon_0.GetLongitude()));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100065", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected internal void ManouverToSweepMine(UnguidedWeapon unguidedWeapon_0, float float_0, bool bool_0 = false)
	{
		try
		{
			if (m_EventVal.MineCountermeasures.Count == 0)
			{
				return;
			}
			if (!bool_0 && (double)float_0 < 0.5 && m_EventVal.Navigator.HasPlottedCourse())
			{
				float num = (float)((double)Math2.VerifyClass(m_EventVal.Navigator.PlottedCourse[0].Latitude, m_EventVal.Navigator.PlottedCourse[0].Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude()) + 0.1);
				if (m_EventVal.IsAircraft || (double)num - 0.3 <= (double)float_0)
				{
					return;
				}
			}
			Sensor sensor = null;
			foreach (Sensor mineCountermeasure in m_EventVal.MineCountermeasures)
			{
				if (mineCountermeasure.IsActive && (mineCountermeasure.GetCanSweepThisMine(unguidedWeapon_0) || mineCountermeasure.GetCanTriggerThisMine(unguidedWeapon_0)))
				{
					sensor = mineCountermeasure;
					break;
				}
			}
			if (sensor != null && sensor.MineSweepCoverageArea != null)
			{
				Geopoint_Struct geopoint_Struct = Misc.Center(sensor.MineSweepCoverageArea);
				float num2;
				if (m_EventVal.IsAircraft)
				{
					num2 = GameGeneral.LockRandom_0.Next(0, 5);
				}
				else
				{
					num2 = Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, Math2.PublishClass(geopoint_Struct.Latitude, geopoint_Struct.Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude())));
					num2 += (float)((sensor.MineSweepCoverageArea.Length - 1) * 5);
				}
				float num3 = (float)((double)Math2.VerifyClass(geopoint_Struct.Latitude, geopoint_Struct.Longitude, m_EventVal.GetLatitude(), m_EventVal.GetLongitude()) + 0.15);
				if (m_EventVal.IsAircraft)
				{
					num3 *= 4f;
				}
				GeoPoint geoPoint = new GeoPoint();
				double longitude = unguidedWeapon_0.GetLongitude();
				double latitude = unguidedWeapon_0.GetLatitude();
				GeoPoint geoPoint2;
				double double_ = (geoPoint2 = geoPoint).Longitude;
				GeoPoint geoPoint3;
				double double_2 = (geoPoint3 = geoPoint).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, num3, Math2.UpdateClass(num2 + Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), unguidedWeapon_0.GetLatitude(), unguidedWeapon_0.GetLongitude())));
				geoPoint3.Latitude = double_2;
				geoPoint2.Longitude = double_;
				bool bool_ = false;
				bool bool_2 = false;
				if (m_EventVal.IsShip || m_EventVal.IsSubmarine)
				{
					ActiveUnit eventVal = m_EventVal;
					double longitude2 = geoPoint.Longitude;
					double latitude2 = geoPoint.Latitude;
					int int_ = 0;
					float? nullable_ = 0f;
					List<ActiveUnit> list_ = null;
					string string_ = "";
					bool bool_3 = false;
					if (eventVal.CanMoveToThisLocation(longitude2, latitude2, ref int_, bool_0: false, bool_1: true, bool_2: true, ref bool_, bool_4: true, ref bool_2, nullable_, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3) && (bool_2 || bool_))
					{
						return;
					}
				}
				if (m_EventVal.Navigator.HasPlottedCourse())
				{
					if (m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
					{
						m_EventVal.Navigator.PlottedCourse[0].Longitude = geoPoint.Longitude;
						m_EventVal.Navigator.PlottedCourse[0].Latitude = geoPoint.Latitude;
						m_EventVal.Navigator.PlottedCourse[0].Description = "Mine clearing endpoint";
					}
					else
					{
						m_EventVal.Navigator.AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						m_EventVal.Navigator.PlottedCourse[0].Description = "Mine clearing endpoint";
					}
				}
				else
				{
					m_EventVal.Navigator.AddWaypoint(new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				}
			}
			else if (!m_EventVal.Navigator.HasPlottedCourse() && !Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
			{
				if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
				{
					m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
				}
				m_EventVal.Navigator.PlotCourseToStationArea(1f, bool_1: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100066", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool MustSlowDownToAllowGroupFormUp()
	{
		try
		{
			if (m_EventVal == null)
			{
				return false;
			}
			if (m_EventVal.IsGroupLead())
			{
				if (m_EventVal.GetParentGroup().Kinematics.LeadAllowedToSlowDown)
				{
					if (m_EventVal.GetParentGroup().Type != Group.GroupType.SurfaceGroup && m_EventVal.GetParentGroup().Type != 0 && m_EventVal.GetParentGroup().Type != Group.GroupType.MobileGroup)
					{
						return false;
					}
					List<ActiveUnit> list = new List<ActiveUnit>();
					foreach (ActiveUnit value in m_EventVal.GetParentGroup().Units.Values)
					{
						if (value != m_EventVal && value.IsOperating() && (object)value.GetType() == m_EventVal.GetType())
						{
							list.Add(value);
						}
					}
					int num = list.Count - 1;
					while (true)
					{
						if (num >= 0)
						{
							ActiveUnit activeUnit = list[num];
							if (!activeUnit.Navigator.SprintDrift && !activeUnit.Navigator.HaveReachedFormationStation())
							{
								break;
							}
							num += -1;
							continue;
						}
						return false;
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
			exception_?.Data.Add("Error at 200356", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		try
		{
			m_EventVal.Navigator.m_ErrorWrapper = false;
			if (m_EventVal.IsSatellite)
			{
				return;
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(float_0, WeaponThreat);
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive && (m_EventVal.IsAircraft || m_EventVal.IsShip || m_EventVal.IsSubmarine))
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				ManouverAgainstPrimaryThreat(float_0);
				return;
			}
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				byte? b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
					return;
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
			{
				m_EventVal.DesiredSpeed = 0f;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				return;
			}
			if (m_EventVal.IsRTB)
			{
				if (((Aircraft)m_EventVal).Navigator.HasReachedLandingAssemblyPoint(((Aircraft)m_EventVal).AirOps.GetAssignedHostUnit(bool_0: true)))
				{
					if (!((Aircraft)m_EventVal).AirOps.GetAssignedHostUnit(bool_0: true).AirOps.LandingQueue_ReadOnly.Contains((Aircraft)m_EventVal))
					{
						((Aircraft)m_EventVal).AirOps.GetAssignedHostUnit(bool_0: true).AirOps.LandingQueue_AddAircraft((Aircraft)m_EventVal);
					}
					((Aircraft)m_EventVal).Kinematics.Loiter(float_0);
				}
				else
				{
					Aircraft_Navigator navigator = ((Aircraft)m_EventVal).Navigator;
					ActiveUnit assignedHostUnit = ((Aircraft)m_EventVal).AirOps.GetAssignedHostUnit(bool_0: true);
					float float_ = m_EventVal.Kinematics.GetMaximumSpeed(((Aircraft)m_EventVal).GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false);
					Aircraft_Navigator navigator2 = ((Aircraft)m_EventVal).Navigator;
					ActiveUnit eventVal = m_EventVal;
					ActiveUnit eventVal2;
					bool bool_ = eventVal.GetDesiredAltitude_UseTerrainFollowing(eventVal2 = m_EventVal);
					float float_2 = navigator2.OrderProxy(ref bool_);
					eventVal.SetDesiredAltitude_UseTerrainFollowing(eventVal2, bool_);
					ActiveUnit eventVal3 = m_EventVal;
					ActiveUnit eventVal4;
					bool bool_2 = eventVal3.GetDesiredAltitude_UseTerrainFollowing(eventVal4 = m_EventVal);
					navigator.HeadToLandingAssemblyPoint(float_0, assignedHostUnit, float_, float_2, ref bool_2);
					eventVal3.SetDesiredAltitude_UseTerrainFollowing(eventVal4, bool_2);
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				if (Information.IsNothing(PrimaryTarget))
				{
					return;
				}
				if ((int)PrimaryTarget.Type <= 1)
				{
					m_EventVal.DesiredSpeed = 0f;
					return;
				}
				if ((int)m_EventVal.ThrottleSetting < 3)
				{
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
				}
				ManouverTowardsTarget(float_0);
				Weapon weapon_ = null;
				OptimizeAltSpeedForNextEngagement(float_0, ref weapon_);
				return;
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
			{
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				if (m_EventVal.IsGroupLead())
				{
					m_EventVal.DesiredSpeed = m_EventVal.GetParentGroup().DesiredSpeed;
				}
				return;
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.OnPatrol)
			{
				Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
				if (!Information.IsNothing(patrol))
				{
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
						else
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
					return;
				}
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				if (m_EventVal.IsSubmarine && !m_EventVal.Kinematics.DesiredAltitudeOverride)
				{
					if (m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2f, bool_1: false))
					{
						if (patrol.TransitDepth_Submarine.Value < 0f)
						{
							m_EventVal.DesiredAltitude = patrol.TransitDepth_Submarine.Value;
						}
					}
					else if (patrol.StationDepth_Submarine.Value < 0f)
					{
						m_EventVal.DesiredAltitude = patrol.StationDepth_Submarine.Value;
					}
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.OnSupportMission)
			{
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else
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
			}
			if (m_EventVal.IsGroupMember() && m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
			}
			else if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				m_EventVal.DesiredSpeed = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100068", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float DisableClient(AircraftAltitudePreset aircraftAltitudePreset_0)
	{
		if (m_EventVal != null)
		{
			if (1 == 0)
			{
			}
			float result = aircraftAltitudePreset_0 switch
			{
				AircraftAltitudePreset.MinAltitude => 6.096f, 
				AircraftAltitudePreset.Low1000 => 304.8f, 
				AircraftAltitudePreset.Low2000 => 609.6f, 
				AircraftAltitudePreset.const_4 => 3657.6f, 
				AircraftAltitudePreset.const_5 => 7620f, 
				AircraftAltitudePreset.const_6 => 10972.8f, 
				AircraftAltitudePreset.MaxAltitude => 200000f, 
				_ => 0f, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		return 0f;
	}

	public virtual void FollowAltitudePreset()
	{
		if (m_EventVal == null || !m_EventVal.Kinematics.DesiredAltitudeOverride)
		{
			return;
		}
		switch (((Aircraft)m_EventVal).AI.AltitudePreset)
		{
		case AircraftAltitudePreset.MinAltitude:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = 6.096f;
			}
			else
			{
				m_EventVal.DesiredAltitude = m_EventVal.Kinematics.GetMinimumAltitude();
			}
			break;
		case AircraftAltitudePreset.Low1000:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = 304.8f;
			}
			else
			{
				m_EventVal.DesiredAltitude = 304.8f;
			}
			break;
		case AircraftAltitudePreset.Low2000:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = 609.6f;
			}
			else
			{
				m_EventVal.DesiredAltitude = 609.6f;
			}
			break;
		case AircraftAltitudePreset.const_4:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = 3657.6f;
			}
			else
			{
				m_EventVal.DesiredAltitude = 3657.6f;
			}
			break;
		case AircraftAltitudePreset.const_5:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = 7620f;
			}
			else
			{
				m_EventVal.DesiredAltitude = 7620f;
			}
			break;
		case AircraftAltitudePreset.const_6:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = 10972.8f;
			}
			else
			{
				m_EventVal.DesiredAltitude = 10972.8f;
			}
			break;
		case AircraftAltitudePreset.MaxAltitude:
			if (m_EventVal.GetDesiredAltitude_UseTerrainFollowing(m_EventVal))
			{
				m_EventVal.DesiredAltitude_AGL = m_EventVal.Kinematics.GetMaximumAltitude();
			}
			else
			{
				m_EventVal.DesiredAltitude = m_EventVal.Kinematics.GetMaximumAltitude();
			}
			break;
		case AircraftAltitudePreset.None:
			break;
		}
	}

	internal bool UpdateClient(WithdrawReason withdrawReason_0, string string_0)
	{
		try
		{
			switch (withdrawReason_0)
			{
			case WithdrawReason.HighDamage:
				if (m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true))
				{
					m_EventVal.AddMessage(m_EventVal.Name + "退出（原因：" + string_0 + "). ", "单元撤退", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
					return true;
				}
				goto default;
			default:
				return false;
			case WithdrawReason.LowFuel:
			{
				bool flag2 = false;
				if (m_EventVal.DockingOps.IncludeDic(m_EventVal.AI.LoginClient(), null, null, bool_0: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					flag2 = true;
				}
				else if (m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true))
				{
					flag2 = true;
				}
				if (flag2)
				{
					m_EventVal.AddMessage(m_EventVal.Name + "退出（原因：" + string_0 + "). ", "单元撤退", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				return flag2;
			}
			case WithdrawReason.LowAttackAmmo:
			case WithdrawReason.LowDefenceAmmo:
			{
				bool flag = false;
				ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps;
				string string_ = null;
				List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(bool_0: true, null, ref string_, ActiveUnit_DockingOps.ResupplyRequest.Material);
				if (potentialUNREPunits.Count <= 0)
				{
					if (m_EventVal.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true))
					{
						flag = true;
					}
				}
				else
				{
					Weapon weapon = ((withdrawReason_0 == WithdrawReason.LowAttackAmmo) ? ((m_EventVal.Weaponry.PrimaryAttackWeapon_Actual == null) ? m_EventVal.Weaponry.PrimaryAttackWeapon_Default : m_EventVal.Weaponry.PrimaryAttackWeapon_Actual) : ((m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual == null) ? m_EventVal.Weaponry.PrimaryDefenceWeapon_Default : m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual));
					if (weapon != null)
					{
						foreach (ActiveUnit item in potentialUNREPunits)
						{
							if (item.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, bool_1: false) > 0 && m_EventVal.DockingOps.IncludeDic(m_EventVal.AI.LoginClient(), item, null, bool_0: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
							{
								m_EventVal.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
								flag = true;
								break;
							}
						}
					}
				}
				if (flag)
				{
					m_EventVal.AddMessage(m_EventVal.Name + "退出（原因：" + string_0 + "). ", "单元撤退", LoggedMessage.MessageType.DockingOps, 0, bool_0: false, new Geopoint_Struct(m_EventVal.GetLongitude(), m_EventVal.GetLatitude()));
				}
				return flag;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101358", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool InsertClient()
	{
		try
		{
			Doctrine._DamageThreshold? withdrawDamageThreshold = m_EventVal.Doctrine.GetWithdrawDamageThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			short? num = (short?)withdrawDamageThreshold;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num = (short?)withdrawDamageThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					if (m_EventVal.Damage.DamagePercent >= 5f)
					{
						return UpdateClient(WithdrawReason.HighDamage, "毁伤现在超过5％");
					}
				}
				else
				{
					num = (short?)withdrawDamageThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						if (m_EventVal.Damage.DamagePercent >= 25f)
						{
							return UpdateClient(WithdrawReason.HighDamage, "毁伤现在超过25％");
						}
					}
					else
					{
						num = (short?)withdrawDamageThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							if (m_EventVal.Damage.DamagePercent >= 50f)
							{
								return UpdateClient(WithdrawReason.HighDamage, "现在毁伤超过50％");
							}
						}
						else
						{
							num = (short?)withdrawDamageThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault() && m_EventVal.Damage.DamagePercent >= 75f)
							{
								return UpdateClient(WithdrawReason.HighDamage, "毁伤现在超过75％");
							}
						}
					}
				}
			}
			Doctrine._FuelQuantityThreshold? withdrawFuelThreshold = m_EventVal.Doctrine.GetWithdrawFuelThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawFuelThreshold;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num = (short?)withdrawFuelThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					ActiveUnit._ActiveUnitFuelState isBingoOrJoker = m_EventVal.GetIsBingoOrJoker(null, null);
					if (isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						m_EventVal.FuelState = isBingoOrJoker;
						return UpdateClient(WithdrawReason.LowFuel, "现在Bingo的燃料水平");
					}
				}
				else
				{
					num = (short?)withdrawFuelThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						double double_ = 0.0;
						double double_2 = 0.0;
						if ((int)Math.Round(m_EventVal.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0) < 25)
						{
							return UpdateClient(WithdrawReason.LowFuel, "燃油水平现在低于25％");
						}
					}
					else
					{
						num = (short?)withdrawFuelThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							double double_3 = 0.0;
							double double_4 = 0.0;
							if ((int)Math.Round(m_EventVal.FuelPercent(ref double_3, ref double_4, bool_0: false) * 100.0) < 50)
							{
								return UpdateClient(WithdrawReason.LowFuel, "燃油水平现在低于50％");
							}
						}
						else
						{
							num = (short?)withdrawFuelThreshold;
							double double_5 = 0.0;
							double double_6 = 0.0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault() && (int)Math.Round(m_EventVal.FuelPercent(ref double_5, ref double_6, bool_0: false) * 100.0) < 75)
							{
								return UpdateClient(WithdrawReason.LowFuel, "燃油水平现在低于75％");
							}
						}
					}
				}
			}
			Doctrine._WeaponQuantityThreshold? withdrawAttackThreshold = m_EventVal.Doctrine.GetWithdrawAttackThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawAttackThreshold;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num = (short?)withdrawAttackThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					Weapon primaryAttackWeapon_Default = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
					if (!Information.IsNothing(primaryAttackWeapon_Default) && m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default.DBID, bool_1: false) == 0)
					{
						return UpdateClient(WithdrawReason.LowAttackAmmo, "主要攻击武器（" + primaryAttackWeapon_Default.Name + "）现在耗尽了");
					}
				}
				else
				{
					num = (short?)withdrawAttackThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						Weapon primaryAttackWeapon_Default2 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
						if (!Information.IsNothing(primaryAttackWeapon_Default2))
						{
							int num6 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default2.DBID, bool_1: false);
							int num7 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default2.DBID);
							if (num6 == 0 || (double)num6 / (double)num7 < 0.25)
							{
								return UpdateClient(WithdrawReason.LowAttackAmmo, "主要攻击武器（" + primaryAttackWeapon_Default2.Name + "）现在低于25％");
							}
						}
					}
					else
					{
						num = (short?)withdrawAttackThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							Weapon primaryAttackWeapon_Default3 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
							if (!Information.IsNothing(primaryAttackWeapon_Default3))
							{
								int num8 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default3.DBID, bool_1: false);
								int num9 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default3.DBID);
								if (num8 == 0 || (double)num8 / (double)num9 < 0.5)
								{
									return UpdateClient(WithdrawReason.LowAttackAmmo, "主要攻击武器（" + primaryAttackWeapon_Default3.Name + "）现在低于50％");
								}
							}
						}
						else
						{
							num = (short?)withdrawAttackThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								Weapon primaryAttackWeapon_Default4 = m_EventVal.Weaponry.PrimaryAttackWeapon_Default;
								if (!Information.IsNothing(primaryAttackWeapon_Default4))
								{
									int num10 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default4.DBID, bool_1: false);
									int num11 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default4.DBID);
									if (num10 == 0 || (double)num10 / (double)num11 < 0.75)
									{
										return UpdateClient(WithdrawReason.LowAttackAmmo, "主要攻击武器（" + primaryAttackWeapon_Default4.Name + "）现在低于75％");
									}
								}
							}
						}
					}
				}
			}
			Doctrine._WeaponQuantityThreshold? withdrawDefenceThreshold = m_EventVal.Doctrine.GetWithdrawDefenceThreshold(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawDefenceThreshold;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num = (short?)withdrawDefenceThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					Weapon primaryDefenceWeapon_Actual = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
					if (!Information.IsNothing(primaryDefenceWeapon_Actual) && m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual.DBID, bool_1: false) == 0)
					{
						return UpdateClient(WithdrawReason.LowDefenceAmmo, "主要防御武器（" + primaryDefenceWeapon_Actual.Name + "）现在耗尽了");
					}
				}
				else
				{
					num = (short?)withdrawDefenceThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						Weapon primaryDefenceWeapon_Actual2 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
						if (!Information.IsNothing(primaryDefenceWeapon_Actual2))
						{
							int num12 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual2.DBID, bool_1: false);
							int num13 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual2.DBID);
							if (num12 == 0 || (double)num12 / (double)num13 < 0.25)
							{
								return UpdateClient(WithdrawReason.LowDefenceAmmo, "主要防御武器（" + primaryDefenceWeapon_Actual2.Name + "）现在低于25％");
							}
						}
					}
					else
					{
						num = (short?)withdrawDefenceThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							Weapon primaryDefenceWeapon_Actual3 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
							if (!Information.IsNothing(primaryDefenceWeapon_Actual3))
							{
								int num2 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual3.DBID, bool_1: false);
								int num3 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual3.DBID);
								if (num2 == 0 || (double)num2 / (double)num3 < 0.5)
								{
									return UpdateClient(WithdrawReason.LowDefenceAmmo, "主要防御武器（" + primaryDefenceWeapon_Actual3.Name + "）现在低于50％");
								}
							}
						}
						else
						{
							num = (short?)withdrawDefenceThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								Weapon primaryDefenceWeapon_Actual4 = m_EventVal.Weaponry.PrimaryDefenceWeapon_Actual;
								if (!Information.IsNothing(primaryDefenceWeapon_Actual4))
								{
									int num4 = m_EventVal.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual4.DBID, bool_1: false);
									int num5 = m_EventVal.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual4.DBID);
									if (num4 == 0 || (double)num4 / (double)num5 < 0.75)
									{
										return UpdateClient(WithdrawReason.LowDefenceAmmo, "主要防御武器（" + primaryDefenceWeapon_Actual4.Name + "）现在低于75％");
									}
								}
							}
						}
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101359", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal float PrepareClient(bool bool_0, SubmarineDepthPreset submarineDepthPreset_0)
	{
		if (m_EventVal == null)
		{
			return 0f;
		}
		Submarine_AI aI = ((Submarine)m_EventVal).AI;
		float num = 0f;
		switch (submarineDepthPreset_0)
		{
		case SubmarineDepthPreset.None:
			return 0f;
		case SubmarineDepthPreset.Periscope:
			num = -20f;
			break;
		case SubmarineDepthPreset.Shallow:
			num = -40f;
			break;
		case SubmarineDepthPreset.OverLayer:
			num = Submarine_AI.OverLayerDepth(m_EventVal);
			break;
		case SubmarineDepthPreset.UnderLayer:
			num = Submarine_AI.UnderLayerDepth(m_EventVal);
			break;
		case SubmarineDepthPreset.MaxDepth:
			num = m_EventVal.Kinematics.GetMinimumAltitude();
			break;
		case SubmarineDepthPreset.Surface:
			num = 0f;
			break;
		}
		if (bool_0)
		{
			if (Math.Round(num) >= -20.0 && !aI.ResolveSpecification(m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive, null, -1.0, -1.0))
			{
				num = -40f;
			}
			return 0f;
		}
		return num;
	}

	public virtual void FollowDepthPreset(bool bool_0)
	{
		try
		{
			if (m_EventVal == null || !m_EventVal.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			Submarine_AI aI = ((Submarine)m_EventVal).AI;
			float num = 0f;
			switch (aI.DepthPreset)
			{
			case SubmarineDepthPreset.None:
				return;
			case SubmarineDepthPreset.Periscope:
				num = -20f;
				break;
			case SubmarineDepthPreset.Shallow:
				num = -40f;
				break;
			case SubmarineDepthPreset.OverLayer:
				num = Submarine_AI.OverLayerDepth(m_EventVal);
				break;
			case SubmarineDepthPreset.UnderLayer:
				num = Submarine_AI.UnderLayerDepth(m_EventVal);
				break;
			case SubmarineDepthPreset.MaxDepth:
				num = m_EventVal.Kinematics.GetMinimumAltitude();
				break;
			case SubmarineDepthPreset.Surface:
				num = 0f;
				break;
			}
			if (bool_0)
			{
				if (!(Math.Round(num) < -20.0) && !aI.ResolveSpecification(m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive, null, -1.0, -1.0))
				{
					m_EventVal.DesiredAltitude = -40f;
				}
				else
				{
					m_EventVal.DesiredAltitude = num;
				}
			}
			else
			{
				m_EventVal.DesiredAltitude = num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101360", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectClient(object sender, NotifyDictionaryChangedEventArgs<string, TargetingEntry> e)
	{
		_AuthenticationVal = null;
	}

	public static void ExportTargetingChangeEvent(string string_0, Contact contact_0, ActiveUnit activeUnit_0, Side side_0, Scenario scenario_0, string string_1)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
			{
				if (applicableEventExporter.IsOperating && applicableEventExporter.ExportEngagementCycle)
				{
					Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
					if (scenario_0.MonteCarloIteration > 0)
					{
						dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(scenario_0.Title, typeof(string), 500));
						dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(scenario_0.MonteCarloIteration, typeof(int)));
					}
					dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(scenario_0.TimelineID, typeof(string), 40));
					if (applicableEventExporter.UseZeroHour)
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.Subtract(scenario_0.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					else
					{
						dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					if (activeUnit_0 == null)
					{
						dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 40));
						dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
						dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(activeUnit_0.ObjectID, typeof(string), 40));
						dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(activeUnit_0.Name, typeof(string), 500));
						dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(activeUnit_0.UnitClass, typeof(string), 500));
					}
					if (side_0 == null)
					{
						dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(side_0.Name, typeof(string), 500));
					}
					dictionary.Add("CycleAction", new IEventExporter.EventNotificationParameter(string_0, typeof(string), 200));
					dictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(contact_0.ObjectID, typeof(string), 40));
					dictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(contact_0.Name, typeof(string), 500));
					dictionary.Add("ContactLongitude", new IEventExporter.EventNotificationParameter(contact_0.GetLongitude().ToString(), typeof(double)));
					dictionary.Add("ContactLatitude", new IEventExporter.EventNotificationParameter(contact_0.GetLatitude().ToString(), typeof(double)));
					if (activeUnit_0 == null)
					{
						dictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
						dictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
					}
					else
					{
						dictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Horiz(activeUnit_0, contact_0), typeof(float)));
						dictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Slant(activeUnit_0, contact_0), typeof(float)));
					}
					if (contact_0.ActualUnit != null)
					{
						dictionary.Add("ContactActualUnitID", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.ObjectID, typeof(string), 40));
						dictionary.Add("ContactActualUnitName", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.Name, typeof(string), 500));
						dictionary.Add("ContactActualUnitClass", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.UnitClass, typeof(string), 500));
						dictionary.Add("ContactActualUnitSide", new IEventExporter.EventNotificationParameter(contact_0.ActualUnit.GetUnitSide().Name, typeof(string), 500));
					}
					dictionary.Add("SalvoID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(string_1, typeof(string)));
					applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.EngagementCycle, dictionary, scenario_0);
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
	}

	internal float VisitClient(ref double double_0, ref double double_1)
	{
		try
		{
			Aircraft aircraft = (Aircraft)m_EventVal;
			float num = Terrain.GetElevation(double_0, double_1, bool_0: false, m_EventVal.ParentScen);
			num = ((num <= 0f) ? 0f : ((float)(Math.Round(num * 3.28084f / 1000f, 0) * 1000.0 / 3.2808399200439453)));
			if (!Information.IsNothing(aircraft.Loadout) && !Information.IsNothing(aircraft.Loadout.GetMissionProfile(aircraft.ParentScen).FormUpAltitude) && aircraft.Loadout.GetMissionProfile(aircraft.ParentScen).FormUpAltitude > 0f)
			{
				return aircraft.Loadout.GetMissionProfile(aircraft.ParentScen).FormUpAltitude + num;
			}
			return 609.6f + num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101361", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 609.6f;
		}
	}

	public virtual void ReturnToBase(float float_0)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			m_EventVal.IsExhausted();
			if (m_EventVal.AssignedMissionOrPackage() != null && m_EventVal.AssignedMissionOrPackage().SecondaryNavalBase != null)
			{
				m_EventVal.DockingOps.SetAssignedHostUnit(bool_0: false, m_EventVal.AssignedMissionOrPackage().SecondaryNavalBase);
			}
			ActiveUnit actualDestinationHost = m_EventVal.DockingOps.ActualDestinationHost;
			if (!Information.IsNothing(actualDestinationHost) && !actualDestinationHost.IsDestroyed)
			{
				ActiveUnit_DockingOps dockingOps = actualDestinationHost.DockingOps;
				ActiveUnit eventVal = m_EventVal;
				DockFacility dockFacility_ = null;
				if (dockingOps.CanHostThisBoat(eventVal, ref dockFacility_))
				{
					goto IL_00e6;
				}
			}
			m_EventVal.DockingOps.PickNewAssignedHost_RandomWithinRange();
			actualDestinationHost = m_EventVal.DockingOps.ActualDestinationHost;
			goto IL_00e6;
			IL_00e6:
			if (Information.IsNothing(actualDestinationHost))
			{
				if (m_EventVal.Navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				return;
			}
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, actualDestinationHost);
			if (m_EventVal.CurrentSpeed == 0f && num < 1f && m_EventVal.FuelCapacityCurrent == 0)
			{
				m_EventVal.DockingOps.AttemptToStartDocking(actualDestinationHost);
				return;
			}
			if (num * 1852f < 100f)
			{
				m_EventVal.DockingOps.AttemptToStartDocking(actualDestinationHost);
				return;
			}
			if (m_EventVal.Navigator.HasPathfindingPlottedCourse)
			{
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
			}
			else
			{
				m_EventVal.Navigator.ClearPlottedCourse();
				if (m_EventVal.IsShip)
				{
					m_EventVal.Navigator.bool_0 = true;
				}
				m_EventVal.Navigator.AddWaypoint(new Waypoint(actualDestinationHost.GetLongitude(), actualDestinationHost.GetLatitude(), 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
			}
			m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100819", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool ManouverForSpace(DateTime? nullable_0, ref Waypoint waypoint_0, bool bool_0)
	{
		return false;
	}

	public virtual bool ManouverRaceTrack(ref Scenario scenario_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1)
	{
		return false;
	}

	public bool PerformTerrainFollowingIfNecessary()
	{
		if (m_EventVal.CurrentAltitude_AGL < 1000f && (m_EventVal.DesiredAltitude_AGL != 0f || m_EventVal.DesiredAltitude < 3000f))
		{
			float value = ((IFlier)m_EventVal).MinimumSafeHeight.Value;
			m_InstanceWrapper.Clear();
			float num = 0.2f;
			double double_ = 0.0;
			double double_2 = 0.0;
			(double, double, float, short) item = default((double, double, float, short));
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(m_EventVal.GetLongitude(), m_EventVal.GetLatitude(), ref double_, ref double_2, num, m_EventVal.CurrentHeading);
				short elevation = Terrain.GetElevation(double_2, double_, bool_0: false, m_EventVal.ParentScen);
				item.Item1 = double_2;
				item.Item2 = double_;
				item.Item3 = num;
				item.Item4 = elevation;
				if ((float)elevation > m_EventVal.GetCurrentAltitude())
				{
					m_InstanceWrapper.Add(item);
				}
				num += 0.2f;
			}
			while (num <= 2f);
			if (m_InstanceWrapper.Count <= 0)
			{
				return false;
			}
			(double, double, float, short) tuple = m_InstanceWrapper.OrderByDescending<(double, double, float, short), double>(((double theLat, double theLon, float theDistance, short theElev) valueTuple_0) => Math.Atan2(Math.Abs((float)valueTuple_0.theElev - m_EventVal.GetCurrentAltitude()), (double)valueTuple_0.theDistance * 1852.0) * 57.2957795130823).ElementAtOrDefault(0);
			if ((float)tuple.Item4 + value <= m_EventVal.GetCurrentAltitude())
			{
				CalculateDesiredPitch(tuple.Item1, tuple.Item2, m_EventVal.DesiredAltitude);
				CalculatedDesiredPitchThisPulse = true;
			}
			else
			{
				CalculateDesiredPitch(tuple.Item1, tuple.Item2, (float)tuple.Item4 + value);
				CalculatedDesiredPitchThisPulse = true;
			}
			return true;
		}
		return false;
	}

	public void CalculateDesiredPitch(double double_0, double double_1, double double_2)
	{
		if (!m_EventVal.SupportsAttitude_Pitch)
		{
			return;
		}
		if (m_EventVal.IsPalletWeapon)
		{
			m_EventVal.DesiredPitch = -85f;
			return;
		}
		double num = Math.Atan2((double)m_EventVal.GetCurrentAltitude() - double_2, (double)Module_Unit.RangeToPoint_Horiz(m_EventVal, double_0, double_1) * 1852.0) * 57.2957795130823;
		if (num > 0.0 && (double)m_EventVal.GetCurrentAltitude() > double_2)
		{
			num = 0.0 - num;
		}
		if (num < 0.0 && (double)m_EventVal.GetCurrentAltitude() < double_2)
		{
			num = 0.0 - num;
		}
		m_EventVal.DesiredPitch = (float)num;
	}

	public virtual void ManoueverTorpedoEvasion(float float_0, Contact contact_0)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	protected virtual void ExecuteManeuver(PersistentManeuver persistentManeuver_0)
	{
		if (persistentManeuver_0 == null)
		{
			return;
		}
		m_EventVal.SetThrottle(persistentManeuver_0.DesiredThrottle);
		if (m_EventVal.CurrentHeading != persistentManeuver_0.DesiredHeading)
		{
			float num = m_EventVal.Kinematics.TurnRate();
			float float_ = persistentManeuver_0.DesiredHeading;
			PersistentManeuver.TurnDirection turnDirection = persistentManeuver_0.Direction;
			if (turnDirection == PersistentManeuver.TurnDirection.Nearest)
			{
				turnDirection = PersistentManeuver.TurnDirection.Right;
				float num2 = persistentManeuver_0.DesiredHeading - m_EventVal.CurrentHeading;
				if (num2 > 180f || (num2 < 0f && num2 > -180f))
				{
					turnDirection = PersistentManeuver.TurnDirection.Left;
				}
			}
			float num3 = MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, persistentManeuver_0.DesiredHeading);
			if (turnDirection == PersistentManeuver.TurnDirection.Left)
			{
				if (num3 > 0f || 0f - num3 > num)
				{
					float_ = Math2.UpdateClass(m_EventVal.CurrentHeading - num);
				}
			}
			else if (num3 < 0f || num3 > num)
			{
				float_ = Math2.UpdateClass(m_EventVal.CurrentHeading + num);
			}
			m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_);
		}
		if (m_EventVal.IsSubmarine || m_EventVal.IsAircraft)
		{
			m_EventVal.DesiredAltitude = persistentManeuver_0.DesiredAltitude;
		}
	}

	[CompilerGenerated]
	private float RestartClient(ActiveUnit activeUnit_0)
	{
		return Module_Unit.RangeToUnit_Horiz(m_EventVal, activeUnit_0);
	}

	[CompilerGenerated]
	private float TestClient(ActiveUnit activeUnit_0)
	{
		return Module_Unit.RangeToUnit_Horiz(activeUnit_0, m_EventVal);
	}

	[CompilerGenerated]
	private bool StopClient(Contact contact_0)
	{
		ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
		Doctrine doctrine = m_EventVal.Doctrine;
		string string_ = "";
		int int_ = 0;
		if (weaponry.PopConsumer(contact_0, bool_1: true, doctrine, ref string_, ref int_))
		{
			return ContactIsThreatToMissionUnits(contact_0);
		}
		return false;
	}

	[CompilerGenerated]
	private float CancelClient(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private int VerifyClient(Contact contact_0)
	{
		return m_EventVal.GetUnitSide().processProxy[contact_0.ObjectID];
	}

	[CompilerGenerated]
	private float ListClient(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private float ResolveClient(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private float PostClient(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private void RunClient(Contact contact_0)
	{
		int count = Module_Contact.PostTokenizer(contact_0, m_EventVal.GetUnitSide(), bool_0: true, m_EventVal, bool_1: false).Count;
		_RuleWrapper[contact_0] = count;
	}

	[CompilerGenerated]
	private float StartClient(TargetingEntry targetingEntry_0)
	{
		return Module_Unit.RangeToUnit_Horiz(m_EventVal, targetingEntry_0.Target);
	}

	[CompilerGenerated]
	private double AssetClient((double theLat, double theLon, float theDistance, short theElev) valueTuple_0)
	{
		return Math.Atan2(Math.Abs((float)valueTuple_0.theElev - m_EventVal.GetCurrentAltitude()), (double)valueTuple_0.theDistance * 1852.0) * 57.2957795130823;
	}
}
