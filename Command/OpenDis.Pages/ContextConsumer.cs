using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace OpenDis.Pages;

[StandardModule]
internal sealed class ContextConsumer
{
	internal static DataTable SetupStub(string string_0, int int_0 = 0)
	{
		DataTable result = null;
		try
		{
			IWorkbook val;
			using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read))
			{
				val = new HSSFWorkbook(fileStream);
			}
			ISheet sheetAt = val.GetSheetAt(int_0);
			DataTable dataTable = new DataTable(sheetAt.SheetName);
			IRow row = sheetAt.GetRow(0);
			foreach (ICell item in row)
			{
				dataTable.Columns.Add(item.ToString());
			}
			int num = row.Count();
			bool flag = true;
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = sheetAt.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					IRow val2 = (IRow)enumerator2.Current;
					if (flag)
					{
						flag = false;
						continue;
					}
					DataRow dataRow = dataTable.NewRow();
					try
					{
						List<string> list = new List<string>();
						int num2 = num - 1;
						for (int i = 0; i <= num2; i++)
						{
							if (val2.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK) == null)
							{
								list.Add("");
								continue;
							}
							string text = val2.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
							if (string.IsNullOrEmpty(text))
							{
								list.Add("");
							}
							else
							{
								list.Add(text);
							}
						}
						if (list.Count > 0 && Operators.CompareString(list.Last(), "", TextCompare: false) == 0)
						{
							list.RemoveAt(list.Count - 1);
						}
						object[] array = list.ToArray();
						object[] itemArray = array;
						dataRow.ItemArray = itemArray;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						continue;
					}
					dataTable.Rows.Add(dataRow);
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			result = dataTable;
			return result;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				throw;
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
