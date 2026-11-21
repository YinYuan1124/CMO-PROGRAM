using System.Collections;
using DotSpatial.Topology.Planargraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMerger
{
	private class RecordCallbackCandidate : IGeometryComponentFilter
	{
		private readonly LineMerger refPrototype;

		public RecordCallbackCandidate(LineMerger lineMerger_0)
		{
			refPrototype = lineMerger_0;
		}

		public void Filter(IGeometry igeometry_0)
		{
			if (igeometry_0 is LineString)
			{
				refPrototype.Add((LineString)igeometry_0);
			}
		}
	}

	private readonly LineMergeGraph serializerRule = new LineMergeGraph();

	private IList _RefRule;

	private IGeometryFactory m_ErrorRule;

	private IList codeRule;

	public virtual IList MergedLineStrings
	{
		get
		{
			PrepareInstance();
			return codeRule;
		}
	}

	public virtual void Add(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Geometry geometry_ = (Geometry)enumerator.Current;
			Add(geometry_);
		}
	}

	public virtual void Add(Geometry geometry_0)
	{
		geometry_0.Apply(new RecordCallbackCandidate(this));
	}

	private void Add(LineString lineString_0)
	{
		if (m_ErrorRule == null)
		{
			m_ErrorRule = lineString_0.Factory;
		}
		serializerRule.AddEdge(lineString_0);
	}

	private void PrepareInstance()
	{
		if (codeRule == null)
		{
			_RefRule = new ArrayList();
			ReflectInstance();
			VisitInstance();
			codeRule = new ArrayList();
			IEnumerator enumerator = _RefRule.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeString edgeString = (EdgeString)enumerator.Current;
				codeRule.Add(edgeString.ToLineString());
			}
		}
	}

	private void ReflectInstance()
	{
		TestInstance();
	}

	private void VisitInstance()
	{
		RestartInstance();
	}

	private void RestartInstance()
	{
		IEnumerator enumerator = serializerRule.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (!node.IsMarked)
			{
				Assert.IsTrue(node.Degree == 2);
				StopInstance(node);
				node.IsMarked = true;
			}
		}
	}

	private void TestInstance()
	{
		IEnumerator enumerator = serializerRule.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (node.Degree != 2)
			{
				StopInstance(node);
				node.IsMarked = true;
			}
		}
	}

	private void StopInstance(Node node_0)
	{
		IEnumerator enumerator = node_0.OutEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			LineMergeDirectedEdge lineMergeDirectedEdge = (LineMergeDirectedEdge)enumerator.Current;
			if (!lineMergeDirectedEdge.Edge.IsMarked)
			{
				_RefRule.Add(CancelInstance(lineMergeDirectedEdge));
			}
		}
	}

	private EdgeString CancelInstance(LineMergeDirectedEdge lineMergeDirectedEdge_0)
	{
		EdgeString edgeString = new EdgeString(m_ErrorRule);
		LineMergeDirectedEdge lineMergeDirectedEdge = lineMergeDirectedEdge_0;
		do
		{
			edgeString.Add(lineMergeDirectedEdge);
			lineMergeDirectedEdge.Edge.IsMarked = true;
			lineMergeDirectedEdge = lineMergeDirectedEdge.Next;
		}
		while (lineMergeDirectedEdge != null && lineMergeDirectedEdge != lineMergeDirectedEdge_0);
		return edgeString;
	}
}
