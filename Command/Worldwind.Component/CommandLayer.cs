using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using CSMaterial;
using Command_Core;
using DXRenderer;
using ExWorldWind;

namespace Worldwind.Component;

public class CommandLayer
{
	public enum IconOutlineLevel
	{
		NoOutline,
		Fast,
		HighQuality
	}

	public delegate void RenderDelegate();

	[CompilerGenerated]
	private sealed class WriterDecoratorEntry
	{
		public int int_0;

		public int int_1;

		internal bool DestroyInterruptibleTemplate(PointF F)
		{
			if (F.X == (float)int_0)
			{
				return F.Y == (float)int_1;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ProductProcessResolver
	{
		public int int_0;

		public int int_1;

		internal bool ComputeInterruptibleTemplate(PointF F)
		{
			if (F.X == (float)int_0)
			{
				return F.Y == (float)int_1;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ParamExporter
	{
		public int int_0;

		public int int_1;

		internal bool PatchInterruptibleTemplate(PointF F)
		{
			if (F.X == (float)int_0)
			{
				return F.Y == (float)int_1;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class DispatcherCollectionTask
	{
		public int int_0;

		public int int_1;

		internal bool SelectInterruptibleTemplate(PointF F)
		{
			if (F.X == (float)int_0)
			{
				return F.Y == (float)int_1;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class AttributeParameterMock
	{
		public CommandLayer _003C_003E4__this;

		public Color color;

		internal CustomVertex.PositionColored CallInterruptibleTemplate(Geopoint_Struct F)
		{
			return _003C_003E4__this.WriteMerchant(F, color);
		}
	}

	[CompilerGenerated]
	private sealed class DefinitionParameterMessage
	{
		public CommandLayer _003C_003E4__this;

		public Color color_0;

		internal CustomVertex.PositionColored LogoutInterruptibleTemplate(PointF F)
		{
			return _003C_003E4__this.NewMerchant(F, color_0);
		}
	}

	private Dictionary<string, shape> _MapMerchant = new Dictionary<string, shape>();

	public const bool forceSubstitution = true;

	protected string name;

	public bool isInitialized;

	private bool _TemplateMerchant;

	private double mappingMerchant;

	public RenderDelegate callback;

	private int m_MockMerchant;

	private int tagMerchant;

	public static HashSet<string> AlaCarteDisabledSet;

	public void DrawArea(IEnumerable<Geopoint_Struct> ienumerable_0, int int_0, Color color_0, Color color_1)
	{
		if (IsAlaCarteDisabled("DrawArea1"))
		{
			return;
		}
		DrawArgs instance = DrawArgs.Instance;
		Vector3 vector = new Vector3(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		int int_3 = color_1.ToArgb();
		int num = ienumerable_0.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Geopoint_Struct geopoint_Struct = ienumerable_0.ElementAt(i);
			Vector3 vector2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian(geopoint_Struct.Latitude, geopoint_Struct.Longitude, mappingMerchant) - vector);
			int int_ = (int)Math.Round(vector2.X);
			int int_2 = (int)Math.Round(vector2.Y);
			if (!list.Any((PointF F) => F.X == (float)int_ && F.Y == (float)int_2))
			{
				list.Add(new PointF(int_, int_2));
			}
		}
		if (list.Count() < 3)
		{
			return;
		}
		List<List<PointF>> list2 = PolygonTriangulator.Triangulate(list);
		ScreenTransform();
		int count = list2.Count;
		if (count > 0)
		{
			CustomVertex.PositionColored[] array = new CustomVertex.PositionColored[count * 3];
			int num2 = 0;
			foreach (PointF item in list2.SelectMany((List<PointF> F) => F))
			{
				array[num2] = new CustomVertex.PositionColored(item.X, item.Y, 0f, int_3);
				num2++;
			}
		}
		RestoreTransform();
		ResetRenderState();
		DrawGeoLine(color_0, int_0, ienumerable_0.Concat(new Geopoint_Struct[1] { ienumerable_0.First() }));
	}

	public void DrawAreaAlpha(IEnumerable<Geopoint_Struct> ienumerable_0, int int_0, Color color_0, Color color_1, int int_1)
	{
		if (IsAlaCarteDisabled("DrawAreaAlpha"))
		{
			return;
		}
		DrawArgs instance = DrawArgs.Instance;
		Vector3 vector = new Vector3(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		int int_4 = Color.FromArgb(int_1, color_1).ToArgb();
		int num = ienumerable_0.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Geopoint_Struct geopoint_Struct = ienumerable_0.ElementAt(i);
			Vector3 vector2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian(geopoint_Struct.Latitude, geopoint_Struct.Longitude, mappingMerchant) - vector);
			int int_2 = (int)Math.Round(vector2.X);
			int int_3 = (int)Math.Round(vector2.Y);
			if (!list.Any((PointF F) => F.X == (float)int_2 && F.Y == (float)int_3))
			{
				list.Add(new PointF(int_2, int_3));
			}
		}
		if (list.Count() < 3)
		{
			return;
		}
		List<List<PointF>> list2 = PolygonTriangulator.Triangulate(list);
		ScreenTransform();
		ViewMerchant(int_1);
		int count = list2.Count;
		if (count > 0)
		{
			CustomVertex.PositionColored[] array = new CustomVertex.PositionColored[count * 3];
			int num2 = 0;
			foreach (PointF item in list2.SelectMany((List<PointF> F) => F))
			{
				array[num2] = new CustomVertex.PositionColored(item.X, item.Y, 0f, int_4);
				num2++;
			}
		}
		RestoreTransform();
		ResetRenderState();
		DrawGeoLine(color_0, int_0, ienumerable_0.Concat(new Geopoint_Struct[1] { ienumerable_0.First() }));
	}

	public void DrawEllipse(float float_0, Color color_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (!IsAlaCarteDisabled("DrawEllipse1"))
		{
			int num = 120;
			for (int i = 0; i < num; i++)
			{
				float num2 = (float)(Math.PI * 2.0 * ((double)i / (double)num));
				float num3 = (float)Math.Sin(num2);
				float num4 = (float)Math.Cos(num2);
				float num5 = (float)(Math.PI * 2.0 * ((double)(i - 1) / (double)num));
				float num6 = (float)Math.Sin(num5);
				float num7 = (float)Math.Cos(num5);
				float float_ = (float)int_0 + num7 * (float)int_3 / 2f;
				float float_2 = (float)int_1 + num6 * (float)int_2 / 2f;
				float float_3 = (float)int_0 + num4 * (float)int_3 / 2f;
				float float_4 = (float)int_1 + num3 * (float)int_2 / 2f;
				DrawLine(color_0, float_0, float_, float_2, float_3, float_4);
			}
		}
	}

	public void FillEllipse(Color color_0, Color color_1, int int_0, int int_1, int int_2, int int_3)
	{
		if (IsAlaCarteDisabled("FillEllipse1"))
		{
			return;
		}
		if (color_1.A == 0)
		{
			int int_4 = color_0.ToArgb();
			int num = 45;
			CustomVertex.PositionColored[] array = new CustomVertex.PositionColored[135];
			for (int i = 0; i < num; i++)
			{
				float num7 = (float)(Math.PI * 2.0 * ((double)i / (double)num));
				float num8 = (float)Math.Sin(num7);
				float num9 = (float)Math.Cos(num7);
				float num10 = (float)(Math.PI * 2.0 * ((double)(i - 1) / (double)num));
				float num11 = (float)Math.Sin(num10);
				float num12 = (float)Math.Cos(num10);
				array[i * 3] = new CustomVertex.PositionColored((float)int_0 + num12 * (float)int_3 / 2f, (float)int_1 + num11 * (float)int_2 / 2f, 0f, int_4);
				array[i * 3 + 1] = new CustomVertex.PositionColored((float)int_0 + num9 * (float)int_3 / 2f, (float)int_1 + num8 * (float)int_2 / 2f, 0f, int_4);
				array[i * 3 + 2] = new CustomVertex.PositionColored(int_0, int_1, 0f, int_4);
			}
			ScreenTransform();
			LogoutMerchant(array, color_0);
			RestoreTransform();
			ResetRenderState();
			return;
		}
		int int_5 = color_0.ToArgb();
		int int_6 = color_1.ToArgb();
		int num13 = 45;
		CustomVertex.PositionColored[] array2 = new CustomVertex.PositionColored[135];
		CustomVertex.PositionColored[] array3 = new CustomVertex.PositionColored[90];
		for (int j = 0; j < num13; j++)
		{
			float num14 = (float)(Math.PI * 2.0 * ((double)j / (double)num13));
			float num2 = (float)Math.Sin(num14);
			float num3 = (float)Math.Cos(num14);
			float num4 = (float)(Math.PI * 2.0 * ((double)(j - 1) / (double)num13));
			float num5 = (float)Math.Sin(num4);
			float num6 = (float)Math.Cos(num4);
			array3[j * 2] = new CustomVertex.PositionColored((float)int_0 + num6 * (float)int_3 / 2f, (float)int_1 + num5 * (float)int_2 / 2f, 0f, int_6);
			array3[j * 2 + 1] = new CustomVertex.PositionColored((float)int_0 + num3 * (float)int_3 / 2f, (float)int_1 + num2 * (float)int_2 / 2f, 0f, int_6);
			array2[j * 3] = new CustomVertex.PositionColored((float)int_0 + num6 * (float)int_3 / 2f, (float)int_1 + num5 * (float)int_2 / 2f, 0f, int_5);
			array2[j * 3 + 1] = new CustomVertex.PositionColored((float)int_0 + num3 * (float)int_3 / 2f, (float)int_1 + num2 * (float)int_2 / 2f, 0f, int_5);
			array2[j * 3 + 2] = new CustomVertex.PositionColored(int_0, int_1, 0f, int_5);
		}
		ScreenTransform();
		LogoutMerchant(array2, color_0);
		CallMerchant(array3);
		RestoreTransform();
		ResetRenderState();
	}

	public void DrawRectangle(Color color_0, int int_0, int int_1, int int_2, int int_3)
	{
		DrawLine(color_0, int_0, int_1, int_0 + int_3, int_1);
		DrawLine(color_0, int_0 + int_3, int_1, int_0 + int_3, int_1 + int_2);
		DrawLine(color_0, int_0 + int_3, int_1 + int_2, int_0, int_1 + int_2);
		DrawLine(color_0, int_0, int_1 + int_2, int_0, int_1);
	}

	public void DrawThickRectangle(Color color_0, int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		DrawLine(color_0, int_0, int_1, int_2, int_1 + int_4, int_2);
		DrawLine(color_0, int_0, int_1 + int_4, int_2, int_1 + int_4, int_2 + int_3);
		DrawLine(color_0, int_0, int_1 + int_4, int_2 + int_3, int_1, int_2 + int_3);
		DrawLine(color_0, int_0, int_1, int_2 + int_3, int_1, int_2);
	}

	public void SetVertexFormat()
	{
	}

	public void DrawTrianglePrimitives(CustomVertex.PositionColored[] positionColored_0)
	{
	}

	public void FillRectangle(Color color_0, Color color_1, int int_0, int int_1, int int_2, int int_3)
	{
		if (!IsAlaCarteDisabled("FillRectangle1"))
		{
			Main instance = Main.Instance;
			if (instance != null)
			{
				PointF[] pointF_ = new PointF[4]
				{
					new PointF
					{
						X = int_0,
						Y = int_1
					},
					new PointF
					{
						X = int_0 + int_3,
						Y = int_1
					},
					new PointF
					{
						X = int_0 + int_3,
						Y = int_1 + int_2
					},
					new PointF
					{
						X = int_0,
						Y = int_1 + int_2
					}
				};
				instance.FillGeometry(pointF_, color_0);
			}
		}
	}

	public void FillPolygon(List<Geopoint_Struct> list_0, Color color_0)
	{
		if (IsAlaCarteDisabled("FillPolygon1"))
		{
			return;
		}
		DrawArgs instance = DrawArgs.Instance;
		Vector3 vector = new Vector3(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		color_0.ToArgb();
		int num = list_0.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Geopoint_Struct geopoint_Struct = list_0[i];
			Vector3 vector2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian(geopoint_Struct.Latitude, geopoint_Struct.Longitude, mappingMerchant) - vector);
			int int_0 = (int)Math.Round(vector2.X);
			int int_1 = (int)Math.Round(vector2.Y);
			if (!list.Any((PointF F) => F.X == (float)int_0 && F.Y == (float)int_1))
			{
				list.Add(new PointF(int_0, int_1));
			}
		}
		if (list.Count() >= 3)
		{
			Main.Instance?.FillGeometry(list.ToArray(), color_0);
		}
	}

	public void FillPolygon(List<Point> list_0, Color color_0)
	{
		if (IsAlaCarteDisabled("FillPolygon2"))
		{
			return;
		}
		int num = list_0.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Point point = list_0[i];
			int int_0 = point.X;
			int int_1 = point.Y;
			if (!list.Any((PointF F) => F.X == (float)int_0 && F.Y == (float)int_1))
			{
				list.Add(new PointF(int_0, int_1));
			}
		}
		if (list.Count() >= 3)
		{
			Main.Instance?.FillGeometry(list.ToArray(), color_0);
		}
	}

	public void FillPolygon(Color color_0, Point[] point_0, Point[] point_1, Point point_2)
	{
		Main.Instance?.FillRing(point_0, point_1, color_0);
	}

	public Tuple<double, double> LoxodromicInterpolation(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = Math.Cos(double_1);
		double num2 = Math.Cos(double_3);
		double x = (num + num2) / 2.0;
		double num3 = Math.Atan2(0.0, x);
		double_1 -= num3;
		double_3 -= num3;
		double num4 = double_3 * (1.0 - double_4) + double_1 * double_4;
		double item = double_2 * (1.0 - double_4) + double_0 * double_4;
		for (num4 += num3; num4 > Math.PI; num4 -= Math.PI * 2.0)
		{
		}
		for (; num4 < -Math.PI; num4 += Math.PI * 2.0)
		{
		}
		return new Tuple<double, double>(item, num4);
	}

	public void DrawLoxodromicLine(Color color_0, float float_0, double double_0, double double_1, double double_2, double double_3)
	{
		if (IsAlaCarteDisabled("DrawLoxodromicLine"))
		{
			return;
		}
		double num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
		double_0 *= CSMath.PI_dividedBy_180;
		double_2 *= CSMath.PI_dividedBy_180;
		double_1 *= CSMath.PI_dividedBy_180;
		double_3 *= CSMath.PI_dividedBy_180;
		int num2 = (int)(num / 100.0);
		if (num2 < 2)
		{
			DrawLine(color_0, float_0, ValidateMerchant(double_0, double_1), ValidateMerchant(double_2, double_3));
			return;
		}
		for (int i = 0; i < num2; i++)
		{
			double double_4 = (double)i / (double)num2;
			double double_5 = (double)(i + 1) / (double)num2;
			Tuple<double, double> tuple = LoxodromicInterpolation(double_0, double_1, double_2, double_3, double_4);
			Tuple<double, double> tuple2 = LoxodromicInterpolation(double_0, double_1, double_2, double_3, double_5);
			DrawLine(color_0, float_0, ValidateMerchant(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI), ValidateMerchant(tuple2.Item1 * 180.0 / Math.PI, tuple2.Item2 * 180.0 / Math.PI));
		}
	}

	public static Tuple<double, double> UTIL_OrthodromicInterpolation(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double_1 = 0.0 - double_1;
		double_3 = 0.0 - double_3;
		double num = 2.0 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((double_0 - double_2) / 2.0), 2.0) + Math.Cos(double_0) * Math.Cos(double_2) * Math.Pow(Math.Sin((double_1 - double_3) / 2.0), 2.0)));
		double num2 = Math.Sin((1.0 - double_4) * num) / Math.Sin(num);
		double num3 = Math.Sin(double_4 * num) / Math.Sin(num);
		double x = num2 * Math.Cos(double_0) * Math.Cos(double_1) + num3 * Math.Cos(double_2) * Math.Cos(double_3);
		double num4 = num2 * Math.Cos(double_0) * Math.Sin(double_1) + num3 * Math.Cos(double_2) * Math.Sin(double_3);
		double item = Math.Atan2(num2 * Math.Sin(double_0) + num3 * Math.Sin(double_2), Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num4, 2.0)));
		double num5 = Math.Atan2(num4, x);
		return new Tuple<double, double>(item, 0.0 - num5);
	}

	public void DrawOrthodromicLine(Color color_0, float float_0, double double_0, double double_1, double double_2, double double_3)
	{
		if (IsAlaCarteDisabled("DrawOrthodromicLine"))
		{
			return;
		}
		double num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
		double_0 *= CSMath.PI_dividedBy_180;
		double_2 *= CSMath.PI_dividedBy_180;
		double_1 *= CSMath.PI_dividedBy_180;
		double_3 *= CSMath.PI_dividedBy_180;
		int num2 = (int)(num / 100.0);
		if (num2 < 2)
		{
			DrawLine(color_0, float_0, ValidateMerchant(double_0 * 180.0 / Math.PI, double_1 * 180.0 / Math.PI), ValidateMerchant(double_2 * 180.0 / Math.PI, double_3 * 180.0 / Math.PI));
			return;
		}
		for (int i = 0; i < num2; i++)
		{
			double double_4 = (double)i / (double)num2;
			double double_5 = (double)(i + 1) / (double)num2;
			Tuple<double, double> tuple = UTIL_OrthodromicInterpolation(double_0, double_1, double_2, double_3, double_4);
			Tuple<double, double> tuple2 = UTIL_OrthodromicInterpolation(double_0, double_1, double_2, double_3, double_5);
			DrawLine(color_0, float_0, ValidateMerchant(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI), ValidateMerchant(tuple2.Item1 * 180.0 / Math.PI, tuple2.Item2 * 180.0 / Math.PI));
		}
	}

	public Rectangle MeasureString(Color color_0, int int_0, int int_1, string string_0, double double_0 = 0.0, int int_2 = 18)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			throw new Exception("Measure String Failure!");
		}
		return Main.Instance.MeasureText(string_0, (float)int_2 * 0.75f, int_0, int_1);
	}

