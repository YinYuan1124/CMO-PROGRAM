namespace DotSpatial.Topology.GeometriesGraph;

public class Position
{
	public static PositionType Opposite(PositionType positionType_0)
	{
		if (1 == 0)
		{
		}
		PositionType result = positionType_0 switch
		{
			PositionType.Right => PositionType.Left, 
			PositionType.Left => PositionType.Right, 
			_ => positionType_0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
