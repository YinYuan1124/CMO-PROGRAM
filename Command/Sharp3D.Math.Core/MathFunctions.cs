using System;

namespace Sharp3D.Math.Core;

public static class MathFunctions
{
	public delegate T VoidFunction<T>();

	public delegate T UnaryFunction<T>(T param);

	public delegate T BinaryFunction<T>(T param1, T param2);

	public delegate T TenaryFunction<T>(T param1, T param2, T param3);

	public const double PI = System.Math.PI;

	public const double TwoPI = System.Math.PI * 2.0;

	public const double SquaredPI = 9.869604401089358;

	public const double HalfPI = System.Math.PI / 2.0;

	public const float EpsilonF = 4.7683716E-07f;

	public const double EpsilonD = 8.881784197001252E-16;

	public static readonly UnaryFunction<double> DoubleSinFunction;

	public static readonly UnaryFunction<double> DoubleCosFunction;

	public static readonly UnaryFunction<double> DoubleTanFunction;

	public static readonly UnaryFunction<double> DoubleCotFunction;

	public static readonly UnaryFunction<double> DoubleSecFunction;

	public static readonly UnaryFunction<double> DoubleCscFunction;

	public static readonly UnaryFunction<ComplexD> unaryFunction_0;

	public static readonly UnaryFunction<ComplexD> unaryFunction_1;

	public static readonly UnaryFunction<ComplexD> unaryFunction_2;

	public static readonly UnaryFunction<ComplexD> unaryFunction_3;

	public static readonly UnaryFunction<ComplexD> unaryFunction_4;

	public static readonly UnaryFunction<ComplexD> unaryFunction_5;

	public static readonly UnaryFunction<double> DoubleAsinFunction;

	public static readonly UnaryFunction<double> DoubleAcosFunction;

	public static readonly UnaryFunction<double> DoubleAtanFunction;

	public static readonly UnaryFunction<double> DoubleAcotFunction;

	public static readonly UnaryFunction<double> DoubleAsecFunction;

	public static readonly UnaryFunction<double> DoubleAcscFunction;

	public static readonly UnaryFunction<ComplexD> unaryFunction_6;

	public static readonly UnaryFunction<ComplexD> unaryFunction_7;

	public static readonly UnaryFunction<ComplexD> unaryFunction_8;

	public static readonly UnaryFunction<ComplexD> unaryFunction_9;

	public static readonly UnaryFunction<ComplexD> unaryFunction_10;

	public static readonly UnaryFunction<ComplexD> unaryFunction_11;

	public static readonly UnaryFunction<double> DoubleSinhFunction;

	public static readonly UnaryFunction<double> DoubleCoshFunction;

	public static readonly UnaryFunction<double> DoubleTanhFunction;

	public static readonly UnaryFunction<double> DoubleCothFunction;

	public static readonly UnaryFunction<double> DoubleSechFunction;

	public static readonly UnaryFunction<double> DoubleCschFunction;

	public static readonly UnaryFunction<ComplexD> unaryFunction_12;

	public static readonly UnaryFunction<ComplexD> unaryFunction_13;

	public static readonly UnaryFunction<ComplexD> unaryFunction_14;

	public static readonly UnaryFunction<ComplexD> unaryFunction_15;

	public static readonly UnaryFunction<ComplexD> unaryFunction_16;

	public static readonly UnaryFunction<ComplexD> unaryFunction_17;

	public static readonly UnaryFunction<double> DoubleAsinhFunction;

	public static readonly UnaryFunction<double> DoubleAcoshFunction;

	public static readonly UnaryFunction<double> DoubleAtanhFunction;

	public static readonly UnaryFunction<double> DoubleAcothFunction;

	public static readonly UnaryFunction<double> DoubleAsechFunction;

	public static readonly UnaryFunction<double> DoubleAcschFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAsinhFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAcoshFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAtanhFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAcothFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAsechFunction;

