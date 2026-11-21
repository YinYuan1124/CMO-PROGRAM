using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core;
using Nini.Config;
using WpfApp = System.Windows.Application;
using WpfContentControl = System.Windows.Controls.ContentControl;
using WpfFrameworkElement = System.Windows.FrameworkElement;
using WpfHeaderedContentControl = System.Windows.Controls.HeaderedContentControl;
using WpfTextBlock = System.Windows.Controls.TextBlock;
using WpfWindow = System.Windows.Window;
using WinFormsApp = System.Windows.Forms.Application;
using WinFormsButtonBase = System.Windows.Forms.ButtonBase;
using WinFormsControl = System.Windows.Forms.Control;
using WinFormsForm = System.Windows.Forms.Form;
using WinFormsGroupBox = System.Windows.Forms.GroupBox;
using WinFormsLabel = System.Windows.Forms.Label;
using WinFormsListView = System.Windows.Forms.ListView;
using WinFormsTabPage = System.Windows.Forms.TabPage;
using WinFormsToolStrip = System.Windows.Forms.ToolStrip;
using WinFormsToolStripItem = System.Windows.Forms.ToolStripItem;

namespace Command
{
	public enum AppLanguage
	{
		Chinese = 0,
		English = 1
	}

	/// <summary>
	/// Lightweight runtime localization service. UI strings are translated by their
	/// original text, so existing designer code does not have to be rewritten.
	/// A Config\Localization.ini file can add/override entries without rebuilding.
	/// </summary>
	public static class Localization
	{
		private static readonly Dictionary<string, string> ChineseToEnglish = new Dictionary<string, string>(StringComparer.Ordinal);
		private static readonly Dictionary<string, string> EnglishToChinese = new Dictionary<string, string>(StringComparer.Ordinal);
		private static readonly ConditionalWeakTable<object, string> OriginalTexts = new ConditionalWeakTable<object, string>();
		private static readonly string[] DynamicLabelPrefixes = new string[]
		{
			"困难度：",
			"复杂度：",
			"年份：",
			"位置 / 设置：",
			"选定的想定通过分数："
		};
		private static readonly ConditionalWeakTable<WinFormsForm, object> LocalizedForms = new ConditionalWeakTable<WinFormsForm, object>();
		private static readonly ConditionalWeakTable<WpfWindow, object> LocalizedWpfWindows = new ConditionalWeakTable<WpfWindow, object>();
		private static int _hookStartTick;
		private static int _lastSweepTick;

		public static AppLanguage CurrentLanguage { get; private set; }

		/// <summary>Language saved in the config, applied on the next startup.</summary>
		public static AppLanguage SavedLanguage { get; private set; }

		public static event EventHandler LanguageChanged;

		static Localization()
		{
			CurrentLanguage = AppLanguage.Chinese;
			AddDefaults();
			LoadOverrides();
		}

		public static string T(string chinese, string english)
		{
			return (CurrentLanguage == AppLanguage.English) ? english : chinese;
		}

		public static string Translate(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			if (CurrentLanguage == AppLanguage.English)
			{
				if (ChineseToEnglish.TryGetValue(text, out string value))
				{
					return value;
				}
				foreach (string prefix in DynamicLabelPrefixes)
				{
					if (text.StartsWith(prefix, StringComparison.Ordinal) && ChineseToEnglish.TryGetValue(prefix, out string prefixValue))
					{
						return prefixValue + text.Substring(prefix.Length);
					}
				}
			}
			else if (EnglishToChinese.TryGetValue(text, out string value2))
			{
				return value2;
			}
			return text;
		}

		public static string TranslateEnum(Type enumType, object value)
		{
			if (enumType == null || value == null)
			{
				return Convert.ToString(value);
			}
			var field = enumType.GetField(Enum.GetName(enumType, value));
			var description = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
			string text = ((description == null) ? value.ToString() : description.Description);
			return Translate(text);
		}

