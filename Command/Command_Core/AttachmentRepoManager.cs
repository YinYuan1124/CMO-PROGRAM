using System.Collections.Generic;
using System.IO;
using System.Linq;
using Command_Core.LoadSave;
using Microsoft.VisualBasic.CompilerServices;
using SevenZip;

namespace Command_Core;

[StandardModule]
public sealed class AttachmentRepoManager
{
	private static SevenZipCompressor refObserver;

	public static void PackageScenarioForDistribution(Scenario scenario_0, Side side_0, string string_0)
	{
		if (scenario_0.ScenAttachments.Count == 0)
		{
			return;
		}
		if (Directory.Exists(Path.Combine(GameGeneral.TempPath, "package")))
		{
			Directory.Delete(Path.Combine(GameGeneral.TempPath, "package"), recursive: true);
		}
		Directory.CreateDirectory(Path.Combine(GameGeneral.TempPath, "package"));
		Command_Core.LoadSave.LoadSave.SaveScenario(scenario_0, side_0, Path.Combine(GameGeneral.TempPath, "package", Path.GetFileNameWithoutExtension(string_0) + ".scen"), bool_0: false);
		Directory.CreateDirectory(Path.Combine(GameGeneral.TempPath, "package\\attachments"));
		foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in scenario_0.ScenAttachments)
		{
			if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
			{
				Misc.CopyDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), Path.Combine(GameGeneral.TempPath, "package\\attachments", scenAttachment.Key), bool_0: true);
			}
		}
		refObserver = new SevenZipCompressor();
		refObserver.ArchiveFormat = OutArchiveFormat.Zip;
		refObserver.CompressionLevel = CompressionLevel.Fast;
		refObserver.CompressDirectory(Path.Combine(GameGeneral.TempPath, "package"), string_0, recursion: true);
		Directory.Delete(Path.Combine(GameGeneral.TempPath, "package"), recursive: true);
		refObserver = null;
	}

	public static void MoveAttachmentsToLocalRepo(Scenario scenario_0, string string_0)
	{
		string text = Path.Combine(Path.GetDirectoryName(string_0), "attachments");
		if (!Directory.Exists(text))
		{
			return;
		}
		foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in scenario_0.ScenAttachments)
		{
			if (Directory.Exists(Path.Combine(text, scenAttachment.Key)))
			{
				if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
				{
					Directory.Delete(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), recursive: true);
				}
				Directory.Move(Path.Combine(text, scenAttachment.Key), Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key));
			}
		}
		if (Directory.Exists(text) && Directory.EnumerateFileSystemEntries(text).Count() == 0)
		{
			Directory.Delete(text);
		}
	}

	public static void MoveAttachmentsToLocalRepo(string string_0)
	{
		string text = Path.Combine(string_0, "attachments");
		if (!Directory.Exists(text))
		{
			return;
		}
		string[] directories = Directory.GetDirectories(text);
		string[] array = directories;
		foreach (string path in array)
		{
			if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, Path.GetFileName(path))))
			{
				Directory.Delete(Path.Combine(GameGeneral.AttachmentRepoPath, Path.GetFileName(path)), recursive: true);
			}
			Directory.Move(Path.Combine(text, Path.GetFileName(path)), Path.Combine(GameGeneral.AttachmentRepoPath, Path.GetFileName(path)));
		}
		if (Directory.Exists(text) && Directory.EnumerateFileSystemEntries(text).Count() == 0)
		{
			Directory.Delete(text);
		}
	}
}
