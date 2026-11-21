#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EmitterSystem))]
[XmlRoot]
[XmlInclude(typeof(FundamentalParameterData))]
public class ElectronicEmmisionsPdu : DistributedEmissionsPdu, IEquatable<ElectronicEmmisionsPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte fplEviOyUjq;

	private ushort ushort_1;

	private byte byte_5;

	private byte byte_6;

	private ushort ushort_2;

	private EmitterSystem emitterSystem_0 = new EmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private byte byte_7;

	private byte byte_8;

	private ushort ushort_3;

	private FundamentalParameterData fundamentalParameterData_0 = new FundamentalParameterData();

	[XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
	public EntityID EmittingEntityID
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

	[XmlElement(Type = typeof(EventID), ElementName = "eventID")]
	public EventID EventID
	{
		get
		{
			return eventID_0;
		}
		set
		{
			eventID_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
	public byte StateUpdateIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
	public byte NumberOfSystems
	{
		get
		{
			return fplEviOyUjq;
		}
		set
		{
			fplEviOyUjq = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding")]
	public ushort EmissionsPadding
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

	[XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
	public byte SystemDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
	public byte NumberOfBeams
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
	public ushort EmissionsPadding2
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

	[XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
	public byte BeamDataLength
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "beamIdNumber")]
	public byte BeamIdNumber
	{
		get
		{
			return byte_8;
		}
		set
		{
			byte_8 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
	public ushort BeamParameterIndex
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

	public ElectronicEmmisionsPdu()
	{
		base.PduType = 23;
	}

	public static bool operator !=(ElectronicEmmisionsPdu electronicEmmisionsPdu_0, ElectronicEmmisionsPdu electronicEmmisionsPdu_1)
	{
		return !(electronicEmmisionsPdu_0 == electronicEmmisionsPdu_1);
	}

	public static bool operator ==(ElectronicEmmisionsPdu electronicEmmisionsPdu_0, ElectronicEmmisionsPdu electronicEmmisionsPdu_1)
	{
		if ((object)electronicEmmisionsPdu_0 == electronicEmmisionsPdu_1)
		{
			return true;
		}
		if ((object)electronicEmmisionsPdu_0 != null && (object)electronicEmmisionsPdu_1 != null)
		{
			return electronicEmmisionsPdu_0.Equals(electronicEmmisionsPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + eventID_0.GetMarshalledSize() + 1 + 1 + 2 + 1 + 1 + 2 + emitterSystem_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + 1 + 1 + 2 + fundamentalParameterData_0.GetMarshalledSize();
	}

	public override void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dataOutputStream_0);
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
		if (dataOutputStream_0 == null)
		{
			return;
		}
		try
		{
			entityID_0.Marshal(dataOutputStream_0);
			eventID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(fplEviOyUjq);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			emitterSystem_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
			dataOutputStream_0.WriteUnsignedByte(byte_8);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			fundamentalParameterData_0.Marshal(dataOutputStream_0);
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

	public override void Unmarshal(DataInputStream dataInputStream_0)
	{
		base.Unmarshal(dataInputStream_0);
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			entityID_0.Unmarshal(dataInputStream_0);
			eventID_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			fplEviOyUjq = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			emitterSystem_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			byte_8 = dataInputStream_0.ReadUnsignedByte();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			fundamentalParameterData_0.Unmarshal(dataInputStream_0);
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

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ElectronicEmmisionsPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emittingEntityID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<stateUpdateIndicator type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
			stringBuilder_0.AppendLine("<numberOfSystems type=\"byte\">" + fplEviOyUjq.ToString(CultureInfo.InvariantCulture) + "</numberOfSystems>");
			stringBuilder_0.AppendLine("<emissionsPadding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding>");
			stringBuilder_0.AppendLine("<systemDataLength type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
			stringBuilder_0.AppendLine("<numberOfBeams type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</numberOfBeams>");
			stringBuilder_0.AppendLine("<emissionsPadding2 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
			stringBuilder_0.AppendLine("<emitterSystem>");
			emitterSystem_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emitterSystem>");
			stringBuilder_0.AppendLine("<location>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</location>");
			stringBuilder_0.AppendLine("<beamDataLength type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
			stringBuilder_0.AppendLine("<beamIdNumber type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</beamIdNumber>");
			stringBuilder_0.AppendLine("<beamParameterIndex type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
			stringBuilder_0.AppendLine("<fundamentalParameterData>");
			fundamentalParameterData_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</fundamentalParameterData>");
			stringBuilder_0.AppendLine("</ElectronicEmmisionsPdu>");
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
		return this == obj as ElectronicEmmisionsPdu;
	}

	public bool Equals(ElectronicEmmisionsPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((DistributedEmissionsPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!eventID_0.Equals(other.eventID_0))
			{
				flag = false;
			}
			if (byte_4 != other.byte_4)
			{
				flag = false;
			}
			if (fplEviOyUjq != other.fplEviOyUjq)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (!emitterSystem_0.Equals(other.emitterSystem_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
			{
				flag = false;
			}
			if (byte_8 != other.byte_8)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (!fundamentalParameterData_0.Equals(other.fundamentalParameterData_0))
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ eventID_0.GetHashCode()) ^ byte_4.GetHashCode()) ^ fplEviOyUjq.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_5.GetHashCode()) ^ byte_6.GetHashCode()) ^ ushort_2.GetHashCode()) ^ emitterSystem_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ byte_7.GetHashCode()) ^ byte_8.GetHashCode()) ^ ushort_3.GetHashCode()) ^ fundamentalParameterData_0.GetHashCode();
	}
}
