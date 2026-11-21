using System;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public sealed class ShapePoint : Shape
{
	private PointD contextListener;

	public PointD Point => contextListener;

	protected internal ShapePoint(int int_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0, byte[] byte_0)
		: base(ShapeType.Point, int_0, stringDictionary_0, idataRecord_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("shapeData");
		}
		if (byte_0.Length != 28)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		contextListener = new PointD(EndianBitConverter.ToDouble(byte_0, 12, ProvidedOrder.Little), EndianBitConverter.ToDouble(byte_0, 20, ProvidedOrder.Little));
	}
}
