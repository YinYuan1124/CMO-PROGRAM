using System;
using System.Collections;
using System.IO;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Noding;

public class SegmentNodeList : IEnumerable
{
	private readonly SegmentString registryCollection;

	private readonly IDictionary definitionCollection = new SortedList();

	public SegmentString Edge => registryCollection;

	public SegmentNodeList(SegmentString segmentString_0)
	{
		registryCollection = segmentString_0;
	}

	public IEnumerator GetEnumerator()
	{
		return definitionCollection.Values.GetEnumerator();
	}

	public void Add(Coordinate coordinate_0, int int_0)
	{
		SegmentNode segmentNode = new SegmentNode(registryCollection, coordinate_0, int_0, registryCollection.GetSegmentOctant(int_0));
		SegmentNode segmentNode2 = (SegmentNode)definitionCollection[segmentNode];
		if (segmentNode2 == null)
		{
			definitionCollection.Add(segmentNode, segmentNode);
		}
		else
		{
			Assert.IsTrue(segmentNode2.Coordinate.Equals2D(coordinate_0), "Found equal nodes with different coordinates");
		}
	}

	private void ResetObject()
	{
		int int_ = registryCollection.Count - 1;
		Add(registryCollection.GetCoordinate(0), 0);
		Add(registryCollection.GetCoordinate(int_), int_);
	}

	private void MapObject()
	{
		IList list = new ArrayList();
		CalcObject(list);
		SortObject(list);
		foreach (int item in list)
		{
			Add(registryCollection.GetCoordinate(item), item);
		}
	}

	private void SortObject(IList ilist_0)
	{
		for (int i = 0; i < registryCollection.Count - 2; i++)
		{
			Coordinate coordinate = registryCollection.GetCoordinate(i);
			Coordinate coordinate2 = registryCollection.GetCoordinate(i + 2);
			if (coordinate.Equals2D(coordinate2))
			{
				ilist_0.Add(i + 1);
			}
		}
	}

	private void CalcObject(IList ilist_0)
	{
		int[] array = new int[1];
		IEnumerator enumerator = GetEnumerator();
		enumerator.MoveNext();
		SegmentNode coordinate_ = (SegmentNode)enumerator.Current;
		while (enumerator.MoveNext())
		{
			SegmentNode segmentNode = (SegmentNode)enumerator.Current;
			if (RateObject(coordinate_, segmentNode, array))
			{
				ilist_0.Add(array[0]);
			}
			coordinate_ = segmentNode;
		}
	}

	private static bool RateObject(SegmentNode segmentNode, SegmentNode object_0, int[] int_0)
	{
		if (segmentNode.Coordinate.Equals2D(object_0.Coordinate))
		{
			int num = object_0.SegmentIndex - segmentNode.SegmentIndex;
			if (!object_0.IsInterior)
			{
				num--;
			}
			if (num == 1)
			{
				int_0[0] = segmentNode.SegmentIndex + 1;
				return true;
			}
			return false;
		}
		return false;
	}

	public void AddSplitEdges(IList ilist_0)
	{
		ResetObject();
		MapObject();
		IEnumerator enumerator = GetEnumerator();
		enumerator.MoveNext();
		SegmentNode segmentNode_ = (SegmentNode)enumerator.Current;
		while (enumerator.MoveNext())
		{
			SegmentNode segmentNode = (SegmentNode)enumerator.Current;
			SegmentString value = FlushObject(segmentNode_, segmentNode);
			ilist_0.Add(value);
			segmentNode_ = segmentNode;
		}
	}

	private SegmentString FlushObject(SegmentNode segmentNode_0, SegmentNode segmentNode_1)
	{
		int num = segmentNode_1.SegmentIndex - segmentNode_0.SegmentIndex + 2;
		Coordinate coordinate = registryCollection.GetCoordinate(segmentNode_1.SegmentIndex);
		bool flag;
		if (!(flag = segmentNode_1.IsInterior || !segmentNode_1.Coordinate.Equals2D(coordinate)))
		{
			num--;
		}
		Coordinate[] array = new Coordinate[num];
		int num2 = 0;
		num2 = 1;
		array[0] = new Coordinate(segmentNode_0.Coordinate);
		for (int i = segmentNode_0.SegmentIndex + 1; i <= segmentNode_1.SegmentIndex; i++)
		{
			array[num2++] = registryCollection.GetCoordinate(i);
		}
		if (flag)
		{
			array[num2] = segmentNode_1.Coordinate;
		}
		return new SegmentString(array, registryCollection.Data);
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.Write("Intersections:");
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((SegmentNode)enumerator.Current).Write(streamWriter_0);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}
