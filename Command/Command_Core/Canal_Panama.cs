using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Canal_Panama : FixedGeoPolygon
{
	private List<Geopoint_Struct> m_RecordObserver;

	public override List<Geopoint_Struct> Area
	{
		get
		{
			if (Information.IsNothing(m_RecordObserver))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				list.Add(new Geopoint_Struct(-79.9, 9.45));
				list.Add(new Geopoint_Struct(-79.95, 9.4));
				list.Add(new Geopoint_Struct(-79.95, 9.4));
				list.Add(new Geopoint_Struct(-79.95, 9.35));
				list.Add(new Geopoint_Struct(-79.95, 9.3));
				list.Add(new Geopoint_Struct(-79.95, 9.25));
				list.Add(new Geopoint_Struct(-79.9, 9.2));
				list.Add(new Geopoint_Struct(-79.85, 9.15));
				list.Add(new Geopoint_Struct(-79.8, 9.1));
				list.Add(new Geopoint_Struct(-79.75, 9.05));
				list.Add(new Geopoint_Struct(-79.7, 9.0));
				list.Add(new Geopoint_Struct(-79.65, 8.95));
				list.Add(new Geopoint_Struct(-79.6, 8.9));
				list.Add(new Geopoint_Struct(-79.55, 8.85));
				list.Add(new Geopoint_Struct(-79.48, 8.92));
				list.Add(new Geopoint_Struct(-79.55, 9.0));
				list.Add(new Geopoint_Struct(-79.6, 9.05));
				list.Add(new Geopoint_Struct(-79.65, 9.1));
				list.Add(new Geopoint_Struct(-79.7, 9.15));
				list.Add(new Geopoint_Struct(-79.75, 9.2));
				list.Add(new Geopoint_Struct(-79.8, 9.25));
				list.Add(new Geopoint_Struct(-79.85, 9.3));
				list.Add(new Geopoint_Struct(-79.85, 9.35));
				list.Add(new Geopoint_Struct(-79.85, 9.4));
				m_RecordObserver = list;
			}
			return m_RecordObserver;
		}
	}
}
