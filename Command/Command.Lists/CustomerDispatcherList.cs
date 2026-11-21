using System;
using OpenDis.Producers;
using Zeptomoby.OrbitTools;

namespace Command.Lists;

internal class CustomerDispatcherList : MerchantProcessProducer
{
	private double _Iterator;

	private double initializer;

	private double _Role;

	private double test;

	private double _Factory;

	private double _Attribute;

	private double @event;

	private double global;

	private double m_Worker;

	private double m_Account;

	private double _State;

	private double authentication;

	private double @params;

	private double info;

	private double _Helper;

	private double m_Mapper;

	private double manager;

	private double getter;

	private double producer;

	private double _Proc;

	private double structMerchant;

	private double _MerchantMerchant;

	private double _CallbackMerchant;

	private double _DecoratorMerchant;

	private double _ProcessMerchant;

	private double threadMerchant;

	private double ruleMerchant;

	private double collectionMerchant;

	private double instanceMerchant;

	private double _ObjectMerchant;

	private double parameterMerchant;

	private double _ExpressionMerchant;

	private double m_DispatcherMerchant;

	private double m_ListenerMerchant;

	private double configMerchant;

	private double registryMerchant;

	private double m_DefinitionMerchant;

	private double m_ValMerchant;

	private double _WrapperMerchant;

	private double _ObserverMerchant;

	private double m_IssuerMerchant;

	private double _ClientMerchant;

	private double dicMerchant;

	private double m_ConsumerMerchant;

	private double facadeMerchant;

	private double m_ProxyMerchant;

	private double readerMerchant;

	private double propertyMerchant;

	private double _ImporterMerchant;

	private double m_RepositoryMerchant;

	private double _BridgeMerchant;

	private double invocationMerchant;

	private double classMerchant;

	private double requestMerchant;

	private double m_ValueMerchant;

	private bool m_TokenizerMerchant;

	private bool stubMerchant;

