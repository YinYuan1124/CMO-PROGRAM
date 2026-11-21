using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Text;

namespace DXRenderer;

public sealed class SQLiteHelper
{
	public SQLiteConnection theConnection;

	private static Dictionary<Type, string> m_WriterVal;

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

	public SQLiteDataReader ExecuteReader(string string_0)
	{
		OpenConnection();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return (SQLiteDataReader)dbCommand.ExecuteReader();
	}

	public DataTable ExecuteDataTable(string string_0)
	{
		OpenConnection();
		DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		SQLiteDataReader val = (SQLiteDataReader)dbCommand.ExecuteReader();
		DataTable dataTable = new DataTable();
		int fieldCount = ((DbDataReader)val).FieldCount;
		int i = 0;
		for (int num = fieldCount - 1; i <= num; i++)
		{
			dataTable.Columns.Add(((DbDataReader)val).GetName(i), ((DbDataReader)val).GetFieldType(i));
		}
		while (((DbDataReader)val).Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int j = 0;
			for (int num2 = fieldCount - 1; j <= num2; j++)
			{
				dataRow[j] = ((DbDataReader)val)[j];
			}
			dataTable.Rows.Add(dataRow);
		}
		dbCommand.Cancel();
		dbCommand.Dispose();
		((DbDataReader)val).Close();
		val = null;
		return dataTable;
	}

	public string ExecuteScalar(string string_0, bool bool_0)
	{
		OpenConnection();
		string result;
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			result = dbCommand.ExecuteScalar().ToString();
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
		stringBuilder.Append(PublishIssuer(dateTime_0.Month.ToString()));
		stringBuilder.Append("-");
		stringBuilder.Append(PublishIssuer(dateTime_0.Day.ToString()));
		stringBuilder.Append(" ");
		stringBuilder.Append(PublishIssuer(dateTime_0.Hour.ToString()));
		stringBuilder.Append(":");
		stringBuilder.Append(PublishIssuer(dateTime_0.Minute.ToString()));
		stringBuilder.Append(":");
		stringBuilder.Append(PublishIssuer(dateTime_0.Second.ToString()));
		return stringBuilder.ToString();
	}

	private static string PublishIssuer(string string_0)
	{
		if (string_0.Length == 1)
		{
			return "0" + string_0;
		}
		return string_0;
	}

	[SpecialName]
	private static Dictionary<Type, string> smethod_0()
	{
		if (m_WriterVal == null)
		{
			m_WriterVal = new Dictionary<Type, string>();
			m_WriterVal.Add(typeof(int), "INTEGER");
			m_WriterVal.Add(typeof(string), "TEXT");
			m_WriterVal.Add(typeof(bool), "INTEGER");
			m_WriterVal.Add(typeof(DateTime), "DATETIME");
			m_WriterVal.Add(typeof(float), "DOUBLE");
			m_WriterVal.Add(typeof(double), "DOUBLE");
			m_WriterVal.Add(typeof(decimal), "DOUBLE");
			m_WriterVal.Add(typeof(TimeSpan), "TEXT");
		}
		return m_WriterVal;
	}
}
