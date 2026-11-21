namespace DotSpatial.Topology;

public class Triangle
{
	private Coordinate m_StateProcess;

	private Coordinate authenticationProcess;

	private Coordinate m_ParamsProcess;

	public virtual Coordinate P2
	{
		get
		{
			return m_ParamsProcess;
		}
		set
		{
			m_ParamsProcess = value;
		}
	}

	public virtual Coordinate P1
	{
		get
		{
			return authenticationProcess;
		}
		set
		{
			authenticationProcess = value;
		}
	}

	public virtual Coordinate P0
	{
		get
		{
			return m_StateProcess;
		}
		set
		{
			m_StateProcess = value;
		}
	}

	public virtual Coordinate InCentre
	{
		get
		{
			double num = P1.Distance(P2);
			double num2 = P0.Distance(P2);
			double num3 = P0.Distance(P1);
			double num4 = num + num2 + num3;
			double double_ = (num * P0.X + num2 * P1.X + num3 * P2.X) / num4;
			double double_2 = (num * P0.Y + num2 * P1.Y + num3 * P2.Y) / num4;
			return new Coordinate(double_, double_2);
		}
	}

	public Triangle(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		m_StateProcess = coordinate_0;
		authenticationProcess = coordinate_1;
		m_ParamsProcess = coordinate_2;
	}
}
