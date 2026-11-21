using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScenarioMerge : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class ParameterConfigManager
	{
		public string scenario1FileName;

		public string scenario2FileName;

		public string mergeResultFileName;

		public DBOps.DatabaseMatchToleranceLevel dBMatchToleranceLevel;

		public ScenarioMerge _003C_003E4__this;

		internal void SearchInterruptibleMethod()
		{
			Scenario.MergeScenarios(scenario1FileName, scenario2FileName, mergeResultFileName, dBMatchToleranceLevel, _003C_003E4__this.CB_AllowSameSide.Checked, ref _003C_003E4__this.interceptorPredicate);
			_003C_003E4__this.Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				_003C_003E4__this.LogoutInterruptiblePublisher().Stop();
				_003C_003E4__this.AssetInterruptibleResolver();
			});
		}

		internal void EnableInterruptibleMethod()
		{
			_003C_003E4__this.LogoutInterruptiblePublisher().Stop();
			_003C_003E4__this.AssetInterruptibleResolver();
		}
	}

	private IContainer _FieldPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_QueuePredicate;

	[AccessedThroughProperty("Button_Scenario1File")]
	[CompilerGenerated]
	private DarkUIButton m_ParamPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Scenario2File")]
	private DarkUIButton m_MethodPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_MergeResult")]
	private DarkUITextBox systemPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MergeResultFile")]
	private DarkUIButton candidatePredicate;

	[AccessedThroughProperty("Button_Merge")]
	[CompilerGenerated]
	private DarkUIButton m_BasePredicate;

	[AccessedThroughProperty("Label_DBMatch")]
	[CompilerGenerated]
	private DarkLabel broadcasterPredicate;

	[AccessedThroughProperty("Combo_DBMatch")]
	[CompilerGenerated]
	private DarkUIComboBox identifierPredicate;

	[AccessedThroughProperty("SaveFileDialog1")]
	[CompilerGenerated]
	private SaveFileDialog m_PrinterPredicate;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer _ParserPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox m_AlgoPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AllowSameSide")]
	private DarkCheckBox databasePredicate;

	private string interceptorPredicate;

	private string messagePredicate;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_QueuePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_QueuePredicate = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_Scenario1")]
	internal DarkUITextBox TextBox_Scenario1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_Scenario1File
	{
		[CompilerGenerated]
		get
		{
			return m_ParamPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleResolver;
			DarkUIButton paramPredicate = m_ParamPredicate;
			if (paramPredicate != null)
			{
				paramPredicate.Click -= value2;
			}
			m_ParamPredicate = value;
			paramPredicate = m_ParamPredicate;
			if (paramPredicate != null)
			{
				paramPredicate.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_Scenario2")]
	internal DarkUITextBox TextBox_Scenario2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_Scenario2File
	{
		[CompilerGenerated]
		get
		{
			return m_MethodPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleResolver;
			DarkUIButton methodPredicate = m_MethodPredicate;
			if (methodPredicate != null)
			{
				methodPredicate.Click -= value2;
			}
			m_MethodPredicate = value;
			methodPredicate = m_MethodPredicate;
			if (methodPredicate != null)
			{
				methodPredicate.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox_MergeResult
	{
		[CompilerGenerated]
		get
		{
			return systemPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			systemPredicate = value;
		}
	}

	internal DarkUIButton Button_MergeResultFile
	{
		[CompilerGenerated]
		get
		{
			return candidatePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleResolver;
			DarkUIButton darkUIButton = candidatePredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			candidatePredicate = value;
			darkUIButton = candidatePredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_Merge
	{
		[CompilerGenerated]
		get
		{
			return m_BasePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleResolver;
			DarkUIButton basePredicate = m_BasePredicate;
			if (basePredicate != null)
			{
				basePredicate.Click -= value2;
			}
			m_BasePredicate = value;
			basePredicate = m_BasePredicate;
			if (basePredicate != null)
			{
				basePredicate.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("OpenFileDialog1")]
	internal OpenFileDialog OpenFileDialog1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_DBMatch
	{
		[CompilerGenerated]
		get
		{
			return broadcasterPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			broadcasterPredicate = value;
		}
	}

	internal DarkUIComboBox Combo_DBMatch
	{
		[CompilerGenerated]
		get
		{
			return identifierPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			identifierPredicate = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AlgoPredicate = value;
		}
	}

	internal DarkCheckBox CB_AllowSameSide
	{
		[CompilerGenerated]
		get
		{
			return databasePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databasePredicate = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog PatchInterruptiblePublisher()
	{
		return m_PrinterPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void SelectInterruptiblePublisher(SaveFileDialog saveFileDialog_0)
	{
		m_PrinterPredicate = saveFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer LogoutInterruptiblePublisher()
	{
		return _ParserPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ViewInterruptiblePublisher(Timer timer_0)
	{
		EventHandler value = StartInterruptibleResolver;
		Timer parserPredicate = _ParserPredicate;
		if (parserPredicate != null)
		{
			parserPredicate.Tick -= value;
		}
		_ParserPredicate = timer_0;
		parserPredicate = _ParserPredicate;
		if (parserPredicate != null)
		{
			parserPredicate.Tick += value;
		}
	}

	public ScenarioMerge()
	{
		base.Shown += StopInterruptibleResolver;
		base.KeyDown += PostInterruptibleResolver;
		base.FormClosing += RunInterruptibleResolver;
		TestInterruptibleResolver();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _FieldPredicate != null)
			{
				_FieldPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void TestInterruptibleResolver()
	{
		_FieldPredicate = new Container();
		Label1 = new DarkLabel();
		TextBox_Scenario1 = new DarkUITextBox();
		Button_Scenario1File = new DarkUIButton();
		Label2 = new DarkLabel();
		TextBox_Scenario2 = new DarkUITextBox();
		Button_Scenario2File = new DarkUIButton();
		Label4 = new DarkLabel();
		TextBox_MergeResult = new DarkUITextBox();
		Button_MergeResultFile = new DarkUIButton();
		Button_Merge = new DarkUIButton();
		OpenFileDialog1 = new OpenFileDialog();
		Label_DBMatch = new DarkLabel();
		Combo_DBMatch = new DarkUIComboBox();
		SelectInterruptiblePublisher(new SaveFileDialog());
		ViewInterruptiblePublisher(new Timer(_FieldPredicate));
		TextBox1 = new DarkUITextBox();
		CB_AllowSameSide = new DarkCheckBox();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(0, 16);
		Label1.Name = "Label1";
		Label1.Size = new Size(71, 15);
		Label1.TabIndex = 8;
		Label1.Text = "想定1：";
		TextBox_Scenario1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox_Scenario1.AutoCompleteCustomSource = null;
		TextBox_Scenario1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_Scenario1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_Scenario1.BackColor = Color.FromArgb(69, 73, 74);
		TextBox_Scenario1.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox_Scenario1.Image = null;
		TextBox_Scenario1.Lines = null;
		TextBox_Scenario1.Location = new Point(120, 12);
		TextBox_Scenario1.MaxLength = 32767;
		TextBox_Scenario1.Multiline = false;
		TextBox_Scenario1.Name = "TextBox_Scenario1";
		TextBox_Scenario1.ReadOnly = false;
		TextBox_Scenario1.ScrollBars = ScrollBars.None;
		TextBox_Scenario1.SelectionStart = 0;
		TextBox_Scenario1.Size = new Size(413, 23);
		TextBox_Scenario1.TabIndex = 9;
		TextBox_Scenario1.TextAlign = HorizontalAlignment.Left;
		TextBox_Scenario1.UseSystemPasswordChar = false;
		TextBox_Scenario1.WatermarkText = "";
		Button_Scenario1File.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Scenario1File.BackColor = Color.Transparent;
		Button_Scenario1File.DialogResult = DialogResult.None;
		Button_Scenario1File.ForeColor = SystemColors.Control;
		Button_Scenario1File.Location = new Point(539, 12);
		Button_Scenario1File.Name = "Button_Scenario1File";
		Button_Scenario1File.RoundRadius = 0;
		Button_Scenario1File.Size = new Size(73, 23);
		Button_Scenario1File.TabIndex = 10;
		Button_Scenario1File.Text = "选择...";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(0, 42);
		Label2.Name = "Label2";
		Label2.Size = new Size(71, 15);
		Label2.TabIndex = 11;
		Label2.Text = "想定2：";
		TextBox_Scenario2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox_Scenario2.AutoCompleteCustomSource = null;
		TextBox_Scenario2.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_Scenario2.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_Scenario2.BackColor = Color.FromArgb(69, 73, 74);
		TextBox_Scenario2.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox_Scenario2.Image = null;
		TextBox_Scenario2.Lines = null;
		TextBox_Scenario2.Location = new Point(120, 39);
		TextBox_Scenario2.MaxLength = 32767;
		TextBox_Scenario2.Multiline = false;
		TextBox_Scenario2.Name = "TextBox_Scenario2";
		TextBox_Scenario2.ReadOnly = false;
		TextBox_Scenario2.ScrollBars = ScrollBars.None;
		TextBox_Scenario2.SelectionStart = 0;
		TextBox_Scenario2.Size = new Size(413, 23);
		TextBox_Scenario2.TabIndex = 12;
		TextBox_Scenario2.TextAlign = HorizontalAlignment.Left;
		TextBox_Scenario2.UseSystemPasswordChar = false;
		TextBox_Scenario2.WatermarkText = "";
		Button_Scenario2File.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Scenario2File.BackColor = Color.Transparent;
		Button_Scenario2File.DialogResult = DialogResult.None;
		Button_Scenario2File.ForeColor = SystemColors.Control;
		Button_Scenario2File.Location = new Point(539, 39);
		Button_Scenario2File.Name = "Button_Scenario2File";
		Button_Scenario2File.RoundRadius = 0;
		Button_Scenario2File.Size = new Size(73, 23);
		Button_Scenario2File.TabIndex = 13;
		Button_Scenario2File.Text = "选择...";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(0, 68);
		Label4.Name = "Label4";
		Label4.Size = new Size(98, 15);
		Label4.TabIndex = 14;
		Label4.Text = "合并想定：";
		TextBox_MergeResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox_MergeResult.AutoCompleteCustomSource = null;
		TextBox_MergeResult.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_MergeResult.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_MergeResult.BackColor = Color.FromArgb(69, 73, 74);
		TextBox_MergeResult.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox_MergeResult.Image = null;
		TextBox_MergeResult.Lines = null;
		TextBox_MergeResult.Location = new Point(120, 65);
		TextBox_MergeResult.MaxLength = 32767;
		TextBox_MergeResult.Multiline = false;
		TextBox_MergeResult.Name = "TextBox_MergeResult";
		TextBox_MergeResult.ReadOnly = false;
		TextBox_MergeResult.ScrollBars = ScrollBars.None;
		TextBox_MergeResult.SelectionStart = 0;
		TextBox_MergeResult.Size = new Size(413, 23);
		TextBox_MergeResult.TabIndex = 15;
		TextBox_MergeResult.TextAlign = HorizontalAlignment.Left;
		TextBox_MergeResult.UseSystemPasswordChar = false;
		TextBox_MergeResult.WatermarkText = "";
		Button_MergeResultFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_MergeResultFile.BackColor = Color.Transparent;
		Button_MergeResultFile.DialogResult = DialogResult.None;
		Button_MergeResultFile.ForeColor = SystemColors.Control;
		Button_MergeResultFile.Location = new Point(539, 65);
		Button_MergeResultFile.Name = "Button_MergeResultFile";
		Button_MergeResultFile.RoundRadius = 0;
		Button_MergeResultFile.Size = new Size(73, 23);
		Button_MergeResultFile.TabIndex = 16;
		Button_MergeResultFile.Text = "选择...";
		Button_Merge.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Merge.BackColor = Color.Transparent;
		Button_Merge.DialogResult = DialogResult.None;
		Button_Merge.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button_Merge.ForeColor = SystemColors.Control;
		Button_Merge.Location = new Point(266, 145);
		Button_Merge.MaximumSize = new Size(100, 34);
		Button_Merge.Name = "Button_Merge";
		Button_Merge.RoundRadius = 0;
		Button_Merge.Size = new Size(100, 34);
		Button_Merge.TabIndex = 17;
		Button_Merge.Text = "合并";
		OpenFileDialog1.FileName = "OpenFileDialog1";
		Label_DBMatch.AutoSize = true;
		Label_DBMatch.ForeColor = Color.FromArgb(220, 220, 220);
		Label_DBMatch.Location = new Point(0, 94);
		Label_DBMatch.Name = "Label_DBMatch";
		Label_DBMatch.Size = new Size(114, 15);
		Label_DBMatch.TabIndex = 18;
		Label_DBMatch.Text = "数据库差异匹配：";
		Combo_DBMatch.BackColor = Color.Transparent;
		Combo_DBMatch.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_DBMatch.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_DBMatch.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_DBMatch.FormattingEnabled = true;
		Combo_DBMatch.Items.AddRange(new object[3] { "各想定必须使用完全一致的数据库版本（安全）", "各想定必须使用一致的数据库（存在风险）", "不检查数据库匹配度（高风险）" });
		Combo_DBMatch.Location = new Point(120, 91);
		Combo_DBMatch.Name = "Combo_DBMatch";
		Combo_DBMatch.Size = new Size(413, 21);
		Combo_DBMatch.TabIndex = 19;
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.FromArgb(69, 73, 74);
		TextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(1, 185);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.Vertical;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(611, 196);
		TextBox1.TabIndex = 20;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		CB_AllowSameSide.BackColor = Color.Transparent;
		CB_AllowSameSide.Cursor = Cursors.Hand;
		CB_AllowSameSide.ForeColor = Color.FromArgb(209, 209, 209);
		CB_AllowSameSide.Location = new Point(120, 118);
		CB_AllowSameSide.Name = "CB_AllowSameSide";
		CB_AllowSameSide.Size = new Size(205, 18);
		CB_AllowSameSide.TabIndex = 21;
		CB_AllowSameSide.Text = "允许相同分方的合并克隆";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.ClientSize = new Size(613, 379);
		base.Controls.Add(CB_AllowSameSide);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Combo_DBMatch);
		base.Controls.Add(Label_DBMatch);
		base.Controls.Add(Button_Merge);
		base.Controls.Add(Label4);
		base.Controls.Add(TextBox_MergeResult);
		base.Controls.Add(Button_MergeResultFile);
		base.Controls.Add(Label1);
		base.Controls.Add(TextBox_Scenario1);
		base.Controls.Add(Button_Scenario1File);
		base.Controls.Add(Label2);
		base.Controls.Add(TextBox_Scenario2);
		base.Controls.Add(Button_Scenario2File);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ScenarioMerge";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "合并想定";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void StopInterruptibleResolver(object sender, EventArgs e)
	{
		Combo_DBMatch.SelectedIndex = 0;
		Label_DBMatch.Visible = false;
		Combo_DBMatch.Visible = false;
		CB_AllowSameSide.Visible = false;
	}

	private void CancelInterruptibleResolver(object sender, EventArgs e)
	{
		TextBox1.Clear();
		messagePredicate = string.Empty;
		interceptorPredicate = string.Empty;
		string scenario1FileName = TextBox_Scenario1.Text;
		string scenario2FileName = TextBox_Scenario2.Text;
		string mergeResultFileName = TextBox_MergeResult.Text;
		DBOps.DatabaseMatchToleranceLevel dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.ExactVersion;
		switch (Combo_DBMatch.SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.ExactVersion;
			break;
		case 1:
			dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.SameFamily;
			break;
		case 2:
			dBMatchToleranceLevel = DBOps.DatabaseMatchToleranceLevel.CompletelyNoMatch;
			break;
		}
		LogoutInterruptiblePublisher().Start();
		Task.Factory.StartNew(delegate
		{
			Scenario.MergeScenarios(scenario1FileName, scenario2FileName, mergeResultFileName, dBMatchToleranceLevel, CB_AllowSameSide.Checked, ref interceptorPredicate);
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				LogoutInterruptiblePublisher().Stop();
				AssetInterruptibleResolver();
			});
		});
	}

	private void VerifyInterruptibleResolver(object sender, EventArgs e)
	{
		OpenFileDialog1.DefaultExt = "*.scen";
		OpenFileDialog1.FileName = "*.scen";
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			TextBox_Scenario1.Text = OpenFileDialog1.FileName;
		}
	}

	private void ListInterruptibleResolver(object sender, EventArgs e)
	{
		OpenFileDialog1.DefaultExt = "*.scen";
		OpenFileDialog1.FileName = "*.scen";
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			TextBox_Scenario2.Text = OpenFileDialog1.FileName;
		}
	}

	private void ResolveInterruptibleResolver(object sender, EventArgs e)
	{
		PatchInterruptiblePublisher().DefaultExt = "*.scen";
		PatchInterruptiblePublisher().Filter = "Command Scenario File|*.scen";
		if (PatchInterruptiblePublisher().ShowDialog() == DialogResult.OK)
		{
			TextBox_MergeResult.Text = PatchInterruptiblePublisher().FileName;
		}
	}

	private void PostInterruptibleResolver(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode != Keys.Space || !base.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RunInterruptibleResolver(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void StartInterruptibleResolver(object sender, EventArgs e)
	{
		AssetInterruptibleResolver();
	}

	private void AssetInterruptibleResolver()
	{
		if (string.CompareOrdinal(interceptorPredicate, messagePredicate) > 0)
		{
			TextBox1.SuspendLayout();
			TextBox1.Clear();
			TextBox1.Text = interceptorPredicate;
			TextBox1.ResumeLayout();
			messagePredicate = interceptorPredicate;
		}
	}
}
