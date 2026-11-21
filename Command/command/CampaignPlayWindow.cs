using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CampaignPlayWindow : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class WrapperMerchantPage
	{
		public List<string> Local_theList;

		public CampaignPlayWindow Me;

		public int Local_SavesProcessed;

		public int Local_TotalSaves;

		internal void AssetInterruptibleParam()
		{
			foreach (string local_the in Local_theList)
			{
				ValMap CS_0024_003C_003E8__locals0 = new ValMap
				{
					CS_0024_003C_003E8__locals1 = this,
					Local_theCampaign = Campaign.ReadFromFile(local_the)
				};
				string directoryName = Path.GetDirectoryName(local_the);
				CS_0024_003C_003E8__locals0.Local_CampaignNode = null;
				IEnumerable<string> enumerable = from theFN in Directory.GetFiles(directoryName, "*-*-*-*-*.save")
					orderby new FileInfo(theFN).CreationTime
					select theFN;
				if (enumerable.Count() <= 0)
				{
					continue;
				}
				if (!Me.Visible)
				{
					return;
				}
				Me.TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					CS_0024_003C_003E8__locals0.Local_CampaignNode = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Me.TGV_CampaignSaves.Nodes.Add(CS_0024_003C_003E8__locals0.Local_theCampaign.Name);
					Application.DoEvents();
				});
				CS_0024_003C_003E8__locals0.Local_CampaignNode.Tag = CS_0024_003C_003E8__locals0.Local_theCampaign;
				HashSet<string> hashSet = new HashSet<string>();
				using (IEnumerator<string> enumerator2 = enumerable.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						IssuerCollectionTask issuerCollectionTask = new IssuerCollectionTask
						{
							CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals0,
							Local_theFileName = enumerator2.Current
						};
						if (Operators.CompareString(Path.GetExtension(issuerCollectionTask.Local_theFileName), ".save", TextCompare: true) != 0)
						{
							continue;
						}
						try
						{
							issuerCollectionTask.Local_SaveFile_Title = null;
							issuerCollectionTask.Local_SaveFile_CampaignSessionID = null;
							ScenContainer scenContainer = ScenContainer.LoadFromFile(issuerCollectionTask.Local_theFileName);
							string text;
							string value;
							if (scenContainer.SaveCurrentTime == 0)
							{
								List<string> list_ = new List<string> { "CampaignID", "CampaignSessionID", "Title", "Time" };
								string[] array = Scenario.QueryScenario_ScenFileName(issuerCollectionTask.Local_theFileName, list_);
								text = array[0];
								issuerCollectionTask.Local_SaveFile_CampaignSessionID = array[1];
								issuerCollectionTask.Local_SaveFile_Title = array[2];
								value = array[3];
								scenContainer.CampaignID = text;
								scenContainer.CampaignSessionID = issuerCollectionTask.Local_SaveFile_CampaignSessionID;
								scenContainer.ScenTitle = issuerCollectionTask.Local_SaveFile_Title;
								scenContainer.SaveCurrentTime = Conversions.ToLong(value);
								scenContainer.SaveToFile(issuerCollectionTask.Local_theFileName, bool_0: true);
							}
							else
							{
								text = scenContainer.CampaignID;
								issuerCollectionTask.Local_SaveFile_CampaignSessionID = scenContainer.CampaignSessionID;
								issuerCollectionTask.Local_SaveFile_Title = scenContainer.ScenTitle;
								value = Conversions.ToString(scenContainer.SaveCurrentTime);
							}
							if (string.IsNullOrEmpty(text))
							{
								continue;
							}
							ParamsCollectionRecord CS_0024_003C_003E8__locals1 = new ParamsCollectionRecord
							{
								CS_0024_003C_003E8__locals3 = issuerCollectionTask,
								Local_SessionNode = null
							};
							if (hashSet.Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_CampaignSessionID))
							{
								CS_0024_003C_003E8__locals1.Local_SessionNode = (from theNode in InterpreterObjectListener.FlushInterruptibleTask(Me.TGV_CampaignSaves)
									where (object)theNode.Tag.GetType() == typeof(string) && Operators.CompareString(Conversions.ToString(theNode.Tag), "Session_" + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_CampaignSessionID, TextCompare: true) == 0
									select theNode).ElementAtOrDefault(0);
							}
							else
							{
								hashSet.Add(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_CampaignSessionID);
								if (!Me.Visible)
								{
									return;
								}
								Me.TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
								{
									CS_0024_003C_003E8__locals1.Local_SessionNode = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.Local_CampaignNode.Nodes.Add("Session started at: " + new FileInfo(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_theFileName).CreationTime.ToShortDateString() + " " + new FileInfo(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_theFileName).CreationTime.ToShortTimeString());
									Application.DoEvents();
								});
								CS_0024_003C_003E8__locals1.Local_SessionNode.Tag = "Session_" + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_CampaignSessionID;
							}
							CS_0024_003C_003E8__locals1.Local_ScenTime = DateTime.FromBinary(Conversions.ToLong(value));
							if (scenContainer.IsCampaignCheckpoint)
							{
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_Title = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_Title + " (Checkpoint)";
							}
							CS_0024_003C_003E8__locals1.Local_SaveTime = File.GetLastWriteTime(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_theFileName);
							CS_0024_003C_003E8__locals1.Local_SaveNode = null;
							if (Me.Visible)
							{
								Me.TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
								{
									CS_0024_003C_003E8__locals1.Local_SaveNode = CS_0024_003C_003E8__locals1.Local_SessionNode.Nodes.Add(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_SaveFile_Title, CS_0024_003C_003E8__locals1.Local_ScenTime, CS_0024_003C_003E8__locals1.Local_SaveTime);
									int local_SavesProcessed = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_SavesProcessed;
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_SavesProcessed = local_SavesProcessed + 1;
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.PB_CampaignSaves.Value = (int)Math.Round(100.0 * ((double)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_SavesProcessed / (double)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_TotalSaves));
									Application.DoEvents();
								});
								CS_0024_003C_003E8__locals1.Local_SaveNode.Tag = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.Local_theFileName;
								continue;
							}
							return;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200374", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				if (Me.Visible)
				{
					Me.TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						CS_0024_003C_003E8__locals0.Local_CampaignNode.Expand();
						Application.DoEvents();
					});
					continue;
				}
				return;
			}
			if (Me.Visible)
			{
				Me.TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					Me.PB_CampaignSaves.Visible = false;
					Application.DoEvents();
				});
			}
		}

		internal void PrintInterruptibleParam()
		{
			Me.PB_CampaignSaves.Visible = false;
			Application.DoEvents();
		}
	}

	[CompilerGenerated]
	private sealed class ValMap
	{
		public TreeGridNode Local_CampaignNode;

		public Campaign Local_theCampaign;

		public WrapperMerchantPage CS_0024_003C_003E8__locals1;

		internal void DefineInterruptibleParam()
		{
			Local_CampaignNode = CS_0024_003C_003E8__locals1.Me.TGV_CampaignSaves.Nodes.Add(Local_theCampaign.Name);
			Application.DoEvents();
		}

		internal void PublishInterruptibleParam()
		{
			Local_CampaignNode.Expand();
			Application.DoEvents();
		}
	}

	[CompilerGenerated]
	private sealed class IssuerCollectionTask
	{
		public string Local_theFileName;

		public string Local_SaveFile_CampaignSessionID;

		public string Local_SaveFile_Title;

		public ValMap CS_0024_003C_003E8__locals2;

		internal bool AwakeInterruptibleParam(TreeGridNode theNode)
		{
			if ((object)theNode.Tag.GetType() == typeof(string))
			{
				return Operators.CompareString(Conversions.ToString(theNode.Tag), "Session_" + Local_SaveFile_CampaignSessionID, TextCompare: true) == 0;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ParamsCollectionRecord
	{
		public TreeGridNode Local_SessionNode;

		public TreeGridNode Local_SaveNode;

		public DateTime Local_ScenTime;

		public DateTime Local_SaveTime;

		public IssuerCollectionTask CS_0024_003C_003E8__locals3;

		internal void QueryInterruptibleParam()
		{
			Local_SessionNode = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.Local_CampaignNode.Nodes.Add("Session started at: " + new FileInfo(CS_0024_003C_003E8__locals3.Local_theFileName).CreationTime.ToShortDateString() + " " + new FileInfo(CS_0024_003C_003E8__locals3.Local_theFileName).CreationTime.ToShortTimeString());
			Application.DoEvents();
		}

		internal void ResetInterruptibleParam()
		{
			Local_SaveNode = Local_SessionNode.Nodes.Add(CS_0024_003C_003E8__locals3.Local_SaveFile_Title, Local_ScenTime, Local_SaveTime);
			int local_SavesProcessed = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_SavesProcessed;
			CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_SavesProcessed = local_SavesProcessed + 1;
			CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.PB_CampaignSaves.Value = (int)Math.Round(100.0 * ((double)CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_SavesProcessed / (double)CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Local_TotalSaves));
			Application.DoEvents();
		}
	}

	private IContainer m_FilterInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _InterpreterInvocation;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	private DarkUITabControl containerInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage m_ComposerInvocation;

	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage modelInvocation;

	[AccessedThroughProperty("TGV_CampaignSaves")]
	[CompilerGenerated]
	private DarkTreeGridView _AdvisorInvocation;

	[AccessedThroughProperty("Button4")]
	[CompilerGenerated]
	private DarkUIButton _CustomerInvocation;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _SerializerInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _CodeInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_CampaignSaves")]
	private DarkUIProgressBar connectionInvocation;

	private string _StrategyInvocation;

	[AccessedThroughProperty("theButton")]
	[CompilerGenerated]
	private Button m_ConfigurationInvocation;

	private Queue<Tuple<string, string, string, string>> _TokenInvocation;

	[field: AccessedThroughProperty("WebBrowser1")]
	internal WebBrowser WebBrowser1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _InterpreterInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableStatus;
			DarkUIButton interpreterInvocation = _InterpreterInvocation;
			if (interpreterInvocation != null)
			{
				interpreterInvocation.Click -= value2;
			}
			_InterpreterInvocation = value;
			interpreterInvocation = _InterpreterInvocation;
			if (interpreterInvocation != null)
			{
				interpreterInvocation.Click += value2;
			}
		}
	}

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return containerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerInvocation = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerInvocation = value;
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return modelInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelInvocation = value;
		}
	}

	private DarkTreeGridView TGV_CampaignSaves
	{
		[CompilerGenerated]
		get
		{
			return _AdvisorInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertStatus;
			DarkTreeGridView advisorInvocation = _AdvisorInvocation;
			if (advisorInvocation != null)
			{
				advisorInvocation.SelectionChanged -= value2;
			}
			_AdvisorInvocation = value;
			advisorInvocation = _AdvisorInvocation;
			if (advisorInvocation != null)
			{
				advisorInvocation.SelectionChanged += value2;
			}
		}
	}

	internal DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return _CustomerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareStatus;
			DarkUIButton customerInvocation = _CustomerInvocation;
			if (customerInvocation != null)
			{
				customerInvocation.Click -= value2;
			}
			_CustomerInvocation = value;
			customerInvocation = _CustomerInvocation;
			if (customerInvocation != null)
			{
				customerInvocation.Click += value2;
			}
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _SerializerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateStatus;
			DarkUIButton serializerInvocation = _SerializerInvocation;
			if (serializerInvocation != null)
			{
				serializerInvocation.Click -= value2;
			}
			_SerializerInvocation = value;
			serializerInvocation = _SerializerInvocation;
			if (serializerInvocation != null)
			{
				serializerInvocation.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_SelectCampaign")]
	internal DarkLabel Label_SelectCampaign
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _CodeInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopStatus;
			DarkUIButton codeInvocation = _CodeInvocation;
			if (codeInvocation != null)
			{
				codeInvocation.Click -= value2;
			}
			_CodeInvocation = value;
			codeInvocation = _CodeInvocation;
			if (codeInvocation != null)
			{
				codeInvocation.Click += value2;
			}
		}
	}

	internal DarkUIProgressBar PB_CampaignSaves
	{
		[CompilerGenerated]
		get
		{
			return connectionInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionInvocation = value;
		}
	}

	[field: AccessedThroughProperty("Column_Name")]
	internal TreeGridColumn Column_Name
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Column_ScenTime")]
	internal TreeGridColumn Column_ScenTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Column_SaveTime")]
	internal TreeGridColumn Column_SaveTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	private Button AddProccesor()
	{
		return m_ConfigurationInvocation;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void DestroyProccesor(Button button_0)
	{
		m_ConfigurationInvocation = button_0;
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_FilterInvocation != null)
			{
				m_FilterInvocation.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PopStatus()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		Button1 = new DarkUIButton();
		WebBrowser1 = new WebBrowser();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		Button2 = new DarkUIButton();
		Label_SelectCampaign = new DarkLabel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		TabPage2 = new TabPage();
		PB_CampaignSaves = new DarkUIProgressBar();
		Button4 = new DarkUIButton();
		Button3 = new DarkUIButton();
		TGV_CampaignSaves = new DarkTreeGridView();
		Column_Name = new TreeGridColumn();
		Column_ScenTime = new TreeGridColumn();
		Column_SaveTime = new TreeGridColumn();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		TabPage2.SuspendLayout();
		((ISupportInitialize)TGV_CampaignSaves).BeginInit();
		SuspendLayout();
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(316, 508);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(253, 48);
		Button1.TabIndex = 17;
		Button1.Text = "开始新战役";
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.Location = new Point(316, 3);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(687, 502);
		WebBrowser1.TabIndex = 16;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Dock = DockStyle.Fill;
		TabControl1.Font = new Font("Segoe UI", 8f);
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(0, 0);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(1014, 588);
		TabControl1.TabIndex = 19;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(Button2);
		TabPage1.Controls.Add(Label_SelectCampaign);
		TabPage1.Controls.Add(FlowLayoutPanel1);
		TabPage1.Controls.Add(WebBrowser1);
		TabPage1.Controls.Add(Button1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(1006, 560);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "开始新战役";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(750, 508);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(253, 48);
		Button2.TabIndex = 20;
		Button2.Text = "取消";
		Label_SelectCampaign.AutoSize = true;
		Label_SelectCampaign.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label_SelectCampaign.ForeColor = Color.FromArgb(220, 220, 220);
		Label_SelectCampaign.Location = new Point(317, 4);
		Label_SelectCampaign.Name = "Label_SelectCampaign";
		Label_SelectCampaign.Size = new Size(429, 42);
		Label_SelectCampaign.TabIndex = 19;
		Label_SelectCampaign.Text = "选择一个新的战役进程，或从保存中恢复现有的战役进程。";
		FlowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		FlowLayoutPanel1.AutoScroll = true;
		FlowLayoutPanel1.BackColor = Color.FromArgb(43, 43, 43);
		FlowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
		FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel1.Location = new Point(0, 0);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(305, 562);
		FlowLayoutPanel1.TabIndex = 18;
		FlowLayoutPanel1.WrapContents = false;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(PB_CampaignSaves);
		TabPage2.Controls.Add(Button4);
		TabPage2.Controls.Add(Button3);
		TabPage2.Controls.Add(TGV_CampaignSaves);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(1006, 560);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "从保存中恢复";
		PB_CampaignSaves.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		PB_CampaignSaves.BackColor = Color.Transparent;
		PB_CampaignSaves.Font = new Font("Segoe UI", 9f);
		PB_CampaignSaves.Location = new Point(346, 521);
		PB_CampaignSaves.Maximum = 100;
		PB_CampaignSaves.Name = "PB_CampaignSaves";
		PB_CampaignSaves.ShowProgressLines = true;
		PB_CampaignSaves.ShowProgressValue = true;
		PB_CampaignSaves.Size = new Size(340, 33);
		PB_CampaignSaves.TabIndex = 11;
		PB_CampaignSaves.Value = 0;
		Button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button4.BackColor = Color.Transparent;
		Button4.DialogResult = DialogResult.None;
		Button4.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button4.ForeColor = SystemColors.Control;
		Button4.Location = new Point(773, 521);
		Button4.Name = "Button4";
		Button4.RoundRadius = 0;
		Button4.Size = new Size(225, 33);
		Button4.TabIndex = 10;
		Button4.Text = "删除所选的保存";
		Button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(3, 521);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(223, 33);
		Button3.TabIndex = 9;
		Button3.Text = "从选定的保存中恢复";
		TGV_CampaignSaves.AllowUserToAddRows = false;
		TGV_CampaignSaves.AllowUserToDeleteRows = false;
		TGV_CampaignSaves.AllowUserToOrderColumns = true;
		TGV_CampaignSaves.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_CampaignSaves.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_CampaignSaves.BorderStyle = BorderStyle.None;
		TGV_CampaignSaves.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_CampaignSaves.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_CampaignSaves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_CampaignSaves.Columns.AddRange(Column_Name, Column_ScenTime, Column_SaveTime);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_CampaignSaves.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_CampaignSaves.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_CampaignSaves.EnableHeadersVisualStyles = false;
		TGV_CampaignSaves.ImageList = null;
		TGV_CampaignSaves.Location = new Point(3, 3);
		TGV_CampaignSaves.MultiSelect = false;
		TGV_CampaignSaves.Name = "TGV_CampaignSaves";
		TGV_CampaignSaves.RowHeadersVisible = false;
		TGV_CampaignSaves.RowHeadersWidth = 20;
		TGV_CampaignSaves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_CampaignSaves.ShowLines = false;
		TGV_CampaignSaves.Size = new Size(997, 500);
		TGV_CampaignSaves.TabIndex = 8;
		Column_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Column_Name.DefaultNodeImage = null;
		Column_Name.HeaderText = "名称";
		Column_Name.Name = "Column_Name";
		Column_Name.ReadOnly = true;
		Column_Name.Resizable = DataGridViewTriState.True;
		Column_Name.SortMode = DataGridViewColumnSortMode.NotSortable;
		Column_ScenTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Column_ScenTime.DefaultNodeImage = null;
		Column_ScenTime.HeaderText = "想定时间";
		Column_ScenTime.Name = "Column_ScenTime";
		Column_ScenTime.ReadOnly = true;
		Column_ScenTime.Resizable = DataGridViewTriState.True;
		Column_ScenTime.SortMode = DataGridViewColumnSortMode.NotSortable;
		Column_ScenTime.Width = 82;
		Column_SaveTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Column_SaveTime.DefaultNodeImage = null;
		Column_SaveTime.HeaderText = "节省实际时间";
		Column_SaveTime.Name = "Column_SaveTime";
		Column_SaveTime.ReadOnly = true;
		Column_SaveTime.Resizable = DataGridViewTriState.True;
		Column_SaveTime.SortMode = DataGridViewColumnSortMode.NotSortable;
		Column_SaveTime.Width = 96;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1014, 588);
		base.Controls.Add(TabControl1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CampaignPlayWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "战役";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		((ISupportInitialize)TGV_CampaignSaves).EndInit();
		ResumeLayout(performLayout: false);
	}

	public CampaignPlayWindow()
	{
		base.FormClosed += CreateStatus;
		base.Load += ReadStatus;
		base.Shown += CancelStatus;
		_TokenInvocation = new Queue<Tuple<string, string, string, string>>();
		PopStatus();
		InterpreterObjectListener.ShowScrollBar(FlowLayoutPanel1.Handle, 1, bool_0: true);
	}

	private void InstantiateStatus()
	{
		FlowLayoutPanel1.Controls.Clear();
		List<string> list = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		list = list.OrderByDescending((string theFilename) => new FileInfo(theFilename).CreationTimeUtc).ToList();
		foreach (string item in list)
		{
			Campaign.ReadFromFile(item);
			DestroyProccesor(new Button());
			AddProccesor().Height = 135;
			AddProccesor().Width = 280;
			if (FileExistsNative.FileExistsFast(Path.ChangeExtension(item, "png")))
			{
				AddProccesor().Image = Image.FromFile(Path.ChangeExtension(item, "png"));
			}
			else
			{
				AddProccesor().Image = Image.FromFile(Path.Combine(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath, "Command.ico"));
			}
			AddProccesor().Tag = item;
			FlowLayoutPanel1.Controls.Add(AddProccesor());
			AddProccesor().Click += ReflectStatus;
			AddProccesor().MouseEnter += RestartStatus;
			AddProccesor().MouseLeave += TestStatus;
		}
	}

	private void CreateStatus(object sender, FormClosedEventArgs e)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = FlowLayoutPanel1.Controls.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				DestroyProccesor((Button)objectValue);
				AddProccesor().Click -= ReflectStatus;
				AddProccesor().MouseEnter -= RestartStatus;
				AddProccesor().MouseLeave -= TestStatus;
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	private void CompareStatus()
	{
		TGV_CampaignSaves.Nodes.Clear();
		List<string> Local_theList = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, Local_theList);
		int Local_TotalSaves = 0;
		foreach (string item in Local_theList)
		{
			string directoryName = Path.GetDirectoryName(item);
			Local_TotalSaves += Directory.GetFiles(directoryName, "*-*-*-*-*.save").Count();
		}
		PB_CampaignSaves.Visible = true;
		int Local_SavesProcessed = 0;
		Application.DoEvents();
		Task.Factory.StartNew(delegate
		{
			foreach (string current in Local_theList)
			{
				Campaign Local_theCampaign = Campaign.ReadFromFile(current);
				string directoryName2 = Path.GetDirectoryName(current);
				TreeGridNode Local_CampaignNode = null;
				IEnumerable<string> enumerable = from theFN in Directory.GetFiles(directoryName2, "*-*-*-*-*.save")
					orderby new FileInfo(theFN).CreationTime
					select theFN;
				if (enumerable.Count() > 0)
				{
					if (!base.Visible)
					{
						return;
					}
					TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						Local_CampaignNode = TGV_CampaignSaves.Nodes.Add(Local_theCampaign.Name);
						Application.DoEvents();
					});
					Local_CampaignNode.Tag = Local_theCampaign;
					HashSet<string> hashSet = new HashSet<string>();
					foreach (string Local_theFileName in enumerable)
					{
						if (Operators.CompareString(Path.GetExtension(Local_theFileName), ".save", TextCompare: true) == 0)
						{
							try
							{
								string Local_SaveFile_Title = null;
								string Local_SaveFile_CampaignSessionID = null;
								ScenContainer scenContainer = ScenContainer.LoadFromFile(Local_theFileName);
								string text;
								string value;
								if (scenContainer.SaveCurrentTime == 0)
								{
									List<string> list_ = new List<string> { "CampaignID", "CampaignSessionID", "Title", "Time" };
									string[] array = Scenario.QueryScenario_ScenFileName(Local_theFileName, list_);
									text = array[0];
									Local_SaveFile_CampaignSessionID = array[1];
									Local_SaveFile_Title = array[2];
									value = array[3];
									scenContainer.CampaignID = text;
									scenContainer.CampaignSessionID = Local_SaveFile_CampaignSessionID;
									scenContainer.ScenTitle = Local_SaveFile_Title;
									scenContainer.SaveCurrentTime = Conversions.ToLong(value);
									scenContainer.SaveToFile(Local_theFileName, bool_0: true);
								}
								else
								{
									text = scenContainer.CampaignID;
									Local_SaveFile_CampaignSessionID = scenContainer.CampaignSessionID;
									Local_SaveFile_Title = scenContainer.ScenTitle;
									value = Conversions.ToString(scenContainer.SaveCurrentTime);
								}
								if (!string.IsNullOrEmpty(text))
								{
									TreeGridNode Local_SessionNode = null;
									if (hashSet.Contains(Local_SaveFile_CampaignSessionID))
									{
										Local_SessionNode = (from theNode in InterpreterObjectListener.FlushInterruptibleTask(TGV_CampaignSaves)
											where (object)theNode.Tag.GetType() == typeof(string) && Operators.CompareString(Conversions.ToString(theNode.Tag), "Session_" + Local_SaveFile_CampaignSessionID, TextCompare: true) == 0
											select theNode).ElementAtOrDefault(0);
									}
									else
									{
										hashSet.Add(Local_SaveFile_CampaignSessionID);
										if (!base.Visible)
										{
											return;
										}
										TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
										{
											Local_SessionNode = Local_CampaignNode.Nodes.Add("Session started at: " + new FileInfo(Local_theFileName).CreationTime.ToShortDateString() + " " + new FileInfo(Local_theFileName).CreationTime.ToShortTimeString());
											Application.DoEvents();
										});
										Local_SessionNode.Tag = "Session_" + Local_SaveFile_CampaignSessionID;
									}
									DateTime Local_ScenTime = DateTime.FromBinary(Conversions.ToLong(value));
									if (scenContainer.IsCampaignCheckpoint)
									{
										Local_SaveFile_Title += " (Checkpoint)";
									}
									DateTime Local_SaveTime = File.GetLastWriteTime(Local_theFileName);
									TreeGridNode Local_SaveNode = null;
									if (!base.Visible)
									{
										return;
									}
									TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
									{
										Local_SaveNode = Local_SessionNode.Nodes.Add(Local_SaveFile_Title, Local_ScenTime, Local_SaveTime);
										int num = Local_SavesProcessed;
										Local_SavesProcessed = num + 1;
										PB_CampaignSaves.Value = (int)Math.Round(100.0 * ((double)Local_SavesProcessed / (double)Local_TotalSaves));
										Application.DoEvents();
									});
									Local_SaveNode.Tag = Local_theFileName;
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception exception_ = ex;
								exception_?.Data.Add("Error at 200374", exception_.Message);
								GameGeneral.WriteExceptionsToLog(ref exception_);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
					}
					if (!base.Visible)
					{
						return;
					}
					TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						Local_CampaignNode.Expand();
						Application.DoEvents();
					});
				}
			}
			if (base.Visible)
			{
				TGV_CampaignSaves.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					PB_CampaignSaves.Visible = false;
					Application.DoEvents();
				});
			}
		});
	}

	private void ReadStatus(object sender, EventArgs e)
	{
		WebBrowser1.Visible = false;
		FlowLayoutPanel1.VerticalScroll.Visible = true;
		InstantiateStatus();
		Button1.Visible = false;
		Application.DoEvents();
	}

	private void DisableStatus(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(_StrategyInvocation) || Operators.CompareString(Path.GetExtension(_StrategyInvocation), ".campaign", TextCompare: true) != 0)
		{
			return;
		}
		Campaign campaign = Campaign.ReadFromFile(_StrategyInvocation);
		AttachmentRepoManager.MoveAttachmentsToLocalRepo(Path.GetDirectoryName(_StrategyInvocation));
		foreach (Campaign.CampaignItem campaignItem in campaign.CampaignItems)
		{
			Type type = campaignItem.GetType();
			if (!(type == typeof(Campaign.ScenarioRecord)))
			{
				if (type == typeof(Campaign.AttachmentRecord))
				{
					LuaSAO.ScenEdit_UseAttachment(((Campaign.AttachmentRecord)campaignItem).ID, null);
				}
				continue;
			}
			string scenFileName = Path.GetDirectoryName(_StrategyInvocation) + "\\" + ((Campaign.ScenarioRecord)campaignItem).FileName;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.SelectedCampaign = campaign;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.ScenFileName = scenFileName;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.CampaignSessionID = Guid.NewGuid().ToString();
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.CampaignScore = 0;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.LuaXml = "";
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.Show();
			Close();
			break;
		}
	}

	private void UpdateStatus(object sender, EventArgs e)
	{
		if (TGV_CampaignSaves.CurrentNode == null || Operators.CompareString(Path.GetExtension(_StrategyInvocation), ".save", TextCompare: true) != 0)
		{
			return;
		}
		Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		ScenContainer scenContainer = ScenContainer.LoadFromFile(_StrategyInvocation);
		if (scenContainer.IsCampaignCheckpoint)
		{
			string directoryName = Path.GetDirectoryName(_StrategyInvocation);
			string text = scenContainer.CampaignID;
			if (string.IsNullOrEmpty(text))
			{
				text = Scenario.QueryScenario_ScenFileName(_StrategyInvocation, "CampaignID");
			}
			string text2 = scenContainer.CampaignSessionID;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = Scenario.QueryScenario_ScenFileName(_StrategyInvocation, "CampaignSessionID");
			}
			if (!string.IsNullOrEmpty(text))
			{
				Campaign campaignByID = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, text);
				if (campaignByID != null)
				{
					string text3 = Scenario.QueryScenario_ScenFileName(_StrategyInvocation, "ObjectID");
					if (!string.IsNullOrEmpty(text3))
					{
						Campaign.ScenarioRecord scenarioRecord = campaignByID.GetScenarioRecord(text3);
						if (scenarioRecord != null)
						{
							_StrategyInvocation = Path.Combine(directoryName, scenarioRecord.FileName);
							ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.CampaignSessionID = text2;
						}
					}
				}
			}
		}
		ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = _StrategyInvocation;
		ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
		if (Client.CurrentGame.GameMode != 0)
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		}
		Close();
	}

	private void InsertStatus(object sender, EventArgs e)
	{
		if (Information.IsNothing(TGV_CampaignSaves.CurrentNode))
		{
			Button3.Enabled = false;
		}
		else if ((object)TGV_CampaignSaves.CurrentNode.Tag.GetType() == typeof(string) && !Conversions.ToString(TGV_CampaignSaves.CurrentNode.Tag).StartsWith("Session_"))
		{
			_StrategyInvocation = Conversions.ToString(TGV_CampaignSaves.CurrentNode.Tag);
			Button3.Enabled = true;
		}
		else
		{
			Button3.Enabled = false;
		}
	}

	private void PrepareStatus(object sender, EventArgs e)
	{
		if (TGV_CampaignSaves.CurrentNode != null && !string.IsNullOrEmpty(_StrategyInvocation) && Operators.CompareString(Path.GetExtension(_StrategyInvocation), ".save", TextCompare: true) == 0)
		{
			File.Delete(_StrategyInvocation);
			TGV_CampaignSaves.CurrentNode.Parent.Nodes.Remove(TGV_CampaignSaves.CurrentNode);
			_StrategyInvocation = null;
		}
	}

	private void ReflectStatus(object sender, EventArgs e)
	{
		WebBrowser1.Visible = true;
		_StrategyInvocation = Conversions.ToString(((Button)sender).Tag);
		if (Operators.CompareString(Path.GetExtension(_StrategyInvocation), ".campaign", TextCompare: true) != 0)
		{
			return;
		}
		Label_SelectCampaign.Visible = false;
		Campaign campaign = Campaign.ReadFromFile(_StrategyInvocation);
		string string_ = Scenario.QueryScenario_ScenXML(ScenContainer.LoadFromFile(campaign.GetFirstScenarioFilename(_StrategyInvocation)).GetScenarioObject_AsXML(), "ContentTag");
		if (Licensing.IsUserLicensedForThisContent(string_))
		{
			WebBrowser1.Visible = true;
			WebBrowser1.AllowNavigation = true;
			string localizedDescription = Localization.ScenarioText(_StrategyInvocation, "Description", campaign.Description);
			if (!VisitStatus(WebBrowser1, localizedDescription, Path.GetDirectoryName(_StrategyInvocation)))
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, localizedDescription);
			}
			Button1.Visible = true;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(string_) };
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
			WebBrowser1.Visible = false;
			WebBrowser1.AllowNavigation = false;
			Button1.Visible = false;
		}
	}

	private bool VisitStatus(WebBrowser webBrowser_0, string string_0, string string_1)
	{
		if (string_0.Contains("[LOADDOC]"))
		{
			int num = Strings.InStr(string_0, "[LOADDOC]", CompareMethod.Text) + "[LOADDOC]".Length - 1;
			int num2 = Strings.InStr(string_0, "[/LOADDOC]", CompareMethod.Text);
			string path = string_0.Substring(num, string_0.Length - num - (string_0.Length - num2 + 1));
			webBrowser_0.Navigate(Path.Combine(string_1, path));
			return true;
		}
		return false;
	}

	private void RestartStatus(object sender, EventArgs e)
	{
		Cursor = Cursors.Hand;
	}

	private void TestStatus(object sender, EventArgs e)
	{
		Cursor = Cursors.Arrow;
	}

	private void StopStatus(object sender, EventArgs e)
	{
		StartGameMenuWindow.ShowStartWindow();
		Close();
	}

	private void CancelStatus(object sender, EventArgs e)
	{
		Application.DoEvents();
		CompareStatus();
	}
}
