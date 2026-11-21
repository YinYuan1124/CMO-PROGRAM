#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
public class DeadReckoningParameter
{
	private byte byte_0;

	private byte[] byte_1 = new byte[15];

	private Vector3Float AqhEofOhqkD = new Vector3Float();

	private Vector3Float vector3Float_0 = new Vector3Float();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
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

	[XmlArray(ElementName = "otherParameters")]
	public byte[] OtherParameters
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
	public Vector3Float EntityLinearAcceleration
	{
		get
		{
			return AqhEofOhqkD;
		}
		set
		{
			AqhEofOhqkD = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityAngularVelocity")]
	public Vector3Float EntityAngularVelocity
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
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

	public static bool operator !=(DeadReckoningParameter deadReckoningParameter_0, DeadReckoningParameter deadReckoningParameter_1)
	{
		return !(deadReckoningParameter_0 == deadReckoningParameter_1);
	}

	public static bool operator ==(DeadReckoningParameter deadReckoningParameter_0, DeadReckoningParameter deadReckoningParameter_1)
	{
		if ((object)deadReckoningParameter_0 == deadReckoningParameter_1)
		{
			return true;
		}
		if ((object)deadReckoningParameter_0 != null && (object)deadReckoningParameter_1 != null)
		{
			return deadReckoningParameter_0.Equals(deadReckoningParameter_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 16 + AqhEofOhqkD.GetMarshalledSize() + vector3Float_0.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_0);
			for (int i = 0; i < byte_1.Length; i++)
			{
				dataOutputStream_0.WriteByte(byte_1[i]);
			}
			AqhEofOhqkD.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
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
			byte_0 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < byte_1.Length; i++)
			{
				byte_1[i] = dataInputStream_0.ReadByte();
			}
			AqhEofOhqkD.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<DeadReckoningParameter>");
		try
		{
			stringBuilder_0.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				stringBuilder_0.AppendLine("<otherParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</otherParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<entityLinearAcceleration>");
			AqhEofOhqkD.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLinearAcceleration>");
			stringBuilder_0.AppendLine("<entityAngularVelocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityAngularVelocity>");
			stringBuilder_0.AppendLine("</DeadReckoningParameter>");
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
		return this == obj as DeadReckoningParameter;
	}

	public bool Equals(DeadReckoningParameter deadReckoningParameter_0)
	{
		bool flag = true;
		if (deadReckoningParameter_0.GetType() == GetType())
		{
			if (byte_0 != deadReckoningParameter_0.byte_0)
			{
				flag = false;
			}
			if (deadReckoningParameter_0.byte_1.Length != 15)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 15; i++)
				{
					if (byte_1[i] != deadReckoningParameter_0.byte_1[i])
					{
						flag = false;
					}
				}
			}
			if (!AqhEofOhqkD.Equals(deadReckoningParameter_0.AqhEofOhqkD))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(deadReckoningParameter_0.vector3Float_0))
			{
				flag = false;
			}
			return flag;
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
		int num = 0;
		num = smethod_0(0) ^ byte_0.GetHashCode();
		for (int i = 0; i < 15; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		num = smethod_0(num) ^ AqhEofOhqkD.GetHashCode();
		return smethod_0(num) ^ vector3Float_0.GetHashCode();
	}
}
