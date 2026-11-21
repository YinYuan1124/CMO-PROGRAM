using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command_Core;

public sealed class EventExporter_Common
{
	private ConcurrentDictionary<Module_Unit.Unit, double> definitionClient;

	private ConcurrentDictionary<string, UnitExporterState> _ValClient;

	private IEventExporter wrapperClient;

	public Dictionary<string, float> EligibleUnitWithExportLocationFrequency;

	[CompilerGenerated]
	private bool m_ObserverClient;

	[CompilerGenerated]
	private float m_DicClient;

	[CompilerGenerated]
	private float consumerClient;

	[CompilerGenerated]
	private float proxyClient;

	[CompilerGenerated]
	private float m_ImporterClient;

	[CompilerGenerated]
	private float repositoryClient;

	public bool UseCustomUnitExportFrequency
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverClient;
		}
		[CompilerGenerated]
		set
		{
			m_ObserverClient = value;
		}
	}

	public float SpeedBandFrequency0To20 { get; set; }

	public float SpeedBandFrequency20To40 { get; set; }

	public float SpeedBandFrequency40To80
	{
		[CompilerGenerated]
		get
		{
			return m_DicClient;
		}
		[CompilerGenerated]
		set
		{
			m_DicClient = value;
		}
	}

	public float SpeedBandFrequency80To160
	{
		[CompilerGenerated]
		get
		{
			return consumerClient;
		}
		[CompilerGenerated]
		set
		{
			consumerClient = value;
		}
	}

	public float SpeedBandFrequency160To320 { get; set; }

	public float SpeedBandFrequency320To640
	{
		[CompilerGenerated]
		get
		{
			return proxyClient;
		}
		[CompilerGenerated]
		set
		{
			proxyClient = value;
		}
	}

	public float SpeedBandFrequency640To1280 { get; set; }

	public float SpeedBandFrequency1280To2560 { get; set; }

	public float SpeedBandFrequencyOver2560
	{
		[CompilerGenerated]
		get
		{
			return m_ImporterClient;
		}
		[CompilerGenerated]
		set
		{
			m_ImporterClient = value;
		}
	}

	public float SpeedBandFrequencyDynamic
	{
		[CompilerGenerated]
		get
		{
			return repositoryClient;
		}
		[CompilerGenerated]
		set
		{
			repositoryClient = value;
		}
	}

	public EventExporter_Common(IEventExporter ieventExporter_0)
	{
		definitionClient = new ConcurrentDictionary<Module_Unit.Unit, double>();
		_ValClient = new ConcurrentDictionary<string, UnitExporterState>();
		EligibleUnitWithExportLocationFrequency = new Dictionary<string, float>();
		wrapperClient = ieventExporter_0;
	}

	public void LoadPerUnitExportSettings()
	{
		string path = Path.Combine(GameGeneral.ConfigFolderPath, "ExportUnitLocationFrequencySettings.csv");
		if (File.Exists(path))
		{
			foreach (string item in File.ReadAllLines(path).Skip(1))
			{
				string[] array = item.Split(',');
				if (!EligibleUnitWithExportLocationFrequency.ContainsKey(array[0]))
				{
					EligibleUnitWithExportLocationFrequency.Add(array[0], Conversions.ToSingle(array[1]));
				}
			}
			return;
		}
		FileStream fileStream = File.Create(path);
		byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("Unit's GUID,Override");
		fileStream.Write(bytes, 0, bytes.Length);
		fileStream.Close();
	}

	internal string RunRepository()
	{
		IEventExporter.EventExporterType exporterType = wrapperClient.ExporterType;
		if (1 == 0)
		{
		}
		string result = exporterType switch
		{
			IEventExporter.EventExporterType.XMLFile => "XML Settings", 
			IEventExporter.EventExporterType.CSVFile => "CSV Settings", 
			IEventExporter.EventExporterType.MSAccess => "MSAccess Settings", 
			IEventExporter.EventExporterType.const_4 => "Tacview Settings", 
			IEventExporter.EventExporterType.const_5 => "Tacview Settings", 
			IEventExporter.EventExporterType.TacviewRealtime => "", 
			IEventExporter.EventExporterType.const_7 => "SQLServer Settings", 
			IEventExporter.EventExporterType.SQLite => "SQLite Settings", 
			IEventExporter.EventExporterType.TacviewPipe => "", 
			IEventExporter.EventExporterType.SIMDIS => "", 
			_ => "ERROR", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public void GetCommonConfig(string string_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			IniConfigSource iniConfigSource;
			if (File.Exists(Exporter_General.EventExporter_ConfigFileName))
			{
				iniConfigSource = new IniConfigSource(Exporter_General.EventExporter_ConfigFileName);
			}
			else
			{
				iniConfigSource = new IniConfigSource();
				iniConfigSource.Save(Exporter_General.EventExporter_ConfigFileName);
			}
			iniConfigSource.AutoSave = true;
			if (iniConfigSource.Configs[string_0] == null)
			{
				iniConfigSource.AddConfig(string_0);
			}
			try
			{
				UseCustomUnitExportFrequency = iniConfigSource.Configs[string_0].GetBoolean("UseCustomUnitExportFrequency");
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				iniConfigSource.Configs[string_0].Set("UseCustomUnitExportFrequency", false);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency0To20 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency0To20");
			}
			catch (Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency0To20", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency20To40 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency20To40");
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency20To40", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency40To80 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency40To80");
			}
			catch (Exception projectError6)
			{
				ProjectData.SetProjectError(projectError6);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency40To80", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency80To160 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency80To160");
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency80To160", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency160To320 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency160To320");
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency160To320", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency320To640 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency320To640");
			}
			catch (Exception projectError9)
			{
				ProjectData.SetProjectError(projectError9);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency320To640", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency640To1280 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency640To1280");
			}
			catch (Exception projectError10)
			{
				ProjectData.SetProjectError(projectError10);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency640To1280", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequency1280To2560 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequency1280To2560");
			}
			catch (Exception projectError11)
			{
				ProjectData.SetProjectError(projectError11);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequency1280To2560", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequencyOver2560 = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequencyOver2560");
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequencyOver2560", 0);
				ProjectData.ClearProjectError();
			}
			try
			{
				SpeedBandFrequencyDynamic = iniConfigSource.Configs[string_0].GetFloat("SpeedBandFrequencyDynamic");
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				iniConfigSource.Configs[string_0].Set("SpeedBandFrequencyDynamic", 0);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ApplyLastExportLocation(Module_Unit.Unit unit_0)
	{
		try
		{
			if (_ValClient.ContainsKey(unit_0.ObjectID))
			{
				_ValClient[unit_0.ObjectID] = new UnitExporterState(unit_0);
			}
			else
			{
				_ValClient.TryAdd(unit_0.ObjectID, new UnitExporterState(unit_0));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool StartRepository(Scenario scenario_0, Module_Unit.Unit unit_0)
	{
		if (_ValClient.ContainsKey(unit_0.ObjectID))
		{
			if (_ValClient[unit_0.ObjectID].RunWatcher(unit_0))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal bool AssetRepository(Scenario scenario_0, Module_Unit.Unit unit_0)
	{
		if (wrapperClient.RequiresHeartbeatForStaticUnits)
		{
			return true;
		}
		if (_ValClient.ContainsKey(unit_0.ObjectID))
		{
			if (_ValClient[unit_0.ObjectID].RunWatcher(unit_0))
			{
				return false;
			}
			if (wrapperClient.Common.UseCustomUnitExportFrequency)
			{
				float num = ((EligibleUnitWithExportLocationFrequency.Count <= 0 || !EligibleUnitWithExportLocationFrequency.ContainsKey(unit_0.ObjectID)) ? GetLocationExportFrequencyFromUnitSpeed(unit_0) : ((EligibleUnitWithExportLocationFrequency[unit_0.ObjectID] == 0f) ? GetLocationExportFrequencyFromUnitSpeed(unit_0) : EligibleUnitWithExportLocationFrequency[unit_0.ObjectID]));
				double? num2 = PrintRepository(scenario_0, unit_0);
				double num3 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() < num3) : null).GetValueOrDefault())
				{
					return false;
				}
				ApplyLocationFrequencyTimestamp(scenario_0.Time, unit_0);
				return true;
			}
			return true;
		}
		return true;
	}

	public void ApplyLocationFrequencyTimestamp(DateTime dateTime_0, Module_Unit.Unit unit_0)
	{
		double totalMilliseconds = (dateTime_0 - new DateTime(1970, 1, 1)).TotalMilliseconds;
		if (definitionClient.ContainsKey(unit_0))
		{
			definitionClient[unit_0] = totalMilliseconds;
		}
		else
		{
			definitionClient.TryAdd(unit_0, totalMilliseconds);
		}
	}

	internal double? PrintRepository(Scenario scenario_0, Module_Unit.Unit unit_0)
	{
		if (!definitionClient.ContainsKey(unit_0))
		{
			ApplyLocationFrequencyTimestamp(scenario_0.Time, unit_0);
		}
		return (scenario_0.Time - new DateTime(1970, 1, 1)).TotalMilliseconds - definitionClient[unit_0];
	}

	public float GetLocationExportFrequencyFromUnitSpeed(Module_Unit.Unit unit_0)
	{
		if (unit_0.CurrentSpeed == 0f)
		{
			return 0f;
		}
		if (wrapperClient.Common.SpeedBandFrequencyDynamic == 0f)
		{
			if (unit_0.CurrentSpeed <= 2560f)
			{
				if (unit_0.CurrentSpeed < 1280f)
				{
					if (unit_0.CurrentSpeed < 640f)
					{
						if (unit_0.CurrentSpeed < 320f)
						{
							if (unit_0.CurrentSpeed < 160f)
							{
								if (unit_0.CurrentSpeed < 80f)
								{
									if (unit_0.CurrentSpeed < 40f)
									{
										if (unit_0.CurrentSpeed < 20f)
										{
											return wrapperClient.Common.SpeedBandFrequency0To20;
										}
										return wrapperClient.Common.SpeedBandFrequency20To40;
									}
									return wrapperClient.Common.SpeedBandFrequency40To80;
								}
								return wrapperClient.Common.SpeedBandFrequency80To160;
							}
							return wrapperClient.Common.SpeedBandFrequency160To320;
						}
						return wrapperClient.Common.SpeedBandFrequency320To640;
					}
					return wrapperClient.Common.SpeedBandFrequency640To1280;
				}
				return wrapperClient.Common.SpeedBandFrequency1280To2560;
			}
			return wrapperClient.Common.SpeedBandFrequencyOver2560;
		}
		return wrapperClient.Common.SpeedBandFrequencyDynamic / unit_0.CurrentSpeed * 1000f;
	}
}
