using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public sealed class StoredCourse
{
	public List<TravelWaypoint> Waypoints;

	private int _ValueProxy;

	private int tokenizerProxy;

	private float _StubProxy;

	private double m_WriterProxy;

	public StoredCourse()
	{
		_ValueProxy = 0;
		tokenizerProxy = 0;
		_StubProxy = 0f;
		m_WriterProxy = 0.0;
		Waypoints = new List<TravelWaypoint>();
	}

	internal bool PushSpecification()
	{
		if (Waypoints.Count <= 0)
		{
			return true;
		}
		return false;
	}

	private void InvokeSpecification(Geopoint_Struct geopoint_Struct_0, DateTime dateTime_0, float float_0, float float_1)
	{
		Waypoints.Add(new TravelWaypoint(geopoint_Struct_0, dateTime_0, float_0, float_1));
	}

	public void AddWaypoint(TravelWaypoint travelWaypoint_0, bool bool_0 = true)
	{
		Waypoints.Add(travelWaypoint_0);
		IncludeSpecification();
		SearchSpecification();
	}

	internal float SetupSpecification(int int_0, int int_1)
	{
		return Math2.RunClass(Waypoints[int_0].position.DisableInvocation(), Waypoints[int_1].position.DisableInvocation());
	}

	internal double ExcludeSpecification(int int_0, int int_1)
	{
		if (Waypoints.Count - 1 >= int_0 && Waypoints.Count - 1 >= int_1)
		{
			return (Waypoints[int_1].TimeStamp - Waypoints[int_0].TimeStamp).TotalSeconds;
		}
		return 0.0;
	}

	internal float IncludeSpecification(bool bool_0 = false)
	{
		if (Waypoints.Count >= 2 && (bool_0 || tokenizerProxy <= Waypoints.Count - 2))
		{
			if (bool_0)
			{
				_StubProxy = 0f;
				int num = Waypoints.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					_StubProxy += SetupSpecification(i, i + 1);
				}
			}
			else
			{
				int num2 = tokenizerProxy;
				int num3 = Waypoints.Count - 2;
				for (int j = num2; j <= num3; j++)
				{
					_StubProxy += SetupSpecification(j, j + 1);
				}
			}
			tokenizerProxy = Waypoints.Count - 2;
			return _StubProxy;
		}
		return 0f;
	}

	internal double SearchSpecification(bool bool_0 = false)
	{
		if (Waypoints.Count >= 2 && (bool_0 || _ValueProxy <= Waypoints.Count - 2))
		{
			if (bool_0)
			{
				_StubProxy = 0f;
				int num = Waypoints.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					m_WriterProxy += ExcludeSpecification(i, i + 1);
				}
			}
			else
			{
				int valueProxy = _ValueProxy;
				int num2 = Waypoints.Count - 2;
				for (int j = valueProxy; j <= num2; j++)
				{
					m_WriterProxy += ExcludeSpecification(j, j + 1);
				}
			}
			_ValueProxy = Waypoints.Count - 2;
			return m_WriterProxy;
		}
		return 0.0;
	}

	internal StoredCourse EnableSpecification(float float_0)
	{
		if (float_0 != 1f && float_0 != 0f)
		{
			StoredCourse storedCourse = new StoredCourse();
			float num = float_0;
			foreach (TravelWaypoint waypoint in Waypoints)
			{
				num -= 1f;
				if (num == 0f)
				{
					storedCourse.AddWaypoint(waypoint);
					num = float_0;
				}
			}
			return storedCourse;
		}
		return this;
	}

	public void CopyWaypointDataToWeapon(ref Weapon weapon_0, int int_0)
	{
		if (int_0 <= Waypoints.Count - 1 && int_0 >= 0)
		{
			Waypoints.ElementAt(int_0).CopyDataToWeapon(ref weapon_0);
		}
	}

	public void CopyWaypointDataToContact(ref Contact contact_0, int int_0)
	{
		if (int_0 <= Waypoints.Count - 1 && int_0 >= 0)
		{
			Waypoints.ElementAt(int_0).CopyDataToContact(ref contact_0);
		}
	}

	internal int ChangeSpecification(DateTime dateTime_0)
	{
		int num = Waypoints.Count - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (DateTime.Compare(Waypoints.ElementAt(num2).TimeStamp, dateTime_0) == 0)
				{
					break;
				}
				num2++;
				continue;
			}
			return -1;
		}
		return num2;
	}

	internal Trajectory_Str InitSpecification(int int_0)
	{
		if (Waypoints.Count >= int_0 && int_0 != 0)
		{
			Trajectory_Str trajectory_Str = new Trajectory_Str();
			int num = Waypoints.Count - 1;
			int num2 = Waypoints.Count - 1 - int_0;
			int num3 = num;
			for (int i = num2; i <= num3; i++)
			{
				trajectory_Str.MeanSpeed += Waypoints.ElementAt(i).CurrentSpeed;
				trajectory_Str.MeanHeading += Waypoints.ElementAt(i).CurrentHeading;
			}
			if (trajectory_Str.MeanSpeed != 0f && trajectory_Str.MeanHeading != 0f)
			{
				trajectory_Str.MeanSpeed /= int_0;
				trajectory_Str.MeanHeading /= int_0;
				trajectory_Str.AltitudeDeltaPerSecond = (float)((double)(Waypoints.ElementAt(num).position.Altitude - Waypoints.ElementAt(num2).position.Altitude) / ExcludeSpecification(num2, num));
				return trajectory_Str;
			}
			return null;
		}
		return null;
	}

	internal Trajectory_Str CheckSpecification(int int_0, int int_1)
	{
		Trajectory_Str trajectory_Str = InitSpecification(int_0);
		trajectory_Str.AltitudeDeltaPerSecond *= int_1;
		return trajectory_Str;
	}

	internal bool ConcatSpecification(int int_0)
	{
		if (int_0 <= Waypoints.Count - 1 && Waypoints.Count > 0)
		{
			return true;
		}
		return false;
	}
}
