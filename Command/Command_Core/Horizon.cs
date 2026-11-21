using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Horizon
{
	internal static float ForgotInvocation(Module_Unit.Unit unit_0, ref float float_0, Sensor sensor_0)
	{
		return CountClass(Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(unit_0, sensor_0), float_0);
	}

	internal static float CollectInvocation(Module_Unit.Unit unit_0, Module_Unit.Unit unit_1, Sensor sensor_0)
	{
		float float_ = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(unit_1);
		return CountClass(Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(unit_0, sensor_0), float_);
	}

	internal static float OrderInvocation(Module_Unit.Unit unit_0, ref float float_0, Sensor sensor_0)
	{
		return RevertInvocation(unit_0.GetCurrentAltitude() + (float)unit_0.GetMastHeight_Visual(sensor_0), float_0);
	}

	internal static float RegisterInvocation(Module_Unit.Unit unit_0, Module_Unit.Unit unit_1, Sensor sensor_0)
	{
		float float_ = unit_0.GetCurrentAltitude() + (float)unit_0.GetMastHeight_Visual(sensor_0);
		float float_2 = unit_1.GetCurrentAltitude() + (float)unit_1.GetMastHeight_Visual();
		return RevertInvocation(float_, float_2);
	}

	internal static float ManageInvocation(float float_0, float float_1)
	{
		double num = Math.Sqrt(12742000.0 * (double)float_0 + Math.Pow(float_0, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)float_1 + Math.Pow(float_1, 2.0));
		return (float)((num + num2) * 0.000539957);
	}

	internal static float RevertInvocation(float float_0, float float_1)
	{
		double num = Math.Sqrt(12742000.0 * (double)float_0 + Math.Pow(float_0, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)float_1 + Math.Pow(float_1, 2.0));
		return (float)((num + num2) * 0.000539957 * 1.06);
	}

	internal static float CountClass(float float_0, float float_1)
	{
		double num = Math.Sqrt(12742000.0 * (double)float_0 + Math.Pow(float_0, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)float_1 + Math.Pow(float_1, 2.0));
		return (float)((num + num2) * 0.000539957 * 1.23);
	}

	internal static float CustomizeClass(float float_0, float float_1)
	{
		double num = Math.Sqrt(12742000.0 * (double)float_0 + Math.Pow(float_0, 2.0));
		double num2 = Math.Sqrt(12742000.0 * (double)float_1 + Math.Pow(float_1, 2.0));
		return (float)((num + num2) * 0.000539957 * 1.5);
	}
}
