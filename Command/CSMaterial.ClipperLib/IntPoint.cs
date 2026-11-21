namespace CSMaterial.ClipperLib;

public struct IntPoint
{
	public long X;

	public long Y;

	public IntPoint(long long_0, long long_1)
	{
		X = long_0;
		Y = long_1;
	}

	public IntPoint(double double_0, double double_1)
	{
		X = (long)double_0;
		Y = (long)double_1;
	}

	public IntPoint(IntPoint intPoint_0)
	{
		X = intPoint_0.X;
		Y = intPoint_0.Y;
	}

	public static bool operator ==(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		if (intPoint_0.X == intPoint_1.X)
		{
			return intPoint_0.Y == intPoint_1.Y;
		}
		return false;
	}

	public static bool operator !=(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		if (intPoint_0.X == intPoint_1.X)
		{
			return intPoint_0.Y != intPoint_1.Y;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is IntPoint intPoint)
		{
			if (X == intPoint.X)
			{
				return Y == intPoint.Y;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
