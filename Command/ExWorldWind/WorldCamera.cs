using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ExWorldWind;

public class WorldCamera
{
	public delegate void PanDelegate();

	[CompilerGenerated]
	private PanDelegate _ServerProcess = delegate
	{
	};

	internal Angle _AdapterProcess;

	public Vector3 ReferenceCenter;

	public ViewFrustum ViewFrustum = new ViewFrustum();

	internal Matrix4x4 View;

	internal Matrix4x4 _SchemaProcess;

	public float ViewportWidth;

	public float ViewportHeight;

	protected int lastStepZoomTickCount;

	protected double _distance;

	protected double _altitude;

	protected Angle _latitude;

	protected Angle _longitude;

	protected Angle _heading;

	protected Quaternion4d m_Orientation = Quaternion4d.EulerToQuaternion(0.0, 0.0, 0.0);

	protected Angle _tilt;

	protected static readonly double minimumAltitude;

	private Matrix4x4 m_UtilsProcess = Matrix4x4.Identity;

	public virtual float Altitude
	{
		get
		{
			return (float)_altitude;
		}
		set
		{
			TargetAltitude = value;
		}
	}

	public virtual double TargetAltitude
	{
		get
		{
			return _altitude;
		}
		set
		{
			float num = 127562740f;
			if (value < minimumAltitude)
			{
				value = minimumAltitude;
			}
			if (value > (double)num)
			{
				value = num;
			}
			_altitude = value;
			ComputeDistance(_altitude, _tilt);
		}
	}

	public virtual Angle Latitude => _latitude;

	public virtual Angle Longitude => _longitude;

	public double TargetDistance
	{
		get
		{
			return _distance;
		}
		set
		{
			int num = 10;
			float num2 = 127562740f;
			Angle angle_ = default(Angle);
			angle_.Radians = 0.0;
			if (value < 10.0)
			{
				value = num;
			}
			if (value > (double)num2)
			{
				value = num2;
			}
			_distance = value;
			ComputeAltitude(_distance, angle_);
		}
	}

