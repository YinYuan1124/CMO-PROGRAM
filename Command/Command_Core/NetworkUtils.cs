using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class NetworkUtils
{
	internal static IPAddress GetStub(object object_0)
	{
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		for (int i = 0; i < allNetworkInterfaces.Length; i++)
		{
			foreach (UnicastIPAddressInformation unicastAddress in allNetworkInterfaces[i].GetIPProperties().UnicastAddresses)
			{
				if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork && object_0.Equals(unicastAddress.Address))
				{
					return unicastAddress.IPv4Mask;
				}
			}
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new ArgumentException($"Can't find subnetmask for IP address '{object_0}'");
	}

	internal static IPAddress WriteStub(IPAddress ipaddress_0, IPAddress ipaddress_1)
	{
		byte[] addressBytes = ipaddress_0.GetAddressBytes();
		byte[] addressBytes2 = ipaddress_1.GetAddressBytes();
		if (addressBytes.Length == addressBytes2.Length)
		{
			byte[] array = new byte[addressBytes.Length - 1 + 1];
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = (byte)(addressBytes[i] | (addressBytes2[i] ^ 0xFFu));
			}
			return new IPAddress(array);
		}
		throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
	}

	internal static bool NewStub(int int_0)
	{
		TcpConnectionInformation[] activeTcpConnections = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections();
		for (int i = 0; i < activeTcpConnections.Length; i = checked(i + 1))
		{
			if (activeTcpConnections[i].LocalEndPoint.Port == int_0)
			{
				return false;
			}
		}
		return true;
	}

	internal static string PushStub()
	{
		string result = string.Empty;
		try
		{
			using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
			{
				socket.Connect("8.8.8.8", 65530);
				result = ((IPEndPoint)socket.LocalEndPoint).Address.ToString();
			}
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			IPAddress[] array = addressList;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					result = iPAddress.ToString();
					return result;
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			NetworkInterface[] allNetworkInterfaces2 = NetworkInterface.GetAllNetworkInterfaces();
			NetworkInterface[] array2 = allNetworkInterfaces2;
			foreach (NetworkInterface networkInterface in array2)
			{
				if (networkInterface.OperationalStatus != OperationalStatus.Up)
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
					{
						result = unicastAddress.Address.ToString();
						return result;
					}
				}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			UnicastIPAddressInformation unicastIPAddressInformation = null;
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			NetworkInterface[] array3 = allNetworkInterfaces;
			foreach (NetworkInterface networkInterface2 in array3)
			{
				if (networkInterface2.OperationalStatus != OperationalStatus.Up)
				{
					continue;
				}
				IPInterfaceProperties iPProperties = networkInterface2.GetIPProperties();
				if (iPProperties.GatewayAddresses.Count == 0)
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress2 in iPProperties.UnicastAddresses)
				{
					if (unicastAddress2.Address.AddressFamily != AddressFamily.InterNetwork || IPAddress.IsLoopback(unicastAddress2.Address))
					{
						continue;
					}
					if (unicastAddress2.IsDnsEligible)
					{
						if (unicastAddress2.PrefixOrigin == PrefixOrigin.Dhcp)
						{
							result = unicastAddress2.Address.ToString();
							return result;
						}
						if (unicastIPAddressInformation == null || !unicastIPAddressInformation.IsDnsEligible)
						{
							unicastIPAddressInformation = unicastAddress2;
						}
					}
					else if (unicastIPAddressInformation == null)
					{
						unicastIPAddressInformation = unicastAddress2;
					}
				}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
