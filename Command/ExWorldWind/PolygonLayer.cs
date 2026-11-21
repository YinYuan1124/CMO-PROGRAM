using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using DXRenderer;
using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;
using GisSharpBlog.NetTopologySuite.IO;

namespace ExWorldWind;

public class PolygonLayer
{
	public class PolygonVertexBuffer
	{
		public Vector3[] vector3s;

		public int Vertcount => vector3s.Length;
	}

	private readonly double tokenProcess;

	public static bool WireframeMode;

	public bool IsAllowedToRender = true;

	private string m_IndexerProcess;

	private readonly List<PolygonVertexBuffer> _ResolverProcess = new List<PolygonVertexBuffer>();

	private bool m_PublisherProcess;

	public PolygonLayer(string string_0)
	{
		m_IndexerProcess = string_0;
		ShapefileReader val = new ShapefileReader(m_IndexerProcess);
		if (val.Header.ShapeType == ShapeGeometryType.Polygon)
		{
			tokenProcess = 6378137.0;
			List<Vector3> list = new List<Vector3>();
			int num = 0;
			foreach (Polygon item4 in val.OfType<Polygon>())
			{
				ILinearRing shell = item4.Shell;
				ICoordinateSequence coordinateSequence = shell.CoordinateSequence;
				int numPoints = shell.NumPoints;
				ICoordinate coordinate = coordinateSequence.GetCoordinate(0);
				ICoordinate coordinate2 = coordinateSequence.GetCoordinate(numPoints - 1);
				for (int i = 0; i < numPoints - 1; i++)
				{
					ICoordinate coordinate3 = coordinateSequence.GetCoordinate(i);
					ICoordinate coordinate4 = coordinateSequence.GetCoordinate(i + 1);
					Vector3 vector = MathEngine.SphericalToCartesian(coordinate3.Y, coordinate3.X + 180.0, tokenProcess);
					Vector3 item = new Vector3(0f - vector.Y, vector.Z, vector.X);
					list.Add(item);
					vector = MathEngine.SphericalToCartesian(coordinate4.Y, coordinate4.X + 180.0, tokenProcess);
					item = new Vector3(0f - vector.Y, vector.Z, vector.X);
					list.Add(item);
					num++;
					if (num > 1000)
					{
						num = 0;
						ForgotThread(list);
					}
				}
				Vector3 vector2 = MathEngine.SphericalToCartesian(coordinate2.Y, coordinate2.X + 180.0, tokenProcess);
				Vector3 item2 = new Vector3(0f - vector2.Y, vector2.Z, vector2.X);
				list.Add(item2);
				Vector3 vector3 = MathEngine.SphericalToCartesian(coordinate.Y, coordinate.X + 180.0, tokenProcess);
				Vector3 item3 = new Vector3(0f - vector3.Y, vector3.Z, vector3.X);
				list.Add(item3);
			}
			ForgotThread(list);
			return;
		}
		throw new Exception("Wrong shape type in shapefile. Expecting Polygon.");
	}

	private void ForgotThread(List<Vector3> list_0)
	{
		Vector3[] vector3s = list_0.ToArray();
		list_0.Clear();
		_ResolverProcess.Add(new PolygonVertexBuffer
		{
			vector3s = vector3s
		});
	}

	public void Render(float float_0)
	{
		Vector4 vector4_ = Main.IntToVector4(Color.FromArgb(255, 255, 255, 0).ToArgb());
		int num = 0;
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Main instance = Main.Instance;
		if (m_PublisherProcess)
		{
			instance.DrawLineList(m_IndexerProcess, null, null, float_0);
		}
		else
		{
			foreach (PolygonVertexBuffer item2 in _ResolverProcess)
			{
				for (int i = 0; i < item2.Vertcount; i++)
				{
					Vertex item = new Vertex(item2.vector3s[i], vector4_);
					list.Add(item);
					list2.Add((uint)num++);
				}
			}
			instance.DrawLineList(m_IndexerProcess, list.ToArray(), list2.ToArray(), float_0);
		}
		m_PublisherProcess = true;
	}
}
