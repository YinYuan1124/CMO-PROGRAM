namespace Command_Core;

public class ErrorForm
{
	public static void Open(ExceptionEntry exceptionEntry_0, string string_0 = "")
	{
		GlobalSingleton.GetInstance().CrossThreadErrorDispatch_entry.Add((exceptionEntry_0, string_0));
	}

	public static void Open(string string_0)
	{
		GlobalSingleton.GetInstance().CrossThreadErrorDispatch_str.Add(string_0);
	}
}
