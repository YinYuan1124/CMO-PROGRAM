#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
public class PropulsionSystemData
{
	private float float_0;

	private float float_1;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(float), ElementName = "powerSetting")]
	public float PowerSetting
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

	[XmlElement(Type = typeof(float), ElementName = "engineRpm")]
	public float EngineRpm
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public event EventHandler<PduExceptionEventArgs> ExceptionOccured
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static bool operator !=(PropulsionSystemData propulsionSystemData_0, PropulsionSystemData propulsionSystemData_1)
	{
		return !(propulsionSystemData_0 == propulsionSystemData_1);
	}

	public static bool operator ==(PropulsionSystemData propulsionSystemData_0, PropulsionSystemData propulsionSystemData_1)
	{
		if ((object)propulsionSystemData_0 == propulsionSystemData_1)
		{
			return true;
		}
		if ((object)propulsionSystemData_0 != null && (object)propulsionSystemData_1 != null)
		{
			return propulsionSystemData_0.Equals(propulsionSystemData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 8;
	}

	protected void RaiseExceptionOccured(Exception exception_0)
	{
		if (PduBase.FireExceptionEvents && eventHandler_0 != null)
		{
			eventHandler_0(this, new PduExceptionEventArgs(exception_0));
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 == null)
		{
			return;
		}
		try
		{
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<PropulsionSystemData>");
		try
		{
			stringBuilder_0.AppendLine("<powerSetting type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</powerSetting>");
			stringBuilder_0.AppendLine("<engineRpm type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</engineRpm>");
			stringBuilder_0.AppendLine("</PropulsionSystemData>");
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as PropulsionSystemData;
	}

	public bool Equals(PropulsionSystemData propulsionSystemData_0)
	{
		bool result = true;
		if (propulsionSystemData_0.GetType() == GetType())
		{
			if (float_0 != propulsionSystemData_0.float_0)
			{
				result = false;
			}
			if (float_1 != propulsionSystemData_0.float_1)
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
		return smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode();
	}
}
