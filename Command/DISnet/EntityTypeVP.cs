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
[XmlInclude(typeof(EntityType))]
public class EntityTypeVP
{
	private byte byte_0 = 3;

	private byte byte_1;

	private EntityType entityType_0 = new EntityType();

	private ushort ushort_0;

	private uint uint_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "recordType")]
	public byte RecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "changeIndicator")]
	public byte ChangeIndicator
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

	[XmlElement(Type = typeof(EntityType), ElementName = "entityType")]
	public EntityType EntityType
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(uint), ElementName = "padding1")]
	public uint Padding1
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

	public static bool operator !=(EntityTypeVP entityTypeVP_0, EntityTypeVP entityTypeVP_1)
	{
		return !(entityTypeVP_0 == entityTypeVP_1);
	}

	public static bool operator ==(EntityTypeVP entityTypeVP_0, EntityTypeVP entityTypeVP_1)
	{
		if ((object)entityTypeVP_0 == entityTypeVP_1)
		{
			return true;
		}
		if ((object)entityTypeVP_0 != null && (object)entityTypeVP_1 != null)
		{
			return entityTypeVP_0.Equals(entityTypeVP_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 2 + entityType_0.GetMarshalledSize() + 2 + 4;
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
				entityType_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
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
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				entityType_0.Unmarshal(dataInputStream_0);
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<EntityTypeVP>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<changeIndicator type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</changeIndicator>");
			stringBuilder_0.AppendLine("<entityType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityType>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<padding1 type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("</EntityTypeVP>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityTypeVP;
	}

	public bool Equals(EntityTypeVP entityTypeVP_0)
	{
		bool result = true;
		if (entityTypeVP_0.GetType() == GetType())
		{
			if (byte_0 != entityTypeVP_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != entityTypeVP_0.byte_1)
			{
				result = false;
			}
			if (!entityType_0.Equals(entityTypeVP_0.entityType_0))
			{
				result = false;
			}
			if (ushort_0 != entityTypeVP_0.ushort_0)
			{
				result = false;
			}
			if (uint_0 != entityTypeVP_0.uint_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ entityType_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ uint_0.GetHashCode();
	}
}
