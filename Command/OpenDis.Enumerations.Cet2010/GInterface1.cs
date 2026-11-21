using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface GInterface1 : INotifyPropertyChanged, IGenericEntry, IGenericEntryDescription
{
	ulong UId { get; set; }
}
