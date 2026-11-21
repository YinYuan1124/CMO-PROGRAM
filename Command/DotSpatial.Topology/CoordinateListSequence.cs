using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public class CoordinateListSequence : ICollection<Coordinate>, IEnumerable<Coordinate>, IEnumerable, ICloneable, GInterface2
{
	private List<Coordinate> m_InitializerProcess;

	private int roleProcess;

	public int Count => m_InitializerProcess.Count;

	public int Dimension => 0;

	public bool IsReadOnly => false;

	public virtual Coordinate this[int int_0]
	{
		get
		{
			return m_InitializerProcess[int_0];
		}
		set
		{
			m_InitializerProcess[int_0] = value;
			CallRule();
		}
	}

	public int VersionID => roleProcess;

	public CoordinateListSequence(Coordinate coordinate_0)
	{
		SelectRule(new List<Coordinate> { coordinate_0 });
	}

	public CoordinateListSequence()
	{
		SelectRule(new List<Coordinate>());
	}

	public CoordinateListSequence(IEnumerable<Coordinate> ienumerable_0)
	{
		List<Coordinate> list = ienumerable_0 as List<Coordinate>;
		if (list == null)
		{
			list = new List<Coordinate>();
			foreach (Coordinate item in ienumerable_0)
			{
				list.Add(item);
			}
		}
		SelectRule(list);
	}

	public CoordinateListSequence(GInterface2 ginterface2_0)
	{
		List<Coordinate> list = new List<Coordinate>();
		for (int i = 0; i <= ginterface2_0.Count; i++)
		{
			list.Add(ginterface2_0[i].Clone() as Coordinate);
		}
		SelectRule(list);
	}

	private void SelectRule(List<Coordinate> list_0)
	{
		m_InitializerProcess = list_0;
		roleProcess = 0;
	}

	public void Add(Coordinate item)
	{
		m_InitializerProcess.Add(item);
		CallRule();
	}

	public void Clear()
	{
		m_InitializerProcess = new List<Coordinate>();
		CallRule();
	}

	public object Clone()
	{
		return new CoordinateListSequence(m_InitializerProcess);
	}

	public bool Contains(Coordinate item)
	{
		return m_InitializerProcess.Contains(item);
	}

	public void CopyTo(Coordinate[] array, int arrayIndex)
	{
		m_InitializerProcess.CopyTo(array, arrayIndex);
	}

	public IEnvelope ExpandEnvelope(IEnvelope ienvelope_0)
	{
		IEnvelope envelope = ienvelope_0.Copy();
		foreach (Coordinate item in m_InitializerProcess)
		{
			envelope.ExpandToInclude(item);
		}
		return envelope;
	}

	public IEnumerator<Coordinate> GetEnumerator()
	{
		return m_InitializerProcess.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return m_InitializerProcess.GetEnumerator();
	}

	public double GetOrdinate(int int_0, Ordinate ordinate_0)
	{
		return m_InitializerProcess[int_0].Z;
	}

	public bool Remove(Coordinate item)
	{
		CallRule();
		return m_InitializerProcess.Remove(item);
	}

	public void SetOrdinate(int int_0, Ordinate ordinate_0, double double_0)
	{
		switch (ordinate_0)
		{
		case Ordinate.X:
			m_InitializerProcess[int_0].X = double_0;
			break;
		case Ordinate.Y:
			m_InitializerProcess[int_0].Y = double_0;
			break;
		case Ordinate.Z:
			m_InitializerProcess[int_0].Z = double_0;
			break;
		case Ordinate.M:
			m_InitializerProcess[int_0].M = double_0;
			break;
		}
		CallRule();
	}

	public Coordinate[] ToCoordinateArray()
	{
		return m_InitializerProcess.ToArray();
	}

	private void CallRule()
	{
		if (roleProcess == int.MaxValue)
		{
			roleProcess = int.MinValue;
		}
		else
		{
			roleProcess++;
		}
	}
}
