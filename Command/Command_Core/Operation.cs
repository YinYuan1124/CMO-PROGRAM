using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Operation : ScenarioObject
{
	public DateTime _HHour;

	public DateTime _LHour;

	public string _HHourMissionID;

	public Mission HHourMission;

	public DateTime HHourEffectiveStartTime;

	public DateTime LHourEffectiveStartTime;

	public bool H_LHourAreRelative;

	public string _LHourMissionID;

	public Mission LHourMission;

	private Side _TokenConsumer;

	private Scenario m_IndexerConsumer;

	public bool PhasesValidation;

	private Dictionary<Mission, MissionPhase> _ResolverConsumer;

	private Dictionary<Mission, int> m_PublisherConsumer;

	private DateTime serverConsumer;

	private DateTime adapterConsumer;

	private DateTime schemaConsumer;

	public bool Boolean_0 => DateTime.Compare(LHourEffectiveStartTime, DateTime.MinValue) != 0;

	public bool Boolean_1 => DateTime.Compare(HHourEffectiveStartTime, DateTime.MinValue) != 0;

	public DateTime LHour
	{
		get
		{
			return _LHour;
		}
		set
		{
			_LHour = value;
		}
	}

	public DateTime HHour
	{
		get
		{
			return _HHour;
		}
		set
		{
			if (H_LHourAreRelative)
			{
				TimeSpan timeSpan = value - _HHour;
				LHour += timeSpan;
			}
			_HHour = value;
		}
	}

	public Operation(Side side_0)
	{
		_HHour = DateTime.MinValue;
		_LHour = DateTime.MinValue;
		_HHourMissionID = "";
		HHourEffectiveStartTime = DateTime.MinValue;
		LHourEffectiveStartTime = DateTime.MinValue;
		_LHourMissionID = "";
		PhasesValidation = false;
		_ResolverConsumer = new Dictionary<Mission, MissionPhase>();
		m_PublisherConsumer = new Dictionary<Mission, int>();
		schemaConsumer = DateTime.MinValue;
		_TokenConsumer = side_0;
		HHour = GameGeneral.ScenarioLastGoodClone_DateTime;
		LHour = GameGeneral.ScenarioLastGoodClone_DateTime;
	}

	internal int InitStub(Scenario scenario_0, int int_0 = 1)
	{
		if (HHourMission == null)
		{
			foreach (Mission mission in _TokenConsumer.Missions)
			{
				mission.EstimatedExecutionTime = 0;
			}
		}
		else
		{
			_ResolverConsumer.Clear();
			m_PublisherConsumer.Clear();
			foreach (Mission mission2 in _TokenConsumer.Missions)
			{
				_ResolverConsumer.Add(mission2, MissionPhase.OnHold);
				m_PublisherConsumer.Add(mission2, 0);
			}
			if (DateTime.Compare(scenario_0.Time, HHour) <= 0)
			{
				adapterConsumer = HHour;
			}
			else
			{
				adapterConsumer = scenario_0.Time;
			}
			schemaConsumer = adapterConsumer;
			HHourMission.EstimatedExecutionTime = 0;
			serverConsumer = adapterConsumer;
			_ResolverConsumer[HHourMission] = MissionPhase.Active;
		}
		int i;
		for (i = 0; CheckStub(int_0, i) && i < 2592000; i += int_0)
		{
		}
		if (i < 2592000)
		{
			return i;
		}
		foreach (KeyValuePair<Mission, MissionPhase> item in _ResolverConsumer)
		{
			item.Key.EstimatedExecutionTime = -500;
		}
		return i;
	}

	internal bool CheckStub(int int_0 = 1, int int_1 = 0)
	{
		bool result = false;
		for (int i = _ResolverConsumer.Count - 1; i >= 0; i += -1)
		{
			Mission key = _ResolverConsumer.ElementAt(i).Key;
			List<Mission.TriggerOperationWrapper> list = new List<Mission.TriggerOperationWrapper>();
			if (_ResolverConsumer[key] == MissionPhase.OnHold)
			{
				result = true;
				bool bool_ = true;
				if (key.MissionStartTrigger_MissionCompleted_Enabled)
				{
					foreach (KeyValuePair<Mission, Mission> item in key.MissionStartTrigger_MissionCompleted)
					{
						if (_ResolverConsumer[item.Key] != MissionPhase.Completed)
						{
							bool_ = false;
							break;
						}
					}
					list.Add(new Mission.TriggerOperationWrapper(bool_, key.MissionStartTrigger_MissionCompleted_Operator));
				}
				if (key.MissionStartTrigger_Time_Enabled && DateTime.Compare(schemaConsumer, DateTime.MinValue) != 0)
				{
					list.Add(new Mission.TriggerOperationWrapper(DateTime.Compare(serverConsumer, schemaConsumer.AddSeconds(key.MissionStartTrigger_Time)) > 0, key.MissionStartTrigger_Time_Operator));
				}
				bool flag = false;
				foreach (Mission.TriggerOperationWrapper item2 in list)
				{
					if (item2.Value)
					{
						if (!item2.ConditionalOperator)
						{
							flag = true;
							break;
						}
						flag = true;
					}
					else if (item2.ConditionalOperator)
					{
						flag = false;
						break;
					}
				}
				if (flag || list.Count == 0)
				{
					_ResolverConsumer[key] = MissionPhase.Active;
					key.EstimatedExecutionTime = int_1;
				}
			}
			else if (_ResolverConsumer[key] == MissionPhase.Active)
			{
				m_PublisherConsumer[key] += int_0;
				if ((float)m_PublisherConsumer[key] > key.MissionCompletedTrigger_ElapsedTime)
				{
					_ResolverConsumer[key] = MissionPhase.Completed;
				}
			}
		}
		serverConsumer = serverConsumer.AddSeconds(int_0);
		return result;
	}

	public void Tick(Scenario scenario_0, float float_0)
	{
		try
		{
			m_IndexerConsumer = scenario_0;
			if (m_IndexerConsumer.SecondIsChangingOnThisPulse)
			{
				CheckH_Hour(m_IndexerConsumer);
				CheckL_Hour(m_IndexerConsumer);
			}
			foreach (Mission mission in _TokenConsumer.Missions)
			{
				if (mission.MissionCompletedTrigger_ElapsedTime_Enabled && mission.GetPhase(m_IndexerConsumer, _TokenConsumer) == MissionPhase.Active)
				{
					mission.MissionCompletedTrigger_ElapsedTime_Current += float_0;
				}
				if (m_IndexerConsumer.SecondIsChangingOnThisPulse)
				{
					if (mission.GetPhase(m_IndexerConsumer, _TokenConsumer) == MissionPhase.OnHold && mission.WriteValue(m_IndexerConsumer, _TokenConsumer))
					{
						mission.SetPhase(m_IndexerConsumer, _TokenConsumer, MissionPhase.Active);
					}
					else if (mission.GetPhase(m_IndexerConsumer, _TokenConsumer) == MissionPhase.Active && mission.GetValue(m_IndexerConsumer, _TokenConsumer))
					{
						mission.SetPhase(m_IndexerConsumer, _TokenConsumer, MissionPhase.Completed);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at OM_1654612314", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CheckH_Hour(Scenario scenario_0, bool bool_0 = false)
	{
		if (!Information.IsNothing(HHourMission) && HHourMission.GetPhase(scenario_0, _TokenConsumer) == MissionPhase.OnHold && (DateTime.Compare(scenario_0.Time, HHour) > 0 || bool_0))
		{
			HHourMission.SetPhase(scenario_0, _TokenConsumer, MissionPhase.Active);
		}
	}

	public void CheckL_Hour(Scenario scenario_0, bool bool_0 = false)
	{
		if (!Information.IsNothing(LHourMission) && LHourMission.GetPhase(scenario_0, _TokenConsumer) == MissionPhase.OnHold && (DateTime.Compare(scenario_0.Time, LHour) > 0 || bool_0))
		{
			LHourMission.SetPhase(scenario_0, _TokenConsumer, MissionPhase.Active);
		}
	}

	public string ToXML(ref HashSet<string> hashSet_0)
	{
		string result = null;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			stringBuilder.Append("<Operation>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (HHourMission != null)
			{
				stringBuilder.Append("<HHourMissionID>").Append(HHourMission.ObjectID).Append("</HHourMissionID>");
			}
			if (LHourMission != null)
			{
				stringBuilder.Append("<LHourMissionID>").Append(LHourMission.ObjectID).Append("</LHourMissionID>");
			}
			stringBuilder.Append("<HHourMissionTime>").Append(HHour.Ticks.ToString()).Append("</HHourMissionTime>");
			stringBuilder.Append("<LHourMissionTime>").Append(LHour.Ticks.ToString()).Append("</LHourMissionTime>");
			stringBuilder.Append("<HHourEffectiveStartTime>").Append(HHourEffectiveStartTime.Ticks.ToString()).Append("</HHourEffectiveStartTime>");
			stringBuilder.Append("<LHourEffectiveStartTime>").Append(LHourEffectiveStartTime.Ticks.ToString()).Append("</LHourEffectiveStartTime>");
			stringBuilder.Append("<H_LHourAreRelative>").Append(H_LHourAreRelative).Append("</H_LHourAreRelative>");
			stringBuilder.Append("</Operation>");
			result = stringBuilder.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1005845_c", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Operation FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Side side_0)
	{
		try
		{
			Operation operation = new Operation(side_0);
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						operation.ObjectID = xmlNode.InnerText;
						break;
					case "HHourMissionID":
						operation._HHourMissionID = xmlNode.InnerText;
						break;
					case "HHourMissionTime":
						operation.HHour = new DateTime(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "LHourMissionTime":
						operation.LHour = new DateTime(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "HHourEffectiveStartTime":
						operation.HHourEffectiveStartTime = new DateTime(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "LHourEffectiveStartTime":
						operation.LHourEffectiveStartTime = new DateTime(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "LHourMissionID":
						operation._LHourMissionID = xmlNode.InnerText;
						break;
					case "H_LHourAreRelative":
						operation.H_LHourAreRelative = Conversions.ToBoolean(xmlNode.InnerText);
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
			return operation;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1005855_c", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Operation result = new Operation(side_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
