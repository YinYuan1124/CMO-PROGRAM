using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public sealed class ShapePolygon : Shape
{
	private RectangleD statusListener;

	private List<PointD[]> _ProccesorListener;

	public RectangleD BoundingBox => statusListener;

	public List<PointD[]> Parts => _ProccesorListener;

	protected internal ShapePolygon(int int_0, StringDictionary stringDictionary_0, IDataRecord idataRecord_0, byte[] byte_0)
		: base(ShapeType.Polygon, int_0, stringDictionary_0, idataRecord_0)
	{
		ParsePolyLineOrPolygon(byte_0, out statusListener, out _ProccesorListener);
	}
}
