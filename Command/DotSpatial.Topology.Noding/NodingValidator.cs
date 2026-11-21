using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class NodingValidator
{
	private readonly LineIntersector m_ProcessCollection = new RobustLineIntersector();

	private readonly IList _ThreadCollection;

	public NodingValidator(IList ilist_0)
	{
		_ThreadCollection = ilist_0;
	}

	public void CheckValid()
	{
		ListObject();
		TestObject();
		ReflectObject();
	}

	private void ReflectObject()
	{
		foreach (SegmentString item in _ThreadCollection)
		{
			VisitObject(item);
		}
	}

	private static void VisitObject(SegmentString segmentString_0)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		for (int i = 0; i < coordinates.Count - 2; i++)
		{
			RestartObject(coordinates[i], coordinates[i + 1], coordinates[i + 2]);
		}
	}

	private static void RestartObject(object object_0, object object_1, object object_2)
	{
		if (object_0.Equals(object_2))
		{
			throw new Exception("found non-noded collapse at: " + object_0?.ToString() + ", " + object_1?.ToString() + " " + object_2);
		}
	}

	private void TestObject()
	{
		foreach (SegmentString item in _ThreadCollection)
		{
			foreach (SegmentString item2 in _ThreadCollection)
			{
				StopObject(item, item2);
			}
		}
	}

	private void StopObject(SegmentString segmentString_0, SegmentString segmentString_1)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		IList<Coordinate> coordinates2 = segmentString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				CancelObject(segmentString_0, i, segmentString_1, j);
			}
		}
	}

	private void CancelObject(SegmentString segmentString_0, int int_0, SegmentString segmentString_1, int int_1)
	{
		if (segmentString_0 != segmentString_1 || int_0 != int_1)
		{
			Coordinate coordinate = segmentString_0.Coordinates[int_0];
			Coordinate coordinate2 = segmentString_0.Coordinates[int_0 + 1];
			Coordinate coordinate3 = segmentString_1.Coordinates[int_1];
			Coordinate coordinate4 = segmentString_1.Coordinates[int_1 + 1];
			m_ProcessCollection.ComputeIntersection(coordinate, coordinate2, coordinate3, coordinate4);
			if (m_ProcessCollection.HasIntersection && (m_ProcessCollection.IsProper || VerifyObject(m_ProcessCollection, coordinate, coordinate2) || VerifyObject(m_ProcessCollection, coordinate3, coordinate4)))
			{
				throw new Exception("found non-noded intersection at " + ((object)coordinate)?.ToString() + "-" + ((object)coordinate2)?.ToString() + " and " + ((object)coordinate3)?.ToString() + "-" + (object)coordinate4);
			}
		}
	}

	private static bool VerifyObject(LineIntersector lineIntersector_0, object object_0, object object_1)
	{
		int num = 0;
		while (true)
		{
			if (num < lineIntersector_0.IntersectionNum)
			{
				Coordinate intersection = lineIntersector_0.GetIntersection(num);
				if (!intersection.Equals(object_0) && !intersection.Equals(object_1))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void ListObject()
	{
		foreach (SegmentString item in _ThreadCollection)
		{
			IList<Coordinate> coordinates = item.Coordinates;
			ResolveObject(coordinates[0], _ThreadCollection);
			ResolveObject(coordinates[coordinates.Count - 1], _ThreadCollection);
		}
	}

	private static void ResolveObject(object object_0, IEnumerable ienumerable_0)
	{
		foreach (SegmentString item in ienumerable_0)
		{
			IList<Coordinate> coordinates = item.Coordinates;
			for (int i = 1; i < coordinates.Count - 1; i++)
			{
				if (coordinates[i].Equals(object_0))
				{
					throw new Exception("found endpt/interior pt intersection at index " + i + " :pt " + object_0);
				}
			}
		}
	}
}
