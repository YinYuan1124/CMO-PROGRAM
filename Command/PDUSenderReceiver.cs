using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using OpenDis.Core;
using OpenDis.Dis1998;

public class PDUSenderReceiver
{
	public static bool DebugMode;

	private static IPAddress _Specification;

	private static int watcher;

	private static int _Reponse;

	private static Socket _Descriptor;

	private static Socket _List;

	private static MulticastOption m_Pool;

	private static IPEndPoint _Task;

	private static EndPoint _Filter;

	public static string SentException;

	public static long BytesSent;

	public static int BytesRecv;

	public static string GetMulticastSocketDetails()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_Descriptor == null)
		{
			stringBuilder.AppendLine("Socket is null.");
		}
		else
		{
			stringBuilder.AppendLine($"AddressFamily: {_Descriptor.AddressFamily}");
			stringBuilder.AppendLine($"Available data to read: {_Descriptor.Available}");
			stringBuilder.AppendLine($"Is Blocking: {_Descriptor.Blocking}");
			stringBuilder.AppendLine($"Is Connected: {_Descriptor.Connected}");
			stringBuilder.AppendLine($"Is Fragmentation allowed: {_Descriptor.DontFragment}");
			stringBuilder.AppendLine($"Is Broadcast enabled: {_Descriptor.EnableBroadcast}");
			stringBuilder.AppendLine($"Is ExclusiveAddressUse: {_Descriptor.ExclusiveAddressUse}");
			stringBuilder.AppendLine($"Handle: {_Descriptor.Handle}");
			stringBuilder.AppendLine($"Is Bound: {_Descriptor.IsBound}");
			stringBuilder.AppendLine($"LocalEndPoint: {_Descriptor.LocalEndPoint}");
			stringBuilder.AppendLine($"Is MulticastLoopback: {_Descriptor.MulticastLoopback}");
			stringBuilder.AppendLine($"ProtocolType: {_Descriptor.ProtocolType}");
			stringBuilder.AppendLine($"ReceiveBufferSize: {_Descriptor.ReceiveBufferSize}");
			stringBuilder.AppendLine($"ReceiveTimeout: {_Descriptor.ReceiveTimeout}");
			stringBuilder.AppendLine($"SendBufferSize: {_Descriptor.SendBufferSize}");
			stringBuilder.AppendLine($"SendTimeout: {_Descriptor.SendTimeout}");
			stringBuilder.AppendLine($"SocketType: {_Descriptor.SocketType}");
		}
		return stringBuilder.ToString();
	}

	public static string GetSendSocketDetails()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_List == null)
		{
			stringBuilder.AppendLine("Socket is null.");
		}
		else
		{
			stringBuilder.AppendLine($"AddressFamily: {_List.AddressFamily}");
			stringBuilder.AppendLine($"Available data to read: {_List.Available}");
			stringBuilder.AppendLine($"Is Blocking: {_List.Blocking}");
			stringBuilder.AppendLine($"Is Connected: {_List.Connected}");
			stringBuilder.AppendLine($"Is Fragmentation allowed: {_List.DontFragment}");
			stringBuilder.AppendLine($"Is Broadcast enabled: {_List.EnableBroadcast}");
			stringBuilder.AppendLine($"Is ExclusiveAddressUse: {_List.ExclusiveAddressUse}");
			stringBuilder.AppendLine($"Handle: {_List.Handle}");
			stringBuilder.AppendLine($"Is Bound: {_List.IsBound}");
			stringBuilder.AppendLine($"LocalEndPoint: {_List.LocalEndPoint}");
			stringBuilder.AppendLine($"Is MulticastLoopback: {_List.MulticastLoopback}");
			stringBuilder.AppendLine($"ProtocolType: {_List.ProtocolType}");
			stringBuilder.AppendLine($"ReceiveBufferSize: {_List.ReceiveBufferSize}");
			stringBuilder.AppendLine($"ReceiveTimeout: {_List.ReceiveTimeout}");
			stringBuilder.AppendLine($"SendBufferSize: {_List.SendBufferSize}");
			stringBuilder.AppendLine($"SendTimeout: {_List.SendTimeout}");
			stringBuilder.AppendLine($"SocketType: {_List.SocketType}");
		}
		return stringBuilder.ToString();
	}

	private static void InstantiateStruct()
	{
		Console.WriteLine("Current multicast group is: " + m_Pool.Group);
		Console.WriteLine("Current multicast local address is: " + m_Pool.LocalAddress);
	}

	public static void StartBroadcast_ForSend(IPAddress ipaddress_0, int int_0, IPAddress ipaddress_1)
	{
		try
		{
			_Specification = GetBroadcastAddress(ipaddress_0, ipaddress_1);
			watcher = int_0;
			_Reponse = int_0;
			_List = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			_List.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
			_Task = new IPEndPoint(_Specification, _Reponse);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public static IPAddress GetBroadcastAddress(IPAddress ipaddress_0, IPAddress ipaddress_1)
	{
		byte[] addressBytes = ipaddress_0.GetAddressBytes();
		byte[] addressBytes2 = ipaddress_1.GetAddressBytes();
		if (addressBytes.Length == addressBytes2.Length)
		{
			byte[] array = new byte[addressBytes.Length];
			for (int i = 0; i < addressBytes.Length; i++)
			{
				array[i] = (byte)(addressBytes[i] | ~addressBytes2[i]);
			}
			return new IPAddress(array);
		}
		throw new ArgumentException("IP address and subnet mask must be of the same type (IPv4 or IPv6).");
	}

	public static void StartBroadcast_ForReceive(IPAddress ipaddress_0, int int_0)
	{
		try
		{
			_List = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			_List.ExclusiveAddressUse = false;
			_List.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
			_Descriptor = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			watcher = int_0;
			_Reponse = int_0;
			_Filter = new IPEndPoint(ipaddress_0, _Reponse);
			_Descriptor.ExclusiveAddressUse = false;
			_Descriptor.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
			_Descriptor.Bind(_Filter);
			Console.WriteLine("Receive Broadcat UDP on Port: " + _Reponse);
			Console.WriteLine("----------------------------");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Console.Write("Error ---->   HIT ENTER TO EXIT");
		}
	}

	public static void StopBroadcast()
	{
		if (_Descriptor != null)
		{
			_Descriptor.Close();
		}
		if (_List != null)
		{
			_List.Close();
		}
	}

	private static void CreateStruct(object object_0)
	{
		Interlocked.Add(ref BytesSent, ((Array)object_0).Length);
		try
		{
			_List.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, optionValue: true);
			_List.SendTo((byte[])object_0, _Task);
		}
		catch (Exception ex)
		{
			SentException = ex.ToString();
		}
	}

	public static void SendSinglePDU(Pdu pdu_0)
	{
		pdu_0.Timestamp = DisTime.DisRelativeTimestamp;
		DataOutputStream dataOutputStream = new DataOutputStream(Endian.Big);
		pdu_0.MarshalAutoLengthSet(dataOutputStream);
		CreateStruct(dataOutputStream.ConvertToBytes(pdu_0));
	}

	public static void ReceiveBroadcastMessages(Queue<object> queue_0, EventWaitHandle eventWaitHandle_0)
	{
		bool flag = false;
		byte[] array = new byte[10000];
		int num = 0;
		PduProcessor pduProcessor = new PduProcessor();
		pduProcessor.Endian = Endian.Big;
		while (!flag)
		{
			try
			{
				num = _Descriptor.ReceiveFrom(array, ref _Filter);
				Interlocked.Add(ref BytesRecv, num);
				foreach (object item in pduProcessor.ProcessPdu(array, Endian.Big))
				{
					queue_0.Enqueue(item);
				}
				eventWaitHandle_0.Set();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}

	static PDUSenderReceiver()
	{
		DebugMode = false;
		SentException = "";
		BytesSent = 0L;
		BytesRecv = 0;
	}
}
