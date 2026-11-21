namespace GodSharp.Sockets.Extensions;

public static class StringExtensions
{
	public static bool IsNullOrWhiteSpace(this string string_0)
	{
		if (string_0 == null)
		{
			return true;
		}
		return string.IsNullOrWhiteSpace(string_0);
	}
}
