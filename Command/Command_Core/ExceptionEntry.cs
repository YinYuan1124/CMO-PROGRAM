using System;
using System.Collections.Generic;

namespace Command_Core;

public class ExceptionEntry
{
	public List<DateTime> Occurrences;

	public int FuseOrder;

	public string Content;

	public bool Fused;

	public bool UI_Ignored;

	public double CurrentFuse => Math.Pow(20.0, FuseOrder);

	public ExceptionEntry(string string_0, DateTime dateTime_0)
	{
		Occurrences = new List<DateTime>();
		FuseOrder = 1;
		Content = string_0;
		AddOccurrences(dateTime_0);
	}

	public void AddOccurrences(DateTime dateTime_0)
	{
		Occurrences.Add(dateTime_0);
		if ((double)Occurrences.Count > CurrentFuse)
		{
			Fuse();
		}
	}

	public void Fuse()
	{
		Exception exception_ = new Exception("!!!WARNING!!! EXCEPTION FUSE REACHED (x" + CurrentFuse + " exceptions) FOR : " + Content);
		GameGeneral.WriteExceptionsToLog(ref exception_, bool_1: true, bool_2: true, bool_3: true);
		Fused = true;
		FuseOrder++;
	}
}
