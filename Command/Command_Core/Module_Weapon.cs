using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_Weapon
{
	internal static float CollectTokenizer(object object_0)
	{
		double num = (double)(float)((Weapon)object_0).FindReponse() * 9.81;
		float currentAltitude = ((Module_Unit.Unit)object_0).GetCurrentAltitude();
		Weather.TAtmosphere tAtmosphere = Weather.VisitDescriptor(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, (int)Math.Round(currentAltitude), ((ActiveUnit)object_0).WeatherAtMyLocation.GetActualTemp_CurrentScenarioTime(((ActiveUnit)object_0).ParentScen, ((Module_Unit.Unit)object_0).GetLatitude(), ((Module_Unit.Unit)object_0).GetLongitude(), currentAltitude));
		double num2 = tAtmosphere.Pressure * 100.0 / (287.058 * tAtmosphere.Temperature) + tAtmosphere.Rho / 1000.0;
		double num3 = Math.PI * Math.Pow(((Weapon)object_0).Diameter / 2f, 2.0);
		double num4 = ((Weapon)object_0).RemoveReponse();
		return (float)(Math.Sqrt(2.0 * num / (num2 * num4 * num3)) * 1.94384);
	}
}
