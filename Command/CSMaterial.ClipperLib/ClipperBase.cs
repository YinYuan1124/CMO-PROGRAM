using System.Collections.Generic;
using Command.Bridges;
using Command.Lists;
using Command.Managers;
using Command.Watchers;
using OpenDis.Candidates;

namespace CSMaterial.ClipperLib;

public class ClipperBase
{
	protected const double horizontal = -3.4E+38;

	protected const int Skip = -2;

	protected const int Unassigned = -1;

	protected const double tolerance = 1E-20;

	internal const long codeDispatcher = 1073741823L;

	internal const long _ConnectionDispatcher = 4611686018427387903L;

	internal IndexerCallbackCandidate contextDispatcher;

	internal IndexerCallbackCandidate statusDispatcher;

	internal List<List<RefDispatcherList>> _ProccesorDispatcher = new List<List<RefDispatcherList>>();

	internal bool _StrategyDispatcher;

	internal bool _ConfigurationDispatcher;

	public bool PreserveCollinear { get; set; }

	internal static bool AwakeVal(double double_0)
	{
		if (double_0 <= -1E-20)
		{
			return false;
		}
		return double_0 < 1E-20;
	}

	internal static bool QueryVal(object object_0)
	{
		return ((RefDispatcherList)object_0)._FactoryDispatcher.Y == 0;
	}

	internal bool ResetVal(IntPoint intPoint_0, PredicateThreadBridge predicateThreadBridge_0)
	{
		PredicateThreadBridge predicateThreadBridge = predicateThreadBridge_0;
		do
		{
			if (!(predicateThreadBridge.m_ParamDispatcher == intPoint_0))
			{
				predicateThreadBridge = predicateThreadBridge.pageDispatcher;
				continue;
			}
			return true;
		}
		while (predicateThreadBridge != predicateThreadBridge_0);
		return false;
	}

	internal bool MapVal(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, bool bool_0)
	{
		if (bool_0)
		{
			if ((intPoint_0.X == intPoint_1.X && intPoint_0.Y == intPoint_1.Y) || (intPoint_0.X == intPoint_2.X && intPoint_0.Y == intPoint_2.Y))
			{
				return true;
			}
			if (intPoint_0.X > intPoint_1.X == intPoint_0.X < intPoint_2.X && intPoint_0.Y > intPoint_1.Y == intPoint_0.Y < intPoint_2.Y)
			{
				return DescriptorRuleWatcher.CallWrapper(intPoint_0.X - intPoint_1.X, intPoint_2.Y - intPoint_1.Y) == DescriptorRuleWatcher.CallWrapper(intPoint_2.X - intPoint_1.X, intPoint_0.Y - intPoint_1.Y);
			}
			return false;
		}
		if ((intPoint_0.X == intPoint_1.X && intPoint_0.Y == intPoint_1.Y) || (intPoint_0.X == intPoint_2.X && intPoint_0.Y == intPoint_2.Y))
		{
			return true;
		}
		if (intPoint_0.X > intPoint_1.X == intPoint_0.X < intPoint_2.X && intPoint_0.Y > intPoint_1.Y == intPoint_0.Y < intPoint_2.Y)
		{
			return (intPoint_0.X - intPoint_1.X) * (intPoint_2.Y - intPoint_1.Y) == (intPoint_2.X - intPoint_1.X) * (intPoint_0.Y - intPoint_1.Y);
		}
		return false;
	}

	internal bool SortVal(IntPoint intPoint_0, PredicateThreadBridge predicateThreadBridge_0, bool bool_0)
	{
		PredicateThreadBridge predicateThreadBridge = predicateThreadBridge_0;
		do
		{
			if (!MapVal(intPoint_0, predicateThreadBridge.m_ParamDispatcher, predicateThreadBridge.pageDispatcher.m_ParamDispatcher, bool_0))
			{
				predicateThreadBridge = predicateThreadBridge.pageDispatcher;
				continue;
			}
			return true;
		}
		while (predicateThreadBridge != predicateThreadBridge_0);
		return false;
	}

