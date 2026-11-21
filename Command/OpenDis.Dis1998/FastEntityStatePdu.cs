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
[XmlInclude(typeof(ArticulationParameter))]
[XmlRoot]
public class FastEntityStatePdu : EntityInformationFamilyPdu, IEquatable<FastEntityStatePdu>
{
	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte SlvEkGuJhbY;

	private ushort ushort_4;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private byte byte_10;

	private byte byte_11;

	private byte byte_12;

	private ushort ushort_5;

	private byte byte_13;

	private byte byte_14;

	private byte byte_15;

	private byte byte_16;

	private float float_0;

	private float float_1;

	private float float_2;

	private double double_0;

	private double double_1;

	private double double_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private int int_0;

	private byte byte_17;

	private byte[] byte_18 = new byte[15];

	private float float_6;

	private float float_7;

	private float qnxEkJpGoDg;

	private float float_8;

	private float float_9;

	private float float_10;

	private byte[] byte_19 = new byte[12];

	private int int_1;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

	[XmlElement(Type = typeof(ushort), ElementName = "site")]
	public ushort Site
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

	[XmlElement(Type = typeof(ushort), ElementName = "application")]
	public ushort Application
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

	[XmlElement(Type = typeof(ushort), ElementName = "entity")]
	public ushort Entity
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

	[XmlElement(Type = typeof(byte), ElementName = "forceId")]
	public byte ForceId
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
	public byte NumberOfArticulationParameters
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

	[XmlElement(Type = typeof(byte), ElementName = "entityKind")]
	public byte EntityKind
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

	[XmlElement(Type = typeof(byte), ElementName = "domain")]
	public byte Domain
	{
		get
		{
			return SlvEkGuJhbY;
		}
		set
		{
			SlvEkGuJhbY = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "country")]
	public ushort Country
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

	[XmlElement(Type = typeof(byte), ElementName = "category")]
	public byte Category
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

	[XmlElement(Type = typeof(byte), ElementName = "subcategory")]
	public byte Subcategory
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

	[XmlElement(Type = typeof(byte), ElementName = "specific")]
	public byte Specific
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

	[XmlElement(Type = typeof(byte), ElementName = "extra")]
	public byte Extra
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

