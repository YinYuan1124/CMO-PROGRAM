using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SQLTableGenerator;

namespace Command.Maps;

internal class FacadeListenerMapping
{
	private static void Main(object[] object_0)
	{
		List<TableClass> list = new List<TableClass>();
		Type[] types = Assembly.LoadFile((string)object_0[0]).GetTypes();
		for (int i = 0; i < types.Length; i++)
		{
			TableClass item = new TableClass(types[i]);
			list.Add(item);
		}
		foreach (TableClass item2 in list)
		{
			Console.WriteLine(item2.OrderDescriptor());
			Console.WriteLine();
		}
	}
}
