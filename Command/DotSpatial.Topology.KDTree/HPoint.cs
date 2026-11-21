using System;

namespace DotSpatial.Topology.KDTree;

public class HPoint : Coordinate
{
	private readonly int _InterpreterCollection;

	public double[] Values
	{
		get
		{
			return ToArray();
		}
		set
		{
			if (value.Length != 0)
			{
				X = value[0];
			}
			if (value.Length > 1)
			{
				Y = value[1];
			}
			if (value.Length > 2)
			{
				Z = value[2];
			}
		}
	}

	public HPoint(int int_0)
	{
		_InterpreterCollection = int_0;
	}

	public HPoint(double[] double_0)
	{
		_InterpreterCollection = double_0.Length;
		if (_InterpreterCollection > 0)
		{
			X = double_0[0];
		}
		if (_InterpreterCollection > 1)
		{
			Y = double_0[1];
		}
		if (_InterpreterCollection > 2)
		{
			Z = double_0[2];
		}
	}

	public static double SquareDistance(HPoint hpoint_0, HPoint hpoint_1)
	{
		int num = Math.Min(hpoint_0.NumOrdinates, hpoint_1.NumOrdinates);
		double num2 = 0.0;
		if (!(hpoint_0 == null) && !(hpoint_1 == null))
		{
			for (int i = 0; i < num; i++)
			{
				double num3 = hpoint_0[i] - hpoint_1[i];
				num2 += num3 * num3;
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				double num4 = hpoint_0[j] - hpoint_1[j];
				num2 += num4 * num4;
			}
		}
		return num2;
	}

	public static double EuclideanDistance(HPoint hpoint_0, HPoint hpoint_1)
	{
		return Math.Sqrt(SquareDistance(hpoint_0, hpoint_1));
	}

	public double HyperDistance(HPoint hpoint_0)
	{
		return Math.Sqrt(SquareHyperDistance(hpoint_0));
	}

	public double SquareHyperDistance(HPoint hpoint_0)
	{
		int num = Math.Min(hpoint_0.NumOrdinates, base.NumOrdinates);
		double num2 = 0.0;
		for (int i = 0; i < num; i++)
		{
			double num3 = hpoint_0[i] - base[i];
			num2 += num3 * num3;
		}
		return num2;
	}
}
