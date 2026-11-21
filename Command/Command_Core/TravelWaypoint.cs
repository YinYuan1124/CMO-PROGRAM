using System;

namespace Command_Core;

public sealed class TravelWaypoint
{
	public DateTime TimeStamp;

	public Geopoint_Struct position;

	public float CurrentSpeed;

	public float CurrentHeading;

	private float m_CreatorProxy;

	public TravelWaypoint()
	{
	}

	public TravelWaypoint(Geopoint_Struct geopoint_Struct_0, DateTime dateTime_0, float float_0, float float_1)
	{
		TimeStamp = dateTime_0;
		position = geopoint_Struct_0;
		CurrentSpeed = float_0;
		CurrentHeading = float_1;
	}

	public void CopyDataToWeapon(ref Weapon weapon_0)
	{
		weapon_0.CurrentSpeed = CurrentSpeed;
		weapon_0.CurrentHeading = CurrentHeading;
		weapon_0.SetLongitude(null, position.Longitude);
		weapon_0.SetLatitude(null, position.Latitude);
		weapon_0.SetCurrentAltitude(bool_0: false, position.Altitude);
	}

	public void CopyDataToContact(ref Contact contact_0)
	{
		contact_0.CurrentSpeed = CurrentSpeed;
		contact_0.CurrentHeading = CurrentHeading;
		contact_0.SetLongitude(null, position.Longitude);
		contact_0.SetLatitude(null, position.Latitude);
		contact_0.SetCurrentAltitude(bool_0: false, position.Altitude);
	}
}
