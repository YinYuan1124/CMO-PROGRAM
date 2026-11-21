using System;
using System.Management;

namespace baileysoft.Wmi;

public sealed class Connection
{
	private ManagementScope publisherListener;

	private ConnectionOptions _ServerListener;

	public ManagementScope GetConnectionScope => publisherListener;

	public ConnectionOptions GetOptions => _ServerListener;

	public static ConnectionOptions SetConnectionOptions()
	{
		return new ConnectionOptions
		{
			Impersonation = ImpersonationLevel.Impersonate,
			Authentication = AuthenticationLevel.Default,
			EnablePrivileges = true
		};
	}

	public static ManagementScope SetConnectionScope(string string_0, ConnectionOptions connectionOptions_0)
	{
		ManagementScope managementScope = new ManagementScope();
		managementScope.Path = new ManagementPath("\\\\" + string_0 + "\\root\\CIMV2");
		managementScope.Options = connectionOptions_0;
		try
		{
			managementScope.Connect();
			return managementScope;
		}
		catch (ManagementException ex)
		{
			Console.WriteLine("An Error Occurred: " + ex.Message.ToString());
			return managementScope;
		}
	}

	public Connection()
	{
		LogoutObserver(null, null, null, Environment.MachineName);
	}

	public Connection(string string_0, string string_1, string string_2, string string_3)
	{
		LogoutObserver(string_0, string_1, string_2, string_3);
	}

	private void LogoutObserver(string string_0, string string_1, string string_2, string string_3)
	{
		_ServerListener = SetConnectionOptions();
		if (string_2 != null || string_0 != null)
		{
			_ServerListener.Username = string_2 + "\\" + string_0;
			_ServerListener.Password = string_1;
		}
		publisherListener = SetConnectionScope(string_3, _ServerListener);
	}
}
