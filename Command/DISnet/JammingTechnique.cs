using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class JammingTechnique
{
	private byte aPyEghDpAcn;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "kind")]
	public byte Kind
	{
		get
		{
			return aPyEghDpAcn;
		}
		set
		{
			aPyEghDpAcn = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "category")]
	public byte Category
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

	[XmlElement(Type = typeof(byte), ElementName = "subcategory")]
	public byte Subcategory
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

	[XmlElement(Type = typeof(byte), ElementName = "specific")]
	public byte Specific
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

	public static bool operator !=(JammingTechnique jammingTechnique_0, JammingTechnique jammingTechnique_1)
	{
		return !(jammingTechnique_0 == jammingTechnique_1);
	}

	public static bool operator ==(JammingTechnique jammingTechnique_0, JammingTechnique jammingTechnique_1)
	{
		if ((object)jammingTechnique_0 == jammingTechnique_1)
		{
			return true;
		}
		if ((object)jammingTechnique_0 != null && (object)jammingTechnique_1 != null)
		{
			return jammingTechnique_0.Equals(jammingTechnique_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 4;
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
				dataOutputStream_0.WriteUnsignedByte(aPyEghDpAcn);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
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
				aPyEghDpAcn = dataInputStream_0.ReadUnsignedByte();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<JammingTechnique>");
		try
		{
			stringBuilder_0.AppendLine("<kind type=\"byte\">" + aPyEghDpAcn.ToString(CultureInfo.InvariantCulture) + "</kind>");
			stringBuilder_0.AppendLine("<category type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</category>");
			stringBuilder_0.AppendLine("<subcategory type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			stringBuilder_0.AppendLine("<specific type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</specific>");
			stringBuilder_0.AppendLine("</JammingTechnique>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as JammingTechnique;
	}

	public bool Equals(JammingTechnique jammingTechnique_0)
	{
		bool result = true;
		if (jammingTechnique_0.GetType() == GetType())
		{
			if (aPyEghDpAcn != jammingTechnique_0.aPyEghDpAcn)
			{
				result = false;
			}
			if (byte_0 != jammingTechnique_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != jammingTechnique_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != jammingTechnique_0.byte_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ aPyEghDpAcn.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode();
	}
}
