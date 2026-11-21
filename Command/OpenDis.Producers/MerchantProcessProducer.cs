using System;
using System.Runtime.CompilerServices;
using Zeptomoby.OrbitTools;

namespace OpenDis.Producers;

internal abstract class MerchantProcessProducer
{
	protected double exporter;

	protected double m_Prototype;

	protected double m_Comparator;

	protected double m_Item;

	protected double setter;

	protected double _Creator;

	protected double _Map;

	protected double template;

	protected double m_Mapping;

	protected double _Mock;

	protected double tag;

	protected double _Field;

	protected double queue;

	protected double m_Reg;

	protected double _Param;

	protected double _Page;

	protected double rules;

	protected double _Method;

	protected double m_Service;

	protected double _System;

	protected double candidate;

	protected double m_Base;

	protected double m_Policy;

	protected double _Broadcaster;

	protected double m_Identifier;

	protected double m_Printer;

	protected double m_Parser;

	protected double _Algo;

	protected double _Database;

	protected double interceptor;

	protected double message;

	protected double _Product;

	[CompilerGenerated]
	private Orbit m_Annotation;

	[SpecialName]
	[CompilerGenerated]
	protected Orbit QueryStruct()
	{
		return m_Annotation;
	}

	[SpecialName]
	[CompilerGenerated]
	private void ResetStruct(Orbit orbit_0)
	{
		m_Annotation = orbit_0;
	}

	public abstract EciTime ConcatInterruptibleBroadcaster(double double_0);

	public MerchantProcessProducer(Orbit orbit_0)
	{
		ResetStruct(orbit_0);
		PublishStruct();
	}

	private void PublishStruct()
	{
		exporter = QueryStruct().Inclination;
		m_Prototype = QueryStruct().Eccentricity;
		m_Comparator = Math.Cos(exporter);
		m_Item = m_Comparator * m_Comparator;
		setter = 3.0 * m_Item - 1.0;
		_Creator = m_Prototype * m_Prototype;
		_Map = 1.0 - _Creator;
		template = Math.Sqrt(_Map);
		m_Mapping = QueryStruct().SemiMajor;
		_Mock = QueryStruct().MeanMotion;
		queue = 6378.135 * (m_Mapping * (1.0 - m_Prototype) - 1.0);
		tag = 1.0122292801892716;
		_Field = Globals.Qoms2t;
		if (queue < 156.0)
		{
			tag = queue - 78.0;
			if (queue <= 98.0)
			{
				tag = 20.0;
			}
			_Field = Math.Pow((120.0 - tag) * 1.0 / 6378.135, 4.0);
			tag = tag / 6378.135 + 1.0;
		}
		double num = 1.0 / (m_Mapping * m_Mapping * _Map * _Map);
		m_Reg = 1.0 / (m_Mapping - tag);
		_Param = m_Mapping * m_Prototype * m_Reg;
		_Page = _Param * _Param;
		rules = m_Prototype * _Param;
		double num3 = Math.Abs(1.0 - _Page);
		_Method = _Field * Math.Pow(m_Reg, 4.0);
		m_Service = _Method / Math.Pow(num3, 3.5);
		double num4 = m_Service * _Mock * (m_Mapping * (1.0 + 1.5 * _Page + rules * (4.0 + _Page)) + 0.000405980925 * m_Reg / num3 * setter * (8.0 + 3.0 * _Page * (8.0 + _Page)));
		_System = QueryStruct().BStar * num4;
		m_Policy = Math.Sin(exporter);
		double num5 = 0.004690140306468833 * Math.Pow(1.0, 3.0);
		candidate = _Method * m_Reg * num5 * _Mock * 1.0 * m_Policy / m_Prototype;
		_Broadcaster = 1.0 - m_Item;
		m_Base = 2.0 * _Mock * m_Service * m_Mapping * _Map * (_Param * (2.0 + 0.5 * _Page) + m_Prototype * (0.5 + 2.0 * _Page) - 0.0010826158 * m_Reg / (m_Mapping * num3) * (-3.0 * setter * (1.0 - 2.0 * rules + _Page * (1.5 - 0.5 * rules)) + 0.75 * _Broadcaster * (2.0 * _Page - rules * (1.0 + _Page)) * Math.Cos(2.0 * QueryStruct().ArgPerigee)));
		double num6 = m_Item * m_Item;
		double num7 = 0.0016239237 * num * _Mock;
		double num8 = num7 * 0.0005413079 * num;
		double num9 = 7.762359374999998E-07 * num * num * _Mock;
		m_Identifier = _Mock + 0.5 * num7 * template * setter + 0.0625 * num8 * template * (13.0 - 78.0 * m_Item + 137.0 * num6);
		double num10 = 1.0 - 5.0 * m_Item;
		m_Printer = -0.5 * num7 * num10 + 0.0625 * num8 * (7.0 - 114.0 * m_Item + 395.0 * num6) + num9 * (3.0 - 36.0 * m_Item + 49.0 * num6);
		double num2 = (0.0 - num7) * m_Comparator;
		m_Parser = num2 + (0.5 * num8 * (4.0 - 19.0 * m_Item) + 2.0 * num9 * (3.0 - 7.0 * m_Item)) * m_Comparator;
		_Algo = 3.5 * _Map * num2 * _System;
		_Database = 1.5 * _System;
		interceptor = 0.125 * num5 * m_Policy * (3.0 + 5.0 * m_Comparator) / (1.0 + m_Comparator);
		message = 0.25 * num5 * m_Policy;
		_Product = 7.0 * m_Item - 1.0;
	}

