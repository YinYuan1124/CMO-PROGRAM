using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Sgp4Sdp4
{
	public static void sgp4(double double_0, ref SxPxConstants.vector vector_0, ref SxPxConstants.vector vector_1, SxPxConstants.sgp_data sgp_data_0)
	{
		SxPxConstants.vector vector = default(SxPxConstants.vector);
		vector.v = new double[4];
		SxPxConstants.vector vector2 = default(SxPxConstants.vector);
		vector2.v = new double[4];
		SxPxConstants.vector vector3 = default(SxPxConstants.vector);
		vector3.v = new double[4];
		SxPxConstants.vector vector4 = default(SxPxConstants.vector);
		vector4.v = new double[4];
		double num = 0.0;
		double num22 = 0.0;
		double num33 = 0.0;
		double num44 = 0.0;
		double num55 = 0.0;
		double num66 = 0.0;
		double num77 = 0.0;
		double num88 = 0.0;
		double num99 = 0.0;
		double num2 = 0.0;
		double num13 = 0.0;
		double num14 = 0.0;
		double num15 = 0.0;
		double num16 = 0.0;
		double num17 = 0.0;
		double num18 = 0.0;
		double num19 = 0.0;
		double num20 = 0.0;
		double num21 = 0.0;
		double num23 = 0.0;
		double num24 = 0.0;
		double num25 = 0.0;
		double num26 = 0.0;
		double num27 = 0.0;
		double num28 = 0.0;
		double num29 = 0.0;
		double num30 = 0.0;
		double num31 = 0.0;
		double num32 = 0.0;
		double num34 = 0.0;
		double num35 = 0.0;
		double num36 = 0.0;
		double num37 = 0.0;
		double num38 = 0.0;
		double num39 = 0.0;
		double num40 = 0.0;
		double num41 = 0.0;
		double num42 = 0.0;
		double num43 = 0.0;
		double num45 = 0.0;
		double num46 = 0.0;
		double num47 = 0.0;
		double num48 = 0.0;
		double num49 = 0.0;
		double num50 = 0.0;
		double num51 = 0.0;
		double num52 = 0.0;
		double num53 = 0.0;
		double num54 = 0.0;
		double num56 = 0.0;
		double num57 = 0.0;
		double num58 = 0.0;
		double num59 = 0.0;
		double num60 = 0.0;
		double num61 = 0.0;
		double num62 = 0.0;
		int num63 = 0;
		int num64 = 0;
		double num65 = 0.0;
		double num67 = 0.0;
		num65 = Math.Sqrt(1434962880.0 / SxPxMath.RevertSpecification(6378.135));
		double num68 = SxPxMath.CountWatcher(SxPxMath.CountWatcher(0.006584997024992489));
		num46 = num65 / sgp_data_0.xno;
		num = Math.Pow(num46, 2.0 / 3.0);
		num18 = Math.Cos(sgp_data_0.xincl);
		num48 = SxPxMath.CountWatcher(num18);
		num53 = 3.0 * num48 - 1.0;
		num27 = SxPxMath.CountWatcher(sgp_data_0.eo);
		num77 = 1.0 - num27;
		num66 = Math.Sqrt(num77);
		num23 = 0.00081196185 * num53 / (SxPxMath.CountWatcher(num) * num66 * num77);
		num33 = num * (1.0 - num23 * (1.0 / 3.0 + num23 * (1.0 + 1.654320987654321 * num23)));
		num25 = 0.00081196185 * num53 / (SxPxMath.CountWatcher(num33) * num66 * num77);
		num62 = sgp_data_0.xno / (1.0 + num25);
		num44 = num33 / (1.0 - num25);
		num63 = 0;
		if (num44 * (1.0 - sgp_data_0.eo) / 1.0 < 1.034492841559484)
		{
			num63 = 1;
		}
		num37 = 1.0122292801892716;
		num30 = num68;
		num34 = (num44 * (1.0 - sgp_data_0.eo) - 1.0) * 6378.135;
		if (num34 < 156.0)
		{
			num37 = num34 - 78.0;
			if (num34 <= 98.0)
			{
				num37 = 20.0;
			}
			num30 = Math.Pow((120.0 - num37) * 1.0 / 6378.135, 4.0);
			num37 = num37 / 6378.135 + 1.0;
		}
		num35 = 1.0 / (SxPxMath.CountWatcher(num44) * SxPxMath.CountWatcher(num77));
		num50 = 1.0 / (num44 - num37);
		num28 = num44 * sgp_data_0.eo * num50;
		num29 = SxPxMath.CountWatcher(num28);
		num26 = sgp_data_0.eo * num28;
		num36 = Math.Abs(1.0 - num29);
		num16 = num30 * Math.Pow(num50, 4.0);
		num17 = num16 / Math.Pow(num36, 3.5);
		num2 = num17 * num62 * (num44 * (1.0 + 1.5 * num29 + num26 * (4.0 + num29)) + 0.000405980925 * num50 / num36 * num53 * (8.0 + 3.0 * num29 * (8.0 + num29)));
		num88 = sgp_data_0.bstar * num2;
		num38 = Math.Sin(sgp_data_0.xincl);
		num22 = 0.004690140306468833 * Math.Pow(1.0, 3.0);
		num13 = num16 * num50 * num22 * num62 * 1.0 * num38 / sgp_data_0.eo;
		num52 = 1.0 - num48;
		num14 = 2.0 * num62 * num17 * num44 * num77 * (num28 * (2.0 + 0.5 * num29) + sgp_data_0.eo * (0.5 + 2.0 * num29) - 0.0010826158 * num50 / (num44 * num36) * (-3.0 * num53 * (1.0 - 2.0 * num26 + num29 * (1.5 - 0.5 * num26)) + 0.75 * num52 * (2.0 * num29 - num26 * (1.0 + num29)) * Math.Cos(2.0 * sgp_data_0.omegao)));
		num15 = 2.0 * num17 * num44 * num77 * (1.0 + 2.75 * (num29 + num26) + num26 * num29);
		num49 = SxPxMath.CountWatcher(num48);
		num45 = 0.0016239237 * num35 * num62;
		num46 = num45 * 0.0005413079 * num35;
		num47 = 7.762359374999998E-07 * num35 * num35 * num62;
		num59 = num62 + 0.5 * num45 * num66 * num53 + 0.0625 * num46 * num66 * (13.0 - 78.0 * num48 + 137.0 * num49);
		num51 = 1.0 - 5.0 * num48;
		num32 = -0.5 * num45 * num51 + 0.0625 * num46 * (7.0 - 114.0 * num48 + 395.0 * num49) + num47 * (3.0 - 36.0 * num48 + 49.0 * num49);
		num56 = (0.0 - num45) * num18;
		num61 = num56 + (0.5 * num46 * (4.0 - 19.0 * num48) + 2.0 * num47 * (3.0 - 7.0 * num48)) * num18;
		num31 = sgp_data_0.bstar * num13 * Math.Cos(sgp_data_0.omegao);
		num58 = -2.0 / 3.0 * num16 * sgp_data_0.bstar * 1.0 / num26;
		num60 = 3.5 * num77 * num56 * num88;
		double num69 = 1.5 * num88;
		num57 = 0.125 * num22 * num38 * (3.0 + 5.0 * num18) / (1.0 + num18);
		num55 = 0.25 * num22 * num38;
		num24 = Math.Pow(1.0 + num28 * Math.Cos(sgp_data_0.xmo), 3.0);
		num39 = Math.Sin(sgp_data_0.xmo);
		num54 = 7.0 * num48 - 1.0;
		if (num63 == 0)
		{
			num99 = SxPxMath.CountWatcher(num88);
			num19 = 4.0 * num44 * num50 * num99;
			num43 = num19 * num50 * num88 / 3.0;
			num20 = (17.0 * num44 + num37) * num43;
			num21 = 0.5 * num43 * num44 * num50 * (221.0 * num44 + 31.0 * num37) * num88;
			num40 = num19 + 2.0 * num99;
			num41 = 0.25 * (3.0 * num20 + num88 * (12.0 * num19 + 10.0 * num99));
			num42 = 0.2 * (3.0 * num21 + 12.0 * num88 * num20 + 6.0 * num19 * num19 + 15.0 * num99 * (2.0 * num19 + num99));
		}
		double num70 = sgp_data_0.xmo + num59 * double_0;
		double num71 = sgp_data_0.omegao + num32 * double_0;
		double num72 = sgp_data_0.xnodeo + num61 * double_0;
		double num73 = num71;
		double num74 = num70;
		double num75 = SxPxMath.CountWatcher(double_0);
		double num76 = num72 + num60 * num75;
		double num78 = 1.0 - num88 * double_0;
		double num79 = sgp_data_0.bstar * num14 * double_0;
		double num80 = num69 * num75;
		if (num63 == 0)
		{
			double num81 = num31 * double_0;
			double num82 = num58 * (Math.Pow(1.0 + num28 * Math.Cos(num70), 3.0) - num24);
			num43 = num81 + num82;
			num74 = num70 + num43;
			num73 = num71 - num43;
			double num83 = num75 * double_0;
			double num84 = double_0 * num83;
			num78 = num78 - num19 * num75 - num20 * num83 - num21 * num84;
			num79 += sgp_data_0.bstar * num15 * (Math.Sin(num74) - num39);
			num80 = num80 + num40 * num83 + num84 * (num41 + double_0 * num42);
		}
		double num85 = num44 * SxPxMath.CountWatcher(num78);
		double num86 = sgp_data_0.eo - num79;
		double num87 = num74 + num73 + num76 + num62 * num80;
		double double_ = Math.Sqrt(1.0 - SxPxMath.CountWatcher(num86));
		double num89 = num65 / Math.Pow(num85, 1.5);
		double num90 = num86 * Math.Cos(num73);
		num43 = 1.0 / (num85 * SxPxMath.CountWatcher(double_));
		double num91 = num43 * num57 * num90;
		double num92 = num43 * num55;
		double num93 = num87 + num91;
		double num94 = num86 * Math.Sin(num73) + num92;
		double double_2 = num93 - num76;
		double num95 = SxPxMath.CloneWatcher(ref double_2);
		num46 = num95;
		num64 = 1;
		double num96;
		double num97;
		double num98;
		double num100;
		double num101;
		double num102;
		do
		{
			num96 = Math.Sin(num46);
			num97 = Math.Cos(num46);
			num47 = num90 * num96;
			num98 = num94 * num97;
			num100 = num90 * num97;
			num101 = num94 * num96;
			num102 = (num95 - num98 + num47 - num46) / (1.0 - num100 - num101) + num46;
			num67 = num46;
			num46 = num102;
			num64++;
		}
		while ((num64 <= 10) & (Math.Abs(num102 - num67) > 1E-06));
		double num103 = num100 + num101;
		double num104 = num47 - num98;
		double num105 = SxPxMath.CountWatcher(num90) + SxPxMath.CountWatcher(num94);
		num43 = 1.0 - num105;
		double num106 = num85 * num43;
		double num107 = num85 * (1.0 - num103);
		num45 = 1.0 / num107;
		double num108 = num65 * Math.Sqrt(num85) * num104 * num45;
		double num109 = num65 * Math.Sqrt(num106) * num45;
		num46 = num85 * num45;
		double num3 = Math.Sqrt(num43);
		num47 = 1.0 / (1.0 + num3);
		double double_3 = num46 * (num97 - num90 + num94 * num104 * num47);
		double double_4 = num46 * (num96 - num94 - num90 * num104 * num47);
		double num4 = SxPxMath.MoveWatcher(ref double_4, ref double_3);
		double num5 = 2.0 * double_4 * double_3;
		double num6 = 2.0 * SxPxMath.CountWatcher(double_3) - 1.0;
		num43 = 1.0 / num106;
		num45 = 0.0005413079 * num43;
		num46 = num45 * num43;
		double num7 = num107 * (1.0 - 1.5 * num46 * num3 * num53) + 0.5 * num45 * num52 * num6;
		double num8 = num4 - 0.25 * num46 * num54 * num5;
		double num9 = num76 + 1.5 * num46 * num18 * num5;
		double num10 = sgp_data_0.xincl + 1.5 * num46 * num18 * num38 * num6;
		double num11 = num108 - num89 * num45 * num52 * num5;
		double num12 = num109 + num89 * num45 * (num52 * num6 + 1.5 * num53);
		vector.v[0] = (0.0 - Math.Sin(num9)) * Math.Cos(num10);
		vector.v[1] = Math.Cos(num9) * Math.Cos(num10);
		vector.v[2] = Math.Sin(num10);
		vector2.v[0] = Math.Cos(num9);
		vector2.v[1] = Math.Sin(num9);
		vector2.v[2] = 0.0;
		for (num64 = 0; num64 < 3; num64++)
		{
			vector3.v[num64] = vector.v[num64] * Math.Sin(num8) + vector2.v[num64] * Math.Cos(num8);
			vector4.v[num64] = vector.v[num64] * Math.Cos(num8) - vector2.v[num64] * Math.Sin(num8);
		}
		for (num64 = 0; num64 < 3; num64++)
		{
			vector_0.v[num64] = num7 * vector3.v[num64];
			vector_1.v[num64] = num11 * vector3.v[num64] + num12 * vector4.v[num64];
		}
	}

	public static void sdp4(ref double double_0, ref SxPxConstants.vector vector_0, ref SxPxConstants.vector vector_1, ref SxPxConstants.sgp_data sgp_data_0)
	{
		SxPxConstants.vector vector = default(SxPxConstants.vector);
		vector.v = new double[4];
		SxPxConstants.vector vector2 = default(SxPxConstants.vector);
		vector2.v = new double[4];
		SxPxConstants.vector vector3 = default(SxPxConstants.vector);
		vector3.v = new double[4];
		SxPxConstants.vector vector4 = default(SxPxConstants.vector);
		vector4.v = new double[4];
		double num = 0.0;
		double num12 = 0.0;
		double num23 = 0.0;
		double num34 = 0.0;
		double num45 = 0.0;
		double num56 = 0.0;
		double num67 = 0.0;
		double num78 = 0.0;
		double num84 = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num13 = 0.0;
		double num14 = 0.0;
		double num15 = 0.0;
		double num16 = 0.0;
		double num17 = 0.0;
		double num18 = 0.0;
		double num19 = 0.0;
		double num20 = 0.0;
		double num21 = 0.0;
		double num22 = 0.0;
		double num24 = 0.0;
		double num25 = 0.0;
		double num26 = 0.0;
		double num27 = 0.0;
		double num28 = 0.0;
		double num29 = 0.0;
		double num30 = 0.0;
		double num31 = 0.0;
		double num32 = 0.0;
		double num33 = 0.0;
		double num35 = 0.0;
		double num36 = 0.0;
		double num37 = 0.0;
		double num38 = 0.0;
		double emm = 0.0;
		double xincc = 0.0;
		double num39 = 0.0;
		num39 = Math.Sqrt(1434962880.0 / SxPxMath.RevertSpecification(6378.135));
		double num40 = SxPxMath.CountWatcher(SxPxMath.CountWatcher(0.006584997024992489));
		num22 = num39 / sgp_data_0.xno;
		num = Math.Pow(num22, 2.0 / 3.0);
		num5 = Math.Cos(sgp_data_0.xincl);
		num25 = SxPxMath.CountWatcher(num5);
		num30 = 3.0 * num25 - 1.0;
		num9 = SxPxMath.CountWatcher(sgp_data_0.eo);
		num67 = 1.0 - num9;
		num56 = Math.Sqrt(num67);
		num6 = 0.00081196185 * num30 / (SxPxMath.CountWatcher(num) * num56 * num67);
		num23 = num * (1.0 - num6 * (1.0 / 3.0 + num6 * (1.0 + 1.654320987654321 * num6)));
		num7 = 0.00081196185 * num30 / (SxPxMath.CountWatcher(num23) * num56 * num67);
		num38 = sgp_data_0.xno / (1.0 + num7);
		num34 = num23 / (1.0 - num7);
		num18 = 1.0122292801892716;
		num17 = num40;
		num14 = (num34 * (1.0 - sgp_data_0.eo) - 1.0) * 6378.135;
		if (num14 < 156.0)
		{
			num18 = num14 - 78.0;
			if (num14 <= 98.0)
			{
				num18 = 20.0;
			}
			num17 = Math.Pow((120.0 - num18) * 1.0 / 6378.135, 4.0);
			num18 = num18 / 6378.135 + 1.0;
		}
		num15 = 1.0 / (SxPxMath.CountWatcher(num34) * SxPxMath.CountWatcher(num67));
		num19 = Math.Sin(sgp_data_0.omegao);
		num4 = Math.Cos(sgp_data_0.omegao);
		num27 = 1.0 / (num34 - num18);
		num10 = num34 * sgp_data_0.eo * num27;
		num11 = SxPxMath.CountWatcher(num10);
		num8 = sgp_data_0.eo * num10;
		num16 = Math.Abs(1.0 - num11);
		num3 = num17 * Math.Pow(num27, 4.0) / Math.Pow(num16, 3.5);
		num84 = num3 * num38 * (num34 * (1.0 + 1.5 * num11 + num8 * (4.0 + num11)) + 0.000405980925 * num27 / num16 * num30 * (8.0 + 3.0 * num11 * (8.0 + num11)));
		num78 = sgp_data_0.bstar * num84;
		num20 = Math.Sin(sgp_data_0.xincl);
		num12 = 0.004690140306468833 * Math.Pow(1.0, 3.0);
		num29 = 1.0 - num25;
		num2 = 2.0 * num38 * num3 * num34 * num67 * (num10 * (2.0 + 0.5 * num11) + sgp_data_0.eo * (0.5 + 2.0 * num11) - 0.0010826158 * num27 / (num34 * num16) * (-3.0 * num30 * (1.0 - 2.0 * num8 + num11 * (1.5 - 0.5 * num8)) + 0.75 * num29 * (2.0 * num11 - num8 * (1.0 + num11)) * Math.Cos(2.0 * sgp_data_0.omegao)));
		num26 = SxPxMath.CountWatcher(num25);
		num21 = 0.0016239237 * num15 * num38;
		num22 = num21 * 0.0005413079 * num15;
		num24 = 7.762359374999998E-07 * num15 * num15 * num38;
		num35 = num38 + 0.5 * num21 * num56 * num30 + 0.0625 * num22 * num56 * (13.0 - 78.0 * num25 + 137.0 * num26);
		num28 = 1.0 - 5.0 * num25;
		num13 = -0.5 * num21 * num28 + 0.0625 * num22 * (7.0 - 114.0 * num25 + 395.0 * num26) + num24 * (3.0 - 36.0 * num25 + 49.0 * num26);
		num32 = (0.0 - num21) * num5;
		num37 = num32 + (0.5 * num22 * (4.0 - 19.0 * num25) + 2.0 * num24 * (3.0 - 7.0 * num25)) * num5;
		num36 = 3.5 * num67 * num32 * num78;
		double num41 = 1.5 * num78;
		num33 = 0.125 * num12 * num20 * (3.0 + 5.0 * num5) / (1.0 + num5);
		num45 = 0.25 * num12 * num20;
		num31 = 7.0 * num25 - 1.0;
		SxPxConstants.val_deep_init val_deep_init = default(SxPxConstants.val_deep_init);
		val_deep_init.eosq = num9;
		val_deep_init.sinio = num20;
		val_deep_init.cosio = num5;
		val_deep_init.betao = num56;
		val_deep_init.aodp = num34;
		val_deep_init.theta2 = num25;
		val_deep_init.sing = num19;
		val_deep_init.cosg = num4;
		val_deep_init.betao2 = num67;
		val_deep_init.xmdot = num35;
		val_deep_init.omgdot = num13;
		val_deep_init.xnodott = num37;
		val_deep_init.xnodpp = num38;
		SxPxConstants.val_deep_init val_deep_init_ = val_deep_init;
		Sgp_Deep.call_dpinit(ref val_deep_init_, ref sgp_data_0);
		num9 = val_deep_init_.eosq;
		num20 = val_deep_init_.sinio;
		num5 = val_deep_init_.cosio;
		num56 = val_deep_init_.betao;
		num34 = val_deep_init_.aodp;
		num25 = val_deep_init_.theta2;
		num19 = val_deep_init_.sing;
		num4 = val_deep_init_.cosg;
		num67 = val_deep_init_.betao2;
		num35 = val_deep_init_.xmdot;
		num13 = val_deep_init_.omgdot;
		num37 = val_deep_init_.xnodott;
		num38 = val_deep_init_.xnodpp;
		double xmdf = sgp_data_0.xmo + num35 * double_0;
		double omgadf = sgp_data_0.omegao + num13 * double_0;
		double num42 = sgp_data_0.xnodeo + num37 * double_0;
		double num43 = SxPxMath.CountWatcher(double_0);
		double xnode = num42 + num36 * num43;
		double double_ = 1.0 - num78 * double_0;
		double num44 = sgp_data_0.bstar * num2 * double_0;
		double num46 = num41 * num43;
		double xnn = num38;
		SxPxConstants.val_deep_sec val_deep_sec_ = default(SxPxConstants.val_deep_sec);
		val_deep_sec_.xmdf = xmdf;
		val_deep_sec_.omgadf = omgadf;
		val_deep_sec_.xnode = xnode;
		val_deep_sec_.emm = emm;
		val_deep_sec_.xincc = xincc;
		val_deep_sec_.xnn = xnn;
		val_deep_sec_.tsince = double_0;
		Sgp_Deep.call_dpsec(ref val_deep_sec_, ref sgp_data_0);
		xmdf = val_deep_sec_.xmdf;
		omgadf = val_deep_sec_.omgadf;
		xnode = val_deep_sec_.xnode;
		emm = val_deep_sec_.emm;
		xincc = val_deep_sec_.xincc;
		xnn = val_deep_sec_.xnn;
		double_0 = val_deep_sec_.tsince;
		double num47 = Math.Pow(num39 / xnn, 2.0 / 3.0) * SxPxMath.CountWatcher(double_);
		double e = emm - num44;
		double xmam = xmdf + num38 * num46;
		SxPxConstants.val_deep_per val_deep_per_ = default(SxPxConstants.val_deep_per);
		val_deep_per_.e = e;
		val_deep_per_.xincc = xincc;
		val_deep_per_.omgadf = omgadf;
		val_deep_per_.xnode = xnode;
		val_deep_per_.xmam = xmam;
		Sgp_Deep.call_dpper(ref val_deep_per_, ref sgp_data_0);
		e = val_deep_per_.e;
		xincc = val_deep_per_.xincc;
		omgadf = val_deep_per_.omgadf;
		xnode = val_deep_per_.xnode;
		xmam = val_deep_per_.xmam;
		double num48 = xmam + omgadf + xnode;
		double double_2 = Math.Sqrt(1.0 - SxPxMath.CountWatcher(e));
		xnn = num39 / Math.Pow(num47, 1.5);
		double num49 = e * Math.Cos(omgadf);
		double num50 = 1.0 / (num47 * SxPxMath.CountWatcher(double_2));
		double num51 = num50 * num33 * num49;
		double num52 = num50 * num45;
		double num53 = num48 + num51;
		double num54 = e * Math.Sin(omgadf) + num52;
		double double_3 = num53 - xnode;
		double num55 = SxPxMath.CloneWatcher(ref double_3);
		num22 = num55;
		int num57 = 1;
		double num58;
		double num59;
		double num60;
		double num61;
		double num62;
		double num63;
		double num64;
		do
		{
			num58 = Math.Sin(num22);
			num59 = Math.Cos(num22);
			num24 = num49 * num58;
			num60 = num54 * num59;
			num61 = num49 * num59;
			num62 = num54 * num58;
			num63 = (num55 - num60 + num24 - num22) / (1.0 - num61 - num62) + num22;
			num64 = num22;
			num22 = num63;
			num57++;
		}
		while ((num57 <= 10) & (Math.Abs(num63 - num64) > 1E-06));
		double num65 = num61 + num62;
		double num66 = num24 - num60;
		double num68 = SxPxMath.CountWatcher(num49) + SxPxMath.CountWatcher(num54);
		num50 = 1.0 - num68;
		double num69 = num47 * num50;
		double num70 = num47 * (1.0 - num65);
		num21 = 1.0 / num70;
		double num71 = num39 * Math.Sqrt(num47) * num66 * num21;
		double num72 = num39 * Math.Sqrt(num69) * num21;
		num22 = num47 * num21;
		double num73 = Math.Sqrt(num50);
		num24 = 1.0 / (1.0 + num73);
		double double_4 = num22 * (num59 - num49 + num54 * num66 * num24);
		double double_5 = num22 * (num58 - num54 - num49 * num66 * num24);
		double num74 = SxPxMath.MoveWatcher(ref double_5, ref double_4);
		double num75 = 2.0 * double_5 * double_4;
		double num76 = 2.0 * SxPxMath.CountWatcher(double_4) - 1.0;
		num50 = 1.0 / num69;
		num21 = 0.0005413079 * num50;
		num22 = num21 * num50;
		double num77 = num70 * (1.0 - 1.5 * num22 * num73 * num30) + 0.5 * num21 * num29 * num76;
		double num79 = num74 - 0.25 * num22 * num31 * num75;
		double num80 = xnode + 1.5 * num22 * num5 * num75;
		double num81 = xincc + 1.5 * num22 * num5 * num20 * num76;
		double num82 = num71 - xnn * num21 * num29 * num75;
		double num83 = num72 + xnn * num21 * (num29 * num76 + 1.5 * num30);
		vector.v[0] = (0.0 - Math.Sin(num80)) * Math.Cos(num81);
		vector.v[1] = Math.Cos(num80) * Math.Cos(num81);
		vector.v[2] = Math.Sin(num81);
		vector2.v[0] = Math.Cos(num80);
		vector2.v[1] = Math.Sin(num80);
		vector2.v[2] = 0.0;
		for (num57 = 0; num57 < 3; num57++)
		{
			vector3.v[num57] = vector.v[num57] * Math.Sin(num79) + vector2.v[num57] * Math.Cos(num79);
			vector4.v[num57] = vector.v[num57] * Math.Cos(num79) - vector2.v[num57] * Math.Sin(num79);
		}
		for (num57 = 0; num57 < 3; num57++)
		{
			vector_0.v[num57] = num77 * vector3.v[num57];
			vector_1.v[num57] = num82 * vector3.v[num57] + num83 * vector4.v[num57];
		}
	}

	public static void sgp4call(double double_0, ref SxPxConstants.vector vector_0, ref SxPxConstants.vector vector_1, SxPxConstants.sgp_data sgp_data_0)
	{
		double double_ = (double_0 - sgp_data_0.julian_epoch) * 1440.0;
		if (sgp_data_0.ideep == 0)
		{
			sgp4(double_, ref vector_0, ref vector_1, sgp_data_0);
		}
		else
		{
			sdp4(ref double_, ref vector_0, ref vector_1, ref sgp_data_0);
		}
	}
}
