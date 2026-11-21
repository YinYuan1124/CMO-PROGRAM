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

public sealed class Submarine_AI : ActiveUnit_AI
{
	[CompilerGenerated]
	private sealed class ParamsItem
	{
		public ObservableDictionary<string, UnguidedWeapon> Local_WeaponsDic;

		public List<ReferencePoint> Local_MissionArea;

		public Submarine_AI Me;

		public TList<UnguidedWeapon> Local_LegitTargets;

		public MineClearingMission Local_myMission;

		internal void MoveInterruptibleParam(string theUW_ObjectID)
		{
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

	[CompilerGenerated]
	private sealed class ErrorObjectListener
	{
		public ObservableDictionary<string, UnguidedWeapon> Local_WeaponsDic0;

		public List<ReferencePoint> Local_MissionArea0;

		public Submarine_AI Me0;

		public TList<UnguidedWeapon> Local_LegitTargets0;

		internal void DeleteInterruptibleParam(string theUW_ObjectID)
		{
			UnguidedWeapon unguidedWeapon = null;
			Local_WeaponsDic0.TryGetValue(theUW_ObjectID, ref unguidedWeapon);
			if (!Information.IsNothing(unguidedWeapon) && unguidedWeapon.IsMine && unguidedWeapon.GetIsInsideThisArea(Local_MissionArea0, Me0.m_EventVal.ParentScen, bool_0: true))
			{
				Local_LegitTargets0.Add(unguidedWeapon);
			}
		}
	}

	[CompilerGenerated]
	private sealed class WorkerCollectionRecord
	{
		public Submarine_AI _003C_003E4__this;

		public Doctrine doctrine;

		internal float AddInterruptibleParam(Weapon theWeapon)
		{
			return theWeapon.GetMaxRangeForThisTarget(_003C_003E4__this.m_EventVal, _003C_003E4__this.PrimaryTarget, bool_0: true, doctrine, bool_1: false);
		}
	}

	private float m_CodeProxy;

	private SubmarineDepthPreset m_ConnectionProxy;

	private Submarine _ContextProxy;

	protected Contact _LastPrimaryThreat;

	private float _StatusProxy;

	private HashSet<string> proccesorProxy;

	private bool strategyProxy;

	public override Contact PrimaryThreat
	{
		get
		{
			return _PrimaryThreat;
		}
		set
		{
			if (_PrimaryThreat != value)
			{
				_LastPrimaryThreat = _PrimaryThreat;
			}
			_PrimaryThreat = value;
		}
	}

	public Contact LastPrimaryThreat => _LastPrimaryThreat;

	public SubmarineDepthPreset DepthPreset
	{
		get
		{
			return m_ConnectionProxy;
		}
		set
		{
			m_ConnectionProxy = value;
			if (value != 0)
			{
				m_EventVal.Kinematics.DesiredAltitudeOverride = true;
			}
		}
	}

	[SpecialName]
	private Submarine GetParentPlatform()
	{
		if (_ContextProxy == null)
		{
			_ContextProxy = (Submarine)m_EventVal;
		}
		return _ContextProxy;
	}

	public Submarine_AI(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		proccesorProxy = new HashSet<string>();
		strategyProxy = false;
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
			xmlWriter_0.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			xmlWriter_0.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			xmlWriter_0.WriteElementString("FCLIO", _FerryCycleLegIsOutbound.ToString());
			if (!EvaluateTargets_Enabled)
			{
				xmlWriter_0.WriteElementString("ET_E", "False");
			}
			if (!DeterminePrimaryTarget_Enabled)
			{
				xmlWriter_0.WriteElementString("DPT_E", "False");
			}
			xmlWriter_0.WriteElementString("DP", ((byte)DepthPreset).ToString());
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
			if (base.PrimaryPickupTarget != null)
			{
				xmlWriter_0.WriteElementString("PrimaryPickupTarget", _PrimaryPickupTarget.ObjectID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100815", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Submarine_AI FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Submarine_AI submarine_AI = new Submarine_AI(ref activeUnit_0);
			submarine_AI.m_EventVal = activeUnit_0;
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
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "PrimaryTarget":
						submarine_AI._PrimaryTarget = Contact.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						break;
					case "DP":
						submarine_AI.DepthPreset = (SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Threats":
						if (submarine_AI._Threats == null)
						{
							submarine_AI._Threats = new List<Contact>();
						}
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								Contact item = Contact.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
								submarine_AI._Threats.Add(item);
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
						submarine_AI._PrimaryThreat = Contact.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						break;
					case "LKTL":
						submarine_AI._LastKnownTargetLocation = GeoPoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
						break;
					case "DPT_E":
						submarine_AI.DeterminePrimaryTarget_Enabled = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TTNPTE":
						submarine_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "IE":
						submarine_AI.IsEscort = true;
						break;
					case "PrimaryTarget_LastKnown_Lon":
						submarine_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(xmlNode_.InnerText);
						break;
					case "TargetList":
						submarine_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator2.Current;
								TargetingEntry targetingEntry = TargetingEntry.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
								if (targetingEntry.Target != null && !submarine_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
								{
									submarine_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
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
					case "FerryCycleLegIsOutbound":
					case "FCLIO":
						submarine_AI._FerryCycleLegIsOutbound = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lat":
						submarine_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(xmlNode_.InnerText);
						break;
					case "PrimaryTargetOverride":
					case "PrimaryTargetOverrideExists":
					case "PTOE":
						submarine_AI.PrimaryTargetOverrideExists = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "PrimaryPickupTarget":
						submarine_AI._PrimaryPickupTarget = ActiveUnit.FromXML(xmlNode_.InnerText, ref concurrentDictionary_0);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						submarine_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(xmlNode_.InnerText);
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
					case "ET_E":
						submarine_AI.EvaluateTargets_Enabled = Conversions.ToBoolean(xmlNode_.InnerText);
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
			return submarine_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100816", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Submarine_AI result = new Submarine_AI(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private bool VisitSpecification(int int_0)
	{
		if (_Threats != null && _Threats.Count != 0)
		{
			foreach (Contact threat in _Threats)
			{
				if (!(Module_Unit.RangeToUnit_Horiz(GetParentPlatform(), threat) >= (float)int_0))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public FuelRec._FuelType SelectFuelTypeToConsume(Engine engine_0)
	{
		try
		{
			if (engine_0 == null)
			{
				return FuelRec._FuelType.NoFuel;
			}
			switch (engine_0.Type)
			{
			case Engine.EngineType.AIP:
				if (m_EventVal.Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.Electric).Count() == 0)
				{
					return FuelRec._FuelType.Battery;
				}
				return FuelRec._FuelType.AirIndepedent;
			default:
				return FuelRec._FuelType.NoFuel;
			case Engine.EngineType.Electric:
				return FuelRec._FuelType.Battery;
			case Engine.EngineType.Diesel:
				return FuelRec._FuelType.DieselFuel;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 321654987245", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return FuelRec._FuelType.NoFuel;
		}
	}

	public Dictionary<int, Engine> SelectEngines()
	{
		if (m_EventVal == null)
		{
			return new Dictionary<int, Engine>();
		}
		if (m_EventVal.Propulsion.Count == 0)
		{
			return new Dictionary<int, Engine>();
		}
		Dictionary<int, Engine> dictionary = new Dictionary<int, Engine>();
		if (m_EventVal.Propulsion.Count == 1)
		{
			GetParentPlatform().PrimaryEngine = m_EventVal.Propulsion[0];
			GetParentPlatform().PrimaryEngineNo = 0;
			dictionary.Add(0, m_EventVal.Propulsion[0]);
			return dictionary;
		}
		try
		{
			if (Math.Round(GetParentPlatform().GetCurrentAltitude()) < -20.0)
			{
				if (GetParentPlatform().Propulsion != null && GetParentPlatform().Propulsion.Count > 0)
				{
					int num = GetParentPlatform().Propulsion.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Engine engine = GetParentPlatform().Propulsion[i];
						if (engine.Status != PlatformComponent._ComponentStatus.Destroyed && engine.Type == Engine.EngineType.Electric)
						{
							dictionary.Add(i, engine);
							GetParentPlatform().PrimaryEngine = engine;
							GetParentPlatform().PrimaryEngineNo = i;
							break;
						}
					}
					if (dictionary.Count == 0)
					{
						int num2 = GetParentPlatform().Propulsion.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							Engine engine2 = GetParentPlatform().Propulsion[j];
							if (engine2.Status != PlatformComponent._ComponentStatus.Destroyed && engine2.Type == Engine.EngineType.AIP)
							{
								dictionary.Add(j, engine2);
								GetParentPlatform().PrimaryEngine = engine2;
								GetParentPlatform().PrimaryEngineNo = j;
								break;
							}
						}
					}
				}
				if (GetParentPlatform().IsAIP)
				{
					Doctrine._UseAIP? useAIP = m_EventVal.Doctrine.method_2(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
					byte? b = (byte?)useAIP;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						if (!Information.IsNothing(GetParentPlatform().Propulsion) && GetParentPlatform().Propulsion.Count > 0)
						{
							int num3 = GetParentPlatform().Propulsion.Count - 1;
							for (int k = 0; k <= num3; k++)
							{
								Engine engine3 = GetParentPlatform().Propulsion[k];
								if (engine3.Status != PlatformComponent._ComponentStatus.Destroyed && engine3.Type == Engine.EngineType.AIP)
								{
									dictionary.Add(k, engine3);
									break;
								}
							}
						}
					}
					else if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
					{
						b = (byte?)useAIP;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault() && !Information.IsNothing(GetParentPlatform().Propulsion) && GetParentPlatform().Propulsion.Count > 0)
						{
							int num4 = GetParentPlatform().Propulsion.Count - 1;
							for (int l = 0; l <= num4; l++)
							{
								Engine engine4 = GetParentPlatform().Propulsion[l];
								if (engine4.Status != PlatformComponent._ComponentStatus.Destroyed && engine4.Type == Engine.EngineType.AIP && dictionary.Where((KeyValuePair<int, Engine> theKVP) => theKVP.Value.Type == Engine.EngineType.AIP).Count() == 0)
								{
									dictionary.Add(l, engine4);
									break;
								}
							}
						}
					}
				}
			}
			else if (DecideToSnort())
			{
				if (!Information.IsNothing(GetParentPlatform().Propulsion) && GetParentPlatform().Propulsion.Count > 0)
				{
					int num5 = GetParentPlatform().Propulsion.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						Engine engine5 = GetParentPlatform().Propulsion[m];
						if (engine5.Status != PlatformComponent._ComponentStatus.Destroyed)
						{
							if (engine5.Type == Engine.EngineType.Diesel)
							{
								dictionary.Add(m, engine5);
								GetParentPlatform().PrimaryEngine = engine5;
								GetParentPlatform().PrimaryEngineNo = m;
							}
							if (engine5.Type == Engine.EngineType.Electric)
							{
								dictionary.Add(m, engine5);
							}
						}
					}
				}
			}
			else if (!Information.IsNothing(GetParentPlatform().Propulsion) && GetParentPlatform().Propulsion.Count > 0)
			{
				int num6 = GetParentPlatform().Propulsion.Count - 1;
				for (int n = 0; n <= num6; n++)
				{
					Engine engine6 = GetParentPlatform().Propulsion[n];
					if (engine6.Status != PlatformComponent._ComponentStatus.Destroyed && engine6.Type == Engine.EngineType.Electric)
					{
						dictionary.Add(n, engine6);
						GetParentPlatform().PrimaryEngine = engine6;
						GetParentPlatform().PrimaryEngineNo = n;
						break;
					}
				}
			}
			return dictionary;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100812", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Dictionary<int, Engine> result = new Dictionary<int, Engine>();
			ProjectData.ClearProjectError();
			return result;
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
				if (Information.IsNothing(_PrimaryThreat))
				{
					if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
					{
						m_EventVal.Status = m_EventVal._SingletonVal;
					}
				}
				else if (_PrimaryThreat.Type == Contact_Base.ContactType.Torpedo)
				{
					if (Module_Unit.RangeToUnit_Horiz(m_EventVal, _PrimaryThreat) < 3f)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
						return;
					}
					if (Module_Unit.RangeToUnit_Horiz(m_EventVal, _PrimaryThreat) < 10f && AngleOffContactsBoresight(ref _PrimaryThreat) < 90f)
					{
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
						return;
					}
				}
				else if ((uint)(GetParentPlatform().Type - 2004) <= 1u && Module_Unit.RangeToUnit_Horiz(GetParentPlatform(), _PrimaryThreat) < 30f)
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
			}
			if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				return;
			}
			if (m_EventVal.CommStuff.HasBeenSummonedToReestablishComms)
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.AttemptingToReestablishComms;
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
			if (m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse && !m_EventVal.IsRTB && InsertClient())
			{
				m_EventVal.Navigator.ResetTimeToNextPathfinderCheck();
				return;
			}
			if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				if (Information.IsNothing(PrimaryTarget))
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					return;
				}
				b = (byte?)m_EventVal.Doctrine.GetIgnorePlottedCourse(m_EventVal.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					return;
				}
			}
			if (!Information.IsNothing(PrimaryTarget) && (int)PrimaryTarget.Type > 1)
			{
				bool flag = true;
				if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)m_EventVal.AssignedMissionOrPackage();
					if (strike.MaxResponseRadius_Ship > 0 || strike.MinResponseRadius_Ship > 0)
					{
						float num = Math2.VerifyClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
						if (num > (float)strike.MaxResponseRadius_Ship || num < (float)strike.MinResponseRadius_Ship)
						{
							flag = false;
						}
					}
				}
				if (flag)
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
						if (Information.IsNothing(PrimaryTarget))
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
						}
						else
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
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
					case Mission._MissionClass.Ferry:
						if (Information.IsNothing(PrimaryTarget))
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.OnFerryMission;
						}
						else
						{
							m_EventVal.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						return;
					case Mission._MissionClass.Mining:
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.MineClearing:
						m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					}
				}
			}
			if (m_EventVal.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && m_EventVal.FuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker && m_EventVal.WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun && m_EventVal.Status != 0)
			{
				m_EventVal.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 200347", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool CanInterceptTargetAtCurrentAltSpeed(double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float? nullable_0, bool bool_0, bool bool_1)
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
					float float_5 = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), double_0, double_1);
					num2 = Module_Unit.ClosureSpeed(m_EventVal, double_0, double_1, float_0, float_1, float_3, float_5);
				}
				if (num2 <= 0f || double.IsNaN(num2))
				{
					return false;
				}
			}
			long num3 = (long)Math.Round(num / num2 * 3600f);
			float? num4 = (float)GetParentPlatform().Kinematics.RemainingEndurance(float_3, float_2, bool_0: true, bool_1: false) * (1f + nullable_0);
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

	private Weapon[] RestartSpecification()
	{
		return m_EventVal.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float float_0, bool bool_0, bool bool_1)
	{
		if (!EvaluateTargets_Enabled)
		{
			return;
		}
		try
		{
			if (m_EventVal == null || GetParentPlatform().IsBiological || GetParentPlatform().IsFalseTarget)
			{
				return;
			}
			Contact contact = null;
			if (m_EventVal.Mounts.Count == 0 && m_EventVal.Sensors_Cached.Length == 0)
			{
				if (!Information.IsNothing(PrimaryTarget))
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
			list3.AddRange(RestartSpecification());
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
			if (proccesorProxy.Count > 0)
			{
				proccesorProxy.Clear();
			}
			foreach (Contact item3 in PrintClient())
			{
				if (TargetingBehaviorForThisTarget(item3) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					proccesorProxy.Add(item3.ObjectID);
				}
			}
			Misc.PostureStance value;
			int int_;
			if (mission != null && mission.IsActive && count > 0)
			{
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					contact = PrintClient()[i];
					if (proccesorProxy.Contains(contact.ObjectID) || list2.Contains(contact))
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
						if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
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
						if (contact.HeadingIsKnown && contact.SpeedIsKnown && contact.CurrentSpeed > 0f && m_EventVal.CurrentSpeed > 0f)
						{
							if (RemoveClient(contact, bool_0: true))
							{
								TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								proccesorProxy.Add(contact.ObjectID);
							}
						}
						else
						{
							TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							proccesorProxy.Add(contact.ObjectID);
						}
						break;
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
					{
						if (PopClient(contact))
						{
							break;
						}
						ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
						Contact contact_2 = contact;
						Doctrine doctrine = m_EventVal.Doctrine;
						string_ = "";
						int_ = 0;
						if (!weaponry.PopConsumer(contact_2, bool_1: true, doctrine, ref string_, ref int_, list3) || (contact.Type == Contact_Base.ContactType.Submarine && contact.IsClassifiedFalseTarget))
						{
							break;
						}
						if (contact.HeadingIsKnown && contact.SpeedIsKnown && contact.CurrentSpeed > 0f && m_EventVal.CurrentSpeed > 0f)
						{
							if (RemoveClient(contact, bool_0: true))
							{
								TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								proccesorProxy.Add(contact.ObjectID);
							}
						}
						else
						{
							TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							proccesorProxy.Add(contact.ObjectID);
						}
						break;
					}
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
			if (count <= 0)
			{
				return;
			}
			int_ = count - 1;
			for (int j = 0; j <= int_; j++)
			{
				contact = PrintClient()[j];
				if (proccesorProxy.Contains(contact.ObjectID) || list2.Contains(contact))
				{
					continue;
				}
				if (m_AccountVal[j] == null)
				{
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
					{
						value = contact.GetStance(m_EventVal.GetUnitSide());
					}
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
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault() || !RemoveClient(contact, bool_0: true))
				{
					continue;
				}
				if (!flag && !Information.IsNothing(mission) && mission.MissionClass == Mission._MissionClass.Patrol && !contact.IsAir_Missile_Submarine_Contact && !((Patrol)mission).GetInvestigateOutsidePatrolArea(m_EventVal.ParentScen))
				{
					Patrol patrol2 = (Patrol)mission;
					if (!contact.GetIsInsideThisArea(patrol2.PatrolArea, m_EventVal.ParentScen, bool_0: true) && TargetingBehaviorForThisTarget(contact) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !m_EventVal.Sensory.IsIlluminatingThisContact(contact) && (!hasValue || useShootTourists != Doctrine._UseShootTourists.Yes))
					{
						continue;
					}
				}
				if (!proccesorProxy.Contains(contact.ObjectID))
				{
					ActiveUnit_Weaponry weaponry2 = m_EventVal.Weaponry;
					Contact contact_3 = contact;
					Doctrine doctrine2 = m_EventVal.Doctrine;
					string string_2 = "";
					int int_2 = 0;
					if (weaponry2.PopConsumer(contact_3, bool_1: true, doctrine2, ref string_2, ref int_2, list3) && TargetIsEligibleBasedOnWeaponRange(contact, value, hasValue, useShootTourists, weapon_, weapon_3, weapon_4, weapon_2))
					{
						TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						proccesorProxy.Add(contact.ObjectID);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100815", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
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
				flag = TestSpecification(float_0);
			}
		}
		if (!flag)
		{
			base.ManouverTowardsTarget(float_0);
		}
	}

	internal bool TestSpecification(float float_0)
	{
		try
		{
			strategyProxy = false;
			if (PrimaryTarget == null)
			{
				return false;
			}
			if (PrimaryTarget.Type != 0 && PrimaryTarget.Type != Contact_Base.ContactType.Missile)
			{
				Doctrine doctrine = m_EventVal.Doctrine;
				Weapon weapon = m_EventVal.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, bool_1: true, bool_2: true, bool_3: true, doctrine, bool_4: false, bool_5: true);
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
						if (m_EventVal.IsSubmarine && weapon.IsMissile)
						{
							((Submarine)m_EventVal).DesiredAltitude = -20f;
						}
						m_EventVal.DesiredSpeed = 0f;
						m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
						ActiveUnit_Navigator navigator = m_EventVal.Navigator;
						Waypoint[] gparam_ = navigator.PlottedCourse;
						ArrayExtensions.Clear(ref gparam_);
						navigator.PlottedCourse = gparam_;
						strategyProxy = true;
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

	internal void StopSpecification()
	{
		if (GetParentPlatform().DesiredAltitude <= GetParentPlatform().GetCurrentAltitude())
		{
			if (GetParentPlatform().DesiredAltitude < GetParentPlatform().GetCurrentAltitude())
			{
				if (GetParentPlatform().DesiredAltitude < GetParentPlatform().GetCurrentAltitude() - 150f)
				{
					GetParentPlatform().DesiredPitch = -30f;
				}
				else
				{
					GetParentPlatform().DesiredPitch = (GetParentPlatform().DesiredAltitude - GetParentPlatform().GetCurrentAltitude()) / 5f;
				}
			}
			else
			{
				GetParentPlatform().DesiredPitch = 0f;
			}
		}
		else if (GetParentPlatform().DesiredAltitude <= GetParentPlatform().GetCurrentAltitude() + 150f)
		{
			GetParentPlatform().DesiredPitch = (GetParentPlatform().DesiredAltitude - GetParentPlatform().GetCurrentAltitude()) / 5f;
		}
		else
		{
			GetParentPlatform().DesiredPitch = 30f;
		}
	}

	private float CancelSpecification(Contact contact_0)
	{
		float currentAltitude = GetParentPlatform().GetCurrentAltitude();
		if (contact_0.AltitudeIsKnown)
		{
			currentAltitude = contact_0.GetCurrentAltitude();
		}
		if (Math.Abs(currentAltitude - GetParentPlatform().GetCurrentAltitude()) <= 20f)
		{
			float num = GetParentPlatform().Kinematics.GetMinimumAltitude();
			float num2 = GetParentPlatform().GetLandElevation(bool_0: false, bool_1: false, bool_2: false, m_EventVal.ParentScen);
			if (num < num2)
			{
				num = num2;
			}
			float num3 = Math.Abs(GetParentPlatform().GetCurrentAltitude() - num);
			float num4 = Math.Abs(GetParentPlatform().GetCurrentAltitude() - -20f);
			if (GetParentPlatform().GetCurrentAltitude() <= currentAltitude)
			{
				num4 /= 4f;
			}
			else
			{
				num3 /= 4f;
			}
			if (num4 <= num3)
			{
				return num;
			}
			return -19f;
		}
		return GetParentPlatform().DesiredAltitude;
	}

	public override void ManoueverTorpedoEvasion(float float_0, Contact contact_0)
	{
		if (contact_0 == null)
		{
			return;
		}
		float num = Module_Unit.RangeToPoint_Horiz(GetParentPlatform(), contact_0.GetLatitude(), contact_0.GetLongitude());
		Weapon weapon_ = GetParentPlatform().Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: true, bool_2: true, bool_3: true, m_EventVal.Doctrine);
		if (weapon_ != null && weapon_.Type != Weapon._WeaponType.Decoy_Expendable && weapon_.Type != Weapon._WeaponType.Decoy_Towed && IsClearedToEngageThisTarget(contact_0) && num <= weapon_.GetMaxRangeForThisTarget(GetParentPlatform(), contact_0, bool_0: true, GetParentPlatform().Doctrine, bool_1: false))
		{
			GetParentPlatform().SetThrottle(ActiveUnit.Throttle.Flank);
			Tuple<Mount, float, bool> tuple_ = null;
			TurnToUnmaskPrimaryWeapon(ref weapon_, contact_0, ref tuple_);
			return;
		}
		if (EvasionManeuver != null)
		{
			if (contact_0 == EvasionManeuver.TargetContact && (num >= EvasionManeuver.OriginalRange || GetParentPlatform().CurrentHeading != EvasionManeuver.DesiredHeading || GetParentPlatform().CurrentSpeed != GetParentPlatform().DesiredSpeed || GetParentPlatform().GetCurrentAltitude() != GetParentPlatform().DesiredAltitude))
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
		float num2 = (float)Math.Round(Math2.PublishClass(GetParentPlatform().GetLatitude(), GetParentPlatform().GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()), 0);
		Submarine parentPlatform = GetParentPlatform();
		string string_ = "";
		float num3 = Module_Unit.PrintTokenizer(contact_0, parentPlatform, bool_0: true, ref string_);
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
			EvasionManeuver = new PersistentManeuver(GetParentPlatform(), contact_0, num);
			EvasionManeuver.DesiredAltitude = GetParentPlatform().DesiredAltitude;
			if (GetParentPlatform().Weaponry.IsGuidingWireTorpedoes)
			{
				EvasionManeuver.DesiredThrottle = GetParentPlatform().Kinematics.GetThrottleSuitableForThisSpeed(GetParentPlatform().GetCurrentAltitude(), Submarine.MaxTorpedoWireSpeed);
			}
			else
			{
				EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
			}
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
			num7 = GetParentPlatform().Kinematics.GetMaximumSpeed();
		}
		if (num7 >= num6)
		{
			float num8 = Math.Abs(Math2.UpdateClass(num2 + 180f) - GetParentPlatform().CurrentHeading);
			if (num8 > 180f)
			{
				num8 = 360f - num8;
			}
			if (num8 < 1f || num8 / GetParentPlatform().Kinematics.TurnRate() < num / (num6 / 3600f))
			{
				int int_ = (int)Math.Round(num2);
				OutrunThreat(ref int_);
				GetParentPlatform().SetThrottle(ActiveUnit.Throttle.Flank);
				GetParentPlatform().DesiredAltitude = m_EventVal.Kinematics.GetMinimumAltitude();
				return;
			}
		}
		float num9 = Math.Abs(num3);
		EvasionManeuver = new PersistentManeuver(GetParentPlatform(), contact_0, num);
		EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
		EvasionManeuver.DesiredAltitude = CancelSpecification(contact_0);
		if (num <= ActiveUnit_AI.TorpedoEvasionEmergencyRange)
		{
			if (num9 < 60f)
			{
				if (num3 < 0f)
				{
					EvasionManeuver.DesiredHeading = Math2.UpdateClass(GetParentPlatform().CurrentHeading - 90f);
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
				}
				else
				{
					EvasionManeuver.DesiredHeading = Math2.UpdateClass(GetParentPlatform().CurrentHeading + 90f);
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
				}
			}
			else if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(GetParentPlatform().CurrentHeading + 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.UpdateClass(GetParentPlatform().CurrentHeading - 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
		}
		else if (num3 < 0f)
		{
			EvasionManeuver.DesiredHeading = Math2.UpdateClass(num2 - 135f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
		}
		else
		{
			EvasionManeuver.DesiredHeading = Math2.UpdateClass(num2 - 225f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
		}
	}

	public override void ManouverAgainstPrimaryThreat(float float_0)
	{
		if (m_EventVal == null || PrimaryThreat == null)
		{
			return;
		}
		try
		{
			float num = (float)Math.Round(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryThreat.GetLatitude(), PrimaryThreat.GetLongitude()), 0);
			if (float.IsNegativeInfinity(num))
			{
				return;
			}
			switch (PrimaryThreat.Type)
			{
			case Contact_Base.ContactType.Torpedo:
				ManoueverTorpedoEvasion(float_0, PrimaryThreat);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Submarine:
			{
				if (!Information.IsNothing(LastPrimaryThreat) && (double)Math.Abs(Module_Unit.RangeToUnit_Horiz(LastPrimaryThreat, m_EventVal) - Module_Unit.RangeToUnit_Horiz(PrimaryThreat, m_EventVal)) < 0.5)
				{
					float num2 = (float)Math.Round(Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), LastPrimaryThreat.GetLatitude(), LastPrimaryThreat.GetLongitude()), 0);
					double x = Math.Cos(0.0174532925199433 * (double)num) + Math.Cos(0.0174532925199433 * (double)num2);
					double y = Math.Sin(0.0174532925199433 * (double)num) + Math.Sin(0.0174532925199433 * (double)num2);
					num = (float)(57.2957795130823 * Math.Atan2(y, x));
				}
				int int_ = (int)Math.Round(num);
				OutrunThreat(ref int_);
				if (PrimaryThreat.SpeedIsKnown && GetParentPlatform().IsNuke)
				{
					GetParentPlatform().DesiredSpeed = PrimaryThreat.CurrentSpeed;
					GetParentPlatform().SetThrottle(GetParentPlatform().Kinematics.GetThrottleSuitableForThisSpeed(GetParentPlatform().GetCurrentAltitude(), GetParentPlatform().DesiredSpeed), GetParentPlatform().DesiredSpeed);
				}
				else
				{
					GetParentPlatform().SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100816", "");
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
		try
		{
			if (m_EventVal == null)
			{
				return;
			}
			if (_Threats != null && _Threats.Count != 0)
			{
				IEnumerable<Contact> source = from theC in _Threats
					where ((theC == null) ? new bool?(false) : theC.ActualUnit?.IsWeapon).GetValueOrDefault()
					select (theC) into contact_0
					orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
					select contact_0;
				if (source.Count() <= 0)
				{
					IEnumerable<Contact> source2 = from theC in _Threats
						where theC != null
						select (theC) into contact_0
						orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0)
						select contact_0;
					PrimaryThreat = source2.ElementAtOrDefault(0);
				}
				else
				{
					PrimaryThreat = source.ElementAtOrDefault(0);
				}
			}
			else
			{
				PrimaryThreat = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100817", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateThreats()
	{
		if (m_EventVal == null || GetParentPlatform().IsBiological || GetParentPlatform().IsFalseTarget)
		{
			return;
		}
		try
		{
			ClearAllThreats();
			if (PrintClient().Count == 0)
			{
				return;
			}
			int num = PrintClient().Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Contact contact;
				try
				{
					contact = PrintClient()[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				if (contact.GetIsDestroyed(m_EventVal.ParentScen))
				{
					continue;
				}
				if (contact.IDStatus >= Contact_Base.IdentificationStatus.KnownType && !Information.IsNothing(contact.ActualUnit) && contact.ActualUnit.IsSubmarine)
				{
					Submarine submarine = (Submarine)contact.ActualUnit;
					if (submarine.Type == Submarine._SubmarineType.Biologics || submarine.Type == Submarine._SubmarineType.FalseTarget)
					{
						continue;
					}
				}
				if (Information.IsNothing(contact.ActualUnit))
				{
					continue;
				}
				if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out var value))
				{
					value = contact.GetStance(m_EventVal.GetUnitSide());
				}
				if (value != Misc.PostureStance.Friendly && contact.ActualUnit.IsWeapon && ((Weapon)contact.ActualUnit).Type == Weapon._WeaponType.Torpedo)
				{
					AddContactToThreatList(contact);
					Weapon weapon = m_EventVal.Weaponry.CloneFacade(contact);
					if (weapon != null)
					{
						ActiveUnit_Weaponry weaponry = m_EventVal.Weaponry;
						Doctrine doctrine = m_EventVal.Doctrine;
						string string_ = "";
						int int_ = 0;
						if (weaponry.PopConsumer(contact, bool_1: true, doctrine, ref string_, ref int_) && (double)Module_Unit.RangeToUnit_Slant(m_EventVal, contact) < 1.5 * (double)weapon.MaxSubsurfaceRange)
						{
							TargetThisContact(contact, bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						}
					}
					continue;
				}
				switch (contact.Type)
				{
				case Contact_Base.ContactType.Submarine:
				case Contact_Base.ContactType.UndeterminedNaval:
					if (!contact.IsClassifiedFalseTarget && (value == Misc.PostureStance.Hostile || value == Misc.PostureStance.Unfriendly || value == Misc.PostureStance.Unknown))
					{
						AddContactToThreatList(contact);
					}
					break;
				case Contact_Base.ContactType.Surface:
				{
					Ship ship = (Ship)contact.ActualUnit;
					if (contact.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
					{
						Ship._ShipCategory category = ship.Category;
						if (((uint)(category - 2001) <= 1u || (uint)(category - 2007) <= 1u) && (value == Misc.PostureStance.Hostile || value == Misc.PostureStance.Unfriendly))
						{
							AddContactToThreatList(contact);
						}
					}
					break;
				}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100818", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float OverLayerDepth(ActiveUnit activeUnit_0)
	{
		return Math.Min(SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen), activeUnit_0.ParentScen).Ceiling + 10, -25);
	}

	public static float UnderLayerDepth(ActiveUnit activeUnit_0)
	{
		return Math.Min(SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen), activeUnit_0.ParentScen).Floor - 10, -25);
	}

	public bool DecideToSnort()
	{
		if (Math.Round(GetParentPlatform().GetCurrentAltitude()) < -20.0)
		{
			return true;
		}
		if (Math.Round(GetParentPlatform().DesiredAltitude) < -20.0)
		{
			return false;
		}
		if (GetParentPlatform().Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.Diesel && theE.Status != PlatformComponent._ComponentStatus.Destroyed).Count() == 0)
		{
			return false;
		}
		if (GetParentPlatform().Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.Diesel && theE.Status != PlatformComponent._ComponentStatus.Destroyed).Count() == 0)
		{
			return false;
		}
		return true;
	}

	private bool VerifySpecification(float float_0)
	{
		if (m_EventVal == null)
		{
			return false;
		}
		try
		{
			if (GetParentPlatform().IsNuke)
			{
				return false;
			}
			FuelRec fuelRec = GetParentPlatform().Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.DieselFuel).ElementAtOrDefault(0);
			if ((Information.IsNothing(fuelRec) || fuelRec.CurrentQuantity <= 0f) && GetParentPlatform().IsAIP)
			{
				fuelRec = GetParentPlatform().Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.AirIndepedent).ElementAtOrDefault(0);
			}
			if (!Information.IsNothing(fuelRec) && fuelRec.CurrentQuantity > 0f)
			{
				FuelRec fuelRec2 = GetParentPlatform().Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
				if (Information.IsNothing(fuelRec2))
				{
					return false;
				}
				double num = fuelRec2.PercentFull;
				if (num == 0.0)
				{
					return true;
				}
				if (num <= (double)(float_0 / 100f))
				{
					return true;
				}
				return false;
			}
			GetParentPlatform().StopRechargingBatteries();
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100820", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool ListSpecification(bool bool_0, ActiveUnit_DockingOps._DockingOpsCondition? nullable_0)
	{
		if (m_EventVal == null)
		{
			return false;
		}
		if (GetParentPlatform().IsNuke)
		{
			return false;
		}
		try
		{
			double num = (double)m_EventVal.Doctrine.GetRechargePercentageAttack(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value / 100.0;
			FuelRec fuelRec = GetParentPlatform().Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
			if (Information.IsNothing(fuelRec))
			{
				GetParentPlatform().StopRechargingBatteries();
				return false;
			}
			double num2 = fuelRec.PercentFull;
			if (num2 < num)
			{
				return true;
			}
			if (Information.IsNothing(nullable_0))
			{
				nullable_0 = GetParentPlatform().DockingOps.Condition;
			}
			byte? b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 9) : null).GetValueOrDefault())
			{
				double num3 = (double)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value / 100.0;
				if (num2 < num3)
				{
					return true;
				}
			}
			return ResolveSpecification(bool_0, nullable_0, num, num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100822", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool ResolveSpecification(bool bool_0, ActiveUnit_DockingOps._DockingOpsCondition? nullable_0, double double_0, double double_1)
	{
		try
		{
			if (GetParentPlatform().IsBiological)
			{
				return true;
			}
			if (GetParentPlatform().IsFalseTarget)
			{
				return false;
			}
			if (!GetParentPlatform().IsNuke)
			{
				if (double_0 < 0.0)
				{
					double_0 = (double)m_EventVal.Doctrine.GetRechargePercentageAttack(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value / 100.0;
				}
				if (double_1 < 0.0)
				{
					double_1 = GetParentPlatform().Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0).PercentFull;
				}
			}
			Doctrine._DiveOnContact? diveWhenThreatsDetected = m_EventVal.Doctrine.GetDiveWhenThreatsDetected(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			byte? b = (byte?)diveWhenThreatsDetected;
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
				b = (byte?)diveWhenThreatsDetected;
				flag2 = (flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
				flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
			}
			flag4 = flag3;
			bool value = flag4.Value;
			b = (byte?)diveWhenThreatsDetected;
			flag2 = (flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null));
			bool? flag5;
			if (flag2.HasValue && flag4.GetValueOrDefault())
			{
				flag5 = true;
			}
			else
			{
				b = (byte?)diveWhenThreatsDetected;
				flag2 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null));
				flag5 = ((!flag2.HasValue) ? null : (flag.GetValueOrDefault() | flag4));
			}
			flag = flag5;
			bool value2 = flag.Value;
			if (m_EventVal.TimeSinceLastThreatDetection_ESM < 1800f && value)
			{
				if (Math.Round(m_EventVal.DesiredAltitude) >= -20.0)
				{
					string text = "";
					if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + m_EventVal.UnitClass + ")";
					}
					if (m_EventVal.Kinematics.DesiredAltitudeOverride)
					{
						m_EventVal.ParentScen.AddMessage("潜艇：" + m_EventVal.Name + text + "已被命令其到潜望镜深度或水面，但条令已被设定为“探测到威胁时潜水”。潜艇现在将潜水。要允许潜水艇进入潜望镜深度或水面，请将“探测到威胁时潜水”设置为“否”。", m_EventVal.Name + " 正下潜（附近发现威胁！）", LoggedMessage.MessageType.SpecialMessage, 0, null, m_EventVal.GetUnitSide());
					}
				}
				if (GetParentPlatform().IsNuke)
				{
					return false;
				}
				if (!bool_0 && double_0 <= double_1)
				{
					GetParentPlatform().StopRechargingBatteries();
					return false;
				}
			}
			if (value2)
			{
				foreach (Contact item in PrintClient())
				{
					if (!m_EventVal.GetUnitSide().Cache_ContactStancesOnThisPulse.TryGetValue(item.ObjectID, out var value3))
					{
						value3 = item.GetStance(m_EventVal.GetUnitSide());
					}
					if (item.IDStatus <= Contact_Base.IdentificationStatus.KnownType)
					{
						continue;
					}
					if (item.IsSubmergedContact && !Information.IsNothing(item.ActualUnit) && item.ActualUnit.IsSubmarine)
					{
						Submarine submarine = (Submarine)item.ActualUnit;
						if (submarine.Type == Submarine._SubmarineType.Biologics || submarine.Type == Submarine._SubmarineType.FalseTarget)
						{
							continue;
						}
					}
					if (value3 == Misc.PostureStance.Friendly || value3 == Misc.PostureStance.Neutral)
					{
						continue;
					}
					Contact_Base.ContactType type = item.Type;
					int num;
					if (type == Contact_Base.ContactType.Air)
					{
						num = 30;
					}
					else
					{
						if ((int)(type - 2) > 1 && type != Contact_Base.ContactType.Sonobuoy)
						{
							continue;
						}
						num = 20;
					}
					if (Module_Unit.RangeToUnit_Horiz(GetParentPlatform(), item) >= (float)num)
					{
						continue;
					}
					if (!GetParentPlatform().IsNuke)
					{
						GetParentPlatform().StopRechargingBatteries();
					}
					if (Math.Round(m_EventVal.DesiredAltitude) >= -20.0)
					{
						string text2 = "";
						if (Operators.CompareString(m_EventVal.Name, m_EventVal.UnitClass, TextCompare: false) != 0)
						{
							text2 = " (" + m_EventVal.UnitClass + ")";
						}
						if (m_EventVal.Kinematics.DesiredAltitudeOverride)
						{
							m_EventVal.ParentScen.AddMessage("潜艇：" + m_EventVal.Name + text2 + "已经命令其到潜望镜深度或水面，但条令已被配置为“探测到威胁时潜水”。潜艇现在将潜水。为了让潜水艇进入潜望镜深度或水面，将“探测到威胁时潜水”更改为否。", m_EventVal.Name + " 正下潜（附近发现威胁！）", LoggedMessage.MessageType.SpecialMessage, 0, null, m_EventVal.GetUnitSide());
						}
					}
					return false;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101280", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool PostSpecification(float float_0, bool bool_0, bool bool_1)
	{
		ActiveUnit_DockingOps._DockingOpsCondition condition = GetParentPlatform().DockingOps.Condition;
		if (condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
		{
			if (ListSpecification(bool_1, condition))
			{
				if (GetParentPlatform().Flags.HasSnorkel && Math.Round(GetParentPlatform().DesiredAltitude) < -20.0)
				{
					GetParentPlatform().DesiredAltitude = -20f;
				}
				else if (!GetParentPlatform().Flags.HasSnorkel && Math.Round(GetParentPlatform().DesiredAltitude) < -5.0)
				{
					GetParentPlatform().DesiredAltitude = -5f;
				}
				return true;
			}
			GetParentPlatform().DesiredAltitude = -40f;
			return false;
		}
		try
		{
			if (m_EventVal == null)
			{
				return false;
			}
			if (GetParentPlatform().IsNuke)
			{
				return false;
			}
			_ = GetParentPlatform().DesiredAltitude;
			if (VerifySpecification(float_0) && (bool_1 || ListSpecification(bool_1, null)))
			{
				GetParentPlatform().DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries;
				if (GetParentPlatform().Flags.HasSnorkel && Math.Round(GetParentPlatform().DesiredAltitude) < -20.0)
				{
					GetParentPlatform().DesiredAltitude = -20f;
				}
				else if (!GetParentPlatform().Flags.HasSnorkel && Math.Round(GetParentPlatform().DesiredAltitude) < -5.0)
				{
					GetParentPlatform().DesiredAltitude = -5f;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100823", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void RunSpecification(float float_0)
	{
		if (m_EventVal == null || m_EventVal.AssignedMissionOrPackage() == null || m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
		{
			return;
		}
		try
		{
			if (GetParentPlatform().DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
			{
				return;
			}
			Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
			if (patrol.StationDepth_Submarine.HasValue)
			{
				float num = 0f;
				if (!m_EventVal.GetIsInsideThisArea(patrol.PatrolArea, m_EventVal.ParentScen, bool_0: false))
				{
					num = (patrol.TransitDepth_Submarine.HasValue ? patrol.TransitDepth_Submarine.Value : patrol.StationDepth_Submarine.Value);
				}
				if (!(Math.Round(num) < -20.0) && !ListSpecification(bool_0: false, null))
				{
					m_EventVal.DesiredAltitude = -40f;
				}
				else
				{
					m_EventVal.DesiredAltitude = num;
				}
				return;
			}
			switch (patrol.Type)
			{
			case GlobalVariables.PatrolType.AAW:
			case GlobalVariables.PatrolType.ASuW_Land:
			case GlobalVariables.PatrolType.ASuW_Mixed:
			case GlobalVariables.PatrolType.SEAD:
				if (patrol.StationDepth_Submarine.HasValue)
				{
					if (!(Math.Round(patrol.StationDepth_Submarine.Value) < -20.0) && !ListSpecification(bool_0: false, null))
					{
						m_EventVal.DesiredAltitude = -40f;
					}
					else
					{
						m_EventVal.DesiredAltitude = -20f;
					}
				}
				else
				{
					m_EventVal.DesiredAltitude = -40f;
				}
				break;
			case GlobalVariables.PatrolType.ASW:
			case GlobalVariables.PatrolType.ASuW_Naval:
			case GlobalVariables.PatrolType.SeaControl:
				m_CodeProxy -= float_0;
				if (m_CodeProxy <= 0f)
				{
					m_CodeProxy = GameGeneral.LockRandom_0.Next(1, 901);
					SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), Terrain.GetElevation(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), bool_0: false, m_EventVal.ParentScen), m_EventVal.ParentScen);
					int num2 = -40;
					int num3 = (m_EventVal.Sensory.HasOperationalTowedArray ? (thermalLayerAtThisLocation.Ceiling + 10) : (thermalLayerAtThisLocation.Floor - 10));
					if (num2 < num3)
					{
						num2 = num3 + 1;
					}
					if (GameGeneral.LockRandom_0.Next(1, 101) < 50)
					{
						m_EventVal.DesiredAltitude = num2;
					}
					else
					{
						m_EventVal.DesiredAltitude = num3;
					}
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100824", "");
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
		if (m_EventVal != null)
		{
			float relativeBearing = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, m_EventVal.DesiredHeading);
			float num = 30f;
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
				m_EventVal.DesiredRoll = num;
			}
			else if (relativeBearing > 180f && relativeBearing <= 320f)
			{
				m_EventVal.DesiredRoll = 0f - num;
			}
			else
			{
				m_EventVal.DesiredRoll = -4f * (360f - relativeBearing);
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
	}

	private float StartSpecification(string string_0)
	{
		Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
		float result = 0f;
		if (Operators.CompareString(string_0, "Transit", TextCompare: false) == 0)
		{
			result = ((patrol == null || !patrol.UseTransitDepth_Submarine_Preset.GetValueOrDefault()) ? patrol.TransitDepth_Submarine.Value : m_EventVal.AI.PrepareClient(bool_0: false, patrol.TransitDepth_Submarine_Preset.Value));
		}
		if (Operators.CompareString(string_0, "Station", TextCompare: false) == 0)
		{
			result = ((patrol == null || !patrol.UseStationDepth_Submarine_Preset.GetValueOrDefault()) ? patrol.StationDepth_Submarine.Value : m_EventVal.AI.PrepareClient(bool_0: false, patrol.StationDepth_Submarine_Preset.Value));
		}
		if (Operators.CompareString(string_0, "Attack", TextCompare: false) == 0)
		{
			result = ((patrol == null || !patrol.UseAttackDepth_Submarine_Preset.GetValueOrDefault()) ? patrol.AttackDepth_Submarine.Value : m_EventVal.AI.PrepareClient(bool_0: false, patrol.AttackDepth_Submarine_Preset.Value));
		}
		return result;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		if (m_EventVal == null)
		{
			return;
		}
		try
		{
			ActiveUnit._ActiveUnitStatus activeUnitStatus = m_EventVal.Status;
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(float_0, WeaponThreat);
				m_EventVal.Kinematics.DesiredSpeedOverride = null;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				m_EventVal.DesiredAltitude = m_EventVal.Kinematics.GetMinimumAltitude();
				return;
			}
			if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
			{
				switch (m_EventVal.AssignedMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)m_EventVal.AssignedMissionOrPackage();
					if (patrol != null)
					{
						if (patrol.UseStationDepth_Submarine_Preset.GetValueOrDefault())
						{
							patrol.StationDepth_Submarine = PrepareClient(bool_0: false, patrol.StationDepth_Submarine_Preset.Value);
						}
						if (patrol.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
						{
							patrol.TransitDepth_Submarine = PrepareClient(bool_0: false, patrol.TransitDepth_Submarine_Preset.Value);
						}
						if (patrol.UseAttackDepth_Submarine_Preset.GetValueOrDefault())
						{
							patrol.AttackDepth_Submarine = PrepareClient(bool_0: false, patrol.AttackDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.Support:
				{
					SupportMission supportMission = (SupportMission)m_EventVal.AssignedMissionOrPackage();
					if (supportMission != null)
					{
						if (supportMission.UseStationDepth_Submarine_Preset.GetValueOrDefault())
						{
							supportMission.StationDepth_Submarine = PrepareClient(bool_0: false, supportMission.StationDepth_Submarine_Preset.Value);
						}
						if (supportMission.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
						{
							supportMission.TransitDepth_Submarine = PrepareClient(bool_0: false, supportMission.TransitDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					MiningMission miningMission = (MiningMission)m_EventVal.AssignedMissionOrPackage();
					if (miningMission != null)
					{
						if (miningMission.UseStationDepth_Submarine_Preset.GetValueOrDefault())
						{
							miningMission.StationDepth_Submarine = PrepareClient(bool_0: false, miningMission.StationDepth_Submarine_Preset.Value);
						}
						if (miningMission.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
						{
							miningMission.TransitDepth_Submarine = PrepareClient(bool_0: false, miningMission.TransitDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
				{
					MineClearingMission mineClearingMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
					if (mineClearingMission != null)
					{
						if (mineClearingMission.UseStationDepth_Submarine_Preset.GetValueOrDefault())
						{
							mineClearingMission.StationDepth_Submarine = PrepareClient(bool_0: false, mineClearingMission.StationDepth_Submarine_Preset.Value);
						}
						if (mineClearingMission.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
						{
							mineClearingMission.TransitDepth_Submarine = PrepareClient(bool_0: false, mineClearingMission.TransitDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				}
			}
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
			{
				int value = (int)m_EventVal.Doctrine.GetRechargePercentageAttack(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
				if (!PostSpecification(value, bool_0: true, bool_1: true))
				{
					m_EventVal.Kinematics.DesiredSpeedOverride = null;
					m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
				}
				ManouverAgainstPrimaryThreat(float_0);
				return;
			}
			case ActiveUnit._ActiveUnitStatus.AttemptingToReestablishComms:
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
				DepthPreset = SubmarineDepthPreset.Shallow;
				FollowDepthPreset(bool_0: true);
				return;
			case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
			{
				bool flag = true;
				GeoPoint geoPoint_ = LoginClient();
				ActiveUnit_DockingOps dockingOps = m_EventVal.DockingOps;
				string string_ = "";
				List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(bool_0: true, null, ref string_, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
				if (m_EventVal.ParentScen.MinuteIsChangingOnThisPulse || Information.IsNothing(m_EventVal.DockingOps.UNREP_Destination))
				{
					if (!Information.IsNothing(m_EventVal.DockingOps.UNREP_Destination) && potentialUNREPunits.Contains(m_EventVal.DockingOps.UNREP_Destination))
					{
						flag = m_EventVal.DockingOps.SearchDic(m_EventVal.DockingOps.UNREP_Destination) == ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success || m_EventVal.DockingOps.IncludeDic(geoPoint_, null, null, bool_0: false, 100).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
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
				if (!Information.IsNothing(m_EventVal.DockingOps.UNREP_Destination) && flag)
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
				return;
			}
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
				m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(m_EventVal.DesiredSpeed)), (int)Math.Round(m_EventVal.DesiredSpeed));
				return;
			}
			case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
				m_EventVal.DesiredSpeed = 0f;
				m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				if (GetParentPlatform().IsTetheredROV)
				{
					ActiveUnit assignedHostUnit = m_EventVal.DockingOps.GetAssignedHostUnit();
					if (!Information.IsNothing(assignedHostUnit))
					{
						assignedHostUnit.DesiredSpeed = 0f;
						assignedHostUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
					}
				}
				return;
			default:
			{
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.RTB_Exhaustion)
				{
					break;
				}
				if (activeUnitStatus != ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
				{
					if (activeUnitStatus != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
					{
						if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.Tasked)
						{
							if (IsEscort)
							{
								HeadToNearestEscortSubject();
								return;
							}
							if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
							{
								AssetSpecification(float_0);
								return;
							}
							if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
							{
								MineClearingMission mineClearingMission2 = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
								ObservableDictionary<string, UnguidedWeapon> Local_WeaponsDic2 = m_EventVal.ParentScen.UnguidedWeapons;
								List<ReferencePoint> Local_MissionArea2 = mineClearingMission2.Area;
								if (!m_EventVal.HasMineCountermeasures() && !m_EventVal.HasMineCounterWeapons())
								{
									if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
									{
										if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_30nm_Buffered, ref mineClearingMission2.Area_30nm_ChangeCheck, 30f, bool_1: false))
										{
											m_EventVal.Navigator.PlotCourseToArea(mineClearingMission2.Area);
										}
										m_EventVal.Navigator.FollowPlottedCourse(float_0);
									}
									else
									{
										m_EventVal.Navigator.PlotCourseToArea(mineClearingMission2.Area);
									}
									if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
									{
										return;
									}
									if (m_EventVal.Navigator.DisableDic(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
									{
										if (GetParentPlatform().IsTetheredROV)
										{
											m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
										}
										else
										{
											m_EventVal.SetThrottle(mineClearingMission2.StationThrottle_Submarine);
										}
									}
									else
									{
										m_EventVal.SetThrottle(mineClearingMission2.TransitThrottle_Submarine);
									}
									return;
								}
								TList<UnguidedWeapon> Local_LegitTargets2 = new TList<UnguidedWeapon>();
								Parallel.ForEach(m_EventVal.GetUnitSide().Contacts_NonAU, delegate(string theUW_ObjectID)
								{
									UnguidedWeapon value11 = null;
									Local_WeaponsDic2.TryGetValue(theUW_ObjectID, ref value11);
									if (!Information.IsNothing(value11) && value11.IsMine && value11.GetIsInsideThisArea(Local_MissionArea2, m_EventVal.ParentScen, bool_0: true))
									{
										Local_LegitTargets2.Add(value11);
									}
								});
								TList<UnguidedWeapon> tList = new TList<UnguidedWeapon>();
								IEnumerator enumerator = null;
								try
								{
									enumerator = Local_LegitTargets2.GetEnumerator();
									while (enumerator.MoveNext())
									{
										UnguidedWeapon unguidedWeapon = (UnguidedWeapon)enumerator.Current;
										if ((float)GetParentPlatform().MaxDepth <= unguidedWeapon.GetCurrentAltitude())
										{
											if (unguidedWeapon.GetCurrentAltitude() <= -5f)
											{
												if (GetParentPlatform().IsTetheredROV)
												{
													if (!((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon) <= (double)GetParentPlatform().ROVControlRadius_m / 1852.0 * 2.0))
													{
														continue;
													}
													ActiveUnit assignedHostUnit2 = m_EventVal.DockingOps.GetAssignedHostUnit();
													if (!Information.IsNothing(assignedHostUnit2) && ((double)Module_Unit.RangeToUnit_Horiz(assignedHostUnit2, GetParentPlatform()) * 1852.0 > (double)GetParentPlatform().ROVControlRadius_m || (double)Module_Unit.RangeToUnit_Horiz(assignedHostUnit2, unguidedWeapon) * 1852.0 > (double)GetParentPlatform().ROVControlRadius_m))
													{
														continue;
													}
												}
												if (!(Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon) <= 2f))
												{
													continue;
												}
												if (unguidedWeapon._CandidateProxy == null)
												{
													tList.Add(unguidedWeapon);
													continue;
												}
												if (m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon._CandidateProxy.ObjectID) && !m_EventVal.ParentScen.MineAllocation.Contains(new KeyValuePair<string, UnguidedWeapon>(unguidedWeapon._CandidateProxy.ObjectID, unguidedWeapon)))
												{
													unguidedWeapon._CandidateProxy = null;
												}
												if (unguidedWeapon._CandidateProxy != null && !unguidedWeapon._CandidateProxy.Equals(m_EventVal))
												{
													if (!unguidedWeapon._CandidateProxy.IsWeapon)
													{
														if (m_EventVal.GetUnitSide().Units.Contains(unguidedWeapon._CandidateProxy))
														{
															if (unguidedWeapon._CandidateProxy.AssignedMissionOrPackage() != null && unguidedWeapon._CandidateProxy.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
															{
																if (Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon) < Module_Unit.RangeToUnit_Horiz(unguidedWeapon._CandidateProxy, unguidedWeapon) && m_EventVal.GetCanSweepMine(unguidedWeapon))
																{
																	if (unguidedWeapon._CandidateProxy != null)
																	{
																		m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon._CandidateProxy.ObjectID);
																		if (unguidedWeapon._CandidateProxy.Navigator.HasPlottedCourse() && unguidedWeapon._CandidateProxy.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
																		{
																			unguidedWeapon._CandidateProxy.Navigator.RemoveWaypoint_Soft(unguidedWeapon._CandidateProxy.Navigator.PlottedCourse[0], bool_1: false);
																		}
																		else if (unguidedWeapon._CandidateProxy.Navigator.PlottedCourse.Count() <= 1)
																		{
																			unguidedWeapon._CandidateProxy.Navigator.ClearPlottedCourse();
																			unguidedWeapon._CandidateProxy.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
																		}
																	}
																	unguidedWeapon._CandidateProxy = null;
																}
															}
															else
															{
																unguidedWeapon._CandidateProxy = null;
															}
														}
														else
														{
															unguidedWeapon._CandidateProxy = null;
														}
													}
												}
												else if (unguidedWeapon._CandidateProxy != null && unguidedWeapon._CandidateProxy.Equals(m_EventVal))
												{
													tList.Add(unguidedWeapon);
													if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
													{
														m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon);
													}
												}
												if (unguidedWeapon._CandidateProxy == null)
												{
													tList.Add(unguidedWeapon);
												}
											}
											else if (unguidedWeapon._CandidateProxy != null && unguidedWeapon._CandidateProxy.IsSubmarine && m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon._CandidateProxy.ObjectID))
											{
												m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon._CandidateProxy.ObjectID);
												unguidedWeapon._CandidateProxy = null;
											}
										}
										else if (unguidedWeapon._CandidateProxy != null && unguidedWeapon._CandidateProxy.IsSubmarine && m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon._CandidateProxy.ObjectID))
										{
											m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon._CandidateProxy.ObjectID);
											unguidedWeapon._CandidateProxy = null;
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
								Local_LegitTargets2 = tList;
								UnguidedWeapon unguidedWeapon2 = null;
								if (Local_LegitTargets2.Count > 0 && m_EventVal.MineCountermeasures.Count > 0)
								{
									while (Local_LegitTargets2.Count > 0)
									{
										unguidedWeapon2 = (from unguidedWeapon_0 in Local_LegitTargets2.ToList()
											where unguidedWeapon_0 != null && m_EventVal.GetCanSweepMine(unguidedWeapon_0)
											orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0)
											select unguidedWeapon_0).ElementAtOrDefault(0);
										if (unguidedWeapon2 == null || unguidedWeapon2._CandidateProxy == null || unguidedWeapon2._CandidateProxy.Equals(m_EventVal))
										{
											break;
										}
										Local_LegitTargets2.Remove(unguidedWeapon2);
									}
								}
								else
								{
									m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
								}
								if (Local_LegitTargets2.Count > 0 && unguidedWeapon2 != null)
								{
									float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon2);
									if (m_EventVal.HasMineDisposalCharges)
									{
										ManouverToNeutralizeMine(unguidedWeapon2, num);
									}
									else
									{
										ManouverToSweepMine(unguidedWeapon2, num);
									}
									unguidedWeapon2._CandidateProxy = m_EventVal;
									if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
									{
										UnguidedWeapon obj = null;
										if (!m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref obj) || !unguidedWeapon2.Equals(obj))
										{
											m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
											m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon2);
										}
									}
									else
									{
										m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon2);
									}
									Submarine submarine = (Submarine)m_EventVal;
									if (submarine.Type != Submarine._SubmarineType.ROV && submarine.Type != Submarine._SubmarineType.UUV)
									{
										if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
										{
											if (m_EventVal.Navigator.DisableDic(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
											{
												m_EventVal.SetThrottle(mineClearingMission2.StationThrottle_Submarine);
											}
											else
											{
												m_EventVal.SetThrottle(mineClearingMission2.TransitThrottle_Submarine);
											}
										}
									}
									else
									{
										if ((double)num <= 0.5)
										{
											if ((double)num <= 0.1)
											{
												m_EventVal.DesiredSpeed = Math.Max(1f, num * 10f);
											}
											else
											{
												m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
											}
										}
										else if (submarine.IsTetheredROV)
										{
											m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
										}
										else
										{
											m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
										}
										m_EventVal.DesiredAltitude = unguidedWeapon2.GetCurrentAltitude();
									}
									m_EventVal.Navigator.FollowPlottedCourse(float_0);
									return;
								}
								if (m_EventVal.IsGroupMember())
								{
									if (m_EventVal.IsGroupLead())
									{
										if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
										{
											if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_30nm_Buffered, ref mineClearingMission2.Area_30nm_ChangeCheck, 30f, bool_1: false))
											{
												m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(mineClearingMission2.Area);
											}
											m_EventVal.Navigator.FollowPlottedCourse(float_0);
										}
										else
										{
											m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(mineClearingMission2.Area);
										}
									}
									else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
									{
										m_EventVal.Navigator.HeadToFormationStation(float_0);
									}
								}
								else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
								{
									if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_30nm_Buffered, ref mineClearingMission2.Area_30nm_ChangeCheck, 30f, bool_1: false))
									{
										m_EventVal.Navigator.PlotCourseToArea(mineClearingMission2.Area);
									}
									m_EventVal.Navigator.FollowPlottedCourse(float_0);
								}
								else if (GetParentPlatform().IsTetheredROV)
								{
									ActiveUnit assignedHostUnit3 = GetParentPlatform().DockingOps.GetAssignedHostUnit();
									if (!Information.IsNothing(assignedHostUnit3))
									{
										try
										{
											float num10 = Module_Unit.RangeToUnit_Horiz(m_EventVal, assignedHostUnit3);
											if (GetParentPlatform().IsTetheredROV && (double)num10 * 1852.0 > (double)((Submarine)m_EventVal).ROVControlRadius_m)
											{
												GetParentPlatform().SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(GetParentPlatform(), assignedHostUnit3));
											}
											else if (m_EventVal.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
											{
												float float_ = (GetParentPlatform().IsTetheredROV ? ((float)((double)GetParentPlatform().ROVControlRadius_m / 1852.0)) : ((GetParentPlatform().Sensors_Cached.Length == 0) ? 5f : GetParentPlatform().Sensors_Cached[0].maxRange));
												float num11 = assignedHostUnit3.CurrentHeading;
												if (num11 - 45f <= 0f)
												{
													num11 += 360f;
												}
												int int_ = Math2.InsertClass(GameGeneral.LockRandom_0.Next((int)Math.Round(num11 - 45f), (int)Math.Round(num11 + 46f)));
												double double_ = 0.0;
												double double_2 = 0.0;
												Geodesic_EdWilliams.CalcPoint_Williams(assignedHostUnit3.GetLongitude(), assignedHostUnit3.GetLatitude(), ref double_, ref double_2, float_, int_);
												GetParentPlatform().SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(GetParentPlatform().GetLatitude(), GetParentPlatform().GetLongitude(), double_2, double_));
											}
											m_EventVal.Navigator.FollowPlottedCourse(float_0);
										}
										catch (Exception projectError)
										{
											ProjectData.SetProjectError(projectError);
											ProjectData.ClearProjectError();
										}
									}
								}
								else
								{
									m_EventVal.Navigator.PlotCourseToArea(mineClearingMission2.Area);
								}
								if (m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
								{
									return;
								}
								if (m_EventVal.Navigator.DisableDic(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
								{
									if (GetParentPlatform().IsTetheredROV)
									{
										m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
									}
									else if (GetParentPlatform().Type == Submarine._SubmarineType.UUV)
									{
										m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
									}
									else
									{
										m_EventVal.SetThrottle(mineClearingMission2.StationThrottle_Submarine);
									}
								}
								else
								{
									m_EventVal.SetThrottle(mineClearingMission2.TransitThrottle_Submarine);
								}
								return;
							}
						}
						if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnPatrol)
						{
							if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
							{
								activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
							{
								Patrol patrol2 = (Patrol)m_EventVal.AssignedMissionOrPackage();
								if (Information.IsNothing(patrol2))
								{
									activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
								}
								else
								{
									if (m_EventVal.IsGroupMember())
									{
										if (m_EventVal.IsGroupLead())
										{
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
										else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
										{
											m_EventVal.Navigator.HeadToFormationStation(float_0);
										}
									}
									else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
									{
										if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_30nm_Buffered, ref patrol2.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
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
										m_EventVal.Kinematics.AdjustSpeedForCavitation();
									}
								}
								int value2 = (int)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
								if (!PostSpecification(value2, bool_0: false, bool_1: false) && !GetParentPlatform().Kinematics.DesiredAltitudeOverride)
								{
									RunSpecification(float_0);
								}
							}
						}
						if (activeUnitStatus != ActiveUnit._ActiveUnitStatus.OnSupportMission)
						{
							if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnFerryMission)
							{
								if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
								{
									activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
								}
								else if (m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
								{
									FerryMission ferryMission = (FerryMission)m_EventVal.AssignedMissionOrPackage();
									if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && ferryMission.FerryThrottle_Submarine.HasValue)
									{
										_ = ferryMission.FerryThrottle_Submarine.Value;
									}
									if (m_EventVal.Kinematics.DesiredAltitudeOverride)
									{
										_ = m_EventVal.DesiredAltitude;
									}
									else if (Information.IsNothing(ferryMission.FerryAltitude_Submarine))
									{
										GetParentPlatform().Kinematics.GetMinimumAltitude();
									}
									else
									{
										_ = ferryMission.FerryAltitude_Submarine.Value;
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
										m_EventVal.ParentScen.AddMessage("潜艇：" + m_EventVal.Name + text + "被分配到转载任务但它不能停靠在目的地。取消分配潜艇并返回最近的基地。", m_EventVal.Name + " 无法停靠到目标；取消", LoggedMessage.MessageType.DockingOps, 0, null, m_EventVal.GetUnitSide());
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
							if (m_EventVal.IsGroupMember())
							{
								if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
								{
									m_EventVal.Navigator.HeadToFormationStation(float_0);
								}
								int value3 = (int)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
								PostSpecification(value3, bool_0: false, bool_1: false);
							}
							else if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
							{
								if (!m_EventVal.Navigator.HasPlottedCourse())
								{
									m_EventVal.DesiredSpeed = 0f;
								}
								if (m_EventVal.Kinematics.DesiredAltitudeOverride)
								{
									FollowDepthPreset(bool_0: true);
								}
							}
						}
						else if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()))
						{
							activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						else
						{
							if (m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Support)
							{
								return;
							}
							if (m_EventVal.IsGroupMember())
							{
								if (m_EventVal.IsGroupLead())
								{
									m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
									return;
								}
								if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
								{
									m_EventVal.Navigator.HeadToFormationStation(float_0);
								}
								int value4 = (int)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
								PostSpecification(value4, bool_0: false, bool_1: false);
							}
							else
							{
								m_EventVal.Navigator.FollowSupportMissionCourse(float_0, m_EventVal.Navigator.IsInSupportTransit);
							}
						}
					}
					else
					{
						if (PrimaryTarget == null)
						{
							return;
						}
						Contact_Base.ContactType type = PrimaryTarget.Type;
						if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
						{
							ManouverTowardsTarget(float_0);
						}
						float? num12 = null;
						float num13 = float.MaxValue;
						int value5 = (int)m_EventVal.Doctrine.GetRechargePercentageAttack(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
						Patrol patrol3 = null;
						if (!PostSpecification(value5, bool_0: true, bool_1: true) && !m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
						{
							ActiveUnit.Throttle? throttle = null;
							if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
							{
								patrol3 = (Patrol)m_EventVal.AssignedMissionOrPackage();
								if (!Information.IsNothing(patrol3.AttackThrottle_Submarine))
								{
									num12 = patrol3.AttackDistance_Submarine;
									if (Information.IsNothing(num12))
									{
										throttle = patrol3.AttackThrottle_Submarine;
									}
									else
									{
										num13 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
										throttle = ((num12.HasValue ? new bool?(num13 > num12.GetValueOrDefault()) : null).GetValueOrDefault() ? new ActiveUnit.Throttle?(patrol3.TransitThrottle_Submarine) : patrol3.AttackThrottle_Submarine);
									}
								}
							}
							if (Information.IsNothing(throttle))
							{
								if (!PrimaryTarget.IsShipContact && !PrimaryTarget.IsSubmergedContact)
								{
									if (!strategyProxy)
									{
										m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
									}
								}
								else
								{
									int? num14 = MinimumSpeedToInterceptTarget(PrimaryTarget.ActualUnit);
									if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
									{
										float num15 = Math.Abs(MathFunctions.GetRelativeBearing(Module_Unit.BearingToUnit_True(GetParentPlatform(), PrimaryTarget), PrimaryTarget.CurrentHeading));
										if (num15 < 20f)
										{
											if (num14.HasValue)
											{
												m_EventVal.DesiredSpeed = Math.Max(num14.Value, PrimaryTarget.CurrentSpeed * 2f + 1f);
											}
											else
											{
												m_EventVal.DesiredSpeed = PrimaryTarget.CurrentSpeed * 2f + 1f;
											}
											m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)));
										}
										else if (num15 < 90f)
										{
											if (num14.HasValue)
											{
												m_EventVal.DesiredSpeed = Math.Max(num14.Value, PrimaryTarget.CurrentSpeed * 2f + 1f);
											}
											else
											{
												m_EventVal.DesiredSpeed = (float)((double)PrimaryTarget.CurrentSpeed * 1.5) + 1f;
											}
											m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)));
										}
										else if (num14.HasValue)
										{
											m_EventVal.DesiredSpeed = num14.Value;
											m_EventVal.SetThrottle(m_EventVal.Kinematics.GetThrottleSuitableForThisSpeed(m_EventVal.GetCurrentAltitude(), (int)Math.Round(m_EventVal.DesiredSpeed)));
										}
										else
										{
											m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
										}
									}
									else if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
									{
										if (Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading) <= 0f)
										{
											m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
										}
										else
										{
											m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
										}
									}
									else
									{
										m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
									}
								}
							}
							else
							{
								m_EventVal.SetThrottle(throttle.Value);
							}
						}
						if (!m_EventVal.Kinematics.DesiredAltitudeOverride && GetParentPlatform().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
						{
							float? num16 = null;
							if (!Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) && m_EventVal.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
							{
								if (Information.IsNothing(patrol3))
								{
									patrol3 = (Patrol)m_EventVal.AssignedMissionOrPackage();
								}
								if (!Information.IsNothing(patrol3.AttackDepth_Submarine))
								{
									if (Information.IsNothing(num12))
									{
										num12 = patrol3.AttackDistance_Submarine;
									}
									if (Information.IsNothing(num12))
									{
										num16 = patrol3.AttackDepth_Submarine;
									}
									else
									{
										if (num13 == float.MaxValue)
										{
											num13 = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
										}
										num16 = ((num12.HasValue ? new bool?(num13 > num12.GetValueOrDefault()) : null).GetValueOrDefault() ? patrol3.TransitDepth_Submarine : patrol3.AttackDepth_Submarine);
									}
								}
							}
							if (Information.IsNothing(num16))
							{
								if ((float)m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.ThrottleSetting, bool_0: false) < m_EventVal.DesiredSpeed)
								{
									if (m_EventVal.TimeSinceLastThreatDetection_ESM < 1800f && !ListSpecification(bool_0: false, null))
									{
										m_EventVal.DesiredAltitude = -40f;
									}
									else
									{
										int num17 = 1;
										do
										{
											ActiveUnit.Throttle throttle_2 = (ActiveUnit.Throttle)num17;
											float? num2 = ((Submarine_Kinematics)m_EventVal.Kinematics).MinimumDepthToAchieveThisSpeed(m_EventVal.DesiredSpeed, throttle_2);
											if (num2.HasValue)
											{
												m_EventVal.SetThrottle(throttle_2);
												float? num3 = num2;
												if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() < -40f) : null).GetValueOrDefault())
												{
													m_EventVal.DesiredAltitude = num2.Value;
												}
											}
											num17++;
										}
										while (num17 <= 4);
									}
								}
								else
								{
									switch (PrimaryTarget.Type)
									{
									case Contact_Base.ContactType.Submarine:
										if (PrimaryTarget.AltitudeIsKnown)
										{
											if (PrimaryTarget.GetCurrentAltitude() <= -40f)
											{
												m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
											}
											else
											{
												m_EventVal.DesiredAltitude = -40f;
											}
										}
										else
										{
											m_EventVal.DesiredAltitude = -40f;
										}
										break;
									default:
										m_EventVal.DesiredAltitude = -40f;
										break;
									case Contact_Base.ContactType.Surface:
										m_EventVal.DesiredAltitude = -40f;
										break;
									}
								}
								Weapon weapon_ = null;
								OptimizeAltSpeedForNextEngagement(float_0, ref weapon_);
							}
							else
							{
								float value6 = num16.Value;
								if (!(Math.Round(value6) < -20.0) && !ListSpecification(bool_0: false, null))
								{
									m_EventVal.DesiredAltitude = -40f;
								}
								else if (!strategyProxy)
								{
									m_EventVal.DesiredAltitude = value6;
								}
							}
						}
						else if (GetParentPlatform().DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
						{
							if (ListSpecification(bool_0: false, null))
							{
								if (Math.Round(m_EventVal.DesiredAltitude) < -20.0)
								{
									m_EventVal.DesiredAltitude = -20f;
								}
							}
							else
							{
								Weapon weapon_2 = null;
								OptimizeAltSpeedForNextEngagement(float_0, ref weapon_2);
							}
						}
						else
						{
							FollowDepthPreset(bool_0: true);
						}
					}
					return;
				}
				if (m_EventVal.IsOnActivePatrol && !m_EventVal.Navigator.NextWaypointIsManual)
				{
					if (m_EventVal.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && m_EventVal.Navigator.PlottedCourse.Length == 1 && m_EventVal.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
					{
						m_EventVal.Navigator.ClearPlottedCourse();
						return;
					}
					Patrol patrol4 = (Patrol)m_EventVal.AssignedMissionOrPackage();
					if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref patrol4.PatrolArea, ref patrol4.PatrolArea_30nm_Buffered, ref patrol4.PatrolArea_30nm_ChangeCheck, 30f, bool_1: false))
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
					m_EventVal.Status = m_EventVal.m_SchemaVal;
					return;
				}
				if (GetParentPlatform().IsOnActiveMiningMission)
				{
					AssetSpecification(float_0);
					return;
				}
				if (m_EventVal.Navigator.SprintDrift)
				{
					m_EventVal.Navigator.PerformSprintDrift(float_0);
				}
				bool flag2 = false;
				MineClearingMission mineClearingMission3 = null;
				if (GetParentPlatform().IsOnActivePatrol)
				{
					Patrol patrol5 = (Patrol)m_EventVal.AssignedMissionOrPackage();
					flag2 = (m_EventVal.Navigator.DisableDic(ref patrol5.PatrolArea, ref patrol5.PatrolArea_2nm_Buffered, ref patrol5.PatrolArea_2nm_ChangeCheck, 2, bool_1: false, bool_2: false) ? true : false);
				}
				else if (GetParentPlatform().IsOnActiveMineClearingMission)
				{
					mineClearingMission3 = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
					flag2 = (m_EventVal.Navigator.DisableDic(ref mineClearingMission3.Area, ref mineClearingMission3.Area_2nm_Buffered, ref mineClearingMission3.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false) ? true : false);
				}
				if (GetParentPlatform().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries && !m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && !m_EventVal.Navigator.SprintDrift)
				{
					if (GetParentPlatform().IsOnActivePatrol)
					{
						Patrol patrol6 = (Patrol)m_EventVal.AssignedMissionOrPackage();
						if (flag2)
						{
							m_EventVal.SetThrottle(patrol6.StationThrottle_Submarine);
						}
						else
						{
							m_EventVal.SetThrottle(patrol6.TransitThrottle_Submarine);
						}
					}
					else if (GetParentPlatform().IsOnActiveMineClearingMission)
					{
						if (flag2)
						{
							if (GetParentPlatform().IsTetheredROV)
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
							}
							else
							{
								m_EventVal.SetThrottle(mineClearingMission3.StationThrottle_Submarine);
							}
						}
						else
						{
							m_EventVal.SetThrottle(mineClearingMission3.TransitThrottle_Submarine);
						}
					}
					else if (GetParentPlatform().IsOnActiveFerryMission)
					{
						FerryMission ferryMission2 = (FerryMission)GetParentPlatform().AssignedMissionOrPackage();
						if (!GetParentPlatform().Kinematics.DesiredSpeedOverride.HasValue)
						{
							if (ferryMission2.FerryThrottle_Submarine.HasValue)
							{
								GetParentPlatform().SetThrottle(ferryMission2.FerryThrottle_Submarine.Value);
							}
							else
							{
								GetParentPlatform().SetThrottle(ActiveUnit.Throttle.Cruise);
							}
						}
					}
					else if (GetParentPlatform().IsTetheredROV)
					{
						m_EventVal.SetThrottle(ActiveUnit.Throttle.Flank);
					}
					else if (!m_EventVal.Navigator.SprintDrift)
					{
						if (GetParentPlatform().IsNuke)
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
							m_EventVal.Kinematics.AdjustSpeedForCavitation();
						}
						else
						{
							FuelRec fuelRec = (from theRec in m_EventVal.Fuel_ReadOnly
								where theRec.FuelType == FuelRec._FuelType.Battery
								select (theRec)).ElementAtOrDefault(0);
							if (Information.IsNothing(fuelRec))
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
								m_EventVal.Kinematics.AdjustSpeedForCavitation();
							}
							else if ((double)fuelRec.PercentFull < 0.0001)
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.FullStop);
								m_EventVal.Kinematics.AdjustSpeedForCavitation();
							}
							else if (fuelRec.PercentFull < 1f)
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Loiter);
								m_EventVal.Kinematics.AdjustSpeedForCavitation();
							}
							else
							{
								m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
								m_EventVal.Kinematics.AdjustSpeedForCavitation();
							}
						}
					}
				}
				int value7 = (int)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
				if (GetParentPlatform().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
				{
					if (m_EventVal.Kinematics.DesiredAltitudeOverride)
					{
						FollowDepthPreset(bool_0: true);
					}
					else if (m_EventVal.IsOnActivePatrol)
					{
						if (flag2)
						{
							if (!PostSpecification(value7, bool_0: false, bool_1: false))
							{
								Patrol patrol7 = (Patrol)m_EventVal.AssignedMissionOrPackage();
								if (patrol7.StationDepth_Submarine.HasValue)
								{
									int num4 = (int)Math.Round(patrol7.StationDepth_Submarine.Value);
									if (num4 >= -20 && !ListSpecification(bool_0: false, null))
									{
										m_EventVal.DesiredAltitude = -40f;
									}
									else
									{
										m_EventVal.DesiredAltitude = num4;
									}
								}
								else
								{
									RunSpecification(float_0);
								}
							}
						}
						else if (!PostSpecification(value7, bool_0: false, bool_1: false))
						{
							Patrol patrol8 = (Patrol)m_EventVal.AssignedMissionOrPackage();
							if (patrol8.TransitDepth_Submarine.HasValue)
							{
								int num5 = (int)Math.Round(patrol8.TransitDepth_Submarine.Value);
								if (num5 >= -20 && !ListSpecification(bool_0: false, null))
								{
									m_EventVal.DesiredAltitude = (int)Math.Round(OverLayerDepth(GetParentPlatform()));
								}
								else
								{
									m_EventVal.DesiredAltitude = num5;
								}
							}
							else
							{
								GetParentPlatform().DesiredAltitude = OverLayerDepth(GetParentPlatform());
							}
						}
					}
					else if (GetParentPlatform().IsOnActiveMineClearingMission)
					{
						if (flag2)
						{
							if (!PostSpecification(value7, bool_0: false, bool_1: false))
							{
								if (mineClearingMission3.StationDepth_Submarine.HasValue)
								{
									int num6 = (int)Math.Round(mineClearingMission3.StationDepth_Submarine.Value);
									if (num6 >= -20 && !ListSpecification(bool_0: false, null))
									{
										m_EventVal.DesiredAltitude = -40f;
									}
									else
									{
										m_EventVal.DesiredAltitude = num6;
									}
								}
								else
								{
									m_EventVal.DesiredAltitude = -20f;
								}
							}
						}
						else if (!PostSpecification(value7, bool_0: false, bool_1: false))
						{
							if (mineClearingMission3.TransitDepth_Submarine.HasValue)
							{
								int num7 = (int)Math.Round(mineClearingMission3.TransitDepth_Submarine.Value);
								if (num7 >= -20 && !ListSpecification(bool_0: false, null))
								{
									m_EventVal.DesiredAltitude = (int)Math.Round(OverLayerDepth(GetParentPlatform()));
								}
								else
								{
									m_EventVal.DesiredAltitude = num7;
								}
							}
							else
							{
								GetParentPlatform().DesiredAltitude = OverLayerDepth(GetParentPlatform());
							}
						}
					}
					else if (GetParentPlatform().IsOnActiveFerryMission)
					{
						FerryMission ferryMission3 = (FerryMission)GetParentPlatform().AssignedMissionOrPackage();
						if (!PostSpecification(value7, bool_0: false, bool_1: false))
						{
							if (ferryMission3.FerryAltitude_Submarine.HasValue)
							{
								int num8 = (int)Math.Round(ferryMission3.FerryAltitude_Submarine.Value);
								if (num8 >= -20 && !ListSpecification(bool_0: false, null))
								{
									GetParentPlatform().DesiredAltitude = (int)Math.Round(OverLayerDepth(GetParentPlatform()));
								}
								else
								{
									GetParentPlatform().DesiredAltitude = num8;
								}
							}
							else
							{
								GetParentPlatform().DesiredAltitude = OverLayerDepth(GetParentPlatform());
							}
						}
					}
					else if (!GetParentPlatform().Kinematics.DesiredAltitudeOverride && !PostSpecification(value7, bool_0: true, bool_1: false))
					{
						GetParentPlatform().DesiredAltitude = Math.Min(-20f, OverLayerDepth(GetParentPlatform()));
					}
				}
				if (Information.IsNothing(m_EventVal.AssignedMissionOrPackage()) || m_EventVal.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
				{
					return;
				}
				if (m_EventVal.ParentScen.FifteenthSecondIsChangingOnThisPulse)
				{
					MineClearingMission Local_myMission = (MineClearingMission)m_EventVal.AssignedMissionOrPackage();
					List<ReferencePoint> Local_MissionArea = Local_myMission.Area;
					TList<UnguidedWeapon> Local_LegitTargets = new TList<UnguidedWeapon>();
					ObservableDictionary<string, UnguidedWeapon> Local_WeaponsDic = m_EventVal.ParentScen.UnguidedWeapons;
					if (!m_EventVal.HasMineCountermeasures() && !m_EventVal.HasMineCounterWeapons())
					{
						if (GetParentPlatform().IsTetheredROV)
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
						}
						else
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
					}
					else
					{
						Parallel.ForEach(m_EventVal.GetUnitSide().Contacts_NonAU, delegate(string theUW_ObjectID)
						{
							UnguidedWeapon value10 = null;
							Local_WeaponsDic.TryGetValue(theUW_ObjectID, ref value10);
							if (!Information.IsNothing(value10) && value10.IsMine)
							{
								if (value10.GetIsInsideThisArea(Local_MissionArea, m_EventVal.ParentScen, bool_0: true))
								{
									Local_LegitTargets.Add(value10);
								}
								else if (Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && m_EventVal.Navigator.DisableDic(ref Local_MissionArea, ref Local_myMission.Area_2nm_Buffered, ref Local_myMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
								{
									Local_LegitTargets.Add(value10);
								}
							}
						});
						TList<UnguidedWeapon> tList2 = new TList<UnguidedWeapon>();
						IEnumerator enumerator2 = null;
						try
						{
							enumerator2 = Local_LegitTargets.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								UnguidedWeapon unguidedWeapon3 = (UnguidedWeapon)enumerator2.Current;
								if ((float)GetParentPlatform().MaxDepth <= unguidedWeapon3.GetCurrentAltitude())
								{
									if (unguidedWeapon3.GetCurrentAltitude() <= -5f)
									{
										if (GetParentPlatform().IsTetheredROV)
										{
											if (!((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon3) <= (double)GetParentPlatform().ROVControlRadius_m / 1852.0 * 2.0))
											{
												continue;
											}
											ActiveUnit assignedHostUnit4 = m_EventVal.DockingOps.GetAssignedHostUnit();
											if (!Information.IsNothing(assignedHostUnit4) && ((double)Module_Unit.RangeToUnit_Horiz(assignedHostUnit4, GetParentPlatform()) * 1852.0 > (double)(GetParentPlatform().ROVControlRadius_m - 20) || (double)Module_Unit.RangeToUnit_Horiz(assignedHostUnit4, unguidedWeapon3) * 1852.0 > (double)(GetParentPlatform().ROVControlRadius_m - 20)))
											{
												continue;
											}
										}
										if (!(Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon3) <= 2f))
										{
											continue;
										}
										if (unguidedWeapon3._CandidateProxy == null)
										{
											tList2.Add(unguidedWeapon3);
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
														if (Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon3) < Module_Unit.RangeToUnit_Horiz(unguidedWeapon3._CandidateProxy, unguidedWeapon3) && m_EventVal.GetCanSweepMine(unguidedWeapon3))
														{
															if (unguidedWeapon3._CandidateProxy != null)
															{
																m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon3._CandidateProxy.ObjectID);
																if (unguidedWeapon3._CandidateProxy.Navigator.HasPlottedCourse() && unguidedWeapon3._CandidateProxy.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
																{
																	unguidedWeapon3._CandidateProxy.Navigator.RemoveWaypoint_Soft(unguidedWeapon3._CandidateProxy.Navigator.PlottedCourse[0], bool_1: false);
																}
																else if (unguidedWeapon3._CandidateProxy.Navigator.PlottedCourse.Count() <= 1)
																{
																	unguidedWeapon3._CandidateProxy.Navigator.ClearPlottedCourse();
																	unguidedWeapon3._CandidateProxy.Navigator.PlotCourseToStationArea(float_0, bool_1: false);
																}
															}
															unguidedWeapon3._CandidateProxy = null;
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
											tList2.Add(unguidedWeapon3);
											if (!m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
											{
												m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon3);
											}
										}
										if (unguidedWeapon3._CandidateProxy == null)
										{
											tList2.Add(unguidedWeapon3);
										}
									}
									else if (unguidedWeapon3._CandidateProxy != null && unguidedWeapon3._CandidateProxy.IsSubmarine && m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon3._CandidateProxy.ObjectID))
									{
										m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon3._CandidateProxy.ObjectID);
										unguidedWeapon3._CandidateProxy = null;
									}
								}
								else if (unguidedWeapon3._CandidateProxy != null && unguidedWeapon3._CandidateProxy.IsSubmarine && m_EventVal.ParentScen.MineAllocation.ContainsKey(unguidedWeapon3._CandidateProxy.ObjectID))
								{
									m_EventVal.ParentScen.MineAllocation.Remove(unguidedWeapon3._CandidateProxy.ObjectID);
									unguidedWeapon3._CandidateProxy = null;
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
						Local_LegitTargets = tList2;
						UnguidedWeapon unguidedWeapon4 = null;
						if (Local_LegitTargets.Count <= 0)
						{
							UnguidedWeapon unguidedWeapon5 = null;
							if (m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref unguidedWeapon5))
							{
								if (unguidedWeapon5 != null && Operators.CompareString(unguidedWeapon5._CandidateProxy.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
								{
									unguidedWeapon5._CandidateProxy = null;
								}
								m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
							}
						}
						else
						{
							while (Local_LegitTargets.Count > 0)
							{
								unguidedWeapon4 = (from unguidedWeapon_0 in Local_LegitTargets.ToList()
									where !Information.IsNothing(unguidedWeapon_0) && m_EventVal.GetCanSweepMine(unguidedWeapon_0)
									orderby Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0)
									select unguidedWeapon_0).ElementAtOrDefault(0);
								if (unguidedWeapon4 == null || unguidedWeapon4._CandidateProxy == null || unguidedWeapon4._CandidateProxy.Equals(m_EventVal))
								{
									break;
								}
								Local_LegitTargets.Remove(unguidedWeapon4);
							}
							if (unguidedWeapon4 == null)
							{
								UnguidedWeapon unguidedWeapon6 = null;
								if (m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref unguidedWeapon6))
								{
									if (unguidedWeapon6 != null && Operators.CompareString(unguidedWeapon6._CandidateProxy.ObjectID, m_EventVal.ObjectID, TextCompare: false) == 0)
									{
										unguidedWeapon6._CandidateProxy = null;
									}
									m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
								}
							}
						}
						if (Local_LegitTargets.Count > 0 && unguidedWeapon4 != null)
						{
							float num9 = Module_Unit.RangeToUnit_Horiz(m_EventVal, unguidedWeapon4);
							if (m_EventVal.HasMineDisposalCharges)
							{
								ManouverToNeutralizeMine(unguidedWeapon4, num9);
							}
							else
							{
								ManouverToSweepMine(unguidedWeapon4, num9);
							}
							unguidedWeapon4._CandidateProxy = m_EventVal;
							if (m_EventVal.ParentScen.MineAllocation.ContainsKey(m_EventVal.ObjectID))
							{
								UnguidedWeapon obj2 = null;
								if (!m_EventVal.ParentScen.MineAllocation.TryGetValue(m_EventVal.ObjectID, ref obj2) || !unguidedWeapon4.Equals(obj2))
								{
									m_EventVal.ParentScen.MineAllocation.Remove(m_EventVal.ObjectID);
									m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon4);
								}
							}
							else
							{
								m_EventVal.ParentScen.MineAllocation.Add(m_EventVal.ObjectID, unguidedWeapon4);
							}
							if (GetParentPlatform().Type != Submarine._SubmarineType.ROV && GetParentPlatform().Type != Submarine._SubmarineType.UUV)
							{
								if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue)
								{
									if (m_EventVal.Navigator.DisableDic(ref Local_myMission.Area, ref Local_myMission.Area_2nm_Buffered, ref Local_myMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
									{
										m_EventVal.SetThrottle(Local_myMission.StationThrottle_Submarine);
									}
									else
									{
										m_EventVal.SetThrottle(Local_myMission.TransitThrottle_Submarine);
									}
								}
							}
							else
							{
								if ((double)num9 <= 0.5)
								{
									if ((double)num9 <= 0.1)
									{
										m_EventVal.DesiredSpeed = Math.Max(1f, num9 * 10f);
									}
									else
									{
										m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
									}
								}
								else if (GetParentPlatform().IsTetheredROV)
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
								}
								else
								{
									m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
								}
								m_EventVal.DesiredAltitude = unguidedWeapon4.GetCurrentAltitude();
							}
							if (GetParentPlatform().IsTetheredROV)
							{
								ActiveUnit assignedHostUnit5 = m_EventVal.DockingOps.GetAssignedHostUnit();
								if (!Information.IsNothing(assignedHostUnit5))
								{
									if (Module_Unit.RangeToUnit_Horiz(assignedHostUnit5, unguidedWeapon4) < num9)
									{
										assignedHostUnit5.DesiredSpeed = 0f;
									}
									else if ((double)Module_Unit.RangeToUnit_Horiz(m_EventVal, assignedHostUnit5) * 1852.0 < (double)(GetParentPlatform().ROVControlRadius_m - 20))
									{
										if (assignedHostUnit5.CurrentSpeed > m_EventVal.CurrentSpeed)
										{
											assignedHostUnit5.DesiredSpeed = m_EventVal.CurrentSpeed;
										}
									}
									else if ((float)m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false) >= 5f)
									{
										assignedHostUnit5.DesiredSpeed = (float)(0.5 * (double)assignedHostUnit5.Kinematics.GetMaximumSpeed(assignedHostUnit5.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false));
									}
								}
								m_EventVal.Navigator.bool_0 = false;
							}
						}
						else if (GetParentPlatform().IsTetheredROV)
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
						}
						else
						{
							m_EventVal.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
					}
				}
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				return;
			}
			case ActiveUnit._ActiveUnitStatus.RTB:
			case ActiveUnit._ActiveUnitStatus.RTB_Manual:
			case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
				break;
			}
			switch (m_EventVal.DockingOps.Condition)
			{
			case ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries:
				m_EventVal.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
				ReturnToBase(float_0);
				break;
			case ActiveUnit_DockingOps._DockingOpsCondition.RTB:
				if (m_EventVal.IsGroupMember())
				{
					m_EventVal.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
				}
				ReturnToBase(float_0);
				if (m_EventVal != null)
				{
					int value9 = (int)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
					PostSpecification(value9, bool_0: true, bool_1: false);
				}
				break;
			case ActiveUnit_DockingOps._DockingOpsCondition.Underway:
			{
				ReturnToBase(float_0);
				int value8 = (int)m_EventVal.Doctrine.GetRechargePercentagePatrol(m_EventVal.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
				PostSpecification(value8, bool_0: true, bool_1: false);
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100825", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AssetSpecification(float float_0)
	{
		MiningMission miningMission = (MiningMission)m_EventVal.AssignedMissionOrPackage();
		if (m_EventVal.IsGroupMember())
		{
			if (m_EventVal.IsGroupLead())
			{
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
				{
					if (!m_EventVal.GetParentGroup().Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
					{
						m_EventVal.GetParentGroup().Navigator.PlotCourseToArea(miningMission.Area);
						if (m_EventVal.AI.MiningInfo != null)
						{
							m_EventVal.AI.MiningInfo = null;
						}
					}
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
			else if (m_EventVal.CommStuff.IsConnectedToSideNetwork)
			{
				m_EventVal.Navigator.HeadToFormationStation(float_0);
			}
		}
		else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
		{
			if (!m_EventVal.Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, bool_1: false))
			{
				m_EventVal.Navigator.PlotCourseToArea(miningMission.Area);
				if (m_EventVal.AI.MiningInfo != null)
				{
					m_EventVal.AI.MiningInfo = null;
				}
			}
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
		if (Information.IsNothing(GetParentPlatform().Kinematics.DesiredSpeedOverride))
		{
			if (m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
			{
				m_EventVal.SetThrottle(miningMission.StationThrottle_Submarine);
			}
			else
			{
				m_EventVal.SetThrottle(miningMission.TransitThrottle_Submarine);
			}
		}
		if (GetParentPlatform().Kinematics.DesiredAltitudeOverride)
		{
			if (!GetParentPlatform().IsNuke && !ListSpecification(bool_0: false, null))
			{
				if (GetParentPlatform().DesiredAltitude < -20f)
				{
					if (Math.Round(Math.Min(-20f, OverLayerDepth(GetParentPlatform()))) < -20.0)
					{
						GetParentPlatform().DesiredAltitude = Math.Min(-20f, OverLayerDepth(GetParentPlatform()));
					}
				}
				else
				{
					GetParentPlatform().Kinematics.DesiredAltitudeOverride = false;
				}
			}
			else
			{
				FollowDepthPreset(bool_0: true);
			}
		}
		else if (m_EventVal.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, bool_1: false, bool_2: false))
		{
			if (miningMission.StationDepth_Submarine.HasValue)
			{
				float value = miningMission.StationDepth_Submarine.Value;
				if (!(Math.Round(value) < -20.0) && !ListSpecification(bool_0: false, null))
				{
					m_EventVal.DesiredAltitude = -40f;
				}
				else
				{
					m_EventVal.DesiredAltitude = value;
				}
			}
			else if (m_EventVal.TimeSinceLastThreatDetection_ESM < 1800f && !ListSpecification(bool_0: false, null))
			{
				m_EventVal.DesiredAltitude = -40f;
			}
			else
			{
				m_EventVal.DesiredAltitude = -20f;
			}
		}
		else if (miningMission.TransitDepth_Submarine.HasValue)
		{
			float value2 = miningMission.TransitDepth_Submarine.Value;
			if (!(Math.Round(value2) < -20.0) && !ListSpecification(bool_0: false, null))
			{
				m_EventVal.DesiredAltitude = Math.Min(-20f, OverLayerDepth(GetParentPlatform()));
			}
			else
			{
				m_EventVal.DesiredAltitude = value2;
			}
		}
		else
		{
			GetParentPlatform().DesiredAltitude = Math.Min(-20f, OverLayerDepth(GetParentPlatform()));
		}
	}

	public override void OptimizeAltSpeedForNextEngagement(float float_0, ref Weapon weapon_0)
	{
		if (m_EventVal == null || Information.IsNothing(PrimaryTarget))
		{
			return;
		}
		try
		{
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
			float num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
			if (!m_EventVal.Kinematics.DesiredAltitudeOverride)
			{
				float float_ = ((PrimaryTarget.CurrentSpeed == 0f) ? m_EventVal.CurrentSpeed : Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, m_EventVal.CurrentSpeed, m_EventVal.CurrentHeading));
				Weapon._WeaponType type = weapon_0.Type;
				float num2 = 0f;
				if (type != Weapon._WeaponType.Rocket && type != Weapon._WeaponType.Gun)
				{
					num2 = ((!weapon_0.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(weapon_0.ParentScen.DBConnection) || weapon_0.MinLaunchAlt_AGL != 0f || weapon_0.MaxLaunchAlt_AGL != 0f) ? weapon_0.MinLaunchAlt_AGL : weapon_0.MinLaunchAlt_ASL);
				}
				else if (Module_Unit.RangeToUnit_Slant(m_EventVal, PrimaryTarget) > maxRangeForThisTarget)
				{
					num2 = (float)(Math.Sqrt(2.0) / 2.0 * (double)maxRangeForThisTarget * 1852.0);
				}
				float num3 = 0f;
				if (num2 < m_EventVal.DesiredAltitude)
				{
					num3 = (m_EventVal.DesiredAltitude - num2) / m_EventVal.Kinematics.DiveRate_Nominal();
				}
				float num4;
				if (num <= maxRangeForThisTarget)
				{
					num4 = 0f;
				}
				else
				{
					float float_2 = num - maxRangeForThisTarget;
					num4 = m_EventVal.ETA_To_Location(float_, float_2);
				}
				if (num4 < 0f)
				{
					return;
				}
				if (num3 >= num4)
				{
					if (num2 < m_EventVal.DesiredAltitude)
					{
						if (PrimaryTarget.AltitudeIsKnown)
						{
							if (PrimaryTarget.GetCurrentAltitude() < num2 && m_EventVal.DesiredAltitude < num2)
							{
								m_EventVal.DesiredAltitude = num2;
							}
						}
						else if (Math.Round(m_EventVal.DesiredAltitude) > -20.0)
						{
							m_EventVal.DesiredAltitude = -20f;
						}
					}
					else if (num2 > m_EventVal.DesiredAltitude)
					{
						m_EventVal.DesiredAltitude = num2;
					}
				}
			}
			if (!m_EventVal.Kinematics.DesiredSpeedOverride.HasValue && (double)maxRangeForThisTarget * 1.2 < (double)num)
			{
				if (weapon_0.MaxLaunchSpeed != 0 && (float)weapon_0.MaxLaunchSpeed < m_EventVal.CurrentSpeed)
				{
					m_EventVal.DesiredSpeed = weapon_0.MaxLaunchSpeed;
				}
				if (weapon_0.MinLaunchSpeed != 0 && (float)weapon_0.MinLaunchSpeed > m_EventVal.CurrentSpeed)
				{
					m_EventVal.DesiredSpeed = weapon_0.MinLaunchSpeed;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100826", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private double PrintSpecification(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private double DefineSpecification(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, contact_0);
	}

	[CompilerGenerated]
	private bool PublishSpecification(UnguidedWeapon unguidedWeapon_0)
	{
		if (!Information.IsNothing(unguidedWeapon_0))
		{
			return m_EventVal.GetCanSweepMine(unguidedWeapon_0);
		}
		return false;
	}

	[CompilerGenerated]
	private double AwakeSpecification(UnguidedWeapon unguidedWeapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0);
	}

	[CompilerGenerated]
	private bool QuerySpecification(UnguidedWeapon unguidedWeapon_0)
	{
		if (unguidedWeapon_0 != null)
		{
			return m_EventVal.GetCanSweepMine(unguidedWeapon_0);
		}
		return false;
	}

	[CompilerGenerated]
	private double ResetSpecification(UnguidedWeapon unguidedWeapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(m_EventVal, unguidedWeapon_0);
	}
}
