using System;
using System.IO;

namespace DotSpatial.Topology.Utilities;

public class WkbWriter
{
	protected const int INIT_COUNT = 5;

	private readonly ByteOrder m_DicThread;

	public WkbWriter()
		: this(ByteOrder.LittleEndian)
	{
	}

	public WkbWriter(ByteOrder byteOrder_0)
	{
		m_DicThread = byteOrder_0;
	}

	public virtual byte[] Write(IGeometry igeometry_0)
	{
		byte[] bytes = GetBytes(igeometry_0);
		Write(igeometry_0, new MemoryTributary(bytes));
		return bytes;
	}

	public virtual void Write(IGeometry igeometry_0, Stream stream_0)
	{
		BinaryWriter binaryWriter = null;
		try
		{
			binaryWriter = ((m_DicThread == ByteOrder.LittleEndian) ? new BinaryWriter(stream_0) : new BeBinaryWriter(stream_0));
			Write(igeometry_0, binaryWriter);
		}
		finally
		{
			binaryWriter?.Close();
		}
	}

	protected virtual void Write(IGeometry igeometry_0, BinaryWriter binaryWriter_0)
	{
		if (igeometry_0 is IPoint)
		{
			Write(igeometry_0 as IPoint, binaryWriter_0);
			return;
		}
		if (igeometry_0 is ILineString)
		{
			Write(igeometry_0 as ILineString, binaryWriter_0);
			return;
		}
		if (igeometry_0 is IPolygon)
		{
			Write(igeometry_0 as IPolygon, binaryWriter_0);
			return;
		}
		if (igeometry_0 is IMultiPoint)
		{
			Write(igeometry_0 as IMultiPoint, binaryWriter_0);
			return;
		}
		if (igeometry_0 is IMultiLineString)
		{
			Write(igeometry_0 as IMultiLineString, binaryWriter_0);
			return;
		}
		if (igeometry_0 is IMultiPolygon)
		{
			Write(igeometry_0 as IMultiPolygon, binaryWriter_0);
			return;
		}
		if (!(igeometry_0 is GInterface3))
		{
			throw new ArgumentException("Geometry not recognized: " + igeometry_0.ToString());
		}
		Write(igeometry_0 as GInterface3, binaryWriter_0);
	}

	protected virtual void WriteByteOrder(BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write((byte)m_DicThread);
	}

	protected virtual void Write(IPoint ipoint_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(1);
		Write(ipoint_0.Coordinate, binaryWriter_0);
	}

	protected virtual void Write(ILineString ilineString_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(2);
		binaryWriter_0.Write(ilineString_0.NumPoints);
		for (int i = 0; i < ilineString_0.Coordinates.Count; i++)
		{
			Write(ilineString_0.Coordinates[i], binaryWriter_0);
		}
	}

