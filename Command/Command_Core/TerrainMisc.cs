using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class TerrainMisc
{
	private struct MapperItem
	{
		public short managerItem;

		public short m_GetterItem;

		public MapperItem(short short_0, short short_1)
		{
			this = default(MapperItem);
			managerItem = 0;
			m_GetterItem = 0;
		}
	}

	[CompilerGenerated]
	private sealed class ProducerItem
	{
		public int Local_NumCols;

		public BinGridModule.TBinGrid Local_theGrid;

		public Scenario Local_theScen;

		internal void LoginInterruptibleParam(int i)
		{
			int num = Local_NumCols - 1;
			double double_ = 0.0;
			double double_2 = 0.0;
			for (int j = 0; j <= num; j++)
			{
				Local_theGrid.CellToProj(j, i, ref double_, ref double_2);
				float value = ActiveUnit_Navigator.NearestDistanceToLand(double_2, double_, Local_theScen);
				if (!exporterProxy.ContainsKey(i))
				{
					exporterProxy.Add(i, new Dictionary<int, float>());
				}
				Dictionary<int, float> dictionary = exporterProxy[i];
				if (!dictionary.ContainsKey(j))
				{
					dictionary.Add(j, value);
				}
			}
		}
	}

	private static MapperItem[][] _VisitorProxy;

	private static Dictionary<int, Dictionary<int, float>> exporterProxy;

	private static bool m_PrototypeProxy;

	static TerrainMisc()
	{
		_VisitorProxy = new MapperItem[360][];
		m_PrototypeProxy = false;
	}

	private static MapperItem EnableWatcher(object[] object_0, int int_0, int int_1)
	{
		try
		{
			if (object_0[int_0] == null)
			{
				return default(MapperItem);
			}
			MapperItem[] array = (MapperItem[])object_0[int_0];
			if (array == null)
			{
				return default(MapperItem);
			}
			return array[int_1];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 32409583296482094213398", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return default(MapperItem);
		}
	}

	private static void ChangeWatcher(object[] object_0, int int_0, int int_1, MapperItem mapperItem_0)
	{
		try
		{
			if (object_0[int_0] == null)
			{
				MapperItem[] array = new MapperItem[180];
				array[int_1] = mapperItem_0;
				object_0[int_0] = array;
			}
			else
			{
				((MapperItem[])object_0[int_0])[int_1] = mapperItem_0;
			}
		}
		catch (OutOfMemoryException projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 20324958729856749764398764397", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void InitializeMaxMinStore()
	{
		MapperItem mapperItem = default(MapperItem);
		IEnumerator enumerator = null;
		IEnumerator enumerator2 = null;
		int num = 0;
		int num2 = 0;
		foreach (List<BinGridModule.TBinGrid> value in Terrain.TerrainGrids.Values)
		{
			BinGridModule.TBinGrid tBinGrid = value[0];
			FileStream fileStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Terrain\\SRTM30Plus\\" + tBinGrid.Filename + "_MaxMin"), FileMode.Open, FileAccess.Read);
			XmlDocument xmlDocument = new XmlDocument();
			using (fileStream)
			{
				xmlDocument.Load(fileStream);
			}
			XmlNode xmlNode = xmlDocument.ChildNodes[1];
			try
			{
				enumerator = xmlNode.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator.Current;
					mapperItem = default(MapperItem);
					try
					{
						enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							XmlNode xmlNode3 = (XmlNode)enumerator2.Current;
							switch (xmlNode3.Name)
							{
							case "Min":
								mapperItem.m_GetterItem = Conversions.ToShort(xmlNode3.InnerText);
								break;
							case "Max":
								mapperItem.managerItem = Conversions.ToShort(xmlNode3.InnerText);
								break;
							case "Lon_Lat":
								num = Conversions.ToInteger(xmlNode3.InnerText.Split('_')[0]);
								num2 = Conversions.ToInteger(xmlNode3.InnerText.Split('_')[1]);
								num2 += 90;
								num += 180;
								break;
							}
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					object[] visitorProxy = _VisitorProxy;
					ChangeWatcher(visitorProxy, num, num2, mapperItem);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
		m_PrototypeProxy = true;
	}

	public static void CalculateDistanceFromLand(Scenario scenario_0)
	{
		Queue<BinGridModule.TBinGrid> queue = new Queue<BinGridModule.TBinGrid>();
		foreach (List<BinGridModule.TBinGrid> value2 in Terrain.TerrainGrids.Values)
		{
			queue.Enqueue(value2[0]);
		}
		exporterProxy = new Dictionary<int, Dictionary<int, float>>();
		BinGridModule.TBinGrid Local_theGrid = queue.Dequeue();
		int nrows = Local_theGrid.nrows;
		int Local_NumCols = Local_theGrid.ncols;
		Parallel.For(0, nrows, delegate(int i)
		{
			int num = Local_NumCols - 1;
			double double_ = 0.0;
			double double_2 = 0.0;
			for (int j = 0; j <= num; j++)
			{
				Local_theGrid.CellToProj(j, i, ref double_, ref double_2);
				float value3 = ActiveUnit_Navigator.NearestDistanceToLand(double_2, double_, scenario_0);
				if (!exporterProxy.ContainsKey(i))
				{
					exporterProxy.Add(i, new Dictionary<int, float>());
				}
				Dictionary<int, float> dictionary2 = exporterProxy[i];
				if (!dictionary2.ContainsKey(j))
				{
					dictionary2.Add(j, value3);
				}
			}
		});
		StringBuilder stringBuilder = new StringBuilder();
		FileStream fileStream = new FileStream(GameGeneral.GISFolderPath + "\\" + Local_theGrid.Filename + "_DFL", FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "    ";
			XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);
			xmlWriter.WriteStartElement("DFLRecs");
			foreach (int key in exporterProxy.Keys)
			{
				Dictionary<int, float> dictionary = exporterProxy[key];
				foreach (int key2 in dictionary.Keys)
				{
					stringBuilder.Clear();
					stringBuilder.Append(key).Append("_").Append(key2);
					xmlWriter.WriteStartElement("Rec");
					xmlWriter.WriteElementString("R_C", stringBuilder.ToString());
					xmlWriter.WriteElementString("D", Conversions.ToString(dictionary[key2]));
					xmlWriter.WriteEndElement();
				}
				xmlWriter.Flush();
			}
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
			fileStream.Flush();
		}
		GameGeneral.ResolveBridge("Done", null);
	}
}
