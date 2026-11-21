using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Noding;

namespace DotSpatial.Topology.Operation.Buffer;

public class OffsetCurveSetBuilder
{
	private readonly OffsetCurveBuilder _BaseRule;

	private readonly IList policyRule = new ArrayList();

	private readonly double m_BroadcasterRule;

	private readonly IGeometry m_IdentifierRule;

	public OffsetCurveSetBuilder(IGeometry igeometry_0, double double_0, OffsetCurveBuilder offsetCurveBuilder_0)
	{
		m_IdentifierRule = igeometry_0;
		m_BroadcasterRule = double_0;
		_BaseRule = offsetCurveBuilder_0;
	}

	public virtual IList GetCurves()
	{
		Add(m_IdentifierRule);
		return policyRule;
	}

	private void WriteObject(IEnumerable ienumerable_0, LocationType locationType_0, LocationType locationType_1)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			NewObject(enumerator.Current as IList<Coordinate>, locationType_0, locationType_1);
		}
	}

	private void NewObject(IList<Coordinate> ilist_0, LocationType locationType_0, LocationType locationType_1)
	{
		if (ilist_0.Count >= 2)
		{
			SegmentString value = new SegmentString(ilist_0, new Label(0, LocationType.Boundary, locationType_0, locationType_1));
			policyRule.Add(value);
		}
	}

	private void Add(IGeometry igeometry_0)
	{
		if (igeometry_0.IsEmpty)
		{
			return;
		}
		if (igeometry_0 is Polygon)
		{
			ExcludeObject((Polygon)igeometry_0);
			return;
		}
		if (igeometry_0 is LineString)
		{
			SetupObject((LineString)igeometry_0);
			return;
		}
		if (igeometry_0 is Point)
		{
			InvokeObject((Point)igeometry_0);
			return;
		}
		if (igeometry_0 is MultiPoint)
		{
			PushObject((MultiPoint)igeometry_0);
			return;
		}
		if (igeometry_0 is MultiLineString)
		{
			PushObject((MultiLineString)igeometry_0);
			return;
		}
		if (igeometry_0 is MultiPolygon)
		{
			PushObject((MultiPolygon)igeometry_0);
			return;
		}
		if (!(igeometry_0 is GeometryCollection))
		{
			throw new NotSupportedException(igeometry_0.GetType().FullName);
		}
		PushObject((GeometryCollection)igeometry_0);
	}

	private void PushObject(GInterface3 ginterface3_0)
	{
		for (int i = 0; i < ginterface3_0.NumGeometries; i++)
		{
			IGeometry geometryN = ginterface3_0.GetGeometryN(i);
			Add(geometryN);
		}
	}

	private void InvokeObject(IPoint ipoint_0)
	{
		if (m_BroadcasterRule > 0.0)
		{
			IList<Coordinate> coordinates = ipoint_0.Coordinates;
			IList lineCurve = _BaseRule.GetLineCurve(coordinates, m_BroadcasterRule);
			WriteObject(lineCurve, LocationType.Exterior, LocationType.Interior);
		}
	}

	private void SetupObject(ILineString ilineString_0)
	{
		if (m_BroadcasterRule > 0.0)
		{
			IList<Coordinate> ilist_ = CoordinateArrays.RemoveRepeatedPoints(ilineString_0.Coordinates);
			IList lineCurve = _BaseRule.GetLineCurve(ilist_, m_BroadcasterRule);
			WriteObject(lineCurve, LocationType.Exterior, LocationType.Interior);
		}
	}

	private void ExcludeObject(IPolygon ipolygon_0)
	{
		double double_ = m_BroadcasterRule;
		PositionType positionType_ = PositionType.Left;
		if (m_BroadcasterRule < 0.0)
		{
			double_ = 0.0 - m_BroadcasterRule;
			positionType_ = PositionType.Right;
		}
		IList<Coordinate> ilist_ = CoordinateArrays.RemoveRepeatedPoints(ipolygon_0.Shell.Coordinates);
		if (m_BroadcasterRule < 0.0 && SearchObject(ilist_, m_BroadcasterRule))
		{
			return;
		}
		IncludeObject(ilist_, double_, positionType_, LocationType.Exterior, LocationType.Interior);
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			IList<Coordinate> ilist_2 = CoordinateArrays.RemoveRepeatedPoints(((ILinearRing)ipolygon_0.GetInteriorRingN(i)).Coordinates);
			if (m_BroadcasterRule <= 0.0 || !SearchObject(ilist_2, 0.0 - m_BroadcasterRule))
			{
				IncludeObject(ilist_2, double_, Position.Opposite(positionType_), LocationType.Interior, LocationType.Exterior);
			}
		}
	}

	private void IncludeObject(IList<Coordinate> ilist_0, double double_0, PositionType positionType_0, LocationType locationType_0, LocationType locationType_1)
	{
		LocationType locationType_2 = locationType_0;
		LocationType locationType_3 = locationType_1;
		if (CgAlgorithms.IsCounterClockwise(ilist_0))
		{
			locationType_2 = locationType_1;
			locationType_3 = locationType_0;
			positionType_0 = Position.Opposite(positionType_0);
		}
		IList ringCurve = _BaseRule.GetRingCurve(ilist_0, positionType_0, double_0);
		WriteObject(ringCurve, locationType_2, locationType_3);
	}

	private bool SearchObject(IList<Coordinate> ilist_0, double double_0)
	{
		if (ilist_0.Count < 4)
		{
			return double_0 < 0.0;
		}
		if (ilist_0.Count == 4)
		{
			return EnableObject(ilist_0, double_0);
		}
		return new MinimumDiameter(m_IdentifierRule.Factory.CreateLinearRing(ilist_0)).Length < 2.0 * Math.Abs(double_0);
	}

	private bool EnableObject(IList<Coordinate> ilist_0, double double_0)
	{
		Triangle triangle = new Triangle(ilist_0[0], ilist_0[1], ilist_0[2]);
		return CgAlgorithms.DistancePointLine(triangle.InCentre, triangle.P0, triangle.P1) < Math.Abs(double_0);
	}
}
