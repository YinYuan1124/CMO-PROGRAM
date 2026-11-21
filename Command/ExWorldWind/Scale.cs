using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using DXRenderer;

namespace ExWorldWind;

public class Scale
{
	internal Scale()
	{
	}

	internal void CollectThread(DrawArgs drawArgs_0)
	{
		float num = 0.0175f;
		int regDefinition = Main.Instance._RegDefinition;
		int screenHeight = Main.Instance.ScreenHeight;
		Point point = new Point(Convert.ToInt32((float)((double)(float)regDefinition * 0.8499999940395355 / 2.0)), screenHeight / 2);
		Point point2 = new Point(Convert.ToInt32((float)((double)(float)regDefinition * 1.1500000059604645 / 2.0)), screenHeight / 2);
		Point point3 = new Point(Convert.ToInt32((float)((double)(float)regDefinition * 0.8324999939650297)), Convert.ToInt32((float)((double)(float)screenHeight * 0.9824999999254942)));
		Point point4 = new Point(Convert.ToInt32((float)((double)(float)regDefinition * 0.9824999999254942)), Convert.ToInt32((float)((double)(float)screenHeight * 0.9824999999254942)));
		point3.X += -30;
		point4.X += -30;
		int xOffset = DrawArgs.Instance.XOffset;
		point3.X -= xOffset;
		point4.X -= xOffset;
		point3.Y += 10;
		point4.Y += 10;
		Vertex[] array = new Vertex[2];
		float num4 = Main.Instance.PopIssuer("Aj");
		array[0]._DescriptorVal.X = point3.X;
		array[0]._DescriptorVal.Y = (float)point3.Y - num4 * 1.1f;
		array[1]._DescriptorVal.X = point4.X;
		array[1]._DescriptorVal.Y = (float)point4.Y - num4 * 1.1f;
		Vertex[,] array2 = new Vertex[10, 2];
		float num5 = (float)(point4.X - point3.X) / (float)(array2.GetLength(0) - 1);
		for (int i = 0; i < array2.GetLength(0); i++)
		{
			array2[i, 0]._DescriptorVal.X = (float)point3.X + num5 * (float)i;
			array2[i, 1]._DescriptorVal.X = (float)point3.X + num5 * (float)i;
			array2[i, 0]._DescriptorVal.Y = point3.Y - Convert.ToInt32((double)num4 * 1.1);
			array2[i, 1]._DescriptorVal.Y = (float)(point3.Y - Convert.ToInt32((double)num4 * 1.1)) - num * (float)screenHeight;
		}
		drawArgs_0.WorldCamera.PickingRayIntersection(point.X, point.Y, out var angle_, out var angle_2);
		if (Angle.IsNaN(angle_) || Angle.IsNaN(angle_2))
		{
			return;
		}
		drawArgs_0.WorldCamera.PickingRayIntersection(point2.X, point2.Y, out var angle_3, out var angle_4);
		if (Angle.IsNaN(angle_3) || Angle.IsNaN(angle_4))
		{
			return;
		}
		double num6 = World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Radians * 6378137.0;
		int num7 = 1;
		string string_ = "Meters";
		if (num6 > 5556.0)
		{
			num7 = 1852;
			string_ = "Nautical miles";
		}
		Main.Instance.DrawLine(Color.White, 1f, array[0]._DescriptorVal.X, array[0]._DescriptorVal.Y, array[1]._DescriptorVal.X, array[1]._DescriptorVal.Y);
		for (int j = 0; j < array2.GetLength(0); j++)
		{
			Main.Instance.DrawLine(Color.White, 1f, array2[j, 0]._DescriptorVal.X, array2[j, 0]._DescriptorVal.Y, array2[j, 1]._DescriptorVal.X, array2[j, 1]._DescriptorVal.Y);
		}
		float num8 = Main.Instance.InstantiateIssuer(string_);
		float num9 = Main.Instance.PopIssuer(string_);
		Main.Instance.DrawText(string_, Convert.ToInt32(((float)(point3.X + point4.X) - num8) / 2f), Convert.ToInt32((float)point3.Y - num9), bool_0: true);
		string[] array3 = new string[4];
		float num10 = (float)(point4.X - point3.X) / (float)(array3.Length - 1);
		array3[0] = "0";
		double num11 = 0.0;
		for (int k = 0; k < array3.Length; k++)
		{
			if (k > 0)
			{
				num11 = num6 / (double)num7 * ((double)k / (double)(array3.Length - 1));
				if (num11 == 0.0)
				{
					array3[k] = "n/a";
				}
				else
				{
					array3[k] = OrderThread(num11, 2).ToString();
				}
			}
			float num2 = Main.Instance.InstantiateIssuer(array3[k]);
			float num3 = Main.Instance.PopIssuer(array3[k]);
			Main.Instance.DrawText(array3[k], Convert.ToInt32((float)point3.X + num10 * (float)k - num2 / 2f), Convert.ToInt32((double)(array2[k, 1]._DescriptorVal.Y - num3) - (double)(array2[k, 0]._DescriptorVal.Y - array2[k, 1]._DescriptorVal.Y) * 0.1), bool_0: true);
		}
	}

	[CompilerGenerated]
	internal static int OrderThread(double double_0, int int_0)
	{
		if (double_0 == 0.0)
		{
			throw new ArgumentException("Precise is ZERO!");
		}
		int num = Convert.ToInt32(Math.Log10(double_0) + 1.0);
		if (num <= int_0)
		{
			return Convert.ToInt32(double_0);
		}
		int num2 = Convert.ToInt32(Math.Pow(10.0, num - int_0));
		return Convert.ToInt32(Math.Round(double_0 / (double)num2) * (double)num2);
	}
}
