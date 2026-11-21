using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RecorderForm : DarkSecondaryFormBase
{
	private IContainer _DicUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Snapshots")]
	private TrackBar _ConsumerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip1")]
	private DarkToolStrip facadeUtils;

	[AccessedThroughProperty("TSB_LoadRecording")]
	[CompilerGenerated]
	private ToolStripButton _ProxyUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator readerUtils;

	[AccessedThroughProperty("TSB_GoToStart")]
	[CompilerGenerated]
	private ToolStripButton _PropertyUtils;

	[AccessedThroughProperty("TSB_StepBack")]
	[CompilerGenerated]
	private ToolStripButton _ImporterUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Play")]
	private ToolStripButton _RepositoryUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_StepForward")]
	private ToolStripButton m_BridgeUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_GoToEnd")]
	private ToolStripButton m_InvocationUtils;

	[AccessedThroughProperty("TSB_LoadMostRecent")]
	[CompilerGenerated]
	private ToolStripButton classUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog1")]
	private OpenFileDialog requestUtils;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer valueUtils;

	[AccessedThroughProperty("Timer2")]
	[CompilerGenerated]
	private Timer m_TokenizerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TSL1")]
	private ToolStripLabel m_WriterUtils;

	[AccessedThroughProperty("TSSL_BadFrame")]
	[CompilerGenerated]
	private ToolStripLabel specificationUtils;

	private RecorderTape _WatcherUtils;

	private int _ReponseUtils;

	private Side _DescriptorUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker _PoolUtils;

	private double _TaskUtils;

	private Scenario m_FilterUtils;

	private bool _TestsUtils;

	private string _InterpreterUtils;

	internal TrackBar TB_Snapshots
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = CreateInterruptibleStatus;
			MouseEventHandler value3 = InsertInterruptibleStatus;
			TrackBar consumerUtils = _ConsumerUtils;
			if (consumerUtils != null)
			{
				consumerUtils.MouseMove -= value2;
				consumerUtils.MouseUp -= value3;
			}
			_ConsumerUtils = value;
			consumerUtils = _ConsumerUtils;
			if (consumerUtils != null)
			{
				consumerUtils.MouseMove += value2;
				consumerUtils.MouseUp += value3;
			}
		}
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return facadeUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			facadeUtils = value;
		}
	}

	internal ToolStripButton TSB_LoadRecording
	{
		[CompilerGenerated]
		get
		{
			return _ProxyUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleStatus;
			ToolStripButton proxyUtils = _ProxyUtils;
			if (proxyUtils != null)
			{
				proxyUtils.Click -= value2;
			}
			_ProxyUtils = value;
			proxyUtils = _ProxyUtils;
			if (proxyUtils != null)
			{
				proxyUtils.Click += value2;
			}
		}
	}

	internal ToolStripSeparator ToolStripSeparator1
	{
		[CompilerGenerated]
		get
		{
			return readerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			readerUtils = value;
		}
	}

	internal ToolStripButton TSB_GoToStart
	{
		[CompilerGenerated]
		get
		{
			return _PropertyUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptibleStatus;
			ToolStripButton propertyUtils = _PropertyUtils;
			if (propertyUtils != null)
			{
				propertyUtils.Click -= value2;
			}
			_PropertyUtils = value;
			propertyUtils = _PropertyUtils;
			if (propertyUtils != null)
			{
				propertyUtils.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_StepBack
	{
		[CompilerGenerated]
		get
		{
			return _ImporterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleStatus;
			ToolStripButton importerUtils = _ImporterUtils;
			if (importerUtils != null)
			{
				importerUtils.Click -= value2;
			}
			_ImporterUtils = value;
			importerUtils = _ImporterUtils;
			if (importerUtils != null)
			{
				importerUtils.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Play
	{
		[CompilerGenerated]
		get
		{
			return _RepositoryUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateInterruptibleStatus;
			ToolStripButton repositoryUtils = _RepositoryUtils;
			if (repositoryUtils != null)
			{
				repositoryUtils.CheckedChanged -= value2;
			}
			_RepositoryUtils = value;
			repositoryUtils = _RepositoryUtils;
			if (repositoryUtils != null)
			{
				repositoryUtils.CheckedChanged += value2;
			}
		}
	}

	internal ToolStripButton TSB_StepForward
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadInterruptibleStatus;
			ToolStripButton bridgeUtils = m_BridgeUtils;
			if (bridgeUtils != null)
			{
				bridgeUtils.Click -= value2;
			}
			m_BridgeUtils = value;
			bridgeUtils = m_BridgeUtils;
			if (bridgeUtils != null)
			{
				bridgeUtils.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_GoToEnd
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptibleStatus;
			ToolStripButton invocationUtils = m_InvocationUtils;
			if (invocationUtils != null)
			{
				invocationUtils.Click -= value2;
			}
			m_InvocationUtils = value;
			invocationUtils = m_InvocationUtils;
			if (invocationUtils != null)
			{
				invocationUtils.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_LoadMostRecent
	{
		[CompilerGenerated]
		get
		{
			return classUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleStatus;
			ToolStripButton toolStripButton = classUtils;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			classUtils = value;
			toolStripButton = classUtils;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return requestUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestUtils = value;
		}
	}

	[field: AccessedThroughProperty("DarkToolStrip1")]
	internal DarkToolStrip DarkToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripLabel TSL1
	{
		[CompilerGenerated]
		get
		{
			return m_WriterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WriterUtils = value;
		}
	}

	internal ToolStripLabel TSSL_BadFrame
	{
		[CompilerGenerated]
		get
		{
			return specificationUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationUtils = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer CustomizeInterruptibleProccesor()
	{
		return valueUtils;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CloneInterruptibleProccesor(Timer timer_0)
	{
		EventHandler value = ReflectInterruptibleStatus;
		Timer timer = valueUtils;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		valueUtils = timer_0;
		timer = valueUtils;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer MoveInterruptibleProccesor()
	{
		return m_TokenizerUtils;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void DeleteInterruptibleProccesor(Timer timer_0)
	{
		EventHandler value = StopInterruptibleStatus;
		Timer tokenizerUtils = m_TokenizerUtils;
		if (tokenizerUtils != null)
		{
			tokenizerUtils.Tick -= value;
		}
		m_TokenizerUtils = timer_0;
		tokenizerUtils = m_TokenizerUtils;
		if (tokenizerUtils != null)
		{
			tokenizerUtils.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker ViewInterruptibleProccesor()
	{
		return _PoolUtils;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void ValidateInterruptibleProccesor(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = VisitInterruptibleStatus;
		RunWorkerCompletedEventHandler value2 = TestInterruptibleStatus;
		BackgroundWorker poolUtils = _PoolUtils;
		if (poolUtils != null)
		{
			poolUtils.DoWork -= value;
			poolUtils.RunWorkerCompleted -= value2;
		}
		_PoolUtils = backgroundWorker_0;
		poolUtils = _PoolUtils;
		if (poolUtils != null)
		{
			poolUtils.DoWork += value;
			poolUtils.RunWorkerCompleted += value2;
		}
	}

	public RecorderForm()
	{
		base.Load += PrepareInterruptibleStatus;
		base.KeyDown += CancelInterruptibleStatus;
		base.FormClosing += VerifyInterruptibleStatus;
		base.Closing += ListInterruptibleStatus;
		RemoveInterruptibleStatus();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _DicUtils != null)
			{
				_DicUtils.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RemoveInterruptibleStatus()
	{
		_DicUtils = new Container();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(RecorderForm));
		TB_Snapshots = new TrackBar();
		ToolStrip1 = new DarkToolStrip();
		TSB_LoadRecording = new ToolStripButton();
		TSB_LoadMostRecent = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_GoToStart = new ToolStripButton();
		TSB_StepBack = new ToolStripButton();
		TSB_Play = new ToolStripButton();
		TSB_StepForward = new ToolStripButton();
		TSB_GoToEnd = new ToolStripButton();
		OpenFileDialog1 = new OpenFileDialog();
		CloneInterruptibleProccesor(new Timer(_DicUtils));
		DeleteInterruptibleProccesor(new Timer(_DicUtils));
		DarkToolStrip1 = new DarkToolStrip();
		TSL1 = new ToolStripLabel();
		TSSL_BadFrame = new ToolStripLabel();
		((ISupportInitialize)TB_Snapshots).BeginInit();
		ToolStrip1.SuspendLayout();
		DarkToolStrip1.SuspendLayout();
		SuspendLayout();
		TB_Snapshots.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Snapshots.Location = new Point(0, 28);
		TB_Snapshots.Name = "TB_Snapshots";
		TB_Snapshots.Size = new Size(464, 45);
		TB_Snapshots.TabIndex = 0;
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[8] { TSB_LoadRecording, TSB_LoadMostRecent, ToolStripSeparator1, TSB_GoToStart, TSB_StepBack, TSB_Play, TSB_StepForward, TSB_GoToEnd });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(464, 25);
		ToolStrip1.TabIndex = 1;
		ToolStrip1.Text = "ToolStrip1";
		TSB_LoadRecording.BackColor = Color.FromArgb(60, 63, 65);
		TSB_LoadRecording.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_LoadRecording.Image = componentResourceManager.GetObject("TSB_LoadRecording.Image");
		TSB_LoadRecording.ImageTransparentColor = Color.Magenta;
		TSB_LoadRecording.Name = "TSB_LoadRecording";
		TSB_LoadRecording.Size = new Size(53, 22);
		TSB_LoadRecording.Text = "加载";
		TSB_LoadMostRecent.BackColor = Color.FromArgb(60, 63, 65);
		TSB_LoadMostRecent.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_LoadMostRecent.Image = componentResourceManager.GetObject("TSB_LoadMostRecent.Image");
		TSB_LoadMostRecent.ImageTransparentColor = Color.Magenta;
		TSB_LoadMostRecent.Name = "TSB_LoadMostRecent";
		TSB_LoadMostRecent.Size = new Size(119, 22);
		TSB_LoadMostRecent.Text = "加载最近";
		ToolStripSeparator1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator1.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(6, 25);
		TSB_GoToStart.BackColor = Color.FromArgb(60, 63, 65);
		TSB_GoToStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
		TSB_GoToStart.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_GoToStart.Image = componentResourceManager.GetObject("TSB_GoToStart.Image");
		TSB_GoToStart.ImageTransparentColor = Color.Magenta;
		TSB_GoToStart.Name = "TSB_GoToStart";
		TSB_GoToStart.Size = new Size(23, 22);
		TSB_GoToStart.Text = "TSB_GoToStart";
		TSB_GoToStart.ToolTipText = "Jump to start of recording";
		TSB_StepBack.BackColor = Color.FromArgb(60, 63, 65);
		TSB_StepBack.DisplayStyle = ToolStripItemDisplayStyle.Image;
		TSB_StepBack.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_StepBack.Image = componentResourceManager.GetObject("TSB_StepBack.Image");
		TSB_StepBack.ImageTransparentColor = Color.Magenta;
		TSB_StepBack.Name = "TSB_StepBack";
		TSB_StepBack.Size = new Size(23, 22);
		TSB_StepBack.Text = "TSB_Reverse";
		TSB_StepBack.ToolTipText = "Step Back";
		TSB_Play.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Play.CheckOnClick = true;
		TSB_Play.DisplayStyle = ToolStripItemDisplayStyle.Image;
		TSB_Play.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Play.Image = componentResourceManager.GetObject("TSB_Play.Image");
		TSB_Play.ImageTransparentColor = Color.Magenta;
		TSB_Play.Name = "TSB_Play";
		TSB_Play.Size = new Size(23, 22);
		TSB_Play.Text = "继续/暂停";
		TSB_Play.ToolTipText = "Pause";
		TSB_StepForward.BackColor = Color.FromArgb(60, 63, 65);
		TSB_StepForward.DisplayStyle = ToolStripItemDisplayStyle.Image;
		TSB_StepForward.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_StepForward.Image = componentResourceManager.GetObject("TSB_StepForward.Image");
		TSB_StepForward.ImageTransparentColor = Color.Magenta;
		TSB_StepForward.Name = "TSB_StepForward";
		TSB_StepForward.Size = new Size(23, 22);
		TSB_StepForward.Text = "TSB_Play";
		TSB_StepForward.ToolTipText = "Step Forward";
		TSB_GoToEnd.BackColor = Color.FromArgb(60, 63, 65);
		TSB_GoToEnd.DisplayStyle = ToolStripItemDisplayStyle.Image;
		TSB_GoToEnd.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_GoToEnd.Image = componentResourceManager.GetObject("TSB_GoToEnd.Image");
		TSB_GoToEnd.ImageTransparentColor = Color.Magenta;
		TSB_GoToEnd.Name = "TSB_GoToEnd";
		TSB_GoToEnd.Size = new Size(23, 22);
		TSB_GoToEnd.Text = "TSB_GoToEnd";
		TSB_GoToEnd.ToolTipText = "Jump to end of recording";
		OpenFileDialog1.FileName = "OpenFileDialog1";
		CustomizeInterruptibleProccesor().Interval = 500;
		MoveInterruptibleProccesor().Interval = 50;
		DarkToolStrip1.AutoSize = false;
		DarkToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		DarkToolStrip1.Dock = DockStyle.Bottom;
		DarkToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		DarkToolStrip1.Items.AddRange(new ToolStripItem[2] { TSL1, TSSL_BadFrame });
		DarkToolStrip1.Location = new Point(0, 57);
		DarkToolStrip1.Name = "DarkToolStrip1";
		DarkToolStrip1.Padding = new Padding(5, 0, 1, 0);
		DarkToolStrip1.Size = new Size(464, 28);
		DarkToolStrip1.TabIndex = 2;
		DarkToolStrip1.Text = "DarkToolStrip1";
		TSL1.BackColor = Color.FromArgb(60, 63, 65);
		TSL1.ForeColor = Color.FromArgb(220, 220, 220);
		TSL1.Name = "TSL1";
		TSL1.Size = new Size(32, 25);
		TSL1.Text = "TSL1";
		TSSL_BadFrame.BackColor = Color.FromArgb(60, 63, 65);
		TSSL_BadFrame.ForeColor = Color.FromArgb(220, 220, 220);
		TSSL_BadFrame.Image = componentResourceManager.GetObject("TSSL_BadFrame.Image");
		TSSL_BadFrame.Name = "TSSL_BadFrame";
		TSSL_BadFrame.Size = new Size(106, 25);
		TSSL_BadFrame.Text = "TSSL_BadFrame";
		TSSL_BadFrame.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(464, 85);
		base.Controls.Add(DarkToolStrip1);
		base.Controls.Add(ToolStrip1);
		base.Controls.Add(TB_Snapshots);
		DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "RecorderForm";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "回放查看器";
		base.TopMost = true;
		((ISupportInitialize)TB_Snapshots).EndInit();
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		DarkToolStrip1.ResumeLayout(performLayout: false);
		DarkToolStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	private int GetCurrentSnapStep()
	{
		return _ReponseUtils;
	}

	[SpecialName]
	private void GoToSnapStep(int int_0)
	{
		_ReponseUtils = int_0;
		_DescriptorUtils = Client.CurrentScenario.GetCurrentSide();
		while (ViewInterruptibleProccesor().IsBusy)
		{
			Application.DoEvents();
		}
		ViewInterruptibleProccesor().RunWorkerAsync();
		_TaskUtils = 0.0;
		TSL1.Visible = true;
	}

	private void FindInterruptibleStatus(object sender, EventArgs e)
	{
		OpenFileDialog1.InitialDirectory = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Recordings" + Conversions.ToString(Path.DirectorySeparatorChar);
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			string fileName = OpenFileDialog1.FileName;
			FillInterruptibleStatus(fileName);
		}
	}

	private void SetInterruptibleStatus(object sender, EventArgs e)
	{
		string text = Recorder.FilenameOfMostRecentTape();
		if (string.IsNullOrEmpty(text))
		{
			DarkMessageBox.ShowError("找不到VCR文件。", "没有文件存在！");
		}
		else
		{
			FillInterruptibleStatus(text);
		}
	}

	private void FillInterruptibleStatus(string string_0)
	{
		_WatcherUtils = Recorder.GetTape(string_0);
		if (_WatcherUtils.SnapshotList.Count == 0)
		{
			DarkMessageBox.ShowError("此回放没有任何已保存的快照！请加载另一个回放记录。", "Error");
			_WatcherUtils = null;
			return;
		}
		TB_Snapshots.Maximum = _WatcherUtils.SnapshotList.Count - 1;
		TB_Snapshots.Value = 0;
		_InterpreterUtils = "TapeLoad";
		GoToSnapStep(_WatcherUtils.SnapshotList[0].Item1);
		TSB_GoToEnd.Enabled = true;
		TSB_GoToStart.Enabled = true;
		TSB_Play.Enabled = true;
		TSB_StepBack.Enabled = true;
		TSB_StepForward.Enabled = true;
		TB_Snapshots.Enabled = true;
	}

	private void CalculateInterruptibleStatus(object sender, EventArgs e)
	{
		if (TSB_Play.Checked)
		{
			TSB_Play.Checked = true;
			TSB_Play.Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\Pause.gif");
			CustomizeInterruptibleProccesor().Start();
			return;
		}
		if (ViewInterruptibleProccesor().IsBusy)
		{
			ViewInterruptibleProccesor().CancelAsync();
		}
		TSB_Play.Checked = false;
		TSB_Play.Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\Run.gif");
		CustomizeInterruptibleProccesor().Stop();
	}

	private void PopInterruptibleStatus(object sender, EventArgs e)
	{
		if (ViewInterruptibleProccesor().IsBusy)
		{
			ViewInterruptibleProccesor().CancelAsync();
		}
		_InterpreterUtils = "TapeStep";
		GoToSnapStep(_WatcherUtils.SnapshotList[0].Item1);
	}

	private void InstantiateInterruptibleStatus(object sender, EventArgs e)
	{
		if (ViewInterruptibleProccesor().IsBusy)
		{
			ViewInterruptibleProccesor().CancelAsync();
		}
		_InterpreterUtils = "TapeStep";
		GoToSnapStep(_WatcherUtils.SnapshotList[_WatcherUtils.SnapshotList.Count - 1].Item1);
	}

	private void CreateInterruptibleStatus(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			TSB_Play.Checked = false;
			Text = "想定时间：" + _WatcherUtils.SnapshotList[TB_Snapshots.Value].Item2.ToShortDateString() + " " + _WatcherUtils.SnapshotList[TB_Snapshots.Value].Item2.ToShortTimeString() + " GMT - 释放鼠标按钮来加载！";
		}
	}

	private void CompareInterruptibleStatus(object sender, EventArgs e)
	{
		UpdateInterruptibleStatus();
	}

	private void ReadInterruptibleStatus(object sender, EventArgs e)
	{
		DisableInterruptibleStatus();
	}

	private void DisableInterruptibleStatus()
	{
		if (TB_Snapshots.Value != TB_Snapshots.Maximum - 1)
		{
			if (ViewInterruptibleProccesor().IsBusy)
			{
				ViewInterruptibleProccesor().CancelAsync();
			}
			TB_Snapshots.Value = Math.Min(TB_Snapshots.Maximum, TB_Snapshots.Value + 1);
			_InterpreterUtils = "TapeStep";
			GoToSnapStep(_WatcherUtils.SnapshotList[TB_Snapshots.Value].Item1);
		}
	}

	private void UpdateInterruptibleStatus()
	{
		if (TB_Snapshots.Value != 0)
		{
			if (ViewInterruptibleProccesor().IsBusy)
			{
				ViewInterruptibleProccesor().CancelAsync();
			}
			TB_Snapshots.Value = Math.Max(TB_Snapshots.Minimum, TB_Snapshots.Value - 1);
			_InterpreterUtils = "TapeStep";
			GoToSnapStep(_WatcherUtils.SnapshotList[TB_Snapshots.Value].Item1);
		}
	}

	private void InsertInterruptibleStatus(object sender, MouseEventArgs e)
	{
		Text = "回放查看器";
		GoToSnapStep(_WatcherUtils.SnapshotList[TB_Snapshots.Value].Item1);
	}

	private void PrepareInterruptibleStatus(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ValidateInterruptibleProccesor(new BackgroundWorker());
		ViewInterruptibleProccesor().WorkerSupportsCancellation = true;
		MoveInterruptibleProccesor().Start();
		TSB_GoToEnd.Enabled = false;
		TSB_GoToStart.Enabled = false;
		TSB_Play.Enabled = false;
		TSB_StepBack.Enabled = false;
		TSB_StepForward.Enabled = false;
		TB_Snapshots.Enabled = false;
	}

	private void ReflectInterruptibleStatus(object sender, EventArgs e)
	{
		if (!Client._ProductClass && TB_Snapshots.Value != TB_Snapshots.Maximum)
		{
			TB_Snapshots.Value++;
			_InterpreterUtils = "TapeStep";
			GoToSnapStep(_WatcherUtils.SnapshotList[TB_Snapshots.Value].Item1);
		}
	}

	private void VisitInterruptibleStatus(object sender, DoWorkEventArgs e)
	{
		Client._ProductClass = true;
		try
		{
			m_FilterUtils = _WatcherUtils.GetSnapshot(GetCurrentSnapStep(), delegate(double double_0)
			{
				_TaskUtils = double_0;
			});
			_TestsUtils = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_TestsUtils = true;
			ProjectData.ClearProjectError();
		}
	}

	private void RestartInterruptibleStatus()
	{
		if (TSB_Play.Checked | TSB_StepForward.Checked)
		{
			DisableInterruptibleStatus();
		}
		if (TSB_StepBack.Checked)
		{
			UpdateInterruptibleStatus();
		}
	}

	private void TestInterruptibleStatus(object sender, RunWorkerCompletedEventArgs e)
	{
		if (_TestsUtils)
		{
			TSSL_BadFrame.Visible = true;
			RestartInterruptibleStatus();
			return;
		}
		TSSL_BadFrame.Visible = false;
		if (!Information.IsNothing(_DescriptorUtils))
		{
			Side[] sides_ReadOnly = m_FilterUtils.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (Operators.CompareString(side.ObjectID, _DescriptorUtils.ObjectID, TextCompare: true) == 0)
				{
					m_FilterUtils.SetCurrentSide(side);
					break;
				}
			}
		}
		TSL1.Visible = false;
		Client.SetCurrentScenario(m_FilterUtils, bool_0: true);
		Client._ProductClass = false;
		if (Operators.CompareString(_InterpreterUtils, "TapeLoad", TextCompare: true) == 0 && !Information.IsNothing(_DescriptorUtils) && Operators.CompareString(_DescriptorUtils.ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, Client.CurrentScenario.GetCurrentSide().MapCenter);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = (int)Math.Round(Client.CurrentScenario.GetCurrentSide().CameraAlt);
		}
	}

	private void StopInterruptibleStatus(object sender, EventArgs e)
	{
		TSL1.Text = "加载帧..." + Conversions.ToString((int)Math.Round(_TaskUtils * 100.0)) + "%";
	}

	private void CancelInterruptibleStatus(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void VerifyInterruptibleStatus(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ListInterruptibleStatus(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		Hide();
	}

	[CompilerGenerated]
	private void ResolveInterruptibleStatus(double double_0)
	{
		_TaskUtils = double_0;
	}
}
