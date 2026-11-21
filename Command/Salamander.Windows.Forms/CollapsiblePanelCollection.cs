using System;
using System.Collections;

namespace Salamander.Windows.Forms;

public sealed class CollapsiblePanelCollection : CollectionBase
{
	public void Add(CollapsiblePanel collapsiblePanel_0)
	{
		base.List.Add(collapsiblePanel_0);
	}

	public void Remove(int int_0)
	{
		if (int_0 >= base.Count || int_0 < 0)
		{
			throw new IndexOutOfRangeException("The supplied index is out of range");
		}
		base.List.RemoveAt(int_0);
	}

	public CollapsiblePanel Item(int int_0)
	{
		if (int_0 >= base.Count || int_0 < 0)
		{
			throw new IndexOutOfRangeException("The supplied index is out of range");
		}
		return (CollapsiblePanel)base.List[int_0];
	}

	public void Insert(int int_0, CollapsiblePanel collapsiblePanel_0)
	{
		base.List.Insert(int_0, collapsiblePanel_0);
	}

	public void CopyTo(Array array_0, int int_0)
	{
		base.List.CopyTo(array_0, int_0);
	}

	public int IndexOf(CollapsiblePanel collapsiblePanel_0)
	{
		return base.List.IndexOf(collapsiblePanel_0);
	}
}