	internal static bool CalcVal(object object_0, object object_1, bool bool_0)
	{
		if (bool_0)
		{
			return DescriptorRuleWatcher.CallWrapper(((RefDispatcherList)object_0)._FactoryDispatcher.Y, ((RefDispatcherList)object_1)._FactoryDispatcher.X) == DescriptorRuleWatcher.CallWrapper(((RefDispatcherList)object_0)._FactoryDispatcher.X, ((RefDispatcherList)object_1)._FactoryDispatcher.Y);
		}
		return ((RefDispatcherList)object_0)._FactoryDispatcher.Y * ((RefDispatcherList)object_1)._FactoryDispatcher.X == ((RefDispatcherList)object_0)._FactoryDispatcher.X * ((RefDispatcherList)object_1)._FactoryDispatcher.Y;
	}

	protected static bool SlopesEqual(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, bool bool_0)
	{
		if (bool_0)
		{
			return DescriptorRuleWatcher.CallWrapper(intPoint_0.Y - intPoint_1.Y, intPoint_1.X - intPoint_2.X) == DescriptorRuleWatcher.CallWrapper(intPoint_0.X - intPoint_1.X, intPoint_1.Y - intPoint_2.Y);
		}
		return (intPoint_0.Y - intPoint_1.Y) * (intPoint_1.X - intPoint_2.X) - (intPoint_0.X - intPoint_1.X) * (intPoint_1.Y - intPoint_2.Y) == 0;
	}

	protected static bool SlopesEqual(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, IntPoint intPoint_3, bool bool_0)
	{
		if (bool_0)
		{
			return DescriptorRuleWatcher.CallWrapper(intPoint_0.Y - intPoint_1.Y, intPoint_2.X - intPoint_3.X) == DescriptorRuleWatcher.CallWrapper(intPoint_0.X - intPoint_1.X, intPoint_2.Y - intPoint_3.Y);
		}
		return (intPoint_0.Y - intPoint_1.Y) * (intPoint_2.X - intPoint_3.X) - (intPoint_0.X - intPoint_1.X) * (intPoint_2.Y - intPoint_3.Y) == 0;
	}

	internal ClipperBase()
	{
		contextDispatcher = null;
		statusDispatcher = null;
		_StrategyDispatcher = false;
		_ConfigurationDispatcher = false;
	}

	public virtual void Clear()
	{
		RateVal();
		for (int i = 0; i < _ProccesorDispatcher.Count; i++)
		{
			for (int j = 0; j < _ProccesorDispatcher[i].Count; j++)
			{
				_ProccesorDispatcher[i][j] = null;
			}
			_ProccesorDispatcher[i].Clear();
		}
		_ProccesorDispatcher.Clear();
		_StrategyDispatcher = false;
		_ConfigurationDispatcher = false;
	}

	private void RateVal()
	{
		while (contextDispatcher != null)
		{
			IndexerCallbackCandidate queueDispatcher = contextDispatcher.m_QueueDispatcher;
			contextDispatcher = null;
			contextDispatcher = queueDispatcher;
		}
		statusDispatcher = null;
	}

	private void FlushVal(IntPoint intPoint_0, ref bool bool_0)
	{
		if (bool_0)
		{
			if (intPoint_0.X > 4611686018427387903L || intPoint_0.Y > 4611686018427387903L || -intPoint_0.X > 4611686018427387903L || -intPoint_0.Y > 4611686018427387903L)
			{
				throw new InfoListenerManager("Coordinate outside allowed range");
			}
		}
		else if (intPoint_0.X > 1073741823 || intPoint_0.Y > 1073741823 || -intPoint_0.X > 1073741823 || -intPoint_0.Y > 1073741823)
		{
			bool_0 = true;
			FlushVal(intPoint_0, ref bool_0);
		}
	}

	private void ForgotVal(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1, RefDispatcherList refDispatcherList_2, IntPoint intPoint_0)
	{
		refDispatcherList_0._ParamsDispatcher = refDispatcherList_1;
		refDispatcherList_0.infoDispatcher = refDispatcherList_2;
		refDispatcherList_0.roleDispatcher = intPoint_0;
		refDispatcherList_0.m_AuthenticationDispatcher = -1;
	}

