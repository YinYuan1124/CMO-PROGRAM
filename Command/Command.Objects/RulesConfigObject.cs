using CSMaterial.ClipperLib;
using Command.Bridges;

namespace Command.Objects;

internal class RulesConfigObject
{
	internal int m_MethodDispatcher;

	internal bool serviceDispatcher;

	internal bool m_SystemDispatcher;

	internal RulesConfigObject candidateDispatcher;

	internal PredicateThreadBridge _BaseDispatcher;

	internal PredicateThreadBridge policyDispatcher;

	internal PolyNode m_BroadcasterDispatcher;
}
