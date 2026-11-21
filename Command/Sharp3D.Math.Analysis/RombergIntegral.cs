using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public sealed class RombergIntegral : ICloneable, IFloatIntegrator, IDoubleIntegrator
{
	private int dispatcherCallback = 5;

	private double[,] m_ListenerCallback;

	private float[,] m_ConfigCallback;

	public int Order
	{
		get
		{
			return dispatcherCallback;
		}
		set
		{
			if (dispatcherCallback != value)
			{
				dispatcherCallback = value;
				m_ConfigCallback = null;
				m_ListenerCallback = null;
			}
		}
	}

	public RombergIntegral()
	{
	}

	public RombergIntegral(int int_0)
	{
		dispatcherCallback = int_0;
	}

	public RombergIntegral(RombergIntegral rombergIntegral_0)
	{
		dispatcherCallback = rombergIntegral_0.Order;
	}

	public double Integrate(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0, double double_1)
	{
		if (m_ListenerCallback == null || m_ListenerCallback.GetLength(1) == dispatcherCallback)
		{
			m_ListenerCallback = new double[1, dispatcherCallback];
		}
		if (double_0 <= double_1)
		{
			double num = double_1 - double_0;
			m_ListenerCallback[0, 0] = 0.5 * num * (unaryFunction_0(double_0) + unaryFunction_0(double_1));
			int num2 = 2;
			int num3 = 1;
			while (num2 <= dispatcherCallback)
			{
				double num4 = 0.0;
				for (int i = 1; i <= num3; i++)
				{
					num4 += unaryFunction_0(double_0 + num * ((double)i - 0.5));
				}
				m_ListenerCallback[1, 0] = 0.5 * (m_ListenerCallback[0, 0] + num * num4);
				int num5 = 1;
				int num6 = 4;
				while (num5 < num2)
				{
					m_ListenerCallback[1, num5] = ((double)num6 * m_ListenerCallback[1, num5 - 1] - m_ListenerCallback[0, num5 - 1]) / (double)(num6 - 1);
					num5++;
					num6 *= 4;
				}
				for (int j = 0; j < num2; j++)
				{
					m_ListenerCallback[0, j] = m_ListenerCallback[1, j];
				}
				num2++;
				num3 *= 2;
				num /= 2.0;
			}
			return m_ListenerCallback[0, dispatcherCallback - 1];
		}
		return Integrate(unaryFunction_0, double_1, double_0);
	}

	public float Integrate(MathFunctions.UnaryFunction<float> unaryFunction_0, float float_0, float float_1)
	{
		if (m_ConfigCallback == null || m_ConfigCallback.GetLength(1) == dispatcherCallback)
		{
			m_ConfigCallback = new float[1, dispatcherCallback];
		}
		if (float_0 <= float_1)
		{
			float num = float_1 - float_0;
			m_ConfigCallback[0, 0] = 0.5f * num * (unaryFunction_0(float_0) + unaryFunction_0(float_1));
			int num2 = 2;
			int num3 = 1;
			while (num2 <= dispatcherCallback)
			{
				float num4 = 0f;
				for (int i = 1; i <= num3; i++)
				{
					num4 += unaryFunction_0(float_0 + num * ((float)i - 0.5f));
				}
				m_ConfigCallback[1, 0] = 0.5f * (m_ConfigCallback[0, 0] + num * num4);
				int num5 = 1;
				int num6 = 4;
				while (num5 < num2)
				{
					m_ConfigCallback[1, num5] = ((float)num6 * m_ConfigCallback[1, num5 - 1] - m_ConfigCallback[0, num5 - 1]) / (float)(num6 - 1);
					num5++;
					num6 *= 4;
				}
				for (int j = 0; j < num2; j++)
				{
					m_ConfigCallback[0, j] = m_ConfigCallback[1, j];
				}
				num2++;
				num3 *= 2;
				num /= 2f;
			}
			return m_ConfigCallback[0, dispatcherCallback - 1];
		}
		return Integrate(unaryFunction_0, float_1, float_0);
	}

	object ICloneable.Clone()
	{
		return new RombergIntegral(this);
	}

	public RombergIntegral Clone()
	{
		return new RombergIntegral(this);
	}
}
