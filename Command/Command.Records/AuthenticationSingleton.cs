using System;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Records;

[StandardModule]
internal sealed class AuthenticationSingleton
{
	public static SoundHandler_Music m_ParamsSingleton;

	public static SoundHandler_Effects m_InfoSingleton;

	public static void NewInterruptibleSchema()
	{
		try
		{
			m_ParamsSingleton = new SoundHandler_Music();
			m_InfoSingleton = new SoundHandler_Effects();
			m_InfoSingleton.Volume = SimConfiguration.DefaultGamePreferences.Int32_0;
			m_ParamsSingleton.Volume = SimConfiguration.DefaultGamePreferences.MusicVolume;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200419", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			InvokeInterruptibleSchema(exception_);
			ProjectData.ClearProjectError();
		}
	}

	public static void PushInterruptibleSchema()
	{
		try
		{
			m_ParamsSingleton.StartPlayingMusic();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200420", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			InvokeInterruptibleSchema(exception_);
			ProjectData.ClearProjectError();
		}
	}

	public static void InvokeInterruptibleSchema(Exception exception_0)
	{
		DarkMessageBox.ShowError("声音出现严重错误。错误描述是：" + exception_0.Message + "。现在将禁用声音效果和音乐。请使用此信息与Command开发团队联系，以帮助他们解决此问题。", "严重的声音问题");
		SimConfiguration.DefaultGamePreferences.GameSounds = false;
		SimConfiguration.DefaultGamePreferences.GameMusic = false;
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
	}
}
