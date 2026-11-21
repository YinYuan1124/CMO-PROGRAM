using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace CSMaterial.Sonar;

public sealed class SonarRender
{
	public int SideGutter_px = 75;

	public int TopGutter_px = 75;

	public int Width_px;

	public int Height_px;

	public List<TerrainProfiler_Step> TerrainData = new List<TerrainProfiler_Step>();

	public WriteableBitmap SubjectABitmap;

	public WriteableBitmap SubjectBBitmap;

	public double LeftDepth_m;

	public double RightDepth_m;

	public double Dist_m;

	public double MaxHeight_m;

	public double MinHeight_m;

	public WriteableBitmap Bitmap;

	public void Render()
	{
	}
}
