using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface IGeometryFactory
{
	IGeometryFactory Floating { get; set; }

	IGeometryFactory FloatingSingle { get; set; }

	int Srid { get; }

	PrecisionModelType PrecisionModel { get; }

	ICoordinateSequenceFactory CoordinateSequenceFactory { get; }

	IGeometry BuildGeometry(IList ilist_0);

	IPoint CreatePoint(Coordinate coordinate_0);

	IMultiLineString CreateMultiLineString(IBasicLineString[] ibasicLineString_0);

	GInterface3 CreateGeometryCollection(IGeometry[] igeometry_0);

	IMultiPolygon CreateMultiPolygon(IPolygon[] ipolygon_0);

	ILinearRing CreateLinearRing(IList<Coordinate> ilist_0);

	IMultiPoint CreateMultiPoint(IEnumerable<ICoordinate> ienumerable_0);

	IMultiPoint CreateMultiPoint(IEnumerable<Coordinate> ienumerable_0);

	ILineString CreateLineString(IList<Coordinate> ilist_0);

	IGeometry CreateGeometry(IGeometry igeometry_0);

	IPolygon CreatePolygon(ILinearRing ilinearRing_0, ILinearRing[] ilinearRing_1);
}
