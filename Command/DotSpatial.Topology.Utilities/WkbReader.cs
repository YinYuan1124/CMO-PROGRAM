using System;
using System.IO;

namespace DotSpatial.Topology.Utilities;

public class WkbReader
{
	private IGeometryFactory m_ClientThread;

	protected virtual IGeometryFactory Factory => m_ClientThread;

	public WkbReader()
		: this(new GeometryFactory())
	{
	}

	public WkbReader(IGeometryFactory igeometryFactory_0)
	{
		m_ClientThread = igeometryFactory_0;
	}

	public virtual IGeometry Read(byte[] byte_0)
	{
		using Stream stream_ = new MemoryTributary(byte_0);
		return Read(stream_);
	}

	public virtual IGeometry Read(Stream stream_0)
	{
		BinaryReader binaryReader = null;
		ByteOrder byteOrder = (ByteOrder)stream_0.ReadByte();
		try
		{
			binaryReader = ((byteOrder == ByteOrder.BigEndian) ? new BeBinaryReader(stream_0) : new BinaryReader(stream_0));
			return Read(binaryReader);
		}
		finally
		{
			binaryReader?.Close();
		}
	}

	protected virtual IGeometry Read(BinaryReader binaryReader_0)
	{
		WkbGeometryType wkbGeometryType = (WkbGeometryType)binaryReader_0.ReadInt32();
		if (1 == 0)
		{
		}
		IGeometry result = wkbGeometryType switch
		{
			WkbGeometryType.Point => ReadPoint(binaryReader_0), 
			WkbGeometryType.LineString => ReadLineString(binaryReader_0), 
			WkbGeometryType.Polygon => ReadPolygon(binaryReader_0), 
			WkbGeometryType.MultiPoint => ReadMultiPoint(binaryReader_0), 
			WkbGeometryType.MultiLineString => ReadMultiLineString(binaryReader_0), 
			WkbGeometryType.MultiPolygon => ReadMultiPolygon(binaryReader_0), 
			WkbGeometryType.GeometryCollection => ReadGeometryCollection(binaryReader_0), 
			_ => throw new ArgumentException("Geometry type not recognized. GeometryCode: " + wkbGeometryType), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	protected virtual ByteOrder ReadByteOrder(BinaryReader binaryReader_0)
	{
		return (ByteOrder)binaryReader_0.ReadByte();
	}

	protected virtual Coordinate ReadCoordinate(BinaryReader binaryReader_0)
	{
		return new Coordinate(binaryReader_0.ReadDouble(), binaryReader_0.ReadDouble());
	}

	protected virtual ILinearRing ReadRing(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		Coordinate[] array = new Coordinate[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = ReadCoordinate(binaryReader_0);
		}
		return Factory.CreateLinearRing(array);
	}

	protected virtual IGeometry ReadPoint(BinaryReader binaryReader_0)
	{
		return Factory.CreatePoint(ReadCoordinate(binaryReader_0));
	}

	protected virtual IGeometry ReadLineString(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		Coordinate[] array = new Coordinate[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = ReadCoordinate(binaryReader_0);
		}
		return Factory.CreateLineString(array);
	}

	protected virtual IGeometry ReadPolygon(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		ILinearRing ilinearRing_ = ReadRing(binaryReader_0);
		ILinearRing[] array3 = new LinearRing[num - 1];
		ILinearRing[] array = array3;
		ILinearRing[] array2 = array;
		for (int i = 0; i < num - 1; i++)
		{
			array2[i] = ReadRing(binaryReader_0);
		}
		return Factory.CreatePolygon(ilinearRing_, array2);
	}

	protected virtual IGeometry ReadMultiPoint(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		Point[] array = new Point[num];
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(binaryReader_0);
			if (binaryReader_0.ReadInt32() == 1)
			{
				array[i] = ReadPoint(binaryReader_0) as Point;
				continue;
			}
			throw new ArgumentException("Point feature expected");
		}
		return Factory.CreateMultiPoint(array);
	}

	protected virtual IGeometry ReadMultiLineString(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		LineString[] array = new LineString[num];
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(binaryReader_0);
			if (binaryReader_0.ReadInt32() == 2)
			{
				array[i] = ReadLineString(binaryReader_0) as LineString;
				continue;
			}
			throw new ArgumentException("LineString feature expected");
		}
		IGeometryFactory factory = Factory;
		IBasicLineString[] array3 = array;
		IBasicLineString[] array2 = array3;
		IBasicLineString[] ibasicLineString_ = array2;
		return factory.CreateMultiLineString(ibasicLineString_);
	}

	protected virtual IGeometry ReadMultiPolygon(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		Polygon[] array = new Polygon[num];
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(binaryReader_0);
			if (binaryReader_0.ReadInt32() == 3)
			{
				array[i] = ReadPolygon(binaryReader_0) as Polygon;
				continue;
			}
			throw new ArgumentException("Polygon feature expected");
		}
		IGeometryFactory factory = Factory;
		IPolygon[] array3 = array;
		IPolygon[] array2 = array3;
		IPolygon[] ipolygon_ = array2;
		return factory.CreateMultiPolygon(ipolygon_);
	}

	protected virtual IGeometry ReadGeometryCollection(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		IGeometry[] array3 = new Geometry[num];
		IGeometry[] array = array3;
		IGeometry[] array2 = array;
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(binaryReader_0);
			switch (binaryReader_0.ReadInt32())
			{
			case 1:
				array2[i] = ReadPoint(binaryReader_0);
				break;
			case 2:
				array2[i] = ReadLineString(binaryReader_0);
				break;
			case 3:
				array2[i] = ReadPolygon(binaryReader_0);
				break;
			case 4:
				array2[i] = ReadMultiPoint(binaryReader_0);
				break;
			case 5:
				array2[i] = ReadMultiLineString(binaryReader_0);
				break;
			case 6:
				array2[i] = ReadMultiPolygon(binaryReader_0);
				break;
			case 7:
				array2[i] = ReadGeometryCollection(binaryReader_0);
				break;
			default:
				throw new ArgumentException("Should never reach here!");
			}
		}
		return Factory.CreateGeometryCollection(array2);
	}
}
