using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class DLZCAche
{
	public string FiringUnit_ID;

	public int Weapon_Id;

	public double FiringUnit_Lat;

	public double FiringUnit_Lon;

	public double Target_Lat;

	public double Target_Lon;

	public float Time;

	public ActiveUnit_Weaponry.DLZResultEnum ResultValue;

	public DLZCAche(string string_0, int int_0, double double_0, double double_1, double double_2, double double_3, float float_0, ActiveUnit_Weaponry.DLZResultEnum dlzresultEnum_0)
	{
		FiringUnit_ID = string_0;
		Weapon_Id = int_0;
		FiringUnit_Lat = double_0;
		FiringUnit_Lon = double_1;
		Target_Lat = double_2;
		Target_Lon = double_3;
		Time = float_0;
		ResultValue = dlzresultEnum_0;
	}

	public DLZCAche()
	{
		FiringUnit_ID = "";
		Weapon_Id = 0;
		FiringUnit_Lat = 0.0;
		FiringUnit_Lon = 0.0;
		Target_Lat = 0.0;
		Target_Lon = 0.0;
		Time = 0f;
		ResultValue = ActiveUnit_Weaponry.DLZResultEnum.None;
	}

	internal bool DeleteRepository(DLZCAche dlzcache_0, DLZCAche dlzcache_1)
	{
		if (Math.Abs(dlzcache_0.FiringUnit_Lat - dlzcache_1.FiringUnit_Lat) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance && Math.Abs(dlzcache_0.FiringUnit_Lon - dlzcache_1.FiringUnit_Lon) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance && Math.Abs(dlzcache_0.Target_Lon - dlzcache_1.Target_Lon) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance && Math.Abs(dlzcache_0.Target_Lat - dlzcache_1.Target_Lat) < (double)ActiveUnit_Weaponry.DLZ_Nm_tolerance)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		DLZCAche dLZCAche = (DLZCAche)obj;
		if (Weapon_Id == dLZCAche.Weapon_Id && Operators.CompareString(FiringUnit_ID, dLZCAche.FiringUnit_ID, TextCompare: false) == 0 && Target_Lat == dLZCAche.Target_Lat)
		{
			return Target_Lon == dLZCAche.Target_Lon;
		}
		return false;
	}
}
