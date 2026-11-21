using CSMaterial.ClipperLib;
using Command.Bridges;

namespace Command.Filter;

internal class ExporterInstanceFilter
{
	internal PredicateThreadBridge m_TemplateDispatcher;

	internal PredicateThreadBridge m_MappingDispatcher;

	internal IntPoint mockDispatcher;
}
