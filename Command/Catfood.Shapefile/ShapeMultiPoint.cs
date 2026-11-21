using System;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public sealed class ShapeMultiPoint : Shape
{
	private RectangleD codeListener;

	private PointD[] _ConnectionListener;

	public RectangleD BoundingBox => codeListener;

	public PointD[] Points => _ConnectionListener;

	protected internal ShapeMultiPoint(int int_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0, byte[] byte_0)
		: base(ShapeType.MultiPoint, int_0, stringDictionary_0, idataRecord_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("shapeData");
		}
		if (byte_0.Length < 48)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		codeListener = ParseBoundingBox(byte_0, 12, ProvidedOrder.Little);
		int num = EndianBitConverter.ToInt32(byte_0, 44, ProvidedOrder.Little);
		if (byte_0.Length == 48 + 16 * num)
		{
			_ConnectionListener = new PointD[num];
			for (int i = 0; i < num; i++)
			{
				_ConnectionListener[i] = new PointD(EndianBitConverter.ToDouble(byte_0, 48 + 16 * i, ProvidedOrder.Little), EndianBitConverter.ToDouble(byte_0, 56 + 16 * i, ProvidedOrder.Little));
			}
			return;
		}
		throw new InvalidOperationException("Invalid shape data");
	}
}
