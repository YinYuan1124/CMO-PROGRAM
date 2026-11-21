using System;

namespace DotSpatial.Topology.Noding;

public static class Octant
{
	public static OctantDirection GetOctant(double double_0, double double_1)
	{
		if (double_0 == 0.0 && double_1 == 0.0)
		{
			throw new ArgumentException("Cannot compute the octant for point ( " + double_0 + ", " + double_1 + " )");
		}
		double num = Math.Abs(double_0);
		double num2 = Math.Abs(double_1);
		if (double_0 < 0.0)
		{
			if (double_1 < 0.0)
			{
				if (num < num2)
				{
					return OctantDirection.Five;
				}
				return OctantDirection.Four;
			}
			if (num < num2)
			{
				return OctantDirection.Two;
			}
			return OctantDirection.Three;
		}
		if (double_1 < 0.0)
		{
			if (num < num2)
			{
				return OctantDirection.Six;
			}
			return OctantDirection.Seven;
		}
		if (num < num2)
		{
			return OctantDirection.One;
		}
		return OctantDirection.Zero;
	}

	public static OctantDirection GetOctant(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		double num = coordinate_1.X - coordinate_0.X;
		double num2 = coordinate_1.Y - coordinate_0.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			throw new ArgumentException("Cannot compute the octant for two identical points " + (object)coordinate_0);
		}
		return GetOctant(num, num2);
	}
}
