namespace CSMaterial.ClipperLib;

public struct DoublePoint
{
	public double X;

	public double Y;

	public DoublePoint(double double_0 = 0.0, double double_1 = 0.0)
	{
		X = double_0;
		Y = double_1;
	}

	public DoublePoint(DoublePoint doublePoint_0)
	{
		X = doublePoint_0.X;
		Y = doublePoint_0.Y;
	}

	public DoublePoint(IntPoint intPoint_0)
	{
		X = intPoint_0.X;
		Y = intPoint_0.Y;
	}
}
