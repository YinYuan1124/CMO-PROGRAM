using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public abstract class GraphComponent
{
	private bool _CustomerInstance;

	private bool m_SerializerInstance;

	private bool _RefInstance;

	private bool errorInstance;

	private Label _CodeInstance;

	public virtual Label Label
	{
		get
		{
			return _CodeInstance;
		}
		set
		{
			_CodeInstance = value;
		}
	}

	public virtual bool IsInResult
	{
		get
		{
			return _RefInstance;
		}
		set
		{
			_RefInstance = value;
		}
	}

	public virtual bool IsCovered
	{
		get
		{
			return _CustomerInstance;
		}
		set
		{
			_CustomerInstance = value;
			m_SerializerInstance = true;
		}
	}

	public virtual bool IsCoveredSet => m_SerializerInstance;

	public virtual bool IsVisited
	{
		get
		{
			return errorInstance;
		}
		set
		{
			errorInstance = value;
		}
	}

	public abstract Coordinate Coordinate { get; set; }

	public abstract bool IsIsolated { get; }

	protected GraphComponent()
	{
	}

	protected GraphComponent(Label label_0)
	{
		_CodeInstance = label_0;
	}

	public abstract void ComputeIm(IntersectionMatrix intersectionMatrix_0);

	public virtual void UpdateIm(IntersectionMatrix intersectionMatrix_0)
	{
		Assert.IsTrue(Label.GeometryCount >= 2, "found partial label");
		ComputeIm(intersectionMatrix_0);
	}
}
