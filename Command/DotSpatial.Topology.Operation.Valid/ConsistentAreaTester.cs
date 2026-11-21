using System.Collections;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;
using DotSpatial.Topology.Operation.Relate;

namespace DotSpatial.Topology.Operation.Valid;

public class ConsistentAreaTester
{
	private readonly GeometryGraph m_RegThread;

	private readonly LineIntersector _ParamThread = new RobustLineIntersector();

	private readonly RelateNodeGraph pageThread = new RelateNodeGraph();

	private Coordinate m_RulesThread;

	public virtual Coordinate InvalidPoint => m_RulesThread;

	public virtual bool IsNodeConsistentArea
	{
		get
		{
			SegmentIntersector segmentIntersector = m_RegThread.ComputeSelfNodes(_ParamThread, bool_0: true);
			if (segmentIntersector.HasProperIntersection)
			{
				m_RulesThread = segmentIntersector.ProperIntersectionPoint;
				return false;
			}
			pageThread.Build(m_RegThread);
			return GetCollection();
		}
	}

	public virtual bool HasDuplicateRings
	{
		get
		{
			IEnumerator nodeEnumerator = pageThread.GetNodeEnumerator();
			while (nodeEnumerator.MoveNext())
			{
				IEnumerator enumerator = ((RelateNode)nodeEnumerator.Current).Edges.GetEnumerator();
				while (enumerator.MoveNext())
				{
					EdgeEndBundle edgeEndBundle = (EdgeEndBundle)enumerator.Current;
					if (edgeEndBundle.EdgeEnds.Count > 1)
					{
						m_RulesThread = edgeEndBundle.Edge.GetCoordinate(0);
						return true;
					}
				}
			}
			return false;
		}
	}

	[SpecialName]
	private bool GetCollection()
	{
		IEnumerator nodeEnumerator = pageThread.GetNodeEnumerator();
		RelateNode relateNode;
		do
		{
			if (nodeEnumerator.MoveNext())
			{
				relateNode = (RelateNode)nodeEnumerator.Current;
				continue;
			}
			return true;
		}
		while (relateNode.Edges.IsAreaLabelsConsistent);
		m_RulesThread = (Coordinate)relateNode.Coordinate.Clone();
		return false;
	}

	public ConsistentAreaTester(GeometryGraph geometryGraph_0)
	{
		m_RegThread = geometryGraph_0;
	}
}
