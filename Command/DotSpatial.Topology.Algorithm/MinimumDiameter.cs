using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public class MinimumDiameter
{
	private readonly IGeometry m_ProducerInstance;

	private readonly bool _ProcInstance;

	private LineSegment _StructObject = new LineSegment();

	private int m_MerchantObject;

	private double m_CallbackObject;

	private Coordinate _DecoratorObject = new Coordinate(0.0, 0.0, 0.0, 0.0);

	public virtual double Length
	{
		get
		{
			ChangeExpression();
			return m_CallbackObject;
		}
	}

	public virtual Coordinate WidthCoordinate
	{
		get
		{
			ChangeExpression();
			return _DecoratorObject;
		}
	}

	public virtual ILineString SupportingSegment
	{
		get
		{
			ChangeExpression();
			return m_ProducerInstance.Factory.CreateLineString(new Coordinate[2] { _StructObject.P0, _StructObject.P1 });
		}
	}

	public virtual ILineString Diameter
	{
		get
		{
			ChangeExpression();
			if (_DecoratorObject.IsEmpty())
			{
				return m_ProducerInstance.Factory.CreateLineString(null);
			}
			Coordinate coordinate = new Coordinate(_StructObject.Project(_DecoratorObject));
			return m_ProducerInstance.Factory.CreateLineString(new Coordinate[2] { coordinate, _DecoratorObject });
		}
	}

	public MinimumDiameter(IGeometry igeometry_0)
		: this(igeometry_0, bool_0: false)
	{
	}

	public MinimumDiameter(IGeometry igeometry_0, bool bool_0)
	{
		m_ProducerInstance = igeometry_0;
		_ProcInstance = bool_0;
	}

	private void ChangeExpression()
	{
		if (!_DecoratorObject.IsEmpty())
		{
			if (_ProcInstance)
			{
				InitExpression(m_ProducerInstance);
				return;
			}
			IGeometry convexHull = new ConvexHull(m_ProducerInstance).GetConvexHull();
			InitExpression(convexHull);
		}
	}

	private void InitExpression(IGeometry igeometry_0)
	{
		IList<Coordinate> list = ((igeometry_0 is Polygon) ? ((Polygon)igeometry_0).Shell.Coordinates : igeometry_0.Coordinates);
		if (list.Count == 0)
		{
			m_CallbackObject = 0.0;
			_DecoratorObject = Coordinate.Empty;
			_StructObject = null;
		}
		else if (list.Count == 1)
		{
			m_CallbackObject = 0.0;
			_DecoratorObject = list[0];
			_StructObject.P0 = list[0];
			_StructObject.P1 = list[0];
		}
		else if (list.Count != 2 && list.Count != 3)
		{
			CheckExpression(list);
		}
		else
		{
			m_CallbackObject = 0.0;
			_DecoratorObject = list[0];
			_StructObject.P0 = list[0];
			_StructObject.P1 = list[1];
		}
	}

	private void CheckExpression(IList<Coordinate> ilist_0)
	{
		m_CallbackObject = double.MaxValue;
		int int_ = 1;
		LineSegment lineSegment = new LineSegment();
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			lineSegment.P0 = ilist_0[i];
			lineSegment.P1 = ilist_0[i + 1];
			int_ = ConcatExpression(ilist_0, lineSegment, int_);
		}
	}

	private int ConcatExpression(IList<Coordinate> ilist_0, ILineSegment ilineSegment_0, int int_0)
	{
		double num = ilineSegment_0.DistancePerpendicular(ilist_0[int_0]);
		double num2 = num;
		int num3 = int_0;
		int num4 = num3;
		while (num2 >= num)
		{
			num = num2;
			num3 = num4;
			num4 = InterruptExpression(ilist_0, num3);
			num2 = ilineSegment_0.DistancePerpendicular(ilist_0[num4]);
		}
		if (num < m_CallbackObject)
		{
			m_MerchantObject = num3;
			m_CallbackObject = num;
			_DecoratorObject = ilist_0[m_MerchantObject];
			_StructObject = new LineSegment(ilineSegment_0);
		}
		return num3;
	}

	private static int InterruptExpression(ICollection<Coordinate> icollection_0, int int_0)
	{
		int_0++;
		if (int_0 >= icollection_0.Count)
		{
			int_0 = 0;
		}
		return int_0;
	}
}