		public static string ParseEnumDisplay(Type enumType, string display)
		{
			foreach (var field in enumType.GetFields())
			{
				if (!field.IsStatic)
				{
					continue;
				}
				var description = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
				string text = ((description == null) ? field.Name : description.Description);
				if (string.Equals(display, text, StringComparison.OrdinalIgnoreCase) ||
					string.Equals(display, Translate(text), StringComparison.OrdinalIgnoreCase))
				{
					return field.Name;
				}
			}
			return display;
		}

		public static void InitializeFromConfig()
		{
			string language = null;
			string localizationPath = Path.Combine(GameGeneral.ConfigFolderPath, "Localization.ini");
			try
			{
				if (File.Exists(localizationPath))
				{
					var source = new IniConfigSource(localizationPath);
					var settings = source.Configs["Settings"];
					if (settings != null)
					{
						language = settings.Get("Language");
					}
				}
			}
			catch
			{
			}
			if (string.IsNullOrEmpty(language))
			{
				try
				{
					string path = Path.Combine(GameGeneral.ConfigFolderPath, "Command.ini");
					if (File.Exists(path))
					{
						var source = new IniConfigSource(path);
						var config = source.Configs["Game Preferences"];
						if (config != null)
						{
							language = config.Get("Language");
						}
					}
				}
				catch
				{
				}
			}
			if (string.IsNullOrEmpty(language))
			{
				language = "zh-CN";
			}
			CurrentLanguage = language.StartsWith("en", StringComparison.OrdinalIgnoreCase) ? AppLanguage.English : AppLanguage.Chinese;
			SavedLanguage = CurrentLanguage;
		}

		/// <summary>
		/// Saves the requested language without applying it to the running UI.
		/// A restart is required; this avoids rebuilding live WPF/WinForms trees.
		/// </summary>
		public static void SaveLanguagePreference(AppLanguage language)
		{
			SavedLanguage = language;
			string value = (language == AppLanguage.English) ? "en-US" : "zh-CN";
			// Localization.ini is our own file; the game rewrites Command.ini and would
			// drop the unknown Language key, so this file is the source of truth.
			try
			{
				string localizationPath = Path.Combine(GameGeneral.ConfigFolderPath, "Localization.ini");
				var source = File.Exists(localizationPath) ? new IniConfigSource(localizationPath) : new IniConfigSource();
				var settings = source.Configs["Settings"] ?? source.AddConfig("Settings");
				settings.Set("Language", value);
				source.Save(localizationPath);
			}
			catch
			{
			}
			try
			{
				string path = Path.Combine(GameGeneral.ConfigFolderPath, "Command.ini");
				var source = File.Exists(path) ? new IniConfigSource(path) : new IniConfigSource();
				var config = source.Configs["Game Preferences"] ?? source.AddConfig("Game Preferences");
				config.Set("Language", value);
				source.Save(path);
			}
			catch
			{
			}
		}

		public static void SaveToConfig()
		{
			try
			{
				string path = Path.Combine(GameGeneral.ConfigFolderPath, "Command.ini");
				var source = File.Exists(path) ? new IniConfigSource(path) : new IniConfigSource();
				var config = source.Configs["Game Preferences"] ?? source.AddConfig("Game Preferences");
				config.Set("Language", (CurrentLanguage == AppLanguage.English) ? "en-US" : "zh-CN");
				source.Save(path);
			}
			catch
			{
			}
		}

		public static void SetLanguage(AppLanguage language)
		{
			if (CurrentLanguage == language)
			{
				return;
			}
			CurrentLanguage = language;
			try
			{
				TypeDescriptor.Refresh(typeof(HoverInfoOptionsViewModel));
			}
			catch
			{
			}
			try
			{
				ApplyToOpenForms();
			}
			catch
			{
			}
			try
			{
				LanguageChanged?.Invoke(null, EventArgs.Empty);
			}
			catch
			{
			}
		}

