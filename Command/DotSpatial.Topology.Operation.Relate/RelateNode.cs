using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateNode : Node
{
	public RelateNode(Coordinate coordinate_0, EdgeEndStar edgeEndStar_0)
		: base(coordinate_0, edgeEndStar_0)
	{
	}

	public override void ComputeIm(IntersectionMatrix intersectionMatrix_0)
	{
		intersectionMatrix_0.SetAtLeastIfValid(Label.GetLocation(0), Label.GetLocation(1), DimensionType.Point);
	}

	public virtual void UpdateImFromEdges(IntersectionMatrix intersectionMatrix_0)
	{
		((EdgeEndBundleStar)Edges).UpdateIm(intersectionMatrix_0);
	}
}
