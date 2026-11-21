using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Catfood.Shapefile;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using OpenDis.Pages;

namespace Command_Core;

[StandardModule]
public sealed class SeaIceProvider
{
	public enum PolarRegion : byte
	{
		Arctic,
		Antarctic
	}

	private sealed class BroadcasterConfigObject
	{
		private int _MethodItem;

		private int _ServiceItem;

		private ConcurrentDictionary<string, bool> _SystemItem;

		public BroadcasterConfigObject()
		{
			_ServiceItem = 10000000;
			_SystemItem = new ConcurrentDictionary<string, bool>();
		}

		public bool? TestInterruptibleReg(string string_0)
		{
			if (!_SystemItem.TryGetValue(string_0, out var value))
			{
				return null;
			}
			return value;
		}

		public void StopInterruptibleReg(string string_0, bool bool_0)
		{
			if (_MethodItem >= _ServiceItem)
			{
				_SystemItem = new ConcurrentDictionary<string, bool>();
				_MethodItem = 0;
			}
			if (_SystemItem.TryAdd(string_0, bool_0))
			{
				_MethodItem++;
			}
		}
	}

	[CompilerGenerated]
	private sealed class ConsumerParameterMessage
	{
		public double double_1;

		public double double_0;

		public double double_3;

		public double double_2;

		public bool flag;

		internal void CancelInterruptibleReg(IcePack thePack, ParallelLoopState loopstate)
		{
			if (Math2.LineIntersectsArea_Clipper(double_1, double_0, double_3, double_2, thePack.Area, bool_0: false))
			{
				flag = true;
				loopstate.Stop();
			}
		}
	}

	private static BroadcasterConfigObject _ObserverFacade;

	public static DateTime EarliestDataDate;

	private static List<IcePack> issuerFacade;

	private static double? _ClientFacade;

	private static double? _DicFacade;

	private static object _ConsumerFacade;

	private static string _FacadeFacade;

	public static List<IcePack> CurrentIcePacks
	{
		get
		{
			if (Information.IsNothing(issuerFacade))
			{
				issuerFacade = RestartWriter(DateTime.Now);
			}
			return issuerFacade;
		}
	}

	static SeaIceProvider()
	{
		_ObserverFacade = new BroadcasterConfigObject();
		EarliestDataDate = new DateTime(1995, 1, 1);
		_ConsumerFacade = RuntimeHelpers.GetObjectValue(new object());
		_FacadeFacade = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"dBase IV\"";
	}

	public static void Initialize()
	{
		string[] directories = Directory.GetDirectories(Path.Combine(GameGeneral.GISFolderPath, "SeaIce\\Arctic\\"));
		string[] array = directories;
		foreach (string directory in array)
		{
			MerchantMerchantPage.SelectList.FileSystem.DeleteDirectory(directory, DeleteDirectoryOption.DeleteAllContents);
		}
		GetShapefilename(DateTime.Now);
		issuerFacade = RestartWriter(DateTime.Now);
	}

	internal static int InsertWriter(double double_0)
	{
		if (Math.Ceiling(double_0) - double_0 <= 0.5)
		{
			return (int)Math.Ceiling(double_0);
		}
		return RadarModel.PrintStub(double_0);
	}

	internal static bool PrepareWriter(double double_0, double double_1)
	{
		bool result = false;
		try
		{
			if (double_1 <= 0.0)
			{
				result = false;
				return false;
			}
			double num = double_1;
			double? clientFacade = _ClientFacade;
			if ((clientFacade.HasValue ? new bool?(num > clientFacade.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				result = true;
				return true;
			}
			num = double_1;
			clientFacade = _DicFacade;
			if ((clientFacade.HasValue ? new bool?(num < clientFacade.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				result = false;
				return false;
			}
			double_0 = Math2.VisitClass(double_0);
			double_1 = Math2.ReflectClass(double_1);
			string uniqueKey = Terrain.SetupWatcher(double_1, double_0).UniqueKey;
			bool? flag = _ObserverFacade.TestInterruptibleReg(uniqueKey);
			if (flag.HasValue)
			{
				return result = flag.Value;
			}
			bool bool_;
			flag = (bool_ = VisitWriter(double_1, double_0));
			_ObserverFacade.StopInterruptibleReg(uniqueKey, bool_);
			return result = flag.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101100", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static bool ReflectWriter(double double_0, double double_1, double double_2, double double_3)
	{
		bool flag = false;
		bool result = false;
		try
		{
			Parallel.ForEach(CurrentIcePacks, delegate(IcePack thePack, ParallelLoopState loopstate)
			{
				if (Math2.LineIntersectsArea_Clipper(double_1, double_0, double_3, double_2, thePack.Area, bool_0: false))
				{
					flag = true;
					loopstate.Stop();
				}
			});
			return result = flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101101", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static bool VisitWriter(double double_0, double double_1)
	{
		bool result = false;
		try
		{
			new GeoPoint(double_1, double_0);
			if (double_0 <= 0.0)
			{
				result = false;
				return false;
			}
			double num = double_0;
			double? clientFacade = _ClientFacade;
			if ((clientFacade.HasValue ? new bool?(num > clientFacade.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				result = true;
				return true;
			}
			num = double_0;
			clientFacade = _DicFacade;
			if ((clientFacade.HasValue ? new bool?(num < clientFacade.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				result = false;
				return false;
			}
			bool flag = false;
			foreach (IcePack currentIcePack in CurrentIcePacks)
			{
				if (currentIcePack.GetPointIsInArea(double_0, double_1, bool_0: false))
				{
					flag = true;
					break;
				}
			}
			return result = flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101102", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static string GetShapefilename(DateTime dateTime_0)
	{
		return Path.Combine(GameGeneral.GISFolderPath, "SeaIce\\Arctic\\nic_autoc2012270n_pl_a.shp");
	}

	private static List<IcePack> RestartWriter(DateTime dateTime_0)
	{
		List<IcePack> list = new List<IcePack>();
		HashSet<double> hashSet = new HashSet<double>();
		Shapefile shapefile;
		try
		{
			shapefile = new Shapefile(GetShapefilename(DateTime.Now), _FacadeFacade);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_FacadeFacade = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"dBase IV\"";
			shapefile = new Shapefile(GetShapefilename(DateTime.Now), _FacadeFacade);
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (Shape item2 in shapefile)
			{
				if (item2.Type != ShapeType.Polygon)
				{
					continue;
				}
				foreach (PointD[] part in ((ShapePolygon)item2).Parts)
				{
					if (part.Count() <= 30)
					{
						continue;
					}
					List<Geopoint_Struct> list2 = new List<Geopoint_Struct>();
					int num = 0;
					if (part.Count() > 500)
					{
						num = 2;
					}
					int num2 = 0;
					PointD[] array = part;
					for (int i = 0; i < array.Length; i = checked(i + 1))
					{
						PointD pointD = array[i];
						num2++;
						double y = pointD.Y;
						hashSet.Add(y);
						if (num == 0 || (num > 0 && num2 == num))
						{
							num2 = 0;
							list2.Add(new Geopoint_Struct(pointD.X, y));
						}
					}
					IcePack item = new IcePack(list2);
					list.Add(item);
				}
			}
			_ClientFacade = hashSet.Max();
			_DicFacade = hashSet.Min();
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101103", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<IcePack> result = new List<IcePack>();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
