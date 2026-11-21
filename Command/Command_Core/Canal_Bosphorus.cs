using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Canal_Bosphorus : FixedGeoPolygon
{
	private List<Geopoint_Struct> predicateObserver;

	public override List<Geopoint_Struct> Area
	{
		get
		{
			if (Information.IsNothing(predicateObserver))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				list.Add(new Geopoint_Struct(29.08, 41.25));
				list.Add(new Geopoint_Struct(29.25, 41.25));
				list.Add(new Geopoint_Struct(29.16, 41.16));
				list.Add(new Geopoint_Struct(29.16, 41.08));
				list.Add(new Geopoint_Struct(29.0, 40.91));
				list.Add(new Geopoint_Struct(29.0, 40.91));
				list.Add(new Geopoint_Struct(28.91, 41.0));
				list.Add(new Geopoint_Struct(29.0, 41.08));
				list.Add(new Geopoint_Struct(29.0, 41.16));
				predicateObserver = list;
			}
			return predicateObserver;
		}
	}
}
