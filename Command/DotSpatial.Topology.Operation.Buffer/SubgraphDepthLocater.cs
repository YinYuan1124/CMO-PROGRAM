using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Buffer;

public class SubgraphDepthLocater
{
	private class ExceptionCallbackCandidate : IComparable
	{
		private readonly int errorPrototype;

		private readonly LineSegment _CodePrototype;

		[SpecialName]
		public int RegisterInterruptibleMapping()
		{
			return errorPrototype;
		}

		public ExceptionCallbackCandidate(ILineSegmentBase ilineSegmentBase_0, int int_0)
		{
			_CodePrototype = new LineSegment(ilineSegmentBase_0);
			errorPrototype = int_0;
		}

		public int CompareTo(object target)
		{
			ExceptionCallbackCandidate exceptionCallbackCandidate = (ExceptionCallbackCandidate)target;
			int num = _CodePrototype.OrientationIndex(exceptionCallbackCandidate._CodePrototype);
			if (num == 0)
			{
				num = -1 * exceptionCallbackCandidate._CodePrototype.OrientationIndex(_CodePrototype);
			}
			if (num == 0)
			{
				return OrderInterruptibleMapping(_CodePrototype, exceptionCallbackCandidate._CodePrototype);
			}
			return num;
		}

		private static int OrderInterruptibleMapping(ILineSegmentBase ilineSegmentBase_0, ILineSegmentBase ilineSegmentBase_1)
		{
			int num = ilineSegmentBase_0.P0.CompareTo(ilineSegmentBase_1.P0);
			if (num == 0)
			{
				return ilineSegmentBase_0.P1.CompareTo(ilineSegmentBase_1.P1);
			}
			return num;
		}
	}

	private readonly LineSegment interceptorRule = new LineSegment();

	private readonly IList messageRule;

	public SubgraphDepthLocater(IList ilist_0)
	{
		messageRule = ilist_0;
	}

	public virtual int GetDepth(Coordinate coordinate_0)
	{
		ArrayList arrayList = new ArrayList(RemoveObject(coordinate_0));
		if (arrayList.Count == 0)
		{
			return 0;
		}
		arrayList.Sort();
		return ((ExceptionCallbackCandidate)arrayList[0]).RegisterInterruptibleMapping();
	}

	private IList RemoveObject(Coordinate coordinate_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = messageRule.GetEnumerator();
		while (enumerator.MoveNext())
		{
			BufferSubgraph bufferSubgraph = (BufferSubgraph)enumerator.Current;
			FindObject(coordinate_0, bufferSubgraph.DirectedEdges, list);
		}
		return list;
	}

	private void FindObject(Coordinate coordinate_0, IEnumerable ienumerable_0, IList ilist_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsForward)
			{
				SetObject(coordinate_0, directedEdge, ilist_0);
			}
		}
	}

	private void SetObject(Coordinate coordinate_0, DirectedEdge directedEdge_0, IList ilist_0)
	{
		IList<Coordinate> coordinates = directedEdge_0.Edge.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			interceptorRule.P0 = coordinates[i];
			interceptorRule.P1 = coordinates[i + 1];
			if (interceptorRule.P0.Y > interceptorRule.P1.Y)
			{
				interceptorRule.Reverse();
			}
			if (Math.Max(interceptorRule.P0.X, interceptorRule.P1.X) >= coordinate_0.X && !interceptorRule.IsHorizontal && coordinate_0.Y >= interceptorRule.P0.Y && coordinate_0.Y <= interceptorRule.P1.Y && CgAlgorithms.ComputeOrientation(interceptorRule.P0, interceptorRule.P1, coordinate_0) != -1)
			{
				int depth = directedEdge_0.GetDepth(PositionType.Left);
				if (!interceptorRule.P0.Equals(coordinates[i]))
				{
					depth = directedEdge_0.GetDepth(PositionType.Right);
				}
				ExceptionCallbackCandidate value = new ExceptionCallbackCandidate(interceptorRule, depth);
				ilist_0.Add(value);
			}
		}
	}
}
