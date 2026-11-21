using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
[XmlRoot("cet", IsNullable = false)]
public class Cet : GenericTable
{
	private List<Entity> list_1;

	[XmlElement("entity", Form = XmlSchemaForm.Unqualified)]
	public List<Entity> Entities
	{
		get
		{
			return list_1;
		}
		set
		{
			if (list_1 != value)
			{
				list_1 = value;
				RaisePropertyChanged("Entities");
			}
		}
	}
}
