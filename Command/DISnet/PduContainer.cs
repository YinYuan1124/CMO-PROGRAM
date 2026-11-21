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
[XmlInclude(typeof(Pdu))]
public class PduContainer
{
	private int int_0;

	private List<Pdu> list_0 = new List<Pdu>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(int), ElementName = "numberOfPdus")]
	public int NumberOfPdus
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

	[XmlElement(ElementName = "pdusList", Type = typeof(List<Pdu>))]
	public List<Pdu> Pdus => list_0;

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

	public static bool operator !=(PduContainer pduContainer_0, PduContainer pduContainer_1)
	{
		return !(pduContainer_0 == pduContainer_1);
	}

	public static bool operator ==(PduContainer pduContainer_0, PduContainer pduContainer_1)
	{
		if ((object)pduContainer_0 == pduContainer_1)
		{
			return true;
		}
		if ((object)pduContainer_0 != null && (object)pduContainer_1 != null)
		{
			return pduContainer_0.Equals(pduContainer_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			Pdu pdu = list_0[i];
			num += pdu.GetMarshalledSize();
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
			dataOutputStream_0.WriteInt(list_0.Count);
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
			int_0 = dataInputStream_0.ReadInt();
			for (int i = 0; i < NumberOfPdus; i++)
			{
				Pdu pdu = new Pdu();
				pdu.Unmarshal(dataInputStream_0);
				list_0.Add(pdu);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<PduContainer>");
		try
		{
			stringBuilder_0.AppendLine("<pdus type=\"int\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</pdus>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<pdus" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Pdu\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</pdus" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</PduContainer>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as PduContainer;
	}

	public bool Equals(PduContainer pduContainer_0)
	{
		bool flag = true;
		if (pduContainer_0.GetType() == GetType())
		{
			if (int_0 != pduContainer_0.int_0)
			{
				flag = false;
			}
			if (list_0.Count != pduContainer_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(pduContainer_0.list_0[i]))
					{
						flag = false;
					}
				}
			}
			return flag;
		}
		return false;
	}

	private static int smethod_0(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_0(0) ^ int_0.GetHashCode();
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