	private void CollectVal(RefDispatcherList refDispatcherList_0, PolyType polyType_0)
	{
		if (refDispatcherList_0.roleDispatcher.Y < refDispatcherList_0._ParamsDispatcher.roleDispatcher.Y)
		{
			refDispatcherList_0.Top = refDispatcherList_0.roleDispatcher;
			refDispatcherList_0.m_InitializerDispatcher = refDispatcherList_0._ParamsDispatcher.roleDispatcher;
		}
		else
		{
			refDispatcherList_0.m_InitializerDispatcher = refDispatcherList_0.roleDispatcher;
			refDispatcherList_0.Top = refDispatcherList_0._ParamsDispatcher.roleDispatcher;
		}
		CountWrapper(refDispatcherList_0);
		refDispatcherList_0._EventDispatcher = polyType_0;
	}

	private RefDispatcherList OrderVal(RefDispatcherList refDispatcherList_0)
	{
		while (true)
		{
			if (!(refDispatcherList_0.m_InitializerDispatcher == refDispatcherList_0.infoDispatcher.m_InitializerDispatcher) || !(refDispatcherList_0.roleDispatcher != refDispatcherList_0.Top))
			{
				refDispatcherList_0 = refDispatcherList_0._ParamsDispatcher;
				continue;
			}
			if (refDispatcherList_0.m_AttributeDispatcher != -3.4E+38 && refDispatcherList_0.infoDispatcher.m_AttributeDispatcher != -3.4E+38)
			{
				break;
			}
			while (refDispatcherList_0.infoDispatcher.m_AttributeDispatcher == -3.4E+38)
			{
				refDispatcherList_0 = refDispatcherList_0.infoDispatcher;
			}
			RefDispatcherList refDispatcherList = refDispatcherList_0;
			while (refDispatcherList_0.m_AttributeDispatcher == -3.4E+38)
			{
				refDispatcherList_0 = refDispatcherList_0._ParamsDispatcher;
			}
			if (refDispatcherList_0.Top.Y == refDispatcherList_0.infoDispatcher.m_InitializerDispatcher.Y)
			{
				continue;
			}
			if (refDispatcherList.infoDispatcher.m_InitializerDispatcher.X < refDispatcherList_0.m_InitializerDispatcher.X)
			{
				refDispatcherList_0 = refDispatcherList;
			}
			break;
		}
		return refDispatcherList_0;
	}

