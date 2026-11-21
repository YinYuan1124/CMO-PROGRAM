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
public class ExplosionDescriptor
{
	private EntityType entityType_0 = new EntityType();

	private ushort ushort_0;

	private ushort ushort_1;

	private float float_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "explodingObject")]
	public EntityType ExplodingObject
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

	[XmlElement(Type = typeof(ushort), ElementName = "explosiveMaterial")]
	public ushort ExplosiveMaterial
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(float), ElementName = "explosiveForce")]
	public float ExplosiveForce
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

	public static bool operator !=(ExplosionDescriptor explosionDescriptor_0, ExplosionDescriptor explosionDescriptor_1)
	{
		return !(explosionDescriptor_0 == explosionDescriptor_1);
	}

	public static bool operator ==(ExplosionDescriptor explosionDescriptor_0, ExplosionDescriptor explosionDescriptor_1)
	{
		if ((object)explosionDescriptor_0 == explosionDescriptor_1)
		{
			return true;
		}
		if ((object)explosionDescriptor_0 != null && (object)explosionDescriptor_1 != null)
		{
			return explosionDescriptor_0.Equals(explosionDescriptor_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 2 + 2 + 4;
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
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteFloat(float_0);
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
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				float_0 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ExplosionDescriptor>");
		try
		{
			stringBuilder_0.AppendLine("<explodingObject>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</explodingObject>");
			stringBuilder_0.AppendLine("<explosiveMaterial type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</explosiveMaterial>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<explosiveForce type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</explosiveForce>");
			stringBuilder_0.AppendLine("</ExplosionDescriptor>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ExplosionDescriptor;
	}

	public bool Equals(ExplosionDescriptor explosionDescriptor_0)
	{
		bool result = true;
		if (explosionDescriptor_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(explosionDescriptor_0.entityType_0))
			{
				result = false;
			}
			if (ushort_0 != explosionDescriptor_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != explosionDescriptor_0.ushort_1)
			{
				result = false;
			}
			if (float_0 != explosionDescriptor_0.float_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ float_0.GetHashCode();
	}
}
