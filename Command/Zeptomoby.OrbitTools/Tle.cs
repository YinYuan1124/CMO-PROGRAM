using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Zeptomoby.OrbitTools;

public sealed class Tle
{
	public enum Line
	{
		Zero,
		One,
		Two
	}

	public enum Field
	{
		NoradNum,
		IntlDesignator,
		SetNumber,
		EpochYear,
		EpochDay,
		RevAtEpoch,
		Inclination,
		Raan,
		Eccentricity,
		ArgPerigee,
		MeanAnomaly,
		MeanMotion,
		MeanMotionDt,
		MeanMotionDt2,
		const_14
	}

	public enum Unit
	{
		Radians,
		Degrees,
		Native
	}

	private string m_ResolverMerchant;

	private string _PublisherMerchant;

	private string m_ServerMerchant;

	private string[] _AdapterMerchant;

	private string[] _SchemaMerchant;

	private Dictionary<Field, string> m_UtilsMerchant;

	private Dictionary<int, double> predicateMerchant;

	public string Name => m_ResolverMerchant;

	public string Line1 => _PublisherMerchant;

	public string Line2 => m_ServerMerchant;

	public string NoradNumber => GetField(Field.NoradNum, bool_0: false);

	public string Eccentricity => GetField(Field.Eccentricity, bool_0: false);

	public string Inclination => GetField(Field.Inclination, bool_0: true);

	public string Epoch => string.Format(CultureInfo.InvariantCulture, "{0:00}{1:000.00000000}", GetField(Field.EpochYear), GetField(Field.EpochDay));

	public string IntlDesignator => GetField(Field.IntlDesignator, bool_0: false);

	public string SetNumber => GetField(Field.SetNumber, bool_0: false);

	public string RevAtEpoch => GetField(Field.RevAtEpoch, bool_0: false);

	public string RAAscendingNode => GetField(Field.Raan, bool_0: true);

	public string ArgPerigee => GetField(Field.ArgPerigee, bool_0: true);

	public string MeanAnomaly => GetField(Field.MeanAnomaly, bool_0: true);

	public string MeanMotion => GetField(Field.MeanMotion, bool_0: true);

	public string MeanMotionDt => GetField(Field.MeanMotionDt, bool_0: false);

	public string MeanMotionDt2 => GetField(Field.MeanMotionDt2, bool_0: false);

	public string String_0 => GetField(Field.const_14, bool_0: false);

	public Julian EpochJulian
	{
		get
		{
			int num = (int)GetField(Field.EpochYear);
			double field = GetField(Field.EpochDay);
			num = ((num < 57) ? (num + 2000) : (num + 1900));
			return new Julian(num, field);
		}
	}

	public Tle(string string_0, string string_1, string string_2)
	{
		m_ResolverMerchant = string_0;
		_PublisherMerchant = string_1;
		m_ServerMerchant = string_2;
		RevertStruct();
	}

	public Tle(Tle tle_0)
		: this(tle_0.Name, tle_0.Line1, tle_0.Line2)
	{
	}

