using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Buffer;

public class OffsetCurveBuilder
{
	public const int DEFAULT_QUADRANT_SEGMENTS = 8;

	private readonly double templateRule;

	private readonly LineIntersector m_MappingRule;

	private readonly LineSegment _MockRule = new LineSegment();

	private readonly LineSegment m_TagRule = new LineSegment();

	private readonly PrecisionModel m_FieldRule;

	private readonly LineSegment _QueueRule = new LineSegment();

	private readonly LineSegment regRule = new LineSegment();

	private double _ParamRule;

	private BufferStyle m_PageRule = BufferStyle.CapRound;

	private IList<Coordinate> m_RulesRule;

	private Coordinate m_MethodRule;

	private Coordinate serviceRule;

	private Coordinate m_SystemRule;

	private PositionType candidateRule;

	public virtual BufferStyle EndCapStyle
	{
		get
		{
			return m_PageRule;
		}
		set
		{
			m_PageRule = value;
		}
	}

	private IList<Coordinate> Coordinates
	{
		get
		{
			if (m_RulesRule.Count > 1)
			{
				Coordinate coordinate = m_RulesRule.First();
				Coordinate obj = m_RulesRule.Last();
				if (!coordinate.Equals(obj))
				{
					DeleteObject(coordinate);
				}
			}
			return m_RulesRule;
		}
	}

	public OffsetCurveBuilder(PrecisionModel precisionModel_0)
		: this(precisionModel_0, 8)
	{
	}

	public OffsetCurveBuilder(PrecisionModel precisionModel_0, int int_0)
	{
		m_FieldRule = precisionModel_0;
		m_MappingRule = new RobustLineIntersector();
		templateRule = Math.PI / 2.0 / (double)((int_0 < 1) ? 1 : int_0);
	}

	public virtual IList GetLineCurve(IList<Coordinate> ilist_0, double double_0)
	{
		IList list = new ArrayList();
		if (double_0 <= 0.0)
		{
			return list;
		}
		CloneObject(double_0);
		if (ilist_0.Count <= 1)
		{
			switch (m_PageRule)
			{
			case BufferStyle.CapSquare:
				LoginObject(ilist_0[0], double_0);
				break;
			case BufferStyle.CapRound:
				ValidateObject(ilist_0[0], double_0);
				break;
			}
		}
		else
		{
			ConnectObject(ilist_0);
		}
		IList<Coordinate> coordinates = Coordinates;
		list.Add(coordinates);
		return list;
	}

	public virtual IList GetRingCurve(IList<Coordinate> ilist_0, PositionType positionType_0, double double_0)
	{
		IList list = new ArrayList();
		CloneObject(double_0);
		if (ilist_0.Count <= 2)
		{
			return GetLineCurve(ilist_0, double_0);
		}
		if (double_0 == 0.0)
		{
			list.Add(CustomizeObject(ilist_0));
			return list;
		}
		MoveObject(ilist_0, positionType_0);
		list.Add(Coordinates);
		return list;
	}

	private static IList<Coordinate> CustomizeObject(IEnumerable<Coordinate> ienumerable_0)
	{
		return ienumerable_0.CloneList();
	}

	private void CloneObject(double double_0)
	{
		_ParamRule = double_0;
		m_RulesRule = new List<Coordinate>();
	}

	private void ConnectObject(IList<Coordinate> ilist_0)
	{
		int num = ilist_0.Count - 1;
		DestroyObject(ilist_0[0], ilist_0[1], PositionType.Left);
		for (int i = 2; i <= num; i++)
		{
			ComputeObject(ilist_0[i], bool_0: true);
		}
		PatchObject();
		CallObject(ilist_0[num - 1], ilist_0[num]);
		DestroyObject(ilist_0[num], ilist_0[num - 1], PositionType.Left);
		for (int num2 = num - 2; num2 >= 0; num2--)
		{
			ComputeObject(ilist_0[num2], bool_0: true);
		}
		PatchObject();
		CallObject(ilist_0[1], ilist_0[0]);
		AddObject();
	}

	private void MoveObject(IList<Coordinate> ilist_0, PositionType positionType_0)
	{
		int num = ilist_0.Count - 1;
		DestroyObject(ilist_0[num - 1], ilist_0[0], positionType_0);
		for (int i = 1; i <= num; i++)
		{
			bool bool_ = i != 1;
			ComputeObject(ilist_0[i], bool_);
		}
		AddObject();
	}

