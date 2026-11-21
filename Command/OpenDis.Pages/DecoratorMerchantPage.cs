using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command;
using Command.Messages;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace OpenDis.Pages;

[StandardModule]
internal sealed class DecoratorMerchantPage
{
	[CompilerGenerated]
	private sealed class ObserverMerchantPage
	{
		public DialogResult dialogResult;

		public string message;

		public DarkDialogButton buttons;

		internal void DestroyInterruptibleRules()
		{
			dialogResult = DarkMessageBox.ShowInformation(message, "Incoming message", buttons);
		}
	}

	[CompilerGenerated]
	private sealed class ProccesorMap
	{
		public string text;

		public string prompt;

		internal void ComputeInterruptibleRules()
		{
			text = Interaction.InputBox(prompt).ToString();
		}
	}

	[CompilerGenerated]
	private sealed class TokenDispatcherList
	{
		public object Local_result;

		public string Local_Title;

		public string Local_Description;

		public List<string> Local_TheList;

		internal void PatchInterruptibleRules()
		{
			Local_result = RuntimeHelpers.GetObjectValue(AdvancedDialog.CallHTMLDialog(Local_Title, Local_Description, Local_TheList.ToArray()));
		}
	}

	[CompilerGenerated]
	private sealed class RecordRegistryFilter
	{
		public string Local_result;

		public string Local_Title;

		public string Local_Description;

		public List<string> Local_TheList;

		internal void SelectInterruptibleRules()
		{
			Local_result = AdvancedDialog.CallDialog(Local_Title, Local_Description, Local_TheList.ToArray());
		}
	}

	[CompilerGenerated]
	private sealed class InvocationProcessProducer
	{
		public string text;

		internal void CallInterruptibleRules()
		{
			Scenario.enumTimeCompression timeCompression = Client.CurrentScenario.TimeCompression;
			Client.CurrentGame.Pause();
			Client.CloseAllOpenWindows(bool_0: true);
			if (text == null)
			{
				Client.CreateNewScenario();
			}
			else
			{
				Client.CreateNewScenario(text);
			}
			Client.MustRefreshMainForm = true;
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			Client.MustRefreshMainForm = true;
			Client.CurrentScenario.TimeCompression_Set(timeCompression);
			Client.CurrentGame.Run();
		}
	}

	private static ConcurrentQueue<Tuple<string, bool, int>> getterModel;

	[AccessedThroughProperty("TheTimer")]
	[CompilerGenerated]
	private static Timer m_ProducerModel;

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void SelectWorker(Timer timer_0)
	{
		EventHandler value = CloneWorker;
		Timer producerModel = m_ProducerModel;
		if (producerModel != null)
		{
			producerModel.Tick -= value;
		}
		m_ProducerModel = timer_0;
		producerModel = m_ProducerModel;
		if (producerModel != null)
		{
			producerModel.Tick += value;
		}
	}

	static DecoratorMerchantPage()
	{
		getterModel = new ConcurrentQueue<Tuple<string, bool, int>>();
		SelectWorker(new Timer());
	}

	public static void RegisterGlobal()
	{
		PrivateMethods.LuaMessageBox += RevertGlobal;
		PrivateMethods.LuaLocalVideo += CustomizeWorker;
		PrivateMethods.LuaInputBox += CountWorker;
		PrivateMethods.LuaGame += DestroyWorker;
		PrivateMethods.LuaSelectUnitsPrompt_OwnSide += delegate(ref LuaTable a0, bool a1)
		{
			DeleteWorker(ref a0, a1);
		};
		PrivateMethods.LuaSelectUnitsPrompt_FromSides += delegate(ref LuaTable a0, LuaTable a1, bool a2)
		{
			AddWorker(ref a0, a1, a2);
		};
		PrivateMethods.LuaCallAdvancedDialog += delegate(string a0, string a1, LuaTable a2, ref string a3)
		{
			MoveWorker(a0, a1, a2, ref a3);
		};
		PrivateMethods.LuaCallAdvancedHTMLDialog += delegate(string a0, string a1, LuaTable a2, ref object a3)
		{
			ConnectWorker(a0, a1, a2, ref a3);
		};
		PrivateMethods.LuaNewBlankScenario += delegate(string a0)
		{
			ComputeWorker(a0);
		};
		m_ProducerModel.Interval = 100;
		m_ProducerModel.Start();
	}