	private RefDispatcherList RegisterVal(RefDispatcherList refDispatcherList_0, bool bool_0)
	{
		RefDispatcherList refDispatcherList = refDispatcherList_0;
		RefDispatcherList refDispatcherList2 = refDispatcherList_0;
		if (refDispatcherList_0.m_AttributeDispatcher == -3.4E+38)
		{
			long num = (bool_0 ? refDispatcherList_0.infoDispatcher.m_InitializerDispatcher.X : refDispatcherList_0._ParamsDispatcher.m_InitializerDispatcher.X);
			if (refDispatcherList_0.m_InitializerDispatcher.X != num)
			{
				CloneWrapper(refDispatcherList_0);
			}
		}
		if (refDispatcherList2.m_AuthenticationDispatcher != -2)
		{
			if (bool_0)
			{
				while (refDispatcherList2.Top.Y == refDispatcherList2._ParamsDispatcher.m_InitializerDispatcher.Y && refDispatcherList2._ParamsDispatcher.m_AuthenticationDispatcher != -2)
				{
					refDispatcherList2 = refDispatcherList2._ParamsDispatcher;
				}
				if (refDispatcherList2.m_AttributeDispatcher == -3.4E+38 && refDispatcherList2._ParamsDispatcher.m_AuthenticationDispatcher != -2)
				{
					RefDispatcherList refDispatcherList3 = refDispatcherList2;
					while (refDispatcherList3.infoDispatcher.m_AttributeDispatcher == -3.4E+38)
					{
						refDispatcherList3 = refDispatcherList3.infoDispatcher;
					}
					if (refDispatcherList3.infoDispatcher.Top.X == refDispatcherList2._ParamsDispatcher.Top.X)
					{
						if (!bool_0)
						{
							refDispatcherList2 = refDispatcherList3.infoDispatcher;
						}
					}
					else if (refDispatcherList3.infoDispatcher.Top.X > refDispatcherList2._ParamsDispatcher.Top.X)
					{
						refDispatcherList2 = refDispatcherList3.infoDispatcher;
					}
				}
				while (refDispatcherList_0 != refDispatcherList2)
				{
					refDispatcherList_0._HelperDispatcher = refDispatcherList_0._ParamsDispatcher;
					if (refDispatcherList_0.m_AttributeDispatcher == -3.4E+38 && refDispatcherList_0 != refDispatcherList && refDispatcherList_0.m_InitializerDispatcher.X != refDispatcherList_0.infoDispatcher.Top.X)
					{
						CloneWrapper(refDispatcherList_0);
					}
					refDispatcherList_0 = refDispatcherList_0._ParamsDispatcher;
				}
				if (refDispatcherList_0.m_AttributeDispatcher == -3.4E+38 && refDispatcherList_0 != refDispatcherList && refDispatcherList_0.m_InitializerDispatcher.X != refDispatcherList_0.infoDispatcher.Top.X)
				{
					CloneWrapper(refDispatcherList_0);
				}
				refDispatcherList2 = refDispatcherList2._ParamsDispatcher;
			}
			else
			{
				while (refDispatcherList2.Top.Y == refDispatcherList2.infoDispatcher.m_InitializerDispatcher.Y && refDispatcherList2.infoDispatcher.m_AuthenticationDispatcher != -2)
				{
					refDispatcherList2 = refDispatcherList2.infoDispatcher;
				}
				if (refDispatcherList2.m_AttributeDispatcher == -3.4E+38 && refDispatcherList2.infoDispatcher.m_AuthenticationDispatcher != -2)
				{
					RefDispatcherList refDispatcherList4 = refDispatcherList2;
					while (refDispatcherList4._ParamsDispatcher.m_AttributeDispatcher == -3.4E+38)
					{
						refDispatcherList4 = refDispatcherList4._ParamsDispatcher;
					}
					if (refDispatcherList4._ParamsDispatcher.Top.X == refDispatcherList2.infoDispatcher.Top.X)
					{
						if (!bool_0)
						{
							refDispatcherList2 = refDispatcherList4._ParamsDispatcher;
						}
					}
					else if (refDispatcherList4._ParamsDispatcher.Top.X > refDispatcherList2.infoDispatcher.Top.X)
					{
						refDispatcherList2 = refDispatcherList4._ParamsDispatcher;
					}
				}
				while (refDispatcherList_0 != refDispatcherList2)
				{
					refDispatcherList_0._HelperDispatcher = refDispatcherList_0.infoDispatcher;
					if (refDispatcherList_0.m_AttributeDispatcher == -3.4E+38 && refDispatcherList_0 != refDispatcherList && refDispatcherList_0.m_InitializerDispatcher.X != refDispatcherList_0._ParamsDispatcher.Top.X)
					{
						CloneWrapper(refDispatcherList_0);
					}
					refDispatcherList_0 = refDispatcherList_0.infoDispatcher;
				}
				if (refDispatcherList_0.m_AttributeDispatcher == -3.4E+38 && refDispatcherList_0 != refDispatcherList && refDispatcherList_0.m_InitializerDispatcher.X != refDispatcherList_0._ParamsDispatcher.Top.X)
				{
					CloneWrapper(refDispatcherList_0);
				}
				refDispatcherList2 = refDispatcherList2.infoDispatcher;
			}
		}
		if (refDispatcherList2.m_AuthenticationDispatcher == -2)
		{
			refDispatcherList_0 = refDispatcherList2;
			if (bool_0)
			{
				while (refDispatcherList_0.Top.Y == refDispatcherList_0._ParamsDispatcher.m_InitializerDispatcher.Y)
				{
					refDispatcherList_0 = refDispatcherList_0._ParamsDispatcher;
				}
				while (refDispatcherList_0 != refDispatcherList2 && refDispatcherList_0.m_AttributeDispatcher == -3.4E+38)
				{
					refDispatcherList_0 = refDispatcherList_0.infoDispatcher;
				}
			}
			else
			{
				while (refDispatcherList_0.Top.Y == refDispatcherList_0.infoDispatcher.m_InitializerDispatcher.Y)
				{
					refDispatcherList_0 = refDispatcherList_0.infoDispatcher;
				}
				while (refDispatcherList_0 != refDispatcherList2 && refDispatcherList_0.m_AttributeDispatcher == -3.4E+38)
				{
					refDispatcherList_0 = refDispatcherList_0._ParamsDispatcher;
				}
			}
			if (refDispatcherList_0 == refDispatcherList2)
			{
				refDispatcherList2 = (bool_0 ? refDispatcherList_0._ParamsDispatcher : refDispatcherList_0.infoDispatcher);
			}
			else
			{
				refDispatcherList_0 = (bool_0 ? refDispatcherList2._ParamsDispatcher : refDispatcherList2.infoDispatcher);
				IndexerCallbackCandidate indexerCallbackCandidate = new IndexerCallbackCandidate();
				indexerCallbackCandidate.m_QueueDispatcher = null;
				indexerCallbackCandidate.Y = refDispatcherList_0.m_InitializerDispatcher.Y;
				indexerCallbackCandidate._TagDispatcher = null;
				indexerCallbackCandidate.m_FieldDispatcher = refDispatcherList_0;
				indexerCallbackCandidate.m_FieldDispatcher.workerDispatcher = 0;
				refDispatcherList2 = RegisterVal(indexerCallbackCandidate.m_FieldDispatcher, bool_0);
				CustomizeWrapper(indexerCallbackCandidate);
			}
		}
		return refDispatcherList2;
	}

