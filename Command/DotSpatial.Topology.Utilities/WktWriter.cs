using System.Globalization;
using System.IO;
using System.Text;

namespace DotSpatial.Topology.Utilities;

public class WktWriter
{
	private NumberFormatInfo consumerThread;

	private bool facadeThread;

	public static string ToPoint(Coordinate coordinate_0)
	{
		return "POINT ( " + coordinate_0.X + " " + coordinate_0.Y + " )";
	}

	public static string ToLineString(GInterface2 ginterface2_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("LINESTRING ");
		if (ginterface2_0.Count == 0)
		{
			stringBuilder.Append(" EMPTY");
		}
		else
		{
			stringBuilder.Append("(");
			for (int i = 0; i < ginterface2_0.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(ginterface2_0[i].X + " " + ginterface2_0[i].Y);
			}
			stringBuilder.Append(")");
		}
		return stringBuilder.ToString();
	}

	public static string ToLineString(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return "LINESTRING ( " + coordinate_0.X + " " + coordinate_0.Y + ", " + coordinate_1.X + " " + coordinate_1.Y + " )";
	}

	private static NumberFormatInfo ReadRule(PrecisionModel precisionModel_0)
	{
		int maximumSignificantDigits = precisionModel_0.MaximumSignificantDigits;
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
		numberFormatInfo.NumberDecimalSeparator = ".";
		numberFormatInfo.NumberDecimalDigits = maximumSignificantDigits;
		numberFormatInfo.NumberGroupSeparator = string.Empty;
		numberFormatInfo.NumberGroupSizes = new int[0];
		return numberFormatInfo;
	}

