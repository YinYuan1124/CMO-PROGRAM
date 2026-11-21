using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(PduHeader))]
public class SimulationManagementPduHeader
{
	private PduHeader pduHeader_0 = new PduHeader();

	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(PduHeader), ElementName = "pduHeader")]
	public PduHeader PduHeader
	{
		get
		{
			return pduHeader_0;
		}
		set
		{
			pduHeader_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "recevingID")]
	public EntityID RecevingID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
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

	public static bool operator !=(SimulationManagementPduHeader simulationManagementPduHeader_0, SimulationManagementPduHeader simulationManagementPduHeader_1)
	{
		return !(simulationManagementPduHeader_0 == simulationManagementPduHeader_1);
	}

	public static bool operator ==(SimulationManagementPduHeader simulationManagementPduHeader_0, SimulationManagementPduHeader simulationManagementPduHeader_1)
	{
		if ((object)simulationManagementPduHeader_0 == simulationManagementPduHeader_1)
		{
			return true;
		}
		if ((object)simulationManagementPduHeader_0 != null && (object)simulationManagementPduHeader_1 != null)
		{
			return simulationManagementPduHeader_0.Equals(simulationManagementPduHeader_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return pduHeader_0.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize();
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
				pduHeader_0.Marshal(dataOutputStream_0);
				entityID_0.Marshal(dataOutputStream_0);
				entityID_1.Marshal(dataOutputStream_0);
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
				pduHeader_0.Unmarshal(dataInputStream_0);
				entityID_0.Unmarshal(dataInputStream_0);
				entityID_1.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<SimulationManagementPduHeader>");
		try
		{
			stringBuilder_0.AppendLine("<pduHeader>");
			pduHeader_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</pduHeader>");
			stringBuilder_0.AppendLine("<originatingID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</originatingID>");
			stringBuilder_0.AppendLine("<recevingID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</recevingID>");
			stringBuilder_0.AppendLine("</SimulationManagementPduHeader>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SimulationManagementPduHeader;
	}

	public bool Equals(SimulationManagementPduHeader simulationManagementPduHeader_0)
	{
		bool result = true;
		if (simulationManagementPduHeader_0.GetType() == GetType())
		{
			if (!pduHeader_0.Equals(simulationManagementPduHeader_0.pduHeader_0))
			{
				result = false;
			}
			if (!entityID_0.Equals(simulationManagementPduHeader_0.entityID_0))
			{
				result = false;
			}
			if (!entityID_1.Equals(simulationManagementPduHeader_0.entityID_1))
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
		return smethod_0(smethod_0(smethod_0(0) ^ pduHeader_0.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode();
	}
}
