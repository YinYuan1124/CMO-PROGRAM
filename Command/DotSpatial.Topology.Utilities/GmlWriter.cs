using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace DotSpatial.Topology.Utilities;

public class GmlWriter
{
	protected virtual NumberFormatInfo NumberFormatter => Global.GetNfi();

	public virtual XmlReader Write(IGeometry igeometry_0)
	{
		byte[] bytes = GetBytes(igeometry_0);
		using (Stream stream_ = new MemoryTributary(bytes))
		{
			Write(igeometry_0, stream_);
		}
		return new XmlTextReader(new MemoryTributary(bytes));
	}

	public virtual void Write(IGeometry igeometry_0, Stream stream_0)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream_0, null);
		xmlTextWriter.Formatting = Formatting.Indented;
		Write(igeometry_0, xmlTextWriter);
		xmlTextWriter.Close();
	}

	protected void Write(Coordinate coordinate_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("coord");
		xmlTextWriter_0.WriteElementString("X", coordinate_0.X.ToString("g", NumberFormatter));
		xmlTextWriter_0.WriteElementString("Y", coordinate_0.Y.ToString("g", NumberFormatter));
		xmlTextWriter_0.WriteEndElement();
	}

	protected void Write(IList<Coordinate> ilist_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteRaw("<coordinates>");
		foreach (Coordinate item in ilist_0)
		{
			xmlTextWriter_0.WriteRaw(item.X.ToString("g", NumberFormatter) + " ");
			xmlTextWriter_0.WriteRaw(item.Y.ToString("g", NumberFormatter) + " ");
		}
		xmlTextWriter_0.WriteRaw("</coordinates>");
	}

	protected virtual void Write(IGeometry igeometry_0, XmlTextWriter xmlTextWriter_0)
	{
		if (igeometry_0 is Point)
		{
			Write(igeometry_0 as Point, xmlTextWriter_0);
			return;
		}
		if (igeometry_0 is LineString)
		{
			Write(igeometry_0 as LineString, xmlTextWriter_0);
			return;
		}
		if (igeometry_0 is Polygon)
		{
			Write(igeometry_0 as Polygon, xmlTextWriter_0);
			return;
		}
		if (igeometry_0 is MultiPoint)
		{
			Write(igeometry_0 as MultiPoint, xmlTextWriter_0);
			return;
		}
		if (igeometry_0 is MultiLineString)
		{
			Write(igeometry_0 as MultiLineString, xmlTextWriter_0);
			return;
		}
		if (igeometry_0 is MultiPolygon)
		{
			Write(igeometry_0 as MultiPolygon, xmlTextWriter_0);
			return;
		}
		if (!(igeometry_0 is GeometryCollection))
		{
			throw new ArgumentException("Geometry not recognized: " + igeometry_0.ToString());
		}
		Write(igeometry_0 as GeometryCollection, xmlTextWriter_0);
	}

	protected virtual void Write(IPoint ipoint_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("Point");
		Write(ipoint_0.Coordinate, xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(LineString lineString_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("LineString");
		Write(lineString_0.Coordinates, xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(LinearRing linearRing_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("LinearRing");
		Write(linearRing_0.Coordinates, xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(Polygon polygon_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("Polygon");
		xmlTextWriter_0.WriteStartElement("outerBoundaryIs");
		Write(polygon_0.ExteriorRing as LinearRing, xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		for (int i = 0; i < polygon_0.NumHoles; i++)
		{
			xmlTextWriter_0.WriteStartElement("innerBoundaryIs");
			Write(polygon_0.Holes[i] as LinearRing, xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(MultiPoint multiPoint_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("MultiPoint");
		for (int i = 0; i < multiPoint_0.NumGeometries; i++)
		{
			xmlTextWriter_0.WriteStartElement("pointMember");
			Write(multiPoint_0.Geometries[i] as Point, xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(MultiLineString multiLineString_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("MultiLineString");
		for (int i = 0; i < multiLineString_0.NumGeometries; i++)
		{
			xmlTextWriter_0.WriteStartElement("lineStringMember");
			Write(multiLineString_0.Geometries[i] as LineString, xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(MultiPolygon multiPolygon_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("MultiPolygon");
		for (int i = 0; i < multiPolygon_0.NumGeometries; i++)
		{
			xmlTextWriter_0.WriteStartElement("polygonMember");
			Write(multiPolygon_0.Geometries[i] as Polygon, xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual void Write(GeometryCollection geometryCollection_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("MultiGeometry");
		for (int i = 0; i < geometryCollection_0.NumGeometries; i++)
		{
			xmlTextWriter_0.WriteStartElement("geometryMember");
			Write(geometryCollection_0.Geometries[i] as Geometry, xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	protected virtual byte[] GetBytes(IGeometry igeometry_0)
	{
		if (igeometry_0 is IPoint)
		{
			return new byte[SetByteStreamLength(igeometry_0 as Point)];
		}
		if (igeometry_0 is ILineString)
		{
			return new byte[SetByteStreamLength(igeometry_0 as LineString)];
		}
		if (igeometry_0 is IPolygon)
		{
			return new byte[SetByteStreamLength(igeometry_0 as Polygon)];
		}
		if (igeometry_0 is IMultiPoint)
		{
			return new byte[SetByteStreamLength(igeometry_0 as MultiPoint)];
		}
		if (igeometry_0 is IMultiLineString)
		{
			return new byte[SetByteStreamLength(igeometry_0 as MultiLineString)];
		}
		if (igeometry_0 is IMultiPolygon)
		{
			return new byte[SetByteStreamLength(igeometry_0 as MultiPolygon)];
		}
		if (!(igeometry_0 is GInterface3))
		{
			throw new ArgumentException("ShouldNeverReachHere");
		}
		return new byte[SetByteStreamLength(igeometry_0 as GeometryCollection)];
	}

	protected virtual int SetByteStreamLength(Geometry geometry_0)
	{
		if (geometry_0 is Point)
		{
			return SetByteStreamLength(geometry_0 as Point);
		}
		if (geometry_0 is LineString)
		{
			return SetByteStreamLength(geometry_0 as LineString);
		}
		if (geometry_0 is Polygon)
		{
			return SetByteStreamLength(geometry_0 as Polygon);
		}
		if (geometry_0 is MultiPoint)
		{
			return SetByteStreamLength(geometry_0 as MultiPoint);
		}
		if (geometry_0 is MultiLineString)
		{
			return SetByteStreamLength(geometry_0 as MultiLineString);
		}
		if (geometry_0 is MultiPolygon)
		{
			return SetByteStreamLength(geometry_0 as MultiPolygon);
		}
		if (!(geometry_0 is GeometryCollection))
		{
			throw new ArgumentException("ShouldNeverReachHere");
		}
		return SetByteStreamLength(geometry_0 as GeometryCollection);
	}

	protected virtual int SetByteStreamLength(GeometryCollection geometryCollection_0)
	{
		int num = 100;
		IGeometry[] geometries = geometryCollection_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Geometry byteStreamLength = (Geometry)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(MultiPolygon multiPolygon_0)
	{
		int num = 100;
		IGeometry[] geometries = multiPolygon_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Polygon byteStreamLength = (Polygon)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(MultiLineString multiLineString_0)
	{
		int num = 100;
		IGeometry[] geometries = multiLineString_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			LineString byteStreamLength = (LineString)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(MultiPoint multiPoint_0)
	{
		int num = 100;
		IGeometry[] geometries = multiPoint_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Point byteStreamLength = (Point)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(Polygon polygon_0)
	{
		return 100 + polygon_0.NumPoints * 100;
	}

	protected virtual int SetByteStreamLength(LineString lineString_0)
	{
		return 100 + lineString_0.NumPoints * 100;
	}

	protected virtual int SetByteStreamLength(Point point_0)
	{
		return 200;
	}
}
