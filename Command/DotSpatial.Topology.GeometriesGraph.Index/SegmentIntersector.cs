using System;
using System.Collections;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SegmentIntersector
{
	private readonly bool _RecordInstance;

	private readonly LineIntersector m_ExceptionInstance;

	private readonly bool _AttrInstance;

	public int NumTests;

	private ICollection[] m_VisitorInstance;

	private bool exporterInstance;

	private bool m_PrototypeInstance;

	private bool _ComparatorInstance;

	private int itemInstance;

	private Coordinate m_SetterInstance;

	public virtual Coordinate ProperIntersectionPoint => m_SetterInstance;

	public virtual bool HasIntersection => exporterInstance;

	public virtual bool HasProperIntersection => m_PrototypeInstance;

	public virtual bool HasProperInteriorIntersection => _ComparatorInstance;

	public SegmentIntersector(LineIntersector lineIntersector_0, bool bool_0, bool bool_1)
	{
		m_ExceptionInstance = lineIntersector_0;
		_RecordInstance = bool_0;
		_AttrInstance = bool_1;
	}

	public static bool IsAdjacentSegments(int int_0, int int_1)
	{
		return Math.Abs(int_0 - int_1) == 1;
	}

	public virtual void SetBoundaryNodes(ICollection icollection_0, ICollection icollection_1)
	{
		m_VisitorInstance = new ICollection[2];
		m_VisitorInstance[0] = icollection_0;
		m_VisitorInstance[1] = icollection_1;
	}

	private bool SortParameter(Edge edge_0, int int_0, Edge edge_1, int int_1)
	{
		if ((object)edge_0 == edge_1 && m_ExceptionInstance.IntersectionNum == 1)
		{
			if (IsAdjacentSegments(int_0, int_1))
			{
				return true;
			}
			if (edge_0.IsClosed)
			{
				int num = edge_0.NumPoints - 1;
				if ((int_0 == 0 && int_1 == num) || (int_1 == 0 && int_0 == num))
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual void AddIntersections(Edge edge_0, int int_0, Edge edge_1, int int_1)
	{
		if ((object)edge_0 == edge_1 && int_0 == int_1)
		{
			return;
		}
		NumTests++;
		Coordinate coordinate_ = edge_0.Coordinates[int_0];
		Coordinate coordinate_2 = edge_0.Coordinates[int_0 + 1];
		Coordinate coordinate_3 = edge_1.Coordinates[int_1];
		Coordinate coordinate_4 = edge_1.Coordinates[int_1 + 1];
		m_ExceptionInstance.ComputeIntersection(coordinate_, coordinate_2, coordinate_3, coordinate_4);
		if (!m_ExceptionInstance.HasIntersection)
		{
			return;
		}
		if (_AttrInstance)
		{
			edge_0.Isolated = false;
			edge_1.Isolated = false;
		}
		itemInstance++;
		if (SortParameter(edge_0, int_0, edge_1, int_1))
		{
			return;
		}
		exporterInstance = true;
		if (_RecordInstance || !m_ExceptionInstance.IsProper)
		{
			edge_0.AddIntersections(m_ExceptionInstance, int_0, 0);
			edge_1.AddIntersections(m_ExceptionInstance, int_1, 1);
		}
		if (m_ExceptionInstance.IsProper)
		{
			m_SetterInstance = (Coordinate)m_ExceptionInstance.GetIntersection(0).Clone();
			m_PrototypeInstance = true;
			LineIntersector exceptionInstance = m_ExceptionInstance;
			object[] visitorInstance = m_VisitorInstance;
			if (!CalcParameter(exceptionInstance, visitorInstance))
			{
				_ComparatorInstance = true;
			}
		}
	}

	private static bool CalcParameter(LineIntersector lineIntersector_0, object[] object_0)
	{
		if (object_0 == null)
		{
			return false;
		}
		if (RateParameter(lineIntersector_0, (IEnumerable)object_0[0]))
		{
			return true;
		}
		if (RateParameter(lineIntersector_0, (IEnumerable)object_0[1]))
		{
			return true;
		}
		return false;
	}

	private static bool RateParameter(LineIntersector lineIntersector_0, IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		Coordinate coordinate;
		do
		{
			if (enumerator.MoveNext())
			{
				coordinate = ((Node)enumerator.Current).Coordinate;
				continue;
			}
			return false;
		}
		while (!lineIntersector_0.IsIntersection(coordinate));
		return true;
	}
}
