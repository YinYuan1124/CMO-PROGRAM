namespace DotSpatial.Topology;

public interface GInterface4
{
	void Add(GInterface4 ginterface4_0);

	void Set(LocationType locationType_0, LocationType locationType_1, DimensionType dimensionType_0);

	void Set(string string_0);

	void SetAtLeast(LocationType locationType_0, LocationType locationType_1, DimensionType dimensionType_0);

	void SetAtLeastIfValid(LocationType locationType_0, LocationType locationType_1, DimensionType dimensionType_0);

	void SetAtLeast(string string_0);

	void SetAll(DimensionType dimensionType_0);

	DimensionType Get(LocationType locationType_0, LocationType locationType_1);

	bool IsDisjoint();

	bool IsIntersects();

	bool IsTouches(DimensionType dimensionType_0, DimensionType dimensionType_1);

	bool IsCrosses(DimensionType dimensionType_0, DimensionType dimensionType_1);

	bool IsWithin();

	bool IsContains();

	bool IsCovers();

	bool IsEquals(DimensionType dimensionType_0, DimensionType dimensionType_1);

	bool IsOverlaps(DimensionType dimensionType_0, DimensionType dimensionType_1);

	bool Matches(string string_0);

	GInterface4 Transpose();

	new string ToString();
}
