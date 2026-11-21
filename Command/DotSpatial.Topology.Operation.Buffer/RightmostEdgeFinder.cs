using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Buffer;

public sealed class RightmostEdgeFinder
{
	private Coordinate printerRule;

	private DirectedEdge _ParserRule;

	private int _AlgoRule = -1;

	private DirectedEdge databaseRule;

	public DirectedEdge Edge => databaseRule;

	public Coordinate Coordinate => printerRule;

	public void FindEdge(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsForward)
			{
				CheckObject(directedEdge);
			}
		}
		Assert.IsTrue(_AlgoRule != 0 || printerRule.Equals(_ParserRule.Coordinate), "inconsistency in rightmost processing");
		if (_AlgoRule == 0)
		{
			ChangeObject();
		}
		else
		{
			InitObject();
		}
		databaseRule = _ParserRule;
		if (ConcatObject(_ParserRule, _AlgoRule) == PositionType.Left)
		{
			databaseRule = _ParserRule.Sym;
		}
	}

	private void ChangeObject()
	{
		DirectedEdgeStar directedEdgeStar = (DirectedEdgeStar)_ParserRule.Node.Edges;
		_ParserRule = directedEdgeStar.GetRightmostEdge();
		if (!_ParserRule.IsForward)
		{
			_ParserRule = _ParserRule.Sym;
			_AlgoRule = _ParserRule.Edge.Coordinates.Count - 1;
		}
	}

	private void InitObject()
	{
		IList<Coordinate> coordinates = _ParserRule.Edge.Coordinates;
		Assert.IsTrue(_AlgoRule > 0 && _AlgoRule < coordinates.Count, "rightmost point expected to be interior vertex of edge");
		Coordinate coordinate = coordinates[_AlgoRule - 1];
		Coordinate coordinate2 = coordinates[_AlgoRule + 1];
		int num = CgAlgorithms.ComputeOrientation(printerRule, coordinate2, coordinate);
		bool flag = false;
		if (coordinate.Y < printerRule.Y && coordinate2.Y < printerRule.Y && num == 1)
		{
			flag = true;
		}
		else if (coordinate.Y > printerRule.Y && coordinate2.Y > printerRule.Y && num == -1)
		{
			flag = true;
		}
		if (flag)
		{
			_AlgoRule--;
		}
	}

	private void CheckObject(DirectedEdge directedEdge_0)
	{
		IList<Coordinate> coordinates = directedEdge_0.Edge.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			if (printerRule == null || coordinates[i].X > printerRule.X)
			{
				_ParserRule = directedEdge_0;
				_AlgoRule = i;
				printerRule = coordinates[i];
			}
		}
	}

	private PositionType ConcatObject(DirectedEdge directedEdge_0, int int_0)
	{
		PositionType positionType = InterruptObject(directedEdge_0, int_0);
		if (positionType < PositionType.On)
		{
			positionType = InterruptObject(directedEdge_0, int_0 - 1);
		}
		if (positionType < PositionType.On)
		{
			printerRule = null;
			CheckObject(directedEdge_0);
		}
		return positionType;
	}

	private static PositionType InterruptObject(EdgeEnd edgeEnd_0, int int_0)
	{
		IList<Coordinate> coordinates = edgeEnd_0.Edge.Coordinates;
		if (int_0 >= 0 && int_0 + 1 < coordinates.Count)
		{
			if (coordinates[int_0].Y == coordinates[int_0 + 1].Y)
			{
				return PositionType.Parallel;
			}
			PositionType result = PositionType.Left;
			if (coordinates[int_0].Y < coordinates[int_0 + 1].Y)
			{
				result = PositionType.Right;
			}
			return result;
		}
		return PositionType.Parallel;
	}
}
