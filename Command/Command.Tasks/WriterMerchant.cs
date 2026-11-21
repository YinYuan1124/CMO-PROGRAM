using System;
using OpenDis.Producers;
using Zeptomoby.OrbitTools;

namespace Command.Tasks;

internal class WriterMerchant : MerchantProcessProducer
{
	private readonly double orderMerchant;

	private readonly double specificationMerchant;

	private readonly double watcherMerchant;

	private readonly double m_ReponseMerchant;

	private readonly double _DescriptorMerchant;

	public WriterMerchant(Orbit orbit_0)
		: base(orbit_0)
	{
		orderMerchant = 2.0 * m_Service * m_Mapping * _Map * (1.0 + 2.75 * (_Page + rules) + rules * _Page);
		specificationMerchant = QueryStruct().BStar * candidate * Math.Cos(QueryStruct().ArgPerigee);
		watcherMerchant = -2.0 / 3.0 * _Method * QueryStruct().BStar * 1.0 / rules;
		m_ReponseMerchant = Math.Pow(1.0 + _Param * Math.Cos(QueryStruct().MeanAnomaly), 3.0);
		_DescriptorMerchant = Math.Sin(QueryStruct().MeanAnomaly);
	}

	public override EciTime ConcatInterruptibleBroadcaster(double double_0)
	{
		bool flag = false;
		if (m_Mapping * (1.0 - m_Prototype) / 1.0 < 1.034492841559484)
		{
			flag = true;
		}
		double num = 0.0;
		double num12 = 0.0;
		double num18 = 0.0;
		double num19 = 0.0;
		double num20 = 0.0;
		double num21 = 0.0;
		if (!flag)
		{
			double num22 = _System * _System;
			num = 4.0 * m_Mapping * m_Reg * num22;
			double num23 = num * m_Reg * _System / 3.0;
			num12 = (17.0 * m_Mapping + tag) * num23;
			num18 = 0.5 * num23 * m_Mapping * m_Reg * (221.0 * m_Mapping + 31.0 * tag) * _System;
			num19 = num + 2.0 * num22;
			num20 = 0.25 * (3.0 * num12 + _System * (12.0 * num + 10.0 * num22));
			num21 = 0.2 * (3.0 * num18 + 12.0 * _System * num12 + 6.0 * num * num + 15.0 * num22 * (2.0 * num + num22));
		}
		double num24 = QueryStruct().MeanAnomaly + m_Identifier * double_0;
		double num2 = QueryStruct().ArgPerigee + m_Printer * double_0;
		double num3 = QueryStruct().RAAN + m_Parser * double_0;
		double num4 = num2;
		double num5 = num24;
		double num6 = double_0 * double_0;
		double num7 = num3 + _Algo * num6;
		double num8 = 1.0 - _System * double_0;
		double num9 = QueryStruct().BStar * m_Base * double_0;
		double num10 = _Database * num6;
		if (!flag)
		{
			double num11 = specificationMerchant * double_0;
			double num13 = watcherMerchant * (Math.Pow(1.0 + _Param * Math.Cos(num24), 3.0) - m_ReponseMerchant);
			double num14 = num11 + num13;
			num5 = num24 + num14;
			num4 = num2 - num14;
			double num15 = num6 * double_0;
			double num16 = double_0 * num15;
			num8 = num8 - num * num6 - num12 * num15 - num18 * num16;
			num9 += QueryStruct().BStar * orderMerchant * (Math.Sin(num5) - _DescriptorMerchant);
			num10 = num10 + num19 * num15 + num16 * (num20 + double_0 * num21);
		}
		double num17 = m_Mapping * Globals.Sqr(num8);
		double double_ = m_Prototype - num9;
		double double_2 = num5 + num4 + num7 + _Mock * num10;
		double double_3 = Globals.Xke / Math.Pow(num17, 1.5);
		return AwakeStruct(exporter, num2, double_, num17, double_2, num7, double_3, double_0);
	}
}