	private static Form ManageGlobal()
	{
		Form result = null;
		IEnumerator enumerator = null;
		if (ItemExporter.ConnectInterruptibleTemplate.databaseTemplate == null)
		{
			try
			{
				enumerator = ItemExporter.RevertInterruptibleMap.OpenForms.GetEnumerator();
				Form form;
				do
				{
					if (!enumerator.MoveNext())
					{
						return result;
					}
					form = (Form)enumerator.Current;
				}
				while (form == null || !(form is MainForm));
				return form;
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
		return ItemExporter.ConnectInterruptibleTemplate.MainForm;
	}

	private static void RevertGlobal(string string_0, int int_0, bool bool_0, ref string string_1)
	{
		if (bool_0)
		{
			return;
		}
		bool flag;
		if (flag = Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			Client.CurrentGame.Pause();
		}
		DarkDialogButton buttons;
		switch (int_0)
		{
		default:
			buttons = DarkDialogButton.Ok;
			break;
		case 1:
			buttons = DarkDialogButton.OkCancel;
			break;
		case 2:
			buttons = DarkDialogButton.AbortRetryIgnore;
			break;
		case 3:
			buttons = DarkDialogButton.YesNoCancel;
			break;
		case 4:
			buttons = DarkDialogButton.YesNo;
			break;
		case 5:
			buttons = DarkDialogButton.RetryCancel;
			break;
		}
		DialogResult dialogResult = DialogResult.Cancel;
		Form form = ManageGlobal();
		if (form == null)
		{
			dialogResult = DarkMessageBox.ShowInformation(string_0, "Incoming message", buttons);
		}
		else
		{
			form.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				dialogResult = DarkMessageBox.ShowInformation(string_0, "Incoming message", buttons);
			});
		}
		string_1 = dialogResult.ToString();
		if (flag)
		{
			Client.CurrentGame.Run();
		}
	}

