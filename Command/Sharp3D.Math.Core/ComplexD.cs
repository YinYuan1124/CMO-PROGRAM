using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
public struct ComplexD : ICloneable
{
	private double _real;

	private double _image;

	public static readonly ComplexD Zero;

	public static readonly ComplexD One;

	public static readonly ComplexD I;

	public double Real
	{
		get
		{
			return _real;
		}
		set
		{
			_real = value;
		}
	}

	public double Imaginary
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
		}
	}

	public bool IsReal => _image == 0.0;

	public bool IsImaginary => _real == 0.0;

	public double Modulus => System.Math.Sqrt(_real * _real + _image * _image);

	public double ModulusSquared => _real * _real + _image * _image;

	public double Argument
	{
		get
		{
			if (_image == 0.0 && _real < 0.0)
			{
				return System.Math.PI;
			}
			if (_image == 0.0 && _real >= 0.0)
			{
				return 0.0;
			}
			return System.Math.Atan2(_image, _real);
		}
		set
		{
			double modulus = Modulus;
			_real = System.Math.Cos(value) * modulus;
			_image = System.Math.Sin(value) * modulus;
		}
	}

	public ComplexD Conjugate
	{
		get
		{
			return new ComplexD(_real, 0.0 - _image);
		}
		set
		{
			this = value.Conjugate;
		}
	}

	public ComplexD(double double_0, double double_1)
	{
		_real = double_0;
		_image = double_1;
	}

	public ComplexD(ComplexD complexD_0)
	{
		_real = complexD_0.Real;
		_image = complexD_0.Imaginary;
	}

	object ICloneable.Clone()
	{
		return new ComplexD(this);
	}

	public ComplexD Clone()
	{
		return new ComplexD(this);
	}

	public static ComplexD Parse(string string_0)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new ComplexD(double.Parse(match.Result("${real}")), double.Parse(match.Result("${imaginary}")));
	}

	public static bool TryParse(string string_0, out ComplexD complexD_0)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(string_0);
		if (match.Success)
		{
			complexD_0 = new ComplexD(double.Parse(match.Result("${real}")), double.Parse(match.Result("${imaginary}")));
			return true;
		}
		complexD_0 = Zero;
		return false;
	}

	public static ComplexD Add(ComplexD complexD_0, ComplexD complexD_1)
	{
		return new ComplexD(complexD_0.Real + complexD_1.Real, complexD_0.Imaginary + complexD_1.Imaginary);
	}

	public static ComplexD Add(ComplexD complexD_0, double double_0)
	{
		return new ComplexD(complexD_0.Real + double_0, complexD_0.Imaginary);
	}

	public static void Add(ComplexD complexD_0, ComplexD complexD_1, ref ComplexD complexD_2)
	{
		complexD_2.Real = complexD_0.Real + complexD_1.Real;
		complexD_2.Imaginary = complexD_0.Imaginary + complexD_1.Imaginary;
	}

	public static void Add(ComplexD complexD_0, double double_0, ref ComplexD complexD_1)
	{
		complexD_1.Real = complexD_0.Real + double_0;
		complexD_1.Imaginary = complexD_0.Imaginary;
	}

	public static ComplexD Subtract(ComplexD complexD_0, ComplexD complexD_1)
	{
		return new ComplexD(complexD_0.Real - complexD_1.Real, complexD_0.Imaginary - complexD_1.Imaginary);
	}

	public static ComplexD Subtract(ComplexD complexD_0, double double_0)
	{
		return new ComplexD(complexD_0.Real - double_0, complexD_0.Imaginary);
	}

	public static ComplexD Subtract(double double_0, ComplexD complexD_0)
	{
		return new ComplexD(double_0 - complexD_0.Real, complexD_0.Imaginary);
	}

	public static void Subtract(ComplexD complexD_0, ComplexD complexD_1, ref ComplexD complexD_2)
	{
		complexD_2.Real = complexD_0.Real - complexD_1.Real;
		complexD_2.Imaginary = complexD_0.Imaginary - complexD_1.Imaginary;
	}

	public static void Subtract(ComplexD complexD_0, double double_0, ref ComplexD complexD_1)
	{
		complexD_1.Real = complexD_0.Real - double_0;
		complexD_1.Imaginary = complexD_0.Imaginary;
	}

	public static void Subtract(double double_0, ComplexD complexD_0, ref ComplexD complexD_1)
	{
		complexD_1.Real = double_0 - complexD_0.Real;
		complexD_1.Imaginary = complexD_0.Imaginary;
	}

	public static ComplexD Multiply(ComplexD complexD_0, ComplexD complexD_1)
	{
		double real = complexD_0.Real;
		double imaginary = complexD_0.Imaginary;
		double real2 = complexD_1.Real;
		double imaginary2 = complexD_1.Imaginary;
		return new ComplexD(real * real2 - imaginary * imaginary2, real * imaginary2 + imaginary * real2);
	}

	public static ComplexD Multiply(ComplexD complexD_0, double double_0)
	{
		return new ComplexD(complexD_0.Real * double_0, complexD_0.Imaginary * double_0);
	}

	public static void Multiply(ComplexD complexD_0, ComplexD complexD_1, ref ComplexD complexD_2)
	{
		double real = complexD_0.Real;
		double imaginary = complexD_0.Imaginary;
		double real2 = complexD_1.Real;
		double imaginary2 = complexD_1.Imaginary;
		complexD_2.Real = real * real2 - imaginary * imaginary2;
		complexD_2.Imaginary = real * imaginary2 + imaginary * real2;
	}

	public static void Multiply(ComplexD complexD_0, double double_0, ref ComplexD complexD_1)
	{
		complexD_1.Real = complexD_0.Real * double_0;
		complexD_1.Imaginary = complexD_0.Imaginary * double_0;
	}

	public static ComplexD Divide(ComplexD complexD_0, ComplexD complexD_1)
	{
		double real = complexD_0.Real;
		double imaginary = complexD_0.Imaginary;
		double real2 = complexD_1.Real;
		double imaginary2 = complexD_1.Imaginary;
		double num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0.0)
		{
			throw new DivideByZeroException();
		}
		double num2 = 1.0 / num;
		return new ComplexD((real * real2 + imaginary * imaginary2) * num2, (imaginary * real2 - real * imaginary2) * num2);
	}

	public static ComplexD Divide(ComplexD complexD_0, double double_0)
	{
		if (double_0 == 0.0)
		{
			throw new DivideByZeroException();
		}
		return new ComplexD(complexD_0.Real / double_0, complexD_0.Imaginary / double_0);
	}

	public static ComplexD Divide(double double_0, ComplexD complexD_0)
	{
		if (complexD_0.Real == 0.0 || complexD_0.Imaginary == 0.0)
		{
			throw new DivideByZeroException();
		}
		return new ComplexD(double_0 / complexD_0.Real, double_0 / complexD_0.Imaginary);
	}

	public static void Divide(ComplexD complexD_0, ComplexD complexD_1, ref ComplexD complexD_2)
	{
		double real = complexD_0.Real;
		double imaginary = complexD_0.Imaginary;
		double real2 = complexD_1.Real;
		double imaginary2 = complexD_1.Imaginary;
		double num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0.0)
		{
			throw new DivideByZeroException();
		}
		double num2 = 1.0 / num;
		complexD_2.Real = (real * real2 + imaginary * imaginary2) * num2;
		complexD_2.Imaginary = (imaginary * real2 - real * imaginary2) * num2;
	}

	public static void Divide(ComplexD complexD_0, double double_0, ref ComplexD complexD_1)
	{
		if (double_0 == 0.0)
		{
			throw new DivideByZeroException();
		}
		complexD_1.Real = complexD_0.Real / double_0;
		complexD_1.Imaginary = complexD_0.Imaginary / double_0;
	}

	public static void Divide(double double_0, ComplexD complexD_0, ref ComplexD complexD_1)
	{
		if (complexD_0.Real == 0.0 || complexD_0.Imaginary == 0.0)
		{
			throw new DivideByZeroException();
		}
		complexD_1.Real = double_0 / complexD_0.Real;
		complexD_1.Imaginary = double_0 / complexD_0.Imaginary;
	}

	public static ComplexD Negate(ComplexD complexD_0)
	{
		return new ComplexD(0.0 - complexD_0.Real, 0.0 - complexD_0.Imaginary);
	}

	public static bool ApproxEqual(ComplexD complexD_0, ComplexD complexD_1)
	{
		return ApproxEqual(complexD_0, complexD_1, 8.881784197001252E-16);
	}

	public static bool ApproxEqual(ComplexD complexD_0, ComplexD complexD_1, double double_0)
	{
		if (System.Math.Abs(complexD_0.Real - complexD_1.Real) <= double_0)
		{
			return System.Math.Abs(complexD_0.Imaginary - complexD_1.Imaginary) <= double_0;
		}
		return false;
	}

	public static ComplexD Sqrt(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.Real == 0.0 && complexD_0.Imaginary == 0.0)
		{
			return zero;
		}
		if (complexD_0.IsReal)
		{
			zero.Real = ((complexD_0.Real <= 0.0) ? System.Math.Sqrt(0.0 - complexD_0.Real) : System.Math.Sqrt(complexD_0.Real));
			zero.Imaginary = 0.0;
		}
		else
		{
			double modulus = complexD_0.Modulus;
			zero.Real = System.Math.Sqrt(0.5 * (modulus + complexD_0.Real));
			zero.Imaginary = System.Math.Sqrt(0.5 * (modulus - complexD_0.Real));
			if (complexD_0.Imaginary < 0.0)
			{
				zero.Imaginary = 0.0 - zero.Imaginary;
			}
		}
		return zero;
	}

	public static ComplexD Log(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.Real > 0.0 && complexD_0.Imaginary == 0.0)
		{
			zero.Real = System.Math.Log(complexD_0.Real);
			zero.Imaginary = 0.0;
		}
		else if (complexD_0.Real == 0.0)
		{
			if (complexD_0.Imaginary <= 0.0)
			{
				zero.Real = System.Math.Log(0.0 - complexD_0.Imaginary);
				zero.Imaginary = -System.Math.PI / 2.0;
			}
			else
			{
				zero.Real = System.Math.Log(complexD_0.Imaginary);
				zero.Imaginary = System.Math.PI / 2.0;
			}
		}
		else
		{
			zero.Real = System.Math.Log(complexD_0.Modulus);
			zero.Imaginary = System.Math.Atan2(complexD_0.Imaginary, complexD_0.Real);
		}
		return zero;
	}

	public static ComplexD Exp(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		double num = System.Math.Exp(complexD_0.Real);
		zero.Real = num * System.Math.Cos(complexD_0.Imaginary);
		zero.Imaginary = num * System.Math.Sin(complexD_0.Imaginary);
		return zero;
	}

	public static ComplexD Pow(ComplexD complexD_0, ComplexD complexD_1)
	{
		return Exp(Multiply(complexD_1, Log(complexD_0)));
	}

	public static ComplexD Square(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(complexD_0.Real * complexD_0.Real, 0.0);
		}
		double real = complexD_0.Real;
		double imaginary = complexD_0.Imaginary;
		return new ComplexD(real * real - imaginary * imaginary, 2.0 * real * imaginary);
	}

	public static ComplexD Sin(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.IsReal)
		{
			zero.Real = System.Math.Sin(complexD_0.Real);
			zero.Imaginary = 0.0;
		}
		else
		{
			zero.Real = System.Math.Sin(complexD_0.Real) * System.Math.Cosh(complexD_0.Imaginary);
			zero.Imaginary = System.Math.Cos(complexD_0.Real) * System.Math.Sinh(complexD_0.Imaginary);
		}
		return zero;
	}

	public static ComplexD Cos(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.IsReal)
		{
			zero.Real = System.Math.Cos(complexD_0.Real);
			zero.Imaginary = 0.0;
		}
		else
		{
			zero.Real = System.Math.Cos(complexD_0.Real) * System.Math.Cosh(complexD_0.Imaginary);
			zero.Imaginary = (0.0 - System.Math.Sin(complexD_0.Real)) * System.Math.Sinh(complexD_0.Imaginary);
		}
		return zero;
	}

	public static ComplexD Tan(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.IsReal)
		{
			zero.Real = System.Math.Tan(complexD_0.Real);
			zero.Imaginary = 0.0;
		}
		else
		{
			double num = System.Math.Cos(complexD_0.Real);
			double num2 = System.Math.Sinh(complexD_0.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = System.Math.Sin(complexD_0.Real) * num / num3;
			zero.Imaginary = num2 * System.Math.Cosh(complexD_0.Imaginary) / num3;
		}
		return zero;
	}

	public static ComplexD Cot(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.IsReal)
		{
			zero.Real = MathFunctions.Cot(complexD_0.Real);
		}
		else
		{
			double num = System.Math.Sin(complexD_0.Real);
			double num2 = System.Math.Sinh(complexD_0.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = num * System.Math.Cos(complexD_0.Real) / num3;
			zero.Imaginary = (0.0 - num2) * System.Math.Cosh(complexD_0.Imaginary) / num3;
		}
		return zero;
	}

	public static ComplexD Sec(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.IsReal)
		{
			zero.Real = MathFunctions.Sec(complexD_0.Real);
		}
		else
		{
			double num = MathFunctions.Cos(complexD_0.Real);
			double num2 = MathFunctions.Sinh(complexD_0.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = num * MathFunctions.Cosh(complexD_0.Imaginary) / num3;
			zero.Imaginary = MathFunctions.Sin(complexD_0.Real) * num2 / num3;
		}
		return zero;
	}

	public static ComplexD Csc(ComplexD complexD_0)
	{
		ComplexD zero = Zero;
		if (complexD_0.IsReal)
		{
			zero.Real = MathFunctions.Csc(complexD_0.Real);
		}
		else
		{
			double num = MathFunctions.Sin(complexD_0.Real);
			double num2 = MathFunctions.Sinh(complexD_0.Imaginary);
			double num3 = num * num + num2 * num2;
			zero.Real = num * MathFunctions.Cosh(complexD_0.Imaginary) / num3;
			zero.Imaginary = (0.0 - MathFunctions.Cos(complexD_0.Real)) * num2 / num3;
		}
		return zero;
	}

	public static ComplexD Asin(ComplexD complexD_0)
	{
		ComplexD complexD_ = Subtract(1.0, Square(complexD_0));
		complexD_ = Sqrt(complexD_);
		complexD_ = Add(complexD_, Multiply(I, complexD_0));
		complexD_ = Log(complexD_);
		return Multiply(Negate(I), complexD_);
	}

	public static ComplexD Acos(ComplexD complexD_0)
	{
		ComplexD complexD_ = Subtract(1.0, Square(complexD_0));
		complexD_ = Sqrt(complexD_);
		complexD_ = Multiply(I, complexD_);
		complexD_ = Add(complexD_0, complexD_);
		complexD_ = Log(complexD_);
		return Multiply(Negate(I), complexD_);
	}

	public static ComplexD Atan(ComplexD complexD_0)
	{
		ComplexD complexD = new ComplexD(0.0 - complexD_0.Imaginary, complexD_0.Real);
		return Multiply(new ComplexD(0.0, 0.5), Subtract(Log(Subtract(1.0, complexD)), Log(1.0 + complexD)));
	}

	public static ComplexD Acot(ComplexD complexD_0)
	{
		ComplexD complexD = new ComplexD(0.0 - complexD_0.Imaginary, complexD_0.Real);
		return Add(Multiply(new ComplexD(0.0, 0.5), Subtract(Log(1.0 + complexD), Log(Subtract(1.0, complexD)))), System.Math.PI / 2.0);
	}

	public static ComplexD Asec(ComplexD complexD_0)
	{
		ComplexD complexD_ = Divide(1.0, complexD_0);
		return Multiply(Negate(I), Log(Add(complexD_, Multiply(I, Sqrt(Subtract(1.0, Square(complexD_)))))));
	}

	public static ComplexD Acsc(ComplexD complexD_0)
	{
		ComplexD complexD = Divide(1.0, complexD_0);
		return Multiply(Negate(I), Log(Add(Multiply(I, complexD), Sqrt(Subtract(1.0, Square(complexD))))));
	}

	public static ComplexD Sinh(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(System.Math.Sinh(complexD_0.Real), 0.0);
		}
		return new ComplexD(System.Math.Sinh(complexD_0.Real) * System.Math.Cos(complexD_0.Imaginary), System.Math.Cosh(complexD_0.Real) * System.Math.Sin(complexD_0.Imaginary));
	}

	public static ComplexD Cosh(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(System.Math.Cosh(complexD_0.Real), 0.0);
		}
		return new ComplexD(System.Math.Cosh(complexD_0.Real) * System.Math.Cos(complexD_0.Imaginary), System.Math.Sinh(complexD_0.Real) * System.Math.Sin(complexD_0.Imaginary));
	}

	public static ComplexD Tanh(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(System.Math.Tanh(complexD_0.Real), 0.0);
		}
		double num = System.Math.Cos(complexD_0.Imaginary);
		double num2 = System.Math.Sinh(complexD_0.Real);
		double num3 = num * num + num2 * num2;
		return new ComplexD(num2 * System.Math.Cosh(complexD_0.Real) / num3, num * System.Math.Sin(complexD_0.Imaginary) / num3);
	}

	public static ComplexD Coth(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(MathFunctions.Coth(complexD_0.Real), 0.0);
		}
		double num = 0.0 - System.Math.Sin(complexD_0.Imaginary);
		double num2 = System.Math.Sinh(complexD_0.Real);
		double num3 = num * num + num2 * num2;
		return new ComplexD(num2 * System.Math.Cosh(complexD_0.Real) / num3, num * System.Math.Cos(complexD_0.Imaginary) / num3);
	}

	public static ComplexD Sech(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(MathFunctions.Sech(complexD_0.Real), 0.0);
		}
		ComplexD complexD = Exp(complexD_0);
		return Divide(2.0 * complexD, Add(Square(complexD), 1.0));
	}

	public static ComplexD Csch(ComplexD complexD_0)
	{
		if (complexD_0.IsReal)
		{
			return new ComplexD(MathFunctions.Csch(complexD_0.Real), 0.0);
		}
		ComplexD complexD = Exp(complexD_0);
		return Divide(2.0 * complexD, Subtract(Square(complexD), 1.0));
	}

	public static ComplexD Asinh(ComplexD complexD_0)
	{
		ComplexD complexD_ = Sqrt(Add(Square(complexD_0), 1.0));
		return Log(Add(complexD_0, complexD_));
	}

	public static ComplexD Acosh(ComplexD complexD_0)
	{
		ComplexD complexD_ = Multiply(Sqrt(Subtract(complexD_0, 1.0)), Sqrt(Add(complexD_0, 1.0)));
		complexD_ = Add(complexD_0, complexD_);
		return Log(complexD_);
	}

	public static ComplexD Atanh(ComplexD complexD_0)
	{
		return 0.5 * Subtract(Log(1.0 + complexD_0), Log(Subtract(1.0, complexD_0)));
	}

	public static ComplexD Acoth(ComplexD complexD_0)
	{
		return 0.5 * Subtract(Log(Add(complexD_0, 1.0)), Log(Subtract(complexD_0, 1.0)));
	}

	public static ComplexD Asech(ComplexD complexD_0)
	{
		ComplexD complexD_ = Divide(1.0, complexD_0);
		return Log(Add(complexD_, Multiply(Sqrt(Subtract(complexD_, 1.0)), Sqrt(Add(complexD_, 1.0)))));
	}

	public static ComplexD Acsch(ComplexD complexD_0)
	{
		ComplexD complexD_ = Divide(1.0, complexD_0);
		return Log(Add(complexD_, Multiply(Square(Subtract(complexD_, 1.0)), Square(Add(complexD_, 1.0)))));
	}

	public void Normalize()
	{
		double modulus = Modulus;
		if (modulus == 0.0)
		{
			throw new DivideByZeroException("Can not normalize a complex number that is zero.");
		}
		_real /= modulus;
		_image /= modulus;
	}

	public override int GetHashCode()
	{
		return _real.GetHashCode() ^ _image.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is ComplexD complexD)
		{
			if (Real == complexD.Real)
			{
				return Imaginary == complexD.Imaginary;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", _real, _image);
	}

	public static bool operator ==(ComplexD complexD_0, ComplexD complexD_1)
	{
		return object.Equals(complexD_0, complexD_1);
	}

	public static bool operator !=(ComplexD complexD_0, ComplexD complexD_1)
	{
		return !object.Equals(complexD_0, complexD_1);
	}

	public static ComplexD operator -(ComplexD complexD_0)
	{
		return Negate(complexD_0);
	}

	public static ComplexD operator +(ComplexD complexD_0, ComplexD complexD_1)
	{
		return Add(complexD_0, complexD_1);
	}

	public static ComplexD operator +(ComplexD complexD_0, double double_0)
	{
		return Add(complexD_0, double_0);
	}

	public static ComplexD operator +(double double_0, ComplexD complexD_0)
	{
		return Add(complexD_0, double_0);
	}

	public static ComplexD operator -(ComplexD complexD_0, ComplexD complexD_1)
	{
		return Subtract(complexD_0, complexD_1);
	}

	public static ComplexD operator -(ComplexD complexD_0, double double_0)
	{
		return Subtract(complexD_0, double_0);
	}

	public static ComplexD operator -(double double_0, ComplexD complexD_0)
	{
		return Subtract(double_0, complexD_0);
	}

	public static ComplexD operator *(ComplexD complexD_0, ComplexD complexD_1)
	{
		return Multiply(complexD_0, complexD_1);
	}

	public static ComplexD operator *(double double_0, ComplexD complexD_0)
	{
		return Multiply(complexD_0, double_0);
	}

	public static ComplexD operator *(ComplexD complexD_0, double double_0)
	{
		return Multiply(complexD_0, double_0);
	}

	public static ComplexD operator /(ComplexD complexD_0, ComplexD complexD_1)
	{
		return Divide(complexD_0, complexD_1);
	}

	public static ComplexD operator /(ComplexD complexD_0, double double_0)
	{
		return Divide(complexD_0, double_0);
	}

	public static ComplexD operator /(double double_0, ComplexD complexD_0)
	{
		return Divide(double_0, complexD_0);
	}

	static ComplexD()
	{
		Zero = new ComplexD(0.0, 0.0);
		One = new ComplexD(1.0, 0.0);
		I = new ComplexD(0.0, 1.0);
	}
}
