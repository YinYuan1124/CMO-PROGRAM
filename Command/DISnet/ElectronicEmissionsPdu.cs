using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EmitterSystem))]
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(EntityID))]
public class ElectronicEmissionsPdu : DistributedEmissionsFamilyPdu, IEquatable<ElectronicEmissionsPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private byte byte_5;

	private byte byte_6;

	private ushort ushort_1;

	private byte byte_7;

	private byte byte_8;

	private EmitterSystem emitterSystem_0 = new EmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private List<Vector3Float> list_0 = new List<Vector3Float>();

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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "eventID")]
	public EventIdentifier EventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
	public byte StateUpdateIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
	public byte NumberOfSystems
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

	[XmlElement(Type = typeof(ushort), ElementName = "paddingForEmissionsPdu")]
	public ushort PaddingForEmissionsPdu
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
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
	public byte NumberOfBeams
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

	[XmlElement(ElementName = "systemsList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> Systems => list_0;

	public ElectronicEmissionsPdu()
	{
		base.PduType = 23;
	}

	public static bool operator !=(ElectronicEmissionsPdu electronicEmissionsPdu_0, ElectronicEmissionsPdu electronicEmissionsPdu_1)
	{
		return !(electronicEmissionsPdu_0 == electronicEmissionsPdu_1);
	}

	public static bool operator ==(ElectronicEmissionsPdu electronicEmissionsPdu_0, ElectronicEmissionsPdu electronicEmissionsPdu_1)
	{
		if ((object)electronicEmissionsPdu_0 == electronicEmissionsPdu_1)
		{
			return true;
		}
		if ((object)electronicEmissionsPdu_0 != null && (object)electronicEmissionsPdu_1 != null)
		{
			return electronicEmissionsPdu_0.Equals(electronicEmissionsPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += eventIdentifier_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num += emitterSystem_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Float vector3Float = list_0[i];
			num += vector3Float.GetMarshalledSize();
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
			eventIdentifier_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
			dataOutputStream_0.WriteUnsignedByte(byte_8);
			emitterSystem_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
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
			entityID_0.Unmarshal(dataInputStream_0);
			eventIdentifier_0.Unmarshal(dataInputStream_0);
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			byte_8 = dataInputStream_0.ReadUnsignedByte();
			emitterSystem_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			for (int i = 0; i < NumberOfSystems; i++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dataInputStream_0);
				list_0.Add(vector3Float);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ElectronicEmissionsPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emittingEntityID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventIdentifier_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<stateUpdateIndicator type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
			stringBuilder_0.AppendLine("<systems type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</systems>");
			stringBuilder_0.AppendLine("<paddingForEmissionsPdu type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</paddingForEmissionsPdu>");
			stringBuilder_0.AppendLine("<systemDataLength type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
			stringBuilder_0.AppendLine("<numberOfBeams type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</numberOfBeams>");
			stringBuilder_0.AppendLine("<emitterSystem>");
			emitterSystem_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emitterSystem>");
			stringBuilder_0.AppendLine("<location>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</location>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<systems" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</systems" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ElectronicEmissionsPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ElectronicEmissionsPdu;
	}

	public bool Equals(ElectronicEmissionsPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((DistributedEmissionsFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!eventIdentifier_0.Equals(other.eventIdentifier_0))
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
			if (byte_7 != other.byte_7)
			{
				flag = false;
			}
			if (byte_8 != other.byte_8)
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
		num = smethod_3(num) ^ eventIdentifier_0.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ byte_8.GetHashCode();
		num = smethod_3(num) ^ emitterSystem_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
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
