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
[XmlInclude(typeof(FundamentalParameterDataIff))]
[XmlInclude(typeof(BeamData))]
[XmlInclude(typeof(LayerHeader))]
[XmlRoot]
public class IffAtcNavAidsLayer2Pdu : IffAtcNavAidsLayer1Pdu, IEquatable<IffAtcNavAidsLayer2Pdu>
{
	private LayerHeader layerHeader_0 = new LayerHeader();

	private BeamData beamData_0 = new BeamData();

	private BeamData beamData_1 = new BeamData();

	private List<FundamentalParameterDataIff> list_0 = new List<FundamentalParameterDataIff>();

	[XmlElement(Type = typeof(LayerHeader), ElementName = "layerHeader")]
	public LayerHeader LayerHeader
	{
		get
		{
			return layerHeader_0;
		}
		set
		{
			layerHeader_0 = value;
		}
	}

	[XmlElement(Type = typeof(BeamData), ElementName = "beamData")]
	public BeamData BeamData
	{
		get
		{
			return beamData_0;
		}
		set
		{
			beamData_0 = value;
		}
	}

	[XmlElement(Type = typeof(BeamData), ElementName = "secondaryOperationalData")]
	public BeamData SecondaryOperationalData
	{
		get
		{
			return beamData_1;
		}
		set
		{
			beamData_1 = value;
		}
	}

	[XmlElement(ElementName = "fundamentalIffParametersList", Type = typeof(List<FundamentalParameterDataIff>))]
	public List<FundamentalParameterDataIff> FundamentalIffParameters => list_0;

	public static bool operator !=(IffAtcNavAidsLayer2Pdu iffAtcNavAidsLayer2Pdu_0, IffAtcNavAidsLayer2Pdu iffAtcNavAidsLayer2Pdu_1)
	{
		return !(iffAtcNavAidsLayer2Pdu_0 == iffAtcNavAidsLayer2Pdu_1);
	}

	public static bool operator ==(IffAtcNavAidsLayer2Pdu iffAtcNavAidsLayer2Pdu_0, IffAtcNavAidsLayer2Pdu iffAtcNavAidsLayer2Pdu_1)
	{
		if ((object)iffAtcNavAidsLayer2Pdu_0 == iffAtcNavAidsLayer2Pdu_1)
		{
			return true;
		}
		if ((object)iffAtcNavAidsLayer2Pdu_0 != null && (object)iffAtcNavAidsLayer2Pdu_1 != null)
		{
			return iffAtcNavAidsLayer2Pdu_0.Equals(iffAtcNavAidsLayer2Pdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += layerHeader_0.GetMarshalledSize();
		num += beamData_0.GetMarshalledSize();
		num += beamData_1.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			FundamentalParameterDataIff fundamentalParameterDataIff = list_0[i];
			num += fundamentalParameterDataIff.GetMarshalledSize();
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
			layerHeader_0.Marshal(dataOutputStream_0);
			beamData_0.Marshal(dataOutputStream_0);
			beamData_1.Marshal(dataOutputStream_0);
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
			layerHeader_0.Unmarshal(dataInputStream_0);
			beamData_0.Unmarshal(dataInputStream_0);
			beamData_1.Unmarshal(dataInputStream_0);
			for (int i = 0; i < base.Pad2; i++)
			{
				FundamentalParameterDataIff fundamentalParameterDataIff = new FundamentalParameterDataIff();
				fundamentalParameterDataIff.Unmarshal(dataInputStream_0);
				list_0.Add(fundamentalParameterDataIff);
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
		stringBuilder_0.AppendLine("<IffAtcNavAidsLayer2Pdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<layerHeader>");
			layerHeader_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</layerHeader>");
			stringBuilder_0.AppendLine("<beamData>");
			beamData_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</beamData>");
			stringBuilder_0.AppendLine("<secondaryOperationalData>");
			beamData_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</secondaryOperationalData>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<fundamentalIffParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FundamentalParameterDataIff\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</fundamentalIffParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</IffAtcNavAidsLayer2Pdu>");
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
		return this == obj as IffAtcNavAidsLayer2Pdu;
	}

	public bool Equals(IffAtcNavAidsLayer2Pdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((IffAtcNavAidsLayer1Pdu)other);
			if (!layerHeader_0.Equals(other.layerHeader_0))
			{
				flag = false;
			}
			if (!beamData_0.Equals(other.beamData_0))
			{
				flag = false;
			}
			if (!beamData_1.Equals(other.beamData_1))
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
		num = smethod_3(num) ^ layerHeader_0.GetHashCode();
		num = smethod_3(num) ^ beamData_0.GetHashCode();
		num = smethod_3(num) ^ beamData_1.GetHashCode();
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