		public static void HookOpenForms()
		{
			_hookStartTick = Environment.TickCount;
			WinFormsApp.Idle += delegate
			{
				foreach (WinFormsForm form in WinFormsApp.OpenForms)
				{
					if (!LocalizedForms.TryGetValue(form, out object _))
					{
						LocalizedForms.Add(form, new object());
						try
						{
							ApplyToControl(form);
						}
						catch
						{
						}
						try
						{
							form.BeginInvoke(new Action(delegate
							{
								try
								{
									ApplyToControl(form);
								}
								catch
								{
								}
							}));
						}
						catch
						{
						}
					}
				}
				if (WpfApp.Current != null)
				{
					foreach (WpfWindow window in WpfApp.Current.Windows)
					{
						if (!LocalizedWpfWindows.TryGetValue(window, out object _))
						{
							LocalizedWpfWindows.Add(window, new object());
							try
							{
								ApplyToWpf(window);
							}
							catch
							{
							}
							try
							{
								window.Dispatcher.InvokeAsync(delegate
								{
									try
									{
										ApplyToWpf(window);
									}
									catch
									{
									}
								}, System.Windows.Threading.DispatcherPriority.Background);
							}
							catch
							{
							}
						}
					}
				}
				// Some controls receive their text after the first idle pass (data binding,
				// delayed initialization). Sweep the open windows again for the first 20s.
				int now = Environment.TickCount;
				if (now - _hookStartTick <= 20000 && now - _lastSweepTick >= 700)
				{
					_lastSweepTick = now;
					ApplyToOpenForms();
				}
			};
		}

		public static void ApplyToOpenForms()
		{
			foreach (WinFormsForm form in WinFormsApp.OpenForms)
			{
				try
				{
					ApplyToControl(form);
				}
				catch
				{
				}
			}
			if (WpfApp.Current != null)
			{
				foreach (WpfWindow window in WpfApp.Current.Windows)
				{
					WpfWindow localWindow = window;
					try
					{
						localWindow.Dispatcher.InvokeAsync(delegate
						{
							ApplyToWpf(localWindow);
						});
					}
					catch
					{
					}
				}
			}
		}

		public static void ApplyToWpfElement(object element)
		{
			if (element is System.Windows.DependencyObject dependencyObject)
			{
				ApplyToWpf(dependencyObject);
			}
		}

		public static void ApplyToControl(WinFormsControl control)
		{
			if (ShouldTranslateControlText(control))
			{
				TranslateText(control, control.Text, delegate(string value)
				{
					control.Text = value;
				});
			}
			if (control is WinFormsToolStrip toolStrip)
			{
				ApplyToToolStripItems(toolStrip.Items);
			}
			if (control is WinFormsListView listView)
			{
				foreach (System.Windows.Forms.ColumnHeader column in listView.Columns)
				{
					TranslateText(column, column.Text, delegate(string value)
					{
						column.Text = value;
					});
				}
			}
			if (control is System.Windows.Forms.DataGridView dataGridView)
			{
				foreach (System.Windows.Forms.DataGridViewColumn column in dataGridView.Columns)
				{
					TranslateText(column, column.HeaderText, delegate(string value)
					{
						column.HeaderText = value;
					});
				}
			}
			if (control is System.Windows.Forms.Integration.ElementHost elementHost && elementHost.Child != null)
			{
				try
				{
					ApplyToWpfElement(elementHost.Child);
				}
				catch
				{
				}
			}
			foreach (WinFormsControl child in control.Controls)
			{
				ApplyToControl(child);
			}
		}

		private static bool ShouldTranslateControlText(WinFormsControl control)
		{
			if (control is System.Windows.Forms.TextBoxBase ||
				control is System.Windows.Forms.ListControl ||
				control is System.Windows.Forms.TreeView ||
				control is System.Windows.Forms.ListView ||
				control is System.Windows.Forms.DataGridView ||
				control is System.Windows.Forms.WebBrowser ||
				control is System.Windows.Forms.NumericUpDown ||
				control is System.Windows.Forms.PropertyGrid ||
				control is System.Windows.Forms.Integration.ElementHost)
			{
				return false;
			}
			return true;
		}

