using System;
using System.Drawing;

namespace Command_Core;

public sealed class EmconLevel
{
	private Alertlevels _DispatcherClient;

	public Alertlevels Level
	{
		get
		{
			return _DispatcherClient;
		}
		set
		{
			_DispatcherClient = value;
		}
	}

	public static Alertlevels GetAlertEnumWithString(string string_0)
	{
		string_0 = string_0.ToLower();
		if (1 == 0)
		{
		}
		Alertlevels result = string_0 switch
		{
			"yellow" => Alertlevels.Yellow, 
			"red" => Alertlevels.Red, 
			"orange" => Alertlevels.Orange, 
			"green" => Alertlevels.Green, 
			"custom" => Alertlevels.Custom, 
			"blue" => Alertlevels.Blue, 
			_ => Alertlevels.Green, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static Color GetAlertColor(Alertlevels alertlevels_0, bool bool_0 = false)
	{
		Color result = default(Color);
		switch (alertlevels_0)
		{
		case Alertlevels.Green:
			result = Color.FromArgb(0, 255, 0);
			break;
		case Alertlevels.Blue:
			result = Color.FromArgb(0, 0, 255);
			break;
		case Alertlevels.Yellow:
			result = Color.FromArgb(255, 255, 0);
			break;
		case Alertlevels.Orange:
			result = Color.FromArgb(255, 125, 0);
			break;
		case Alertlevels.Red:
			result = Color.FromArgb(255, 0, 0);
			break;
		case Alertlevels.Custom:
			result = Color.FromArgb(50, 50, 50);
			break;
		}
		if (bool_0)
		{
			result = Color.FromArgb((int)Math.Round((double)(int)result.R / 4.0), (int)Math.Round((double)(int)result.G / 4.0), (int)Math.Round((double)(int)result.B / 4.0));
		}
		return result;
	}
}
