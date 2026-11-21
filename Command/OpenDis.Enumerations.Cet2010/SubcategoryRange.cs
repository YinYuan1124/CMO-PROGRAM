using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class SubcategoryRange : GenericEntryRange, INotifyPropertyChanged, IGenericEntry, IGenericEntryDescription, ISubcategoryOrSubcategoryRange
{
	private List<GenericEntryDescription> list_1;

	private ulong ulong_1;

	private string string_4;

	[XmlAttribute(AttributeName = "uid", DataType = "nonNegativeInteger")]
	public string RawUId
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
				ulong_1 = ulong.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawUId");
			}
		}
	}

	[XmlElement("specific_range", typeof(SpecificRange), Form = XmlSchemaForm.Unqualified)]
	[XmlElement("specific", typeof(Specific), Form = XmlSchemaForm.Unqualified)]
	public List<GenericEntryDescription> Specifices
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
				RaisePropertyChanged("Specifices");
			}
		}
	}

	[XmlIgnore]
	public ulong UId
	{
		get
		{
			return ulong_1;
		}
		set
		{
			if (ulong_1 != value)
			{
				ulong num = value;
				RawUId = num.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("UId");
			}
		}
	}
}