		private static void ApplyToToolStripItems(System.Windows.Forms.ToolStripItemCollection items)
		{
			foreach (WinFormsToolStripItem item in items)
			{
				TranslateText(item, item.Text, delegate(string value)
				{
					item.Text = value;
				});
				if (item is System.Windows.Forms.ToolStripDropDownItem dropDown)
				{
					ApplyToToolStripItems(dropDown.DropDownItems);
				}
			}
		}

		private static void ApplyToWpf(System.Windows.DependencyObject root)
		{
			// Iterative traversal: a recursive logical+visual walk can overflow the stack on
			// large template trees. The visited set also stops logical-tree cycles from looping.
			Stack<System.Windows.DependencyObject> pending = new Stack<System.Windows.DependencyObject>();
			HashSet<System.Windows.DependencyObject> visited = new HashSet<System.Windows.DependencyObject>();
			pending.Push(root);
			while (pending.Count > 0 && visited.Count < 200000)
			{
				System.Windows.DependencyObject element = pending.Pop();
				if (element == null || !visited.Add(element))
				{
					continue;
				}
				TranslateWpfElement(element);
				try
				{
					foreach (object child in System.Windows.LogicalTreeHelper.GetChildren(element))
					{
						if (child is System.Windows.DependencyObject dependencyObject)
						{
							pending.Push(dependencyObject);
						}
					}
				}
				catch
				{
				}
				try
				{
					if (element is System.Windows.Media.Visual || element is System.Windows.Media.Media3D.Visual3D)
					{
						int childCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(element);
						for (int i = 0; i < childCount; i++)
						{
							pending.Push(System.Windows.Media.VisualTreeHelper.GetChild(element, i));
						}
					}
				}
				catch
				{
				}
			}
		}

		private static void TranslateWpfElement(System.Windows.DependencyObject element)
		{
			if (element is WpfTextBlock textBlock)
			{
				TranslateText(textBlock, textBlock.Text, delegate(string value)
				{
					textBlock.Text = value;
				});
			}
			if (element is WpfContentControl contentControl && contentControl.Content is string content)
			{
				TranslateText(contentControl, content, delegate(string value)
				{
					contentControl.Content = value;
				});
			}
			if (element is WpfHeaderedContentControl headered && headered.Header is string header)
			{
				TranslateText(headered, header, delegate(string value)
				{
					headered.Header = value;
				});
			}
			if (element is WpfFrameworkElement frameworkElement && frameworkElement.ToolTip is string toolTip)
			{
				TranslateText(frameworkElement, toolTip, delegate(string value)
				{
					frameworkElement.ToolTip = value;
				});
			}
			if (element is WpfWindow window)
			{
				TranslateText(window, window.Title, delegate(string value)
				{
					window.Title = value;
				});
			}
		}

		private static void TranslateText(object owner, string currentText, Action<string> setter)
		{
			if (string.IsNullOrEmpty(currentText))
			{
				return;
			}
			if (!OriginalTexts.TryGetValue(owner, out string original))
			{
				original = currentText;
				OriginalTexts.Add(owner, original);
			}
			string translated = Translate(original);
			if (!string.Equals(currentText, translated, StringComparison.Ordinal))
			{
				try
				{
					setter(translated);
				}
				catch
				{
				}
			}
		}