	public bool AddPath(List<IntPoint> list_0, PolyType polyType_0, bool bool_0)
	{
		if (bool_0)
		{
			int num = list_0.Count - 1;
			if (bool_0)
			{
				while (num > 0 && list_0[num] == list_0[0])
				{
					num--;
				}
			}
			while (num > 0 && list_0[num] == list_0[num - 1])
			{
				num--;
			}
			if ((bool_0 && num < 2) || (!bool_0 && num < 1))
			{
				return false;
			}
			List<RefDispatcherList> list = new List<RefDispatcherList>(num + 1);
			for (int i = 0; i <= num; i++)
			{
				list.Add(new RefDispatcherList());
			}
			bool flag = true;
			list[1].roleDispatcher = list_0[1];
			FlushVal(list_0[0], ref _StrategyDispatcher);
			FlushVal(list_0[num], ref _StrategyDispatcher);
			ForgotVal(list[0], list[1], list[num], list_0[0]);
			ForgotVal(list[num], list[0], list[num - 1], list_0[num]);
			for (int num2 = num - 1; num2 >= 1; num2--)
			{
				FlushVal(list_0[num2], ref _StrategyDispatcher);
				ForgotVal(list[num2], list[num2 + 1], list[num2 - 1], list_0[num2]);
			}
			RefDispatcherList refDispatcherList = list[0];
			RefDispatcherList refDispatcherList2 = refDispatcherList;
			RefDispatcherList refDispatcherList3 = refDispatcherList;
			while (true)
			{
				if (!(refDispatcherList2.roleDispatcher == refDispatcherList2._ParamsDispatcher.roleDispatcher))
				{
					if (refDispatcherList2.infoDispatcher == refDispatcherList2._ParamsDispatcher)
					{
						break;
					}
					if (bool_0 && SlopesEqual(refDispatcherList2.infoDispatcher.roleDispatcher, refDispatcherList2.roleDispatcher, refDispatcherList2._ParamsDispatcher.roleDispatcher, _StrategyDispatcher) && (!PreserveCollinear || !ManageVal(refDispatcherList2.infoDispatcher.roleDispatcher, refDispatcherList2.roleDispatcher, refDispatcherList2._ParamsDispatcher.roleDispatcher)))
					{
						if (refDispatcherList2 == refDispatcherList)
						{
							refDispatcherList = refDispatcherList2._ParamsDispatcher;
						}
						refDispatcherList2 = RevertVal(refDispatcherList2);
						refDispatcherList2 = refDispatcherList2.infoDispatcher;
						refDispatcherList3 = refDispatcherList2;
					}
					else
					{
						refDispatcherList2 = refDispatcherList2._ParamsDispatcher;
						if (refDispatcherList2 == refDispatcherList3)
						{
							break;
						}
					}
				}
				else
				{
					if (refDispatcherList2 == refDispatcherList2._ParamsDispatcher)
					{
						break;
					}
					if (refDispatcherList2 == refDispatcherList)
					{
						refDispatcherList = refDispatcherList2._ParamsDispatcher;
					}
					refDispatcherList2 = RevertVal(refDispatcherList2);
					refDispatcherList3 = refDispatcherList2;
				}
			}
			if ((!bool_0 && refDispatcherList2 == refDispatcherList2._ParamsDispatcher) || (bool_0 && refDispatcherList2.infoDispatcher == refDispatcherList2._ParamsDispatcher))
			{
				return false;
			}
			if (!bool_0)
			{
				_ConfigurationDispatcher = true;
				refDispatcherList.infoDispatcher.m_AuthenticationDispatcher = -2;
			}
			refDispatcherList2 = refDispatcherList;
			do
			{
				CollectVal(refDispatcherList2, polyType_0);
				refDispatcherList2 = refDispatcherList2._ParamsDispatcher;
				if (flag && refDispatcherList2.roleDispatcher.Y != refDispatcherList.roleDispatcher.Y)
				{
					flag = false;
				}
			}
			while (refDispatcherList2 != refDispatcherList);
			if (flag)
			{
				if (bool_0)
				{
					return false;
				}
				refDispatcherList2.infoDispatcher.m_AuthenticationDispatcher = -2;
				if (refDispatcherList2.infoDispatcher.m_InitializerDispatcher.X < refDispatcherList2.infoDispatcher.Top.X)
				{
					CloneWrapper(refDispatcherList2.infoDispatcher);
				}
				IndexerCallbackCandidate indexerCallbackCandidate = new IndexerCallbackCandidate();
				indexerCallbackCandidate.m_QueueDispatcher = null;
				indexerCallbackCandidate.Y = refDispatcherList2.m_InitializerDispatcher.Y;
				indexerCallbackCandidate._TagDispatcher = null;
				indexerCallbackCandidate.m_FieldDispatcher = refDispatcherList2;
				indexerCallbackCandidate.m_FieldDispatcher.globalDispatcher = EdgeSide.esRight;
				indexerCallbackCandidate.m_FieldDispatcher.workerDispatcher = 0;
				while (refDispatcherList2._ParamsDispatcher.m_AuthenticationDispatcher != -2)
				{
					refDispatcherList2._HelperDispatcher = refDispatcherList2._ParamsDispatcher;
					if (refDispatcherList2.m_InitializerDispatcher.X != refDispatcherList2.infoDispatcher.Top.X)
					{
						CloneWrapper(refDispatcherList2);
					}
					refDispatcherList2 = refDispatcherList2._ParamsDispatcher;
				}
				CustomizeWrapper(indexerCallbackCandidate);
				_ProccesorDispatcher.Add(list);
				return true;
			}
			_ProccesorDispatcher.Add(list);
			RefDispatcherList refDispatcherList4 = null;
			while (true)
			{
				refDispatcherList2 = OrderVal(refDispatcherList2);
				if (refDispatcherList2 == refDispatcherList4)
				{
					break;
				}
				if (refDispatcherList4 == null)
				{
					refDispatcherList4 = refDispatcherList2;
				}
				IndexerCallbackCandidate indexerCallbackCandidate2 = new IndexerCallbackCandidate();
				indexerCallbackCandidate2.m_QueueDispatcher = null;
				indexerCallbackCandidate2.Y = refDispatcherList2.m_InitializerDispatcher.Y;
				bool flag2;
				if (refDispatcherList2.m_AttributeDispatcher < refDispatcherList2.infoDispatcher.m_AttributeDispatcher)
				{
					indexerCallbackCandidate2._TagDispatcher = refDispatcherList2.infoDispatcher;
					indexerCallbackCandidate2.m_FieldDispatcher = refDispatcherList2;
					flag2 = false;
				}
				else
				{
					indexerCallbackCandidate2._TagDispatcher = refDispatcherList2;
					indexerCallbackCandidate2.m_FieldDispatcher = refDispatcherList2.infoDispatcher;
					flag2 = true;
				}
				indexerCallbackCandidate2._TagDispatcher.globalDispatcher = EdgeSide.esLeft;
				indexerCallbackCandidate2.m_FieldDispatcher.globalDispatcher = EdgeSide.esRight;
				if (bool_0)
				{
					if (indexerCallbackCandidate2._TagDispatcher._ParamsDispatcher == indexerCallbackCandidate2.m_FieldDispatcher)
					{
						indexerCallbackCandidate2._TagDispatcher.workerDispatcher = -1;
					}
					else
					{
						indexerCallbackCandidate2._TagDispatcher.workerDispatcher = 1;
					}
				}
				else
				{
					indexerCallbackCandidate2._TagDispatcher.workerDispatcher = 0;
				}
				indexerCallbackCandidate2.m_FieldDispatcher.workerDispatcher = -indexerCallbackCandidate2._TagDispatcher.workerDispatcher;
				refDispatcherList2 = RegisterVal(indexerCallbackCandidate2._TagDispatcher, flag2);
				RefDispatcherList refDispatcherList5 = RegisterVal(indexerCallbackCandidate2.m_FieldDispatcher, !flag2);
				if (indexerCallbackCandidate2._TagDispatcher.m_AuthenticationDispatcher == -2)
				{
					indexerCallbackCandidate2._TagDispatcher = null;
				}
				else if (indexerCallbackCandidate2.m_FieldDispatcher.m_AuthenticationDispatcher == -2)
				{
					indexerCallbackCandidate2.m_FieldDispatcher = null;
				}
				CustomizeWrapper(indexerCallbackCandidate2);
				if (!flag2)
				{
					refDispatcherList2 = refDispatcherList5;
				}
			}
			return true;
		}
		throw new InfoListenerManager("AddPath: Open paths have been disabled.");
	}

