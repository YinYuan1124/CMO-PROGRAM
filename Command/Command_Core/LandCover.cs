using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using BitMiracle.LibTiff.Classic;
using Command.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class LandCover
{
	public enum LandCoverType : byte
	{
		Water = 0,
		Evergreen_Needleleaf_forest = 1,
		Evergreen_Broadleaf_forest = 2,
		Deciduous_Needleleaf_forest = 3,
		Deciduous_Broadleaf_forest = 4,
		Mixed_forest = 5,
		Closed_shrublands = 6,
		Open_shrublands = 7,
		Woody_savannas = 8,
		Savannas = 9,
		Grasslands = 10,
		Permanent_wetlands = 11,
		Croplands = 12,
		UrbanAndBuiltUp = 13,
		CroplandNaturalVegetationMosaic = 14,
		SnowAndIce = 15,
		BarrenOrSparselyVegetated = 16,
		Unclassified = 254,
		Use_Underlying_Values = byte.MaxValue,
		Urban_CloseInnerCity = 201,
		Urban_SpacedHighRise = 202,
		Urban_AttachedHouses = 203,
		Urban_CloseIndustrial = 204,
		Urban_SpacedApartments = 205,
		Urban_DetachedHouses = 206,
		Urban_SpacedIndustrial = 207,
		Urban_ShantyTown = 208
	}

	[CompilerGenerated]
	private sealed class _003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__10 : IEnumerable<Tuple<LandCoverType, int>>, IEnumerable, IEnumerator<Tuple<LandCoverType, int>>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private Tuple<LandCoverType, int> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private double double_0;

		public double _003C_003E3__double_0;

		private double double_1;

		public double _003C_003E3__double_1;

		private float float_0;

		public float _003C_003E3__float_0;

		private double double_2;

		public double _003C_003E3__double_2;

		private double double_3;

		public double _003C_003E3__double_3;

		private float float_1;

		public float _003C_003E3__float_1;

		private Scenario scenario_0;

		public Scenario _003C_003E3__scenario_0;

		private Side side_0;

		public Side _003C_003E3__side_0;

		private double _003Cnum_003E5__1;

		private bool _003Cflag_003E5__2;

		private double _003Cnum2_003E5__3;

		private double _003Cnum3_003E5__4;

		private double _003Cnum4_003E5__5;

		private double _003Cnum5_003E5__6;

		private int _003Cnum6_003E5__7;

		private double _003Cnum7_003E5__8;

		private double _003Cnum8_003E5__9;

		private double _003Cnum9_003E5__10;

		private double _003Cnum10_003E5__11;

		private double _003Cnum11_003E5__12;

		private int _003Celevation_003E5__13;

		private (LandCoverType, int) _003Ctuple_003E5__14;

		Tuple<LandCoverType, int> IEnumerator<Tuple<LandCoverType, int>>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__10(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_029f;
			}
			_003C_003E1__state = -1;
			new List<Tuple<LandCoverType, int>>();
			if (attrDic.Count() <= 0)
			{
				return false;
			}
			_003Cnum_003E5__1 = Math.Abs(attrDic[0]._RequestDic);
			_003Cflag_003E5__2 = false;
			_003Cnum2_003E5__3 = double_0;
			_003Cnum3_003E5__4 = double_1;
			_003Cnum4_003E5__5 = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Deg(double_0, double_1, double_2, double_3);
			_003Cnum5_003E5__6 = float_1 - float_0;
			_003Cnum6_003E5__7 = SelectClass(scenario_0);
			goto IL_02b8;
			IL_02b8:
			while (true)
			{
				if (!_003Cflag_003E5__2)
				{
					_003Cnum7_003E5__8 = MathFunctions.LogoutRequest(_003Cnum2_003E5__3, _003Cnum3_003E5__4, double_2, double_3);
					_003Cnum8_003E5__9 = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Deg(double_0, double_1, _003Cnum2_003E5__3, _003Cnum3_003E5__4);
					if (_003Cnum8_003E5__9 + _003Cnum_003E5__1 < _003Cnum4_003E5__5)
					{
						break;
					}
					_003Cflag_003E5__2 = true;
					continue;
				}
				return false;
			}
			_003Cnum9_003E5__10 = _003Cnum3_003E5__4 + Math2.SetClass(_003Cnum7_003E5__8) * _003Cnum_003E5__1;
			_003Cnum10_003E5__11 = _003Cnum2_003E5__3 + Math2.CalculateClass(_003Cnum7_003E5__8) * _003Cnum_003E5__1;
			_003Cnum11_003E5__12 = (double)float_0 + (1.0 - _003Cnum8_003E5__9 / _003Cnum4_003E5__5) * _003Cnum5_003E5__6;
			if (_003Cnum11_003E5__12 <= (double)Terrain.GlobalMaxTerrainElevation)
			{
				_003Celevation_003E5__13 = Terrain.GetElevation(_003Cnum10_003E5__11, _003Cnum9_003E5__10, bool_0: false, scenario_0);
				if (_003Cnum11_003E5__12 <= (double)(_003Celevation_003E5__13 + _003Cnum6_003E5__7) && _003Celevation_003E5__13 >= 0)
				{
					_003Ctuple_003E5__14 = AddClass(_003Cnum10_003E5__11, _003Cnum9_003E5__10, scenario_0, (List<CustomEnvironmentZone>)(object)side_0);
					Geodesic_Haversine.Distance_Horiz_Angular_Approx_Deg(_003Cnum10_003E5__11, _003Cnum9_003E5__10, double_2, double_3);
					if (!((double)(_003Celevation_003E5__13 + _003Ctuple_003E5__14.Item2) <= _003Cnum11_003E5__12))
					{
						_003C_003E2__current = new Tuple<LandCoverType, int>(_003Ctuple_003E5__14.Item1, _003Ctuple_003E5__14.Item2);
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_029f;
			IL_029f:
			_003Cnum3_003E5__4 = _003Cnum9_003E5__10;
			_003Cnum2_003E5__3 = _003Cnum10_003E5__11;
			goto IL_02b8;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<Tuple<LandCoverType, int>> IEnumerable<Tuple<LandCoverType, int>>.GetEnumerator()
		{
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__10 _003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__ = this;
			}
			else
			{
				_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__ = new _003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__10(0);
			}
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.double_0 = _003C_003E3__double_0;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.double_1 = _003C_003E3__double_1;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.float_0 = _003C_003E3__float_0;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.double_2 = _003C_003E3__double_2;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.double_3 = _003C_003E3__double_3;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.float_1 = _003C_003E3__float_1;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.scenario_0 = _003C_003E3__scenario_0;
			_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__.side_0 = _003C_003E3__side_0;
			return _003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Tuple<LandCoverType, int>>)this).GetEnumerator();
		}
	}

	public static string LandCoverFilesPath;

	private static GeoTIFF_Tile[] attrDic;

	public static int MaxCultureHeight_BuiltIn;

	static LandCover()
	{
		MaxCultureHeight_BuiltIn = 45;
	}

	public static void TestLandCover(string string_0)
	{
		using Tiff val = Tiff.Open(string_0, "r");
		FieldValue fieldValue = val.GetField(TiffTag.IMAGELENGTH)[0];
		int num = fieldValue.ToInt();
		FieldValue[] field = val.GetField(TiffTag.GEOTIFF_MODELPIXELSCALETAG);
		FieldValue[] field2 = val.GetField(TiffTag.GEOTIFF_MODELTIEPOINTTAG);
		fieldValue = field[1];
		byte[] bytes = fieldValue.GetBytes();
		double num6 = BitConverter.ToDouble(bytes, 0);
		double num7 = BitConverter.ToDouble(bytes, 8) * -1.0;
		fieldValue = field2[1];
		byte[] bytes2 = fieldValue.GetBytes();
		double num8 = BitConverter.ToDouble(bytes2, 24);
		double num9 = BitConverter.ToDouble(bytes2, 32) + num7 / 2.0;
		double num10 = num8 + num6 / 2.0;
		byte[] array = new byte[val.ScanlineSize() - 1 + 1];
		double num11 = num9;
		double num12 = num10;
		int num13 = num - 1;
		for (int i = 0; i <= num13; i++)
		{
			val.ReadScanline(array, i);
			double num2 = num11 + num7 * (double)i;
			int num3 = array.Length - 1;
			for (int j = 0; j <= num3; j++)
			{
				double num4 = num12 + num6 * (double)j;
				int num5 = array[j];
				Console.WriteLine("Lat: " + Conversions.ToString(num2) + " - 经度：" + Conversions.ToString(num4) + " - Value: " + Conversions.ToString(num5));
			}
		}
	}

	public static void LoadGrids()
	{
		try
		{
			LandCoverFilesPath = Path.Combine(GameGeneral.GISFolderPath, "LandCover");
			string[] files = Directory.GetFiles(LandCoverFilesPath);
			attrDic = new GeoTIFF_Tile[files.Length - 1 + 1];
			Tiff.SetErrorHandler(new ClientIssuer());
			int num = files.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				GeoTIFF_Tile geoTIFF_Tile = new GeoTIFF_Tile(files[i]);
				geoTIFF_Tile.Initialize();
				attrDic[i] = geoTIFF_Tile;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10121342130593240909120902", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static (LandCoverType theTerrainType, int theLandCoverHeight) AddClass(double double_0, double double_1, Scenario scenario_0, List<CustomEnvironmentZone> list_0)
	{
		LandCoverType landCoverType = LandCoverType.Use_Underlying_Values;
		int num = int.MinValue;
		bool flag = false;
		if (list_0 != null)
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in ((Side)(object)list_0).CustomEnvironmentZones)
			{
				if (customEnvironmentZone.TerrainType != LandCoverType.Use_Underlying_Values && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
				{
					landCoverType = customEnvironmentZone.TerrainType;
					flag = true;
				}
				if (customEnvironmentZone.HasCustomTerrainHeight && flag)
				{
					num = customEnvironmentZone.TerrainHeight;
				}
			}
		}
		if (landCoverType != LandCoverType.Use_Underlying_Values && num > int.MinValue)
		{
			return (theTerrainType: landCoverType, theLandCoverHeight: num);
		}
		LandCoverType landCoverType2 = DestroyClass(double_0, double_1, scenario_0);
		if (landCoverType != LandCoverType.Use_Underlying_Values)
		{
			landCoverType2 = landCoverType;
		}
		if (num == int.MinValue)
		{
			num = CallClass(landCoverType2);
		}
		return (theTerrainType: landCoverType2, theLandCoverHeight: num);
	}

	internal static LandCoverType DestroyClass(double double_0, double double_1, Scenario scenario_0)
	{
		if (scenario_0.NatureSideExists())
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in scenario_0.GetNatureSide().CustomEnvironmentZones)
			{
				if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
				{
					return customEnvironmentZone.TerrainType;
				}
			}
		}
		GeoTIFF_Tile geoTIFF_Tile = ComputeClass(double_0, double_1);
		if (geoTIFF_Tile == null)
		{
			return LandCoverType.Water;
		}
		return (LandCoverType)geoTIFF_Tile.ReadValue(double_1, double_0);
	}

	private static GeoTIFF_Tile ComputeClass(double double_0, double double_1)
	{
		GeoTIFF_Tile[] array = attrDic;
		GeoTIFF_Tile[] array2 = array;
		foreach (GeoTIFF_Tile geoTIFF_Tile in array2)
		{
			if (geoTIFF_Tile.tokenizerDic >= double_0 && geoTIFF_Tile._ValueDic <= double_1 && Math.Ceiling(double_1) <= Math.Ceiling(geoTIFF_Tile.RightEdgeLongitude) && Math.Ceiling(double_0) >= Math.Ceiling(geoTIFF_Tile.BottomEdgeLatitude))
			{
				return geoTIFF_Tile;
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__10))]
	public static IEnumerable<Tuple<LandCoverType, int>> GetAllLandCoverAndCoverElevationBetweenPoints(double double_0, double double_1, float float_0, double double_2, double double_3, float float_1, Scenario scenario_0, Side side_0)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetAllLandCoverAndCoverElevationBetweenPoints_003Ed__10(-2)
		{
			_003C_003E3__double_0 = double_0,
			_003C_003E3__double_1 = double_1,
			_003C_003E3__float_0 = float_0,
			_003C_003E3__double_2 = double_2,
			_003C_003E3__double_3 = double_3,
			_003C_003E3__float_1 = float_1,
			_003C_003E3__scenario_0 = scenario_0,
			_003C_003E3__side_0 = side_0
		};
	}

	internal static Color PatchClass(LandCoverType landCoverType_0)
	{
		if (1 == 0)
		{
		}
		Color result = landCoverType_0 switch
		{
			LandCoverType.Urban_CloseInnerCity => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_SpacedHighRise => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_AttachedHouses => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_CloseIndustrial => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_SpacedApartments => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_DetachedHouses => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_SpacedIndustrial => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_ShantyTown => Color.FromArgb(204, 2, 2), 
			LandCoverType.Water => Color.FromArgb(174, 195, 214), 
			LandCoverType.Evergreen_Needleleaf_forest => Color.FromArgb(22, 33, 3), 
			LandCoverType.Evergreen_Broadleaf_forest => Color.FromArgb(35, 81, 35), 
			LandCoverType.Deciduous_Needleleaf_forest => Color.FromArgb(57, 155, 56), 
			LandCoverType.Deciduous_Broadleaf_forest => Color.FromArgb(56, 235, 56), 
			LandCoverType.Mixed_forest => Color.FromArgb(57, 114, 59), 
			LandCoverType.Closed_shrublands => Color.FromArgb(106, 36, 36), 
			LandCoverType.Open_shrublands => Color.FromArgb(195, 165, 95), 
			LandCoverType.Woody_savannas => Color.FromArgb(183, 97, 36), 
			LandCoverType.Savannas => Color.FromArgb(217, 145, 37), 
			LandCoverType.Grasslands => Color.FromArgb(146, 175, 31), 
			LandCoverType.Permanent_wetlands => Color.FromArgb(16, 16, 76), 
			LandCoverType.Croplands => Color.FromArgb(205, 180, 0), 
			LandCoverType.UrbanAndBuiltUp => Color.FromArgb(204, 2, 2), 
			LandCoverType.CroplandNaturalVegetationMosaic => Color.FromArgb(51, 40, 8), 
			LandCoverType.SnowAndIce => Color.FromArgb(215, 205, 204), 
			LandCoverType.BarrenOrSparselyVegetated => Color.FromArgb(247, 225, 116), 
			_ => Color.FromArgb(255, 0, 255), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static int SelectClass(Scenario scenario_0)
	{
		int num = MaxCultureHeight_BuiltIn;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i++)
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in sides_ReadOnly[i].CustomEnvironmentZones)
			{
				num = Math.Max(num, customEnvironmentZone.TerrainHeight);
			}
		}
		return num;
	}

	internal static int CallClass(LandCoverType landCoverType_0)
	{
		if (1 == 0)
		{
		}
		int result = landCoverType_0 switch
		{
			LandCoverType.Urban_CloseInnerCity => 30, 
			LandCoverType.Urban_SpacedHighRise => 45, 
			LandCoverType.Urban_AttachedHouses => 6, 
			LandCoverType.Urban_CloseIndustrial => 9, 
			LandCoverType.Urban_SpacedApartments => 20, 
			LandCoverType.Urban_DetachedHouses => 6, 
			LandCoverType.Urban_SpacedIndustrial => 9, 
			LandCoverType.Urban_ShantyTown => 4, 
			LandCoverType.Water => 0, 
			LandCoverType.Evergreen_Needleleaf_forest => 5, 
			LandCoverType.Evergreen_Broadleaf_forest => 5, 
			LandCoverType.Deciduous_Needleleaf_forest => 5, 
			LandCoverType.Deciduous_Broadleaf_forest => 5, 
			LandCoverType.Mixed_forest => 5, 
			LandCoverType.Closed_shrublands => 1, 
			LandCoverType.Open_shrublands => 1, 
			LandCoverType.Woody_savannas => 5, 
			LandCoverType.Savannas => 1, 
			LandCoverType.Grasslands => 1, 
			LandCoverType.Permanent_wetlands => 1, 
			LandCoverType.Croplands => 1, 
			LandCoverType.UrbanAndBuiltUp => 9, 
			LandCoverType.CroplandNaturalVegetationMosaic => 1, 
			LandCoverType.SnowAndIce => 1, 
			LandCoverType.BarrenOrSparselyVegetated => 1, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string LogoutClass(LandCoverType landCoverType_0)
	{
		string text = ViewClass(landCoverType_0);
		if (text.Length > 0)
		{
			text = "地表：" + text;
		}
		return text + " ";
	}

	internal static string ViewClass(LandCoverType landCoverType_0)
	{
		string result = "";
		switch (landCoverType_0)
		{
		case LandCoverType.Urban_CloseInnerCity:
			result = "Attached and Closely Spaced Inner City Buildings";
			break;
		case LandCoverType.Urban_SpacedHighRise:
			result = "Widely Spaced High-rise Office Buildings";
			break;
		case LandCoverType.Urban_AttachedHouses:
			result = "Attached Houses";
			break;
		case LandCoverType.Urban_CloseIndustrial:
			result = "Closely Spaced Industrial / Storage Buildings";
			break;
		case LandCoverType.Urban_SpacedApartments:
			result = "Widely Spaced Apartment Buildings";
			break;
		case LandCoverType.Urban_DetachedHouses:
			result = "Detached Houses";
			break;
		case LandCoverType.Urban_SpacedIndustrial:
			result = "Widely Spaced Industrial / Storage Buildings";
			break;
		case LandCoverType.Urban_ShantyTown:
			result = "Shanty Town";
			break;
		case LandCoverType.Water:
			result = "Water";
			break;
		case LandCoverType.Evergreen_Needleleaf_forest:
			result = "Evergreen Needleleaf Forest";
			break;
		case LandCoverType.Evergreen_Broadleaf_forest:
			result = "Evergreen Broadleaf Forest";
			break;
		case LandCoverType.Deciduous_Needleleaf_forest:
			result = "Deciduous Needleleaf Forest";
			break;
		case LandCoverType.Deciduous_Broadleaf_forest:
			result = "Deciduous Broadleaf Forest";
			break;
		case LandCoverType.Mixed_forest:
			result = "Mixed Forest";
			break;
		case LandCoverType.Closed_shrublands:
			result = "Closed Shrublands";
			break;
		case LandCoverType.Open_shrublands:
			result = "Open Shrublands";
			break;
		case LandCoverType.Woody_savannas:
			result = "Woody Savannas";
			break;
		case LandCoverType.Savannas:
			result = "Savannas";
			break;
		case LandCoverType.Grasslands:
			result = "Grasslands";
			break;
		case LandCoverType.Permanent_wetlands:
			result = "Permanent Wetlands";
			break;
		case LandCoverType.Croplands:
			result = "Croplands";
			break;
		case LandCoverType.UrbanAndBuiltUp:
			result = "Urban / Built Up";
			break;
		case LandCoverType.CroplandNaturalVegetationMosaic:
			result = "Cropland / Natural Vegetation Mosaic";
			break;
		case LandCoverType.SnowAndIce:
			result = "Snow / Ice";
			break;
		case LandCoverType.BarrenOrSparselyVegetated:
			result = "Barren / Sparsely Vegetated";
			break;
		}
		return result;
	}
}
