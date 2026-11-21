using System;

public class LockRandom : Random
{
	private readonly object repository = new object();

	public LockRandom()
	{
	}

	public LockRandom(int int_0)
		: base(int_0)
	{
	}

	public override int Next()
	{
		lock (repository)
		{
			return base.Next();
		}
	}

	public override int Next(int maxValue)
	{
		lock (repository)
		{
			return base.Next(maxValue);
		}
	}

	public override int Next(int minValue, int maxValue)
	{
		lock (repository)
		{
			return base.Next(minValue, maxValue);
		}
	}

	public override void NextBytes(byte[] buffer)
	{
		lock (repository)
		{
			base.NextBytes(buffer);
		}
	}

	public override double NextDouble()
	{
		lock (repository)
		{
			return base.NextDouble();
		}
	}

	protected override double Sample()
	{
		lock (repository)
		{
			return base.Sample();
		}
	}
}
