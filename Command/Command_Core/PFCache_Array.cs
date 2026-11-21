using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Command_Core;

public sealed class PFCache_Array
{
	private short[,] m_AuthenticationConsumer;

	public PFCache_Array()
	{
		m_AuthenticationConsumer = new short[3601, 7201];
		if (Directory.Exists(GameGeneral.GISFolderPath))
		{
			using (FileStream serializationStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Elevations"), FileMode.Open))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				m_AuthenticationConsumer = (short[,])binaryFormatter.Deserialize(serializationStream);
				return;
			}
		}
		GameGeneral.ResolveBridge("找不到地图数据目录" + GameGeneral.GISFolderPath + "。仿真程序是否正确安装和配置？", null);
	}

	public short GetElev(double double_0, double double_1, Scenario scenario_0)
	{
		short num = (short)Math.Round((double_0 + 90.0) / 0.05);
		short num2 = (short)Math.Round((double_1 + 180.0) / 0.05);
		short num3 = m_AuthenticationConsumer[num, num2];
		if (num3 == 0)
		{
			short elevation = Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0);
			m_AuthenticationConsumer[num, num2] = elevation;
			num3 = elevation;
		}
		return num3;
	}

	public void SetElev(double double_0, double double_1, short short_0)
	{
		short num = (short)Math.Round((double_0 + 90.0) / 0.05);
		short num2 = (short)Math.Round((double_1 + 180.0) / 0.05);
		m_AuthenticationConsumer[num, num2] = short_0;
	}

	public void SaveToDisk()
	{
		using FileStream serializationStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Elevations"), FileMode.Create);
		new BinaryFormatter().Serialize(serializationStream, m_AuthenticationConsumer);
	}
}
