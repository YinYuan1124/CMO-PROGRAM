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
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
[XmlInclude(typeof(ElectronicEmissionBeamData))]
[XmlInclude(typeof(EmitterSystem))]
public class ElectronicEmissionSystemData
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private EmitterSystem emitterSystem_0 = new EmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private List<ElectronicEmissionBeamData> list_0 = new List<ElectronicEmissionBeamData>();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
	public byte SystemDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
	public byte NumberOfBeams
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

	[XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
	public ushort EmissionsPadding2
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

	[XmlElement(Type = typeof(EmitterSystem), ElementName = "emitterSystem")]
	public EmitterSystem EmitterSystem
	{
		get
		{
			return emitterSystem_0;
		}
		set
		{
			emitterSystem_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
	public Vector3Float Location
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

	[XmlElement(ElementName = "beamDataRecordsList", Type = typeof(List<ElectronicEmissionBeamData>))]
	public List<ElectronicEmissionBeamData> BeamDataRecords => list_0;

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

	public static bool operator !=(ElectronicEmissionSystemData electronicEmissionSystemData_0, ElectronicEmissionSystemData electronicEmissionSystemData_1)
	{
		return !(electronicEmissionSystemData_0 == electronicEmissionSystemData_1);
	}

	public static bool operator ==(ElectronicEmissionSystemData electronicEmissionSystemData_0, ElectronicEmissionSystemData electronicEmissionSystemData_1)
	{
		if ((object)electronicEmissionSystemData_0 == electronicEmissionSystemData_1)
		{
			return true;
		}
		if ((object)electronicEmissionSystemData_0 != null && (object)electronicEmissionSystemData_1 != null)
		{
			return electronicEmissionSystemData_0.Equals(electronicEmissionSystemData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 1;
		num = 2;
		num = 4;
		num = 4 + emitterSystem_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			ElectronicEmissionBeamData electronicEmissionBeamData = list_0[i];
			num += electronicEmissionBeamData.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			emitterSystem_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
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
			emitterSystem_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			for (int i = 0; i < NumberOfBeams; i++)
			{
				ElectronicEmissionBeamData electronicEmissionBeamData = new ElectronicEmissionBeamData();
				electronicEmissionBeamData.Unmarshal(dataInputStream_0);
				list_0.Add(electronicEmissionBeamData);
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
		stringBuilder_0.AppendLine("<ElectronicEmissionSystemData>");
		try
		{
			stringBuilder_0.AppendLine("<systemDataLength type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
			stringBuilder_0.AppendLine("<beamDataRecords type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</beamDataRecords>");
			stringBuilder_0.AppendLine("<emissionsPadding2 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
			stringBuilder_0.AppendLine("<emitterSystem>");
			emitterSystem_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emitterSystem>");
			stringBuilder_0.AppendLine("<location>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</location>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<beamDataRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionBeamData\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</beamDataRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ElectronicEmissionSystemData>");
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
		return this == obj as ElectronicEmissionSystemData;
	}

	public bool Equals(ElectronicEmissionSystemData electronicEmissionSystemData_0)
	{
		bool flag = true;
		if (electronicEmissionSystemData_0.GetType() == GetType())
		{
			if (byte_0 != electronicEmissionSystemData_0.byte_0)
			{
				flag = false;
			}
			if (byte_1 != electronicEmissionSystemData_0.byte_1)
			{
				flag = false;
			}
			if (ushort_0 != electronicEmissionSystemData_0.ushort_0)
			{
				flag = false;
			}
			if (!emitterSystem_0.Equals(electronicEmissionSystemData_0.emitterSystem_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(electronicEmissionSystemData_0.vector3Float_0))
			{
				flag = false;
			}
			if (list_0.Count != electronicEmissionSystemData_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(electronicEmissionSystemData_0.list_0[i]))
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
		num = smethod_0(num) ^ emitterSystem_0.GetHashCode();
		num = smethod_0(num) ^ vector3Float_0.GetHashCode();
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
