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
public class ExpendableReload
{
	private EntityType entityType_0 = new EntityType();

	private uint uint_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private uint uint_1;

	private uint uint_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "expendable")]
	public EntityType Expendable
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

	[XmlElement(Type = typeof(ushort), ElementName = "standardQuantity")]
	public ushort StandardQuantity
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

	[XmlElement(Type = typeof(ushort), ElementName = "maximumQuantity")]
	public ushort MaximumQuantity
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

	[XmlElement(Type = typeof(uint), ElementName = "standardQuantityReloadTime")]
	public uint StandardQuantityReloadTime
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "maximumQuantityReloadTime")]
	public uint MaximumQuantityReloadTime
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
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

	public static bool operator !=(ExpendableReload expendableReload_0, ExpendableReload expendableReload_1)
	{
		return !(expendableReload_0 == expendableReload_1);
	}

	public static bool operator ==(ExpendableReload expendableReload_0, ExpendableReload expendableReload_1)
	{
		if ((object)expendableReload_0 == expendableReload_1)
		{
			return true;
		}
		if ((object)expendableReload_0 != null && (object)expendableReload_1 != null)
		{
			return expendableReload_0.Equals(expendableReload_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 4 + 2 + 2 + 4 + 4;
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
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteUnsignedInt(uint_2);
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
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				uint_2 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ExpendableReload>");
		try
		{
			stringBuilder_0.AppendLine("<expendable>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</expendable>");
			stringBuilder_0.AppendLine("<station type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</station>");
			stringBuilder_0.AppendLine("<standardQuantity type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
			stringBuilder_0.AppendLine("<maximumQuantity type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
			stringBuilder_0.AppendLine("<standardQuantityReloadTime type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
			stringBuilder_0.AppendLine("<maximumQuantityReloadTime type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
			stringBuilder_0.AppendLine("</ExpendableReload>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ExpendableReload;
	}

	public bool Equals(ExpendableReload expendableReload_0)
	{
		bool result = true;
		if (expendableReload_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(expendableReload_0.entityType_0))
			{
				result = false;
			}
			if (uint_0 != expendableReload_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != expendableReload_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != expendableReload_0.ushort_1)
			{
				result = false;
			}
			if (uint_1 != expendableReload_0.uint_1)
			{
				result = false;
			}
			if (uint_2 != expendableReload_0.uint_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ uint_1.GetHashCode()) ^ uint_2.GetHashCode();
	}
}
