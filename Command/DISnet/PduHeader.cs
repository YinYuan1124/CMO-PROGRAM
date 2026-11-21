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
public class PduHeader
{
	private byte byte_0 = 7;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private uint uint_0;

	private byte byte_4;

	private ushort ushort_0;

	private byte byte_5;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "protocolVersion")]
	public byte ProtocolVersion
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

	[XmlElement(Type = typeof(byte), ElementName = "exerciseID")]
	public byte ExerciseID
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pduType")]
	public byte PduType
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "protocolFamily")]
	public byte ProtocolFamily
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "timestamp")]
	public uint Timestamp
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

	[XmlElement(Type = typeof(byte), ElementName = "pduLength")]
	public byte PduLength
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "pduStatus")]
	public ushort PduStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
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

	public static bool operator !=(PduHeader pduHeader_0, PduHeader pduHeader_1)
	{
		return !(pduHeader_0 == pduHeader_1);
	}

	public static bool operator ==(PduHeader pduHeader_0, PduHeader pduHeader_1)
	{
		if ((object)pduHeader_0 == pduHeader_1)
		{
			return true;
		}
		if ((object)pduHeader_0 != null && (object)pduHeader_1 != null)
		{
			return pduHeader_0.Equals(pduHeader_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 12;
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
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedByte(byte_4);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedByte(byte_5);
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
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				byte_4 = dataInputStream_0.ReadUnsignedByte();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				byte_5 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<PduHeader>");
		try
		{
			stringBuilder_0.AppendLine("<protocolVersion type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</protocolVersion>");
			stringBuilder_0.AppendLine("<exerciseID type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</exerciseID>");
			stringBuilder_0.AppendLine("<pduType type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</pduType>");
			stringBuilder_0.AppendLine("<protocolFamily type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</protocolFamily>");
			stringBuilder_0.AppendLine("<timestamp type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</timestamp>");
			stringBuilder_0.AppendLine("<pduLength type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</pduLength>");
			stringBuilder_0.AppendLine("<pduStatus type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</pduStatus>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</PduHeader>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as PduHeader;
	}

	public bool Equals(PduHeader pduHeader_0)
	{
		bool result = true;
		if (pduHeader_0.GetType() == GetType())
		{
			if (byte_0 != pduHeader_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != pduHeader_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != pduHeader_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != pduHeader_0.byte_3)
			{
				result = false;
			}
			if (uint_0 != pduHeader_0.uint_0)
			{
				result = false;
			}
			if (byte_4 != pduHeader_0.byte_4)
			{
				result = false;
			}
			if (ushort_0 != pduHeader_0.ushort_0)
			{
				result = false;
			}
			if (byte_5 != pduHeader_0.byte_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ uint_0.GetHashCode()) ^ byte_4.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_5.GetHashCode();
	}
}
