using System.Threading;
using System.Threading.Tasks;

namespace OpenDis.Common;

internal struct SerializerDefinition
{
	internal string ID;

	internal Task _RefDefinition;

	internal CancellationTokenSource m_ErrorDefinition;
}
