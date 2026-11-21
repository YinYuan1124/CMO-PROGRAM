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
public class PduSuperclass
{
	private byte byte_0 = 7;

	private byte byte_1;

	private byte byte_2;

	private byte qqdEsbIjYhl;

	private uint uint_0;

	private ushort ushort_0;

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
			return qqdEsbIjYhl;
		}
		set
		{
			qqdEsbIjYhl = value;
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

	[XmlElement(Type = typeof(ushort), ElementName = "length")]
	public ushort Length
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

	public static bool operator !=(PduSuperclass pduSuperclass_0, PduSuperclass pduSuperclass_1)
	{
		return !(pduSuperclass_0 == pduSuperclass_1);
	}

	public static bool operator ==(PduSuperclass pduSuperclass_0, PduSuperclass pduSuperclass_1)
	{
		if ((object)pduSuperclass_0 == pduSuperclass_1)
		{
			return true;
		}
		if ((object)pduSuperclass_0 != null && (object)pduSuperclass_1 != null)
		{
			return pduSuperclass_0.Equals(pduSuperclass_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 10;
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
				dataOutputStream_0.WriteUnsignedByte(qqdEsbIjYhl);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
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
				qqdEsbIjYhl = dataInputStream_0.ReadUnsignedByte();
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<PduSuperclass>");
		try
		{
			stringBuilder_0.AppendLine("<protocolVersion type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</protocolVersion>");
			stringBuilder_0.AppendLine("<exerciseID type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</exerciseID>");
			stringBuilder_0.AppendLine("<pduType type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</pduType>");
			stringBuilder_0.AppendLine("<protocolFamily type=\"byte\">" + qqdEsbIjYhl.ToString(CultureInfo.InvariantCulture) + "</protocolFamily>");
			stringBuilder_0.AppendLine("<timestamp type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</timestamp>");
			stringBuilder_0.AppendLine("<length type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</length>");
			stringBuilder_0.AppendLine("</PduSuperclass>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as PduSuperclass;
	}

	public bool Equals(PduSuperclass pduSuperclass_0)
	{
		bool result = true;
		if (pduSuperclass_0.GetType() == GetType())
		{
			if (byte_0 != pduSuperclass_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != pduSuperclass_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != pduSuperclass_0.byte_2)
			{
				result = false;
			}
			if (qqdEsbIjYhl != pduSuperclass_0.qqdEsbIjYhl)
			{
				result = false;
			}
			if (uint_0 != pduSuperclass_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != pduSuperclass_0.ushort_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ qqdEsbIjYhl.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}
}
