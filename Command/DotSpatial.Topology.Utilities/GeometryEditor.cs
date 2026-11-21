using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

public class GeometryEditor
{
	public abstract class CoordinateOperation : IGeometryEditorOperation
	{
		public virtual IGeometry Edit(IGeometry igeometry_0, IGeometryFactory igeometryFactory_0)
		{
			if (igeometry_0 is LinearRing)
			{
				return igeometryFactory_0.CreateLinearRing(Edit(igeometry_0.Coordinates, igeometry_0));
			}
			if (igeometry_0 is LineString)
			{
				return igeometryFactory_0.CreateLineString(Edit(igeometry_0.Coordinates, igeometry_0));
			}
			if (igeometry_0 is Point)
			{
				IList<Coordinate> list = Edit(igeometry_0.Coordinates, igeometry_0);
				return igeometryFactory_0.CreatePoint((list.Count <= 0) ? null : list[0]);
			}
			return igeometry_0;
		}

		public abstract IList<Coordinate> Edit(IList<Coordinate> ilist_0, IGeometry igeometry_0);
	}

	public interface IGeometryEditorOperation
	{
		IGeometry Edit(IGeometry igeometry_0, IGeometryFactory igeometryFactory_0);
	}

	private IGeometryFactory parameterThread;

	public GeometryEditor()
	{
	}

	public GeometryEditor(IGeometryFactory igeometryFactory_0)
	{
		parameterThread = igeometryFactory_0;
	}

	public virtual IGeometry Edit(IGeometry igeometry_0, IGeometryEditorOperation igeometryEditorOperation_0)
	{
		if (parameterThread == null)
		{
			parameterThread = igeometry_0.Factory;
		}
		if (igeometry_0 is GeometryCollection)
		{
			return CompareRule(igeometry_0, igeometryEditorOperation_0);
		}
		if (igeometry_0 is Polygon)
		{
			return CreateRule(igeometry_0, igeometryEditorOperation_0);
		}
		if (igeometry_0 is Point)
		{
			return igeometryEditorOperation_0.Edit(igeometry_0, parameterThread);
		}
		if (!(igeometry_0 is LineString))
		{
			throw new UnsupportedGeometryException();
		}
		return igeometryEditorOperation_0.Edit(igeometry_0, parameterThread);
	}

	private IPolygon CreateRule(IGeometry igeometry_0, IGeometryEditorOperation igeometryEditorOperation_0)
	{
		Polygon polygon = (Polygon)igeometryEditorOperation_0.Edit(igeometry_0, parameterThread);
		if (polygon.IsEmpty)
		{
			return polygon;
		}
		LinearRing linearRing = (LinearRing)Edit(polygon.Shell, igeometryEditorOperation_0);
		if (linearRing.IsEmpty)
		{
			return parameterThread.CreatePolygon(null, null);
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < polygon.NumHoles; i++)
		{
			LinearRing linearRing2 = (LinearRing)Edit(polygon.GetInteriorRingN(i), igeometryEditorOperation_0);
			if (!linearRing2.IsEmpty)
			{
				arrayList.Add(linearRing2);
			}
		}
		IGeometryFactory geometryFactory = parameterThread;
		ILinearRing[] array2 = (LinearRing[])arrayList.ToArray(typeof(LinearRing));
		ILinearRing[] array = array2;
		ILinearRing[] ilinearRing_ = array;
		return geometryFactory.CreatePolygon(linearRing, ilinearRing_);
	}

	private GInterface3 CompareRule(IGeometry igeometry_0, IGeometryEditorOperation igeometryEditorOperation_0)
	{
		GeometryCollection geometryCollection = (GeometryCollection)igeometryEditorOperation_0.Edit(igeometry_0, parameterThread);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geometryCollection.NumGeometries; i++)
		{
			IGeometry geometry = Edit(geometryCollection.GetGeometryN(i), igeometryEditorOperation_0);
			if (!geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		if (geometryCollection is MultiPoint)
		{
			return parameterThread.CreateMultiPoint((Point[])arrayList.ToArray(typeof(Point)));
		}
		if (geometryCollection is MultiLineString)
		{
			IGeometryFactory geometryFactory = parameterThread;
			IBasicLineString[] array4 = (LineString[])arrayList.ToArray(typeof(LineString));
			IBasicLineString[] array = array4;
			IBasicLineString[] ibasicLineString_ = array;
			return geometryFactory.CreateMultiLineString(ibasicLineString_);
		}
		if (geometryCollection is MultiPolygon)
		{
			IGeometryFactory geometryFactory2 = parameterThread;
			IPolygon[] array5 = (Polygon[])arrayList.ToArray(typeof(Polygon));
			IPolygon[] array2 = array5;
			IPolygon[] ipolygon_ = array2;
			return geometryFactory2.CreateMultiPolygon(ipolygon_);
		}
		IGeometryFactory geometryFactory3 = parameterThread;
		IGeometry[] array6 = (Geometry[])arrayList.ToArray(typeof(Geometry));
		IGeometry[] array3 = array6;
		IGeometry[] igeometry_ = array3;
		return geometryFactory3.CreateGeometryCollection(igeometry_);
	}
}
