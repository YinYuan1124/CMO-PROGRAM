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
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(Vector3Double))]
public class DirectedEnergyPrecisionAimpoint
{
	private uint uint_0 = 4000u;

	private ushort ushort_0 = 88;

	private ushort ushort_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private Vector3Float vector3Float_2 = new Vector3Float();

	private EntityID entityID_0 = new EntityID();

	private byte byte_0;

	private byte byte_1;

	private float float_0;

	private float float_1;

	private float float_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "targetSpotLocation")]
	public Vector3Double TargetSpotLocation
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotEntityLocation")]
	public Vector3Float TargetSpotEntityLocation
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotVelocity")]
	public Vector3Float TargetSpotVelocity
	{
		get
		{
			return vector3Float_1;
		}
		set
		{
			vector3Float_1 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotAcceleration")]
	public Vector3Float TargetSpotAcceleration
	{
		get
		{
			return vector3Float_2;
		}
		set
		{
			vector3Float_2 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "targetEntityID")]
	public EntityID TargetEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "targetComponentID")]
	public byte TargetComponentID
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

	[XmlElement(Type = typeof(byte), ElementName = "SpotShape")]
	public byte SpotShape
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

	[XmlElement(Type = typeof(float), ElementName = "BeamSpotXSecSemiMajorAxis")]
	public float BeamSpotXSecSemiMajorAxis
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

	[XmlElement(Type = typeof(float), ElementName = "BeamSpotCrossSectionSemiMinorAxis")]
	public float BeamSpotCrossSectionSemiMinorAxis
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

	[XmlElement(Type = typeof(float), ElementName = "BeamSpotCrossSectionOrientAngle")]
	public float BeamSpotCrossSectionOrientAngle
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

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(DirectedEnergyPrecisionAimpoint directedEnergyPrecisionAimpoint_0, DirectedEnergyPrecisionAimpoint directedEnergyPrecisionAimpoint_1)
	{
		return !(directedEnergyPrecisionAimpoint_0 == directedEnergyPrecisionAimpoint_1);
	}

	public static bool operator ==(DirectedEnergyPrecisionAimpoint directedEnergyPrecisionAimpoint_0, DirectedEnergyPrecisionAimpoint directedEnergyPrecisionAimpoint_1)
	{
		if ((object)directedEnergyPrecisionAimpoint_0 == directedEnergyPrecisionAimpoint_1)
		{
			return true;
		}
		if ((object)directedEnergyPrecisionAimpoint_0 != null && (object)directedEnergyPrecisionAimpoint_1 != null)
		{
			return directedEnergyPrecisionAimpoint_0.Equals(directedEnergyPrecisionAimpoint_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 8 + vector3Double_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + vector3Float_1.GetMarshalledSize() + vector3Float_2.GetMarshalledSize() + entityID_0.GetMarshalledSize() + 1 + 1 + 4 + 4 + 4;
	}

	protected void OnException(Exception exception_0)
	{
		if (action_0 != null)
		{
			action_0(exception_0);
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				vector3Double_0.Marshal(dataOutputStream_0);
				vector3Float_0.Marshal(dataOutputStream_0);
				vector3Float_1.Marshal(dataOutputStream_0);
				vector3Float_2.Marshal(dataOutputStream_0);
				entityID_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
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
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				vector3Double_0.Unmarshal(dataInputStream_0);
				vector3Float_0.Unmarshal(dataInputStream_0);
				vector3Float_1.Unmarshal(dataInputStream_0);
				vector3Float_2.Unmarshal(dataInputStream_0);
				entityID_0.Unmarshal(dataInputStream_0);
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DirectedEnergyPrecisionAimpoint>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<targetSpotLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetSpotLocation>");
			stringBuilder_0.AppendLine("<targetSpotEntityLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetSpotEntityLocation>");
			stringBuilder_0.AppendLine("<targetSpotVelocity>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetSpotVelocity>");
			stringBuilder_0.AppendLine("<targetSpotAcceleration>");
			vector3Float_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetSpotAcceleration>");
			stringBuilder_0.AppendLine("<targetEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetEntityID>");
			stringBuilder_0.AppendLine("<targetComponentID type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</targetComponentID>");
			stringBuilder_0.AppendLine("<SpotShape type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</SpotShape>");
			stringBuilder_0.AppendLine("<BeamSpotXSecSemiMajorAxis type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</BeamSpotXSecSemiMajorAxis>");
			stringBuilder_0.AppendLine("<BeamSpotCrossSectionSemiMinorAxis type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</BeamSpotCrossSectionSemiMinorAxis>");
			stringBuilder_0.AppendLine("<BeamSpotCrossSectionOrientAngle type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</BeamSpotCrossSectionOrientAngle>");
			stringBuilder_0.AppendLine("</DirectedEnergyPrecisionAimpoint>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyPrecisionAimpoint;
	}

	public bool Equals(DirectedEnergyPrecisionAimpoint directedEnergyPrecisionAimpoint_0)
	{
		bool result = true;
		if (directedEnergyPrecisionAimpoint_0.GetType() == GetType())
		{
			if (uint_0 != directedEnergyPrecisionAimpoint_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != directedEnergyPrecisionAimpoint_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != directedEnergyPrecisionAimpoint_0.ushort_1)
			{
				result = false;
			}
			if (!vector3Double_0.Equals(directedEnergyPrecisionAimpoint_0.vector3Double_0))
			{
				result = false;
			}
			if (!vector3Float_0.Equals(directedEnergyPrecisionAimpoint_0.vector3Float_0))
			{
				result = false;
			}
			if (!vector3Float_1.Equals(directedEnergyPrecisionAimpoint_0.vector3Float_1))
			{
				result = false;
			}
			if (!vector3Float_2.Equals(directedEnergyPrecisionAimpoint_0.vector3Float_2))
			{
				result = false;
			}
			if (!entityID_0.Equals(directedEnergyPrecisionAimpoint_0.entityID_0))
			{
				result = false;
			}
			if (byte_0 != directedEnergyPrecisionAimpoint_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != directedEnergyPrecisionAimpoint_0.byte_1)
			{
				result = false;
			}
			if (float_0 != directedEnergyPrecisionAimpoint_0.float_0)
			{
				result = false;
			}
			if (float_1 != directedEnergyPrecisionAimpoint_0.float_1)
			{
				result = false;
			}
			if (float_2 != directedEnergyPrecisionAimpoint_0.float_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ vector3Float_1.GetHashCode()) ^ vector3Float_2.GetHashCode()) ^ entityID_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode();
	}
}
