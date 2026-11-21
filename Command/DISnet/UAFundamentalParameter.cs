using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class UAFundamentalParameter
{
	private ushort ushort_0;

	private ushort ushort_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "activeEmissionParameterIndex")]
	public ushort ActiveEmissionParameterIndex
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "scanPattern")]
	public ushort ScanPattern
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuthHorizontal")]
	public float BeamCenterAzimuthHorizontal
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidthHorizontal")]
	public float AzimuthalBeamwidthHorizontal
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamCenterDepressionElevation")]
	public float BeamCenterDepressionElevation
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamwidthDownElevation")]
	public float BeamwidthDownElevation
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(UAFundamentalParameter uafundamentalParameter_0, UAFundamentalParameter uafundamentalParameter_1)
	{
		return !(uafundamentalParameter_0 == uafundamentalParameter_1);
	}

	public static bool operator ==(UAFundamentalParameter uafundamentalParameter_0, UAFundamentalParameter uafundamentalParameter_1)
	{
		if ((object)uafundamentalParameter_0 == uafundamentalParameter_1)
		{
			return true;
		}
		if ((object)uafundamentalParameter_0 != null && (object)uafundamentalParameter_1 != null)
		{
			return uafundamentalParameter_0.Equals(uafundamentalParameter_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 20;
	}

	protected void OnException(Exception exception_0)
	{
		if (action_0 != null)
		{
			action_0(exception_0);
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
				dataOutputStream_0.WriteFloat(float_3);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 != null)
		{
			try
			{
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
				float_3 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<UAFundamentalParameter>");
		try
		{
			stringBuilder_0.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
			stringBuilder_0.AppendLine("<scanPattern type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
			stringBuilder_0.AppendLine("<beamCenterAzimuthHorizontal type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuthHorizontal>");
			stringBuilder_0.AppendLine("<azimuthalBeamwidthHorizontal type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidthHorizontal>");
			stringBuilder_0.AppendLine("<beamCenterDepressionElevation type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</beamCenterDepressionElevation>");
			stringBuilder_0.AppendLine("<beamwidthDownElevation type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</beamwidthDownElevation>");
			stringBuilder_0.AppendLine("</UAFundamentalParameter>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as UAFundamentalParameter;
	}

	public bool Equals(UAFundamentalParameter uafundamentalParameter_0)
	{
		bool result = true;
		if (uafundamentalParameter_0.GetType() == GetType())
		{
			if (ushort_0 != uafundamentalParameter_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != uafundamentalParameter_0.ushort_1)
			{
				result = false;
			}
			if (float_0 != uafundamentalParameter_0.float_0)
			{
				result = false;
			}
			if (float_1 != uafundamentalParameter_0.float_1)
			{
				result = false;
			}
			if (float_2 != uafundamentalParameter_0.float_2)
			{
				result = false;
			}
			if (float_3 != uafundamentalParameter_0.float_3)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode();
	}
}
