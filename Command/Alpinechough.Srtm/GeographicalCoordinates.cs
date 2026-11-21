using System;

namespace Alpinechough.Srtm;

public sealed class GeographicalCoordinates : IGeographicalCoordinates
{
	private double _HelperListener;

	private double mapperListener;

	public double Latitude
	{
		get
		{
			return _HelperListener;
		}
		set
		{
			if (!(value >= -90.0) || value > 90.0)
			{
				throw new ArgumentOutOfRangeException();
			}
			_HelperListener = value;
		}
	}

	public double Longitude
	{
		get
		{
			return mapperListener;
		}
		set
		{
			if (!(value <= 180.0) || value <= -180.0)
			{
				throw new ArgumentOutOfRangeException();
			}
			mapperListener = value;
		}
	}

	public GeographicalCoordinates()
	{
	}

	public GeographicalCoordinates(double double_0, double double_1)
	{
		Latitude = double_0;
		Longitude = double_1;
	}

	public GeographicalCoordinates(int int_0, int int_1, int int_2, char char_0, int int_3, int int_4, int int_5, char char_1)
		: this(((double)int_0 + (double)int_1 / 60.0 + (double)int_2 / 3600.0) * ((char_0.ToString().ToUpper() == "N") ? 1.0 : (-1.0)), ((double)int_3 + (double)int_4 / 60.0 + (double)int_5 / 3600.0) * ((char_1.ToString().ToUpper() == "W") ? 1.0 : (-1.0)))
	{
		switch (char_0)
		{
		default:
			throw new ArgumentException();
		case 'N':
		case 'S':
		case 'n':
		case 's':
			switch (char_1)
			{
			default:
				throw new ArgumentException();
			case 'E':
			case 'W':
			case 'e':
			case 'w':
				break;
			}
			break;
		}
	}

	public GeographicalCoordinates(GeographicalCoordinates geographicalCoordinates_0)
		: this(geographicalCoordinates_0.Latitude, geographicalCoordinates_0.Longitude)
	{
	}

	public override string ToString()
	{
		return $"{Latitude:0.000000}°, {Longitude:0.000000}°";
	}
}
