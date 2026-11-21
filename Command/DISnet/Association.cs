using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class Association
{
	private byte byte_0;

	private byte byte_1;

	private EntityID entityID_0 = new EntityID();

	private Vector3Double vector3Double_0 = new Vector3Double();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "associationType")]
	public byte AssociationType
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

	[XmlElement(Type = typeof(byte), ElementName = "padding4")]
	public byte Padding4
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

	[XmlElement(Type = typeof(EntityID), ElementName = "associatedEntityID")]
	public EntityID AssociatedEntityID
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "associatedLocation")]
	public Vector3Double AssociatedLocation
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

	public static bool operator !=(Association association_0, Association association_1)
	{
		return !(association_0 == association_1);
	}

	public static bool operator ==(Association association_0, Association association_1)
	{
		if ((object)association_0 == association_1)
		{
			return true;
		}
		if ((object)association_0 != null && (object)association_1 != null)
		{
			return association_0.Equals(association_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 2 + entityID_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize();
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
				entityID_0.Marshal(dataOutputStream_0);
				vector3Double_0.Marshal(dataOutputStream_0);
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
				entityID_0.Unmarshal(dataInputStream_0);
				vector3Double_0.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<Association>");
		try
		{
			stringBuilder_0.AppendLine("<associationType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</associationType>");
			stringBuilder_0.AppendLine("<padding4 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding4>");
			stringBuilder_0.AppendLine("<associatedEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</associatedEntityID>");
			stringBuilder_0.AppendLine("<associatedLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</associatedLocation>");
			stringBuilder_0.AppendLine("</Association>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Association;
	}

	public bool Equals(Association association_0)
	{
		bool result = true;
		if (association_0.GetType() == GetType())
		{
			if (byte_0 != association_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != association_0.byte_1)
			{
				result = false;
			}
			if (!entityID_0.Equals(association_0.entityID_0))
			{
				result = false;
			}
			if (!vector3Double_0.Equals(association_0.vector3Double_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ entityID_0.GetHashCode()) ^ vector3Double_0.GetHashCode();
	}
}
