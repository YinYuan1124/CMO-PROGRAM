using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using OpenDis.Pages;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Weather
{
	public enum TTimeOfDayType : byte
	{
		tod_Day,
		tod_Twilight,
		tod_Night
	}

	public enum THighCloudType : byte
	{
		None = 0,
		Ci_Cirrus = 8,
		Cs_Cirrostratus = 9,
		Cc_Cirrocumulus = 10
	}

	public enum TMiddleCloudType : byte
	{
		None = 0,
		Ac_Altocumulus = 5,
		As_Altostratus = 6,
		Ns_Nimbostratus = 7
	}

	public enum TLowCloudType : byte
	{
		None,
		Cb_Cumulonimbus,
		Sc_Stratocumulus,
		St_Stratus,
		Cu_Cumulus
	}

	public struct TCloudInfo
	{
		public TLowCloudType LowCloudType;

		public int LowCloudBase_m;

		public int LowCloudTop_m;

		public int LowCloudCoverThickness;

		public TMiddleCloudType MiddleCloudType;

		public int MiddleCloudBase_m;

		public int MiddleCloudTop_m;

		public int MiddleCloudCoverThickness;

		public THighCloudType HighCloudType;

		public int HighCloudBase_m;

		public int HighCloudTop_m;

		public int HighCloudCoverThickness;
	}

	public sealed class WeatherProfile
	{
		public TDictionary<double, double> GaseousAttenuationByFrequency;

		protected double _AverageTemp;

		protected double _Pressure;

		protected double _RelativeHumidity;

		public int SeaState;

		public float RainfallRate;

		private float _DecoratorSetter;

		public TCloudInfo CloudInfo;

		public int ContrailAltitude;

		public float SurfaceVisibilityKM;

		public double RunwayVisualRangeNM;

		public double GroundReflectionCoeff;

		protected double _DELTA_N;

		public double SurfaceRefractivity;

		public double SurfaceDuctHeight;

		public double EvaporationDuctHeight;

		public double RadiusEffective;

		public double k50;

		public string RainfallRate_Description
		{
			get
			{
				float rainfallRate = RainfallRate;
				if (rainfallRate == 0f)
				{
					return "无雨";
				}
				if (rainfallRate < 5f)
				{
					return "小雨";
				}
				if (rainfallRate < 10f)
				{
					return "中雨";
				}
				if (rainfallRate < 20f)
				{
					return "大雨";
				}
				if (rainfallRate < 30f)
				{
					return "暴雨";
				}
				if (rainfallRate < 40f)
				{
					return "大暴雨";
				}
				return "特大暴雨";
			}
		}

		public float FractionUnderRain
		{
			get
			{
				return _DecoratorSetter;
			}
			set
			{
				_DecoratorSetter = value;
				float num = (float)((double)_DecoratorSetter - 0.001);
				if (_DecoratorSetter == 0f)
				{
					num = 0f;
				}
				if ((double)num <= 0.9)
				{
					if ((double)num <= 0.8)
					{
						if ((double)num <= 0.7)
						{
							if ((double)num <= 0.6)
							{
								if ((double)num <= 0.5)
								{
									if ((double)num <= 0.4)
									{
										if ((double)num <= 0.3)
										{
											if ((double)num <= 0.2)
											{
												if ((double)num <= 0.1)
												{
													if ((double)num <= 0.0)
													{
														CloudInfo.HighCloudTop_m = 0;
														CloudInfo.HighCloudBase_m = 0;
														CloudInfo.HighCloudCoverThickness = 0;
														CloudInfo.MiddleCloudTop_m = 0;
														CloudInfo.MiddleCloudBase_m = 0;
														CloudInfo.MiddleCloudCoverThickness = 0;
														CloudInfo.LowCloudTop_m = 0;
														CloudInfo.LowCloudBase_m = 0;
														CloudInfo.LowCloudCoverThickness = 0;
													}
													else
													{
														CloudInfo.HighCloudTop_m = 0;
														CloudInfo.HighCloudBase_m = 0;
														CloudInfo.HighCloudCoverThickness = 0;
														CloudInfo.MiddleCloudTop_m = 0;
														CloudInfo.MiddleCloudBase_m = 0;
														CloudInfo.MiddleCloudCoverThickness = 0;
														CloudInfo.LowCloudTop_m = 2134;
														CloudInfo.LowCloudBase_m = 1524;
														CloudInfo.LowCloudCoverThickness = 2;
													}
												}
												else
												{
													CloudInfo.HighCloudTop_m = 0;
													CloudInfo.HighCloudBase_m = 0;
													CloudInfo.HighCloudCoverThickness = 0;
													CloudInfo.MiddleCloudTop_m = 4877;
													CloudInfo.MiddleCloudBase_m = 3048;
													CloudInfo.MiddleCloudCoverThickness = 2;
													CloudInfo.LowCloudTop_m = 0;
													CloudInfo.LowCloudBase_m = 0;
													CloudInfo.LowCloudCoverThickness = 0;
												}
											}
											else
											{
												CloudInfo.HighCloudTop_m = 0;
												CloudInfo.HighCloudBase_m = 0;
												CloudInfo.HighCloudCoverThickness = 0;
												CloudInfo.MiddleCloudTop_m = 7010;
												CloudInfo.MiddleCloudBase_m = 6096;
												CloudInfo.MiddleCloudCoverThickness = 2;
												CloudInfo.LowCloudTop_m = 0;
												CloudInfo.LowCloudBase_m = 0;
												CloudInfo.LowCloudCoverThickness = 0;
											}
										}
										else
										{
											CloudInfo.HighCloudTop_m = 0;
											CloudInfo.HighCloudBase_m = 0;
											CloudInfo.HighCloudCoverThickness = 0;
											CloudInfo.MiddleCloudTop_m = 0;
											CloudInfo.MiddleCloudBase_m = 0;
											CloudInfo.MiddleCloudCoverThickness = 0;
											CloudInfo.LowCloudTop_m = 2134;
											CloudInfo.LowCloudBase_m = 610;
											CloudInfo.LowCloudCoverThickness = 4;
										}
									}
									else
									{
										CloudInfo.HighCloudTop_m = 0;
										CloudInfo.HighCloudBase_m = 0;
										CloudInfo.HighCloudCoverThickness = 0;
										CloudInfo.MiddleCloudTop_m = 4877;
										CloudInfo.MiddleCloudBase_m = 2134;
										CloudInfo.MiddleCloudCoverThickness = 4;
										CloudInfo.LowCloudTop_m = 0;
										CloudInfo.LowCloudBase_m = 0;
										CloudInfo.LowCloudCoverThickness = 0;
									}
								}
								else
								{
									CloudInfo.HighCloudTop_m = 0;
									CloudInfo.HighCloudBase_m = 0;
									CloudInfo.HighCloudCoverThickness = 0;
									CloudInfo.MiddleCloudTop_m = 8534;
									CloudInfo.MiddleCloudBase_m = 7620;
									CloudInfo.MiddleCloudCoverThickness = 4;
									CloudInfo.LowCloudTop_m = 0;
									CloudInfo.LowCloudBase_m = 0;
									CloudInfo.LowCloudCoverThickness = 0;
								}
							}
							else
							{
								CloudInfo.HighCloudTop_m = 9144;
								CloudInfo.HighCloudBase_m = 8230;
								CloudInfo.HighCloudCoverThickness = 2;
								CloudInfo.MiddleCloudTop_m = 4877;
								CloudInfo.MiddleCloudBase_m = 2134;
								CloudInfo.MiddleCloudCoverThickness = 4;
								CloudInfo.LowCloudTop_m = 0;
								CloudInfo.LowCloudBase_m = 0;
								CloudInfo.LowCloudCoverThickness = 0;
							}
						}
						else
						{
							CloudInfo.HighCloudTop_m = 10973;
							CloudInfo.HighCloudBase_m = 9144;
							CloudInfo.HighCloudCoverThickness = 4;
							CloudInfo.MiddleCloudTop_m = 4877;
							CloudInfo.MiddleCloudBase_m = 2134;
							CloudInfo.MiddleCloudCoverThickness = 8;
							CloudInfo.LowCloudTop_m = 0;
							CloudInfo.LowCloudBase_m = 0;
							CloudInfo.LowCloudCoverThickness = 0;
						}
					}
					else
					{
						CloudInfo.HighCloudTop_m = 10973;
						CloudInfo.HighCloudBase_m = 2134;
						CloudInfo.HighCloudCoverThickness = 8;
						CloudInfo.MiddleCloudTop_m = 0;
						CloudInfo.MiddleCloudBase_m = 0;
						CloudInfo.MiddleCloudCoverThickness = 0;
						CloudInfo.LowCloudTop_m = 610;
						CloudInfo.LowCloudBase_m = 0;
						CloudInfo.LowCloudCoverThickness = 2;
					}
				}
				else
				{
					CloudInfo.HighCloudTop_m = 10973;
					CloudInfo.HighCloudBase_m = 2134;
					CloudInfo.HighCloudCoverThickness = 8;
					CloudInfo.MiddleCloudTop_m = 0;
					CloudInfo.MiddleCloudBase_m = 0;
					CloudInfo.MiddleCloudCoverThickness = 0;
					CloudInfo.LowCloudTop_m = 610;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 8;
				}
			}
		}

		public string CloudInfo_Description
		{
			get
			{
				float fractionUnderRain = FractionUnderRain;
				if (fractionUnderRain <= 0.9f)
				{
					if (fractionUnderRain <= 0.8f)
					{
						if (fractionUnderRain <= 0.7f)
						{
							if (fractionUnderRain <= 0.6f)
							{
								if (fractionUnderRain <= 0.5f)
								{
									if (fractionUnderRain <= 0.4f)
									{
										if (fractionUnderRain <= 0.3f)
										{
											if (fractionUnderRain <= 0.2f)
											{
												if (fractionUnderRain <= 0.1f)
												{
													if (fractionUnderRain <= 0f)
													{
														return "晴朗无云";
													}
													if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
													{
														return "Light low clouds 5 - 7k ft";
													}
													return "轻度低层云 " + Conversions.ToString(2) + " - " + Conversions.ToString(2) + " 千米";
												}
												if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
												{
													return "Light middle clouds 10 - 16k ft";
												}
												return "轻度中层云 " + Conversions.ToString(3) + " - " + Conversions.ToString(5) + " 千米";
											}
											if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												return "Light high clouds 20 - 23k ft";
											}
											return "轻度高层云 " + Conversions.ToString(6) + " - " + Conversions.ToString(7) + " 千米";
										}
										if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											return "Moderate low clouds 2 - 7k ft";
										}
										return "中度低层云 " + Conversions.ToString(1) + " - " + Conversions.ToString(2) + " 千米";
									}
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										return "Moderate middle clouds 7 - 16k ft";
									}
									return "中度中层云 " + Conversions.ToString(2) + " - " + Conversions.ToString(5) + " 千米";
								}
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									return "Moderate high clouds 25 - 28k ft";
								}
								return "中度高层云 " + Conversions.ToString(8) + " - " + Conversions.ToString(9) + " 千米";
							}
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								return "Moderate middle clouds 7 - 16k ft, light high clouds 27 - 30k ft";
							}
							return "中度中层云 " + Conversions.ToString(2) + " - " + Conversions.ToString(5) + " 千米, 轻度高层云 " + Conversions.ToString(8) + " - " + Conversions.ToString(9) + " 千米";
						}
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							return "Solid middle clouds 7 - 16k ft, moderate high clouds 30 - 36k ft";
						}
						return "重度中层云 " + Conversions.ToString(2) + " - " + Conversions.ToString(5) + " 千米, 中度高层云 " + Conversions.ToString(9) + " - " + Conversions.ToString(11) + " 千米";
					}
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "薄雾 0 - 2k ft, solid cloud cover 7 - 36k ft";
					}
					return "薄雾 0 - " + Conversions.ToString(1) + "千米, 浓密云层 " + Conversions.ToString(2) + " - " + Conversions.ToString(11) + " 千米";
				}
				if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
				{
					return "大雾 0 - 2k ft, 浓密云层 7 - 36k ft";
				}
				return "大雾 0 - " + Conversions.ToString(1) + "千米, 浓密云层 " + Conversions.ToString(2) + " - " + Conversions.ToString(11) + " 千米";
			}
		}

		public double AverageTemp
		{
			get
			{
				return _AverageTemp;
			}
			set
			{
				if (_AverageTemp != value)
				{
					_AverageTemp = value;
					SurfaceRefractivity = TestDescriptor(_AverageTemp, _Pressure, _RelativeHumidity);
					GaseousAttenuationByFrequency.Clear();
				}
			}
		}

		public double Pressure
		{
			get
			{
				return _Pressure;
			}
			set
			{
				if (_Pressure != value)
				{
					_Pressure = value;
					SurfaceRefractivity = TestDescriptor(_AverageTemp, _Pressure, _RelativeHumidity);
					GaseousAttenuationByFrequency.Clear();
				}
			}
		}

		public double RelativeHumidity
		{
			get
			{
				return _RelativeHumidity;
			}
			set
			{
				if (_RelativeHumidity != value)
				{
					_RelativeHumidity = value;
					SurfaceRefractivity = TestDescriptor(_AverageTemp, _Pressure, _RelativeHumidity);
					GaseousAttenuationByFrequency.Clear();
				}
			}
		}

		public float SurfaceVisibilityNM
		{
			get
			{
				return (float)((double)SurfaceVisibilityKM * 1000.0 / 1852.0);
			}
			set
			{
				SurfaceVisibilityKM = (float)((double)value * 1852.0 / 1000.0);
			}
		}

		public double DELTA_N
		{
			get
			{
				return _DELTA_N;
			}
			set
			{
				if (_DELTA_N != value)
				{
					_DELTA_N = value;
					RadiusEffective = ReflectDescriptor(value);
					k50 = 157.0 / (157.0 - DELTA_N);
				}
			}
		}

		public WeatherProfile()
		{
			GaseousAttenuationByFrequency = new TDictionary<double, double>();
			AverageTemp = 15.0;
			Pressure = 1013.25;
			RelativeHumidity = 86.17;
			GroundReflectionCoeff = 0.0;
			DELTA_N = 39.0;
			SurfaceDuctHeight = 0.0;
			EvaporationDuctHeight = 0.0;
			RainfallRate = 0f;
			FractionUnderRain = 0f;
			SeaState = 0;
		}

		public void ToXML(ref XmlWriter xmlWriter_0)
		{
			xmlWriter_0.WriteStartElement("WeatherProfile");
			xmlWriter_0.WriteElementString("Temp", XmlConvert.ToString(AverageTemp));
			xmlWriter_0.WriteElementString("Pressure", XmlConvert.ToString(Pressure));
			xmlWriter_0.WriteElementString("RL", XmlConvert.ToString(RelativeHumidity));
			xmlWriter_0.WriteElementString("GRC", XmlConvert.ToString(GroundReflectionCoeff));
			xmlWriter_0.WriteElementString("DN", XmlConvert.ToString(DELTA_N));
			xmlWriter_0.WriteElementString("SDH", XmlConvert.ToString(SurfaceDuctHeight));
			xmlWriter_0.WriteElementString("EDH", XmlConvert.ToString(EvaporationDuctHeight));
			xmlWriter_0.WriteElementString("RFR", XmlConvert.ToString(RainfallRate));
			xmlWriter_0.WriteElementString("FUR", XmlConvert.ToString(FractionUnderRain));
			xmlWriter_0.WriteElementString("SS", XmlConvert.ToString(SeaState));
			xmlWriter_0.WriteEndElement();
		}

		public static WeatherProfile FromXML(ref XmlNode xmlNode_0)
		{
			WeatherProfile weatherProfile = new WeatherProfile();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes[0].ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Temp":
						weatherProfile.AverageTemp = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "SDH":
						weatherProfile.SurfaceDuctHeight = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "RL":
						weatherProfile.RelativeHumidity = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "SS":
						weatherProfile.SeaState = XmlConvert.ToInt16(xmlNode.InnerText);
						break;
					case "DN":
						weatherProfile.DELTA_N = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "EDH":
						weatherProfile.EvaporationDuctHeight = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "RFR":
						weatherProfile.RainfallRate = XmlConvert.ToInt32(xmlNode.InnerText);
						break;
					case "FUR":
						weatherProfile.FractionUnderRain = (float)XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "Pressure":
						weatherProfile.Pressure = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "GRC":
						weatherProfile.GroundReflectionCoeff = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					}
				}
				return weatherProfile;
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		[SpecialName]
		public short GetActualTemp(TTimeOfDayType ttimeOfDayType_0)
		{
			switch (ttimeOfDayType_0)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			case TTimeOfDayType.tod_Day:
				return (short)Math.Round(AverageTemp + 10.0);
			case TTimeOfDayType.tod_Twilight:
				return (short)Math.Round(AverageTemp);
			case TTimeOfDayType.tod_Night:
				return (short)Math.Round(AverageTemp - 10.0);
			}
		}

		[SpecialName]
		public short GetActualTemp_CurrentScenarioTime(Scenario scenario_0, double double_0, double double_1, float float_0)
		{
			switch (SunModule.CollectSpecification(scenario_0, scenario_0.Time.Year, scenario_0.Time.Month, scenario_0.Time.Day, scenario_0.Time.Hour, scenario_0.Time.Minute, scenario_0.Time.Second, bool_0: true, double_0, double_1, float_0))
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			case TTimeOfDayType.tod_Day:
				return (short)Math.Round(AverageTemp + 10.0);
			case TTimeOfDayType.tod_Twilight:
				return (short)Math.Round(AverageTemp);
			case TTimeOfDayType.tod_Night:
				return (short)Math.Round(AverageTemp - 10.0);
			}
		}

		public void ImportWeatherRecord(ref TWeatherRecord tweatherRecord_0)
		{
			AverageTemp = (double)(int)tweatherRecord_0.Temp - 100.0;
			Pressure = tweatherRecord_0.Pressure;
			if ((tweatherRecord_0.RelativeHumidity > 100) | (tweatherRecord_0.RelativeHumidity < 0))
			{
				throw new Exception("Relative humidity out of bounds");
			}
			RelativeHumidity = (int)tweatherRecord_0.RelativeHumidity;
			if ((tweatherRecord_0.SeaState > 9) | (tweatherRecord_0.SeaState < 0))
			{
				throw new Exception("Sea state out of bounds");
			}
			SeaState = tweatherRecord_0.SeaState;
			if (tweatherRecord_0.DELTA_N < 157)
			{
				DELTA_N = tweatherRecord_0.DELTA_N;
				RainfallRate = (float)(double)tweatherRecord_0.RainfallRate;
				if ((tweatherRecord_0.PercentUnderRain > 100) | (tweatherRecord_0.PercentUnderRain < 0))
				{
					throw new Exception("Rain patchiness out of bounds");
				}
				FractionUnderRain = (float)((double)(int)tweatherRecord_0.PercentUnderRain / 100.0);
				if (((uint)tweatherRecord_0.LowCloudType > 4u) | ((uint)tweatherRecord_0.LowCloudType < 0u))
				{
					throw new Exception("Invalid low cloud type");
				}
				if (((uint)tweatherRecord_0.MiddleCloudType > 7u) | ((uint)tweatherRecord_0.MiddleCloudType < 0u))
				{
					throw new Exception("Invalid middle cloud type");
				}
				if (((uint)tweatherRecord_0.HighCloudType > 10u) | ((uint)tweatherRecord_0.HighCloudType < 0u))
				{
					throw new Exception("Invalid high cloud type");
				}
				CloudInfo.LowCloudType = (TLowCloudType)tweatherRecord_0.LowCloudType;
				CloudInfo.MiddleCloudType = (TMiddleCloudType)tweatherRecord_0.MiddleCloudType;
				CloudInfo.HighCloudType = (THighCloudType)tweatherRecord_0.HighCloudType;
				if ((tweatherRecord_0.LowCloudBase < 0) | (tweatherRecord_0.LowCloudTop < tweatherRecord_0.LowCloudBase))
				{
					throw new Exception("Invalid low cloud limits");
				}
				if ((tweatherRecord_0.MiddleCloudBase < 0) | (tweatherRecord_0.MiddleCloudTop < tweatherRecord_0.MiddleCloudBase))
				{
					throw new Exception("Invalid middle cloud limits");
				}
				if ((tweatherRecord_0.HighCloudBase < 0) | (tweatherRecord_0.HighCloudTop < tweatherRecord_0.HighCloudBase))
				{
					throw new Exception("Invalid high cloud limits");
				}
				if (tweatherRecord_0.LowCloudBase > 0)
				{
					if ((tweatherRecord_0.MiddleCloudBase > 0) & (tweatherRecord_0.MiddleCloudBase < tweatherRecord_0.LowCloudTop))
					{
						throw new Exception("Middle cloud intersects low cloud");
					}
					if ((tweatherRecord_0.HighCloudBase > 0) & (tweatherRecord_0.HighCloudBase < tweatherRecord_0.LowCloudTop))
					{
						throw new Exception("High cloud intersects low cloud");
					}
				}
				if (tweatherRecord_0.MiddleCloudBase > 0 && ((tweatherRecord_0.HighCloudBase > 0) & (tweatherRecord_0.HighCloudBase < tweatherRecord_0.MiddleCloudTop)))
				{
					throw new Exception("High cloud intersects low cloud");
				}
				if ((tweatherRecord_0.LowCloudCover < 0) | (tweatherRecord_0.LowCloudCover > 8) | (tweatherRecord_0.MiddleCloudCover < 0) | (tweatherRecord_0.MiddleCloudCover > 8) | (tweatherRecord_0.HighCloudCover < 0) | (tweatherRecord_0.HighCloudCover > 8))
				{
					throw new Exception("Cloud cover for one of the layers outside the 0..8 range");
				}
				CloudInfo.LowCloudBase_m = tweatherRecord_0.LowCloudBase;
				CloudInfo.MiddleCloudBase_m = tweatherRecord_0.MiddleCloudBase;
				CloudInfo.HighCloudBase_m = tweatherRecord_0.HighCloudBase;
				CloudInfo.LowCloudTop_m = tweatherRecord_0.LowCloudTop;
				CloudInfo.MiddleCloudTop_m = tweatherRecord_0.MiddleCloudTop;
				CloudInfo.HighCloudTop_m = tweatherRecord_0.HighCloudTop;
				CloudInfo.LowCloudCoverThickness = tweatherRecord_0.LowCloudCover;
				CloudInfo.MiddleCloudCoverThickness = tweatherRecord_0.MiddleCloudCover;
				CloudInfo.HighCloudCoverThickness = tweatherRecord_0.HighCloudCover;
				if (tweatherRecord_0.ContrailAltitude < 0)
				{
					throw new Exception("Contrail altitude cannot be negative");
				}
				ContrailAltitude = tweatherRecord_0.ContrailAltitude;
				if (tweatherRecord_0.SurfaceVisibility < 0)
				{
					throw new Exception("Surface visibility cannot be negative");
				}
				SurfaceVisibilityKM = (float)((double)tweatherRecord_0.SurfaceVisibility / 100.0);
				if (tweatherRecord_0.SurfaceDuctHeight < 0)
				{
					throw new Exception("Surface visibility cannot be negative");
				}
				SurfaceDuctHeight = tweatherRecord_0.SurfaceDuctHeight;
				if (tweatherRecord_0.EvaporationDuctHeight < 0)
				{
					throw new Exception("Surface visibility cannot be negative");
				}
				EvaporationDuctHeight = (int)tweatherRecord_0.EvaporationDuctHeight;
				return;
			}
			throw new Exception("Refractivity gradient out of bounds");
		}

		public void ExportWeatherRecord(ref TWeatherRecord tweatherRecord_0)
		{
			tweatherRecord_0.Temp = (byte)Math.Max(0, Math.Min(255, (int)Math.Round(AverageTemp + 100.0)));
			tweatherRecord_0.Pressure = (short)(int)Math.Round(Pressure);
			tweatherRecord_0.RelativeHumidity = (byte)(int)Math.Round(RelativeHumidity);
			tweatherRecord_0.SeaState = (byte)SeaState;
			tweatherRecord_0.DELTA_N = (short)Math.Round(DELTA_N);
			tweatherRecord_0.RainfallRate = (short)Math.Round(RainfallRate);
			tweatherRecord_0.PercentUnderRain = (byte)(int)Math.Round((double)FractionUnderRain * 100.0);
			tweatherRecord_0.LowCloudBase = (short)CloudInfo.LowCloudBase_m;
			tweatherRecord_0.MiddleCloudBase = (short)CloudInfo.MiddleCloudBase_m;
			tweatherRecord_0.HighCloudBase = (short)CloudInfo.HighCloudBase_m;
			tweatherRecord_0.LowCloudTop = (short)CloudInfo.LowCloudTop_m;
			tweatherRecord_0.MiddleCloudTop = (short)CloudInfo.MiddleCloudTop_m;
			tweatherRecord_0.HighCloudTop = (short)CloudInfo.HighCloudTop_m;
			tweatherRecord_0.LowCloudCover = (byte)CloudInfo.LowCloudCoverThickness;
			tweatherRecord_0.MiddleCloudCover = (byte)CloudInfo.MiddleCloudCoverThickness;
			tweatherRecord_0.HighCloudCover = (byte)CloudInfo.HighCloudCoverThickness;
			tweatherRecord_0.LowCloudType = (byte)CloudInfo.LowCloudType;
			tweatherRecord_0.MiddleCloudType = (byte)CloudInfo.MiddleCloudType;
			tweatherRecord_0.HighCloudType = (byte)CloudInfo.HighCloudType;
			tweatherRecord_0.SurfaceVisibility = (short)(int)Math.Round((double)SurfaceVisibilityKM * 100.0);
			tweatherRecord_0.ContrailAltitude = (short)ContrailAltitude;
			tweatherRecord_0.SurfaceDuctHeight = (short)(int)Math.Round(SurfaceDuctHeight);
			tweatherRecord_0.EvaporationDuctHeight = (byte)(int)Math.Round(EvaporationDuctHeight);
		}
	}

	public struct TSDSItem
	{
		public double AvgEvapDuct;

		public int MSQ;

		public int[] CDF;
	}

	public struct TESARainItem
	{
		public double MC;

		public double MS;

		public double Pr6;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 35)]
	public struct TWeatherRecord
	{
		[FieldOffset(0)]
		public byte Temp;

		[FieldOffset(1)]
		public short Pressure;

		[FieldOffset(3)]
		public byte RelativeHumidity;

		[FieldOffset(4)]
		public byte SeaState;

		[FieldOffset(5)]
		public short DELTA_N;

		[FieldOffset(7)]
		public short RainfallRate;

		[FieldOffset(9)]
		public byte PercentUnderRain;

		[FieldOffset(10)]
		public byte LowCloudType;

		[FieldOffset(11)]
		public short LowCloudBase;

		[FieldOffset(13)]
		public short LowCloudTop;

		[FieldOffset(15)]
		public byte LowCloudCover;

		[FieldOffset(16)]
		public byte MiddleCloudType;

		[FieldOffset(17)]
		public short MiddleCloudBase;

		[FieldOffset(19)]
		public short MiddleCloudTop;

		[FieldOffset(21)]
		public byte MiddleCloudCover;

		[FieldOffset(22)]
		public byte HighCloudType;

		[FieldOffset(23)]
		public short HighCloudBase;

		[FieldOffset(25)]
		public short HighCloudTop;

		[FieldOffset(27)]
		public byte HighCloudCover;

		[FieldOffset(28)]
		public short ContrailAltitude;

		[FieldOffset(30)]
		public short SurfaceVisibility;

		[FieldOffset(32)]
		public short SurfaceDuctHeight;

		[FieldOffset(34)]
		public byte EvaporationDuctHeight;
	}

	public enum TWeatherGridType : byte
	{
		wgt_LatLonFixedStep,
		wgt_LatLonAdaptive,
		wgt_RectangularFixedStep,
		wgt_RectangularAdaptive,
		wgt_Polar
	}

	public struct TBILInfo
	{
		public int NRows;

		public int NCols;

		public double A;

		public double B;

		public double C;

		public double D;

		public double E;

		public double F;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 35)]
	public struct TWeatherHeader
	{
		[FieldOffset(0)]
		public int Magic;

		[FieldOffset(4)]
		public byte FormatVersion;

		[FieldOffset(5)]
		public byte Smoothing;

		[FieldOffset(6)]
		public byte CompressionAlgorithm;

		[FieldOffset(7)]
		public byte GridType;

		[FieldOffset(8)]
		public short Delta_T;

		[FieldOffset(10)]
		public float Delta_X;

		[FieldOffset(14)]
		public float Delta_Y;

		[FieldOffset(18)]
		public short T;

		[FieldOffset(20)]
		public short X;

		[FieldOffset(22)]
		public short Y;

		[FieldOffset(24)]
		public float LeftX;

		[FieldOffset(28)]
		public float LowerY;

		[FieldOffset(32)]
		public short xReserved1;

		[FieldOffset(34)]
		public byte xReserved2;
	}

	public enum TAtmosphereType
	{
		atm_Summer_Midlat,
		atm_Winter_Midlat,
		atm_Summer_Subart,
		atm_Winter_Subart,
		atm_Annual_Tropic,
		atm_ITU_R_Ref_Std
	}

	public struct TModRefractivityProfileItem
	{
		public int Altitude;

		public double ModRefractivity;
	}

	public struct TAtmosphere
	{
		public double Pressure;

		public double Temperature;

		public double Rho;
	}

	public const string ModuleCredits = "This module includes NOVAS 3.0f library from US Naval Observatory for astronomical calculations.\r\nBased on JPL ASCII ephemerides DE405 valid for 2000-2019 (will extend back to 1940s in the future)\r\nSources: ITU-R P.837 rainfall rate data\r\nDr. Tim Mitchell from UK Met.Office (Tyndall centre), CRU TS 2.1 (1901-2002 data)\r\nHansen's thermal anomaly data from http://data.giss.nasa.gov/gistemp/";

	public const string ModuleVersion = "Version 0.15";

	public const byte THighCloudType_Max = 10;

	public const byte TMiddleCloudType_Max = 7;

	public const byte TLowCloudType_Max = 4;

	public const int int_0 = 35;

	public const int WeatherMagic = 1464094019;

	public const byte WeatherVersionNumber = 2;

	public const int int_1 = 35;

	[SpecialName]
	public static WeatherProfile GetWeatherAtThisTimeAndPlace(Scenario scenario_0, double double_0, double double_1, int int_2)
	{
		if (scenario_0.WeatherLevel == Scenario.WeatherModellingLevel.Level0)
		{
			WeatherProfile globalWeather = scenario_0.GlobalWeather;
			if (scenario_0.NatureSideExists())
			{
				foreach (CustomEnvironmentZone customEnvironmentZone in scenario_0.GetNatureSide().CustomEnvironmentZones)
				{
					if (GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
					{
						return customEnvironmentZone.Weather;
					}
				}
			}
			return globalWeather;
		}
		throw new NotImplementedException();
	}

	internal static bool PopDescriptor(string string_0, ref TSDSItem[,] tsdsitem_0)
	{
		TextFieldParser textFieldParser = new TextFieldParser(string_0);
		CultureInfo provider = new CultureInfo("en-US");
		textFieldParser.TextFieldType = FieldType.Delimited;
		textFieldParser.SetDelimiters("\t");
		tsdsitem_0 = new TSDSItem[18, 36];
		int num = 0;
		do
		{
			int num2 = 0;
			do
			{
				tsdsitem_0[num, num2].CDF = new int[21];
				num2++;
			}
			while (num2 <= 35);
			num++;
		}
		while (num <= 17);
		while (!textFieldParser.EndOfData)
		{
			try
			{
				string[] array = textFieldParser.ReadFields();
				if (!int.TryParse(array[0], NumberStyles.Integer, provider, out var result) || !int.TryParse(array[1], NumberStyles.Integer, provider, out var result2))
				{
					continue;
				}
				int num3 = (int)Math.Round((double)result / 10.0 + 9.0);
				int num4 = (int)Math.Round((double)result2 / 10.0 + 18.0);
				if (!double.TryParse(array[2], NumberStyles.AllowDecimalPoint, provider, out tsdsitem_0[num3, num4].AvgEvapDuct))
				{
					tsdsitem_0[num3, num4].AvgEvapDuct = 0.0;
				}
				if (!int.TryParse(array[3], NumberStyles.Integer, provider, out tsdsitem_0[num3, num4].MSQ))
				{
					tsdsitem_0[num3, num4].MSQ = 0;
				}
				num = 0;
				do
				{
					if (!int.TryParse(array[4 + num], NumberStyles.Integer, provider, out tsdsitem_0[num3, num4].CDF[num]))
					{
						tsdsitem_0[num3, num4].CDF[num] = 0;
					}
					num++;
				}
				while (num <= 20);
			}
			catch (MalformedLineException ex)
			{
				ProjectData.SetProjectError(ex);
				ex?.Data.Add("Error at 101180", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		textFieldParser.Close();
		return false;
	}

	internal static bool InstantiateDescriptor(string string_0, ref int[,,] int_2)
	{
		TextFieldParser textFieldParser = new TextFieldParser(string_0);
		CultureInfo provider = new CultureInfo("en-US");
		textFieldParser.TextFieldType = FieldType.Delimited;
		textFieldParser.SetDelimiters("\t");
		int_2 = new int[12, 37, 72];
		while (!textFieldParser.EndOfData)
		{
			try
			{
				string[] array = textFieldParser.ReadFields();
				if (int.TryParse(array[0], NumberStyles.Integer, provider, out var result) && int.TryParse(array[1], NumberStyles.Integer, provider, out var result2) && int.TryParse(array[2], NumberStyles.Integer, provider, out var result3))
				{
					int num = (int)Math.Round((double)result2 / 5.0 + 18.0);
					int num2 = (int)Math.Round((double)result3 / 5.0 + 36.0);
					if (!int.TryParse(array[3], NumberStyles.Integer, provider, out int_2[result - 1, num, num2]))
					{
						int_2[result, num, num2] = 0;
					}
				}
			}
			catch (MalformedLineException ex)
			{
				ProjectData.SetProjectError(ex);
				ex?.Data.Add("Error at 101181", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		textFieldParser.Close();
		return false;
	}

	internal static bool CreateDescriptor(string string_0, ref TESARainItem[,] tesarainItem_0)
	{
		TextFieldParser textFieldParser = new TextFieldParser(string_0);
		CultureInfo provider = new CultureInfo("en-US");
		textFieldParser.TextFieldType = FieldType.Delimited;
		textFieldParser.SetDelimiters("\t");
		tesarainItem_0 = new TESARainItem[121, 241];
		while (!textFieldParser.EndOfData)
		{
			try
			{
				string[] array = textFieldParser.ReadFields();
				if (double.TryParse(array[0], NumberStyles.Float, provider, out var result) && double.TryParse(array[1], NumberStyles.Float, provider, out var result2))
				{
					int num = (int)Math.Round(result / 1.5) + 60;
					int num2 = (int)Math.Round(result2 / 1.5);
					if (!double.TryParse(array[2], NumberStyles.Float, provider, out tesarainItem_0[num, num2].MC))
					{
						tesarainItem_0[num, num2].MC = 0.0;
					}
					if (!double.TryParse(array[3], NumberStyles.Float, provider, out tesarainItem_0[num, num2].MS))
					{
						tesarainItem_0[num, num2].MS = 0.0;
					}
					if (!double.TryParse(array[4], NumberStyles.Float, provider, out tesarainItem_0[num, num2].Pr6))
					{
						tesarainItem_0[num, num2].Pr6 = 0.0;
					}
				}
			}
			catch (MalformedLineException ex)
			{
				ProjectData.SetProjectError(ex);
				ex?.Data.Add("Error at 101182", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		textFieldParser.Close();
		return false;
	}

	internal static bool CompareDescriptor(string string_0, ref double[,] double_0, ref TBILInfo tbilinfo_0, string string_1 = "", string string_2 = "")
	{
		if (FileExistsNative.FileExistsFast(string_0))
		{
			string text = ((Operators.CompareString(string_1, "", TextCompare: false) == 0) ? Path.ChangeExtension(string_0, ".hdr") : string_1);
			if (FileExistsNative.FileExistsFast(text))
			{
				string text2 = ((Operators.CompareString(string_2, "", TextCompare: false) == 0) ? Path.ChangeExtension(string_0, ".blw") : string_2);
				if (FileExistsNative.FileExistsFast(text2))
				{
					TextFieldParser textFieldParser = new TextFieldParser(text);
					textFieldParser.TrimWhiteSpace = true;
					textFieldParser.TextFieldType = FieldType.Delimited;
					textFieldParser.SetDelimiters(" ");
					try
					{
						string[] array = textFieldParser.ReadFields();
						if (Operators.CompareString(Strings.UCase(array[0]), "BYTEORDER", TextCompare: false) == 0)
						{
							int i;
							for (i = 1; Operators.CompareString(array[i], "", TextCompare: false) == 0; i++)
							{
							}
							if ((Operators.CompareString(Strings.UCase(array[i]), "M", TextCompare: false) == 0) | (Operators.CompareString(Strings.UCase(array[i]), "I", TextCompare: false) == 0))
							{
								bool flag = false;
								if (Operators.CompareString(Strings.UCase(array[i]), "M", TextCompare: false) == 0)
								{
									flag = true;
								}
								array = textFieldParser.ReadFields();
								if (Operators.CompareString(Strings.UCase(array[0]), "LAYOUT", TextCompare: false) == 0)
								{
									for (i = 1; Operators.CompareString(array[i], "", TextCompare: false) == 0; i++)
									{
									}
									if (Operators.CompareString(Strings.UCase(array[i]), "BIL", TextCompare: false) == 0)
									{
										array = textFieldParser.ReadFields();
										if (Operators.CompareString(Strings.UCase(array[0]), "NROWS", TextCompare: false) == 0)
										{
											for (i = 1; Operators.CompareString(array[i], "", TextCompare: false) == 0; i++)
											{
											}
											if (int.TryParse(array[i], out tbilinfo_0.NRows))
											{
												array = textFieldParser.ReadFields();
												if (Operators.CompareString(Strings.UCase(array[0]), "NCOLS", TextCompare: false) == 0)
												{
													for (i = 1; Operators.CompareString(array[i], "", TextCompare: false) == 0; i++)
													{
													}
													if (int.TryParse(array[i], out tbilinfo_0.NCols))
													{
														array = textFieldParser.ReadFields();
														if (Operators.CompareString(Strings.UCase(array[0]), "NBANDS", TextCompare: false) == 0)
														{
															for (i = 1; Operators.CompareString(array[i], "", TextCompare: false) == 0; i++)
															{
															}
															if (int.TryParse(array[i], out var result))
															{
																if (result == 1)
																{
																	array = textFieldParser.ReadFields();
																	if (Operators.CompareString(Strings.UCase(array[0]), "NBITS", TextCompare: false) == 0)
																	{
																		for (i = 1; Operators.CompareString(array[i], "", TextCompare: false) == 0; i++)
																		{
																		}
																		if (int.TryParse(array[i], out var result2))
																		{
																			byte[] array2 = MerchantMerchantPage.SelectList.FileSystem.ReadAllBytes(string_0);
																			double_0 = new double[tbilinfo_0.NRows - 1 + 1, tbilinfo_0.NCols - 1 + 1];
																			if ((double)array2.Length == (double)(tbilinfo_0.NRows * tbilinfo_0.NCols * result2) / 8.0)
																			{
																				switch (result2)
																				{
																				default:
																					throw new Exception("Multi-band files not supported");
																				case 32:
																				{
																					i = 0;
																					int num3 = tbilinfo_0.NRows - 1;
																					for (int l = 0; l <= num3; l++)
																					{
																						int num4 = tbilinfo_0.NCols - 1;
																						for (int m = 0; m <= num4; m++)
																						{
																							ulong num5 = (ulong)(flag ? (array2[i + 3] + array2[i + 2] * 256 + array2[i + 1] * 256 * 256 + array2[i] * 256 * 256 * 256) : (array2[i] + array2[i + 1] * 256 + array2[i + 2] * 256 * 256 + array2[i + 3] * 256 * 256 * 256));
																							if (decimal.Compare(new decimal(num5), 2147483647m) <= 0)
																							{
																								double_0[l, m] = num5;
																							}
																							else
																							{
																								double_0[l, m] = Convert.ToDouble(decimal.Subtract(new decimal(num5), 4294967296m));
																							}
																							i += 4;
																						}
																					}
																					break;
																				}
																				case 16:
																				{
																					i = 0;
																					int num6 = tbilinfo_0.NRows - 1;
																					for (int n = 0; n <= num6; n++)
																					{
																						int num7 = tbilinfo_0.NCols - 1;
																						for (int num8 = 0; num8 <= num7; num8++)
																						{
																							uint num9 = (uint)(flag ? (array2[i + 1] + array2[i] * 256) : (array2[i] + array2[i + 1] * 256));
																							if ((long)num9 <= 32767L)
																							{
																								double_0[n, num8] = num9;
																							}
																							else
																							{
																								double_0[n, num8] = (long)num9 - 65536L;
																							}
																							i += 2;
																						}
																					}
																					break;
																				}
																				case 8:
																				{
																					i = 0;
																					int num = tbilinfo_0.NRows - 1;
																					for (int j = 0; j <= num; j++)
																					{
																						int num2 = tbilinfo_0.NCols - 1;
																						for (int k = 0; k <= num2; k++)
																						{
																							byte b = array2[i];
																							if (b <= 127)
																							{
																								double_0[j, k] = (int)b;
																							}
																							else
																							{
																								double_0[j, k] = b - 256;
																							}
																							i++;
																						}
																					}
																					break;
																				}
																				}
																				array2 = null;
																				StreamReader streamReader = new StreamReader(text2, Encoding.ASCII, detectEncodingFromByteOrderMarks: false);
																				CultureInfo provider = new CultureInfo("en-US");
																				if (double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out tbilinfo_0.A))
																				{
																					if (double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out tbilinfo_0.B))
																					{
																						if (double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out tbilinfo_0.C))
																						{
																							if (double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out tbilinfo_0.D))
																							{
																								if (double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out tbilinfo_0.E))
																								{
																									if (double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out tbilinfo_0.F))
																									{
																										streamReader.Close();
																										return true;
																									}
																									throw new Exception("Invalid BLW file format");
																								}
																								throw new Exception("Invalid BLW file format");
																							}
																							throw new Exception("Invalid BLW file format");
																						}
																						throw new Exception("Invalid BLW file format");
																					}
																					throw new Exception("Invalid BLW file format");
																				}
																				throw new Exception("Invalid BLW file format");
																			}
																			throw new Exception("BIL file doesn't match the header");
																		}
																		textFieldParser.Close();
																		return false;
																	}
																	textFieldParser.Close();
																	return false;
																}
																throw new Exception("Multi-band files not supported");
															}
															textFieldParser.Close();
															return false;
														}
														textFieldParser.Close();
														return false;
													}
													textFieldParser.Close();
													return false;
												}
												textFieldParser.Close();
												return false;
											}
											textFieldParser.Close();
											return false;
										}
										textFieldParser.Close();
										return false;
									}
									textFieldParser.Close();
									return false;
								}
								textFieldParser.Close();
								return false;
							}
							textFieldParser.Close();
							return false;
						}
						textFieldParser.Close();
						return false;
					}
					finally
					{
						textFieldParser.Close();
					}
				}
				return false;
			}
			return false;
		}
		return false;
	}

	internal static double ReadDescriptor(double double_0, double double_1, ref double[,] double_2, ref TBILInfo tbilinfo_0)
	{
		if ((Information.UBound(double_2) != tbilinfo_0.NRows - 1) | (Information.UBound(double_2, 2) != tbilinfo_0.NCols - 1))
		{
			throw new Exception("BIL array and BILInfo don't match");
		}
		double num = (double_0 + tbilinfo_0.E * tbilinfo_0.C / tbilinfo_0.A - tbilinfo_0.C * double_1 / tbilinfo_0.A - tbilinfo_0.F) / (tbilinfo_0.D - tbilinfo_0.B * tbilinfo_0.C / tbilinfo_0.A);
		double double_3 = double_1 / tbilinfo_0.A - tbilinfo_0.B * num / tbilinfo_0.A - tbilinfo_0.E / tbilinfo_0.A;
		int val = RadarModel.PrintStub(num);
		int val2 = RadarModel.PrintStub(double_3);
		val2 = Math.Max(0, Math.Min(val2, Information.UBound(double_2, 2)));
		val = Math.Max(0, Math.Min(val, Information.UBound(double_2)));
		return double_2[val, val2];
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	internal static bool DisableDescriptor(string string_0, ref TWeatherHeader tweatherHeader_0)
	{
		int num = Microsoft.VisualBasic.FileSystem.FreeFile();
		Microsoft.VisualBasic.FileSystem.FileOpen(num, string_0, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, 35);
		ValueType Value = tweatherHeader_0;
		Microsoft.VisualBasic.FileSystem.FileGet(num, ref Value, -1L);
		ValueType valueType = Value;
		tweatherHeader_0 = ((valueType == null) ? default(TWeatherHeader) : ((TWeatherHeader)(object)valueType));
		if (tweatherHeader_0.Magic == 1464094019)
		{
			if ((uint)tweatherHeader_0.FormatVersion <= 2u)
			{
				if (tweatherHeader_0.CompressionAlgorithm == 0)
				{
					if (tweatherHeader_0.GridType == 0)
					{
						if ((double)(tweatherHeader_0.Delta_X * (float)tweatherHeader_0.X) <= 360.0)
						{
							if (((double)(tweatherHeader_0.Delta_Y * (float)tweatherHeader_0.Y) >= 180.0) | ((double)((float)(tweatherHeader_0.Y - 1) * tweatherHeader_0.Delta_Y + tweatherHeader_0.LowerY) > 90.0))
							{
								throw new Exception("Wraparound along Y axis unsupported");
							}
							if ((double)tweatherHeader_0.Delta_X == 0.0)
							{
								throw new Exception("X-axis grid step is zero");
							}
							if ((double)tweatherHeader_0.Delta_Y == 0.0)
							{
								throw new Exception("Y-axis grid step is zero");
							}
							if (tweatherHeader_0.Delta_T == 0)
							{
								throw new Exception("Time step is zero");
							}
							Microsoft.VisualBasic.FileSystem.FileClose(num);
							return true;
						}
						throw new Exception("Wraparound along X axis unsupported");
					}
					throw new Exception("Unsupported weather grid type");
				}
				throw new Exception("Unable to read compressed weather files (yet)");
			}
			throw new Exception("Weather file version higher than software version");
		}
		throw new Exception("File doesn't contain weather data");
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	internal static bool UpdateDescriptor(string string_0, ref TWeatherHeader tweatherHeader_0, ref TWeatherRecord[] tweatherRecord_0, int int_2 = -1)
	{
		int num = Microsoft.VisualBasic.FileSystem.FreeFile();
		Microsoft.VisualBasic.FileSystem.FileOpen(num, string_0, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, 35);
		ValueType Value = tweatherHeader_0;
		Microsoft.VisualBasic.FileSystem.FileGet(num, ref Value, -1L);
		ValueType valueType = Value;
		tweatherHeader_0 = ((valueType == null) ? default(TWeatherHeader) : ((TWeatherHeader)(object)valueType));
		if (tweatherHeader_0.Magic == 1464094019)
		{
			if ((uint)tweatherHeader_0.FormatVersion <= 2u)
			{
				if ((uint)tweatherHeader_0.FormatVersion < 2u)
				{
					throw new Exception("Weather file version lower than software version, backward compatibility currently not implemented");
				}
				if (tweatherHeader_0.CompressionAlgorithm == 0)
				{
					if (tweatherHeader_0.GridType == 0)
					{
						if ((double)tweatherHeader_0.Delta_X * (double)tweatherHeader_0.X <= 360.0)
						{
							if (((double)tweatherHeader_0.Delta_Y * (double)tweatherHeader_0.Y >= 180.0) | (((double)tweatherHeader_0.Y - 1.0) * (double)tweatherHeader_0.Delta_Y + (double)tweatherHeader_0.LowerY > 90.0))
							{
								throw new Exception("Wraparound along Y axis unsupported");
							}
							if ((double)tweatherHeader_0.Delta_X == 0.0)
							{
								throw new Exception("X-axis grid step is zero");
							}
							if ((double)tweatherHeader_0.Delta_Y == 0.0)
							{
								throw new Exception("Y-axis grid step is zero");
							}
							if (tweatherHeader_0.Delta_T == 0)
							{
								throw new Exception("Time step is zero");
							}
							int num2;
							int num3;
							if (int_2 <= -1)
							{
								num2 = tweatherHeader_0.X * tweatherHeader_0.Y * tweatherHeader_0.T;
								num3 = 1;
							}
							else
							{
								num2 = tweatherHeader_0.X * tweatherHeader_0.Y;
								num3 = num2 * int_2 + 1;
							}
							tweatherRecord_0 = new TWeatherRecord[num2 - 1 + 1];
							Microsoft.VisualBasic.FileSystem.Seek(num, num3 + 1);
							int num4 = 0;
							TWeatherRecord tWeatherRecord = default(TWeatherRecord);
							do
							{
								Value = tWeatherRecord;
								Microsoft.VisualBasic.FileSystem.FileGet(num, ref Value, -1L);
								ValueType valueType2 = Value;
								tWeatherRecord = ((valueType2 != null) ? ((TWeatherRecord)(object)valueType2) : default(TWeatherRecord));
								tweatherRecord_0[num4] = tWeatherRecord;
								num4++;
							}
							while (!Microsoft.VisualBasic.FileSystem.EOF(num) && num4 < num2);
							Microsoft.VisualBasic.FileSystem.FileClose(num);
							return true;
						}
						throw new Exception("Wraparound along X axis unsupported");
					}
					throw new Exception("Unsupported weather grid type");
				}
				throw new Exception("Unable to read compressed weather files (yet)");
			}
			throw new Exception("Weather file version higher than software version");
		}
		throw new Exception("File doesn't contain weather data");
	}

	internal static int InsertDescriptor(ref TWeatherHeader tweatherHeader_0, double double_0, double double_1, int int_2)
	{
		int val = RadarModel.PrintStub((double_1 - (double)tweatherHeader_0.LeftX) / (double)tweatherHeader_0.Delta_X);
		int val2 = RadarModel.PrintStub((double_0 - (double)tweatherHeader_0.LowerY) / (double)tweatherHeader_0.Delta_Y);
		int val3 = RadarModel.PrintStub((double)int_2 / (double)tweatherHeader_0.Delta_T);
		val = Math.Max(0, Math.Min(tweatherHeader_0.X - 1, val));
		val2 = Math.Max(0, Math.Min(tweatherHeader_0.Y - 1, val2));
		val3 = Math.Max(0, Math.Min(tweatherHeader_0.T - 1, val3));
		return val2 + tweatherHeader_0.Y * val + (short)(tweatherHeader_0.Y * tweatherHeader_0.X) * val3 + 1;
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	internal static bool PrepareDescriptor(string string_0, int int_2, int int_3, int int_4, double double_0, double double_1, object object_0, double double_2 = 1.0, double double_3 = 1.0, int int_5 = 60)
	{
		int num = Microsoft.VisualBasic.FileSystem.FreeFile();
		File.Delete(string_0);
		Microsoft.VisualBasic.FileSystem.FileOpen(num, string_0, OpenMode.Random, OpenAccess.Write, OpenShare.LockRead, 35);
		TWeatherHeader tWeatherHeader = default(TWeatherHeader);
		tWeatherHeader.Magic = 1464094019;
		tWeatherHeader.FormatVersion = 2;
		tWeatherHeader.Smoothing = 0;
		tWeatherHeader.CompressionAlgorithm = 0;
		tWeatherHeader.GridType = 0;
		tWeatherHeader.Delta_T = (short)int_5;
		tWeatherHeader.Delta_X = (float)double_2;
		tWeatherHeader.Delta_Y = (float)double_3;
		tWeatherHeader.LowerY = (float)double_1;
		tWeatherHeader.LeftX = (float)double_0;
		tWeatherHeader.X = (short)int_2;
		tWeatherHeader.Y = (short)int_3;
		tWeatherHeader.T = (short)int_4;
		Microsoft.VisualBasic.FileSystem.FilePut(num, tWeatherHeader, -1L);
		int num2 = 0;
		int num3 = tWeatherHeader.T - 1;
		for (int i = 0; i <= num3; i++)
		{
			int x = tWeatherHeader.X;
			for (int j = 1; j <= x; j++)
			{
				int y = tWeatherHeader.Y;
				for (int k = 1; k <= y; k++)
				{
					TWeatherRecord tWeatherRecord = ((TWeatherRecord[])object_0)[num2];
					Microsoft.VisualBasic.FileSystem.FilePut(num, tWeatherRecord, -1L);
					num2++;
				}
			}
		}
		Microsoft.VisualBasic.FileSystem.FileClose(num);
		return true;
	}

	internal static double ReflectDescriptor(double double_0)
	{
		double num = 157.0 / (157.0 - double_0);
		return 6371.0 * num;
	}

	internal static TAtmosphere VisitDescriptor(TAtmosphereType tatmosphereType_0, int int_2, float? nullable_0 = null)
	{
		double num = (double)int_2 / 1000.0;
		TAtmosphere result = default(TAtmosphere);
		if (!nullable_0.HasValue)
		{
			nullable_0 = 15f;
		}
		float num2 = (float)((double?)nullable_0 + 273.15).Value;
		switch (tatmosphereType_0)
		{
		case TAtmosphereType.atm_Summer_Midlat:
			if (num >= 0.0 && num <= 10.0)
			{
				result.Pressure = 1012.8186 - 111.5569 * num + 3.8646 * num * num;
			}
			else if (num > 10.0 && num <= 72.0)
			{
				result.Pressure = 283.709 * Math.Exp(-0.147 * (num - 10.0));
			}
			else if (num > 72.0 && num <= 100.0)
			{
				result.Pressure = 0.0312402229 * Math.Exp(-0.165 * (num - 72.0));
			}
			else
			{
				result.Pressure = 0.0;
			}
			if (num >= 0.0 && num <= 13.0)
			{
				result.Temperature = 294.9838 - 5.2159 * num - 0.07109 * num * num;
			}
			else if (num > 13.0 && num <= 17.0)
			{
				result.Temperature = 215.15;
			}
			else if (num > 17.0 && num <= 47.0)
			{
				result.Temperature = 215.15 * Math.Exp(0.008128 * (num - 17.0));
			}
			else if (num > 47.0 && num <= 53.0)
			{
				result.Temperature = 275.0;
			}
			else if (num > 53.0 && num <= 80.0)
			{
				result.Temperature = 275.0 + 20.0 * (1.0 - Math.Exp(0.06 * (num - 53.0)));
			}
			else if (num > 80.0 && num <= 100.0)
			{
				result.Temperature = 175.0;
			}
			else
			{
				result.Temperature = 0.0;
			}
			if (num >= 0.0 && num <= 15.0)
			{
				result.Rho = 14.2542 * Math.Exp(-0.4174 * num - 0.0229 * num * num + 0.001007 * num * num * num);
			}
			else
			{
				result.Rho = 0.0;
			}
			break;
		case TAtmosphereType.atm_Winter_Midlat:
			if (num >= 0.0 && num <= 10.0)
			{
				result.Pressure = 1018.8627 - 124.2954 * num + 4.8307 * num * num;
			}
			else if (num > 10.0 && num <= 72.0)
			{
				result.Pressure = 258.9787 * Math.Exp(-0.147 * (num - 10.0));
			}
			else if (num > 72.0 && num <= 100.0)
			{
				result.Pressure = 0.0285170199 * Math.Exp(-0.155 * (num - 72.0));
			}
			else
			{
				result.Pressure = 0.0;
			}
			if (num >= 0.0 && num <= 10.0)
			{
				result.Temperature = 272.7241 - 3.6217 * num - 0.1759 * num * num;
			}
			else if (num > 10.0 && num <= 33.0)
			{
				result.Temperature = 218.0;
			}
			else if (num > 33.0 && num <= 47.0)
			{
				result.Temperature = 218.0 + 3.3571 * (num - 33.0);
			}
			else if (num > 47.0 && num <= 53.0)
			{
				result.Temperature = 265.0;
			}
			else if (num > 53.0 && num <= 80.0)
			{
				result.Temperature = 265.0 - 2.037 * (num - 53.0);
			}
			else if (num > 80.0 && num <= 100.0)
			{
				result.Temperature = 210.0;
			}
			else
			{
				result.Temperature = 0.0;
			}
			if (num >= 0.0 && num <= 10.0)
			{
				result.Rho = 3.4742 * Math.Exp(-0.2697 * num - 0.03604 * num * num + 0.0004489 * num * num * num);
			}
			else
			{
				result.Rho = 0.0;
			}
			break;
		case TAtmosphereType.atm_Summer_Subart:
			if (num >= 0.0 && num <= 10.0)
			{
				result.Pressure = 1008.0278 - 113.2494 * num + 3.9408 * num * num;
			}
			else if (num > 10.0 && num <= 72.0)
			{
				result.Pressure = 269.6138 * Math.Exp(-0.14 * (num - 10.0));
			}
			else if (num > 72.0 && num <= 100.0)
			{
				result.Pressure = 0.0458211532 * Math.Exp(-0.165 * (num - 72.0));
			}
			else
			{
				result.Pressure = 0.0;
			}
			if (num >= 0.0 && num <= 10.0)
			{
				result.Temperature = 286.8374 - 4.7805 * num - 0.1402 * num * num;
			}
			else if (num > 10.0 && num <= 23.0)
			{
				result.Temperature = 225.0;
			}
			else if (num > 23.0 && num <= 48.0)
			{
				result.Temperature = 225.0 * Math.Exp(0.008317 * (num - 23.0));
			}
			else if (num > 48.0 && num <= 53.0)
			{
				result.Temperature = 277.0;
			}
			else if (num > 53.0 && num <= 79.0)
			{
				result.Temperature = 277.0 - 4.0769 * (num - 53.0);
			}
			else if (num > 79.0 && num <= 100.0)
			{
				result.Temperature = 171.0;
			}
			else
			{
				result.Temperature = 0.0;
			}
			if (num >= 0.0 && num <= 15.0)
			{
				result.Rho = 8.988 * Math.Exp(-0.3614 * num - 0.005402 * num * num - 0.001955 * num * num * num);
			}
			else
			{
				result.Rho = 0.0;
			}
			break;
		case TAtmosphereType.atm_Winter_Subart:
			if (num >= 0.0 && num <= 10.0)
			{
				result.Pressure = 1010.8828 - 122.2411 * num + 4.554 * num * num;
			}
			else if (num > 10.0 && num <= 72.0)
			{
				result.Pressure = 243.8718 * Math.Exp(-0.147 * (num - 10.0));
			}
			else if (num > 72.0 && num <= 100.0)
			{
				result.Pressure = 0.0268535481 * Math.Exp(-0.15 * (num - 72.0));
			}
			else
			{
				result.Pressure = 0.0;
			}
			if (num >= 0.0 && num <= 8.5)
			{
				result.Temperature = 257.4345 + 2.3474 * num - 1.5479 * num * num + 0.08473 * num * num * num;
			}
			else if (num > 8.5 && num <= 30.0)
			{
				result.Temperature = 217.5;
			}
			else if (num > 30.0 && num <= 50.0)
			{
				result.Temperature = 217.5 + 2.125 * (num - 30.0);
			}
			else if (num > 50.0 && num <= 54.0)
			{
				result.Temperature = 260.0;
			}
			else if (num > 54.0 && num <= 100.0)
			{
				result.Temperature = 260.0 - 1.667 * (num - 54.0);
			}
			else
			{
				result.Temperature = 0.0;
			}
			if (num >= 0.0 && num <= 10.0)
			{
				result.Rho = 1.2319 * Math.Exp(0.07481 * num - 0.0981 * num * num + 0.00281 * num * num * num);
			}
			else
			{
				result.Rho = 0.0;
			}
			break;
		case TAtmosphereType.atm_Annual_Tropic:
			if (num >= 0.0 && num <= 10.0)
			{
				result.Pressure = 1012.0306 - 109.0338 * num + 3.6316 * num * num;
			}
			else if (num > 10.0 && num <= 72.0)
			{
				result.Pressure = 284.8526 * Math.Exp(-0.147 * (num - 10.0));
			}
			else if (num > 72.0 && num <= 100.0)
			{
				result.Pressure = 0.0313660825 * Math.Exp(-0.165 * (num - 72.0));
			}
			else
			{
				result.Pressure = 0.0;
			}
			if (num >= 0.0 && num <= 17.0)
			{
				result.Temperature = 300.4222 - 6.3533 * num + 0.005886 * num * num;
			}
			else if (num > 17.0 && num <= 47.0)
			{
				result.Temperature = 194.0 + 2.533 * (num - 17.0);
			}
			else if (num > 47.0 && num <= 52.0)
			{
				result.Temperature = 270.0;
			}
			else if (num > 52.0 && num <= 80.0)
			{
				result.Temperature = 270.0 - 3.0714 * (num - 52.0);
			}
			else if (num > 80.0 && num <= 100.0)
			{
				result.Temperature = 184.0;
			}
			else
			{
				result.Temperature = 0.0;
			}
			if (num >= 0.0 && num <= 15.0)
			{
				result.Rho = 19.6542 * Math.Exp(-0.2313 * num - 0.1122 * num * num + 0.01351 * num * num * num - 0.0005923 * num * num * num * num);
			}
			else
			{
				result.Rho = 0.0;
			}
			break;
		case TAtmosphereType.atm_ITU_R_Ref_Std:
			if (num >= 0.0 && num <= 11.0)
			{
				result.Pressure = 1013.25 * Math.Pow(288.15 / (288.15 + -6.5 * num), -5.255846153846154);
			}
			else if (num > 11.0 && num <= 20.0)
			{
				result.Pressure = 226.3226 * Math.Exp(-34.163 * (num - 11.0) / 216.65);
			}
			else if (num > 20.0 && num <= 32.0)
			{
				result.Pressure = 54.7498 * Math.Pow(216.65 / (216.65 + 1.0 * (num - 20.0)), 34.163);
			}
			else if (num > 32.0 && num <= 47.0)
			{
				result.Pressure = 8.6804 * Math.Pow(228.65 / (228.65 + 2.8 * (num - 32.0)), 12.201071428571428);
			}
			else if (num > 47.0 && num <= 51.0)
			{
				result.Pressure = 1.1091 * Math.Exp(-34.163 * (num - 47.0) / 270.65);
			}
			else if (num > 51.0 && num <= 71.0)
			{
				result.Pressure = 0.6694 * Math.Pow(270.65 / (270.65 + -2.8 * (num - 51.0)), -12.201071428571428);
			}
			else if (num > 71.0 && num <= 100.0)
			{
				result.Pressure = 0.0396 * Math.Pow(214.65 / (214.65 + -2.0 * (num - 71.0)), -17.0815);
			}
			else
			{
				result.Pressure = 0.0;
			}
			if (num >= 0.0 && num <= 20.0)
			{
				result.Temperature = (double)num2 + -6.5 * num;
			}
			else if (num > 20.0 && num <= 32.0)
			{
				result.Temperature = (double)num2 - 71.5 + (num - 20.0);
			}
			else if (num > 32.0 && num <= 47.0)
			{
				result.Temperature = (double)num2 - 59.5 + 2.8 * (num - 32.0);
			}
			else if (num > 47.0 && num <= 51.0)
			{
				result.Temperature = (double)num2 - 17.5;
			}
			else if (num > 51.0 && num <= 71.0)
			{
				result.Temperature = (double)num2 - 17.85 - 2.8 * (num - 51.0);
			}
			else if (num > 71.0 && num <= 100.0)
			{
				result.Temperature = (double)num2 - 73.65 - 2.0 * (num - 71.0);
			}
			else
			{
				result.Temperature = 0.0;
			}
			if (num <= 100.0)
			{
				result.Rho = 7.5 * Math.Exp(-0.5 * num);
				if (result.Rho * result.Temperature / 216.7 / result.Pressure < 2E-06)
				{
					double num3 = 2E-06 * result.Pressure;
					result.Rho = num3 * 216.7 / result.Temperature;
				}
			}
			break;
		}
		return result;
	}

	internal static double RestartDescriptor(double double_0, double double_1)
	{
		double num = 6.11 * Math.Pow(10.0, 7.5 * double_1 / (237.7 + double_1));
		return double_0 * num / 100.0 * 100.0 * 1000.0 / ((273.15 + double_1) * 461.5);
	}

	internal static double TestDescriptor(double double_0, double double_1, double double_2)
	{
		double num = double_0 + 273.15;
		double d = 25.22 * (double_0 / num) - 5.31 * Math.Log(num / 273.15);
		double num2 = double_2 * 6.105 * Math.Exp(d) / 100.0;
		return 77.6 * double_1 / num + num2 * 373000.0 / (num * num);
	}

	internal static double StopDescriptor(double double_0, double double_1, double double_2, double double_3)
	{
		return TestDescriptor(double_0, double_1, double_2) + 0.157 * double_3;
	}

	internal static double CancelDescriptor(double double_0, double double_1)
	{
		return double_0 + 0.157 * double_1;
	}

	internal static TTimeOfDayType VerifyDescriptor(DateTime dateTime_0, ref Geodesic_Vincenty.TCoord tcoord_0, double double_0 = 0.0)
	{
		return SunModule.CollectSpecification(null, dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second, bool_0: false, tcoord_0.Lat, tcoord_0.Lon, double_0);
	}

	internal static double ListDescriptor(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, double double_9)
	{
		if (Math.Abs(double_8 - double_6) <= 0.0)
		{
			if (Math.Abs(double_7 - double_9) <= 0.0)
			{
				return double_4;
			}
			return double_4 * (double_7 - double_1) / (double_7 - double_9) + double_2 * (double_1 - double_9) / (double_7 - double_9);
		}
		double num = double_4 * (double_8 - double_0) / (double_8 - double_6) + double_5 * (double_0 - double_6) / (double_8 - double_6);
		double num2 = double_2 * (double_8 - double_0) / (double_8 - double_6) + double_3 * (double_0 - double_6) / (double_8 - double_6);
		return num * (double_7 - double_1) / (double_7 - double_9) + num2 * (double_1 - double_9) / (double_7 - double_9);
	}

	internal static bool ResolveDescriptor(TESARainItem tesarainItem_0, ref double[] double_0)
	{
		double_0 = new double[100];
		if (tesarainItem_0.Pr6 == 0.0)
		{
			return false;
		}
		double num = tesarainItem_0.Pr6 * (1.0 - Math.Exp(-0.0117 * tesarainItem_0.MS / tesarainItem_0.Pr6));
		double num2 = 1.11;
		double num3 = (tesarainItem_0.MC + tesarainItem_0.MS) / (22932.0 * num);
		double num4 = 31.5 * num3;
		double num5 = num2 * num3;
		double_0[0] = 0.0;
		int num6 = 1;
		do
		{
			double num7 = num2 + num4 * Math.Log((double)(100 - num6) / 100.0 / num);
			double num8 = Math.Log((double)(100 - num6) / 100.0 / num);
			double_0[num6] = (0.0 - num7 + Math.Sqrt(Math.Pow(num7, 2.0) - 4.0 * num5 * num8)) / (2.0 * num5);
			if (double.IsNaN(double_0[num6]) | (double_0[num6] < double_0[num6 - 1]))
			{
				double_0[num6] = double_0[num6 - 1];
			}
			num6++;
		}
		while (num6 <= 99);
		return true;
	}

	internal static bool PostDescriptor(double double_0, double double_1, ref TESARainItem[,] tesarainItem_0, ref double[] double_2)
	{
		if ((Information.UBound(tesarainItem_0) != 120) | (Information.UBound(tesarainItem_0, 2) != 240))
		{
			throw new ArgumentOutOfRangeException("Wrong dimensions of ESARain array");
		}
		double num = double_1;
		if (num < 0.0)
		{
			num += 360.0;
		}
		int num2 = RadarModel.PrintStub(num / 1.5);
		int num3 = RadarModel.PrintStub(double_0 / 1.5) + 60;
		double num4 = (double)num2 * 1.5;
		double num5 = (double)(num3 - 60) * 1.5;
		if ((Math.Abs(num4 - num) < 1E-12) & (Math.Abs(num5 - double_0) < 1E-12))
		{
			return ResolveDescriptor(tesarainItem_0[num3, num2], ref double_2);
		}
		int num6;
		if (num3 == 120)
		{
			num3 = 119;
			num5 = 88.5;
			num6 = 120;
		}
		else
		{
			num6 = num3 + 1;
		}
		int num7;
		if (num2 == 240)
		{
			num2 = 239;
			num4 = 358.5;
			num7 = 240;
		}
		else
		{
			num7 = num2 + 1;
		}
		double double_3 = (double)num7 * 1.5;
		double double_4 = (double)(num6 - 60) * 1.5;
		if (num2 - num7 > 1 || num6 - num3 > 1)
		{
			throw new Exception("Non-neighbour interpolation");
		}
		TESARainItem tesarainItem_ = default(TESARainItem);
		tesarainItem_.MC = ListDescriptor(num, double_0, tesarainItem_0[num6, num2].MC, tesarainItem_0[num6, num7].MC, tesarainItem_0[num3, num2].MC, tesarainItem_0[num3, num7].MC, num4, double_4, double_3, num5);
		tesarainItem_.MS = ListDescriptor(num, double_0, tesarainItem_0[num6, num2].MS, tesarainItem_0[num6, num7].MS, tesarainItem_0[num3, num2].MS, tesarainItem_0[num3, num7].MS, num4, double_4, double_3, num5);
		tesarainItem_.Pr6 = ListDescriptor(num, double_0, tesarainItem_0[num6, num2].Pr6, tesarainItem_0[num6, num7].Pr6, tesarainItem_0[num3, num2].Pr6, tesarainItem_0[num3, num7].Pr6, num4, double_4, double_3, num5);
		return ResolveDescriptor(tesarainItem_, ref double_2);
	}

	internal static double RunDescriptor(int int_2)
	{
		double result = 0.0;
		switch (int_2)
		{
		case 0:
			result = 0.0;
			break;
		case 1:
			result = 3.131;
			break;
		case 2:
			result = 7.67;
			break;
		case 3:
			result = 13.099;
			break;
		case 4:
			result = 19.175;
			break;
		case 5:
			result = 25.246;
			break;
		case 6:
			result = 31.313;
			break;
		case 7:
			result = 38.351;
			break;
		case 8:
			result = 47.489;
			break;
		case 9:
			result = 54.237;
			break;
		}
		return result;
	}

	private static void Main__()
	{
		Console.WriteLine(StopDescriptor(24.5, 1020.3, 95.0, 2.0));
		Console.WriteLine(StopDescriptor(25.9, 1018.91, 90.3, 14.0));
		Console.WriteLine(StopDescriptor(26.2, 1018.85, 90.3, 15.0));
		Console.WriteLine(StopDescriptor(26.4, 1009.21, 89.8, 99.0));
		Console.WriteLine(StopDescriptor(26.6, 1000.0, 82.0, 178.0));
		Console.WriteLine(StopDescriptor(21.6, 920.08, 76.4, 913.0));
		Console.WriteLine(StopDescriptor(17.0, 850.0, 79.8, 1601.0));
	}

	public static WeatherProfile DefaultWeather()
	{
		return new WeatherProfile();
	}

	public static bool Visibility(Module_Unit.Unit unit_0, Module_Unit.Unit unit_1, ref Scenario scenario_0)
	{
		float fractionUnderRain = GetWeatherAtThisTimeAndPlace(scenario_0, unit_1.GetLatitude(), unit_1.GetLongitude(), (int)Math.Round(unit_1.GetCurrentAltitude())).FractionUnderRain;
		if (fractionUnderRain <= 0.9f)
		{
			if (fractionUnderRain <= 0.8f)
			{
				if (fractionUnderRain <= 0.7f)
				{
					if (fractionUnderRain <= 0.6f)
					{
						if (fractionUnderRain <= 0.5f)
						{
							if (fractionUnderRain <= 0.4f)
							{
								if (fractionUnderRain <= 0.3f)
								{
									if (fractionUnderRain <= 0.2f)
									{
										if (fractionUnderRain <= 0.1f)
										{
											if (fractionUnderRain <= 0f)
											{
												return true;
											}
											if (!(unit_0.GetCurrentAltitude() < 2133.6f) && unit_1.GetCurrentAltitude() >= 2133.6f)
											{
												return true;
											}
											if (unit_0.GetCurrentAltitude() <= 1524f && unit_1.GetCurrentAltitude() <= 1524f)
											{
												return true;
											}
											if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 1524f)
											{
												return true;
											}
											return false;
										}
										if (!(unit_0.GetCurrentAltitude() < 4876.8f) && unit_1.GetCurrentAltitude() >= 4876.8f)
										{
											return true;
										}
										if (unit_0.GetCurrentAltitude() <= 3048f && unit_1.GetCurrentAltitude() <= 3048f)
										{
											return true;
										}
										if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 1524f)
										{
											return true;
										}
										return false;
									}
									if (!(unit_0.GetCurrentAltitude() < 7010.4f) && unit_1.GetCurrentAltitude() >= 7010.4f)
									{
										return true;
									}
									if (unit_0.GetCurrentAltitude() <= 6096f && unit_1.GetCurrentAltitude() <= 6096f)
									{
										return true;
									}
									if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 1524f)
									{
										return true;
									}
									return false;
								}
								if (!(unit_0.GetCurrentAltitude() < 2133.6f) && unit_1.GetCurrentAltitude() >= 2133.6f)
								{
									return true;
								}
								if (unit_0.GetCurrentAltitude() <= 609.6f && unit_1.GetCurrentAltitude() <= 609.6f)
								{
									return true;
								}
								if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 762f)
								{
									return true;
								}
								return false;
							}
							if (!(unit_0.GetCurrentAltitude() < 4876.8f) && unit_1.GetCurrentAltitude() >= 4876.8f)
							{
								return true;
							}
							if (unit_0.GetCurrentAltitude() <= 2133.6f && unit_1.GetCurrentAltitude() <= 2133.6f)
							{
								return true;
							}
							if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 762f)
							{
								return true;
							}
							return false;
						}
						if (!(unit_0.GetCurrentAltitude() < 8534.4f) && unit_1.GetCurrentAltitude() >= 8534.4f)
						{
							return true;
						}
						if (unit_0.GetCurrentAltitude() <= 7620f && unit_1.GetCurrentAltitude() <= 7620f)
						{
							return true;
						}
						if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 762f)
						{
							return true;
						}
						return false;
					}
					if (!(unit_0.GetCurrentAltitude() < 9144f) && unit_1.GetCurrentAltitude() >= 9144f)
					{
						return true;
					}
					if (unit_0.GetCurrentAltitude() >= 4876.8f && unit_0.GetCurrentAltitude() <= 8229.6f && unit_1.GetCurrentAltitude() >= 4876.8f && unit_1.GetCurrentAltitude() <= 8229.6f)
					{
						return true;
					}
					if (unit_0.GetCurrentAltitude() <= 2133.6f && unit_1.GetCurrentAltitude() <= 2133.6f)
					{
						return true;
					}
					if (!(unit_0.GetCurrentAltitude() < 4876.8f) && unit_1.GetCurrentAltitude() >= 4876.8f)
					{
						if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 1524f)
						{
							return true;
						}
					}
					else if (Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 762f)
					{
						return true;
					}
					return false;
				}
				if (!(unit_0.GetCurrentAltitude() < 10972.8f) && unit_1.GetCurrentAltitude() >= 10972.8f)
				{
					return true;
				}
				if (unit_0.GetCurrentAltitude() >= 4876.8f && unit_0.GetCurrentAltitude() <= 9144f && unit_1.GetCurrentAltitude() >= 4876.8f && unit_1.GetCurrentAltitude() <= 9144f)
				{
					return true;
				}
				if (unit_0.GetCurrentAltitude() <= 2133.6f && unit_1.GetCurrentAltitude() <= 2133.6f)
				{
					return true;
				}
				if (unit_0.GetCurrentAltitude() >= 4876.8f && unit_1.GetCurrentAltitude() >= 4876.8f && Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 762f)
				{
					return true;
				}
				return false;
			}
			if (!(unit_0.GetCurrentAltitude() < 10972.8f) && unit_1.GetCurrentAltitude() >= 10972.8f)
			{
				return true;
			}
			if (unit_0.CurrentAltitude_AGL >= 609.6f && unit_0.GetCurrentAltitude() <= 2133.6f && unit_1.CurrentAltitude_AGL >= 609.6f && unit_1.GetCurrentAltitude() <= 2133.6f)
			{
				return true;
			}
			if ((unit_0.CurrentAltitude_AGL < 2000f || unit_1.CurrentAltitude_AGL < 2000f) && Math.Abs(unit_0.GetCurrentAltitude() - unit_1.GetCurrentAltitude()) < 304.8f)
			{
				return true;
			}
			return false;
		}
		if (!unit_0.IsShip && !unit_0.IsSubmarine && !unit_0.IsFacility)
		{
			if (!unit_1.IsShip && !unit_1.IsSubmarine && !unit_1.IsFacility)
			{
				if (!(unit_0.GetCurrentAltitude() < 10972.8f) && unit_1.GetCurrentAltitude() >= 10972.8f)
				{
					return true;
				}
				if (unit_0.CurrentAltitude_AGL >= 609.6f && unit_0.GetCurrentAltitude() <= 2133.6f && unit_1.CurrentAltitude_AGL >= 609.6f && unit_1.GetCurrentAltitude() <= 2133.6f)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}
}
