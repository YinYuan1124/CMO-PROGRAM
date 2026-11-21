using System.Collections.Generic;

namespace Command_Core;

public interface ICargoClient
{
	CargoType GetRequiredCargoType();

	float GetRequiredCrewSpace();

	float GetRequiredArea();

	float GetRequiredMass();

	bool GetParadropCapable();

	string GetCargoName();

	string GetCargoObjectID();

	int imethod_0();

	PlatformComponent._ComponentStatus GetCargoObjectStatus();

	PlatformComponent._DamageSeverityFactor GetCargoObjectDamageSeverity();

	string GetCargoObjectReasonForInoperative();

	string GetCargoObjectLossString();

	string CargoObjectToXML(HashSet<string> hashSet_0, Scenario scenario_0);

	void imethod_1();

	void DestroyCargoObject(Side side_0, bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null);

	bool WantsToUnload();

	bool IsTowable();

	bool IsStackable();

	float GetRequiredHeight();

	float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_0);

	bool isMatch(Cargo cargo_0);

	int GetCargoQuantity();
}
