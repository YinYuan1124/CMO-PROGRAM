using System;

namespace Command.Tasks;

internal abstract class ThreadThread : IComparable
{
	public abstract double Y { get; }

	protected abstract double X { get; }

	public int CompareTo(object target)
	{
		if (target is ThreadThread)
		{
			int num = Y.CompareTo(((ThreadThread)target).Y);
			if (num == 0)
			{
				return X.CompareTo(((ThreadThread)target).X);
			}
			return num;
		}
		throw new ArgumentException("obj not VEvent!");
	}
}
