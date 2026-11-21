using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EulerAngles))]
[XmlRoot]
public class BeamAntennaPattern
{
	private EulerAngles eulerAngles_0 = new EulerAngles();

	private float float_0;

	private float float_1;

	private float float_2;

	private byte byte_0;

	private ushort ushort_0;

	private float float_3;

	private float float_4;

	private float float_5;

	private uint uint_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EulerAngles), ElementName = "beamDirection")]
	public EulerAngles BeamDirection
	{
		get
		{
			return eulerAngles_0;
		}
		set
		{
			eulerAngles_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "azimuthBeamwidth")]
	public float AzimuthBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "elevationBeamwidth")]
	public float ElevationBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "referenceSystem")]
	public float ReferenceSystem
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
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

	[XmlElement(Type = typeof(float), ElementName = "ez")]
	public float Ez
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

	[XmlElement(Type = typeof(float), ElementName = "ex")]
	public float Ex
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "phase")]
	public float Phase
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "padding3")]
	public uint Padding3
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
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

	public static bool operator !=(BeamAntennaPattern beamAntennaPattern_0, BeamAntennaPattern beamAntennaPattern_1)
	{
		return !(beamAntennaPattern_0 == beamAntennaPattern_1);
	}

	public static bool operator ==(BeamAntennaPattern beamAntennaPattern_0, BeamAntennaPattern beamAntennaPattern_1)
	{
		if ((object)beamAntennaPattern_0 == beamAntennaPattern_1)
		{
			return true;
		}
		if ((object)beamAntennaPattern_0 != null && (object)beamAntennaPattern_1 != null)
		{
			return beamAntennaPattern_0.Equals(beamAntennaPattern_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return eulerAngles_0.GetMarshalledSize() + 4 + 4 + 4 + 1 + 2 + 4 + 4 + 4 + 4;
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
				eulerAngles_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteFloat(float_3);
				dataOutputStream_0.WriteFloat(float_4);
				dataOutputStream_0.WriteFloat(float_5);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
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
				eulerAngles_0.Unmarshal(dataInputStream_0);
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				float_3 = dataInputStream_0.ReadFloat();
				float_4 = dataInputStream_0.ReadFloat();
				float_5 = dataInputStream_0.ReadFloat();
				uint_0 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<BeamAntennaPattern>");
		try
		{
			stringBuilder_0.AppendLine("<beamDirection>");
			eulerAngles_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</beamDirection>");
			stringBuilder_0.AppendLine("<azimuthBeamwidth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</azimuthBeamwidth>");
			stringBuilder_0.AppendLine("<elevationBeamwidth type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</elevationBeamwidth>");
			stringBuilder_0.AppendLine("<referenceSystem type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</referenceSystem>");
			stringBuilder_0.AppendLine("<padding1 type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<ez type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</ez>");
			stringBuilder_0.AppendLine("<ex type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</ex>");
			stringBuilder_0.AppendLine("<phase type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</phase>");
			stringBuilder_0.AppendLine("<padding3 type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			stringBuilder_0.AppendLine("</BeamAntennaPattern>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as BeamAntennaPattern;
	}

	public bool Equals(BeamAntennaPattern beamAntennaPattern_0)
	{
		bool result = true;
		if (beamAntennaPattern_0.GetType() == GetType())
		{
			if (!eulerAngles_0.Equals(beamAntennaPattern_0.eulerAngles_0))
			{
				result = false;
			}
			if (float_0 != beamAntennaPattern_0.float_0)
			{
				result = false;
			}
			if (float_1 != beamAntennaPattern_0.float_1)
			{
				result = false;
			}
			if (float_2 != beamAntennaPattern_0.float_2)
			{
				result = false;
			}
			if (byte_0 != beamAntennaPattern_0.byte_0)
			{
				result = false;
			}
			if (ushort_0 != beamAntennaPattern_0.ushort_0)
			{
				result = false;
			}
			if (float_3 != beamAntennaPattern_0.float_3)
			{
				result = false;
			}
			if (float_4 != beamAntennaPattern_0.float_4)
			{
				result = false;
			}
			if (float_5 != beamAntennaPattern_0.float_5)
			{
				result = false;
			}
			if (uint_0 != beamAntennaPattern_0.uint_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ eulerAngles_0.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ byte_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ uint_0.GetHashCode();
	}
}