	protected virtual void Write(IPolygon ipolygon_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(3);
		binaryWriter_0.Write(ipolygon_0.NumHoles + 1);
		Write(ipolygon_0.Shell, binaryWriter_0);
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			Write(ipolygon_0.Holes[i], binaryWriter_0);
		}
	}

	protected virtual void Write(IMultiPoint imultiPoint_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(4);
		binaryWriter_0.Write(imultiPoint_0.NumGeometries);
		for (int i = 0; i < imultiPoint_0.NumGeometries; i++)
		{
			Write(imultiPoint_0.Geometries[i] as Point, binaryWriter_0);
		}
	}

	protected virtual void Write(IMultiLineString imultiLineString_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(5);
		binaryWriter_0.Write(imultiLineString_0.NumGeometries);
		for (int i = 0; i < imultiLineString_0.NumGeometries; i++)
		{
			Write(imultiLineString_0.Geometries[i] as LineString, binaryWriter_0);
		}
	}

	protected virtual void Write(IMultiPolygon imultiPolygon_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(6);
		binaryWriter_0.Write(imultiPolygon_0.NumGeometries);
		for (int i = 0; i < imultiPolygon_0.NumGeometries; i++)
		{
			Write(imultiPolygon_0.Geometries[i] as Polygon, binaryWriter_0);
		}
	}

	protected virtual void Write(GInterface3 ginterface3_0, BinaryWriter binaryWriter_0)
	{
		WriteByteOrder(binaryWriter_0);
		binaryWriter_0.Write(7);
		binaryWriter_0.Write(ginterface3_0.NumGeometries);
		for (int i = 0; i < ginterface3_0.NumGeometries; i++)
		{
			Write(ginterface3_0.Geometries[i], binaryWriter_0);
		}
	}

	protected virtual void Write(Coordinate coordinate_0, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(coordinate_0.X);
		binaryWriter_0.Write(coordinate_0.Y);
	}

	protected virtual void Write(ILinearRing ilinearRing_0, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(ilinearRing_0.NumPoints);
		for (int i = 0; i < ilinearRing_0.Coordinates.Count; i++)
		{
			Write(ilinearRing_0.Coordinates[i], binaryWriter_0);
		}
	}

	protected virtual byte[] GetBytes(IGeometry igeometry_0)
	{
		if (igeometry_0 is IPoint)
		{
			return new byte[SetByteStream(igeometry_0 as IPoint)];
		}
		if (igeometry_0 is ILineString)
		{
			return new byte[SetByteStream(igeometry_0 as ILineString)];
		}
		if (igeometry_0 is IPolygon)
		{
			return new byte[SetByteStream(igeometry_0 as IPolygon)];
		}
		if (igeometry_0 is IMultiPoint)
		{
			return new byte[SetByteStream(igeometry_0 as IMultiPoint)];
		}
		if (igeometry_0 is IMultiLineString)
		{
			return new byte[SetByteStream(igeometry_0 as IMultiLineString)];
		}
		if (igeometry_0 is IMultiPolygon)
		{
			return new byte[SetByteStream(igeometry_0 as IMultiPolygon)];
		}
		if (!(igeometry_0 is GInterface3))
		{
			throw new ArgumentException("ShouldNeverReachHere");
		}
		return new byte[SetByteStream(igeometry_0 as GInterface3)];
	}

	protected virtual int SetByteStream(IGeometry igeometry_0)
	{
		if (igeometry_0 is Point)
		{
			return SetByteStream(igeometry_0 as Point);
		}
		if (igeometry_0 is LineString)
		{
			return SetByteStream(igeometry_0 as LineString);
		}
		if (igeometry_0 is Polygon)
		{
			return SetByteStream(igeometry_0 as Polygon);
		}
		if (igeometry_0 is MultiPoint)
		{
			return SetByteStream(igeometry_0 as MultiPoint);
		}
		if (igeometry_0 is MultiLineString)
		{
			return SetByteStream(igeometry_0 as MultiLineString);
		}
		if (igeometry_0 is MultiPolygon)
		{
			return SetByteStream(igeometry_0 as MultiPolygon);
		}
		if (!(igeometry_0 is GeometryCollection))
		{
			throw new ArgumentException("ShouldNeverReachHere");
		}
		return SetByteStream(igeometry_0 as GeometryCollection);
	}

	protected virtual int SetByteStream(GInterface3 ginterface3_0)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = ginterface3_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Geometry byteStream = (Geometry)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IMultiPolygon imultiPolygon_0)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = imultiPolygon_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Polygon byteStream = (Polygon)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IMultiLineString imultiLineString_0)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = imultiLineString_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			LineString byteStream = (LineString)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IMultiPoint imultiPoint_0)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = imultiPoint_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Point byteStream = (Point)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IPolygon ipolygon_0)
	{
		return 13 + 4 * (ipolygon_0.NumHoles + 1) + ipolygon_0.NumPoints * 16;
	}

	protected virtual int SetByteStream(ILineString ilineString_0)
	{
		int numPoints = ilineString_0.NumPoints;
		return 9 + 16 * numPoints;
	}

	protected virtual int SetByteStream(IPoint ipoint_0)
	{
		return 21;
	}
}
