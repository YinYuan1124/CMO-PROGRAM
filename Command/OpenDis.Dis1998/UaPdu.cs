#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(ApaData))]
[XmlRoot]
[XmlInclude(typeof(AcousticEmitterSystemData))]
[XmlInclude(typeof(ShaftRPMs))]
public class UaPdu : DistributedEmissionsFamilyPdu, IEquatable<UaPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_1;

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private List<ShaftRPMs> list_0 = new List<ShaftRPMs>();

	private List<ApaData> list_1 = new List<ApaData>();

	private List<AcousticEmitterSystemData> list_2 = new List<AcousticEmitterSystemData>();

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

	[XmlElement(Type = typeof(byte), ElementName = "stateChangeIndicator")]
	public byte StateChangeIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "pad")]
	public byte Pad
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

	[XmlElement(Type = typeof(ushort), ElementName = "passiveParameterIndex")]
	public ushort PassiveParameterIndex
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

	[XmlElement(Type = typeof(byte), ElementName = "propulsionPlantConfiguration")]
	public byte PropulsionPlantConfiguration
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfShafts")]
	public byte NumberOfShafts
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfAPAs")]
	public byte NumberOfAPAs
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfUAEmitterSystems")]
	public byte NumberOfUAEmitterSystems
	{
		get
		{
			return byte_9;
		}
		set
		{
			byte_9 = value;
		}
	}

	[XmlElement(ElementName = "shaftRPMsList", Type = typeof(List<ShaftRPMs>))]
	public List<ShaftRPMs> List_0 => list_0;

	[XmlElement(ElementName = "apaDataList", Type = typeof(List<ApaData>))]
	public List<ApaData> ApaData => list_1;

	[XmlElement(ElementName = "emitterSystemsList", Type = typeof(List<AcousticEmitterSystemData>))]
	public List<AcousticEmitterSystemData> EmitterSystems => list_2;

	public UaPdu()
	{
		base.PduType = 29;
	}

	public static bool operator !=(UaPdu uaPdu_0, UaPdu uaPdu_1)
	{
		return !(uaPdu_0 == uaPdu_1);
	}

	public static bool operator ==(UaPdu uaPdu_0, UaPdu uaPdu_1)
	{
		if ((object)uaPdu_0 == uaPdu_1)
		{
			return true;
		}
		if ((object)uaPdu_0 != null && (object)uaPdu_1 != null)
		{
			return uaPdu_0.Equals(uaPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += eventID_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			ShaftRPMs shaftRPMs = list_0[i];
			num += shaftRPMs.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			ApaData apaData = list_1[j];
			num += apaData.GetMarshalledSize();
		}
		for (int k = 0; k < list_2.Count; k++)
		{
			AcousticEmitterSystemData acousticEmitterSystemData = list_2[k];
			num += acousticEmitterSystemData.GetMarshalledSize();
		}
		return num;
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
			dataOutputStream_0.WriteByte(byte_4);
			dataOutputStream_0.WriteByte(byte_5);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedByte((byte)list_1.Count);
			dataOutputStream_0.WriteUnsignedByte((byte)list_2.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dataOutputStream_0);
			}
			for (int k = 0; k < list_2.Count; k++)
			{
				list_2[k].Marshal(dataOutputStream_0);
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
			byte_4 = dataInputStream_0.ReadByte();
			byte_5 = dataInputStream_0.ReadByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			byte_8 = dataInputStream_0.ReadUnsignedByte();
			byte_9 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < NumberOfShafts; i++)
			{
				ShaftRPMs shaftRPMs = new ShaftRPMs();
				shaftRPMs.Unmarshal(dataInputStream_0);
				list_0.Add(shaftRPMs);
			}
			for (int j = 0; j < NumberOfAPAs; j++)
			{
				ApaData apaData = new ApaData();
				apaData.Unmarshal(dataInputStream_0);
				list_1.Add(apaData);
			}
			for (int k = 0; k < NumberOfUAEmitterSystems; k++)
			{
				AcousticEmitterSystemData acousticEmitterSystemData = new AcousticEmitterSystemData();
				acousticEmitterSystemData.Unmarshal(dataInputStream_0);
				list_2.Add(acousticEmitterSystemData);
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

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<UaPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emittingEntityID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<stateChangeIndicator type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</stateChangeIndicator>");
			stringBuilder_0.AppendLine("<pad type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad>");
			stringBuilder_0.AppendLine("<passiveParameterIndex type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</passiveParameterIndex>");
			stringBuilder_0.AppendLine("<propulsionPlantConfiguration type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</propulsionPlantConfiguration>");
			stringBuilder_0.AppendLine("<shaftRPMs type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</shaftRPMs>");
			stringBuilder_0.AppendLine("<apaData type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</apaData>");
			stringBuilder_0.AppendLine("<emitterSystems type=\"byte\">" + list_2.Count.ToString(CultureInfo.InvariantCulture) + "</emitterSystems>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<shaftRPMs" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ShaftRPMs\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</shaftRPMs" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<apaData" + j.ToString(CultureInfo.InvariantCulture) + " type=\"ApaData\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</apaData" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int k = 0; k < list_2.Count; k++)
			{
				stringBuilder_0.AppendLine("<emitterSystems" + k.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticEmitterSystemData\">");
				list_2[k].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</emitterSystems" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</UaPdu>");
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
		return this == obj as UaPdu;
	}

	public bool Equals(UaPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((DistributedEmissionsFamilyPdu)other);
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
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
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
			if (byte_9 != other.byte_9)
			{
				flag = false;
			}
			if (list_0.Count != other.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(other.list_0[i]))
					{
						flag = false;
					}
				}
			}
			if (list_1.Count != other.list_1.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < list_1.Count; j++)
				{
					if (!list_1[j].Equals(other.list_1[j]))
					{
						flag = false;
					}
				}
			}
			if (list_2.Count != other.list_2.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int k = 0; k < list_2.Count; k++)
				{
					if (!list_2[k].Equals(other.list_2[k]))
					{
						flag = false;
					}
				}
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
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ eventID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ byte_9.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_2(num) ^ list_1[j].GetHashCode();
			}
		}
		if (list_2.Count > 0)
		{
			for (int k = 0; k < list_2.Count; k++)
			{
				num = smethod_2(num) ^ list_2[k].GetHashCode();
			}
		}
		return num;
	}
}