	public CustomerDispatcherList(Orbit orbit_0)
		: base(orbit_0)
	{
		double num = Math.Sin(QueryStruct().ArgPerigee);
		double num19 = Math.Cos(QueryStruct().ArgPerigee);
		Julian epoch = QueryStruct().Epoch;
		_BridgeMerchant = epoch.ToGmst();
		double eccentricity = QueryStruct().Eccentricity;
		double num30 = 1.0 / QueryStruct().SemiMajor;
		_ProcessMerchant = QueryStruct().Inclination;
		double meanAnomaly = QueryStruct().MeanAnomaly;
		double num41 = m_Printer + m_Parser;
		double num52 = Math.Sin(QueryStruct().RAAN);
		double num63 = Math.Cos(QueryStruct().RAAN);
		_ClientMerchant = QueryStruct().ArgPerigee;
		double num74 = epoch.FromJan0_12h_1900();
		double num85 = 4.523602 - 0.00092422029 * num74;
		double num96 = Math.Sin(num85);
		double num2 = Math.Cos(num85);
		double num10 = 0.91375164 - 0.03568096 * num2;
		double num11 = Math.Sqrt(1.0 - num10 * num10);
		double num12 = 0.089683511 * num96 / num11;
		double num13 = Math.Sqrt(1.0 - num12 * num12);
		double num14 = 4.7199672 + 0.2299715 * num74;
		double num15 = 5.8351514 + 0.001944368 * num74;
		threadMerchant = Globals.Fmod2p(num14 - num15);
		double double_ = 0.39785416 * num96 / num11;
		double double_2 = num13 * num2 + 0.91744867 * num12 * num96;
		double num16 = Globals.AcTan(double_, double_2) + num15 - num85;
		double num17 = Math.Cos(num16);
		double num18 = Math.Sin(num16);
		ruleMerchant = 6.2565837 + 0.017201977 * num74;
		ruleMerchant = Globals.Fmod2p(ruleMerchant);
		double num20 = 0.1945905;
		double num21 = -0.98088458;
		double num22 = 0.91744867;
		double num23 = 0.39785416;
		double num24 = num63;
		double num25 = num52;
		double num26 = 2.9864797E-06;
		double num27 = 1.19459E-05;
		double num28 = 0.01675;
		double num29 = 1.0 / QueryStruct().MeanMotion;
		double num31 = 0.0;
		double num32 = 0.0;
		double num33 = 0.0;
		double num34 = 0.0;
		double num35 = 0.0;
		double num36 = Globals.Sqr(QueryStruct().Eccentricity);
		for (int i = 1; i <= 2; i++)
		{
			double num37 = num20 * num24 + num21 * num22 * num25;
			double num38 = (0.0 - num21) * num24 + num20 * num22 * num25;
			double num39 = (0.0 - num20) * num25 + num21 * num22 * num24;
			double num40 = num21 * num23;
			double num42 = num21 * num25 + num20 * num22 * num24;
			double num43 = num20 * num23;
			double num44 = m_Comparator * num39 + m_Policy * num40;
			double num45 = m_Comparator * num42 + m_Policy * num43;
			double num46 = (0.0 - m_Policy) * num39 + m_Comparator * num40;
			double num47 = (0.0 - m_Policy) * num42 + m_Comparator * num43;
			double num48 = num37 * num19 + num44 * num;
			double num49 = num38 * num19 + num45 * num;
			double num50 = (0.0 - num37) * num + num44 * num19;
			double num51 = (0.0 - num38) * num + num45 * num19;
			double num53 = num46 * num;
			double num54 = num47 * num;
			double num55 = num46 * num19;
			double num56 = num47 * num19;
			double num57 = 12.0 * num48 * num48 - 3.0 * num50 * num50;
			double num58 = 24.0 * num48 * num49 - 6.0 * num50 * num51;
			double num59 = 12.0 * num49 * num49 - 3.0 * num51 * num51;
			double num60 = 3.0 * (num37 * num37 + num44 * num44) + num57 * num36;
			double num61 = 6.0 * (num37 * num38 + num44 * num45) + num58 * num36;
			double num62 = 3.0 * (num38 * num38 + num45 * num45) + num59 * num36;
			double num64 = -6.0 * num37 * num46 + num36 * (-24.0 * num48 * num55 - 6.0 * num50 * num53);
			double num65 = -6.0 * (num37 * num47 + num38 * num46) + num36 * (-24.0 * (num49 * num55 + num48 * num56) - 6.0 * (num50 * num54 + num51 * num53));
			double num66 = -6.0 * num38 * num47 + num36 * (-24.0 * num49 * num56 - 6.0 * num51 * num54);
			double num67 = 6.0 * num44 * num46 + num36 * (24.0 * num48 * num53 - 6.0 * num50 * num55);
			double num68 = 6.0 * (num45 * num46 + num44 * num47) + num36 * (24.0 * (num49 * num53 + num48 * num54) - 6.0 * (num51 * num55 + num50 * num56));
			double num69 = 6.0 * num45 * num47 + num36 * (24.0 * num49 * num54 - 6.0 * num51 * num56);
			num60 = num60 + num60 + _Map * num57;
			num61 = num61 + num61 + _Map * num58;
			num62 = num62 + num62 + _Map * num59;
			double num70 = num26 * num29;
			double num71 = -0.5 * num70 / template;
			double num72 = num70 * template;
			double num73 = -15.0 * eccentricity * num72;
			double num75 = num48 * num50 + num49 * num51;
			double num76 = num49 * num50 + num48 * num51;
			double num77 = num49 * num51 - num48 * num50;
			num31 = num73 * num27 * num75;
			num32 = num71 * num27 * (num64 + num66);
			num33 = (0.0 - num27) * num70 * (num60 + num62 - 14.0 - 6.0 * num36);
			num34 = num72 * num27 * (num57 + num59 - 6.0);
			num35 = ((QueryStruct().Inclination < 0.052359877) ? 0.0 : ((0.0 - num27) * num71 * (num67 + num69)));
			initializer = 2.0 * num73 * num76;
			_Iterator = 2.0 * num73 * num77;
			_Proc = 2.0 * num71 * num65;
			structMerchant = 2.0 * num71 * (num66 - num64);
			_MerchantMerchant = -2.0 * num70 * num61;
			_CallbackMerchant = -2.0 * num70 * (num62 - num60);
			_DecoratorMerchant = -2.0 * num70 * (-21.0 - 9.0 * num36) * num28;
			_Helper = 2.0 * num72 * num58;
			m_Mapper = 2.0 * num72 * (num59 - num57);
			manager = -18.0 * num72 * num28;
			getter = -2.0 * num71 * num68;
			producer = -2.0 * num71 * (num69 - num67);
			if (i == 1)
			{
				dicMerchant = num31;
				m_ProxyMerchant = num32;
				readerMerchant = num33;
				facadeMerchant = ((num35 == 0.0) ? 0.0 : (num35 / m_Policy));
				m_ConsumerMerchant = num34 - m_Comparator * facadeMerchant;
				_Role = initializer;
				m_Account = _Proc;
				authentication = _MerchantMerchant;
				_Factory = _Helper;
				global = getter;
				test = _Iterator;
				_State = structMerchant;
				@params = _CallbackMerchant;
				_Attribute = m_Mapper;
				m_Worker = producer;
				info = _DecoratorMerchant;
				@event = manager;
				num20 = num17;
				num21 = num18;
				num22 = num10;
				num23 = num11;
				num24 = num13 * num63 + num12 * num52;
				num25 = num52 * num13 - num63 * num12;
				num27 = 0.00015835218;
				num26 = 4.7968065E-07;
				num28 = 0.0549;
			}
		}
		dicMerchant += num31;
		m_ProxyMerchant += num32;
		readerMerchant += num33;
		m_ConsumerMerchant = m_ConsumerMerchant + num34 - ((num35 == 0.0) ? 0.0 : (m_Comparator / m_Policy * num35));
		facadeMerchant += ((num35 == 0.0) ? 0.0 : (num35 / m_Policy));
		m_TokenizerMerchant = false;
		stubMerchant = false;
		double num78 = 0.0;
		if (QueryStruct().MeanMotion > 0.0034906585 && QueryStruct().MeanMotion < 0.0052359877)
		{
			m_TokenizerMerchant = true;
			stubMerchant = true;
			double num79 = 1.0 + num36 * (-2.5 + 0.8125 * num36);
			double num80 = 1.0 + 2.0 * num36;
			double num81 = 1.0 + num36 * (-6.0 + 6.60937 * num36);
			double num82 = 0.75 * (1.0 + m_Comparator) * (1.0 + m_Comparator);
			double num83 = 0.9375 * m_Policy * m_Policy * (1.0 + 3.0 * m_Comparator) - 0.75 * (1.0 + m_Comparator);
			double num84 = 1.0 + m_Comparator;
			num84 = 1.875 * num84 * num84 * num84;
			_WrapperMerchant = 3.0 * _Mock * _Mock * num30 * num30;
			_ObserverMerchant = 2.0 * _WrapperMerchant * num82 * num79 * 1.7891679E-06;
			m_IssuerMerchant = 3.0 * _WrapperMerchant * num84 * num81 * 2.2123015E-07 * num30;
			_WrapperMerchant = _WrapperMerchant * num83 * num80 * 2.1460748E-06 * num30;
			classMerchant = meanAnomaly + QueryStruct().RAAN + QueryStruct().ArgPerigee - _BridgeMerchant;
			num78 = m_Identifier + num41 - 0.0043752691;
			num78 = num78 + readerMerchant + m_ConsumerMerchant + facadeMerchant;
		}
		else if (QueryStruct().MeanMotion >= 0.00826 && QueryStruct().MeanMotion <= 0.00924 && eccentricity >= 0.5)
		{
			m_TokenizerMerchant = true;
			double num86 = eccentricity * num36;
			double num87 = -0.306 - (eccentricity - 0.64) * 0.44;
			double num88;
			double num89;
			double num90;
			double num91;
			double num92;
			double num93;
			if (eccentricity <= 0.65)
			{
				num88 = 3.616 - 13.247 * eccentricity + 16.29 * num36;
				num89 = -19.302 + 117.39 * eccentricity - 228.419 * num36 + 156.591 * num86;
				num90 = -18.9068 + 109.7927 * eccentricity - 214.6334 * num36 + 146.5816 * num86;
				num91 = -41.122 + 242.694 * eccentricity - 471.094 * num36 + 313.953 * num86;
				num92 = -146.407 + 841.88 * eccentricity - 1629.014 * num36 + 1083.435 * num86;
				num93 = -532.114 + 3017.977 * eccentricity - 5740.0 * num36 + 3708.276 * num86;
			}
			else
			{
				num88 = -72.099 + 331.819 * eccentricity - 508.738 * num36 + 266.724 * num86;
				num89 = -346.844 + 1582.851 * eccentricity - 2415.925 * num36 + 1246.113 * num86;
				num90 = -342.585 + 1554.908 * eccentricity - 2366.899 * num36 + 1215.972 * num86;
				num91 = -1052.797 + 4758.686 * eccentricity - 7193.992 * num36 + 3651.957 * num86;
				num92 = -3581.69 + 16178.11 * eccentricity - 24462.77 * num36 + 12422.52 * num86;
				num93 = ((eccentricity <= 0.715) ? (1464.74 - 4664.75 * eccentricity + 3763.64 * num36) : (-5149.66 + 29936.92 * eccentricity - 54087.36 * num36 + 31324.56 * num86));
			}
			double num94;
			double num95;
			double num97;
			if (eccentricity < 0.7)
			{
				num94 = -919.2277 + 4988.61 * eccentricity - 9064.77 * num36 + 5542.21 * num86;
				num95 = -822.71072 + 4568.6173 * eccentricity - 8491.4146 * num36 + 5337.524 * num86;
				num97 = -853.666 + 4690.25 * eccentricity - 8624.77 * num36 + 5341.4 * num86;
			}
			else
			{
				num94 = -37995.78 + 161616.52 * eccentricity - 229838.2 * num36 + 109377.94 * num86;
				num95 = -51752.104 + 218913.95 * eccentricity - 309468.16 * num36 + 146349.42 * num86;
				num97 = -40023.88 + 170470.89 * eccentricity - 242699.48 * num36 + 115605.82 * num86;
			}
			double num98 = m_Policy * m_Policy;
			double num99 = m_Comparator * m_Comparator;
			double num100 = 0.75 * (1.0 + 2.0 * m_Comparator + num99);
			double num101 = 1.5 * num98;
			double num102 = 1.875 * m_Policy * (1.0 - 2.0 * m_Comparator - 3.0 * num99);
			double num103 = -1.875 * m_Policy * (1.0 + 2.0 * m_Comparator - 3.0 * num99);
			double num104 = 35.0 * num98 * num100;
			double num105 = 39.375 * num98 * num98;
			double num106 = 9.84375 * m_Policy * (num98 * (1.0 - 2.0 * m_Comparator - 5.0 * num99) + 0.33333333 * (-2.0 + 4.0 * m_Comparator + 6.0 * num99));
			double num3 = m_Policy * (4.92187512 * num98 * (-2.0 - 4.0 * m_Comparator + 10.0 * num99) + 6.56250012 * (1.0 + 2.0 * m_Comparator - 3.0 * num99));
			double num4 = 29.53125 * m_Policy * (2.0 - 8.0 * m_Comparator + num99 * (-12.0 + 8.0 * m_Comparator + 10.0 * num99));
			double num5 = 29.53125 * m_Policy * (-2.0 - 8.0 * m_Comparator + num99 * (12.0 + 8.0 * m_Comparator - 10.0 * num99));
			double num6 = _Mock * _Mock;
			double num7 = num30 * num30;
			double num8 = 3.0 * num6 * num7;
			double num9 = num8 * 1.7891679E-06;
			instanceMerchant = num9 * num100 * num87;
			_ObjectMerchant = num9 * num101 * num88;
			num8 *= num30;
			num9 = num8 * 3.7393792E-07;
			parameterMerchant = num9 * num102 * num89;
			_ExpressionMerchant = num9 * num103 * num90;
			num8 *= num30;
			num9 = 2.0 * num8 * 7.3636953E-09;
			m_DispatcherMerchant = num9 * num104 * num91;
			m_ListenerMerchant = num9 * num105 * num92;
			num8 *= num30;
			num9 = num8 * 1.1428639E-07;
			configMerchant = num9 * num106 * num93;
			registryMerchant = num9 * num3 * num97;
			num9 = 2.0 * num8 * 2.1765803E-09;
			m_DefinitionMerchant = num9 * num4 * num95;
			m_ValMerchant = num9 * num5 * num94;
			classMerchant = meanAnomaly + QueryStruct().RAAN + QueryStruct().RAAN - _BridgeMerchant - _BridgeMerchant;
			num78 = m_Identifier + m_Parser + m_Parser - 0.0043752691 - 0.0043752691;
			num78 = num78 + readerMerchant + facadeMerchant + facadeMerchant;
		}
		if (m_TokenizerMerchant || stubMerchant)
		{
			invocationMerchant = num78 - _Mock;
			requestMerchant = classMerchant;
			m_ValueMerchant = _Mock;
			m_RepositoryMerchant = 720.0;
			_ImporterMerchant = -720.0;
			propertyMerchant = 259200.0;
		}
	}

