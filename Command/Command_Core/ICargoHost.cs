using System.Collections.Generic;

namespace Command_Core;

public interface ICargoHost
{
	Cargo[] CargoArray { get; set; }

	float GetCargo_Crew();

	float GetCargo_Area();

	CargoType GetCargo_Type();

	float GetCargo_Mass();

	float GetCargo_TowingCapacity();

	bool GetCargo_ParadropCapable();

	int GetLoadTime(List<Cargo> list_0);

	int GetUnloadTime(List<Cargo> list_0);

	bool CanLoad(ICargoClient icargoClient_0);

	bool CanTow(ICargoClient icargoClient_0);

	bool Add(Cargo cargo_0);

	bool Remove(Cargo cargo_0);

	float GetCargo_MassAvailable();

	bool CanStackCargo();

	float GetCargo_Height();
}
