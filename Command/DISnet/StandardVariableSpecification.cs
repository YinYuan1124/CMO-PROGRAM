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
[XmlInclude(typeof(SimulationManagementPduHeader))]
[XmlRoot]
public class StandardVariableSpecification
{
	private ushort ushort_0;

	private List<SimulationManagementPduHeader> list_0 = new List<SimulationManagementPduHeader>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfStandardVariableRecords")]
	public ushort NumberOfStandardVariableRecords
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

	[XmlElement(ElementName = "standardVariablesList", Type = typeof(List<SimulationManagementPduHeader>))]
	public List<SimulationManagementPduHeader> StandardVariables => list_0;

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

	public static bool operator !=(StandardVariableSpecification standardVariableSpecification_0, StandardVariableSpecification standardVariableSpecification_1)
	{
		return !(standardVariableSpecification_0 == standardVariableSpecification_1);
	}

	public static bool operator ==(StandardVariableSpecification standardVariableSpecification_0, StandardVariableSpecification standardVariableSpecification_1)
	{
		if ((object)standardVariableSpecification_0 == standardVariableSpecification_1)
		{
			return true;
		}
		if ((object)standardVariableSpecification_0 != null && (object)standardVariableSpecification_1 != null)
		{
			return standardVariableSpecification_0.Equals(standardVariableSpecification_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			SimulationManagementPduHeader simulationManagementPduHeader = list_0[i];
			num += simulationManagementPduHeader.GetMarshalledSize();
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

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfStandardVariableRecords; i++)
			{
				SimulationManagementPduHeader simulationManagementPduHeader = new SimulationManagementPduHeader();
				simulationManagementPduHeader.Unmarshal(dataInputStream_0);
				list_0.Add(simulationManagementPduHeader);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<StandardVariableSpecification>");
		try
		{
			stringBuilder_0.AppendLine("<standardVariables type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</standardVariables>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<standardVariables" + i.ToString(CultureInfo.InvariantCulture) + " type=\"SimulationManagementPduHeader\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</standardVariables" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</StandardVariableSpecification>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StandardVariableSpecification;
	}

	public bool Equals(StandardVariableSpecification standardVariableSpecification_0)
	{
		bool flag = true;
		if (standardVariableSpecification_0.GetType() == GetType())
		{
			if (ushort_0 != standardVariableSpecification_0.ushort_0)
			{
				flag = false;
			}
			if (list_0.Count != standardVariableSpecification_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(standardVariableSpecification_0.list_0[i]))
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
		num = smethod_0(0) ^ ushort_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
