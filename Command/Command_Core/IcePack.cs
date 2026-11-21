using System.Collections.Generic;

namespace Command_Core;

public sealed class IcePack : FixedGeoPolygon
{
	private List<Geopoint_Struct> _ExceptionDic;

	public override List<Geopoint_Struct> Area => _ExceptionDic;

	public IcePack(List<Geopoint_Struct> list_0)
	{
		_ExceptionDic = list_0;
	}
}
