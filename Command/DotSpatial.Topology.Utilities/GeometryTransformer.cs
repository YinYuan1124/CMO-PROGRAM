using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

public class GeometryTransformer
{
	private readonly GeometryFactory expressionThread = Geometry.DefaultFactory;

	private IGeometry _DispatcherThread;

	public virtual IGeometry InputGeometry => _DispatcherThread;

	public virtual IGeometry Transform(IGeometry igeometry_0)
	{
		_DispatcherThread = igeometry_0;
		if (igeometry_0 is IPoint)
		{
			return TransformPoint((Point)igeometry_0);
		}
		if (igeometry_0 is IMultiPoint)
		{
			return TransformMultiPoint((IMultiPoint)igeometry_0);
		}
		if (igeometry_0 is ILinearRing)
		{
			return TransformLineString((LinearRing)igeometry_0);
		}
		if (igeometry_0 is ILineString)
		{
			return TransformLineString((LineString)igeometry_0);
		}
		if (igeometry_0 is IMultiLineString)
		{
			return TransformMultiLineString((IMultiLineString)igeometry_0);
		}
		if (igeometry_0 is IPolygon)
		{
			return TransformPolygon((Polygon)igeometry_0, null);
		}
		if (igeometry_0 is IMultiPolygon)
		{
			return TransformMultiPolygon((IMultiPolygon)igeometry_0);
		}
		if (!(igeometry_0 is GInterface3))
		{
			throw new ArgumentException("Unknown Geometry subtype: " + igeometry_0.GeometryType);
		}
		return TransformGeometryCollection((GInterface3)igeometry_0, null);
	}

	protected virtual GInterface2 CreateCoordinateSequence(Coordinate[] coordinate_0)
	{
		return expressionThread.CoordinateSequenceFactory.Create(coordinate_0);
	}

	protected virtual IList<Coordinate> Copy(IList<Coordinate> ilist_0)
	{
		return ilist_0.CloneList();
	}

	protected virtual IList<Coordinate> TransformCoordinates(IList<Coordinate> ilist_0, IGeometry igeometry_0)
	{
		return Copy(ilist_0);
	}

	protected virtual IGeometry TransformPoint(IPoint ipoint_0)
	{
		return expressionThread.CreatePoint(TransformCoordinates(ipoint_0.Coordinates, ipoint_0)[0]);
	}

	protected virtual IGeometry TransformMultiPoint(IMultiPoint imultiPoint_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < imultiPoint_0.NumGeometries; i++)
		{
			IGeometry geometry = TransformPoint((Point)imultiPoint_0.GetGeometryN(i));
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return expressionThread.BuildGeometry(arrayList);
	}

	protected virtual IGeometry TransformLinearRing(ILinearRing ilinearRing_0)
	{
		IList<Coordinate> list = TransformCoordinates(ilinearRing_0.Coordinates, ilinearRing_0);
		int count = list.Count;
		if (count > 0 && count < 4)
		{
			return expressionThread.CreateLineString(list);
		}
		return expressionThread.CreateLinearRing(list);
	}

	protected virtual IGeometry TransformLineString(ILineString ilineString_0)
	{
		return expressionThread.CreateLineString(TransformCoordinates(ilineString_0.Coordinates, ilineString_0));
	}

	protected virtual IGeometry TransformMultiLineString(IMultiLineString imultiLineString_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < imultiLineString_0.NumGeometries; i++)
		{
			IGeometry geometry = TransformLineString((ILineString)imultiLineString_0.GetGeometryN(i));
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return expressionThread.BuildGeometry(arrayList);
	}

	protected virtual IGeometry TransformPolygon(IPolygon ipolygon_0, IGeometry igeometry_0)
	{
		bool flag = true;
		IGeometry geometry = TransformLinearRing(ipolygon_0.Shell);
		if (geometry == null || !(geometry is LinearRing) || geometry.IsEmpty)
		{
			flag = false;
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			IGeometry geometry2 = TransformLinearRing((ILinearRing)ipolygon_0.GetInteriorRingN(i));
			if (geometry2 != null && !geometry2.IsEmpty)
			{
				if (!(geometry2 is LinearRing))
				{
					flag = false;
				}
				arrayList.Add(geometry2);
			}
		}
		if (flag)
		{
			return expressionThread.CreatePolygon((ILinearRing)geometry, (ILinearRing[])arrayList.ToArray(typeof(ILinearRing)));
		}
		ArrayList arrayList2 = new ArrayList();
		if (geometry != null)
		{
			arrayList2.Add(geometry);
		}
		foreach (object item in arrayList)
		{
			arrayList2.Add(item);
		}
		return expressionThread.BuildGeometry(arrayList2);
	}

	protected virtual IGeometry TransformMultiPolygon(IMultiPolygon imultiPolygon_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < imultiPolygon_0.NumGeometries; i++)
		{
			IGeometry geometry = TransformPolygon((Polygon)imultiPolygon_0.GetGeometryN(i), imultiPolygon_0);
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return expressionThread.BuildGeometry(arrayList);
	}

	protected virtual IGeometry TransformGeometryCollection(GInterface3 ginterface3_0, IGeometry igeometry_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < ginterface3_0.NumGeometries; i++)
		{
			IGeometry geometry = Transform(ginterface3_0.GetGeometryN(i));
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return expressionThread.CreateGeometryCollection(GeometryFactory.ToGeometryArray(arrayList));
	}
}
