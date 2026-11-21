#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(TrackJamTarget))]
[XmlInclude(typeof(FundamentalParameterData))]
[XmlRoot]
public class ElectronicEmissionBeamData
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private FundamentalParameterData fundamentalParameterData_0 = new FundamentalParameterData();

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	private uint OfeErKumYy5;

	private List<TrackJamTarget> list_0 = new List<TrackJamTarget>();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
	public byte BeamDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
	public byte BeamIDNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
	public ushort BeamParameterIndex
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

	[XmlElement(Type = typeof(FundamentalParameterData), ElementName = "fundamentalParameterData")]
	public FundamentalParameterData FundamentalParameterData
	{
		get
		{
			return fundamentalParameterData_0;
		}
		set
		{
			fundamentalParameterData_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "beamFunction")]
	public byte BeamFunction
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfTrackJamTargets")]
	public byte NumberOfTrackJamTargets
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "highDensityTrackJam")]
	public byte HighDensityTrackJam
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pad4")]
	public byte Pad4
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "jammingModeSequence")]
	public uint JammingModeSequence
	{
		get
		{
			return OfeErKumYy5;
		}
		set
		{
			OfeErKumYy5 = value;
		}
	}

	[XmlElement(ElementName = "trackJamTargetsList", Type = typeof(List<TrackJamTarget>))]
	public List<TrackJamTarget> TrackJamTargets => list_0;

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

	public static bool operator !=(ElectronicEmissionBeamData electronicEmissionBeamData_0, ElectronicEmissionBeamData electronicEmissionBeamData_1)
	{
		return !(electronicEmissionBeamData_0 == electronicEmissionBeamData_1);
	}

	public static bool operator ==(ElectronicEmissionBeamData electronicEmissionBeamData_0, ElectronicEmissionBeamData electronicEmissionBeamData_1)
	{
		if ((object)electronicEmissionBeamData_0 == electronicEmissionBeamData_1)
		{
			return true;
		}
		if ((object)electronicEmissionBeamData_0 != null && (object)electronicEmissionBeamData_1 != null)
		{
			return electronicEmissionBeamData_0.Equals(electronicEmissionBeamData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 1;
		num = 2;
		num = 4;
		num = 4 + fundamentalParameterData_0.GetMarshalledSize();
		num++;
		num++;
		num++;
		num++;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			TrackJamTarget trackJamTarget = list_0[i];
			num += trackJamTarget.GetMarshalledSize();
		}
		return num;
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
			dataOutputStream_0.WriteUnsignedByte(byte_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			fundamentalParameterData_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_2);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedInt(OfeErKumYy5);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
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
			byte_1 = dataInputStream_0.ReadUnsignedByte();
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			fundamentalParameterData_0.Unmarshal(dataInputStream_0);
			byte_2 = dataInputStream_0.ReadUnsignedByte();
			byte_3 = dataInputStream_0.ReadUnsignedByte();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			OfeErKumYy5 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < NumberOfTrackJamTargets; i++)
			{
				TrackJamTarget trackJamTarget = new TrackJamTarget();
				trackJamTarget.Unmarshal(dataInputStream_0);
				list_0.Add(trackJamTarget);
			}
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
		stringBuilder_0.AppendLine("<ElectronicEmissionBeamData>");
		try
		{
			stringBuilder_0.AppendLine("<beamDataLength type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
			stringBuilder_0.AppendLine("<beamIDNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
			stringBuilder_0.AppendLine("<beamParameterIndex type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
			stringBuilder_0.AppendLine("<fundamentalParameterData>");
			fundamentalParameterData_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</fundamentalParameterData>");
			stringBuilder_0.AppendLine("<beamFunction type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</beamFunction>");
			stringBuilder_0.AppendLine("<trackJamTargets type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</trackJamTargets>");
			stringBuilder_0.AppendLine("<highDensityTrackJam type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</highDensityTrackJam>");
			stringBuilder_0.AppendLine("<pad4 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad4>");
			stringBuilder_0.AppendLine("<jammingModeSequence type=\"uint\">" + OfeErKumYy5.ToString(CultureInfo.InvariantCulture) + "</jammingModeSequence>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<trackJamTargets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"TrackJamTarget\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</trackJamTargets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ElectronicEmissionBeamData>");
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
		return this == obj as ElectronicEmissionBeamData;
	}

	public bool Equals(ElectronicEmissionBeamData electronicEmissionBeamData_0)
	{
		bool flag = true;
		if (electronicEmissionBeamData_0.GetType() == GetType())
		{
			if (byte_0 != electronicEmissionBeamData_0.byte_0)
			{
				flag = false;
			}
			if (byte_1 != electronicEmissionBeamData_0.byte_1)
			{
				flag = false;
			}
			if (ushort_0 != electronicEmissionBeamData_0.ushort_0)
			{
				flag = false;
			}
			if (!fundamentalParameterData_0.Equals(electronicEmissionBeamData_0.fundamentalParameterData_0))
			{
				flag = false;
			}
			if (byte_2 != electronicEmissionBeamData_0.byte_2)
			{
				flag = false;
			}
			if (byte_3 != electronicEmissionBeamData_0.byte_3)
			{
				flag = false;
			}
			if (byte_4 != electronicEmissionBeamData_0.byte_4)
			{
				flag = false;
			}
			if (byte_5 != electronicEmissionBeamData_0.byte_5)
			{
				flag = false;
			}
			if (OfeErKumYy5 != electronicEmissionBeamData_0.OfeErKumYy5)
			{
				flag = false;
			}
			if (list_0.Count != electronicEmissionBeamData_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(electronicEmissionBeamData_0.list_0[i]))
					{
						flag = false;
					}
				}
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
		num = smethod_0(num) ^ byte_1.GetHashCode();
		num = smethod_0(num) ^ ushort_0.GetHashCode();
		num = smethod_0(num) ^ fundamentalParameterData_0.GetHashCode();
		num = smethod_0(num) ^ byte_2.GetHashCode();
		num = smethod_0(num) ^ byte_3.GetHashCode();
		num = smethod_0(num) ^ byte_4.GetHashCode();
		num = smethod_0(num) ^ byte_5.GetHashCode();
		num = smethod_0(num) ^ OfeErKumYy5.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
