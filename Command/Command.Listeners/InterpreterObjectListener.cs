using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Efundies;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeControls;

namespace Command.Listeners;

[StandardModule]
internal sealed class InterpreterObjectListener
{
	public static DrawArgs _UtilsResolver;

	public static bool _PredicateResolver;

	public static bool singletonResolver;

	public static bool m_RecordResolver;

	public static bool _ExceptionResolver;

	public static bool attrResolver;

	public const int m_VisitorResolver = 1;

	public static object exporterResolver;

	static InterpreterObjectListener()
	{
		_PredicateResolver = true;
		singletonResolver = true;
		m_RecordResolver = true;
		_ExceptionResolver = true;
		attrResolver = true;
	}

	[DllImport("user32.dll")]
	public static extern bool ShowScrollBar(IntPtr intptr_0, int int_0, bool bool_0);

	public static Bitmap RestartInterruptibleTask(object object_0, float float_0)
	{
		if (float_0 == 1f)
		{
			return (Bitmap)object_0;
		}
		if (Client.objectRequest.TryGetValue((Image)object_0, out var value))
		{
			return (Bitmap)value;
		}
		Bitmap bitmap = new Bitmap(((Image)object_0).Width, ((Image)object_0).Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		ColorMatrix newColorMatrix = new ColorMatrix
		{
			Matrix33 = float_0
		};
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		graphics.DrawImage((Image)object_0, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, ((Image)object_0).Width, ((Image)object_0).Height, GraphicsUnit.Pixel, imageAttributes);
		graphics.Dispose();
		Client.objectRequest.Add((Image)object_0, bitmap);
		return bitmap;
	}

	public static string TestInterruptibleTask(string string_0)
	{
		return Misc.SearchRequest(string_0);
	}

	public static Bitmap StopInterruptibleTask(string string_0, object object_0, float float_0)
	{
		return CancelInterruptibleTask(string_0, object_0, float_0);
	}

	private static Bitmap CancelInterruptibleTask(string string_0, object object_0, float float_0)
	{
		if ((int)Math.Round(float_0) == 0)
		{
			return (Bitmap)object_0;
		}
		if (object_0 == null)
		{
			return null;
		}
		Image value = null;
		Client._InstanceRequest.TryGetValue(string_0 + Conversions.ToString((int)Math.Round(float_0)), out value);
		if (Information.IsNothing(value))
		{
			Bitmap bitmap = new Bitmap(((Image)object_0).Width, ((Image)object_0).Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.TranslateTransform((float)((Image)object_0).Width / 2f, (float)((Image)object_0).Height / 2f);
			graphics.RotateTransform((int)Math.Round(float_0));
			graphics.TranslateTransform((0f - (float)((Image)object_0).Width) / 2f, (0f - (float)((Image)object_0).Height) / 2f);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.DrawImage((Image)object_0, new Point(0, 0));
			value = bitmap;
			Client._InstanceRequest.Add(string_0 + Conversions.ToString((int)Math.Round(float_0)), value);
		}
		return (Bitmap)value;
	}

	public static void VerifyInterruptibleTask(Control control_0)
	{
		Point p = new Point((int)Math.Round((double)(control_0.Left + control_0.Right) / 2.0), (int)Math.Round((double)(control_0.Top + control_0.Bottom) / 2.0));
		ItemExporter.ConnectInterruptibleTemplate.MainForm.CurrentMousePosition.X = p.X;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.CurrentMousePosition.Y = p.Y;
		Cursor.Position = control_0.Parent.PointToScreen(p);
	}

	public static Bitmap ListInterruptibleTask(Image image_0, Size size_0, bool bool_0 = true)
	{
		int num = 0;
		if (image_0.Width == 0 && num == image_0.Height)
		{
			return (Bitmap)image_0;
		}
		if (Client.parameterRequest.TryGetValue(image_0, out var value))
		{
			return (Bitmap)value;
		}
		int width2;
		if (bool_0)
		{
			int width = image_0.Width;
			int height = image_0.Height;
			float num2 = (float)size_0.Width / (float)width;
			float num3 = (float)size_0.Height / (float)height;
			float num4 = ((num3 < num2) ? num3 : num2);
			width2 = (int)Math.Round((float)width * num4);
			num = (int)Math.Round((float)height * num4);
		}
		else
		{
			width2 = size_0.Width;
			num = size_0.Height;
		}
		Bitmap bitmap = new Bitmap(width2, num);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(image_0, 0, 0, width2, num);
		}
		Client.parameterRequest.Add(image_0, bitmap);
		return bitmap;
	}

	public static ReadOnlyCollection<TreeNode> ResolveInterruptibleTask(TreeView treeView_0)
	{
		List<TreeNode> list = new List<TreeNode>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = treeView_0.Nodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TreeNode treeNode = (TreeNode)enumerator.Current;
				if (!list.Contains(treeNode))
				{
					list.Add(treeNode);
				}
				MapInterruptibleTask(treeNode, list);
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		return list.AsReadOnly();
	}

	public static void PostInterruptibleTask(DarkTreeView darkTreeView_0)
	{
		foreach (DarkTreeNode item in PrintInterruptibleTask(darkTreeView_0))
		{
			item.Expanded = true;
		}
	}

	public static void RunInterruptibleTask(DarkFilterTreeView darkFilterTreeView_0)
	{
		foreach (DarkFilterTreeNode item in DefineInterruptibleTask(darkFilterTreeView_0))
		{
			item.Expanded = true;
		}
	}

	public static void StartInterruptibleTask(DarkTreeView darkTreeView_0)
	{
		foreach (DarkTreeNode item in PrintInterruptibleTask(darkTreeView_0))
		{
			item.Expanded = false;
		}
	}

	public static void AssetInterruptibleTask(DarkFilterTreeView darkFilterTreeView_0)
	{
		foreach (DarkFilterTreeNode item in DefineInterruptibleTask(darkFilterTreeView_0))
		{
			item.Expanded = false;
		}
	}

	public static ReadOnlyCollection<DarkTreeNode> PrintInterruptibleTask(DarkTreeView darkTreeView_0)
	{
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node in darkTreeView_0.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			SortInterruptibleTask(node, list);
		}
		return list.AsReadOnly();
	}

