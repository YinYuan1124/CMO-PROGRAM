using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class ArrayExtensions
{
	public static void Add<T>(ref T[] gparam_0, T theAC)
	{
		gparam_0 = (T[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray(gparam_0, new T[gparam_0.Length + 1]);
		gparam_0[gparam_0.Length - 1] = theAC;
	}

	public static void Remove<T>(ref T[] gparam_0, T theAC)
	{
		List<T> list = new List<T>(gparam_0);
		list.Remove(theAC);
		gparam_0 = list.ToArray();
	}

	public static void Clear<T>(ref T[] gparam_0)
	{
		gparam_0 = new T[0];
	}

	public static void Insert<T>(ref T[] gparam_0, int int_0, T theW)
	{
		List<T> list = new List<T>(gparam_0);
		list.Insert(int_0, theW);
		gparam_0 = list.ToArray();
	}

	public static T[] Join<T>(ref T[] gparam_0, ref T[] gparam_1)
	{
		T[] array = new T[gparam_0.Length + gparam_1.Length - 1 + 1];
		gparam_0.CopyTo(array, 0);
		gparam_1.CopyTo(array, gparam_0.Length);
		return array;
	}
}