	private static void CountWorker(string string_0, bool bool_0, ref string string_1)
	{
		if (bool_0)
		{
			return;
		}
		bool num = Client.CurrentGame.Status == Game._GameStatus.Running;
		if (num)
		{
			Client.CurrentGame.Pause();
		}
		string text = "";
		Form form = ManageGlobal();
		if (form == null)
		{
			text = Interaction.InputBox(string_0).ToString();
		}
		else
		{
			form.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				text = Interaction.InputBox(string_0).ToString();
			});
		}
		string_1 = text;
		if (num)
		{
			Client.CurrentGame.Run();
		}
	}

	private static void CustomizeWorker(string string_0, bool bool_0, bool bool_1, int int_0)
	{
		if (!bool_0)
		{
			getterModel.Enqueue(new Tuple<string, bool, int>(string_0, bool_1, int_0));
		}
	}

	private static void CloneWorker(object object_0, object object_1)
	{
	}

	public static object ConnectWorker(string string_0, string string_1, LuaTable luaTable_0, ref object object_0)
	{
		List<string> Local_TheList = new List<string>();
		if (luaTable_0.Values.Count > 0)
		{
			int num = luaTable_0.Values.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Local_TheList.Add(luaTable_0.Values.Cast<object>().ElementAtOrDefault(i).ToString());
			}
		}
		object Local_result = null;
		Form form = ManageGlobal();
		if (form == null)
		{
			Local_result = RuntimeHelpers.GetObjectValue(AdvancedDialog.CallHTMLDialog(string_0, string_1, Local_TheList.ToArray()));
		}
		else
		{
			form.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				Local_result = RuntimeHelpers.GetObjectValue(AdvancedDialog.CallHTMLDialog(string_0, string_1, Local_TheList.ToArray()));
			});
		}
		object_0 = RuntimeHelpers.GetObjectValue(Local_result);
		return object_0;
	}

	public static string MoveWorker(string string_0, string string_1, LuaTable luaTable_0, ref string string_2)
	{
		List<string> Local_TheList = new List<string>();
		if (luaTable_0.Values.Count > 0)
		{
			int num = luaTable_0.Values.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Local_TheList.Add(luaTable_0.Values.Cast<object>().ElementAtOrDefault(i).ToString());
			}
		}
		string Local_result = null;
		Form form = ManageGlobal();
		if (form == null)
		{
			Local_result = AdvancedDialog.CallDialog(string_0, string_1, Local_TheList.ToArray());
		}
		else
		{
			form.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				Local_result = AdvancedDialog.CallDialog(string_0, string_1, Local_TheList.ToArray());
			});
		}
		string_2 = Local_result;
		return string_2;
	}

	public static LuaTable DeleteWorker(ref LuaTable luaTable_0, bool bool_0)
	{
		UnitSelection.UnitSelectionConfig unitSelectionConfig_ = null;
		List<ActiveUnit> list_ = new List<ActiveUnit>();
		Side currentSide = Client.CurrentSide;
		List<ReferencePoint> list_2 = null;
		List<Zone> list_3 = null;
		UnitSelection.CallDialog(currentSide, bool_0, ref list_, ref list_2, ref list_3, unitSelectionConfig_);
		luaTable_0 = LuaSandBox.Singleton().CreateTable();
		if (list_.Count > 0)
		{
			int num = list_.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				luaTable_0[i] = list_[i].ObjectID;
			}
		}
		return luaTable_0;
	}

	public static LuaTable AddWorker(ref LuaTable luaTable_0, LuaTable luaTable_1, bool bool_0)
	{
		List<Side> list = new List<Side>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = luaTable_1.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Side side = LuaUtility.QuerySideObject(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(enumerator.Current)), Client.CurrentScenario);
				if (side != null)
				{
					list.Add(side);
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
		List<ActiveUnit> list_ = new List<ActiveUnit>();
		List<ReferencePoint> list_2 = null;
		List<Zone> list_3 = null;
		UnitSelection.CallDialog(list, bool_0, ref list_, ref list_2, ref list_3);
		luaTable_0 = LuaSandBox.Singleton().CreateTable();
		if (list_.Count > 0)
		{
			int num = list_.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				luaTable_0[i] = list_[i].ObjectID;
			}
		}
		return luaTable_0;
	}

	private static void DestroyWorker(ref byte byte_0, ref byte byte_1)
	{
		byte_0 = (byte)Client.CurrentGame.Status;
		byte_1 = (byte)Client.CurrentGame.GameMode;
	}

	private static object ComputeWorker(string string_0)
	{
		Form form = ManageGlobal();
		if (form == null)
		{
			Scenario.enumTimeCompression timeCompression = Client.CurrentScenario.TimeCompression;
			Client.CurrentGame.Pause();
			Client.CloseAllOpenWindows(bool_0: true);
			if (string_0 == null)
			{
				Client.CreateNewScenario();
			}
			else
			{
				Client.CreateNewScenario(string_0);
			}
			Client.MustRefreshMainForm = true;
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			Client.MustRefreshMainForm = true;
			Client.CurrentScenario.TimeCompression_Set(timeCompression);
			Client.CurrentGame.Run();
		}
		else
		{
			form.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				Scenario.enumTimeCompression timeCompression2 = Client.CurrentScenario.TimeCompression;
				Client.CurrentGame.Pause();
				Client.CloseAllOpenWindows(bool_0: true);
				if (string_0 == null)
				{
					Client.CreateNewScenario();
				}
				else
				{
					Client.CreateNewScenario(string_0);
				}
				Client.MustRefreshMainForm = true;
				Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
				Client.MustRefreshMainForm = true;
				Client.CurrentScenario.TimeCompression_Set(timeCompression2);
				Client.CurrentGame.Run();
			});
		}
		return Client.CurrentScenario;
	}
}