	public static ReadOnlyCollection<DarkFilterTreeNode> DefineInterruptibleTask(DarkFilterTreeView darkFilterTreeView_0)
	{
		List<DarkFilterTreeNode> list = new List<DarkFilterTreeNode>();
		foreach (DarkFilterTreeNode node in darkFilterTreeView_0.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			CalcInterruptibleTask(node, list);
		}
		return list.AsReadOnly();
	}

	public static ReadOnlyCollection<ThreadSafeTreeNode> PublishInterruptibleTask(ThreadSafeTreeView threadSafeTreeView_0)
	{
		List<ThreadSafeTreeNode> list = new List<ThreadSafeTreeNode>();
		foreach (ThreadSafeTreeNode node in threadSafeTreeView_0.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			RateInterruptibleTask(node, list);
		}
		return list.AsReadOnly();
	}

	public static void AwakeInterruptibleTask(object object_0, string string_0)
	{
		try
		{
			if (!((Control)object_0).IsDisposed)
			{
				string_0 = "<style>\r\n                        body\r\n                            {\r\n                            background:#333333;\r\n                            color:Lightgrey;\r\n                            scrollbar-face-color: #696969;\r\n                            scrollbar-highlight-color: #696969;\r\n                            scrollbar-3dlight-color: #696969;\r\n                            scrollbar-darkshadow-color: #696969;\r\n                            scrollbar-shadow-color: #696969;\r\n                            scrollbar-arrow-color: #696969;\r\n                            scrollbar-track-color: #333333;\r\n                            }\r\n                        hr\r\n                            {\r\n                            border-color:Lightgrey; \r\n                            background-color:Lightgrey\r\n                            }\r\n                        </style><FONT face=Calibri>" + string_0 + "<FONT>";
				((WebBrowser)object_0).DocumentText = string_0;
				((WebBrowser)object_0).Document.BackColor = Color.Black;
				((WebBrowser)object_0).Document.Write(string_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200101", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit QueryInterruptibleTask(object object_0, List<ActiveUnit> list_0)
	{
		return null;
	}

	public static string ResetInterruptibleTask(string string_0, string string_1)
	{
		string directoryName = Path.GetDirectoryName(string_1);
		string_0 = string_0.Replace("src=\\\"", "src=\\\"" + directoryName + Conversions.ToString(Path.PathSeparator));
		return string_0;
	}

	private static void MapInterruptibleTask(TreeNode treeNode_0, List<TreeNode> list_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = treeNode_0.Nodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TreeNode treeNode = (TreeNode)enumerator.Current;
				if (!list_0.Contains(treeNode))
				{
					list_0.Add(treeNode);
				}
				MapInterruptibleTask(treeNode, list_0);
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	private static void SortInterruptibleTask(DarkTreeNode darkTreeNode_0, List<DarkTreeNode> list_0)
	{
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			SortInterruptibleTask(node, list_0);
		}
	}

	private static void CalcInterruptibleTask(DarkFilterTreeNode darkFilterTreeNode_0, List<DarkFilterTreeNode> list_0)
	{
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			CalcInterruptibleTask(node, list_0);
		}
	}

	private static void RateInterruptibleTask(ThreadSafeTreeNode threadSafeTreeNode_0, List<ThreadSafeTreeNode> list_0)
	{
		foreach (ThreadSafeTreeNode node in threadSafeTreeNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			RateInterruptibleTask(node, list_0);
		}
	}

	public static ReadOnlyCollection<TreeGridNode> FlushInterruptibleTask(TreeGridView treeGridView_0)
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in treeGridView_0.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			ForgotInterruptibleTask(node, list);
		}
		return list.AsReadOnly();
	}

	private static void ForgotInterruptibleTask(TreeGridNode treeGridNode_0, List<TreeGridNode> list_0)
	{
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			ForgotInterruptibleTask(node, list_0);
		}
	}