	public static readonly UnaryFunction<ComplexD> ComplexDAcschFunction;

	public static readonly UnaryFunction<float> FloatAbsFunction;

	public static readonly UnaryFunction<double> DoubleAbsFunction;

	public static readonly UnaryFunction<int> IntAbsFunction;

	public static readonly UnaryFunction<double> DoubleSqrtFunction;

	public static int Abs(int int_0)
	{
		return System.Math.Abs(int_0);
	}

	public static float Abs(float float_0)
	{
		return System.Math.Abs(float_0);
	}

	public static double Abs(double double_0)
	{
		return System.Math.Abs(double_0);
	}

	public static int[] Abs(int[] int_0)
	{
		int[] array = new int[int_0.Length];
		for (int i = 0; i < int_0.Length; i++)
		{
			array[i] = System.Math.Abs(int_0[i]);
		}
		return array;
	}

	public static float[] Abs(float[] float_0)
	{
		float[] array = new float[float_0.Length];
		for (int i = 0; i < float_0.Length; i++)
		{
			array[i] = System.Math.Abs(float_0[i]);
		}
		return array;
	}

	public static double[] Abs(double[] double_0)
	{
		double[] array = new double[double_0.Length];
		for (int i = 0; i < double_0.Length; i++)
		{
			array[i] = System.Math.Abs(double_0[i]);
		}
		return array;
	}

	public static double Clamp(double double_0, double double_1, double double_2)
	{
		if (double_2 <= System.Math.Abs(double_0 - double_1))
		{
			return double_0;
		}
		return double_1;
	}

	public static double Clamp(double double_0, double double_1)
	{
		if (8.881784197001252E-16 <= System.Math.Abs(double_0 - double_1))
		{
			return double_0;
		}
		return double_1;
	}

	public static float Clamp(float float_0, float float_1, float float_2)
	{
		if (float_2 <= System.Math.Abs(float_0 - float_1))
		{
			return float_0;
		}
		return float_1;
	}

	public static float Clamp(float float_0, float float_1)
	{
		if (4.7683716E-07f <= System.Math.Abs(float_0 - float_1))
		{
			return float_0;
		}
		return float_1;
	}

	public static double Sin(double double_0)
	{
		return System.Math.Sin(double_0);
	}

	public static float Sin(float float_0)
	{
		return (float)System.Math.Sin(float_0);
	}

	public static ComplexD Sin(ComplexD complexD_0)
	{
		return ComplexD.Sin(complexD_0);
	}

	public static double Cos(double double_0)
	{
		return System.Math.Cos(double_0);
	}

	public static float Cos(float float_0)
	{
		return (float)System.Math.Cos(float_0);
	}

	public static ComplexD Cos(ComplexD complexD_0)
	{
		return ComplexD.Cos(complexD_0);
	}

	public static double Tan(double double_0)
	{
		return System.Math.Tan(double_0);
	}

	public static float Tan(float float_0)
	{
		return (float)System.Math.Tan(float_0);
	}

	public static ComplexD Tan(ComplexD complexD_0)
	{
		return ComplexD.Tan(complexD_0);
	}

	public static double Cot(double double_0)
	{
		return 1.0 / System.Math.Tan(double_0);
	}

	public static float Cot(float float_0)
	{
		return (float)(1.0 / System.Math.Tan(float_0));
	}

	public static ComplexD Cot(ComplexD complexD_0)
	{
		return ComplexD.Cot(complexD_0);
	}

	public static double Sec(double double_0)
	{
		return 1.0 / System.Math.Cos(double_0);
	}

	public static float Sec(float float_0)
	{
		return (float)(1.0 / System.Math.Cos(float_0));
	}

	public static ComplexD Sec(ComplexD complexD_0)
	{
		return ComplexD.Sec(complexD_0);
	}

	public static double Csc(double double_0)
	{
		return 1.0 / System.Math.Sin(double_0);
	}

