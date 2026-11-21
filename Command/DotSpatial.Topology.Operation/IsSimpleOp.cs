using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;

namespace DotSpatial.Topology.Operation;

public class IsSimpleOp
{
	public class EndpointInfo
	{
		private int composerPrototype;

		private bool m_ModelPrototype;

		private Coordinate m_AdvisorPrototype;

		public virtual Coordinate Point
		{
			get
			{
				return m_AdvisorPrototype;
			}
			set
			{
				m_AdvisorPrototype = value;
			}
		}

		public virtual bool IsClosed
		{
			get
			{
				return m_ModelPrototype;
			}
			set
			{
				m_ModelPrototype = value;
			}
		}

		public virtual int Degree
		{
			get
			{
				return composerPrototype;
			}
			set
			{
				composerPrototype = value;
			}
		}

		public EndpointInfo(Coordinate coordinate_0)
		{
			m_AdvisorPrototype = coordinate_0;
			m_ModelPrototype = false;
			composerPrototype = 0;
		}

		public virtual void AddEndpoint(bool bool_0)
		{
			Degree++;
			IsClosed |= bool_0;
		}
	}

	public virtual bool IsSimple(LineString lineString_0)
	{
		return DeleteCollection(lineString_0);
	}

	public virtual bool IsSimple(MultiLineString multiLineString_0)
	{
		return DeleteCollection(multiLineString_0);
	}

	public virtual bool IsSimple(MultiPoint multiPoint_0)
	{
		if (multiPoint_0.IsEmpty)
		{
			return true;
		}
		HashSet<Coordinate> hashSet = new HashSet<Coordinate>();
		int num = 0;
		while (true)
		{
			if (num < multiPoint_0.NumGeometries)
			{
				Coordinate coordinate = ((Point)multiPoint_0.GetGeometryN(num)).Coordinate;
				if (hashSet.Contains(coordinate))
				{
					break;
				}
				hashSet.Add(coordinate);
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static bool DeleteCollection(IGeometry igeometry_0)
	{
		if (igeometry_0.IsEmpty)
		{
			return true;
		}
		GeometryGraph geometryGraph = new GeometryGraph(0, igeometry_0);
		LineIntersector lineIntersector_ = new RobustLineIntersector();
		SegmentIntersector segmentIntersector = geometryGraph.ComputeSelfNodes(lineIntersector_, bool_0: true);
		if (segmentIntersector.HasIntersection)
		{
			if (segmentIntersector.HasProperIntersection)
			{
				return false;
			}
			if (AddCollection(geometryGraph))
			{
				return false;
			}
			if (DestroyCollection(geometryGraph))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private static bool AddCollection(PlanarGraph planarGraph_0)
	{
		IEnumerator edgeEnumerator = planarGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			int maximumSegmentIndex = obj.MaximumSegmentIndex;
			IEnumerator enumerator = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!((EdgeIntersection)enumerator.Current).IsEndPoint(maximumSegmentIndex))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool DestroyCollection(PlanarGraph planarGraph_0)
	{
		IDictionary dictionary = new SortedList();
		IEnumerator edgeEnumerator = planarGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			bool isClosed = obj.IsClosed;
			Coordinate coordinate = obj.GetCoordinate(0);
			ComputeCollection(dictionary, coordinate, isClosed);
			Coordinate coordinate2 = obj.GetCoordinate(obj.NumPoints - 1);
			ComputeCollection(dictionary, coordinate2, isClosed);
		}
		IEnumerator enumerator = dictionary.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EndpointInfo endpointInfo = (EndpointInfo)enumerator.Current;
			if (endpointInfo.IsClosed && endpointInfo.Degree != 2)
			{
				return true;
			}
		}
		return false;
	}

	private static void ComputeCollection(IDictionary idictionary_0, Coordinate coordinate_0, bool bool_0)
	{
		EndpointInfo endpointInfo = (EndpointInfo)idictionary_0[coordinate_0];
		if (endpointInfo == null)
		{
			endpointInfo = new EndpointInfo(coordinate_0);
			idictionary_0.Add(coordinate_0, endpointInfo);
		}
		endpointInfo.AddEndpoint(bool_0);
	}
}
