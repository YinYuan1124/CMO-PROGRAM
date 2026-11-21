using System;

namespace DotSpatial.Topology.Voronoi;

public class VoronoiEdge
{
	internal bool _ObjectThread;

	public Vector2 LeftData;

	public Vector2 RightData;

	public Vector2 VVertexA = Fortune.VVUnkown;

	public Vector2 VVertexB = Fortune.VVUnkown;

	public bool IsInfinite
	{
		get
		{
			if (VVertexA == Fortune.vector2_0)
			{
				return VVertexB == Fortune.vector2_0;
			}
			return false;
		}
	}

	public bool IsPartlyInfinite
	{
		get
		{
			if (VVertexA == Fortune.vector2_0)
			{
				return true;
			}
			return VVertexB == Fortune.vector2_0;
		}
	}

	public Vector2 FixedPoint
	{
		get
		{
			if (IsInfinite)
			{
				return (LeftData + RightData) * 0.5;
			}
			if (VVertexA == Fortune.vector2_0)
			{
				return VVertexB;
			}
			return VVertexA;
		}
	}

	public Vector2 DirectionVector
	{
		get
		{
			if (IsPartlyInfinite)
			{
				if (LeftData.X == RightData.X)
				{
					if (LeftData.Y < RightData.Y)
					{
						return new Vector2(-1.0, 0.0);
					}
					return new Vector2(1.0, 0.0);
				}
				Vector2 vector = new Vector2((0.0 - (RightData.Y - LeftData.Y)) / (RightData.X - LeftData.X), 1.0);
				if (RightData.X < LeftData.X)
				{
					vector *= -1.0;
				}
				return vector * (1.0 / Math.Sqrt(vector.SquaredLength));
			}
			return (VVertexB - VVertexA) * (1.0 / VVertexA.Distance(VVertexB));
		}
	}

	public double Length
	{
		get
		{
			if (IsPartlyInfinite)
			{
				return double.PositiveInfinity;
			}
			return VVertexA.Distance(VVertexB);
		}
	}

	public void AddVertex(Vector2 vector2_0)
	{
		if (VVertexA == Fortune.VVUnkown)
		{
			VVertexA = vector2_0;
			return;
		}
		if (!(VVertexB == Fortune.VVUnkown))
		{
			throw new Exception("Tried to add third vertex!");
		}
		VVertexB = vector2_0;
	}
}