	public event PanDelegate PanEvent
	{
		[CompilerGenerated]
		add
		{
			PanDelegate panDelegate = _ServerProcess;
			PanDelegate panDelegate2;
			do
			{
				panDelegate2 = panDelegate;
				PanDelegate value2 = (PanDelegate)Delegate.Combine(panDelegate2, value);
				panDelegate = Interlocked.CompareExchange(ref _ServerProcess, value2, panDelegate2);
			}
			while ((object)panDelegate != panDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			PanDelegate panDelegate = _ServerProcess;
			PanDelegate panDelegate2;
			do
			{
				panDelegate2 = panDelegate;
				PanDelegate value2 = (PanDelegate)Delegate.Remove(panDelegate2, value);
				panDelegate = Interlocked.CompareExchange(ref _ServerProcess, value2, panDelegate2);
			}
			while ((object)panDelegate != panDelegate2);
		}
	}

	protected void InvokePanEvent()
	{
		_ServerProcess();
	}

	internal void RegisterThread(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		Altitude = float_2;
		ViewportWidth = float_3;
		ViewportHeight = float_4;
		ReferenceCenter = MathEngine.SphericalToCartesian(Latitude, Longitude, 6378137.0);
		float num = Altitude / 6378137f;
		if (num < 1f)
		{
			_AdapterProcess = Angle.FromRadians(Math.Abs(Math.Asin(num)) * 2.0);
		}
		else
		{
			_AdapterProcess = Angle.FromRadians(Math.PI);
		}
		Matrix4x4 identity = Matrix4x4.Identity;
		Vector3 cameraPosition = MathEngine.SphericalToCartesian(Latitude.Degrees, Longitude.Degrees, 6378137f + Altitude);
		Vector3 zero = Vector3.Zero;
		Vector3 cameraUpVector = new Vector3(0f, 0f, 1f);
		View = Matrix4x4.CreateLookAt(cameraPosition, zero, cameraUpVector);
		ManageThread(ViewportWidth, ViewportHeight, float_5);
		ViewFrustum.Update(identity * View * _SchemaProcess);
	}

	protected void ComputeDistance(double double_0, Angle angle_0)
	{
		double num = Math.Cos(Math.PI - angle_0.Radians);
		double num2 = 6378137.0 * num;
		double num3 = 6378137.0 + double_0;
		double num4 = Math.Sqrt(40680631590769.0 * num * num + num3 * num3 - 40680631590769.0);
		double num5 = num2 - num4;
		if (num5 < 0.0)
		{
			num5 = num2 + num4;
		}
		_distance = num5;
	}

	internal void ManageThread(float float_0, float float_1, float float_2)
	{
		float aspectRatio = float_0 / float_1;
		float nearPlaneDistance = Altitude * 0.1f;
		double num = Altitude + 6378137f;
		double num2 = Math.Sqrt(num * num - 40680629993472.0);
		if (num2 < 1000000.0)
		{
			num2 = 1000000.0;
		}
		_SchemaProcess = Matrix4x4.CreatePerspectiveFieldOfView(float_2, aspectRatio, nearPlaneDistance, (float)num2);
	}

	public Vector3 Project(Vector3 vector3_0)
	{
		Matrix4x4 value = Matrix4x4.Multiply(View, Matrix4x4.CreateTranslation(0f, 0f, 6378137f));
		Vector4 vector = new Vector4(vector3_0, 1f);
		Matrix4x4 matrix = Matrix4x4.Multiply(Matrix4x4.Multiply(m_UtilsProcess, value), _SchemaProcess);
		value.M11 *= -1f;
		value.M13 *= -1f;
		value.M21 *= -1f;
		value.M23 *= -1f;
		value.M31 *= -1f;
		value.M33 *= -1f;
		value.M41 *= -1f;
		value.M43 *= -1f;
		vector = Vector4.Transform(vector, matrix);
		float x = vector.X / vector.W * ViewportWidth / 2f + ViewportWidth / 2f;
		float num = vector.Y / vector.W * ViewportHeight / 2f + ViewportHeight / 2f;
		num = ViewportHeight - num;
		return new Vector3(x, num, 0f);
	}

	public Vector3 UnProject(Vector3 vector3_0)
	{
		Matrix4x4 matrix4x = View * Matrix4x4.CreateTranslation(0f, 0f, 6378137f);
		_ = _SchemaProcess * matrix4x * Matrix4x4.Identity;
		Matrix4x4.Invert(View, out var result);
		Matrix4x4.Invert(_SchemaProcess, out var result2);
		Matrix4x4 matrix = result2 * result;
		vector3_0.Y = ViewportHeight - vector3_0.Y;
		Vector4 vector = new Vector4(vector3_0.X / ViewportWidth * 2f - 1f, vector3_0.Y / ViewportHeight * 2f - 1f, vector3_0.Z * 2f - 1f, 1f);
		vector = Vector4.Transform(vector, matrix);
		vector.W = 1f / vector.W;
		return new Vector3(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W);
	}

	public virtual void SetPosition(double double_0, double double_1)
	{
		if (double.IsNaN(double_0))
		{
			double_0 = _latitude.Degrees;
		}
		if (double.IsNaN(double_1))
		{
			double_1 = _longitude.Degrees;
		}
		m_Orientation = Quaternion4d.EulerToQuaternion(MathEngine.DegreesToRadians(double_1), MathEngine.DegreesToRadians(double_0), MathEngine.DegreesToRadians(0.0));
		Point3d point3d = Quaternion4d.QuaternionToEuler(m_Orientation);
		_latitude.Radians = point3d.Y;
		_longitude.Radians = point3d.X;
		_heading.Radians = point3d.Z;
	}

	public void ZoomStepped(float float_0)
	{
		int tickCount = Environment.TickCount;
		double num = 0.014999999664723873;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		double num2 = 50.0;
		double num3 = 250.0;
		double num4 = tickCount - lastStepZoomTickCount;
		if (num4 < num2)
		{
			num4 = num2;
		}
		double num5 = 1.0 - Math.Abs((num4 - num2) / num3);
		if (num5 < 0.0)
		{
			num5 = 0.0;
		}
		num5 *= 10.0;
		double x = Math.Pow(1.0 - num, num5 + 1.0);
		x = Math.Pow(x, Math.Abs(float_0));
		if (float_0 <= 0f)
		{
			TargetDistance /= x;
		}
		else
		{
			TargetDistance *= x;
		}
		lastStepZoomTickCount = tickCount;
	}

	protected void ComputeAltitude(double double_0, Angle angle_0)
	{
		int num = 10;
		float num2 = 127562740f;
		double num3 = Math.Sqrt(40680631590769.0 + double_0 * double_0 - 12756274.0 * double_0 * Math.Cos(Math.PI - angle_0.Radians)) - 6378137.0;
		if (num3 < 10.0)
		{
			num3 = num;
		}
		else if (num3 > (double)num2)
		{
			num3 = num2;
		}
		_altitude = num3;
	}

	public virtual void PickingRayIntersection(int int_0, int int_1, out Angle angle_0, out Angle angle_1)
	{
		Vector3 vector3_ = default(Vector3);
		vector3_.X = int_0;
		vector3_.Y = int_1;
		vector3_.Z = 0f;
		vector3_ = UnProject(vector3_);
		Vector3 vector3_2 = default(Vector3);
		vector3_2.X = int_0;
		vector3_2.Y = int_1;
		vector3_2.Z = 1f;
		vector3_2 = UnProject(vector3_2);
		Point3d point3d = new Point3d(vector3_.X, vector3_.Y, vector3_.Z);
		Point3d point3d2 = new Point3d(vector3_2.X, vector3_2.Y, vector3_2.Z);
		double num = (point3d2.X - point3d.X) * (point3d2.X - point3d.X) + (point3d2.Y - point3d.Y) * (point3d2.Y - point3d.Y) + (point3d2.Z - point3d.Z) * (point3d2.Z - point3d.Z);
		double num2 = 2.0 * ((point3d2.X - point3d.X) * point3d.X + (point3d2.Y - point3d.Y) * point3d.Y + (point3d2.Z - point3d.Z) * point3d.Z);
		double num3 = point3d.X * point3d.X + point3d.Y * point3d.Y + point3d.Z * point3d.Z - 40680631590769.0;
		if (num2 * num2 - 4.0 * num * num3 <= 0.0)
		{
			angle_0 = Angle.NaN;
			angle_1 = Angle.NaN;
			return;
		}
		double num4 = (-1.0 * num2 - Math.Sqrt(num2 * num2 - 4.0 * num * num3)) / (2.0 * num);
		Point3d point3d3 = new Point3d(point3d.X + num4 * (point3d2.X - point3d.X), point3d.Y + num4 * (point3d2.Y - point3d.Y), point3d.Z + num4 * (point3d2.Z - point3d.Z));
		Point3d point3d4 = MathEngine.FlushThread(point3d3.X, point3d3.Y, point3d3.Z);
		angle_0 = Angle.FromRadians(point3d4.Y);
		angle_1 = Angle.FromRadians(point3d4.Z);
	}

	public virtual void Pan(Angle angle_0, Angle angle_1)
	{
		if (Angle.IsNaN(angle_0))
		{
			angle_0 = _latitude;
		}
		if (Angle.IsNaN(angle_1))
		{
			angle_1 = _longitude;
		}
		angle_0 += _latitude;
		angle_1 += _longitude;
		m_Orientation = Quaternion4d.EulerToQuaternion(angle_1.Radians, angle_0.Radians, _heading.Radians);
		Point3d point3d = Quaternion4d.QuaternionToEuler(m_Orientation);
		if (!double.IsNaN(point3d.Y))
		{
			_latitude.Radians = point3d.Y;
			_longitude.Radians = point3d.X;
		}
		InvokePanEvent();
	}

	public void Zoom(float float_0)
	{
		if (float_0 <= 0f)
		{
			double num = 1f - float_0;
			TargetAltitude *= num;
		}
		else
		{
			double num2 = 1f + float_0;
			TargetAltitude /= num2;
		}
	}

	static WorldCamera()
	{
		minimumAltitude = 10.0;
	}
}
