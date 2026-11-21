using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class DBRecord
{
	public int DBID;

	public string Hash;

	public string DBName;

	public string FileName;

	public bool? IsSupportedByGame;

	public string ConnString;

	private List<string> classIssuer;

	public List<string> List_0
	{
		get
		{
			if (classIssuer == null)
			{
				classIssuer = new List<string>();
				DataTable dataTable_ = new DataTable();
				DataTable dataTable_2 = new DataTable();
				DataTable dataTable_3 = new DataTable();
				DataTable dataTable_4 = new DataTable();
				DataTable dataTable_5 = new DataTable();
				DataTable dataTable_6 = new DataTable();
				DataTable dataTable_7 = new DataTable();
				SQLiteConnection sqliteConnection_ = new SQLiteConnection(ConnectionString);
				DBFunctions.GetPlatformLists(ref dataTable_, ref dataTable_2, ref dataTable_3, ref dataTable_4, ref dataTable_5, ref dataTable_6, ref dataTable_7, ref sqliteConnection_);
				IEnumerator enumerator = null;
				try
				{
					enumerator = dataTable_.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						classIssuer.Add("飞机 #" + dataRow["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = dataTable_2.Rows.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						DataRow dataRow2 = (DataRow)enumerator2.Current;
						classIssuer.Add("船 #" + dataRow2["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
				IEnumerator enumerator3 = null;
				try
				{
					enumerator3 = dataTable_3.Rows.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						DataRow dataRow3 = (DataRow)enumerator3.Current;
						classIssuer.Add("潜艇 #" + dataRow3["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator3 is IDisposable)
					{
						(enumerator3 as IDisposable).Dispose();
					}
				}
				IEnumerator enumerator4 = null;
				try
				{
					enumerator4 = dataTable_4.Rows.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						DataRow dataRow4 = (DataRow)enumerator4.Current;
						classIssuer.Add("设施 #" + dataRow4["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator4 is IDisposable)
					{
						(enumerator4 as IDisposable).Dispose();
					}
				}
				IEnumerator enumerator5 = null;
				try
				{
					enumerator5 = dataTable_5.Rows.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						DataRow dataRow5 = (DataRow)enumerator5.Current;
						classIssuer.Add("GroundUnit #" + dataRow5["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator5 is IDisposable)
					{
						(enumerator5 as IDisposable).Dispose();
					}
				}
				IEnumerator enumerator6 = null;
				try
				{
					enumerator6 = dataTable_6.Rows.GetEnumerator();
					while (enumerator6.MoveNext())
					{
						DataRow dataRow6 = (DataRow)enumerator6.Current;
						classIssuer.Add("卫星 #" + dataRow6["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator6 is IDisposable)
					{
						(enumerator6 as IDisposable).Dispose();
					}
				}
				IEnumerator enumerator7 = null;
				try
				{
					enumerator7 = dataTable_7.Rows.GetEnumerator();
					while (enumerator7.MoveNext())
					{
						DataRow dataRow7 = (DataRow)enumerator7.Current;
						classIssuer.Add("武器 #" + dataRow7["ID"].ToString());
					}
				}
				finally
				{
					if (enumerator7 is IDisposable)
					{
						(enumerator7 as IDisposable).Dispose();
					}
				}
			}
			return classIssuer;
		}
	}

	public bool IsRegistered => DBOps.RegisteredDBs().Contains(this);

	public bool LocalCopyExists => FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.DBFolderPath, FileName));

	public string ConnectionString => "Data Source=" + Path.Combine(GameGeneral.DBFolderPath, FileName) + ";Version=3;Read Only=True;";

	public bool IsTheLatestVersion => Operators.CompareString(DBOps.GetHashForMostRecentVersionOfThisDB(DBID), Hash, TextCompare: false) == 0;

	public DBRecord(int int_0, string string_0, string string_1, string string_2, bool bool_0 = false)
	{
		DBID = int_0;
		Hash = string_0;
		DBName = string_1;
		FileName = string_2;
		IsSupportedByGame = bool_0;
	}
}
