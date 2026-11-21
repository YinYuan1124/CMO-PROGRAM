using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Sgp
{
	public static void sgp0(double double_0, ref SxPxConstants.vector vector_0, ref SxPxConstants.vector vector_1, SxPxConstants.sgp_data sgp_data_0)
	{
		double num = 0.0;
		double num12 = 0.0;
		double num23 = 0.0;
		double num33 = 0.0;
		double num34 = 0.0;
		double num35 = 0.0;
		double num36 = 0.0;
		double num37 = 0.0;
		double num38 = 0.0;
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
		SxPxConstants.vector vector = default(SxPxConstants.vector);
		vector.v = new double[4];
		SxPxConstants.vector vector2 = default(SxPxConstants.vector);
		vector2.v = new double[4];
		SxPxConstants.vector vector3 = default(SxPxConstants.vector);
		vector3.v = new double[4];
		SxPxConstants.vector vector4 = default(SxPxConstants.vector);
		vector4.v = new double[4];
		vector_0.v = new double[4];
		vector_1.v = new double[4];
		num29 = Math.Sqrt(1434962880.0 / SxPxMath.RevertSpecification(6378.135));
		num11 = num29 / sgp_data_0.xno;
		num = Math.Pow(num11, 2.0 / 3.0);
		num12 = Math.Cos(sgp_data_0.xincl);
		num23 = Math.Sin(sgp_data_0.xincl);
		num33 = 0.00081196185 * (3.0 * SxPxMath.CountWatcher(num12) - 1.0) / (SxPxMath.CountWatcher(num) * Math.Pow(1.0 - SxPxMath.CountWatcher(sgp_data_0.eo), 1.5));
		double num30 = num * (1.0 - 1.0 / 3.0 * num33 - SxPxMath.CountWatcher(num33) - 1.654320987654321 * SxPxMath.CountWatcher(num33) * num33);
		num34 = num30 * (1.0 - SxPxMath.CountWatcher(sgp_data_0.eo));
		num35 = num30 * (1.0 - sgp_data_0.eo);
		num36 = sgp_data_0.xmo + sgp_data_0.omegao + sgp_data_0.xnodeo;
		num37 = -0.0016239237 * (sgp_data_0.xno * num12) / SxPxMath.CountWatcher(num34);
		num38 = 0.00081196185 * (sgp_data_0.xno * (5.0 * SxPxMath.CountWatcher(num12) - 1.0)) / SxPxMath.CountWatcher(num34);
		num2 = sgp_data_0.xno + 2.0 * sgp_data_0.xndt2o * double_0 + 3.0 * sgp_data_0.xndd6o * SxPxMath.CountWatcher(double_0);
		num2 = sgp_data_0.xno / num2;
		num3 = num30 * Math.Pow(num2, 2.0 / 3.0);
		num4 = ((num3 <= num35) ? 1E-06 : (1.0 - num35 / num3));
		num5 = num3 * (1.0 - SxPxMath.CountWatcher(num4));
		num6 = sgp_data_0.xnodeo + num37 * double_0;
		num7 = sgp_data_0.omegao + num38 * double_0;
		double num31 = num36 + (sgp_data_0.xno + num38 + num37) * double_0 + sgp_data_0.xndt2o * SxPxMath.CountWatcher(double_0) + sgp_data_0.xndd6o * SxPxMath.CountWatcher(double_0) * double_0;
		num8 = num4 * Math.Sin(num7) - -2.53881E-06 * num23 / (0.0021652316 * num5);
		num9 = num4 * Math.Cos(num7);
		num11 = -2.53881E-06 * num9 * num23 * (3.0 + 5.0 * num12);
		num13 = 0.0043304632 * num5 * (1.0 + num12);
		num2 = num31 - num11 / num13;
		double double_ = SxPxMath.CloneWatcher(ref num2) - num6;
		num10 = SxPxMath.CloneWatcher(ref double_);
		num2 = num10;
		int num32 = 1;
		do
		{
			num11 = num10 - num8 * Math.Cos(num2) + num9 * Math.Sin(num2) - num2;
			num13 = 1.0 - num8 * Math.Sin(num2) - num9 * Math.Cos(num2);
			num14 = num11 / num13 + num2;
			num11 = num2;
			num2 = num14;
			num32++;
		}
		while ((num32 <= 10) & (Math.Abs(num14 - num11) > 1E-06));
		num15 = num9 * Math.Cos(num14) + num8 * Math.Sin(num14);
		num16 = num9 * Math.Sin(num14) - num8 * Math.Cos(num14);
		num17 = SxPxMath.CountWatcher(num9) + SxPxMath.CountWatcher(num8);
		num18 = num3 * (1.0 - num17);
		num19 = num3 * (1.0 - num15);
		num20 = num29 * Math.Sqrt(num3) * num16 / num19;
		num21 = num29 * Math.Sqrt(num18) / num19;
		num22 = num3 / num19 * (Math.Sin(num14) - num8 - num9 * num16 / (1.0 + Math.Sqrt(1.0 - num17)));
		num24 = num3 / num19 * (Math.Cos(num14) - num9 + num8 * num16 / (1.0 + Math.Sqrt(1.0 - num17)));
		num10 = SxPxMath.MoveWatcher(ref num22, ref num24);
		num26 = num19 + 0.00027065395 * (SxPxMath.CountWatcher(num23) / num18) * Math.Cos(2.0 * num10);
		num27 = num10 - 0.000135326975 * (Math.Sin(2.0 * num10) * (7.0 * SxPxMath.CountWatcher(num12) - 1.0)) / SxPxMath.CountWatcher(num18);
		num28 = num6 + 0.00081196185 * (num12 * Math.Sin(2.0 * num10)) / SxPxMath.CountWatcher(num18);
		num25 = sgp_data_0.xincl + 0.00081196185 * (num23 * num12 * Math.Cos(2.0 * num10)) / SxPxMath.CountWatcher(num18);
		vector.v[0] = (0.0 - Math.Sin(num28)) * Math.Cos(num25);
		vector.v[1] = Math.Cos(num28) * Math.Cos(num25);
		vector.v[2] = Math.Sin(num25);
		vector2.v[0] = Math.Cos(num28);
		vector2.v[1] = Math.Sin(num28);
		vector2.v[2] = 0.0;
		for (num32 = 0; num32 < 3; num32++)
		{
			vector3.v[num32] = vector.v[num32] * Math.Sin(num27) + vector2.v[num32] * Math.Cos(num27);
			vector4.v[num32] = vector.v[num32] * Math.Cos(num27) - vector2.v[num32] * Math.Sin(num27);
		}
		for (num32 = 0; num32 < 3; num32++)
		{
			vector_0.v[num32] = num26 * vector3.v[num32];
			vector_1.v[num32] = num20 * vector3.v[num32] + num21 * vector4.v[num32];
		}
	}

	public static void sgp0call(double double_0, ref SxPxConstants.vector vector_0, ref SxPxConstants.vector vector_1, SxPxConstants.sgp_data sgp_data_0)
	{
		sgp0((double_0 - sgp_data_0.julian_epoch) * 1440.0, ref vector_0, ref vector_1, sgp_data_0);
	}
}
