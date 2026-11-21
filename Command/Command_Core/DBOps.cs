using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;

namespace Command_Core;

[StandardModule]
public sealed class DBOps
{
	public delegate void DBLoadingCompleteEventHandler();

	public enum DatabaseMatchToleranceLevel : short
	{
		Undefined,
		ExactVersion,
		SameFamily,
		CompletelyNoMatch,
		UnableToCompare
	}

	public enum DBFileCheckResult
	{
		Undefined = 0,
		AllOK = 1,
		DBFileNotPresent = 2,
		DBIsUnregistered = 3,
		DBFileIsTampered = 4,
		UnspecifiedError = 9999
	}

	[CompilerGenerated]
	private sealed class ProccesorComparator
	{
		public int Local_theDB;

		internal bool MoveInterruptibleField(DBRecord theDBR)
		{
			if (theDBR.DBID == Local_theDB)
			{
				return theDBR.LocalCopyExists;
			}
			return false;
		}
	}

	private static DataRow readerIssuer;

	private static DataRow _PropertyIssuer;

	public static SQLiteConnection Conn_FileDB;

	[CompilerGenerated]
	[AccessedThroughProperty("_RegisteredDBs")]
	private static ObservableDictionary<string, DBRecord> m_ImporterIssuer;

	public static bool DBScanComplete_Registered;

	public static bool DBHasLegacyRunwayLengthEnum;

	private static XmlDocument repositoryIssuer;

	private static FileSystemWatcher _BridgeIssuer;

	public static bool DisableLongRunningDBCheck;

	[CompilerGenerated]
	private static DBLoadingCompleteEventHandler invocationIssuer;

