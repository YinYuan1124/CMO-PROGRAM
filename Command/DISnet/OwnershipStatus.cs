using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class OwnershipStatus
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_0;

	private byte byte_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "entityId")]
	public EntityID EntityId
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

	[XmlElement(Type = typeof(byte), ElementName = "ownershipStatus")]
	public byte OwnershipStatus_
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

	public static bool operator !=(OwnershipStatus ownershipStatus_0, OwnershipStatus ownershipStatus_1)
	{
		return !(ownershipStatus_0 == ownershipStatus_1);
	}

	public static bool operator ==(OwnershipStatus ownershipStatus_0, OwnershipStatus ownershipStatus_1)
	{
		if ((object)ownershipStatus_0 == ownershipStatus_1)
		{
			return true;
		}
		if ((object)ownershipStatus_0 != null && (object)ownershipStatus_1 != null)
		{
			return ownershipStatus_0.Equals(ownershipStatus_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityID_0.GetMarshalledSize() + 1 + 1;
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
				entityID_0.Marshal(dataOutputStream_0);
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
				entityID_0.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<OwnershipStatus>");
		try
		{
			stringBuilder_0.AppendLine("<entityId>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityId>");
			stringBuilder_0.AppendLine("<ownershipStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</ownershipStatus>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</OwnershipStatus>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as OwnershipStatus;
	}

	public bool Equals(OwnershipStatus ownershipStatus_0)
	{
		bool result = true;
		if (ownershipStatus_0.GetType() == GetType())
		{
			if (!entityID_0.Equals(ownershipStatus_0.entityID_0))
			{
				result = false;
			}
			if (byte_0 != ownershipStatus_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != ownershipStatus_0.byte_1)
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
		return smethod_0(smethod_0(smethod_0(0) ^ entityID_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode();
	}
}
