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
[XmlInclude(typeof(SimulationAddress))]
public class AggregateIdentifier
{
	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private ushort ushort_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "simulationAddress")]
	public SimulationAddress SimulationAddress
	{
		get
		{
			return simulationAddress_0;
		}
		set
		{
			simulationAddress_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "aggregateID")]
	public ushort AggregateID
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

	public static bool operator !=(AggregateIdentifier aggregateIdentifier_0, AggregateIdentifier aggregateIdentifier_1)
	{
		return !(aggregateIdentifier_0 == aggregateIdentifier_1);
	}

	public static bool operator ==(AggregateIdentifier aggregateIdentifier_0, AggregateIdentifier aggregateIdentifier_1)
	{
		if ((object)aggregateIdentifier_0 == aggregateIdentifier_1)
		{
			return true;
		}
		if ((object)aggregateIdentifier_0 != null && (object)aggregateIdentifier_1 != null)
		{
			return aggregateIdentifier_0.Equals(aggregateIdentifier_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return simulationAddress_0.GetMarshalledSize() + 2;
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
				simulationAddress_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
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
				simulationAddress_0.Unmarshal(dataInputStream_0);
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<AggregateIdentifier>");
		try
		{
			stringBuilder_0.AppendLine("<simulationAddress>");
			simulationAddress_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</simulationAddress>");
			stringBuilder_0.AppendLine("<aggregateID type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</aggregateID>");
			stringBuilder_0.AppendLine("</AggregateIdentifier>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AggregateIdentifier;
	}

	public bool Equals(AggregateIdentifier aggregateIdentifier_0)
	{
		bool result = true;
		if (aggregateIdentifier_0.GetType() == GetType())
		{
			if (!simulationAddress_0.Equals(aggregateIdentifier_0.simulationAddress_0))
			{
				result = false;
			}
			if (ushort_0 != aggregateIdentifier_0.ushort_0)
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
		return smethod_0(smethod_0(0) ^ simulationAddress_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}
}
