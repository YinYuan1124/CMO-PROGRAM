using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SQLiteHelper
{
	[CompilerGenerated]
	private sealed class WorkerItem
	{
		public SQLiteDataReader Local_theReader;

		internal void RevertInterruptibleReg()
		{
			((DbDataReader)Local_theReader).Close();
			Local_theReader = null;
		}
	}

	public SQLiteConnection theConnection;

	private static Dictionary<Type, string> requestProxy;

	public SQLiteHelper(SQLiteConnection sqliteConnection_0)
	{
		theConnection = sqliteConnection_0;
	}

	public void ExecuteNonQuery(string string_0, bool bool_0 = true)
	{
		OpenConnection();
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			dbCommand.ExecuteNonQuery();
		}
		if (bool_0)
		{
			CloseConnection();
		}
	}

	internal string DeleteSpecification(string string_0)
	{
		OpenConnection();
		using SQLiteCommand val = new SQLiteCommand(theConnection);
		using SQLiteTransaction val2 = theConnection.BeginTransaction();
		((DbCommand)val).CommandText = string_0 + "; Select last_insert_rowid()";
		string result;
		try
		{
			result = Conversions.ToString(((DbCommand)val).ExecuteScalar());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			string empty = string.Empty;
			ProjectData.ClearProjectError();
			return empty;
		}
		((DbTransaction)val2).Commit();
		return result;
	}

	internal bool AddSpecification(List<string> list_0)
	{
		OpenConnection();
		using (SQLiteCommand val = new SQLiteCommand(theConnection))
		{
			using SQLiteTransaction val2 = theConnection.BeginTransaction();
			foreach (string item in list_0)
			{
				((DbCommand)val).CommandText = item;
				try
				{
					((DbCommand)val).ExecuteNonQuery();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return false;
				}
			}
			((DbTransaction)val2).Commit();
		}
		return true;
	}

	internal SQLiteDataReader DestroySpecification(string string_0)
	{
		OpenConnection();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return (SQLiteDataReader)dbCommand.ExecuteReader();
	}

	internal DataTable ComputeSpecification(string string_0)
	{
		OpenConnection();
		DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		SQLiteDataReader val = (SQLiteDataReader)dbCommand.ExecuteReader();
		DataTable dataTable = new DataTable();
		int fieldCount = ((DbDataReader)val).FieldCount;
		int num = fieldCount - 1;
		for (int i = 0; i <= num; i++)
		{
			dataTable.Columns.Add(((DbDataReader)val).GetName(i), ((DbDataReader)val).GetFieldType(i));
		}
		while (((DbDataReader)val).Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int num2 = fieldCount - 1;
			for (int j = 0; j <= num2; j++)
			{
				dataRow[j] = RuntimeHelpers.GetObjectValue(((DbDataReader)val)[j]);
			}
			dataTable.Rows.Add(dataRow);
		}
		dbCommand.Cancel();
		dbCommand.Dispose();
		((DbDataReader)val).Close();
		val = null;
		return dataTable;
	}

	internal DataTableTyped PatchSpecification(string string_0)
	{
		OpenConnection();
		DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		SQLiteDataReader Local_theReader = (SQLiteDataReader)dbCommand.ExecuteReader();
		DataTableTyped dataTableTyped = new DataTableTyped();
		int fieldCount = ((DbDataReader)Local_theReader).FieldCount;
		int num = fieldCount - 1;
		for (int i = 0; i <= num; i++)
		{
			dataTableTyped.Columns.Add(((DbDataReader)Local_theReader).GetName(i), ((DbDataReader)Local_theReader).GetFieldType(i));
		}
		while (((DbDataReader)Local_theReader).Read())
		{
			DtrRow dtrRow = dataTableTyped.NewRow();
			int num2 = fieldCount - 1;
			for (int j = 0; j <= num2; j++)
			{
				dtrRow[j] = RuntimeHelpers.GetObjectValue(((DbDataReader)Local_theReader)[j]);
			}
			dataTableTyped.Rows.Add(dtrRow);
		}
		dbCommand.Cancel();
		dbCommand.Dispose();
		Task.Factory.StartNew(delegate
		{
			((DbDataReader)Local_theReader).Close();
			Local_theReader = null;
		});
		return dataTableTyped;
	}

	internal string SelectSpecification(string string_0, bool bool_0 = false)
	{
		OpenConnection();
		string result;
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			result = Conversions.ToString(dbCommand.ExecuteScalar());
		}
		if (bool_0)
		{
			CloseConnection();
		}
		return result;
	}

	public void ExecuteCommand(SQLiteCommand sqliteCommand_0)
	{
		OpenConnection();
		sqliteCommand_0.Connection = theConnection;
		((DbCommand)sqliteCommand_0).ExecuteNonQuery();
		CloseConnection();
	}

	public void OpenConnection()
	{
		if (((DbConnection)theConnection).State == ConnectionState.Closed)
		{
			((DbConnection)theConnection).Open();
		}
	}

	public void CloseConnection()
	{
		if (((DbConnection)theConnection).State == ConnectionState.Open)
		{
			((DbConnection)theConnection).Close();
		}
	}

	public static string TimeToString(DateTime dateTime_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(dateTime_0.Year);
		stringBuilder.Append("-");
		stringBuilder.Append(CallSpecification(Conversions.ToString(dateTime_0.Month)));
		stringBuilder.Append("-");
		stringBuilder.Append(CallSpecification(Conversions.ToString(dateTime_0.Day)));
		stringBuilder.Append(" ");
		stringBuilder.Append(CallSpecification(Conversions.ToString(dateTime_0.Hour)));
		stringBuilder.Append(":");
		stringBuilder.Append(CallSpecification(Conversions.ToString(dateTime_0.Minute)));
		stringBuilder.Append(":");
		stringBuilder.Append(CallSpecification(Conversions.ToString(dateTime_0.Second)));
		return stringBuilder.ToString();
	}

	private static string CallSpecification(string string_0)
	{
		if (string_0.Length == 1)
		{
			return "0" + string_0;
		}
		return string_0;
	}

	internal bool LogoutSpecification(StringBuilder stringBuilder_0, string string_0)
	{
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = new StringBuilder();
		}
		else
		{
			stringBuilder_0.Clear();
		}
		stringBuilder_0.Append("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='").Append(string_0).Append("'");
		string string_ = stringBuilder_0.ToString();
		if (Conversions.ToInteger(DBCache.GetScalar(this, string_)) == 0)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	private static Dictionary<Type, string> GetSqliteTypesString()
	{
		if (requestProxy == null)
		{
			requestProxy = new Dictionary<Type, string>();
			requestProxy.Add(typeof(int), "INTEGER");
			requestProxy.Add(typeof(string), "TEXT");
			requestProxy.Add(typeof(bool), "INTEGER");
			requestProxy.Add(typeof(DateTime), "DATETIME");
			requestProxy.Add(typeof(float), "DOUBLE");
			requestProxy.Add(typeof(double), "DOUBLE");
			requestProxy.Add(typeof(decimal), "DOUBLE");
			requestProxy.Add(typeof(TimeSpan), "TEXT");
		}
		return requestProxy;
	}
}
