using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[XmlInclude(typeof(Subcategory))]
[XmlInclude(typeof(Specific))]
[XmlInclude(typeof(Category))]
[XmlInclude(typeof(Extra))]
[DebuggerStepThrough]
public class GenericEntrySingle : GenericEntryDescription
{
	private int xLyEwlZnfdX;

	[XmlAttribute(AttributeName = "value")]
	public int Value
	{
		get
		{
			return xLyEwlZnfdX;
		}
		set
		{
			if (xLyEwlZnfdX != value)
			{
				xLyEwlZnfdX = value;
				RaisePropertyChanged("Value");
			}
		}
	}
}
