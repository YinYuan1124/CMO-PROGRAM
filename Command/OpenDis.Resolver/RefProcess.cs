namespace OpenDis.Resolver;

internal static class RefProcess
{
	public static string RestartThread(object object_0)
	{
		if (object_0 == null)
		{
			return "{null}";
		}
		if (object_0 is string)
		{
			return "\"" + object_0.ToString() + "\"";
		}
		return object_0.ToString();
	}
}