		public static string ScenarioText(string scenarioPath, string field, string original)
		{
			if (string.IsNullOrEmpty(scenarioPath) || string.IsNullOrEmpty(field))
			{
				return Translate(original);
			}
			string language = (CurrentLanguage == AppLanguage.English) ? "en-US" : "zh-CN";
			try
			{
				string sidecar = scenarioPath + ".i18n.ini";
				if (File.Exists(sidecar))
				{
					var source = new IniConfigSource(sidecar);
					var config = source.Configs[language];
					if (config != null)
					{
						string value = config.Get(field);
						if (!string.IsNullOrEmpty(value))
						{
							return value;
						}
					}
				}
			}
			catch
			{
			}
			if (field == "Title")
			{
				if (TryGetScenarioName(scenarioPath, out string mapped))
				{
					return mapped;
				}
			}
			if (field == "Description")
			{
				try
				{
					string html = scenarioPath + "." + language + ".html";
					if (File.Exists(html))
					{
						return File.ReadAllText(html);
					}
				}
				catch
				{
				}
			}
			return Translate(original);
		}

		/// <summary>Display name for a scenario-tree directory or scenario file.</summary>
		public static string ScenarioDisplayName(string fullPath, bool isDirectory)
		{
			if (string.IsNullOrEmpty(fullPath))
			{
				return fullPath;
			}
			string key = isDirectory ? Path.GetFileName(fullPath) : Path.GetFileNameWithoutExtension(fullPath);
			if (TryGetScenarioNameFromKey(key, out string mapped))
			{
				return mapped;
			}
			return Translate(key);
		}

		private static bool TryGetScenarioName(string scenarioPath, out string name)
		{
			return TryGetScenarioNameFromKey(Path.GetFileNameWithoutExtension(scenarioPath), out name);
		}

		private static bool TryGetScenarioNameFromKey(string key, out string name)
		{
			name = null;
			try
			{
				string path = Path.Combine(GameGeneral.ConfigFolderPath, "ScenarioNames.ini");
				if (!File.Exists(path) || string.IsNullOrEmpty(key))
				{
					return false;
				}
				var source = new IniConfigSource(path);
				string language = (CurrentLanguage == AppLanguage.English) ? "en-US" : "zh-CN";
				var config = source.Configs[language];
				if (config == null)
				{
					return false;
				}
				string value = config.Get(key);
				if (string.IsNullOrEmpty(value))
				{
					return false;
				}
				name = value;
				return true;
			}
			catch
			{
				return false;
			}
		}

