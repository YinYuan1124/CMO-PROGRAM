using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Notification_Bark
{
	public class MessageWrapper : IEquatable<MessageWrapper>
	{
		public string text;

		public Color Color;

		public float FontSize;

		public bool MoveUpward;

		public bool Fades;

		public float Lifetime;

		public MessageWrapper(string string_0, Color color_0, float float_0, bool bool_0, bool bool_1, float float_1)
		{
			text = string_0;
			Color = color_0;
			FontSize = float_0;
			MoveUpward = bool_0;
			Fades = bool_1;
			Lifetime = float_1;
		}

		public bool Equals(MessageWrapper other)
		{
			if (Operators.CompareString(text, other.text, TextCompare: false) == 0 && Color == other.Color && FontSize == other.FontSize && MoveUpward == other.MoveUpward && Fades == other.Fades)
			{
				return Lifetime == other.Lifetime;
			}
			return false;
		}

		public static bool operator ==(MessageWrapper messageWrapper_0, MessageWrapper messageWrapper_1)
		{
			return messageWrapper_0.Equals(messageWrapper_1);
		}

		public static bool operator !=(MessageWrapper messageWrapper_0, MessageWrapper messageWrapper_1)
		{
			return !messageWrapper_0.Equals(messageWrapper_1);
		}
	}

	public DateTime CreationDate;

	public DateTime Expiration;

	public List<MessageWrapper> Messages;

	public Geopoint_Struct Position;

	public Module_Unit.Unit Anchor;

	public double Progress;

	private GlobalSingleton codeConsumer;

	private static object connectionConsumer;

	public Color Color
	{
		get
		{
			if (Messages.Count <= 0)
			{
				return default(Color);
			}
			return Messages[0].Color;
		}
		set
		{
			Messages[0].Color = value;
		}
	}

	public float Lifetime
	{
		get
		{
			if (Messages.Count <= 0)
			{
				return 0f;
			}
			return Messages[0].Lifetime;
		}
	}

	public float FontSize
	{
		get
		{
			if (Messages.Count <= 0)
			{
				return 0f;
			}
			return Messages[0].FontSize;
		}
	}

	public bool Fades
	{
		get
		{
			if (Messages.Count <= 0)
			{
				return false;
			}
			return Messages[0].Fades;
		}
	}

	public bool MoveUpward
	{
		get
		{
			if (Messages.Count <= 0)
			{
				return false;
			}
			return Messages[0].MoveUpward;
		}
	}

	public string Text
	{
		get
		{
			if (Messages.Count <= 0)
			{
				return "";
			}
			return Messages[0].text;
		}
	}

	static Notification_Bark()
	{
		connectionConsumer = RuntimeHelpers.GetObjectValue(new object());
	}

	public Notification_Bark(double double_0, double double_1)
	{
		Messages = new List<MessageWrapper>();
		Position = default(Geopoint_Struct);
		Position = new Geopoint_Struct(double_0, double_1);
		Initialise(null);
	}

	public Notification_Bark(Module_Unit.Unit unit_0)
	{
		Messages = new List<MessageWrapper>();
		Position = default(Geopoint_Struct);
		Initialise(unit_0);
	}

	public void Initialise(Module_Unit.Unit unit_0)
	{
		Anchor = unit_0;
		ReAttachToAnchor();
		ResetTimer();
		codeConsumer = GlobalSingleton.GetInstance();
	}

	public static void Create(double double_0, double double_1, string string_0, Color color_0, bool bool_0 = true, bool bool_1 = true, float float_0 = 1f, float float_1 = 18f)
	{
		GlobalSingleton instance = GlobalSingleton.GetInstance();
		Notification_Bark notification_Bark = new Notification_Bark(double_0, double_1);
		instance.Notification_Barks.Add(notification_Bark);
		object obj = connectionConsumer;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			notification_Bark.AddMessage(new MessageWrapper(string_0, color_0, float_1, bool_0, bool_1, float_0));
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public static void Create(double double_0, double double_1, List<string> list_0, Color color_0, bool bool_0 = true, bool bool_1 = true, float float_0 = 1f, float float_1 = 18f)
	{
		foreach (string item in list_0)
		{
			Create(double_0, double_1, item, color_0, bool_0, bool_1, float_0, float_1);
		}
	}

	public static void Create(Module_Unit.Unit unit_0, List<string> list_0, Color color_0, bool bool_0 = true, bool bool_1 = true, float float_0 = 1f, float float_1 = 18f)
	{
		foreach (string item in list_0)
		{
			Create(unit_0, item, color_0, bool_0, bool_1, float_0, float_1);
		}
	}

	public static void Create(Module_Unit.Unit unit_0, string string_0, Color color_0, bool bool_0 = true, bool bool_1 = true, float float_0 = 1f, float float_1 = 18f)
	{
		try
		{
			object obj = connectionConsumer;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (unit_0.AttachedBark == null)
				{
					GlobalSingleton instance = GlobalSingleton.GetInstance();
					Notification_Bark notification_Bark = new Notification_Bark(unit_0);
					instance.Notification_Barks.Add(notification_Bark);
					notification_Bark.AddMessage(new MessageWrapper(string_0, color_0, float_1, bool_0, bool_1, float_0));
				}
				else
				{
					unit_0.AttachedBark.AddMessage(new MessageWrapper(string_0, color_0, float_1, bool_0, bool_1, float_0));
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 14675178645", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddMessage(MessageWrapper messageWrapper_0)
	{
		if (Information.IsNothing(messageWrapper_0))
		{
			return;
		}
		List<MessageWrapper>.Enumerator enumerator = Messages.GetEnumerator();
		MessageWrapper current;
		do
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				continue;
			}
			Messages.Add(messageWrapper_0);
			if (Messages.Count == 1)
			{
				ResetTimer();
			}
			break;
		}
		while (!(messageWrapper_0 == current));
	}

	public void ResetTimer()
	{
		Progress = 0.0;
		CreationDate = DateTime.Now;
		Expiration = CreationDate.AddSeconds(Lifetime);
	}

	internal bool InvokeStub()
	{
		return Anchor != null;
	}

	public void ReAttachToAnchor()
	{
		if (InvokeStub())
		{
			Position.Longitude = Anchor.GetLongitude();
			Position.Latitude = Anchor.GetLatitude();
			Anchor.AttachedBark = this;
		}
	}

	public void DetachFromAnchor()
	{
		if (InvokeStub())
		{
			Anchor.AttachedBark = null;
		}
	}

	public void Cycle()
	{
		DateTime now = DateTime.Now;
		if (DateTime.Compare(now, Expiration) <= 0)
		{
			if (Fades)
			{
				TimeSpan timeSpan = Expiration - CreationDate;
				Progress = (now - CreationDate).TotalSeconds / timeSpan.TotalSeconds;
				Color = Color.FromArgb((int)Math.Round(255.0 * (1.0 - Progress)), Color.R, Color.G, Color.B);
			}
		}
		else if (Messages.Count <= 1)
		{
			DetachFromAnchor();
			codeConsumer.Notification_Barks.Remove(this);
		}
		else
		{
			Messages.RemoveAt(0);
			ReAttachToAnchor();
			ResetTimer();
		}
	}
}
