using System;
using System.Runtime.InteropServices;

namespace DigitalRune.Mathematics;

public static class Numeric
{
	[StructLayout(LayoutKind.Explicit)]
	private struct ComparatorPrototype
	{
		[FieldOffset(0)]
		internal float _ItemPrototype;

		[FieldOffset(0)]
		internal uint setterPrototype;
	}

	[StructLayout(LayoutKind.Explicit)]
	private struct CreatorPrototype
	{
		[FieldOffset(0)]
		internal double templatePrototype;

		[FieldOffset(0)]
		internal ulong mappingPrototype;
	}

	private static float _SingletonObject;

	private static float recordObject;

	private static double m_ExceptionObject;

	private static double m_AttrObject;

	public static float EpsilonF
	{
		get
		{
			return _SingletonObject;
		}
		set
		{
			if (value <= 0f)
			{
				throw new ArgumentOutOfRangeException("value", "The tolerance value must be greater than 0.");
			}
			_SingletonObject = value;
			recordObject = value * value;
		}
	}

	public static float EpsilonFSquared => recordObject;

	public static double EpsilonD
	{
		get
		{
			return m_ExceptionObject;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", "The epsilon tolerance value must be greater than 0.");
			}
			m_ExceptionObject = value;
			m_AttrObject = value * value;
		}
	}

	public static double EpsilonDSquared => m_AttrObject;

	public static bool AreEqual(float float_0, float float_1)
	{
		if (float_0 == float_1)
		{
			return true;
		}
		float num = _SingletonObject * (Math.Abs(float_0) + Math.Abs(float_1) + 1f);
		float num2 = float_0 - float_1;
		if (0f - num < num2)
		{
			return num2 < num;
		}
		return false;
	}

	public static bool AreEqual(double double_0, double double_1)
	{
		if (double_0 == double_1)
		{
			return true;
		}
		double num = m_ExceptionObject * (Math.Abs(double_0) + Math.Abs(double_1) + 1.0);
		double num2 = double_0 - double_1;
		if (0.0 - num < num2)
		{
			return num2 < num;
		}
		return false;
	}

	public static bool AreEqual(float float_0, float float_1, float float_2)
	{
		if (float_2 <= 0f)
		{
			throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
		}
		if (float_0 == float_1)
		{
			return true;
		}
		float num = float_0 - float_1;
		if (0f - float_2 < num)
		{
			return num < float_2;
		}
		return false;
	}

	public static bool AreEqual(double double_0, double double_1, double double_2)
	{
		if (double_2 <= 0.0)
		{
			throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
		}
		if (double_0 == double_1)
		{
			return true;
		}
		double num = double_0 - double_1;
		if (0.0 - double_2 < num)
		{
			return num < double_2;
		}
		return false;
	}

	public static bool IsLess(float float_0, float float_1)
	{
		if (float_0 < float_1)
		{
			return !AreEqual(float_0, float_1);
		}
		return false;
	}

	public static bool IsLess(float float_0, float float_1, float float_2)
	{
		if (float_0 < float_1)
		{
			return !AreEqual(float_0, float_1, float_2);
		}
		return false;
	}

	public static bool IsLess(double double_0, double double_1)
	{
		if (double_0 < double_1)
		{
			return !AreEqual(double_0, double_1);
		}
		return false;
	}

	public static bool IsLess(double double_0, double double_1, double double_2)
	{
		if (double_0 < double_1)
		{
			return !AreEqual(double_0, double_1, double_2);
		}
		return false;
	}

	public static bool IsLessOrEqual(float float_0, float float_1)
	{
		if (float_0 < float_1)
		{
			return true;
		}
		return AreEqual(float_0, float_1);
	}

	public static bool IsLessOrEqual(float float_0, float float_1, float float_2)
	{
		if (float_0 < float_1)
		{
			return true;
		}
		return AreEqual(float_0, float_1, float_2);
	}

	public static bool IsLessOrEqual(double double_0, double double_1)
	{
		if (double_0 < double_1)
		{
			return true;
		}
		return AreEqual(double_0, double_1);
	}

	public static bool IsLessOrEqual(double double_0, double double_1, double double_2)
	{
		if (double_0 < double_1)
		{
			return true;
		}
		return AreEqual(double_0, double_1, double_2);
	}

	public static bool IsGreater(float float_0, float float_1)
	{
		if (float_0 <= float_1)
		{
			return false;
		}
		return !AreEqual(float_0, float_1);
	}

	public static bool IsGreater(float float_0, float float_1, float float_2)
	{
		if (float_0 <= float_1)
		{
			return false;
		}
		return !AreEqual(float_0, float_1, float_2);
	}

	public static bool IsGreater(double double_0, double double_1)
	{
		if (double_0 <= double_1)
		{
			return false;
		}
		return !AreEqual(double_0, double_1);
	}

	public static bool IsGreater(double double_0, double double_1, double double_2)
	{
		if (double_0 <= double_1)
		{
			return false;
		}
		return !AreEqual(double_0, double_1, double_2);
	}

	public static bool IsGreaterOrEqual(float float_0, float float_1)
	{
		if (float_0 <= float_1)
		{
			return AreEqual(float_0, float_1);
		}
		return true;
	}

	public static bool IsGreaterOrEqual(float float_0, float float_1, float float_2)
	{
		if (float_0 <= float_1)
		{
			return AreEqual(float_0, float_1, float_2);
		}
		return true;
	}

	public static bool IsGreaterOrEqual(double double_0, double double_1)
	{
		if (double_0 <= double_1)
		{
			return AreEqual(double_0, double_1);
		}
		return true;
	}

	public static bool IsGreaterOrEqual(double double_0, double double_1, double double_2)
	{
		if (double_0 <= double_1)
		{
			return AreEqual(double_0, double_1, double_2);
		}
		return true;
	}

	public static float ClampToZero(float float_0)
	{
		if (IsZero(float_0))
		{
			return 0f;
		}
		return float_0;
	}

	public static float ClampToZero(float float_0, float float_1)
	{
		if (IsZero(float_0, float_1))
		{
			return 0f;
		}
		return float_0;
	}

	public static double ClampToZero(double double_0)
	{
		if (IsZero(double_0))
		{
			return 0.0;
		}
		return double_0;
	}

	public static double ClampToZero(double double_0, double double_1)
	{
		if (IsZero(double_0, double_1))
		{
			return 0.0;
		}
		return double_0;
	}

	public static bool IsZero(float float_0)
	{
		if (0f - _SingletonObject < float_0)
		{
			return float_0 < _SingletonObject;
		}
		return false;
	}

	public static bool IsZero(double double_0)
	{
		if (0.0 - m_ExceptionObject < double_0)
		{
			return double_0 < m_ExceptionObject;
		}
		return false;
	}

	public static bool IsZero(float float_0, float float_1)
	{
		if (float_1 <= 0f)
		{
			throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
		}
		if (0f - float_1 < float_0)
		{
			return float_0 < float_1;
		}
		return false;
	}

	public static bool IsZero(double double_0, double double_1)
	{
		if (double_1 <= 0.0)
		{
			throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
		}
		if (0.0 - double_1 < double_0)
		{
			return double_0 < double_1;
		}
		return false;
	}

	public static int Compare(float float_0, float float_1)
	{
		if (AreEqual(float_0, float_1))
		{
			return 0;
		}
		if (float_0 < float_1)
		{
			return -1;
		}
		return 1;
	}

	public static int Compare(double double_0, double double_1)
	{
		if (AreEqual(double_0, double_1))
		{
			return 0;
		}
		if (double_0 < double_1)
		{
			return -1;
		}
		return 1;
	}

	public static int Compare(float float_0, float float_1, float float_2)
	{
		if (AreEqual(float_0, float_1, float_2))
		{
			return 0;
		}
		if (float_0 < float_1)
		{
			return -1;
		}
		return 1;
	}

	public static int Compare(double double_0, double double_1, double double_2)
	{
		if (AreEqual(double_0, double_1, double_2))
		{
			return 0;
		}
		if (double_0 < double_1)
		{
			return -1;
		}
		return 1;
	}

	public static bool IsFiniteOrNaN(float float_0)
	{
		return !float.IsInfinity(float_0);
	}

	public static bool IsFiniteOrNaN(double double_0)
	{
		return !double.IsInfinity(double_0);
	}

	public static bool IsFinite(float float_0)
	{
		if (IsNaN(float_0))
		{
			return false;
		}
		return !float.IsInfinity(float_0);
	}

	public static bool IsFinite(double double_0)
	{
		if (IsNaN(double_0))
		{
			return false;
		}
		return !double.IsInfinity(double_0);
	}

	public static bool IsPositive(float float_0)
	{
		return 0f < float_0;
	}

	public static bool IsPositive(double double_0)
	{
		return 0.0 < double_0;
	}

	public static bool IsNegative(float float_0)
	{
		return float_0 < 0f;
	}

	public static bool IsNegative(double double_0)
	{
		return double_0 < 0.0;
	}

	public static bool IsPositiveFinite(float float_0)
	{
		if (0f < float_0)
		{
			return !float.IsPositiveInfinity(float_0);
		}
		return false;
	}

	public static bool IsPositiveFinite(double double_0)
	{
		if (0.0 < double_0)
		{
			return !double.IsPositiveInfinity(double_0);
		}
		return false;
	}

	public static bool IsNegativeFinite(float float_0)
	{
		if (float_0 < 0f)
		{
			return !float.IsNegativeInfinity(float_0);
		}
		return false;
	}

	public static bool IsNegativeFinite(double double_0)
	{
		if (double_0 < 0.0)
		{
			return !double.IsNegativeInfinity(double_0);
		}
		return false;
	}

	public static bool IsZeroOrPositiveFinite(float float_0)
	{
		if (0f <= float_0)
		{
			return !float.IsPositiveInfinity(float_0);
		}
		return false;
	}

	public static bool IsZeroOrPositiveFinite(double double_0)
	{
		if (0.0 <= double_0)
		{
			return !double.IsPositiveInfinity(double_0);
		}
		return false;
	}

	public static bool IsZeroOrNegativeFinite(float float_0)
	{
		if (float_0 <= 0f)
		{
			return !float.IsNegativeInfinity(float_0);
		}
		return false;
	}

	public static bool IsZeroOrNegativeFinite(double double_0)
	{
		if (double_0 <= 0.0)
		{
			return !double.IsNegativeInfinity(double_0);
		}
		return false;
	}

	public static bool IsNaN(float float_0)
	{
		ComparatorPrototype comparatorPrototype = default(ComparatorPrototype);
		comparatorPrototype._ItemPrototype = float_0;
		ComparatorPrototype comparatorPrototype2 = comparatorPrototype;
		uint num = comparatorPrototype2.setterPrototype & 0x7F800000u;
		uint num2 = comparatorPrototype2.setterPrototype & 0x7FFFFFu;
		if (num == 2139095040)
		{
			return num2 != 0;
		}
		return false;
	}

	public static bool IsNaN(double double_0)
	{
		CreatorPrototype creatorPrototype = default(CreatorPrototype);
		creatorPrototype.templatePrototype = double_0;
		CreatorPrototype creatorPrototype2 = creatorPrototype;
		ulong num = creatorPrototype2.mappingPrototype & 0x7FF0000000000000uL;
		ulong num2 = creatorPrototype2.mappingPrototype & 0xFFFFFFFFFFFFFuL;
		if (num == 9218868437227405312L)
		{
			return num2 != 0;
		}
		return false;
	}

	[CLSCompliant(false)]
	public static uint GetSignificantBitsUnsigned(float float_0, int int_0)
	{
		ComparatorPrototype comparatorPrototype = default(ComparatorPrototype);
		comparatorPrototype._ItemPrototype = float_0;
		return comparatorPrototype.setterPrototype >> 31 - int_0;
	}

	[CLSCompliant(false)]
	public static uint GetSignificantBitsSigned(float float_0, int int_0)
	{
		ComparatorPrototype comparatorPrototype = default(ComparatorPrototype);
		comparatorPrototype._ItemPrototype = float_0;
		ComparatorPrototype comparatorPrototype2 = comparatorPrototype;
		comparatorPrototype2.setterPrototype = SortDispatcher(comparatorPrototype2.setterPrototype);
		return comparatorPrototype2.setterPrototype >> 32 - int_0;
	}

	private static uint SortDispatcher(uint uint_0)
	{
		uint num = (0 - (uint_0 >> 31)) | 0x80000000u;
		return uint_0 ^ num;
	}

	static Numeric()
	{
		_SingletonObject = 1E-05f;
		recordObject = 9.9999994E-11f;
		m_ExceptionObject = 1E-12;
		m_AttrObject = 1E-24;
	}
}
