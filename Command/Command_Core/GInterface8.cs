using System.Collections.Generic;

namespace Command_Core;

public interface GInterface8
{
	float DegreeInterval_Coarse { get; }

	float DegreeInterval_Finegrained { get; }

	List<Waypoint> SolvePF_Finegrained(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0);

	List<Waypoint> SolvePF_Coarse(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1);
}
