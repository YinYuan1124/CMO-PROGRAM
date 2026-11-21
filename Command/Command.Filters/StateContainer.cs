using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Filters;

[StandardModule]
internal sealed class StateContainer
{
	public static bool _AuthenticationContainer;

	private static WebClient _ParamsContainer;

	static StateContainer()
	{
		_AuthenticationContainer = true;
		_ParamsContainer = new WebClient();
	}

	public static void ListInitializer(bool bool_0)
	{
		if (bool_0)
		{
			Task.Factory.StartNew(delegate
			{
				RunInitializer();
			});
		}
		else
		{
			RunInitializer();
		}
	}

	private static void ResolveInitializer()
	{
	}

	private static void PostInitializer()
	{
	}

	private static void RunInitializer()
	{
		bool authenticationContainer = _AuthenticationContainer;
		try
		{
			_ParamsContainer.OpenRead("http://clients3.google.com/generate_204");
			_AuthenticationContainer = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_AuthenticationContainer = false;
			ProjectData.ClearProjectError();
		}
		if (_AuthenticationContainer != authenticationContainer)
		{
			if (_AuthenticationContainer)
			{
				ResolveInitializer();
			}
			else
			{
				PostInitializer();
			}
		}
	}
}
