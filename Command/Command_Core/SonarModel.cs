using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SonarModel
{
	public enum PositionRelativeToThermocline : byte
	{
		Above,
		Inside,
		Below
	}

	public sealed class ThermoclineLayer
	{
		public int Ceiling;

		public int Floor;

		public float Strength;

		[SpecialName]
		public bool GetIsInsideDeepSoundChannel(float float_0)
		{
			return Math.Abs(float_0 - (float)Floor) < 70f;
		}
	}

	public const double DirectPathMaxRange__Nominal_NM = 9.87473;

	public const int SurfaceDuctMaxDepth = -50;

	private static Dictionary<int, float> _BridgeProxy;

	private static List<int> m_InvocationProxy;

	private static object classProxy;

	static SonarModel()
	{
		classProxy = RuntimeHelpers.GetObjectValue(new object());
	}

	public static float smethod_0(double double_0, double double_1, Side side_0, Scenario scenario_0)
	{
		if (double_0 < 69.7 && double_0 > -59.45)
		{
			double num = ((double_0 < 0.0) ? (40.0 - Math.Abs(double_0) / 2.9) : (40.0 - Math.Abs(double_0) / 3.4));
			if (scenario_0.NatureSideExists())
			{
				foreach (CustomEnvironmentZone customEnvironmentZone in scenario_0.GetNatureSide().CustomEnvironmentZones)
				{
					if (GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
					{
						return customEnvironmentZone.Single_0;
					}
				}
			}
			return (float)num;
		}
		return 0f;
	}

	public static void GetThermalLayerAtThisLocation(double double_0, double double_1, int int_0, ref int int_1, ref int int_2, ref float float_0, bool bool_0, Scenario scenario_0)
	{
		ThermoclineLayer thermalLayerAtThisLocation = GetThermalLayerAtThisLocation(double_0, double_1, int_0, scenario_0);
		int_1 = thermalLayerAtThisLocation.Ceiling;
		int_2 = thermalLayerAtThisLocation.Floor;
		float_0 = thermalLayerAtThisLocation.Strength;
	}

	private static float CountSpecification(double double_0)
	{
		if (double_0 > -63.0 && double_0 < 70.0)
		{
			if (_BridgeProxy == null || m_InvocationProxy == null)
			{
				object obj = classProxy;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					_BridgeProxy = new Dictionary<int, float>();
					_BridgeProxy.Add(-63, 0f);
					_BridgeProxy.Add(-54, 0.1f);
					_BridgeProxy.Add(-45, 0.2f);
					_BridgeProxy.Add(-36, 0.3f);
					_BridgeProxy.Add(-27, 0.4f);
					_BridgeProxy.Add(-18, 0.5f);
					_BridgeProxy.Add(-9, 0.6f);
					_BridgeProxy.Add(0, 0.7f);
					_BridgeProxy.Add(10, 0.6f);
					_BridgeProxy.Add(20, 0.5f);
					_BridgeProxy.Add(30, 0.4f);
					_BridgeProxy.Add(40, 0.3f);
					_BridgeProxy.Add(50, 0.2f);
					_BridgeProxy.Add(60, 0.1f);
					_BridgeProxy.Add(70, 0f);
					m_InvocationProxy = new List<int>(_BridgeProxy.Keys);
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			float result = 0f;
			try
			{
				int num = m_InvocationProxy.Count - 2;
				int num2 = 0;
				int num3;
				int num4;
				while (true)
				{
					if (num2 <= num)
					{
						num3 = m_InvocationProxy[num2];
						num4 = m_InvocationProxy[num2 + 1];
						if (double_0 > (double)num3 && !(double_0 >= (double)num4))
						{
							break;
						}
						num2++;
						continue;
					}
					return result;
				}
				double num5 = (double_0 - (double)num3) / (double)(num4 - num3);
				result = (float)((double_0 < 0.0) ? ((double)_BridgeProxy[num3] + num5 * (double)Math.Abs(_BridgeProxy[num4] - _BridgeProxy[num3])) : ((double)_BridgeProxy[num3] - num5 * (double)Math.Abs(_BridgeProxy[num4] - _BridgeProxy[num3])));
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
		return 0f;
	}

	public static float SonarPropagationModifier(bool bool_0, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float? nullable_0 = null)
	{
		float float_ = 1f;
		CloneSpecification(activeUnit_0, activeUnit_1, ref float_, nullable_0);
		EffectOfThermalLayer(activeUnit_0, activeUnit_1, ref float_, nullable_0);
		if (bool_0)
		{
			CustomizeSpecification(activeUnit_0, activeUnit_1, ref float_, nullable_0);
		}
		return float_;
	}

	private static void CustomizeSpecification(object object_0, object object_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			ThermoclineLayer thermalLayerAtThisLocation = GetThermalLayerAtThisLocation(((ActiveUnit)object_0).GetLatitude(), ((ActiveUnit)object_0).GetLongitude(), ((Module_Unit.Unit)object_0).GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ((ActiveUnit)object_0).ParentScen), ((ActiveUnit)object_0).ParentScen);
			ThermoclineLayer thermalLayerAtThisLocation2 = GetThermalLayerAtThisLocation(((ActiveUnit)object_1).GetLatitude(), ((ActiveUnit)object_1).GetLongitude(), ((Module_Unit.Unit)object_1).GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ((ActiveUnit)object_0).ParentScen), ((ActiveUnit)object_0).ParentScen);
			float float_ = (nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(((ActiveUnit)object_0).GetCurrentAltitude())));
			PositionRelativeToThermocline positionRelativeToThermocline = GetPositionRelativeToThermocline(float_, thermalLayerAtThisLocation);
			PositionRelativeToThermocline positionRelativeToThermocline2 = GetPositionRelativeToThermocline((int)Math.Round(((ActiveUnit)object_1).GetCurrentAltitude()), thermalLayerAtThisLocation2);
			if (positionRelativeToThermocline == PositionRelativeToThermocline.Below && positionRelativeToThermocline2 == PositionRelativeToThermocline.Below)
			{
				if (thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel(float_) && thermalLayerAtThisLocation2.GetIsInsideDeepSoundChannel((int)Math.Round(((ActiveUnit)object_1).GetCurrentAltitude())))
				{
					float_0 *= 2f;
				}
				else if (thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel(float_) || thermalLayerAtThisLocation2.GetIsInsideDeepSoundChannel((int)Math.Round(((ActiveUnit)object_1).GetCurrentAltitude())))
				{
					float_0 = (float)((double)float_0 * 1.5);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 102134656566777", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void EffectOfThermalLayer(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			ThermoclineLayer thermalLayerAtThisLocation = GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen), activeUnit_1.ParentScen);
			ThermoclineLayer thermalLayerAtThisLocation2 = GetThermalLayerAtThisLocation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen), activeUnit_1.ParentScen);
			PositionRelativeToThermocline positionRelativeToThermocline = GetPositionRelativeToThermocline(nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude())), thermalLayerAtThisLocation);
			PositionRelativeToThermocline positionRelativeToThermocline2 = GetPositionRelativeToThermocline((int)Math.Round(activeUnit_1.GetCurrentAltitude()), thermalLayerAtThisLocation2);
			float num = (thermalLayerAtThisLocation.Strength + thermalLayerAtThisLocation2.Strength) / 2f;
			if (num == 0f || (positionRelativeToThermocline == PositionRelativeToThermocline.Above && positionRelativeToThermocline2 == PositionRelativeToThermocline.Above))
			{
				return;
			}
			if (positionRelativeToThermocline == PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 == PositionRelativeToThermocline.Inside)
			{
				float_0 = (float)((double)float_0 * Math.Max(0.1, 1f - num * 2f));
			}
			else if (positionRelativeToThermocline != PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 != PositionRelativeToThermocline.Inside)
			{
				if (positionRelativeToThermocline == positionRelativeToThermocline2)
				{
					if (positionRelativeToThermocline != PositionRelativeToThermocline.Below)
					{
					}
				}
				else
				{
					float_0 *= 1f - num;
				}
			}
			else
			{
				float_0 *= 1f - num / 2f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100734", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CloneSpecification(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			int num = -50;
			if ((nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude()))) > (float)num && activeUnit_1.GetCurrentAltitude() > (float)num)
			{
				float_0 = (float)(1.5 * (double)float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100732", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static int ConnectSpecification(double double_0)
	{
		if (double_0 < 69.7 && double_0 > -59.45)
		{
			return (int)Math.Round((double_0 < 0.0) ? (-5380.0 + Math.Abs(double_0) / 2.9 * 220.0) : (-5380.0 + Math.Abs(double_0) / 3.4 * 220.0));
		}
		return int.MaxValue;
	}

	public static ThermoclineLayer GetThermalLayerAtThisLocation(double double_0, double double_1, int int_0, Scenario scenario_0)
	{
		ThermoclineLayer result = null;
		try
		{
			ThermoclineLayer thermoclineLayer = new ThermoclineLayer();
			float num = 1f - (float)(Math.Abs(double_0) / 90.0);
			thermoclineLayer.Ceiling = Math.Min(-40, (int)Math.Round(-10f + num * -150f - -10f));
			int num2 = (int)Math.Round(10f + num * 90f);
			thermoclineLayer.Floor = thermoclineLayer.Ceiling - num2;
			short elevation = Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0);
			if (elevation > thermoclineLayer.Floor)
			{
				thermoclineLayer.Ceiling = (int)Math.Round((double)thermoclineLayer.Ceiling * ((double)Math.Abs(elevation) / 250.0));
				num2 = (int)Math.Round((double)num2 * ((double)Math.Abs(elevation) / 250.0));
				thermoclineLayer.Floor = (int)Math.Round((double)thermoclineLayer.Floor * ((double)Math.Abs(elevation) / 250.0));
			}
			thermoclineLayer.Strength = CountSpecification(double_0);
			if (!Information.IsNothing(scenario_0) && scenario_0.NatureSideExists())
			{
				foreach (CustomEnvironmentZone customEnvironmentZone in scenario_0.GetNatureSide().CustomEnvironmentZones)
				{
					if (GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
					{
						result = customEnvironmentZone.ThermalLayer;
						return result;
					}
				}
			}
			result = thermoclineLayer;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101125", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static PositionRelativeToThermocline GetPositionRelativeToThermocline(float float_0, ThermoclineLayer thermoclineLayer_0)
	{
		if (float_0 <= -10f)
		{
			if (float_0 <= (float)thermoclineLayer_0.Ceiling)
			{
				if (float_0 < (float)thermoclineLayer_0.Floor)
				{
					return PositionRelativeToThermocline.Below;
				}
				return PositionRelativeToThermocline.Inside;
			}
			return PositionRelativeToThermocline.Above;
		}
		return PositionRelativeToThermocline.Above;
	}

	public static PositionRelativeToThermocline GetPositionRelativeToThermocline(double double_0, double double_1, float float_0, Scenario scenario_0)
	{
		if (float_0 <= -10f)
		{
			int elevation = Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0);
			int int_ = 0;
			int int_2 = 0;
			float float_ = 0f;
			GetThermalLayerAtThisLocation(double_0, double_1, elevation, ref int_, ref int_2, ref float_, bool_0: false, scenario_0);
			if (float_0 <= (float)int_)
			{
				if (float_0 < (float)int_2)
				{
					return PositionRelativeToThermocline.Below;
				}
				return PositionRelativeToThermocline.Inside;
			}
			return PositionRelativeToThermocline.Above;
		}
		return PositionRelativeToThermocline.Above;
	}
}
