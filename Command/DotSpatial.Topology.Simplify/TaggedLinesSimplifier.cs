using System.Collections;

namespace DotSpatial.Topology.Simplify;

public class TaggedLinesSimplifier
{
	private readonly LineSegmentIndex stubThread = new LineSegmentIndex();

	private readonly LineSegmentIndex writerThread = new LineSegmentIndex();

	private double specificationThread;

	public virtual double DistanceTolerance
	{
		get
		{
			return specificationThread;
		}
		set
		{
			specificationThread = value;
		}
	}

	public virtual void Simplify(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			stubThread.Add((TaggedLineString)enumerator.Current);
		}
		IEnumerator enumerator2 = ilist_0.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			TaggedLineStringSimplifier taggedLineStringSimplifier = new TaggedLineStringSimplifier(stubThread, writerThread);
			taggedLineStringSimplifier.DistanceTolerance = specificationThread;
			taggedLineStringSimplifier.Simplify((TaggedLineString)enumerator2.Current);
		}
	}
}
