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
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Orientation))]
public class EntityStateUpdatePdu : EntityInformationFamilyPdu, IEquatable<EntityStateUpdatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private int int_0;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearVelocity")]
	public Vector3Float EntityLinearVelocity
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "entityLocation")]
	public Vector3Double EntityLocation
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

	[XmlElement(Type = typeof(Orientation), ElementName = "entityOrientation")]
	public Orientation EntityOrientation
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
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

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

	public EntityStateUpdatePdu()
	{
		base.PduType = 67;
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(EntityStateUpdatePdu entityStateUpdatePdu_0, EntityStateUpdatePdu entityStateUpdatePdu_1)
	{
		return !(entityStateUpdatePdu_0 == entityStateUpdatePdu_1);
	}

	public static bool operator ==(EntityStateUpdatePdu entityStateUpdatePdu_0, EntityStateUpdatePdu entityStateUpdatePdu_1)
	{
		if ((object)entityStateUpdatePdu_0 == entityStateUpdatePdu_1)
		{
			return true;
		}
		if ((object)entityStateUpdatePdu_0 != null && (object)entityStateUpdatePdu_1 != null)
		{
			return entityStateUpdatePdu_0.Equals(entityStateUpdatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num++;
		num++;
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
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
			entityID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			vector3Float_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			orientation_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteInt(int_0);
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
			byte_4 = dataInputStream_0.ReadByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			vector3Float_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			orientation_0.Unmarshal(dataInputStream_0);
			int_0 = dataInputStream_0.ReadInt();
			for (int i = 0; i < NumberOfArticulationParameters; i++)
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
		stringBuilder_0.AppendLine("<EntityStateUpdatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<entityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityID>");
			stringBuilder_0.AppendLine("<padding1 type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
			stringBuilder_0.AppendLine("<entityLinearVelocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLinearVelocity>");
			stringBuilder_0.AppendLine("<entityLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLocation>");
			stringBuilder_0.AppendLine("<entityOrientation>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityOrientation>");
			stringBuilder_0.AppendLine("<entityAppearance type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</EntityStateUpdatePdu>");
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
		return this == obj as EntityStateUpdatePdu;
	}

	public bool Equals(EntityStateUpdatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityInformationFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
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
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!orientation_0.Equals(other.orientation_0))
			{
				flag = false;
			}
			if (int_0 != other.int_0)
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

	private static int smethod_2(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ int_0.GetHashCode();
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
