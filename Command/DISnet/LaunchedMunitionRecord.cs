using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
public class LaunchedMunitionRecord
{
	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private ushort ushort_0;

	private EventIdentifier eventIdentifier_1 = new EventIdentifier();

	private ushort ushort_1;

	private EventIdentifier eventIdentifier_2 = new EventIdentifier();

	private ushort ushort_2;

	private Vector3Double sExEgIoSiHF = new Vector3Double();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "fireEventID")]
	public EventIdentifier FireEventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "firingEntityID")]
	public EventIdentifier FiringEntityID
	{
		get
		{
			return eventIdentifier_1;
		}
		set
		{
			eventIdentifier_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "targetEntityID")]
	public EventIdentifier TargetEntityID
	{
		get
		{
			return eventIdentifier_2;
		}
		set
		{
			eventIdentifier_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding3")]
	public ushort Padding3
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "targetLocation")]
	public Vector3Double TargetLocation
	{
		get
		{
			return sExEgIoSiHF;
		}
		set
		{
			sExEgIoSiHF = value;
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

	public static bool operator !=(LaunchedMunitionRecord launchedMunitionRecord_0, LaunchedMunitionRecord launchedMunitionRecord_1)
	{
		return !(launchedMunitionRecord_0 == launchedMunitionRecord_1);
	}

	public static bool operator ==(LaunchedMunitionRecord launchedMunitionRecord_0, LaunchedMunitionRecord launchedMunitionRecord_1)
	{
		if ((object)launchedMunitionRecord_0 == launchedMunitionRecord_1)
		{
			return true;
		}
		if ((object)launchedMunitionRecord_0 != null && (object)launchedMunitionRecord_1 != null)
		{
			return launchedMunitionRecord_0.Equals(launchedMunitionRecord_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return eventIdentifier_0.GetMarshalledSize() + 2 + eventIdentifier_1.GetMarshalledSize() + 2 + eventIdentifier_2.GetMarshalledSize() + 2 + sExEgIoSiHF.GetMarshalledSize();
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
				eventIdentifier_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				eventIdentifier_1.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				eventIdentifier_2.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				sExEgIoSiHF.Marshal(dataOutputStream_0);
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
				eventIdentifier_0.Unmarshal(dataInputStream_0);
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				eventIdentifier_1.Unmarshal(dataInputStream_0);
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				eventIdentifier_2.Unmarshal(dataInputStream_0);
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				sExEgIoSiHF.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<LaunchedMunitionRecord>");
		try
		{
			stringBuilder_0.AppendLine("<fireEventID>");
			eventIdentifier_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</fireEventID>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<firingEntityID>");
			eventIdentifier_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</firingEntityID>");
			stringBuilder_0.AppendLine("<padding2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<targetEntityID>");
			eventIdentifier_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetEntityID>");
			stringBuilder_0.AppendLine("<padding3 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			stringBuilder_0.AppendLine("<targetLocation>");
			sExEgIoSiHF.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetLocation>");
			stringBuilder_0.AppendLine("</LaunchedMunitionRecord>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LaunchedMunitionRecord;
	}

	public bool Equals(LaunchedMunitionRecord launchedMunitionRecord_0)
	{
		bool result = true;
		if (launchedMunitionRecord_0.GetType() == GetType())
		{
			if (!eventIdentifier_0.Equals(launchedMunitionRecord_0.eventIdentifier_0))
			{
				result = false;
			}
			if (ushort_0 != launchedMunitionRecord_0.ushort_0)
			{
				result = false;
			}
			if (!eventIdentifier_1.Equals(launchedMunitionRecord_0.eventIdentifier_1))
			{
				result = false;
			}
			if (ushort_1 != launchedMunitionRecord_0.ushort_1)
			{
				result = false;
			}
			if (!eventIdentifier_2.Equals(launchedMunitionRecord_0.eventIdentifier_2))
			{
				result = false;
			}
			if (ushort_2 != launchedMunitionRecord_0.ushort_2)
			{
				result = false;
			}
			if (!sExEgIoSiHF.Equals(launchedMunitionRecord_0.sExEgIoSiHF))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ eventIdentifier_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ eventIdentifier_1.GetHashCode()) ^ ushort_1.GetHashCode()) ^ eventIdentifier_2.GetHashCode()) ^ ushort_2.GetHashCode()) ^ sExEgIoSiHF.GetHashCode();
	}
}
