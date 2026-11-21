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
public class EntityAssociation
{
	private byte byte_0 = 2;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private EntityID entityID_0 = new EntityID();

	private ushort ushort_0;

	private ushort ushort_1;

	private byte byte_4;

	private ushort ushort_2;

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

	[XmlElement(Type = typeof(byte), ElementName = "associationStatus")]
	public byte AssociationStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "associationType")]
	public byte AssociationType
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

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "owsSttionLocation")]
	public ushort OwsSttionLocation
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

	[XmlElement(Type = typeof(ushort), ElementName = "physicalConnectionType")]
	public ushort PhysicalConnectionType
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

	[XmlElement(Type = typeof(byte), ElementName = "groupMemberType")]
	public byte GroupMemberType
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

	[XmlElement(Type = typeof(ushort), ElementName = "groupNumber")]
	public ushort GroupNumber
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

	public static bool operator !=(EntityAssociation entityAssociation_0, EntityAssociation entityAssociation_1)
	{
		return !(entityAssociation_0 == entityAssociation_1);
	}

	public static bool operator ==(EntityAssociation entityAssociation_0, EntityAssociation entityAssociation_1)
	{
		if ((object)entityAssociation_0 == entityAssociation_1)
		{
			return true;
		}
		if ((object)entityAssociation_0 != null && (object)entityAssociation_1 != null)
		{
			return entityAssociation_0.Equals(entityAssociation_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 4 + entityID_0.GetMarshalledSize() + 2 + 2 + 1 + 2;
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
				entityID_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedByte(byte_4);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
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
				entityID_0.Unmarshal(dataInputStream_0);
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				byte_4 = dataInputStream_0.ReadUnsignedByte();
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EntityAssociation>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<changeIndicator type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</changeIndicator>");
			stringBuilder_0.AppendLine("<associationStatus type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</associationStatus>");
			stringBuilder_0.AppendLine("<associationType type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</associationType>");
			stringBuilder_0.AppendLine("<entityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityID>");
			stringBuilder_0.AppendLine("<owsSttionLocation type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</owsSttionLocation>");
			stringBuilder_0.AppendLine("<physicalConnectionType type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</physicalConnectionType>");
			stringBuilder_0.AppendLine("<groupMemberType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</groupMemberType>");
			stringBuilder_0.AppendLine("<groupNumber type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</groupNumber>");
			stringBuilder_0.AppendLine("</EntityAssociation>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityAssociation;
	}

	public bool Equals(EntityAssociation entityAssociation_0)
	{
		bool result = true;
		if (entityAssociation_0.GetType() == GetType())
		{
			if (byte_0 != entityAssociation_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != entityAssociation_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != entityAssociation_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != entityAssociation_0.byte_3)
			{
				result = false;
			}
			if (!entityID_0.Equals(entityAssociation_0.entityID_0))
			{
				result = false;
			}
			if (ushort_0 != entityAssociation_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != entityAssociation_0.ushort_1)
			{
				result = false;
			}
			if (byte_4 != entityAssociation_0.byte_4)
			{
				result = false;
			}
			if (ushort_2 != entityAssociation_0.ushort_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_4.GetHashCode()) ^ ushort_2.GetHashCode();
	}
}
