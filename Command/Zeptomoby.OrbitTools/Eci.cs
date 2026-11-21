using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Eci
{
	[CompilerGenerated]
	private Vector m_Schema;

	[CompilerGenerated]
	private Vector utils;

	public Vector Position
	{
		[CompilerGenerated]
		get
		{
			return m_Schema;
		}
		[CompilerGenerated]
		protected set
		{
			m_Schema = value;
		}
	}

	public Vector Velocity
	{
		[CompilerGenerated]
		get
		{
			return utils;
		}
		[CompilerGenerated]
		protected set
		{
			utils = value;
		}
	}

	public Eci()
		: this(new Vector(), new Vector())
	{
	}

	public Eci(Vector vector_0)
		: this(vector_0, new Vector())
	{
	}

	public Eci(Vector vector_0, Vector vector_1)
	{
		Position = vector_0;
		Velocity = vector_1;
	}

	public Eci(Eci eci_0)
	{
		Position = new Vector(eci_0.Position);
		Velocity = new Vector(eci_0.Velocity);
	}

	public Eci(Geo geo_0, Julian julian_0)
	{
		double latitudeRad = geo_0.LatitudeRad;
		double longitudeRad = geo_0.LongitudeRad;
		double altitude = geo_0.Altitude;
		double num = julian_0.ToLmst(longitudeRad);
		double num2 = 1.0 / Math.Sqrt(1.0 + -0.006694317778266723 * Globals.Sqr(Math.Sin(latitudeRad)));
		double num3 = Globals.Sqr(0.9966472205458325) * num2;
		double num4 = (6378.135 * num2 + altitude) * Math.Cos(latitudeRad);
		Position = new Vector();
		Position.X = num4 * Math.Cos(num);
		Position.Y = num4 * Math.Sin(num);
		Position.Z = (6378.135 * num3 + altitude) * Math.Sin(latitudeRad);
		Position.W = Math.Sqrt(Globals.Sqr(Position.X) + Globals.Sqr(Position.Y) + Globals.Sqr(Position.Z));
		Velocity = new Vector();
		double num5 = 7.292115855228083E-05;
		Velocity.X = -7.292115855228083E-05 * Position.Y;
		Velocity.Y = num5 * Position.X;
		Velocity.Z = 0.0;
		Velocity.W = Math.Sqrt(Globals.Sqr(Velocity.X) + Globals.Sqr(Velocity.Y));
	}

	public void ScalePosVector(double double_0)
	{
		Position.Scale(double_0);
	}

	public void ScaleVelVector(double double_0)
	{
		Velocity.Scale(double_0);
	}

	public override string ToString()
	{
		return $"km:({Position.X:F0}, {Position.Y:F0}, {Position.Z:F0}) km/s:({Velocity.X:F1}, {Velocity.Y:F1}, {Velocity.Z:F1})";
	}
}
