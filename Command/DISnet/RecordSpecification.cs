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
[XmlRoot]
[XmlInclude(typeof(RecordSpecificationElement))]
public class RecordSpecification
{
	private uint uint_0;

	private List<RecordSpecificationElement> list_0 = new List<RecordSpecificationElement>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecordSets")]
	public uint NumberOfRecordSets
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

	[XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSpecificationElement>))]
	public List<RecordSpecificationElement> RecordSets => list_0;

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

	public static bool operator !=(RecordSpecification recordSpecification_0, RecordSpecification recordSpecification_1)
	{
		return !(recordSpecification_0 == recordSpecification_1);
	}

	public static bool operator ==(RecordSpecification recordSpecification_0, RecordSpecification recordSpecification_1)
	{
		if ((object)recordSpecification_0 == recordSpecification_1)
		{
			return true;
		}
		if ((object)recordSpecification_0 != null && (object)recordSpecification_1 != null)
		{
			return recordSpecification_0.Equals(recordSpecification_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			RecordSpecificationElement recordSpecificationElement = list_0[i];
			num += recordSpecificationElement.GetMarshalledSize();
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
			uint_0 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < NumberOfRecordSets; i++)
			{
				RecordSpecificationElement recordSpecificationElement = new RecordSpecificationElement();
				recordSpecificationElement.Unmarshal(dataInputStream_0);
				list_0.Add(recordSpecificationElement);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<RecordSpecification>");
		try
		{
			stringBuilder_0.AppendLine("<recordSets type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<recordSets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSpecificationElement\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</recordSets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</RecordSpecification>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RecordSpecification;
	}

	public bool Equals(RecordSpecification recordSpecification_0)
	{
		bool flag = true;
		if (recordSpecification_0.GetType() == GetType())
		{
			if (uint_0 != recordSpecification_0.uint_0)
			{
				flag = false;
			}
			if (list_0.Count != recordSpecification_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(recordSpecification_0.list_0[i]))
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
