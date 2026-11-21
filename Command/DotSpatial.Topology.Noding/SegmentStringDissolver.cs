using System.Collections;

namespace DotSpatial.Topology.Noding;

public class SegmentStringDissolver
{
	public interface GInterface6
	{
		void Merge(SegmentString segmentString_0, SegmentString segmentString_1, bool bool_0);
	}

	private readonly GInterface6 issuerCollection;

	private readonly IDictionary clientCollection = new SortedList();

	public ICollection Dissolved => clientCollection.Values;

	public SegmentStringDissolver(GInterface6 ginterface6_0)
	{
		issuerCollection = ginterface6_0;
	}

	public SegmentStringDissolver()
		: this(null)
	{
	}

	public void Dissolve(ICollection icollection_0)
	{
		foreach (object item in icollection_0)
		{
			Dissolve((SegmentString)item);
		}
	}

	private void Add(OrientedCoordinateArray orientedCoordinateArray_0, SegmentString segmentString_0)
	{
		clientCollection.Add(orientedCoordinateArray_0, segmentString_0);
	}

	public void Dissolve(SegmentString segmentString_0)
	{
		OrientedCoordinateArray orientedCoordinateArray_ = new OrientedCoordinateArray(segmentString_0.Coordinates);
		SegmentString segmentString = CollectObject(orientedCoordinateArray_);
		if (segmentString == null)
		{
			Add(orientedCoordinateArray_, segmentString_0);
		}
		else if (issuerCollection != null)
		{
			bool bool_ = object.Equals(segmentString.Coordinates, segmentString_0.Coordinates);
			issuerCollection.Merge(segmentString, segmentString_0, bool_);
		}
	}

	private SegmentString CollectObject(OrientedCoordinateArray orientedCoordinateArray_0)
	{
		return (SegmentString)clientCollection[orientedCoordinateArray_0];
	}
}