	public static float Csc(float float_0)
	{
		return (float)(1.0 / System.Math.Sin(float_0));
	}

	public static ComplexD Csc(ComplexD complexD_0)
	{
		return ComplexD.Csc(complexD_0);
	}

	public static double Asin(double double_0)
	{
		return System.Math.Asin(double_0);
	}

	public static ComplexD Asin(ComplexD complexD_0)
	{
		return ComplexD.Asin(complexD_0);
	}

	public static double Acos(double double_0)
	{
		return System.Math.Acos(double_0);
	}

	public static ComplexD Acos(ComplexD complexD_0)
	{
		return ComplexD.Acos(complexD_0);
	}

	public static double Atan(double double_0)
	{
		return System.Math.Atan(double_0);
	}

	public static ComplexD Atan(ComplexD complexD_0)
	{
		return ComplexD.Atan(complexD_0);
	}

	public static double Acot(double double_0)
	{
		return System.Math.Atan(1.0 / double_0);
	}

	public static ComplexD Acot(ComplexD complexD_0)
	{
		return ComplexD.Acot(complexD_0);
	}

	public static double Asec(double double_0)
	{
		return System.Math.Acos(1.0 / double_0);
	}

	public static ComplexD Asec(ComplexD complexD_0)
	{
		return ComplexD.Asec(complexD_0);
	}

	public static double Acsc(double double_0)
	{
		return System.Math.Asin(1.0 / double_0);
	}

	public static ComplexD Acsc(ComplexD complexD_0)
	{
		return ComplexD.Acsc(complexD_0);
	}

	public static double Sinh(double double_0)
	{
		return System.Math.Sinh(double_0);
	}

	public static ComplexD Sinh(ComplexD complexD_0)
	{
		return ComplexD.Sinh(complexD_0);
	}

	public static double Cosh(double double_0)
	{
		return System.Math.Cosh(double_0);
	}

	public static ComplexD Cosh(ComplexD complexD_0)
	{
		return ComplexD.Cosh(complexD_0);
	}

	public static double Tanh(double double_0)
	{
		return System.Math.Tanh(double_0);
	}

	public static ComplexD Tanh(ComplexD complexD_0)
	{
		return ComplexD.Tanh(complexD_0);
	}

	public static double Coth(double double_0)
	{
		return 1.0 / System.Math.Tanh(double_0);
	}

	public static ComplexD Coth(ComplexD complexD_0)
	{
		return ComplexD.Coth(complexD_0);
	}

	public static double Sech(double double_0)
	{
		return 1.0 / System.Math.Cosh(double_0);
	}

	public static ComplexD Sech(ComplexD complexD_0)
	{
		return ComplexD.Sech(complexD_0);
	}

	public static double Csch(double double_0)
	{
		return 1.0 / System.Math.Sinh(double_0);
	}

	public static ComplexD Csch(ComplexD complexD_0)
	{
		return ComplexD.Csch(complexD_0);
	}

	public static double Asinh(double double_0)
	{
		return System.Math.Log(double_0 + System.Math.Sqrt(double_0 * double_0 + 1.0), System.Math.E);
	}

	public static ComplexD Asinh(ComplexD complexD_0)
	{
		return ComplexD.Asinh(complexD_0);
	}

	public static double Acosh(double double_0)
	{
		return System.Math.Log(double_0 + System.Math.Sqrt(double_0 - 1.0) * System.Math.Sqrt(double_0 + 1.0), System.Math.E);
	}

	public static ComplexD Acosh(ComplexD complexD_0)
	{
		return ComplexD.Acosh(complexD_0);
	}

	public static double Atanh(double double_0)
	{
		return 0.5 * System.Math.Log((1.0 + double_0) / (1.0 - double_0), System.Math.E);
	}

	public static ComplexD Atanh(ComplexD complexD_0)
	{
		return ComplexD.Atanh(complexD_0);
	}