	private bool SortStruct(ref double double_0, ref double double_1, ref double double_2)
	{
		if (stubMerchant)
		{
			double_0 = _WrapperMerchant * Math.Sin(requestMerchant - 0.13130908) + _ObserverMerchant * Math.Sin(2.0 * (requestMerchant - 2.8843198)) + m_IssuerMerchant * Math.Sin(3.0 * (requestMerchant - 0.37448087));
			double_1 = _WrapperMerchant * Math.Cos(requestMerchant - 0.13130908) + 2.0 * _ObserverMerchant * Math.Cos(2.0 * (requestMerchant - 2.8843198)) + 3.0 * m_IssuerMerchant * Math.Cos(3.0 * (requestMerchant - 0.37448087));
		}
		else
		{
			double num = _ClientMerchant + m_Printer * collectionMerchant;
			double num2 = num + num;
			double num3 = requestMerchant + requestMerchant;
			double_0 = instanceMerchant * Math.Sin(num2 + requestMerchant - 5.7686396) + _ObjectMerchant * Math.Sin(requestMerchant - 5.7686396) + parameterMerchant * Math.Sin(num + requestMerchant - 0.95240898) + _ExpressionMerchant * Math.Sin(0.0 - num + requestMerchant - 0.95240898) + m_DispatcherMerchant * Math.Sin(num2 + num3 - 1.8014998) + m_ListenerMerchant * Math.Sin(num3 - 1.8014998) + configMerchant * Math.Sin(num + requestMerchant - 1.050833) + registryMerchant * Math.Sin(0.0 - num + requestMerchant - 1.050833) + m_DefinitionMerchant * Math.Sin(num + num3 - 4.4108898) + m_ValMerchant * Math.Sin(0.0 - num + num3 - 4.4108898);
			double_1 = instanceMerchant * Math.Cos(num2 + requestMerchant - 5.7686396) + _ObjectMerchant * Math.Cos(requestMerchant - 5.7686396) + parameterMerchant * Math.Cos(num + requestMerchant - 0.95240898) + _ExpressionMerchant * Math.Cos(0.0 - num + requestMerchant - 0.95240898) + configMerchant * Math.Cos(num + requestMerchant - 1.050833) + registryMerchant * Math.Cos(0.0 - num + requestMerchant - 1.050833) + 2.0 * (m_DispatcherMerchant * Math.Cos(num2 + num3 - 1.8014998) + m_ListenerMerchant * Math.Cos(num3 - 1.8014998) + m_DefinitionMerchant * Math.Cos(num + num3 - 4.4108898) + m_ValMerchant * Math.Cos(0.0 - num + num3 - 4.4108898));
		}
		double_2 = m_ValueMerchant + invocationMerchant;
		double_1 *= double_2;
		return true;
	}

