using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[XmlRoot("cet", Namespace = "", IsNullable = false)]
[DebuggerStepThrough]
public class Cet : GenericTable
{
	private List<Entity> list_0;

	[XmlElement("entity", Form = XmlSchemaForm.Unqualified)]
	public List<Entity> Entities
	{
		get
		{
			return list_0;
		}
		set
		{
			if (list_0 != value)
			{
				list_0 = value;
				RaisePropertyChanged("Entities");
			}
		}
	}
}
