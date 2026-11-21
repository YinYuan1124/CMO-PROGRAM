using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public sealed class SimpsonIntegral : ICloneable, IFloatIntegrator, IDoubleIntegrator
{
	private int _RegistryCallback = 100;

	public int Steps => _RegistryCallback;

	public SimpsonIntegral()
	{
	}

	public SimpsonIntegral(int int_0)
	{
		_RegistryCallback = int_0;
	}

	public SimpsonIntegral(SimpsonIntegral simpsonIntegral_0)
	{
		_RegistryCallback = simpsonIntegral_0._RegistryCallback;
	}

	object ICloneable.Clone()
	{
		return new SimpsonIntegral(this);
	}

	public SimpsonIntegral Clone()
	{
		return new SimpsonIntegral(this);
	}

	public float Integrate(MathFunctions.UnaryFunction<float> unaryFunction_0, float float_0, float float_1)
	{
		if (float_0 <= float_1)
		{
			float num = 0f;
			float num2 = (float_1 - float_0) / (float)_RegistryCallback;
			float num3 = num2 / 3f;
			for (int i = 0; i < _RegistryCallback; i += 2)
			{
				num += (unaryFunction_0(float_0 + (float)i * num2) + 4f * unaryFunction_0(float_0 + (float)(i + 1) * num2) + unaryFunction_0(float_0 + (float)(i + 2) * num2)) * num3;
			}
			return num;
		}
		return 0f - Integrate(unaryFunction_0, float_1, float_0);
	}

	public double Integrate(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0, double double_1)
	{
		if (double_0 <= double_1)
		{
			double num = 0.0;
			double num2 = (double_1 - double_0) / (double)_RegistryCallback;
			double num3 = num2 / 3.0;
			for (int i = 0; i < _RegistryCallback; i += 2)
			{
				num += (unaryFunction_0(double_0 + (double)i * num2) + 4.0 * unaryFunction_0(double_0 + (double)(i + 1) * num2) + unaryFunction_0(double_0 + (double)(i + 2) * num2)) * num3;
			}
			return num;
		}
		return 0.0 - Integrate(unaryFunction_0, double_1, double_0);
	}
}
