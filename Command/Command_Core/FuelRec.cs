using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FuelRec : ScenarioObject
{
	public enum _FuelType : short
	{
		NoFuel = 1001,
		AviationFuel = 2001,
		DieselFuel = 3001,
		OilFuel = 3002,
		GasFuel = 3003,
		Gasoline = 3006,
		Battery = 4001,
		AirIndepedent = 4002,
		RocketFuel = 5001,
		TorpedoFuel = 5001,
		WeaponCoast = 5003
	}

	public int? DBID;

	public int MaxQuantity;

	public double _CurrentQuantity;

	public _FuelType FuelType;

	[ThreadStatic]
	private static StringBuilder _GlobalClient;

	public float PercentFull => (float)(_CurrentQuantity / (double)MaxQuantity);

	public float CurrentQuantity
	{
		get
		{
			return (float)_CurrentQuantity;
		}
		set
		{
			_CurrentQuantity = value;
		}
	}

	public string ToXML()
	{
		try
		{
			if (_GlobalClient == null)
			{
				_GlobalClient = new StringBuilder();
			}
			else
			{
				_GlobalClient.Clear();
			}
			_GlobalClient.Append("<FuelRec>");
			_GlobalClient.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (DBID.HasValue)
			{
				_GlobalClient.Append("<DBID>").Append(DBID).Append("</DBID>");
			}
			_GlobalClient.Append("<MQ>").Append(MaxQuantity.ToString()).Append("</MQ>");
			_GlobalClient.Append("<CQ>").Append(XmlConvert.ToString(CurrentQuantity)).Append("</CQ>");
			_GlobalClient.Append("<FT>").Append((int)FuelType).Append("</FT>");
			_GlobalClient.Append("</FuelRec>");
			return _GlobalClient.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101005", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static FuelRec FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		FuelRec result = null;
		try
		{
			FuelRec fuelRec = new FuelRec();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "MQ":
					case "MaxQuantity":
						fuelRec.MaxQuantity = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						fuelRec.ObjectID_Set(xmlNode.InnerText);
						break;
					case "FuelType":
					case "FT":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							fuelRec.FuelType = (_FuelType)Conversions.ToShort(xmlNode.InnerText);
						}
						else
						{
							fuelRec.FuelType = (_FuelType)Enum.Parse(typeof(_FuelType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "CQ":
					case "CurrentQuantity":
						fuelRec.CurrentQuantity = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "DBID":
						fuelRec.DBID = Conversions.ToInteger(xmlNode.InnerText);
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
			result = fuelRec;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101006", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private FuelRec()
	{
	}

	public FuelRec(int int_0, short short_0)
	{
		MaxQuantity = int_0;
		CurrentQuantity = int_0;
		FuelType = (_FuelType)short_0;
	}

	public void SubtractFuel(float float_0)
	{
		_CurrentQuantity -= float_0;
		if (_CurrentQuantity < -3.4028234663852886E+38)
		{
			_CurrentQuantity = -3.4028234663852886E+38;
		}
	}

	public void AddFuel(float float_0)
	{
		_CurrentQuantity += float_0;
		if (_CurrentQuantity > 3.4028234663852886E+38)
		{
			_CurrentQuantity = 3.4028234663852886E+38;
		}
	}
}
