using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using DXRenderer;
using DirectN;

namespace ExWorldWind;

public class LatLongGrid
{
	public double WorldRadius;

	protected double radius;

	public int MinVisibleLongitude;

	public int MaxVisibleLongitude;

	public int MinVisibleLatitude;

	public int MaxVisibleLatitude;

	public int LongitudeInterval;

	public int LatitudeInterval;

	public float LatitudeInterval_curved => (float)LatitudeInterval / 10f;

	public float LongitudeInterval_curved => (float)LongitudeInterval / 10f;

	public LatLongGrid()
	{
		WorldRadius = 6378137.0;
		ResetThread(1);
		ResetThread(2);
		ResetThread(5);
		ResetThread(10);
	}

	private double QueryThread(int int_0)
	{
		return WorldRadius + (double)(int_0 * (int_0 + int_0 / 4) * 100);
	}

	private void ResetThread(int int_0)
	{
		float num = (float)int_0 / 10f;
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Vector4 vector = Main.IntToVector4(-928997216);
		Vector4 vector2 = Main.IntToVector4(-1606360880);
		MinVisibleLatitude = -90;
		MinVisibleLongitude = -180;
		MaxVisibleLatitude = 90;
		MaxVisibleLongitude = 180;
		radius = QueryThread(int_0);
		int num2 = 0;
		for (float num3 = MinVisibleLongitude; num3 < (float)MaxVisibleLongitude; num3 += (float)int_0)
		{
			for (float num4 = MinVisibleLatitude; num4 <= (float)MaxVisibleLatitude; num4 += num)
			{
				Vector3 vector3 = MathEngine.SphericalToCartesian(num4, num3, radius);
				Vertex item = new Vertex(new Vector3(vector3.Y, vector3.Z, vector3.X), vector);
				list.Add(item);
				list2.Add((uint)num2++);
			}
			list2.Add(uint.MaxValue);
		}
		for (float num5 = MinVisibleLatitude; num5 <= (float)MaxVisibleLatitude; num5 += (float)int_0)
		{
			for (float num6 = MinVisibleLongitude; num6 <= (float)MaxVisibleLongitude; num6 += num)
			{
				Vector3 vector4 = MathEngine.SphericalToCartesian(num5, num6, radius);
				Vector4 vector4_ = vector;
				if (num5 == 0f)
				{
					vector4_ = vector2;
				}
				Vertex item2 = new Vertex(new Vector3(vector4.Y, vector4.Z, vector4.X), vector4_);
				list.Add(item2);
				list2.Add((uint)num2++);
			}
			list2.Add(uint.MaxValue);
		}
		Main.Instance.RunIssuer("Longitudes" + int_0, list.ToArray(), list2.ToArray(), D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINESTRIP, bool_0: false);
	}

	internal void MapThread(DrawArgs drawArgs_0)
	{
		Main instance = Main.Instance;
		RateThread(drawArgs_0);
		float num = (float)drawArgs_0.WorldCamera._AdapterProcess.Degrees / 6f;
		Vector3 vector = new Vector3(drawArgs_0.WorldCamera.ReferenceCenter.X, drawArgs_0.WorldCamera.ReferenceCenter.Y, drawArgs_0.WorldCamera.ReferenceCenter.Z);
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Main.IntToVector4(-928997216);
		Main.IntToVector4(-1606360880);
		for (float num2 = MinVisibleLongitude; num2 < (float)MaxVisibleLongitude; num2 += (float)LongitudeInterval)
		{
			float num3 = (float)drawArgs_0.WorldCamera.Latitude.Degrees;
			if (num3 > 70f)
			{
				num3 = 70f;
			}
			if (num3 < -70f)
			{
				num3 = -70f;
			}
			Vector3 vector2 = MathEngine.SphericalToCartesian(num3, num2, radius);
			if (drawArgs_0.WorldCamera.ViewFrustum.ContainsPoint(vector2))
			{
				int num4 = (int)num2;
				if (num4 <= -180)
				{
					num4 += 360;
				}
				else if (num4 > 180)
				{
					num4 -= 360;
				}
				string text = Math.Abs(num4).ToString();
				if (num4 < 0)
				{
					text += "W";
				}
				else if (num4 > 0 && num4 < 180)
				{
					text += "E";
				}
				vector2 = drawArgs_0.WorldCamera.Project(vector2 - vector);
				Rectangle rectangle = new Rectangle((int)vector2.X + 2, (int)vector2.Y, 10, 10);
				instance?.DrawText(text, rectangle.Left, rectangle.Top, bool_0: false);
			}
		}
		for (float num5 = MinVisibleLatitude; num5 <= (float)MaxVisibleLatitude; num5 += (float)LatitudeInterval)
		{
			float num6 = (float)drawArgs_0.WorldCamera.Longitude.Degrees + num;
			Vector3 vector3 = MathEngine.SphericalToCartesian(num5, num6, radius);
			if (!drawArgs_0.WorldCamera.ViewFrustum.ContainsPoint(vector3))
			{
				continue;
			}
			vector3 = drawArgs_0.WorldCamera.Project(vector3 - vector);
			float num7 = num5;
			if (num7 <= 90f)
			{
				if (num7 < -90f)
				{
					num7 = -180f - num7;
				}
			}
			else
			{
				num7 = 180f - num7;
			}
			string text2 = ((int)Math.Abs(num7)).ToString();
			if (num7 <= 0f)
			{
				if (num7 < 0f)
				{
					text2 += "S";
				}
			}
			else
			{
				text2 += "N";
			}
			Rectangle rectangle2 = new Rectangle((int)vector3.X, (int)vector3.Y, 10, 10);
			instance?.DrawText(text2, rectangle2.Left, rectangle2.Top, bool_0: false);
		}
		instance.DrawLineStrip("Longitudes" + LongitudeInterval, list.ToArray(), list2.ToArray());
		SortThread(drawArgs_0);
	}

