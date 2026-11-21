using System;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Specifications;

[StandardModule]
internal sealed class StubDefinitionSpec
{
	private static readonly double _MethodReader;

	private static readonly double m_ServiceReader;

	private static readonly double m_SystemReader;

	private static readonly double m_CandidateReader;

	private static readonly double _BaseReader;

	private static readonly double policyReader;

	private static readonly double m_BroadcasterReader;

	private static readonly double identifierReader;

	static StubDefinitionSpec()
	{
		_MethodReader = 6378137.0;
		m_ServiceReader = 6356752.3142;
		m_SystemReader = m_ServiceReader / _MethodReader;
		m_CandidateReader = Math.Sqrt(1.0 - m_SystemReader * m_SystemReader);
		_BaseReader = 0.5 * m_CandidateReader;
		policyReader = CSMath.PI_dividedBy_180;
		m_BroadcasterReader = 180.0 / Math.PI;
		identifierReader = Math.PI / 2.0;
	}

	public static double[] WriteList(double double_0, double double_1)
	{
		return new double[2]
		{
			PushList(double_0),
			InvokeList(double_1)
		};
	}

	public static double[] NewList(double double_0, double double_1)
	{
		return new double[2]
		{
			SetupList(double_0),
			ExcludeList(double_1)
		};
	}

	public static double PushList(double double_0)
	{
		return _MethodReader * SearchList(double_0);
	}

	public static double InvokeList(double double_0)
	{
		double_0 = Math.Min(89.5, Math.Max(double_0, -89.5));
		double num = SearchList(double_0);
		double num2 = Math.Sin(num);
		double num3 = m_CandidateReader * num2;
		num3 = Math.Pow((1.0 - num3) / (1.0 + num3), _BaseReader);
		double d = Math.Tan(0.5 * (Math.PI / 2.0 - num)) / num3;
		return 0.0 - _MethodReader * Math.Log(d);
	}

	public static double SetupList(double double_0)
	{
		return IncludeList(double_0) / _MethodReader;
	}

	public static double ExcludeList(double double_0)
	{
		double num = Math.Exp((0.0 - double_0) / _MethodReader);
		double num2 = identifierReader - 2.0 * Math.Atan(num);
		double num3 = 1.0;
		int num4 = 0;
		while (Math.Abs(num3) > 1E-09 && num4 < 15)
		{
			double num5 = m_CandidateReader * Math.Sin(num2);
			num3 = identifierReader - 2.0 * Math.Atan(num * Math.Pow((1.0 - num5) / (1.0 + num5), _BaseReader)) - num2;
			num2 += num3;
			num4++;
		}
		return IncludeList(num2);
	}

	private static double IncludeList(double double_0)
	{
		return double_0 * m_BroadcasterReader;
	}

	private static double SearchList(double double_0)
	{
		return double_0 * policyReader;
	}
}