	private void RevertStruct()
	{
		m_UtilsMerchant = new Dictionary<Field, string>();
		predicateMerchant = new Dictionary<int, double>();
		_AdapterMerchant = (from T in _PublisherMerchant.Split()
			where !string.IsNullOrEmpty(T)
			select T).ToArray();
		_SchemaMerchant = (from T in m_ServerMerchant.Split()
			where !string.IsNullOrEmpty(T)
			select T).ToArray();
		m_UtilsMerchant[Field.NoradNum] = _AdapterMerchant[1];
		m_UtilsMerchant[Field.IntlDesignator] = _AdapterMerchant[2];
		m_UtilsMerchant[Field.EpochYear] = _AdapterMerchant[3].Substring(0, 2);
		m_UtilsMerchant[Field.EpochDay] = _AdapterMerchant[3].Substring(2);
		if (_AdapterMerchant[4].StartsWith("-"))
		{
			m_UtilsMerchant[Field.MeanMotionDt] = "-0";
		}
		else
		{
			m_UtilsMerchant[Field.MeanMotionDt] = "0";
		}
		Dictionary<Field, string> utilsMerchant = m_UtilsMerchant;
		utilsMerchant[Field.MeanMotionDt] = utilsMerchant[Field.MeanMotionDt] + "." + _AdapterMerchant[4].Split('.')[1];
		m_UtilsMerchant[Field.MeanMotionDt2] = ExpToDecimal(_AdapterMerchant[5]);
		m_UtilsMerchant[Field.const_14] = ExpToDecimal(_AdapterMerchant[6]);
		m_UtilsMerchant[Field.SetNumber] = _AdapterMerchant[8];
		if (string.IsNullOrEmpty(m_UtilsMerchant[Field.SetNumber]))
		{
			m_UtilsMerchant[Field.SetNumber] = "0";
		}
		m_UtilsMerchant[Field.Inclination] = _SchemaMerchant[2];
		m_UtilsMerchant[Field.Raan] = _SchemaMerchant[3];
		m_UtilsMerchant[Field.Eccentricity] = "0." + _SchemaMerchant[4];
		m_UtilsMerchant[Field.ArgPerigee] = _SchemaMerchant[5];
		m_UtilsMerchant[Field.MeanAnomaly] = _SchemaMerchant[6];
		m_UtilsMerchant[Field.MeanMotion] = _SchemaMerchant[7].Substring(0, Math.Min(_SchemaMerchant[7].Length, 11));
		if (_SchemaMerchant[7].Length < 12)
		{
			if (_SchemaMerchant.Length > 8)
			{
				m_UtilsMerchant[Field.RevAtEpoch] = _SchemaMerchant[8];
			}
		}
		else
		{
			m_UtilsMerchant[Field.RevAtEpoch] = _SchemaMerchant[7].Substring(12, 5);
		}
		if (string.IsNullOrEmpty(m_UtilsMerchant[Field.RevAtEpoch]))
		{
			m_UtilsMerchant[Field.RevAtEpoch] = "0";
		}
	}

	public double GetField(Field field_0)
	{
		return GetField(field_0, Unit.Native);
	}

	public double GetField(Field field_0, Unit unit_0)
	{
		int key = Key(unit_0, field_0);
		if (predicateMerchant.ContainsKey(key))
		{
			return predicateMerchant[key];
		}
		try
		{
			double num = ConvertUnits(double.Parse(m_UtilsMerchant[field_0].ToString(), CultureInfo.InvariantCulture), field_0, unit_0);
			predicateMerchant[key] = num;
			return num;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public string GetField(Field field_0, bool bool_0)
	{
		string text = m_UtilsMerchant[field_0].ToString();
		if (bool_0)
		{
			text += GetUnits(field_0);
		}
		return text.Trim();
	}

	private static int Key(Unit unit_0, Field field_0)
	{
		return (int)((int)unit_0 * 100 + field_0);
	}

	protected static double ConvertUnits(double double_0, Field field_0, Unit unit_0)
	{
		if ((field_0 == Field.Inclination || field_0 == Field.Raan || field_0 == Field.ArgPerigee || field_0 == Field.MeanAnomaly) && unit_0 == Unit.Radians)
		{
			return Globals.ToRadians(double_0);
		}
		return double_0;
	}

	protected static string GetUnits(Field field_0)
	{
		switch (field_0)
		{
		default:
			return string.Empty;
		case Field.Inclination:
		case Field.Raan:
		case Field.ArgPerigee:
		case Field.MeanAnomaly:
			return " degrees";
		case Field.MeanMotion:
			return " revs / day";
		}
	}

	protected static string ExpToDecimal(string string_0)
	{
		string text = string_0.Substring(0, 1);
		string text2;
		string text3;
		if (string_0.Contains('-'))
		{
			text2 = string_0.Split('-')[1];
			text3 = string_0.Split('-')[0];
		}
		else
		{
			text2 = string_0.Split('+')[1];
			text3 = string_0.Split('+')[0];
		}
		return double.Parse(text + "0." + text3 + "e" + text2, CultureInfo.InvariantCulture).ToString("F" + (text3.Length + Math.Abs(int.Parse(text2, CultureInfo.InvariantCulture))), CultureInfo.InvariantCulture);
	}

	public static bool IsValidFormat(string string_0, Line line_0)
	{
		string_0 = string_0.Trim();
		int length = string_0.Length;
		if (line_0 == Line.Zero)
		{
			return string_0.Length <= 24;
		}
		if (length == 69 && string_0[0] - 48 == (int)line_0)
		{
			return string_0[1] == ' ';
		}
		return false;
	}

	private static int CountMerchant(string string_0)
	{
		int num = string_0.Length - 1;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			char c = string_0[i];
			if (char.IsDigit(c))
			{
				num2 += c - 48;
			}
			else if (c == '-')
			{
				num2++;
			}
		}
		return num2 % 10;
	}
}
