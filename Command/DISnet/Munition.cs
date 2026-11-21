using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityType))]
[XmlRoot]
public class Munition
{
	private EntityType entityType_0 = new EntityType();

	private uint uint_0;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "munitionType")]
	public EntityType MunitionType
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "station")]
	public uint Station
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

	[XmlElement(Type = typeof(ushort), ElementName = "quantity")]
	public ushort Quantity
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

	[XmlElement(Type = typeof(byte), ElementName = "munitionStatus")]
	public byte MunitionStatus
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

	public static bool operator !=(Munition munition_0, Munition munition_1)
	{
		return !(munition_0 == munition_1);
	}

	public static bool operator ==(Munition munition_0, Munition munition_1)
	{
		if ((object)munition_0 == munition_1)
		{
			return true;
		}
		if ((object)munition_0 != null && (object)munition_1 != null)
		{
			return munition_0.Equals(munition_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 4 + 2 + 1 + 1;
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
				entityType_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
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
				entityType_0.Unmarshal(dataInputStream_0);
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<Munition>");
		try
		{
			stringBuilder_0.AppendLine("<munitionType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</munitionType>");
			stringBuilder_0.AppendLine("<station type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</station>");
			stringBuilder_0.AppendLine("<quantity type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			stringBuilder_0.AppendLine("<munitionStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</munitionStatus>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</Munition>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Munition;
	}

	public bool Equals(Munition munition_0)
	{
		bool result = true;
		if (munition_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(munition_0.entityType_0))
			{
				result = false;
			}
			if (uint_0 != munition_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != munition_0.ushort_0)
			{
				result = false;
			}
			if (byte_0 != munition_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != munition_0.byte_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode();
	}
}
