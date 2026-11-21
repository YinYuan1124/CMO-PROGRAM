using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Command_Core;

public sealed class DictionaryFactory
{
	private static ConcurrentQueue<Dictionary<string, IEventExporter.EventNotificationParameter>> advisorIssuer;

	private static bool customerIssuer;

	static DictionaryFactory()
	{
		advisorIssuer = new ConcurrentQueue<Dictionary<string, IEventExporter.EventNotificationParameter>>();
	}

	public static Dictionary<string, IEventExporter.EventNotificationParameter> CreateDictionary()
	{
		if (advisorIssuer.TryDequeue(out var result))
		{
			return result;
		}
		if (!customerIssuer)
		{
			customerIssuer = true;
			Task.Factory.StartNew(MoveRepository);
		}
		return new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
	}

	private static void MoveRepository()
	{
		if (advisorIssuer.Count <= 2000)
		{
			customerIssuer = true;
			int num = 1;
			do
			{
				Dictionary<string, IEventExporter.EventNotificationParameter> item = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				advisorIssuer.Enqueue(item);
				num++;
			}
			while (num <= 1000);
			customerIssuer = false;
		}
		else
		{
			customerIssuer = false;
		}
	}
}
