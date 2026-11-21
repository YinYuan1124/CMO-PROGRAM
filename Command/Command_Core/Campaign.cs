using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Campaign
{
	public class CampaignItem
	{
		public string Name;

		public CampaignItemType Type;
	}

	public enum CampaignItemType
	{
		ScenarioRecord,
		AttachmentRecord
	}

	public sealed class ScenarioRecord : CampaignItem
	{
		public string ID;

		public string FileName;

		private int m_FilterComparator;

		public int PassScore
		{
			get
			{
				return m_FilterComparator;
			}
			set
			{
				m_FilterComparator = value;
			}
		}

		public ScenarioRecord()
		{
			Type = CampaignItemType.ScenarioRecord;
		}
	}

	public sealed class AttachmentRecord : CampaignItem
	{
		public string ID;

		public AttachmentRecord()
		{
			Type = CampaignItemType.AttachmentRecord;
		}
	}

	public string ID;

	public string Name;

	public string Description;

	public List<CampaignItem> CampaignItems;

	public string EndingText;

	public string FolderPath;

	public string LuaXml;

	private void DisableProperty(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Campaign");
			xmlWriter_0.WriteElementString("ID", ID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("EndingText", EndingText);
			if (CampaignItems.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Items");
				foreach (CampaignItem campaignItem in CampaignItems)
				{
					Type type = campaignItem.GetType();
					if (type == typeof(ScenarioRecord))
					{
						ScenarioRecord scenarioRecord = (ScenarioRecord)campaignItem;
						xmlWriter_0.WriteStartElement("Scenario");
						xmlWriter_0.WriteElementString("Name", scenarioRecord.Name);
						xmlWriter_0.WriteElementString("ID", scenarioRecord.ID);
						xmlWriter_0.WriteElementString("File", scenarioRecord.FileName);
						xmlWriter_0.WriteElementString("PassScore", Conversions.ToString(scenarioRecord.PassScore));
						xmlWriter_0.WriteEndElement();
					}
					else if (type == typeof(AttachmentRecord))
					{
						xmlWriter_0.WriteStartElement("Attachment");
						AttachmentRecord attachmentRecord = (AttachmentRecord)campaignItem;
						xmlWriter_0.WriteElementString("Name", attachmentRecord.Name);
						xmlWriter_0.WriteElementString("ID", attachmentRecord.ID);
						xmlWriter_0.WriteEndElement();
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101311", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static Campaign UpdateProperty(ref XmlNode xmlNode_0)
	{
		Campaign result = null;
		try
		{
			Campaign campaign = new Campaign();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Name":
						campaign.Name = xmlNode.InnerText;
						break;
					case "Items":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								string name = xmlNode2.Name;
								if (Operators.CompareString(name, "Scenario", TextCompare: false) == 0)
								{
									ScenarioRecord scenarioRecord = new ScenarioRecord();
									try
									{
										enumerator3 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator3.MoveNext())
										{
											XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
											switch (xmlNode3.Name)
											{
											case "PassScore":
												scenarioRecord.PassScore = Conversions.ToInteger(xmlNode3.InnerText);
												break;
											case "Name":
												scenarioRecord.Name = xmlNode3.InnerText;
												break;
											case "ID":
												scenarioRecord.ID = xmlNode3.InnerText;
												break;
											case "File":
												scenarioRecord.FileName = xmlNode3.InnerText;
												break;
											}
										}
									}
									finally
									{
										if (enumerator3 is IDisposable)
										{
											(enumerator3 as IDisposable).Dispose();
										}
									}
									campaign.CampaignItems.Add(scenarioRecord);
								}
								else
								{
									if (Operators.CompareString(name, "Attachment", TextCompare: false) != 0)
									{
										continue;
									}
									AttachmentRecord attachmentRecord = new AttachmentRecord();
									try
									{
										enumerator4 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator4.MoveNext())
										{
											XmlNode xmlNode4 = (XmlNode)enumerator4.Current;
											string name2 = xmlNode4.Name;
											if (Operators.CompareString(name2, "Name", TextCompare: false) == 0)
											{
												attachmentRecord.Name = xmlNode4.InnerText;
											}
											else if (Operators.CompareString(name2, "ID", TextCompare: false) == 0)
											{
												attachmentRecord.ID = xmlNode4.InnerText;
											}
										}
									}
									finally
									{
										if (enumerator4 is IDisposable)
										{
											(enumerator4 as IDisposable).Dispose();
										}
									}
									campaign.CampaignItems.Add(attachmentRecord);
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
						break;
					case "ID":
						campaign.ID = xmlNode.InnerText;
						break;
					case "EndingText":
						campaign.EndingText = xmlNode.InnerText;
						break;
					case "Description":
						campaign.Description = xmlNode.InnerText;
						break;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			result = campaign;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101312", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Campaign()
	{
		CampaignItems = new List<CampaignItem>();
		ID = Guid.NewGuid().ToString();
	}

	public static Campaign ReadFromFile(string string_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
		XmlDocument xmlDocument = new XmlDocument();
		using (fileStream)
		{
			xmlDocument.Load(fileStream);
		}
		XmlNode xmlNode_ = xmlDocument.ChildNodes[1];
		Campaign campaign = UpdateProperty(ref xmlNode_);
		campaign.FolderPath = Path.GetDirectoryName(string_0);
		return campaign;
	}

	public void Save(string string_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "    ";
			XmlWriter xmlWriter_ = XmlWriter.Create(fileStream, xmlWriterSettings);
			DisableProperty(ref xmlWriter_);
			xmlWriter_.Flush();
			fileStream.Flush();
		}
	}

	public static Campaign GetCampaignByID(string string_0, string string_1)
	{
		List<string> list = new List<string>();
		GetCampaignsInFolder(string_0, list);
		foreach (string item in list)
		{
			Campaign campaign = ReadFromFile(item);
			if (Operators.CompareString(campaign.ID, string_1, TextCompare: false) == 0)
			{
				return campaign;
			}
		}
		return null;
	}

	public static void GetCampaignsInFolder(string string_0, List<string> list_0)
	{
		if (!string_0.Equals(GameGeneral.ScenariosRootPath))
		{
			string[] files = Directory.GetFiles(string_0);
			string[] array = files;
			foreach (string text in array)
			{
				if (Operators.CompareString(Path.GetExtension(text), ".campaign", TextCompare: false) == 0)
				{
					list_0.Add(text);
				}
			}
		}
		string[] directories = Directory.GetDirectories(string_0);
		for (int i = 0; i < directories.Length; i = checked(i + 1))
		{
			GetCampaignsInFolder(directories[i], list_0);
		}
	}

	public ScenarioRecord GetScenarioRecord(string string_0)
	{
		foreach (CampaignItem campaignItem in CampaignItems)
		{
			if ((object)campaignItem.GetType() == typeof(ScenarioRecord) && Operators.CompareString(((ScenarioRecord)campaignItem).ID, string_0, TextCompare: false) == 0)
			{
				return (ScenarioRecord)campaignItem;
			}
		}
		return null;
	}

	public static string GetCampaignFilename(string string_0)
	{
		List<string> list = new List<string>();
		GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		foreach (string item in list)
		{
			if (Operators.CompareString(ReadFromFile(item).ID, string_0, TextCompare: false) == 0)
			{
				return item;
			}
		}
		return null;
	}

	public static int? GetCampaignScenarioPassScore(Scenario scenario_0)
	{
		int? result = null;
		List<string> list = new List<string>();
		GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		foreach (string item in list)
		{
			Campaign campaign = ReadFromFile(item);
			if (Operators.CompareString(campaign.ID, scenario_0.CampaignID, TextCompare: false) == 0)
			{
				ScenarioRecord scenarioRecord = campaign.GetScenarioRecord(scenario_0.ObjectID);
				if (scenarioRecord != null)
				{
					return scenarioRecord.PassScore;
				}
			}
		}
		return result;
	}

	public string GetFirstScenarioFilename(string string_0)
	{
		foreach (CampaignItem campaignItem in CampaignItems)
		{
			if ((object)campaignItem.GetType() == typeof(ScenarioRecord))
			{
				return Path.GetDirectoryName(string_0) + "\\" + ((ScenarioRecord)campaignItem).FileName;
			}
		}
		return null;
	}

	public static void UpdateHistory(string string_0, Campaign campaign_0, Scenario scenario_0)
	{
		int passScore = campaign_0.GetScenarioRecord(scenario_0.ObjectID).PassScore;
		_ = DateAndTime.Today;
		FileStream fileStream = new FileStream(Path.GetDirectoryName(string_0) + "\\" + scenario_0.CampaignSessionID + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
		XmlDocument xmlDocument = new XmlDocument();
		using (fileStream)
		{
			XmlNode xmlNode;
			XmlNode xmlNode2;
			if (fileStream.Length <= 0)
			{
				xmlNode = xmlDocument.CreateElement("Campaign");
				xmlDocument.AppendChild(xmlNode);
				xmlNode2 = xmlDocument.CreateElement("ID");
				xmlNode2.AppendChild(xmlDocument.CreateTextNode(campaign_0.ID));
				xmlNode.AppendChild(xmlNode2);
				xmlNode2 = xmlDocument.CreateElement("Name");
				xmlNode2.AppendChild(xmlDocument.CreateTextNode(campaign_0.Name));
				xmlNode.AppendChild(xmlNode2);
				xmlNode2 = xmlDocument.CreateElement("Scenarios");
				xmlNode.AppendChild(xmlNode2);
			}
			else
			{
				xmlDocument.Load(fileStream);
			}
			xmlNode = xmlDocument.SelectSingleNode("descendant::Scenarios");
			XmlNode xmlNode3 = xmlDocument.CreateElement("Scenario");
			xmlNode.AppendChild(xmlNode3);
			xmlNode2 = xmlDocument.CreateElement("Name");
			xmlNode2.AppendChild(xmlDocument.CreateTextNode(scenario_0.Title));
			xmlNode3.AppendChild(xmlNode2);
			xmlNode2 = xmlDocument.CreateElement("FileName");
			xmlNode2.AppendChild(xmlDocument.CreateTextNode(campaign_0.GetScenarioRecord(scenario_0.ObjectID).FileName));
			xmlNode3.AppendChild(xmlNode2);
			xmlNode2 = xmlDocument.CreateElement("ID");
			xmlNode2.AppendChild(xmlDocument.CreateTextNode(scenario_0.ObjectID));
			xmlNode3.AppendChild(xmlNode2);
			xmlNode2 = xmlDocument.CreateElement("Score");
			xmlNode2.AppendChild(xmlDocument.CreateTextNode(scenario_0.GetCurrentSide().GetTotalScore(scenario_0).ToString()));
			xmlNode3.AppendChild(xmlNode2);
			xmlNode2 = xmlDocument.CreateElement("PassScore");
			xmlNode2.AppendChild(xmlDocument.CreateTextNode(passScore.ToString()));
			xmlNode3.AppendChild(xmlNode2);
			xmlNode2 = xmlDocument.CreateElement("CompletedOn");
			xmlNode2.AppendChild(xmlDocument.CreateTextNode(DateAndTime.Today.ToLocalTime().ToString()));
			xmlNode3.AppendChild(xmlNode2);
			fileStream.Position = 0L;
			xmlDocument.Save(fileStream);
			fileStream.Flush();
		}
		fileStream.Close();
	}
}
