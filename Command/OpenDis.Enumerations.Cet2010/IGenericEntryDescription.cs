using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface IGenericEntryDescription : INotifyPropertyChanged, IGenericEntry
{
	string Description { get; set; }

	int Group { get; set; }

	bool GroupSpecified { get; set; }
}
