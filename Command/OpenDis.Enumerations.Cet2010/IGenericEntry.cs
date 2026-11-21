using System.Collections.Generic;
using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface IGenericEntry : INotifyPropertyChanged
{
	bool BaseUuid { get; set; }

	bool BaseUuidSpecified { get; set; }

	List<object> ChangeRequests { get; set; }

	bool Deprecated { get; set; }

	bool DeprecatedSpecified { get; set; }

	bool Boolean_0 { get; set; }

	bool Boolean_1 { get; set; }

	string Footnote { get; set; }

	GenericEntryStatus Status { get; set; }

	bool StatusSpecified { get; set; }

	string Uuid { get; set; }

	ulong XRef { get; set; }
}
