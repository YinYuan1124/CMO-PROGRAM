using System;
using System.Text;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Algorithm;

public abstract class LineIntersector
{
	private Coordinate[,] m_WorkerInstance = new Coordinate[2, 2];

	private int[,] accountInstance;

	private Coordinate[] stateInstance = new Coordinate[2];

	private bool m_AuthenticationInstance;

	private PrecisionModel paramsInstance;

	private IntersectionType m_InfoInstance;

	protected Coordinate PointA
	{
		get
		{
			return stateInstance[0];
		}
		set
		{
			stateInstance[0] = value;
		}
	}

	protected Coordinate PointB
	{
		get
		{
			return stateInstance[0];
		}
		set
		{
			stateInstance[0] = value;
		}
	}

	[Obsolete("Use PrecisionModel instead")]
	public virtual PrecisionModel MakePrecise
	{
		set
		{
			paramsInstance = value;
		}
	}

	public virtual PrecisionModel PrecisionModel
	{
		get
		{
			return paramsInstance;
		}
		set
		{
			paramsInstance = value;
		}
	}

	public virtual bool HasIntersection => m_InfoInstance != IntersectionType.NoIntersection;

	public virtual int IntersectionNum => (int)m_InfoInstance;

	public Coordinate[] IntersectionPoints
	{
		get
		{
			return stateInstance;
		}
		protected set
		{
			stateInstance = value;
		}
	}

	protected Coordinate[,] InputLines
	{
		get
		{
			return m_WorkerInstance;
		}
		set
		{
			m_WorkerInstance = value;
		}
	}

	protected virtual bool IsCollinear => m_InfoInstance == IntersectionType.Collinear;

	protected virtual bool IsEndPoint
	{
		get
		{
			if (HasIntersection)
			{
				return !m_AuthenticationInstance;
			}
			return false;
		}
	}

	public virtual bool IsProper
	{
		get
		{
			if (HasIntersection)
			{
				return m_AuthenticationInstance;
			}
			return false;
		}
		protected set
		{
			m_AuthenticationInstance = value;
		}
	}

	protected IntersectionType Result
	{
		get
		{
			return m_InfoInstance;
		}
		set
		{
			m_InfoInstance = value;
		}
	}

	protected LineIntersector()
	{
		stateInstance[0] = new Coordinate();
		stateInstance[1] = new Coordinate();
		m_InfoInstance = IntersectionType.NoIntersection;
	}

	public static double ComputeEdgeDistance(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		double num = Math.Abs(coordinate_2.X - coordinate_1.X);
		double num2 = Math.Abs(coordinate_2.Y - coordinate_1.Y);
		double num3;
		if (coordinate_0.Equals(coordinate_1))
		{
			num3 = 0.0;
		}
		else if (coordinate_0.Equals(coordinate_2))
		{
			num3 = ((num <= num2) ? num2 : num);
		}
		else
		{
			double num4 = Math.Abs(coordinate_0.X - coordinate_1.X);
			double num5 = Math.Abs(coordinate_0.Y - coordinate_1.Y);
			num3 = ((num <= num2) ? num5 : num4);
			if (num3 == 0.0 && !coordinate_0.Equals(coordinate_1))
			{
				num3 = Math.Max(num4, num5);
			}
		}
		Assert.IsTrue(num3 != 0.0 || coordinate_0.Equals(coordinate_1), "Bad distance calculation");
		return num3;
	}

	public static double NonRobustComputeEdgeDistance(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		double num = coordinate_0.X - coordinate_1.X;
		double num2 = coordinate_0.Y - coordinate_1.Y;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		Assert.IsTrue(num3 != 0.0 || coordinate_0.Equals(coordinate_1), "Invalid distance calculation");
		return num3;
	}

	public abstract void ComputeIntersection(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2);

	public virtual void ComputeIntersection(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		m_WorkerInstance[0, 0] = new Coordinate(coordinate_0);
		m_WorkerInstance[0, 1] = new Coordinate(coordinate_1);
		m_WorkerInstance[1, 0] = new Coordinate(coordinate_2);
		m_WorkerInstance[1, 1] = new Coordinate(coordinate_3);
		m_InfoInstance = ComputeIntersect(coordinate_0, coordinate_1, coordinate_2, coordinate_3);
	}

	public abstract IntersectionType ComputeIntersect(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3);

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(m_WorkerInstance[0, 0]).Append("-");
		stringBuilder.Append(m_WorkerInstance[0, 1]).Append(" ");
		stringBuilder.Append(m_WorkerInstance[1, 0]).Append("-");
		stringBuilder.Append(m_WorkerInstance[1, 1]).Append(" : ");
		if (IsEndPoint)
		{
			stringBuilder.Append(" endpoint");
		}
		if (m_AuthenticationInstance)
		{
			stringBuilder.Append(" proper");
		}
		if (IsCollinear)
		{
			stringBuilder.Append(" collinear");
		}
		return stringBuilder.ToString();
	}

	public virtual Coordinate GetIntersection(int int_0)
	{
		return new Coordinate(stateInstance[int_0]);
	}

	protected virtual void ComputeIntLineIndex()
	{
		if (accountInstance == null)
		{
			accountInstance = new int[2, 2];
			ComputeIntLineIndex(0);
			ComputeIntLineIndex(1);
		}
	}

	public virtual bool IsIntersection(Coordinate coordinate_0)
	{
		int num = 0;
		while (true)
		{
			if (num < (int)m_InfoInstance)
			{
				if (new Coordinate(stateInstance[num]).Equals2D(coordinate_0))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public virtual bool IsInteriorIntersection()
	{
		if (IsInteriorIntersection(0))
		{
			return true;
		}
		if (IsInteriorIntersection(1))
		{
			return true;
		}
		return false;
	}

	public virtual bool IsInteriorIntersection(int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < (int)m_InfoInstance)
			{
				Coordinate coordinate = new Coordinate(stateInstance[num]);
				if (!coordinate.Equals2D(m_WorkerInstance[int_0, 0]) && !coordinate.Equals2D(m_WorkerInstance[int_0, 1]))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public virtual Coordinate GetIntersectionAlongSegment(int int_0, int int_1)
	{
		ComputeIntLineIndex();
		return new Coordinate(stateInstance[accountInstance[int_0, int_1]]);
	}

	public virtual int GetIndexAlongSegment(int int_0, int int_1)
	{
		ComputeIntLineIndex();
		return accountInstance[int_0, int_1];
	}

	protected virtual void ComputeIntLineIndex(int int_0)
	{
		double edgeDistance = GetEdgeDistance(int_0, 0);
		double edgeDistance2 = GetEdgeDistance(int_0, 1);
		if (edgeDistance <= edgeDistance2)
		{
			accountInstance[int_0, 0] = 1;
			accountInstance[int_0, 1] = 0;
		}
		else
		{
			accountInstance[int_0, 0] = 0;
			accountInstance[int_0, 1] = 1;
		}
	}

	public virtual double GetEdgeDistance(int int_0, int int_1)
	{
		return ComputeEdgeDistance(stateInstance[int_1], m_WorkerInstance[int_0, 0], m_WorkerInstance[int_0, 1]);
	}
}