	private void CalcStruct(ref double double_0, ref double double_1, ref double double_2, double double_3)
	{
		SortStruct(ref double_0, ref double_1, ref double_2);
		requestMerchant = requestMerchant + double_2 * double_3 + double_0 * propertyMerchant;
		m_ValueMerchant = m_ValueMerchant + double_0 * double_3 + double_1 * propertyMerchant;
		collectionMerchant += double_3;
	}

	private bool RateStruct(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref double double_5, ref double double_6)
	{
		double_0 += readerMerchant * double_6;
		double_1 += m_ConsumerMerchant * double_6;
		double_2 += facadeMerchant * double_6;
		double_3 = QueryStruct().Eccentricity + dicMerchant * double_6;
		double_4 = QueryStruct().Inclination + m_ProxyMerchant * double_6;
		if (double_4 < 0.0)
		{
			double_4 = 0.0 - double_4;
			double_2 += Math.PI;
			double_1 -= Math.PI;
		}
		double double_8 = 0.0;
		double double_9 = 0.0;
		double double_10 = 0.0;
		double num = 0.0;
		double double_7 = 0.0;
		bool flag = false;
		if (m_TokenizerMerchant)
		{
			while (!flag)
			{
				if (collectionMerchant != 0.0 && (!(double_6 >= 0.0) || !(collectionMerchant < 0.0)) && (!(double_6 < 0.0) || collectionMerchant < 0.0))
				{
					if (Math.Abs(double_6) < Math.Abs(collectionMerchant))
					{
						double_7 = m_RepositoryMerchant;
						if (double_6 >= 0.0)
						{
							double_7 = _ImporterMerchant;
						}
						CalcStruct(ref double_9, ref double_8, ref double_10, double_7);
					}
					else
					{
						double_7 = _ImporterMerchant;
						if (double_6 > 0.0)
						{
							double_7 = m_RepositoryMerchant;
						}
						flag = true;
					}
				}
				else
				{
					double_7 = ((double_6 < 0.0) ? _ImporterMerchant : m_RepositoryMerchant);
					collectionMerchant = 0.0;
					m_ValueMerchant = _Mock;
					requestMerchant = classMerchant;
					flag = true;
				}
			}
			while (Math.Abs(double_6 - collectionMerchant) >= m_RepositoryMerchant)
			{
				CalcStruct(ref double_9, ref double_8, ref double_10, double_7);
			}
			num = double_6 - collectionMerchant;
			SortStruct(ref double_9, ref double_8, ref double_10);
			double_5 = m_ValueMerchant + double_9 * num + double_8 * num * num * 0.5;
			double num2 = requestMerchant + double_10 * num + double_9 * num * num * 0.5;
			double num3 = 0.0 - double_2 + _BridgeMerchant + double_6 * 0.0043752691;
			double_0 = num2 - double_1 + num3;
			if (!stubMerchant)
			{
				double_0 = num2 + num3 + num3;
			}
		}
		return true;
	}