	[XmlElement(Type = typeof(byte), ElementName = "altEntityKind")]
	public byte AltEntityKind
	{
		get
		{
			return byte_11;
		}
		set
		{
			byte_11 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altDomain")]
	public byte AltDomain
	{
		get
		{
			return byte_12;
		}
		set
		{
			byte_12 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "altCountry")]
	public ushort AltCountry
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

	[XmlElement(Type = typeof(byte), ElementName = "altCategory")]
	public byte AltCategory
	{
		get
		{
			return byte_13;
		}
		set
		{
			byte_13 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altSubcategory")]
	public byte AltSubcategory
	{
		get
		{
			return byte_14;
		}
		set
		{
			byte_14 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altSpecific")]
	public byte AltSpecific
	{
		get
		{
			return byte_15;
		}
		set
		{
			byte_15 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altExtra")]
	public byte AltExtra
	{
		get
		{
			return byte_16;
		}
		set
		{
			byte_16 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "xVelocity")]
	public float Single_0
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

	[XmlElement(Type = typeof(float), ElementName = "yVelocity")]
	public float Single_1
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

	[XmlElement(Type = typeof(float), ElementName = "zVelocity")]
	public float Single_2
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

	[XmlElement(Type = typeof(double), ElementName = "xLocation")]
	public double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "yLocation")]
	public double Double_1
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "zLocation")]
	public double Double_2
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "psi")]
	public float Psi
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

	[XmlElement(Type = typeof(float), ElementName = "theta")]
	public float Theta
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

	[XmlElement(Type = typeof(float), ElementName = "phi")]
	public float Phi
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
	public int EntityAppearance
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

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
	{
		get
		{
			return byte_17;
		}
		set
		{
			byte_17 = value;
		}
	}

	[XmlArray(ElementName = "otherParameters")]
	public byte[] OtherParameters
	{
		get
		{
			return byte_18;
		}
		set
		{
			byte_18 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "xAcceleration")]
	public float XAcceleration
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "yAcceleration")]
	public float YAcceleration
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "zAcceleration")]
	public float ZAcceleration
	{
		get
		{
			return qnxEkJpGoDg;
		}
		set
		{
			qnxEkJpGoDg = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "xAngularVelocity")]
	public float XAngularVelocity
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "yAngularVelocity")]
	public float YAngularVelocity
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "zAngularVelocity")]
	public float ZAngularVelocity
	{
		get
		{
			return float_10;
		}
		set
		{
			float_10 = value;
		}
	}

	[XmlArray(ElementName = "marking")]
	public byte[] Marking
	{
		get
		{
			return byte_19;
		}
		set
		{
			byte_19 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "capabilities")]
	public int Capabilities
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

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

	public FastEntityStatePdu()
	{
		base.PduType = 1;
	}

	public static bool operator !=(FastEntityStatePdu fastEntityStatePdu_0, FastEntityStatePdu fastEntityStatePdu_1)
	{
		return !(fastEntityStatePdu_0 == fastEntityStatePdu_1);
	}

	public static bool operator ==(FastEntityStatePdu fastEntityStatePdu_0, FastEntityStatePdu fastEntityStatePdu_1)
	{
		if ((object)fastEntityStatePdu_0 == fastEntityStatePdu_1)
		{
			return true;
		}
		if ((object)fastEntityStatePdu_0 != null && (object)fastEntityStatePdu_1 != null)
		{
			return fastEntityStatePdu_0.Equals(fastEntityStatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num += 4;
		num += 4;
		num += 4;
		num += 8;
		num += 8;
		num += 8;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num++;
		num += 15;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 12;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			ArticulationParameter articulationParameter = list_0[i];
			num += articulationParameter.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedByte(SlvEkGuJhbY);
			dataOutputStream_0.WriteUnsignedShort(ushort_4);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
			dataOutputStream_0.WriteUnsignedByte(byte_8);
			dataOutputStream_0.WriteUnsignedByte(byte_9);
			dataOutputStream_0.WriteUnsignedByte(byte_10);
			dataOutputStream_0.WriteUnsignedByte(byte_11);
			dataOutputStream_0.WriteUnsignedByte(byte_12);
			dataOutputStream_0.WriteUnsignedShort(ushort_5);
			dataOutputStream_0.WriteUnsignedByte(byte_13);
			dataOutputStream_0.WriteUnsignedByte(byte_14);
			dataOutputStream_0.WriteUnsignedByte(byte_15);
			dataOutputStream_0.WriteUnsignedByte(byte_16);
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteFloat(float_2);
			dataOutputStream_0.WriteDouble(double_0);
			dataOutputStream_0.WriteDouble(double_1);
			dataOutputStream_0.WriteDouble(double_2);
			dataOutputStream_0.WriteFloat(float_3);
			dataOutputStream_0.WriteFloat(float_4);
			dataOutputStream_0.WriteFloat(float_5);
			dataOutputStream_0.WriteInt(int_0);
			dataOutputStream_0.WriteUnsignedByte(byte_17);
			for (int i = 0; i < byte_18.Length; i++)
			{
				dataOutputStream_0.WriteByte(byte_18[i]);
			}
			dataOutputStream_0.WriteFloat(float_6);
			dataOutputStream_0.WriteFloat(float_7);
			dataOutputStream_0.WriteFloat(qnxEkJpGoDg);
			dataOutputStream_0.WriteFloat(float_8);
			dataOutputStream_0.WriteFloat(float_9);
			dataOutputStream_0.WriteFloat(float_10);
			for (int j = 0; j < byte_19.Length; j++)
			{
				dataOutputStream_0.WriteByte(byte_19[j]);
			}
			dataOutputStream_0.WriteInt(int_1);
			for (int k = 0; k < list_0.Count; k++)
			{
				list_0[k].Marshal(dataOutputStream_0);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			SlvEkGuJhbY = dataInputStream_0.ReadUnsignedByte();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			byte_8 = dataInputStream_0.ReadUnsignedByte();
			byte_9 = dataInputStream_0.ReadUnsignedByte();
			byte_10 = dataInputStream_0.ReadUnsignedByte();
			byte_11 = dataInputStream_0.ReadUnsignedByte();
			byte_12 = dataInputStream_0.ReadUnsignedByte();
			ushort_5 = dataInputStream_0.ReadUnsignedShort();
			byte_13 = dataInputStream_0.ReadUnsignedByte();
			byte_14 = dataInputStream_0.ReadUnsignedByte();
			byte_15 = dataInputStream_0.ReadUnsignedByte();
			byte_16 = dataInputStream_0.ReadUnsignedByte();
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			float_2 = dataInputStream_0.ReadFloat();
			double_0 = dataInputStream_0.ReadDouble();
			double_1 = dataInputStream_0.ReadDouble();
			double_2 = dataInputStream_0.ReadDouble();
			float_3 = dataInputStream_0.ReadFloat();
			float_4 = dataInputStream_0.ReadFloat();
			float_5 = dataInputStream_0.ReadFloat();
			int_0 = dataInputStream_0.ReadInt();
			byte_17 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < byte_18.Length; i++)
			{
				byte_18[i] = dataInputStream_0.ReadByte();
			}
			float_6 = dataInputStream_0.ReadFloat();
			float_7 = dataInputStream_0.ReadFloat();
			qnxEkJpGoDg = dataInputStream_0.ReadFloat();
			float_8 = dataInputStream_0.ReadFloat();
			float_9 = dataInputStream_0.ReadFloat();
			float_10 = dataInputStream_0.ReadFloat();
			for (int j = 0; j < byte_19.Length; j++)
			{
				byte_19[j] = dataInputStream_0.ReadByte();
			}
			int_1 = dataInputStream_0.ReadInt();
			for (int k = 0; k < NumberOfArticulationParameters; k++)
			{
				ArticulationParameter articulationParameter = new ArticulationParameter();
				articulationParameter.Unmarshal(dataInputStream_0);
				list_0.Add(articulationParameter);
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
		stringBuilder_0.AppendLine("<FastEntityStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<site type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</site>");
			stringBuilder_0.AppendLine("<application type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</application>");
			stringBuilder_0.AppendLine("<entity type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</entity>");
			stringBuilder_0.AppendLine("<forceId type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceId>");
			stringBuilder_0.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
			stringBuilder_0.AppendLine("<entityKind type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
			stringBuilder_0.AppendLine("<domain type=\"byte\">" + SlvEkGuJhbY.ToString(CultureInfo.InvariantCulture) + "</domain>");
			stringBuilder_0.AppendLine("<country type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</country>");
			stringBuilder_0.AppendLine("<category type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</category>");
			stringBuilder_0.AppendLine("<subcategory type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			stringBuilder_0.AppendLine("<specific type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</specific>");
			stringBuilder_0.AppendLine("<extra type=\"byte\">" + byte_10.ToString(CultureInfo.InvariantCulture) + "</extra>");
			stringBuilder_0.AppendLine("<altEntityKind type=\"byte\">" + byte_11.ToString(CultureInfo.InvariantCulture) + "</altEntityKind>");
			stringBuilder_0.AppendLine("<altDomain type=\"byte\">" + byte_12.ToString(CultureInfo.InvariantCulture) + "</altDomain>");
			stringBuilder_0.AppendLine("<altCountry type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</altCountry>");
			stringBuilder_0.AppendLine("<altCategory type=\"byte\">" + byte_13.ToString(CultureInfo.InvariantCulture) + "</altCategory>");
			stringBuilder_0.AppendLine("<altSubcategory type=\"byte\">" + byte_14.ToString(CultureInfo.InvariantCulture) + "</altSubcategory>");
			stringBuilder_0.AppendLine("<altSpecific type=\"byte\">" + byte_15.ToString(CultureInfo.InvariantCulture) + "</altSpecific>");
			stringBuilder_0.AppendLine("<altExtra type=\"byte\">" + byte_16.ToString(CultureInfo.InvariantCulture) + "</altExtra>");
			stringBuilder_0.AppendLine("<xVelocity type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</xVelocity>");
			stringBuilder_0.AppendLine("<yVelocity type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</yVelocity>");
			stringBuilder_0.AppendLine("<zVelocity type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</zVelocity>");
			stringBuilder_0.AppendLine("<xLocation type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</xLocation>");
			stringBuilder_0.AppendLine("<yLocation type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</yLocation>");
			stringBuilder_0.AppendLine("<zLocation type=\"double\">" + double_2.ToString(CultureInfo.InvariantCulture) + "</zLocation>");
			stringBuilder_0.AppendLine("<psi type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</psi>");
			stringBuilder_0.AppendLine("<theta type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</theta>");
			stringBuilder_0.AppendLine("<phi type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</phi>");
			stringBuilder_0.AppendLine("<entityAppearance type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			stringBuilder_0.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_17.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			for (int i = 0; i < byte_18.Length; i++)
			{
				stringBuilder_0.AppendLine("<otherParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_18[i] + "</otherParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<xAcceleration type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</xAcceleration>");
			stringBuilder_0.AppendLine("<yAcceleration type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</yAcceleration>");
			stringBuilder_0.AppendLine("<zAcceleration type=\"float\">" + qnxEkJpGoDg.ToString(CultureInfo.InvariantCulture) + "</zAcceleration>");
			stringBuilder_0.AppendLine("<xAngularVelocity type=\"float\">" + float_8.ToString(CultureInfo.InvariantCulture) + "</xAngularVelocity>");
			stringBuilder_0.AppendLine("<yAngularVelocity type=\"float\">" + float_9.ToString(CultureInfo.InvariantCulture) + "</yAngularVelocity>");
			stringBuilder_0.AppendLine("<zAngularVelocity type=\"float\">" + float_10.ToString(CultureInfo.InvariantCulture) + "</zAngularVelocity>");
			for (int j = 0; j < byte_19.Length; j++)
			{
				stringBuilder_0.AppendLine("<marking" + j.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_19[j] + "</marking" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<capabilities type=\"int\">" + int_1.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
			for (int k = 0; k < list_0.Count; k++)
			{
				stringBuilder_0.AppendLine("<articulationParameters" + k.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[k].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</articulationParameters" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</FastEntityStatePdu>");
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
		return this == obj as FastEntityStatePdu;
	}

	public bool Equals(FastEntityStatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityInformationFamilyPdu)other);
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
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
			if (SlvEkGuJhbY != other.SlvEkGuJhbY)
			{
				flag = false;
			}
			if (ushort_4 != other.ushort_4)
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
			if (byte_11 != other.byte_11)
			{
				flag = false;
			}
			if (byte_12 != other.byte_12)
			{
				flag = false;
			}
			if (ushort_5 != other.ushort_5)
			{
				flag = false;
			}
			if (byte_13 != other.byte_13)
			{
				flag = false;
			}
			if (byte_14 != other.byte_14)
			{
				flag = false;
			}
			if (byte_15 != other.byte_15)
			{
				flag = false;
			}
			if (byte_16 != other.byte_16)
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
			if (float_2 != other.float_2)
			{
				flag = false;
			}
			if (double_0 != other.double_0)
			{
				flag = false;
			}
			if (double_1 != other.double_1)
			{
				flag = false;
			}
			if (double_2 != other.double_2)
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
			if (float_5 != other.float_5)
			{
				flag = false;
			}
			if (int_0 != other.int_0)
			{
				flag = false;
			}
			if (byte_17 != other.byte_17)
			{
				flag = false;
			}
			if (other.byte_18.Length != 15)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 15; i++)
				{
					if (byte_18[i] != other.byte_18[i])
					{
						flag = false;
					}
				}
			}
			if (float_6 != other.float_6)
			{
				flag = false;
			}
			if (float_7 != other.float_7)
			{
				flag = false;
			}
			if (qnxEkJpGoDg != other.qnxEkJpGoDg)
			{
				flag = false;
			}
			if (float_8 != other.float_8)
			{
				flag = false;
			}
			if (float_9 != other.float_9)
			{
				flag = false;
			}
			if (float_10 != other.float_10)
			{
				flag = false;
			}
			if (other.byte_19.Length != 12)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < 12; j++)
				{
					if (byte_19[j] != other.byte_19[j])
					{
						flag = false;
					}
				}
			}
			if (int_1 != other.int_1)
			{
				flag = false;
			}
			if (list_0.Count != other.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int k = 0; k < list_0.Count; k++)
				{
					if (!list_0[k].Equals(other.list_0[k]))
					{
						flag = false;
					}
				}
			}
			return flag;
		}
		return false;
	}

	private static int smethod_2(int int_2)
	{
		int_2 <<= 5 + int_2;
		return int_2;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ SlvEkGuJhbY.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ byte_9.GetHashCode();
		num = smethod_2(num) ^ byte_10.GetHashCode();
		num = smethod_2(num) ^ byte_11.GetHashCode();
		num = smethod_2(num) ^ byte_12.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		num = smethod_2(num) ^ byte_13.GetHashCode();
		num = smethod_2(num) ^ byte_14.GetHashCode();
		num = smethod_2(num) ^ byte_15.GetHashCode();
		num = smethod_2(num) ^ byte_16.GetHashCode();
		num = smethod_2(num) ^ float_0.GetHashCode();
		num = smethod_2(num) ^ float_1.GetHashCode();
		num = smethod_2(num) ^ float_2.GetHashCode();
		num = smethod_2(num) ^ double_0.GetHashCode();
		num = smethod_2(num) ^ double_1.GetHashCode();
		num = smethod_2(num) ^ double_2.GetHashCode();
		num = smethod_2(num) ^ float_3.GetHashCode();
		num = smethod_2(num) ^ float_4.GetHashCode();
		num = smethod_2(num) ^ float_5.GetHashCode();
		num = smethod_2(num) ^ int_0.GetHashCode();
		num = smethod_2(num) ^ byte_17.GetHashCode();
		for (int i = 0; i < 15; i++)
		{
			num = smethod_2(num) ^ byte_18[i].GetHashCode();
		}
		num = smethod_2(num) ^ float_6.GetHashCode();
		num = smethod_2(num) ^ float_7.GetHashCode();
		num = smethod_2(num) ^ qnxEkJpGoDg.GetHashCode();
		num = smethod_2(num) ^ float_8.GetHashCode();
		num = smethod_2(num) ^ float_9.GetHashCode();
		num = smethod_2(num) ^ float_10.GetHashCode();
		for (int j = 0; j < 12; j++)
		{
			num = smethod_2(num) ^ byte_19[j].GetHashCode();
		}
		num = smethod_2(num) ^ int_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int k = 0; k < list_0.Count; k++)
			{
				num = smethod_2(num) ^ list_0[k].GetHashCode();
			}
		}
		return num;
	}
}
