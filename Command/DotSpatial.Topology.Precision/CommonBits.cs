using System;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Precision;

public class CommonBits
{
	private long m_SerializerThread;

	private int _RefThread = 53;

	private long _ErrorThread;

	private bool codeThread = true;

	public virtual double Common => BitConverter.Int64BitsToDouble(m_SerializerThread);

	public static long SignExpBits(long long_0)
	{
		return long_0 >> 52;
	}

	public static int NumCommonMostSigMantissaBits(long long_0, long long_1)
	{
		int num = 0;
		int num2 = 52;
		while (true)
		{
			if (num2 >= 0)
			{
				if (GetBit(long_0, num2) != GetBit(long_1, num2))
				{
					break;
				}
				num++;
				num2--;
				continue;
			}
			return 52;
		}
		return num;
	}

	public static long ZeroLowerBits(long long_0, int int_0)
	{
		long num = ~((1L << int_0) - 1);
		return long_0 & num;
	}

	public static int GetBit(long long_0, int int_0)
	{
		long num = 1L << int_0;
		if ((long_0 & num) != 0)
		{
			return 1;
		}
		return 0;
	}

	public virtual void Add(double double_0)
	{
		long num = BitConverter.DoubleToInt64Bits(double_0);
		if (codeThread)
		{
			m_SerializerThread = num;
			_ErrorThread = SignExpBits(m_SerializerThread);
			codeThread = false;
		}
		else if (SignExpBits(num) == _ErrorThread)
		{
			_RefThread = NumCommonMostSigMantissaBits(m_SerializerThread, num);
			m_SerializerThread = ZeroLowerBits(m_SerializerThread, 64 - (12 + _RefThread));
		}
		else
		{
			m_SerializerThread = 0L;
		}
	}

	public virtual string ToString(long long_0)
	{
		double num = BitConverter.Int64BitsToDouble(long_0);
		string text = HexConverter.ConvertAny2Any(long_0.ToString(), 10, 2);
		string text2 = "0000000000000000000000000000000000000000000000000000000000000000" + text;
		string text3 = text2.Substring(text2.Length - 64);
		return text3.Substring(0, 1) + "  " + text3.Substring(1, 12) + "(exp) " + text3.Substring(12) + " [ " + num + " ]";
	}
}
