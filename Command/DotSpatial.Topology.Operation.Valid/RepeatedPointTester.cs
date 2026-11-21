using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Operation.Valid;

public class RepeatedPointTester
{
	private Coordinate printerThread;

	public virtual Coordinate Coordinate => printerThread;

	protected virtual bool HasRepeatedPoint(IGeometry igeometry_0)
	{
		if (igeometry_0.IsEmpty)
		{
			return false;
		}
		if (igeometry_0 is Point)
		{
			return false;
		}
		if (igeometry_0 is MultiPoint)
		{
			return false;
		}
		if (igeometry_0 is LineString)
		{
			return HasRepeatedPoint(igeometry_0.Coordinates);
		}
		if (igeometry_0 is Polygon)
		{
			return ReadCollection((IPolygon)igeometry_0);
		}
		if (!(igeometry_0 is GeometryCollection))
		{
			throw new NotSupportedException(igeometry_0.GetType().FullName);
		}
		return DisableCollection((GInterface3)igeometry_0);
	}

	public virtual bool HasRepeatedPoint(IList<Coordinate> ilist_0)
	{
		for (int i = 1; i < ilist_0.Count; i++)
		{
			if (ilist_0[i - 1].Equals(ilist_0[i]))
			{
				printerThread = ilist_0[i];
				return true;
			}
		}
		return false;
	}

	private bool ReadCollection(IPolygon ipolygon_0)
	{
		if (HasRepeatedPoint(ipolygon_0.Shell.Coordinates))
		{
			return true;
		}
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			if (HasRepeatedPoint(ipolygon_0.GetInteriorRingN(i).Coordinates))
			{
				return true;
			}
		}
		return false;
	}

	private bool DisableCollection(GInterface3 ginterface3_0)
	{
		int num = 0;
		while (true)
		{
			if (num < ginterface3_0.NumGeometries)
			{
				IGeometry geometryN = ginterface3_0.GetGeometryN(num);
				if (HasRepeatedPoint(geometryN))
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
}