	private void DeleteObject(Coordinate coordinate_0)
	{
		Coordinate coordinate = new Coordinate(coordinate_0);
		m_FieldRule.MakePrecise(coordinate);
		Coordinate coordinate2 = null;
		if (m_RulesRule.Count >= 1)
		{
			coordinate2 = m_RulesRule.Last();
		}
		if (coordinate2 == null || !coordinate.Equals(coordinate2))
		{
			m_RulesRule.Add(coordinate);
		}
	}

	private void AddObject()
	{
		if (m_RulesRule.Count >= 1)
		{
			Coordinate coordinate = new Coordinate(m_RulesRule[0]);
			Coordinate obj = m_RulesRule[m_RulesRule.Count - 1];
			if (!coordinate.Equals(obj))
			{
				m_RulesRule.Add(coordinate);
			}
		}
	}

	private void DestroyObject(Coordinate coordinate_0, Coordinate coordinate_1, PositionType positionType_0)
	{
		serviceRule = coordinate_0;
		m_SystemRule = coordinate_1;
		candidateRule = positionType_0;
		regRule.SetCoordinates(coordinate_0, coordinate_1);
		SelectObject(regRule, positionType_0, _ParamRule, m_TagRule);
	}

	private void ComputeObject(Coordinate coordinate_0, bool bool_0)
	{
		m_MethodRule = serviceRule;
		serviceRule = m_SystemRule;
		m_SystemRule = coordinate_0;
		_QueueRule.SetCoordinates(m_MethodRule, serviceRule);
		SelectObject(_QueueRule, candidateRule, _ParamRule, _MockRule);
		regRule.SetCoordinates(serviceRule, m_SystemRule);
		SelectObject(regRule, candidateRule, _ParamRule, m_TagRule);
		if (serviceRule.Equals(m_SystemRule))
		{
			return;
		}
		int num = CgAlgorithms.ComputeOrientation(m_MethodRule, serviceRule, m_SystemRule);
		bool flag = (num == -1 && candidateRule == PositionType.Left) || (num == 1 && candidateRule == PositionType.Right);
		if (num == 0)
		{
			m_MappingRule.ComputeIntersection(m_MethodRule, serviceRule, serviceRule, m_SystemRule);
			if (m_MappingRule.IntersectionNum >= 2)
			{
				LogoutObject(serviceRule, _MockRule.P1, m_TagRule.P0, -1, _ParamRule);
			}
			return;
		}
		if (flag)
		{
			if (bool_0)
			{
				DeleteObject(_MockRule.P1);
			}
			LogoutObject(serviceRule, _MockRule.P1, m_TagRule.P0, num, _ParamRule);
			DeleteObject(m_TagRule.P0);
			return;
		}
		m_MappingRule.ComputeIntersection(_MockRule.P0, _MockRule.P1, m_TagRule.P0, m_TagRule.P1);
		if (m_MappingRule.HasIntersection)
		{
			DeleteObject(m_MappingRule.GetIntersection(0));
			return;
		}
		if (new Coordinate(_MockRule.P1).Distance(m_TagRule.P0) < _ParamRule / 1000.0)
		{
			DeleteObject(_MockRule.P1);
			return;
		}
		DeleteObject(_MockRule.P1);
		DeleteObject(serviceRule);
		DeleteObject(m_TagRule.P0);
	}

	private void PatchObject()
	{
		DeleteObject(m_TagRule.P1);
	}

	private static void SelectObject(ILineSegmentBase ilineSegmentBase_0, PositionType positionType_0, double double_0, ILineSegmentBase ilineSegmentBase_1)
	{
		int num = ((positionType_0 == PositionType.Left) ? 1 : (-1));
		double num2 = ilineSegmentBase_0.P1.X - ilineSegmentBase_0.P0.X;
		double num3 = ilineSegmentBase_0.P1.Y - ilineSegmentBase_0.P0.Y;
		double num4 = Math.Sqrt(num2 * num2 + num3 * num3);
		double num5 = (double)num * double_0 * num2 / num4;
		double num6 = (double)num * double_0 * num3 / num4;
		ilineSegmentBase_1.P0.X = ilineSegmentBase_0.P0.X - num6;
		ilineSegmentBase_1.P0.Y = ilineSegmentBase_0.P0.Y + num5;
		ilineSegmentBase_1.P1.X = ilineSegmentBase_0.P1.X - num6;
		ilineSegmentBase_1.P1.Y = ilineSegmentBase_0.P1.Y + num5;
	}