		private static void AddDefaults()
		{
			// Chinese -> English (the current UI is mostly Chinese)
			Add(ChineseToEnglish, "通用", "General");
			Add(ChineseToEnglish, "地图显示", "Map Display");
			Add(ChineseToEnglish, "消息日志", "Message Log");
			Add(ChineseToEnglish, "音乐/音效", "Music / Sound");
			Add(ChineseToEnglish, "推演速度", "Simulation Speed");
			Add(ChineseToEnglish, "鼠标悬浮信息", "Hover Info");
			Add(ChineseToEnglish, "鼠标悬浮信息设置", "Hover Info Settings");
			Add(ChineseToEnglish, "语言", "Language");
			Add(ChineseToEnglish, "界面语言：", "UI language:");
			Add(ChineseToEnglish, "想定标题", "Scenario title");
			Add(ChineseToEnglish, "显示单位", "Units to display");
			Add(ChineseToEnglish, "允许右键单击下达命令或设定航线", "Right-click to issue orders or set course");
			Add(ChineseToEnglish, "确定", "OK");
			Add(ChineseToEnglish, "取消", "Cancel");
			Add(ChineseToEnglish, "应用", "Apply");
			Add(ChineseToEnglish, "关闭", "Close");
			Add(ChineseToEnglish, "保存", "Save");
			Add(ChineseToEnglish, "是", "Yes");
			Add(ChineseToEnglish, "否", "No");
			// Main window / start menu
			Add(ChineseToEnglish, "开始新推演", "Start New Scenario");
			Add(ChineseToEnglish, "快速战斗", "Quick Battle");
			Add(ChineseToEnglish, "战役", "Campaign");
			Add(ChineseToEnglish, "加载保存进度", "Load Saved Game");
			Add(ChineseToEnglish, "从自动保存中恢复", "Resume from Autosave");
			Add(ChineseToEnglish, "创建新想定", "Create New Scenario");
			Add(ChineseToEnglish, "编辑想定", "Edit Scenario");
			Add(ChineseToEnglish, "退出", "Exit");
			Add(ChineseToEnglish, "时间压缩：", "Time Compression:");
			Add(ChineseToEnglish, "时间模式：", "Time Mode:");
			Add(ChineseToEnglish, "开始/继续", "Start / Continue");
			Add(ChineseToEnglish, "自定义叠加层", "Custom Overlay");
			Add(ChineseToEnglish, "录像", "Record");
			Add(ChineseToEnglish, "所有", "All");
			Add(ChineseToEnglish, "编队视图", "Formation View");
			Add(ChineseToEnglish, "15秒", "15 sec");
			Add(ChineseToEnglish, "1分钟", "1 min");
			Add(ChineseToEnglish, "5分钟", "5 min");
			Add(ChineseToEnglish, "15分钟", "15 min");
			// Main menu
			Add(ChineseToEnglish, "文件", "File");
			Add(ChineseToEnglish, "查看", "View");
			Add(ChineseToEnglish, "推演", "Simulation");
			Add(ChineseToEnglish, "地图设置", "Map Settings");
			Add(ChineseToEnglish, "快速跳转", "Quick Jump");
			Add(ChineseToEnglish, "单元命令", "Unit Orders");
			Add(ChineseToEnglish, "任务和参考点", "Missions and Reference Points");
			Add(ChineseToEnglish, "目标", "Targets");
			Add(ChineseToEnglish, "帮助", "Help");
			// Load Scenario / scenario browser (开始新推演 and 编辑想定)
			Add(ChineseToEnglish, "加载想定", "Load Scenario");
			Add(ChineseToEnglish, "选择想定", "Select Scenario");
			Add(ChineseToEnglish, "加载选中", "Load Selected");
			Add(ChineseToEnglish, "想定", "Scenario");
			Add(ChineseToEnglish, "保存的推演", "Saved Games");
			Add(ChineseToEnglish, "载入中...", "Loading...");
			Add(ChineseToEnglish, "困难度：", "Difficulty:");
			Add(ChineseToEnglish, "复杂度：", "Complexity:");
			Add(ChineseToEnglish, "位置 / 设置：", "Location / Setting:");
			Add(ChineseToEnglish, "年份：", "Year:");
			Add(ChineseToEnglish, "排序想定：", "Sort Scenarios:");
			Add(ChineseToEnglish, "浏览...", "Browse...");
			Add(ChineseToEnglish, "删除所选", "Delete Selected");
			Add(ChineseToEnglish, "选择自动保存", "Select Autosave");
			Add(ChineseToEnglish, "搜索想定：", "Search Scenarios:");
			Add(ChineseToEnglish, "[未注册]", "[Unregistered]");
			Add(ChineseToEnglish, "地点：", "Location:");
			Add(ChineseToEnglish, "错误！", "Error!");
			// Quick Battle
			Add(ChineseToEnglish, "快速生成想定", "Quick Generate Scenario");
			Add(ChineseToEnglish, "开始", "Start");
			// Campaign
			Add(ChineseToEnglish, "开始新战役", "Start New Campaign");
			Add(ChineseToEnglish, "选择一个新的战役进程，或从保存中恢复现有的战役进程。", "Select a new campaign, or resume an existing campaign from a save.");
			Add(ChineseToEnglish, "从保存中恢复", "Resume from Save");
			Add(ChineseToEnglish, "删除所选的保存", "Delete Selected Save");
			Add(ChineseToEnglish, "从选定的保存中恢复", "Resume from Selected Save");
			Add(ChineseToEnglish, "战役想定", "Campaign Scenario");
			Add(ChineseToEnglish, "取消（返回战役）", "Cancel (Back to Campaign)");
			Add(ChineseToEnglish, "开始想定", "Start Scenario");
			Add(ChineseToEnglish, "战役编辑器", "Campaign Editor");
			Add(ChineseToEnglish, "更改ID", "Change ID");
			Add(ChineseToEnglish, "添加想定", "Add Scenario");
			Add(ChineseToEnglish, "添加附件", "Add Attachment");
			Add(ChineseToEnglish, "删除选定", "Delete Selected");
			Add(ChineseToEnglish, "上移", "Move Up");
			Add(ChineseToEnglish, "下移", "Move Down");
			Add(ChineseToEnglish, "标题+描述", "Title + Description");
			Add(ChineseToEnglish, "结束文本", "Ending Text");
			Add(ChineseToEnglish, "保存战役", "Save Campaign");
			Add(ChineseToEnglish, "选定的想定通过分数：", "Selected scenario pass score:");
			Add(ChineseToEnglish, "设置", "Settings");
			Add(ChineseToEnglish, "名称", "Name");
			Add(ChineseToEnglish, "想定时间", "Scenario Time");
			Add(ChineseToEnglish, "节省实际时间", "Time Saved");
			Add(ChineseToEnglish, "通过分数", "Pass Score");
			Add(ChineseToEnglish, "想定ID", "Scenario ID");
			// Create / edit scenario dialog
			Add(ChineseToEnglish, "标题：", "Title:");
			Add(ChineseToEnglish, "描述：", "Description:");
			Add(ChineseToEnglish, "编辑HTML", "Edit HTML");
			// StartGame legacy form
			Add(ChineseToEnglish, "开始推演", "Start Scenario");
			Add(ChineseToEnglish, "从上次自动保存恢复", "Resume from Last Autosave");
			Add(ChineseToEnglish, "加载已保存的推演", "Load Saved Game");
			Add(ChineseToEnglish, "开始新的想定", "Start New Scenario");
			Add(ChineseToEnglish, "想定编辑器", "Scenario Editor");
			Add(ChineseToEnglish, "加载现有想定", "Load Existing Scenario");
			Add(ChineseToEnglish, "创建新的空白想定", "Create New Blank Scenario");
			Add(ChineseToEnglish, "退出推演", "Exit Scenario");

			// English -> Chinese (for labels that are still English in the source)
			Add(EnglishToChinese, "Hover Info Settings", "鼠标悬浮信息设置");
			Add(EnglishToChinese, "Hover Info", "鼠标悬浮信息");
			Add(EnglishToChinese, "Weapon", "武器");
			Add(EnglishToChinese, "Sensor", "传感器");
			Add(EnglishToChinese, "Cargo", "货物");
			Add(EnglishToChinese, "Damage", "损伤");
			Add(EnglishToChinese, "Landed Aircraft", "降落飞机");
			Add(EnglishToChinese, "Docked Boats", "停靠小艇");
			Add(EnglishToChinese, "Fuel Information", "燃油信息");
			Add(EnglishToChinese, "Mission Information", "任务信息");
			Add(EnglishToChinese, "Vehicle Information", "载具信息");
			Add(EnglishToChinese, "Ground unit vehicles", "地面单位载具");
			Add(EnglishToChinese, "Group Members", "小组成员");
			Add(EnglishToChinese, "Aircraft landed on carrier/airbase", "降落于航母/机场的飞机");
			Add(EnglishToChinese, "Boats docked to mothership", "停靠母舰的小艇");
			Add(EnglishToChinese, "Show", "显示");
			Add(EnglishToChinese, "Hide", "隐藏");
			Add(EnglishToChinese, "Show Summary", "显示摘要");
			Add(EnglishToChinese, "Show Detailed", "显示详情");
			Add(EnglishToChinese, "Message Log", "消息日志");
		}

