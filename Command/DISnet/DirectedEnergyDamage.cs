using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EventIdentifier))]
[XmlRoot]
public class DirectedEnergyDamage
{
	private uint svjEhFsAnfS = 4500u;

	private ushort ushort_0 = 40;

	private ushort ushort_1;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	private float float_1 = -273.15f;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private ushort ushort_2;

	[CompilerGenerated]
	private Action<Exception> OowEhdfsOmm;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
	{
		get
		{
			return svjEhFsAnfS;
		}
		set
		{
			svjEhFsAnfS = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "damageLocation")]
	public Vector3Float DamageLocation
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

	[XmlElement(Type = typeof(float), ElementName = "damageDiameter")]
	public float DamageDiameter
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

	[XmlElement(Type = typeof(float), ElementName = "temperature")]
	public float Temperature
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

	[XmlElement(Type = typeof(byte), ElementName = "componentIdentification")]
	public byte ComponentIdentification
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "componentDamageStatus")]
	public byte ComponentDamageStatus
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "componentVisualDamageStatus")]
	public byte ComponentVisualDamageStatus
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "componentVisualSmokeColor")]
	public byte ComponentVisualSmokeColor
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "fireEventID")]
	public EventIdentifier FireEventID
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
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

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = OowEhdfsOmm;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OowEhdfsOmm, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = OowEhdfsOmm;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OowEhdfsOmm, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(DirectedEnergyDamage directedEnergyDamage_0, DirectedEnergyDamage directedEnergyDamage_1)
	{
		return !(directedEnergyDamage_0 == directedEnergyDamage_1);
	}

	public static bool operator ==(DirectedEnergyDamage directedEnergyDamage_0, DirectedEnergyDamage directedEnergyDamage_1)
	{
		if ((object)directedEnergyDamage_0 == directedEnergyDamage_1)
		{
			return true;
		}
		if ((object)directedEnergyDamage_0 != null && (object)directedEnergyDamage_1 != null)
		{
			return directedEnergyDamage_0.Equals(directedEnergyDamage_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 8 + vector3Float_0.GetMarshalledSize() + 4 + 4 + 1 + 1 + 1 + 1 + eventIdentifier_0.GetMarshalledSize() + 2;
	}

	protected void OnException(Exception exception_0)
	{
		if (OowEhdfsOmm != null)
		{
			OowEhdfsOmm(exception_0);
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedInt(svjEhFsAnfS);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				vector3Float_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				eventIdentifier_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 != null)
		{
			try
			{
				svjEhFsAnfS = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				vector3Float_0.Unmarshal(dataInputStream_0);
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				eventIdentifier_0.Unmarshal(dataInputStream_0);
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DirectedEnergyDamage>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + svjEhFsAnfS.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<damageLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</damageLocation>");
			stringBuilder_0.AppendLine("<damageDiameter type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</damageDiameter>");
			stringBuilder_0.AppendLine("<temperature type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</temperature>");
			stringBuilder_0.AppendLine("<componentIdentification type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</componentIdentification>");
			stringBuilder_0.AppendLine("<componentDamageStatus type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</componentDamageStatus>");
			stringBuilder_0.AppendLine("<componentVisualDamageStatus type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</componentVisualDamageStatus>");
			stringBuilder_0.AppendLine("<componentVisualSmokeColor type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</componentVisualSmokeColor>");
			stringBuilder_0.AppendLine("<fireEventID>");
			eventIdentifier_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</fireEventID>");
			stringBuilder_0.AppendLine("<padding2 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("</DirectedEnergyDamage>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyDamage;
	}

	public bool Equals(DirectedEnergyDamage directedEnergyDamage_0)
	{
		bool result = true;
		if (directedEnergyDamage_0.GetType() == GetType())
		{
			if (svjEhFsAnfS != directedEnergyDamage_0.svjEhFsAnfS)
			{
				result = false;
			}
			if (ushort_0 != directedEnergyDamage_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != directedEnergyDamage_0.ushort_1)
			{
				result = false;
			}
			if (!vector3Float_0.Equals(directedEnergyDamage_0.vector3Float_0))
			{
				result = false;
			}
			if (float_0 != directedEnergyDamage_0.float_0)
			{
				result = false;
			}
			if (float_1 != directedEnergyDamage_0.float_1)
			{
				result = false;
			}
			if (byte_0 != directedEnergyDamage_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != directedEnergyDamage_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != directedEnergyDamage_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != directedEnergyDamage_0.byte_3)
			{
				result = false;
			}
			if (!eventIdentifier_0.Equals(directedEnergyDamage_0.eventIdentifier_0))
			{
				result = false;
			}
			if (ushort_2 != directedEnergyDamage_0.ushort_2)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ svjEhFsAnfS.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ ushort_2.GetHashCode();
	}
}
