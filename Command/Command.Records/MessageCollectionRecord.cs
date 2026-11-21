using System;

namespace Command.Records;

internal static class MessageCollectionRecord
{
	public static bool VerifyThread(this Type type_0)
	{
		return type_0.IsGenericType;
	}

	public static Type ListThread(this Type type_0)
	{
		return type_0.BaseType;
	}

	public static bool ResolveThread(this Type type_0)
	{
		return type_0.IsVisible;
	}

	public static bool PostThread(this Type type_0)
	{
		return type_0.IsValueType;
	}
}
