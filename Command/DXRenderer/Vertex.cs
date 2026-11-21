using System.Numerics;

namespace DXRenderer;

public struct Vertex
{
	internal Vector3 _DescriptorVal;

	internal Vector4 poolVal;

	internal Vector2 m_TaskVal;

	internal Vertex(Vector3 vector3_0, Vector4 vector4_0, Vector2 vector2_0)
	{
		_DescriptorVal = vector3_0;
		poolVal = vector4_0;
		m_TaskVal = vector2_0;
	}

	public Vertex(Vector3 vector3_0, Vector4 vector4_0)
	{
		_DescriptorVal = vector3_0;
		poolVal = vector4_0;
		m_TaskVal = default(Vector2);
	}
}
