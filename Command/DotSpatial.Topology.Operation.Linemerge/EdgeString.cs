using System.Collections;

namespace DotSpatial.Topology.Operation.Linemerge;

public class EdgeString
{
	private readonly IList _ComposerRule = new ArrayList();

	private readonly IGeometryFactory modelRule;

	private Coordinate[] _AdvisorRule;

	private Coordinate[] Coordinates
	{
		get
		{
			if (_AdvisorRule == null)
			{
				int num = 0;
				int num2 = 0;
				CoordinateList coordinateList = new CoordinateList();
				IEnumerator enumerator = _ComposerRule.GetEnumerator();
				while (enumerator.MoveNext())
				{
					LineMergeDirectedEdge lineMergeDirectedEdge = (LineMergeDirectedEdge)enumerator.Current;
					if (lineMergeDirectedEdge.EdgeDirection)
					{
						num++;
					}
					else
					{
						num2++;
					}
					coordinateList.Add(((LineMergeEdge)lineMergeDirectedEdge.Edge).Line.Coordinates, bool_0: false, lineMergeDirectedEdge.EdgeDirection);
				}
				_AdvisorRule = coordinateList.ToCoordinateArray();
				if (num2 > num)
				{
					CoordinateArrays.Reverse(_AdvisorRule);
				}
			}
			return _AdvisorRule;
		}
	}

	public EdgeString(IGeometryFactory igeometryFactory_0)
	{
		modelRule = igeometryFactory_0;
	}

	public virtual void Add(LineMergeDirectedEdge lineMergeDirectedEdge_0)
	{
		_ComposerRule.Add(lineMergeDirectedEdge_0);
	}

	public virtual ILineString ToLineString()
	{
		return modelRule.CreateLineString(Coordinates);
	}
}
