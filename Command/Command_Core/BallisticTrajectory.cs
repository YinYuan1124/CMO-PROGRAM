using System;
using System.Globalization;
using System.Xml;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticTrajectory
{
	public struct LatLonAlt
	{
		public double lat;

		public double lon;

		public double radius_km;

		public static implicit operator LatLonAlt(GeoPoint geoPoint_0)
		{
			LatLonAlt result = default(LatLonAlt);
			result.lat = geoPoint_0.Latitude * CSMath.PI_dividedBy_180;
			result.lon = geoPoint_0.Longitude * CSMath.PI_dividedBy_180;
			result.radius_km = (double)geoPoint_0.Altitude / 1000.0 + 6371.0;
			return result;
		}

		public static implicit operator LatLonAlt(Module_Unit.Unit unit_0)
		{
			LatLonAlt result = default(LatLonAlt);
			result.lat = unit_0.GetLatitude() * CSMath.PI_dividedBy_180;
			result.lon = unit_0.GetLongitude() * CSMath.PI_dividedBy_180;
			result.radius_km = (double)(unit_0.GetCurrentAltitude() / 1000f) + 6371.0;
			return result;
		}

		internal LatLonAlt PostInterruptibleTag(double double_0, double double_1)
		{
			double double_2 = Wrap(GetProperty(LoginProperty(lat) * ValidateProperty(double_1) + ValidateProperty(lat) * LoginProperty(double_1) * ValidateProperty(double_0)));
			LatLonAlt result = default(LatLonAlt);
			result.lat = double_2;
			result.lon = Wrap(lon + Math.Atan2(LoginProperty(double_0) * LoginProperty(double_1) * ValidateProperty(lat), ValidateProperty(double_1) - LoginProperty(lat) * LoginProperty(double_2)));
			result.radius_km = radius_km;
			return result;
		}

		public void ToXML(ref XmlWriter xmlWriter_0)
		{
			xmlWriter_0.WriteStartElement("LatLonAlt");
			xmlWriter_0.WriteElementString("lat", XmlConvert.ToString(lat));
			xmlWriter_0.WriteElementString("lon", XmlConvert.ToString(lon));
			xmlWriter_0.WriteElementString("radius_km", XmlConvert.ToString(radius_km));
			xmlWriter_0.WriteEndElement();
		}

		public static LatLonAlt FromXML(ref XmlNode xmlNode_0)
		{
			LatLonAlt result = default(LatLonAlt);
			result.lat = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "lat").InnerText, CultureInfo.InvariantCulture);
			result.lon = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "lon").InnerText, CultureInfo.InvariantCulture);
			result.radius_km = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "radius_km").InnerText, CultureInfo.InvariantCulture);
			return result;
		}
	}

	public struct Record
	{
		public double CurrentMeanAngularMotion_rad__s;

		public double Time_s;

		public double Radius_km;

		public double TA;

		public double MA;

		public byte Phase;

		public double Pitch;

		public void ToXML(ref XmlWriter xmlWriter_0)
		{
			xmlWriter_0.WriteStartElement("Record");
			xmlWriter_0.WriteElementString("CurrentMeanAngularMotion_rad__s", XmlConvert.ToString(CurrentMeanAngularMotion_rad__s));
			xmlWriter_0.WriteElementString("Time_s", XmlConvert.ToString(Time_s));
			xmlWriter_0.WriteElementString("Radius_km", XmlConvert.ToString(Radius_km));
			xmlWriter_0.WriteElementString("TA", XmlConvert.ToString(TA));
			xmlWriter_0.WriteElementString("MA", XmlConvert.ToString(MA));
			xmlWriter_0.WriteElementString("Phase", XmlConvert.ToString(Phase));
			xmlWriter_0.WriteElementString("Pitch", XmlConvert.ToString(Pitch));
			xmlWriter_0.WriteEndElement();
		}

		public static Record FromXML(ref XmlNode xmlNode_0)
		{
			Record result = default(Record);
			result.CurrentMeanAngularMotion_rad__s = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "CurrentMeanAngularMotion_rad__s").InnerText, CultureInfo.InvariantCulture);
			result.Time_s = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "Time_s").InnerText, CultureInfo.InvariantCulture);
			result.Radius_km = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "Radius_km").InnerText, CultureInfo.InvariantCulture);
			result.TA = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "TA").InnerText, CultureInfo.InvariantCulture);
			result.MA = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "MA").InnerText, CultureInfo.InvariantCulture);
			result.Phase = Conversions.ToByte(Misc.StartRequest(xmlNode_0.ChildNodes, "Phase").InnerText);
			result.Pitch = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "Pitch").InnerText, CultureInfo.InvariantCulture);
			return result;
		}
	}

	public struct BallisticResult
	{
		public double Lat_deg;

		public double Lon_deg;

		public double AltASL_m;

		public double Heading_deg;

		public double Speed_kts;

		public double Pitch_deg;
	}

	public bool High;

	public LatLonAlt Shooter;

	public LatLonAlt Target;

	public double RangeAngle_MaxRange;

	public double e;

	public double a_km;

	public double w;

	public double DeltaMeanAngularMotion_rad__s;

	public double FinalMeanAngularMotion_rad__s;

	public double InitialHeading;

	public Record CurrentRecord;

	public Record NextRecord;

	public double StartTA;

	public double EndTA;

	public double BoostTime_s;

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		xmlWriter_0.WriteStartElement("BallisticTrajectory");
		xmlWriter_0.WriteElementString("e", XmlConvert.ToString(e));
		xmlWriter_0.WriteElementString("a_km", XmlConvert.ToString(a_km));
		xmlWriter_0.WriteElementString("w", XmlConvert.ToString(w));
		xmlWriter_0.WriteElementString("DeltaMeanAngularMotion_rad__s", XmlConvert.ToString(DeltaMeanAngularMotion_rad__s));
		xmlWriter_0.WriteElementString("FinalMeanAngularMotion_rad__s", XmlConvert.ToString(FinalMeanAngularMotion_rad__s));
		xmlWriter_0.WriteElementString("InitialHeading", XmlConvert.ToString(InitialHeading));
		xmlWriter_0.WriteElementString("StartTA", XmlConvert.ToString(StartTA));
		xmlWriter_0.WriteElementString("EndTA", XmlConvert.ToString(EndTA));
		xmlWriter_0.WriteElementString("BoostTime_s", XmlConvert.ToString(BoostTime_s));
		xmlWriter_0.WriteElementString("High", XmlConvert.ToString(High));
		xmlWriter_0.WriteElementString("RangeAngle_MaxRange", XmlConvert.ToString(RangeAngle_MaxRange));
		xmlWriter_0.WriteStartElement("CurrentRecord");
		CurrentRecord.ToXML(ref xmlWriter_0);
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.WriteStartElement("NextRecord");
		NextRecord.ToXML(ref xmlWriter_0);
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.WriteStartElement("Shooter");
		Shooter.ToXML(ref xmlWriter_0);
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.WriteStartElement("Target");
		Target.ToXML(ref xmlWriter_0);
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.WriteEndElement();
	}

	public static BallisticTrajectory FromXML(ref XmlNode xmlNode_0)
	{
		BallisticTrajectory obj = new BallisticTrajectory
		{
			e = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "e").InnerText, CultureInfo.InvariantCulture),
			a_km = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "a_km").InnerText, CultureInfo.InvariantCulture),
			w = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "w").InnerText, CultureInfo.InvariantCulture),
			DeltaMeanAngularMotion_rad__s = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "DeltaMeanAngularMotion_rad__s").InnerText, CultureInfo.InvariantCulture),
			FinalMeanAngularMotion_rad__s = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "FinalMeanAngularMotion_rad__s").InnerText, CultureInfo.InvariantCulture),
			InitialHeading = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "InitialHeading").InnerText, CultureInfo.InvariantCulture),
			StartTA = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "StartTA").InnerText, CultureInfo.InvariantCulture),
			EndTA = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "EndTA").InnerText, CultureInfo.InvariantCulture),
			BoostTime_s = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "BoostTime_s").InnerText, CultureInfo.InvariantCulture),
			High = Conversions.ToBoolean(Misc.StartRequest(xmlNode_0.ChildNodes, "High").InnerText),
			RangeAngle_MaxRange = double.Parse(Misc.StartRequest(xmlNode_0.ChildNodes, "RangeAngle_MaxRange").InnerText, CultureInfo.InvariantCulture)
		};
		XmlNode xmlNode_ = Misc.StartRequest(xmlNode_0.ChildNodes, "CurrentRecord").FirstChild;
		obj.CurrentRecord = Record.FromXML(ref xmlNode_);
		xmlNode_ = Misc.StartRequest(xmlNode_0.ChildNodes, "NextRecord").FirstChild;
		obj.NextRecord = Record.FromXML(ref xmlNode_);
		xmlNode_ = Misc.StartRequest(xmlNode_0.ChildNodes, "Shooter").FirstChild;
		obj.Shooter = LatLonAlt.FromXML(ref xmlNode_);
		xmlNode_ = Misc.StartRequest(xmlNode_0.ChildNodes, "Target").FirstChild;
		obj.Target = LatLonAlt.FromXML(ref xmlNode_);
		return obj;
	}

	private void ConnectProperty(double double_0)
	{
		if (double_0 < CurrentRecord.Time_s)
		{
			throw new Exception();
		}
		while (double_0 >= NextRecord.Time_s)
		{
			CurrentRecord = NextRecord;
			NextRecord = ComputeNextRecord(this, CurrentRecord, 1.0);
		}
	}

	internal BallisticResult MoveProperty(double double_0)
	{
		ConnectProperty(double_0);
		double num = DeleteProperty(CurrentRecord.Time_s, NextRecord.Time_s, CurrentRecord.TA, NextRecord.TA, double_0);
		double altASL_m = (DeleteProperty(CurrentRecord.Time_s, NextRecord.Time_s, CurrentRecord.Radius_km, NextRecord.Radius_km, double_0) - 6371.0) * 1000.0;
		double num2 = num - StartTA;
		if (num2 < 0.0)
		{
			num2 += Math.PI * 2.0;
		}
		LatLonAlt latLonAlt = Shooter.PostInterruptibleTag(InitialHeading, num2);
		LatLonAlt latLonAlt2 = Shooter.PostInterruptibleTag(InitialHeading, num2 + 0.001);
		float num3 = Math2.PublishClass(latLonAlt.lat * 180.0 / Math.PI, latLonAlt.lon * 180.0 / Math.PI, latLonAlt2.lat * 180.0 / Math.PI, latLonAlt2.lon * 180.0 / Math.PI);
		double num4 = (NextRecord.Radius_km - CurrentRecord.Radius_km) / (NextRecord.Time_s - CurrentRecord.Time_s) * 1000.0 * 0.000539957;
		double num5 = (NextRecord.TA - CurrentRecord.TA) / (NextRecord.Time_s - CurrentRecord.Time_s) * 3443.9170326175517;
		double speed_kts = Math.Sqrt(num4 * num4 + num5 * num5) * 60.0 * 60.0;
		double num6 = DeleteProperty(CurrentRecord.Time_s, NextRecord.Time_s, CurrentRecord.Pitch, NextRecord.Pitch, double_0);
		BallisticResult result = default(BallisticResult);
		result.AltASL_m = altASL_m;
		result.Lat_deg = DestroyProperty(latLonAlt.lat) * 180.0 / Math.PI;
		result.Lon_deg = DestroyProperty(latLonAlt.lon) * 180.0 / Math.PI;
		result.Heading_deg = num3;
		result.Speed_kts = speed_kts;
		result.Pitch_deg = num6 * 180.0 / Math.PI;
		return result;
	}

	private double DeleteProperty(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		return (double_4 * double_2 - double_1 * double_2 - double_4 * double_3 + double_0 * double_3) / (double_0 - double_1);
	}

	private static double AddProperty(double double_0, double double_1, double double_2)
	{
		return Math.Acos((double_1 - double_1 * double_2 * double_2 - double_0) / (double_2 * double_0));
	}

	private static double DestroyProperty(double double_0)
	{
		while (double_0 >= Math.PI)
		{
			double_0 -= Math.PI * 2.0;
		}
		while (double_0 < -Math.PI)
		{
			double_0 += Math.PI * 2.0;
		}
		return double_0;
	}

	private static double Wrap(double double_0)
	{
		while (double_0 >= Math.PI * 2.0)
		{
			double_0 -= Math.PI * 2.0;
		}
		while (double_0 < 0.0)
		{
			double_0 += Math.PI * 2.0;
		}
		return double_0;
	}

	private static double ComputeProperty(double double_0, double double_1)
	{
		if (double_1 >= 1.0)
		{
			throw new Exception();
		}
		return Wrap(2.0 * Math.Atan(Math.Sqrt((1.0 + double_1) / (1.0 - double_1)) * Math.Tan(double_0 / 2.0)));
	}

	private static double PatchProperty(double double_0, double double_1)
	{
		return 2.0 * Math.Atan2(Math.Tan(double_0 / 2.0), Math.Sqrt((1.0 + double_1) / (1.0 - double_1))) - double_1 * Math.Sin(2.0 * Math.Atan2(Math.Tan(double_0 / 2.0), Math.Sqrt((1.0 + double_1) / (1.0 - double_1))));
	}

	private static double SelectProperty(double double_0, double double_1)
	{
		double num = 1.0;
		if (double_1 < 1.0)
		{
			double num2 = 0.0;
			num2 = ((double_0 < Math.PI) ? (double_0 + double_1 / 2.0) : (double_0 - double_1 / 2.0));
			while (Math.Abs(num) > 1E-09)
			{
				num = (num2 - double_1 * Math.Sin(num2) - double_0) / (1.0 - double_1 * Math.Cos(num2));
				num2 -= num;
			}
			return num2;
		}
		throw new Exception();
	}

	public static BallisticTrajectory Factory(LatLonAlt latLonAlt_0, LatLonAlt latLonAlt_1, double double_0, bool bool_0, double double_1)
	{
		BallisticTrajectory ballisticTrajectory = new BallisticTrajectory
		{
			Shooter = latLonAlt_0,
			Target = latLonAlt_1,
			BoostTime_s = double_1,
			RangeAngle_MaxRange = double_0 * 0.00029036704151956565,
			High = bool_0
		};
		double num = Math.Acos(Math.Cos(latLonAlt_0.lat) * Math.Cos(latLonAlt_1.lat) * Math.Cos(latLonAlt_0.lon - latLonAlt_1.lon) + Math.Sin(latLonAlt_0.lat) * Math.Sin(latLonAlt_1.lat));
		if (num > ballisticTrajectory.RangeAngle_MaxRange)
		{
			ballisticTrajectory.RangeAngle_MaxRange = num;
		}
		ballisticTrajectory.w = (0.0 - num) / 2.0 + Math.PI;
		if (bool_0)
		{
			ballisticTrajectory.e = EccentricityHighTrajectory(num, ballisticTrajectory.RangeAngle_MaxRange);
		}
		else
		{
			ballisticTrajectory.e = EccentricityLowTrajectory(num, ballisticTrajectory.RangeAngle_MaxRange);
		}
		ballisticTrajectory.a_km = SemiMajorAxis(ballisticTrajectory.RangeAngle_MaxRange, 6371.0);
		ballisticTrajectory.InitialHeading = MathFunctions.LogoutRequest(latLonAlt_0.lat * 180.0 / Math.PI, latLonAlt_0.lon * 180.0 / Math.PI, latLonAlt_1.lat * 180.0 / Math.PI, latLonAlt_1.lon * 180.0 / Math.PI) * CSMath.PI_dividedBy_180;
		ballisticTrajectory.StartTA = AddProperty(latLonAlt_0.radius_km, ballisticTrajectory.a_km, ballisticTrajectory.e);
		ballisticTrajectory.EndTA = Wrap(0.0 - AddProperty(latLonAlt_1.radius_km, ballisticTrajectory.a_km, ballisticTrajectory.e));
		ballisticTrajectory.FinalMeanAngularMotion_rad__s = Math.Sqrt(398600.0 / (ballisticTrajectory.a_km * ballisticTrajectory.a_km * ballisticTrajectory.a_km));
		ballisticTrajectory.DeltaMeanAngularMotion_rad__s = ballisticTrajectory.FinalMeanAngularMotion_rad__s / double_1;
		ballisticTrajectory.CurrentRecord = new Record
		{
			Time_s = 0.0,
			Phase = 1,
			Radius_km = latLonAlt_0.radius_km,
			TA = ballisticTrajectory.StartTA,
			MA = PatchProperty(ballisticTrajectory.StartTA, ballisticTrajectory.e),
			CurrentMeanAngularMotion_rad__s = 0.0
		};
		ballisticTrajectory.NextRecord = ComputeNextRecord(ballisticTrajectory, ballisticTrajectory.CurrentRecord, 1.0);
		return ballisticTrajectory;
	}

	public static Record ComputeNextRecord(BallisticTrajectory ballisticTrajectory_0, Record record_0, double double_0)
	{
		double num = Wrap(record_0.MA + record_0.CurrentMeanAngularMotion_rad__s * double_0);
		double num2 = ComputeProperty(SelectProperty(num, ballisticTrajectory_0.e), ballisticTrajectory_0.e);
		double pitch = Math.Atan2(ballisticTrajectory_0.e * Math.Sin(num2), 1.0 + ballisticTrajectory_0.e * Math.Cos(num2));
		Record result = default(Record);
		result.Time_s = record_0.Time_s + double_0;
		result.MA = num;
		result.TA = num2;
		result.Phase = record_0.Phase;
		result.Radius_km = RadiusEllipse(ballisticTrajectory_0.a_km, ballisticTrajectory_0.e, num2);
		result.Pitch = pitch;
		result.CurrentMeanAngularMotion_rad__s = Math.Min(record_0.CurrentMeanAngularMotion_rad__s + ballisticTrajectory_0.DeltaMeanAngularMotion_rad__s, ballisticTrajectory_0.FinalMeanAngularMotion_rad__s);
		return result;
	}

	private BallisticTrajectory()
	{
	}

	private static double ValidateProperty(double double_0)
	{
		return Math.Cos(double_0);
	}

	private static double LoginProperty(double double_0)
	{
		return Math.Sin(double_0);
	}

	private static double GetProperty(double double_0)
	{
		return Math.Asin(double_0);
	}

	private static double WriteProperty(double double_0)
	{
		return 1.0 / Math.Sin(double_0);
	}

	public static double SemiMajorAxis(double double_0, double double_1)
	{
		return double_1 * (1.0 + Math.Sin(double_0 / 2.0)) / 2.0;
	}

	public static double SemiMinorAxis(double double_0, double double_1)
	{
		return Math.Sqrt(0.0 - double_0 * double_0 * (-1.0 + double_1 * double_1));
	}

	public static double EccentricityHighTrajectory(double double_0, double double_1)
	{
		return Math.Sqrt((1.0 + Math.Cos(double_0) * Math.Pow(WriteProperty(double_1 / 2.0), 2.0) + 2.0 * Math.Cos(double_0 / 2.0) * WriteProperty(double_1 / 2.0) * (1.0 + WriteProperty(double_1 / 2.0)) * Math.Sqrt((Math.Cos(double_1) - Math.Cos(double_0)) / (-3.0 + Math.Cos(double_1) - 4.0 * Math.Sin(double_1 / 2.0)))) / Math.Pow(1.0 + WriteProperty(double_1 / 2.0), 2.0));
	}

	public static double EccentricityLowTrajectory(double double_0, double double_1)
	{
		return Math.Sqrt((1.0 + Math.Cos(double_0) * Math.Pow(WriteProperty(double_1 / 2.0), 2.0) - 2.0 * Math.Cos(double_0 / 2.0) * WriteProperty(double_1 / 2.0) * (1.0 + WriteProperty(double_1 / 2.0)) * Math.Sqrt((Math.Cos(double_1) - Math.Cos(double_0)) / (-3.0 + Math.Cos(double_1) - 4.0 * Math.Sin(double_1 / 2.0)))) / Math.Pow(1.0 + WriteProperty(double_1 / 2.0), 2.0));
	}

	public static double RadiusEllipse(double double_0, double double_1, double double_2)
	{
		return (double_0 - double_0 * double_1 * double_1) / (1.0 + double_1 * Math.Cos(double_2));
	}
}
