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
public class SupplyQuantity
{
	private EntityType entityType_0 = new EntityType();

	private float float_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "supplyType")]
	public EntityType SupplyType
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

	[XmlElement(Type = typeof(float), ElementName = "quantity")]
	public float Quantity
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

	public static bool operator !=(SupplyQuantity supplyQuantity_0, SupplyQuantity supplyQuantity_1)
	{
		return !(supplyQuantity_0 == supplyQuantity_1);
	}

	public static bool operator ==(SupplyQuantity supplyQuantity_0, SupplyQuantity supplyQuantity_1)
	{
		if ((object)supplyQuantity_0 == supplyQuantity_1)
		{
			return true;
		}
		if ((object)supplyQuantity_0 != null && (object)supplyQuantity_1 != null)
		{
			return supplyQuantity_0.Equals(supplyQuantity_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 4;
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
		stringBuilder_0.AppendLine("<SupplyQuantity>");
		try
		{
			stringBuilder_0.AppendLine("<supplyType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</supplyType>");
			stringBuilder_0.AppendLine("<quantity type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			stringBuilder_0.AppendLine("</SupplyQuantity>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SupplyQuantity;
	}

	public bool Equals(SupplyQuantity supplyQuantity_0)
	{
		bool result = true;
		if (supplyQuantity_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(supplyQuantity_0.entityType_0))
			{
				result = false;
			}
			if (float_0 != supplyQuantity_0.float_0)
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
		return smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ float_0.GetHashCode();
	}
}
