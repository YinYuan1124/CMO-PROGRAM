using System.Numerics;

namespace Worldwind.Component;

public class SegmentVect
{
	public Vector3 A;

	public Vector3 B;

	public int int_0;

	public SegmentVect(Vector3 vector3_0, Vector3 vector3_1, int int_1)
	{
		A = vector3_0;
		B = vector3_1;
		int_0 = int_1;
	}
}
