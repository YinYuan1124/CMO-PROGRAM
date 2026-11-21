using System.Collections.Generic;

namespace Command_Core;

public sealed class DLZResultData
{
	public List<TrajectoryPoint> TargetFutureBallisticPath;

	public List<GStruct1> WeaponTrack;

	public List<GStruct1> TargetFutureBallisticTrack;

	public List<GStruct1> TargetTrack;

	public List<GStruct1> InterceptPointTrack;

	public DLZResultData()
	{
		WeaponTrack = new List<GStruct1>();
		TargetTrack = new List<GStruct1>();
		InterceptPointTrack = new List<GStruct1>();
	}

	public void InsertData(double double_0, Weapon weapon_0, Contact contact_0, Geopoint_Struct geopoint_Struct_0)
	{
		InterceptPointTrack.Add(new GStruct1
		{
			Alt = geopoint_Struct_0.Altitude,
			Lat = geopoint_Struct_0.Latitude,
			Lon = geopoint_Struct_0.Longitude,
			Time = double_0
		});
		InsertData(double_0, weapon_0, contact_0);
	}

	public void InsertData(double double_0, Weapon weapon_0, Contact contact_0)
	{
		WeaponTrack.Add(new GStruct1
		{
			Alt = weapon_0.GetCurrentAltitude(),
			Lat = weapon_0.GetLatitude(),
			Lon = weapon_0.GetLongitude(),
			Time = double_0
		});
		TargetTrack.Add(new GStruct1
		{
			Alt = contact_0.GetCurrentAltitude(),
			Lat = contact_0.GetLatitude(),
			Lon = contact_0.GetLongitude(),
			Time = double_0
		});
	}
}
