using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.Messages;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[StandardModule]
public sealed class SteamWorkshop
{
	public sealed class WorkshopItem
	{
		[CompilerGenerated]
		private bool m_AlgoMap;

		[CompilerGenerated]
		private bool interceptorMap;

		[CompilerGenerated]
		private bool messageMap;

		[CompilerGenerated]
		private bool m_ProductMap;

		[CompilerGenerated]
		private PublishedFileId_t m_AnnotationMap;

		[CompilerGenerated]
		private bool iteratorMap;

		[CompilerGenerated]
		private ulong initializerMap;

		[CompilerGenerated]
		private ulong m_RoleMap;

		[CompilerGenerated]
		private bool m_FactoryMap;

		[CompilerGenerated]
		private ulong m_AttributeMap;

		[CompilerGenerated]
		private bool workerMap;

		public bool Subscribed
		{
			[CompilerGenerated]
			get
			{
				return m_AlgoMap;
			}
			[CompilerGenerated]
			set
			{
				m_AlgoMap = value;
			}
		}

		public bool Installed { get; set; }

		public bool NeedsUpdate
		{
			[CompilerGenerated]
			get
			{
				return interceptorMap;
			}
			[CompilerGenerated]
			set
			{
				interceptorMap = value;
			}
		}

		public bool Downloading
		{
			[CompilerGenerated]
			get
			{
				return messageMap;
			}
			[CompilerGenerated]
			set
			{
				messageMap = value;
			}
		}

		public bool DownloadPending
		{
			[CompilerGenerated]
			get
			{
				return m_ProductMap;
			}
			[CompilerGenerated]
			set
			{
				m_ProductMap = value;
			}
		}

		public PublishedFileId_t FileId
		{
			[CompilerGenerated]
			get
			{
				return m_AnnotationMap;
			}
			[CompilerGenerated]
			set
			{
				m_AnnotationMap = value;
			}
		}

		public bool DownloadInfoAvailable
		{
			[CompilerGenerated]
			get
			{
				return iteratorMap;
			}
			[CompilerGenerated]
			set
			{
				iteratorMap = value;
			}
		}

		public ulong BytesDownloaded
		{
			[CompilerGenerated]
			get
			{
				return initializerMap;
			}
			[CompilerGenerated]
			set
			{
				initializerMap = value;
			}
		}

		public ulong BytesTotal
		{
			[CompilerGenerated]
			get
			{
				return m_RoleMap;
			}
			[CompilerGenerated]
			set
			{
				m_RoleMap = value;
			}
		}

		public bool GoodToGo
		{
			[CompilerGenerated]
			get
			{
				return m_FactoryMap;
			}
			[CompilerGenerated]
			set
			{
				m_FactoryMap = value;
			}
		}

		public ulong punSizeOnDisk
		{
			[CompilerGenerated]
			get
			{
				return m_AttributeMap;
			}
			[CompilerGenerated]
			set
			{
				m_AttributeMap = value;
			}
		}

		public string pchFolder { get; set; }

		public uint punTimeStamp { get; set; }

		public bool AlreadyInstalled
		{
			[CompilerGenerated]
			get
			{
				return workerMap;
			}
			[CompilerGenerated]
			set
			{
				workerMap = value;
			}
		}