	public bool AddPaths(List<List<IntPoint>> list_0, PolyType polyType_0, bool bool_0)
	{
		bool result = false;
		for (int i = 0; i < list_0.Count; i++)
		{
			if (AddPath(list_0[i], polyType_0, bool_0))
			{
				result = true;
			}
		}
		return result;
	}

	internal bool ManageVal(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2)
	{
		if (!(intPoint_0 == intPoint_2) && !(intPoint_0 == intPoint_1) && !(intPoint_2 == intPoint_1))
		{
			if (intPoint_0.X == intPoint_2.X)
			{
				return intPoint_1.Y > intPoint_0.Y == intPoint_1.Y < intPoint_2.Y;
			}
			return intPoint_1.X > intPoint_0.X == intPoint_1.X < intPoint_2.X;
		}
		return false;
	}

	private RefDispatcherList RevertVal(RefDispatcherList refDispatcherList_0)
	{
		refDispatcherList_0.infoDispatcher._ParamsDispatcher = refDispatcherList_0._ParamsDispatcher;
		refDispatcherList_0._ParamsDispatcher.infoDispatcher = refDispatcherList_0.infoDispatcher;
		RefDispatcherList paramsDispatcher = refDispatcherList_0._ParamsDispatcher;
		refDispatcherList_0.infoDispatcher = null;
		return paramsDispatcher;
	}