	private void SortThread(DrawArgs drawArgs_0)
	{
		CalcThread(drawArgs_0, 23.439444f, "Tropic Of Cancer");
		CalcThread(drawArgs_0, -23.439444f, "Tropic Of Capricorn");
		CalcThread(drawArgs_0, 66.560555f, "Arctic Circle");
		CalcThread(drawArgs_0, -66.560555f, "Antarctic Circle");
	}

	private void CalcThread(DrawArgs drawArgs_0, float float_0, string string_0)
	{
		Main instance = Main.Instance;
		int num = 0;
		Vector3 vector = new Vector3(drawArgs_0.WorldCamera.ReferenceCenter.X, drawArgs_0.WorldCamera.ReferenceCenter.Y, drawArgs_0.WorldCamera.ReferenceCenter.Z);
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Vector4 vector4_ = Main.IntToVector4(-1599020826);
		for (float num2 = MinVisibleLongitude; num2 <= (float)MaxVisibleLongitude; num2 += LongitudeInterval_curved)
		{
			Vector3 vector2 = MathEngine.SphericalToCartesian(float_0, num2, radius);
			Vertex item = new Vertex(new Vector3(vector2.Y, vector2.Z, vector2.X), vector4_);
			list.Add(item);
			list2.Add((uint)num++);
		}
		Vector3 vector3 = MathEngine.SphericalToCartesian(Angle.FromDegrees(float_0), drawArgs_0.WorldCamera.Longitude - drawArgs_0.WorldCamera._AdapterProcess * 0.30000001192092896 * 0.5, radius);
		if (drawArgs_0.WorldCamera.ViewFrustum.ContainsPoint(vector3))
		{
			vector3 = drawArgs_0.WorldCamera.Project(vector3 - vector);
		}
		if (instance != null)
		{
			instance.DrawLineStrip(list.ToArray(), list2.ToArray());
			instance.DrawText(string_0, (int)vector3.X, (int)vector3.Y, bool_0: false);
		}
	}

	internal void RateThread(DrawArgs drawArgs_0)
	{
		double radians = drawArgs_0.WorldCamera._AdapterProcess.Radians;
		radians *= 1.0 + Math.Abs(Math.Sin(drawArgs_0.WorldCamera.Latitude.Radians));
		if (radians < 0.17)
		{
			LatitudeInterval = 1;
		}
		else if (radians < 0.6)
		{
			LatitudeInterval = 2;
		}
		else if (radians < 1.0)
		{
			LatitudeInterval = 5;
		}
		else
		{
			LatitudeInterval = 10;
		}
		LongitudeInterval = LatitudeInterval;
		if (drawArgs_0.WorldCamera.ViewFrustum.ContainsPoint(MathEngine.SphericalToCartesian(90.0, 0.0, radius)) || drawArgs_0.WorldCamera.ViewFrustum.ContainsPoint(MathEngine.SphericalToCartesian(-90.0, 0.0, radius)))
		{
			LongitudeInterval = 10;
		}
		MinVisibleLongitude = ((LongitudeInterval < 10) ? ((int)drawArgs_0.WorldCamera.Longitude.Degrees / LongitudeInterval * LongitudeInterval - 18 * LongitudeInterval) : (-180));
		MaxVisibleLongitude = ((LongitudeInterval < 10) ? ((int)drawArgs_0.WorldCamera.Longitude.Degrees / LongitudeInterval * LongitudeInterval + 18 * LongitudeInterval) : 180);
		MinVisibleLatitude = (int)drawArgs_0.WorldCamera.Latitude.Degrees / LatitudeInterval * LatitudeInterval - 9 * LatitudeInterval;
		MaxVisibleLatitude = (int)drawArgs_0.WorldCamera.Latitude.Degrees / LatitudeInterval * LatitudeInterval + 9 * LatitudeInterval;
		if (MaxVisibleLatitude - MinVisibleLatitude >= 180 || LongitudeInterval == 10)
		{
			MinVisibleLatitude = -90;
			MaxVisibleLatitude = 90;
		}
		radius = QueryThread(LongitudeInterval);
	}
}
