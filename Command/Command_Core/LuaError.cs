using System;
using System.Text;
using Command_Core.Lua;
using KeraLua;

namespace Command_Core;

public sealed class LuaError : Exception
{
	public string sMessage;

	public string sFunctionName;

	public int sLine;

	private LuaDebug _LuaDebug;

	public LuaError(string string_0, string string_1 = null)
	{
		_LuaDebug = default(LuaDebug);
		sMessage = string_0;
		if (string_1 == null)
		{
			sFunctionName = LuaSandBox.Singleton().currentFunction;
		}
		else
		{
			sFunctionName = string_1;
		}
		LuaSandBox.Singleton().lastError = sFunctionName + "/" + string_0;
		LuaSandBox.Singleton().SB_Getinfo("nSl", ref _LuaDebug);
		sLine = _LuaDebug.CurrentLine;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		stringBuilder.Append("函数：" + sFunctionName).Append(" (" + sLine + ") ").Append(" 错误： " + sMessage);
		string string_2 = "... ";
		object object_ = stringBuilder.ToString();
		LuaUtility.AddToLuaHistoryFile(ref string_2, ref object_);
		LuaSandBox.Singleton().SB_Lua()["_errmsg_"] = string_0;
		LuaSandBox.Singleton().SB_Lua()["_errfnc_"] = sFunctionName;
		LuaSandBox.Singleton().SB_Lua()["_errnum_"] = 1;
	}
}
