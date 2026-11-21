using System.Globalization;

namespace DotSpatial.Topology.Utilities;

public sealed class Global
{
	private static readonly Global _ListenerThread;

	private readonly NumberFormatInfo configThread;

	private Global()
	{
		configThread = new NumberFormatInfo
		{
			NumberDecimalSeparator = "."
		};
	}

	public static NumberFormatInfo GetNfi()
	{
		return _ListenerThread.configThread;
	}

	static Global()
	{
		_ListenerThread = new Global();
	}
}
