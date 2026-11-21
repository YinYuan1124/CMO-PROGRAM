using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize;

public class EdgeRing
{
	private readonly IList m_ParameterRule = new ArrayList();

	private readonly IGeometryFactory m_ExpressionRule;

	private IList dispatcherRule;

	private ILinearRing _ListenerRule;

	private IList<Coordinate> _ConfigRule;

	public virtual bool IsHole => CgAlgorithms.IsCounterClockwise(Ring.Coordinates);

	public virtual IPolygon Polygon
	{
		get
		{
			ILinearRing[] array = null;
			if (dispatcherRule != null)
			{
				array = new ILinearRing[dispatcherRule.Count];
				for (int i = 0; i < dispatcherRule.Count; i++)
				{
					array[i] = (ILinearRing)dispatcherRule[i];
				}
			}
			return m_ExpressionRule.CreatePolygon(_ListenerRule, array);
		}
	}

	public virtual bool IsValid
	{
		get
		{
			RateCollection();
			if (_ConfigRule.Count <= 3)
			{
				return false;
			}
			FlushCollection();
			return _ListenerRule.IsValid;
		}
	}

	private IList<Coordinate> Coordinates
	{
		get
		{
			RateCollection();
			return _ConfigRule;
		}
	}

	public virtual ILineString LineString => m_ExpressionRule.CreateLineString(Coordinates);

	public virtual ILinearRing Ring
	{
		get
		{
			FlushCollection();
			return _ListenerRule;
		}
	}

	public EdgeRing(IGeometryFactory igeometryFactory_0)
	{
		m_ExpressionRule = igeometryFactory_0;
	}

	public static EdgeRing FindEdgeRingContaining(EdgeRing edgeRing_0, IList ilist_0)
	{
		ILinearRing ring = edgeRing_0.Ring;
		IEnvelope envelopeInternal = ring.EnvelopeInternal;
		EdgeRing edgeRing = null;
		IEnvelope ienvelope_ = null;
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing2 = (EdgeRing)enumerator.Current;
			ILinearRing ring2 = edgeRing2.Ring;
			IEnvelope envelopeInternal2 = ring2.EnvelopeInternal;
			if (edgeRing != null)
			{
				ienvelope_ = edgeRing.Ring.EnvelopeInternal;
			}
			bool flag = false;
			if (!envelopeInternal2.Equals(envelopeInternal))
			{
				Coordinate coordinate_ = PtNotInList(ring.Coordinates, ring2.Coordinates);
				if (envelopeInternal2.Contains(envelopeInternal) && CgAlgorithms.IsPointInRing(coordinate_, ring2.Coordinates))
				{
					flag = true;
				}
				if (flag && (edgeRing == null || ienvelope_.Contains(envelopeInternal2)))
				{
					edgeRing = edgeRing2;
				}
			}
		}
		return edgeRing;
	}

	public static Coordinate PtNotInList(IList<Coordinate> ilist_0, IList<Coordinate> ilist_1)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if (!IsInList(ilist_0[i], ilist_1))
			{
				return new Coordinate(ilist_0[i]);
			}
		}
		return null;
	}

	public static bool IsInList(Coordinate coordinate_0, IList<Coordinate> ilist_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if (new Coordinate(coordinate_0).Equals(ilist_0[i]))
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Add(DirectedEdge directedEdge_0)
	{
		m_ParameterRule.Add(directedEdge_0);
	}

	public virtual void AddHole(ILinearRing ilinearRing_0)
	{
		if (dispatcherRule == null)
		{
			dispatcherRule = new ArrayList();
		}
		dispatcherRule.Add(ilinearRing_0);
	}

	private void RateCollection()
	{
		if (_ConfigRule == null)
		{
			CoordinateList coordinateList = new CoordinateList();
			IEnumerator enumerator = m_ParameterRule.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
				ForgotCollection(((PolygonizeEdge)directedEdge.Edge).Line.Coordinates, directedEdge.EdgeDirection, coordinateList);
			}
			_ConfigRule = coordinateList;
		}
	}

	private void FlushCollection()
	{
		if (_ListenerRule == null)
		{
			_ListenerRule = m_ExpressionRule.CreateLinearRing(Coordinates);
		}
	}

	private static void ForgotCollection(IList<Coordinate> ilist_0, bool bool_0, CoordinateList coordinateList_0)
	{
		if (bool_0)
		{
			for (int i = 0; i < ilist_0.Count; i++)
			{
				coordinateList_0.Add(ilist_0[i], bool_0: false);
			}
			return;
		}
		for (int num = ilist_0.Count - 1; num >= 0; num--)
		{
			coordinateList_0.Add(ilist_0[num], bool_0: false);
		}
	}
}
