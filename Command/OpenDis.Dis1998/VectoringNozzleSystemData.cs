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
public class VectoringNozzleSystemData
{
	private float float_0;

	private float float_1;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(float), ElementName = "horizontalDeflectionAngle")]
	public float HorizontalDeflectionAngle
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

	[XmlElement(Type = typeof(float), ElementName = "verticalDeflectionAngle")]
	public float VerticalDeflectionAngle
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

	public static bool operator !=(VectoringNozzleSystemData vectoringNozzleSystemData_0, VectoringNozzleSystemData vectoringNozzleSystemData_1)
	{
		return !(vectoringNozzleSystemData_0 == vectoringNozzleSystemData_1);
	}

	public static bool operator ==(VectoringNozzleSystemData vectoringNozzleSystemData_0, VectoringNozzleSystemData vectoringNozzleSystemData_1)
	{
		if ((object)vectoringNozzleSystemData_0 == vectoringNozzleSystemData_1)
		{
			return true;
		}
		if ((object)vectoringNozzleSystemData_0 != null && (object)vectoringNozzleSystemData_1 != null)
		{
			return vectoringNozzleSystemData_0.Equals(vectoringNozzleSystemData_1);
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
		stringBuilder_0.AppendLine("<VectoringNozzleSystemData>");
		try
		{
			stringBuilder_0.AppendLine("<horizontalDeflectionAngle type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</horizontalDeflectionAngle>");
			stringBuilder_0.AppendLine("<verticalDeflectionAngle type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</verticalDeflectionAngle>");
			stringBuilder_0.AppendLine("</VectoringNozzleSystemData>");
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
		return this == obj as VectoringNozzleSystemData;
	}

	public bool Equals(VectoringNozzleSystemData vectoringNozzleSystemData_0)
	{
		bool result = true;
		if (vectoringNozzleSystemData_0.GetType() == GetType())
		{
			if (float_0 != vectoringNozzleSystemData_0.float_0)
			{
				result = false;
			}
			if (float_1 != vectoringNozzleSystemData_0.float_1)
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
