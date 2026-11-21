namespace DotSpatial.Topology.Utilities;

public class Assert
{
	private Assert()
	{
	}

	public static void IsTrue(bool bool_0)
	{
		IsTrue(bool_0, null);
	}

	public static void IsTrue(bool bool_0, string string_0)
	{
		if (!bool_0)
		{
			if (string_0 == null)
			{
				throw new AssertionFailedException();
			}
			throw new AssertionFailedException(string_0);
		}
	}

	public static void IsEquals(object object_0, object object_1)
	{
		IsEquals(object_0, object_1, null);
	}

	public static void IsEquals(object object_0, object object_1, string string_0)
	{
		if (!object_1.Equals(object_0))
		{
			throw new AssertionFailedException("Expected " + object_0?.ToString() + " but encountered " + object_1?.ToString() + ((string_0 == null) ? string.Empty : (": " + string_0)));
		}
	}
}
