using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class Intersection2D
{
	public enum IntersectionType
	{
		I2D_NONE,
		I2D_POINT,
		I2D_SEGMENT,
		I2D_ARC
	}

	private IntersectionType m_RuleCallback;

	private Vector2D collectionCallback;

	private Segment instanceCallback;

	public IntersectionType Type => m_RuleCallback;

	public object Result
	{
		get
		{
			IntersectionType ruleCallback = m_RuleCallback;
			if (1 == 0)
			{
			}
			object result = ruleCallback switch
			{
				IntersectionType.I2D_NONE => throw new Exception("No intersection!"), 
				IntersectionType.I2D_POINT => collectionCallback, 
				IntersectionType.I2D_SEGMENT => instanceCallback, 
				_ => throw new NotImplementedException(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public Intersection2D()
	{
		m_RuleCallback = IntersectionType.I2D_NONE;
	}

	public Intersection2D(Vector2D vector2D_0)
	{
		m_RuleCallback = IntersectionType.I2D_POINT;
		collectionCallback = vector2D_0;
	}

	public Intersection2D(Segment segment_0)
	{
		m_RuleCallback = IntersectionType.I2D_SEGMENT;
		instanceCallback = segment_0;
	}
}
