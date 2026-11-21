using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Filters;

[StandardModule]
internal sealed class StrategyRegistryFilter
{
	[CompilerGenerated]
	private sealed class ExpressionConfigManager
	{
		public HashSet<string> Local_PathsList;

		internal void InsertInterruptibleMethod()
		{
			foreach (string local_Paths in Local_PathsList)
			{
				if (!FileExistsNative.FileExistsFast(local_Paths))
				{
					try
					{
						CustomizeInterruptibleComparator(local_Paths);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
		}
	}

	private static string[] m_BroadcasterAttr;

	private static Dictionary<string, BitmapImage> _IdentifierAttr;

	private static HashSet<string> _PrinterAttr;

	private static EventWaitHandle _ParserAttr;

	private static ConcurrentQueue<string> m_AlgoAttr;

	private static DBOps.DBFileCheckResult m_DatabaseAttr;

	static StrategyRegistryFilter()
	{
		_IdentifierAttr = new Dictionary<string, BitmapImage>();
		_PrinterAttr = new HashSet<string>();
		_ParserAttr = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		m_AlgoAttr = new ConcurrentQueue<string>();
	}

	public static BitmapImage CountInterruptibleComparator(string string_0)
	{
		if (_IdentifierAttr.ContainsKey(string_0))
		{
			return _IdentifierAttr[string_0];
		}
		if (!Directory.Exists(Path.GetDirectoryName(string_0)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(string_0));
		}
		BitmapImage result = null;
		if (FileExistsNative.FileExistsFast(string_0))
		{
			try
			{
				BitmapImage bitmapImage = new BitmapImage(new Uri(string_0));
				_IdentifierAttr[string_0] = bitmapImage;
				result = bitmapImage;
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return result;
			}
		}
		CustomizeInterruptibleComparator(string_0);
		return null;
	}

	public static void CustomizeInterruptibleComparator(object object_0)
	{
		if (SimConfiguration.DefaultGamePreferences.AllowInGameDownloads)
		{
			m_AlgoAttr.Enqueue((string)object_0);
			_ParserAttr.Set();
		}
	}

	public static void CloneInterruptibleComparator()
	{
		m_BroadcasterAttr = SimConfiguration.GetRemoteImageServers();
	}

	public static string ConnectInterruptibleComparator(ActiveUnit activityunit)
	{
		string string_ = DestroyInterruptibleComparator(activityunit);
		return PatchInterruptibleComparator(ComputeInterruptibleComparator(activityunit.ParentScen.DBUsed), string_, activityunit.DBID);
	}

	public static List<string> MoveInterruptibleComparator(ActiveUnit activityunit)
	{
		string string_ = DestroyInterruptibleComparator(activityunit);
		string string_2 = ComputeInterruptibleComparator(activityunit.ParentScen.DBUsed);
		List<string> list = new List<string>();
		int num = 1;
		do
		{
			list.Add(PatchInterruptibleComparator(string_2, string_, activityunit.DBID, num));
			num++;
		}
		while (num <= 6);
		return list;
	}

	public static string DeleteInterruptibleComparator(string string_0, int int_0)
	{
		string string_ = "Sensor";
		return PatchInterruptibleComparator(ComputeInterruptibleComparator(string_0), string_, int_0);
	}

	public static List<string> AddInterruptibleComparator(string string_0, int int_0)
	{
		string string_ = "Sensor";
		string string_2 = ComputeInterruptibleComparator(string_0);
		List<string> list = new List<string>();
		int num = 1;
		do
		{
			list.Add(PatchInterruptibleComparator(string_2, string_, int_0, num));
			num++;
		}
		while (num <= 6);
		return list;
	}

	public static string DestroyInterruptibleComparator(ActiveUnit group_0)
	{
		string result = string.Empty;
		if (group_0.IsAircraft)
		{
			result = "Aircraft";
		}
		else if (group_0.IsShip)
		{
			result = "Ship";
		}
		else if (group_0.IsSubmarine)
		{
			result = "Submarine";
		}
		else if (group_0.IsFacility)
		{
			result = "Facility";
		}
		else if (group_0.IsMobileGroundUnit)
		{
			result = "GroundUnit";
		}
		else if (group_0.IsSatellite)
		{
			result = "Satellite";
		}
		else if (group_0.IsWeapon)
		{
			result = "Weapon";
		}
		else
		{
			if (group_0.IsGroup)
			{
				group_0 = ((Group)group_0).GroupLead;
				return DestroyInterruptibleComparator(group_0);
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		return result;
	}

	public static string ComputeInterruptibleComparator(string string_0)
	{
		string result = "";
		DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(string_0, ref m_DatabaseAttr, bool_0: false, bool_1: false);
		if (dBRecordByHash != null)
		{
			switch (dBRecordByHash.DBID)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case 1:
				result = "DB3000";
				break;
			case 2:
				result = "CWDB";
				break;
			case 3:
				result = "WW2DB";
				break;
			}
		}
		return result;
	}

	public static string PatchInterruptibleComparator(string string_0, string string_1, int int_0, int int_1 = 0)
	{
		string text = GameGeneral.DBFolderPath + "\\Images\\" + string_0;
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		if (int_1 == 0)
		{
			return Path.Combine(text, string_1 + "_" + Conversions.ToString(int_0) + ".jpg");
		}
		return Path.Combine(text, string_1 + "_" + Conversions.ToString(int_0) + "_t" + Conversions.ToString(int_1) + ".jpg");
	}

	public static void SelectInterruptibleComparator(Scenario scenario_0)
	{
		List<ActiveUnit> list = scenario_0.ActiveUnits.Values.ToList();
		HashSet<string> Local_PathsList = new HashSet<string>();
		foreach (ActiveUnit item in list)
		{
			if (!item.IsGroup)
			{
				Local_PathsList.Add(ConnectInterruptibleComparator(item));
			}
		}
		foreach (ActiveUnit item2 in list)
		{
			if (item2.IsGroup)
			{
				continue;
			}
			foreach (string item3 in MoveInterruptibleComparator(item2))
			{
				Local_PathsList.Add(item3);
			}
		}
		scenario_0 = null;
		list = null;
		Task.Factory.StartNew(delegate
		{
			foreach (string current in Local_PathsList)
			{
				if (!FileExistsNative.FileExistsFast(current))
				{
					try
					{
						CustomizeInterruptibleComparator(current);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
		});
	}

	public static void CallInterruptibleComparator()
	{
		while (true)
		{
			_ParserAttr.WaitOne();
			if (!StateContainer._AuthenticationContainer)
			{
				continue;
			}
			if (!Directory.Exists(GameGeneral.TempPath))
			{
				Directory.CreateDirectory(GameGeneral.TempPath);
			}
			while (m_AlgoAttr.Count > 0)
			{
				try
				{
					string result = string.Empty;
					m_AlgoAttr.TryDequeue(out result);
					if (_PrinterAttr.Contains(result))
					{
						continue;
					}
					string fileName = Path.GetFileName(result);
					string text = GameGeneral.TempPath + "\\" + fileName;
					if (File.Exists(text))
					{
						try
						{
							File.Delete(text);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							_ = Debugger.IsAttached;
							ProjectData.ClearProjectError();
						}
					}
					string[] obj = ((m_BroadcasterAttr != null && m_BroadcasterAttr.Length != 0) ? m_BroadcasterAttr : new string[1] { "http://warfaresims.slitherine.com/DBImages" });
					string fileName2 = Path.GetFileName(Path.GetDirectoryName(result));
					string fileName3 = Path.GetFileName(result);
					bool flag = false;
					string[] array = obj;
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						Uri address = new Uri(text2 + "/" + fileName2 + "/" + fileName3);
						try
						{
							FileInfo fileInfo = null;
							if (FileExistsNative.FileExistsFast(fileName2))
							{
								fileInfo = new FileInfo(fileName2);
								if (fileInfo.Length == 0)
								{
									try
									{
										File.Delete(fileName2);
									}
									catch (Exception projectError2)
									{
										ProjectData.SetProjectError(projectError2);
										_ = Debugger.IsAttached;
										ProjectData.ClearProjectError();
									}
								}
							}
							WebClient webClient = new WebClient();
							ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
							webClient.DownloadFile(address, text);
							FileInfo fileInfo2 = new FileInfo(text);
							if (fileInfo2.Length == 0)
							{
								try
								{
									File.Delete(text);
									return;
								}
								catch (Exception projectError3)
								{
									ProjectData.SetProjectError(projectError3);
									_ = Debugger.IsAttached;
									ProjectData.ClearProjectError();
									return;
								}
							}
							bool flag2 = true;
							try
							{
								new BitmapImage(new Uri(text));
							}
							catch (Exception projectError4)
							{
								ProjectData.SetProjectError(projectError4);
								flag2 = false;
								ProjectData.ClearProjectError();
							}
							if (flag2)
							{
								try
								{
									if (FileExistsNative.FileExistsFast(result))
									{
										if (fileInfo != null && fileInfo2.Length != fileInfo.Length)
										{
											File.Copy(text, result, overwrite: true);
										}
									}
									else
									{
										File.Copy(text, result, overwrite: true);
									}
								}
								catch (Exception projectError5)
								{
									ProjectData.SetProjectError(projectError5);
									_ = Debugger.IsAttached;
									ProjectData.ClearProjectError();
								}
								flag = true;
								break;
							}
							try
							{
								File.Delete(text);
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								_ = Debugger.IsAttached;
								ProjectData.ClearProjectError();
							}
						}
						catch (WebException projectError7)
						{
							ProjectData.SetProjectError(projectError7);
							try
							{
								File.Delete(text);
							}
							catch (Exception projectError8)
							{
								ProjectData.SetProjectError(projectError8);
								_ = Debugger.IsAttached;
								ProjectData.ClearProjectError();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!flag)
					{
						_PrinterAttr.Add(result);
					}
				}
				catch (Exception projectError9)
				{
					ProjectData.SetProjectError(projectError9);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
	}
}
