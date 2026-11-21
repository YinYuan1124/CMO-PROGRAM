using System.Collections;

namespace DotSpatial.Topology.Noding;

public interface INoder
{
	void ComputeNodes(IList ilist_0);

	IList GetNodedSubstrings();
}
