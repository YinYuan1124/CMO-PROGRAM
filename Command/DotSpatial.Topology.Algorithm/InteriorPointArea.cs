namespace DotSpatial.Topology.Algorithm;

public class InteriorPointArea
{
	private readonly IGeometryFactory _ProductInstance;

	private Coordinate _AnnotationInstance = Coordinate.Empty;

	private double _IteratorInstance;

	public virtual Coordinate InteriorPoint => _AnnotationInstance;

	public InteriorPointArea(IGeometry igeometry_0)
	{
		_ProductInstance = igeometry_0.Factory;
		Add(igeometry_0);
	}

	private static double WriteExpression(double double_0, double double_1)
	{
		return (double_0 + double_1) / 2.0;
	}

	private void Add(IGeometry igeometry_0)
	{
		if (igeometry_0 is IPolygon)
		{
			AddPolygon(igeometry_0);
		}
		else if (igeometry_0 is GInterface3)
		{
			IGeometry[] geometries = ((GInterface3)igeometry_0).Geometries;
			IGeometry[] array = geometries;
			foreach (IGeometry igeometry_ in array)
			{
				Add(igeometry_);
			}
		}
	}

	public virtual void AddPolygon(IGeometry igeometry_0)
	{
		IGeometry igeometry_ = HorizontalBisector(igeometry_0).Intersection(igeometry_0);
		IGeometry geometry = WidestGeometry(igeometry_);
		double width = geometry.EnvelopeInternal.Width;
		if (_AnnotationInstance.IsEmpty() || width > _IteratorInstance)
		{
			_AnnotationInstance = Centre(geometry.EnvelopeInternal);
			_IteratorInstance = width;
		}
	}

	protected virtual IGeometry WidestGeometry(IGeometry igeometry_0)
	{
		if (igeometry_0 is GeometryCollection)
		{
			return NewExpression((GeometryCollection)igeometry_0);
		}
		return igeometry_0;
	}

	private static IGeometry NewExpression(object object_0)
	{
		if (((IGeometry)object_0).IsEmpty)
		{
			return (IGeometry)object_0;
		}
		IGeometry geometryN = ((IGeometry)object_0).GetGeometryN(0);
		for (int i = 1; i < ((IBasicGeometry)object_0).NumGeometries; i++)
		{
			if (((IGeometry)object_0).GetGeometryN(i).EnvelopeInternal.Width > geometryN.EnvelopeInternal.Width)
			{
				geometryN = ((IGeometry)object_0).GetGeometryN(i);
			}
		}
		return geometryN;
	}

	protected virtual ILineString HorizontalBisector(IGeometry igeometry_0)
	{
		IEnvelope envelopeInternal = igeometry_0.EnvelopeInternal;
		double double_ = WriteExpression(envelopeInternal.Minimum.Y, envelopeInternal.Maximum.Y);
		return _ProductInstance.CreateLineString(new Coordinate[2]
		{
			new Coordinate(envelopeInternal.Minimum.X, double_),
			new Coordinate(envelopeInternal.Maximum.X, double_)
		});
	}

	public virtual Coordinate Centre(IEnvelope ienvelope_0)
	{
		return new Coordinate(WriteExpression(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X), WriteExpression(ienvelope_0.Minimum.Y, ienvelope_0.Maximum.Y));
	}
}