	public static string StringOfChar(char char_0, int int_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < int_0; i++)
		{
			stringBuilder.Append(char_0);
		}
		return stringBuilder.ToString();
	}

	public virtual string Write(Geometry geometry_0)
	{
		TextWriter textWriter = new StringWriter();
		DisableRule(geometry_0, bool_0: false, textWriter);
		return textWriter.ToString();
	}

	public virtual void Write(Geometry geometry_0, TextWriter textWriter_0)
	{
		DisableRule(geometry_0, bool_0: false, textWriter_0);
	}

	public virtual string WriteFormatted(Geometry geometry_0)
	{
		TextWriter textWriter = new StringWriter();
		DisableRule(geometry_0, bool_0: true, textWriter);
		return textWriter.ToString();
	}

	public virtual void WriteFormatted(Geometry geometry_0, TextWriter textWriter_0)
	{
		DisableRule(geometry_0, bool_0: true, textWriter_0);
	}

	private void DisableRule(IGeometry igeometry_0, bool bool_0, TextWriter textWriter_0)
	{
		facadeThread = bool_0;
		consumerThread = ReadRule(new PrecisionModel(igeometry_0.PrecisionModel));
		UpdateRule(igeometry_0, 0, textWriter_0);
	}

	private void UpdateRule(IGeometry igeometry_0, int int_0, TextWriter textWriter_0)
	{
		PublishRule(int_0, textWriter_0);
		if (igeometry_0 is Point)
		{
			Point point = (Point)igeometry_0;
			InsertRule(point.Coordinate, textWriter_0);
			return;
		}
		if (igeometry_0 is ILinearRing)
		{
			ReflectRule((ILinearRing)igeometry_0, int_0, textWriter_0);
			return;
		}
		if (igeometry_0 is ILineString)
		{
			PrepareRule((ILineString)igeometry_0, int_0, textWriter_0);
			return;
		}
		if (igeometry_0 is IPolygon)
		{
			VisitRule((IPolygon)igeometry_0, int_0, textWriter_0);
			return;
		}
		if (igeometry_0 is IMultiPoint)
		{
			RestartRule((IMultiPoint)igeometry_0, textWriter_0);
			return;
		}
		if (igeometry_0 is IMultiLineString)
		{
			TestRule((IMultiLineString)igeometry_0, int_0, textWriter_0);
			return;
		}
		if (igeometry_0 is IMultiPolygon)
		{
			StopRule((IMultiPolygon)igeometry_0, int_0, textWriter_0);
			return;
		}
		if (!(igeometry_0 is GInterface3))
		{
			throw new UnsupportedGeometryException();
		}
		CancelRule((GInterface3)igeometry_0, int_0, textWriter_0);
	}

	private void InsertRule(Coordinate coordinate_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("POINT ");
		VerifyRule(coordinate_0, textWriter_0);
	}

	private void PrepareRule(IBasicLineString ibasicLineString_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("LINESTRING ");
		PostRule(ibasicLineString_0, int_0, bool_0: false, textWriter_0);
	}

	private void ReflectRule(ILinearRing ilinearRing_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("LINEARRING ");
		PostRule(ilinearRing_0, int_0, bool_0: false, textWriter_0);
	}

	private void VisitRule(IPolygon ipolygon_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("POLYGON ");
		RunRule(ipolygon_0, int_0, bool_0: false, textWriter_0);
	}

	private void RestartRule(IMultiPoint imultiPoint_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("MULTIPOINT ");
		StartRule(imultiPoint_0, textWriter_0);
	}

	private void TestRule(IMultiLineString imultiLineString_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("MULTILINESTRING ");
		AssetRule(imultiLineString_0, int_0, bool_0: false, textWriter_0);
	}

	private void StopRule(IMultiPolygon imultiPolygon_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("MULTIPOLYGON ");
		PrintRule(imultiPolygon_0, int_0, textWriter_0);
	}

	private void CancelRule(GInterface3 ginterface3_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("GEOMETRYCOLLECTION ");
		DefineRule(ginterface3_0, int_0, textWriter_0);
	}

	private void VerifyRule(Coordinate coordinate_0, TextWriter textWriter_0)
	{
		if (coordinate_0 == null)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		textWriter_0.Write("(");
		ListRule(coordinate_0, textWriter_0);
		textWriter_0.Write(")");
	}

	private void ListRule(Coordinate coordinate_0, TextWriter textWriter_0)
	{
		textWriter_0.Write(ResolveRule(coordinate_0.X) + " " + ResolveRule(coordinate_0.Y));
	}

	private string ResolveRule(double double_0)
	{
		return double_0.ToString("N", consumerThread);
	}

	private void PostRule(IBasicLineString ibasicLineString_0, int int_0, bool bool_0, TextWriter textWriter_0)
	{
		if (ibasicLineString_0.Coordinates.Count == 0)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		if (bool_0)
		{
			PublishRule(int_0, textWriter_0);
		}
		textWriter_0.Write("(");
		for (int i = 0; i < ibasicLineString_0.NumPoints; i++)
		{
			if (i > 0)
			{
				textWriter_0.Write(", ");
				if (i % 10 == 0)
				{
					PublishRule(int_0 + 2, textWriter_0);
				}
			}
			ListRule(ibasicLineString_0.Coordinates[i], textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void RunRule(IPolygon ipolygon_0, int int_0, bool bool_0, TextWriter textWriter_0)
	{
		if (ipolygon_0.IsEmpty)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		if (bool_0)
		{
			PublishRule(int_0, textWriter_0);
		}
		textWriter_0.Write("(");
		PostRule(ipolygon_0.Shell, int_0, bool_0: false, textWriter_0);
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			textWriter_0.Write(", ");
			PostRule(ipolygon_0.GetInteriorRingN(i), int_0 + 1, bool_0: true, textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void StartRule(IGeometry igeometry_0, TextWriter textWriter_0)
	{
		if (igeometry_0.IsEmpty)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		textWriter_0.Write("(");
		for (int i = 0; i < igeometry_0.NumGeometries; i++)
		{
			if (i > 0)
			{
				textWriter_0.Write(", ");
			}
			ListRule(((Point)igeometry_0.GetGeometryN(i)).Coordinate, textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void AssetRule(IMultiLineString imultiLineString_0, int int_0, bool bool_0, TextWriter textWriter_0)
	{
		if (imultiLineString_0.IsEmpty)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		int int_ = int_0;
		bool bool_ = bool_0;
		textWriter_0.Write("(");
		for (int i = 0; i < imultiLineString_0.NumGeometries; i++)
		{
			if (i > 0)
			{
				textWriter_0.Write(", ");
				int_ = int_0 + 1;
				bool_ = true;
			}
			PostRule((LineString)imultiLineString_0.GetGeometryN(i), int_, bool_, textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void PrintRule(IMultiPolygon imultiPolygon_0, int int_0, TextWriter textWriter_0)
	{
		if (imultiPolygon_0.IsEmpty)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		int int_ = int_0;
		bool bool_ = false;
		textWriter_0.Write("(");
		for (int i = 0; i < imultiPolygon_0.NumGeometries; i++)
		{
			if (i > 0)
			{
				textWriter_0.Write(", ");
				int_ = int_0 + 1;
				bool_ = true;
			}
			RunRule((Polygon)imultiPolygon_0.GetGeometryN(i), int_, bool_, textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void DefineRule(GInterface3 ginterface3_0, int int_0, TextWriter textWriter_0)
	{
		if (ginterface3_0.IsEmpty)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		int int_ = int_0;
		textWriter_0.Write("(");
		for (int i = 0; i < ginterface3_0.NumGeometries; i++)
		{
			if (i > 0)
			{
				textWriter_0.Write(", ");
				int_ = int_0 + 1;
			}
			UpdateRule(ginterface3_0.GetGeometryN(i), int_, textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void PublishRule(int int_0, TextWriter textWriter_0)
	{
		if (facadeThread && int_0 > 0)
		{
			textWriter_0.Write("\n");
			textWriter_0.Write(StringOfChar(' ', 2 * int_0));
		}
	}
}
