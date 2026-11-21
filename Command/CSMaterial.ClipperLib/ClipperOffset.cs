using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSMaterial.ClipperLib;

public sealed class ClipperOffset
{
	private List<List<IntPoint>> _IndexerDispatcher;

	private List<IntPoint> _ResolverDispatcher;

	private List<IntPoint> m_PublisherDispatcher;

	private List<DoublePoint> serverDispatcher = new List<DoublePoint>();

	private double _AdapterDispatcher;

	private double _SchemaDispatcher;

	private double utilsDispatcher;

	private double m_PredicateDispatcher;

	private double m_SingletonDispatcher;

	private double recordDispatcher;

	private IntPoint m_ExceptionDispatcher;

	private PolyNode _AttrDispatcher = new PolyNode();

	[CompilerGenerated]
	private double m_VisitorDispatcher;

	public double ArcTolerance
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorDispatcher;
		}
		[CompilerGenerated]
		set
		{
			m_VisitorDispatcher = value;
		}
	}

	public double MiterLimit { get; set; }

	public ClipperOffset(double double_0 = 2.0, double double_1 = 0.25)
	{
		MiterLimit = double_0;
		ArcTolerance = double_1;
		m_ExceptionDispatcher.X = -1L;
	}

	public void Clear()
	{
		_AttrDispatcher.Childs.Clear();
		m_ExceptionDispatcher.X = -1L;
	}

	internal static long Round(double double_0)
	{
		if (double_0 < 0.0)
		{
			return (long)(double_0 - 0.5);
		}
		return (long)(double_0 + 0.5);
	}

	public void AddPath(List<IntPoint> list_0, JoinType joinType_0, EndType endType_0)
	{
		int num = list_0.Count - 1;
		if (num < 0)
		{
			return;
		}
		PolyNode polyNode = new PolyNode();
		polyNode.algoDispatcher = joinType_0;
		polyNode.m_DatabaseDispatcher = endType_0;
		if (endType_0 == EndType.etClosedLine || endType_0 == EndType.etClosedPolygon)
		{
			while (num > 0 && list_0[0] == list_0[num])
			{
				num--;
			}
		}
		polyNode.m_PrinterDispatcher.Capacity = num + 1;
		polyNode.m_PrinterDispatcher.Add(list_0[0]);
		int num2 = 0;
		int num3 = 0;
		for (int i = 1; i <= num; i++)
		{
			if (polyNode.m_PrinterDispatcher[num2] != list_0[i])
			{
				num2++;
				polyNode.m_PrinterDispatcher.Add(list_0[i]);
				if (list_0[i].Y > polyNode.m_PrinterDispatcher[num3].Y || (list_0[i].Y == polyNode.m_PrinterDispatcher[num3].Y && list_0[i].X < polyNode.m_PrinterDispatcher[num3].X))
				{
					num3 = num2;
				}
			}
		}
		if ((endType_0 == EndType.etClosedPolygon && num2 < 2) || (endType_0 != 0 && num2 < 0))
		{
			return;
		}
		_AttrDispatcher.ValidateWrapper(polyNode);
		if (endType_0 != 0)
		{
			return;
		}
		if (m_ExceptionDispatcher.X < 0)
		{
			m_ExceptionDispatcher = new IntPoint(0L, num3);
			return;
		}
		IntPoint intPoint = _AttrDispatcher.Childs[(int)m_ExceptionDispatcher.X].m_PrinterDispatcher[(int)m_ExceptionDispatcher.Y];
		if (polyNode.m_PrinterDispatcher[num3].Y > intPoint.Y || (polyNode.m_PrinterDispatcher[num3].Y == intPoint.Y && polyNode.m_PrinterDispatcher[num3].X < intPoint.X))
		{
			m_ExceptionDispatcher = new IntPoint(_AttrDispatcher.ChildCount - 1, num3);
		}
	}

	public void AddPaths(List<List<IntPoint>> list_0, JoinType joinType_0, EndType endType_0)
	{
		foreach (List<IntPoint> item in list_0)
		{
			AddPath(item, joinType_0, endType_0);
		}
	}

	private void ConnectWrapper()
	{
		if (m_ExceptionDispatcher.X >= 0 && !Clipper.Orientation(_AttrDispatcher.Childs[(int)m_ExceptionDispatcher.X].m_PrinterDispatcher))
		{
			for (int i = 0; i < _AttrDispatcher.ChildCount; i++)
			{
				PolyNode polyNode = _AttrDispatcher.Childs[i];
				if (polyNode.m_DatabaseDispatcher == EndType.etClosedPolygon || (polyNode.m_DatabaseDispatcher == EndType.etClosedLine && Clipper.Orientation(polyNode.m_PrinterDispatcher)))
				{
					polyNode.m_PrinterDispatcher.Reverse();
				}
			}
			return;
		}
		for (int j = 0; j < _AttrDispatcher.ChildCount; j++)
		{
			PolyNode polyNode2 = _AttrDispatcher.Childs[j];
			if (polyNode2.m_DatabaseDispatcher == EndType.etClosedLine && !Clipper.Orientation(polyNode2.m_PrinterDispatcher))
			{
				polyNode2.m_PrinterDispatcher.Reverse();
			}
		}
	}

	internal static DoublePoint MoveWrapper(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		double num = intPoint_1.X - intPoint_0.X;
		double num2 = intPoint_1.Y - intPoint_0.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			return default(DoublePoint);
		}
		double num3 = 1.0 / Math.Sqrt(num * num + num2 * num2);
		num *= num3;
		num2 *= num3;
		return new DoublePoint(num2, 0.0 - num);
	}

	private void DeleteWrapper(double double_0)
	{
		_IndexerDispatcher = new List<List<IntPoint>>();
		_AdapterDispatcher = double_0;
		if (ClipperBase.AwakeVal(double_0))
		{
			_IndexerDispatcher.Capacity = _AttrDispatcher.ChildCount;
			for (int i = 0; i < _AttrDispatcher.ChildCount; i++)
			{
				PolyNode polyNode = _AttrDispatcher.Childs[i];
				if (polyNode.m_DatabaseDispatcher == EndType.etClosedPolygon)
				{
					_IndexerDispatcher.Add(polyNode.m_PrinterDispatcher);
				}
			}
			return;
		}
		if (MiterLimit <= 2.0)
		{
			m_SingletonDispatcher = 0.5;
		}
		else
		{
			m_SingletonDispatcher = 2.0 / (MiterLimit * MiterLimit);
		}
		double num = ((ArcTolerance <= 0.0) ? 0.25 : ((ArcTolerance <= Math.Abs(double_0) * 0.25) ? ArcTolerance : (Math.Abs(double_0) * 0.25)));
		double num7 = Math.PI / Math.Acos(1.0 - num / Math.Abs(double_0));
		utilsDispatcher = Math.Sin(Math.PI * 2.0 / num7);
		m_PredicateDispatcher = Math.Cos(Math.PI * 2.0 / num7);
		recordDispatcher = num7 / (Math.PI * 2.0);
		if (double_0 < 0.0)
		{
			utilsDispatcher = 0.0 - utilsDispatcher;
		}
		_IndexerDispatcher.Capacity = _AttrDispatcher.ChildCount * 2;
		for (int j = 0; j < _AttrDispatcher.ChildCount; j++)
		{
			PolyNode polyNode2 = _AttrDispatcher.Childs[j];
			_ResolverDispatcher = polyNode2.m_PrinterDispatcher;
			int count = _ResolverDispatcher.Count;
			if (count == 0 || (double_0 <= 0.0 && (count < 3 || polyNode2.m_DatabaseDispatcher != 0)))
			{
				continue;
			}
			m_PublisherDispatcher = new List<IntPoint>();
			if (count == 1)
			{
				if (polyNode2.algoDispatcher == JoinType.jtRound)
				{
					double num8 = 1.0;
					double num9 = 0.0;
					for (int k = 1; (double)k <= num7; k++)
					{
						m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[0].X + num8 * double_0), Round((double)_ResolverDispatcher[0].Y + num9 * double_0)));
						double num10 = num8;
						num8 = num8 * m_PredicateDispatcher - utilsDispatcher * num9;
						num9 = num10 * utilsDispatcher + num9 * m_PredicateDispatcher;
					}
				}
				else
				{
					double num11 = -1.0;
					double num12 = -1.0;
					for (int l = 0; l < 4; l++)
					{
						m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[0].X + num11 * double_0), Round((double)_ResolverDispatcher[0].Y + num12 * double_0)));
						if (num11 < 0.0)
						{
							num11 = 1.0;
						}
						else if (num12 < 0.0)
						{
							num12 = 1.0;
						}
						else
						{
							num11 = -1.0;
						}
					}
				}
				_IndexerDispatcher.Add(m_PublisherDispatcher);
				continue;
			}
			serverDispatcher.Clear();
			serverDispatcher.Capacity = count;
			for (int m = 0; m < count - 1; m++)
			{
				serverDispatcher.Add(MoveWrapper(_ResolverDispatcher[m], _ResolverDispatcher[m + 1]));
			}
			if (polyNode2.m_DatabaseDispatcher != EndType.etClosedLine && polyNode2.m_DatabaseDispatcher != 0)
			{
				serverDispatcher.Add(new DoublePoint(serverDispatcher[count - 2]));
			}
			else
			{
				serverDispatcher.Add(MoveWrapper(_ResolverDispatcher[count - 1], _ResolverDispatcher[0]));
			}
			if (polyNode2.m_DatabaseDispatcher == EndType.etClosedPolygon)
			{
				int int_ = count - 1;
				for (int n = 0; n < count; n++)
				{
					AddWrapper(n, ref int_, polyNode2.algoDispatcher);
				}
				_IndexerDispatcher.Add(m_PublisherDispatcher);
				continue;
			}
			if (polyNode2.m_DatabaseDispatcher == EndType.etClosedLine)
			{
				int int_2 = count - 1;
				for (int num13 = 0; num13 < count; num13++)
				{
					AddWrapper(num13, ref int_2, polyNode2.algoDispatcher);
				}
				_IndexerDispatcher.Add(m_PublisherDispatcher);
				m_PublisherDispatcher = new List<IntPoint>();
				DoublePoint doublePoint = serverDispatcher[count - 1];
				for (int num14 = count - 1; num14 > 0; num14--)
				{
					serverDispatcher[num14] = new DoublePoint(0.0 - serverDispatcher[num14 - 1].X, 0.0 - serverDispatcher[num14 - 1].Y);
				}
				serverDispatcher[0] = new DoublePoint(0.0 - doublePoint.X, 0.0 - doublePoint.Y);
				int_2 = 0;
				for (int num2 = count - 1; num2 >= 0; num2--)
				{
					AddWrapper(num2, ref int_2, polyNode2.algoDispatcher);
				}
				_IndexerDispatcher.Add(m_PublisherDispatcher);
				continue;
			}
			int int_3 = 0;
			for (int num3 = 1; num3 < count - 1; num3++)
			{
				AddWrapper(num3, ref int_3, polyNode2.algoDispatcher);
			}
			if (polyNode2.m_DatabaseDispatcher == EndType.etOpenButt)
			{
				int index = count - 1;
				IntPoint item = new IntPoint(Round((double)_ResolverDispatcher[index].X + serverDispatcher[index].X * double_0), Round((double)_ResolverDispatcher[index].Y + serverDispatcher[index].Y * double_0));
				m_PublisherDispatcher.Add(item);
				item = new IntPoint(Round((double)_ResolverDispatcher[index].X - serverDispatcher[index].X * double_0), Round((double)_ResolverDispatcher[index].Y - serverDispatcher[index].Y * double_0));
				m_PublisherDispatcher.Add(item);
			}
			else
			{
				int num4 = count - 1;
				int_3 = count - 2;
				_SchemaDispatcher = 0.0;
				serverDispatcher[num4] = new DoublePoint(0.0 - serverDispatcher[num4].X, 0.0 - serverDispatcher[num4].Y);
				if (polyNode2.m_DatabaseDispatcher == EndType.etOpenSquare)
				{
					DestroyWrapper(num4, int_3);
				}
				else
				{
					PatchWrapper(num4, int_3);
				}
			}
			for (int num5 = count - 1; num5 > 0; num5--)
			{
				serverDispatcher[num5] = new DoublePoint(0.0 - serverDispatcher[num5 - 1].X, 0.0 - serverDispatcher[num5 - 1].Y);
			}
			serverDispatcher[0] = new DoublePoint(0.0 - serverDispatcher[1].X, 0.0 - serverDispatcher[1].Y);
			int_3 = count - 1;
			for (int num6 = int_3 - 1; num6 > 0; num6--)
			{
				AddWrapper(num6, ref int_3, polyNode2.algoDispatcher);
			}
			if (polyNode2.m_DatabaseDispatcher == EndType.etOpenButt)
			{
				IntPoint item2 = new IntPoint(Round((double)_ResolverDispatcher[0].X - serverDispatcher[0].X * double_0), Round((double)_ResolverDispatcher[0].Y - serverDispatcher[0].Y * double_0));
				m_PublisherDispatcher.Add(item2);
				item2 = new IntPoint(Round((double)_ResolverDispatcher[0].X + serverDispatcher[0].X * double_0), Round((double)_ResolverDispatcher[0].Y + serverDispatcher[0].Y * double_0));
				m_PublisherDispatcher.Add(item2);
			}
			else
			{
				int_3 = 1;
				_SchemaDispatcher = 0.0;
				if (polyNode2.m_DatabaseDispatcher == EndType.etOpenSquare)
				{
					DestroyWrapper(0, 1);
				}
				else
				{
					PatchWrapper(0, 1);
				}
			}
			_IndexerDispatcher.Add(m_PublisherDispatcher);
		}
	}

	public void Execute(ref List<List<IntPoint>> list_0, double double_0)
	{
		list_0.Clear();
		ConnectWrapper();
		DeleteWrapper(double_0);
		Clipper clipper = new Clipper();
		clipper.AddPaths(_IndexerDispatcher, PolyType.ptSubject, bool_0: true);
		if (double_0 <= 0.0)
		{
			IntRect bounds = ClipperBase.GetBounds(_IndexerDispatcher);
			List<IntPoint> list = new List<IntPoint>(4);
			list.Add(new IntPoint(bounds.left - 10, bounds.bottom + 10));
			list.Add(new IntPoint(bounds.right + 10, bounds.bottom + 10));
			list.Add(new IntPoint(bounds.right + 10, bounds.top - 10));
			list.Add(new IntPoint(bounds.left - 10, bounds.top - 10));
			clipper.AddPath(list, PolyType.ptSubject, bool_0: true);
			clipper.ReverseSolution = true;
			clipper.Execute(ClipType.ctUnion, list_0, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (list_0.Count > 0)
			{
				list_0.RemoveAt(0);
			}
		}
		else
		{
			clipper.Execute(ClipType.ctUnion, list_0, PolyFillType.pftPositive, PolyFillType.pftPositive);
		}
	}

	public void Execute(ref PolyTree polyTree_0, double double_0)
	{
		polyTree_0.Clear();
		ConnectWrapper();
		DeleteWrapper(double_0);
		Clipper clipper = new Clipper();
		clipper.AddPaths(_IndexerDispatcher, PolyType.ptSubject, bool_0: true);
		if (double_0 <= 0.0)
		{
			IntRect bounds = ClipperBase.GetBounds(_IndexerDispatcher);
			List<IntPoint> list = new List<IntPoint>(4);
			list.Add(new IntPoint(bounds.left - 10, bounds.bottom + 10));
			list.Add(new IntPoint(bounds.right + 10, bounds.bottom + 10));
			list.Add(new IntPoint(bounds.right + 10, bounds.top - 10));
			list.Add(new IntPoint(bounds.left - 10, bounds.top - 10));
			clipper.AddPath(list, PolyType.ptSubject, bool_0: true);
			clipper.ReverseSolution = true;
			clipper.Execute(ClipType.ctUnion, polyTree_0, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (polyTree_0.ChildCount == 1 && polyTree_0.Childs[0].ChildCount > 0)
			{
				PolyNode polyNode = polyTree_0.Childs[0];
				polyTree_0.Childs.Capacity = polyNode.ChildCount;
				polyTree_0.Childs[0] = polyNode.Childs[0];
				for (int i = 1; i < polyNode.ChildCount; i++)
				{
					polyTree_0.ValidateWrapper(polyNode.Childs[i]);
				}
			}
			else
			{
				polyTree_0.Clear();
			}
		}
		else
		{
			clipper.Execute(ClipType.ctUnion, polyTree_0, PolyFillType.pftPositive, PolyFillType.pftPositive);
		}
	}

	private void AddWrapper(int int_0, ref int int_1, JoinType joinType_0)
	{
		_SchemaDispatcher = serverDispatcher[int_1].X * serverDispatcher[int_0].Y - serverDispatcher[int_0].X * serverDispatcher[int_1].Y;
		if (_SchemaDispatcher < 5E-05 && _SchemaDispatcher > -5E-05)
		{
			return;
		}
		if (_SchemaDispatcher <= 1.0)
		{
			if (_SchemaDispatcher < -1.0)
			{
				_SchemaDispatcher = -1.0;
			}
		}
		else
		{
			_SchemaDispatcher = 1.0;
		}
		if (_SchemaDispatcher * _AdapterDispatcher < 0.0)
		{
			m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + serverDispatcher[int_1].X * _AdapterDispatcher), Round((double)_ResolverDispatcher[int_0].Y + serverDispatcher[int_1].Y * _AdapterDispatcher)));
			m_PublisherDispatcher.Add(_ResolverDispatcher[int_0]);
			m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + serverDispatcher[int_0].X * _AdapterDispatcher), Round((double)_ResolverDispatcher[int_0].Y + serverDispatcher[int_0].Y * _AdapterDispatcher)));
		}
		else
		{
			switch (joinType_0)
			{
			case JoinType.jtSquare:
				DestroyWrapper(int_0, int_1);
				break;
			case JoinType.jtRound:
				PatchWrapper(int_0, int_1);
				break;
			case JoinType.jtMiter:
			{
				double num = 1.0 + (serverDispatcher[int_0].X * serverDispatcher[int_1].X + serverDispatcher[int_0].Y * serverDispatcher[int_1].Y);
				if (num < m_SingletonDispatcher)
				{
					DestroyWrapper(int_0, int_1);
				}
				else
				{
					ComputeWrapper(int_0, int_1, num);
				}
				break;
			}
			}
		}
		int_1 = int_0;
	}

	internal void DestroyWrapper(int int_0, int int_1)
	{
		double num = Math.Tan(Math.Atan2(_SchemaDispatcher, serverDispatcher[int_1].X * serverDispatcher[int_0].X + serverDispatcher[int_1].Y * serverDispatcher[int_0].Y) / 4.0);
		m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + _AdapterDispatcher * (serverDispatcher[int_1].X - serverDispatcher[int_1].Y * num)), Round((double)_ResolverDispatcher[int_0].Y + _AdapterDispatcher * (serverDispatcher[int_1].Y + serverDispatcher[int_1].X * num))));
		m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + _AdapterDispatcher * (serverDispatcher[int_0].X + serverDispatcher[int_0].Y * num)), Round((double)_ResolverDispatcher[int_0].Y + _AdapterDispatcher * (serverDispatcher[int_0].Y - serverDispatcher[int_0].X * num))));
	}

	internal void ComputeWrapper(int int_0, int int_1, double double_0)
	{
		double num = _AdapterDispatcher / double_0;
		m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + (serverDispatcher[int_1].X + serverDispatcher[int_0].X) * num), Round((double)_ResolverDispatcher[int_0].Y + (serverDispatcher[int_1].Y + serverDispatcher[int_0].Y) * num)));
	}

	internal void PatchWrapper(int int_0, int int_1)
	{
		double value = Math.Atan2(_SchemaDispatcher, serverDispatcher[int_1].X * serverDispatcher[int_0].X + serverDispatcher[int_1].Y * serverDispatcher[int_0].Y);
		int num = (int)Round(recordDispatcher * Math.Abs(value));
		double num2 = serverDispatcher[int_1].X;
		double num3 = serverDispatcher[int_1].Y;
		for (int i = 0; i < num; i++)
		{
			m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + num2 * _AdapterDispatcher), Round((double)_ResolverDispatcher[int_0].Y + num3 * _AdapterDispatcher)));
			double num4 = num2;
			num2 = num2 * m_PredicateDispatcher - utilsDispatcher * num3;
			num3 = num4 * utilsDispatcher + num3 * m_PredicateDispatcher;
		}
		m_PublisherDispatcher.Add(new IntPoint(Round((double)_ResolverDispatcher[int_0].X + serverDispatcher[int_0].X * _AdapterDispatcher), Round((double)_ResolverDispatcher[int_0].Y + serverDispatcher[int_0].Y * _AdapterDispatcher)));
	}
}
