using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Simplify;

public class TaggedLineStringSimplifier
{
	private static readonly LineIntersector _TaskThread;

	private readonly LineSegmentIndex filterThread = new LineSegmentIndex();

	private readonly LineSegmentIndex m_TestsThread = new LineSegmentIndex();

	private double _InterpreterThread;

	private TaggedLineString containerThread;

	private IList<Coordinate> _ComposerThread;

	public virtual double DistanceTolerance
	{
		get
		{
			return _InterpreterThread;
		}
		set
		{
			_InterpreterThread = value;
		}
	}

	public TaggedLineStringSimplifier(LineSegmentIndex lineSegmentIndex_0, LineSegmentIndex lineSegmentIndex_1)
	{
		filterThread = lineSegmentIndex_0;
		m_TestsThread = lineSegmentIndex_1;
	}

	public virtual void Simplify(TaggedLineString taggedLineString_0)
	{
		containerThread = taggedLineString_0;
		_ComposerThread = taggedLineString_0.ParentCoordinates;
		SortRule(0, _ComposerThread.Count - 1, 0);
	}

	private void SortRule(int int_0, int int_1, int int_2)
	{
		int_2++;
		int[] array = new int[2];
		if (int_0 + 1 == int_1)
		{
			LineSegment segment = containerThread.GetSegment(int_0);
			containerThread.AddToResult(segment);
			return;
		}
		double[] array2 = new double[1];
		int num = CalcRule(_ComposerThread, int_0, int_1, array2);
		bool flag = true;
		if (containerThread.ResultSize < containerThread.MinimumSize && int_2 < 2)
		{
			flag = false;
		}
		if (array2[0] > DistanceTolerance)
		{
			flag = false;
		}
		LineSegment lineSegment = new LineSegment();
		lineSegment.P0 = _ComposerThread[int_0];
		lineSegment.P1 = _ComposerThread[int_1];
		array[0] = int_0;
		array[1] = int_1;
		if (FlushRule(containerThread, array, lineSegment))
		{
			flag = false;
		}
		if (flag)
		{
			LineSegment lineSegment_ = RateRule(int_0, int_1);
			containerThread.AddToResult(lineSegment_);
		}
		else
		{
			SortRule(int_0, num, int_2);
			SortRule(num, int_1, int_2);
		}
	}

	private static int CalcRule(IList<Coordinate> ilist_0, int int_0, int int_1, double[] double_0)
	{
		LineSegment lineSegment = new LineSegment();
		lineSegment.P0 = ilist_0[int_0];
		lineSegment.P1 = ilist_0[int_1];
		double num = -1.0;
		int result = int_0;
		for (int i = int_0 + 1; i < int_1; i++)
		{
			Coordinate coordinate_ = ilist_0[i];
			double num2 = lineSegment.Distance(coordinate_);
			if (num2 > num)
			{
				num = num2;
				result = i;
			}
		}
		double_0[0] = num;
		return result;
	}

	private LineSegment RateRule(int int_0, int int_1)
	{
		Coordinate coordinate_ = _ComposerThread[int_0];
		Coordinate coordinate_2 = _ComposerThread[int_1];
		LineSegment lineSegment = new LineSegment(coordinate_, coordinate_2);
		Remove(containerThread, int_0, int_1);
		m_TestsThread.Add(lineSegment);
		return lineSegment;
	}

	private bool FlushRule(TaggedLineString taggedLineString_0, int[] int_0, LineSegment lineSegment_0)
	{
		if (ForgotRule(lineSegment_0))
		{
			return true;
		}
		if (CollectRule(taggedLineString_0, int_0, lineSegment_0))
		{
			return true;
		}
		return false;
	}

	private bool ForgotRule(LineSegment lineSegment_0)
	{
		IEnumerator enumerator = m_TestsThread.Query(lineSegment_0).GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!RegisterRule((LineSegment)enumerator.Current, lineSegment_0));
		return true;
	}

	private bool CollectRule(TaggedLineString taggedLineString_0, int[] int_0, LineSegment lineSegment_0)
	{
		IEnumerator enumerator = filterThread.Query(lineSegment_0).GetEnumerator();
		TaggedLineSegment taggedLineSegment;
		do
		{
			if (enumerator.MoveNext())
			{
				taggedLineSegment = (TaggedLineSegment)enumerator.Current;
				continue;
			}
			return false;
		}
		while (!RegisterRule(taggedLineSegment, lineSegment_0) || OrderRule(taggedLineString_0, int_0, taggedLineSegment));
		return true;
	}

	private static bool OrderRule(TaggedLineString taggedLineString_0, int[] int_0, TaggedLineSegment taggedLineSegment_0)
	{
		if (taggedLineSegment_0.Parent == taggedLineString_0.Parent)
		{
			int index = taggedLineSegment_0.Index;
			if (index >= int_0[0] && index < int_0[1])
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool RegisterRule(ILineSegmentBase ilineSegmentBase_0, ILineSegmentBase ilineSegmentBase_1)
	{
		_TaskThread.ComputeIntersection(ilineSegmentBase_0.P0, ilineSegmentBase_0.P1, ilineSegmentBase_1.P0, ilineSegmentBase_1.P1);
		return _TaskThread.IsInteriorIntersection();
	}

	private void Remove(TaggedLineString taggedLineString_0, int int_0, int int_1)
	{
		for (int i = int_0; i < int_1; i++)
		{
			TaggedLineSegment segment = taggedLineString_0.GetSegment(i);
			filterThread.Remove(segment);
		}
	}

	static TaggedLineStringSimplifier()
	{
		_TaskThread = new RobustLineIntersector();
	}
}