	public void DrawText(Color color_0, int int_0, int int_1, string string_0, double double_0 = 0.0, int int_2 = 18, FontWeight fontWeight_0 = FontWeight.Normal, bool bool_0 = false, bool bool_1 = false, string string_1 = "Segoe UI", bool bool_2 = false, bool bool_3 = false)
	{
		Main.Instance?.DrawText(string_0, (float)int_2 * 0.75f, color_0, int_0, int_1, bool_2, bool_3);
	}

	public void DrawTransientBitmap(Bitmap bitmap_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (!IsAlaCarteDisabled("DrawTransientBitmap"))
		{
			CustomVertex.PositionTextured[] array = new CustomVertex.PositionTextured[6];
			int_0 += int_3 / 2;
			int_1 += int_2 / 2;
			array[0] = new CustomVertex.PositionTextured(new Vector3(int_0 - int_3 / 2, int_1 - int_2 / 2, 0f), 0f, 0f);
			array[1] = new CustomVertex.PositionTextured(new Vector3(int_0 + int_3 / 2, int_1 + int_2 / 2, 0f), 1f, 1f);
			array[2] = new CustomVertex.PositionTextured(new Vector3(int_0 - int_3 / 2, int_1 + int_2 / 2, 0f), 0f, 1f);
			array[3] = new CustomVertex.PositionTextured(new Vector3(int_0 + int_3 / 2, int_1 - int_2 / 2, 0f), 1f, 0f);
			array[4] = new CustomVertex.PositionTextured(new Vector3(int_0 + int_3 / 2, int_1 + int_2 / 2, 0f), 1f, 1f);
			array[5] = new CustomVertex.PositionTextured(new Vector3(int_0 - int_3 / 2, int_1 - int_2 / 2, 0f), 0f, 0f);
			ScreenTransform();
			RestoreTransform();
			ResetRenderState();
			Main.Instance?.DrawBitmap(bitmap_0);
		}
	}

