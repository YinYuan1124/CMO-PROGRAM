namespace Command_Core;

public interface ITerrainProvider
{
	string TerrainFilesPath { get; set; }

	bool Initialize();

	short GetElevation(double double_0, double double_1, bool bool_0);

	void DisposeResources();

	(bool IsOverland, short? RetrievedElevation) PointIsOverland(double double_0, double double_1);

	float LandPercentageInThisSquare(double double_0, double double_1, float float_0);

	bool GeopointsAreOnSameOrAdjacentCell(double double_0, double double_1, double double_2, double double_3);

	Terrain.TerrainRasterCell[] GetAllCellsInThisRadius(double double_0, double double_1, float float_0, bool bool_0);

	Terrain.TerrainRasterCell GetSingleRasterCell(double double_0, double double_1);

	short GetMaxForThisDegCell(double double_0, double double_1);

	short GetMinForThisDegCell(double double_0, double double_1);
}
