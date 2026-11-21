using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command.Records;
using OpenDis.Resolver;

namespace OpenDis.Common;

internal static class ErrorProcess
{
	[CompilerGenerated]
	private sealed class ProxyPrototype
	{
		public string method;

		public Type methodDeclaringType;

		internal bool ResetInterruptibleMapping(MethodInfo info)
		{
			if (info.Name == method && info.DeclaringType != methodDeclaringType)
			{
				return info.GetBaseDefinition().DeclaringType == methodDeclaringType;
			}
			return false;
		}
	}

	public static bool TestThread(Type type_0)
	{
		PrinterProcessResolver.RunThread(type_0, "t");
		if (type_0.PostThread())
		{
			return StopThread(type_0);
		}
		return true;
	}

	public static bool StopThread(Type type_0)
	{
		PrinterProcessResolver.RunThread(type_0, "t");
		if (type_0.VerifyThread())
		{
			return type_0.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
		return false;
	}

	public static bool CancelThread(Type type_0, Type type_1, string string_0)
	{
		return type_0.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Any((MethodInfo info) => info.Name == string_0 && info.DeclaringType != type_1 && info.GetBaseDefinition().DeclaringType == type_1);
	}
}
