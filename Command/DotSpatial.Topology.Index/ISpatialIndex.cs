using System.Collections;

namespace DotSpatial.Topology.Index;

public interface ISpatialIndex
{
	void Insert(IEnvelope ienvelope_0, object object_0);

	IList Query(IEnvelope ienvelope_0);

	void Query(IEnvelope ienvelope_0, IItemVisitor iitemVisitor_0);

	bool Remove(IEnvelope ienvelope_0, object object_0);
}
