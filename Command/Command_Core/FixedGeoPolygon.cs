using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class FixedGeoPolygon
{
	protected float? _Bounds_North;

	protected float? _Bounds_South;

	protected float? _Bounds_East;

	protected float? _Bounds_West;

	private double[] messageClient;

	private double[] productClient;

	public abstract List<Geopoint_Struct> Area { get; }

	public double[] LongitudesArray
	{
		get
		{
			if (Information.IsNothing(messageClient))
			{
				messageClient = Area.Select((Geopoint_Struct theGP) => theGP.Longitude).ToArray();
			}
			return messageClient;
		}
	}

	public double[] LatitudesArray
	{
		get
		{
			if (Information.IsNothing(productClient))
			{
				productClient = Area.Select((Geopoint_Struct theGP) => theGP.Latitude).ToArray();
			}
			return productClient;
		}
	}

	protected float Bounds_North
	{
		get
		{
			if (!_Bounds_North.HasValue)
			{
				_Bounds_North = (float)(from theGP in Area
					select (theGP) into theGP
					orderby theGP.Latitude descending
					select theGP).ElementAtOrDefault(0).Latitude;
			}
			return _Bounds_North.Value;
		}
	}

	protected float Bounds_South
	{
		get
		{
			if (!_Bounds_South.HasValue)
			{
				_Bounds_South = (float)(from theGP in Area
					select (theGP) into theGP
					orderby theGP.Latitude
					select theGP).ElementAtOrDefault(0).Latitude;
			}
			return _Bounds_South.Value;
		}
	}

	protected float Bounds_East
	{
		get
		{
			if (!_Bounds_East.HasValue)
			{
				_Bounds_East = (float)(from theGP in Area
					select (theGP) into theGP
					orderby theGP.Longitude descending
					select theGP).ElementAtOrDefault(0).Longitude;
			}
			return _Bounds_East.Value;
		}
	}

	protected float Bounds_West
	{
		get
		{
			if (!_Bounds_West.HasValue)
			{
				_Bounds_West = (float)(from theGP in Area
					select (theGP) into theGP
					orderby theGP.Longitude
					select theGP).ElementAtOrDefault(0).Longitude;
			}
			return _Bounds_West.Value;
		}
	}

	[SpecialName]
	public bool GetPointIsInArea(double double_0, double double_1, bool bool_0)
	{
		try
		{
			if (double_0 <= (double)Bounds_North)
			{
				if (double_0 < (double)Bounds_South)
				{
					return false;
				}
				if (double_1 <= (double)Bounds_East)
				{
					if (double_1 < (double)Bounds_West)
					{
						return false;
					}
					double[] double_2 = LongitudesArray;
					double[] double_3 = LatitudesArray;
					return GeoPoint.PointInPolygon(ref double_0, ref double_1, ref double_2, ref double_3);
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200095", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	public bool GetPointIsInArea(GeoPoint geoPoint_0, bool bool_0)
	{
		if (geoPoint_0.Latitude <= (double)Bounds_North)
		{
			if (geoPoint_0.Latitude < (double)Bounds_South)
			{
				return false;
			}
			if (geoPoint_0.Longitude <= (double)Bounds_East)
			{
				if (geoPoint_0.Longitude < (double)Bounds_West)
				{
					return false;
				}
				GeoPoint geoPoint;
				double double_ = (geoPoint = geoPoint_0).Latitude;
				GeoPoint geoPoint2;
				double double_2 = (geoPoint2 = geoPoint_0).Longitude;
				double[] double_3 = LongitudesArray;
				double[] double_4 = LatitudesArray;
				bool result = GeoPoint.PointInPolygon(ref double_, ref double_2, ref double_3, ref double_4);
				geoPoint2.Longitude = double_2;
				geoPoint.Latitude = double_;
				return result;
			}
			return false;
		}
		return false;
	}
}