	private void CountWrapper(RefDispatcherList refDispatcherList_0)
	{
		refDispatcherList_0._FactoryDispatcher.X = refDispatcherList_0.Top.X - refDispatcherList_0.m_InitializerDispatcher.X;
		refDispatcherList_0._FactoryDispatcher.Y = refDispatcherList_0.Top.Y - refDispatcherList_0.m_InitializerDispatcher.Y;
		if (refDispatcherList_0._FactoryDispatcher.Y == 0)
		{
			refDispatcherList_0.m_AttributeDispatcher = -3.4E+38;
		}
		else
		{
			refDispatcherList_0.m_AttributeDispatcher = (double)refDispatcherList_0._FactoryDispatcher.X / (double)refDispatcherList_0._FactoryDispatcher.Y;
		}
	}

	private void CustomizeWrapper(IndexerCallbackCandidate indexerCallbackCandidate_0)
	{
		if (contextDispatcher == null)
		{
			contextDispatcher = indexerCallbackCandidate_0;
		}
		else if (indexerCallbackCandidate_0.Y < contextDispatcher.Y)
		{
			IndexerCallbackCandidate queueDispatcher = contextDispatcher;
			while (queueDispatcher.m_QueueDispatcher != null && indexerCallbackCandidate_0.Y < queueDispatcher.m_QueueDispatcher.Y)
			{
				queueDispatcher = queueDispatcher.m_QueueDispatcher;
			}
			indexerCallbackCandidate_0.m_QueueDispatcher = queueDispatcher.m_QueueDispatcher;
			queueDispatcher.m_QueueDispatcher = indexerCallbackCandidate_0;
		}
		else
		{
			indexerCallbackCandidate_0.m_QueueDispatcher = contextDispatcher;
			contextDispatcher = indexerCallbackCandidate_0;
		}
	}