	private bool FlushStruct(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, double double_5)
	{
		double num = Math.Sin(double_1);
		double num12 = Math.Cos(double_1);
		double num23 = 0.0;
		double num25 = 0.0;
		double num26 = 0.0;
		double num27 = 0.0;
		double num28 = 0.0;
		double num29 = 0.0;
		double num30 = ruleMerchant + 1.19459E-05 * double_5;
		double num2 = num30 + 0.0335 * Math.Sin(num30);
		double num3 = Math.Sin(num2);
		double num4 = 0.5 * num3 * num3 - 0.25;
		double num5 = -0.5 * num3 * Math.Cos(num2);
		double num6 = _Role * num4 + test * num5;
		double num7 = m_Account * num4 + _State * num5;
		double num8 = authentication * num4 + @params * num5 + info * num3;
		num23 = _Factory * num4 + _Attribute * num5 + @event * num3;
		double num9 = global * num4 + m_Worker * num5;
		num30 = threadMerchant + 0.00015835218 * double_5;
		num2 = num30 + 0.1098 * Math.Sin(num30);
		num3 = Math.Sin(num2);
		num4 = 0.5 * num3 * num3 - 0.25;
		num5 = -0.5 * num3 * Math.Cos(num2);
		double num10 = initializer * num4 + _Iterator * num5;
		double num11 = _Proc * num4 + structMerchant * num5;
		double num13 = _MerchantMerchant * num4 + _CallbackMerchant * num5 + _DecoratorMerchant * num3;
		num29 = _Helper * num4 + m_Mapper * num5 + manager * num3;
		num25 = getter * num4 + producer * num5;
		num26 = num6 + num10;
		num27 = num7 + num11;
		num28 = num8 + num13;
		double num14 = num23 + num29;
		double num15 = num9 + num25;
		double_1 += num27;
		double_0 += num26;
		if (_ProcessMerchant < 0.2)
		{
			double num16 = Math.Sin(double_3);
			double num17 = Math.Cos(double_3);
			double num18 = num * num16;
			double num19 = num * num17;
			double num20 = num15 * num17 + num27 * num12 * num16;
			double num21 = (0.0 - num15) * num16 + num27 * num12 * num17;
			num18 += num20;
			num19 += num21;
			double num22 = double_4 + double_2 + num12 * double_3;
			double num24 = num28 + num14 - num27 * double_3 * num;
			num22 += num24;
			double_3 = Globals.AcTan(num18, num19);
			double_4 += num28;
			double_2 = num22 - double_4 - Math.Cos(double_1) * double_3;
		}
		else
		{
			num15 /= m_Policy;
			num14 -= m_Comparator * num15;
			double_2 += num14;
			double_3 += num15;
			double_4 += num28;
		}
		return true;
	}