		public WorkshopItem(PublishedFileId_t publishedFileId_t_0)
		{
			FileId = publishedFileId_t_0;
			uint itemState = SteamUGC.GetItemState(publishedFileId_t_0);
			Subscribed = ((ulong)itemState & 1uL) != 0;
			Installed = ((ulong)itemState & 4uL) != 0;
			NeedsUpdate = ((ulong)itemState & 8uL) != 0;
			Downloading = ((ulong)itemState & 0x10uL) != 0;
			DownloadPending = ((ulong)itemState & 0x20uL) != 0;
			ulong bytesDownloaded = BytesDownloaded;
			ulong bytesTotal = BytesTotal;
			bool itemDownloadInfo = SteamUGC.GetItemDownloadInfo(publishedFileId_t_0, out bytesDownloaded, out bytesTotal);
			BytesTotal = bytesTotal;
			BytesDownloaded = bytesDownloaded;
			DownloadInfoAvailable = itemDownloadInfo;
			GoodToGo = true;
			if ((NeedsUpdate | !Installed) && SteamUGC.DownloadItem(publishedFileId_t_0, bHighPriority: false))
			{
				GoodToGo = false;
			}
			if (GoodToGo)
			{
				bytesTotal = punSizeOnDisk;
				string text = pchFolder;
				uint num = punTimeStamp;
				bool itemInstallInfo = SteamUGC.GetItemInstallInfo(publishedFileId_t_0, out bytesTotal, out text, 1024u, out num);
				punTimeStamp = num;
				pchFolder = text;
				punSizeOnDisk = bytesTotal;
				AlreadyInstalled = itemInstallInfo;
			}
		}

