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
[XmlInclude(typeof(IntercomCommunicationsParameters))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class IntercomControlPdu : RadioCommunicationsFamilyPdu, IEquatable<IntercomControlPdu>
{
	private byte byte_4;

	private byte byte_5;

	private EntityID entityID_1 = new EntityID();

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private byte byte_10;

	private EntityID entityID_2 = new EntityID();

	private ushort ushort_2;

	private uint uint_1;

	private List<IntercomCommunicationsParameters> list_0 = new List<IntercomCommunicationsParameters>();

	[XmlElement(Type = typeof(byte), ElementName = "controlType")]
	public byte ControlType
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

	[XmlElement(Type = typeof(byte), ElementName = "communicationsChannelType")]
	public byte CommunicationsChannelType
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

	[XmlElement(Type = typeof(EntityID), ElementName = "sourceEntityID")]
	public EntityID SourceEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "sourceCommunicationsDeviceID")]
	public byte SourceCommunicationsDeviceID
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

	[XmlElement(Type = typeof(byte), ElementName = "sourceLineID")]
	public byte SourceLineID
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

	[XmlElement(Type = typeof(byte), ElementName = "transmitPriority")]
	public byte TransmitPriority
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

	[XmlElement(Type = typeof(byte), ElementName = "transmitLineState")]
	public byte TransmitLineState
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

	[XmlElement(Type = typeof(byte), ElementName = "command")]
	public byte Command
	{
		get
		{
			return byte_10;
		}
		set
		{
			byte_10 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "masterEntityID")]
	public EntityID MasterEntityID
	{
		get
		{
			return entityID_2;
		}
		set
		{
			entityID_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "masterCommunicationsDeviceID")]
	public ushort MasterCommunicationsDeviceID
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

	[XmlElement(Type = typeof(uint), ElementName = "intercomParametersLength")]
	public uint IntercomParametersLength
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(ElementName = "intercomParametersList", Type = typeof(List<IntercomCommunicationsParameters>))]
	public List<IntercomCommunicationsParameters> IntercomParameters => list_0;

	public IntercomControlPdu()
	{
		base.PduType = 32;
	}

	public static bool operator !=(IntercomControlPdu intercomControlPdu_0, IntercomControlPdu intercomControlPdu_1)
	{
		return !(intercomControlPdu_0 == intercomControlPdu_1);
	}

	public static bool operator ==(IntercomControlPdu intercomControlPdu_0, IntercomControlPdu intercomControlPdu_1)
	{
		if ((object)intercomControlPdu_0 == intercomControlPdu_1)
		{
			return true;
		}
		if ((object)intercomControlPdu_0 != null && (object)intercomControlPdu_1 != null)
		{
			return intercomControlPdu_0.Equals(intercomControlPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num++;
		num++;
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		num++;
		num++;
		num++;
		num += entityID_2.GetMarshalledSize();
		num += 2;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			IntercomCommunicationsParameters intercomCommunicationsParameters = list_0[i];
			num += intercomCommunicationsParameters.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			entityID_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
			dataOutputStream_0.WriteUnsignedByte(byte_8);
			dataOutputStream_0.WriteUnsignedByte(byte_9);
			dataOutputStream_0.WriteUnsignedByte(byte_10);
			entityID_2.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
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
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			entityID_1.Unmarshal(dataInputStream_0);
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			byte_8 = dataInputStream_0.ReadUnsignedByte();
			byte_9 = dataInputStream_0.ReadUnsignedByte();
			byte_10 = dataInputStream_0.ReadUnsignedByte();
			entityID_2.Unmarshal(dataInputStream_0);
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < IntercomParametersLength; i++)
			{
				IntercomCommunicationsParameters intercomCommunicationsParameters = new IntercomCommunicationsParameters();
				intercomCommunicationsParameters.Unmarshal(dataInputStream_0);
				list_0.Add(intercomCommunicationsParameters);
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
		stringBuilder_0.AppendLine("<IntercomControlPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<controlType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</controlType>");
			stringBuilder_0.AppendLine("<communicationsChannelType type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</communicationsChannelType>");
			stringBuilder_0.AppendLine("<sourceEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</sourceEntityID>");
			stringBuilder_0.AppendLine("<sourceCommunicationsDeviceID type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</sourceCommunicationsDeviceID>");
			stringBuilder_0.AppendLine("<sourceLineID type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</sourceLineID>");
			stringBuilder_0.AppendLine("<transmitPriority type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</transmitPriority>");
			stringBuilder_0.AppendLine("<transmitLineState type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</transmitLineState>");
			stringBuilder_0.AppendLine("<command type=\"byte\">" + byte_10.ToString(CultureInfo.InvariantCulture) + "</command>");
			stringBuilder_0.AppendLine("<masterEntityID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</masterEntityID>");
			stringBuilder_0.AppendLine("<masterCommunicationsDeviceID type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</masterCommunicationsDeviceID>");
			stringBuilder_0.AppendLine("<intercomParameters type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</intercomParameters>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<intercomParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"IntercomCommunicationsParameters\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</intercomParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</IntercomControlPdu>");
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
		return this == obj as IntercomControlPdu;
	}

	public bool Equals(IntercomControlPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((RadioCommunicationsFamilyPdu)other);
			if (byte_4 != other.byte_4)
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
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
			if (byte_10 != other.byte_10)
			{
				flag = false;
			}
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
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
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ byte_9.GetHashCode();
		num = smethod_2(num) ^ byte_10.GetHashCode();
		num = smethod_2(num) ^ entityID_2.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
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
