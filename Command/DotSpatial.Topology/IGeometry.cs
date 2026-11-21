using System;
using System.Xml;

namespace DotSpatial.Topology;

public interface IGeometry : ICloneable, IComparable, IBasicGeometry, IOverlay, IRelate
{
	double Area { get; }

	IGeometry Boundary { get; set; }

	DimensionType BoundaryDimension { get; set; }

	IPoint Centroid { get; }

	Coordinate Coordinate { get; }

	DimensionType Dimension { get; set; }

	IEnvelope EnvelopeInternal { get; }

	IGeometryFactory Factory { get; }

	IGeometry InteriorPoint { get; }

	bool IsEmpty { get; }

	bool IsRectangle { get; }

	bool IsSimple { get; }

	bool IsValid { get; }

	double Length { get; }

	PrecisionModelType PrecisionModel { get; }

	int Srid { get; set; }

	object UserData { get; set; }

	void Apply(ICoordinateFilter icoordinateFilter_0);

	void Apply(IGeometryFilter igeometryFilter_0);

	void Apply(IGeometryComponentFilter igeometryComponentFilter_0);

	IGeometry Buffer(double double_0);

	IGeometry Buffer(double double_0, BufferStyle bufferStyle_0);

	IGeometry Buffer(double double_0, int int_0);

	IGeometry Buffer(double double_0, int int_0, BufferStyle bufferStyle_0);

	void ClearEnvelope();

	Coordinate ClosestPoint(Coordinate coordinate_0);

	IGeometry ConvexHull();

	int CompareToSameClass(object object_0);

	double Distance(IGeometry igeometry_0);

	bool Equals(IGeometry igeometry_0);

	bool EqualsExact(IGeometry igeometry_0, double double_0);

	bool EqualsExact(IGeometry igeometry_0);

	void GeometryChangedAction();

	void GeometryChanged();

	IGeometry GetGeometryN(int int_0);

	bool IsWithinDistance(IGeometry igeometry_0, double double_0);

	void Normalize();

	XmlReader ToGmlFeature();

	void Rotate(Coordinate coordinate_0, double double_0);
}