		private static void Add(Dictionary<string, string> dictionary, string key, string value)
		{
			dictionary[key] = value;
		}

		private static void LoadOverrides()
		{
			try
			{
				string path = Path.Combine(GameGeneral.ConfigFolderPath, "Localization.ini");
				if (!File.Exists(path))
				{
					return;
				}
				var source = new IniConfigSource(path);
				LoadSection(source.Configs["ChineseToEnglish"], ChineseToEnglish);
				LoadSection(source.Configs["EnglishToChinese"], EnglishToChinese);
			}
			catch
			{
			}
		}

		private static void LoadSection(IConfig config, Dictionary<string, string> dictionary)
		{
			if (config == null)
			{
				return;
			}
			foreach (string key in config.GetKeys())
			{
				dictionary[key] = config.Get(key);
			}
		}
	}

	/// <summary>Localizes DisplayName/Description/Category for the hover-info property grid.</summary>
	internal sealed class HoverInfoLocalizedTypeDescriptionProvider : TypeDescriptionProvider
	{
		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
		{
			return new LocalizedTypeDescriptor(objectType, instance);
		}
	}

	internal sealed class LocalizedTypeDescriptor : ICustomTypeDescriptor
	{
		private readonly Type _objectType;
		private readonly object _instance;

		public LocalizedTypeDescriptor(Type objectType, object instance)
		{
			_objectType = objectType;
			_instance = instance;
		}

