using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoContainerContent : ScenarioObject, ICargoClient
{
	public enum CargoContainerContentType
	{
		Generic,
		Ammunition,
		LiquidFuel
	}

	public ICargoHost Parent;

	public CargoContainerContentType ContentType;

	public CargoType Size;

	public float Mass;

	public float Area;

	public float Height;

	public float Volume;

	public float Crew;

	public CargoContainerContent()
	{
	}

	public CargoContainerContent(CargoContainerContent cargoContainerContent_0)
	{
		Name = cargoContainerContent_0.Name;
		Parent = cargoContainerContent_0.Parent;
		ContentType = cargoContainerContent_0.ContentType;
		Size = cargoContainerContent_0.Size;
		Mass = cargoContainerContent_0.Mass;
		Area = cargoContainerContent_0.Area;
		Height = cargoContainerContent_0.Height;
		Volume = cargoContainerContent_0.Volume;
		Crew = cargoContainerContent_0.Crew;
	}

	public virtual bool TransferToUnit(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Cargo cargo_0 = null, float float_0 = 0f)
	{
		return false;
	}

	public virtual bool TransferFromUnit(CargoContainer cargoContainer_0, ActiveUnit activeUnit_0, Cargo cargo_0 = null, float float_0 = 0f)
	{
		return false;
	}

	public virtual void imethod_1()
	{
		ResetIDs();
	}

	public virtual void DestroyCargoObject(Side side_0, bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
	}

	public virtual CargoType GetRequiredCargoType()
	{
		return Size;
	}

	public virtual float GetRequiredCrewSpace()
	{
		return Crew;
	}

	public virtual float GetRequiredArea()
	{
		return Area;
	}

	public virtual float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_0)
	{
		return GetRequiredArea() * (float)int_0;
	}

	public virtual float GetRequiredMass()
	{
		return Mass;
	}

	public virtual bool GetParadropCapable()
	{
		return false;
	}

	public virtual string GetCargoName()
	{
		if (string.IsNullOrEmpty(Name) && ContentType == CargoContainerContentType.Generic)
		{
			int num = (int)Math.Round(Mass * 1000f);
			if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				return "Generic Cargo (" + (int)Math.Round(Cargo.DisplayValueSmallMass(num, bool_0: true)) + "lbs)";
			}
			return "Generic Cargo (" + num + "kg)";
		}
		return Name;
	}

	public virtual string GetCargoObjectID()
	{
		return ObjectID;
	}

	public virtual int imethod_0()
	{
		return 0;
	}

	public virtual PlatformComponent._ComponentStatus GetCargoObjectStatus()
	{
		return PlatformComponent._ComponentStatus.Operational;
	}

	public virtual PlatformComponent._DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		return PlatformComponent._DamageSeverityFactor.Light;
	}

	public virtual string GetCargoObjectReasonForInoperative()
	{
		return "None";
	}

	public virtual string GetCargoObjectLossString()
	{
		return null;
	}

	public virtual bool IsStackable()
	{
		return false;
	}

	public virtual float GetRequiredHeight()
	{
		return 0f;
	}

	public virtual int GetCargoQuantity()
	{
		return 1;
	}

	public virtual bool isMatch(Cargo cargo_0)
	{
		return false;
	}

	public virtual bool isMatch(CargoContainerContent cargoContainerContent_0)
	{
		return false;
	}

	public virtual bool isExactMatch(CargoContainerContent cargoContainerContent_0)
	{
		return false;
	}

	public virtual float GetQuantityDifference(CargoContainerContent cargoContainerContent_0)
	{
		return 0f;
	}

	public virtual void SetQuantity(float float_0)
	{
	}

	public virtual CargoContainerContent CreateNewContentMatching(float float_0)
	{
		CargoContainerContent cargoContainerContent = null;
		switch (ContentType)
		{
		case CargoContainerContentType.Generic:
			cargoContainerContent = new CargoContainerContent();
			break;
		case CargoContainerContentType.Ammunition:
			cargoContainerContent = new CargoAmmunition
			{
				int_0 = ((CargoAmmunition)this).int_0,
				WeaponQuantity = (int)Math.Round(float_0)
			};
			break;
		case CargoContainerContentType.LiquidFuel:
			cargoContainerContent = new CargoLiquidFuel
			{
				FuelType = ((CargoLiquidFuel)this).FuelType,
				CurrentQuantity = float_0
			};
			break;
		}
		if (cargoContainerContent != null)
		{
			cargoContainerContent.Name = Name;
			cargoContainerContent.Size = Size;
			cargoContainerContent.Mass = Mass;
			cargoContainerContent.Area = Area;
			cargoContainerContent.Volume = Volume;
			cargoContainerContent.Crew = Crew;
		}
		return cargoContainerContent;
	}

	public virtual string CargoObjectToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<CargoContainerContent>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					stringBuilder.Append("</CargoContainerContent>");
					return stringBuilder.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			StringBuilder stringBuilder2 = stringBuilder.Append("<CCCT>");
			int contentType = (int)ContentType;
			stringBuilder2.Append(contentType.ToString()).Append("</CCCT>");
			if (Size != 0)
			{
				StringBuilder stringBuilder3 = stringBuilder.Append("<CT>");
				contentType = (int)Size;
				stringBuilder3.Append(contentType.ToString()).Append("</CT>");
			}
			if (Mass > 0f)
			{
				stringBuilder.Append("<CCCM>").Append(XmlConvert.ToString(Mass)).Append("</CCCM>");
			}
			if (Area > 0f)
			{
				stringBuilder.Append("<CCCA>").Append(XmlConvert.ToString(Area)).Append("</CCCA>");
			}
			if (Volume > 0f)
			{
				stringBuilder.Append("<CCCV>").Append(XmlConvert.ToString(Volume)).Append("</CCCV>");
			}
			if (Height > 0f)
			{
				stringBuilder.Append("<CCCH>").Append(XmlConvert.ToString(Height)).Append("</CCCH>");
			}
			if (Crew > 0f)
			{
				stringBuilder.Append("<CCCC>").Append(XmlConvert.ToString(Crew)).Append("</CCCC>");
			}
			switch (ContentType)
			{
			case CargoContainerContentType.LiquidFuel:
				stringBuilder.Append(((CargoLiquidFuel)this).ConnectImporter(hashSet_0, scenario_0));
				break;
			case CargoContainerContentType.Ammunition:
				stringBuilder.Append(((CargoAmmunition)this).StopProperty(hashSet_0, scenario_0));
				break;
			}
			stringBuilder.Append("</CargoContainerContent>");
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100901", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	public virtual bool WantsToUnload()
	{
		return false;
	}

	public virtual bool IsTowable()
	{
		return false;
	}

	public static CargoContainerContent FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, ActiveUnit activeUnit_0, ICargoHost icargoHost_0 = null)
	{
		try
		{
			CargoContainerContent cargoContainerContent = null;
			CargoContainerContentType cargoContainerContentType = (CargoContainerContentType)Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "CCCT").InnerText);
			switch (cargoContainerContentType)
			{
			case CargoContainerContentType.Generic:
				cargoContainerContent = new CargoContainerContent();
				break;
			case CargoContainerContentType.Ammunition:
				cargoContainerContent = new CargoAmmunition();
				break;
			case CargoContainerContentType.LiquidFuel:
				cargoContainerContent = new CargoLiquidFuel();
				break;
			}
			cargoContainerContent.Parent = icargoHost_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (!Information.IsNothing(concurrentDictionary_0))
			{
				if (concurrentDictionary_0.ContainsKey(innerText))
				{
					return (CargoContainerContent)concurrentDictionary_0[innerText];
				}
				cargoContainerContent.ObjectID_Set(innerText);
				concurrentDictionary_0.TryAdd(cargoContainerContent.ObjectID, cargoContainerContent);
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					try
					{
						switch (xmlNode.Name)
						{
						case "CT":
							cargoContainerContent.Size = (CargoType)Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "Name":
							cargoContainerContent.Name = xmlNode.InnerText;
							break;
						case "CCCC":
							cargoContainerContent.Crew = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "CCCA":
							cargoContainerContent.Area = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "CCCM":
							cargoContainerContent.Mass = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "CCCH":
							cargoContainerContent.Height = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "CCCV":
							cargoContainerContent.Volume = XmlConvert.ToSingle(xmlNode.InnerText);
							break;
						case "CCCT":
							cargoContainerContent.ContentType = (CargoContainerContentType)Conversions.ToInteger(xmlNode.InnerText);
							break;
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
			switch (cargoContainerContentType)
			{
			case CargoContainerContentType.LiquidFuel:
				((CargoLiquidFuel)cargoContainerContent).SubclassFromXML(ref xmlNode_0, ref concurrentDictionary_0);
				break;
			case CargoContainerContentType.Ammunition:
				((CargoAmmunition)cargoContainerContent).SubclassFromXML(ref xmlNode_0, ref concurrentDictionary_0);
				break;
			}
			return cargoContainerContent;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100902", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}
}
