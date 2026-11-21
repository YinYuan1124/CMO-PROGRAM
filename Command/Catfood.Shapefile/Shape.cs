using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public class Shape
{
	internal ShapeType _ValueListener;

	private int tokenizerListener;

	private StringDictionary _StubListener;

	private IDataRecord writerListener;

	public IDataRecord DataRecord => writerListener;

	public int RecordNumber => tokenizerListener;

	public ShapeType Type => _ValueListener;

	protected internal Shape(ShapeType shapeType_0, int int_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0)
	{
		_ValueListener = shapeType_0;
		_StubListener = stringDictionary_0;
		tokenizerListener = int_0;
		writerListener = idataRecord_0;
	}

	public string GetMetadata(string string_0)
	{
		if (_StubListener != null && _StubListener.ContainsKey(string_0))
		{
			return _StubListener[string_0];
		}
		return null;
	}

	public string[] GetMetadataNames()
	{
		if (_StubListener != null && _StubListener.Keys.Count > 0)
		{
			List<string> list = new List<string>(_StubListener.Keys.Count);
			foreach (string key in _StubListener.Keys)
			{
				list.Add(key);
			}
			return list.ToArray();
		}
		return null;
	}

	protected RectangleD ParseBoundingBox(byte[] byte_0, int int_0, ProvidedOrder providedOrder_0)
	{
		return new RectangleD(EndianBitConverter.ToDouble(byte_0, int_0, providedOrder_0), EndianBitConverter.ToDouble(byte_0, int_0 + 8, providedOrder_0), EndianBitConverter.ToDouble(byte_0, int_0 + 16, providedOrder_0), EndianBitConverter.ToDouble(byte_0, int_0 + 24, providedOrder_0));
	}

	protected void ParsePolyLineOrPolygon(byte[] byte_0, out RectangleD rectangleD_0, out List<PointD[]> list_0)
	{
		rectangleD_0 = default(RectangleD);
		list_0 = null;
		if (byte_0 == null)
		{
			throw new ArgumentNullException("shapeData");
		}
		if (byte_0.Length < 44)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		rectangleD_0 = ParseBoundingBox(byte_0, 12, ProvidedOrder.Little);
		int num = EndianBitConverter.ToInt32(byte_0, 44, ProvidedOrder.Little);
		int num2 = EndianBitConverter.ToInt32(byte_0, 48, ProvidedOrder.Little);
		if (byte_0.Length == 52 + 4 * num + 16 * num2)
		{
			int num3 = 52 + 4 * num;
			list_0 = new List<PointD[]>(num);
			for (int i = 0; i < num; i++)
			{
				int num4 = EndianBitConverter.ToInt32(byte_0, 52 + 4 * i, ProvidedOrder.Little) * 16 + num3;
				int num5 = ((i == num - 1) ? (byte_0.Length - num4) : (EndianBitConverter.ToInt32(byte_0, 52 + 4 * (i + 1), ProvidedOrder.Little) * 16 + num3 - num4)) / 16;
				PointD[] array = new PointD[num5];
				for (int j = 0; j < num5; j++)
				{
					array[j] = new PointD(EndianBitConverter.ToDouble(byte_0, num4 + 16 * j, ProvidedOrder.Little), EndianBitConverter.ToDouble(byte_0, num4 + 8 + 16 * j, ProvidedOrder.Little));
				}
				list_0.Add(array);
			}
			return;
		}
		throw new InvalidOperationException("Invalid shape data");
	}
}
