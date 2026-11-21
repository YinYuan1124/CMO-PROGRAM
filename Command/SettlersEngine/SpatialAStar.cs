using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using OpenDis.Common;

namespace SettlersEngine;

public class SpatialAStar<T, TUserContext> where T : IPathNode<TUserContext>
{
	protected class PathNode : IPathNode<TUserContext>, IComparer<PathNode>, IIndexedObject
	{
		public static readonly PathNode Comparer;

		[CompilerGenerated]
		private T m_EventExporter;

		[CompilerGenerated]
		private float globalExporter;

		[CompilerGenerated]
		private float workerExporter;

		[CompilerGenerated]
		private float m_AccountExporter;

		[CompilerGenerated]
		private int stateExporter;

		[CompilerGenerated]
		private int m_AuthenticationExporter;

		[CompilerGenerated]
		private int paramsExporter;

		internal static object m_InfoExporter;

		public T UserContext
		{
			[CompilerGenerated]
			get
			{
				return m_EventExporter;
			}
			[CompilerGenerated]
			internal set
			{
				m_EventExporter = value;
			}
		}

		public float G
		{
			[CompilerGenerated]
			get
			{
				return globalExporter;
			}
			[CompilerGenerated]
			internal set
			{
				globalExporter = value;
			}
		}

		public float H
		{
			[CompilerGenerated]
			get
			{
				return workerExporter;
			}
			[CompilerGenerated]
			internal set
			{
				workerExporter = value;
			}
		}

