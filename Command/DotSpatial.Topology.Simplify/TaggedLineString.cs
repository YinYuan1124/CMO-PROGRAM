using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Simplify;

public class TaggedLineString
{
	private readonly int watcherThread;

	private readonly LineString m_ReponseThread;

	private readonly IList descriptorThread = new ArrayList();

	private TaggedLineSegment[] m_PoolThread;

	public virtual int MinimumSize => watcherThread;

	public virtual LineString Parent => m_ReponseThread;

	public virtual IList<Coordinate> ParentCoordinates => m_ReponseThread.Coordinates;

	public virtual Coordinate[] ResultCoordinates => MapRule(descriptorThread);

	public virtual int ResultSize
	{
		get
		{
			int count = descriptorThread.Count;
			if (count == 0)
			{
				return 0;
			}
			return count + 1;
		}
	}

	public virtual TaggedLineSegment[] Segments => m_PoolThread;

	public TaggedLineString(LineString lineString_0)
		: this(lineString_0, 2)
	{
	}

	public TaggedLineString(LineString lineString_0, int int_0)
	{
		m_ReponseThread = lineString_0;
		watcherThread = int_0;
		ResetRule();
	}

	public virtual TaggedLineSegment GetSegment(int int_0)
	{
		return m_PoolThread[int_0];
	}

	private void ResetRule()
	{
		IList<Coordinate> coordinates = m_ReponseThread.Coordinates;
		m_PoolThread = new TaggedLineSegment[coordinates.Count - 1];
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			TaggedLineSegment taggedLineSegment = new TaggedLineSegment(coordinates[i], coordinates[i + 1], m_ReponseThread, i);
			m_PoolThread[i] = taggedLineSegment;
		}
	}

	public virtual void AddToResult(LineSegment lineSegment_0)
	{
		descriptorThread.Add(lineSegment_0);
	}

	public virtual ILineString AsLineString()
	{
		return m_ReponseThread.Factory.CreateLineString(MapRule(descriptorThread));
	}

	public virtual ILinearRing AsLinearRing()
	{
		return m_ReponseThread.Factory.CreateLinearRing(MapRule(descriptorThread));
	}

	private static Coordinate[] MapRule(object object_0)
	{
		Coordinate[] array = new Coordinate[((ICollection)object_0).Count + 1];
		LineSegment lineSegment = null;
		for (int i = 0; i < ((ICollection)object_0).Count; i++)
		{
			lineSegment = (LineSegment)((IList)object_0)[i];
			array[i] = lineSegment.P0;
		}
		if (lineSegment != null)
		{
			array[array.Length - 1] = lineSegment.P1;
		}
		return array;
	}
}
