using System.Numerics;

namespace ExWorldWind;

public class ViewFrustum
{
	public Plane[] planes = new Plane[6];

	public void Update(Matrix4x4 matrix4x4_0)
	{
		planes[0] = new Plane(matrix4x4_0.M14 + matrix4x4_0.M12, matrix4x4_0.M24 + matrix4x4_0.M22, matrix4x4_0.M34 + matrix4x4_0.M32, matrix4x4_0.M44 + matrix4x4_0.M42);
		planes[1] = new Plane(matrix4x4_0.M14 - matrix4x4_0.M13, matrix4x4_0.M24 - matrix4x4_0.M23, matrix4x4_0.M34 - matrix4x4_0.M33, matrix4x4_0.M44 - matrix4x4_0.M43);
		planes[2] = new Plane(matrix4x4_0.M14 - matrix4x4_0.M11, matrix4x4_0.M24 - matrix4x4_0.M21, matrix4x4_0.M34 - matrix4x4_0.M31, matrix4x4_0.M44 - matrix4x4_0.M41);
		planes[3] = new Plane(matrix4x4_0.M14 + matrix4x4_0.M11, matrix4x4_0.M24 + matrix4x4_0.M21, matrix4x4_0.M34 + matrix4x4_0.M31, matrix4x4_0.M44 + matrix4x4_0.M41);
		planes[4] = new Plane(matrix4x4_0.M13, matrix4x4_0.M23, matrix4x4_0.M33, matrix4x4_0.M43);
		planes[5] = new Plane(matrix4x4_0.M14 - matrix4x4_0.M12, matrix4x4_0.M24 - matrix4x4_0.M22, matrix4x4_0.M34 - matrix4x4_0.M32, matrix4x4_0.M44 - matrix4x4_0.M42);
	}

	public bool ContainsPoint(Vector3 vector3_0)
	{
		Plane[] array = planes;
		for (int i = 0; i < array.Length; i++)
		{
			if (Plane.DotCoordinate(array[i], vector3_0) < 0f)
			{
				return false;
			}
		}
		return true;
	}
}
