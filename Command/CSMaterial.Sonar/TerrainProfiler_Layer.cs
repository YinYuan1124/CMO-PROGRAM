using System.Windows.Media;

namespace CSMaterial.Sonar;

public sealed class TerrainProfiler_Layer
{
	public Color color;

	public string Name;

	public double Height_m;

	public double Top_m;

	public TerrainProfiler_Layer(double double_0, double double_1, Color? nullable_0 = null, string string_0 = "")
	{
		Top_m = double_0;
		Height_m = double_1;
		if (nullable_0.HasValue)
		{
			color = nullable_0.Value;
		}
		else
		{
			nullable_0 = Colors.Pink;
		}
		Name = string_0;
	}
}
