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
[XmlInclude(typeof(EntityID))]
public class GClass1
{
	private uint uint_0 = 5501u;

	private ushort ushort_0 = 16;

	private byte byte_0;

	private byte byte_1;

	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
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

	[XmlElement(Type = typeof(byte), ElementName = "communcationsNodeType")]
	public byte CommuncationsNodeType
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	[XmlElement(Type = typeof(EntityID), ElementName = "communicationsNode")]
	public EntityID CommunicationsNode
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "elementID")]
	public ushort ElementID
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

	public static bool operator !=(GClass1 gclass1_0, GClass1 gclass1_1)
	{
		return !(gclass1_0 == gclass1_1);
	}

	public static bool operator ==(GClass1 gclass1_0, GClass1 gclass1_1)
	{
		if ((object)gclass1_0 == gclass1_1)
		{
			return true;
		}
		if ((object)gclass1_0 != null && (object)gclass1_1 != null)
		{
			return gclass1_0.Equals(gclass1_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 8 + entityID_0.GetMarshalledSize() + 2;
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
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				entityID_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
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
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				entityID_0.Unmarshal(dataInputStream_0);
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<IOCommunicationsNode>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<communcationsNodeType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</communcationsNodeType>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<communicationsNode>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</communicationsNode>");
			stringBuilder_0.AppendLine("<elementID type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</elementID>");
			stringBuilder_0.AppendLine("</IOCommunicationsNode>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as GClass1;
	}

	public bool Equals(GClass1 gclass1_0)
	{
		bool result = true;
		if (gclass1_0.GetType() == GetType())
		{
			if (uint_0 != gclass1_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != gclass1_0.ushort_0)
			{
				result = false;
			}
			if (byte_0 != gclass1_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != gclass1_0.byte_1)
			{
				result = false;
			}
			if (!entityID_0.Equals(gclass1_0.entityID_0))
			{
				result = false;
			}
			if (ushort_1 != gclass1_0.ushort_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_1.GetHashCode();
	}
}
