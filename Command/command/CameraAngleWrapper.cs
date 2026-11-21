using System;
using ExWorldWind;

namespace Command;

public sealed class CameraAngleWrapper
{
	public Angle Latitude;

	public Angle Longitude;

	public CameraAngleWrapper(Angle angle_0, Angle angle_1)
	{
		Latitude = angle_0;
		Longitude = angle_1;
	}

	public static bool IsIdentical(CameraAngleWrapper cameraAngleWrapper_0, CameraAngleWrapper cameraAngleWrapper_1, double double_0 = 0.0)
	{
		if (double_0 == 0.0)
		{
			if (cameraAngleWrapper_0.Longitude.Radians == cameraAngleWrapper_1.Longitude.Radians)
			{
				if (cameraAngleWrapper_0.Latitude.Radians == cameraAngleWrapper_1.Latitude.Radians)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		if (Math.Abs(cameraAngleWrapper_0.Longitude.Radians - cameraAngleWrapper_1.Longitude.Radians) <= double_0)
		{
			if (Math.Abs(cameraAngleWrapper_0.Latitude.Radians - cameraAngleWrapper_1.Latitude.Radians) <= double_0)
			{
				return true;
			}
			return false;
		}
		return false;
	}
}
