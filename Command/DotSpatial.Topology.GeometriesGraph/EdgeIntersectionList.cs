using System.Collections;
using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeIntersectionList
{
	private readonly Edge _RepositoryInstance;

	private readonly IDictionary _BridgeInstance = new SortedList();

	public int Count => _BridgeInstance.Count;

	public EdgeIntersectionList(Edge edge_0)
	{
		_RepositoryInstance = edge_0;
	}

	public virtual void Add(Coordinate coordinate_0, int int_0, double double_0)
	{
		EdgeIntersection edgeIntersection = new EdgeIntersection(coordinate_0, int_0, double_0);
		if ((EdgeIntersection)_BridgeInstance[edgeIntersection] == null)
		{
			_BridgeInstance.Add(edgeIntersection, edgeIntersection);
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		return _BridgeInstance.Values.GetEnumerator();
	}

	public virtual bool IsIntersection(Coordinate coordinate_0)
	{
		IEnumerator enumerator = GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!((EdgeIntersection)enumerator.Current).Coordinate.Equals(coordinate_0));
		return true;
	}

	public virtual void AddEndpoints()
	{
		int num = _RepositoryInstance.Points.Count - 1;
		Add(_RepositoryInstance.Points[0], 0, 0.0);
		Add(_RepositoryInstance.Points[num], num, 0.0);
	}

	public virtual void AddSplitEdges(IList ilist_0)
	{
		AddEndpoints();
		IEnumerator enumerator = GetEnumerator();
		enumerator.MoveNext();
		EdgeIntersection edgeIntersection_ = (EdgeIntersection)enumerator.Current;
		while (enumerator.MoveNext())
		{
			EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator.Current;
			Edge value = CreateSplitEdge(edgeIntersection_, edgeIntersection);
			ilist_0.Add(value);
			edgeIntersection_ = edgeIntersection;
		}
	}

	public virtual Edge CreateSplitEdge(EdgeIntersection edgeIntersection_0, EdgeIntersection edgeIntersection_1)
	{
		int num = edgeIntersection_1.SegmentIndex - edgeIntersection_0.SegmentIndex + 2;
		Coordinate coordinate_ = _RepositoryInstance.Points[edgeIntersection_1.SegmentIndex];
		bool flag;
		if (!(flag = edgeIntersection_1.Distance > 0.0 || !edgeIntersection_1.Coordinate.Equals2D(coordinate_)))
		{
			num--;
		}
		Coordinate[] array = new Coordinate[num];
		int num2 = 0;
		num2 = 1;
		array[0] = new Coordinate(edgeIntersection_0.Coordinate);
		for (int i = edgeIntersection_0.SegmentIndex + 1; i <= edgeIntersection_1.SegmentIndex; i++)
		{
			array[num2++] = _RepositoryInstance.Points[i];
		}
		if (flag)
		{
			array[num2] = edgeIntersection_1.Coordinate;
		}
		return new Edge(array, new Label(_RepositoryInstance.Label));
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.WriteLine("Intersections:");
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeIntersection)enumerator.Current).Write(streamWriter_0);
		}
	}
}
