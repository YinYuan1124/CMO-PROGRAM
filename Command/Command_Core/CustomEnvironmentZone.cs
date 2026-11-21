using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CustomEnvironmentZone : Zone
{
	public bool IsLocked;

	public Weather.WeatherProfile Weather;

	protected int? _CustomTerrainHeight;

	[CompilerGenerated]
	private LandCover.LandCoverType definitionIssuer;

	[CompilerGenerated]
	private float m_ObserverIssuer;

	[CompilerGenerated]
	private float m_IssuerIssuer;

	public LandCover.LandCoverType TerrainType
	{
		[CompilerGenerated]
		get
		{
			return definitionIssuer;
		}
		[CompilerGenerated]
		set
		{
			definitionIssuer = value;
		}
	}

	public SonarModel.ThermoclineLayer ThermalLayer => new SonarModel.ThermoclineLayer
	{
		Ceiling = ThermalLayerCeiling,
		Floor = ThermalLayerFloor,
		Strength = LayerStrength
	};

	public int ThermalLayerFloor { get; set; }

	public int ThermalLayerCeiling { get; set; }

	public float LayerStrength
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverIssuer;
		}
		[CompilerGenerated]
		set
		{
			m_ObserverIssuer = value;
		}
	}

	public float Single_0
	{
		[CompilerGenerated]
		get
		{
			return m_IssuerIssuer;
		}
		[CompilerGenerated]
		set
		{
			m_IssuerIssuer = value;
		}
	}

	public override ZoneType Type => ZoneType.CustomEnvironmentZone;

	public bool HasCustomTerrain => TerrainType != LandCover.LandCoverType.Use_Underlying_Values;

	public bool HasCustomTerrainHeight => _CustomTerrainHeight.HasValue;

	public int TerrainHeight
	{
		get
		{
			if (_CustomTerrainHeight.HasValue)
			{
				return _CustomTerrainHeight.Value;
			}
			return LandCover.CallClass(TerrainType);
		}
		set
		{
			_CustomTerrainHeight = value;
		}
	}

	public void RemoveCustomTerrainHeight()
	{
		_CustomTerrainHeight = null;
	}

	public CustomEnvironmentZone(string string_0, List<ReferencePoint> list_0, Scenario scenario_0, Side side_0, Weather.WeatherProfile weatherProfile_0, List<GlobalVariables.ActiveUnitType> list_1 = null)
	{
		TerrainType = LandCover.LandCoverType.Use_Underlying_Values;
		_CustomTerrainHeight = null;
		scenario_0.CreateNatureSideIfNeeded();
		Description = string_0;
		Area = list_0;
		Weather = weatherProfile_0;
		if (Information.IsNothing(list_1))
		{
			AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
			{
				GlobalVariables.ActiveUnitType.Aircraft,
				GlobalVariables.ActiveUnitType.Ship,
				GlobalVariables.ActiveUnitType.Submarine,
				GlobalVariables.ActiveUnitType.Facility
			};
		}
		else
		{
			AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
			foreach (GlobalVariables.ActiveUnitType item in list_1)
			{
				AffectedUnitTypes.Add(item);
			}
		}
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			activeUnits_.Navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
		Side natureSide = scenario_0.GetNatureSide();
		if (natureSide != side_0)
		{
			foreach (ReferencePoint item2 in Area)
			{
				if (!natureSide.RefPoints.Contains(item2))
				{
					natureSide.RefPoints.Add(item2);
				}
			}
			foreach (ReferencePoint refPoint in natureSide.RefPoints)
			{
				if (side_0.RefPoints.Contains(refPoint))
				{
					side_0.RefPoints.Remove(refPoint);
				}
			}
		}
		string string_ = null;
		if (!ActiveUnit_Navigator.ValidateArea(ref list_0, ref string_, scenario_0.GetNatureSide(), scenario_0, "Custom Environmnet Zone '" + Description + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
	}

	public new static void TransformTo(Zone zone_0, Side side_0, Scenario scenario_0)
	{
		scenario_0.CreateNatureSideIfNeeded();
		if (zone_0 != null)
		{
			scenario_0.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(zone_0.Description, zone_0.Area, scenario_0, side_0, scenario_0.GlobalWeather));
			side_0.StandardZones.Remove(zone_0);
		}
	}

	public new static void TransformTo(ExclusionZone exclusionZone_0, Side side_0, Scenario scenario_0)
	{
		scenario_0.CreateNatureSideIfNeeded();
		if (exclusionZone_0 != null)
		{
			scenario_0.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(exclusionZone_0.Description, exclusionZone_0.Area, scenario_0, side_0, scenario_0.GlobalWeather));
			side_0.ExclusionZones.Remove(exclusionZone_0);
		}
	}

	public new static void TransformTo(NoNavZone noNavZone_0, Side side_0, Scenario scenario_0)
	{
		scenario_0.CreateNatureSideIfNeeded();
		if (noNavZone_0 != null)
		{
			scenario_0.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(noNavZone_0.Description, noNavZone_0.Area, scenario_0, side_0, scenario_0.GlobalWeather));
			side_0.NoNavZones.Remove(noNavZone_0);
		}
	}

	internal CustomEnvironmentZone RunImporter()
	{
		CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone();
		customEnvironmentZone.Weather = new Weather.WeatherProfile();
		customEnvironmentZone.Description = Description;
		customEnvironmentZone.Weather.AverageTemp = Weather.AverageTemp;
		customEnvironmentZone.Weather.RainfallRate = Weather.RainfallRate;
		customEnvironmentZone.Weather.FractionUnderRain = Weather.FractionUnderRain;
		customEnvironmentZone.Weather.SeaState = Weather.SeaState;
		customEnvironmentZone.TerrainType = TerrainType;
		customEnvironmentZone.ThermalLayerCeiling = ThermalLayerCeiling;
		customEnvironmentZone.ThermalLayerFloor = ThermalLayerFloor;
		customEnvironmentZone.LayerStrength = LayerStrength;
		customEnvironmentZone.Single_0 = Single_0;
		customEnvironmentZone.Area = Area;
		return customEnvironmentZone;
	}

	private CustomEnvironmentZone()
	{
		TerrainType = LandCover.LandCoverType.Use_Underlying_Values;
		_CustomTerrainHeight = null;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("CustomEnvironmentZone");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("Weather");
			Weather.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Area");
			int num = Area.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ReferencePoint referencePoint;
				try
				{
					referencePoint = Area[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				xmlWriter_0.WriteRaw(referencePoint.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			if (!Information.IsNothing(AffectedUnitTypes))
			{
				xmlWriter_0.WriteElementString("AffectedUnitTypes", string.Join("_", AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
				{
					int num2 = (int)theType;
					return num2.ToString();
				})));
			}
			xmlWriter_0.WriteElementString("IsLocked", IsLocked.ToString());
			xmlWriter_0.WriteElementString("IsActive", IsActive.ToString());
			xmlWriter_0.WriteElementString("TerrainType", Convert.ToInt32((byte)TerrainType).ToString());
			xmlWriter_0.WriteElementString("ThermalLayerCeiling", ThermalLayerCeiling.ToString());
			xmlWriter_0.WriteElementString("ThermalLayerFloor", ThermalLayerFloor.ToString());
			xmlWriter_0.WriteElementString("LayerStrength", LayerStrength.ToString());
			xmlWriter_0.WriteElementString("CZInterval", Single_0.ToString());
			xmlWriter_0.WriteElementString("Color_A", AreaColor.A.ToString());
			xmlWriter_0.WriteElementString("Color_R", AreaColor.R.ToString());
			xmlWriter_0.WriteElementString("Color_G", AreaColor.G.ToString());
			xmlWriter_0.WriteElementString("Color_B", AreaColor.B.ToString());
			xmlWriter_0.WriteElementString("Layer", _PredicateReader.ToString());
			if (_CustomTerrainHeight.HasValue)
			{
				xmlWriter_0.WriteElementString("TerrainHeight", _CustomTerrainHeight.Value.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100993", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static CustomEnvironmentZone FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone();
			IEnumerator enumerator = null;
			byte? b = null;
			byte? b2 = null;
			byte? b3 = null;
			byte? b4 = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "CZInterval":
						try
						{
							customEnvironmentZone.Single_0 = Conversions.ToInteger(xmlNode_.InnerText);
						}
						catch (Exception projectError5)
						{
							ProjectData.SetProjectError(projectError5);
							customEnvironmentZone.Single_0 = 0f;
							ProjectData.ClearProjectError();
						}
						break;
					case "TerrainType":
						customEnvironmentZone.TerrainType = (LandCover.LandCoverType)Enum.Parse(typeof(LandCover.LandCoverType), xmlNode_.InnerText);
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								customEnvironmentZone.Area.Add(ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0));
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "Color_G":
						b3 = XmlConvert.ToByte(xmlNode_.InnerText);
						break;
					case "Color_B":
						b2 = XmlConvert.ToByte(xmlNode_.InnerText);
						break;
					case "Color_A":
						b = XmlConvert.ToByte(xmlNode_.InnerText);
						break;
					case "AffectedUnitTypes":
					{
						customEnvironmentZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
						string[] array = xmlNode_.InnerText.Split('_');
						string[] array2 = array;
						foreach (string text in array2)
						{
							if (Versioned.IsNumeric(text))
							{
								int num = Conversions.ToInteger(text);
								customEnvironmentZone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
							}
						}
						break;
					}
					case "Color_R":
						b4 = XmlConvert.ToByte(xmlNode_.InnerText);
						break;
					case "ThermalLayerFloor":
						try
						{
							customEnvironmentZone.ThermalLayerFloor = Conversions.ToInteger(xmlNode_.InnerText);
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							customEnvironmentZone.ThermalLayerFloor = 0;
							ProjectData.ClearProjectError();
						}
						break;
					case "TerrainHeight":
						try
						{
							customEnvironmentZone._CustomTerrainHeight = Conversions.ToInteger(xmlNode_.InnerText);
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							customEnvironmentZone._CustomTerrainHeight = null;
							ProjectData.ClearProjectError();
						}
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							customEnvironmentZone.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(customEnvironmentZone.ObjectID, customEnvironmentZone);
							break;
						}
						return (CustomEnvironmentZone)concurrentDictionary_0[xmlNode_.InnerText];
					case "IsLocked":
						customEnvironmentZone.IsLocked = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Weather":
						customEnvironmentZone.Weather = Command_Core.Weather.WeatherProfile.FromXML(ref xmlNode_);
						break;
					case "Description":
						customEnvironmentZone.Description = xmlNode_.InnerText;
						break;
					case "ThermalLayerCeiling":
						try
						{
							customEnvironmentZone.ThermalLayerCeiling = Conversions.ToInteger(xmlNode_.InnerText);
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							customEnvironmentZone.ThermalLayerCeiling = 0;
							ProjectData.ClearProjectError();
						}
						break;
					case "LayerStrength":
						try
						{
							customEnvironmentZone.LayerStrength = Conversions.ToInteger(xmlNode_.InnerText);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							customEnvironmentZone.LayerStrength = 0f;
							ProjectData.ClearProjectError();
						}
						break;
					case "IsActive":
						customEnvironmentZone.IsActive = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
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
			if (Information.IsNothing(b4))
			{
				customEnvironmentZone.AreaColor = Color.DarkViolet;
			}
			else
			{
				customEnvironmentZone.AreaColor = Color.FromArgb(b.Value, b4.Value, b3.Value, b2.Value);
			}
			if (Information.IsNothing(customEnvironmentZone.AffectedUnitTypes))
			{
				customEnvironmentZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			return customEnvironmentZone;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100994", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			CustomEnvironmentZone result = new CustomEnvironmentZone();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override string ToString()
	{
		return Description + " " + Weather.RainfallRate_Description + " " + Weather.CloudInfo_Description + " Sea: " + Weather.SeaState;
	}
}
