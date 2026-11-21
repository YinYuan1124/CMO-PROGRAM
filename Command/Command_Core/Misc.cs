using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.DAL;
using CoordinateSharp;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Misc
{
	public enum PostureStance : byte
	{
		Neutral,
		Friendly,
		Unfriendly,
		Hostile,
		Unknown
	}

	public enum DiskType : byte
	{
		Undefined,
		HDD,
		SSD,
		SCM
	}

	public enum ExtendPhase : byte
	{
		FinalApproach,
		LiningUp,
		Extending,
		Standard
	}

	public enum GroupingLogic
	{
		SplitByType,
		MixedGroup
	}

	public enum TurnDirection
	{
		TurnLeft = 1,
		TurnRight = 2,
		TurnPort = 1,
		TurnStarboard = 2
	}

	[CompilerGenerated]
	private sealed class BridgeListenerMapping
	{
		public char int_;

		public char[] char_0;

		internal void EnableInterruptibleQueue(int i)
		{
			int_ = char_0[i];
			if (!InstantiateRequest(int_))
			{
				char_0[i] = '\0';
			}
		}
	}

	[CompilerGenerated]
	private sealed class MappingCallbackCandidate
	{
		public char int_;

		public byte[] byte_0;

		internal void ChangeInterruptibleQueue(int i)
		{
			int_ = Convert.ToChar(byte_0[i]);
			if (!InstantiateRequest(int_))
			{
				byte_0[i] = 0;
			}
		}
	}

	[CompilerGenerated]
	private sealed class PredicateRegistryFilter
	{
		public int Local_theInt;

		internal bool InitInterruptibleQueue(ActiveUnit AC)
		{
			return ((Aircraft)AC).Int32_0 == Local_theInt;
		}
	}

	public const float METERS_TO_FEET = 3.28084f;

	public const float FEET_TO_METERS = 0.3048f;

	public const int PeriscopeRadarSignature = -30;

	public const int PeriscopeVisualSignature = 2;

	public const int PeriscopeInfraredSignature = 2;

	public const int PeriscopeDepth_m = -20;

	public const int SnorkelRadarSignature = -20;

	public const int SnorkelVisualSignature = 2;

	public const int SnorkelInfraredSignature = 2;

	public const int SurfacedDepth_m = -5;

	public const float MaxTargetSpeedOverrideModifier = 1.2f;

	public const float MinTargetSpeedOverrideModifier = 0.8f;

	public static double AngularDistance_5nm;

	public static string LastBarkText;

	public const float float_0 = -10000f;

	static Misc()
	{
		LastBarkText = "";
	}

	internal static float SetupRequest(float float_1, float float_2, int int_0)
	{
		return (float)Math.Round(float_1 + float_2, int_0);
	}

	internal static float ExcludeRequest(float float_1, float float_2, int int_0)
	{
		return (float)Math.Round(float_1 - float_2, int_0);
	}

	internal static List<FiringProposal> IncludeRequest(ConcurrentQueue<FiringProposal> concurrentQueue_0)
	{
		List<FiringProposal> list = new List<FiringProposal>();
		FiringProposal result;
		while (concurrentQueue_0.TryDequeue(out result))
		{
			list.Add(result);
		}
		return list;
	}

	internal static string SearchRequest(string string_0, string string_1 = "")
	{
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		string text = string_0;
		for (int i = 0; i < text.Length; i = checked(i + 1))
		{
			char c = text[i];
			char[] array = invalidFileNameChars;
			char[] array2 = array;
			foreach (char c2 in array2)
			{
				if (Operators.CompareString(c2.ToString(), c.ToString(), TextCompare: false) == 0)
				{
					string_0 = string_0.Replace(Conversions.ToString(c), string_1);
				}
			}
		}
		return string_0;
	}

	internal static List<T> EnableRequest<T>(List<T> list_0)
	{
		return list_0.GetRange(0, list_0.Count);
	}

	internal static T[] ChangeRequest<T>(List<T> list_0)
	{
		if (list_0 == null)
		{
			return null;
		}
		int count = list_0.Count;
		T[] array = new T[count - 1 + 1];
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = list_0[i];
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array[j] = list_0[j];
			}
			ProjectData.ClearProjectError();
		}
		return array;
	}

	internal static T[] InitRequest<T>(TList<T> tlist_0)
	{
		if (tlist_0 == null)
		{
			return null;
		}
		int count = tlist_0.Count;
		T[] array = new T[count - 1 + 1];
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = tlist_0[i];
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array[j] = tlist_0[j];
			}
			ProjectData.ClearProjectError();
		}
		return array;
	}

	internal static T[] CheckRequest<T>(Array array_0)
	{
		if (array_0 == null)
		{
			return null;
		}
		int num = array_0.Length;
		T[] array = new T[num - 1 + 1];
		try
		{
			Array.Copy(array_0, array, num);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Array.Copy(array_0, array, num);
			ProjectData.ClearProjectError();
		}
		return array;
	}

	public static void Sort<TSource, TKey>(ObservableCollection<TSource> observableCollection_0, Func<TSource, TKey> func_0, bool bool_0)
	{
		List<TSource> list = (bool_0 ? new List<TSource>(observableCollection_0.OrderByDescending(func_0)) : new List<TSource>(observableCollection_0.OrderBy(func_0)));
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			object obj = observableCollection_0[i];
			object obj2 = list[i];
			if (obj != obj2)
			{
				int num2 = observableCollection_0.IndexOf(list[i]);
				if (num2 != i)
				{
					observableCollection_0.Move(num2, i);
				}
			}
		}
	}

	internal static DiskType ConcatRequest(int int_0)
	{
		ManagementScope managementScope = new ManagementScope("\\\\.\\root\\microsoft\\windows\\storage");
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM MSFT_PhysicalDisk");
		try
		{
			managementScope.Connect();
			managementObjectSearcher.Scope = managementScope;
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			DiskType result = DiskType.Undefined;
			foreach (ManagementObject item in managementObjectCollection)
			{
				if (Conversions.ToInteger(item["DeviceId"]) == int_0)
				{
					short num = Convert.ToInt16(RuntimeHelpers.GetObjectValue(item["MediaType"]));
					if (1 == 0)
					{
					}
					DiskType diskType = num switch
					{
						1 => DiskType.Undefined, 
						3 => DiskType.HDD, 
						4 => DiskType.SSD, 
						5 => DiskType.SCM, 
						_ => DiskType.Undefined, 
					};
					if (1 == 0)
					{
					}
					result = diskType;
				}
			}
			managementObjectSearcher.Dispose();
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
			return DiskType.Undefined;
		}
	}

	internal static string InterruptRequest(string string_0)
	{
		string_0 = string_0.TrimEnd('\\');
		ManagementScope scope = new ManagementScope("\\root\\cimv2");
		ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher(scope, new ObjectQuery("select * from Win32_DiskDrive")).Get();
		try
		{
			foreach (ManagementObject item in managementObjectCollection)
			{
				foreach (ManagementObject item2 in new ManagementObjectSearcher(scope, new ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + Conversions.ToString(item["DeviceID"]) + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition")).Get())
				{
					foreach (ManagementBaseObject item3 in new ManagementObjectSearcher(scope, new ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + Conversions.ToString(item2["DeviceID"]) + "'} WHERE AssocClass = Win32_LogicalDiskToPartition")).Get())
					{
						if (Operators.CompareString(item3["DeviceId"].ToString(), string_0, TextCompare: false) == 0)
						{
							return item2["DiskIndex"].ToString();
						}
					}
				}
			}
			return null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static string LatitudeToEnglish(double double_0)
	{
		string text;
		if (double_0 <= 0.0)
		{
			text = "S";
			double_0 = 0.0 - double_0;
		}
		else
		{
			text = "N";
		}
		return text + MathFunctions.WriteRequest(MathFunctions.GetRequest(Math.Round(double_0, 4)));
	}

	public static string LongitudeToEnglish(double double_0)
	{
		string text;
		if (double_0 <= 0.0)
		{
			text = "W";
			double_0 = 0.0 - double_0;
		}
		else
		{
			text = "E";
		}
		return text + MathFunctions.WriteRequest(MathFunctions.GetRequest(Math.Round(double_0, 4)));
	}

	public static string ReplaceIllegalCharacters(string string_0, string string_1)
	{
		string text = "~\"#%&*:<>?{|}/\\[]\n\r";
		int num = Strings.Len(text);
		for (int i = 1; i <= num; i++)
		{
			string_0 = Strings.Replace(string_0, Strings.Mid(text, i, 1), string_1);
		}
		return string_0;
	}

	public static Alertlevels GetSelectedIntermittentEmissionConfig_ByString(string string_0)
	{
		string_0 = string_0.ToLower();
		if (1 == 0)
		{
		}
		Alertlevels result = string_0 switch
		{
			"yellow" => Alertlevels.Yellow, 
			"red" => Alertlevels.Red, 
			"orange" => Alertlevels.Orange, 
			"green" => Alertlevels.Green, 
			"custom" => Alertlevels.Custom, 
			"blue" => Alertlevels.Blue, 
			_ => Alertlevels.Unknown, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static ActiveUnit GetActiveUnitByNameOrID(string string_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		scenario_0.ActiveUnits.TryGetValue(string_0, ref activeUnit);
		if (activeUnit == null)
		{
			foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
			{
				if (value != null && string.Equals(value.Name, string_0, StringComparison.OrdinalIgnoreCase))
				{
					return value;
				}
			}
			return activeUnit;
		}
		return activeUnit;
	}

	internal static bool RemoveRequest(string string_0)
	{
		if (MerchantMerchantPage.SelectList.FileSystem.DirectoryExists(string_0))
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		DirectorySecurity accessControl = Directory.GetAccessControl(string_0);
		if (accessControl == null)
		{
			return false;
		}
		AuthorizationRuleCollection accessRules = accessControl.GetAccessRules(includeExplicit: true, includeInherited: true, typeof(SecurityIdentifier));
		if (accessRules == null)
		{
			return false;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = accessRules.GetEnumerator();
			while (enumerator.MoveNext())
			{
				FileSystemAccessRule fileSystemAccessRule = (FileSystemAccessRule)enumerator.Current;
				if ((FileSystemRights.Write & fileSystemAccessRule.FileSystemRights) == FileSystemRights.Write)
				{
					if (fileSystemAccessRule.AccessControlType == AccessControlType.Allow)
					{
						flag = true;
					}
					if (fileSystemAccessRule.AccessControlType == AccessControlType.Deny)
					{
						flag2 = true;
					}
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
		if (flag && !flag2)
		{
			return true;
		}
		return false;
	}

	internal static bool FindRequest(double double_0)
	{
		try
		{
			Math.Round(double_0);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200090", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static bool SetRequest(string string_0)
	{
		return !Directory.EnumerateFileSystemEntries(string_0).Any();
	}

	internal static string FillRequest(float float_1)
	{
		string text = string.Format("{0:0.0}", float_1, 2);
		if (Operators.CompareString(text, "360.0", TextCompare: false) == 0)
		{
			text = "0.0";
		}
		else if (Operators.CompareString(text, "360", TextCompare: false) == 0)
		{
			text = "360";
		}
		return text;
	}

	internal static string CalculateRequest(string string_0)
	{
		string extension = Path.GetExtension(string_0);
		extension = ((extension.Length == 4) ? (Conversions.ToString(extension[0]) + Conversions.ToString(extension[1]) + Conversions.ToString(extension[extension.Length - 1]) + "w") : (extension + "w"));
		string text = Path.ChangeExtension(string_0, extension);
		if (FileExistsNative.FileExistsFast(text))
		{
			string text2 = File.ReadAllText(text);
			text2 = text2.Replace(",", ".");
			File.WriteAllText(text, text2);
			return text;
		}
		return null;
	}

	public static void CopyDirectory(string string_0, string string_1, bool bool_0)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (directoryInfo.Exists)
		{
			if (!Directory.Exists(string_1))
			{
				Directory.CreateDirectory(string_1);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array2 = files;
			foreach (FileInfo fileInfo in array2)
			{
				string destFileName = Path.Combine(string_1, fileInfo.Name);
				fileInfo.CopyTo(destFileName, overwrite: true);
			}
			if (bool_0)
			{
				DirectoryInfo[] array = directories;
				DirectoryInfo[] array3 = array;
				foreach (DirectoryInfo directoryInfo2 in array3)
				{
					string string_2 = Path.Combine(string_1, directoryInfo2.Name);
					CopyDirectory(directoryInfo2.FullName, string_2, bool_0);
				}
			}
			return;
		}
		throw new DirectoryNotFoundException(Convert.ToString("源目录不存在或找不到：") + string_0);
	}

	public static void DeleteEverythingInDirectory(string string_0)
	{
		if (Directory.Exists(string_0))
		{
			foreach (string item in Directory.EnumerateDirectories(string_0))
			{
				Directory.Delete(item, recursive: true);
			}
			string[] files = Directory.GetFiles(string_0);
			string[] array = files;
			foreach (string text in array)
			{
				if (!text.EndsWith("\\instance"))
				{
					try
					{
						File.Delete(text);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200574: Could not delete file " + text, ex2.Message);
						_ = Debugger.IsAttached;
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		else
		{
			Directory.CreateDirectory(string_0);
		}
	}

	public static int LevenshteinDistance(string string_0, string string_1)
	{
		int length = string_0.Length;
		int length2 = string_1.Length;
		int[,] array = new int[length + 1, length2 + 1];
		if (length == 0)
		{
			return length2;
		}
		if (length2 == 0)
		{
			return length;
		}
		int location = 0;
		while (location <= length)
		{
			array[location, 0] = Math.Max(Interlocked.Increment(ref location), location - 1);
		}
		int location2 = 0;
		while (location2 <= length2)
		{
			array[0, location2] = Math.Max(Interlocked.Increment(ref location2), location2 - 1);
		}
		int num = length;
		for (int i = 1; i <= num; i++)
		{
			int num2 = length2;
			for (int j = 1; j <= num2; j++)
			{
				int num3 = ((string_1[j - 1] != string_0[i - 1]) ? 1 : 0);
				array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1, array[i, j - 1] + 1), array[i - 1, j - 1] + num3);
			}
		}
		return array[length, length2];
	}

	internal static string PopRequest(string string_0)
	{
		char[] array = new char[string_0.Length - 1 + 1];
		int num = 0;
		bool flag = false;
		int num2 = string_0.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			char c = string_0[i];
			switch (c)
			{
			case '>':
				flag = false;
				continue;
			case '<':
				flag = true;
				continue;
			}
			if (!flag)
			{
				array[num] = c;
				num++;
			}
		}
		return new string(array, 0, num).Replace("&nbsp;", " ");
	}

	public static void CopyDirectoryOverwriteIfDifferent(string string_0, string string_1, bool bool_0)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (directoryInfo.Exists)
		{
			if (!Directory.Exists(string_1))
			{
				Directory.CreateDirectory(string_1);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array2 = files;
			foreach (FileInfo fileInfo in array2)
			{
				string text = Path.Combine(string_1, fileInfo.Name);
				if (FileExistsNative.FileExistsFast(text))
				{
					FileInfo fileInfo2 = new FileInfo(text);
					if (DateTime.Compare(fileInfo2.LastWriteTimeUtc, fileInfo.LastWriteTimeUtc) != 0 || fileInfo2.Length != fileInfo.Length)
					{
						fileInfo2.Delete();
						fileInfo.CopyTo(text, overwrite: true);
					}
				}
				else
				{
					fileInfo.CopyTo(text, overwrite: true);
				}
			}
			if (bool_0)
			{
				DirectoryInfo[] array = directories;
				DirectoryInfo[] array3 = array;
				foreach (DirectoryInfo directoryInfo2 in array3)
				{
					string string_2 = Path.Combine(string_1, directoryInfo2.Name);
					CopyDirectoryOverwriteIfDifferent(directoryInfo2.FullName, string_2, bool_0);
				}
			}
			return;
		}
		throw new DirectoryNotFoundException(Convert.ToString("源目录不存在或找不到：") + string_0);
	}

	public static string CleanUpXML_Headers(string string_0)
	{
		string @string = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
		if (string_0.StartsWith(@string))
		{
			string_0 = string_0.Remove(0, @string.Length);
		}
		if (!string_0.StartsWith("<"))
		{
			string_0 = "<" + string_0;
		}
		if (string_0.StartsWith("<?xml"))
		{
			string_0 = Strings.Right(string_0, Strings.Len(string_0) - Strings.InStr(string_0, ">"));
		}
		return string_0;
	}

	public static byte[] CleanUpXML_Headers(byte[] byte_0)
	{
		int num = byte_0.Length - 1;
		int num2 = 0;
		for (int i = 0; i <= num; i++)
		{
			if (Operators.CompareString(Conversions.ToString(Convert.ToChar(byte_0[i])), ">", TextCompare: false) == 0)
			{
				num2 = i;
				break;
			}
		}
		byte[] array = new byte[byte_0.Length - (num2 + 2) + 1];
		try
		{
			Array.Copy(byte_0, num2 + 1, array, 0, array.Length);
			byte_0 = array;
			return byte_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101335", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static string CleanUpXML_IllegalCharacters(char[] char_0)
	{
		int toExclusive = char_0.Length;
		char int_;
		Parallel.For(0, toExclusive, delegate(int i)
		{
			int_ = char_0[i];
			if (!InstantiateRequest(int_))
			{
				char_0[i] = '\0';
			}
		});
		return char_0.ToString();
	}

	public static byte[] CleanUpXML_IllegalCharacters(byte[] byte_0)
	{
		int toExclusive = byte_0.Length;
		char int_;
		Parallel.For(0, toExclusive, delegate(int i)
		{
			int_ = Convert.ToChar(byte_0[i]);
			if (!InstantiateRequest(int_))
			{
				byte_0[i] = 0;
			}
		});
		return byte_0;
	}

	private static bool InstantiateRequest(int int_0)
	{
		if (int_0 != 9 && int_0 != 10 && int_0 != 13 && (int_0 < 32 || int_0 > 55295) && (int_0 < 57344 || int_0 > 65533))
		{
			if (int_0 < 65536)
			{
				return false;
			}
			return int_0 <= 1114111;
		}
		return true;
	}

	public static string CoordinateToString(double double_0, double double_1, Parse_Format_Type parse_Format_Type_0)
	{
		if (parse_Format_Type_0 == Parse_Format_Type.Degree_Minute_Second)
		{
			return CoordsToEnglish(double_0, double_1);
		}
		Coordinate val = new Coordinate(double_0, double_1);
		if (parse_Format_Type_0 != Parse_Format_Type.Signed_Degree)
		{
			int num = (int)(parse_Format_Type_0 - 5);
			if (1 == 0)
			{
			}
			string result = num switch
			{
				0 => val.UTM.ToString(), 
				1 => val.MGRS.ToString(), 
				3 => val.ECEF.ToString(), 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		return Conversions.ToString(Math.Round(double_0, 3)) + ", " + Conversions.ToString(Math.Round(double_1, 3));
	}

	public static string CoordsToEnglish(double double_0, double double_1)
	{
		string text;
		if (double_0 <= 0.0)
		{
			text = "S";
			double_0 = 0.0 - double_0;
		}
		else
		{
			text = "N";
		}
		string text2;
		if (double_1 <= 0.0)
		{
			text2 = "W";
			double_1 = 0.0 - double_1;
		}
		else
		{
			text2 = "E";
		}
		return text + MathFunctions.WriteRequest(MathFunctions.GetRequest(Math.Round(double_0, 4))) + ", " + text2 + MathFunctions.WriteRequest(MathFunctions.GetRequest(Math.Round(double_1, 4)));
	}

	public static void FixMissingElements(Scenario scenario_0)
	{
		try
		{
			scenario_0.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (Information.IsNothing(side.MapCenter))
				{
					side.MapCenter = new GeoPoint(0.0, 0.0);
				}
				if (Information.IsNothing(side.CameraAlt))
				{
					side.CameraAlt = 6000000.0;
				}
				else if (side.CameraAlt == 0.0)
				{
					side.CameraAlt = 4000000.0;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static bool CreateRequest(string string_0, char char_0)
	{
		return string_0.IndexOf(char_0) != -1;
	}

	internal static bool CompareRequest(string string_0, string string_1)
	{
		return string_0.IndexOf(string_1, StringComparison.OrdinalIgnoreCase) != -1;
	}

	internal static string ReadRequest(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return string.Empty;
		}
		int num = string_0.IndexOf('|');
		if (num == -1)
		{
			return string_0;
		}
		return Strings.Left(string_0, num);
	}

	internal static DateTime DisableRequest(DateTime dateTime_0, double double_0, bool bool_0, string string_0, string string_1)
	{
		try
		{
			if (dateTime_0.Year < 1900)
			{
				dateTime_0 = DateTime.Now;
			}
			DateTime result = dateTime_0.AddHours(Math.Floor((double_0 + 7.5) / 15.0));
			if (bool_0)
			{
				List<string> list = string_0.Split('.').ToList();
				List<string> list2 = string_1.Split('.').ToList();
				if ((Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1])) && (((double)dateTime_0.Day >= Conversions.ToDouble(list[0])) & ((double)dateTime_0.Month >= Conversions.ToDouble(list[1]))) && (((double)dateTime_0.Day <= Conversions.ToDouble(list2[0])) & ((double)dateTime_0.Month <= Conversions.ToDouble(list2[1]))))
				{
					result = result.AddHours(1.0);
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101099", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return default(DateTime);
		}
	}

	internal static string UpdateRequest(long long_0, Aircraft_AirOps.AirOpsAvailabilityStatus airOpsAvailabilityStatus_0 = Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool bool_0 = false, bool bool_1 = false)
	{
		if (long_0 <= int.MaxValue)
		{
			TimeSpan timeSpan;
			try
			{
				timeSpan = TimeSpan.FromSeconds(long_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200091", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return "N/A";
			}
			int num = (int)Math.Floor((double)timeSpan.Days / 7.0);
			int num2 = (int)Math.Floor((double)timeSpan.Days / 30.0);
			int num3 = (int)Math.Floor((double)timeSpan.Days / 365.0);
			if (airOpsAvailabilityStatus_0 == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance)
			{
				return "不可用";
			}
			if (num3 <= 0)
			{
				if (num2 <= 0)
				{
					if (num <= 0)
					{
						if (timeSpan.Days <= 0)
						{
							if (timeSpan.Hours <= 0)
							{
								if (timeSpan.Minutes <= 0)
								{
									if (timeSpan.Seconds <= 0)
									{
										if (timeSpan.Seconds == 0)
										{
											if (bool_0)
											{
												return "否";
											}
											if (bool_1)
											{
												return "0";
											}
											return "准备";
										}
										return "错误！";
									}
									return Conversions.ToString(timeSpan.Seconds) + " 秒";
								}
								return Conversions.ToString(timeSpan.Minutes) + " 分钟" + ((timeSpan.Seconds == 0) ? "" : (" " + Conversions.ToString(timeSpan.Seconds) + " 秒")).ToString();
							}
							return Conversions.ToString(timeSpan.Hours) + " 小时" + ((timeSpan.Minutes == 0) ? "" : (" " + Conversions.ToString(timeSpan.Minutes) + " 分钟")).ToString();
						}
						return Conversions.ToString(timeSpan.Days) + " 天" + ((timeSpan.Hours == 0) ? "" : (" " + Conversions.ToString(timeSpan.Hours) + " 小时")).ToString();
					}
					return Conversions.ToString(num) + " 星期" + ((timeSpan.Days - num * 7 == 0) ? "" : (" " + Conversions.ToString(timeSpan.Days - num * 7) + " 天")).ToString();
				}
				return Conversions.ToString(num2) + " 月" + ((num - num2 * 4 == 0) ? "" : (" " + Conversions.ToString(num - num2 * 4) + " 星期")).ToString();
			}
			return Conversions.ToString(num3) + " 年" + ((num2 - num3 * 12 == 0) ? "" : (" " + Conversions.ToString(num2 - num3 * 12) + " 月")).ToString();
		}
		return "很长";
	}

	internal static string InsertRequest(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder(((Array)object_0).Length * 2);
		int num = ((Array)object_0).Length - 1;
		for (int i = 0; i <= num; i++)
		{
			stringBuilder.Append(((byte[])object_0)[i].ToString("X2"));
		}
		return stringBuilder.ToString().ToLower();
	}

	public static string ToString(EventTrigger_RegularTime.RegularTimeInterval regularTimeInterval_0)
	{
		if (1 == 0)
		{
		}
		string result = regularTimeInterval_0 switch
		{
			EventTrigger_RegularTime.RegularTimeInterval.OneSecond => "一秒", 
			EventTrigger_RegularTime.RegularTimeInterval.FiveSeconds => "五秒", 
			EventTrigger_RegularTime.RegularTimeInterval.FifteenSeconds => "十五秒", 
			EventTrigger_RegularTime.RegularTimeInterval.ThirtySeconds => "三十秒", 
			EventTrigger_RegularTime.RegularTimeInterval.OneMinute => "一分钟", 
			EventTrigger_RegularTime.RegularTimeInterval.FiveMinutes => "五分钟", 
			EventTrigger_RegularTime.RegularTimeInterval.FifteenMinutes => "十五分钟", 
			EventTrigger_RegularTime.RegularTimeInterval.ThirtyMinutes => "三十分钟", 
			EventTrigger_RegularTime.RegularTimeInterval.OneHour => "一小时", 
			EventTrigger_RegularTime.RegularTimeInterval.SixHours => "六小时", 
			EventTrigger_RegularTime.RegularTimeInterval.TwelveHours => "十二小时", 
			EventTrigger_RegularTime.RegularTimeInterval.TwentyFourHours => "二十四小时", 
			EventTrigger_RegularTime.RegularTimeInterval.EveryPulse => "每个仿真步长", 
			_ => "错误！", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool IsEmpty_LockFreeCheck(ConcurrentDictionary<int, bool> concurrentDictionary_0)
	{
		if (concurrentDictionary_0.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static bool IsEmpty_LockFreeCheck(ConcurrentDictionary<Tuple<int, string>, Tuple<ActiveUnit_Weaponry.DLZResultEnum, float>> concurrentDictionary_0)
	{
		if (concurrentDictionary_0.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static bool IsEmpty_LockFreeCheck(ConcurrentDictionary<string, Contact> concurrentDictionary_0)
	{
		if (concurrentDictionary_0.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static bool IsEmpty_LockFreeCheck(ConcurrentDictionary<Tuple<ActiveUnit, int, ScenarioObject>, double> concurrentDictionary_0)
	{
		if (concurrentDictionary_0.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static List<T> Values_ToList<T>(ConcurrentDictionary<T, T> concurrentDictionary_0)
	{
		IEnumerator<KeyValuePair<T, T>> enumerator = concurrentDictionary_0.GetEnumerator();
		List<T> list = new List<T>();
		while (enumerator.MoveNext())
		{
			list.Add(enumerator.Current.Value);
		}
		return list;
	}

	public static List<T> Keys_ToList<T>(ConcurrentDictionary<T, T> concurrentDictionary_0)
	{
		IEnumerator<KeyValuePair<T, T>> enumerator = concurrentDictionary_0.GetEnumerator();
		List<T> list = new List<T>();
		while (enumerator.MoveNext())
		{
			list.Add(enumerator.Current.Key);
		}
		return list;
	}

	public static bool HasActiveMode(Sensor.Sensor_Type sensor_Type_0)
	{
		switch (sensor_Type_0)
		{
		default:
			return false;
		case Sensor.Sensor_Type.Radar:
		case Sensor.Sensor_Type.ECM:
		case Sensor.Sensor_Type.LaserDesignator:
		case Sensor.Sensor_Type.LaserRangefinder:
		case Sensor.Sensor_Type.HullSonar_ActivePassive:
		case Sensor.Sensor_Type.HullSonar_ActiveOnly:
		case Sensor.Sensor_Type.TowedArray_ActivePassive:
		case Sensor.Sensor_Type.TowedArray_ActiveOnly:
		case Sensor.Sensor_Type.VDS_ActivePassive:
		case Sensor.Sensor_Type.VDS_ActiveOnly:
		case Sensor.Sensor_Type.DippingSonar_ActivePassive:
		case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
		case Sensor.Sensor_Type.NonDetectingEmitter:
			return true;
		}
	}

	public static void Shuffle<T>(IList<T> ilist_0)
	{
		RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		int num = ilist_0.Count;
		while (num > 1)
		{
			byte[] array = new byte[1];
			do
			{
				rNGCryptoServiceProvider.GetBytes(array);
			}
			while (!((double)(int)array[0] < (double)num * (255.0 / (double)num)));
			int index = array[0] % num;
			num--;
			T value = ilist_0[index];
			ilist_0[index] = ilist_0[num];
			ilist_0[num] = value;
		}
	}

	public static void Clear<T>(ConcurrentQueue<T> concurrentQueue_0)
	{
		T result;
		while (concurrentQueue_0.TryDequeue(out result))
		{
		}
	}

	internal static int PrepareRequest(IEnumerable<ActiveUnit> ienumerable_0)
	{
		try
		{
			int num = 999999999;
			foreach (ActiveUnit item in ienumerable_0)
			{
				int maximumSpeed = item.Kinematics.GetMaximumSpeed(item.GetCurrentAltitude(), item.MaxPossibleThrottleSetting, bool_0: false);
				if (maximumSpeed < num)
				{
					num = maximumSpeed;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101098", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal static bool ReflectRequest(string string_0, string string_1)
	{
		return (double)(string_0.Length - string_0.Replace(string_1, string.Empty).Length) / (double)string_1.Length == 1.0;
	}

	internal static string VisitRequest(Aircraft.CockpitVisibility cockpitVisibility_0)
	{
		if (1 == 0)
		{
		}
		string result = cockpitVisibility_0 switch
		{
			Aircraft.CockpitVisibility.Excellent => "优秀", 
			Aircraft.CockpitVisibility.Average => "一般", 
			Aircraft.CockpitVisibility.Poor => "较差", 
			_ => "错误！", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string RestartRequest(Warhead.WarheadCaliber warheadCaliber_0)
	{
		switch (warheadCaliber_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return "错误";
		case Warhead.WarheadCaliber.Rocket_6_15mm:
			return "Rocket (6-15mm)";
		case Warhead.WarheadCaliber.Rocket_16_24mm:
			return "Rocket (16-24mm)";
		case Warhead.WarheadCaliber.Rocket_25_60mm:
			return "Rocket (25-60mm)";
		case Warhead.WarheadCaliber.Rocket_61_80mm:
			return "Rocket (61-80mm)";
		case Warhead.WarheadCaliber.Rocket_81_150mm:
			return "Rocket (81-150mm)";
		case Warhead.WarheadCaliber.Rocket_151_200mm:
			return "Rocket (151-200mm)";
		case Warhead.WarheadCaliber.Rocket_201_350mm:
			return "Rocket (201-350mm)";
		case Warhead.WarheadCaliber.Rocket_351_450mm:
			return "Rocket (351-450mm)";
		case Warhead.WarheadCaliber.Gun_6_15mm:
			return "Gun (6-15mm)";
		case Warhead.WarheadCaliber.Gun_16_24mm:
			return "Gun (16-24mm)";
		case Warhead.WarheadCaliber.Gun_25_60mm:
			return "Gun (25-60mm)";
		case Warhead.WarheadCaliber.Gun_61_80mm:
			return "Gun (61-80mm)";
		case Warhead.WarheadCaliber.Gun_81_150mm:
			return "Gun (81-150mm)";
		case Warhead.WarheadCaliber.Gun_151_200mm:
			return "Gun (151-200mm)";
		case Warhead.WarheadCaliber.Gun_201_350mm:
			return "Gun (201-350mm)";
		case Warhead.WarheadCaliber.Gun_351_450mm:
			return "Gun (351-450mm)";
		case Warhead.WarheadCaliber.None:
			return "无";
		}
	}

	internal static string TestRequest(GlobalVariables.ProficiencyLevel proficiencyLevel_0)
	{
		if (1 == 0)
		{
		}
		string result = proficiencyLevel_0 switch
		{
			GlobalVariables.ProficiencyLevel.Novice => "新手", 
			GlobalVariables.ProficiencyLevel.Cadet => "学生", 
			GlobalVariables.ProficiencyLevel.Regular => "一般", 
			GlobalVariables.ProficiencyLevel.Veteran => "熟练", 
			GlobalVariables.ProficiencyLevel.Ace => "高手", 
			_ => "错误！", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static bool StopRequest(IEnumerable<Weapon> ienumerable_0)
	{
		try
		{
			foreach (Weapon item in ienumerable_0)
			{
				if (item.IsNuke.Value)
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101097", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void ShuffleList<T>(IList<T> ilist_0)
	{
		int num = ilist_0.Count;
		while (num > 1)
		{
			num--;
			int index = GameGeneral.LockRandom_0.Next(num + 1);
			T value = ilist_0[index];
			ilist_0[index] = ilist_0[num];
			ilist_0[num] = value;
		}
	}

	public static string ToEnglishString(Sensor.DetectionAttemptType detectionAttemptType_0)
	{
		if (1 == 0)
		{
		}
		string result = detectionAttemptType_0 switch
		{
			Sensor.DetectionAttemptType.VolumeSearch => "搜索", 
			Sensor.DetectionAttemptType.SpecificTargetTracking => "SpecificTargetTrack", 
			Sensor.DetectionAttemptType.WeaponGuidance => "WeaponGuidance", 
			Sensor.DetectionAttemptType.Recon => "Recon", 
			_ => detectionAttemptType_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static string ToEnglishString(LoggedMessage.MessageType messageType_0)
	{
		if (1 == 0)
		{
		}
		string result = messageType_0 switch
		{
			LoggedMessage.MessageType.NewContact => "新目标", 
			LoggedMessage.MessageType.ContactChange => "目标变更", 
			LoggedMessage.MessageType.WeaponEndgame => "武器计算", 
			LoggedMessage.MessageType.WeaponDamage => "武器毁伤", 
			LoggedMessage.MessageType.AirOps => "空中行动", 
			LoggedMessage.MessageType.UnitLost => "单元损失", 
			LoggedMessage.MessageType.UnitDamage => "单元毁伤", 
			LoggedMessage.MessageType.PointDefence => "点防御", 
			LoggedMessage.MessageType.UI => "用户界面", 
			LoggedMessage.MessageType.WeaponLogic => "武器逻辑", 
			LoggedMessage.MessageType.UnitAI => "单元AI", 
			LoggedMessage.MessageType.EventEngine => "想定事件", 
			LoggedMessage.MessageType.NewWeaponContact => "新的武器目标", 
			LoggedMessage.MessageType.DockingOps => "停靠操作", 
			LoggedMessage.MessageType.SpecialMessage => "特殊消息", 
			LoggedMessage.MessageType.NewMineContact => "新雷场目标", 
			LoggedMessage.MessageType.CommsIsolatedMessage => "通信中断单元消息", 
			LoggedMessage.MessageType.NewAirContact => "新的空中目标", 
			LoggedMessage.MessageType.NewSurfaceContact => "新的水面目标", 
			LoggedMessage.MessageType.NewUnderwaterContact => "新的水下目标", 
			LoggedMessage.MessageType.NewGroundContact => "新的地面目标", 
			LoggedMessage.MessageType.UnguidedWeaponModifiers => "非制导武器精确度修正", 
			LoggedMessage.MessageType.const_23 => "条令与交战规则", 
			LoggedMessage.MessageType.Debug => "调试", 
			LoggedMessage.MessageType.UnitAIEmergency => "单元AI紧急事件", 
			_ => messageType_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static string ToEnglishString(IMobileGroundUnit._MobileUnitCategory _MobileUnitCategory_0)
	{
		switch (_MobileUnitCategory_0)
		{
		case IMobileGroundUnit._MobileUnitCategory.Infantry:
			return "步兵";
		case IMobileGroundUnit._MobileUnitCategory.None:
			return "无";
		case IMobileGroundUnit._MobileUnitCategory.Air_Assault:
			return "Air Assault";
		case IMobileGroundUnit._MobileUnitCategory.Marines:
			return "Naval Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Airborne:
			return "Airborne Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Mountain:
			return "Mountain Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Combined_Arms:
			return "Combined Arms";
		case IMobileGroundUnit._MobileUnitCategory.Special_Forces:
			return "Special Forces";
		case IMobileGroundUnit._MobileUnitCategory.Armor_Recon:
			return "Armor Recon";
		case IMobileGroundUnit._MobileUnitCategory.Armor:
			return "防护(Armor)";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
			return "Towed Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			return "炮兵";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Wheeled:
			return "Rocket Wheeled Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_SP:
			return "SP Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Mortar:
			return "Mortar Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked:
			return "Rocket Tracked Artillery";
		case IMobileGroundUnit._MobileUnitCategory.AAA:
			return "防空火炮(AAA)";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
			return "导弹炮兵";
		case IMobileGroundUnit._MobileUnitCategory.Engineer:
			return "工程师";
		case IMobileGroundUnit._MobileUnitCategory.SAM:
			return "地空导弹(SAM)";
		case IMobileGroundUnit._MobileUnitCategory.Surveillance:
			return "监控";
		case IMobileGroundUnit._MobileUnitCategory.Supply:
			return "Supply";
		case IMobileGroundUnit._MobileUnitCategory.Amphibious_Recon:
			return "Amphib Recon";
		case IMobileGroundUnit._MobileUnitCategory.Recon:
			return "Reconnaisance";
		case IMobileGroundUnit._MobileUnitCategory.MechMarines:
			return "Naval Mech Infantry";
		case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
			return "机械化步兵";
		case IMobileGroundUnit._MobileUnitCategory.MechWheeled:
			return "Wheeled Infantry";
		case IMobileGroundUnit._MobileUnitCategory.MechAirborne:
			return "Airborne Mech Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Anti_Tank:
			return "Anti-tank";
		case IMobileGroundUnit._MobileUnitCategory.Motorized_Infantry:
			return "Motorised Infantry";
		default:
			_ = Debugger.IsAttached;
			return _MobileUnitCategory_0.ToString();
		case IMobileGroundUnit._MobileUnitCategory.Headquarters:
			return "HQ";
		case IMobileGroundUnit._MobileUnitCategory.Radar:
			return "雷达";
		}
	}

	internal static string Description(Satellite._SatelliteType _SatelliteType_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT ST.Description from EnumSatelliteType as ST where ST.ID = " + Conversions.ToString((int)_SatelliteType_0));
	}

	internal static string Description(Satellite._SatelliteCategory _SatelliteCategory_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT SC.Description from EnumSatelliteCategory as SC where SC.ID = " + Conversions.ToString((int)_SatelliteCategory_0));
	}

	internal static float CancelRequest(IEnumerable<ActiveUnit> ienumerable_0)
	{
		try
		{
			float num = 1E+09f;
			foreach (ActiveUnit item in ienumerable_0)
			{
				float maximumAltitude = item.Kinematics.GetMaximumAltitude();
				if (maximumAltitude < num)
				{
					num = maximumAltitude;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101096", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal static int VerifyRequest(IEnumerable<ActiveUnit> ienumerable_0)
	{
		try
		{
			int num = 0;
			foreach (ActiveUnit item in ienumerable_0)
			{
				int num2 = (int)Math.Round(item.Kinematics.GetMinimumSpeed_Total(item.GetCurrentAltitude(), bool_0: false));
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101095", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal static string Description(Engine.EngineType engineType_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT PT.Description from EnumPropulsionType as PT where PT.ID = " + Conversions.ToString((int)engineType_0));
	}

	internal static string Description(FuelRec._FuelType _FuelType_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT FT.Description from EnumFuelType as FT where FT.ID = " + Conversions.ToString((int)_FuelType_0));
	}

	internal static string Description(Facility._FacilityCategory _FacilityCategory_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT FC.Description from EnumFacilityCategory as FC where FC.ID = " + Conversions.ToString((int)_FacilityCategory_0));
	}

	internal static string Description(Loadout._LoadoutDayNight _LoadoutDayNight_0)
	{
		if (1 == 0)
		{
		}
		string result = _LoadoutDayNight_0 switch
		{
			Loadout._LoadoutDayNight.DayNight => "白天/黑夜", 
			Loadout._LoadoutDayNight.NightOnly => "仅限夜晚", 
			Loadout._LoadoutDayNight.DayOnly => "仅限白天", 
			Loadout._LoadoutDayNight.None => "", 
			_ => "错误！", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string Description(Loadout._LoadoutWeather _LoadoutWeather_0)
	{
		if (1 == 0)
		{
		}
		string result = _LoadoutWeather_0 switch
		{
			Loadout._LoadoutWeather.AllWeather => "全天候", 
			Loadout._LoadoutWeather.LimitedAllWeather => "有限的全天候", 
			Loadout._LoadoutWeather.ClearWeather => "晴天", 
			Loadout._LoadoutWeather.None => "", 
			_ => "错误！", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string Description(Loadout.LoadoutRole loadoutRole_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT LR.Description from EnumLoadoutRole as LR where LR.ID = " + Conversions.ToString((int)loadoutRole_0));
	}

	internal static string Description(Aircraft._AircraftType _AircraftType_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT AT.Description from EnumAircraftType as AT where AT.ID = " + Conversions.ToString((int)_AircraftType_0));
	}

	internal static string Description(Aircraft._AircraftCategory _AircraftCategory_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT AC.Description from EnumAircraftCategory as AC where AC.ID = " + Conversions.ToString((int)_AircraftCategory_0));
	}

	internal static string Description(GlobalVariables.AircraftSizeClass aircraftSizeClass_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		int num = DBFunctions.ReflectList(aircraftSizeClass_0);
		return DBCache.GetScalar(sqliteHelper_, "SELECT APS.Description from EnumAircraftPhysicalSize as APS where APS.ID = " + Conversions.ToString(num));
	}

	internal static string Description(Ship._ShipType _ShipType_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT ST.Description from EnumShipType as ST where ST.ID = " + Conversions.ToString((int)_ShipType_0));
	}

	internal static string Description(Ship._ShipCategory _ShipCategory_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT ST.Description from EnumShipCategory as ST where ST.ID = " + Conversions.ToString((int)_ShipCategory_0));
	}

	internal static string Description(Submarine._SubmarineType _SubmarineType_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT ST.Description from EnumSubmarineType as ST where ST.ID = " + Conversions.ToString((int)_SubmarineType_0));
	}

	internal static string Description(Submarine._SubmarineCategory _SubmarineCategory_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT ST.Description from EnumSubmarineCategory as ST where ST.ID = " + Conversions.ToString((int)_SubmarineCategory_0));
	}

	internal static string Description(GlobalVariables.ArmorRating armorRating_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		if (armorRating_0 == GlobalVariables.ArmorRating.None)
		{
			return "无";
		}
		return DBCache.GetScalar(sqliteHelper_, "SELECT AT.Description from EnumArmorType as AT where AT.ID = " + Conversions.ToString((int)armorRating_0));
	}

	internal static string Description(DockFacility.DockingPhysicalSize dockingPhysicalSize_0, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "SELECT Description from EnumDockingFacilityPhysicalSize where ID = " + Conversions.ToString((int)dockingPhysicalSize_0));
	}

	internal static string Description(GlobalVariables.RunwayLengthClass runwayLengthClass_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string text = "EnumRunwayLength";
		if (DBOps.DBHasLegacyRunwayLengthEnum)
		{
			text = "EnumAircraftRunwayLength";
		}
		int num = DBFunctions.UpdateList(runwayLengthClass_0);
		return DBCache.GetScalar(sqliteHelper_, "SELECT ARL.Description from " + text + " as ARL where ARL.ID = " + Conversions.ToString(num));
	}

	internal static float ListRequest(IEnumerable<ActiveUnit> ienumerable_0)
	{
		try
		{
			float num = 0f;
			foreach (ActiveUnit item in ienumerable_0)
			{
				float minimumAltitude = item.Kinematics.GetMinimumAltitude();
				if (minimumAltitude > num)
				{
					num = minimumAltitude;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101094", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public static void AddOrUpdate(Dictionary<string, bool> dictionary_0, string string_0, bool bool_0)
	{
		if (dictionary_0.TryGetValue(string_0, out var _))
		{
			dictionary_0[string_0] = bool_0;
		}
		else
		{
			dictionary_0.Add(string_0, bool_0);
		}
	}

	internal static string ResolveRequest(string string_0)
	{
		try
		{
			int num = string_0.IndexOf(' ');
			if (num == -1)
			{
				return string_0;
			}
			return string_0.Substring(0, num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101088", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "错误！";
		}
	}

	internal static string PostRequest(ActiveUnit.Throttle throttle_0, object object_0)
	{
		switch (throttle_0)
		{
		default:
			return "未定义！";
		case ActiveUnit.Throttle.FullStop:
			if (((ScenarioObject)object_0).IsAircraft && ((Aircraft)object_0).GetCanHover(bool_1: false))
			{
				return "盘旋";
			}
			if (((ActiveUnit)object_0).AI.HoldPosition)
			{
				return "保持";
			}
			return "完全停止";
		case ActiveUnit.Throttle.Loiter:
			if (!((ScenarioObject)object_0).IsAircraft && !((ScenarioObject)object_0).IsMissile)
			{
				string text2 = "低速";
				if (((ActiveUnit)object_0).Kinematics.HasAdjustedSpeedForCavitation)
				{
					text2 += " - 无空泡";
				}
				return text2;
			}
			return "低速";
		case ActiveUnit.Throttle.Cruise:
		{
			string text3 = "巡航";
			if (((ActiveUnit)object_0).Kinematics.HasAdjustedSpeedForCavitation)
			{
				text3 += " - 无空泡";
			}
			return text3;
		}
		case ActiveUnit.Throttle.Full:
		{
			string text4 = "全速";
			if (((ActiveUnit)object_0).Kinematics.HasAdjustedSpeedForCavitation)
			{
				text4 += " - 无空泡";
			}
			return text4;
		}
		case ActiveUnit.Throttle.Flank:
			if (!((ScenarioObject)object_0).IsAircraft && !((ScenarioObject)object_0).IsMissile)
			{
				string text = "最大";
				if (((ActiveUnit)object_0).Kinematics.HasAdjustedSpeedForCavitation)
				{
					text += " - 无空泡";
				}
				return text;
			}
			return "加力";
		}
	}

	internal static string RunRequest(GlobalVariables.ActiveUnitType activeUnitType_0)
	{
		if (1 == 0)
		{
		}
		string result = activeUnitType_0 switch
		{
			GlobalVariables.ActiveUnitType.None => "无", 
			GlobalVariables.ActiveUnitType.Aircraft => "飞机", 
			GlobalVariables.ActiveUnitType.Ship => "舰船", 
			GlobalVariables.ActiveUnitType.Submarine => "潜艇", 
			GlobalVariables.ActiveUnitType.Facility => "设施", 
			GlobalVariables.ActiveUnitType.Aimpoint => "瞄准点", 
			GlobalVariables.ActiveUnitType.Weapon => "武器", 
			GlobalVariables.ActiveUnitType.Satellite => "卫星", 
			GlobalVariables.ActiveUnitType.Vehicle => "地面单元", 
			_ => throw new NotImplementedException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static XmlNode StartRequest(XmlNodeList xmlNodeList_0, string string_0)
	{
		try
		{
			int num = xmlNodeList_0.Count - 1;
			int num2 = 0;
			XmlNode xmlNode;
			while (true)
			{
				if (num2 <= num)
				{
					xmlNode = xmlNodeList_0[num2];
					if (string.CompareOrdinal(xmlNode.Name, string_0) == 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return null;
			}
			return xmlNode;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101093", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal static string AssetRequest(Stream stream_0)
	{
		long position = stream_0.Position;
		stream_0.Position = 0L;
		string result = new StreamReader(stream_0).ReadToEnd();
		stream_0.Position = position;
		return result;
	}

	internal static Geopoint_Struct Center(List<GeoPoint> list_0)
	{
		try
		{
			double num = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			_ = list_0.Count;
			int num8 = list_0.Count - 1;
			for (int i = 0; i <= num8; i++)
			{
				GeoPoint geoPoint = list_0[i];
				double num9 = 0.0174532925199433 * geoPoint.Latitude;
				double num10 = 0.0174532925199433 * geoPoint.Longitude;
				double num11 = Math.Cos(num9);
				double num12 = num11 * Math.Cos(num10);
				double num13 = num11 * Math.Sin(num10);
				double num2 = Math.Sin(num9);
				num += num12;
				num6 += num13;
				num7 += num2;
			}
			double num3 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num6, 2.0) + Math.Pow(num7, 2.0));
			num /= num3;
			num6 /= num3;
			num7 /= num3;
			double num4 = Math.Atan2(num6, num);
			double x = Math.Sqrt(num * num + num6 * num6);
			double num5 = Math.Atan2(num7, x);
			return new Geopoint_Struct(57.2957795130823 * num4, 57.2957795130823 * num5);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101332", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static Geopoint_Struct Center(object object_0)
	{
		try
		{
			double num = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			int num8 = ((Array)object_0).Length - 1;
			for (int i = 0; i <= num8; i++)
			{
				Geopoint_Struct geopoint_Struct = ((Geopoint_Struct[])object_0)[i];
				double num9 = 0.0174532925199433 * geopoint_Struct.Latitude;
				double num10 = 0.0174532925199433 * geopoint_Struct.Longitude;
				double num11 = Math.Cos(num9);
				double num12 = num11 * Math.Cos(num10);
				double num13 = num11 * Math.Sin(num10);
				double num2 = Math.Sin(num9);
				num += num12;
				num6 += num13;
				num7 += num2;
			}
			double num3 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num6, 2.0) + Math.Pow(num7, 2.0));
			num /= num3;
			num6 /= num3;
			num7 /= num3;
			double num4 = Math.Atan2(num6, num);
			double x = Math.Sqrt(num * num + num6 * num6);
			double num5 = Math.Atan2(num7, x);
			return new Geopoint_Struct(57.2957795130823 * num4, 57.2957795130823 * num5);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101332", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static Geopoint_Struct Center(List<Geopoint_Struct> list_0)
	{
		try
		{
			double num = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			int num8 = list_0.Count - 1;
			for (int i = 0; i <= num8; i++)
			{
				Geopoint_Struct geopoint_Struct = list_0[i];
				double num9 = 0.0174532925199433 * geopoint_Struct.Latitude;
				double num10 = 0.0174532925199433 * geopoint_Struct.Longitude;
				double num11 = Math.Cos(num9);
				double num12 = num11 * Math.Cos(num10);
				double num13 = num11 * Math.Sin(num10);
				double num2 = Math.Sin(num9);
				num += num12;
				num6 += num13;
				num7 += num2;
			}
			double num3 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num6, 2.0) + Math.Pow(num7, 2.0));
			num /= num3;
			num6 /= num3;
			num7 /= num3;
			double num4 = Math.Atan2(num6, num);
			double x = Math.Sqrt(num * num + num6 * num6);
			double num5 = Math.Atan2(num7, x);
			return new Geopoint_Struct(57.2957795130823 * num4, 57.2957795130823 * num5);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 103245324059", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static GeoPoint Center_bak(object object_0)
	{
		try
		{
			double num = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			int num8 = ((Array)object_0).Length - 1;
			for (int i = 0; i <= num8; i++)
			{
				GeoPoint geoPoint = (GeoPoint)((object[])object_0)[i];
				double num9 = 0.0174532925199433 * geoPoint.Latitude;
				double num10 = 0.0174532925199433 * geoPoint.Longitude;
				double num11 = Math.Cos(num9);
				double num12 = num11 * Math.Cos(num10);
				double num13 = num11 * Math.Sin(num10);
				double num2 = Math.Sin(num9);
				num += num12;
				num6 += num13;
				num7 += num2;
			}
			double num3 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num6, 2.0) + Math.Pow(num7, 2.0));
			num /= num3;
			num6 /= num3;
			num7 /= num3;
			double num4 = Math.Atan2(num6, num);
			double x = Math.Sqrt(num * num + num6 * num6);
			double num5 = Math.Atan2(num7, x);
			return new GeoPoint(57.2957795130823 * num4, 57.2957795130823 * num5);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101332", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GeoPoint result = new GeoPoint(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static Geopoint_Struct Center(List<ReferencePoint> list_0)
	{
		try
		{
			List<GeoPoint> list = new List<GeoPoint>();
			int num = list_0.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					list.Add(list_0[i]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			return Center(list);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101331", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static GeoPoint PrintRequest(List<GeoPoint> list_0)
	{
		try
		{
			if (Math2.PolygonCrossesAntimeridian(list_0))
			{
				List<GeoPoint> list = new List<GeoPoint>();
				foreach (GeoPoint item in list_0)
				{
					list.Add(new GeoPoint(Math2.VisitClass(item.Longitude + 180.0), item.Latitude));
				}
				if (Math2.PolygonCrossesAntimeridian(list))
				{
					double double_ = list.Select((GeoPoint theGP) => theGP.Latitude).Average();
					return new GeoPoint(list.Select((GeoPoint theGP) => theGP.Longitude).Average() + 180.0, double_);
				}
				Geopoint_Struct geopoint_Struct = Center(list);
				return new GeoPoint(Math2.VisitClass(geopoint_Struct.Longitude - 180.0), geopoint_Struct.Latitude);
			}
			int count = list_0.Count;
			double num = list_0.Select((GeoPoint theRP) => theRP.Latitude).Sum();
			return new GeoPoint(list_0.Select((GeoPoint theRP) => theRP.Longitude).Sum() / (double)count, num / (double)count);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101089", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GeoPoint result = new GeoPoint(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static GeoPoint DefineRequest(List<ReferencePoint> list_0)
	{
		try
		{
			if (Math2.PolygonCrossesAntimeridian(ref list_0))
			{
				List<GeoPoint> list = new List<GeoPoint>();
				foreach (ReferencePoint item in list_0)
				{
					list.Add(new GeoPoint(Math2.VisitClass(item.Longitude + 180.0), item.Latitude));
				}
				if (Math2.PolygonCrossesAntimeridian(list))
				{
					double double_ = list.Select((GeoPoint theGP) => theGP.Latitude).Average();
					return new GeoPoint(list.Select((GeoPoint theGP) => theGP.Longitude).Average() + 180.0, double_);
				}
				Geopoint_Struct geopoint_Struct = Center(list);
				return new GeoPoint(Math2.VisitClass(geopoint_Struct.Longitude - 180.0), geopoint_Struct.Latitude);
			}
			int count = list_0.Count;
			double num = list_0.Select((ReferencePoint theRP) => theRP.Latitude).Sum();
			return new GeoPoint(list_0.Select((ReferencePoint theRP) => theRP.Longitude).Sum() / (double)count, num / (double)count);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101090", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GeoPoint result = new GeoPoint(0.0, 0.0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static bool PublishRequest(List<ReferencePoint> list_0)
	{
		try
		{
			if (Math2.PolygonCrossesAntimeridian(ref list_0))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				foreach (ReferencePoint item in list_0)
				{
					list.Add(new Geopoint_Struct(Math2.VisitClass(item.Longitude + 180.0), item.Latitude));
				}
				return Math2.PolygonCrossesAntimeridian(list);
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101091", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static bool AwakeRequest(List<GeoPoint> list_0)
	{
		try
		{
			if (Math2.PolygonCrossesAntimeridian(list_0))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(list_0.Count);
				foreach (GeoPoint item in list_0)
				{
					list.Add(new Geopoint_Struct(Math2.VisitClass(item.Longitude + 180.0), item.Latitude));
				}
				return Math2.PolygonCrossesAntimeridian(list);
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101091", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static bool QueryRequest(List<Geopoint_Struct> list_0)
	{
		try
		{
			if (Math2.PolygonCrossesAntimeridian(list_0))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(list_0.Count);
				foreach (Geopoint_Struct item in list_0)
				{
					list.Add(new Geopoint_Struct(Math2.VisitClass(item.Longitude + 180.0), item.Latitude));
				}
				return Math2.PolygonCrossesAntimeridian(list);
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 121345698989", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static string ResetRequest(object object_0, string string_0)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(object_0.GetType().GetProperty(string_0).GetValue(object_0, null));
		if (objectValue == null)
		{
			return "";
		}
		return objectValue.ToString();
	}

	internal static string MapRequest(GlobalVariables.TechGenerationClass techGenerationClass_0)
	{
		if (1 == 0)
		{
		}
		string result = techGenerationClass_0 switch
		{
			GlobalVariables.TechGenerationClass.IR_SingleSpectral => "单光谱红外", 
			GlobalVariables.TechGenerationClass.IR_DualSpectral => "双光谱红外", 
			GlobalVariables.TechGenerationClass.IR_Imaging_FPA => "成像红外", 
			GlobalVariables.TechGenerationClass.Early1950s => "20世纪50年代初", 
			GlobalVariables.TechGenerationClass.Late1950s => "20世纪50年代末", 
			GlobalVariables.TechGenerationClass.Early1960s => "20世纪60年代初", 
			GlobalVariables.TechGenerationClass.Late1960s => "20世纪60年代末", 
			GlobalVariables.TechGenerationClass.Early1970s => "20世纪70年代初", 
			GlobalVariables.TechGenerationClass.Late1970s => "20世纪70年代末", 
			GlobalVariables.TechGenerationClass.Early1980s => "20世纪80年代初", 
			GlobalVariables.TechGenerationClass.Late1980s => "20世纪80年代末", 
			GlobalVariables.TechGenerationClass.Early1990s => "20世纪90年代", 
			GlobalVariables.TechGenerationClass.Late1990s => "90年代后期", 
			GlobalVariables.TechGenerationClass.Early2000s => "21世纪初", 
			GlobalVariables.TechGenerationClass.Late2000s => "2000年代后期", 
			GlobalVariables.TechGenerationClass.Early2010s => "2010年初", 
			GlobalVariables.TechGenerationClass.Late2010s => "2010年末", 
			GlobalVariables.TechGenerationClass.Late2020s => "2020年末", 
			GlobalVariables.TechGenerationClass.NotApplicable => "N/A", 
			_ => techGenerationClass_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string SortRequest(Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_0)
	{
		if (1 == 0)
		{
		}
		string result = missionAssignmentAttemptResult_0 switch
		{
			Mission.MissionAssignmentAttemptResult.Success => "Success", 
			Mission.MissionAssignmentAttemptResult.Fail_OutOfComms => "失败 - 单元通信连接已断开", 
			Mission.MissionAssignmentAttemptResult.Fail_Other => "失败 - 未定义原因", 
			_ => missionAssignmentAttemptResult_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string CalcRequest(ActiveUnit_Damage.FireIntensityLevel? nullable_0)
	{
		ActiveUnit_Damage.FireIntensityLevel? fireIntensityLevel = nullable_0;
		byte? b = (byte?)fireIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return "无火情";
		}
		b = (byte?)fireIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			return "小火灾";
		}
		b = (byte?)fireIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			return "大火灾";
		}
		b = (byte?)fireIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			return "严重火灾";
		}
		b = (byte?)fireIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			return "特大火灾";
		}
		return nullable_0.ToString();
	}

	internal static string RateRequest(ActiveUnit_Damage.FloodingIntensityLevel? nullable_0)
	{
		ActiveUnit_Damage.FloodingIntensityLevel? floodingIntensityLevel = nullable_0;
		byte? b = (byte?)floodingIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return "无漏水";
		}
		b = (byte?)floodingIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			return "轻微漏水";
		}
		b = (byte?)floodingIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			return "较多漏水";
		}
		b = (byte?)floodingIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			return "严重漏水";
		}
		b = (byte?)floodingIntensityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			return "即将崩溃";
		}
		return nullable_0.ToString();
	}

	internal static string FlushRequest(Contact.BDA_StructuralIntegrityLevel? nullable_0)
	{
		Contact.BDA_StructuralIntegrityLevel? bDA_StructuralIntegrityLevel = nullable_0;
		byte? b = (byte?)bDA_StructuralIntegrityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return "无损伤";
		}
		b = (byte?)bDA_StructuralIntegrityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			return "轻度损伤";
		}
		b = (byte?)bDA_StructuralIntegrityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			return "中等损伤";
		}
		b = (byte?)bDA_StructuralIntegrityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			return "重度损伤";
		}
		b = (byte?)bDA_StructuralIntegrityLevel;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			return "被摧毁";
		}
		return nullable_0.ToString();
	}

	internal static string ForgotRequest(Weapon._WeaponType _WeaponType_0)
	{
		if (1 == 0)
		{
		}
		string result = _WeaponType_0 switch
		{
			Weapon._WeaponType.GuidedWeapon => "制导武器", 
			Weapon._WeaponType.Rocket => "火箭弹", 
			Weapon._WeaponType.IronBomb => "无制导炸弹", 
			Weapon._WeaponType.Gun => "枪炮", 
			Weapon._WeaponType.Decoy_Expendable => "诱饵（消耗品）", 
			Weapon._WeaponType.Decoy_Towed => "诱饵（牵引）", 
			Weapon._WeaponType.Decoy_Vehicle => "诱饵（车辆）", 
			Weapon._WeaponType.TrainingRound => "训练设备", 
			Weapon._WeaponType.UAV_Expendable => "UAV (Expendable)", 
			Weapon._WeaponType.None => "无", 
			Weapon._WeaponType.Torpedo => "鱼雷", 
			Weapon._WeaponType.DepthCharge => "深水炸弹", 
			Weapon._WeaponType.Sonobuoy => "声呐浮标", 
			Weapon._WeaponType.BottomMine => "沉底水雷", 
			Weapon._WeaponType.MooredMine => "锚雷", 
			Weapon._WeaponType.FloatingMine => "水雷", 
			Weapon._WeaponType.MovingMine => "自航水雷", 
			Weapon._WeaponType.RisingMine => "上浮雷", 
			Weapon._WeaponType.DriftingMine => "漂雷", 
			Weapon._WeaponType.DummyMine => "教练雷", 
			Weapon._WeaponType.SensorPod => "传感器/电磁设备", 
			Weapon._WeaponType.DropTank => "副油箱", 
			Weapon._WeaponType.BuddyStore => "储备弹药", 
			Weapon._WeaponType.FerryTank => "机内附加油箱", 
			Weapon._WeaponType.RV => "再入飞行器", 
			Weapon._WeaponType.BallisticMissile => "弹道弹道", 
			Weapon._WeaponType.Cargo => "运输", 
			Weapon._WeaponType.Troops => "步兵", 
			Weapon._WeaponType.Paratroops => "空降部队", 
			Weapon._WeaponType.HGV => "HGV", 
			Weapon._WeaponType.Laser => "激光", 
			Weapon._WeaponType.Microwave => "Microwave (HPM)", 
			Weapon._WeaponType.LaserDazzler => "Laser Dazzler", 
			_ => _WeaponType_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string CollectRequest(GlobalVariables.TargetVisualSizeClass targetVisualSizeClass_0)
	{
		if (1 == 0)
		{
		}
		string result = targetVisualSizeClass_0 switch
		{
			GlobalVariables.TargetVisualSizeClass.Stealthy => "超小", 
			GlobalVariables.TargetVisualSizeClass.VSmall => "很小", 
			GlobalVariables.TargetVisualSizeClass.Small => "小号", 
			GlobalVariables.TargetVisualSizeClass.Medium => "中等", 
			GlobalVariables.TargetVisualSizeClass.Large => "大", 
			GlobalVariables.TargetVisualSizeClass.VLarge => "很大", 
			GlobalVariables.TargetVisualSizeClass.Unknown => "未知", 
			_ => targetVisualSizeClass_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static string ToEnglishString(ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, ActiveUnit activeUnit_0)
	{
		ActiveUnit._ActiveUnitFuelState fuelState = activeUnit_0.FuelState;
		ActiveUnit._ActiveUnitWeaponState weaponState = activeUnit_0.WeaponState;
		string text = "";
		switch (fuelState)
		{
		case ActiveUnit._ActiveUnitFuelState.IsBingo:
			text = "Bingo";
			break;
		case ActiveUnit._ActiveUnitFuelState.IsJoker:
			text = "滑稽角色";
			break;
		case ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker:
			text = "达到燃料/武器状态要求后返回基地命令取消";
			break;
		}
		switch (weaponState)
		{
		default:
			if (fuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker && weaponState == ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
			{
				text = "达到燃料/武器状态要求后返回基地命令取消";
			}
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsWinchester:
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				text += "和";
			}
			text += "温彻斯特";
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO:
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				text += "和";
			}
			text += "温彻斯特，攻击合适目标";
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsShotgun:
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				text += "和";
			}
			text += "滑膛枪";
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO:
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				text += "和";
			}
			text += "机炮，攻击合适目标";
			break;
		}
		if (Operators.CompareString(text, "", TextCompare: false) == 0 && activeUnit_0.AI.PrimaryPickupTarget != null)
		{
			text = "Pick up from " + activeUnit_0.AI.PrimaryPickupTarget.Name;
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			text = " (" + text + ")";
		}
		switch (_ActiveUnitStatus_0)
		{
		case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
			return "RTB (Exhaustion)";
		case ActiveUnit._ActiveUnitStatus.Unassigned:
		case ActiveUnit._ActiveUnitStatus.Manual_Unassigned:
			if (activeUnit_0.IsWeapon)
			{
				string text2 = "(none)";
				if (!Information.IsNothing(activeUnit_0.AI.PrimaryTarget))
				{
					if (Information.IsNothing(activeUnit_0.AI.PrimaryTarget.Name))
					{
						Contact contact = activeUnit_0.AI.PrimaryTarget.InitImporter(activeUnit_0.GetUnitSide());
						if (!Information.IsNothing(contact))
						{
							text2 = contact.Name;
						}
					}
					else
					{
						text2 = activeUnit_0.AI.PrimaryTarget.Name;
					}
				}
				return "Target " + text2;
			}
			return "未分配" + text;
		case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
			return "在规划路径中" + text;
		case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
			return "主动攻击" + text;
		case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
			return "被动攻击" + text;
		case ActiveUnit._ActiveUnitStatus.OnAttackRun:
			return "受攻击时逃避" + text;
		case ActiveUnit._ActiveUnitStatus.OnPatrol:
			return "在巡逻时" + text;
		case ActiveUnit._ActiveUnitStatus.RTB:
			return "返回基地" + text;
		case ActiveUnit._ActiveUnitStatus.Tasked:
			if (activeUnit_0.AI.IsEscort)
			{
				return "任务护航" + text;
			}
			return "任务完成任务" + text;
		case ActiveUnit._ActiveUnitStatus.FormingUp:
			return "形成编队队形" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_Manual:
			return "返回基地（按指令）" + text;
		case ActiveUnit._ActiveUnitStatus.OnSupportMission:
			return "支援任务" + text;
		case ActiveUnit._ActiveUnitStatus.OnFerryMission:
			return "转场任务" + text;
		case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
			return "前往加油点" + text;
		case ActiveUnit._ActiveUnitStatus.Refuelling:
			return "加油中" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
			return "返回基地（任务结束）" + text;
		case ActiveUnit._ActiveUnitStatus.GroupLead_SlowingToAllowFormUp:
			return "放慢速度（以形成编队）" + text;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return _ActiveUnitStatus_0.ToString();
		case ActiveUnit._ActiveUnitStatus.RTB_Group:
			return "返回基地（编队指令）" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
			return "返回基地（任务已取消）" + text;
		case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
			return "等待路径搜索";
		case ActiveUnit._ActiveUnitStatus.AttemptingToReestablishComms:
			return "尝试重建通信连接";
		case ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects:
			return "躲避武器影响" + text;
		}
	}

	public static void FormIntoGroups(List<ActiveUnit> list_0, Scenario scenario_0, Side side_0, GroupingLogic groupingLogic_0, Mission mission_0 = null, bool bool_0 = false)
	{
		try
		{
			if (list_0.Count < 2)
			{
				return;
			}
			foreach (ActiveUnit item in list_0)
			{
				if (item.GetParentGroup() != null)
				{
					item.SetParentGroup(bool_0: false, null);
				}
			}
			if ((from theAU in list_0
				select (theAU) into theAU
				where theAU.IsAircraft
				select theAU).Count() == list_0.Count)
			{
				switch (groupingLogic_0)
				{
				case GroupingLogic.MixedGroup:
				{
					Group group2 = new Group(ref scenario_0, ref side_0, list_0);
					if (mission_0 != null)
					{
						group2.Doctrine = mission_0.Doctrine;
					}
					break;
				}
				case GroupingLogic.SplitByType:
				{
					foreach (int item2 in list_0.Select((ActiveUnit AU) => ((Aircraft)AU).Int32_0).Distinct())
					{
						int Local_theInt = item2;
						List<ActiveUnit> list = new List<ActiveUnit>();
						foreach (ActiveUnit item3 in list_0.Where((ActiveUnit AC) => ((Aircraft)AC).Int32_0 == Local_theInt))
						{
							list.Add(item3);
						}
						if (list.Count > 1)
						{
							Group group = new Group(ref scenario_0, ref side_0, list);
							if (mission_0 != null)
							{
								group.Doctrine = mission_0.Doctrine;
							}
						}
					}
					break;
				}
				}
			}
			else
			{
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				list2.AddRange(list_0);
				Group group3 = new Group(ref scenario_0, ref side_0, list2);
				if (mission_0 != null)
				{
					group3.Doctrine = mission_0.Doctrine;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101092", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float TurnRadius(float float_1, float float_2)
	{
		return (float)((double)(float)((double)((float)((double)float_1 * 1.68780986) * (360f / float_2)) / 3.14159265358979 / 2.0) / 6076.11549);
	}

	internal static List<List<GraphicsPath>> OrderRequest(List<GraphicsPath> list_0, int int_0 = 30)
	{
		List<List<GraphicsPath>> list = new List<List<GraphicsPath>>();
		for (int i = 0; i < list_0.Count; i += int_0)
		{
			list.Add(list_0.GetRange(i, Math.Min(int_0, list_0.Count - i)));
		}
		return list;
	}

	internal static List<List<Point[]>> RegisterRequest(List<Point[]> list_0, int int_0 = 30)
	{
		List<List<Point[]>> list = new List<List<Point[]>>();
		for (int i = 0; i < list_0.Count; i += int_0)
		{
			list.Add(list_0.GetRange(i, Math.Min(int_0, list_0.Count - i)));
		}
		return list;
	}

	internal static bool ManageRequest(object object_0, object object_1, object object_2, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1)
	{
		float num = (float)Math.Sqrt(0.0);
		double double_ = 0.0;
		double double_2 = 0.0;
		double num2 = 0.0;
		if (num2 < (double)(num * num))
		{
			geoPoint_0 = null;
			geoPoint_1 = null;
			return false;
		}
		double num3 = Math.Sqrt(num2 - (double)(num * num));
		RevertRequest(0.0, 0.0, num, double_2, double_, (float)num3, ref geoPoint_0, ref geoPoint_1);
		MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(geoPoint_0.Longitude, geoPoint_0.Latitude);
		MercatorProjection.TCoord tCoord2 = MercatorProjection.toGeoCoord(geoPoint_1.Longitude, geoPoint_1.Latitude);
		geoPoint_0.Longitude = tCoord.Lon;
		geoPoint_0.Latitude = tCoord.Lat;
		geoPoint_1.Longitude = tCoord2.Lon;
		geoPoint_1.Latitude = tCoord2.Lat;
		return true;
	}

	private static int RevertRequest(double double_0, double double_1, float float_1, double double_2, double double_3, float float_2, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1)
	{
		double num = double_0 - double_2;
		double num2 = double_1 - double_3;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		if (num3 <= (double)(float_1 + float_2))
		{
			if (num3 < (double)Math.Abs(float_1 - float_2))
			{
				geoPoint_0 = new GeoPoint(double.NaN, double.NaN);
				geoPoint_1 = new GeoPoint(double.NaN, double.NaN);
				return 0;
			}
			if (num3 == 0.0 && float_1 == float_2)
			{
				geoPoint_0 = new GeoPoint(double.NaN, double.NaN);
				geoPoint_1 = new GeoPoint(double.NaN, double.NaN);
				return 0;
			}
			double num4 = ((double)(float_1 * float_1 - float_2 * float_2) + num3 * num3) / (2.0 * num3);
			double num5 = Math.Sqrt((double)(float_1 * float_1) - num4 * num4);
			double num6 = double_0 + num4 * (double_2 - double_0) / num3;
			double num7 = double_1 + num4 * (double_3 - double_1) / num3;
			geoPoint_0 = new GeoPoint((float)(num6 + num5 * (double_3 - double_1) / num3), (float)(num7 - num5 * (double_2 - double_0) / num3));
			geoPoint_1 = new GeoPoint((float)(num6 - num5 * (double_3 - double_1) / num3), (float)(num7 + num5 * (double_2 - double_0) / num3));
			if (num3 == (double)(float_1 + float_2))
			{
				return 1;
			}
			return 2;
		}
		geoPoint_0 = new GeoPoint(double.NaN, double.NaN);
		geoPoint_1 = new GeoPoint(double.NaN, double.NaN);
		return 0;
	}

	internal static TurnDirection CountValue(float float_1, float float_2)
	{
		float_2 = Math2.UpdateClass(float_2 - float_1);
		float_1 = 0f;
		if (float_2 <= 180f)
		{
			return TurnDirection.TurnRight;
		}
		return TurnDirection.TurnLeft;
	}

	internal static bool CustomizeValue(string string_0, string string_1, StringComparison stringComparison_0)
	{
		return string_0.IndexOf(string_1, stringComparison_0) >= 0;
	}

	internal unsafe static T[] CloneValue<T>(Array array_0, Array array_1)
	{
		int destinationIndex = array_0.Length;
		Array.Resize(ref *(T[]*)(&array_0), array_0.Length + array_1.Length);
		Array.Copy(array_1, 0, array_0, destinationIndex, array_1.Length);
		return (T[])array_0;
	}

	internal static T[] ConnectValue<T>(Array array_0, Array array_1)
	{
		T[] array = new T[array_0.Length + array_1.Length - 1 + 1];
		Buffer.BlockCopy(array_0, 0, array, 0, array_0.Length);
		Buffer.BlockCopy(array_1, 0, array, array_0.Length, array_1.Length);
		return array;
	}

	internal static int[] MoveValue(Array array_0, Array array_1)
	{
		int[] array = new int[array_0.Length + array_1.Length - 1 + 1];
		Buffer.BlockCopy(array_0, 0, array, 0, array_0.Length);
		Buffer.BlockCopy(array_1, 0, array, array_0.Length, array_1.Length);
		return array;
	}

	internal static long DeleteValue(int int_0)
	{
		int num = 0;
		long location = 2L;
		while (num < int_0)
		{
			long num2 = 2L;
			int num3 = 1;
			for (; num2 * num2 <= location; num2++)
			{
				if (location % num2 == 0)
				{
					num3 = 0;
					break;
				}
			}
			if (num3 > 0)
			{
				num++;
			}
			location++;
		}
		return Interlocked.Decrement(ref location);
	}

	internal static List<T>[] AddValue<T>(List<T> list_0, int int_0)
	{
		if (list_0 == null)
		{
			throw new ArgumentNullException("list");
		}
		if (int_0 < 1)
		{
			throw new ArgumentOutOfRangeException("totalPartitions");
		}
		int count = list_0.Count;
		List<T>[] array = new List<T>[int_0 - 1 + 1];
		int num = (int)Math.Ceiling((double)count / (double)int_0);
		int num2 = 0;
		int num3 = array.Length - 1;
		for (int i = 0; i <= num3; i++)
		{
			array[i] = new List<T>();
			int num4 = num2;
			int num5 = num2 + num - 1;
			for (int j = num4; j <= num5 && j < count; j++)
			{
				array[i].Add(list_0[j]);
			}
			num2 += num;
		}
		return array;
	}

	internal static string DestroyValue(ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker resultOfAttemptToRendezvousWithTanker_0)
	{
		if (1 == 0)
		{
		}
		string result = resultOfAttemptToRendezvousWithTanker_0 switch
		{
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.None => "无", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success => "Success", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_Unknown => "失败 - 未知原因", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer => "失败 - 无合适油料或储备需运输", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_CannotIntercept => "失败 - 无法与提供者汇合", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_ProviderSmallerThanReceiver => "失败 - 提供者比接收者小，不是合适的补给平台", 
			_ => resultOfAttemptToRendezvousWithTanker_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static List<ActiveUnit> ComputeValue(HashSet<ActiveUnit> hashSet_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>(hashSet_0.Count);
		HashSet<ActiveUnit>.Enumerator enumerator = hashSet_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			list.Add(enumerator.Current);
		}
		return list;
	}

	public static Group GetByName(List<Group> list_0, string string_0)
	{
		foreach (Group item in list_0)
		{
			if (string.CompareOrdinal(item.Name, string_0) == 0)
			{
				return item;
			}
		}
		return null;
	}

	public static bool ContainsByName(List<Group> list_0, string string_0)
	{
		foreach (Group item in list_0)
		{
			if (string.CompareOrdinal(item.Name, string_0) == 0)
			{
				return true;
			}
		}
		return false;
	}

	internal static string PatchValue(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = string_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			char c = string_0[i];
			if (Operators.CompareString(Conversions.ToString(c), "*", TextCompare: false) != 0 && Operators.CompareString(Conversions.ToString(c), "%", TextCompare: false) != 0 && Operators.CompareString(Conversions.ToString(c), "[", TextCompare: false) != 0 && Operators.CompareString(Conversions.ToString(c), "]", TextCompare: false) != 0)
			{
				if (Operators.CompareString(Conversions.ToString(c), "\\'", TextCompare: false) == 0)
				{
					stringBuilder.Append("''");
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			else
			{
				stringBuilder.Append("[").Append(c).Append("]");
			}
		}
		return stringBuilder.ToString();
	}

	internal static bool SelectValue(string string_0)
	{
		if (!string_0.StartsWith("/") && !string_0.StartsWith("\\"))
		{
			return new DriveInfo(Path.GetPathRoot(string_0)).DriveType == DriveType.Network;
		}
		return true;
	}

	internal static List<string> CallValue(string string_0, int int_0, bool bool_0 = false)
	{
		List<string> list = new List<string>();
		string text = "";
		list.Add("");
		foreach (char c in string_0)
		{
			if (Operators.CompareString(Conversions.ToString(c), " ", TextCompare: false) == 0)
			{
				list[list.Count - 1] += text;
				text = "";
				list[list.Count - 1] += " ";
			}
			else
			{
				text += Conversions.ToString(c);
			}
			if (list[list.Count - 1].Length + text.Length > int_0 - 1)
			{
				list.Add(text);
				text = "";
			}
		}
		if (list.Count == 1)
		{
			list[0] += text;
			return list;
		}
		if (text.Length > 0)
		{
			list.Add(text);
		}
		return list;
	}

	internal static Image LogoutValue(string string_0)
	{
		using MemoryTributary stream = new MemoryTributary(File.ReadAllBytes(string_0));
		return Image.FromStream(stream, useEmbeddedColorManagement: false, validateImageData: false);
	}

	internal static int ViewValue(DateTime dateTime_0)
	{
		DayOfWeek dayOfWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime_0);
		if (dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Wednesday)
		{
			dateTime_0 = dateTime_0.AddDays(3.0);
		}
		return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime_0, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
	}

	public static void FormatXML_DiskFile(string string_0)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(string_0);
			xmlDocument.Save(new XmlTextWriter(string_0, Encoding.UTF8)
			{
				Formatting = Formatting.Indented
			});
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

	internal static string ValidateValue(float float_1, int int_0, Game.GamePreferences.SpeedUnitSetting speedUnitSetting_0)
	{
		if (1 == 0)
		{
		}
		string result = speedUnitSetting_0 switch
		{
			Game.GamePreferences.SpeedUnitSetting.Knots => Conversions.ToString(Math.Round(float_1, int_0)) + " 节", 
			Game.GamePreferences.SpeedUnitSetting.KPH => Conversions.ToString(Math.Round((double)float_1 * 1.852, int_0)) + " KPH", 
			Game.GamePreferences.SpeedUnitSetting.MPH => Conversions.ToString(Math.Round((double)float_1 * 1.15078, int_0)) + " MPH", 
			_ => Conversions.ToString(Math.Round(float_1, 0)) + " 节", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static int LoginValue(DateTime dateTime_0)
	{
		return (dateTime_0.Hour * 60 + dateTime_0.Minute) * 60 + dateTime_0.Second;
	}
}
