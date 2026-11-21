using System.Collections.Generic;

namespace CSMaterial.Sonar;

public sealed class TerrainProfiler_Step
{
	public double Height;

	public List<TerrainProfiler_Layer> Layers = new List<TerrainProfiler_Layer>();

	public TerrainProfiler_Step(double double_0)
	{
		Height = double_0;
	}
}
