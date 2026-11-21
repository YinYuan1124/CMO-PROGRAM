using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public sealed class LuaWrapper_Cargo
{
	internal Cargo cargo;

	protected Scenario ScenarioContext;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			PropertyInfo[] array3 = array;
			MethodInfo[] array2;
			foreach (PropertyInfo propertyInfo in array3)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				array2 = methods;
				MethodInfo[] array4 = array2;
				foreach (MethodInfo obj2 in array4)
				{
					string right = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, right, TextCompare: false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			array2 = methods;
			MethodInfo[] array5 = array2;
			foreach (MethodInfo methodInfo in array5)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text2 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text2 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text2 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text2 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public object __obj => cargo;

	[DoNotPrune]
	public string guid => cargo.CargoObjectID;

	[DoNotPrune]
	public int type => (int)cargo.CurrentType;

	[DoNotPrune]
	public int storageType => (int)cargo.StorageType;

	[DoNotPrune]
	public int dbid => cargo.CargoObjectDBID;

	[DoNotPrune]
	public string name
	{
		get
		{
			if (string.IsNullOrEmpty(cargo.Name))
			{
				return cargo.CargoObjectName;
			}
			return cargo.Name;
		}
	}

	[DoNotPrune]
	public int requiredSize => (int)cargo.RequiredCargoType;

	[DoNotPrune]
	public float requiredMass => cargo.RequiredMass;

	[DoNotPrune]
	public float requiredArea => cargo.RequiredAreaExternal;

	[DoNotPrune]
	public int Int32_0 => (int)Math.Round(cargo.RequiredCrewSpaceExternal);

	[DoNotPrune]
	public float requiredAreaAsStored => cargo.RequiredArea;

	[DoNotPrune]
	public int Int32_1 => (int)Math.Round(cargo.RequiredCrewSpace);

	[DoNotPrune]
	public bool isParadropCapable => cargo.isParadropCapable;

	[DoNotPrune]
	public LuaWrapper_ActiveUnit unit
	{
		get
		{
			ActiveUnit cargoObjectActiveUnit = cargo.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit == null)
			{
				return null;
			}
			return new LuaWrapper_ActiveUnit(cargoObjectActiveUnit, ScenarioContext);
		}
	}

	[DoNotPrune]
	public LuaTable containerCargo
	{
		get
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer == null)
			{
				return null;
			}
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (cargoObjectContainer.OnboardCargo.Count() > 0)
			{
				Cargo[] onboardCargo = cargoObjectContainer.OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo cargo in array)
				{
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					CargoContainerContent cargoObjectContainerContents = cargo.CargoObjectContainerContents;
					val2["name"] = cargo.CargoObjectName;
					val2["Type"] = (int)cargo.CurrentType;
					val2["dbid"] = cargo.CargoObjectDBID;
					val2["guid"] = cargo.CargoObjectID;
					val2["area"] = cargo.RequiredArea;
					val2["pax"] = cargo.RequiredCrewSpace;
					val2["mass"] = cargo.RequiredMass;
					if (cargoObjectContainerContents != null)
					{
						val2["contentType"] = (int)cargoObjectContainerContents.ContentType;
						switch (cargoObjectContainerContents.ContentType)
						{
						case CargoContainerContent.CargoContainerContentType.LiquidFuel:
						{
							CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoObjectContainerContents;
							val2["fuelType"] = (int)cargoLiquidFuel.FuelType;
							val2["fuelQuantity"] = cargoLiquidFuel.CurrentQuantity;
							break;
						}
						case CargoContainerContent.CargoContainerContentType.Ammunition:
						{
							CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoObjectContainerContents;
							val2["weaponDBID"] = cargoAmmunition.int_0;
							val2["weaponQuantity"] = cargoAmmunition.WeaponQuantity;
							break;
						}
						}
					}
					val[val.Keys.Count + 1] = val2;
				}
			}
			return val;
		}
	}

	public LuaWrapper_Cargo(Cargo cargo_0, Scenario scenario_0)
	{
		cargo = cargo_0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("cargo {\r\n name = '" + name + "', \r\n type = '" + type + "', \r\n dbid = '" + dbid + "', \r\n guid = '" + guid.ToString() + "', \r\n storageType = '" + storageType + "', \r\n size = '" + storageType + "', \r\n mass = '" + requiredMass + "', \r\n area = '" + requiredArea + "', \r\n pax = '" + Int32_0 + "', \r\n isParadropCapable = '" + isParadropCapable + "', \r\n", "}");
	}

	public LuaWrapper_Cargo createContainerContentCustom(string string_0, int int_0, float float_0, float float_1, float float_2)
	{
		if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = cargo.CargoObjectContainer;
			if (cargoObjectContainer != null)
			{
				CargoContainerContent cargoContainerContent = new CargoContainerContent();
				cargoContainerContent.Name = string_0;
				cargoContainerContent.Mass = float_0;
				cargoContainerContent.Area = float_1;
				cargoContainerContent.Volume = float_2;
				cargoContainerContent.Size = (CargoType)int_0;
				if (cargoObjectContainer.PrintProperty(cargoContainerContent))
				{
					Cargo cargo_ = new Cargo(cargoObjectContainer.ParentPlatform, cargoContainerContent, cargoObjectContainer);
					cargoObjectContainer.Add(cargo_);
					return new LuaWrapper_Cargo(cargo_, ScenarioContext);
				}
			}
		}
		return null;
	}

	public LuaWrapper_Cargo createContainerContentFuel(int int_0, float float_0)
	{
		if (this.cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer != null && cargoObjectContainer.ContainerType == CargoContainer.CargoContainerType.Tank)
			{
				CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
				cargoLiquidFuel.FuelType = (FuelRec._FuelType)int_0;
				cargoLiquidFuel.CurrentQuantity = float_0;
				Cargo cargo = null;
				if (cargoObjectContainer.CargoArray.Count() > 0)
				{
					cargo = cargoObjectContainer.CargoArray[0];
					cargoObjectContainer.Remove(cargo);
				}
				if (cargoObjectContainer.PrintProperty(cargoLiquidFuel) && cargoLiquidFuel.CurrentQuantity > 0f)
				{
					Cargo cargo_ = new Cargo(cargoObjectContainer.ParentPlatform, cargoLiquidFuel, cargoObjectContainer);
					cargoObjectContainer.Add(cargo_);
					return new LuaWrapper_Cargo(cargo_, ScenarioContext);
				}
			}
		}
		return null;
	}

	public LuaWrapper_Cargo createContainerContentAmmunition(int int_0, int int_1)
	{
		if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = cargo.CargoObjectContainer;
			if (cargoObjectContainer != null)
			{
				CargoAmmunition cargoAmmunition = new CargoAmmunition(int_0, int_1, ScenarioContext);
				if (cargoObjectContainer.PrintProperty(cargoAmmunition))
				{
					Cargo cargo_ = new Cargo(cargoObjectContainer.ParentPlatform, cargoAmmunition, cargoObjectContainer);
					cargoObjectContainer.Add(cargo_);
					return new LuaWrapper_Cargo(cargo_, ScenarioContext);
				}
			}
		}
		return null;
	}

	public bool deleteContainerContents(string string_0)
	{
		if (this.cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
		{
			CargoContainer cargoObjectContainer = this.cargo.CargoObjectContainer;
			if (cargoObjectContainer != null)
			{
				Cargo[] onboardCargo = cargoObjectContainer.OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo cargo in array)
				{
					if (Operators.CompareString(cargo.CargoObjectID, string_0, TextCompare: false) == 0)
					{
						ArrayExtensions.Remove(ref cargoObjectContainer.OnboardCargo, cargo);
						return true;
					}
				}
			}
		}
		return false;
	}
}
