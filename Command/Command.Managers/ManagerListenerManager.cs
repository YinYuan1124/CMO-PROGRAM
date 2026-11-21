using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using CSMaterial;
using Command.Listeners;
using Command_Core;
using DigitalRune.Mathematics;
using ExWorldWind;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Managers;

[StandardModule]
internal sealed class ManagerListenerManager
{
	public static WorldCamera _AdapterExporter;

	private static bool schemaExporter;

	static ManagerListenerManager()
	{
		schemaExporter = false;
	}

	public static Point SetInterruptibleMap(WorldWindow worldWindow_0, double double_0, double double_1)
	{
		Point result = default(Point);
		DrawArgs utilsResolver = InterpreterObjectListener._UtilsResolver;
		int int_ = result.X;
		int int_2 = result.Y;
		InstantiateInterruptibleMap(worldWindow_0, utilsResolver, ref double_0, ref double_1, ref int_, ref int_2);
		result.Y = int_2;
		result.X = int_;
		return result;
	}

	public static GeoPoint FillInterruptibleMap(WorldWindow worldWindow_0, int int_0, int int_1)
	{
		GeoPoint geoPoint = new GeoPoint();
		Angle angle_ = default(Angle);
		Angle angle_2 = default(Angle);
		worldWindow_0.DrawArgs.WorldCamera.PickingRayIntersection(int_0, int_1, out angle_, out angle_2);
		geoPoint.Longitude = angle_2.Degrees;
		geoPoint.Latitude = angle_.Degrees;
		return geoPoint;
	}

	public static Geopoint_Struct CalculateInterruptibleMap(WorldWindow worldWindow_0, int int_0, int int_1)
	{
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		Angle angle_ = default(Angle);
		Angle angle_2 = default(Angle);
		Geopoint_Struct result = default(Geopoint_Struct);
		try
		{
			worldWindow_0?.DrawArgs?.WorldCamera?.PickingRayIntersection(int_0, int_1, out angle_, out angle_2);
			geopoint_Struct.Longitude = angle_2.Degrees;
			geopoint_Struct.Latitude = angle_.Degrees;
			result = geopoint_Struct;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 32450239465095", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void PopInterruptibleMap(WorldWindow worldWindow_0, ref int int_0, ref int int_1, ref double double_0, ref double double_1)
	{
		try
		{
			Angle angle_ = default(Angle);
			Angle angle_2 = default(Angle);
			worldWindow_0?.DrawArgs?.WorldCamera?.PickingRayIntersection(int_0, int_1, out angle_, out angle_2);
			double_0 = angle_2.Degrees;
			double_1 = angle_.Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 32459038569486", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void InstantiateInterruptibleMap(WorldWindow worldWindow_0, DrawArgs worldCamera_0, ref double double_0, ref double double_1, ref int int_0, ref int int_1)
	{
		double double_2 = double_0;
		double num = double_1;
		try
		{
			if (!Numeric.IsNaN(double_2) && CSMath.IsFinite(double_2) && !Numeric.IsNaN(num) && CSMath.IsFinite(num))
			{
				Vector3 vector = MathEngine.SphericalToCartesian(double_2, num, 6378137.0);
				Vector3 vector3_ = new Vector3(vector.X - worldCamera_0.WorldCamera.ReferenceCenter.X, vector.Y - worldCamera_0.WorldCamera.ReferenceCenter.Y, vector.Z - worldCamera_0.WorldCamera.ReferenceCenter.Z);
				if (!schemaExporter)
				{
					_AdapterExporter = worldWindow_0.DrawArgs.WorldCamera;
					schemaExporter = true;
				}
				Vector3 vector2 = _AdapterExporter.Project(vector3_);
				if (!Numeric.IsNaN(vector2.X) && !Numeric.IsNaN(vector2.Y))
				{
					int_0 = (int)Math.Round(vector2.X);
					int_1 = (int)Math.Round(vector2.Y);
				}
			}
			else
			{
				int_0 = -1;
				int_1 = -1;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200424", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CreateInterruptibleMap(WorldWindow worldWindow_0, double double_0, double double_1)
	{
		if (double.IsNaN(double_0) | double.IsNaN(double_1))
		{
			return false;
		}
		Vector3 vector3_ = MathEngine.SphericalToCartesian(double_0, double_1, 6378137.0);
		return worldWindow_0.DrawArgs.WorldCamera.ViewFrustum.ContainsPoint(vector3_);
	}

	public static bool CompareInterruptibleMap(WorldWindow worldWindow_0, object object_0)
	{
		if (((ScenarioObject)object_0).IsActiveUnit && !((ActiveUnit)object_0).IsOperating())
		{
			return false;
		}
		if (((ScenarioObject)object_0).DisableWriter())
		{
			List<Geopoint_Struct> uncertaintyArea = ((Contact)object_0).UncertaintyArea;
			if (uncertaintyArea != null)
			{
				int count = uncertaintyArea.Count;
				if (CreateInterruptibleMap(worldWindow_0, ((Module_Unit.Unit)object_0).GetLatitude(), ((Module_Unit.Unit)object_0).GetLongitude()))
				{
					return true;
				}
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					Geopoint_Struct geopoint_Struct = uncertaintyArea[i];
					if (CreateInterruptibleMap(worldWindow_0, geopoint_Struct.Latitude, geopoint_Struct.Longitude))
					{
						return true;
					}
				}
				return false;
			}
		}
		double latitude = ((Module_Unit.Unit)object_0).GetLatitude();
		double longitude = ((Module_Unit.Unit)object_0).GetLongitude();
		if (double.IsNaN(latitude))
		{
			return false;
		}
		if (double.IsNaN(longitude))
		{
			return false;
		}
		Vector3 vector3_ = MathEngine.SphericalToCartesian(latitude, longitude, 6378137.0);
		return worldWindow_0.DrawArgs.WorldCamera.ViewFrustum.ContainsPoint(vector3_);
	}
}