		public AttributeCollection GetAttributes() => new AttributeCollection(Attribute.GetCustomAttributes(_objectType, true));
		public string GetClassName() => _objectType.Name;
		public string GetComponentName() => null;
		public TypeConverter GetConverter() => TypeDescriptor.GetConverter(_objectType);
		public EventDescriptor GetDefaultEvent() => null;
		public PropertyDescriptor GetDefaultProperty() => GetProperties().Cast<PropertyDescriptor>().FirstOrDefault();
		public object GetEditor(Type editorBaseType) => null;
		public EventDescriptorCollection GetEvents() => EventDescriptorCollection.Empty;
		public EventDescriptorCollection GetEvents(Attribute[] attributes) => EventDescriptorCollection.Empty;
		public PropertyDescriptorCollection GetProperties() => GetProperties(null);
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyInfo[] properties = _objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			return new PropertyDescriptorCollection(properties.Select(p => (PropertyDescriptor)new LocalizedPropertyDescriptor(p)).ToArray());
		}
		public object GetPropertyOwner(PropertyDescriptor pd) => _instance;
	}

	internal sealed class LocalizedPropertyDescriptor : PropertyDescriptor
	{
		private readonly PropertyInfo _property;

		public LocalizedPropertyDescriptor(PropertyInfo property)
			: base(property.Name, (Attribute[])Attribute.GetCustomAttributes(property, true))
		{
			_property = property;
		}

		public override string DisplayName
		{
			get
			{
				DisplayNameAttribute attribute = (DisplayNameAttribute)Attribute.GetCustomAttribute(_property, typeof(DisplayNameAttribute));
				return Localization.Translate((attribute == null) ? _property.Name : attribute.DisplayName);
			}
		}

		public override string Description
		{
			get
			{
				DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(_property, typeof(DescriptionAttribute));
				return Localization.Translate((attribute == null) ? string.Empty : attribute.Description);
			}
		}

		public override string Category
		{
			get
			{
				CategoryAttribute attribute = (CategoryAttribute)Attribute.GetCustomAttribute(_property, typeof(CategoryAttribute));
				return Localization.Translate((attribute == null) ? "Misc" : attribute.Category);
			}
		}

		public override Type ComponentType => _property.DeclaringType;
		public override bool IsReadOnly => !_property.CanWrite;
		public override Type PropertyType => _property.PropertyType;

		public override bool CanResetValue(object component) => false;
		public override object GetValue(object component) => _property.GetValue(component, null);
		public override void ResetValue(object component) { }
		public override void SetValue(object component, object value) => _property.SetValue(component, value, null);
		public override bool ShouldSerializeValue(object component) => true;
	}
}
