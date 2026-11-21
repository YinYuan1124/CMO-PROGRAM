using System;
using System.ComponentModel;
using DotSpatial.Serialization;

namespace DotSpatial.Topology;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class Envelope : ICloneable, IEnvelope, IRectangle
{
	[Serialize("Max")]
	private Coordinate _max;

	[Serialize("Min")]
	private Coordinate _min;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual GeometryType GeometryType => GeometryType.Envelope;

	[Description("Gets the Horizontal boundaries in geographic coordinates")]
	[Category("Range")]
	public string BoundsX => _min.X + " - " + _max.X;

	[Description("Gets the Horizontal boundaries in geographic coordinates")]
	[Category("Range")]
	public string BoundsY => _min.Y + " - " + _max.Y;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Coordinate Minimum => _min;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Coordinate Maximum => _max;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int NumOrdinates => _min.NumOrdinates;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual bool IsNull
	{
		get
		{
			if (!(_max == null) && !(_min == null))
			{
				return _max.X < _min.X;
			}
			return true;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual double Height
	{
		get
		{
			if (IsNull)
			{
				return 0.0;
			}
			return Maximum.Y - Minimum.Y;
		}
		set
		{
			double num = Math.Abs(value);
			_max.Y = _min.Y + num;
			OnEnvelopeChanged();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual double Width
	{
		get
		{
			if (IsNull)
			{
				return 0.0;
			}
			return _max.X - _min.X;
		}
		set
		{
			_max.X = value + _min.X;
			OnEnvelopeChanged();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual double X
	{
		get
		{
			return _min.X;
		}
		set
		{
			double width = Width;
			_min.X = value;
			_max.X = value + width;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual double Y
	{
		get
		{
			return _max.Y;
		}
		set
		{
			double height = Height;
			_max.Y = value;
			_min.Y = value - height;
		}
	}

	public event EventHandler EnvelopeChanged;

	public Envelope()
	{
		DoInit();
	}

	public Envelope(double double_0, double double_1, double double_2, double double_3)
	{
		Coordinate coordinate_ = new Coordinate(Math.Min(double_0, double_1), Math.Min(double_2, double_3));
		Coordinate coordinate_2 = new Coordinate(Math.Max(double_0, double_1), Math.Max(double_2, double_3));
		DoInit(coordinate_, coordinate_2);
	}

	public Envelope(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		Coordinate coordinate_ = new Coordinate(Math.Min(double_0, double_1), Math.Min(double_2, double_3), Math.Min(double_4, double_5));
		Coordinate coordinate_2 = new Coordinate(Math.Max(double_0, double_1), Math.Max(double_2, double_3), Math.Max(double_4, double_5));
		DoInit(coordinate_, coordinate_2);
	}

	public Envelope(IEnvelope ienvelope_0)
	{
		Coordinate coordinate_ = ienvelope_0.Minimum.Copy();
		Coordinate coordinate_2 = ienvelope_0.Maximum.Copy();
		DoInit(coordinate_, coordinate_2);
	}

	public Envelope(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (coordinate_0 != null && coordinate_1 != null)
		{
			int num = Math.Min(coordinate_0.NumOrdinates, coordinate_1.NumOrdinates);
			_min = new Coordinate();
			_max = new Coordinate();
			for (int i = 0; i < num; i++)
			{
				_min[i] = Math.Min(coordinate_0[i], coordinate_1[i]);
				_max[i] = Math.Max(coordinate_0[i], coordinate_1[i]);
			}
			_min.M = Math.Min(coordinate_0.M, coordinate_1.M);
			_max.M = Math.Min(coordinate_0.M, coordinate_1.M);
		}
	}

	public Envelope(Coordinate coordinate_0)
	{
		DoInit(coordinate_0.Copy(), coordinate_0.Copy());
	}

	public Envelope(double[] double_0, double double_1, double double_2)
	{
		_min = new Coordinate();
		_max = new Coordinate();
		for (int i = 0; i < double_0.Length / 2; i++)
		{
			_min[i] = double_0[i * 2];
			_max[i] = double_0[i * 2 + 1];
		}
		_min.M = double_1;
		_max.M = double_2;
	}

	public Envelope(double[] double_0)
		: this(double_0, 0.0, 0.0)
	{
	}

	public virtual void Init(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (coordinate_0 == null && coordinate_1 == null)
		{
			Init();
			return;
		}
		if (coordinate_0 == null)
		{
			Init(coordinate_1, coordinate_1);
			return;
		}
		if (coordinate_1 == null)
		{
			Init(coordinate_0, coordinate_0);
			return;
		}
		int num = Math.Min(coordinate_0.NumOrdinates, coordinate_1.NumOrdinates);
		_min = new Coordinate();
		_max = new Coordinate();
		for (int i = 0; i < num; i++)
		{
			_min[i] = Math.Min(coordinate_0[i], coordinate_1[i]);
			_max[i] = Math.Max(coordinate_0[i], coordinate_1[i]);
		}
		_min.M = Math.Min(coordinate_0.M, coordinate_1.M);
		_max.M = Math.Min(coordinate_0.M, coordinate_1.M);
		OnEnvelopeChanged();
	}

	private void DoInit()
	{
		_min = new Coordinate(0.0, 0.0);
		_max = new Coordinate(-1.0, -1.0);
	}

	private void DoInit(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		_min = coordinate_0;
		_max = coordinate_1;
	}

	public virtual void Init()
	{
		SetToNull();
	}

	public virtual void Init(double double_0, double double_1, double double_2, double double_3)
	{
		_min = new Coordinate();
		_max = new Coordinate();
		_min.X = Math.Min(double_0, double_1);
		_max.X = Math.Max(double_0, double_1);
		_min.Y = Math.Min(double_2, double_3);
		_max.Y = Math.Max(double_2, double_3);
		OnEnvelopeChanged();
	}

	public virtual void Init(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		_min = new Coordinate();
		_max = new Coordinate();
		_min.X = Math.Min(double_0, double_1);
		_max.X = Math.Max(double_0, double_1);
		_min.Y = Math.Min(double_2, double_3);
		_max.Y = Math.Max(double_2, double_3);
		_max.Z = Math.Max(double_4, double_5);
		_min.Z = Math.Min(double_4, double_5);
		OnEnvelopeChanged();
	}

	public virtual void Init(Coordinate coordinate_0)
	{
		if (coordinate_0 == null)
		{
			Init();
			return;
		}
		_min = coordinate_0.Copy();
		_max = coordinate_0.Copy();
		OnEnvelopeChanged();
	}

	public virtual void Init(IEnvelope ienvelope_0)
	{
		if (ienvelope_0.Maximum == null || ienvelope_0.Minimum == null)
		{
			Init();
		}
		if (ienvelope_0.Maximum != null)
		{
			_max = ienvelope_0.Maximum.Copy();
		}
		if (ienvelope_0.Minimum != null)
		{
			_min = ienvelope_0.Minimum.Copy();
		}
		OnEnvelopeChanged();
	}

	public bool HasM()
	{
		if (!double.IsNaN(Minimum.M) && !double.IsNaN(Maximum.M))
		{
			if (Minimum.M <= Maximum.M)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public bool HasZ()
	{
		if (!double.IsNaN(Minimum.Z) && !double.IsNaN(Maximum.Z))
		{
			if (Minimum.Z <= Maximum.Z)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public virtual object Clone()
	{
		return Copy();
	}

	IEnvelope IEnvelope.Copy()
	{
		return Copy();
	}

	public virtual void SetToNull()
	{
		_min = new Coordinate();
		_max = new Coordinate();
		for (int i = 0; i < NumOrdinates; i++)
		{
			_min[i] = 0.0;
			_max[i] = -1.0;
		}
		OnEnvelopeChanged();
	}

	public virtual Envelope Copy()
	{
		if (IsNull)
		{
			return new Envelope();
		}
		return new Envelope(_min, _max);
	}

	public static bool Intersects(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		return new Envelope(coordinate_0, coordinate_1).Intersects(coordinate_2);
	}

	public static bool Intersects(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		Envelope ienvelope_ = new Envelope(coordinate_0, coordinate_1);
		Envelope ienvelope_2 = new Envelope(coordinate_2, coordinate_3);
		return ienvelope_.Intersects(ienvelope_2);
	}

	public override string ToString()
	{
		string text = "Env[";
		for (int i = 0; i < NumOrdinates; i++)
		{
			if (i > 0)
			{
				text += ", ";
			}
			text = text + Minimum[i] + " : " + Maximum[i];
		}
		return text;
	}

	protected void OnEnvelopeChanged()
	{
		if (this.EnvelopeChanged != null)
		{
			this.EnvelopeChanged(this, EventArgs.Empty);
		}
	}
}
