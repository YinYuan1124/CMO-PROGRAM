using System;
using System.Collections.Specialized;
using System.Data;
using Catfood.Shapefile;

namespace Command.Filters;

internal static class SpecificationListener
{
	public static Shape DestroyObserver(byte[] byte_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0)
	{
		if (byte_0 != null)
		{
			if (byte_0.Length < 12)
			{
				throw new ArgumentException("shapeData must be at least 12 bytes long");
			}
			int int_ = EndianBitConverter.ToInt32(byte_0, 0, ProvidedOrder.Big);
			int num = EndianBitConverter.ToInt32(byte_0, 4, ProvidedOrder.Big);
			ShapeType shapeType = (ShapeType)EndianBitConverter.ToInt32(byte_0, 8, ProvidedOrder.Little);
			if (byte_0.Length == num * 2 + 8)
			{
				if (1 == 0)
				{
				}
				Shape result = shapeType switch
				{
					ShapeType.PolyLineM => new ShapePolyLineM(int_, stringDictionary_0, idataRecord_0, byte_0), 
					ShapeType.Null => new Shape(shapeType, int_, stringDictionary_0, idataRecord_0), 
					ShapeType.Point => new ShapePoint(int_, stringDictionary_0, idataRecord_0, byte_0), 
					ShapeType.PolyLine => new ShapePolyLine(int_, stringDictionary_0, idataRecord_0, byte_0), 
					ShapeType.Polygon => new ShapePolygon(int_, stringDictionary_0, idataRecord_0, byte_0), 
					ShapeType.MultiPoint => new ShapeMultiPoint(int_, stringDictionary_0, idataRecord_0, byte_0), 
					_ => throw new NotImplementedException($"Shapetype {shapeType} is not implemented"), 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			throw new InvalidOperationException("Shape data length does not match shape header length");
		}
		throw new ArgumentNullException("shapeData");
	}
}
