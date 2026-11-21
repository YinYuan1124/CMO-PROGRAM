using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public class NodeMap
{
	private readonly IDictionary comparatorThread = new SortedList();

	public virtual ICollection Values => comparatorThread.Values;

	public virtual Node Add(Node node_0)
	{
		Coordinate coordinate = node_0.Coordinate;
		if (!comparatorThread.Contains(coordinate))
		{
			comparatorThread.Add(coordinate, node_0);
		}
		return node_0;
	}

	public virtual Node Remove(Coordinate coordinate_0)
	{
		Node result = (Node)comparatorThread[coordinate_0];
		comparatorThread.Remove(coordinate_0);
		return result;
	}

	public virtual Node Find(Coordinate coordinate_0)
	{
		return (Node)comparatorThread[coordinate_0];
	}

	public virtual IEnumerator GetEnumerator()
	{
		return comparatorThread.Values.GetEnumerator();
	}
}
