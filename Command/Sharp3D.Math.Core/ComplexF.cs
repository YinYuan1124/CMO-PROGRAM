using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
public struct ComplexF : ICloneable
{
	private float _real;

	private float _image;

	public static readonly ComplexF Zero;

	public static readonly ComplexF One;

	public static readonly ComplexF I;

	public float Real
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

	public float Imaginary
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

	public bool IsReal => (double)_image == 0.0;

	public bool IsImaginary => (double)_real == 0.0;

	public float Modulus => (float)System.Math.Sqrt(_real * _real + _image * _image);

	public float ModulusSquared => _real * _real + _image * _image;

	public float Argument
	{
		get
		{
			if ((double)_image == 0.0 && (double)_real < 0.0)
			{
				return (float)System.Math.PI;
			}
			if ((double)_image == 0.0 && (double)_real >= 0.0)
			{
				return 0f;
			}
			return (float)System.Math.Atan2(_image, _real);
		}
		set
		{
			float modulus = Modulus;
			_real = (float)System.Math.Cos(value) * modulus;
			_image = (float)System.Math.Sin(value) * modulus;
		}
	}

	public ComplexF Conjugate
	{
		get
		{
			return new ComplexF(_real, 0f - _image);
		}
		set
		{
			this = value.Conjugate;
		}
	}

	public ComplexF(float float_0, float float_1)
	{
		_real = float_0;
		_image = float_1;
	}

	public ComplexF(ComplexF complexF_0)
	{
		_real = complexF_0.Real;
		_image = complexF_0.Imaginary;
	}

	object ICloneable.Clone()
	{
		return new ComplexF(this);
	}

	public ComplexF Clone()
	{
		return new ComplexF(this);
	}

