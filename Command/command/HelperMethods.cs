using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class HelperMethods
{
	public enum MouseMode : byte
	{
		Normal,
		Hovered,
		Pushed,
		Disabled
	}

	public static void smethod_0(Graphics graphics_0, string string_0, Rectangle rectangle_0)
	{
		Image image = null;
		Graphics graphics = graphics_0;
		using (MemoryTributary memoryTributary = new MemoryTributary(Convert.FromBase64String(string_0)))
		{
			image = Image.FromStream(memoryTributary);
			memoryTributary.Close();
		}
		graphics.DrawImage(image, rectangle_0);
		graphics = null;
	}

	public static void FillRoundedPath(Graphics graphics_0, Color color_0, Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		graphics_0.FillPath(new SolidBrush(color_0), RoundRec(rectangle_0, int_0, bool_0, bool_1, bool_2, bool_3));
	}

	public static void FillRoundedPath(Graphics graphics_0, Brush brush_0, Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		graphics_0.FillPath(brush_0, RoundRec(rectangle_0, int_0, bool_0, bool_1, bool_2, bool_3));
	}

	public static void FillWithInnerRectangle(Graphics graphics_0, Color color_0, Color color_1, Point point_0, Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		using PathGradientBrush pathGradientBrush = new PathGradientBrush(RoundRec(rectangle_0, int_0, bool_0, bool_1, bool_2, bool_3));
		PathGradientBrush pathGradientBrush2 = pathGradientBrush;
		pathGradientBrush2.CenterColor = color_0;
		pathGradientBrush2.SurroundColors = new Color[1] { color_1 };
		pathGradientBrush2.FocusScales = point_0;
		GraphicsPath graphicsPath = new GraphicsPath
		{
			FillMode = FillMode.Winding
		};
		graphicsPath.AddRectangle(rectangle_0);
		graphics_0.FillPath(pathGradientBrush, graphicsPath);
		graphicsPath.Dispose();
		pathGradientBrush2 = null;
	}

	public static void FillWithInnerEllipse(Graphics graphics_0, Color color_0, Color color_1, Point point_0, Rectangle rectangle_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath
		{
			FillMode = FillMode.Winding
		};
		graphicsPath.AddEllipse(rectangle_0);
		using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
		PathGradientBrush pathGradientBrush2 = pathGradientBrush;
		pathGradientBrush2.CenterColor = color_0;
		pathGradientBrush2.SurroundColors = new Color[1] { color_1 };
		pathGradientBrush2.FocusScales = point_0;
		graphics_0.FillPath(pathGradientBrush, graphicsPath);
		graphicsPath.Dispose();
		pathGradientBrush2 = null;
	}

	public static void FillWithInnerRoundedPath(Graphics graphics_0, Color color_0, Color color_1, Point point_0, Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		using PathGradientBrush pathGradientBrush = new PathGradientBrush(RoundRec(rectangle_0, int_0, bool_0, bool_1, bool_2, bool_3));
		PathGradientBrush pathGradientBrush2 = pathGradientBrush;
		pathGradientBrush2.CenterColor = color_0;
		pathGradientBrush2.SurroundColors = new Color[1] { color_1 };
		pathGradientBrush2.FocusScales = point_0;
		graphics_0.FillPath(pathGradientBrush, RoundRec(rectangle_0, int_0, bool_0, bool_1, bool_2, bool_3));
		pathGradientBrush2 = null;
	}

	public static void DrawRoundedPath(Graphics graphics_0, Color color_0, float float_0, Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		graphics_0.DrawPath(new Pen(color_0, float_0), RoundRec(rectangle_0, int_0, bool_0, bool_1, bool_2, bool_3));
	}

	public static void DrawTriangle(Graphics graphics_0, Color color_0, int int_0, Point point_0, Point point_1, Point point_2, Point point_3, Point point_4, Point point_5)
	{
		graphics_0.DrawLine(new Pen(color_0, int_0), point_0, point_1);
		graphics_0.DrawLine(new Pen(color_0, int_0), point_2, point_3);
		graphics_0.DrawLine(new Pen(color_0, int_0), point_4, point_5);
	}

	public static void FillStrokedRectangle(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, int int_0 = 1)
	{
		using SolidBrush brush = new SolidBrush(color_0);
		using Pen pen = new Pen(color_1, int_0);
		graphics_0.FillRectangle(brush, rectangle_0);
		graphics_0.DrawRectangle(pen, rectangle_0);
	}

	public static void FillRoundedStrokedRectangle(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, int int_0 = 1, int int_1 = 1, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		using SolidBrush brush_ = new SolidBrush(color_0);
		FillRoundedPath(graphics_0, brush_, rectangle_0, int_1, bool_0, bool_1, bool_2, bool_3);
		DrawRoundedPath(graphics_0, color_1, int_0, rectangle_0, int_1, bool_0, bool_1, bool_2, bool_3);
	}

	public static void DrawImageWithColor(Graphics graphics_0, Rectangle rectangle_0, Image image_0, Color color_0)
	{
		float[][] newColorMatrix = new float[5][]
		{
			new float[5]
			{
				Convert.ToSingle((double)(int)color_0.R / 255.0),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				Convert.ToSingle((double)(int)color_0.G / 255.0),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				Convert.ToSingle((double)(int)color_0.B / 255.0),
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				0f,
				Convert.ToSingle((double)(int)color_0.A / 255.0),
				0f
			},
			new float[5]
			{
				Convert.ToSingle((double)(int)color_0.R / 255.0),
				Convert.ToSingle((double)(int)color_0.G / 255.0),
				Convert.ToSingle((double)(int)color_0.B / 255.0),
				0f,
				Convert.ToSingle((double)(int)color_0.A / 255.0)
			}
		};
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(new ColorMatrix(newColorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Default);
		graphics_0.DrawImage(image_0, rectangle_0, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel, imageAttributes);
	}

	public static void DrawImageWithColor(Graphics graphics_0, Rectangle rectangle_0, string string_0, Color color_0)
	{
		Image image = ImageFromBase64(string_0);
		float[][] newColorMatrix = new float[5][]
		{
			new float[5]
			{
				Convert.ToSingle((double)(int)color_0.R / 255.0),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				Convert.ToSingle((double)(int)color_0.G / 255.0),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				Convert.ToSingle((double)(int)color_0.B / 255.0),
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				0f,
				Convert.ToSingle((double)(int)color_0.A / 255.0),
				0f
			},
			new float[5]
			{
				Convert.ToSingle((double)(int)color_0.R / 255.0),
				Convert.ToSingle((double)(int)color_0.G / 255.0),
				Convert.ToSingle((double)(int)color_0.B / 255.0),
				0f,
				Convert.ToSingle((double)(int)color_0.A / 255.0)
			}
		};
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(new ColorMatrix(newColorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Default);
		graphics_0.DrawImage(image, rectangle_0, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
	}

	public static Point[] Triangle(Point point_0, Point point_1, Point point_2)
	{
		return new Point[3] { point_0, point_1, point_2 };
	}

	public static PathGradientBrush GlowBrush(Color color_0, Color color_1, Point point_0, Rectangle rectangle_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.FillMode = FillMode.Winding;
		graphicsPath.AddRectangle(rectangle_0);
		PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
		pathGradientBrush.CenterColor = color_0;
		pathGradientBrush.SurroundColors = new Color[1] { color_1 };
		pathGradientBrush.FocusScales = point_0;
		return pathGradientBrush;
	}

	public static SolidBrush smethod_1(int int_0, int int_1, int int_2, int int_3 = 0)
	{
		return new SolidBrush(Color.FromArgb(int_3, int_0, int_1, int_2));
	}

	public static SolidBrush smethod_2(string string_0)
	{
		return new SolidBrush(GetHTMLColor(string_0));
	}

	public static Pen smethod_3(int int_0, int int_1, int int_2, int int_3, float float_0)
	{
		return new Pen(Color.FromArgb(int_3, int_0, int_1, int_2), float_0);
	}

	public static Pen PenHTMlColor(string string_0, float float_0 = 1f)
	{
		return new Pen(GetHTMLColor(string_0), float_0);
	}

	public static Color GetHTMLColor(string string_0)
	{
		return ColorTranslator.FromHtml("#" + string_0);
	}

	public static Color GetAlphaHTMLColor(int int_0, string string_0)
	{
		return Color.FromArgb(int_0, ColorTranslator.FromHtml("#" + string_0));
	}

	public static StringFormat SetPosition(StringAlignment stringAlignment_0 = StringAlignment.Center, StringAlignment stringAlignment_1 = StringAlignment.Center)
	{
		return new StringFormat
		{
			Alignment = stringAlignment_0,
			LineAlignment = stringAlignment_1
		};
	}

	public static float[][] ColorToMatrix(Color color_0)
	{
		return new float[5][]
		{
			new float[5]
			{
				Convert.ToSingle((double)(int)color_0.R / 255.0),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				Convert.ToSingle((double)(int)color_0.G / 255.0),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				Convert.ToSingle((double)(int)color_0.B / 255.0),
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				0f,
				Convert.ToSingle((double)(int)color_0.A / 255.0),
				0f
			},
			new float[5]
			{
				Convert.ToSingle((double)(int)color_0.R / 255.0),
				Convert.ToSingle((double)(int)color_0.G / 255.0),
				Convert.ToSingle((double)(int)color_0.B / 255.0),
				0f,
				Convert.ToSingle((double)(int)color_0.A / 255.0)
			}
		};
	}

	public static Image ImageFromBase64(string string_0)
	{
		using MemoryTributary stream = new MemoryTributary(Convert.FromBase64String(string_0));
		return Image.FromStream(stream);
	}

	public static GraphicsPath RoundRec(Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
		if (bool_0)
		{
			graphicsPath.AddArc(rectangle_0.X, rectangle_0.Y, int_0, int_0, 180f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.X, rectangle_0.Y, rectangle_0.X, rectangle_0.Y);
		}
		if (bool_1)
		{
			graphicsPath.AddArc(rectangle_0.Right - int_0, rectangle_0.Y, int_0, int_0, 270f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.Right - rectangle_0.Width, rectangle_0.Y, rectangle_0.Width, rectangle_0.Y);
		}
		if (bool_3)
		{
			graphicsPath.AddArc(rectangle_0.Right - int_0, rectangle_0.Bottom - int_0, int_0, int_0, 0f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Right, rectangle_0.Bottom);
		}
		if (bool_2)
		{
			graphicsPath.AddArc(rectangle_0.X, rectangle_0.Bottom - int_0, int_0, int_0, 90f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.X, rectangle_0.Bottom, rectangle_0.X, rectangle_0.Bottom);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
