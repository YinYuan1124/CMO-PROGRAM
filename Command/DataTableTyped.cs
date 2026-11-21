using System.Collections;
using System.Collections.Generic;
using System.Data;

public sealed class DataTableTyped : IEnumerable<IEnumerable<object>>, IEnumerable
{
	private readonly DtrColumnCollection _Dispatcher;

	private readonly DtrRowCollection _Listener;

	public DtrColumnCollection Columns => _Dispatcher;

	public DtrRowCollection Rows => _Listener;

	public DataTableTyped()
	{
		_Dispatcher = new DtrColumnCollection();
		_Listener = new DtrRowCollection();
	}

	public DtrRow NewRow()
	{
		return new DtrRow(this);
	}

	public DataTable ToDataTable()
	{
		DataTable dataTable = new DataTable();
		dataTable.BeginLoadData();
		_Dispatcher.CreateColumns(dataTable);
		_Listener.CreateRows(dataTable);
		dataTable.EndLoadData();
		return dataTable;
	}

	public IEnumerator<IEnumerable<object>> GetEnumerator()
	{
		foreach (DtrRow item in _Listener)
		{
			yield return item.ToArray();
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
