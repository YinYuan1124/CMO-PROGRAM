using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Aced.Compression;
using Command.Maps;
using LZ4;
using Microsoft.IO;
using Microsoft.VisualBasic.CompilerServices;
using SevenZip;

namespace Command_Core;

[Serializable]
public sealed class ScenContainer
{
	public string ScenTitle;

	public string ScenDescription;

	public string ScenAuthor;

	public short Complexity;

	public short Difficulty;

	public string ScenSetting;

	public short ScenDate;

	public string string_0;

	private Scenario _ScenarioObject;

	public byte[] Scenario_Compressed;

	public int CompressVersion;

	[XmlElement("BuildNumber", IsNullable = true)]
	public string BuildNumber;

	[XmlElement("Version", IsNullable = true)]
	public string Version;

	public bool IsCampaignCheckpoint;

	public long SaveCurrentTime;

	public string CampaignID;

	public string CampaignSessionID;

	public static ScenContainer FromXML(string string_1)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScenContainer));
			StringReader stringReader = new StringReader(string_1);
			XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
			ScenContainer result = (ScenContainer)xmlSerializer.Deserialize(xmlTextReader);
			xmlTextReader.Close();
			stringReader.Close();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101047", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static string QueryScenContainer(string string_1, string string_2)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(string_1);
		using (xmlTextReader)
		{
			if (xmlTextReader.ReadToDescendant(string_2))
			{
				return xmlTextReader.ReadElementContentAsString();
			}
			return null;
		}
	}

	private string DecompressScenarioObjectToXML_Aced()
	{
		try
		{
			AcedInflator acedInflator = new AcedInflator();
			byte[] array = new byte[Scenario_Compressed.Length + 1];
			array = Scenario_Compressed;
			byte[] array2 = acedInflator.Decompress(array, 0, 0, 0);
			array = null;
			int num = array2.Length - 1;
			while (array2[num] == 0)
			{
				num--;
			}
			byte[] array3 = new byte[num + 1 + 1];
			Array.Copy(array2, array3, num + 1);
			array2 = array3;
			array2 = Misc.CleanUpXML_Headers(array2);
			array2 = Misc.CleanUpXML_IllegalCharacters(array2);
			string @string = Encoding.UTF8.GetString(array2);
			array2 = null;
			return @string;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private string DecompressScenarioObjectToXML_7z()
	{
		using MemoryTributary memoryTributary = new MemoryTributary(Scenario_Compressed);
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		new SevenZipExtractor(memoryTributary, GameGeneral.m_StructDic).ExtractFile(0, memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] byte_ = memoryStream.ToArray();
		byte_ = Misc.CleanUpXML_Headers(byte_);
		byte_ = Misc.CleanUpXML_IllegalCharacters(byte_);
		string @string = Encoding.UTF8.GetString(byte_);
		byte_ = null;
		return @string;
	}

	public void CompressScenario_Aced()
	{
		using MemoryTributary object_ = GameGeneral.PostBridge(_ScenarioObject);
		CompressVersion = 1;
		Scenario_Compressed = ConsumerListenerMapping.WriteImporter(object_, AcedCompressionLevel.Maximum);
	}

	public void CompressScenario_Aced(Stream stream_0)
	{
		CompressVersion = 1;
		Scenario_Compressed = ConsumerListenerMapping.WriteImporter(stream_0, AcedCompressionLevel.Maximum);
	}

	public void CompressScenario_7z()
	{
		using MemoryTributary stream_ = GameGeneral.PostBridge(_ScenarioObject);
		CompressVersion = 2;
		using MemoryTributary memoryTributary = ConsumerListenerMapping.GetImporter(stream_, CompressionLevel.High);
		Scenario_Compressed = memoryTributary.ToArray();
	}

	public void CompressScenario_7z(Stream stream_0)
	{
		CompressVersion = 2;
		using MemoryTributary memoryTributary = ConsumerListenerMapping.GetImporter(stream_0, CompressionLevel.High);
		Scenario_Compressed = memoryTributary.ToArray();
	}

	public void AttachAndCompressScenarioObject(Stream stream_0)
	{
		try
		{
			CompressScenario_LZ(stream_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200055", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
		}
	}

	public void SaveToFile(string string_1, bool bool_0 = false)
	{
		if (Scenario_Compressed == null)
		{
			try
			{
				try
				{
					CompressScenario_LZ();
				}
				catch (OutOfMemoryException projectError)
				{
					ProjectData.SetProjectError(projectError);
					CompressScenario_LZ();
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				CompressScenario_Aced();
				exception_?.Data.Add("Error at 200056", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				ProjectData.ClearProjectError();
			}
		}
		_ScenarioObject = null;
		bool flag = false;
		DateTime creationTime = default(DateTime);
		DateTime lastWriteTime = default(DateTime);
		DateTime lastAccessTime = default(DateTime);
		if (bool_0 && FileExistsNative.FileExistsFast(string_1))
		{
			flag = true;
			FileInfo fileInfo = new FileInfo(string_1);
			creationTime = fileInfo.CreationTime;
			lastWriteTime = fileInfo.LastWriteTime;
			lastAccessTime = fileInfo.LastAccessTime;
		}
		if (!Directory.Exists(Path.GetDirectoryName(string_1)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(string_1));
		}
		FileStream fileStream = new FileStream(string_1, FileMode.Create);
		new XmlSerializer(GetType()).Serialize(fileStream, this);
		fileStream.Close();
		fileStream = null;
		if (bool_0 && flag)
		{
			new FileInfo(string_1)
			{
				CreationTime = creationTime,
				LastWriteTime = lastWriteTime,
				LastAccessTime = lastAccessTime
			};
		}
	}

	public override string ToString()
	{
		MemoryTributary memoryTributary = ToMemoryStream();
		string result = Misc.AssetRequest(memoryTributary);
		memoryTributary.Dispose();
		return result;
	}

	private MemoryTributary ToMemoryStream()
	{
		if (Scenario_Compressed == null)
		{
			try
			{
				CompressScenario_LZ();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				CompressScenario_Aced();
				exception_?.Data.Add("Error at 200057", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		_ScenarioObject = null;
		MemoryTributary memoryTributary = new MemoryTributary();
		new XmlSerializer(typeof(ScenContainer)).Serialize(memoryTributary, this);
		return memoryTributary;
	}

	public static ScenContainer LoadFromFile(string string_1)
	{
		try
		{
			new FileInfo(string_1);
			ScenContainer scenContainer = new ScenContainer(null);
			if (!Directory.Exists(Path.GetDirectoryName(string_1)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(string_1));
			}
			FileStream fileStream = new FileStream(string_1, FileMode.Open);
			ScenContainer result = (ScenContainer)new XmlSerializer(scenContainer.GetType()).Deserialize(fileStream);
			fileStream.Close();
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public string GetScenarioObject_AsXML()
	{
		string result = "";
		try
		{
			switch (CompressVersion)
			{
			case 1:
				result = DecompressScenarioObjectToXML_Aced();
				break;
			case 2:
				result = DecompressScenarioObjectToXML_7z();
				break;
			case 3:
				result = Crypto.ListImporter(DecompressScenarioObjectToXML_Aced(), GameGeneral.m_StructDic);
				break;
			case 5:
				result = DecompressScenarioObjectToXML_LZ();
				break;
			}
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public Scenario GetScenarioObject(ref string string_1, Action<double> action_0, bool bool_0)
	{
		if (action_0 == null)
		{
			action_0 = delegate
			{
			};
		}
		return Scenario.FromXmlText(GetScenarioObject_AsXML(), ref string_1, action_0, bool_0);
	}

	public ScenContainer(Scenario scenario_0)
	{
		CompressVersion = 1;
		IsCampaignCheckpoint = false;
		_ScenarioObject = scenario_0;
		if (scenario_0 == null)
		{
			Complexity = 1;
			Difficulty = 1;
			ScenSetting = "没有设置";
		}
		else
		{
			if (!string.IsNullOrEmpty(scenario_0.Title))
			{
				ScenTitle = scenario_0.Title.ToString();
			}
			if (!string.IsNullOrEmpty(scenario_0.Description))
			{
				ScenDescription = scenario_0.Description.ToString();
			}
			if (!string.IsNullOrEmpty(scenario_0.Description))
			{
				ScenDescription = scenario_0.Description.ToString();
			}
			Complexity = scenario_0.Meta_Complexity;
			Difficulty = scenario_0.Meta_Difficulty;
			ScenSetting = scenario_0.Meta_ScenSetting;
			string dBUsed = scenario_0.DBUsed;
			DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(dBUsed, ref dbfileCheckResult_, bool_0: true, bool_1: false);
			if (dBRecordByHash != null)
			{
				string_0 = dBRecordByHash.FileName;
			}
		}
		BuildNumber = "1328.18";
		Version = GameGeneral.ProgramTitle;
	}

	public ScenContainer()
	{
		CompressVersion = 1;
		IsCampaignCheckpoint = false;
	}

	public void CompressScenario_LZ()
	{
		CompressVersion = 5;
		RijndaelManaged rijndaelManaged = GetRijndaelManaged();
		using MemoryTributary stream_ = GameGeneral.PostBridge(_ScenarioObject);
		using MemoryTributary memoryTributary = ConsumerListenerMapping.PushImporter(stream_);
		memoryTributary.Seek(0L, SeekOrigin.Begin);
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
		using MemoryTributary memoryTributary2 = new MemoryTributary();
		memoryTributary2.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
		memoryTributary2.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
		using (CryptoStream destination = new CryptoStream(memoryTributary2, transform, CryptoStreamMode.Write))
		{
			memoryTributary.CopyTo(destination);
		}
		Scenario_Compressed = memoryTributary2.ToArray();
	}

	public void CompressScenario_LZ(Stream stream_0)
	{
		CompressVersion = 5;
		RijndaelManaged rijndaelManaged = GetRijndaelManaged();
		using (stream_0)
		{
			using MemoryTributary memoryTributary = ConsumerListenerMapping.PushImporter(stream_0);
			memoryTributary.Seek(0L, SeekOrigin.Begin);
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryTributary memoryTributary2 = new MemoryTributary();
			memoryTributary2.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
			memoryTributary2.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
			using (CryptoStream destination = new CryptoStream(memoryTributary2, transform, CryptoStreamMode.Write))
			{
				memoryTributary.CopyTo(destination);
			}
			Scenario_Compressed = memoryTributary2.ToArray();
		}
	}

	private static RijndaelManaged GetRijndaelManaged()
	{
		byte[] bytes = Encoding.ASCII.GetBytes("Eg:ù2à[kÝB{ãÞ¬KîâÉ{µ\\µ¥¤4\u00b4J»ãvaWÀó±òÈV:£W-(Èª|cêI¹");
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("âcI}\u00b4EjÆãoµËÛÞwÿë6ØçÌP«4lWT¶-áòêªÓb¶þ×r2Z,¬}¶üÿTYá^¦\u00afH%ÿºÂOð=_Û^&¬oÚýª~ÁtÂRëg{Ñ§kA«Õº½Ë¥PÊ+jbo<_ù\u00a8xKUíTïBGÙøªçäð(tX`íÅuÉù³l(¶WØ$ëèw¬¦ÇJ|Z©*.¼ÏÒ_<·UP=W²üßå3ÂOºÃo_¤«ì8G2¶/R¬mo;>YwsÿJS}W£1ãC?ÍREÚâÙLK¬ä%¡X>ÀZÉUïdp¿o/uÕfé>ÄC©ñ)á6T~åÜ¡9>/ÚÑ«Wl£ÈÄëw{úupU®1ìU%0µõ\u00a8", bytes);
		RijndaelManaged rijndaelManaged = null;
		rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.KeySize = 256;
		rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
		return rijndaelManaged;
	}

	public string DecompressScenarioObjectToXML_LZ()
	{
		using MemoryTributary memoryTributary = new MemoryTributary(Scenario_Compressed);
		if (RCMS.recyclableMemoryStreamManager_0 == null)
		{
			RCMS.recyclableMemoryStreamManager_0 = new RecyclableMemoryStreamManager();
		}
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		RijndaelManaged rijndaelManaged = GetRijndaelManaged();
		byte[] array = new byte[4];
		memoryTributary.Read(array, 0, array.Length);
		byte[] array2 = new byte[BitConverter.ToInt32(array, 0) - 1 + 1];
		memoryTributary.Read(array2, 0, array2.Length);
		rijndaelManaged.IV = array2;
		ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
		using (CryptoStream cryptoStream = new CryptoStream(memoryTributary, transform, CryptoStreamMode.Read))
		{
			using LZ4Stream val = new LZ4Stream(cryptoStream, LZ4StreamMode.Decompress, LZ4StreamFlags.IsolateInnerStream);
			((Stream)val).CopyTo(memoryStream);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] byte_ = memoryStream.ToArray();
		byte_ = Misc.CleanUpXML_Headers(byte_);
		byte_ = Misc.CleanUpXML_IllegalCharacters(byte_);
		return Encoding.UTF8.GetString(byte_);
	}
}
