using System.Collections;
using DotSpatial.Topology.Noding;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeNodingValidator
{
	private readonly NodingValidator _RequestInstance;

	public EdgeNodingValidator(IEnumerable ienumerable_0)
	{
		_RequestInstance = new NodingValidator(CancelParameter(ienumerable_0));
	}

	private static IList CancelParameter(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			list.Add(new SegmentString(edge.Coordinates, edge));
		}
		return list;
	}

	public virtual void CheckValid()
	{
		_RequestInstance.CheckValid();
	}
}
