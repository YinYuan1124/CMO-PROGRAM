using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class GenericEntryString : GenericEntryDescription
{
	private string string_4;

	[XmlAttribute(AttributeName = "value")]
	public string Value
	{
		get
		{
			return string_4;
		}
		set
		{
			if (string_4 != value)
			{
				string_4 = value;
				RaisePropertyChanged("Value");
			}
		}
	}
}
