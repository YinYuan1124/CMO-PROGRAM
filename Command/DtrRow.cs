public sealed class DtrRow
{
	private readonly object[] m_Definition;

	private readonly DataTableTyped m_Val;

	public object this[string string_0]
	{
		get
		{
			int index = m_Val.Columns.GetIndex(string_0);
			return m_Definition[index];
		}
		set
		{
			int index = m_Val.Columns.GetIndex(string_0);
			m_Definition[index] = value;
		}
	}

	public object this[int int_0]
	{
		get
		{
			return m_Definition[int_0];
		}
		set
		{
			m_Definition[int_0] = value;
		}
	}

	public DtrRow(DataTableTyped dataTableTyped_0)
	{
		m_Val = dataTableTyped_0;
		int count = m_Val.Columns.Count;
		m_Definition = new object[count];
	}

	public object[] ToArray()
	{
		return m_Definition;
	}
}
