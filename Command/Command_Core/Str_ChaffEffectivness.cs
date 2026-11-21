using System.Collections.Generic;

namespace Command_Core;

public sealed class Str_ChaffEffectivness
{
	public Dictionary<GlobalVariables.TargetVisualSizeClass, float> ShipSize;

	public Str_ChaffEffectivness(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		ShipSize = new Dictionary<GlobalVariables.TargetVisualSizeClass, float>();
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.VSmall, float_0);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Small, float_1);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Medium, float_2);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Large, float_3);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.VLarge, float_4);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Stealthy, float_5);
	}
}
