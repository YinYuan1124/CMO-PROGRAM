using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Command_Core.SendFileTo;

public sealed class MAPI
{
	public enum howTo
	{
		MAPI_ORIG,
		MAPI_TO,
		MAPI_CC,
		MAPI_BCC
	}

	private readonly string[] mappingReader;

	private List<MapiRecipDesc> _MockReader;

	private List<string> _TagReader;

	private int _FieldReader;

	public MAPI()
	{
		mappingReader = new string[27]
		{
			"OK [0]", "User abort [1]", "General MAPI failure [2]", "MAPI login failure [3]", "Disk full [4]", "Insufficient memory [5]", "Access denied [6]", "-unknown- [7]", "Too many sessions [8]", "Too many files were specified [9]",
			"Too many recipients were specified [10]", "A specified attachment was not found [11]", "Attachment open failure [12]", "Attachment write failure [13]", "Unknown recipient [14]", "Bad recipient type [15]", "No messages [16]", "Invalid message [17]", "Text too large [18]", "Invalid session [19]",
			"Type not supported [20]", "A recipient was specified ambiguously [21]", "Message in use [22]", "Network failure [23]", "Invalid edit fields [24]", "Invalid recipients [25]", "Not supported [26]"
		};
		_MockReader = new List<MapiRecipDesc>();
		_TagReader = new List<string>();
		_FieldReader = 0;
	}

	internal bool RegisterDescriptor(string string_0)
	{
		return MoveList(string_0, howTo.MAPI_TO);
	}

	internal bool ManageDescriptor(string string_0)
	{
		return MoveList(string_0, howTo.MAPI_TO);
	}

	internal bool RevertDescriptor(string string_0)
	{
		return MoveList(string_0, howTo.MAPI_TO);
	}

	public void AddAttachment(string string_0)
	{
		_TagReader.Add(string_0);
	}

	internal int CountList(string string_0, string string_1)
	{
		return ConnectList(string_0, string_1, 9);
	}

	internal int CustomizeList(string string_0, string string_1)
	{
		return ConnectList(string_0, string_1, 1);
	}

	[DllImport("MAPI32.DLL")]
	private static extern int MAPISendMail(IntPtr intptr_0, IntPtr intptr_1, MapiMessage mapiMessage_0, int int_0, int int_1);

	private int ConnectList(string string_0, string string_1, int int_0)
	{
		MapiMessage mapiMessage_ = new MapiMessage();
		mapiMessage_.subject = string_0;
		mapiMessage_.noteText = string_1;
		mapiMessage_.recips = DeleteList(ref mapiMessage_.recipCount);
		mapiMessage_.files = AddList(ref mapiMessage_.fileCount);
		_FieldReader = MAPISendMail(new IntPtr(0), new IntPtr(0), mapiMessage_, int_0, 0);
		if (_FieldReader > 1)
		{
			GameGeneral.ResolveBridge("MAPISendMail failed! " + ComputeList(), null);
		}
		DestroyList(ref mapiMessage_);
		return _FieldReader;
	}

	private bool MoveList(string string_0, howTo howTo_0)
	{
		MapiRecipDesc mapiRecipDesc = new MapiRecipDesc();
		mapiRecipDesc.recipClass = (int)howTo_0;
		mapiRecipDesc.name = string_0;
		_MockReader.Add(mapiRecipDesc);
		return true;
	}

	private IntPtr DeleteList(ref int int_0)
	{
		int_0 = 0;
		if (_MockReader.Count == 0)
		{
			return (IntPtr)0;
		}
		int num = Marshal.SizeOf(typeof(MapiRecipDesc));
		IntPtr intPtr = Marshal.AllocHGlobal(_MockReader.Count * num);
		int num2 = (int)intPtr;
		foreach (MapiRecipDesc item in _MockReader)
		{
			Marshal.StructureToPtr(item, (IntPtr)num2, fDeleteOld: false);
			num2 += num;
		}
		int_0 = _MockReader.Count;
		return intPtr;
	}

	private IntPtr AddList(ref int int_0)
	{
		int_0 = 0;
		if (_TagReader == null)
		{
			return (IntPtr)0;
		}
		if ((_TagReader.Count <= 0) | (_TagReader.Count > 20))
		{
			return (IntPtr)0;
		}
		int num = Marshal.SizeOf(typeof(MapiFileDesc));
		IntPtr intPtr = Marshal.AllocHGlobal(_TagReader.Count * num);
		MapiFileDesc mapiFileDesc = new MapiFileDesc();
		mapiFileDesc.position = -1;
		int num2 = (int)intPtr;
		foreach (string item in _TagReader)
		{
			mapiFileDesc.name = Path.GetFileName(item);
			mapiFileDesc.path = item;
			Marshal.StructureToPtr(mapiFileDesc, (IntPtr)num2, fDeleteOld: false);
			num2 += num;
		}
		int_0 = _TagReader.Count;
		return intPtr;
	}

	private void DestroyList(ref MapiMessage mapiMessage_0)
	{
		int num = Marshal.SizeOf(typeof(MapiRecipDesc));
		int num2 = 0;
		if (mapiMessage_0.recips != IntPtr.Zero)
		{
			num2 = (int)mapiMessage_0.recips;
			int num3 = mapiMessage_0.recipCount - 1;
			int num4 = 0;
			int num5 = 1;
			for (num4 = 0; ((num5 >> 31) ^ num4) <= ((num5 >> 31) ^ num3); num4 += num5)
			{
				Marshal.DestroyStructure((IntPtr)num2, typeof(MapiRecipDesc));
				num2 += num;
			}
			Marshal.FreeHGlobal(mapiMessage_0.recips);
		}
		if (mapiMessage_0.files != IntPtr.Zero)
		{
			num = Marshal.SizeOf(typeof(MapiFileDesc));
			num2 = (int)mapiMessage_0.files;
			int num6 = mapiMessage_0.fileCount - 1;
			int num7 = 0;
			int num8 = 1;
			for (num7 = 0; ((num8 >> 31) ^ num7) <= ((num8 >> 31) ^ num6); num7 += num8)
			{
				Marshal.DestroyStructure((IntPtr)num2, typeof(MapiFileDesc));
				num2 += num;
			}
			Marshal.FreeHGlobal(mapiMessage_0.files);
		}
		_MockReader.Clear();
		_TagReader.Clear();
		_FieldReader = 0;
	}

	internal string ComputeList()
	{
		if (_FieldReader <= 26)
		{
			return mappingReader[_FieldReader];
		}
		return "MAPI error [" + _FieldReader + "]";
	}
}
