using System;
using System.Collections.Generic;
using System.Data;

public sealed class DtrColumnCollection
{
	private readonly Dictionary<string, int> m_Config;

	private readonly Dictionary<string, Type> registry;

	public int Count => m_Config.Count;

	public DtrColumnCollection()
	{
		m_Config = new Dictionary<string, int>();
		registry = new Dictionary<string, Type>();
	}

	public Dictionary<string, int> GetColumnsIndexes()
	{
		return m_Config;
	}

	public bool Contains(string string_0)
	{
		return m_Config.ContainsKey(string_0);
	}

	public void Add(string string_0, Type type_0)
	{
		int count = m_Config.Count;
		if (!m_Config.ContainsKey(string_0))
		{
			m_Config.Add(string_0, count);
			registry.Add(string_0, type_0);
		}
	}

	public int GetIndex(string string_0)
	{
		return m_Config[string_0];
	}

	public void CreateColumns(DataTable dataTable_0)
	{
		foreach (KeyValuePair<string, Type> item in registry)
		{
			dataTable_0.Columns.Add(item.Key, item.Value);
		}
	}

	private static void EnableStruct()
	{
		ChangeStruct(bool_0: false);
		ChangeStruct(bool_0: true);
		InitStruct();
		Console.ReadKey();
	}

	private static void ChangeStruct(bool bool_0)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("cInt", typeof(int));
		dataTable.Columns.Add("cString", typeof(string));
		dataTable.Columns.Add("cBool", typeof(bool));
		dataTable.Columns.Add("cDateTime", typeof(DateTime));
		if (bool_0)
		{
			dataTable.BeginLoadData();
		}
		for (int i = 0; i < 100000; i++)
		{
			dataTable.Rows.Add(dataTable.NewRow());
		}
		DateTime now = DateTime.Now;
		for (int j = 0; j < 100000; j++)
		{
			dataTable.Rows[j]["cInt"] = 1;
			dataTable.Rows[j]["cString"] = "Some string";
			dataTable.Rows[j]["cBool"] = true;
			dataTable.Rows[j]["cDateTime"] = now;
		}
		if (bool_0)
		{
			dataTable.EndLoadData();
		}
		Console.WriteLine("Filling DataTable" + (bool_0 ? " with BeginLoadData/EndLoadData" : "") + ": " + (DateTime.Now - now).TotalMilliseconds);
	}

	private static void InitStruct()
	{
		DataTableTyped dataTableTyped = new DataTableTyped();
		dataTableTyped.Columns.Add("cInt", typeof(int));
		dataTableTyped.Columns.Add("cString", typeof(string));
		dataTableTyped.Columns.Add("cBool", typeof(bool));
		dataTableTyped.Columns.Add("cDateTime", typeof(DateTime));
		for (int i = 0; i < 100000; i++)
		{
			dataTableTyped.Rows.Add(dataTableTyped.NewRow());
		}
		DateTime now = DateTime.Now;
		for (int j = 0; j < 100000; j++)
		{
			dataTableTyped.Rows[j]["cInt"] = 1;
			dataTableTyped.Rows[j]["cString"] = "Some string";
			dataTableTyped.Rows[j]["cBool"] = true;
			dataTableTyped.Rows[j]["cDateTime"] = now;
		}
		double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
		Console.WriteLine("Filling DataTableTyped: " + totalMilliseconds);
		now = DateTime.Now;
		dataTableTyped.ToDataTable();
		double totalMilliseconds2 = (DateTime.Now - now).TotalMilliseconds;
		Console.WriteLine("Transforming DataTableTyped to DataTable: " + totalMilliseconds2);
		Console.WriteLine("Total filling and transforming: " + (totalMilliseconds + totalMilliseconds2));
	}
}
