using System.Collections;
using System.Collections.Generic;
using System.Data;

public sealed class DtrRowCollection : IEnumerable<DtrRow>, IEnumerable
{
	private readonly List<DtrRow> m_Wrapper;

	public DtrRow this[int int_0] => m_Wrapper[int_0];

	public DtrRowCollection()
	{
		m_Wrapper = new List<DtrRow>();
	}

	public void Add(DtrRow dtrRow_0)
	{
		m_Wrapper.Add(dtrRow_0);
	}

	public void CreateRows(DataTable dataTable_0)
	{
		foreach (DtrRow item in m_Wrapper)
		{
			dataTable_0.Rows.Add(item.ToArray());
		}
	}

	public IEnumerator<DtrRow> GetEnumerator()
	{
		return m_Wrapper.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
