namespace Command_Core;

public sealed class Trajectory_Str
{
	public float MeanSpeed;

	public float AltitudeDeltaPerSecond;

	public float MeanHeading;

	public Trajectory_Str()
	{
	}

	public Trajectory_Str(float float_0, float float_1, float float_2)
	{
		MeanSpeed = float_0;
		MeanHeading = float_1;
		AltitudeDeltaPerSecond = float_2;
	}
}
