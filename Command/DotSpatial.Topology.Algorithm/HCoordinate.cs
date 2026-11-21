using System;

namespace DotSpatial.Topology.Algorithm;

public class HCoordinate
{
	private double databaseInstance;

	private double m_InterceptorInstance;

	private double m_MessageInstance;

	[Obsolete("This is a simple access to x private field: use GetX() instead.")]
	protected virtual double X
	{
		get
		{
			return m_InterceptorInstance;
		}
		set
		{
			m_InterceptorInstance = value;
		}
	}

	[Obsolete("This is a simple access to y private field: use GetY() instead.")]
	protected virtual double Y
	{
		get
		{
			return m_MessageInstance;
		}
		set
		{
			m_MessageInstance = value;
		}
	}

	[Obsolete("This is a simple access to w private field: how do you use this field for?...")]
	protected virtual double W
	{
		get
		{
			return databaseInstance;
		}
		set
		{
			databaseInstance = value;
		}
	}

	public virtual Coordinate Coordinate => new Coordinate(GetX(), GetY());

	public HCoordinate()
	{
		m_InterceptorInstance = 0.0;
		m_MessageInstance = 0.0;
		databaseInstance = 1.0;
	}

	public HCoordinate(double double_0, double double_1, double double_2)
	{
		m_InterceptorInstance = double_0;
		m_MessageInstance = double_1;
		databaseInstance = double_2;
	}

	public HCoordinate(Coordinate coordinate_0)
	{
		m_InterceptorInstance = coordinate_0.X;
		m_MessageInstance = coordinate_0.Y;
		databaseInstance = 1.0;
	}

	public HCoordinate(HCoordinate hcoordinate_0, HCoordinate hcoordinate_1)
	{
		m_InterceptorInstance = hcoordinate_0.m_MessageInstance * hcoordinate_1.databaseInstance - hcoordinate_1.m_MessageInstance * hcoordinate_0.databaseInstance;
		m_MessageInstance = hcoordinate_1.m_InterceptorInstance * hcoordinate_0.databaseInstance - hcoordinate_0.m_InterceptorInstance * hcoordinate_1.databaseInstance;
		databaseInstance = hcoordinate_0.m_InterceptorInstance * hcoordinate_1.m_MessageInstance - hcoordinate_1.m_InterceptorInstance * hcoordinate_0.m_MessageInstance;
	}

	public static Coordinate Intersection(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		HCoordinate hcoordinate_ = new HCoordinate(new HCoordinate(coordinate_0), new HCoordinate(coordinate_1));
		HCoordinate hcoordinate_2 = new HCoordinate(new HCoordinate(coordinate_2), new HCoordinate(coordinate_3));
		return new HCoordinate(hcoordinate_, hcoordinate_2).Coordinate;
	}

	public virtual double GetX()
	{
		double num = m_InterceptorInstance / databaseInstance;
		if (double.IsNaN(num) || double.IsInfinity(num))
		{
			throw new NotRepresentableException();
		}
		return num;
	}

	public virtual double GetY()
	{
		double num = m_MessageInstance / databaseInstance;
		if (double.IsNaN(num) || double.IsInfinity(num))
		{
			throw new NotRepresentableException();
		}
		return num;
	}
}