		public void CopyDataToScenarioFolder()
		{
			if (!Installed)
			{
				return;
			}
			try
			{
				if (Directory.Exists(pchFolder))
				{
					CopyDirectoryLazy(pchFolder, Client.RemoveConfiguration(), bool_0: true);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		public void CopyDirectoryLazy(string string_0, string string_1, bool bool_0)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			if (directoryInfo.Exists)
			{
				if (!Directory.Exists(string_1))
				{
					Directory.CreateDirectory(string_1);
				}
				FileInfo[] files = directoryInfo.GetFiles();
				FileInfo[] array2 = files;
				foreach (FileInfo fileInfo in array2)
				{
					string text = Path.Combine(string_1, fileInfo.Name);
					if (FileExistsNative.FileExistsFast(text))
					{
						FileInfo fileInfo2 = ItemExporter.RegisterInterruptibleMap.FileSystem.GetFileInfo(text);
						FileInfo fileInfo3 = ItemExporter.RegisterInterruptibleMap.FileSystem.GetFileInfo(fileInfo.FullName);
						if ((DateTime.Compare(fileInfo2.LastWriteTimeUtc, fileInfo3.LastWriteTimeUtc) == 0) & (fileInfo2.Length == fileInfo3.Length))
						{
							continue;
						}
					}
					fileInfo.CopyTo(text, overwrite: true);
					Thread.Sleep(100);
				}
				if (bool_0)
				{
					DirectoryInfo[] array = directories;
					DirectoryInfo[] array3 = array;
					foreach (DirectoryInfo directoryInfo2 in array3)
					{
						string string_2 = Path.Combine(string_1, directoryInfo2.Name);
						CopyDirectoryLazy(directoryInfo2.FullName, string_2, bool_0);
					}
				}
				return;
			}
			throw new DirectoryNotFoundException(Convert.ToString("源目录不存在或找不到：") + string_0);
		}
	}

	public sealed class SteamWorkshopScenario
	{
		public string Name;

		public string Description;

		public List<string> Tags;

		public string ScenFileName;

		public string PreviewFilePath;

		public string WorkingDirectory;
	}

	[CompilerGenerated]
	private sealed class AccountMap
	{
		public SteamUGCDetails_t Local_pDetails;

		internal bool CreateInterruptibleMethod(SteamUGCDetails_t F)
		{
			return F.m_nPublishedFileId.m_PublishedFileId == Local_pDetails.m_nPublishedFileId.m_PublishedFileId;
		}
	}

	public static SteamWorkshopScenario workshopScenarioUploadInformation;

	private static List<PublishedFileId_t> codeException;

	public static List<WorkshopItem> SubscribedWorkshopItems;

	public static ERemoteStoragePublishedFileVisibility visibiltyWorkshopItem;

	private static CallResult<CreateItemResult_t> _ConnectionException;

	private static CreateItemResult_t m_ContextException;

	private static CallResult<SubmitItemUpdateResult_t> _StatusException;

	private static SubmitItemUpdateResult_t _ProccesorException;

	private static CallResult<RemoteStoragePublishedFileSubscribed_t> m_StrategyException;

	private static RemoteStoragePublishedFileSubscribed_t _ConfigurationException;

	private static CallResult<RemoteStoragePublishedFileUnsubscribed_t> _TokenException;

	private static RemoteStoragePublishedFileUnsubscribed_t _IndexerException;

	private static CallResult<ItemInstalled_t> resolverException;

	private static ItemInstalled_t publisherException;

	private static CallResult<DownloadItemResult_t> _ServerException;

	private static DownloadItemResult_t adapterException;

	private static CallResult<SteamUGCQueryCompleted_t> m_SchemaException;

	private static SteamUGCQueryCompleted_t _UtilsException;

	private static object predicateException;

	private static bool _SingletonException;

	private static UGCQueryHandle_t _RecordException;

	public static List<SteamUGCDetails_t> UserScens;

	private static uint _ExceptionException;

	private static uint _AttrException;

	static SteamWorkshop()
	{
		SubscribedWorkshopItems = new List<WorkshopItem>();
		visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
		predicateException = RuntimeHelpers.GetObjectValue(new object());
		_SingletonException = false;
		UserScens = new List<SteamUGCDetails_t>();
		_ExceptionException = 0u;
		_AttrException = 0u;
	}

	public static void Update(SteamWorkshopScenario steamWorkshopScenario_0, SteamUGCDetails_t steamUGCDetails_t_0)
	{
		if (CommandSteam.steamOnline)
		{
			ItemExporter.ConnectInterruptibleTemplate.SteamUpdateScenarioForm.Enabled = false;
			workshopScenarioUploadInformation = steamWorkshopScenario_0;
			if (workshopScenarioUploadInformation.Name.Length > 120)
			{
				workshopScenarioUploadInformation.Name = workshopScenarioUploadInformation.Name.Substring(0, 100);
			}
			if (workshopScenarioUploadInformation.Description.Length > 7500)
			{
				workshopScenarioUploadInformation.Description = workshopScenarioUploadInformation.Description.Substring(0, 7500);
			}
			workshopScenarioUploadInformation.Tags = new List<string>();
			workshopScenarioUploadInformation.Tags.Add("Scenario");
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.Name))
			{
				throw new ArgumentNullException();
			}
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.Description))
			{
				throw new ArgumentNullException();
			}
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.ScenFileName))
			{
				throw new ArgumentNullException();
			}
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.PreviewFilePath))
			{
				throw new ArgumentNullException();
			}
			workshopScenarioUploadInformation.WorkingDirectory = Path.Combine(Path.GetTempPath() + workshopScenarioUploadInformation.ScenFileName);
			Directory.CreateDirectory(workshopScenarioUploadInformation.WorkingDirectory);
			Directory.CreateDirectory(Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments"));
			Client.SaveCurrentScenario(bool_0: false, Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, workshopScenarioUploadInformation.ScenFileName + ".scen"));
			workshopScenarioUploadInformation.PreviewFilePath = Path.GetFullPath(workshopScenarioUploadInformation.PreviewFilePath);
			foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in Client.CurrentScenario.ScenAttachments)
			{
				if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
				{
					Misc.CopyDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments", scenAttachment.Key), bool_0: true);
				}
			}
			UGCUpdateHandle_t val = SteamUGC.StartItemUpdate(Licensing.appID_FullBaseVersion, steamUGCDetails_t_0.m_nPublishedFileId);
			SteamUGC.SetItemTitle(val, workshopScenarioUploadInformation.Name);
			SteamUGC.SetItemDescription(val, workshopScenarioUploadInformation.Description);
			SteamUGC.SetItemVisibility(val, visibiltyWorkshopItem);
			SteamUGC.SetItemTags(val, workshopScenarioUploadInformation.Tags);
			SteamUGC.SetItemContent(val, workshopScenarioUploadInformation.WorkingDirectory);
			SteamUGC.SetItemPreview(val, workshopScenarioUploadInformation.PreviewFilePath);
			SteamAPICall_t val2 = SteamUGC.SubmitItemUpdate(val, "Update");
			_StatusException.Set(val2);
			return;
		}
		throw new WorkshopNotSupportedException();
	}

	public static void Publish(SteamWorkshopScenario steamWorkshopScenario_0)
	{
		if (CommandSteam.steamOnline)
		{
			ItemExporter.ConnectInterruptibleTemplate.SteamPublishScenarioForm.Enabled = false;
			workshopScenarioUploadInformation = steamWorkshopScenario_0;
			if (workshopScenarioUploadInformation.Name.Length > 120)
			{
				workshopScenarioUploadInformation.Name = workshopScenarioUploadInformation.Name.Take(127).ToString();
			}
			if (workshopScenarioUploadInformation.Description.Length > 7500)
			{
				workshopScenarioUploadInformation.Description = workshopScenarioUploadInformation.Description.Take(7999).ToString();
			}
			workshopScenarioUploadInformation.Tags = new List<string>();
			workshopScenarioUploadInformation.Tags.Add("Scenario");
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.Name))
			{
				throw new ArgumentNullException();
			}
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.Description))
			{
				throw new ArgumentNullException();
			}
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.ScenFileName))
			{
				throw new ArgumentNullException();
			}
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.PreviewFilePath))
			{
				throw new ArgumentNullException();
			}
			workshopScenarioUploadInformation.WorkingDirectory = Path.Combine(Path.GetTempPath() + workshopScenarioUploadInformation.ScenFileName);
			Directory.CreateDirectory(workshopScenarioUploadInformation.WorkingDirectory);
			Directory.CreateDirectory(Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments"));
			Client.SaveCurrentScenario(bool_0: false, Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, workshopScenarioUploadInformation.ScenFileName + ".scen"));
			workshopScenarioUploadInformation.PreviewFilePath = Path.GetFullPath(workshopScenarioUploadInformation.PreviewFilePath);
			foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in Client.CurrentScenario.ScenAttachments)
			{
				if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
				{
					Misc.CopyDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments", scenAttachment.Key), bool_0: true);
				}
			}
			SteamAPICall_t val = SteamUGC.CreateItem(Licensing.appID_FullBaseVersion, EWorkshopFileType.k_EWorkshopFileTypeFirst);
			_ConnectionException.Set(val);
			return;
		}
		throw new WorkshopNotSupportedException();
	}

	public static void Open()
	{
		if (CommandSteam.steamOnline)
		{
			_ConnectionException = new CallResult<CreateItemResult_t>(SetupInterruptibleException);
			_StatusException = new CallResult<SubmitItemUpdateResult_t>(InvokeInterruptibleException);
			m_StrategyException = new CallResult<RemoteStoragePublishedFileSubscribed_t>(ExcludeInterruptibleException);
			_TokenException = new CallResult<RemoteStoragePublishedFileUnsubscribed_t>(IncludeInterruptibleException);
			resolverException = new CallResult<ItemInstalled_t>(SearchInterruptibleException);
			_ServerException = new CallResult<DownloadItemResult_t>(PushInterruptibleException);
			m_SchemaException = new CallResult<SteamUGCQueryCompleted_t>(NewInterruptibleException);
			UpdateSubscribedItems();
			QueryUserUGC();
		}
	}

	public static void UpdateSubscribedItems()
	{
		if (_SingletonException)
		{
			return;
		}
		object obj = predicateException;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			_SingletonException = true;
			if (!CommandSteam.steamOnline)
			{
				return;
			}
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems + 1];
			SteamUGC.GetSubscribedItems(array, numSubscribedItems);
			codeException = array.ToList();
			List<WorkshopItem> list = new List<WorkshopItem>();
			foreach (PublishedFileId_t item in codeException)
			{
				list.Add(new WorkshopItem(item));
			}
			SubscribedWorkshopItems = list;
			QueryUserUGC();
			_SingletonException = false;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private static void GetInterruptibleException(PublishedFileId_t publishedFileId_t_0)
	{
		WorkshopItem workshopItem = new WorkshopItem(publishedFileId_t_0);
		if (workshopItem.GoodToGo)
		{
			workshopItem.CopyDataToScenarioFolder();
		}
	}

	public static void RunCallbacks()
	{
		if (CommandSteam.steamOnline)
		{
			SteamAPI.RunCallbacks();
		}
	}

	private static void WriteInterruptibleException(object object_0, bool bool_0)
	{
		if (CommandSteam.steamOnline)
		{
			if (bool_0)
			{
				throw new WorkshopException("IO失败");
			}
			if (object_0 == null)
			{
				throw new WorkshopException("空回调对象");
			}
			return;
		}
		throw new WorkshopNotSupportedException();
	}

	public static void QueryUserUGC()
	{
		CSteamID steamID = SteamUser.GetSteamID();
		CSteamID cSteamID = steamID;
		UGCQueryHandle_t val = SteamUGC.CreateQueryUserUGCRequest(cSteamID.GetAccountID(), EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, Licensing.appID_FullBaseVersion, Licensing.appID_FullBaseVersion, 1u);
		_ExceptionException = 0u;
		_AttrException = 1u;
		SteamAPICall_t val2 = SteamUGC.SendQueryUGCRequest(val);
		m_SchemaException.Set(val2);
		UserScens = new List<SteamUGCDetails_t>();
	}

	private static void NewInterruptibleException(SteamUGCQueryCompleted_t steamUGCQueryCompleted_t_0, bool bool_0)
	{
		WriteInterruptibleException(steamUGCQueryCompleted_t_0, bool_0);
		uint unNumResultsReturned = steamUGCQueryCompleted_t_0.m_unNumResultsReturned;
		for (uint num = 0u; num <= unNumResultsReturned; num++)
		{
			SteamUGCDetails_t Local_pDetails = default(SteamUGCDetails_t);
			SteamUGC.GetQueryUGCResult(steamUGCQueryCompleted_t_0.m_handle, num, out Local_pDetails);
			if (!UserScens.Any((SteamUGCDetails_t F) => F.m_nPublishedFileId.m_PublishedFileId == Local_pDetails.m_nPublishedFileId.m_PublishedFileId))
			{
				UserScens.Add(Local_pDetails);
			}
		}
		_ExceptionException += steamUGCQueryCompleted_t_0.m_unNumResultsReturned;
		SteamUGC.ReleaseQueryUGCRequest(_RecordException);
		if (_ExceptionException < steamUGCQueryCompleted_t_0.m_unTotalMatchingResults)
		{
			_AttrException = (uint)((ulong)_AttrException + 1uL);
			CSteamID steamID = SteamUser.GetSteamID();
			CSteamID cSteamID = steamID;
			_RecordException = SteamUGC.CreateQueryUserUGCRequest(cSteamID.GetAccountID(), EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, Licensing.appID_FullBaseVersion, Licensing.appID_FullBaseVersion, _AttrException);
			SteamAPICall_t val = SteamUGC.SendQueryUGCRequest(_RecordException);
			m_SchemaException.Set(val);
		}
	}

	private static void PushInterruptibleException(DownloadItemResult_t downloadItemResult_t_0, bool bool_0)
	{
		WriteInterruptibleException(downloadItemResult_t_0, bool_0);
		if (downloadItemResult_t_0.m_unAppID.m_AppId == Licensing.appID_FullBaseVersion.m_AppId)
		{
			adapterException = downloadItemResult_t_0;
			GetInterruptibleException(downloadItemResult_t_0.m_nPublishedFileId);
		}
	}

	private static void InvokeInterruptibleException(SubmitItemUpdateResult_t submitItemUpdateResult_t_0, bool bool_0)
	{
		WriteInterruptibleException(submitItemUpdateResult_t_0, bool_0);
		_ProccesorException = submitItemUpdateResult_t_0;
		if (_ProccesorException.m_eResult == EResult.k_EResultOK)
		{
			DarkMessageBox.ShowInformation("该想定已成功上传到Steam！", "Success");
			ItemExporter.ConnectInterruptibleTemplate.SteamPublishScenarioForm.Enabled = true;
			ItemExporter.ConnectInterruptibleTemplate.SteamPublishScenarioForm.Close();
		}
		else
		{
			DarkMessageBox.ShowError("将想定上传到Steam时出现问题。错误代码是：" + _ProccesorException.m_eResult, "Error");
		}
		if (_ProccesorException.m_bUserNeedsToAcceptWorkshopLegalAgreement)
		{
			Process.Start("http: //steamcommunity.com/sharedfiles/workshoplegalagreement");
			DarkMessageBox.ShowInformation("请接受Steam Workshop法律协议。", "");
		}
		if (!Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.SteamPublishScenarioForm))
		{
			ItemExporter.ConnectInterruptibleTemplate.SteamPublishScenarioForm.Enabled = true;
			ItemExporter.ConnectInterruptibleTemplate.SteamPublishScenarioForm.Close();
		}
		if (!Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.SteamUpdateScenarioForm))
		{
			ItemExporter.ConnectInterruptibleTemplate.SteamUpdateScenarioForm.Enabled = true;
			ItemExporter.ConnectInterruptibleTemplate.SteamUpdateScenarioForm.Close();
		}
		if (!Directory.Exists(workshopScenarioUploadInformation.WorkingDirectory))
		{
			return;
		}
		try
		{
			Directory.Delete(workshopScenarioUploadInformation.WorkingDirectory, recursive: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200423", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void SetupInterruptibleException(CreateItemResult_t createItemResult_t_0, bool bool_0)
	{
		WriteInterruptibleException(createItemResult_t_0, bool_0);
		m_ContextException = createItemResult_t_0;
		if (m_ContextException.m_bUserNeedsToAcceptWorkshopLegalAgreement)
		{
			Process.Start("http://steamcommunity.com/sharedfiles/workshoplegalagreement");
			DarkMessageBox.ShowInformation("请接受Steam Workshop法律协议。", "");
		}
		UGCUpdateHandle_t val = SteamUGC.StartItemUpdate(Licensing.appID_FullBaseVersion, m_ContextException.m_nPublishedFileId);
		SteamUGC.SetItemTitle(val, workshopScenarioUploadInformation.Name);
		SteamUGC.SetItemDescription(val, workshopScenarioUploadInformation.Description);
		SteamUGC.SetItemVisibility(val, visibiltyWorkshopItem);
		SteamUGC.SetItemTags(val, workshopScenarioUploadInformation.Tags);
		SteamUGC.SetItemContent(val, workshopScenarioUploadInformation.WorkingDirectory);
		SteamUGC.SetItemPreview(val, workshopScenarioUploadInformation.PreviewFilePath);
		SteamAPICall_t val2 = SteamUGC.SubmitItemUpdate(val, "初始上传");
		_StatusException.Set(val2);
	}

	private static void ExcludeInterruptibleException(RemoteStoragePublishedFileSubscribed_t remoteStoragePublishedFileSubscribed_t_0, bool bool_0)
	{
		WriteInterruptibleException(remoteStoragePublishedFileSubscribed_t_0, bool_0);
		_ConfigurationException = remoteStoragePublishedFileSubscribed_t_0;
		GetInterruptibleException(remoteStoragePublishedFileSubscribed_t_0.m_nPublishedFileId);
	}

	private static void IncludeInterruptibleException(RemoteStoragePublishedFileUnsubscribed_t remoteStoragePublishedFileUnsubscribed_t_0, bool bool_0)
	{
		WriteInterruptibleException(remoteStoragePublishedFileUnsubscribed_t_0, bool_0);
		_IndexerException = remoteStoragePublishedFileUnsubscribed_t_0;
		GetInterruptibleException(remoteStoragePublishedFileUnsubscribed_t_0.m_nPublishedFileId);
	}

	private static void SearchInterruptibleException(ItemInstalled_t itemInstalled_t_0, bool bool_0)
	{
		WriteInterruptibleException(itemInstalled_t_0, bool_0);
		if (itemInstalled_t_0.m_unAppID.m_AppId == Licensing.appID_FullBaseVersion.m_AppId)
		{
			publisherException = itemInstalled_t_0;
			GetInterruptibleException(itemInstalled_t_0.m_nPublishedFileId);
		}
	}
}
