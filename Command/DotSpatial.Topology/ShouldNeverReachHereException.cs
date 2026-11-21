using System;
using Command.Listeners;

namespace DotSpatial.Topology;

public class ShouldNeverReachHereException : Exception
{
	public ShouldNeverReachHereException()
		: base(AccountProcess.ShouldNeverReachHereException)
	{
	}
}