	protected EciTime AwakeStruct(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7)
	{
		if (double_2 * double_2 <= 1.0)
		{
			double num = Math.Sqrt(1.0 - double_2 * double_2);
			double num12 = double_2 * Math.Cos(double_1);
			double num23 = 1.0 / (double_3 * num * num);
			double num34 = num23 * interceptor * num12;
			double num45 = num23 * message;
			double num47 = double_4 + num34;
			double num48 = double_2 * Math.Sin(double_1) + num45;
			double num49 = Globals.Fmod2p(num47 - double_5);
			double num50 = num49;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			bool flag = false;
			for (int i = 1; i <= 10; i++)
			{
				if (flag)
				{
					break;
				}
				num6 = Math.Sin(num50);
				num7 = Math.Cos(num50);
				num2 = num12 * num6;
				num3 = num48 * num7;
				num4 = num12 * num7;
				num5 = num48 * num6;
				double num8 = (num49 - num3 + num2 - num50) / (1.0 - num4 - num5) + num50;
				if (Math.Abs(num8 - num50) <= 1E-06)
				{
					flag = true;
				}
				else
				{
					num50 = num8;
				}
			}
			double num9 = num4 + num5;
			double num10 = num2 - num3;
			double num11 = num12 * num12 + num48 * num48;
			num23 = 1.0 - num11;
			double num13 = double_3 * num23;
			double num14 = double_3 * (1.0 - num9);
			double num15 = 1.0 / num14;
			double num16 = Globals.Xke * Math.Sqrt(double_3) * num10 * num15;
			double num17 = Globals.Xke * Math.Sqrt(num13) * num15;
			num50 = double_3 * num15;
			double num18 = Math.Sqrt(num23);
			num2 = 1.0 / (1.0 + num18);
			double num19 = num50 * (num7 - num12 + num48 * num10 * num2);
			double num20 = num50 * (num6 - num48 - num12 * num10 * num2);
			double num21 = Globals.AcTan(num20, num19);
			double num22 = 2.0 * num20 * num19;
			double num24 = 2.0 * num19 * num19 - 1.0;
			num23 = 1.0 / num13;
			num15 = 0.0005413079 * num23;
			num50 = num15 * num23;
			double num25 = num14 * (1.0 - 1.5 * num50 * num18 * setter) + 0.5 * num15 * _Broadcaster * num24;
			double num26 = num21 - 0.25 * num50 * _Product * num22;
			double num27 = double_5 + 1.5 * num50 * m_Comparator * num22;
			double num28 = double_0 + 1.5 * num50 * m_Comparator * m_Policy * num24;
			double num29 = num16 - double_6 * num15 * _Broadcaster * num22;
			double num30 = num17 + double_6 * num15 * (_Broadcaster * num24 + 1.5 * setter);
			double num31 = Math.Sin(num26);
			double num32 = Math.Cos(num26);
			double num33 = Math.Sin(num28);
			double num35 = Math.Cos(num28);
			double num36 = Math.Sin(num27);
			double num37 = Math.Cos(num27);
			double num38 = (0.0 - num36) * num35;
			double num39 = num37 * num35;
			double num40 = num38 * num31 + num37 * num32;
			double num41 = num39 * num31 + num36 * num32;
			double num42 = num33 * num31;
			double num43 = num38 * num32 - num37 * num31;
			double num44 = num39 * num32 - num36 * num31;
			double num46 = num33 * num32;
			double double_12 = num25 * num40;
			double double_13 = num25 * num41;
			double double_8 = num25 * num42;
			Vector vector = new Vector(double_12, double_13, double_8);
			Julian julian = new Julian(QueryStruct().Epoch);
			julian.AddMin(double_7);
			if (vector.Magnitude() * 6378.135 < 6378.135)
			{
				throw new DecayException(julian, QueryStruct().SatNameLong);
			}
			double double_9 = num29 * num40 + num30 * num43;
			double double_10 = num29 * num41 + num30 * num44;
			double double_11 = num29 * num42 + num30 * num46;
			Vector vector_ = new Vector(double_9, double_10, double_11);
			return new EciTime(vector, vector_, julian);
		}
		throw new PropagationException("Error in satellite data");
	}
}
