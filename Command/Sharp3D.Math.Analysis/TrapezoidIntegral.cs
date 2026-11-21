using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public sealed class TrapezoidIntegral : ICloneable, IDoubleIntegrator
{
	public enum Method
	{
		Default,
		MidPoint
	}

	private double m_DefinitionCallback;

	private int _ValCallback;

	private Method m_WrapperCallback;

	public double Accuracy
	{
		get
		{
			return m_DefinitionCallback;
		}
		set
		{
			m_DefinitionCallback = value;
		}
	}

	public int MaxIterations
	{
		get
		{
			return _ValCallback;
		}
		set
		{
			_ValCallback = value;
		}
	}

	public Method IntegrationMethod
	{
		get
		{
			return m_WrapperCallback;
		}
		set
		{
			m_WrapperCallback = value;
		}
	}

	public TrapezoidIntegral()
	{
		m_DefinitionCallback = 0.0001;
		_ValCallback = int.MaxValue;
		m_WrapperCallback = Method.Default;
	}

	public TrapezoidIntegral(double double_0, int int_0, Method method_0)
	{
		m_DefinitionCallback = double_0;
		_ValCallback = int_0;
		m_WrapperCallback = method_0;
	}

	public TrapezoidIntegral(TrapezoidIntegral trapezoidIntegral_0)
	{
		m_DefinitionCallback = trapezoidIntegral_0.m_DefinitionCallback;
		_ValCallback = trapezoidIntegral_0._ValCallback;
		m_WrapperCallback = trapezoidIntegral_0.m_WrapperCallback;
	}

	private double VisitCallback(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0, double double_1, double double_2, int int_0)
	{
		double num = 0.0;
		double num2 = (double_1 - double_0) / (double)int_0;
		double num3 = double_0 + num2 / 2.0;
		int num4 = 0;
		while (num4 < int_0)
		{
			num += unaryFunction_0(num3);
			num4++;
			num3 += num2;
		}
		return (double_2 + num2 * num) / 2.0;
	}

	private double RestartCallback(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0, double double_1, double double_2, int int_0)
	{
		double num = 0.0;
		double num2 = (double_1 - double_0) / (double)int_0;
		double num3 = num2 * 0.0;
		double num4 = double_0 + num2 / 6.0;
		int num5 = 0;
		while (num5 < int_0)
		{
			num += unaryFunction_0(num4) + unaryFunction_0(num4 + num3);
			num5++;
			num4 += num2;
		}
		return (double_2 + num2 * num) / 3.0;
	}

	object ICloneable.Clone()
	{
		return new TrapezoidIntegral(this);
	}

	public TrapezoidIntegral Clone()
	{
		return new TrapezoidIntegral(this);
	}

	public double Integrate(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0, double double_1)
	{
		if (double_0 == double_1)
		{
			return 0.0;
		}
		if (double_0 <= double_1)
		{
			int num = 1;
			double num2 = (unaryFunction_0(double_0) + unaryFunction_0(double_1)) * (double_1 - double_0) / 2.0;
			double num3 = 0.0;
			int num4 = 1;
			while (true)
			{
				switch (m_WrapperCallback)
				{
				case Method.MidPoint:
					num3 = RestartCallback(unaryFunction_0, double_0, double_1, num2, num);
					num *= 3;
					break;
				case Method.Default:
					num3 = VisitCallback(unaryFunction_0, double_0, double_1, num2, num);
					num *= 2;
					break;
				}
				if (System.Math.Abs(num3 - num2) <= m_DefinitionCallback)
				{
					break;
				}
				num2 = num3;
				num4++;
				if (num4 >= _ValCallback)
				{
					throw new MathException("Max number of iterations reached.");
				}
			}
			return num3;
		}
		return 0.0 - Integrate(unaryFunction_0, double_1, double_0);
	}
}
