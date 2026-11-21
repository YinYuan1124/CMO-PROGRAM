using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Algorithms;

[Author("Franco, Gustavo")]
public sealed class PathFinderFast : IPathFinder
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[Author("Franco, Gustavo")]
	internal struct MessagePrototype
	{
		public int m_ProductPrototype;

		public int m_AnnotationPrototype;

		public ushort m_IteratorPrototype;

		public ushort _InitializerPrototype;

		public byte Status;

		public bool _RolePrototype;

		public bool m_FactoryPrototype;
	}

	[Author("Franco, Gustavo")]
	internal class ConnectionDispatcherList : IComparer<int>
	{
		private MessagePrototype[] Area;

		public ConnectionDispatcherList(MessagePrototype[] messagePrototype_0)
		{
			Area = messagePrototype_0;
		}

		public int Compare(int x, int y)
		{
			if (Area[x].m_ProductPrototype <= Area[y].m_ProductPrototype)
			{
				if (Area[x].m_ProductPrototype < Area[y].m_ProductPrototype)
				{
					return -1;
				}
				return 0;
			}
			return 1;
		}
	}

	[CompilerGenerated]
	private PathFinderDebugHandler _DefinitionConfig;

	private int[,] valConfig;

	private PriorityQueueB<int> wrapperConfig;

	private List<PathFinderNode> observerConfig = new List<PathFinderNode>();

	private bool m_IssuerConfig;

	private bool clientConfig = true;

	private int m_DicConfig;

	private HeuristicFormula consumerConfig = HeuristicFormula.Manhattan;

	private bool m_FacadeConfig = true;

	private int proxyConfig = 2;

	private bool m_ReaderConfig;

	private bool _PropertyConfig;

	private bool m_ImporterConfig;

	private bool repositoryConfig = true;

	private bool _BridgeConfig;

	private bool invocationConfig;

	private int m_ClassConfig = 2000;

	private double requestConfig;

	private bool m_ValueConfig;

	private bool _TokenizerConfig;

	private MessagePrototype[] stubConfig;

	private byte writerConfig = 1;

	private byte m_SpecificationConfig = 2;

	private int watcherConfig;

	private int reponseConfig;

	private int descriptorConfig;

	private int poolConfig;

	private ushort m_TaskConfig;

	private ushort _FilterConfig;

	private ushort _TestsConfig;

	private ushort interpreterConfig;

	private int m_ContainerConfig;

	private ushort _ComposerConfig;

	private ushort m_ModelConfig;

	private int _AdvisorConfig;

	private ushort _CustomerConfig;

	private ushort m_SerializerConfig;

	private ushort m_RefConfig;

	private ushort _ErrorConfig;

	private bool _CodeConfig;

	private sbyte[,] connectionConfig = new sbyte[8, 2]
	{
		{ 0, -1 },
		{ 1, 0 },
		{ 0, 1 },
		{ -1, 0 },
		{ 1, -1 },
		{ 1, 1 },
		{ -1, 1 },
		{ -1, -1 }
	};

	private int _ContextConfig;

	private int _StatusConfig;

	private static readonly double proccesorConfig;

	public bool Stopped => clientConfig;

	public HeuristicFormula Formula
	{
		get
		{
			return consumerConfig;
		}
		set
		{
			consumerConfig = value;
		}
	}

	public bool Diagonals
	{
		get
		{
			return m_FacadeConfig;
		}
		set
		{
			m_FacadeConfig = value;
			if (m_FacadeConfig)
			{
				connectionConfig = new sbyte[8, 2]
				{
					{ 0, -1 },
					{ 1, 0 },
					{ 0, 1 },
					{ -1, 0 },
					{ 1, -1 },
					{ 1, 1 },
					{ -1, 1 },
					{ -1, -1 }
				};
			}
			else
			{
				connectionConfig = new sbyte[4, 2]
				{
					{ 0, -1 },
					{ 1, 0 },
					{ 0, 1 },
					{ -1, 0 }
				};
			}
		}
	}

	public bool HeavyDiagonals
	{
		get
		{
			return invocationConfig;
		}
		set
		{
			invocationConfig = value;
		}
	}

	public int HeuristicEstimate
	{
		get
		{
			return proxyConfig;
		}
		set
		{
			proxyConfig = value;
		}
	}

	public bool PunishChangeDirection
	{
		get
		{
			return m_ReaderConfig;
		}
		set
		{
			m_ReaderConfig = value;
		}
	}

	public bool PunishWalkingOnEdge
	{
		get
		{
			return _PropertyConfig;
		}
		set
		{
			_PropertyConfig = value;
		}
	}

	public bool TrimAutoNavPoints
	{
		get
		{
			return m_ImporterConfig;
		}
		set
		{
			m_ImporterConfig = value;
		}
	}

	public bool ReopenCloseNodes
	{
		get
		{
			return repositoryConfig;
		}
		set
		{
			repositoryConfig = value;
		}
	}

	public bool TieBreaker
	{
		get
		{
			return _BridgeConfig;
		}
		set
		{
			_BridgeConfig = value;
		}
	}

	public int SearchLimit
	{
		get
		{
			return m_ClassConfig;
		}
		set
		{
			m_ClassConfig = value;
		}
	}

	public int EdgeCost
	{
		get
		{
			return watcherConfig;
		}
		set
		{
			watcherConfig = value;
		}
	}

	public double CompletedTime
	{
		get
		{
			return requestConfig;
		}
		set
		{
			requestConfig = value;
		}
	}

	public bool DebugProgress
	{
		get
		{
			return m_ValueConfig;
		}
		set
		{
			m_ValueConfig = value;
		}
	}

	public bool DebugFoundPath
	{
		get
		{
			return _TokenizerConfig;
		}
		set
		{
			_TokenizerConfig = value;
		}
	}

	public event PathFinderDebugHandler PathFinderDebug
	{
		[CompilerGenerated]
		add
		{
			PathFinderDebugHandler pathFinderDebugHandler = _DefinitionConfig;
			PathFinderDebugHandler pathFinderDebugHandler2;
			do
			{
				pathFinderDebugHandler2 = pathFinderDebugHandler;
				PathFinderDebugHandler value2 = (PathFinderDebugHandler)Delegate.Combine(pathFinderDebugHandler2, value);
				pathFinderDebugHandler = Interlocked.CompareExchange(ref _DefinitionConfig, value2, pathFinderDebugHandler2);
			}
			while ((object)pathFinderDebugHandler != pathFinderDebugHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PathFinderDebugHandler pathFinderDebugHandler = _DefinitionConfig;
			PathFinderDebugHandler pathFinderDebugHandler2;
			do
			{
				pathFinderDebugHandler2 = pathFinderDebugHandler;
				PathFinderDebugHandler value2 = (PathFinderDebugHandler)Delegate.Remove(pathFinderDebugHandler2, value);
				pathFinderDebugHandler = Interlocked.CompareExchange(ref _DefinitionConfig, value2, pathFinderDebugHandler2);
			}
			while ((object)pathFinderDebugHandler != pathFinderDebugHandler2);
		}
	}

	[DllImport("kernel32.dll")]
	public unsafe static extern bool RtlZeroMemory(byte* pByte_0, int int_0);

	public PathFinderFast(int[,] int_0)
	{
		if (int_0 == null)
		{
			throw new Exception("Grid cannot be null");
		}
		valConfig = int_0;
		_CustomerConfig = (ushort)(valConfig.GetUpperBound(0) + 1);
		m_SerializerConfig = (ushort)(valConfig.GetUpperBound(1) + 1);
		m_RefConfig = (ushort)(_CustomerConfig - 1);
		_ErrorConfig = (ushort)Math.Log((int)m_SerializerConfig, 2.0);
		if (Math.Log((int)_CustomerConfig, 2.0) == (double)(int)Math.Log((int)_CustomerConfig, 2.0) && Math.Log((int)m_SerializerConfig, 2.0) == (double)(int)Math.Log((int)m_SerializerConfig, 2.0))
		{
			if (stubConfig == null || stubConfig.Length != _CustomerConfig * m_SerializerConfig)
			{
				stubConfig = new MessagePrototype[_CustomerConfig * m_SerializerConfig];
			}
			wrapperConfig = new PriorityQueueB<int>(new ConnectionDispatcherList(stubConfig));
			return;
		}
		throw new Exception("Invalid Grid, size in X and Y must be power of 2");
	}

	public void FindPathStop()
	{
		m_IssuerConfig = true;
	}

	public List<PathFinderNode> FindPath(Point point_0, Point point_1)
	{
		lock (this)
		{
			HighResolutionTime.Start();
			_CodeConfig = false;
			m_IssuerConfig = false;
			clientConfig = false;
			_AdvisorConfig = 0;
			writerConfig += 2;
			m_SpecificationConfig += 2;
			wrapperConfig.Clear();
			observerConfig.Clear();
			if (m_ValueConfig && _DefinitionConfig != null)
			{
				_DefinitionConfig(0, 0, point_0.X, point_0.Y, PathFinderNodeType.Start, -1, -1);
			}
			if (m_ValueConfig && _DefinitionConfig != null)
			{
				_DefinitionConfig(0, 0, point_1.X, point_1.Y, PathFinderNodeType.End, -1, -1);
			}
			descriptorConfig = (point_0.Y << (int)_ErrorConfig) + point_0.X;
			_ContextConfig = (point_1.Y << (int)_ErrorConfig) + point_1.X;
			stubConfig[descriptorConfig].m_AnnotationPrototype = 0;
			stubConfig[descriptorConfig].m_ProductPrototype = proxyConfig;
			stubConfig[descriptorConfig].m_IteratorPrototype = (ushort)point_0.X;
			stubConfig[descriptorConfig]._InitializerPrototype = (ushort)point_0.Y;
			stubConfig[descriptorConfig].Status = writerConfig;
			wrapperConfig.Push(descriptorConfig);
			while (wrapperConfig.Count > 0 && !m_IssuerConfig)
			{
				descriptorConfig = wrapperConfig.Pop();
				if (stubConfig[descriptorConfig].Status == m_SpecificationConfig)
				{
					continue;
				}
				m_TaskConfig = (ushort)(descriptorConfig & m_RefConfig);
				_FilterConfig = (ushort)(descriptorConfig >> (int)_ErrorConfig);
				if (m_ValueConfig && _DefinitionConfig != null)
				{
					_DefinitionConfig(0, 0, descriptorConfig & m_RefConfig, descriptorConfig >> (int)_ErrorConfig, PathFinderNodeType.Current, -1, -1);
				}
				if (descriptorConfig != _ContextConfig)
				{
					if (_AdvisorConfig <= m_ClassConfig)
					{
						if (m_ReaderConfig)
						{
							m_DicConfig = m_TaskConfig - stubConfig[descriptorConfig].m_IteratorPrototype;
						}
						for (int i = 0; i < (m_FacadeConfig ? 8 : 4); i++)
						{
							_TestsConfig = (ushort)(m_TaskConfig + connectionConfig[i, 0]);
							interpreterConfig = (ushort)(_FilterConfig + connectionConfig[i, 1]);
							poolConfig = (interpreterConfig << (int)_ErrorConfig) + _TestsConfig;
							if (_TestsConfig >= _CustomerConfig || interpreterConfig >= m_SerializerConfig || (stubConfig[poolConfig].Status == m_SpecificationConfig && !repositoryConfig) || valConfig[_TestsConfig, interpreterConfig] == 0)
							{
								continue;
							}
							if (valConfig[_TestsConfig, interpreterConfig] == watcherConfig)
							{
								stubConfig[poolConfig]._RolePrototype = true;
							}
							if (invocationConfig && i > 3)
							{
								_StatusConfig = stubConfig[descriptorConfig].m_AnnotationPrototype + (int)((double)valConfig[_TestsConfig, interpreterConfig] * 2.41);
							}
							else if (i <= 3)
							{
								_StatusConfig = stubConfig[descriptorConfig].m_AnnotationPrototype + valConfig[_TestsConfig, interpreterConfig];
							}
							else
							{
								_StatusConfig = stubConfig[descriptorConfig].m_AnnotationPrototype + (int)((double)valConfig[_TestsConfig, interpreterConfig] * proccesorConfig);
							}
							if (m_ReaderConfig)
							{
								if (_TestsConfig - m_TaskConfig != 0 && m_DicConfig == 0)
								{
									_StatusConfig += Math.Abs(_TestsConfig - point_1.X) + Math.Abs(interpreterConfig - point_1.Y);
								}
								if (interpreterConfig - _FilterConfig != 0 && m_DicConfig != 0)
								{
									_StatusConfig += Math.Abs(_TestsConfig - point_1.X) + Math.Abs(interpreterConfig - point_1.Y);
								}
							}
							if ((stubConfig[poolConfig].Status != writerConfig && stubConfig[poolConfig].Status != m_SpecificationConfig) || stubConfig[poolConfig].m_AnnotationPrototype > _StatusConfig)
							{
								stubConfig[poolConfig].m_IteratorPrototype = m_TaskConfig;
								stubConfig[poolConfig]._InitializerPrototype = _FilterConfig;
								stubConfig[poolConfig].m_AnnotationPrototype = _StatusConfig;
								switch (consumerConfig)
								{
								default:
									reponseConfig = proxyConfig * (Math.Abs(_TestsConfig - point_1.X) + Math.Abs(interpreterConfig - point_1.Y));
									break;
								case HeuristicFormula.MaxDXDY:
									reponseConfig = proxyConfig * Math.Max(Math.Abs(_TestsConfig - point_1.X), Math.Abs(interpreterConfig - point_1.Y));
									break;
								case HeuristicFormula.DiagonalShortCut:
								{
									int num3 = Math.Min(Math.Abs(_TestsConfig - point_1.X), Math.Abs(interpreterConfig - point_1.Y));
									int num4 = Math.Abs(_TestsConfig - point_1.X) + Math.Abs(interpreterConfig - point_1.Y);
									reponseConfig = proxyConfig * 2 * num3 + proxyConfig * (num4 - 2 * num3);
									break;
								}
								case HeuristicFormula.Euclidean:
									reponseConfig = (int)((double)proxyConfig * Math.Sqrt(Math.Pow(_TestsConfig - point_1.X, 2.0) + Math.Pow(interpreterConfig - point_1.Y, 2.0)));
									break;
								case HeuristicFormula.EuclideanNoSQR:
									reponseConfig = (int)((double)proxyConfig * (Math.Pow(_TestsConfig - point_1.X, 2.0) + Math.Pow(interpreterConfig - point_1.Y, 2.0)));
									break;
								case HeuristicFormula.Custom1:
								{
									Point point = new Point(Math.Abs(point_1.X - _TestsConfig), Math.Abs(point_1.Y - interpreterConfig));
									int num = Math.Abs(point.X - point.Y);
									int num2 = Math.Abs((point.X + point.Y - num) / 2);
									reponseConfig = proxyConfig * (num2 + num + point.X + point.Y);
									break;
								}
								}
								if (_BridgeConfig)
								{
									int num5 = m_TaskConfig - point_1.X;
									int num6 = _FilterConfig - point_1.Y;
									int num7 = point_0.X - point_1.X;
									int num8 = point_0.Y - point_1.Y;
									int num9 = Math.Abs(num5 * num8 - num7 * num6);
									reponseConfig = (int)((double)reponseConfig + (double)num9 * 0.001);
								}
								stubConfig[poolConfig].m_ProductPrototype = _StatusConfig + reponseConfig;
								if (m_ValueConfig && _DefinitionConfig != null)
								{
									_DefinitionConfig(m_TaskConfig, _FilterConfig, _TestsConfig, interpreterConfig, PathFinderNodeType.Open, stubConfig[poolConfig].m_ProductPrototype, stubConfig[poolConfig].m_AnnotationPrototype);
								}
								wrapperConfig.Push(poolConfig);
								stubConfig[poolConfig].Status = writerConfig;
							}
						}
						_AdvisorConfig++;
						stubConfig[descriptorConfig].Status = m_SpecificationConfig;
						if (m_ValueConfig && _DefinitionConfig != null)
						{
							_DefinitionConfig(0, 0, m_TaskConfig, _FilterConfig, PathFinderNodeType.Close, stubConfig[descriptorConfig].m_ProductPrototype, stubConfig[descriptorConfig].m_AnnotationPrototype);
						}
						continue;
					}
					clientConfig = true;
					requestConfig = HighResolutionTime.GetTime();
					return null;
				}
				stubConfig[descriptorConfig].Status = m_SpecificationConfig;
				_CodeConfig = true;
				break;
			}
			if (_PropertyConfig)
			{
				for (int j = 0; j < (m_FacadeConfig ? 8 : 4); j++)
				{
					ushort num10 = (ushort)(point_0.X + connectionConfig[j, 0]);
					ushort num11 = (ushort)(point_0.Y + connectionConfig[j, 1]);
					if (num10 < _CustomerConfig && num11 < m_SerializerConfig && valConfig[num10, num11] == 0)
					{
						stubConfig[descriptorConfig]._RolePrototype = true;
						break;
					}
				}
				for (int k = 0; k < (m_FacadeConfig ? 8 : 4); k++)
				{
					ushort num12 = (ushort)(point_1.X + connectionConfig[k, 0]);
					ushort num13 = (ushort)(point_1.Y + connectionConfig[k, 1]);
					if (num12 < _CustomerConfig && num13 < m_SerializerConfig && valConfig[num12, num13] == 0)
					{
						stubConfig[_ContextConfig]._RolePrototype = true;
						break;
					}
				}
			}
			requestConfig = HighResolutionTime.GetTime();
			if (_CodeConfig)
			{
				observerConfig.Clear();
				int x = point_1.X;
				int y = point_1.Y;
				MessagePrototype messagePrototype = stubConfig[(point_1.Y << (int)_ErrorConfig) + point_1.X];
				PathFinderNode item = default(PathFinderNode);
				item.F = messagePrototype.m_ProductPrototype;
				item.G = messagePrototype.m_AnnotationPrototype;
				item.H = 0;
				item.PX = messagePrototype.m_IteratorPrototype;
				item.PY = messagePrototype._InitializerPrototype;
				item.X = point_1.X;
				item.Y = point_1.Y;
				item.E = messagePrototype._RolePrototype;
				item.W = messagePrototype.m_FactoryPrototype;
				while (item.X != item.PX || item.Y != item.PY)
				{
					observerConfig.Add(item);
					if (_TokenizerConfig && _DefinitionConfig != null)
					{
						_DefinitionConfig(item.PX, item.PY, item.X, item.Y, PathFinderNodeType.Path, item.F, item.G);
					}
					x = item.PX;
					y = item.PY;
					messagePrototype = stubConfig[(y << (int)_ErrorConfig) + x];
					item.F = messagePrototype.m_ProductPrototype;
					item.G = messagePrototype.m_AnnotationPrototype;
					item.H = 0;
					item.PX = messagePrototype.m_IteratorPrototype;
					item.PY = messagePrototype._InitializerPrototype;
					item.X = x;
					item.Y = y;
					item.E = messagePrototype._RolePrototype;
					item.W = messagePrototype.m_FactoryPrototype;
				}
				observerConfig.Add(item);
				if (_TokenizerConfig && _DefinitionConfig != null)
				{
					_DefinitionConfig(item.PX, item.PY, item.X, item.Y, PathFinderNodeType.Path, item.F, item.G);
				}
				int int_ = observerConfig.Count;
				if (m_ImporterConfig && int_ > 0)
				{
					List<PathFinderNode> list = new List<PathFinderNode>();
					for (int int_2 = int_ - 1; int_2 > -1; int_2--)
					{
						PathFinderNode pathFinderNode_ = observerConfig[int_2];
						if (FindWaypoint(ref int_2, ref int_, ref pathFinderNode_, bool_0: false))
						{
							pathFinderNode_ = observerConfig[int_2];
							pathFinderNode_.W = true;
							observerConfig[int_2] = pathFinderNode_;
						}
					}
					for (int l = 0; l < int_; l++)
					{
						PathFinderNode pathFinderNode_2 = observerConfig[l];
						if (!pathFinderNode_2.W && (l >= int_ - 1 || !observerConfig[l + 1].W) && (l <= 1 || !observerConfig[l - 1].W) && FindWaypoint(ref l, ref int_, ref pathFinderNode_2, bool_0: true))
						{
							pathFinderNode_2 = observerConfig[l];
							pathFinderNode_2.W = true;
							observerConfig[l] = pathFinderNode_2;
						}
					}
					for (int m = 0; m < int_; m++)
					{
						PathFinderNode item2 = observerConfig[m];
						if (item2.W)
						{
							list.Add(item2);
						}
					}
					if (list.Count > 0)
					{
						observerConfig = null;
						observerConfig = list;
					}
				}
				clientConfig = true;
				return observerConfig;
			}
			clientConfig = true;
			return null;
		}
	}

	public bool FindWaypoint(ref int int_0, ref int int_1, ref PathFinderNode pathFinderNode_0, bool bool_0)
	{
		int num = -1;
		if (int_0 == int_1 - 1)
		{
			if (pathFinderNode_0.E)
			{
				return true;
			}
			return false;
		}
		if (int_0 == 0)
		{
			if (pathFinderNode_0.E)
			{
				return true;
			}
			return false;
		}
		if (pathFinderNode_0.E)
		{
			return true;
		}
		int x = pathFinderNode_0.X;
		int y = pathFinderNode_0.Y;
		int num2;
		int num3;
		if (bool_0)
		{
			int x2 = observerConfig[int_0 - 1].X;
			int y2 = observerConfig[int_0 - 1].Y;
			num2 = x2 - x;
			num3 = y2 - y;
		}
		else
		{
			int x3 = observerConfig[int_0 + 1].X;
			int y3 = observerConfig[int_0 + 1].Y;
			num2 = x - x3;
			num3 = y - y3;
		}
		if (num2 <= 0)
		{
			if (num2 < 0)
			{
				num = ((num3 > 0) ? 7 : ((num3 < 0) ? 5 : 6));
			}
			else if (num3 <= 0)
			{
				if (num3 >= 0)
				{
					return false;
				}
				num = 4;
			}
			else
			{
				num = 0;
			}
		}
		else
		{
			num = ((num3 > 0) ? 1 : ((num3 < 0) ? 3 : 2));
		}
		int x4 = pathFinderNode_0.X;
		int x5 = pathFinderNode_0.X;
		int y4 = pathFinderNode_0.Y;
		int y5 = pathFinderNode_0.Y;
		int num4 = int_0;
		while (true)
		{
			int num5;
			if (num4 >= 1)
			{
				if (num4 > int_1 - 2)
				{
					break;
				}
				PathFinderNode pathFinderNode = observerConfig[num4];
				PathFinderNode pathFinderNode2;
				if (bool_0)
				{
					pathFinderNode2 = observerConfig[num4 + 1];
					num2 = pathFinderNode.X - pathFinderNode2.X;
					num3 = pathFinderNode.Y - pathFinderNode2.Y;
				}
				else
				{
					pathFinderNode2 = observerConfig[num4 - 1];
					num2 = pathFinderNode2.X - pathFinderNode.X;
					num3 = pathFinderNode2.Y - pathFinderNode.Y;
				}
				switch (num)
				{
				case 0:
					if (num2 > Math.Abs(num3))
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 1:
					if (num3 < 0 || num2 < 0)
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 2:
					if (num3 > Math.Abs(num2))
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 3:
					if (num3 > 0 || num2 < 0)
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 4:
					if (Math.Abs(num2) > Math.Abs(num3))
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 5:
					if (num3 > 0 || num2 > 0)
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 6:
					if (Math.Abs(num3) > Math.Abs(num2))
					{
						int_0 = num4;
						return true;
					}
					goto default;
				case 7:
					if (num3 < 0 || num2 > 0)
					{
						break;
					}
					goto default;
				default:
					if (pathFinderNode2.X <= x4)
					{
						if (pathFinderNode2.X < x5)
						{
							x5 = pathFinderNode2.X;
							for (int i = y5; i <= y4; i++)
							{
								if (valConfig[pathFinderNode2.X, i] == 0 || pathFinderNode2.E)
								{
									int_0 = num4;
									return true;
								}
							}
						}
					}
					else
					{
						x4 = pathFinderNode2.X;
						for (int j = y5; j <= y4; j++)
						{
							if (valConfig[pathFinderNode2.X, j] == 0 || pathFinderNode2.E)
							{
								int_0 = num4;
								return true;
							}
						}
					}
					if (pathFinderNode2.Y <= y4)
					{
						if (pathFinderNode2.Y < y5)
						{
							y5 = pathFinderNode2.Y;
							for (int k = x5; k <= x4; k++)
							{
								if (valConfig[k, pathFinderNode2.Y] == 0 || pathFinderNode2.E)
								{
									int_0 = num4;
									return true;
								}
							}
						}
					}
					else
					{
						y4 = pathFinderNode2.Y;
						for (int l = x5; l <= x4; l++)
						{
							if (valConfig[l, pathFinderNode2.Y] == 0 || pathFinderNode2.E)
							{
								int_0 = num4;
								return true;
							}
						}
					}
					num5 = (bool_0 ? (num4 + 1) : (num4 - 1));
					goto IL_0380;
				}
				int_0 = num4;
				return true;
			}
			int_0 = num4 + 1;
			return false;
			IL_0380:
			num4 = num5;
		}
		int_0 = num4 - 1;
		return false;
	}

	static PathFinderFast()
	{
		proccesorConfig = Math.Sqrt(2.0);
	}
}
