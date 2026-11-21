using System;

public static class RandomFactory
{
	private static readonly Random tests;

	private static readonly LockRandom _Interpreter;

	private static readonly ThreadStaticRandom m_Container;

	private static readonly ThreadLocalRandom _Composer;

	public static Random GetRandom()
	{
		return tests;
	}

	public static LockRandom GetLockRandom()
	{
		return _Interpreter;
	}

	public static ThreadStaticRandom GetThreadStaticRandom()
	{
		return m_Container;
	}

	public static ThreadLocalRandom GetThreadLocalRandom()
	{
		return _Composer;
	}

	static RandomFactory()
	{
		tests = new Random();
		_Interpreter = new LockRandom();
		m_Container = new ThreadStaticRandom();
		_Composer = new ThreadLocalRandom();
	}
}
