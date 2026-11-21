using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(StandardVariableSpecification))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(ClockTime))]
[XmlRoot]
public class DirectedEnergyFirePdu : WarfareFamilyPdu, IEquatable<DirectedEnergyFirePdu>
{
	private EntityType entityType_0 = new EntityType();

	private ClockTime clockTime_0 = new ClockTime();

	private float float_0;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private int int_0;

	private int int_1;

	private byte byte_5;

	private byte byte_6;

	private uint uint_1;

	private ushort ushort_1;

	private ushort ushort_2;

	private List<StandardVariableSpecification> list_0 = new List<StandardVariableSpecification>();

	[XmlElement(Type = typeof(EntityType), ElementName = "munitionType")]
	public EntityType MunitionType
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

	[XmlElement(Type = typeof(ClockTime), ElementName = "shotStartTime")]
	public ClockTime ShotStartTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "commulativeShotTime")]
	public float CommulativeShotTime
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "ApertureEmitterLocation")]
	public Vector3Float ApertureEmitterLocation
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

	[XmlElement(Type = typeof(float), ElementName = "apertureDiameter")]
	public float ApertureDiameter
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

	[XmlElement(Type = typeof(float), ElementName = "wavelength")]
	public float Wavelength
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "peakIrradiance")]
	public float PeakIrradiance
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
	public float PulseRepetitionFrequency
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "pulseWidth")]
	public int PulseWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "flags")]
	public int Flags
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pulseShape")]
	public byte PulseShape
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(uint), ElementName = "padding2")]
	public uint Padding2
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding3")]
	public ushort Padding3
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDERecords")]
	public ushort NumberOfDERecords
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

	[XmlElement(ElementName = "dERecordsList", Type = typeof(List<StandardVariableSpecification>))]
	public List<StandardVariableSpecification> List_0 => list_0;

	public DirectedEnergyFirePdu()
	{
		base.PduType = 68;
	}

	public static bool operator !=(DirectedEnergyFirePdu directedEnergyFirePdu_0, DirectedEnergyFirePdu directedEnergyFirePdu_1)
	{
		return !(directedEnergyFirePdu_0 == directedEnergyFirePdu_1);
	}

	public static bool operator ==(DirectedEnergyFirePdu directedEnergyFirePdu_0, DirectedEnergyFirePdu directedEnergyFirePdu_1)
	{
		if ((object)directedEnergyFirePdu_0 == directedEnergyFirePdu_1)
		{
			return true;
		}
		if ((object)directedEnergyFirePdu_0 != null && (object)directedEnergyFirePdu_1 != null)
		{
			return directedEnergyFirePdu_0.Equals(directedEnergyFirePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityType_0.GetMarshalledSize();
		num += clockTime_0.GetMarshalledSize();
		num += 4;
		num += vector3Float_0.GetMarshalledSize();
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num++;
		num++;
		num += 4;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			StandardVariableSpecification standardVariableSpecification = list_0[i];
			num += standardVariableSpecification.GetMarshalledSize();
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
			entityType_0.Marshal(dataOutputStream_0);
			clockTime_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteFloat(float_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteFloat(float_2);
			dataOutputStream_0.WriteFloat(float_3);
			dataOutputStream_0.WriteFloat(float_4);
			dataOutputStream_0.WriteInt(int_0);
			dataOutputStream_0.WriteInt(int_1);
			dataOutputStream_0.WriteByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
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
			entityType_0.Unmarshal(dataInputStream_0);
			clockTime_0.Unmarshal(dataInputStream_0);
			float_0 = dataInputStream_0.ReadFloat();
			vector3Float_0.Unmarshal(dataInputStream_0);
			float_1 = dataInputStream_0.ReadFloat();
			float_2 = dataInputStream_0.ReadFloat();
			float_3 = dataInputStream_0.ReadFloat();
			float_4 = dataInputStream_0.ReadFloat();
			int_0 = dataInputStream_0.ReadInt();
			int_1 = dataInputStream_0.ReadInt();
			byte_5 = dataInputStream_0.ReadByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfDERecords; i++)
			{
				StandardVariableSpecification standardVariableSpecification = new StandardVariableSpecification();
				standardVariableSpecification.Unmarshal(dataInputStream_0);
				list_0.Add(standardVariableSpecification);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DirectedEnergyFirePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<munitionType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</munitionType>");
			stringBuilder_0.AppendLine("<shotStartTime>");
			clockTime_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</shotStartTime>");
			stringBuilder_0.AppendLine("<commulativeShotTime type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</commulativeShotTime>");
			stringBuilder_0.AppendLine("<ApertureEmitterLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</ApertureEmitterLocation>");
			stringBuilder_0.AppendLine("<apertureDiameter type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</apertureDiameter>");
			stringBuilder_0.AppendLine("<wavelength type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</wavelength>");
			stringBuilder_0.AppendLine("<peakIrradiance type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</peakIrradiance>");
			stringBuilder_0.AppendLine("<pulseRepetitionFrequency type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
			stringBuilder_0.AppendLine("<pulseWidth type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			stringBuilder_0.AppendLine("<flags type=\"int\">" + int_1.ToString(CultureInfo.InvariantCulture) + "</flags>");
			stringBuilder_0.AppendLine("<pulseShape type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pulseShape>");
			stringBuilder_0.AppendLine("<padding1 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<padding3 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			stringBuilder_0.AppendLine("<dERecords type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</dERecords>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<dERecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"StandardVariableSpecification\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</dERecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DirectedEnergyFirePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyFirePdu;
	}

	public bool Equals(DirectedEnergyFirePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((WarfareFamilyPdu)other);
			if (!entityType_0.Equals(other.entityType_0))
			{
				flag = false;
			}
			if (!clockTime_0.Equals(other.clockTime_0))
			{
				flag = false;
			}
			if (float_0 != other.float_0)
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (float_1 != other.float_1)
			{
				flag = false;
			}
			if (float_2 != other.float_2)
			{
				flag = false;
			}
			if (float_3 != other.float_3)
			{
				flag = false;
			}
			if (float_4 != other.float_4)
			{
				flag = false;
			}
			if (int_0 != other.int_0)
			{
				flag = false;
			}
			if (int_1 != other.int_1)
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
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
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

	private static int smethod_3(int int_2)
	{
		int_2 <<= 5 + int_2;
		return int_2;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ clockTime_0.GetHashCode();
		num = smethod_3(num) ^ float_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		num = smethod_3(num) ^ float_1.GetHashCode();
		num = smethod_3(num) ^ float_2.GetHashCode();
		num = smethod_3(num) ^ float_3.GetHashCode();
		num = smethod_3(num) ^ float_4.GetHashCode();
		num = smethod_3(num) ^ int_0.GetHashCode();
		num = smethod_3(num) ^ int_1.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
