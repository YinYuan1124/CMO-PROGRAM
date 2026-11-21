using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class Notification
{
	public string Description;

	public string Title;

	public NotificationType Type;

	public DateTime TimeStamp;

	public float FadingTime;

	public int TransparencyCountDown;

	public List<string> ProcessedMultilines_Title;

	public List<string> ProcessedMultilines_Description;

	public int BoxWidth;

	public int HeightAllocatedByText;

	public int SidePadding;

	public Rectangle StringLengthTitle;

	public Rectangle StringLengthDescription;

	public float StringHeightTitle;

	public float StringHeightDescription;

	public int CharactersPerLineTitle;

	public int CharactersPerLineDescription;

	public Notification(string string_0, string string_1, NotificationType notificationType_0, float float_0 = 10f)
	{
		ProcessedMultilines_Title = new List<string>();
		ProcessedMultilines_Description = new List<string>();
		Description = string_1;
		Title = string_0;
		Type = notificationType_0;
		TransparencyCountDown = 200;
		FadingTime = float_0;
		TimeStamp = DateTime.Now;
	}

	public void ProcessMultilines(bool bool_0 = false)
	{
		if (ProcessedMultilines_Title.Count <= 0 || bool_0)
		{
			if (StringLengthTitle.IsEmpty && Operators.CompareString(Title, "", TextCompare: true) != 0)
			{
				StringLengthTitle = ItemExporter.ConnectInterruptibleTemplate.MainForm.GetCommandLayer().MeasureString(Color.White, 20, 20, Title, 0.0, 34);
				CharactersPerLineTitle = (int)Math.Round((double)Title.Length / ((double)StringLengthTitle.Width / (double)(BoxWidth - SidePadding * 3)));
			}
			if (StringLengthDescription.IsEmpty && Operators.CompareString(Description, "", TextCompare: true) != 0)
			{
				StringLengthDescription = ItemExporter.ConnectInterruptibleTemplate.MainForm.GetCommandLayer().MeasureString(Color.White, 20, 20, Description, 0.0, 30);
				CharactersPerLineDescription = (int)Math.Round((double)Description.Length / ((double)StringLengthDescription.Width / (double)(BoxWidth - SidePadding * 3)));
			}
			StringHeightTitle = StringLengthTitle.Height;
			StringHeightDescription = StringLengthDescription.Height;
			ProcessedMultilines_Title = Misc.CallValue(Title, CharactersPerLineTitle);
			ProcessedMultilines_Description = Misc.CallValue(Description, CharactersPerLineDescription);
			HeightAllocatedByText = StringLengthTitle.Height * ProcessedMultilines_Title.Count + StringLengthTitle.Height * ProcessedMultilines_Description.Count;
			if (Operators.CompareString(Description, "", TextCompare: true) != 0)
			{
				HeightAllocatedByText += StringLengthTitle.Height;
			}
		}
	}

	public bool HasExpired()
	{
		if (FadingTime == -1f)
		{
			return false;
		}
		if ((DateTime.Now - TimeStamp).TotalSeconds <= (double)FadingTime)
		{
			return false;
		}
		return true;
	}

	public static void DeleteNotification()
	{
		if (GlobalSingleton.GetInstance().NotificationContainer.Count != 0)
		{
			GlobalSingleton.GetInstance().NotificationContainer.RemoveAt(0);
		}
	}

	public static void AddNotification(string string_0, string string_1, NotificationType notificationType_0, float float_0 = 10f, bool bool_0 = true)
	{
		if (bool_0)
		{
			GlobalSingleton.GetInstance().NotificationContainer.Clear();
		}
		GlobalSingleton.GetInstance().NotificationContainer.Add(new Notification(string_0, string_1, notificationType_0, float_0));
	}

	public static Notification FetchNotification()
	{
		if (GlobalSingleton.GetInstance().NotificationContainer.Count == 0)
		{
			return null;
		}
		return GlobalSingleton.GetInstance().NotificationContainer[0];
	}

	public static VisualIndicator AddIndicator(Module_Unit.Unit unit_0, bool bool_0 = true, Color color_0 = default(Color))
	{
		return ItemExporter.ConnectInterruptibleTemplate.MainForm.AddNotificationIndicator(unit_0, bool_0, color_0);
	}

	public static VisualIndicator AddIndicator(Control control_0, Point point_0, Size size_0, VisualIndicatorDesign visualIndicatorDesign_0 = VisualIndicatorDesign.AnimatedCircle, Color color_0 = default(Color))
	{
		return ItemExporter.ConnectInterruptibleTemplate.MainForm.AddNotificationIndicator(control_0, point_0, size_0, visualIndicatorDesign_0, color_0);
	}

	public static VisualIndicator AddIndicator(Control control_0, ToolStrip toolStrip_0, VisualIndicatorDesign visualIndicatorDesign_0 = VisualIndicatorDesign.AnimatedCircle, Color color_0 = default(Color))
	{
		return ItemExporter.ConnectInterruptibleTemplate.MainForm.AddNotificationIndicator(control_0, toolStrip_0, visualIndicatorDesign_0, color_0);
	}

	public static VisualIndicator AddIndicator(Control control_0, Control control_1, bool bool_0, VisualIndicatorDesign visualIndicatorDesign_0 = VisualIndicatorDesign.AnimatedCircle, Color color_0 = default(Color), bool bool_1 = true)
	{
		return ItemExporter.ConnectInterruptibleTemplate.MainForm.AddNotificationIndicator(control_0, control_1, bool_0, visualIndicatorDesign_0, color_0, bool_1);
	}

	public static VisualIndicator AddIndicator(Control control_0, ToolStripItem toolStripItem_0, bool bool_0 = true, VisualIndicatorDesign visualIndicatorDesign_0 = VisualIndicatorDesign.AnimatedCircle, Color color_0 = default(Color), bool bool_1 = true)
	{
		return ItemExporter.ConnectInterruptibleTemplate.MainForm.AddNotificationIndicator(control_0, toolStripItem_0, bool_0, visualIndicatorDesign_0, color_0, bool_1);
	}

	public static void RemoveIndicator(VisualIndicator visualIndicator_0)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RemoveIndicator(visualIndicator_0);
	}

	public static void RemoveIndicator(List<VisualIndicator> list_0)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RemoveIndicator(list_0);
	}
}