	public static ComplexF Parse(string string_0)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new ComplexF(float.Parse(match.Result("${real}")), float.Parse(match.Result("${imaginary}")));
	}

	public static bool TryParse(string string_0, out ComplexF complexF_0)
	{
		Match match = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None).Match(string_0);
		if (match.Success)
		{
			complexF_0 = new ComplexF(float.Parse(match.Result("${real}")), float.Parse(match.Result("${imaginary}")));
			return true;
		}
		complexF_0 = Zero;
		return false;
	}

	public static ComplexF Add(ComplexF complexF_0, ComplexF complexF_1)
	{
		return new ComplexF(complexF_0.Real + complexF_1.Real, complexF_0.Imaginary + complexF_1.Imaginary);
	}

	public static ComplexF Add(ComplexF complexF_0, float float_0)
	{
		return new ComplexF(complexF_0.Real + float_0, complexF_0.Imaginary);
	}

	public static void Add(ComplexF complexF_0, ComplexF complexF_1, ref ComplexF complexF_2)
	{
		complexF_2.Real = complexF_0.Real + complexF_1.Real;
		complexF_2.Imaginary = complexF_0.Imaginary + complexF_1.Imaginary;
	}

	public static void Add(ComplexF complexF_0, float float_0, ref ComplexF complexF_1)
	{
		complexF_1.Real = complexF_0.Real + float_0;
		complexF_1.Imaginary = complexF_0.Imaginary;
	}

	public static ComplexF Subtract(ComplexF complexF_0, ComplexF complexF_1)
	{
		return new ComplexF(complexF_0.Real - complexF_1.Real, complexF_0.Imaginary - complexF_1.Imaginary);
	}

	public static ComplexF Subtract(ComplexF complexF_0, float float_0)
	{
		return new ComplexF(complexF_0.Real - float_0, complexF_0.Imaginary);
	}

	public static ComplexF Subtract(float float_0, ComplexF complexF_0)
	{
		return new ComplexF(float_0 - complexF_0.Real, complexF_0.Imaginary);
	}

	public static void Subtract(ComplexF complexF_0, ComplexF complexF_1, ref ComplexF complexF_2)
	{
		complexF_2.Real = complexF_0.Real - complexF_1.Real;
		complexF_2.Imaginary = complexF_0.Imaginary - complexF_1.Imaginary;
	}

	public static void Subtract(ComplexF complexF_0, float float_0, ref ComplexF complexF_1)
	{
		complexF_1.Real = complexF_0.Real - float_0;
		complexF_1.Imaginary = complexF_0.Imaginary;
	}

	public static void Subtract(float float_0, ComplexF complexF_0, ref ComplexF complexF_1)
	{
		complexF_1.Real = float_0 - complexF_0.Real;
		complexF_1.Imaginary = complexF_0.Imaginary;
	}

	public static ComplexF Multiply(ComplexF complexF_0, ComplexF complexF_1)
	{
		float real = complexF_0.Real;
		float imaginary = complexF_0.Imaginary;
		float real2 = complexF_1.Real;
		float imaginary2 = complexF_1.Imaginary;
		return new ComplexF(real * real2 - imaginary * imaginary2, real * imaginary2 + imaginary * real2);
	}

	public static ComplexF Multiply(ComplexF complexF_0, float float_0)
	{
		return new ComplexF(complexF_0.Real * float_0, complexF_0.Imaginary * float_0);
	}

	public static void Multiply(ComplexF complexF_0, ComplexF complexF_1, ref ComplexF complexF_2)
	{
		float real = complexF_0.Real;
		float imaginary = complexF_0.Imaginary;
		float real2 = complexF_1.Real;
		float imaginary2 = complexF_1.Imaginary;
		complexF_2.Real = real * real2 - imaginary * imaginary2;
		complexF_2.Imaginary = real * imaginary2 + imaginary * real2;
	}

	public static void Multiply(ComplexF complexF_0, float float_0, ref ComplexF complexF_1)
	{
		complexF_1.Real = complexF_0.Real * float_0;
		complexF_1.Imaginary = complexF_0.Imaginary * float_0;
	}

	public static ComplexF Divide(ComplexF complexF_0, ComplexF complexF_1)
	{
		float real = complexF_0.Real;
		float imaginary = complexF_0.Imaginary;
		float real2 = complexF_1.Real;
		float imaginary2 = complexF_1.Imaginary;
		float num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0f)
		{
			throw new DivideByZeroException();
		}
		float num2 = 1f / num;
		return new ComplexF((real * real2 + imaginary * imaginary2) * num2, (imaginary * real2 - real * imaginary2) * num2);
	}

	public static ComplexF Divide(ComplexF complexF_0, float float_0)
	{
		if (float_0 == 0f)
		{
			throw new DivideByZeroException();
		}
		return new ComplexF(complexF_0.Real / float_0, complexF_0.Imaginary / float_0);
	}

	public static ComplexF Divide(float float_0, ComplexF complexF_0)
	{
		if (complexF_0.Real == 0f || complexF_0.Imaginary == 0f)
		{
			throw new DivideByZeroException();
		}
		return new ComplexF(float_0 / complexF_0.Real, float_0 / complexF_0.Imaginary);
	}

	public static void Divide(ComplexF complexF_0, ComplexF complexF_1, ref ComplexF complexF_2)
	{
		float real = complexF_0.Real;
		float imaginary = complexF_0.Imaginary;
		float real2 = complexF_1.Real;
		float imaginary2 = complexF_1.Imaginary;
		float num = real2 * real2 + imaginary2 * imaginary2;
		if (num == 0f)
		{
			throw new DivideByZeroException();
		}
		float num2 = 1f / num;
		complexF_2.Real = (real * real2 + imaginary * imaginary2) * num2;
		complexF_2.Imaginary = (imaginary * real2 - real * imaginary2) * num2;
	}

	public static void Divide(ComplexF complexF_0, float float_0, ref ComplexF complexF_1)
	{
		if (float_0 == 0f)
		{
			throw new DivideByZeroException();
		}
		complexF_1.Real = complexF_0.Real / float_0;
		complexF_1.Imaginary = complexF_0.Imaginary / float_0;
	}

	public static void Divide(float float_0, ComplexF complexF_0, ref ComplexF complexF_1)
	{
		if (complexF_0.Real == 0f || complexF_0.Imaginary == 0f)
		{
			throw new DivideByZeroException();
		}
		complexF_1.Real = float_0 / complexF_0.Real;
		complexF_1.Imaginary = float_0 / complexF_0.Imaginary;
	}

	public static ComplexF Negate(ComplexF complexF_0)
	{
		return new ComplexF(0f - complexF_0.Real, 0f - complexF_0.Imaginary);
	}

	public static bool ApproxEqual(ComplexF complexF_0, ComplexF complexF_1)
	{
		return ApproxEqual(complexF_0, complexF_1, 4.7683716E-07f);
	}

	public static bool ApproxEqual(ComplexF complexF_0, ComplexF complexF_1, float float_0)
	{
		if (System.Math.Abs(complexF_0.Real - complexF_1.Real) <= float_0)
		{
			return System.Math.Abs(complexF_0.Imaginary - complexF_1.Imaginary) <= float_0;
		}
		return false;
	}

	public static ComplexF Sqrt(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.Real == 0f && complexF_0.Imaginary == 0f)
		{
			return zero;
		}
		if (complexF_0.IsReal)
		{
			zero.Real = ((complexF_0.Real <= 0f) ? ((float)System.Math.Sqrt(0f - complexF_0.Real)) : ((float)System.Math.Sqrt(complexF_0.Real)));
			zero.Imaginary = 0f;
		}
		else
		{
			float modulus = complexF_0.Modulus;
			zero.Real = (float)System.Math.Sqrt(0.5f * (modulus + complexF_0.Real));
			zero.Imaginary = (float)System.Math.Sqrt(0.5f * (modulus - complexF_0.Real));
			if (complexF_0.Imaginary < 0f)
			{
				zero.Imaginary = 0f - zero.Imaginary;
			}
		}
		return zero;
	}

	public static ComplexF Log(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if ((double)complexF_0.Real > 0.0 && (double)complexF_0.Imaginary == 0.0)
		{
			zero.Real = (float)System.Math.Log(complexF_0.Real);
			zero.Imaginary = 0f;
		}
		else if (complexF_0.Real == 0f)
		{
			if (complexF_0.Imaginary <= 0f)
			{
				zero.Real = (float)System.Math.Log(0f - complexF_0.Imaginary);
				zero.Imaginary = -(float)System.Math.PI / 2f;
			}
			else
			{
				zero.Real = (float)System.Math.Log(complexF_0.Imaginary);
				zero.Imaginary = (float)System.Math.PI / 2f;
			}
		}
		else
		{
			zero.Real = (float)System.Math.Log(complexF_0.Modulus);
			zero.Imaginary = (float)System.Math.Atan2(complexF_0.Imaginary, complexF_0.Real);
		}
		return zero;
	}

	public static ComplexF Exp(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		float num = (float)System.Math.Exp(complexF_0.Real);
		zero.Real = num * (float)System.Math.Cos(complexF_0.Imaginary);
		zero.Imaginary = num * (float)System.Math.Sin(complexF_0.Imaginary);
		return zero;
	}

	public static ComplexF Pow(ComplexF complexF_0, ComplexF complexF_1)
	{
		return Exp(Multiply(complexF_1, Log(complexF_0)));
	}

	public static ComplexF Square(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF(complexF_0.Real * complexF_0.Real, 0f);
		}
		float real = complexF_0.Real;
		float imaginary = complexF_0.Imaginary;
		return new ComplexF(real * real - imaginary * imaginary, 2f * real * imaginary);
	}

	public static ComplexF Sin(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.IsReal)
		{
			zero.Real = (float)System.Math.Sin(complexF_0.Real);
			zero.Imaginary = 0f;
		}
		else
		{
			zero.Real = (float)(System.Math.Sin(complexF_0.Real) * System.Math.Cosh(complexF_0.Imaginary));
			zero.Imaginary = (float)(System.Math.Cos(complexF_0.Real) * System.Math.Sinh(complexF_0.Imaginary));
		}
		return zero;
	}

	public static ComplexF Cos(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.IsReal)
		{
			zero.Real = (float)System.Math.Cos(complexF_0.Real);
			zero.Imaginary = 0f;
		}
		else
		{
			zero.Real = (float)(System.Math.Cos(complexF_0.Real) * System.Math.Cosh(complexF_0.Imaginary));
			zero.Imaginary = (float)((0.0 - System.Math.Sin(complexF_0.Real)) * System.Math.Sinh(complexF_0.Imaginary));
		}
		return zero;
	}

	public static ComplexF Tan(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.IsReal)
		{
			zero.Real = (float)System.Math.Tan(complexF_0.Real);
			zero.Imaginary = 0f;
		}
		else
		{
			float num = (float)System.Math.Cos(complexF_0.Real);
			float num2 = (float)System.Math.Sinh(complexF_0.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = (float)System.Math.Sin(complexF_0.Real) * num / num3;
			zero.Imaginary = num2 * (float)System.Math.Cosh(complexF_0.Imaginary) / num3;
		}
		return zero;
	}

	public static ComplexF Cot(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.IsReal)
		{
			zero.Real = MathFunctions.Cot(complexF_0.Real);
		}
		else
		{
			float num = (float)System.Math.Sin(complexF_0.Real);
			float num2 = (float)System.Math.Sinh(complexF_0.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = num * (float)System.Math.Cos(complexF_0.Real) / num3;
			zero.Imaginary = (0f - num2) * (float)System.Math.Cosh(complexF_0.Imaginary) / num3;
		}
		return zero;
	}

	public static ComplexF Sec(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.IsReal)
		{
			zero.Real = MathFunctions.Sec(complexF_0.Real);
		}
		else
		{
			float num = MathFunctions.Cos(complexF_0.Real);
			float num2 = (float)MathFunctions.Sinh(complexF_0.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = num * (float)MathFunctions.Cosh(complexF_0.Imaginary) / num3;
			zero.Imaginary = MathFunctions.Sin(complexF_0.Real) * num2 / num3;
		}
		return zero;
	}

	public static ComplexF Csc(ComplexF complexF_0)
	{
		ComplexF zero = Zero;
		if (complexF_0.IsReal)
		{
			zero.Real = MathFunctions.Csc(complexF_0.Real);
		}
		else
		{
			float num = MathFunctions.Sin(complexF_0.Real);
			float num2 = (float)MathFunctions.Sinh(complexF_0.Imaginary);
			float num3 = num * num + num2 * num2;
			zero.Real = num * (float)MathFunctions.Cosh(complexF_0.Imaginary) / num3;
			zero.Imaginary = (0f - MathFunctions.Cos(complexF_0.Real)) * num2 / num3;
		}
		return zero;
	}

	public static ComplexF Asin(ComplexF complexF_0)
	{
		ComplexF complexF_ = Subtract(1f, Square(complexF_0));
		complexF_ = Sqrt(complexF_);
		complexF_ = Add(complexF_, Multiply(I, complexF_0));
		complexF_ = Log(complexF_);
		return Multiply(Negate(I), complexF_);
	}

	public static ComplexF Acos(ComplexF complexF_0)
	{
		ComplexF complexF_ = Subtract(1f, Square(complexF_0));
		complexF_ = Sqrt(complexF_);
		complexF_ = Multiply(I, complexF_);
		complexF_ = Add(complexF_0, complexF_);
		complexF_ = Log(complexF_);
		return Multiply(Negate(I), complexF_);
	}

	public static ComplexF Atan(ComplexF complexF_0)
	{
		ComplexF complexF = new ComplexF(0f - complexF_0.Imaginary, complexF_0.Real);
		return Multiply(new ComplexF(0f, 0.5f), Subtract(Log(Subtract(1f, complexF)), Log(1f + complexF)));
	}

	public static ComplexF Acot(ComplexF complexF_0)
	{
		ComplexF complexF = new ComplexF(0f - complexF_0.Imaginary, complexF_0.Real);
		return Add(Multiply(new ComplexF(0f, 0.5f), Subtract(Log(1f + complexF), Log(Subtract(1f, complexF)))), (float)System.Math.PI / 2f);
	}

	public static ComplexF Asec(ComplexF complexF_0)
	{
		ComplexF complexF_ = Divide(1f, complexF_0);
		return Multiply(Negate(I), Log(Add(complexF_, Multiply(I, Sqrt(Subtract(1f, Square(complexF_)))))));
	}

	public static ComplexF Acsc(ComplexF complexF_0)
	{
		ComplexF complexF = Divide(1f, complexF_0);
		return Multiply(Negate(I), Log(Add(Multiply(I, complexF), Sqrt(Subtract(1f, Square(complexF))))));
	}

	public static ComplexF Sinh(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF((float)System.Math.Sinh(complexF_0.Real), 0f);
		}
		return new ComplexF((float)(System.Math.Sinh(complexF_0.Real) * System.Math.Cos(complexF_0.Imaginary)), (float)(System.Math.Cosh(complexF_0.Real) * System.Math.Sin(complexF_0.Imaginary)));
	}

	public static ComplexF Cosh(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF((float)System.Math.Cosh(complexF_0.Real), 0f);
		}
		return new ComplexF((float)(System.Math.Cosh(complexF_0.Real) * System.Math.Cos(complexF_0.Imaginary)), (float)(System.Math.Sinh(complexF_0.Real) * System.Math.Sin(complexF_0.Imaginary)));
	}

	public static ComplexF Tanh(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF((float)System.Math.Tanh(complexF_0.Real), 0f);
		}
		float num = (float)System.Math.Cos(complexF_0.Imaginary);
		float num2 = (float)System.Math.Sinh(complexF_0.Real);
		float num3 = num * num + num2 * num2;
		return new ComplexF(num2 * (float)System.Math.Cosh(complexF_0.Real) / num3, num * (float)System.Math.Sin(complexF_0.Imaginary) / num3);
	}

	public static ComplexF Coth(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF((float)MathFunctions.Coth(complexF_0.Real), 0f);
		}
		float num = 0f - (float)System.Math.Sin(complexF_0.Imaginary);
		float num2 = (float)System.Math.Sinh(complexF_0.Real);
		float num3 = num * num + num2 * num2;
		return new ComplexF(num2 * (float)System.Math.Cosh(complexF_0.Real) / num3, num * (float)System.Math.Cos(complexF_0.Imaginary) / num3);
	}

	public static ComplexF Sech(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF((float)MathFunctions.Sech(complexF_0.Real), 0f);
		}
		ComplexF complexF = Exp(complexF_0);
		return Divide(2f * complexF, Add(Square(complexF), 1f));
	}

	public static ComplexF Csch(ComplexF complexF_0)
	{
		if (complexF_0.IsReal)
		{
			return new ComplexF((float)MathFunctions.Csch(complexF_0.Real), 0f);
		}
		ComplexF complexF = Exp(complexF_0);
		return Divide(2f * complexF, Subtract(Square(complexF), 1f));
	}

	public static ComplexF Asinh(ComplexF complexF_0)
	{
		ComplexF complexF_ = Sqrt(Add(Square(complexF_0), 1f));
		return Log(Add(complexF_0, complexF_));
	}

	public static ComplexF Acosh(ComplexF complexF_0)
	{
		ComplexF complexF_ = Multiply(Sqrt(Subtract(complexF_0, 1f)), Sqrt(Add(complexF_0, 1f)));
		complexF_ = Add(complexF_0, complexF_);
		return Log(complexF_);
	}

	public static ComplexF Atanh(ComplexF complexF_0)
	{
		return 0.5f * Subtract(Log(1f + complexF_0), Log(Subtract(1f, complexF_0)));
	}

	public static ComplexF Acoth(ComplexF complexF_0)
	{
		return 0.5f * Subtract(Log(Add(complexF_0, 1f)), Log(Subtract(complexF_0, 1f)));
	}

	public static ComplexF Asech(ComplexF complexF_0)
	{
		ComplexF complexF_ = Divide(1f, complexF_0);
		return Log(Add(complexF_, Multiply(Sqrt(Subtract(complexF_, 1f)), Sqrt(Add(complexF_, 1f)))));
	}

	public static ComplexF Acsch(ComplexF complexF_0)
	{
		ComplexF complexF_ = Divide(1f, complexF_0);
		return Log(Add(complexF_, Multiply(Square(Subtract(complexF_, 1f)), Square(Add(complexF_, 1f)))));
	}

	public void Normalize()
	{
		float modulus = Modulus;
		if (modulus == 0f)
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
		if (obj is ComplexF complexF)
		{
			if (Real == complexF.Real)
			{
				return Imaginary == complexF.Imaginary;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", _real, _image);
	}

	public static bool operator ==(ComplexF complexF_0, ComplexF complexF_1)
	{
		return object.Equals(complexF_0, complexF_1);
	}

	public static bool operator !=(ComplexF complexF_0, ComplexF complexF_1)
	{
		return !object.Equals(complexF_0, complexF_1);
	}

	public static ComplexF operator -(ComplexF complexF_0)
	{
		return Negate(complexF_0);
	}

	public static ComplexF operator +(ComplexF complexF_0, ComplexF complexF_1)
	{
		return Add(complexF_0, complexF_1);
	}

	public static ComplexF operator +(ComplexF complexF_0, float float_0)
	{
		return Add(complexF_0, float_0);
	}

	public static ComplexF operator +(float float_0, ComplexF complexF_0)
	{
		return Add(complexF_0, float_0);
	}

	public static ComplexF operator -(ComplexF complexF_0, ComplexF complexF_1)
	{
		return Subtract(complexF_0, complexF_1);
	}

	public static ComplexF operator -(ComplexF complexF_0, float float_0)
	{
		return Subtract(complexF_0, float_0);
	}

	public static ComplexF operator -(float float_0, ComplexF complexF_0)
	{
		return Subtract(float_0, complexF_0);
	}

	public static ComplexF operator *(ComplexF complexF_0, ComplexF complexF_1)
	{
		return Multiply(complexF_0, complexF_1);
	}

	public static ComplexF operator *(float float_0, ComplexF complexF_0)
	{
		return Multiply(complexF_0, float_0);
	}

	public static ComplexF operator *(ComplexF complexF_0, float float_0)
	{
		return Multiply(complexF_0, float_0);
	}

	public static ComplexF operator /(ComplexF complexF_0, ComplexF complexF_1)
	{
		return Divide(complexF_0, complexF_1);
	}

	public static ComplexF operator /(ComplexF complexF_0, float float_0)
	{
		return Divide(complexF_0, float_0);
	}

	public static ComplexF operator /(float float_0, ComplexF complexF_0)
	{
		return Divide(float_0, complexF_0);
	}

	static ComplexF()
	{
		Zero = new ComplexF(0f, 0f);
		One = new ComplexF(1f, 0f);
		I = new ComplexF(0f, 1f);
	}
}
