using System;
using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeIntersection : IComparable
{
	private Coordinate _ReaderInstance;

	private double propertyInstance;

	private int _ImporterInstance;

	public virtual Coordinate Coordinate
	{
		get
		{
			return _ReaderInstance;
		}
		set
		{
			_ReaderInstance = value;
		}
	}

	public virtual int SegmentIndex
	{
		get
		{
			return _ImporterInstance;
		}
		set
		{
			_ImporterInstance = value;
		}
	}

	public virtual double Distance
	{
		get
		{
			return propertyInstance;
		}
		set
		{
			propertyInstance = value;
		}
	}

	public EdgeIntersection(Coordinate coordinate_0, int int_0, double double_0)
	{
		_ReaderInstance = new Coordinate(coordinate_0);
		_ImporterInstance = int_0;
		propertyInstance = double_0;
	}

	public virtual int CompareTo(object target)
	{
		EdgeIntersection edgeIntersection = (EdgeIntersection)target;
		return Compare(edgeIntersection.SegmentIndex, edgeIntersection.Distance);
	}

	public virtual int Compare(int int_0, double double_0)
	{
		if (SegmentIndex < int_0)
		{
			return -1;
		}
		if (SegmentIndex <= int_0)
		{
			if (Distance < double_0)
			{
				return -1;
			}
			if (!(Distance <= double_0))
			{
				return 1;
			}
			return 0;
		}
		return 1;
	}

	public virtual bool IsEndPoint(int int_0)
	{
		if (SegmentIndex == 0 && Distance == 0.0)
		{
			return true;
		}
		if (SegmentIndex == int_0)
		{
			return true;
		}
		return false;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.Write(Coordinate);
		streamWriter_0.Write(" seg # = " + SegmentIndex);
		streamWriter_0.WriteLine(" dist = " + Distance);
	}
}
