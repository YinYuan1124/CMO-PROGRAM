using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SQLServerHelper
{
	public SqlConnection theConnection;

	public SQLServerHelper(SqlConnection sqlConnection_0)
	{
		theConnection = sqlConnection_0;
	}

	public void ExecuteNonQuery(string string_0, bool bool_0 = true)
	{
		GetSpecification();
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

	internal SqlDataReader ViewSpecification(string string_0)
	{
		GetSpecification();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return (SqlDataReader)dbCommand.ExecuteReader();
	}

	internal DataTable ValidateSpecification(string string_0)
	{
		GetSpecification();
		SqlDataReader sqlDataReader;
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			sqlDataReader = (SqlDataReader)dbCommand.ExecuteReader();
		}
		DataTable dataTable = new DataTable();
		int fieldCount = sqlDataReader.FieldCount;
		int num = fieldCount - 1;
		for (int i = 0; i <= num; i++)
		{
			dataTable.Columns.Add(sqlDataReader.GetName(i), sqlDataReader.GetFieldType(i));
		}
		while (sqlDataReader.Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int num2 = fieldCount - 1;
			for (int j = 0; j <= num2; j++)
			{
				dataRow[j] = RuntimeHelpers.GetObjectValue(sqlDataReader[j]);
			}
			dataTable.Rows.Add(dataRow);
		}
		sqlDataReader.Close();
		sqlDataReader = null;
		return dataTable;
	}

	internal string LoginSpecification(string string_0)
	{
		GetSpecification();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return Conversions.ToString(dbCommand.ExecuteScalar());
	}

	public void ExecuteCommand(SqlCommand sqlCommand_0)
	{
		GetSpecification();
		sqlCommand_0.Connection = theConnection;
		sqlCommand_0.ExecuteNonQuery();
		CloseConnection();
	}

	public void ExecuteBulkCopy(DataTable dataTable_0, string string_0)
	{
		using SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(theConnection);
		sqlBulkCopy.DestinationTableName = string_0;
		try
		{
			sqlBulkCopy.WriteToServer(dataTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable_0.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow_ = (DataRow)enumerator.Current;
					InsertRowIntoSqlServerTable(dataRow_, string_0, theConnection);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			ProjectData.ClearProjectError();
		}
	}

	public void InsertRowIntoSqlServerTable(DataRow dataRow_0, string string_0, SqlConnection sqlConnection_0)
	{
		string text = "INSERT INTO " + string_0 + " VALUES (";
		int num = -1;
		IEnumerator enumerator = null;
		try
		{
			enumerator = dataRow_0.Table.Columns.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataColumn dataColumn = (DataColumn)enumerator.Current;
				num++;
				if (num > 0)
				{
					text += $"'{RuntimeHelpers.GetObjectValue(dataRow_0[dataColumn.ColumnName])}',";
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
		text = text.TrimEnd(',') + ")";
		using SqlCommand sqlCommand = new SqlCommand(text, sqlConnection_0);
		try
		{
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			exception_.Data.Add("SQL-Insert command", sqlCommand.CommandText);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
		}
	}

	private void GetSpecification()
	{
		if (theConnection.State == ConnectionState.Closed)
		{
			theConnection.Open();
		}
	}

	public void CloseConnection()
	{
		if (theConnection.State == ConnectionState.Open)
		{
			theConnection.Close();
		}
	}

	public static string SQLSafeString(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		stringBuilder.Append(string_0);
		return stringBuilder.Replace("'", "''").Replace("`", "''").ToString();
	}

	public static string MakeSQLDateString_YYYYMMDD(DateTime dateTime_0)
	{
		string text = ((Strings.Len(dateTime_0.Day.ToString()) == 1) ? ("0" + dateTime_0.Day) : dateTime_0.Day.ToString());
		string text2 = ((Strings.Len(dateTime_0.Month.ToString()) == 1) ? ("0" + dateTime_0.Month) : dateTime_0.Month.ToString());
		return Conversions.ToString(dateTime_0.Year) + text2 + text;
	}

	public static string MakeSQLDateString_DDMMYYYY(DateTime dateTime_0)
	{
		string text = ((Strings.Len(dateTime_0.Day.ToString()) == 1) ? ("0" + dateTime_0.Day) : dateTime_0.Day.ToString());
		string text2 = ((Strings.Len(dateTime_0.Month.ToString()) == 1) ? ("0" + dateTime_0.Month) : dateTime_0.Month.ToString());
		return text + "/" + text2 + "/" + Conversions.ToString(dateTime_0.Year);
	}
}
