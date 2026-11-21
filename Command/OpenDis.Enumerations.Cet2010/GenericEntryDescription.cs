using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[XmlInclude(typeof(SpecificRange))]
[XmlInclude(typeof(CategoryRange))]
[XmlInclude(typeof(Subcategory))]
[XmlInclude(typeof(GenericEntryString))]
[XmlInclude(typeof(GenericEntrySingle))]
[XmlInclude(typeof(GenericEntryRange))]
[DebuggerStepThrough]
[XmlInclude(typeof(SubcategoryRange))]
[XmlInclude(typeof(Extra))]
[XmlInclude(typeof(Specific))]
[XmlInclude(typeof(Category))]
[XmlInclude(typeof(ExtraRange))]
public abstract class GenericEntryDescription : GenericEntry, INotifyPropertyChanged, IGenericEntry, IGenericEntryDescription
{
	private string string_3;

	private int int_0;

	private bool bool_7;

	[XmlAttribute(AttributeName = "description")]
	public string Description
	{
		get
		{
			return string_3;
		}
		set
		{
			if (string_3 != value)
			{
				string_3 = value;
				RaisePropertyChanged("Description");
			}
		}
	}

	[XmlAttribute(AttributeName = "group")]
	public int Group
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				int_0 = value;
				RaisePropertyChanged("Group");
			}
		}
	}

	[XmlIgnore]
	public bool GroupSpecified
	{
		get
		{
			return bool_7;
		}
		set
		{
			if (bool_7 != value)
			{
				bool_7 = value;
				RaisePropertyChanged("GroupSpecified");
			}
		}
	}
}
