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
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(FixedDatum))]
[XmlRoot]
public class DatumSpecification
{
	private uint uint_0;

	private uint uint_1;

	private List<FixedDatum> list_0 = new List<FixedDatum>();

	private List<VariableDatum> list_1 = new List<VariableDatum>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatums")]
	public uint NumberOfFixedDatums
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatums")]
	public uint NumberOfVariableDatums
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(ElementName = "fixedDatumIDListList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatumIDList => list_0;

	[XmlElement(ElementName = "variableDatumIDListList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> List_0 => list_1;

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

	public static bool operator !=(DatumSpecification datumSpecification_0, DatumSpecification datumSpecification_1)
	{
		return !(datumSpecification_0 == datumSpecification_1);
	}

	public static bool operator ==(DatumSpecification datumSpecification_0, DatumSpecification datumSpecification_1)
	{
		if ((object)datumSpecification_0 == datumSpecification_1)
		{
			return true;
		}
		if ((object)datumSpecification_0 != null && (object)datumSpecification_1 != null)
		{
			return datumSpecification_0.Equals(datumSpecification_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 4;
		num = 8;
		for (int i = 0; i < list_0.Count; i++)
		{
			FixedDatum fixedDatum = list_0[i];
			num += fixedDatum.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			VariableDatum variableDatum = list_1[j];
			num += variableDatum.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
			dataOutputStream_0.WriteUnsignedInt((uint)list_1.Count);
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
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < NumberOfFixedDatums; i++)
			{
				FixedDatum fixedDatum = new FixedDatum();
				fixedDatum.Unmarshal(dataInputStream_0);
				list_0.Add(fixedDatum);
			}
			for (int j = 0; j < NumberOfVariableDatums; j++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dataInputStream_0);
				list_1.Add(variableDatum);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DatumSpecification>");
		try
		{
			stringBuilder_0.AppendLine("<fixedDatumIDList type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatumIDList>");
			stringBuilder_0.AppendLine("<variableDatumIDList type=\"uint\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumIDList>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<fixedDatumIDList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</fixedDatumIDList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<variableDatumIDList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableDatumIDList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DatumSpecification>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DatumSpecification;
	}

	public bool Equals(DatumSpecification datumSpecification_0)
	{
		bool flag = true;
		if (datumSpecification_0.GetType() == GetType())
		{
			if (uint_0 != datumSpecification_0.uint_0)
			{
				flag = false;
			}
			if (uint_1 != datumSpecification_0.uint_1)
			{
				flag = false;
			}
			if (list_0.Count != datumSpecification_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(datumSpecification_0.list_0[i]))
					{
						flag = false;
					}
				}
			}
			if (list_1.Count != datumSpecification_0.list_1.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < list_1.Count; j++)
				{
					if (!list_1[j].Equals(datumSpecification_0.list_1[j]))
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
		num = smethod_0(num) ^ uint_1.GetHashCode();
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