	public static event DBLoadingCompleteEventHandler DBLoadingComplete
	{
		[CompilerGenerated]
		add
		{
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler = invocationIssuer;
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler2;
			do
			{
				dBLoadingCompleteEventHandler2 = dBLoadingCompleteEventHandler;
				DBLoadingCompleteEventHandler value2 = (DBLoadingCompleteEventHandler)Delegate.Combine(dBLoadingCompleteEventHandler2, value);
				dBLoadingCompleteEventHandler = Interlocked.CompareExchange(ref invocationIssuer, value2, dBLoadingCompleteEventHandler2);
			}
			while ((object)dBLoadingCompleteEventHandler != dBLoadingCompleteEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler = invocationIssuer;
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler2;
			do
			{
				dBLoadingCompleteEventHandler2 = dBLoadingCompleteEventHandler;
				DBLoadingCompleteEventHandler value2 = (DBLoadingCompleteEventHandler)Delegate.Remove(dBLoadingCompleteEventHandler2, value);
				dBLoadingCompleteEventHandler = Interlocked.CompareExchange(ref invocationIssuer, value2, dBLoadingCompleteEventHandler2);
			}
			while ((object)dBLoadingCompleteEventHandler != dBLoadingCompleteEventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void OrderImporter(ObservableDictionary<string, DBRecord> observableDictionary_0)
	{
		INotifyDictionaryChanged<string, DBRecord>.DictionaryChangedEventHandler val = DefineImporter;
		ObservableDictionary<string, DBRecord> importerIssuer = m_ImporterIssuer;
		if (importerIssuer != null)
		{
			importerIssuer.DictionaryChanged -= val;
		}
		m_ImporterIssuer = observableDictionary_0;
		importerIssuer = m_ImporterIssuer;
		if (importerIssuer != null)
		{
			importerIssuer.DictionaryChanged += val;
		}
	}

	static DBOps()
	{
		OrderImporter(new ObservableDictionary<string, DBRecord>());
		DBScanComplete_Registered = false;
		DBHasLegacyRunwayLengthEnum = false;
		DisableLongRunningDBCheck = false;
	}

	public static DatabaseMatchToleranceLevel smethod_0(string string_0, string string_1)
	{
		if (Operators.CompareString(string_0, string_1, TextCompare: false) == 0)
		{
			return DatabaseMatchToleranceLevel.ExactVersion;
		}
		DBFileCheckResult dbfileCheckResult_ = DBFileCheckResult.Undefined;
		DBRecord dBRecordByHash = GetDBRecordByHash(string_0, ref dbfileCheckResult_, bool_0: false, bool_1: false);
		if (dBRecordByHash == null)
		{
			return DatabaseMatchToleranceLevel.UnableToCompare;
		}
		DBRecord dBRecordByHash2 = GetDBRecordByHash(string_1, ref dbfileCheckResult_, bool_0: false, bool_1: false);
		if (dBRecordByHash2 == null)
		{
			return DatabaseMatchToleranceLevel.UnableToCompare;
		}
		if (dBRecordByHash.DBID == dBRecordByHash2.DBID)
		{
			return DatabaseMatchToleranceLevel.SameFamily;
		}
		return DatabaseMatchToleranceLevel.CompletelyNoMatch;
	}

	public static ReadOnlyCollection<DBRecord> RegisteredDBs()
	{
		return new List<DBRecord>(m_ImporterIssuer.Values).AsReadOnly();
	}

	public static ReadOnlyCollection<DBRecord> UnregisteredDBs()
	{
		return null;
	}

	public static void AddUnregisteredDB(string string_0, DBRecord dbrecord_0)
	{
	}

	private static void DefineImporter(object sender, NotifyDictionaryChangedEventArgs<string, DBRecord> e)
	{
	}

	public static void ScanDatabases()
	{
		_ = MerchantMerchantPage.LogoutList.Info.DirectoryPath;
		ForgotImporter();
		DBScanComplete_Registered = true;
		MapImporter();
		invocationIssuer?.Invoke();
	}

	internal static string PublishImporter(DBFileCheckResult dbfileCheckResult_0)
	{
		switch (dbfileCheckResult_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return dbfileCheckResult_0.ToString();
		case DBFileCheckResult.UnspecifiedError:
			return "未指定的错误";
		case DBFileCheckResult.Undefined:
			return "未定义的结果";
		case DBFileCheckResult.AllOK:
			return "一切正常";
		case DBFileCheckResult.DBFileNotPresent:
			return "未找到数据库文件 - 请与数据库作者联系以获取此版本数据库的副本";
		case DBFileCheckResult.DBIsUnregistered:
			return "数据库未注册";
		case DBFileCheckResult.DBFileIsTampered:
			return "数据库文件已被篡改";
		}
	}

	private static XmlDocument AwakeImporter()
	{
		if (repositoryIssuer == null)
		{
			if (FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.DBFolderPath, "DBInfo.dat")))
			{
				StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "DBInfo.dat"));
				string string_;
				using (streamReader)
				{
					string_ = streamReader.ReadToEnd();
				}
				string_ = Crypto.ListImporter(string_);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_);
				repositoryIssuer = xmlDocument;
				return xmlDocument;
			}
			return null;
		}
		return repositoryIssuer;
	}

	internal static bool QueryImporter(object object_0)
	{
		return false;
	}

	public static DBRecord GetDBRecordByHash(string string_0, ref DBFileCheckResult dbfileCheckResult_0, bool bool_0 = true, bool bool_1 = true)
	{
		try
		{
			DBRecord dBRecord = null;
			if (m_ImporterIssuer.ContainsKey(string_0))
			{
				dBRecord = m_ImporterIssuer[string_0];
				if (bool_0 && !dBRecord.LocalCopyExists)
				{
					dbfileCheckResult_0 = DBFileCheckResult.DBFileNotPresent;
					return null;
				}
				if (bool_1)
				{
				}
				if (dBRecord.DBID == 0)
				{
					SQLiteHelper sQLiteHelper = new SQLiteHelper(new SQLiteConnection(smethod_1(MerchantMerchantPage.LogoutList.Info.DirectoryPath, string_0)));
					string string_ = "SELECT Name FROM DataComm where ID = 3";
					SQLiteDataReader val = sQLiteHelper.DestroySpecification(string_);
					string left = "";
					((DbDataReader)val).Read();
					if (((DbDataReader)val)[0] != null)
					{
						left = ((DbDataReader)val)[0].ToString();
					}
					((DbDataReader)val).Close();
					if (Operators.CompareString(left, "AS.20 Command Datalink", TextCompare: false) == 0)
					{
						dBRecord.DBID = 2;
					}
					else if (Operators.CompareString(left, "SA-10 Missile Datalink", TextCompare: false) == 0)
					{
						dBRecord.DBID = 1;
					}
				}
				dbfileCheckResult_0 = DBFileCheckResult.AllOK;
				return dBRecord;
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
			dbfileCheckResult_0 = DBFileCheckResult.UnspecifiedError;
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static (DBRecord, DBFileCheckResult) GetDBRecordByFilename(string string_0, bool bool_0)
	{
		(DBRecord, DBFileCheckResult) result;
		try
		{
			foreach (DBRecord dbrecord in m_ImporterIssuer.Values)
			{
				if (string.Equals(dbrecord.FileName, Path.GetFileName(string_0), StringComparison.OrdinalIgnoreCase))
				{
					return (dbrecord, DBFileCheckResult.AllOK);
				}
			}
			result = (null, DBFileCheckResult.DBFileNotPresent);
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (null, DBFileCheckResult.UnspecifiedError);
		}
		return result;
	}

	public static bool DBIsRegistered(string string_0)
	{
		return m_ImporterIssuer.ContainsKey(string_0);
	}

	public static string GetHashForMostRecentVersionOfThisDB(int int_0)
	{
		while (m_ImporterIssuer.Count == 0)
		{
			Thread.Sleep(100);
		}
		try
		{
			DBRecord dBRecord = (from theDBR in RegisteredDBs()
				where theDBR.DBID == int_0 && theDBR.LocalCopyExists
				select theDBR).FirstOrDefault();
			if (dBRecord != null)
			{
				return dBRecord.Hash;
			}
			Dictionary<string, DBRecord> dictionary = new Dictionary<string, DBRecord>();
			foreach (KeyValuePair<string, DBRecord> item in m_ImporterIssuer)
			{
				dictionary.Add(item.Key, item.Value);
			}
			foreach (KeyValuePair<string, DBRecord> item2 in dictionary.OrderByDescending((KeyValuePair<string, DBRecord> theKVP) => new FileInfo(Path.Combine(GameGeneral.DBFolderPath, theKVP.Value.FileName)).LastWriteTime))
			{
				if (item2.Value.DBID == int_0 && item2.Value.LocalCopyExists)
				{
					return item2.Key;
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
			ProjectData.ClearProjectError();
		}
		throw new Exception("没有找到此ID号的数据库版本！");
	}

	public static string smethod_1(string string_0, string string_1)
	{
		bool flag = false;
		DBRecord dBRecord = null;
		try
		{
			if (m_ImporterIssuer.ContainsKey(string_1))
			{
				flag = true;
				dBRecord = m_ImporterIssuer[string_1];
			}
			if (dBRecord == null)
			{
				throw new DBFileNotFoundException("您（显式或隐式）尝试加载DB文件夹中不存在的数据库。");
			}
			if (!dBRecord.LocalCopyExists)
			{
				string text = "尝试加载的数据库（" + dBRecord.DBName + "）在DB目录中不存在。";
				text = (flag ? (text + "数据库以以下名称注册：" + dBRecord.DBName + "。请联系该数据库的作者获取副本。") : (text + "数据库未注册，文件哈希：" + string_1 + "。请联系数据库作者，看看他们的任何数据库版本是否与此哈希相对应，以便获取它。"));
				throw new DBFileNotFoundException(text);
			}
			return dBRecord.ConnectionString;
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

	private static void ResetImporter()
	{
	}

	private static void MapImporter()
	{
		_BridgeIssuer = new FileSystemWatcher();
		_BridgeIssuer.Path = GameGeneral.DBFolderPath;
		_BridgeIssuer.IncludeSubdirectories = false;
		_BridgeIssuer.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
		_BridgeIssuer.Filter = "*.db3";
		_BridgeIssuer.Changed += RateImporter;
		_BridgeIssuer.Created += CalcImporter;
		_BridgeIssuer.Renamed += SortImporter;
		_BridgeIssuer.EnableRaisingEvents = true;
	}

	private static void SortImporter(object sender, FileSystemEventArgs e)
	{
		FlushImporter(e.Name);
	}

	private static void CalcImporter(object sender, FileSystemEventArgs e)
	{
		FlushImporter(e.Name);
	}

	private static void RateImporter(object sender, FileSystemEventArgs e)
	{
		FlushImporter(e.Name);
	}

	private static void FlushImporter(string string_0)
	{
		if (!string_0.EndsWith(".db3"))
		{
			return;
		}
		foreach (DBRecord item in m_ImporterIssuer.Values.ToList())
		{
			if (Operators.CompareString(item.FileName, Path.GetFileName(string_0), TextCompare: false) == 0 && Operators.CompareString(Crypto.GetFileHashFromFilename(Path.Combine(GameGeneral.DBFolderPath, item.FileName)), item.Hash, TextCompare: false) != 0)
			{
				Exception exception_ = new Exception("DB integrity check failed for DB file: " + item.FileName + ". Program will now exit.");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				Environment.Exit(0);
			}
		}
	}

	private static void ForgotImporter()
	{
		m_ImporterIssuer.Clear();
		m_ImporterIssuer.Add("bf56914414bfb6c27f358cd41cac597388604ce4", new DBRecord(2, "bf56914414bfb6c27f358cd41cac597388604ce4", "Cold War DB v505", "CWDB_505.db3", bool_0: true));
		m_ImporterIssuer.Add("e6f46f4b1497aea6fd75bbb2aaafc5e155906700", new DBRecord(1, "e6f46f4b1497aea6fd75bbb2aaafc5e155906700", "DB3000 v505", "DB3K_505.db3", bool_0: true));
		m_ImporterIssuer.Add("24ac7c450f8fe53cb8702aeae422aa6ed6f1d569", new DBRecord(2, "24ac7c450f8fe53cb8702aeae422aa6ed6f1d569", "Cold War DB v504", "CWDB_504.db3", bool_0: true));
		m_ImporterIssuer.Add("1e0f7bd989b26b132f7ba0ba01b8c12da819ca64", new DBRecord(1, "1e0f7bd989b26b132f7ba0ba01b8c12da819ca64", "DB3000 v504", "DB3K_504.db3", bool_0: true));
		m_ImporterIssuer.Add("b19034375a41170519b8282bc14a87038d47d585", new DBRecord(2, "b19034375a41170519b8282bc14a87038d47d585", "Cold War DB v503", "CWDB_503.db3", bool_0: true));
		m_ImporterIssuer.Add("ae3ab5a26ebbd32ff52b97e61d86e897c13545ce", new DBRecord(1, "ae3ab5a26ebbd32ff52b97e61d86e897c13545ce", "DB3000 v503", "DB3K_503.db3", bool_0: true));
		m_ImporterIssuer.Add("72afb353ac2e805a593386198ea8cf7c7ebab6f1", new DBRecord(2, "72afb353ac2e805a593386198ea8cf7c7ebab6f1", "Cold War DB v502", "CWDB_502.db3", bool_0: true));
		m_ImporterIssuer.Add("9808e0c1b7d8384f5e3a55e97b22a047fc23056c", new DBRecord(1, "9808e0c1b7d8384f5e3a55e97b22a047fc23056c", "DB3000 v502", "DB3K_502.db3", bool_0: true));
		m_ImporterIssuer.Add("2d8b74305f86e13fe1ac0c8c450e14ea9993f616", new DBRecord(2, "2d8b74305f86e13fe1ac0c8c450e14ea9993f616", "Cold War DB v501", "CWDB_501.db3", bool_0: true));
		m_ImporterIssuer.Add("4bd100793c6128c6ab2524e20b6ac0abcf45219c", new DBRecord(1, "4bd100793c6128c6ab2524e20b6ac0abcf45219c", "DB3000 v501", "DB3K_501.db3", bool_0: true));
		m_ImporterIssuer.Add("0287bd975dc24ff6dedf2eaf32a2b6ea7ca194b3", new DBRecord(2, "0287bd975dc24ff6dedf2eaf32a2b6ea7ca194b3", "Cold War DB v500", "CWDB_500.db3", bool_0: true));
		m_ImporterIssuer.Add("32b334eca811cd7277b8ff04a1329a76164c5cd6", new DBRecord(1, "32b334eca811cd7277b8ff04a1329a76164c5cd6", "DB3000 v500", "DB3K_500.db3", bool_0: true));
		m_ImporterIssuer.Add("6167e080e25a1e1d717e190ebade2b8d493dea35", new DBRecord(2, "6167e080e25a1e1d717e190ebade2b8d493dea35", "Cold War DB v499", "CWDB_499.db3", bool_0: true));
		m_ImporterIssuer.Add("4eb6c0374fe9544093cc3709590504659a760b63", new DBRecord(1, "4eb6c0374fe9544093cc3709590504659a760b63", "DB3000 v499", "DB3K_499.db3", bool_0: true));
		m_ImporterIssuer.Add("dd2e1df88867fe83c69f2dab4d3613f1280bd86e", new DBRecord(1, "dd2e1df88867fe83c69f2dab4d3613f1280bd86e", "DB3000 v498a", "DB3K_498a.db3", bool_0: true));
		m_ImporterIssuer.Add("dee1efb6e712e11f8ab23a375288072110f55e5c", new DBRecord(2, "dee1efb6e712e11f8ab23a375288072110f55e5c", "Cold War DB v498", "CWDB_498.db3", bool_0: true));
		m_ImporterIssuer.Add("1707b7612750553b77917fecb3ed84bcbab4b92e", new DBRecord(1, "1707b7612750553b77917fecb3ed84bcbab4b92e", "DB3000 v498", "DB3K_498.db3", bool_0: true));
		m_ImporterIssuer.Add("6f5f4f94b0810006008398394f161d3e5833e539", new DBRecord(1, "6f5f4f94b0810006008398394f161d3e5833e539", "DB3000 v497a", "DB3K_497a.db3", bool_0: true));
		m_ImporterIssuer.Add("ed5b39742437472aa6ff43c02ed56fd6eff65511", new DBRecord(1, "ed5b39742437472aa6ff43c02ed56fd6eff65511", "DB3000 v497", "DB3K_497.db3", bool_0: true));
		m_ImporterIssuer.Add("25194d37a18c34bc5dc5dfa69b48e9b2d5584b86", new DBRecord(2, "25194d37a18c34bc5dc5dfa69b48e9b2d5584b86", "Cold War DB v497", "CWDB_497.db3", bool_0: true));
		m_ImporterIssuer.Add("0512e27f11561bdd39b6aa189d792d115ca03f51", new DBRecord(1, "0512e27f11561bdd39b6aa189d792d115ca03f51", "DB3000 v496", "DB3K_496.db3", bool_0: true));
		m_ImporterIssuer.Add("d565fe1f16dd3c3a7b652efbbff10ad4654b45da", new DBRecord(2, "d565fe1f16dd3c3a7b652efbbff10ad4654b45da", "Cold War DB v496", "CWDB_496.db3", bool_0: true));
		m_ImporterIssuer.Add("b383294e8525920ba56f90cc4c61d6a3d86781e0", new DBRecord(1, "b383294e8525920ba56f90cc4c61d6a3d86781e0", "DB3000 v495", "DB3K_495.db3", bool_0: true));
		m_ImporterIssuer.Add("07230c2d0242787a5f69888b8296dd7a39d3eaf2", new DBRecord(2, "07230c2d0242787a5f69888b8296dd7a39d3eaf2", "Cold War DB v495", "CWDB_495.db3", bool_0: true));
		m_ImporterIssuer.Add("ec989b5b028a2f53b0013f7e5d8d56a040cd704c", new DBRecord(1, "ec989b5b028a2f53b0013f7e5d8d56a040cd704c", "DB3000 v494", "DB3K_494.db3", bool_0: true));
		m_ImporterIssuer.Add("2e0e362f0b590f0f44cb6b12cb6086890afebd8e", new DBRecord(2, "2e0e362f0b590f0f44cb6b12cb6086890afebd8e", "Cold War DB v494", "CWDB_494.db3", bool_0: true));
		m_ImporterIssuer.Add("b233518914717e121a7f8c9a9fd86245a688a6d0", new DBRecord(1, "b233518914717e121a7f8c9a9fd86245a688a6d0", "DB3000 v493", "DB3K_493.db3", bool_0: true));
		m_ImporterIssuer.Add("2479ac0d01508bfbb1b77802f8c1a65933adc8db", new DBRecord(2, "2479ac0d01508bfbb1b77802f8c1a65933adc8db", "Cold War DB v493", "CWDB_493.db3", bool_0: true));
		m_ImporterIssuer.Add("9f67f26e2bf6ac67de804217463545cfc9c28fef", new DBRecord(2, "9f67f26e2bf6ac67de804217463545cfc9c28fef", "Cold War DB v492", "CWDB_492.db3", bool_0: true));
		m_ImporterIssuer.Add("6b038bcf7388e314a700292ccb7a5599e5b566eb", new DBRecord(1, "6b038bcf7388e314a700292ccb7a5599e5b566eb", "DB3000 v492", "DB3K_492.db3", bool_0: true));
		m_ImporterIssuer.Add("a416d385c7d7b12c4e3ba2ad3acb3c7cae9ee44f", new DBRecord(2, "a416d385c7d7b12c4e3ba2ad3acb3c7cae9ee44f", "Cold War DB v491", "CWDB_491.db3", bool_0: true));
		m_ImporterIssuer.Add("c7974674be0ba1ea5b751fb0240fbeb4261ea86b", new DBRecord(1, "c7974674be0ba1ea5b751fb0240fbeb4261ea86b", "DB3000 v491", "DB3K_491.db3", bool_0: true));
		m_ImporterIssuer.Add("9cccd1313526d354281216a13d6336badb34fb50", new DBRecord(2, "9cccd1313526d354281216a13d6336badb34fb50", "Cold War DB v490", "CWDB_490.db3", bool_0: true));
		m_ImporterIssuer.Add("80c442a52212456cfc52a0c3d4407293bc4fd540", new DBRecord(1, "80c442a52212456cfc52a0c3d4407293bc4fd540", "DB3000 v490", "DB3K_490.db3", bool_0: true));
		m_ImporterIssuer.Add("c74ad04cb177789c1233b3ae8435c800d7f057cf", new DBRecord(1, "c74ad04cb177789c1233b3ae8435c800d7f057cf", "DB3000 v489", "DB3K_489.db3", bool_0: true));
		m_ImporterIssuer.Add("b32f460e36fa1db6c450ae79bd15dfff82c885ad", new DBRecord(1, "b32f460e36fa1db6c450ae79bd15dfff82c885ad", "DB3000 v488", "DB3K_488.db3", bool_0: true));
		m_ImporterIssuer.Add("7affd98881d0ad7b5eba7c2864786d248c2cd2ec", new DBRecord(1, "7affd98881d0ad7b5eba7c2864786d248c2cd2ec", "DB3000 v487", "DB3K_487.db3", bool_0: true));
		m_ImporterIssuer.Add("73dff9040defc1d403c731b633e133b21ccd8529", new DBRecord(1, "73dff9040defc1d403c731b633e133b21ccd8529", "DB3000 v486", "DB3K_486.db3", bool_0: true));
		m_ImporterIssuer.Add("d41e66e4221108cfd310b65d6fe9b4025a05f96e", new DBRecord(1, "d41e66e4221108cfd310b65d6fe9b4025a05f96e", "DB3000 v486 RC1", "DB3K_486_RC1.db3", bool_0: true));
		m_ImporterIssuer.Add("fc92021b44f60672f0f5cf0ffb0d4ae391e307ef", new DBRecord(1, "fc92021b44f60672f0f5cf0ffb0d4ae391e307ef", "DB3000 v485", "DB3K_485.db3", bool_0: true));
		m_ImporterIssuer.Add("51dd2d405f26ac32b145a367abf2f60f63b56994", new DBRecord(1, "51dd2d405f26ac32b145a367abf2f60f63b56994", "DB3000 v484", "DB3K_484.db3", bool_0: true));
		m_ImporterIssuer.Add("22fe77d8f42ed779a83fe53ee7bc91d4487c8477", new DBRecord(1, "22fe77d8f42ed779a83fe53ee7bc91d4487c8477", "DB3000 v483", "DB3K_483.db3", bool_0: true));
		m_ImporterIssuer.Add("3f3b638febee9b0e6ae0c526644988f5d63507f3", new DBRecord(1, "3f3b638febee9b0e6ae0c526644988f5d63507f3", "DB3000 v482", "DB3K_482.db3", bool_0: true));
		m_ImporterIssuer.Add("71b78d3037b0f4e610b9772136517ef14817d4a0", new DBRecord(1, "71b78d3037b0f4e610b9772136517ef14817d4a0", "DB3000 v481a", "DB3K_481a.db3", bool_0: true));
		m_ImporterIssuer.Add("b439f8334b9767c4b6e6f9b2ca93c86f2d773a30", new DBRecord(1, "b439f8334b9767c4b6e6f9b2ca93c86f2d773a30", "DB3000 v480", "DB3K_480.db3", bool_0: true));
		m_ImporterIssuer.Add("59b67f39e1a31b6f6ee843b9acfa8d1e368133c9", new DBRecord(2, "59b67f39e1a31b6f6ee843b9acfa8d1e368133c9", "Cold War DB v478", "CWDB_478.db3", bool_0: true));
		m_ImporterIssuer.Add("e37e2e6e6522b3ba52a20b791dc854ce3e54d9f1", new DBRecord(1, "e37e2e6e6522b3ba52a20b791dc854ce3e54d9f1", "DB3000 v479", "DB3K_479.db3", bool_0: true));
		XmlDocument xmlDocument = AwakeImporter();
		if (xmlDocument == null)
		{
			return;
		}
		XmlNode xmlNode = xmlDocument.SelectSingleNode("/DBFiles");
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlNode.ChildNodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode2 = (XmlNode)enumerator.Current;
				DBRecord dBRecord = new DBRecord(Conversions.ToInteger(xmlNode2.SelectSingleNode("DBID").InnerText), xmlNode2.SelectSingleNode("Hash").InnerText, xmlNode2.SelectSingleNode("Name").InnerText, xmlNode2.SelectSingleNode("File").InnerText, Conversions.ToBoolean(xmlNode2.SelectSingleNode("Supported").InnerText));
				if (FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.DBFolderPath, dBRecord.FileName)) && !m_ImporterIssuer.ContainsKey(dBRecord.Hash))
				{
					m_ImporterIssuer.Add(dBRecord.Hash, dBRecord);
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
	}
}
