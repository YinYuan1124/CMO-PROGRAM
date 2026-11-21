using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotSpatial.Topology;

[Serializable]
public class CoordinateArraySequence : ICollection<Coordinate>, IEnumerable<Coordinate>, IEnumerable, ICloneable, GInterface2
{
	public class Enumerator : IEnumerator<Coordinate>, IDisposable, IEnumerator
	{
		private readonly IEnumerator m_ClassPrototype;

		public Coordinate Current => m_ClassPrototype.Current as Coordinate;

		object IEnumerator.Current => m_ClassPrototype.Current;

		public Enumerator(IEnumerator ienumerator_0)
		{
			m_ClassPrototype = ienumerator_0;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return m_ClassPrototype.MoveNext();
		}

		public void Reset()
		{
			m_ClassPrototype.Reset();
		}
	}

	private Coordinate[] _coordinates;

	private int _versionId;

	public virtual int Count => _coordinates.Length;

	public virtual int Dimension => 3;

	public virtual bool IsReadOnly => false;

	public virtual Coordinate this[int int_0]
	{
		get
		{
			return _coordinates[int_0];
		}
		set
		{
			_coordinates[int_0] = value;
			IncrementVersion();
		}
	}

	public int VersionID => _versionId;

	private void IncrementVersion()
	{
		if (_versionId == int.MaxValue)
		{
			_versionId = int.MinValue;
		}
		else
		{
			_versionId++;
		}
	}

	public CoordinateArraySequence()
	{
		Configure(new Coordinate[1]
		{
			new Coordinate()
		});
	}

	public CoordinateArraySequence(Coordinate coordinate_0)
	{
		Configure(new Coordinate[1] { coordinate_0 });
	}

	public CoordinateArraySequence(IEnumerable<Coordinate> ienumerable_0)
	{
		List<Coordinate> list = new List<Coordinate>();
		foreach (Coordinate item in ienumerable_0)
		{
			list.Add(item);
		}
		Coordinate[] coordinate_ = list.ToArray();
		Configure(coordinate_);
	}

	public CoordinateArraySequence(Coordinate[] coordinate_0)
	{
		Coordinate[] coordinate_ = coordinate_0;
		if (coordinate_0 == null)
		{
			coordinate_ = new Coordinate[1]
			{
				new Coordinate()
			};
		}
		Configure(coordinate_);
	}

	public CoordinateArraySequence(int int_0)
	{
		Coordinate[] array = new Coordinate[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = new Coordinate();
		}
		Configure(array);
	}

	public CoordinateArraySequence(GInterface2 ginterface2_0)
	{
		Coordinate[] array = ((ginterface2_0 == null) ? new Coordinate[0] : new Coordinate[ginterface2_0.Count]);
		for (int i = 0; i < array.Length; i++)
		{
			if (ginterface2_0 != null)
			{
				array[i] = ginterface2_0[i].Clone() as Coordinate;
			}
		}
		Configure(array);
	}

	private void Configure(Coordinate[] coordinate_0)
	{
		_coordinates = coordinate_0;
		_versionId = 0;
	}

	public virtual void Add(Coordinate item)
	{
		Coordinate[] array = new Coordinate[_coordinates.Length + 1];
		_coordinates.CopyTo(array, 0);
		array[_coordinates.Length] = item;
		IncrementVersion();
	}

	public virtual void Clear()
	{
		_coordinates = new Coordinate[1];
		_coordinates[0] = new Coordinate();
		IncrementVersion();
	}

	public virtual bool Contains(Coordinate item)
	{
		Coordinate[] coordinates = _coordinates;
		for (int i = 0; i < coordinates.Length; i++)
		{
			if (coordinates[i] == item)
			{
				return true;
			}
		}
		return false;
	}

	public virtual object Clone()
	{
		Coordinate[] array = new Coordinate[Count];
		for (int i = 0; i < _coordinates.Length; i++)
		{
			array[i] = new Coordinate(_coordinates[i]);
		}
		return new CoordinateArraySequence(array);
	}

	public virtual void CopyTo(Coordinate[] array, int arrayIndex)
	{
		_coordinates.CopyTo(array, arrayIndex);
	}

	public virtual IEnvelope ExpandEnvelope(IEnvelope ienvelope_0)
	{
		IEnvelope envelope = ienvelope_0.Copy();
		for (int i = 0; i < _coordinates.Length; i++)
		{
			envelope.ExpandToInclude(_coordinates[i]);
		}
		return envelope;
	}

	public virtual IEnumerator<Coordinate> GetEnumerator()
	{
		return new Enumerator(_coordinates.GetEnumerator());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _coordinates.GetEnumerator();
	}

	public virtual double GetOrdinate(int int_0, Ordinate ordinate_0)
	{
		if (1 == 0)
		{
		}
		double result = ordinate_0 switch
		{
			Ordinate.X => _coordinates[int_0].X, 
			Ordinate.Y => _coordinates[int_0].Y, 
			Ordinate.Z => _coordinates[int_0].Z, 
			_ => double.NaN, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public virtual bool Remove(Coordinate item)
	{
		Coordinate[] array = new Coordinate[_coordinates.Length - 1];
		bool flag = false;
		for (int i = 0; i < _coordinates.Length; i++)
		{
			if (item == _coordinates[i] && !flag)
			{
				flag = true;
			}
			else if (flag)
			{
				array[i - 1] = _coordinates[i];
			}
			else
			{
				array[i] = _coordinates[i];
			}
		}
		if (flag)
		{
			_coordinates = array;
		}
		return flag;
	}

	public virtual void SetOrdinate(int int_0, Ordinate ordinate_0, double double_0)
	{
		switch (ordinate_0)
		{
		default:
			throw new ArgumentException("invalid ordinate index: " + ordinate_0);
		case Ordinate.X:
			_coordinates[int_0].X = double_0;
			break;
		case Ordinate.Y:
			_coordinates[int_0].Y = double_0;
			break;
		case Ordinate.Z:
			_coordinates[int_0].Z = double_0;
			break;
		case Ordinate.M:
			_coordinates[int_0].M = double_0;
			break;
		}
		IncrementVersion();
	}

	public virtual Coordinate[] ToCoordinateArray()
	{
		return _coordinates;
	}

	public override string ToString()
	{
		if (_coordinates.Length == 0)
		{
			return "()";
		}
		StringBuilder stringBuilder = new StringBuilder(17 * _coordinates.Length);
		stringBuilder.Append('(');
		stringBuilder.Append(_coordinates[0]);
		for (int i = 1; i < _coordinates.Length; i++)
		{
			stringBuilder.Append(", ");
			stringBuilder.Append(_coordinates[i]);
		}
		stringBuilder.Append(')');
		return stringBuilder.ToString();
	}
}
