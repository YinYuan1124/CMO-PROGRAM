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
public class MunitionDescriptor
{
	private EntityType entityType_0 = new EntityType();

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

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

	[XmlElement(Type = typeof(ushort), ElementName = "warhead")]
	public ushort Warhead
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

	[XmlElement(Type = typeof(ushort), ElementName = "fuse")]
	public ushort Fuse
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

	[XmlElement(Type = typeof(ushort), ElementName = "quantity")]
	public ushort Quantity
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

	[XmlElement(Type = typeof(ushort), ElementName = "rate")]
	public ushort Rate
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

	public static bool operator !=(MunitionDescriptor munitionDescriptor_0, MunitionDescriptor munitionDescriptor_1)
	{
		return !(munitionDescriptor_0 == munitionDescriptor_1);
	}

	public static bool operator ==(MunitionDescriptor munitionDescriptor_0, MunitionDescriptor munitionDescriptor_1)
	{
		if ((object)munitionDescriptor_0 == munitionDescriptor_1)
		{
			return true;
		}
		if ((object)munitionDescriptor_0 != null && (object)munitionDescriptor_1 != null)
		{
			return munitionDescriptor_0.Equals(munitionDescriptor_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 2 + 2 + 2 + 2;
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
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				dataOutputStream_0.WriteUnsignedShort(ushort_3);
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
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				ushort_3 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<MunitionDescriptor>");
		try
		{
			stringBuilder_0.AppendLine("<munitionType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</munitionType>");
			stringBuilder_0.AppendLine("<warhead type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</warhead>");
			stringBuilder_0.AppendLine("<fuse type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</fuse>");
			stringBuilder_0.AppendLine("<quantity type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			stringBuilder_0.AppendLine("<rate type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</rate>");
			stringBuilder_0.AppendLine("</MunitionDescriptor>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as MunitionDescriptor;
	}

	public bool Equals(MunitionDescriptor munitionDescriptor_0)
	{
		bool result = true;
		if (munitionDescriptor_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(munitionDescriptor_0.entityType_0))
			{
				result = false;
			}
			if (ushort_0 != munitionDescriptor_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != munitionDescriptor_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != munitionDescriptor_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != munitionDescriptor_0.ushort_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode();
	}
}
