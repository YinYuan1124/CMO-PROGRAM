using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoLiquidFuel : CargoContainerContent
{
	public const float DENSITY_AVIATION_FUEL = 0.8f;

	public const float DENSITY_DIESEL_FUEL = 0.85f;

	public const float DENSITY_OIL_FUEL = 0.875f;

	public const float DENSITY_GAS_FUEL = 0.875f;

	public const float DENSITY_GASOLINE_FUEL = 0.75f;

	public FuelRec._FuelType FuelType;

	public float CurrentQuantity;

	public CargoLiquidFuel()
	{
		ContentType = CargoContainerContentType.LiquidFuel;
	}

	public CargoLiquidFuel(short short_0, float float_0)
	{
		FuelType = (FuelRec._FuelType)short_0;
		CurrentQuantity = float_0;
	}

	public CargoLiquidFuel(CargoLiquidFuel cargoLiquidFuel_0)
		: base(cargoLiquidFuel_0)
	{
		FuelType = cargoLiquidFuel_0.FuelType;
		CurrentQuantity = cargoLiquidFuel_0.CurrentQuantity;
	}

	public override bool TransferToUnit(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Cargo cargo_0 = null, float float_0 = 0f)
	{
		FuelRec fuelRec = null;
		List<FuelRec> list = activeUnit_1.Fuel_ReadOnly.ToList();
		if (float_0 == 0f || float_0 > CurrentQuantity)
		{
			float_0 = CurrentQuantity;
		}
		float float_ = DeleteImporter(float_0);
		foreach (FuelRec item in list)
		{
			if (item.FuelType == FuelType)
			{
				fuelRec = item;
				break;
			}
		}
		if (fuelRec == null && activeUnit_1.IsFixedFacility)
		{
			fuelRec = new FuelRec(0, (short)FuelType);
			activeUnit_1.AddFuelRec(fuelRec);
		}
		if (fuelRec == null)
		{
			return false;
		}
		fuelRec.AddFuel(float_);
		if (fuelRec.CurrentQuantity > (float)fuelRec.MaxQuantity)
		{
			if (activeUnit_1.IsFixedFacility)
			{
				fuelRec.MaxQuantity = (int)Math.Round(fuelRec.CurrentQuantity) + 1;
			}
			else
			{
				float float_2 = fuelRec.CurrentQuantity - (float)fuelRec.MaxQuantity;
				float_0 = MoveImporter(float_2);
				fuelRec.CurrentQuantity = fuelRec.MaxQuantity;
			}
		}
		CurrentQuantity -= float_0;
		return true;
	}

	public override bool TransferFromUnit(CargoContainer cargoContainer_0, ActiveUnit activeUnit_0, Cargo cargo_0 = null, float float_0 = 0f)
	{
		List<FuelRec> list = activeUnit_0.Fuel_ReadOnly.ToList();
		if (float_0 == 0f || float_0 > CurrentQuantity)
		{
			float_0 = CurrentQuantity;
		}
		DeleteImporter(float_0);
		foreach (FuelRec item in list)
		{
			if (item.FuelType == FuelType)
			{
				item.CurrentQuantity -= float_0;
				if (!(item.CurrentQuantity < 0f))
				{
					float_0 = 0f;
					break;
				}
				float_0 = -1f * item.CurrentQuantity;
				item.CurrentQuantity = 0f;
			}
		}
		if (float_0 > 0f)
		{
			CurrentQuantity -= float_0;
		}
		if (CurrentQuantity <= 0f)
		{
			return false;
		}
		return true;
	}

	public override float GetRequiredMass()
	{
		float num = CurrentQuantity / 1000f;
		FuelRec._FuelType fuelType = FuelType;
		if (1 == 0)
		{
		}
		float result = fuelType switch
		{
			FuelRec._FuelType.DieselFuel => num * 0.85f, 
			FuelRec._FuelType.OilFuel => num * 0.875f, 
			FuelRec._FuelType.GasFuel => num * 0.875f, 
			FuelRec._FuelType.Gasoline => num * 0.75f, 
			FuelRec._FuelType.AviationFuel => num * 0.8f, 
			_ => num, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override string GetCargoName()
	{
		switch (FuelType)
		{
		case FuelRec._FuelType.DieselFuel:
			Name = "Diesel Fuel";
			break;
		case FuelRec._FuelType.OilFuel:
			Name = "Oil Fuel";
			break;
		case FuelRec._FuelType.GasFuel:
			Name = "Gas Fuel";
			break;
		case FuelRec._FuelType.Gasoline:
			Name = "Gasoline";
			break;
		case FuelRec._FuelType.AviationFuel:
			Name = "Aviation Fuel";
			break;
		}
		int num = (int)Math.Round(CurrentQuantity);
		if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			Name = string.Concat(str2: ((int)Math.Round(Cargo.DisplayValueLiquidVolume(CurrentQuantity, bool_0: true))).ToString(), str0: Name, str1: " (", str3: " gallons)");
		}
		else
		{
			Name = Name + " (" + num + " liters)";
		}
		return Name;
	}

	public override int GetCargoQuantity()
	{
		return (int)Math.Round(CurrentQuantity + 0.5f);
	}

	public override bool isMatch(Cargo cargo_0)
	{
		if (cargo_0.CargoObjectContainerContents != null && cargo_0.CargoObjectContainerContents.ContentType == CargoContainerContentType.LiquidFuel && ((CargoLiquidFuel)cargo_0.CargoObjectContainerContents).FuelType == FuelType)
		{
			return true;
		}
		return false;
	}

	public override bool isMatch(CargoContainerContent cargoContainerContent_0)
	{
		if (cargoContainerContent_0.ContentType == CargoContainerContentType.LiquidFuel && ((CargoLiquidFuel)cargoContainerContent_0).FuelType == FuelType)
		{
			return true;
		}
		return false;
	}

	public override bool isExactMatch(CargoContainerContent cargoContainerContent_0)
	{
		if (cargoContainerContent_0.ContentType == CargoContainerContentType.LiquidFuel)
		{
			CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent_0;
			if (cargoLiquidFuel.FuelType == FuelType && cargoLiquidFuel.CurrentQuantity == CurrentQuantity)
			{
				return true;
			}
		}
		return false;
	}

	public override float GetQuantityDifference(CargoContainerContent cargoContainerContent_0)
	{
		if (isMatch(cargoContainerContent_0))
		{
			return CurrentQuantity - ((CargoLiquidFuel)cargoContainerContent_0).CurrentQuantity;
		}
		return 0f;
	}

	public override void SetQuantity(float float_0)
	{
		CurrentQuantity = float_0;
	}

	internal string ConnectImporter(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		string[] obj = new string[5] { "<FT>", null, null, null, null };
		int fuelType = (int)FuelType;
		obj[1] = fuelType.ToString();
		obj[2] = "</FT><CQ>";
		obj[3] = XmlConvert.ToString(CurrentQuantity);
		obj[4] = "</CQ>";
		return string.Concat(obj);
	}

	public void SubclassFromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlNode_0.ChildNodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				try
				{
					string name = xmlNode.Name;
					if (Operators.CompareString(name, "FT", TextCompare: false) == 0)
					{
						FuelType = (FuelRec._FuelType)Conversions.ToShort(xmlNode.InnerText);
					}
					else if (Operators.CompareString(name, "CQ", TextCompare: false) == 0)
					{
						CurrentQuantity = XmlConvert.ToSingle(xmlNode.InnerText);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	internal float MoveImporter(float float_0)
	{
		float result = 0f;
		if (float_0 > 0f)
		{
			switch (FuelType)
			{
			case FuelRec._FuelType.DieselFuel:
				result = float_0 / 0.85f;
				break;
			case FuelRec._FuelType.OilFuel:
				result = float_0 / 0.875f;
				break;
			case FuelRec._FuelType.GasFuel:
				result = float_0 / 0.875f;
				break;
			case FuelRec._FuelType.Gasoline:
				result = float_0 / 0.75f;
				break;
			case FuelRec._FuelType.AviationFuel:
				result = float_0 / 0.8f;
				break;
			}
		}
		return result;
	}

	internal float DeleteImporter(float float_0)
	{
		float result = 0f;
		if (float_0 > 0f)
		{
			switch (FuelType)
			{
			case FuelRec._FuelType.DieselFuel:
				result = float_0 * 0.85f;
				break;
			case FuelRec._FuelType.OilFuel:
				result = float_0 * 0.875f;
				break;
			case FuelRec._FuelType.GasFuel:
				result = float_0 * 0.875f;
				break;
			case FuelRec._FuelType.Gasoline:
				result = float_0 * 0.75f;
				break;
			case FuelRec._FuelType.AviationFuel:
				result = float_0 * 0.8f;
				break;
			}
		}
		return result;
	}
}
