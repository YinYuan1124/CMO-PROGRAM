using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class SoundHandler_Music
{
	[CompilerGenerated]
	private sealed class AccountMerchantService
	{
		public SoundHandler_Music _003C_003E4__this;

		public string string_1;

		internal void PopInterruptibleMethod()
		{
			_003C_003E4__this.MusicPlayer.Open(new Uri(string_1));
			_003C_003E4__this.MusicPlayer.Play();
		}
	}

	private string structRecord;

	private bool m_MerchantRecord;

	[AccessedThroughProperty("MusicPlayer")]
	[CompilerGenerated]
	private MediaPlayer callbackRecord;

	private int decoratorRecord;

	private double processRecord;

	public MediaPlayer MusicPlayer
	{
		[CompilerGenerated]
		get
		{
			return callbackRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = delegate
			{
				ConcatInterruptibleSchema();
			};
			MediaPlayer mediaPlayer = callbackRecord;
			if (mediaPlayer != null)
			{
				mediaPlayer.MediaEnded -= value2;
			}
			callbackRecord = value;
			mediaPlayer = callbackRecord;
			if (mediaPlayer != null)
			{
				mediaPlayer.MediaEnded += value2;
			}
		}
	}

	public int Volume
	{
		get
		{
			return decoratorRecord;
		}
		set
		{
			decoratorRecord = value;
			processRecord = (double)value / 100.0;
			MusicPlayer.Volume = processRecord;
			SimConfiguration.DefaultGamePreferences.MusicVolume = value;
		}
	}

	public SoundHandler_Music()
	{
		structRecord = ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Sound\\Music\\";
		MusicPlayer = new MediaPlayer();
	}

	public void StartPlayingMusic()
	{
		m_MerchantRecord = false;
		if (FileExistsNative.FileExistsFast(structRecord + "Title.mp3"))
		{
			CheckInterruptibleSchema(structRecord + "Title.mp3");
		}
	}

	public void StopPlayingMusic()
	{
		m_MerchantRecord = true;
		if (!Information.IsNothing(MusicPlayer))
		{
			MusicPlayer.Stop();
		}
	}

	private void CheckInterruptibleSchema(string string_0)
	{
		try
		{
			MusicPlayer.Dispatcher.Invoke(delegate
			{
				MusicPlayer.Open(new Uri(string_0));
				MusicPlayer.Play();
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200422", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ConcatInterruptibleSchema()
	{
		if (!m_MerchantRecord)
		{
			List<string> list = Directory.GetFiles(structRecord).ToList();
			if (list.Count != 0)
			{
				Misc.Shuffle(list);
				CheckInterruptibleSchema(list[0]);
			}
		}
	}

	[CompilerGenerated]
	private void InterruptInterruptibleSchema(object sender, EventArgs e)
	{
		ConcatInterruptibleSchema();
	}
}