	public static double Acoth(double double_0)
	{
		return 0.5 * System.Math.Log((double_0 + 1.0) / (double_0 - 1.0), System.Math.E);
	}

	public static ComplexD Acoth(ComplexD complexD_0)
	{
		return ComplexD.Acoth(complexD_0);
	}

	public static double Asech(double double_0)
	{
		return Acosh(1.0 / double_0);
	}

	public static ComplexD Asech(ComplexD complexD_0)
	{
		return ComplexD.Asech(complexD_0);
	}

	public static double Acsch(double double_0)
	{
		return Asinh(1.0 / double_0);
	}

	public static ComplexD Acsch(ComplexD complexD_0)
	{
		return ComplexD.Acsch(complexD_0);
	}

	public static bool ApproxEquals(float float_0, float float_1)
	{
		return System.Math.Abs(float_0 - float_1) <= 4.7683716E-07f;
	}

	public static bool ApproxEquals(float float_0, float float_1, float float_2)
	{
		return System.Math.Abs(float_0 - float_1) <= float_2;
	}

	public static bool ApproxEquals(double double_0, double double_1)
	{
		return System.Math.Abs(double_0 - double_1) <= 8.881784197001252E-16;
	}

	public static bool ApproxEquals(double double_0, double double_1, double double_2)
	{
		return System.Math.Abs(double_0 - double_1) <= double_2;
	}

	public static void Swap<T>(ref T gparam_0, ref T gparam_1)
	{
		T val = gparam_0;
		gparam_0 = gparam_1;
		gparam_1 = val;
	}

	static MathFunctions()
	{
		DoubleSinFunction = Sin;
		DoubleCosFunction = Cos;
		DoubleTanFunction = Tan;
		DoubleCotFunction = Cot;
		DoubleSecFunction = Sec;
		DoubleCscFunction = Csc;
		unaryFunction_0 = Sin;
		unaryFunction_1 = Cos;
		unaryFunction_2 = Tan;
		unaryFunction_3 = Cot;
		unaryFunction_4 = Sec;
		unaryFunction_5 = Csc;
		DoubleAsinFunction = Asin;
		DoubleAcosFunction = Acos;
		DoubleAtanFunction = Atan;
		DoubleAcotFunction = Acot;
		DoubleAsecFunction = Asec;
		DoubleAcscFunction = Acsc;
		unaryFunction_6 = Asin;
		unaryFunction_7 = Acos;
		unaryFunction_8 = Atan;
		unaryFunction_9 = Acot;
		unaryFunction_10 = Asec;
		unaryFunction_11 = Acsc;
		DoubleSinhFunction = Sinh;
		DoubleCoshFunction = Cosh;
		DoubleTanhFunction = Tanh;
		DoubleCothFunction = Coth;
		DoubleSechFunction = Sech;
		DoubleCschFunction = Csch;
		unaryFunction_12 = Sinh;
		unaryFunction_13 = Cosh;
		unaryFunction_14 = Tanh;
		unaryFunction_15 = Coth;
		unaryFunction_16 = Sech;
		unaryFunction_17 = Csch;
		DoubleAsinhFunction = Asinh;
		DoubleAcoshFunction = Acosh;
		DoubleAtanhFunction = Atanh;
		DoubleAcothFunction = Acoth;
		DoubleAsechFunction = Asech;
		DoubleAcschFunction = Acsch;
		ComplexDAsinhFunction = Asinh;
		ComplexDAcoshFunction = Acosh;
		ComplexDAtanhFunction = Atanh;
		ComplexDAcothFunction = Acoth;
		ComplexDAsechFunction = Asech;
		ComplexDAcschFunction = Acsch;
		FloatAbsFunction = System.Math.Abs;
		DoubleAbsFunction = System.Math.Abs;
		IntAbsFunction = System.Math.Abs;
		DoubleSqrtFunction = System.Math.Sqrt;
	}
}
