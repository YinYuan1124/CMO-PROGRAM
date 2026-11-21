namespace CSMaterial.ClipperLib;

public struct IntRect
{
	public long left;

	public long top;

	public long right;

	public long bottom;

	public IntRect(long long_0, long long_1, long long_2, long long_3)
	{
		left = long_0;
		top = long_1;
		right = long_2;
		bottom = long_3;
	}

	public IntRect(IntRect intRect_0)
	{
		left = intRect_0.left;
		top = intRect_0.top;
		right = intRect_0.right;
		bottom = intRect_0.bottom;
	}
}
