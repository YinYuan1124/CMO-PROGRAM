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
[XmlInclude(typeof(Environment))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class EnvironmentalProcessPdu : SyntheticEnvironmentFamilyPdu, IEquatable<EnvironmentalProcessPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityType entityType_0 = new EntityType();

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private ushort ushort_1;

	private List<Environment> list_0 = new List<Environment>();

	[XmlElement(Type = typeof(EntityID), ElementName = "environementalProcessID")]
	public EntityID EnvironementalProcessID
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

	[XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
	public EntityType EnvironmentType
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

	[XmlElement(Type = typeof(byte), ElementName = "modelType")]
	public byte ModelType
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

	[XmlElement(Type = typeof(byte), ElementName = "environmentStatus")]
	public byte EnvironmentStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfEnvironmentRecords")]
	public byte NumberOfEnvironmentRecords
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

	[XmlElement(Type = typeof(ushort), ElementName = "sequenceNumber")]
	public ushort SequenceNumber
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

	[XmlElement(ElementName = "environmentRecordsList", Type = typeof(List<Environment>))]
	public List<Environment> EnvironmentRecords => list_0;

	public EnvironmentalProcessPdu()
	{
		base.PduType = 41;
	}

	public static bool operator !=(EnvironmentalProcessPdu environmentalProcessPdu_0, EnvironmentalProcessPdu environmentalProcessPdu_1)
	{
		return !(environmentalProcessPdu_0 == environmentalProcessPdu_1);
	}

	public static bool operator ==(EnvironmentalProcessPdu environmentalProcessPdu_0, EnvironmentalProcessPdu environmentalProcessPdu_1)
	{
		if ((object)environmentalProcessPdu_0 == environmentalProcessPdu_1)
		{
			return true;
		}
		if ((object)environmentalProcessPdu_0 != null && (object)environmentalProcessPdu_1 != null)
		{
			return environmentalProcessPdu_0.Equals(environmentalProcessPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityType_0.GetMarshalledSize();
		num++;
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			Environment environment = list_0[i];
			num += environment.GetMarshalledSize();
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
			entityType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
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
			entityType_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfEnvironmentRecords; i++)
			{
				Environment environment = new Environment();
				environment.Unmarshal(dataInputStream_0);
				list_0.Add(environment);
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
		stringBuilder_0.AppendLine("<EnvironmentalProcessPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<environementalProcessID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</environementalProcessID>");
			stringBuilder_0.AppendLine("<environmentType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</environmentType>");
			stringBuilder_0.AppendLine("<modelType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</modelType>");
			stringBuilder_0.AppendLine("<environmentStatus type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</environmentStatus>");
			stringBuilder_0.AppendLine("<environmentRecords type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</environmentRecords>");
			stringBuilder_0.AppendLine("<sequenceNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</sequenceNumber>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<environmentRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Environment\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</environmentRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</EnvironmentalProcessPdu>");
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
		return this == obj as EnvironmentalProcessPdu;
	}

	public bool Equals(EnvironmentalProcessPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityType_0.Equals(other.entityType_0))
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
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
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
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
