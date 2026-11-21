using System;
using System.Collections;
using System.Collections.Generic;

namespace AdvancedDataGridView;

public sealed class TreeGridNodeCollection : IList<TreeGridNode>, ICollection<TreeGridNode>, IEnumerable<TreeGridNode>, IEnumerable, IList, ICollection
{
	internal List<TreeGridNode> registryRegistry;

	internal TreeGridNode definitionRegistry;

	public TreeGridNode this[int index]
	{
		get
		{
			return registryRegistry[index];
		}
		set
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public int Count => registryRegistry.Count;

	public bool IsReadOnly => false;

	bool IList.IsReadOnly => IsReadOnly;

	bool IList.IsFixedSize => false;

	int ICollection.Count => Count;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	bool ICollection.IsSynchronized
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	object ICollection.SyncRoot
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	internal TreeGridNodeCollection(TreeGridNode treeGridNode_0)
	{
		definitionRegistry = treeGridNode_0;
		registryRegistry = new List<TreeGridNode>();
	}

	public void Add(TreeGridNode item)
	{
		item.getterConfig = definitionRegistry.getterConfig;
		bool hasChildren = definitionRegistry.HasChildren;
		item._ProcConfig = this;
		registryRegistry.Add(item);
		definitionRegistry.AddChildNode(item);
		if (!hasChildren && definitionRegistry.IsSited)
		{
			definitionRegistry.getterConfig.InvalidateRow(definitionRegistry.RowIndex);
		}
	}

	public TreeGridNode Add(string string_0)
	{
		TreeGridNode treeGridNode = new TreeGridNode();
		Add(treeGridNode);
		treeGridNode.Cells[0].Value = string_0;
		return treeGridNode;
	}

	public TreeGridNode Add(params object[] values)
	{
		TreeGridNode treeGridNode = new TreeGridNode();
		Add(treeGridNode);
		int num = 0;
		if (values.Length <= treeGridNode.Cells.Count)
		{
			foreach (object value in values)
			{
				treeGridNode.Cells[num].Value = value;
				num++;
			}
			return treeGridNode;
		}
		throw new ArgumentOutOfRangeException("values");
	}

	public void Insert(int index, TreeGridNode item)
	{
		item.getterConfig = definitionRegistry.getterConfig;
		item._ProcConfig = this;
		registryRegistry.Insert(index, item);
		definitionRegistry.InsertChildNode(index, item);
	}

	public bool Remove(TreeGridNode item)
	{
		definitionRegistry.RemoveChildNode(item);
		item.getterConfig = null;
		return registryRegistry.Remove(item);
	}

	public void RemoveAt(int index)
	{
		TreeGridNode treeGridNode = registryRegistry[index];
		definitionRegistry.RemoveChildNode(treeGridNode);
		treeGridNode.getterConfig = null;
		registryRegistry.RemoveAt(index);
	}

	public void Clear()
	{
		definitionRegistry.ClearNodes();
		registryRegistry.Clear();
	}

	public int IndexOf(TreeGridNode item)
	{
		return registryRegistry.IndexOf(item);
	}

	public bool Contains(TreeGridNode item)
	{
		return registryRegistry.Contains(item);
	}

	public void CopyTo(TreeGridNode[] array, int arrayIndex)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	void IList.Remove(object value)
	{
		Remove(value as TreeGridNode);
	}

	int IList.Add(object value)
	{
		TreeGridNode treeGridNode = value as TreeGridNode;
		Add(treeGridNode);
		return treeGridNode.Index;
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	void IList.Clear()
	{
		Clear();
	}

	int IList.IndexOf(object value)
	{
		return IndexOf(value as TreeGridNode);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, value as TreeGridNode);
	}

	bool IList.Contains(object value)
	{
		return Contains(value as TreeGridNode);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public IEnumerator<TreeGridNode> GetEnumerator()
	{
		return registryRegistry.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
