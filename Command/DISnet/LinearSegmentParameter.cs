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
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
public class LinearSegmentParameter
{
	private byte lpkEgquAqRk;

	private byte byte_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "segmentNumber")]
	public byte SegmentNumber
	{
		get
		{
			return lpkEgquAqRk;
		}
		set
		{
			lpkEgquAqRk = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "segmentModification")]
	public byte SegmentModification
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

	[XmlElement(Type = typeof(ushort), ElementName = "generalSegmentAppearance")]
	public ushort GeneralSegmentAppearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "specificSegmentAppearance")]
	public ushort SpecificSegmentAppearance
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "segmentLocation")]
	public Vector3Double SegmentLocation
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(EulerAngles), ElementName = "segmentOrientation")]
	public EulerAngles SegmentOrientation
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentLength")]
	public ushort SegmentLength
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "segmentWidth")]
	public ushort SegmentWidth
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "segmentHeight")]
	public ushort SegmentHeight
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "segmentDepth")]
	public ushort SegmentDepth
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
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

	public static bool operator !=(LinearSegmentParameter linearSegmentParameter_0, LinearSegmentParameter linearSegmentParameter_1)
	{
		return !(linearSegmentParameter_0 == linearSegmentParameter_1);
	}

	public static bool operator ==(LinearSegmentParameter linearSegmentParameter_0, LinearSegmentParameter linearSegmentParameter_1)
	{
		if ((object)linearSegmentParameter_0 == linearSegmentParameter_1)
		{
			return true;
		}
		if ((object)linearSegmentParameter_0 != null && (object)linearSegmentParameter_1 != null)
		{
			return linearSegmentParameter_0.Equals(linearSegmentParameter_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 6 + vector3Double_0.GetMarshalledSize() + eulerAngles_0.GetMarshalledSize() + 2 + 2 + 2 + 2;
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
				dataOutputStream_0.WriteUnsignedByte(lpkEgquAqRk);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				vector3Double_0.Marshal(dataOutputStream_0);
				eulerAngles_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				dataOutputStream_0.WriteUnsignedShort(ushort_3);
				dataOutputStream_0.WriteUnsignedShort(ushort_4);
				dataOutputStream_0.WriteUnsignedShort(ushort_5);
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
				lpkEgquAqRk = dataInputStream_0.ReadUnsignedByte();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				vector3Double_0.Unmarshal(dataInputStream_0);
				eulerAngles_0.Unmarshal(dataInputStream_0);
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				ushort_3 = dataInputStream_0.ReadUnsignedShort();
				ushort_4 = dataInputStream_0.ReadUnsignedShort();
				ushort_5 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<LinearSegmentParameter>");
		try
		{
			stringBuilder_0.AppendLine("<segmentNumber type=\"byte\">" + lpkEgquAqRk.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
			stringBuilder_0.AppendLine("<segmentModification type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</segmentModification>");
			stringBuilder_0.AppendLine("<generalSegmentAppearance type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</generalSegmentAppearance>");
			stringBuilder_0.AppendLine("<specificSegmentAppearance type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</specificSegmentAppearance>");
			stringBuilder_0.AppendLine("<segmentLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</segmentLocation>");
			stringBuilder_0.AppendLine("<segmentOrientation>");
			eulerAngles_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</segmentOrientation>");
			stringBuilder_0.AppendLine("<segmentLength type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
			stringBuilder_0.AppendLine("<segmentWidth type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
			stringBuilder_0.AppendLine("<segmentHeight type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
			stringBuilder_0.AppendLine("<segmentDepth type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
			stringBuilder_0.AppendLine("</LinearSegmentParameter>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LinearSegmentParameter;
	}

	public bool Equals(LinearSegmentParameter linearSegmentParameter_0)
	{
		bool result = true;
		if (linearSegmentParameter_0.GetType() == GetType())
		{
			if (lpkEgquAqRk != linearSegmentParameter_0.lpkEgquAqRk)
			{
				result = false;
			}
			if (byte_0 != linearSegmentParameter_0.byte_0)
			{
				result = false;
			}
			if (ushort_0 != linearSegmentParameter_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != linearSegmentParameter_0.ushort_1)
			{
				result = false;
			}
			if (!vector3Double_0.Equals(linearSegmentParameter_0.vector3Double_0))
			{
				result = false;
			}
			if (!eulerAngles_0.Equals(linearSegmentParameter_0.eulerAngles_0))
			{
				result = false;
			}
			if (ushort_2 != linearSegmentParameter_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != linearSegmentParameter_0.ushort_3)
			{
				result = false;
			}
			if (ushort_4 != linearSegmentParameter_0.ushort_4)
			{
				result = false;
			}
			if (ushort_5 != linearSegmentParameter_0.ushort_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ lpkEgquAqRk.GetHashCode()) ^ byte_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ eulerAngles_0.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ ushort_4.GetHashCode()) ^ ushort_5.GetHashCode();
	}
}
