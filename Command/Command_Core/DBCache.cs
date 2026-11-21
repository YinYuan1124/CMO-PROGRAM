using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using CSMaterial;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DBCache
{
	public interface I_CacheableRow
	{
		void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0);
	}

	private static ConcurrentDictionary<string, MemoryCache> _DicIssuer;

	private static ConcurrentDictionary<string, MemoryCache> m_ConsumerIssuer;

	private static ConcurrentDictionary<string, LRUCache<string, DataTableTyped>> m_FacadeIssuer;

	private static CacheItemPolicy proxyIssuer;

	static DBCache()
	{
		_DicIssuer = new ConcurrentDictionary<string, MemoryCache>();
		m_ConsumerIssuer = new ConcurrentDictionary<string, MemoryCache>();
		m_FacadeIssuer = new ConcurrentDictionary<string, LRUCache<string, DataTableTyped>>();
	}

	private static CacheItemPolicy StartImporter()
	{
		if (proxyIssuer == null)
		{
			proxyIssuer = new CacheItemPolicy
			{
				SlidingExpiration = new TimeSpan(0, 0, 30)
			};
		}
		return proxyIssuer;
	}

	public static DataTable GetDatatable(SQLiteHelper sqliteHelper_0, string string_0)
	{
		DataTable result = null;
		try
		{
			MemoryCache value = null;
			if (!_DicIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
			{
				value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
				_DicIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
			}
			DataTable dataTable = null;
			dataTable = (DataTable)value.Get(string_0);
			if (dataTable == null)
			{
				dataTable = sqliteHelper_0.ComputeSpecification(string_0);
				value.Add(string_0, dataTable, StartImporter());
			}
			result = dataTable;
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

	public static DataTableTyped GetDatatableTyped_LRU(SQLiteHelper sqliteHelper_0, string string_0)
	{
		DataTableTyped result = null;
		try
		{
			LRUCache<string, DataTableTyped> value = null;
			if (!m_FacadeIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
			{
				value = new LRUCache<string, DataTableTyped>(1000, bool_0: true);
				m_FacadeIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
			}
			DataTableTyped dataTableTyped = value.get(string_0);
			if (dataTableTyped == null)
			{
				dataTableTyped = sqliteHelper_0.PatchSpecification(string_0);
				value.add(string_0, dataTableTyped);
			}
			result = dataTableTyped;
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

	public static DataTableTyped GetDatatableTyped(SQLiteHelper sqliteHelper_0, string string_0, bool bool_0 = true)
	{
		DataTableTyped result = null;
		try
		{
			MemoryCache value = null;
			if (!_DicIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
			{
				value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
				_DicIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
			}
			DataTableTyped dataTableTyped = null;
			dataTableTyped = (DataTableTyped)value.Get(string_0);
			if (dataTableTyped == null)
			{
				dataTableTyped = sqliteHelper_0.PatchSpecification(string_0);
				if (bool_0)
				{
					value.Add(string_0, dataTableTyped, StartImporter());
				}
			}
			result = dataTableTyped;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (sqliteHelper_0 != null && (sqliteHelper_0.theConnection == null || ((DbConnection)sqliteHelper_0.theConnection).State != ConnectionState.Open))
			{
				throw;
			}
			sqliteHelper_0.CloseConnection();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static string GetScalar(SQLiteHelper sqliteHelper_0, string string_0)
	{
		MemoryCache value = null;
		try
		{
			string key = null;
			string text = null;
			if (string.IsNullOrEmpty(string_0))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				if (!_DicIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
				{
					value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
					_DicIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
				}
				key = string_0;
				text = Conversions.ToString(value.Get(key));
			}
			if (string.IsNullOrEmpty(text))
			{
				text = sqliteHelper_0.SelectSpecification(string_0);
				if (!string.IsNullOrEmpty(text))
				{
					value.Add(key, text, StartImporter());
				}
			}
			return text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			exception_?.Data.Add("Error at 200083", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			string result = sqliteHelper_0.SelectSpecification(string_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static object GetCustomObject(SQLiteHelper sqliteHelper_0, string string_0)
	{
		MemoryCache value = null;
		if (!m_ConsumerIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
		{
			value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
			m_ConsumerIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
		}
		return RuntimeHelpers.GetObjectValue(value.Get(string_0));
	}

	public static void SetCustomObject(SQLiteHelper sqliteHelper_0, string string_0, object object_0)
	{
		MemoryCache value = null;
		if (!m_ConsumerIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
		{
			value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
			m_ConsumerIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
		}
		value.Add(string_0, RuntimeHelpers.GetObjectValue(object_0), StartImporter());
	}

	public static string GetString(SQLiteHelper sqliteHelper_0, string string_0)
	{
		MemoryCache value = null;
		if (!m_ConsumerIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
		{
			value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
			m_ConsumerIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
		}
		return Conversions.ToString(value.Get(string_0));
	}

	public static void SetString(SQLiteHelper sqliteHelper_0, string string_0, string string_1)
	{
		MemoryCache value = null;
		if (!m_ConsumerIssuer.TryGetValue(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, out value))
		{
			value = new MemoryCache(((DbConnection)sqliteHelper_0.theConnection).ConnectionString);
			m_ConsumerIssuer.TryAdd(((DbConnection)sqliteHelper_0.theConnection).ConnectionString, value);
		}
		value.Add(string_0, string_1, StartImporter());
	}

	public static void SetValueIfDataTableHasFieldOfCorrectType<T>(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0, ref T gparam_0, string string_0)
	{
		if (!dataTableTyped_0.Columns.Contains(string_0))
		{
			return;
		}
		if (dtrRow_0[string_0] is T)
		{
			gparam_0 = Conversion.CTypeDynamic<T>(RuntimeHelpers.GetObjectValue(dtrRow_0[string_0]));
			return;
		}
		if (Debugger.IsAttached && Operators.CompareString(string_0, "MastHeight", TextCompare: false) == 0)
		{
			_ = dtrRow_0[string_0];
		}
		try
		{
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow_0[string_0])))
			{
				gparam_0 = Conversion.CTypeDynamic<T>(RuntimeHelpers.GetObjectValue(dtrRow_0[string_0]));
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
	}

	public static List<T> BuildCacheableQueryResult<T>(SQLiteHelper sqliteHelper_0, string string_0, bool bool_0 = true) where T : struct, I_CacheableRow
	{
		DataTableTyped datatableTyped = GetDatatableTyped(sqliteHelper_0, string_0, bool_0: false);
		List<T> list = new List<T>();
		foreach (DtrRow row in datatableTyped.Rows)
		{
			T item = new T();
			item.setValuesFromDataTableTyped(datatableTyped, row);
			list.Add(item);
		}
		if (bool_0)
		{
			SetCustomObject(sqliteHelper_0, string_0, list);
		}
		return list;
	}

	internal static List<T> AssetImporter<T>(SQLiteHelper sqliteHelper_0, string string_0, bool bool_0 = true) where T : struct, I_CacheableRow
	{
		try
		{
			object objectValue = RuntimeHelpers.GetObjectValue(GetCustomObject(sqliteHelper_0, string_0));
			if (objectValue == null)
			{
				return BuildCacheableQueryResult<T>(sqliteHelper_0, string_0);
			}
			return (List<T>)objectValue;
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
		return null;
	}

	internal static List<T> PrintImporter<T>(SQLiteHelper sqliteHelper_0, string string_0, string string_1, bool bool_0 = true)
	{
		try
		{
			object objectValue = RuntimeHelpers.GetObjectValue(GetCustomObject(sqliteHelper_0, string_0));
			if (objectValue == null)
			{
				List<T> list = new List<T>();
				DataTableTyped datatableTyped = GetDatatableTyped(sqliteHelper_0, string_0, bool_0: false);
				T gparam_ = default(T);
				foreach (DtrRow row in datatableTyped.Rows)
				{
					SetValueIfDataTableHasFieldOfCorrectType(datatableTyped, row, ref gparam_, string_1);
					list.Add(gparam_);
				}
				if (bool_0)
				{
					SetCustomObject(sqliteHelper_0, string_0, list);
				}
				return list;
			}
			return (List<T>)objectValue;
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
		return null;
	}
}