	private void CallObject(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		LineSegment ilineSegmentBase_ = new LineSegment(coordinate_0, coordinate_1);
		LineSegment lineSegment = new LineSegment();
		SelectObject(ilineSegmentBase_, PositionType.Left, _ParamRule, lineSegment);
		LineSegment lineSegment2 = new LineSegment();
		SelectObject(ilineSegmentBase_, PositionType.Right, _ParamRule, lineSegment2);
		double x = coordinate_1.X - coordinate_0.X;
		double num = Math.Atan2(coordinate_1.Y - coordinate_0.Y, x);
		switch (m_PageRule)
		{
		case BufferStyle.CapRound:
			DeleteObject(lineSegment.P1);
			ViewObject(coordinate_1, num + Math.PI / 2.0, num - Math.PI / 2.0, -1, _ParamRule);
			DeleteObject(lineSegment2.P1);
			break;
		case BufferStyle.CapButt:
			DeleteObject(lineSegment.P1);
			DeleteObject(lineSegment2.P1);
			break;
		case BufferStyle.CapSquare:
		{
			Coordinate coordinate = new Coordinate();
			coordinate.X = Math.Abs(_ParamRule) * Math.Cos(num);
			coordinate.Y = Math.Abs(_ParamRule) * Math.Sin(num);
			Coordinate coordinate_2 = new Coordinate(lineSegment.P1.X + coordinate.X, lineSegment.P1.Y + coordinate.Y);
			Coordinate coordinate_3 = new Coordinate(lineSegment2.P1.X + coordinate.X, lineSegment2.P1.Y + coordinate.Y);
			DeleteObject(coordinate_2);
			DeleteObject(coordinate_3);
			break;
		}
		}
	}

	private void LogoutObject(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, int int_0, double double_0)
	{
		double x = coordinate_1.X - coordinate_0.X;
		double num = Math.Atan2(coordinate_1.Y - coordinate_0.Y, x);
		double x2 = coordinate_2.X - coordinate_0.X;
		double num2 = Math.Atan2(coordinate_2.Y - coordinate_0.Y, x2);
		if (int_0 == -1)
		{
			if (num <= num2)
			{
				num += Math.PI * 2.0;
			}
		}
		else if (num >= num2)
		{
			num -= Math.PI * 2.0;
		}
		DeleteObject(coordinate_1);
		ViewObject(coordinate_0, num, num2, int_0, double_0);
		DeleteObject(coordinate_2);
	}

	private void ViewObject(Coordinate coordinate_0, double double_0, double double_1, int int_0, double double_2)
	{
		int num = ((int_0 != -1) ? 1 : (-1));
		double num2 = Math.Abs(double_0 - double_1);
		int num3 = (int)(num2 / templateRule + 0.5);
		if (num3 >= 1)
		{
			double num4 = num2 / (double)num3;
			double num5 = 0.0;
			Coordinate coordinate = new Coordinate();
			for (; num5 < num2; num5 += num4)
			{
				double num6 = double_0 + (double)num * num5;
				coordinate.X = coordinate_0.X + double_2 * Math.Cos(num6);
				coordinate.Y = coordinate_0.Y + double_2 * Math.Sin(num6);
				DeleteObject(coordinate);
			}
		}
	}

	private void ValidateObject(Coordinate coordinate_0, double double_0)
	{
		Coordinate coordinate_ = new Coordinate(coordinate_0.X + double_0, coordinate_0.Y);
		DeleteObject(coordinate_);
		ViewObject(coordinate_0, 0.0, Math.PI * 2.0, -1, double_0);
	}

	private void LoginObject(Coordinate coordinate_0, double double_0)
	{
		DeleteObject(new Coordinate(coordinate_0.X + double_0, coordinate_0.Y + double_0));
		DeleteObject(new Coordinate(coordinate_0.X + double_0, coordinate_0.Y - double_0));
		DeleteObject(new Coordinate(coordinate_0.X - double_0, coordinate_0.Y - double_0));
		DeleteObject(new Coordinate(coordinate_0.X - double_0, coordinate_0.Y + double_0));
		DeleteObject(new Coordinate(coordinate_0.X + double_0, coordinate_0.Y + double_0));
	}
}
