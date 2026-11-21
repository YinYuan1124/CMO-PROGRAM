using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
public class AntennaLocation
{
	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
	public Vector3Double AntennaLocation_
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "relativeAntennaLocation")]
	public Vector3Float RelativeAntennaLocation
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

	public static bool operator !=(AntennaLocation antennaLocation_0, AntennaLocation antennaLocation_1)
	{
		return !(antennaLocation_0 == antennaLocation_1);
	}

	public static bool operator ==(AntennaLocation antennaLocation_0, AntennaLocation antennaLocation_1)
	{
		if ((object)antennaLocation_0 == antennaLocation_1)
		{
			return true;
		}
		if ((object)antennaLocation_0 != null && (object)antennaLocation_1 != null)
		{
			return antennaLocation_0.Equals(antennaLocation_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return vector3Double_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize();
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
				vector3Double_0.Marshal(dataOutputStream_0);
				vector3Float_0.Marshal(dataOutputStream_0);
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
				vector3Double_0.Unmarshal(dataInputStream_0);
				vector3Float_0.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<AntennaLocation>");
		try
		{
			stringBuilder_0.AppendLine("<antennaLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</antennaLocation>");
			stringBuilder_0.AppendLine("<relativeAntennaLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</relativeAntennaLocation>");
			stringBuilder_0.AppendLine("</AntennaLocation>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AntennaLocation;
	}

	public bool Equals(AntennaLocation antennaLocation_0)
	{
		bool result = true;
		if (antennaLocation_0.GetType() == GetType())
		{
			if (!vector3Double_0.Equals(antennaLocation_0.vector3Double_0))
			{
				result = false;
			}
			if (!vector3Float_0.Equals(antennaLocation_0.vector3Float_0))
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
		return smethod_0(smethod_0(0) ^ vector3Double_0.GetHashCode()) ^ vector3Float_0.GetHashCode();
	}
}
