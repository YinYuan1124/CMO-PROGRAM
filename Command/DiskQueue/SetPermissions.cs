using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using DiskQueue.Implementation.CrossPlatform.Unix;

namespace DiskQueue;

public static class SetPermissions
{
	public static bool RunningUnderPosix
	{
		get
		{
			int platform = (int)Environment.OSVersion.Platform;
			if (platform != 4 && platform != 6)
			{
				return platform == 128;
			}
			return true;
		}
	}

	public static void AllowReadWriteForAll(string string_0)
	{
		if (Directory.Exists(string_0))
		{
			ValidateDispatcher(string_0);
			return;
		}
		if (!FileExistsNative.FileExistsFast(string_0))
		{
			throw new UnauthorizedAccessException("Can't access the path \"" + string_0 + "\"");
		}
		ViewDispatcher(string_0);
	}

	public static void TryAllowReadWriteForAll(string string_0)
	{
		try
		{
			if (Directory.Exists(string_0))
			{
				ValidateDispatcher(string_0);
			}
			else if (FileExistsNative.FileExistsFast(string_0))
			{
				ViewDispatcher(string_0);
			}
		}
		catch
		{
			LogoutDispatcher();
		}
	}

	private static void LogoutDispatcher()
	{
	}

	private static void ViewDispatcher(string string_0)
	{
		if (RunningUnderPosix)
		{
			UnsafeNativeMethods.chmod(string_0, UnixFilePermissions.ACCESSPERMS);
			return;
		}
		FileInfo fileInfo = new FileInfo(string_0);
		FileSecurity accessControl = fileInfo.GetAccessControl();
		SecurityIdentifier identity = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
		accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
		fileInfo.SetAccessControl(accessControl);
	}

	private static void ValidateDispatcher(string string_0)
	{
		if (RunningUnderPosix)
		{
			UnsafeNativeMethods.chmod(string_0, UnixFilePermissions.ACCESSPERMS);
			return;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
		DirectorySecurity accessControl = directoryInfo.GetAccessControl();
		SecurityIdentifier identity = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
		accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
		directoryInfo.SetAccessControl(accessControl);
	}
}
