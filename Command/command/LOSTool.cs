using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class LOSTool : DarkSecondaryFormBase
{
	private enum HorizonType : short
	{
		Radar
	}

	[CompilerGenerated]
	private sealed class ConfigurationDispatcherList
	{
		public LOSTool _003C_003E4__this;

		public CancellationToken token;

		internal void MoveInterruptibleRules()
		{
			_003C_003E4__this.MoveGlobal(token);
		}
	}

	private IContainer _ExporterModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel prototypeModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl comparatorModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage m_ItemModel;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_CreatorModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_MaxRange")]
	private DarkUITextBox m_TemplateModel;

	[AccessedThroughProperty("TB_TargetAlt")]
	[CompilerGenerated]
	private DarkUITextBox mappingModel;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton mockModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private System.Windows.Forms.Timer m_TagModel;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_FieldModel;

	[AccessedThroughProperty("CB_HorizonType")]
	[CompilerGenerated]
	private DarkUIComboBox _QueueModel;

	[AccessedThroughProperty("CB_AltitudeSameAsObserver")]
	[CompilerGenerated]
	private DarkCheckBox regModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel paramModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ShadeColor")]
	private DarkUIButton pageModel;

	[AccessedThroughProperty("ColorDialog_Shade")]
	[CompilerGenerated]
	private ColorDialog m_RulesModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_HowManyThreads")]
	private TrackBar m_ServiceModel;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_SystemModel;

	private double m_CandidateModel;

	private double baseModel;

	private float policyModel;

	private bool broadcasterModel;

	private ConcurrentQueue<Terrain.TerrainGridCell> _IdentifierModel;

	private HorizonType _PrinterModel;

	private int _ParserModel;

	private float _AlgoModel;

	private Task m_DatabaseModel;

	private CancellationTokenSource m_InterceptorModel;

	private Keys[] messageModel;

	private int productModel;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return prototypeModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			prototypeModel = value;
		}
	}

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return comparatorModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			comparatorModel = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_ItemModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ItemModel = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorModel = value;
		}
	}

	internal DarkUITextBox TB_MaxRange
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchGlobal;
			DarkUITextBox.TextChangedEventHandler value3 = WriteGlobal;
			DarkUITextBox templateModel = m_TemplateModel;
			if (templateModel != null)
			{
				templateModel.Leave -= value2;
				templateModel.TextChanged -= value3;
			}
			m_TemplateModel = value;
			templateModel = m_TemplateModel;
			if (templateModel != null)
			{
				templateModel.Leave += value2;
				templateModel.TextChanged += value3;
			}
		}
	}

	internal DarkUITextBox TB_TargetAlt
	{
		[CompilerGenerated]
		get
		{
			return mappingModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectGlobal;
			DarkUITextBox.TextChangedEventHandler value3 = GetGlobal;
			DarkUITextBox darkUITextBox = mappingModel;
			if (darkUITextBox != null)
			{
				darkUITextBox.Leave -= value2;
				darkUITextBox.TextChanged -= value3;
			}
			mappingModel = value;
			darkUITextBox = mappingModel;
			if (darkUITextBox != null)
			{
				darkUITextBox.Leave += value2;
				darkUITextBox.TextChanged += value3;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return mockModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectGlobal;
			DarkUIButton darkUIButton = mockModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			mockModel = value;
			darkUIButton = mockModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_FieldModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FieldModel = value;
		}
	}

	internal DarkUIComboBox CB_HorizonType
	{
		[CompilerGenerated]
		get
		{
			return _QueueModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallGlobal;
			DarkUIComboBox queueModel = _QueueModel;
			if (queueModel != null)
			{
				queueModel.SelectionChangeCommitted -= value2;
			}
			_QueueModel = value;
			queueModel = _QueueModel;
			if (queueModel != null)
			{
				queueModel.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkCheckBox CB_AltitudeSameAsObserver
	{
		[CompilerGenerated]
		get
		{
			return regModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regModel = value;
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return paramModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramModel = value;
		}
	}

	internal DarkUIButton Button_ShadeColor
	{
		[CompilerGenerated]
		get
		{
			return pageModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewGlobal;
			DarkUIButton darkUIButton = pageModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			pageModel = value;
			darkUIButton = pageModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_SelectedUnitName")]
	internal DarkLabel Label_SelectedUnitName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TrackBar_HowManyThreads
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ServiceModel = value;
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_SystemModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemModel = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.Timer CalculateGlobal()
	{
		return m_TagModel;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void PopGlobal(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = AddGlobal;
		System.Windows.Forms.Timer tagModel = m_TagModel;
		if (tagModel != null)
		{
			tagModel.Tick -= value;
		}
		m_TagModel = timer_0;
		tagModel = m_TagModel;
		if (tagModel != null)
		{
			tagModel.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal ColorDialog TestGlobal()
	{
		return m_RulesModel;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void StopGlobal(ColorDialog colorDialog_0)
	{
		m_RulesModel = colorDialog_0;
	}

	public LOSTool()
	{
		base.Shown += DeleteGlobal;
		base.Closing += LogoutGlobal;
		base.Load += ValidateGlobal;
		base.Resize += NewGlobal;
		broadcasterModel = false;
		m_DatabaseModel = null;
		m_InterceptorModel = null;
		messageModel = new Keys[1] { Keys.Escape };
		productModel = 0;
		CloneGlobal();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ExporterModel != null)
			{
				_ExporterModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CloneGlobal()
	{
		_ExporterModel = new Container();
		Label1 = new DarkLabel();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		Label_SelectedUnitName = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		TB_MaxRange = new DarkUITextBox();
		TB_TargetAlt = new DarkUITextBox();
		CB_AltitudeSameAsObserver = new DarkCheckBox();
		Button1 = new DarkUIButton();
		PopGlobal(new System.Windows.Forms.Timer(_ExporterModel));
		Label2 = new DarkLabel();
		CB_HorizonType = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Button_ShadeColor = new DarkUIButton();
		StopGlobal(new ColorDialog());
		TrackBar_HowManyThreads = new TrackBar();
		DarkLabel1 = new DarkLabel();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		((ISupportInitialize)TrackBar_HowManyThreads).BeginInit();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(4, 11);
		Label1.Name = "Label1";
		Label1.Size = new Size(103, 15);
		Label1.TabIndex = 0;
		Label1.Text = "从此视角：";
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(3, 27);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(405, 52);
		TabControl1.TabIndex = 1;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(Label_SelectedUnitName);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(397, 24);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "选定单元";
		Label_SelectedUnitName.AutoSize = true;
		Label_SelectedUnitName.ForeColor = Color.FromArgb(220, 220, 220);
		Label_SelectedUnitName.Location = new Point(6, 3);
		Label_SelectedUnitName.Name = "Label_SelectedUnitName";
		Label_SelectedUnitName.Size = new Size(76, 15);
		Label_SelectedUnitName.TabIndex = 0;
		Label_SelectedUnitName.Text = "选定单元";
		Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(4, 86);
		Label3.Name = "Label3";
		Label3.Size = new Size(112, 15);
		Label3.TabIndex = 2;
		Label3.Text = "最大距离（海里）：";
		Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(4, 108);
		Label4.Name = "Label4";
		Label4.Size = new Size(107, 15);
		Label4.TabIndex = 3;
		Label4.Text = "目标高度（米 真高）：";
		TB_MaxRange.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_MaxRange.AutoCompleteCustomSource = null;
		TB_MaxRange.AutoCompleteMode = AutoCompleteMode.None;
		TB_MaxRange.AutoCompleteSource = AutoCompleteSource.None;
		TB_MaxRange.BackColor = Color.Transparent;
		TB_MaxRange.ForeColor = Color.FromArgb(189, 189, 189);
		TB_MaxRange.Image = null;
		TB_MaxRange.Lines = null;
		TB_MaxRange.Location = new Point(111, 85);
		TB_MaxRange.MaxLength = 32767;
		TB_MaxRange.Multiline = false;
		TB_MaxRange.Name = "TB_MaxRange";
		TB_MaxRange.ReadOnly = false;
		TB_MaxRange.ScrollBars = ScrollBars.None;
		TB_MaxRange.SelectionStart = 0;
		TB_MaxRange.Size = new Size(100, 20);
		TB_MaxRange.TabIndex = 4;
		TB_MaxRange.Text = "100";
		TB_MaxRange.TextAlign = HorizontalAlignment.Left;
		TB_MaxRange.UseSystemPasswordChar = false;
		TB_MaxRange.WatermarkText = "";
		TB_TargetAlt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_TargetAlt.AutoCompleteCustomSource = null;
		TB_TargetAlt.AutoCompleteMode = AutoCompleteMode.None;
		TB_TargetAlt.AutoCompleteSource = AutoCompleteSource.None;
		TB_TargetAlt.BackColor = Color.Transparent;
		TB_TargetAlt.ForeColor = Color.FromArgb(189, 189, 189);
		TB_TargetAlt.Image = null;
		TB_TargetAlt.Lines = null;
		TB_TargetAlt.Location = new Point(111, 108);
		TB_TargetAlt.MaxLength = 32767;
		TB_TargetAlt.Multiline = false;
		TB_TargetAlt.Name = "TB_TargetAlt";
		TB_TargetAlt.ReadOnly = false;
		TB_TargetAlt.ScrollBars = ScrollBars.None;
		TB_TargetAlt.SelectionStart = 0;
		TB_TargetAlt.Size = new Size(58, 20);
		TB_TargetAlt.TabIndex = 5;
		TB_TargetAlt.Text = "10";
		TB_TargetAlt.TextAlign = HorizontalAlignment.Left;
		TB_TargetAlt.UseSystemPasswordChar = false;
		TB_TargetAlt.WatermarkText = "";
		CB_AltitudeSameAsObserver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_AltitudeSameAsObserver.AutoSize = true;
		CB_AltitudeSameAsObserver.Location = new Point(112, 127);
		CB_AltitudeSameAsObserver.Name = "CB_AltitudeSameAsObserver";
		CB_AltitudeSameAsObserver.Size = new Size(117, 19);
		CB_AltitudeSameAsObserver.TabIndex = 6;
		CB_AltitudeSameAsObserver.Text = "与观察者相同";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(329, 174);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 7;
		Button1.Text = "刷新";
		CalculateGlobal().Interval = 50;
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(222, 87);
		Label2.Name = "Label2";
		Label2.Size = new Size(52, 15);
		Label2.TabIndex = 8;
		Label2.Text = "水平：";
		CB_HorizonType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_HorizonType.BackColor = Color.Transparent;
		CB_HorizonType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_HorizonType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_HorizonType.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_HorizonType.FormattingEnabled = true;
		CB_HorizonType.Items.AddRange(new object[3] { "雷达", "视线/EO/红外", "ESM" });
		CB_HorizonType.Location = new Point(278, 86);
		CB_HorizonType.Name = "CB_HorizonType";
		CB_HorizonType.Size = new Size(127, 21);
		CB_HorizonType.TabIndex = 9;
		Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(4, 179);
		Label5.Name = "Label5";
		Label5.Size = new Size(74, 15);
		Label5.TabIndex = 10;
		Label5.Text = "阴影颜色：";
		Button_ShadeColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ShadeColor.BackColor = Color.Transparent;
		Button_ShadeColor.DialogResult = DialogResult.None;
		Button_ShadeColor.ForeColor = SystemColors.Control;
		Button_ShadeColor.Location = new Point(124, 174);
		Button_ShadeColor.Name = "Button_ShadeColor";
		Button_ShadeColor.RoundRadius = 0;
		Button_ShadeColor.Size = new Size(75, 23);
		Button_ShadeColor.TabIndex = 11;
		Button_ShadeColor.Text = "修改";
		TrackBar_HowManyThreads.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		TrackBar_HowManyThreads.Location = new Point(320, 113);
		TrackBar_HowManyThreads.Name = "TrackBar_HowManyThreads";
		TrackBar_HowManyThreads.Size = new Size(88, 45);
		TrackBar_HowManyThreads.TabIndex = 12;
		DarkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(250, 119);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(75, 15);
		DarkLabel1.TabIndex = 13;
		DarkLabel1.Text = "线程数量：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(411, 201);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(TrackBar_HowManyThreads);
		base.Controls.Add(Button_ShadeColor);
		base.Controls.Add(Label5);
		base.Controls.Add(CB_HorizonType);
		base.Controls.Add(Label2);
		base.Controls.Add(Button1);
		base.Controls.Add(CB_AltitudeSameAsObserver);
		base.Controls.Add(TB_TargetAlt);
		base.Controls.Add(TB_MaxRange);
		base.Controls.Add(Label4);
		base.Controls.Add(Label3);
		base.Controls.Add(TabControl1);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximumSize = new Size(427, 240);
		MinimumSize = new Size(427, 240);
		base.Name = "LOSTool";
		base.ShowIcon = false;
		Text = "视线LOS工具";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		((ISupportInitialize)TrackBar_HowManyThreads).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = messageModel;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys keys = array[num];
				if (keyData == keys)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		Close();
		return true;
	}

	private void ConnectGlobal(object sender, EventArgs e)
	{
		ComputeGlobal();
	}

	private void MoveGlobal(CancellationToken cancellationToken_0)
	{
		if (Client.SelectedUnit == null || cancellationToken_0.IsCancellationRequested)
		{
			return;
		}
		CancellationToken cancellationToken = cancellationToken_0;
		try
		{
			broadcasterModel = true;
			float num = _AlgoModel;
			Module_Unit.Unit unit = Client.SelectedUnit;
			if (Client.SelectedUnit.DisableWriter())
			{
				Contact contact = (Contact)Client.SelectedUnit;
				if (contact.ActualUnit != null)
				{
					unit = contact.ActualUnit;
				}
			}
			float float_ = 0f;
			float num2 = 0f;
			switch (_PrinterModel)
			{
			case HorizonType.Radar:
				float_ = unit.GetCurrentAltitude() + (float)unit.GetMastHeight_Radar();
				num2 = Horizon.CountClass(float_, _ParserModel);
				break;
			case (HorizonType)1:
				float_ = unit.GetCurrentAltitude() + (float)unit.GetMastHeight_Visual();
				num2 = Horizon.RevertInvocation(float_, _ParserModel);
				break;
			case (HorizonType)2:
				float_ = unit.GetCurrentAltitude() + (float)unit.GetMastHeight_Radar();
				num2 = Horizon.CustomizeClass(float_, _ParserModel);
				break;
			}
			if (num > num2)
			{
				num = num2;
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				_IdentifierModel = Terrain.WriteWatcher(Client.SelectedUnit.GetLatitude(), Client.SelectedUnit.GetLongitude(), float_, _ParserModel, num, Client.CurrentScenario);
			}
			List<Geopoint_Struct[]> list = new List<Geopoint_Struct[]>(_IdentifierModel.Count);
			Terrain.TerrainGridCell result;
			while (_IdentifierModel.TryDequeue(out result) && !cancellationToken.IsCancellationRequested)
			{
				list.Add(new Geopoint_Struct[4] { result.NorthWesternCorner, result.NorthEasternCorner, result.SouthEasternCorner, result.SouthWesternCorner });
			}
			while (!cancellationToken.IsCancellationRequested)
			{
				int count = list.Count;
				list = Math2.ForgotClass(list);
				if (list.Count == count)
				{
					break;
				}
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				Client.LOS_ShadedArea = list;
			}
			broadcasterModel = false;
			if (!cancellationToken.IsCancellationRequested)
			{
				Client.MustRefreshMainForm = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DeleteGlobal(object sender, EventArgs e)
	{
		Button_ShadeColor.BackColor = Client.m_DefinitionRequest;
		CalculateGlobal().Start();
		CB_HorizonType.SelectedIndex = 0;
	}

	private void AddGlobal(object sender, EventArgs e)
	{
		string text = "(No Unit Selected)";
		if (Client.SelectedUnit == null)
		{
			Label_SelectedUnitName.Text = text;
			return;
		}
		text = Client.SelectedUnit.Name;
		if (broadcasterModel)
		{
			text += " (Calculating LOS";
			text += Strings.StrDup(productModel % 4, ".");
			text += Strings.StrDup(3 - productModel % 4, " ");
			text += ")";
			productModel++;
		}
		else
		{
			productModel = 0;
		}
		Label_SelectedUnitName.Text = text;
		if (CB_AltitudeSameAsObserver.Checked)
		{
			TB_TargetAlt.Enabled = false;
			TB_TargetAlt.Text = string.Format("{0:0.0}", Client.SelectedUnit.GetCurrentAltitude(), 1);
		}
		else
		{
			TB_TargetAlt.Enabled = true;
		}
		if (!broadcasterModel && !Information.IsNothing(Client.SelectedUnit))
		{
			bool flag = false;
			if (m_CandidateModel != Client.SelectedUnit.GetLatitude())
			{
				flag = true;
			}
			if (baseModel != Client.SelectedUnit.GetLongitude())
			{
				flag = true;
			}
			if ((int)Math.Round(policyModel) != (int)Math.Round(Client.SelectedUnit.GetCurrentAltitude()))
			{
				flag = true;
			}
			if (Versioned.IsNumeric(TB_MaxRange.Text) && Versioned.IsNumeric(TB_TargetAlt.Text) && (flag & !broadcasterModel))
			{
				ComputeGlobal();
			}
		}
	}

	private void DestroyGlobal()
	{
		if (m_InterceptorModel != null && m_DatabaseModel != null && !m_DatabaseModel.IsCompleted)
		{
			m_InterceptorModel.Cancel();
		}
		Client.LOS_ShadedArea = null;
		broadcasterModel = false;
	}

	private void ComputeGlobal()
	{
		DestroyGlobal();
		if (Client.SelectedUnit == null)
		{
			return;
		}
		m_CandidateModel = Client.SelectedUnit.GetLatitude();
		baseModel = Client.SelectedUnit.GetLongitude();
		policyModel = Client.SelectedUnit.GetCurrentAltitude();
		bool flag = true;
		bool flag2 = true;
		if (Versioned.IsNumeric(TB_MaxRange.Text))
		{
			float num = Conversions.ToSingle(TB_MaxRange.Text);
			if (num > 0f)
			{
				_AlgoModel = num;
				flag = false;
			}
		}
		if (Versioned.IsNumeric(TB_TargetAlt.Text))
		{
			int num2 = Conversions.ToInteger(TB_TargetAlt.Text);
			if (num2 >= 0)
			{
				_ParserModel = (int)Math.Round(SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (0.3048f * (float)num2) : ((float)num2));
				Label4.Text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? "Target Alt (ft AGL):" : "目标高度（米 真高）：");
				flag2 = false;
			}
		}
		if (flag)
		{
			TB_MaxRange.Text = _AlgoModel.ToString();
		}
		if (flag2)
		{
			TB_TargetAlt.Text = _ParserModel.ToString();
		}
		m_InterceptorModel = new CancellationTokenSource();
		CancellationToken token = m_InterceptorModel.Token;
		m_DatabaseModel = Task.Factory.StartNew(delegate
		{
			MoveGlobal(token);
		}, token);
	}

	private void PatchGlobal(object sender, EventArgs e)
	{
		if (!Versioned.IsNumeric(TB_MaxRange.Text))
		{
			DarkMessageBox.ShowWarning("The max range value must be a valid number", "Invalid value");
		}
	}

	private void SelectGlobal(object sender, EventArgs e)
	{
		if (!Versioned.IsNumeric(TB_TargetAlt.Text))
		{
			DarkMessageBox.ShowWarning("The target altitude value must be a valid number", "Invalid value");
		}
	}

	private void CallGlobal(object sender, EventArgs e)
	{
		_PrinterModel = (HorizonType)CB_HorizonType.SelectedIndex;
	}

	private void LogoutGlobal(object sender, CancelEventArgs e)
	{
		DestroyGlobal();
		Client.SelectedUnitChanged -= LoginGlobal;
		Client.LOS_ShadedArea = null;
	}

	private void ViewGlobal(object sender, EventArgs e)
	{
		TestGlobal().Color = Client.m_DefinitionRequest;
		TestGlobal().ShowDialog();
		Client.m_DefinitionRequest = Color.FromArgb(75, TestGlobal().Color);
		Button_ShadeColor.BackColor = Client.m_DefinitionRequest;
		Client.MustRefreshMainForm = true;
	}

	private void ValidateGlobal(object sender, EventArgs e)
	{
		if (!Information.IsNothing(Client.SelectedUnit))
		{
			Label_SelectedUnitName.Text = Client.SelectedUnit.Name;
		}
		Client.SelectedUnitChanged += LoginGlobal;
	}

	private void LoginGlobal(Module_Unit.Unit unit_0)
	{
		if (Information.IsNothing(Client.SelectedUnit))
		{
			Label_SelectedUnitName.Text = string.Empty;
		}
		else
		{
			Label_SelectedUnitName.Text = Client.SelectedUnit.Name;
		}
		ComputeGlobal();
	}

	private void GetGlobal(object object_0)
	{
		Label4.Text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? "Target Alt (ft AGL):" : "目标高度（米 真高）：");
		if (Versioned.IsNumeric(TB_TargetAlt.Text))
		{
			_ParserModel = Conversions.ToInteger(TB_TargetAlt.Text);
		}
	}

	private void WriteGlobal(object object_0)
	{
		if (Versioned.IsNumeric(TB_MaxRange.Text))
		{
			_AlgoModel = Conversions.ToSingle(TB_MaxRange.Text);
		}
	}

	private void NewGlobal(object sender, EventArgs e)
	{
		base.Height = 209;
	}
}
