using System.Xml.Serialization;

namespace WorldWind;

public class PlaceListSettings
{
	public class MetaDataEntry
	{
		[XmlAttribute]
		public string name;

		[XmlAttribute]
		public string value;
	}

	public class PlaceData
	{
		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public float Lat;

		[XmlAttribute]
		public float Lon;

		public MetaDataEntry[] metadata;
	}

	public PlaceData[] places;
}
