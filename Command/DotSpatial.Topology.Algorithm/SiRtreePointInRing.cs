using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Index.Strtree;

namespace DotSpatial.Topology.Algorithm;

public class SiRtreePointInRing : IPointInRing
{
	private readonly LinearRing collectionObject;

	private int instanceObject;

	private SiRtree m_ObjectObject;

	public SiRtreePointInRing(LinearRing linearRing_0)
	{
		collectionObject = linearRing_0;
		InsertExpression();
	}

	public bool IsInside(Coordinate coordinate_0)
	{
		instanceObject = 0;
		IEnumerator enumerator = m_ObjectObject.Query(coordinate_0.Y).GetEnumerator();
		while (enumerator.MoveNext())
		{
			LineSegment ilineSegmentBase_ = (LineSegment)enumerator.Current;
			PrepareExpression(coordinate_0, ilineSegmentBase_);
		}
		if (instanceObject % 2 == 1)
		{
			return true;
		}
		return false;
	}

	private void InsertExpression()
	{
		m_ObjectObject = new SiRtree();
		IList<Coordinate> coordinates = collectionObject.Coordinates;
		for (int i = 1; i < coordinates.Count; i++)
		{
			if (!coordinates[i - 1].Equals(coordinates[i]))
			{
				LineSegment lineSegment = new LineSegment(coordinates[i - 1], coordinates[i]);
				m_ObjectObject.Insert(lineSegment.P0.Y, lineSegment.P1.Y, lineSegment);
			}
		}
	}

	private void PrepareExpression(Coordinate coordinate_0, ILineSegmentBase ilineSegmentBase_0)
	{
		Coordinate p = ilineSegmentBase_0.P0;
		Coordinate p2 = ilineSegmentBase_0.P1;
		double double_ = p.X - coordinate_0.X;
		double num = p.Y - coordinate_0.Y;
		double double_2 = p2.X - coordinate_0.X;
		double num2 = p2.Y - coordinate_0.Y;
		if ((num > 0.0 && num2 <= 0.0) || (num2 > 0.0 && num <= 0.0))
		{
			double num3 = (double)RobustDeterminant.SignOfDet2X2(double_, num, double_2, num2) / (num2 - num);
			if (0.0 < num3)
			{
				instanceObject++;
			}
		}
	}
}