	protected void PopLocalMinima()
	{
		if (statusDispatcher != null)
		{
			statusDispatcher = statusDispatcher.m_QueueDispatcher;
		}
	}

	private void CloneWrapper(RefDispatcherList refDispatcherList_0)
	{
		long x = refDispatcherList_0.Top.X;
		refDispatcherList_0.Top.X = refDispatcherList_0.m_InitializerDispatcher.X;
		refDispatcherList_0.m_InitializerDispatcher.X = x;
	}

	protected virtual void Reset()
	{
		statusDispatcher = contextDispatcher;
		if (statusDispatcher == null)
		{
			return;
		}
		for (IndexerCallbackCandidate queueDispatcher = contextDispatcher; queueDispatcher != null; queueDispatcher = queueDispatcher.m_QueueDispatcher)
		{
			RefDispatcherList tagDispatcher = queueDispatcher._TagDispatcher;
			if (tagDispatcher != null)
			{
				tagDispatcher.roleDispatcher = tagDispatcher.m_InitializerDispatcher;
				tagDispatcher.globalDispatcher = EdgeSide.esLeft;
				tagDispatcher.m_AuthenticationDispatcher = -1;
			}
			tagDispatcher = queueDispatcher.m_FieldDispatcher;
			if (tagDispatcher != null)
			{
				tagDispatcher.roleDispatcher = tagDispatcher.m_InitializerDispatcher;
				tagDispatcher.globalDispatcher = EdgeSide.esRight;
				tagDispatcher.m_AuthenticationDispatcher = -1;
			}
		}
	}

	public static IntRect GetBounds(List<List<IntPoint>> list_0)
	{
		int i = 0;
		int count;
		for (count = list_0.Count; i < count && list_0[i].Count == 0; i++)
		{
		}
		if (i == count)
		{
			return new IntRect(0L, 0L, 0L, 0L);
		}
		IntRect result = default(IntRect);
		result.left = list_0[i][0].X;
		result.right = result.left;
		result.top = list_0[i][0].Y;
		result.bottom = result.top;
		for (; i < count; i++)
		{
			for (int j = 0; j < list_0[i].Count; j++)
			{
				if (list_0[i][j].X < result.left)
				{
					result.left = list_0[i][j].X;
				}
				else if (list_0[i][j].X > result.right)
				{
					result.right = list_0[i][j].X;
				}
				if (list_0[i][j].Y < result.top)
				{
					result.top = list_0[i][j].Y;
				}
				else if (list_0[i][j].Y > result.bottom)
				{
					result.bottom = list_0[i][j].Y;
				}
			}
		}
		return result;
	}
}
