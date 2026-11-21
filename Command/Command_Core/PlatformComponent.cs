using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class PlatformComponent : ScenarioObject
{
	public delegate void StatusChangedEventHandler(PlatformComponent theComponent);

	public enum _ComponentStatus : byte
	{
		Operational,
		Damaged,
		Destroyed
	}

	public enum _DamageSeverityFactor : byte
	{
		Light,
		Medium,
		Heavy
	}

	public class _Coverage
	{
		public bool PS1;

		public bool PMA1;

		public bool PMF1;

		public bool PB1;

		public bool SS1;

		public bool SMA1;

		public bool SMF1;

		public bool SB1;

		public bool PS2;

		public bool PMA2;

		public bool PMF2;

		public bool PB2;

		public bool SS2;

		public bool SMA2;

		public bool SMF2;

		public bool SB2;

		public const int NUM_COVERAGE_ARCS = 16;

		[ThreadStatic]
		private static StringBuilder serverItem;

		public bool HasDefinedArcs
		{
			get
			{
				if (!PB1 && !PB2 && !PMA1 && !PMA2 && !PMF1 && !PMF2 && !PS1 && !PS2 && !SB1 && !SB2 && !SMA1 && !SMA2 && !SMF1 && !SMF2 && !SS1)
				{
					return SS2;
				}
				return true;
			}
		}

		public _Coverage Clone()
		{
			return (_Coverage)MemberwiseClone();
		}

		public string ToXML(bool bool_0)
		{
			try
			{
				if (serverItem == null)
				{
					serverItem = new StringBuilder();
				}
				else
				{
					serverItem.Clear();
				}
				if (bool_0)
				{
					serverItem.Append("<Cov_Ill>");
				}
				else
				{
					serverItem.Append("<Cov>");
				}
				if (Has360Coverage())
				{
					serverItem.Append("<Seg>360</Seg>");
				}
				else
				{
					serverItem.Append("<Seg>");
					if (PB1)
					{
						serverItem.Append("PB1,");
					}
					if (PB2)
					{
						serverItem.Append("PB2,");
					}
					if (PMA1)
					{
						serverItem.Append("PMA1,");
					}
					if (PMA2)
					{
						serverItem.Append("PMA2,");
					}
					if (PMF1)
					{
						serverItem.Append("PMF1,");
					}
					if (PMF2)
					{
						serverItem.Append("PMF2,");
					}
					if (PS1)
					{
						serverItem.Append("PS1,");
					}
					if (PS2)
					{
						serverItem.Append("PS2,");
					}
					if (SB1)
					{
						serverItem.Append("SB1,");
					}
					if (SB2)
					{
						serverItem.Append("SB2,");
					}
					if (SMA1)
					{
						serverItem.Append("SMA1,");
					}
					if (SMA2)
					{
						serverItem.Append("SMA2,");
					}
					if (SMF1)
					{
						serverItem.Append("SMF1,");
					}
					if (SMF2)
					{
						serverItem.Append("SMF2,");
					}
					if (SS1)
					{
						serverItem.Append("SS1,");
					}
					if (SS2)
					{
						serverItem.Append("SS2,");
					}
					serverItem.Append("</Seg>");
				}
				if (bool_0)
				{
					serverItem.Append("</Cov_Ill>");
				}
				else
				{
					serverItem.Append("</Cov>");
				}
				return serverItem.ToString();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 104985609568943068", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}

		public static _Coverage FromXML(ref XmlNode xmlNode_0)
		{
			_Coverage result = null;
			try
			{
				_Coverage coverage = new _Coverage();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "StarboardMiddleForward":
							coverage.SMF1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.SMF2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "PortStern":
							coverage.PS1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.PS2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "PortMiddleForward":
							coverage.PMF1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.PMF2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "StarboardStern":
							coverage.SS1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.SS2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "Seg":
						case "Segments":
						{
							string[] array = xmlNode.InnerText.Split(',');
							string[] array2 = array;
							foreach (string text in array2)
							{
								if (!string.IsNullOrEmpty(text))
								{
									switch (text.Trim())
									{
									case "PMF1":
										coverage.PMF1 = true;
										continue;
									case "PS2":
										coverage.PS2 = true;
										continue;
									case "PMA1":
										coverage.PMA1 = true;
										continue;
									case "PMF2":
										coverage.PMF2 = true;
										continue;
									case "SS2":
										coverage.SS2 = true;
										continue;
									case "PMA2":
										coverage.PMA2 = true;
										continue;
									case "PB2":
										coverage.PB2 = true;
										continue;
									case "SS1":
										coverage.SS1 = true;
										continue;
									case "SMF1":
										coverage.SMF1 = true;
										continue;
									case "PB1":
										coverage.PB1 = true;
										continue;
									case "SMA1":
										coverage.SMA1 = true;
										continue;
									case "SMF2":
										coverage.SMF2 = true;
										continue;
									case "SMA2":
										coverage.SMA2 = true;
										continue;
									case "PS1":
										coverage.PS1 = true;
										continue;
									case "SB2":
										coverage.SB2 = true;
										continue;
									case "SB1":
										coverage.SB1 = true;
										continue;
									case "360":
										break;
									default:
										continue;
									}
									coverage.PB1 = true;
									coverage.PMA1 = true;
									coverage.PMF1 = true;
									coverage.PS1 = true;
									coverage.SB1 = true;
									coverage.SMA1 = true;
									coverage.SMF1 = true;
									coverage.SS1 = true;
									coverage.PB2 = true;
									coverage.PMA2 = true;
									coverage.PMF2 = true;
									coverage.PS2 = true;
									coverage.SB2 = true;
									coverage.SMA2 = true;
									coverage.SMF2 = true;
									coverage.SS2 = true;
									break;
								}
							}
							break;
						}
						case "PortBow":
							coverage.PB1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.PB2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "StarboardBow":
							coverage.SB1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.SB2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "StarboardMiddleAft":
							coverage.SMA1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.SMA2 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "PortMiddleAft":
							coverage.PMA1 = Conversions.ToBoolean(xmlNode.InnerText);
							coverage.PMA2 = Conversions.ToBoolean(xmlNode.InnerText);
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
				result = coverage;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100688", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public bool Has360Coverage()
		{
			if (PB1 && PB2 && PMA1 && PMA2 && PMF1 && PMF2 && PS1 && PS2 && SB1 && SB2 && SMA1 && SMA2 && SMF1 && SMF2 && SS1)
			{
				return SS2;
			}
			return false;
		}

		public void ComponentArcString(ref PlatformComponent platformComponent_0, ref List<string> list_0)
		{
			if (Has360Coverage())
			{
				list_0.Add("360");
				return;
			}
			if (PB1)
			{
				list_0.Add("PB1");
			}
			if (PB2)
			{
				list_0.Add("PB2");
			}
			if (PMA1)
			{
				list_0.Add("PMA1");
			}
			if (PMA2)
			{
				list_0.Add("PMA2");
			}
			if (PMF1)
			{
				list_0.Add("PMF1");
			}
			if (PMF2)
			{
				list_0.Add("PMF2");
			}
			if (PS1)
			{
				list_0.Add("PS1");
			}
			if (PS2)
			{
				list_0.Add("PS2");
			}
			if (SB1)
			{
				list_0.Add("SB1");
			}
			if (SB2)
			{
				list_0.Add("SB2");
			}
			if (SMA1)
			{
				list_0.Add("SMA1");
			}
			if (SMA2)
			{
				list_0.Add("SMA2");
			}
			if (SMF1)
			{
				list_0.Add("SMF1");
			}
			if (SMF2)
			{
				list_0.Add("SMF2");
			}
			if (SS1)
			{
				list_0.Add("SS1");
			}
			if (SS2)
			{
				list_0.Add("SS2");
			}
		}

		internal int LoginInterruptibleReg(int int_0, bool bool_0)
		{
			int num = int_0;
			if (bool_0)
			{
				num++;
				if (num >= 16)
				{
					num = 16 - num;
				}
			}
			else
			{
				num--;
				if (num < 0)
				{
					num += 16;
				}
			}
			return num;
		}

		internal bool GetInterruptibleReg(int int_0)
		{
			if (1 == 0)
			{
			}
			bool result = int_0 switch
			{
				0 => SB1, 
				1 => SB2, 
				2 => SMF1, 
				3 => SMF2, 
				4 => SMA1, 
				5 => SMA2, 
				6 => SS1, 
				7 => SS2, 
				8 => PS1, 
				9 => PS2, 
				10 => PMA1, 
				11 => PMA2, 
				12 => PMF1, 
				13 => PMF2, 
				14 => PB1, 
				15 => PB2, 
				_ => false, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	protected _ComponentStatus _Status;

	protected ActiveUnit _ParentPlatform;

	private _DamageSeverityFactor _HelperConsumer;

	public _Coverage Coverage;

	public int DBID;

	[CompilerGenerated]
	private static StatusChangedEventHandler mapperConsumer;

	public bool IsMount => (object)GetType() == typeof(Mount);

	public bool IsMagazine => (object)GetType() == typeof(Magazine);

	public bool IsSensor => (object)GetType() == typeof(Sensor);

	public bool IsAirFacility => (object)GetType() == typeof(AirFacility);

	public bool IsDockFacility => (object)GetType() == typeof(DockFacility);

	public bool IsCommDevice => (object)GetType() == typeof(CommDevice);

	public bool IsEngine => (object)GetType() == typeof(Engine);

	public bool IsCargo => (object)GetType() == typeof(Cargo);

	public bool IsCIC => (object)GetType() == typeof(CIC);

	public _DamageSeverityFactor DamageSeverity
	{
		get
		{
			return _HelperConsumer;
		}
		set
		{
			_HelperConsumer = value;
		}
	}

	public ActiveUnit ParentPlatform
	{
		get
		{
			return _ParentPlatform;
		}
		set
		{
			_ParentPlatform = value;
		}
	}

	public virtual string ReasonForInoperative => "None";

	public virtual _ComponentStatus Status => _Status;

	public static event StatusChangedEventHandler StatusChanged
	{
		[CompilerGenerated]
		add
		{
			StatusChangedEventHandler statusChangedEventHandler = mapperConsumer;
			StatusChangedEventHandler statusChangedEventHandler2;
			do
			{
				statusChangedEventHandler2 = statusChangedEventHandler;
				StatusChangedEventHandler value2 = (StatusChangedEventHandler)Delegate.Combine(statusChangedEventHandler2, value);
				statusChangedEventHandler = Interlocked.CompareExchange(ref mapperConsumer, value2, statusChangedEventHandler2);
			}
			while ((object)statusChangedEventHandler != statusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			StatusChangedEventHandler statusChangedEventHandler = mapperConsumer;
			StatusChangedEventHandler statusChangedEventHandler2;
			do
			{
				statusChangedEventHandler2 = statusChangedEventHandler;
				StatusChangedEventHandler value2 = (StatusChangedEventHandler)Delegate.Remove(statusChangedEventHandler2, value);
				statusChangedEventHandler = Interlocked.CompareExchange(ref mapperConsumer, value2, statusChangedEventHandler2);
			}
			while ((object)statusChangedEventHandler != statusChangedEventHandler2);
		}
	}

	protected PlatformComponent()
	{
		Coverage = new _Coverage();
	}

	public bool GetCoverageArc(float float_0, ref float float_1, ref float float_2)
	{
		int num = -1;
		int num2 = -1;
		float_1 = 0f;
		float_2 = 0f;
		if (Coverage.Has360Coverage())
		{
			float_1 = 0f;
			float_2 = 360f;
			return true;
		}
		int num3 = (int)Conversion.Int(float_0 / 22.5f);
		if (float_0 % 22.5f == 0f && !Coverage.GetInterruptibleReg(num3))
		{
			num3 = Coverage.LoginInterruptibleReg(num3, bool_0: false);
		}
		if (Coverage.GetInterruptibleReg(num3))
		{
			bool flag = true;
			int num4 = num3;
			num = num4;
			while (flag)
			{
				if (flag)
				{
					num4 = Coverage.LoginInterruptibleReg(num4, bool_0: false);
					flag = Coverage.GetInterruptibleReg(num4);
				}
			}
			num = num4 + 1;
			flag = true;
			num4 = num3;
			num2 = num3;
			while (flag)
			{
				if (flag)
				{
					num4 = Coverage.LoginInterruptibleReg(num4, bool_0: true);
					flag = Coverage.GetInterruptibleReg(num4);
				}
			}
			num2 = num4;
			float_1 = (float)num * 22.5f;
			if (float_1 >= 180f)
			{
				float_1 -= 360f;
			}
			float_2 = (float)num2 * 22.5f;
			if (float_1 < 0f && float_2 >= 180f)
			{
				float_2 -= 360f;
			}
			return true;
		}
		return false;
	}

	public static List<RangeSymbol> RangeWedges_GetArcs(Geopoint_Struct geopoint_Struct_0, PlatformComponent platformComponent_0, float float_0)
	{
		List<RangeSymbol> list = new List<RangeSymbol>();
		bool flag = false;
		Color color_ = default(Color);
		_Coverage coverage = platformComponent_0.Coverage;
		RangeSymbol rangeSymbol = null;
		if (platformComponent_0.IsSensor)
		{
			Sensor sensor = (Sensor)platformComponent_0;
			if (sensor.StopWriter())
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, string.Empty, sensor.maxRange, (float)((double)(-sensor.TestWriter()) / 2.0), (float)((double)sensor.TestWriter() / 2.0), color_);
				list.Add(rangeSymbol);
				return list;
			}
			if (sensor.SemiActiveWeaponsGuided.Count > 0)
			{
				coverage = sensor.Coverage_Illuminate;
			}
		}
		if (coverage.SB1)
		{
			flag = true;
			rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 0f, 22.5f, color_);
		}
		if (coverage.SB2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 45f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 22.5f, 45f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.SMF1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 67.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 45f, 67.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.SMF2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 90f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 67.5f, 90f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.SMA1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 112.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 90f, 112.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.SMA2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 135f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 112.5f, 135f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.SS1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 157.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 135f, 157.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.SS2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 180f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 157.5f, 180f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PS1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 202.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 180f, 202.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PS2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 225f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 202.5f, 225f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PMA1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 247.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 225f, 247.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PMA2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 270f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 247.5f, 270f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PMF1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 292.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 270f, 292.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PMF2)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 315f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 292.5f, 315f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PB1)
		{
			if (flag)
			{
				rangeSymbol.RightArc = 337.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 315f, 337.5f, color_);
				flag = true;
			}
		}
		else if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		if (coverage.PB2)
		{
			if (flag)
			{
				if (coverage.SB1)
				{
					if (list.Count <= 0)
					{
						list.Add(rangeSymbol);
						list[0].RightArc = 360f;
						flag = false;
					}
					else
					{
						list[0].LeftArc = 1f;
						list[0].LeftArc = rangeSymbol.LeftArc;
						flag = false;
					}
				}
				else
				{
					rangeSymbol.RightArc = 0f;
				}
			}
			else if (coverage.SB1)
			{
				list[0].LeftArc = 337.5f;
			}
			else
			{
				rangeSymbol = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", float_0, 337.5f, 0f, color_);
				flag = true;
			}
		}
		if (flag)
		{
			list.Add(rangeSymbol);
			flag = false;
		}
		return list;
	}

	public virtual bool TargetIsWithinCoverageArc(Module_Unit.Unit unit_0, float? nullable_0 = null)
	{
		bool result = false;
		try
		{
			if (Coverage.Has360Coverage())
			{
				result = true;
				return true;
			}
			if (ParentPlatform == null)
			{
				result = false;
				return false;
			}
			double num = (nullable_0.HasValue ? ((double)nullable_0.Value) : ((double)ParentPlatform.CurrentHeading));
			double num2 = Math2.DisableClass((double)Math2.PublishClass(ParentPlatform.GetLatitude(true), ParentPlatform.GetLongitude(true), unit_0.GetLatitude(true), unit_0.GetLongitude(true)) - num);
			num = 0.0;
			double num3 = num2;
			if (num3 <= 22.5)
			{
				return result = Coverage.SB1;
			}
			if (num3 <= 45.0)
			{
				return result = Coverage.SB2;
			}
			if (num3 <= 67.5)
			{
				return result = Coverage.SMF1;
			}
			if (num3 <= 90.0)
			{
				return result = Coverage.SMF2;
			}
			if (num3 <= 112.5)
			{
				return result = Coverage.SMA1;
			}
			if (num3 <= 135.0)
			{
				return result = Coverage.SMA2;
			}
			if (num3 <= 157.5)
			{
				return result = Coverage.SS1;
			}
			if (num3 <= 180.0)
			{
				return result = Coverage.SS2;
			}
			if (num3 <= 202.5)
			{
				return result = Coverage.PS1;
			}
			if (num3 <= 225.0)
			{
				return result = Coverage.PS2;
			}
			if (num3 <= 247.5)
			{
				return result = Coverage.PMA1;
			}
			if (num3 <= 270.0)
			{
				return result = Coverage.PMA2;
			}
			if (num3 <= 292.5)
			{
				return result = Coverage.PMF1;
			}
			if (num3 <= 315.0)
			{
				return result = Coverage.PMF2;
			}
			if (num3 <= 337.5)
			{
				return result = Coverage.PB1;
			}
			return result = Coverage.PB2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100685", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public PlatformComponent(ActiveUnit activeUnit_0)
	{
		Coverage = new _Coverage();
		ParentPlatform = activeUnit_0;
	}

	public void RaiseEventStatusChanged()
	{
		mapperConsumer?.Invoke(this);
	}

	public virtual void Destroy(Side side_0, bool bool_0, bool bool_1)
	{
		try
		{
			_Status = _ComponentStatus.Destroyed;
			if (!Information.IsNothing(ParentPlatform) && ParentPlatform.IsFacility && !ParentPlatform.IsDestroyed && ((Facility)ParentPlatform).HasAimpoints && !bool_0 && !Information.IsNothing(ParentPlatform.Mounts) && ParentPlatform.Mounts.Where((Mount theM) => !Information.IsNothing(theM) && theM.Status == _ComponentStatus.Destroyed).Count() == ParentPlatform.Mounts.Count && !Information.IsNothing(ParentPlatform.ParentScen))
			{
				ParentPlatform.ParentScen.DestroyThisUnit(ParentPlatform, "all aimpoints of parent are gone! The entire facility is destroyed", "Weapon Interaction");
			}
			mapperConsumer?.Invoke(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100686", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Repair()
	{
		_Status = _ComponentStatus.Operational;
		mapperConsumer?.Invoke(this);
	}

	public virtual void Damage(_DamageSeverityFactor _DamageSeverityFactor_0)
	{
		_Status = _ComponentStatus.Damaged;
		_HelperConsumer = _DamageSeverityFactor_0;
		mapperConsumer?.Invoke(this);
	}

	public void MakeOperational(bool bool_0)
	{
		_Status = _ComponentStatus.Operational;
		if (bool_0 && (object)GetType() == typeof(AirFacility))
		{
			GameGeneral.ResolveBridge("跑道或跑道有效承载飞机的能力取决于其母平台的完整性，即持续受损的程度。将部件设置为可操作不会改善飞机的容量。", ParentPlatform.GetUnitSide());
		}
		mapperConsumer?.Invoke(this);
	}

	public virtual void vmethod_0(float float_0)
	{
	}

	public virtual void ResolveDamageFromDazzler(float float_0)
	{
	}
}