		public float F
		{
			[CompilerGenerated]
			get
			{
				return m_AccountExporter;
			}
			[CompilerGenerated]
			internal set
			{
				m_AccountExporter = value;
			}
		}

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return stateExporter;
			}
			[CompilerGenerated]
			set
			{
				stateExporter = value;
			}
		}

		public int X
		{
			[CompilerGenerated]
			get
			{
				return m_AuthenticationExporter;
			}
			[CompilerGenerated]
			internal set
			{
				m_AuthenticationExporter = value;
			}
		}

		public int Y
		{
			[CompilerGenerated]
			get
			{
				return paramsExporter;
			}
			[CompilerGenerated]
			internal set
			{
				paramsExporter = value;
			}
		}

		public bool IsWalkable(TUserContext inContext)
		{
			return UserContext.IsWalkable(inContext);
		}

		public int Compare(PathNode x, PathNode y)
		{
			if (x.F < y.F)
			{
				return -1;
			}
			if (x.F <= y.F)
			{
				return 0;
			}
			return 1;
		}

		public PathNode(short short_0, short short_1, T inUserContext)
		{
			X = short_0;
			Y = short_1;
			UserContext = inUserContext;
		}

		static PathNode()
		{
			Comparer = new PathNode(0, 0, default(T));
		}

		internal static bool SortInterruptibleTemplate()
		{
			return m_InfoExporter == null;
		}
	}

	private class IndexerRegistryFilter
	{
		private PathNode[,] m_HelperExporter;

		[CompilerGenerated]
		private int getterExporter;

		private static object _ProducerExporter;

		public int Width { get; private set; }

		public int Height { get; private set; }

		public PathNode this[int int_0, int int_1] => m_HelperExporter[int_0, int_1];

		public PathNode this[PathNode pathNode_0] => m_HelperExporter[pathNode_0.X, pathNode_0.Y];

		[SpecialName]
		[CompilerGenerated]
		public int method_0()
		{
			return getterExporter;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_1(int int_0)
		{
			getterExporter = int_0;
		}

		[SpecialName]
		public bool method_2()
		{
			return method_0() == 0;
		}

		public IndexerRegistryFilter(int int_0, int int_1)
		{
			m_HelperExporter = new PathNode[int_0, int_1];
			Width = int_0;
			Height = int_1;
		}

		public void Add(PathNode pathNode_0)
		{
			_ = m_HelperExporter[pathNode_0.X, pathNode_0.Y];
			int num = method_0();
			method_1(num + 1);
			m_HelperExporter[pathNode_0.X, pathNode_0.Y] = pathNode_0;
		}

		public bool ManageInterruptibleTemplate(PathNode pathNode_0)
		{
			if (m_HelperExporter[pathNode_0.X, pathNode_0.Y] == null)
			{
				return false;
			}
			return true;
		}

		public void Remove(PathNode pathNode_0)
		{
			_ = m_HelperExporter[pathNode_0.X, pathNode_0.Y];
			int num = method_0();
			method_1(num - 1);
			m_HelperExporter[pathNode_0.X, pathNode_0.Y] = null;
		}

		public void RevertInterruptibleTemplate()
		{
			method_1(0);
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					m_HelperExporter[i, j] = null;
				}
			}
		}

		internal static bool CountInterruptibleMapping()
		{
			return _ProducerExporter == null;
		}
	}

	private IndexerRegistryFilter m_ConsumerCallback;

	private IndexerRegistryFilter facadeCallback;

	private ObserverCallback<PathNode> proxyCallback;

	private PathNode[,] _ReaderCallback;

	private IndexerRegistryFilter m_PropertyCallback;

	private PathNode[,] importerCallback;

	[CompilerGenerated]
	private T[,] repositoryCallback;

	[CompilerGenerated]
	private short bridgeCallback;

	private static readonly double _ClassCallback;

	internal static object _RequestCallback;

	public T[,] SearchSpace
	{
		[CompilerGenerated]
		get
		{
			return repositoryCallback;
		}
		[CompilerGenerated]
		private set
		{
			repositoryCallback = value;
		}
	}

	public short Width
	{
		[CompilerGenerated]
		get
		{
			return bridgeCallback;
		}
		[CompilerGenerated]
		private set
		{
			bridgeCallback = value;
		}
	}

	public short Height { get; private set; }

	public SpatialAStar(T[,] gparam_0)
	{
		SearchSpace = gparam_0;
		Width = (short)gparam_0.GetLength(0);
		Height = (short)gparam_0.GetLength(1);
		importerCallback = new PathNode[Width, Height];
		m_ConsumerCallback = new IndexerRegistryFilter(Width, Height);
		facadeCallback = new IndexerRegistryFilter(Width, Height);
		_ReaderCallback = new PathNode[Width, Height];
		m_PropertyCallback = new IndexerRegistryFilter(Width, Height);
		proxyCallback = new ObserverCallback<PathNode>(PathNode.Comparer);
		for (short num = 0; num < Width; num++)
		{
			short num2 = 0;
			while (num2 < Height)
			{
				if (gparam_0[num, num2] != null)
				{
					importerCallback[num, num2] = new PathNode(num, num2, gparam_0[num, num2]);
					num2++;
					continue;
				}
				throw new ArgumentNullException("Null exception at grid X:" + num + " - Y: " + num2);
			}
		}
	}

	protected virtual double Heuristic(PathNode pathNode_0, PathNode pathNode_1)
	{
		return Math.Sqrt((pathNode_0.X - pathNode_1.X) * (pathNode_0.X - pathNode_1.X) + (pathNode_0.Y - pathNode_1.Y) * (pathNode_0.Y - pathNode_1.Y));
	}

	protected virtual double NeighborDistance(PathNode pathNode_0, PathNode pathNode_1)
	{
		int num = Math.Abs(pathNode_0.X - pathNode_1.X);
		int num2 = Math.Abs(pathNode_0.Y - pathNode_1.Y);
		int num3 = num + num2;
		if (1 == 0)
		{
		}
		double result = num3 switch
		{
			0 => 0.0, 
			1 => 1.0, 
			2 => _ClassCallback, 
			_ => throw new ApplicationException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public LinkedList<T> Search(Point point_0, Point point_1, TUserContext inUserContext)
	{
		PathNode pathNode = importerCallback[point_0.X, point_0.Y];
		PathNode pathNode2 = importerCallback[point_1.X, point_1.Y];
		if (pathNode == pathNode2)
		{
			return new LinkedList<T>(new T[1] { pathNode.UserContext });
		}
		PathNode[] array = new PathNode[8];
		m_ConsumerCallback.RevertInterruptibleTemplate();
		facadeCallback.RevertInterruptibleTemplate();
		m_PropertyCallback.RevertInterruptibleTemplate();
		proxyCallback.ResolveCallback();
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				_ReaderCallback[i, j] = null;
			}
		}
		pathNode.G = 0f;
		pathNode.H = (float)Heuristic(pathNode, pathNode2);
		pathNode.F = pathNode.H;
		facadeCallback.Add(pathNode);
		proxyCallback.StopCallback(pathNode);
		m_PropertyCallback.Add(pathNode);
		int num = 0;
		while (true)
		{
			if (!facadeCallback.method_2())
			{
				PathNode pathNode3 = proxyCallback.CancelCallback();
				if (pathNode3 == pathNode2)
				{
					break;
				}
				facadeCallback.Remove(pathNode3);
				m_ConsumerCallback.Add(pathNode3);
				PublishCallback(pathNode3, array);
				PathNode[] array2 = array;
				PathNode[] array3 = array2;
				foreach (PathNode pathNode4 in array3)
				{
					if (pathNode4 == null || !pathNode4.UserContext.IsWalkable(inUserContext) || m_ConsumerCallback.ManageInterruptibleTemplate(pathNode4))
					{
						continue;
					}
					num++;
					double num2 = (double)m_PropertyCallback[pathNode3].G + NeighborDistance(pathNode3, pathNode4);
					bool flag = false;
					bool flag2;
					if (facadeCallback.ManageInterruptibleTemplate(pathNode4))
					{
						flag2 = ((num2 < (double)m_PropertyCallback[pathNode4].G) ? true : false);
					}
					else
					{
						facadeCallback.Add(pathNode4);
						flag2 = true;
						flag = true;
					}
					if (flag2)
					{
						_ReaderCallback[pathNode4.X, pathNode4.Y] = pathNode3;
						if (!m_PropertyCallback.ManageInterruptibleTemplate(pathNode4))
						{
							m_PropertyCallback.Add(pathNode4);
						}
						m_PropertyCallback[pathNode4].G = (float)num2;
						m_PropertyCallback[pathNode4].H = (float)Heuristic(pathNode4, pathNode2);
						m_PropertyCallback[pathNode4].F = m_PropertyCallback[pathNode4].G + m_PropertyCallback[pathNode4].H;
						if (flag)
						{
							proxyCallback.StopCallback(pathNode4);
						}
						else
						{
							proxyCallback.VerifyCallback(pathNode4);
						}
					}
				}
				continue;
			}
			return null;
		}
		LinkedList<T> linkedList = PrintCallback(_ReaderCallback, _ReaderCallback[pathNode2.X, pathNode2.Y]);
		linkedList.AddLast(pathNode2.UserContext);
		return linkedList;
	}

	private LinkedList<T> PrintCallback(PathNode[,] pathNode_0, PathNode pathNode_1)
	{
		LinkedList<T> linkedList = new LinkedList<T>();
		DefineCallback(pathNode_0, pathNode_1, linkedList);
		return linkedList;
	}

	private void DefineCallback(PathNode[,] pathNode_0, PathNode pathNode_1, LinkedList<T> linkedList_0)
	{
		PathNode pathNode = pathNode_0[pathNode_1.X, pathNode_1.Y];
		if (pathNode == null)
		{
			linkedList_0.AddLast(pathNode_1.UserContext);
			return;
		}
		DefineCallback(pathNode_0, pathNode, linkedList_0);
		linkedList_0.AddLast(pathNode_1.UserContext);
	}

	private void PublishCallback(PathNode pathNode_0, PathNode[] pathNode_1)
	{
		int x = pathNode_0.X;
		int y = pathNode_0.Y;
		if (x > 0 && y > 0)
		{
			pathNode_1[0] = importerCallback[x - 1, y - 1];
		}
		else
		{
			pathNode_1[0] = null;
		}
		if (y <= 0)
		{
			pathNode_1[1] = null;
		}
		else
		{
			pathNode_1[1] = importerCallback[x, y - 1];
		}
		if (x < Width - 1 && y > 0)
		{
			pathNode_1[2] = importerCallback[x + 1, y - 1];
		}
		else
		{
			pathNode_1[2] = null;
		}
		if (x <= 0)
		{
			pathNode_1[3] = null;
		}
		else
		{
			pathNode_1[3] = importerCallback[x - 1, y];
		}
		if (x < Width - 1)
		{
			pathNode_1[4] = importerCallback[x + 1, y];
		}
		else
		{
			pathNode_1[4] = null;
		}
		if (x > 0 && y < Height - 1)
		{
			pathNode_1[5] = importerCallback[x - 1, y + 1];
		}
		else
		{
			pathNode_1[5] = null;
		}
		if (y < Height - 1)
		{
			pathNode_1[6] = importerCallback[x, y + 1];
		}
		else
		{
			pathNode_1[6] = null;
		}
		if (x < Width - 1 && y < Height - 1)
		{
			pathNode_1[7] = importerCallback[x + 1, y + 1];
		}
		else
		{
			pathNode_1[7] = null;
		}
	}

	static SpatialAStar()
	{
		_ClassCallback = Math.Sqrt(2.0);
	}

	internal static bool AwakeCallback()
	{
		return _RequestCallback == null;
	}
}
