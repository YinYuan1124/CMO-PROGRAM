using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSMaterial;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using baileysoft.Wmi;

namespace Command;

[DesignerGenerated]
public sealed class BenchmarkForm : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class TagCallbackCandidate
	{
		public string text;

		public string text2;

		public string text3;

		public BenchmarkForm _003C_003E4__this;

		internal void CancelInterruptibleParam()
		{
			_003C_003E4__this.Label_Specs.Text = GameGeneral.ProgramTitle + "\r\n" + text + "\r\n" + text2 + "\r\n" + text3;
		}
	}

	private IContainer _VisitorBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Run")]
	private DarkUIButton m_ExporterBridge;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog prototypeBridge;

	[AccessedThroughProperty("FolderBrowserDialog1")]
	[CompilerGenerated]
	private FolderBrowserDialog comparatorBridge;

	[AccessedThroughProperty("BackgroundWorker1")]
	[CompilerGenerated]
	private BackgroundWorker itemBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel m_SetterBridge;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer creatorBridge;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel m_TemplateBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_EventQueues")]
	private DarkLabel mappingBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Abort")]
	private DarkUIButton mockBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ScenarioFile")]
	private DarkUIButton m_TagBridge;

	[AccessedThroughProperty("Label_Specs")]
	[CompilerGenerated]
	private DarkLabel m_PageBridge;

	[AccessedThroughProperty("Label_PulseTimeInfo")]
	[CompilerGenerated]
	private DarkLabel m_RulesBridge;

	[AccessedThroughProperty("ComboBox_Fidelity")]
	[CompilerGenerated]
	private DarkUIComboBox methodBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel1")]
	private DarkLabel serviceBridge;

	private int systemBridge;

	private int _CandidateBridge;

	private string _BaseBridge;

	private Scenario _PolicyBridge;

	private bool _BroadcasterBridge;

	private bool m_IdentifierBridge;

	private DateTime m_PrinterBridge;

	private float _ParserBridge;

	private int _AlgoBridge;

	private int _DatabaseBridge;

	private int interceptorBridge;

	private double m_MessageBridge;

	private double m_ProductBridge;

	private DateTime annotationBridge;

	private DateTime m_IteratorBridge;

	private DateTime initializerBridge;

	private long m_RoleBridge;

	internal DarkUIButton Button_Run
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveConnection;
			DarkUIButton exporterBridge = m_ExporterBridge;
			if (exporterBridge != null)
			{
				exporterBridge.Click -= value2;
			}
			m_ExporterBridge = value;
			exporterBridge = m_ExporterBridge;
			if (exporterBridge != null)
			{
				exporterBridge.Click += value2;
			}
		}
	}

	internal OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return prototypeBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			prototypeBridge = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_SetterBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SetterBridge = value;
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TemplateBridge = value;
		}
	}

	internal DarkLabel Label_EventQueues
	{
		[CompilerGenerated]
		get
		{
			return mappingBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingBridge = value;
		}
	}

	internal DarkUIButton Button_Abort
	{
		[CompilerGenerated]
		get
		{
			return mockBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateConnection;
			DarkUIButton darkUIButton = mockBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			mockBridge = value;
			darkUIButton = mockBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ScenarioFile
	{
		[CompilerGenerated]
		get
		{
			return m_TagBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptConnection;
			DarkUIButton tagBridge = m_TagBridge;
			if (tagBridge != null)
			{
				tagBridge.Click -= value2;
			}
			m_TagBridge = value;
			tagBridge = m_TagBridge;
			if (tagBridge != null)
			{
				tagBridge.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal DarkUITextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("NumericUpDown1")]
	internal GControl1 NumericUpDown1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_Specs
	{
		[CompilerGenerated]
		get
		{
			return m_PageBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageBridge = value;
		}
	}

	internal DarkLabel Label_PulseTimeInfo
	{
		[CompilerGenerated]
		get
		{
			return m_RulesBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RulesBridge = value;
		}
	}

	internal DarkUIComboBox ComboBox_Fidelity
	{
		[CompilerGenerated]
		get
		{
			return methodBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodBridge = value;
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return serviceBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serviceBridge = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal FolderBrowserDialog UpdateConnection()
	{
		return comparatorBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void InsertConnection(FolderBrowserDialog folderBrowserDialog_0)
	{
		comparatorBridge = folderBrowserDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker ReflectConnection()
	{
		return itemBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void VisitConnection(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = FindConnection;
		RunWorkerCompletedEventHandler value2 = FillConnection;
		BackgroundWorker backgroundWorker = itemBridge;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		itemBridge = backgroundWorker_0;
		backgroundWorker = itemBridge;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer CancelConnection()
	{
		return creatorBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void VerifyConnection(Timer timer_0)
	{
		EventHandler value = SetConnection;
		Timer timer = creatorBridge;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		creatorBridge = timer_0;
		timer = creatorBridge;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	public BenchmarkForm()
	{
		base.Shown += ConcatConnection;
		base.Closing += PopConnection;
		_BroadcasterBridge = false;
		m_IdentifierBridge = false;
		CheckConnection();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _VisitorBridge != null)
			{
				_VisitorBridge.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CheckConnection()
	{
		_VisitorBridge = new Container();
		OpenFileDialog1 = new OpenFileDialog();
		InsertConnection(new FolderBrowserDialog());
		VisitConnection(new BackgroundWorker());
		VerifyConnection(new Timer(_VisitorBridge));
		Label_PulseTimeInfo = new DarkLabel();
		Label_Specs = new DarkLabel();
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button_Abort = new DarkUIButton();
		Button_ScenarioFile = new DarkUIButton();
		Label_EventQueues = new DarkLabel();
		NumericUpDown1 = new GControl1();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		Label3 = new DarkLabel();
		Button_Run = new DarkUIButton();
		ComboBox_Fidelity = new DarkUIComboBox();
		DarkLabel1 = new DarkLabel();
		SuspendLayout();
		OpenFileDialog1.DefaultExt = "scen";
		OpenFileDialog1.FileName = "OpenFileDialog1";
		CancelConnection().Interval = 1000;
		Label_PulseTimeInfo.AutoSize = true;
		Label_PulseTimeInfo.ForeColor = Color.FromArgb(220, 220, 220);
		Label_PulseTimeInfo.Location = new Point(12, 201);
		Label_PulseTimeInfo.Name = "Label_PulseTimeInfo";
		Label_PulseTimeInfo.Size = new Size(16, 15);
		Label_PulseTimeInfo.TabIndex = 15;
		Label_PulseTimeInfo.Text = "...";
		Label_Specs.AutoSize = true;
		Label_Specs.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Specs.Location = new Point(12, 11);
		Label_Specs.Name = "Label_Specs";
		Label_Specs.Size = new Size(127, 15);
		Label_Specs.TabIndex = 14;
		Label_Specs.Text = "正在获取系统参数...";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 84);
		Label1.Name = "Label1";
		Label1.Size = new Size(55, 15);
		Label1.TabIndex = 0;
		Label1.Text = "想定：";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(77, 81);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(506, 20);
		TextBox1.TabIndex = 1;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Button_Abort.BackColor = Color.Transparent;
		Button_Abort.DialogResult = DialogResult.None;
		Button_Abort.Enabled = false;
		Button_Abort.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button_Abort.ForeColor = Color.IndianRed;
		Button_Abort.Location = new Point(507, 185);
		Button_Abort.Name = "Button_Abort";
		Button_Abort.RoundRadius = 0;
		Button_Abort.Size = new Size(157, 54);
		Button_Abort.TabIndex = 13;
		Button_Abort.Text = "取消";
		Button_ScenarioFile.BackColor = Color.Transparent;
		Button_ScenarioFile.DialogResult = DialogResult.None;
		Button_ScenarioFile.ForeColor = SystemColors.Control;
		Button_ScenarioFile.Location = new Point(589, 81);
		Button_ScenarioFile.Name = "Button_ScenarioFile";
		Button_ScenarioFile.RoundRadius = 0;
		Button_ScenarioFile.Size = new Size(75, 20);
		Button_ScenarioFile.TabIndex = 2;
		Button_ScenarioFile.Text = "选择...";
		Label_EventQueues.AutoSize = true;
		Label_EventQueues.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		Label_EventQueues.ForeColor = Color.FromArgb(220, 220, 220);
		Label_EventQueues.Location = new Point(12, 186);
		Label_EventQueues.MaximumSize = new Size(300, 0);
		Label_EventQueues.Name = "Label_EventQueues";
		Label_EventQueues.Size = new Size(168, 15);
		Label_EventQueues.TabIndex = 12;
		Label_EventQueues.Text = "脉冲时间（越低越好）：";
		NumericUpDown1.BackColor = Color.Transparent;
		NumericUpDown1.Location = new Point(77, 110);
		NumericUpDown1.Maximum = 10000;
		NumericUpDown1.Minimum = 1;
		NumericUpDown1.Name = "NumericUpDown1";
		NumericUpDown1.Size = new Size(60, 26);
		NumericUpDown1.TabIndex = 7;
		NumericUpDown1.Value = 10;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(12, 148);
		Label5.Name = "Label5";
		Label5.Size = new Size(57, 15);
		Label5.TabIndex = 10;
		Label5.Text = "已重复次数：";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(12, 164);
		Label4.Name = "Label4";
		Label4.Size = new Size(67, 15);
		Label4.TabIndex = 9;
		Label4.Text = "想定时间：";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(12, 114);
		Label3.Name = "Label3";
		Label3.Size = new Size(59, 15);
		Label3.TabIndex = 6;
		Label3.Text = "重复总数：";
		Button_Run.BackColor = Color.Transparent;
		Button_Run.DialogResult = DialogResult.None;
		Button_Run.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button_Run.ForeColor = Color.Green;
		Button_Run.Location = new Point(344, 185);
		Button_Run.Name = "Button_Run";
		Button_Run.RoundRadius = 0;
		Button_Run.Size = new Size(157, 54);
		Button_Run.TabIndex = 8;
		Button_Run.Text = "开始";
		ComboBox_Fidelity.BackColor = Color.Transparent;
		ComboBox_Fidelity.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_Fidelity.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_Fidelity.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_Fidelity.FormattingEnabled = true;
		ComboBox_Fidelity.Items.AddRange(new object[3] { "非常粗粒度（5秒计算一次）", "粗粒度（1秒计算一次）", "细粒度（0.1秒计算一次）" });
		ComboBox_Fidelity.Location = new Point(210, 110);
		ComboBox_Fidelity.Name = "ComboBox_Fidelity";
		ComboBox_Fidelity.Size = new Size(189, 24);
		ComboBox_Fidelity.TabIndex = 16;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(156, 114);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(48, 15);
		DarkLabel1.TabIndex = 17;
		DarkLabel1.Text = "仿真粒度：";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(676, 249);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(ComboBox_Fidelity);
		base.Controls.Add(Label_PulseTimeInfo);
		base.Controls.Add(Label_Specs);
		base.Controls.Add(Label1);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Button_Abort);
		base.Controls.Add(Button_ScenarioFile);
		base.Controls.Add(Label_EventQueues);
		base.Controls.Add(NumericUpDown1);
		base.Controls.Add(Label5);
		base.Controls.Add(Label4);
		base.Controls.Add(Label3);
		base.Controls.Add(Button_Run);
		base.Icon = QResourceHelper.GetIcon("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "BenchmarkForm";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "性能测试";
		base.TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ConcatConnection(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Hide();
		ComboBox_Fidelity.SelectedIndex = 0;
		Task.Factory.StartNew(delegate
		{
			string text = "CPU: N/A";
			string text2 = "RAM: N/A";
			string text3 = "OS: N/A";
			try
			{
				Connection connection_ = new Connection();
				Win32_Processor win32_Processor = new Win32_Processor(connection_);
				text = "CPU " + (from theStr in win32_Processor.GetPropertyValues()
					where theStr.StartsWith("名称:")
					select theStr).FirstOrDefault();
				Win32_MemoryDevice win32_MemoryDevice = new Win32_MemoryDevice(connection_);
				text2 = "RAM: " + Conversions.ToString((int)Math.Round((double)Conversions.ToInteger((from theStr in win32_MemoryDevice.GetPropertyValues()
					where theStr.StartsWith("EndingAddress:")
					select theStr).LastOrDefault().Split(':')[1]) / 1024.0)) + " MB";
				text3 = "OS: " + OSVersionInfo.Name + " (" + OSVersionInfo.OSBits.ToString() + ")";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					text2 = text2 + "RAM: " + ((double)ItemExporter.RegisterInterruptibleMap.Info.TotalPhysicalMemory / 1000000.0).ToString("#.#") + "MB";
					text3 = text3 + "OS: " + ItemExporter.RegisterInterruptibleMap.Info.OSFullName;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Interaction.MsgBox("错误：" + ex2.Message + "\r\nStackTrace: " + ex4.StackTrace);
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
			Label_Specs.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				Label_Specs.Text = GameGeneral.ProgramTitle + "\r\n" + text + "\r\n" + text2 + "\r\n" + text3;
			});
		});
	}

	private void InterruptConnection(object sender, EventArgs e)
	{
		OpenFileDialog1.DefaultExt = "*.scen";
		OpenFileDialog1.FileName = "*.scen";
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			_BaseBridge = OpenFileDialog1.FileName;
			TextBox1.Text = Path.GetFileName(OpenFileDialog1.FileName);
		}
	}

	private void RemoveConnection(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(TextBox1.Text))
		{
			DarkMessageBox.ShowError("还未选择想定！", "Error");
			return;
		}
		systemBridge = NumericUpDown1.Value;
		Button_Run.Enabled = false;
		Button_ScenarioFile.Enabled = false;
		ComboBox_Fidelity.Enabled = false;
		NumericUpDown1.Enabled = false;
		TextBox1.Enabled = false;
		Button_Abort.Enabled = true;
		Text = "Running...";
		m_PrinterBridge = DateTime.Now;
		switch (ComboBox_Fidelity.SelectedIndex)
		{
		case 0:
			GameGeneral.Global_PulseResolution = 5f;
			break;
		case 1:
			GameGeneral.Global_PulseResolution = 1f;
			break;
		case 2:
			GameGeneral.Global_PulseResolution = 0.1f;
			break;
		}
		CancelConnection().Start();
		ReflectConnection().RunWorkerAsync();
	}

	private void FindConnection(object sender, DoWorkEventArgs e)
	{
		_BroadcasterBridge = true;
		try
		{
			_ParserBridge = 0f;
			_AlgoBridge = 0;
			_DatabaseBridge = 0;
			interceptorBridge = int.MaxValue;
			m_RoleBridge = 0L;
			m_MessageBridge = 0.0;
			m_ProductBridge = 0.0;
			ScenContainer scenContainer = ScenContainer.LoadFromFile(_BaseBridge);
			float global_PulseResolution = GameGeneral.Global_PulseResolution;
			Stopwatch stopwatch = new Stopwatch();
			int num = systemBridge;
			_CandidateBridge = 1;
			while (_CandidateBridge <= num)
			{
				_PolicyBridge = null;
				if (!m_IdentifierBridge)
				{
					string string_ = null;
					_PolicyBridge = scenContainer.GetScenarioObject(ref string_, null, bool_0: false);
					_PolicyBridge.GameResolution = global_PulseResolution;
					_PolicyBridge.RunningHeadless = true;
					_PolicyBridge.BranchToNewTimeline();
					_PolicyBridge.Scenario_LuaSandbox.RefreshStats(_PolicyBridge);
					bool flag = true;
					annotationBridge = _PolicyBridge.Time;
					initializerBridge = DateTime.UtcNow;
					while (!_PolicyBridge.HasEnded)
					{
						if (!m_IdentifierBridge)
						{
							stopwatch.Reset();
							stopwatch.Start();
							GameGeneral.MainGameLoop(ref _PolicyBridge);
							stopwatch.Stop();
							if (flag)
							{
								flag = false;
							}
							else
							{
								_AlgoBridge = (int)stopwatch.ElapsedMilliseconds;
								_DatabaseBridge = Math.Max(_DatabaseBridge, _AlgoBridge);
								interceptorBridge = Math.Min(interceptorBridge, _AlgoBridge);
								_ParserBridge = (_ParserBridge * (float)m_RoleBridge + (float)_AlgoBridge) / (float)(m_RoleBridge + 1);
								m_RoleBridge++;
								int num2 = (int)Math.Ceiling((_PolicyBridge.Time - annotationBridge).TotalSeconds);
								int num3 = (int)Math.Ceiling((DateTime.UtcNow - initializerBridge).TotalSeconds);
								m_MessageBridge = (double)num2 / (double)num3;
								m_ProductBridge = Math.Max(m_ProductBridge, m_MessageBridge);
							}
							Client.PushConfiguration(_PolicyBridge, bool_0: false, string.Empty);
							continue;
						}
						_BroadcasterBridge = false;
						return;
					}
					GameGeneral.DestroyPreviousScenario(ref _PolicyBridge, bool_1: true);
					_CandidateBridge++;
					continue;
				}
				_BroadcasterBridge = false;
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occured: " + ex2.Message + "\r\n\r\nThe benchmark run has been forced to stop. This does not affect the results gathered so far.", "Error during benchmark");
			ProjectData.ClearProjectError();
		}
		_BroadcasterBridge = false;
	}

	private void SetConnection(object sender, EventArgs e)
	{
		if (_PolicyBridge != null)
		{
			TimeSpan timeSpan = _PolicyBridge.StartTime.Add(_PolicyBridge.Duration) - _PolicyBridge.Time;
			Label4.Text = "想定时间：" + _PolicyBridge.Time.ToString() + ((timeSpan.TotalSeconds < 0.0) ? string.Empty : (" (To Go: " + Misc.UpdateRequest((long)Math.Round(timeSpan.TotalSeconds)) + ")")) + " - Time accel: x" + Conversions.ToString(Math.Round(m_MessageBridge, 1)) + " (Max: x" + Conversions.ToString(Math.Round(m_ProductBridge, 1)) + ")";
			Label5.Text = "已重复次数：" + Conversions.ToString(_CandidateBridge);
			Label_PulseTimeInfo.Text = "Highest: " + Conversions.ToString(_DatabaseBridge) + " ms\r\nLowest: " + Conversions.ToString(interceptorBridge) + " ms\r\nAverage: " + Conversions.ToString(Math.Round(_ParserBridge, 1)) + " ms";
		}
	}

	private void FillConnection(object sender, RunWorkerCompletedEventArgs e)
	{
		string text = Misc.UpdateRequest((long)Math.Round((DateTime.Now - m_PrinterBridge).TotalSeconds));
		Button_Run.Enabled = true;
		Button_ScenarioFile.Enabled = true;
		ComboBox_Fidelity.Enabled = true;
		NumericUpDown1.Enabled = true;
		TextBox1.Enabled = true;
		Button_Abort.Enabled = false;
		CancelConnection().Stop();
		if (m_IdentifierBridge)
		{
			m_IdentifierBridge = false;
			Text = "性能测试取消。总用时：" + text;
		}
		else
		{
			Text = "性能测试完成。总用时：" + text;
		}
	}

	private void CalculateConnection(object sender, EventArgs e)
	{
		m_IdentifierBridge = true;
		Button_Abort.Enabled = false;
	}

	private void PopConnection(object sender, CancelEventArgs e)
	{
		m_IdentifierBridge = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Show();
	}

	[CompilerGenerated]
	private void InstantiateConnection()
	{
		string text = "CPU: N/A";
		string text2 = "RAM: N/A";
		string text3 = "OS: N/A";
		try
		{
			Connection connection_ = new Connection();
			Win32_Processor win32_Processor = new Win32_Processor(connection_);
			text = "CPU " + (from theStr in win32_Processor.GetPropertyValues()
				where theStr.StartsWith("名称:")
				select theStr).FirstOrDefault();
			Win32_MemoryDevice win32_MemoryDevice = new Win32_MemoryDevice(connection_);
			text2 = "RAM: " + Conversions.ToString((int)Math.Round((double)Conversions.ToInteger((from theStr in win32_MemoryDevice.GetPropertyValues()
				where theStr.StartsWith("EndingAddress:")
				select theStr).LastOrDefault().Split(':')[1]) / 1024.0)) + " MB";
			text3 = "OS: " + OSVersionInfo.Name + " (" + OSVersionInfo.OSBits.ToString() + ")";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			try
			{
				text2 = text2 + "RAM: " + ((double)ItemExporter.RegisterInterruptibleMap.Info.TotalPhysicalMemory / 1000000.0).ToString("#.#") + "MB";
				text3 = text3 + "OS: " + ItemExporter.RegisterInterruptibleMap.Info.OSFullName;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Interaction.MsgBox("错误：" + ex2.Message + "\r\nStackTrace: " + ex4.StackTrace);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
		Label_Specs.Invoke((VB_0024AnonymousDelegate_0)delegate
		{
			Label_Specs.Text = GameGeneral.ProgramTitle + "\r\n" + text + "\r\n" + text2 + "\r\n" + text3;
		});
	}
}
