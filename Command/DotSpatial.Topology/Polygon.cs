using System;
using System.Collections.Generic;
using System.Linq;
using Command.Listeners;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology;

[Serializable]
public class Polygon : Geometry, ICloneable, IComparable, IBasicGeometry, IBasicPolygon, IGeometry, IOverlay, IRelate, IPolygon
{
	private ILinearRing[] _holes;

	private ILinearRing _shell;

	public static readonly IPolygon Empty;

	public virtual IBasicLineString ExteriorRing => _shell;

	public override double Area
	{
		get
		{
			double num = 0.0;
			num += Math.Abs(CgAlgorithms.SignedArea(_shell.Coordinates));
			for (int i = 0; i < _holes.Length; i++)
			{
				num -= Math.Abs(CgAlgorithms.SignedArea(_holes[i].Coordinates));
			}
			return num;
		}
	}

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			ILinearRing[] array = new ILinearRing[_holes.Length + 1];
			array[0] = _shell;
			for (int i = 0; i < _holes.Length; i++)
			{
				array[i + 1] = _holes[i];
			}
			if (array.Length <= 1)
			{
				return base.Factory.CreateLinearRing(array[0].Coordinates);
			}
			IGeometryFactory factory = base.Factory;
			IBasicLineString[] array3 = array;
			IBasicLineString[] array2 = array3;
			IBasicLineString[] ibasicLineString_ = array2;
			return factory.CreateMultiLineString(ibasicLineString_);
		}
	}

	public override DimensionType BoundaryDimension => DimensionType.Curve;

	public override Coordinate Coordinate => _shell.Coordinate;

	public override IList<Coordinate> Coordinates
	{
		get
		{
			if (IsEmpty)
			{
				return new Coordinate[0];
			}
			List<Coordinate> list = new List<Coordinate>();
			list.AddRange(Shell.Coordinates);
			ILinearRing[] holes = Holes;
			ILinearRing[] array = holes;
			foreach (ILinearRing linearRing in array)
			{
				list.AddRange(linearRing.Coordinates);
			}
			return list;
		}
		set
		{
			Shell.Coordinates = value;
		}
	}

	public override DimensionType Dimension => DimensionType.Surface;

	public override FeatureType FeatureType => FeatureType.Polygon;

	public override string GeometryType => "Polygon";

	public ILinearRing[] Holes
	{
		get
		{
			return _holes;
		}
		set
		{
			_holes = value;
		}
	}

	ICollection<IBasicLineString> IBasicPolygon.Holes
	{
		get
		{
			return _holes;
		}
		set
		{
			SetHoles(value);
		}
	}

	public override bool IsEmpty => _shell.IsEmpty;

	public override bool IsRectangle
	{
		get
		{
			if (NumHoles == 0)
			{
				if (_shell == null)
				{
					return false;
				}
				if (_shell.NumPoints == 5)
				{
					IList<Coordinate> coordinates = _shell.Coordinates;
					IEnvelope envelopeInternal = EnvelopeInternal;
					for (int i = 0; i < 5; i++)
					{
						Coordinate coordinate = coordinates[i];
						double x = coordinate.X;
						if (x == envelopeInternal.Minimum.X || x == envelopeInternal.Maximum.X)
						{
							double y = coordinate.Y;
							if (y != envelopeInternal.Minimum.Y && y != envelopeInternal.Maximum.Y)
							{
								return false;
							}
							continue;
						}
						return false;
					}
					double num = coordinates[0].X;
					double num2 = coordinates[0].Y;
					for (int j = 1; j <= 4; j++)
					{
						double x2 = coordinates[j].X;
						double y2 = coordinates[j].Y;
						if (x2 != num != (y2 != num2))
						{
							num = x2;
							num2 = y2;
							continue;
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public override bool IsSimple => true;

	public override double Length
	{
		get
		{
			double num = 0.0;
			num += _shell.Length;
			ILinearRing[] holes = Holes;
			ILinearRing[] array = holes;
			foreach (ILinearRing linearRing in array)
			{
				num += linearRing.Length;
			}
			return num;
		}
	}

	public virtual int NumHoles => _holes.Length;

	public override int NumPoints
	{
		get
		{
			int num = _shell.NumPoints;
			for (int i = 0; i < _holes.Length; i++)
			{
				num += _holes[i].NumPoints;
			}
			return num;
		}
	}

	public virtual ILinearRing Shell
	{
		get
		{
			return _shell;
		}
		set
		{
			_shell = value;
		}
	}

	IBasicLineString IBasicPolygon.Shell
	{
		get
		{
			return _shell;
		}
		set
		{
			SetShell(value);
		}
	}

	public Polygon(ILinearRing ilinearRing_0, IGeometryFactory igeometryFactory_0)
		: this(ilinearRing_0, null, igeometryFactory_0)
	{
	}

	public Polygon(ILinearRing ilinearRing_0)
		: this(ilinearRing_0, null, Geometry.DefaultFactory)
	{
	}

	public Polygon(IEnumerable<Coordinate> ienumerable_0)
		: this(new LinearRing(ienumerable_0))
	{
	}

	public Polygon(ILinearRing ilinearRing_0, ILinearRing[] ilinearRing_1)
		: this(ilinearRing_0, ilinearRing_1, Geometry.DefaultFactory)
	{
	}

	public Polygon(ILinearRing ilinearRing_0, ILinearRing[] ilinearRing_1, IGeometryFactory igeometryFactory_0)
		: base(igeometryFactory_0)
	{
		if (ilinearRing_0 == null)
		{
			ilinearRing_0 = base.Factory.CreateLinearRing(null);
		}
		if (ilinearRing_1 == null)
		{
			ILinearRing[] array2 = new LinearRing[0];
			ILinearRing[] array = array2;
			ilinearRing_1 = array;
		}
		if (Geometry.HasNullElements(ilinearRing_1))
		{
			throw new PolygonException(AccountProcess.PolygonException_HoleElementNull);
		}
		if (ilinearRing_0.IsEmpty)
		{
			IGeometry[] array3 = ilinearRing_1;
			IGeometry[] igeometry_ = array3;
			if (Geometry.HasNonEmptyElements(igeometry_))
			{
				throw new PolygonException(AccountProcess.PolygonException_ShellEmptyButHolesNot);
			}
		}
		_shell = ilinearRing_0;
		_holes = ilinearRing_1;
	}

	public Polygon(IBasicPolygon ibasicPolygon_0)
		: base(Geometry.DefaultFactory)
	{
		SetHoles(ibasicPolygon_0.Holes);
		LinearRing linearRing = new LinearRing(ibasicPolygon_0.Shell);
		if (Geometry.HasNullElements(_holes))
		{
			throw new PolygonException(AccountProcess.PolygonException_HoleElementNull);
		}
		if (linearRing.IsEmpty)
		{
			IGeometry[] holes2 = _holes;
			IGeometry[] holes = holes2;
			if (Geometry.HasNonEmptyElements(holes))
			{
				throw new PolygonException(AccountProcess.PolygonException_ShellEmptyButHolesNot);
			}
		}
		_shell = linearRing;
	}

	public override void Apply(ICoordinateFilter icoordinateFilter_0)
	{
		_shell.Apply(icoordinateFilter_0);
		for (int i = 0; i < _holes.Length; i++)
		{
			_holes[i].Apply(icoordinateFilter_0);
		}
	}

	public override void Apply(IGeometryFilter igeometryFilter_0)
	{
		igeometryFilter_0.Filter(this);
	}

	public override void Apply(IGeometryComponentFilter igeometryComponentFilter_0)
	{
		igeometryComponentFilter_0.Filter(this);
		_shell.Apply(igeometryComponentFilter_0);
		for (int i = 0; i < _holes.Length; i++)
		{
			_holes[i].Apply(igeometryComponentFilter_0);
		}
	}

	public override int CompareToSameClass(object object_0)
	{
		ILinearRing shell = _shell;
		ILinearRing shell2 = ((IPolygon)object_0).Shell;
		return shell.CompareToSameClass(shell2);
	}

	public override void ClearEnvelope()
	{
		_shell.ClearEnvelope();
		ILinearRing[] holes = Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			holes[i].ClearEnvelope();
		}
	}

	public override IGeometry ConvexHull()
	{
		return _shell.ConvexHull();
	}

	public override bool EqualsExact(IGeometry igeometry_0, double double_0)
	{
		if (IsEquivalentClass(igeometry_0))
		{
			Polygon polygon = (Polygon)igeometry_0;
			ILinearRing shell = _shell;
			IGeometry shell2 = polygon.Shell;
			if (shell.EqualsExact(shell2, double_0))
			{
				if (_holes.Length == polygon.Holes.Length)
				{
					if (_holes.Length == polygon.Holes.Length)
					{
						for (int i = 0; i < _holes.Length; i++)
						{
							if (!_holes[i].EqualsExact(polygon.Holes[i], double_0))
							{
								return false;
							}
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public override Coordinate ClosestPoint(Coordinate coordinate_0)
	{
		if (Intersects(new Point(coordinate_0)))
		{
			Coordinate coordinate = _shell.ClosestPoint(coordinate_0);
			double num = coordinate_0.Distance(coordinate);
			ILinearRing[] holes = Holes;
			for (int i = 0; i < holes.Length; i++)
			{
				Coordinate coordinate2 = holes[i].ClosestPoint(coordinate_0);
				double num2 = coordinate_0.Distance(coordinate2);
				if (num2 < num)
				{
					num = num2;
					coordinate = coordinate2;
				}
			}
			return coordinate;
		}
		return _shell.ClosestPoint(coordinate_0);
	}

	public virtual ILineString GetInteriorRingN(int int_0)
	{
		return _holes[int_0];
	}

	public override void Normalize()
	{
		Normalize(_shell, bool_0: true);
		ILinearRing[] holes = _holes;
		for (int i = 0; i < holes.Length; i++)
		{
			Normalize((LinearRing)holes[i], bool_0: false);
		}
		Array.Sort(Holes);
	}

	protected override void OnCopy(Geometry geometry_0)
	{
		base.OnCopy(geometry_0);
		if (geometry_0 is Polygon polygon)
		{
			polygon.Shell = _shell.Copy();
			polygon.Holes = new ILinearRing[_holes.Length];
			for (int i = 0; i < _holes.Length; i++)
			{
				polygon.Holes[i] = Holes[i].Copy();
			}
		}
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		return _shell.EnvelopeInternal;
	}

	public override void Rotate(Coordinate coordinate_0, double double_0)
	{
		_shell.Rotate(coordinate_0, double_0);
		ILinearRing[] holes = Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			holes[i].Rotate(coordinate_0, double_0);
		}
	}

	private static void Normalize(ILinearRing ilinearRing_0, bool bool_0)
	{
		if (!ilinearRing_0.IsEmpty)
		{
			Coordinate[] array = new Coordinate[ilinearRing_0.Coordinates.Count - 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ilinearRing_0.Coordinates[i];
			}
			Coordinate coordinate_ = CoordinateArrays.MinCoordinate(array);
			CoordinateArrays.Scroll(array, coordinate_);
			List<Coordinate> list = new List<Coordinate>();
			for (int j = 0; j < array.Length; j++)
			{
				list.Add(array[j]);
			}
			list.Add(array[0].Copy());
			ilinearRing_0.Coordinates = list;
			if (CgAlgorithms.IsCounterClockwise(ilinearRing_0.Coordinates) == bool_0)
			{
				ilinearRing_0.Coordinates = ilinearRing_0.Coordinates.Reverse().ToList();
			}
		}
	}

	private void SetHoles(ICollection<IBasicLineString> icollection_0)
	{
		if (icollection_0 != null && icollection_0.Count != 0)
		{
			_holes = icollection_0 as ILinearRing[];
			if (_holes != null)
			{
				return;
			}
			List<ILinearRing> list = new List<ILinearRing>();
			foreach (IBasicLineString item in icollection_0)
			{
				list.Add(new LinearRing(Geometry.FromBasicGeometry(item) as ILineString));
			}
			_holes = list.ToArray();
		}
		else
		{
			_holes = new ILinearRing[0];
		}
	}

	private void SetShell(IBasicLineString ibasicLineString_0)
	{
		if (ibasicLineString_0 == null)
		{
			_shell = null;
		}
		else if (!(ibasicLineString_0 is ILinearRing))
		{
			_shell = new LinearRing(ibasicLineString_0);
		}
	}

	static Polygon()
	{
		Empty = new GeometryFactory().CreatePolygon(null, null);
	}
}
