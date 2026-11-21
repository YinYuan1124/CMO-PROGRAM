using System.Runtime.InteropServices;

namespace Algorithms;

public static class HighResolutionTime
{
	private static long m_ManagerListener;

	private static long m_GetterListener;

	[DllImport("kernel32.dll")]
	private static extern bool QueryPerformanceCounter(out long long_0);

	[DllImport("kernel32.dll")]
	private static extern bool QueryPerformanceFrequency(out long long_0);

	static HighResolutionTime()
	{
		QueryPerformanceFrequency(out m_GetterListener);
	}

	public static void Start()
	{
		QueryPerformanceCounter(out m_ManagerListener);
	}

	public static double GetTime()
	{
		QueryPerformanceCounter(out var long_);
		return (double)(long_ - m_ManagerListener) / (double)m_GetterListener;
	}
}
