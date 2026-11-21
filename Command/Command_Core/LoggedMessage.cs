using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class LoggedMessage : ScenarioObject
{
	public enum MessageType : byte
	{
		None = 0,
		NewContact = 1,
		ContactChange = 2,
		WeaponEndgame = 3,
		WeaponDamage = 4,
		AirOps = 5,
		UnitLost = 6,
		UnitDamage = 7,
		PointDefence = 8,
		UI = 9,
		WeaponLogic = 10,
		UnitAI = 11,
		EventEngine = 13,
		NewWeaponContact = 14,
		DockingOps = 15,
		SpecialMessage = 16,
		NewMineContact = 17,
		CommsIsolatedMessage = 18,
		NewAirContact = 19,
		NewSurfaceContact = 20,
		NewUnderwaterContact = 21,
		NewGroundContact = 22,
		UnguidedWeaponModifiers = 23,
		const_23 = 24,
		Debug = 25,
		UnitAIEmergency = 26
	}

	public class MessageSettings
	{
		public bool ShowOnMessageLog;

		public bool PopUp;

		public bool ShowBaloon;

		public bool bool_0;

		public MessageSettings(bool bool_1, bool bool_2, bool bool_3, bool bool_4)
		{
			ShowOnMessageLog = bool_1;
			PopUp = bool_2;
			ShowBaloon = bool_3;
			bool_0 = bool_4;
		}
	}

	public long Increment;

	public string Text;

	public DateTime Timestamp;

	public byte Level;

	public MessageType Type;

	public string ReporterID;

	public Side Side;

	public Geopoint_Struct? Location;

	public bool ProcessedByClient;

	public string Summary;

	public bool ForceMapRecentre;

	[ThreadStatic]
	private static StringBuilder creatorDic;

	public Color MessageColor
	{
		get
		{
			switch (Type)
			{
			case MessageType.ContactChange:
				return Color.Yellow;
			case MessageType.UnitLost:
				return Color.IndianRed;
			case MessageType.UnitDamage:
				return Color.OrangeRed;
			case MessageType.PointDefence:
				return Color.Gray;
			case MessageType.UnitAI:
				return Color.Gray;
			case MessageType.EventEngine:
				return Color.LightBlue;
			case MessageType.AirOps:
			case MessageType.DockingOps:
				return Color.LimeGreen;
			case MessageType.NewWeaponContact:
			case MessageType.NewMineContact:
				return Color.IndianRed;
			case MessageType.CommsIsolatedMessage:
				return Color.Gray;
			case MessageType.NewContact:
			case MessageType.NewAirContact:
			case MessageType.NewSurfaceContact:
			case MessageType.NewUnderwaterContact:
			case MessageType.NewGroundContact:
				return Color.Yellow;
			case MessageType.WeaponEndgame:
			case MessageType.WeaponDamage:
			case MessageType.WeaponLogic:
			case MessageType.UnguidedWeaponModifiers:
				return Color.LightGray;
			case MessageType.const_23:
				return Color.Gray;
			default:
				return Color.White;
			case MessageType.UnitAIEmergency:
				return Color.OrangeRed;
			}
		}
	}

	internal bool ExcludeClass()
	{
		MessageType type = Type;
		if ((int)(type - 1) > 1 && (int)(type - 19) > 3)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	public Font GetMessageFont(Font font_0)
	{
		switch (Type)
		{
		default:
			return new Font(font_0, FontStyle.Regular);
		case MessageType.WeaponEndgame:
		case MessageType.WeaponDamage:
		case MessageType.PointDefence:
		case MessageType.WeaponLogic:
		case MessageType.UnitAI:
		case MessageType.CommsIsolatedMessage:
		case MessageType.UnguidedWeaponModifiers:
		case MessageType.const_23:
			return new Font(font_0, FontStyle.Italic);
		}
	}

	public string ToXML()
	{
		try
		{
			if (creatorDic == null)
			{
				creatorDic = new StringBuilder();
			}
			else
			{
				creatorDic.Clear();
			}
			creatorDic.Append("<LM>");
			creatorDic.Append("<ID>").Append(ObjectID).Append("</ID>");
			creatorDic.Append("<Inc>").Append(Increment).Append("</Inc>");
			creatorDic.Append("<Text>").Append(SecurityElement.Escape(Text)).Append("</Text>");
			creatorDic.Append("<Summary>").Append(SecurityElement.Escape(Summary)).Append("</Summary>");
			creatorDic.Append("<TStamp>").Append(Timestamp.ToBinary()).Append("</TStamp>");
			if (Level != 0)
			{
				creatorDic.Append("<Level>").Append((int)Level).Append("</Level>");
			}
			creatorDic.Append("<Type>").Append((int)Type).Append("</Type>");
			if (!string.IsNullOrEmpty(ReporterID))
			{
				creatorDic.Append("<R_ID>").Append(ReporterID).Append("</R_ID>");
			}
			if (Side != null)
			{
				creatorDic.Append("<Side>").Append(Side.ObjectID).Append("</Side>");
			}
			if (Location.HasValue && (Location.Value.Latitude != 0.0 || Location.Value.Longitude != 0.0))
			{
				creatorDic.Append("<Loc>").Append(XmlConvert.ToString(Location.Value.Longitude)).Append("_")
					.Append(XmlConvert.ToString(Location.Value.Latitude))
					.Append("</Loc>");
			}
			creatorDic.Append("</LM>");
			return creatorDic.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101011", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			string empty = string.Empty;
			ProjectData.ClearProjectError();
			return empty;
		}
	}

	private LoggedMessage()
	{
	}

	public static LoggedMessage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			LoggedMessage loggedMessage = new LoggedMessage();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Text":
						loggedMessage.Text = xmlNode.InnerText;
						break;
					case "Inc":
					case "Increment":
						loggedMessage.Increment = Conversions.ToLong(xmlNode.InnerText);
						break;
					case "Level":
						loggedMessage.Level = Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Summary":
						loggedMessage.Summary = xmlNode.InnerText;
						break;
					case "ID":
						loggedMessage.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Side":
						if (concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							loggedMessage.Side = (Side)concurrentDictionary_0[xmlNode.InnerText];
							break;
						}
						return null;
					case "Location":
					case "Loc":
						if (xmlNode.ChildNodes.Count <= 1)
						{
							string[] array = xmlNode.InnerText.Split('_');
							loggedMessage.Location = new Geopoint_Struct(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
						}
						else
						{
							loggedMessage.Location = Geopoint_Struct.InsertInvocation(xmlNode, concurrentDictionary_0);
						}
						break;
					case "R_ID":
					case "ReporterID":
						loggedMessage.ReporterID = xmlNode.InnerText;
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							loggedMessage.Type = (MessageType)Conversions.ToByte(xmlNode.InnerText);
						}
						else
						{
							loggedMessage.Type = (MessageType)Enum.Parse(typeof(MessageType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "TStamp":
					case "TimeStamp":
						loggedMessage.Timestamp = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return loggedMessage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101012", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			LoggedMessage result = new LoggedMessage();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public LoggedMessage(long long_0, string string_0, string string_1, MessageType messageType_0, DateTime dateTime_0, string string_2, byte byte_0, Side side_0 = null, Geopoint_Struct? nullable_0 = null, bool bool_0 = false)
	{
		Increment = long_0;
		Text = string_0;
		Summary = string_1;
		Timestamp = dateTime_0;
		Level = byte_0;
		Type = messageType_0;
		ReporterID = string_2;
		Side = side_0;
		Location = nullable_0;
		ForceMapRecentre = bool_0;
	}
}
