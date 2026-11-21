using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Overlay;

public class PolygonBuilder
{
	private readonly IGeometryFactory interpreterRule;

	private readonly IList m_ContainerRule = new ArrayList();

	public virtual IList Polygons => DisableInstance(m_ContainerRule);

	public PolygonBuilder(IGeometryFactory igeometryFactory_0)
	{
		interpreterRule = igeometryFactory_0;
	}

	public virtual void Add(PlanarGraph planarGraph_0)
	{
		Add(planarGraph_0.EdgeEnds, planarGraph_0.NodeValues);
	}

	public virtual void Add(IList ilist_0, IList ilist_1)
	{
		PlanarGraph.LinkResultDirectedEdges(ilist_1);
		IList ienumerable_ = FillInstance(ilist_0);
		IList list = new ArrayList();
		CreateInstance(CalculateInstance(ienumerable_, m_ContainerRule, list), m_ContainerRule, list);
		CompareInstance(m_ContainerRule, list);
	}

	private IList FillInstance(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsInResult && directedEdge.Label.IsArea() && directedEdge.EdgeRing == null)
			{
				MaximalEdgeRing maximalEdgeRing = new MaximalEdgeRing(directedEdge, interpreterRule);
				list.Add(maximalEdgeRing);
				maximalEdgeRing.SetInResult();
			}
		}
		return list;
	}

	private static IList CalculateInstance(IEnumerable ienumerable_0, IList ilist_0, IList ilist_1)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MaximalEdgeRing maximalEdgeRing = (MaximalEdgeRing)enumerator.Current;
			if (maximalEdgeRing.MaxNodeDegree <= 2)
			{
				list.Add(maximalEdgeRing);
				continue;
			}
			maximalEdgeRing.LinkDirectedEdgesForMinimalEdgeRings();
			IList list2 = maximalEdgeRing.BuildMinimalRings();
			EdgeRing edgeRing = PopInstance(list2);
			if (edgeRing == null)
			{
				foreach (object item in list2)
				{
					ilist_1.Add(item);
				}
			}
			else
			{
				InstantiateInstance(edgeRing, list2);
				ilist_0.Add(edgeRing);
			}
		}
		return list;
	}

	private static EdgeRing PopInstance(IEnumerable ienumerable_0)
	{
		int num = 0;
		EdgeRing result = null;
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (MinimalEdgeRing)enumerator.Current;
			if (!edgeRing.IsHole)
			{
				result = edgeRing;
				num++;
			}
		}
		Assert.IsTrue(num <= 1, "found two shells in MinimalEdgeRing list");
		return result;
	}

	private static void InstantiateInstance(EdgeRing edgeRing_0, IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MinimalEdgeRing minimalEdgeRing = (MinimalEdgeRing)enumerator.Current;
			if (minimalEdgeRing.IsHole)
			{
				minimalEdgeRing.Shell = edgeRing_0;
			}
		}
	}

	private static void CreateInstance(IEnumerable ienumerable_0, IList ilist_0, IList ilist_1)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			edgeRing.SetInResult();
			if (edgeRing.IsHole)
			{
				ilist_1.Add(edgeRing);
			}
			else
			{
				ilist_0.Add(edgeRing);
			}
		}
	}

	private static void CompareInstance(IEnumerable ienumerable_0, IEnumerable ienumerable_1)
	{
		IEnumerator enumerator = ienumerable_1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			if (edgeRing.Shell == null)
			{
				EdgeRing edgeRing2 = ReadInstance(edgeRing, ienumerable_0);
				Assert.IsTrue(edgeRing2 != null, "unable to assign hole to a shell");
				edgeRing.Shell = edgeRing2;
			}
		}
	}

	private static EdgeRing ReadInstance(EdgeRing edgeRing_0, IEnumerable ienumerable_0)
	{
		ILinearRing linearRing = edgeRing_0.LinearRing;
		IEnvelope envelopeInternal = linearRing.EnvelopeInternal;
		Coordinate coordinate_ = linearRing.Coordinates[0];
		EdgeRing edgeRing = null;
		IEnvelope ienvelope_ = null;
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing2 = (EdgeRing)enumerator.Current;
			ILinearRing linearRing2 = edgeRing2.LinearRing;
			IEnvelope envelopeInternal2 = linearRing2.EnvelopeInternal;
			if (edgeRing != null)
			{
				ienvelope_ = edgeRing.LinearRing.EnvelopeInternal;
			}
			bool flag = false;
			if (envelopeInternal2.Contains(envelopeInternal) && CgAlgorithms.IsPointInRing(coordinate_, linearRing2.Coordinates))
			{
				flag = true;
			}
			if (flag && (edgeRing == null || ienvelope_.Contains(envelopeInternal2)))
			{
				edgeRing = edgeRing2;
			}
		}
		return edgeRing;
	}

	private IList DisableInstance(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IPolygon value = ((EdgeRing)enumerator.Current).ToPolygon(interpreterRule);
			list.Add(value);
		}
		return list;
	}

	public virtual bool ContainsPoint(Coordinate coordinate_0)
	{
		IEnumerator enumerator = m_ContainerRule.GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!((EdgeRing)enumerator.Current).ContainsPoint(coordinate_0));
		return true;
	}
}