	public static bool CollectInterruptibleTask(ScenarioObject activityunit)
	{
		try
		{
			if (string.IsNullOrEmpty(Client.CurrentMapProfile.String_0))
			{
				return false;
			}
			return Operators.CompareString(activityunit.ObjectID, Client.CurrentMapProfile.String_0, TextCompare: true) == 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void OrderInterruptibleTask(object object_0, bool bool_0 = true)
	{
		((Control)object_0).SuspendLayout();
		((Form)object_0).WindowState = FormWindowState.Normal;
		((Form)object_0).FormBorderStyle = FormBorderStyle.None;
		((Form)object_0).WindowState = FormWindowState.Maximized;
		if (object_0 == ItemExporter.ConnectInterruptibleTemplate.databaseTemplate && bool_0)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Slide_RC_In();
		}
		((Control)object_0).ResumeLayout();
	}

	public static void RegisterInterruptibleTask(object object_0)
	{
		((Control)object_0).SuspendLayout();
		((Form)object_0).FormBorderStyle = FormBorderStyle.Sizable;
		((Form)object_0).WindowState = FormWindowState.Maximized;
		((Control)object_0).ResumeLayout();
	}

	public static string ManageInterruptibleTask()
	{
		string result = "";
		foreach (ManagementObject instance in new ManagementClass("Win32_OperatingSystem").GetInstances())
		{
			result = (string)instance.GetPropertyValue("Version");
		}
		return result;
	}

	public static void RevertInterruptibleTask(ref Bitmap bitmap_0, Color color_0, Color color_1)
	{
		LockBitmap lockBitmap = new LockBitmap(bitmap_0);
		lockBitmap.LockBits();
		int depth = lockBitmap.Depth;
		byte[] pixels = lockBitmap.Pixels;
		int num = lockBitmap.Height - 1;
		for (int i = 0; i <= num; i++)
		{
			int num2 = lockBitmap.Width - 1;
			for (int j = 0; j <= num2; j++)
			{
				Color pixel = lockBitmap.GetPixel(j, i, depth, pixels);
				if (pixel.A == color_0.A && pixel.R == color_0.R && pixel.G == color_0.G && pixel.B == color_0.B)
				{
					lockBitmap.SetPixel(j, i, color_1);
				}
			}
		}
		lockBitmap.UnlockBits();
	}

	public static void CountInterruptibleFilter(Control control_0)
	{
		try
		{
			int num = Conversions.ToInteger(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LogPixels", null));
			if (num <= 0)
			{
				if (Client._StateClass == 0f)
				{
					num = Conversions.ToInteger(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI", "LogPixels", null));
					if (num > 0)
					{
						Client._StateClass = (float)((double)num / 96.0);
						if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
						{
							GameGeneral.WriteLogDebugInfoToFile("DPI registry setting, HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI\\LogPixels:" + Conversions.ToString(num) + ".");
						}
						return;
					}
				}
				if (Client._StateClass == 0f)
				{
					num = Conversions.ToInteger(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI", "LogPixels", null));
					if (num > 0)
					{
						Client._StateClass = (float)((double)num / 96.0);
						if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
						{
							GameGeneral.WriteLogDebugInfoToFile("DPI registry setting, HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI\\LogPixels:" + Conversions.ToString(num) + ".");
						}
						return;
					}
				}
				if (Client._StateClass == 0f)
				{
					using (Graphics graphics = control_0.CreateGraphics())
					{
						Client._StateClass = graphics.DpiX / 96f;
					}
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("DPI缩放：" + Conversions.ToString(Client._StateClass) + ".");
					}
				}
			}
			else
			{
				Client._StateClass = (float)((double)num / 96.0);
				if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
				{
					GameGeneral.WriteLogDebugInfoToFile("DPI registry setting, HKEY_CURRENT_USER\\Control Panel\\Desktop\\LogPixels:" + Conversions.ToString(num) + ".");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 219354783495687", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
