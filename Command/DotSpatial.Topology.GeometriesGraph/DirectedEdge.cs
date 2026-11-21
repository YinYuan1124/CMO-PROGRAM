using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class DirectedEdge : EdgeEnd
{
	private readonly int[] managerCollection = new int[3] { 0, -999, -999 };

	private EdgeRing _GetterCollection;

	private bool _ProducerCollection;

	private bool procCollection;

	private bool m_StructInstance;

	private EdgeRing _MerchantInstance;

	private DirectedEdge m_CallbackInstance;

	private DirectedEdge _DecoratorInstance;

	private DirectedEdge _ProcessInstance;

	public virtual int DepthDelta
	{
		get
		{
			int num = Edge.DepthDelta;
			if (!_ProducerCollection)
			{
				num = -num;
			}
			return num;
		}
	}

	public virtual EdgeRing EdgeRing
	{
		get
		{
			return _GetterCollection;
		}
		set
		{
			_GetterCollection = value;
		}
	}

	public virtual bool IsForward
	{
		get
		{
			return _ProducerCollection;
		}
		protected set
		{
			_ProducerCollection = value;
		}
	}

	public virtual bool IsInResult
	{
		get
		{
			return procCollection;
		}
		set
		{
			procCollection = value;
		}
	}

	public virtual bool IsInteriorAreaEdge
	{
		get
		{
			bool result = true;
			for (int i = 0; i < 2; i++)
			{
				if (!Label.IsArea(i) || Label.GetLocation(i, PositionType.Left) != 0 || Label.GetLocation(i, PositionType.Right) != 0)
				{
					result = false;
				}
			}
			return result;
		}
	}

	public virtual bool IsLineEdge
	{
		get
		{
			bool num = Label.IsLine(0) || Label.IsLine(1);
			bool flag = !Label.IsArea(0) || Label.AllPositionsEqual(0, LocationType.Exterior);
			bool flag2 = !Label.IsArea(1) || Label.AllPositionsEqual(1, LocationType.Exterior);
			return num && flag && flag2;
		}
	}

	public virtual bool IsVisited
	{
		get
		{
			return m_StructInstance;
		}
		set
		{
			m_StructInstance = value;
		}
	}

	public virtual EdgeRing MinEdgeRing
	{
		get
		{
			return _MerchantInstance;
		}
		set
		{
			_MerchantInstance = value;
		}
	}

	public virtual DirectedEdge Next
	{
		get
		{
			return m_CallbackInstance;
		}
		set
		{
			m_CallbackInstance = value;
		}
	}

	public virtual DirectedEdge NextMin
	{
		get
		{
			return _DecoratorInstance;
		}
		set
		{
			_DecoratorInstance = value;
		}
	}

	public virtual DirectedEdge Sym
	{
		get
		{
			return _ProcessInstance;
		}
		set
		{
			_ProcessInstance = value;
		}
	}

	public virtual bool VisitedEdge
	{
		get
		{
			if (m_StructInstance)
			{
				return _ProcessInstance.IsVisited;
			}
			return false;
		}
		set
		{
			m_StructInstance = value;
			_ProcessInstance.IsVisited = value;
		}
	}

	public DirectedEdge(Edge edge_0, bool bool_0)
		: base(edge_0)
	{
		_ProducerCollection = bool_0;
		if (_ProducerCollection)
		{
			base.Init(edge_0.GetCoordinate(0), edge_0.GetCoordinate(1));
		}
		else
		{
			int num = edge_0.NumPoints - 1;
			base.Init(edge_0.GetCoordinate(num), edge_0.GetCoordinate(num - 1));
		}
		PrepareParameter();
	}

	private void PrepareParameter()
	{
		Label = new Label(Edge.Label);
		if (!_ProducerCollection)
		{
			Label.Flip();
		}
	}

	public virtual int GetDepth(PositionType positionType_0)
	{
		return managerCollection[(int)positionType_0];
	}

	public virtual void SetDepth(PositionType positionType_0, int int_0)
	{
		if (managerCollection[(int)positionType_0] != -999 && managerCollection[(int)positionType_0] != int_0)
		{
			throw new TopologyException("Assigned depths do not match", Coordinate);
		}
		managerCollection[(int)positionType_0] = int_0;
	}

	public virtual void SetEdgeDepths(PositionType positionType_0, int int_0)
	{
		int num = Edge.DepthDelta;
		if (!_ProducerCollection)
		{
			num = -num;
		}
		int num2 = 1;
		if (positionType_0 == PositionType.Left)
		{
			num2 = -1;
		}
		PositionType positionType_ = Position.Opposite(positionType_0);
		int num3 = num * num2;
		int int_ = int_0 + num3;
		SetDepth(positionType_0, int_0);
		SetDepth(positionType_, int_);
	}

	public override void Write(StreamWriter streamWriter_0)
	{
		base.Write(streamWriter_0);
		streamWriter_0.Write(" " + managerCollection[1] + "/" + managerCollection[2]);
		streamWriter_0.Write(" (" + DepthDelta + ")");
		if (procCollection)
		{
			streamWriter_0.Write(" inResult");
		}
	}

	public virtual void WriteEdge(StreamWriter streamWriter_0)
	{
		Write(streamWriter_0);
		streamWriter_0.Write(" ");
		if (_ProducerCollection)
		{
			Edge.Write(streamWriter_0);
		}
		else
		{
			Edge.WriteReverse(streamWriter_0);
		}
	}

	public static int DepthFactor(LocationType locationType_0, LocationType locationType_1)
	{
		if (locationType_0 == LocationType.Exterior && locationType_1 == LocationType.Interior)
		{
			return 1;
		}
		if (locationType_0 == LocationType.Interior && locationType_1 == LocationType.Exterior)
		{
			return -1;
		}
		return 0;
	}
}
