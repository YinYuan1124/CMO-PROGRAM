using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public static class DistanceMethods
{
	public static double SquaredDistance(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return (vector2D_0 - vector2D_1).GetLengthSquared();
	}

	public static double Distance(Vector2D vector2D_0, Vector2D vector2D_1)
	{
		return (vector2D_0 - vector2D_1).GetLength();
	}

	public static double SquaredDistance(Vector2D vector2D_0, Segment segment_0)
	{
		Vector2D vector2D = segment_0.P1 - segment_0.P0;
		Vector2D vector2D2 = vector2D_0 - segment_0.P0;
		double num = Vector2D.DotProduct(vector2D, vector2D2);
		if (num <= 0.0)
		{
			return Vector2D.DotProduct(vector2D2, vector2D2);
		}
		double num2 = Vector2D.DotProduct(vector2D, vector2D);
		if (num < num2)
		{
			return Vector2D.DotProduct(vector2D2, vector2D2) - num * num / num2;
		}
		Vector2D vector2D3 = vector2D_0 - segment_0.P1;
		return Vector2D.DotProduct(vector2D3, vector2D3);
	}

	public static double Distance(Vector2D vector2D_0, Segment segment_0)
	{
		return System.Math.Sqrt(SquaredDistance(vector2D_0, segment_0));
	}

	public static double SquaredDistance(Vector2D vector2D_0, Ray ray_0)
	{
		Vector2D vector2D_ = vector2D_0 - ray_0.Origin;
		double num = Vector2D.DotProduct(vector2D_, ray_0.Direction);
		if (num <= 0.0)
		{
			return vector2D_.GetLengthSquared();
		}
		num = num * num / ray_0.Direction.GetLengthSquared();
		return vector2D_.GetLengthSquared() - num;
	}

	public static float Distance(Vector2D vector2D_0, Ray ray_0)
	{
		return (float)System.Math.Sqrt(SquaredDistance(vector2D_0, ray_0));
	}

	public static float SquaredDistance(Vector2D vector2D_0, OrientedBox orientedBox_0)
	{
		throw new NotImplementedException();
	}

	public static float Distance(Vector2D vector2D_0, OrientedBox orientedBox_0)
	{
		throw new NotImplementedException();
	}

	public static float SquaredDistance(Ray ray_0, Ray ray_1)
	{
		throw new NotImplementedException();
	}

	public static float Distance(Ray ray_0, Ray ray_1)
	{
		throw new NotImplementedException();
	}

	public static float SquaredDistance(Segment segment_0, Segment segment_1)
	{
		throw new NotImplementedException();
	}

	public static float Distance(Segment segment_0, Segment segment_1)
	{
		throw new NotImplementedException();
	}
}
