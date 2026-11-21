using System.Collections;
using System.IO;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public class DirectedEdgeStar : EdgeEndStar
{
	private Label threadInstance;

	private IList _RuleInstance;

	public virtual Label Label => threadInstance;

	public override void Insert(EdgeEnd edgeEnd_0)
	{
		DirectedEdge directedEdge = (DirectedEdge)edgeEnd_0;
		InsertEdgeEnd(directedEdge, directedEdge);
	}

	public virtual int GetOutgoingDegree()
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((DirectedEdge)enumerator.Current).IsInResult)
			{
				num++;
			}
		}
		return num;
	}

	public virtual int GetOutgoingDegree(EdgeRing edgeRing_0)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((DirectedEdge)enumerator.Current).EdgeRing == edgeRing_0)
			{
				num++;
			}
		}
		return num;
	}

	public virtual DirectedEdge GetRightmostEdge()
	{
		IList edges = Edges;
		int count = edges.Count;
		if (count < 1)
		{
			return null;
		}
		DirectedEdge directedEdge = (DirectedEdge)edges[0];
		if (count == 1)
		{
			return directedEdge;
		}
		DirectedEdge directedEdge2 = (DirectedEdge)edges[count - 1];
		int quadrant = directedEdge.Quadrant;
		int quadrant2 = directedEdge2.Quadrant;
		if (QuadrantOp.IsNorthern(quadrant) && QuadrantOp.IsNorthern(quadrant2))
		{
			return directedEdge;
		}
		if (!QuadrantOp.IsNorthern(quadrant) && !QuadrantOp.IsNorthern(quadrant2))
		{
			return directedEdge2;
		}
		if (directedEdge.Dy == 0.0)
		{
			if (directedEdge2.Dy == 0.0)
			{
				throw new TwoHorizontalEdgesException();
			}
			return directedEdge2;
		}
		return directedEdge;
	}

	public override void ComputeLabelling(GeometryGraph[] geometryGraph_0)
	{
		base.ComputeLabelling(geometryGraph_0);
		threadInstance = new Label(LocationType.Null);
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Label label = ((EdgeEnd)enumerator.Current).Edge.Label;
			for (int i = 0; i < 2; i++)
			{
				LocationType location = label.GetLocation(i);
				if (location == LocationType.Interior || location == LocationType.Boundary)
				{
					threadInstance.SetLocation(i, LocationType.Interior);
				}
			}
		}
	}

	public virtual void MergeSymLabels()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			directedEdge.Label.Merge(directedEdge.Sym.Label);
		}
	}

	public virtual void UpdateLabelling(Label label_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Label label = ((DirectedEdge)enumerator.Current).Label;
			label.SetAllLocationsIfNull(0, label_0.GetLocation(0));
			label.SetAllLocationsIfNull(1, label_0.GetLocation(1));
		}
	}

	private void ReflectParameter()
	{
		if (_RuleInstance != null)
		{
			return;
		}
		_RuleInstance = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsInResult || directedEdge.Sym.IsInResult)
			{
				_RuleInstance.Add(directedEdge);
			}
		}
	}

	public virtual void LinkResultDirectedEdges()
	{
		ReflectParameter();
		DirectedEdge directedEdge = null;
		DirectedEdge directedEdge2 = null;
		int num = 1;
		for (int i = 0; i < _RuleInstance.Count; i++)
		{
			DirectedEdge directedEdge3 = (DirectedEdge)_RuleInstance[i];
			DirectedEdge sym = directedEdge3.Sym;
			if (!directedEdge3.Label.IsArea())
			{
				continue;
			}
			if (directedEdge == null && directedEdge3.IsInResult)
			{
				directedEdge = directedEdge3;
			}
			switch (num)
			{
			case 2:
				if (directedEdge3.IsInResult)
				{
					if (directedEdge2 != null)
					{
						directedEdge2.Next = directedEdge3;
					}
					num = 1;
				}
				break;
			case 1:
				if (sym.IsInResult)
				{
					directedEdge2 = sym;
					num = 2;
				}
				break;
			}
		}
		if (num == 2)
		{
			if (directedEdge == null)
			{
				throw new TopologyException("no outgoing dirEdge found", Coordinate);
			}
			Assert.IsTrue(directedEdge.IsInResult, "unable to link last incoming dirEdge");
			if (directedEdge2 != null)
			{
				directedEdge2.Next = directedEdge;
			}
		}
	}

	public virtual void LinkMinimalDirectedEdges(EdgeRing edgeRing_0)
	{
		DirectedEdge directedEdge = null;
		DirectedEdge directedEdge2 = null;
		int num = 1;
		for (int num2 = _RuleInstance.Count - 1; num2 >= 0; num2--)
		{
			DirectedEdge directedEdge3 = (DirectedEdge)_RuleInstance[num2];
			DirectedEdge sym = directedEdge3.Sym;
			if (directedEdge == null && directedEdge3.EdgeRing == edgeRing_0)
			{
				directedEdge = directedEdge3;
			}
			switch (num)
			{
			case 2:
				if (directedEdge3.EdgeRing == edgeRing_0)
				{
					if (directedEdge2 != null)
					{
						directedEdge2.NextMin = directedEdge3;
					}
					num = 1;
				}
				break;
			case 1:
				if (sym.EdgeRing == edgeRing_0)
				{
					directedEdge2 = sym;
					num = 2;
				}
				break;
			}
		}
		if (num != 2)
		{
			return;
		}
		Assert.IsTrue(directedEdge != null, "found null for first outgoing dirEdge");
		if (directedEdge != null)
		{
			Assert.IsTrue(directedEdge.EdgeRing == edgeRing_0, "unable to link last incoming dirEdge");
			if (directedEdge2 != null)
			{
				directedEdge2.NextMin = directedEdge;
			}
		}
	}

	public virtual void LinkAllDirectedEdges()
	{
		InitializeEdges();
		DirectedEdge directedEdge = null;
		DirectedEdge directedEdge2 = null;
		for (int num = base.EdgeList.Count - 1; num >= 0; num--)
		{
			DirectedEdge obj = (DirectedEdge)base.EdgeList[num];
			DirectedEdge sym = obj.Sym;
			if (directedEdge2 == null)
			{
				directedEdge2 = sym;
			}
			if (directedEdge != null)
			{
				sym.Next = directedEdge;
			}
			directedEdge = obj;
		}
		if (directedEdge2 != null)
		{
			directedEdge2.Next = directedEdge;
		}
	}

	public virtual void FindCoveredLineEdges()
	{
		LocationType locationType = LocationType.Null;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			DirectedEdge sym = directedEdge.Sym;
			if (!directedEdge.IsLineEdge)
			{
				if (directedEdge.IsInResult)
				{
					locationType = LocationType.Interior;
					break;
				}
				if (sym.IsInResult)
				{
					locationType = LocationType.Exterior;
					break;
				}
			}
		}
		if (locationType == LocationType.Null)
		{
			return;
		}
		LocationType locationType2 = locationType;
		IEnumerator enumerator2 = GetEnumerator();
		while (enumerator2.MoveNext())
		{
			DirectedEdge directedEdge2 = (DirectedEdge)enumerator2.Current;
			DirectedEdge sym2 = directedEdge2.Sym;
			if (directedEdge2.IsLineEdge)
			{
				directedEdge2.Edge.IsCovered = locationType2 == LocationType.Interior;
				continue;
			}
			if (directedEdge2.IsInResult)
			{
				locationType2 = LocationType.Exterior;
			}
			if (sym2.IsInResult)
			{
				locationType2 = LocationType.Interior;
			}
		}
	}

	public virtual void ComputeDepths(DirectedEdge directedEdge_0)
	{
		int num = FindIndex(directedEdge_0);
		int depth = directedEdge_0.GetDepth(PositionType.Left);
		int depth2 = directedEdge_0.GetDepth(PositionType.Right);
		int int_ = VisitParameter(num + 1, base.EdgeList.Count, depth);
		if (VisitParameter(0, num, int_) != depth2)
		{
			throw new TopologyException("depth mismatch at " + (object)directedEdge_0.Coordinate);
		}
	}

	private int VisitParameter(int int_0, int int_1, int int_2)
	{
		int num = int_2;
		for (int i = int_0; i < int_1; i++)
		{
			DirectedEdge obj = (DirectedEdge)base.EdgeList[i];
			obj.SetEdgeDepths(PositionType.Right, num);
			num = obj.GetDepth(PositionType.Left);
		}
		return num;
	}

	public override void Write(StreamWriter streamWriter_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge obj = (DirectedEdge)enumerator.Current;
			streamWriter_0.Write("out ");
			obj.Write(streamWriter_0);
			streamWriter_0.WriteLine();
			streamWriter_0.Write("in ");
			obj.Sym.Write(streamWriter_0);
			streamWriter_0.WriteLine();
		}
	}
}
