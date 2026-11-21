using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public class ShapePolyLine : Shape
{
	internal RectangleD _StrategyListener;

	internal List<PointD[]> m_ConfigurationListener;

	public RectangleD BoundingBox => _StrategyListener;

	public List<PointD[]> Parts => m_ConfigurationListener;

	protected internal ShapePolyLine(int int_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0)
		: base(ShapeType.PolyLine, int_0, stringDictionary_0, idataRecord_0)
	{
	}

	protected internal ShapePolyLine(int int_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0, byte[] byte_0)
		: base(ShapeType.PolyLine, int_0, stringDictionary_0, idataRecord_0)
	{
		ParsePolyLineOrPolygon(byte_0, out _StrategyListener, out m_ConfigurationListener);
	}
}
