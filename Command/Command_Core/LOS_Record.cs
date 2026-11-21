namespace Command_Core;

public sealed class LOS_Record
{
	public string TargetID;

	public bool bool_0;

	public LOS_Record(Module_Unit.Unit unit_0, bool bool_1)
	{
		TargetID = unit_0.ObjectID;
		bool_0 = bool_1;
	}
}
