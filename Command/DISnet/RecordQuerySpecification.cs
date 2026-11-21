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
[XmlInclude(typeof(FourByteChunk))]
[XmlRoot]
public class RecordQuerySpecification
{
	private uint uint_0;

	private List<FourByteChunk> list_0 = new List<FourByteChunk>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecords")]
	public uint NumberOfRecords
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

	[XmlElement(ElementName = "recordsList", Type = typeof(List<FourByteChunk>))]
	public List<FourByteChunk> Records => list_0;

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

	public static bool operator !=(RecordQuerySpecification recordQuerySpecification_0, RecordQuerySpecification recordQuerySpecification_1)
	{
		return !(recordQuerySpecification_0 == recordQuerySpecification_1);
	}

	public static bool operator ==(RecordQuerySpecification recordQuerySpecification_0, RecordQuerySpecification recordQuerySpecification_1)
	{
		if ((object)recordQuerySpecification_0 == recordQuerySpecification_1)
		{
			return true;
		}
		if ((object)recordQuerySpecification_0 != null && (object)recordQuerySpecification_1 != null)
		{
			return recordQuerySpecification_0.Equals(recordQuerySpecification_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			FourByteChunk fourByteChunk = list_0[i];
			num += fourByteChunk.GetMarshalledSize();
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
			for (int i = 0; i < NumberOfRecords; i++)
			{
				FourByteChunk fourByteChunk = new FourByteChunk();
				fourByteChunk.Unmarshal(dataInputStream_0);
				list_0.Add(fourByteChunk);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<RecordQuerySpecification>");
		try
		{
			stringBuilder_0.AppendLine("<records type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</records>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<records" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</records" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</RecordQuerySpecification>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RecordQuerySpecification;
	}

	public bool Equals(RecordQuerySpecification recordQuerySpecification_0)
	{
		bool flag = true;
		if (recordQuerySpecification_0.GetType() == GetType())
		{
			if (uint_0 != recordQuerySpecification_0.uint_0)
			{
				flag = false;
			}
			if (list_0.Count != recordQuerySpecification_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(recordQuerySpecification_0.list_0[i]))
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