	public override EciTime ConcatInterruptibleBroadcaster(double double_0)
	{
		double double_ = QueryStruct().MeanAnomaly + m_Identifier * double_0;
		double double_3 = QueryStruct().ArgPerigee + m_Printer * double_0;
		double num = QueryStruct().RAAN + m_Parser * double_0;
		double num2 = double_0 * double_0;
		double double_4 = num + _Algo * num2;
		double double_5 = 1.0 - _System * double_0;
		double num3 = QueryStruct().BStar * m_Base * double_0;
		double num4 = _Database * num2;
		double double_6 = _Mock;
		double double_7 = 0.0;
		double double_8 = 0.0;
		RateStruct(ref double_, ref double_3, ref double_4, ref double_7, ref double_8, ref double_6, ref double_0);
		double num5 = Math.Pow(Globals.Xke / double_6, 2.0 / 3.0) * Globals.Sqr(double_5);
		double double_9 = double_7 - num3;
		double double_10 = double_ + _Mock * num4;
		FlushStruct(ref double_9, ref double_8, ref double_3, ref double_4, ref double_10, double_0);
		double double_2 = double_10 + double_3 + double_4;
		double_6 = Globals.Xke / Math.Pow(num5, 1.5);
		return AwakeStruct(double_8, double_3, double_9, num5, double_2, double_4, double_6, double_0);
	}
}
