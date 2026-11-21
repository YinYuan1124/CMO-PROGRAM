using System;
using Command.Listeners;

namespace DotSpatial.Topology.Operation.Valid;

public class ShellHoleIdentityException : Exception
{
	public ShellHoleIdentityException()
		: base(AccountProcess.ShellHoleIdentityException)
	{
	}
}
