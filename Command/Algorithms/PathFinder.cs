using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Algorithms;

[Author("Franco, Gustavo")]
public sealed class PathFinder : IPathFinder
{
	[Author("Franco, Gustavo")]
	internal class ExporterThreadBridge : IComparer<PathFinderNode>
	{
		public int Compare(PathFinderNode x, PathFinderNode y)
		{
			if (x.F <= y.F)
			{
				if (x.F < y.F)
				{
					return -1;
				}
				return 0;
			}
			return 1;
		}
	}

	[CompilerGenerated]
	private PathFinderDebugHandler producerListener;

	private int[,] procListener;

	private PriorityQueueB<PathFinderNode> structConfig = new PriorityQueueB<PathFinderNode>(new ExporterThreadBridge());

	private List<PathFinderNode> m_MerchantConfig = new List<PathFinderNode>();

	private bool m_CallbackConfig;

	private bool decoratorConfig = true;

	private int m_ProcessConfig;

	private HeuristicFormula _ThreadConfig = HeuristicFormula.Manhattan;

	private bool _RuleConfig = true;

	private int collectionConfig = 2;

	private bool _InstanceConfig;

	private bool objectConfig;

	private bool parameterConfig;

	private bool m_ExpressionConfig;

	private int dispatcherConfig = 2000;

	private double m_ListenerConfig;

	private bool _ConfigConfig;

	private bool m_RegistryConfig;

	public bool Stopped => decoratorConfig;

	public HeuristicFormula Formula
	{
		get
		{
			return _ThreadConfig;
		}
		set
		{
			_ThreadConfig = value;
		}
	}

	public bool Diagonals
	{
		get
		{
			return _RuleConfig;
		}
		set
		{
			_RuleConfig = value;
		}
	}

	public bool HeavyDiagonals
	{
		get
		{
			return m_ExpressionConfig;
		}
		set
		{
			m_ExpressionConfig = value;
		}
	}

	public int HeuristicEstimate
	{
		get
		{
			return collectionConfig;
		}
		set
		{
			collectionConfig = value;
		}
	}

	public bool PunishChangeDirection
	{
		get
		{
			return _InstanceConfig;
		}
		set
		{
			_InstanceConfig = value;
		}
	}

	public bool ReopenCloseNodes
	{
		get
		{
			return objectConfig;
		}
		set
		{
			objectConfig = value;
		}
	}

	public bool TieBreaker
	{
		get
		{
			return parameterConfig;
		}
		set
		{
			parameterConfig = value;
		}
	}

	public int SearchLimit
	{
		get
		{
			return dispatcherConfig;
		}
		set
		{
			dispatcherConfig = value;
		}
	}

	public double CompletedTime
	{
		get
		{
			return m_ListenerConfig;
		}
		set
		{
			m_ListenerConfig = value;
		}
	}

	public bool DebugProgress
	{
		get
		{
			return _ConfigConfig;
		}
		set
		{
			_ConfigConfig = value;
		}
	}

	public bool DebugFoundPath
	{
		get
		{
			return m_RegistryConfig;
		}
		set
		{
			m_RegistryConfig = value;
		}
	}