	public void DrawIcon(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4, bool bool_0, int int_5, int int_6, int int_7, int int_8 = -1, bool bool_1 = false)
	{
		if (IsAlaCarteDisabled("DrawIcon1"))
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		string extension = Path.GetExtension(string_0);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_0);
		bool flag = false;
		if (!_MapMerchant.ContainsKey(string_0))
		{
			if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_diamond_" + extension)))
			{
				_MapMerchant.Add(string_0, shape.Diamond);
			}
			else if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_flower_" + extension)))
			{
				_MapMerchant.Add(string_0, shape.Flower);
			}
			else if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_rectangle_" + extension)))
			{
				_MapMerchant.Add(string_0, shape.Rectangle);
			}
		}
		if (_MapMerchant.ContainsKey(string_0))
		{
			shape shape2 = _MapMerchant[string_0];
			flag = true;
			switch (shape2)
			{
			case shape.Diamond:
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_diamond_" + extension);
				num2 = int_3 - int_5;
				num = int_4 - int_5;
				int_3 = int_5;
				int_4 = int_5;
				break;
			case shape.Flower:
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_flower_" + extension);
				num2 = int_3 - int_6;
				num = int_4 - int_6;
				int_3 = int_6;
				int_4 = int_6;
				break;
			case shape.Rectangle:
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_rectangle_" + extension);
				num2 = int_3 - int_7;
				num = int_4 - int_7;
				int_3 = int_7;
				int_4 = int_7;
				break;
			}
		}
		if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(string_0))
		{
			if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_diamond_" + extension)))
			{
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_diamond_" + extension);
				num2 = int_3 - int_5;
				num = int_4 - int_5;
				int_3 = int_5;
				int_4 = int_5;
				if (!_MapMerchant.ContainsKey(string_0))
				{
					_MapMerchant.Add(string_0, shape.Diamond);
				}
			}
			else if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_flower_" + extension)))
			{
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_flower_" + extension);
				num2 = int_3 - int_6;
				num = int_4 - int_6;
				int_3 = int_6;
				int_4 = int_6;
				if (!_MapMerchant.ContainsKey(string_0))
				{
					_MapMerchant.Add(string_0, shape.Flower);
				}
			}
			else if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_rectangle_" + extension)))
			{
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_rectangle_" + extension);
				num2 = int_3 - int_7;
				num = int_4 - int_7;
				int_3 = int_7;
				int_4 = int_7;
				if (!_MapMerchant.ContainsKey(string_0))
				{
					_MapMerchant.Add(string_0, shape.Rectangle);
				}
			}
		}
		if (!flag && bool_1)
		{
			num2 = int_3 - int_7;
			num = int_4 - int_7;
			int_3 = int_7;
			int_4 = int_7;
		}
		Main instance = Main.Instance;
		instance?.DrawIcon(string_0, int_0, int_1 + int_4 / 2 + num / 2, instance.ScreenHeight - int_2 - int_3 / 2 - num2 / 2, int_4, int_3, bool_0, int_8);
	}

	public void DrawIconRotated(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4, double double_0, bool bool_0, int int_5, int int_6, int int_7, int int_8 = -1)
	{
		if (IsAlaCarteDisabled("DrawIconRotated"))
		{
			return;
		}
		if (!File.Exists(string_0))
		{
			string extension = Path.GetExtension(string_0);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_0);
			if (File.Exists(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_diamond_" + extension)))
			{
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_diamond_" + extension);
				int_3 = int_5;
				int_4 = int_5;
			}
			else if (File.Exists(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_flower_" + extension)))
			{
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_flower_" + extension);
				int_3 = int_6;
				int_4 = int_6;
			}
			else if (File.Exists(Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_rectangle_" + extension)))
			{
				string_0 = Path.Combine(Path.GetDirectoryName(string_0), fileNameWithoutExtension + "_rectangle_" + extension);
				int_3 = int_7;
				int_4 = int_7 + 50;
			}
		}
		Main instance = Main.Instance;
		instance?.DrawIcon(string_0, int_0, int_1 + int_4 / 2, instance.ScreenHeight - int_2 - int_3 / 2, int_4, int_3, bool_0, int_8, (float)double_0);
	}

	public void DrawGeoLine(Color color_0, IEnumerable<Geopoint_Struct> ienumerable_0, bool bool_0 = false)
	{
		IEnumerable<Geopoint_Struct> source = (bool_0 ? ienumerable_0.Concat(new Geopoint_Struct[1] { ienumerable_0.First() }) : ienumerable_0);
		source.Select((Geopoint_Struct F) => WriteMerchant(F, color_0)).ToArray();
		Geopoint_Struct[] array = source.ToArray();
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Main instance = Main.Instance;
		if (instance != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Geopoint_Struct geopoint_Struct = array[i];
				Vector3 vector = MathEngine.SphericalToCartesian(geopoint_Struct.Latitude, geopoint_Struct.Longitude + 180.0, geopoint_Struct.Altitude + 6378137f);
				Vector3 vector3_ = new Vector3(0f - vector.Y, vector.Z, vector.X);
				Vector4 vector4_ = Main.IntToVector4(color_0.ToArgb());
				Vertex item = new Vertex(vector3_, vector4_);
				list.Add(item);
				list2.Add((uint)i);
			}
			instance.DrawLineStrip(list.ToArray(), list2.ToArray());
		}
	}

	public void DrawGeoLine(Color color_0, int int_0, IEnumerable<Geopoint_Struct> ienumerable_0, bool bool_0 = false)
	{
		DrawLine(color_0, int_0, ienumerable_0.Select(LoginMerchant).ToArray(), bool_0);
	}

	public void DrawGeoLine(Color color_0, double double_0, double double_1, double double_2, double double_3, double double_4 = 0.0, double double_5 = 0.0)
	{
		SelectMerchant(new CustomVertex.PositionColored[2]
		{
			new CustomVertex.PositionColored(MathEngine.SphericalToCartesian(double_0, double_1, mappingMerchant + double_4), color_0.ToArgb()),
			new CustomVertex.PositionColored(MathEngine.SphericalToCartesian(double_2, double_3, mappingMerchant + double_5), color_0.ToArgb())
		});
	}

	public void DrawLine(Color color_0, int int_0, Point[] point_0, bool bool_0 = false)
	{
		if (!IsAlaCarteDisabled("DrawLine1") && point_0.Length >= 2)
		{
			if (bool_0)
			{
				Point[] point_ = new Point[1] { point_0.First() };
				point_0 = DestroyMerchant(ref point_0, ref point_);
			}
			for (int i = 0; i < point_0.Length - 1; i++)
			{
				DrawLine(color_0, int_0, point_0.ElementAt(i), point_0.ElementAt(i + 1));
			}
		}
	}

	private Point[] DestroyMerchant(ref Point[] point_0, ref Point[] point_1)
	{
		Point[] array = new Point[point_0.Length + point_1.Length - 1 + 1];
		point_0.CopyTo(array, 0);
		point_1.CopyTo(array, point_0.Length);
		return array;
	}

	public void DrawLine(Color color_0, Point point_0, Point point_1)
	{
		if (!IsAlaCarteDisabled("DrawLine2"))
		{
			DrawLine(color_0, point_0.X, point_0.Y, point_1.X, point_1.Y);
		}
	}

	public void DrawLine(Color color_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (!IsAlaCarteDisabled("DrawLine3"))
		{
			CustomVertex.PositionColored[] positionColored_ = new CustomVertex.PositionColored[2]
			{
				InvokeMerchant(new Point(int_0, int_1), color_0),
				InvokeMerchant(new Point(int_2, int_3), color_0)
			};
			ScreenTransform();
			SelectMerchant(positionColored_);
			RestoreTransform();
		}
	}

	public void DrawDashedLine(Color color_0, float float_0, bool bool_0, Point point_0, Point point_1)
	{
		if (IsAlaCarteDisabled("DrawDashedLine1"))
		{
			return;
		}
		if (bool_0)
		{
			Vector3 vector = new Vector3(point_0.X, point_0.Y, 0f);
			Vector3 vector2 = new Vector3(point_1.X, point_1.Y, 0f);
			int num = (int)Math.Max((double)(vector2 - vector).Length() / 5.0, 2.0);
			for (int i = 0; i < num; i += 2)
			{
				Vector3 vector3 = vector + (vector2 - vector) * ((float)i / (float)num);
				Vector3 vector4 = vector + (vector2 - vector) * ((float)(i + 1) / (float)num);
				DrawLine(color_0, float_0, vector3.X, vector3.Y, vector4.X, vector4.Y);
			}
		}
		else
		{
			DrawLine(color_0, float_0, point_0, point_1);
		}
	}

	public void DrawLines_FAST(int int_0, SegmentVect[] segmentVect_0)
	{
		ScreenTransform();
		foreach (SegmentVect segmentVect in segmentVect_0)
		{
			Color color_ = Color.FromArgb(segmentVect.int_0);
			DrawLine(color_, int_0, segmentVect.A.X, segmentVect.A.Y, segmentVect.B.X, segmentVect.B.Y);
		}
		RestoreTransform();
	}

	public void DrawDashedLine(Color color_0, float float_0, bool bool_0, IEnumerable<Point> ienumerable_0)
	{
		if (!IsAlaCarteDisabled("DrawDashedLine2"))
		{
			for (int i = 0; i < ienumerable_0.Count() - 1; i++)
			{
				DrawDashedLine(color_0, float_0, bool_0, ienumerable_0.ElementAt(i), ienumerable_0.ElementAt(i + 1));
			}
		}
	}

	public void DrawLine(Color color_0, float float_0, Point point_0, Point point_1)
	{
		if (!IsAlaCarteDisabled("DrawLine4"))
		{
			DrawLine(color_0, float_0, point_0.X, point_0.Y, point_1.X, point_1.Y);
		}
	}

	private void ComputeMerchant(string string_0, Stopwatch stopwatch_0)
	{
		stopwatch_0.Restart();
	}

	public void DrawLine(Color color_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		if (!IsAlaCarteDisabled("DrawLine5"))
		{
			Main.Instance?.DrawLine(color_0, float_0, float_1, float_2, float_3, float_4);
		}
	}

	private static double PatchMerchant(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		if (double_2 - double_1 == 0.0)
		{
			return (double_3 + double_4) / 2.0;
		}
		return double_3 + (double_0 - double_1) * (double_4 - double_3) / (double_2 - double_1);
	}

	public void DrawDashedClosedPointLine(Pen pen_0, Point[] point_0)
	{
		if (IsAlaCarteDisabled("DrawDashedClosedPointLine"))
		{
			return;
		}
		try
		{
			Color color = pen_0.Color;
			int num = point_0.Length;
			Point[] array = new Point[num + 1];
			for (int i = 0; i < num; i++)
			{
				array[i] = point_0[i];
			}
			array[num] = array[0];
			ScreenTransform();
			int num2 = 0;
			bool flag = true;
			List<CustomVertex.PositionColored> list = new List<CustomVertex.PositionColored>(point_0.Length * 10);
			list.Add(InvokeMerchant(array[0], color));
			double num3 = array[0].X;
			double num4 = array[0].Y;
			double num5 = 4.0;
			while (true)
			{
				Point point = array[num2 + 1];
				double num6 = Math.Sqrt((num3 - (double)point.X) * (num3 - (double)point.X) + (num4 - (double)point.Y) * (num4 - (double)point.Y));
				while (num2 != point_0.Length - 1 && num5 >= num6)
				{
					num5 -= num6;
					num2++;
					num3 = array[num2].X;
					num4 = array[num2].Y;
					point = array[num2 + 1];
					num6 = Math.Sqrt((num3 - (double)point.X) * (num3 - (double)point.X) + (num4 - (double)point.Y) * (num4 - (double)point.Y));
					if (flag)
					{
						list.Add(InvokeMerchant(array[num2], color));
						list.Add(InvokeMerchant(array[num2], color));
					}
				}
				double num7 = num5 / num6;
				if (!(num7 <= 1.0) || !(num7 >= 0.0))
				{
					break;
				}
				num3 = PatchMerchant(num7, 0.0, 1.0, num3, point.X);
				num4 = PatchMerchant(num7, 0.0, 1.0, num4, point.Y);
				list.Add(new CustomVertex.PositionColored((int)Math.Round(num3), (int)Math.Round(num4), 0f, color.ToArgb()));
				flag = !flag;
				num5 = 4.0;
			}
			if (list.Count % 2 == 1)
			{
				list.RemoveAt(list.Count - 1);
			}
			CallMerchant(list.ToArray());
			RestoreTransform();
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public void DrawClosedPointLine(Pen pen_0, Point[] point_0)
	{
		if (IsAlaCarteDisabled("DrawClosedPointLine"))
		{
			return;
		}
		try
		{
			Color color = pen_0.Color;
			int num = point_0.Length;
			Point[] array = new Point[num + 1];
			for (int i = 0; i < num; i++)
			{
				array[i] = point_0[i];
			}
			array[num] = array[0];
			ScreenTransform();
			CustomVertex.PositionColored[] array2 = new CustomVertex.PositionColored[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = InvokeMerchant(array[j], color);
			}
			SelectMerchant(array2);
			RestoreTransform();
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public void DrawGraphicsPathLine(Pen pen_0, GraphicsPath graphicsPath_0)
	{
		if (IsAlaCarteDisabled("DrawGraphicsPathLine"))
		{
			return;
		}
		graphicsPath_0.Flatten();
		Color color_0 = pen_0.Color;
		CustomVertex.PositionColored[] array = graphicsPath_0.PathPoints.Select((PointF F) => NewMerchant(F, color_0)).ToArray();
		byte[] pathTypes = graphicsPath_0.PathTypes;
		int num = array.Count();
		int num2 = 0;
		List<CustomVertex.PositionColored> list = new List<CustomVertex.PositionColored>(num);
		ScreenTransform();
		for (int i = 0; i < num; i++)
		{
			if (pathTypes[i] == 0)
			{
				list.Clear();
				list.Add(array[i]);
				num2 = i;
			}
			else if (pathTypes[i] == 1)
			{
				list.Add(array[i]);
			}
			else if (pathTypes[i] == 129)
			{
				list.Add(array[i]);
				list.Add(array[num2]);
				CustomVertex.PositionColored[] positionColored_ = list.ToArray();
				SelectMerchant(positionColored_, pen_0);
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (list.Count() != 0)
		{
			CustomVertex.PositionColored[] positionColored_2 = list.ToArray();
			SelectMerchant(positionColored_2, pen_0);
		}
		RestoreTransform();
	}

	private void SelectMerchant(CustomVertex.PositionColored[] positionColored_0, Pen pen_0 = null)
	{
		if (IsAlaCarteDisabled("DrawPrimitiveLineStrip"))
		{
			return;
		}
		int num = positionColored_0.Length;
		if (num <= 1)
		{
			return;
		}
		for (int i = 0; i < num - 1; i++)
		{
			Color color_;
			float float_;
			if (pen_0 == null)
			{
				color_ = Color.FromArgb(positionColored_0[i].Color);
				float_ = 1.5f;
			}
			else
			{
				color_ = pen_0.Color;
				float_ = pen_0.Width;
			}
			Main.Instance?.DrawLine(color_, float_, positionColored_0[i].X, positionColored_0[i].Y, positionColored_0[i + 1].X, positionColored_0[i + 1].Y);
		}
	}

	private void CallMerchant(CustomVertex.PositionColored[] positionColored_0)
	{
		if (IsAlaCarteDisabled("DrawPrimitiveLineList"))
		{
			return;
		}
		int num = positionColored_0.Length;
		if (num <= 1)
		{
			return;
		}
		if (num % 2 != 0)
		{
			if (!Debugger.IsAttached)
			{
				return;
			}
			Debugger.Break();
		}
		Main instance = Main.Instance;
		if (instance != null)
		{
			Point[] array = new Point[positionColored_0.Length];
			for (int i = 0; i < num; i++)
			{
				CustomVertex.PositionColored positionColored = positionColored_0[i];
				array[i] = new Point((int)positionColored.X, (int)positionColored.Y);
			}
			Color color_ = Color.FromArgb(positionColored_0[0].Color);
			instance.DrawDashedLine(color_, array);
		}
	}

	private void LogoutMerchant(CustomVertex.PositionColored[] positionColored_0, Color color_0)
	{
		Main instance = Main.Instance;
		if (instance != null)
		{
			PointF[] array = new PointF[positionColored_0.Length];
			for (int i = 0; i < positionColored_0.Length; i++)
			{
				CustomVertex.PositionColored positionColored = positionColored_0[i];
				array[i] = new PointF((int)positionColored.X, (int)positionColored.Y);
			}
			instance.FillGeometry(array, color_0);
		}
	}

	public void DrawGradientLine(Color color_0, int int_0, bool bool_0, float float_0, float float_1, float float_2, float float_3)
	{
		if (!IsAlaCarteDisabled("DrawGradientLine"))
		{
			Main.Instance?.DrawGradientLine(color_0, int_0, bool_0, float_0, float_1, float_2, float_3);
		}
	}

	public static bool IsAlaCarteDisabled(string string_0)
	{
		if (AlaCarteDisabledSet.Contains(string_0))
		{
			return true;
		}
		return false;
	}

	public static void SetAlaCarteDisabled(string string_0, bool bool_0)
	{
		if (bool_0)
		{
			if (AlaCarteDisabledSet.Contains(string_0))
			{
				AlaCarteDisabledSet.Remove(string_0);
			}
		}
		else if (!AlaCarteDisabledSet.Contains(string_0))
		{
			AlaCarteDisabledSet.Add(string_0);
		}
	}

	public CommandLayer(string string_0, RenderDelegate renderDelegate_0)
	{
		name = string_0;
		callback = renderDelegate_0;
	}

	public void Render(DrawArgs drawArgs_0)
	{
		DrawArgs instance = DrawArgs.Instance;
		if (!isInitialized)
		{
			Initialize(drawArgs_0);
		}
		m_MockMerchant = (int)instance.WorldCamera.ViewportHeight;
		tagMerchant = (int)instance.WorldCamera.ViewportWidth;
		ResetRenderState();
		ViewMerchant(255);
		RestoreTransform();
		callback();
		ResetRenderState();
		ViewMerchant(255);
		instance = null;
	}

	public void ResetRenderState()
	{
		ViewMerchant(255);
	}

	public bool Update(DrawArgs drawArgs_0)
	{
		return true;
	}

	public void Dispose()
	{
	}

	private void ViewMerchant(int int_0)
	{
	}

	public void Initialize(DrawArgs drawArgs_0)
	{
		if (!isInitialized)
		{
			mappingMerchant = 6378137.0;
			isInitialized = true;
		}
	}

	public bool PerformSelectionAction(DrawArgs drawArgs_0)
	{
		return false;
	}

	private Point ValidateMerchant(double double_0, double double_1)
	{
		DrawArgs instance = DrawArgs.Instance;
		Vector3 vector = new Vector3(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		Vector3 vector2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian(double_0, double_1, mappingMerchant) - vector);
		return new Point((int)vector2.X, (int)vector2.Y);
	}

	private Point LoginMerchant(Geopoint_Struct geopoint_Struct_0)
	{
		DrawArgs instance = DrawArgs.Instance;
		Vector3 vector = new Vector3(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		Vector3 vector2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, mappingMerchant) - vector);
		return new Point((int)vector2.X, (int)vector2.Y);
	}

	private CustomVertex.PositionColored GetMerchant(GeoPoint geoPoint_0, Color color_0)
	{
		return new CustomVertex.PositionColored(MathEngine.SphericalToCartesian(geoPoint_0.Latitude, geoPoint_0.Longitude, mappingMerchant), color_0.ToArgb());
	}

	private CustomVertex.PositionColored WriteMerchant(Geopoint_Struct geopoint_Struct_0, Color color_0)
	{
		return new CustomVertex.PositionColored(MathEngine.SphericalToCartesian(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, mappingMerchant), color_0.ToArgb());
	}

	private CustomVertex.PositionColored NewMerchant(PointF pointF_0, Color color_0)
	{
		return new CustomVertex.PositionColored(new Vector3(pointF_0.X, pointF_0.Y, 0f), color_0.ToArgb());
	}

	private Vector3 PushMerchant(Point point_0)
	{
		return new Vector3(point_0.X, point_0.Y, 0f);
	}

	private CustomVertex.PositionColored InvokeMerchant(Point point_0, Color color_0)
	{
		return new CustomVertex.PositionColored(new Vector3(point_0.X, point_0.Y, 0f), color_0.ToArgb());
	}

	public void ScreenTransform()
	{
	}

	public void RestoreTransform()
	{
	}

	static CommandLayer()
	{
		AlaCarteDisabledSet = new HashSet<string>();
	}
}
