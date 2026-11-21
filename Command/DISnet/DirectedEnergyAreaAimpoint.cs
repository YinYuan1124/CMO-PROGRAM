using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(DirectedEnergyTargetEnergyDeposition))]
[XmlRoot]
[XmlInclude(typeof(BeamAntennaPattern))]
public class DirectedEnergyAreaAimpoint
{
	private uint uint_0 = 4001u;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private List<BeamAntennaPattern> list_0 = new List<BeamAntennaPattern>();

	private List<DirectedEnergyTargetEnergyDeposition> list_1 = new List<DirectedEnergyTargetEnergyDeposition>();

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

	[XmlElement(Type = typeof(ushort), ElementName = "beamAntennaPatternRecordCount")]
	public ushort BeamAntennaPatternRecordCount
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

	[XmlElement(Type = typeof(ushort), ElementName = "directedEnergyTargetEnergyDepositionRecordCount")]
	public ushort DirectedEnergyTargetEnergyDepositionRecordCount
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

	[XmlElement(ElementName = "beamAntennaParameterListList", Type = typeof(List<BeamAntennaPattern>))]
	public List<BeamAntennaPattern> BeamAntennaParameterList => list_0;

	[XmlElement(ElementName = "directedEnergyTargetEnergyDepositionRecordListList", Type = typeof(List<DirectedEnergyTargetEnergyDeposition>))]
	public List<DirectedEnergyTargetEnergyDeposition> DirectedEnergyTargetEnergyDepositionRecordList => list_1;

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

	public static bool operator !=(DirectedEnergyAreaAimpoint directedEnergyAreaAimpoint_0, DirectedEnergyAreaAimpoint directedEnergyAreaAimpoint_1)
	{
		return !(directedEnergyAreaAimpoint_0 == directedEnergyAreaAimpoint_1);
	}

	public static bool operator ==(DirectedEnergyAreaAimpoint directedEnergyAreaAimpoint_0, DirectedEnergyAreaAimpoint directedEnergyAreaAimpoint_1)
	{
		if ((object)directedEnergyAreaAimpoint_0 == directedEnergyAreaAimpoint_1)
		{
			return true;
		}
		if ((object)directedEnergyAreaAimpoint_0 != null && (object)directedEnergyAreaAimpoint_1 != null)
		{
			return directedEnergyAreaAimpoint_0.Equals(directedEnergyAreaAimpoint_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 4;
		num = 6;
		num = 8;
		num = 10;
		num = 12;
		for (int i = 0; i < list_0.Count; i++)
		{
			BeamAntennaPattern beamAntennaPattern = list_0[i];
			num += beamAntennaPattern.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			DirectedEnergyTargetEnergyDeposition directedEnergyTargetEnergyDeposition = list_1[j];
			num += directedEnergyTargetEnergyDeposition.GetMarshalledSize();
		}
		return num;
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
		if (dataOutputStream_0 == null)
		{
			return;
		}
		try
		{
			dataOutputStream_0.WriteUnsignedInt(uint_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
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

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			uint_0 = dataInputStream_0.ReadUnsignedInt();
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < BeamAntennaPatternRecordCount; i++)
			{
				BeamAntennaPattern beamAntennaPattern = new BeamAntennaPattern();
				beamAntennaPattern.Unmarshal(dataInputStream_0);
				list_0.Add(beamAntennaPattern);
			}
			for (int j = 0; j < DirectedEnergyTargetEnergyDepositionRecordCount; j++)
			{
				DirectedEnergyTargetEnergyDeposition directedEnergyTargetEnergyDeposition = new DirectedEnergyTargetEnergyDeposition();
				directedEnergyTargetEnergyDeposition.Unmarshal(dataInputStream_0);
				list_1.Add(directedEnergyTargetEnergyDeposition);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DirectedEnergyAreaAimpoint>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<beamAntennaParameterList type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</beamAntennaParameterList>");
			stringBuilder_0.AppendLine("<directedEnergyTargetEnergyDepositionRecordList type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</directedEnergyTargetEnergyDepositionRecordList>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<beamAntennaParameterList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"BeamAntennaPattern\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</beamAntennaParameterList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<directedEnergyTargetEnergyDepositionRecordList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"DirectedEnergyTargetEnergyDeposition\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</directedEnergyTargetEnergyDepositionRecordList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DirectedEnergyAreaAimpoint>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyAreaAimpoint;
	}

	public bool Equals(DirectedEnergyAreaAimpoint directedEnergyAreaAimpoint_0)
	{
		bool flag = true;
		if (directedEnergyAreaAimpoint_0.GetType() == GetType())
		{
			if (uint_0 != directedEnergyAreaAimpoint_0.uint_0)
			{
				flag = false;
			}
			if (ushort_0 != directedEnergyAreaAimpoint_0.ushort_0)
			{
				flag = false;
			}
			if (ushort_1 != directedEnergyAreaAimpoint_0.ushort_1)
			{
				flag = false;
			}
			if (ushort_2 != directedEnergyAreaAimpoint_0.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != directedEnergyAreaAimpoint_0.ushort_3)
			{
				flag = false;
			}
			if (list_0.Count != directedEnergyAreaAimpoint_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(directedEnergyAreaAimpoint_0.list_0[i]))
					{
						flag = false;
					}
				}
			}
			if (list_1.Count != directedEnergyAreaAimpoint_0.list_1.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < list_1.Count; j++)
				{
					if (!list_1[j].Equals(directedEnergyAreaAimpoint_0.list_1[j]))
					{
						flag = false;
					}
				}
			}
			return flag;
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
		int num = 0;
		num = smethod_0(0) ^ uint_0.GetHashCode();
		num = smethod_0(num) ^ ushort_0.GetHashCode();
		num = smethod_0(num) ^ ushort_1.GetHashCode();
		num = smethod_0(num) ^ ushort_2.GetHashCode();
		num = smethod_0(num) ^ ushort_3.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_0(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}
}
