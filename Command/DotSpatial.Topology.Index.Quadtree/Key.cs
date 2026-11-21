using System;

namespace DotSpatial.Topology.Index.Quadtree;

public class Key
{
	private readonly Coordinate _ParamCollection = new Coordinate();

	private IEnvelope pageCollection;

	private int rulesCollection;

	public virtual Coordinate Point => _ParamCollection;

	public virtual int Level => rulesCollection;

	public virtual IEnvelope Envelope => pageCollection;

	public virtual Coordinate Centre => new Coordinate((pageCollection.Minimum.X + pageCollection.Maximum.X) / 2.0, (pageCollection.Minimum.Y + pageCollection.Maximum.Y) / 2.0);

	public Key(IEnvelope ienvelope_0)
	{
		ComputeKey(ienvelope_0);
	}

	public static int ComputeQuadLevel(IEnvelope ienvelope_0)
	{
		double width = ienvelope_0.Width;
		double height = ienvelope_0.Height;
		return DoubleBits.GetExponent((width <= height) ? height : width) + 1;
	}

	public void ComputeKey(IEnvelope ienvelope_0)
	{
		rulesCollection = ComputeQuadLevel(ienvelope_0);
		pageCollection = new Envelope();
		InterruptParameter(rulesCollection, ienvelope_0);
		while (!pageCollection.Contains(ienvelope_0))
		{
			rulesCollection++;
			InterruptParameter(rulesCollection, ienvelope_0);
		}
	}

	private void InterruptParameter(int int_0, IEnvelope ienvelope_0)
	{
		double num = DoubleBits.PowerOf2(int_0);
		_ParamCollection.X = Math.Floor(ienvelope_0.Minimum.X / num) * num;
		_ParamCollection.Y = Math.Floor(ienvelope_0.Minimum.Y / num) * num;
		pageCollection = new Envelope(_ParamCollection.X, _ParamCollection.X + num, _ParamCollection.Y, _ParamCollection.Y + num);
	}
}
