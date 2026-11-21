namespace DotSpatial.Topology.Noding;

public class SegmentPointComparator
{
	public static int Compare(OctantDirection octantDirection_0, Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (coordinate_0.Equals2D(coordinate_1))
		{
			return 0;
		}
		int num = RelativeSign(coordinate_0.X, coordinate_1.X);
		int num2 = RelativeSign(coordinate_0.Y, coordinate_1.Y);
		if (1 == 0)
		{
		}
		int result = octantDirection_0 switch
		{
			OctantDirection.Zero => ForgotObject(num, num2), 
			OctantDirection.One => ForgotObject(num2, num), 
			OctantDirection.Two => ForgotObject(num2, -num), 
			OctantDirection.Three => ForgotObject(-num, num2), 
			OctantDirection.Four => ForgotObject(-num, -num2), 
			OctantDirection.Five => ForgotObject(-num2, -num), 
			OctantDirection.Six => ForgotObject(-num2, num), 
			OctantDirection.Seven => ForgotObject(num, -num2), 
			_ => throw new InvalidOctantException(octantDirection_0.ToString()), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static int RelativeSign(double double_0, double double_1)
	{
		if (double_0 < double_1)
		{
			return -1;
		}
		if (double_0 <= double_1)
		{
			return 0;
		}
		return 1;
	}

	private static int ForgotObject(int int_0, int int_1)
	{
		if (int_0 < 0)
		{
			return -1;
		}
		if (int_0 <= 0)
		{
			if (int_1 < 0)
			{
				return -1;
			}
			if (int_1 <= 0)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}
}
