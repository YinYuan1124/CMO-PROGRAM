using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(VectoringNozzleSystem))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(PropulsionSystemData))]
public class SeesPdu : DistributedEmissionsFamilyPdu, IEquatable<SeesPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	private List<PropulsionSystemData> list_0 = new List<PropulsionSystemData>();

	private List<VectoringNozzleSystem> list_1 = new List<VectoringNozzleSystem>();

	[XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
	public EntityID OrginatingEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "infraredSignatureRepresentationIndex")]
	public ushort InfraredSignatureRepresentationIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "acousticSignatureRepresentationIndex")]
	public ushort AcousticSignatureRepresentationIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "radarCrossSectionSignatureRepresentationIndex")]
	public ushort RadarCrossSectionSignatureRepresentationIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfPropulsionSystems")]
	public ushort NumberOfPropulsionSystems
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfVectoringNozzleSystems")]
	public ushort NumberOfVectoringNozzleSystems
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

	[XmlElement(ElementName = "propulsionSystemDataList", Type = typeof(List<PropulsionSystemData>))]
	public List<PropulsionSystemData> PropulsionSystemData => list_0;

	[XmlElement(ElementName = "vectoringSystemDataList", Type = typeof(List<VectoringNozzleSystem>))]
	public List<VectoringNozzleSystem> VectoringSystemData => list_1;

	public SeesPdu()
	{
		base.PduType = 30;
	}

	public static bool operator !=(SeesPdu seesPdu_0, SeesPdu seesPdu_1)
	{
		return !(seesPdu_0 == seesPdu_1);
	}

	public static bool operator ==(SeesPdu seesPdu_0, SeesPdu seesPdu_1)
	{
		if ((object)seesPdu_0 == seesPdu_1)
		{
			return true;
		}
		if ((object)seesPdu_0 != null && (object)seesPdu_1 != null)
		{
			return seesPdu_0.Equals(seesPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			PropulsionSystemData propulsionSystemData = list_0[i];
			num += propulsionSystemData.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			VectoringNozzleSystem vectoringNozzleSystem = list_1[j];
			num += vectoringNozzleSystem.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_1.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dataOutputStream_0);
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
			entityID_0.Unmarshal(dataInputStream_0);
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			ushort_5 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfPropulsionSystems; i++)
			{
				PropulsionSystemData propulsionSystemData = new PropulsionSystemData();
				propulsionSystemData.Unmarshal(dataInputStream_0);
				list_0.Add(propulsionSystemData);
			}
			for (int j = 0; j < NumberOfVectoringNozzleSystems; j++)
			{
				VectoringNozzleSystem vectoringNozzleSystem = new VectoringNozzleSystem();
				vectoringNozzleSystem.Unmarshal(dataInputStream_0);
				list_1.Add(vectoringNozzleSystem);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<SeesPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<orginatingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</orginatingEntityID>");
			stringBuilder_0.AppendLine("<infraredSignatureRepresentationIndex type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</infraredSignatureRepresentationIndex>");
			stringBuilder_0.AppendLine("<acousticSignatureRepresentationIndex type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</acousticSignatureRepresentationIndex>");
			stringBuilder_0.AppendLine("<radarCrossSectionSignatureRepresentationIndex type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</radarCrossSectionSignatureRepresentationIndex>");
			stringBuilder_0.AppendLine("<propulsionSystemData type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</propulsionSystemData>");
			stringBuilder_0.AppendLine("<vectoringSystemData type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</vectoringSystemData>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<propulsionSystemData" + i.ToString(CultureInfo.InvariantCulture) + " type=\"PropulsionSystemData\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</propulsionSystemData" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<vectoringSystemData" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VectoringNozzleSystem\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</vectoringSystemData" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</SeesPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SeesPdu;
	}

	public bool Equals(SeesPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((DistributedEmissionsFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
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
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (ushort_4 != other.ushort_4)
			{
				flag = false;
			}
			if (ushort_5 != other.ushort_5)
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		num = smethod_3(num) ^ ushort_4.GetHashCode();
		num = smethod_3(num) ^ ushort_5.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_3(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}
}