	public event PathFinderDebugHandler PathFinderDebug
	{
		[CompilerGenerated]
		add
		{
			PathFinderDebugHandler pathFinderDebugHandler = producerListener;
			PathFinderDebugHandler pathFinderDebugHandler2;
			do
			{
				pathFinderDebugHandler2 = pathFinderDebugHandler;
				PathFinderDebugHandler value2 = (PathFinderDebugHandler)Delegate.Combine(pathFinderDebugHandler2, value);
				pathFinderDebugHandler = Interlocked.CompareExchange(ref producerListener, value2, pathFinderDebugHandler2);
			}
			while ((object)pathFinderDebugHandler != pathFinderDebugHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PathFinderDebugHandler pathFinderDebugHandler = producerListener;
			PathFinderDebugHandler pathFinderDebugHandler2;
			do
			{
				pathFinderDebugHandler2 = pathFinderDebugHandler;
				PathFinderDebugHandler value2 = (PathFinderDebugHandler)Delegate.Remove(pathFinderDebugHandler2, value);
				pathFinderDebugHandler = Interlocked.CompareExchange(ref producerListener, value2, pathFinderDebugHandler2);
			}
			while ((object)pathFinderDebugHandler != pathFinderDebugHandler2);
		}
	}

	[DllImport("kernel32.dll")]
	public unsafe static extern bool RtlZeroMemory(byte* pByte_0, int int_0);

	public PathFinder(int[,] int_0)
	{
		if (int_0 == null)
		{
			throw new Exception("Grid cannot be null");
		}
		procListener = int_0;
	}

	public void FindPathStop()
	{
		m_CallbackConfig = true;
	}

	public List<PathFinderNode> FindPath(Point point_0, Point point_1)
	{
		HighResolutionTime.Start();
		bool flag = false;
		int upperBound = procListener.GetUpperBound(0);
		int upperBound2 = procListener.GetUpperBound(1);
		m_CallbackConfig = false;
		decoratorConfig = false;
		structConfig.Clear();
		m_MerchantConfig.Clear();
		if (_ConfigConfig && producerListener != null)
		{
			producerListener(0, 0, point_0.X, point_0.Y, PathFinderNodeType.Start, -1, -1);
		}
		if (_ConfigConfig && producerListener != null)
		{
			producerListener(0, 0, point_1.X, point_1.Y, PathFinderNodeType.End, -1, -1);
		}
		sbyte[,] array = ((!_RuleConfig) ? new sbyte[4, 2]
		{
			{ 0, -1 },
			{ 1, 0 },
			{ 0, 1 },
			{ -1, 0 }
		} : new sbyte[8, 2]
		{
			{ 0, -1 },
			{ 1, 0 },
			{ 0, 1 },
			{ -1, 0 },
			{ 1, -1 },
			{ 1, 1 },
			{ -1, 1 },
			{ -1, -1 }
		});
		PathFinderNode item = default(PathFinderNode);
		item.G = 0;
		item.H = collectionConfig;
		item.F = item.G + item.H;
		item.X = point_0.X;
		item.Y = point_0.Y;
		item.PX = item.X;
		item.PY = item.Y;
		item.E = false;
		item.W = false;
		structConfig.Push(item);
		PathFinderNode item2 = default(PathFinderNode);
		while (structConfig.Count > 0 && !m_CallbackConfig)
		{
			item = structConfig.Pop();
			if (_ConfigConfig && producerListener != null)
			{
				producerListener(0, 0, item.X, item.Y, PathFinderNodeType.Current, -1, -1);
			}
			if (item.X != point_1.X || item.Y != point_1.Y)
			{
				if (m_MerchantConfig.Count <= dispatcherConfig)
				{
					if (_InstanceConfig)
					{
						m_ProcessConfig = item.X - item.PX;
					}
					for (int i = 0; i < (_RuleConfig ? 8 : 4); i++)
					{
						item2.X = item.X + array[i, 0];
						item2.Y = item.Y + array[i, 1];
						item2.E = false;
						item2.W = false;
						if (item2.X < 0 || item2.Y < 0 || item2.X >= upperBound || item2.Y >= upperBound2)
						{
							continue;
						}
						int num = ((!m_ExpressionConfig || i <= 3) ? (item.G + procListener[item2.X, item2.Y]) : (item.G + (int)((double)procListener[item2.X, item2.Y] * 2.41)));
						if (num == item.G)
						{
							continue;
						}
						if (_InstanceConfig)
						{
							if (item2.X - item.X != 0 && m_ProcessConfig == 0)
							{
								num += 20;
							}
							if (item2.Y - item.Y != 0 && m_ProcessConfig != 0)
							{
								num += 20;
							}
						}
						int num2 = -1;
						for (int j = 0; j < structConfig.Count; j++)
						{
							if (structConfig[j].X == item2.X && structConfig[j].Y == item2.Y)
							{
								num2 = j;
								break;
							}
						}
						if (num2 != -1 && structConfig[num2].G <= num)
						{
							continue;
						}
						int num3 = -1;
						for (int k = 0; k < m_MerchantConfig.Count; k++)
						{
							if (m_MerchantConfig[k].X == item2.X && m_MerchantConfig[k].Y == item2.Y)
							{
								num3 = k;
								break;
							}
						}
						if (num3 == -1 || (!objectConfig && m_MerchantConfig[num3].G > num))
						{
							item2.PX = item.X;
							item2.PY = item.Y;
							item2.G = num;
							switch (_ThreadConfig)
							{
							default:
								item2.H = collectionConfig * (Math.Abs(item2.X - point_1.X) + Math.Abs(item2.Y - point_1.Y));
								break;
							case HeuristicFormula.MaxDXDY:
								item2.H = collectionConfig * Math.Max(Math.Abs(item2.X - point_1.X), Math.Abs(item2.Y - point_1.Y));
								break;
							case HeuristicFormula.DiagonalShortCut:
							{
								int num6 = Math.Min(Math.Abs(item2.X - point_1.X), Math.Abs(item2.Y - point_1.Y));
								int num7 = Math.Abs(item2.X - point_1.X) + Math.Abs(item2.Y - point_1.Y);
								item2.H = collectionConfig * 2 * num6 + collectionConfig * (num7 - 2 * num6);
								break;
							}
							case HeuristicFormula.Euclidean:
								item2.H = (int)((double)collectionConfig * Math.Sqrt(Math.Pow(item2.X - point_1.X, 2.0) + Math.Pow(item2.Y - point_1.Y, 2.0)));
								break;
							case HeuristicFormula.EuclideanNoSQR:
								item2.H = (int)((double)collectionConfig * (Math.Pow(item2.X - point_1.X, 2.0) + Math.Pow(item2.Y - point_1.Y, 2.0)));
								break;
							case HeuristicFormula.Custom1:
							{
								Point point = new Point(Math.Abs(point_1.X - item2.X), Math.Abs(point_1.Y - item2.Y));
								int num4 = Math.Abs(point.X - point.Y);
								int num5 = Math.Abs((point.X + point.Y - num4) / 2);
								item2.H = collectionConfig * (num5 + num4 + point.X + point.Y);
								break;
							}
							}
							if (parameterConfig)
							{
								int num8 = item.X - point_1.X;
								int num9 = item.Y - point_1.Y;
								int num10 = point_0.X - point_1.X;
								int num11 = point_0.Y - point_1.Y;
								int num12 = Math.Abs(num8 * num11 - num10 * num9);
								item2.H = (int)((double)item2.H + (double)num12 * 0.001);
							}
							item2.F = item2.G + item2.H;
							if (_ConfigConfig && producerListener != null)
							{
								producerListener(item.X, item.Y, item2.X, item2.Y, PathFinderNodeType.Open, item2.F, item2.G);
							}
							structConfig.Push(item2);
						}
					}
					m_MerchantConfig.Add(item);
					if (_ConfigConfig && producerListener != null)
					{
						producerListener(0, 0, item.X, item.Y, PathFinderNodeType.Close, item.F, item.G);
					}
					continue;
				}
				decoratorConfig = true;
				return null;
			}
			m_MerchantConfig.Add(item);
			flag = true;
			break;
		}
		m_ListenerConfig = HighResolutionTime.GetTime();
		if (flag)
		{
			PathFinderNode pathFinderNode = m_MerchantConfig[m_MerchantConfig.Count - 1];
			for (int num13 = m_MerchantConfig.Count - 1; num13 >= 0; num13--)
			{
				if ((pathFinderNode.PX == m_MerchantConfig[num13].X && pathFinderNode.PY == m_MerchantConfig[num13].Y) || num13 == m_MerchantConfig.Count - 1)
				{
					if (m_RegistryConfig && producerListener != null)
					{
						producerListener(pathFinderNode.X, pathFinderNode.Y, m_MerchantConfig[num13].X, m_MerchantConfig[num13].Y, PathFinderNodeType.Path, m_MerchantConfig[num13].F, m_MerchantConfig[num13].G);
					}
					pathFinderNode = m_MerchantConfig[num13];
				}
				else
				{
					m_MerchantConfig.RemoveAt(num13);
				}
			}
			decoratorConfig = true;
			return m_MerchantConfig;
		}
		decoratorConfig = true;
		return null;
	}
}
