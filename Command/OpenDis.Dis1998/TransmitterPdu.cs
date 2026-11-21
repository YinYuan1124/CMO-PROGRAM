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
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(RadioEntityType))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(ModulationType))]
[XmlInclude(typeof(Vector3Float))]
public class TransmitterPdu : RadioCommunicationsFamilyPdu, IEquatable<TransmitterPdu>
{
	private RadioEntityType radioEntityType_0 = new RadioEntityType();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_2;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private ushort ushort_3;

	private ushort ushort_4;

	private ulong ulong_0;

	private float float_0;

	private float float_1;

	private ModulationType modulationType_0 = new ModulationType();

	private ushort ushort_5;

	private ushort ushort_6;

	private byte byte_6;

	private ushort ushort_7;

	private byte byte_7;

	private List<Vector3Float> list_0 = new List<Vector3Float>();

	private List<Vector3Float> list_1 = new List<Vector3Float>();

	[XmlElement(Type = typeof(RadioEntityType), ElementName = "radioEntityType")]
	public RadioEntityType RadioEntityType
	{
		get
		{
			return radioEntityType_0;
		}
		set
		{
			radioEntityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "transmitState")]
	public byte TransmitState
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

	[XmlElement(Type = typeof(byte), ElementName = "inputSource")]
	public byte InputSource
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
	public Vector3Double AntennaLocation
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "relativeAntennaLocation")]
	public Vector3Float RelativeAntennaLocation
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

	[XmlElement(Type = typeof(ushort), ElementName = "antennaPatternType")]
	public ushort AntennaPatternType
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

	[XmlElement(Type = typeof(ushort), ElementName = "antennaPatternCount")]
	public ushort AntennaPatternCount
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ulong), ElementName = "frequency")]
	public ulong Frequency
	{
		get
		{
			return ulong_0;
		}
		set
		{
			ulong_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "transmitFrequencyBandwidth")]
	public float TransmitFrequencyBandwidth
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

	[XmlElement(Type = typeof(float), ElementName = "power")]
	public float Power
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

	[XmlElement(Type = typeof(ModulationType), ElementName = "modulationType")]
	public ModulationType ModulationType
	{
		get
		{
			return modulationType_0;
		}
		set
		{
			modulationType_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "cryptoSystem")]
	public ushort CryptoSystem
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "cryptoKeyId")]
	public ushort CryptoKeyId
	{
		get
		{
			return ushort_6;
		}
		set
		{
			ushort_6 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "modulationParameterCount")]
	public byte ModulationParameterCount
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
	{
		get
		{
			return ushort_7;
		}
		set
		{
			ushort_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding3")]
	public byte Padding3
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

	[XmlElement(ElementName = "modulationParametersListList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> ModulationParametersList => list_0;

	[XmlElement(ElementName = "antennaPatternListList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> AntennaPatternList => list_1;

	public TransmitterPdu()
	{
		base.PduType = 25;
	}

	public static bool operator !=(TransmitterPdu transmitterPdu_0, TransmitterPdu transmitterPdu_1)
	{
		return !(transmitterPdu_0 == transmitterPdu_1);
	}

	public static bool operator ==(TransmitterPdu transmitterPdu_0, TransmitterPdu transmitterPdu_1)
	{
		if ((object)transmitterPdu_0 == transmitterPdu_1)
		{
			return true;
		}
		if ((object)transmitterPdu_0 != null && (object)transmitterPdu_1 != null)
		{
			return transmitterPdu_0.Equals(transmitterPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += radioEntityType_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		num += vector3Double_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 8;
		num += 4;
		num += 4;
		num += modulationType_0.GetMarshalledSize();
		num += 2;
		num += 2;
		num++;
		num += 2;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Float vector3Float = list_0[i];
			num += vector3Float.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			Vector3Float vector3Float2 = list_1[j];
			num += vector3Float2.GetMarshalledSize();
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
			radioEntityType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			vector3Double_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_1.Count);
			dataOutputStream_0.WriteUnsignedLong(ulong_0);
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			modulationType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_5);
			dataOutputStream_0.WriteUnsignedShort(ushort_6);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort(ushort_7);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dataOutputStream_0);
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
			radioEntityType_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			vector3Double_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			ulong_0 = dataInputStream_0.ReadUnsignedLong();
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			modulationType_0.Unmarshal(dataInputStream_0);
			ushort_5 = dataInputStream_0.ReadUnsignedShort();
			ushort_6 = dataInputStream_0.ReadUnsignedShort();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			ushort_7 = dataInputStream_0.ReadUnsignedShort();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < ModulationParameterCount; i++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dataInputStream_0);
				list_0.Add(vector3Float);
			}
			for (int j = 0; j < AntennaPatternCount; j++)
			{
				Vector3Float vector3Float2 = new Vector3Float();
				vector3Float2.Unmarshal(dataInputStream_0);
				list_1.Add(vector3Float2);
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
		stringBuilder_0.AppendLine("<TransmitterPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<radioEntityType>");
			radioEntityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</radioEntityType>");
			stringBuilder_0.AppendLine("<transmitState type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</transmitState>");
			stringBuilder_0.AppendLine("<inputSource type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</inputSource>");
			stringBuilder_0.AppendLine("<padding1 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<antennaLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</antennaLocation>");
			stringBuilder_0.AppendLine("<relativeAntennaLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</relativeAntennaLocation>");
			stringBuilder_0.AppendLine("<antennaPatternType type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</antennaPatternType>");
			stringBuilder_0.AppendLine("<antennaPatternList type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</antennaPatternList>");
			stringBuilder_0.AppendLine("<frequency type=\"ulong\">" + ulong_0.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			stringBuilder_0.AppendLine("<transmitFrequencyBandwidth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</transmitFrequencyBandwidth>");
			stringBuilder_0.AppendLine("<power type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</power>");
			stringBuilder_0.AppendLine("<modulationType>");
			modulationType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</modulationType>");
			stringBuilder_0.AppendLine("<cryptoSystem type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</cryptoSystem>");
			stringBuilder_0.AppendLine("<cryptoKeyId type=\"ushort\">" + ushort_6.ToString(CultureInfo.InvariantCulture) + "</cryptoKeyId>");
			stringBuilder_0.AppendLine("<modulationParametersList type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</modulationParametersList>");
			stringBuilder_0.AppendLine("<padding2 type=\"ushort\">" + ushort_7.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<padding3 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<modulationParametersList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</modulationParametersList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<antennaPatternList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</antennaPatternList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</TransmitterPdu>");
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
		return this == obj as TransmitterPdu;
	}

	public bool Equals(TransmitterPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((RadioCommunicationsFamilyPdu)other);
			if (!radioEntityType_0.Equals(other.radioEntityType_0))
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
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (ushort_4 != other.ushort_4)
			{
				flag = false;
			}
			if (ulong_0 != other.ulong_0)
			{
				flag = false;
			}
			if (float_0 != other.float_0)
			{
				flag = false;
			}
			if (float_1 != other.float_1)
			{
				flag = false;
			}
			if (!modulationType_0.Equals(other.modulationType_0))
			{
				flag = false;
			}
			if (ushort_5 != other.ushort_5)
			{
				flag = false;
			}
			if (ushort_6 != other.ushort_6)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (ushort_7 != other.ushort_7)
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
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
		num = smethod_2(num) ^ radioEntityType_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ ulong_0.GetHashCode();
		num = smethod_2(num) ^ float_0.GetHashCode();
		num = smethod_2(num) ^ float_1.GetHashCode();
		num = smethod_2(num) ^ modulationType_0.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		num = smethod_2(num) ^ ushort_6.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ ushort_7.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
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
		return num;
	}
}
