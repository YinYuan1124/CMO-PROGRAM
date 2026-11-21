using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using OpenDis.Pages;

namespace Command_Core;

public sealed class BinaryGridProvider : ITerrainProvider
{
	private int _ProccesorObserver;

	private float strategyObserver;

	private float _ConfigurationObserver;

	internal static string _TokenObserver;

	private Terrain.MaxMinRecord[][] indexerObserver;

	private Dictionary<int, Dictionary<int, float>> _ResolverObserver;

	private bool publisherObserver;

	public string TerrainFilesPath
	{
		get
		{
			return _TokenObserver;
		}
		set
		{
			_TokenObserver = value;
		}
	}

	public BinaryGridProvider()
	{
		_ProccesorObserver = 100;
		strategyObserver = 0.5f;
		_ConfigurationObserver = 1f / 120f;
		indexerObserver = new Terrain.MaxMinRecord[360][];
		publisherObserver = false;
	}

	internal bool PushProperty()
	{
		try
		{
			_TokenObserver = GameGeneral.GISFolderPath + "\\Terrain\\SRTM30Plus\\";
			InvokeProperty();
			InterruptProperty();
			return true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return true;
		}
	}

	bool ITerrainProvider.Initialize()
	{
		return PushProperty();
	}

	private void InvokeProperty()
	{
		try
		{
			string[] directories = Directory.GetDirectories(TerrainFilesPath);
			string[] array = directories;
			foreach (string directory in array)
			{
				MerchantMerchantPage.SelectList.FileSystem.DeleteDirectory(directory, DeleteDirectoryOption.DeleteAllContents);
			}
			Terrain.TerrainGrids.Clear();
			int num = 0;
			directories = Directory.GetFiles(TerrainFilesPath);
			string[] array2 = directories;
			foreach (string text in array2)
			{
				if (text.EndsWith(".bgd"))
				{
					num++;
					BinGridModule.TBinGrid tBinGrid = new BinGridModule.TBinGrid(Path.GetFileName(text));
					tBinGrid.ManageInterruptibleTag(text);
					List<BinGridModule.TBinGrid> list = new List<BinGridModule.TBinGrid>();
					list.Add(tBinGrid);
					if (!Terrain.TerrainGrids.ContainsKey(Path.GetFileName(text)))
					{
						Terrain.TerrainGrids.Add(Path.GetFileName(text), list);
					}
				}
			}
			Terrain.TerrainHasLoaded = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101105", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisposeResources()
	{
		SetupProperty();
	}

	private void SetupProperty()
	{
		try
		{
			foreach (List<BinGridModule.TBinGrid> value in Terrain.TerrainGrids.Values)
			{
				foreach (BinGridModule.TBinGrid item in value)
				{
					if (!Information.IsNothing(item))
					{
						item.CloseTile();
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200271", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string GetTerrainTileFileName(ref double double_0, ref double double_1)
	{
		double_0 = Math2.ReflectClass(double_0);
		double_1 = Math2.VisitClass(double_1);
		double num = double_0;
		if (num <= 40.0)
		{
			if (num <= -10.0)
			{
				if (num <= -60.0)
				{
					double num2 = double_1;
					if (num2 <= 120.0)
					{
						if (num2 <= 60.0)
						{
							if (num2 <= 0.0)
							{
								if (num2 <= -60.0)
								{
									if (num2 <= -120.0)
									{
										return "w180s60.bgd";
									}
									return "w120s60.bgd";
								}
								return "w60s60.bgd";
							}
							return "w0s60.bgd";
						}
						return "e60s60.bgd";
					}
					return "e120s60.bgd";
				}
				double num3 = double_1;
				if (num3 <= 140.0)
				{
					if (num3 <= 100.0)
					{
						if (num3 <= 60.0)
						{
							if (num3 <= 20.0)
							{
								if (num3 <= -20.0)
								{
									if (num3 <= -60.0)
									{
										if (num3 <= -100.0)
										{
											if (num3 <= -140.0)
											{
												return "w180s10.bgd";
											}
											return "w140s10.bgd";
										}
										return "w100s10.bgd";
									}
									return "w60s10.bgd";
								}
								return "w20s10.bgd";
							}
							return "e20s10.bgd";
						}
						return "e60s10.bgd";
					}
					return "e100s10.bgd";
				}
				return "e140s10.bgd";
			}
			double num4 = double_1;
			if (num4 <= 140.0)
			{
				if (num4 <= 100.0)
				{
					if (num4 <= 60.0)
					{
						if (num4 <= 20.0)
						{
							if (num4 <= -20.0)
							{
								if (num4 <= -60.0)
								{
									if (num4 <= -100.0)
									{
										if (num4 <= -140.0)
										{
											return "w180n40.bgd";
										}
										return "w140n40.bgd";
									}
									return "w100n40.bgd";
								}
								return "w60n40.bgd";
							}
							return "w20n40.bgd";
						}
						return "e20n40.bgd";
					}
					return "e60n40.bgd";
				}
				return "e100n40.bgd";
			}
			return "e140n40.bgd";
		}
		double num5 = double_1;
		if (num5 <= 140.0)
		{
			if (num5 <= 100.0)
			{
				if (num5 <= 60.0)
				{
					if (num5 <= 20.0)
					{
						if (num5 <= -20.0)
						{
							if (num5 <= -60.0)
							{
								if (num5 <= -100.0)
								{
									if (num5 <= -140.0)
									{
										return "w180n90.bgd";
									}
									return "w140n90.bgd";
								}
								return "w100n90.bgd";
							}
							return "w60n90.bgd";
						}
						return "w20n90.bgd";
					}
					return "e20n90.bgd";
				}
				return "e60n90.bgd";
			}
			return "e100n90.bgd";
		}
		return "e140n90.bgd";
	}

	private BinGridModule.TBinGrid ExcludeProperty(double double_0, double double_1)
	{
		double_0 = Math2.ReflectClass(double_0);
		double_1 = Math2.VisitClass(double_1);
		string terrainTileFileName = GetTerrainTileFileName(ref double_0, ref double_1);
		List<BinGridModule.TBinGrid> list = Terrain.TerrainGrids[terrainTileFileName];
		if (list.Count == 0)
		{
			return null;
		}
		int count = list.Count;
		BinGridModule.TBinGrid tBinGrid = null;
		if (count > 0)
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				BinGridModule.TBinGrid tBinGrid2 = list[i];
				if (tBinGrid2 != null && !tBinGrid2.ReadingInProgress)
				{
					tBinGrid = tBinGrid2;
					break;
				}
			}
		}
		if (tBinGrid == null)
		{
			BinGridModule.TBinGrid tBinGrid3 = new BinGridModule.TBinGrid(TerrainFilesPath + "\\" + terrainTileFileName);
			tBinGrid3.ManageInterruptibleTag(TerrainFilesPath + "\\" + terrainTileFileName);
			tBinGrid3.poolComparator = list[0].poolComparator;
			if (list.Count < _ProccesorObserver)
			{
				list.Add(tBinGrid3);
			}
			tBinGrid = tBinGrid3;
		}
		return tBinGrid;
	}

	internal short IncludeProperty(double double_0, double double_1, bool bool_0)
	{
		try
		{
			return ExcludeProperty(double_0, double_1)?.ForgotInterruptibleTag(double_1, double_0, bool_0) ?? 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200092", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	short ITerrainProvider.GetElevation(double double_0, double double_1, bool bool_0)
	{
		return IncludeProperty(double_0, double_1, bool_0);
	}

	private bool SearchProperty(double double_0, double double_1, double double_2, double double_3)
	{
		bool result = false;
		try
		{
			string terrainTileFileName = GetTerrainTileFileName(ref double_0, ref double_1);
			string terrainTileFileName2 = GetTerrainTileFileName(ref double_2, ref double_3);
			if (Operators.CompareString(terrainTileFileName, terrainTileFileName2, TextCompare: false) == 0)
			{
				var (num, num2) = Terrain.TerrainGrids[terrainTileFileName][0].StartInterruptibleTag(ref double_1, ref double_0);
				var (num3, num4) = Terrain.TerrainGrids[terrainTileFileName2][0].StartInterruptibleTag(ref double_3, ref double_2);
				if (num == num3 && num2 == num4)
				{
					result = true;
					return true;
				}
				if (Math.Abs(num - num3) < 2 && Math.Abs(num2 - num4) < 2)
				{
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100227", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	bool ITerrainProvider.GeopointsAreOnSameOrAdjacentCell(double double_0, double double_1, double double_2, double double_3)
	{
		return SearchProperty(double_0, double_1, double_2, double_3);
	}

	internal Terrain.TerrainRasterCell[] EnableProperty(double double_0, double double_1, float float_0, bool bool_0)
	{
		Dictionary<string, Terrain.TerrainRasterCell> dictionary = new Dictionary<string, Terrain.TerrainRasterCell>();
		double_0 = Math2.ReflectClass(double_0);
		double_1 = Math2.VisitClass(double_1);
		double double_4 = 0.0;
		double double_5 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_4, ref double_5, (float)((double)float_0 * 1.414), 225);
		double double_6 = 0.0;
		double double_7 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_6, ref double_7, (float)((double)float_0 * 1.414), 315);
		double double_8 = 0.0;
		double double_9 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_8, ref double_9, (float)((double)float_0 * 1.414), 45);
		double double_10 = 0.0;
		double double_11 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_10, ref double_11, (float)((double)float_0 * 1.414), 135);
		Angle angle_ = default(Angle);
		angle_.Degrees = double_4;
		Angle angle_6 = default(Angle);
		angle_6.Degrees = double_5;
		Angle angle_7 = default(Angle);
		angle_7.Degrees = double_6;
		Angle angle_8 = default(Angle);
		angle_8.Degrees = double_7;
		Angle angle_9 = default(Angle);
		angle_9.Degrees = double_9;
		Angle angle_10 = default(Angle);
		angle_10.Degrees = double_8;
		Angle angle_11 = default(Angle);
		angle_11.Degrees = double_10;
		Angle angle_12 = default(Angle);
		angle_12.Degrees = double_11;
		Angle angle_13 = World.ApproxAngularDistance(angle_6, angle_, angle_8, angle_7);
		float num = 0f;
		float num2 = 0f;
		StringBuilder stringBuilder = new StringBuilder();
		for (; (double)num < angle_13.Degrees; num += _ConfigurationObserver)
		{
			Angle angle_2 = default(Angle);
			Angle angle_3 = default(Angle);
			Angle angle_4 = default(Angle);
			Angle angle_5 = default(Angle);
			World.smethod_0((float)((double)num / angle_13.Degrees), angle_6, angle_, angle_8, angle_7, angle_13, out angle_2, out angle_3);
			World.smethod_0((float)((double)num / angle_13.Degrees), angle_12, angle_11, angle_9, angle_10, angle_13, out angle_4, out angle_5);
			for (Angle angle = World.ApproxAngularDistance(angle_2, angle_3, angle_4, angle_5); (double)num2 < angle.Degrees; num2 += _ConfigurationObserver)
			{
				double double_2 = Math2.ReflectClass(double_5 + (double)num);
				double double_3 = Math2.VisitClass(double_4 + (double)num2);
				string terrainTileFileName = GetTerrainTileFileName(ref double_2, ref double_3);
				BinGridModule.TBinGrid tBinGrid = Terrain.TerrainGrids[terrainTileFileName][0];
				try
				{
					var (value, value2) = tBinGrid.StartInterruptibleTag(ref double_3, ref double_2);
					stringBuilder.Clear();
					stringBuilder.Append(terrainTileFileName);
					stringBuilder.Append("_");
					stringBuilder.Append(value);
					stringBuilder.Append("_");
					stringBuilder.Append(value2);
					string key = stringBuilder.ToString();
					if (!dictionary.ContainsKey(key))
					{
						Terrain.TerrainRasterCell value3 = default(Terrain.TerrainRasterCell);
						if (bool_0)
						{
							value3.ElevationValue = tBinGrid.ForgotInterruptibleTag(double_3, double_2, bool_0: false);
						}
						value3.Height_degrees = _ConfigurationObserver;
						value3.Width_degrees = _ConfigurationObserver;
						dictionary.Add(key, value3);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101107", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		return dictionary.Values.ToArray();
	}

	Terrain.TerrainRasterCell[] ITerrainProvider.GetAllCellsInThisRadius(double double_0, double double_1, float float_0, bool bool_0)
	{
		return EnableProperty(double_0, double_1, float_0, bool_0);
	}

	internal Terrain.TerrainRasterCell ChangeProperty(double double_0, double double_1)
	{
		return ExcludeProperty(double_0, double_1).FlushInterruptibleTag(double_0, double_1);
	}

	Terrain.TerrainRasterCell ITerrainProvider.GetSingleRasterCell(double double_0, double double_1)
	{
		return ChangeProperty(double_0, double_1);
	}

	private float InitProperty(double double_0, double double_1, float float_0)
	{
		HashSet<string> hashSet = new HashSet<string>();
		double_0 = Math2.ReflectClass(double_0);
		double_1 = Math2.VisitClass(double_1);
		double double_4 = 0.0;
		double double_5 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_4, ref double_5, (float)((double)float_0 * 1.414), 225);
		double double_6 = 0.0;
		double double_7 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_6, ref double_7, (float)((double)float_0 * 1.414), 315);
		double double_8 = 0.0;
		double double_9 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_8, ref double_9, (float)((double)float_0 * 1.414), 45);
		double double_10 = 0.0;
		double double_11 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_10, ref double_11, (float)((double)float_0 * 1.414), 135);
		Angle angle_ = default(Angle);
		angle_.Degrees = double_4;
		Angle angle_6 = default(Angle);
		angle_6.Degrees = double_5;
		Angle angle_7 = default(Angle);
		angle_7.Degrees = double_6;
		Angle angle_8 = default(Angle);
		angle_8.Degrees = double_7;
		Angle angle_9 = default(Angle);
		angle_9.Degrees = double_9;
		Angle angle_10 = default(Angle);
		angle_10.Degrees = double_8;
		Angle angle_11 = default(Angle);
		angle_11.Degrees = double_10;
		Angle angle_12 = default(Angle);
		angle_12.Degrees = double_11;
		Angle angle_13 = World.ApproxAngularDistance(angle_6, angle_, angle_8, angle_7);
		float num = 0f;
		float num2 = 0f;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		int num3 = 0;
		int num4 = 0;
		for (; (double)num < angle_13.Degrees; num += _ConfigurationObserver)
		{
			Angle angle_2 = default(Angle);
			Angle angle_3 = default(Angle);
			Angle angle_4 = default(Angle);
			Angle angle_5 = default(Angle);
			World.smethod_0((float)((double)num / angle_13.Degrees), angle_6, angle_, angle_8, angle_7, angle_13, out angle_2, out angle_3);
			World.smethod_0((float)((double)num / angle_13.Degrees), angle_12, angle_11, angle_9, angle_10, angle_13, out angle_4, out angle_5);
			for (Angle angle = World.ApproxAngularDistance(angle_2, angle_3, angle_4, angle_5); (double)num2 < angle.Degrees; num2 += _ConfigurationObserver)
			{
				double double_2 = Math2.ReflectClass(double_5 + (double)num);
				double double_3 = Math2.VisitClass(double_4 + (double)num2);
				string terrainTileFileName = GetTerrainTileFileName(ref double_2, ref double_3);
				BinGridModule.TBinGrid tBinGrid = Terrain.TerrainGrids[terrainTileFileName][0];
				try
				{
					var (value, value2) = tBinGrid.StartInterruptibleTag(ref double_1, ref double_0);
					stringBuilder.Clear();
					stringBuilder.Append(terrainTileFileName);
					stringBuilder.Append("_");
					stringBuilder.Append(value);
					stringBuilder.Append("_");
					stringBuilder.Append(value2);
					string item = stringBuilder.ToString();
					if (!hashSet.Contains(item))
					{
						hashSet.Add(item);
						num3++;
						if (SetProperty(double_2, double_3).IsOverland)
						{
							num4++;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101107", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		return (float)((double)num4 / (double)num3);
	}

	float ITerrainProvider.LandPercentageInThisSquare(double double_0, double double_1, float float_0)
	{
		return InitProperty(double_0, double_1, float_0);
	}

	private Terrain.MaxMinRecord CheckProperty(Terrain.MaxMinRecord[][] maxMinRecord_0, int int_0, int int_1)
	{
		try
		{
			if (maxMinRecord_0[int_0] == null)
			{
				return default(Terrain.MaxMinRecord);
			}
			Terrain.MaxMinRecord[] array = maxMinRecord_0[int_0];
			if (array == null)
			{
				return default(Terrain.MaxMinRecord);
			}
			return array[int_1];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 32409583296482094213398", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return default(Terrain.MaxMinRecord);
		}
	}

	private void ConcatProperty(Terrain.MaxMinRecord[][] maxMinRecord_0, int int_0, int int_1, Terrain.MaxMinRecord maxMinRecord_1)
	{
		try
		{
			if (maxMinRecord_0[int_0] == null)
			{
				Terrain.MaxMinRecord[] array = new Terrain.MaxMinRecord[180];
				array[int_1] = maxMinRecord_1;
				maxMinRecord_0[int_0] = array;
			}
			else
			{
				maxMinRecord_0[int_0][int_1] = maxMinRecord_1;
			}
		}
		catch (OutOfMemoryException projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 20324958729856749764398764397", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InterruptProperty()
	{
		Terrain.MaxMinRecord maxMinRecord = default(Terrain.MaxMinRecord);
		IEnumerator enumerator = null;
		IEnumerator enumerator2 = null;
		int num = 0;
		int num2 = 0;
		foreach (List<BinGridModule.TBinGrid> value in Terrain.TerrainGrids.Values)
		{
			BinGridModule.TBinGrid tBinGrid = value[0];
			FileStream fileStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Terrain\\SRTM30Plus\\" + tBinGrid.Filename + "_MaxMin"), FileMode.Open, FileAccess.Read);
			XmlDocument xmlDocument = new XmlDocument();
			using (fileStream)
			{
				xmlDocument.Load(fileStream);
			}
			XmlNode xmlNode = xmlDocument.ChildNodes[1];
			try
			{
				enumerator = xmlNode.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator.Current;
					maxMinRecord = default(Terrain.MaxMinRecord);
					try
					{
						enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							XmlNode xmlNode3 = (XmlNode)enumerator2.Current;
							switch (xmlNode3.Name)
							{
							case "Min":
								maxMinRecord.Min = Conversions.ToShort(xmlNode3.InnerText);
								break;
							case "Max":
								maxMinRecord.Max = Conversions.ToShort(xmlNode3.InnerText);
								break;
							case "Lon_Lat":
								num = Conversions.ToInteger(xmlNode3.InnerText.Split('_')[0]);
								num2 = Conversions.ToInteger(xmlNode3.InnerText.Split('_')[1]);
								num2 += 90;
								num += 180;
								break;
							}
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					ConcatProperty(indexerObserver, num, num2, maxMinRecord);
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
		publisherObserver = true;
	}

	private short RemoveProperty(double double_0, double double_1)
	{
		while (!publisherObserver)
		{
			Thread.Sleep(50);
		}
		try
		{
			double_0 = Math2.ReflectClass(double_0);
			double_1 = Math2.VisitClass(double_1);
			int num = (int)Math.Floor(double_1);
			int num2 = (int)Math.Floor(double_0);
			num2 += 90;
			num += 180;
			return CheckProperty(indexerObserver, num, num2).Max;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	short ITerrainProvider.GetMaxForThisDegCell(double double_0, double double_1)
	{
		return RemoveProperty(double_0, double_1);
	}

	private short FindProperty(double double_0, double double_1)
	{
		while (!publisherObserver)
		{
			Thread.Sleep(50);
		}
		double_0 = Math2.ReflectClass(double_0);
		double_1 = Math2.VisitClass(double_1);
		int num = (int)Math.Floor(double_1);
		int num2 = (int)Math.Floor(double_0);
		num2 += 90;
		num += 180;
		return CheckProperty(indexerObserver, num, num2).Min;
	}

	short ITerrainProvider.GetMinForThisDegCell(double double_0, double double_1)
	{
		return FindProperty(double_0, double_1);
	}

	internal (bool IsOverland, short? RetrievedElevation) SetProperty(double double_0, double double_1)
	{
		double_0 = Math2.ReflectClass(double_0);
		double_1 = Math2.VisitClass(double_1);
		(bool, short?) result;
		if (RemoveProperty(double_0, double_1) < 0)
		{
			result = (false, null);
		}
		else if (FindProperty(double_0, double_1) < 0)
		{
			short num = IncludeProperty(double_0, double_1, bool_0: false);
			result = (num >= 0, num);
		}
		else
		{
			result = (true, null);
		}
		return result;
	}

	(bool IsOverland, short? RetrievedElevation) ITerrainProvider.PointIsOverland(double double_0, double double_1)
	{
		return SetProperty(double_0, double_1);
	}
}
