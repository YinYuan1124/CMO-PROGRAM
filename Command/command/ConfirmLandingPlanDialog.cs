using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ConfirmLandingPlanDialog : Form
{
	private IContainer configurationRequest;

	[AccessedThroughProperty("LV_CreatedMissions")]
	[CompilerGenerated]
	private DarkListView m_IndexerRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Title")]
	private DarkLabel m_ResolverRequest;

	[AccessedThroughProperty("DatePicker_Date")]
	[CompilerGenerated]
	private DateTimePicker m_PublisherRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_Time")]
	private DateTimePicker _ServerRequest;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private DarkUIButton schemaRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_InstantLoading")]
	private DarkCheckBox utilsRequest;

	[AccessedThroughProperty("CB_StartImmediately")]
	[CompilerGenerated]
	private DarkCheckBox m_PredicateRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AssociateToLHour")]
	private DarkCheckBox m_SingletonRequest;

	[AccessedThroughProperty("GP_AmphibiousVehicles")]
	[CompilerGenerated]
	private DarkGroupBox m_RecordRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("NumUD_WaveFreq")]
	private NumericUpDown m_AttrRequest;

	[AccessedThroughProperty("CB_NewWaveEvery")]
	[CompilerGenerated]
	private DarkCheckBox visitorRequest;

	[AccessedThroughProperty("HHourDatePicker_Date")]
	[CompilerGenerated]
	private DateTimePicker prototypeRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("HHourDatePicker_Time")]
	private DateTimePicker m_ComparatorRequest;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_ItemRequest;

	[AccessedThroughProperty("TB_LandingPlanName")]
	[CompilerGenerated]
	private DarkUITextBox m_SetterRequest;

	[AccessedThroughProperty("Label_LandingPlanName")]
	[CompilerGenerated]
	private DarkLabel m_CreatorRequest;

	public LandingPlanner landingPlannerWindow;

	[field: AccessedThroughProperty("TB_Description")]
	internal virtual DarkRichTextBox TB_Description
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkListView LV_CreatedMissions
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IndexerRequest = value;
		}
	}

	internal virtual DarkLabel Label_Title
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ResolverRequest = value;
		}
	}

	internal virtual DateTimePicker DatePicker_Date
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapConfiguration;
			DateTimePicker publisherRequest = m_PublisherRequest;
			if (publisherRequest != null)
			{
				publisherRequest.ValueChanged -= value2;
			}
			m_PublisherRequest = value;
			publisherRequest = m_PublisherRequest;
			if (publisherRequest != null)
			{
				publisherRequest.ValueChanged += value2;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_Time
	{
		[CompilerGenerated]
		get
		{
			return _ServerRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortConfiguration;
			DateTimePicker serverRequest = _ServerRequest;
			if (serverRequest != null)
			{
				serverRequest.ValueChanged -= value2;
			}
			_ServerRequest = value;
			serverRequest = _ServerRequest;
			if (serverRequest != null)
			{
				serverRequest.ValueChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GB_AssociateToLHour")]
	internal virtual DarkGroupBox GB_AssociateToLHour
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return schemaRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectConfiguration;
			DarkUIButton darkUIButton = schemaRequest;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			schemaRequest = value;
			darkUIButton = schemaRequest;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkCheckBox CB_InstantLoading
	{
		[CompilerGenerated]
		get
		{
			return utilsRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderConfiguration;
			DarkCheckBox darkCheckBox = utilsRequest;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			utilsRequest = value;
			darkCheckBox = utilsRequest;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DarkCheckBox CB_StartImmediately
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterConfiguration;
			DarkCheckBox predicateRequest = m_PredicateRequest;
			if (predicateRequest != null)
			{
				predicateRequest.CheckedChanged -= value2;
			}
			m_PredicateRequest = value;
			predicateRequest = m_PredicateRequest;
			if (predicateRequest != null)
			{
				predicateRequest.CheckedChanged += value2;
			}
		}
	}

	internal virtual DarkCheckBox CB_AssociateToLHour
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageConfiguration;
			DarkCheckBox singletonRequest = m_SingletonRequest;
			if (singletonRequest != null)
			{
				singletonRequest.CheckedChanged -= value2;
			}
			m_SingletonRequest = value;
			singletonRequest = m_SingletonRequest;
			if (singletonRequest != null)
			{
				singletonRequest.CheckedChanged += value2;
			}
		}
	}

	internal virtual DarkGroupBox GP_AmphibiousVehicles
	{
		[CompilerGenerated]
		get
		{
			return m_RecordRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordRequest = value;
		}
	}

	[field: AccessedThroughProperty("LabelWaveFreq")]
	internal virtual DarkLabel LabelWaveFreq
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual NumericUpDown NumUD_WaveFreq
	{
		[CompilerGenerated]
		get
		{
			return m_AttrRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrRequest = value;
		}
	}

	internal virtual DarkCheckBox CB_NewWaveEvery
	{
		[CompilerGenerated]
		get
		{
			return visitorRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			visitorRequest = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DateTimePicker HHourDatePicker_Date
	{
		[CompilerGenerated]
		get
		{
			return prototypeRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcConfiguration;
			DateTimePicker dateTimePicker = prototypeRequest;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged -= value2;
			}
			prototypeRequest = value;
			dateTimePicker = prototypeRequest;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged += value2;
			}
		}
	}

	internal virtual DateTimePicker HHourDatePicker_Time
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateConfiguration;
			DateTimePicker comparatorRequest = m_ComparatorRequest;
			if (comparatorRequest != null)
			{
				comparatorRequest.ValueChanged -= value2;
			}
			m_ComparatorRequest = value;
			comparatorRequest = m_ComparatorRequest;
			if (comparatorRequest != null)
			{
				comparatorRequest.ValueChanged += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_ItemRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ItemRequest = value;
		}
	}

	internal virtual DarkUITextBox TB_LandingPlanName
	{
		[CompilerGenerated]
		get
		{
			return m_SetterRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SetterRequest = value;
		}
	}

	internal virtual DarkLabel Label_LandingPlanName
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorRequest = value;
		}
	}

	public ConfirmLandingPlanDialog()
	{
		base.Load += QueryConfiguration;
		AwakeConfiguration();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && configurationRequest != null)
			{
				configurationRequest.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AwakeConfiguration()
	{
		TB_Description = new DarkRichTextBox();
		LV_CreatedMissions = new DarkListView();
		Label_Title = new DarkLabel();
		DatePicker_Date = new DateTimePicker();
		DatePicker_Time = new DateTimePicker();
		GB_AssociateToLHour = new DarkGroupBox();
		DarkLabel2 = new DarkLabel();
		HHourDatePicker_Date = new DateTimePicker();
		HHourDatePicker_Time = new DateTimePicker();
		DarkLabel1 = new DarkLabel();
		Button_OK = new DarkUIButton();
		CB_InstantLoading = new DarkCheckBox();
		CB_StartImmediately = new DarkCheckBox();
		CB_AssociateToLHour = new DarkCheckBox();
		GP_AmphibiousVehicles = new DarkGroupBox();
		LabelWaveFreq = new DarkLabel();
		NumUD_WaveFreq = new NumericUpDown();
		CB_NewWaveEvery = new DarkCheckBox();
		TB_LandingPlanName = new DarkUITextBox();
		Label_LandingPlanName = new DarkLabel();
		GB_AssociateToLHour.SuspendLayout();
		GP_AmphibiousVehicles.SuspendLayout();
		((ISupportInitialize)NumUD_WaveFreq).BeginInit();
		SuspendLayout();
		TB_Description.BackColor = Color.FromArgb(60, 63, 65);
		TB_Description.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Description.Location = new Point(7, 10);
		TB_Description.Margin = new Padding(2, 3, 2, 3);
		TB_Description.Name = "TB_Description";
		TB_Description.ReadOnly = true;
		TB_Description.Size = new Size(279, 49);
		TB_Description.TabIndex = 0;
		TB_Description.Text = "The landing plan has been succesfully created and its generated cargo landing missions added to the operation planner.";
		LV_CreatedMissions.BackColor = Color.FromArgb(40, 43, 45);
		LV_CreatedMissions.Location = new Point(9, 94);
		LV_CreatedMissions.Margin = new Padding(2, 3, 2, 3);
		LV_CreatedMissions.Name = "LV_CreatedMissions";
		LV_CreatedMissions.Size = new Size(277, 143);
		LV_CreatedMissions.TabIndex = 1;
		LV_CreatedMissions.Text = "DarkListView1";
		Label_Title.AutoSize = true;
		Label_Title.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Title.Location = new Point(7, 78);
		Label_Title.Margin = new Padding(2, 0, 2, 0);
		Label_Title.Name = "Label_Title";
		Label_Title.Size = new Size(137, 13);
		Label_Title.TabIndex = 2;
		Label_Title.Text = "Generated Cargo Missions :";
		DatePicker_Date.CustomFormat = "d/MM/yyyy";
		DatePicker_Date.Format = DateTimePickerFormat.Short;
		DatePicker_Date.Location = new Point(89, 22);
		DatePicker_Date.Name = "DatePicker_Date";
		DatePicker_Date.Size = new Size(87, 20);
		DatePicker_Date.TabIndex = 62;
		DatePicker_Time.CustomFormat = "hh:mm:ss";
		DatePicker_Time.Format = DateTimePickerFormat.Custom;
		DatePicker_Time.Location = new Point(180, 22);
		DatePicker_Time.Name = "DatePicker_Time";
		DatePicker_Time.ShowUpDown = true;
		DatePicker_Time.Size = new Size(93, 20);
		DatePicker_Time.TabIndex = 63;
		GB_AssociateToLHour.Controls.Add(DarkLabel2);
		GB_AssociateToLHour.Controls.Add(HHourDatePicker_Date);
		GB_AssociateToLHour.Controls.Add(HHourDatePicker_Time);
		GB_AssociateToLHour.Controls.Add(DarkLabel1);
		GB_AssociateToLHour.Controls.Add(DatePicker_Date);
		GB_AssociateToLHour.Controls.Add(DatePicker_Time);
		GB_AssociateToLHour.ForeColor = Color.FromArgb(220, 220, 220);
		GB_AssociateToLHour.Location = new Point(7, 316);
		GB_AssociateToLHour.Margin = new Padding(2, 3, 2, 3);
		GB_AssociateToLHour.Name = "GB_AssociateToLHour";
		GB_AssociateToLHour.Padding = new Padding(2, 3, 2, 3);
		GB_AssociateToLHour.Size = new Size(280, 72);
		GB_AssociateToLHour.TabIndex = 64;
		GB_AssociateToLHour.TabStop = false;
		GB_AssociateToLHour.Text = "                ";
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(1, 47);
		DarkLabel2.Margin = new Padding(2, 0, 2, 0);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(86, 13);
		DarkLabel2.TabIndex = 67;
		DarkLabel2.Text = "Desired H-Hour :";
		HHourDatePicker_Date.CustomFormat = "d/MM/yyyy";
		HHourDatePicker_Date.Format = DateTimePickerFormat.Short;
		HHourDatePicker_Date.Location = new Point(89, 45);
		HHourDatePicker_Date.Name = "HHourDatePicker_Date";
		HHourDatePicker_Date.Size = new Size(87, 20);
		HHourDatePicker_Date.TabIndex = 65;
		HHourDatePicker_Time.CustomFormat = "hh:mm:ss";
		HHourDatePicker_Time.Format = DateTimePickerFormat.Custom;
		HHourDatePicker_Time.Location = new Point(180, 45);
		HHourDatePicker_Time.Name = "HHourDatePicker_Time";
		HHourDatePicker_Time.ShowUpDown = true;
		HHourDatePicker_Time.Size = new Size(93, 20);
		HHourDatePicker_Time.TabIndex = 66;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(1, 23);
		DarkLabel1.Margin = new Padding(2, 0, 2, 0);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(84, 13);
		DarkLabel1.TabIndex = 64;
		DarkLabel1.Text = "Desired L-Hour :";
		Button_OK.BackColor = Color.Transparent;
		Button_OK.DialogResult = DialogResult.None;
		Button_OK.ForeColor = SystemColors.Control;
		Button_OK.Location = new Point(7, 453);
		Button_OK.Margin = new Padding(2, 3, 2, 3);
		Button_OK.MinimumSize = new Size(278, 32);
		Button_OK.Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		Button_OK.Size = new Size(278, 32);
		Button_OK.TabIndex = 65;
		Button_OK.Text = "确定";
		CB_InstantLoading.AutoSize = true;
		CB_InstantLoading.Location = new Point(12, 272);
		CB_InstantLoading.Name = "CB_InstantLoading";
		CB_InstantLoading.Size = new Size(276, 17);
		CB_InstantLoading.TabIndex = 66;
		CB_InstantLoading.Text = "[EDITOR MODE] - Instant loading for all first waves ?";
		CB_StartImmediately.AutoSize = true;
		CB_StartImmediately.Location = new Point(12, 293);
		CB_StartImmediately.Name = "CB_StartImmediately";
		CB_StartImmediately.Size = new Size(157, 17);
		CB_StartImmediately.TabIndex = 67;
		CB_StartImmediately.Text = "Immediatly start the Landing";
		CB_AssociateToLHour.AutoSize = true;
		CB_AssociateToLHour.Location = new Point(12, 313);
		CB_AssociateToLHour.Name = "CB_AssociateToLHour";
		CB_AssociateToLHour.Size = new Size(67, 17);
		CB_AssociateToLHour.TabIndex = 68;
		CB_AssociateToLHour.Text = "规划中";
		GP_AmphibiousVehicles.Controls.Add(LabelWaveFreq);
		GP_AmphibiousVehicles.Controls.Add(NumUD_WaveFreq);
		GP_AmphibiousVehicles.Controls.Add(CB_NewWaveEvery);
		GP_AmphibiousVehicles.ForeColor = Color.FromArgb(220, 220, 220);
		GP_AmphibiousVehicles.Location = new Point(7, 394);
		GP_AmphibiousVehicles.Name = "GP_AmphibiousVehicles";
		GP_AmphibiousVehicles.Size = new Size(278, 53);
		GP_AmphibiousVehicles.TabIndex = 70;
		GP_AmphibiousVehicles.TabStop = false;
		GP_AmphibiousVehicles.Text = "Amphibious Vehicles Behaviour";
		GP_AmphibiousVehicles.Visible = false;
		LabelWaveFreq.AutoSize = true;
		LabelWaveFreq.ForeColor = Color.FromArgb(220, 220, 220);
		LabelWaveFreq.Location = new Point(223, 23);
		LabelWaveFreq.Margin = new Padding(2, 0, 2, 0);
		LabelWaveFreq.Name = "LabelWaveFreq";
		LabelWaveFreq.Size = new Size(50, 13);
		LabelWaveFreq.TabIndex = 71;
		LabelWaveFreq.Text = "Minute(s)";
		NumUD_WaveFreq.Location = new Point(118, 19);
		NumUD_WaveFreq.Name = "NumUD_WaveFreq";
		NumUD_WaveFreq.Size = new Size(99, 20);
		NumUD_WaveFreq.TabIndex = 72;
		CB_NewWaveEvery.AutoSize = true;
		CB_NewWaveEvery.Location = new Point(6, 19);
		CB_NewWaveEvery.Name = "CB_NewWaveEvery";
		CB_NewWaveEvery.Size = new Size(106, 17);
		CB_NewWaveEvery.TabIndex = 71;
		CB_NewWaveEvery.Text = "New wave every";
		TB_LandingPlanName.AutoCompleteCustomSource = null;
		TB_LandingPlanName.AutoCompleteMode = AutoCompleteMode.None;
		TB_LandingPlanName.AutoCompleteSource = AutoCompleteSource.None;
		TB_LandingPlanName.BackColor = Color.Transparent;
		TB_LandingPlanName.ForeColor = Color.FromArgb(189, 189, 189);
		TB_LandingPlanName.Image = null;
		TB_LandingPlanName.Lines = null;
		TB_LandingPlanName.Location = new Point(51, 243);
		TB_LandingPlanName.MaxLength = 32767;
		TB_LandingPlanName.Multiline = false;
		TB_LandingPlanName.Name = "TB_LandingPlanName";
		TB_LandingPlanName.ReadOnly = false;
		TB_LandingPlanName.ScrollBars = ScrollBars.None;
		TB_LandingPlanName.SelectionStart = 0;
		TB_LandingPlanName.Size = new Size(237, 24);
		TB_LandingPlanName.TabIndex = 71;
		TB_LandingPlanName.TextAlign = HorizontalAlignment.Left;
		TB_LandingPlanName.UseSystemPasswordChar = false;
		TB_LandingPlanName.WatermarkText = "Landing plan's name";
		Label_LandingPlanName.AutoSize = true;
		Label_LandingPlanName.ForeColor = Color.FromArgb(220, 220, 220);
		Label_LandingPlanName.Location = new Point(10, 247);
		Label_LandingPlanName.Name = "Label_LandingPlanName";
		Label_LandingPlanName.Size = new Size(35, 13);
		Label_LandingPlanName.TabIndex = 72;
		Label_LandingPlanName.Text = "名称";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(297, 494);
		base.Controls.Add(Label_LandingPlanName);
		base.Controls.Add(TB_LandingPlanName);
		base.Controls.Add(GP_AmphibiousVehicles);
		base.Controls.Add(CB_AssociateToLHour);
		base.Controls.Add(CB_StartImmediately);
		base.Controls.Add(CB_InstantLoading);
		base.Controls.Add(Button_OK);
		base.Controls.Add(GB_AssociateToLHour);
		base.Controls.Add(Label_Title);
		base.Controls.Add(LV_CreatedMissions);
		base.Controls.Add(TB_Description);
		base.Margin = new Padding(2, 3, 2, 3);
		base.MaximizeBox = false;
		MaximumSize = new Size(313, 533);
		base.MinimizeBox = false;
		MinimumSize = new Size(313, 533);
		base.Name = "ConfirmLandingPlanDialog";
		base.ShowIcon = false;
		Text = "确认着陆计划";
		GB_AssociateToLHour.ResumeLayout(performLayout: false);
		GB_AssociateToLHour.PerformLayout();
		GP_AmphibiousVehicles.ResumeLayout(performLayout: false);
		GP_AmphibiousVehicles.PerformLayout();
		((ISupportInitialize)NumUD_WaveFreq).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void QueryConfiguration(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, LandingType> generatedMission in landingPlannerWindow.GeneratedMissions)
		{
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = generatedMission.Key.Name;
			LV_CreatedMissions.Items.Add(darkListItem);
		}
		foreach (KeyValuePair<ActiveUnit, Transport> transport in landingPlannerWindow.TransportList)
		{
			if (transport.Value.Waves.Count > 0)
			{
				transport.Value.Waves.ElementAt(0).AssociatedMission.InstantLoadingForNextManifest = true;
			}
		}
		TB_LandingPlanName.Text = landingPlannerWindow.LandingPlan.Name;
		FlushConfiguration();
		ResetConfiguration();
	}

	private void ResetConfiguration()
	{
		CB_AssociateToLHour.CheckedChanged -= ManageConfiguration;
		CB_StartImmediately.CheckedChanged -= RegisterConfiguration;
		CB_InstantLoading.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		if (CB_AssociateToLHour.Checked)
		{
			CB_StartImmediately.Enabled = false;
			CB_StartImmediately.Checked = false;
		}
		else
		{
			CB_StartImmediately.Enabled = true;
		}
		if (CB_StartImmediately.Checked)
		{
			CB_AssociateToLHour.Enabled = false;
			CB_AssociateToLHour.Checked = false;
		}
		else
		{
			CB_AssociateToLHour.Enabled = true;
		}
		GB_AssociateToLHour.Visible = CB_AssociateToLHour.Checked;
		bool flag = false;
		foreach (KeyValuePair<Mission, LandingType> generatedMission in landingPlannerWindow.GeneratedMissions)
		{
			if (generatedMission.Key.MissionClass == Mission._MissionClass.Support)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			GP_AmphibiousVehicles.Visible = true;
		}
		else
		{
			GP_AmphibiousVehicles.Visible = false;
		}
		CB_AssociateToLHour.CheckedChanged += ManageConfiguration;
		CB_StartImmediately.CheckedChanged += RegisterConfiguration;
	}

	private void MapConfiguration(object sender, EventArgs e)
	{
		ForgotConfiguration();
	}

	private void SortConfiguration(object sender, EventArgs e)
	{
		ForgotConfiguration();
	}

	private void CalcConfiguration(object sender, EventArgs e)
	{
		ForgotConfiguration();
	}

	private void RateConfiguration(object sender, EventArgs e)
	{
		ForgotConfiguration();
	}

	private void FlushConfiguration()
	{
		DatePicker_Time.ValueChanged -= SortConfiguration;
		DatePicker_Time.ValueChanged -= SortConfiguration;
		HHourDatePicker_Date.ValueChanged -= CalcConfiguration;
		HHourDatePicker_Time.ValueChanged -= RateConfiguration;
		DatePicker_Date.Value = Client.CurrentScenario.Time;
		DatePicker_Time.Value = Client.CurrentScenario.Time;
		HHourDatePicker_Date.Value = Client.CurrentScenario.Time;
		HHourDatePicker_Time.Value = Client.CurrentScenario.Time;
		DatePicker_Time.ValueChanged += SortConfiguration;
		DatePicker_Time.ValueChanged += SortConfiguration;
		HHourDatePicker_Date.ValueChanged += CalcConfiguration;
		HHourDatePicker_Time.ValueChanged += RateConfiguration;
	}

	private void ForgotConfiguration()
	{
		if (DateTime.Compare(new DateTime(DatePicker_Date.Value.Year, DatePicker_Date.Value.Month, DatePicker_Date.Value.Day, DatePicker_Time.Value.Hour, DatePicker_Time.Value.Minute, DatePicker_Time.Value.Second), Client.CurrentScenario.Time) < 0)
		{
			FlushConfiguration();
		}
	}

	private void CollectConfiguration(object sender, EventArgs e)
	{
		landingPlannerWindow.LandingPlan.Name = TB_LandingPlanName.Text;
		if (CB_InstantLoading.Checked)
		{
			foreach (KeyValuePair<ActiveUnit, Transport> transport in landingPlannerWindow.TransportList)
			{
				if (transport.Value.Waves.Count > 0)
				{
					transport.Value.Waves.ElementAt(0).AssociatedMission.InstantLoadingForNextManifest = true;
				}
			}
		}
		if (CB_StartImmediately.Checked)
		{
			foreach (KeyValuePair<ActiveUnit, Transport> transport2 in landingPlannerWindow.TransportList)
			{
				foreach (TransportWave wave in transport2.Value.Waves)
				{
					if (wave.IsFirstWave)
					{
						wave.AssociatedMission.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Active);
					}
				}
			}
		}
		if (CB_AssociateToLHour.Checked && landingPlannerWindow.GeneratedMissions.Count > 0)
		{
			CargoMission cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, " -[Amphibious] Master Landing Plan - ", Mission.MissionCategory.Mission, ((CargoMission)landingPlannerWindow.GeneratedMissions.Keys.ElementAt(0)).Area, bool_0: false);
			foreach (KeyValuePair<Mission, LandingType> item2 in landingPlannerWindow.GeneratedMissions.ToList())
			{
				if (item2.Value == LandingType.Amphibious)
				{
					item2.Key.MissionStartTrigger_MissionCompleted.Add(cargoMission, cargoMission);
					item2.Key.MissionStartTrigger_MissionCompleted_Enabled = true;
					item2.Key.MissionStartTrigger_MissionCompleted_Operator = false;
				}
			}
			cargoMission.MissionCompletedTrigger_ElapsedTime = 0f;
			cargoMission.MissionCompletedTrigger_ElapsedTime_Enabled = true;
			cargoMission.CreationMode = MissionCreationType.LandingPlanner;
			cargoMission.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.OnHold);
			cargoMission.OperationName = landingPlannerWindow.CurrentMothership.Name + " landing operation.";
			Operation operation = Client.CurrentSide.Operation;
			operation.LHour = new DateTime(DatePicker_Date.Value.Year, DatePicker_Date.Value.Month, DatePicker_Date.Value.Day, DatePicker_Time.Value.Hour, DatePicker_Time.Value.Minute, DatePicker_Time.Value.Second);
			operation.LHourMission = cargoMission;
			landingPlannerWindow.LandingPlan.AddMission(cargoMission);
			cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, " -[Air] Master Landing Plan - ", Mission.MissionCategory.Mission, ((CargoMission)landingPlannerWindow.GeneratedMissions.Keys.ElementAt(0)).Area, bool_0: false);
			cargoMission.MissionCompletedTrigger_ElapsedTime = 0f;
			cargoMission.MissionCompletedTrigger_ElapsedTime_Enabled = true;
			cargoMission.CreationMode = MissionCreationType.LandingPlanner;
			cargoMission.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.OnHold);
			cargoMission.OperationName = landingPlannerWindow.CurrentMothership.Name + " landing operation.";
			Operation operation2 = Client.CurrentSide.Operation;
			operation2.HHour = new DateTime(HHourDatePicker_Date.Value.Year, HHourDatePicker_Date.Value.Month, HHourDatePicker_Date.Value.Day, HHourDatePicker_Time.Value.Hour, HHourDatePicker_Time.Value.Minute, HHourDatePicker_Time.Value.Second);
			operation2.HHourMission = cargoMission;
			landingPlannerWindow.LandingPlan.AddMission(cargoMission);
			foreach (KeyValuePair<Mission, LandingType> item3 in landingPlannerWindow.GeneratedMissions.ToList())
			{
				if (item3.Value == LandingType.Airborne)
				{
					item3.Key.MissionStartTrigger_MissionCompleted.Add(cargoMission, cargoMission);
					item3.Key.MissionStartTrigger_MissionCompleted_Enabled = true;
					item3.Key.MissionStartTrigger_MissionCompleted_Operator = false;
				}
			}
		}
		Dictionary<int, List<Mission>> dictionary = new Dictionary<int, List<Mission>>();
		foreach (KeyValuePair<Mission, LandingType> generatedMission in landingPlannerWindow.GeneratedMissions)
		{
			if (generatedMission.Key.MissionClass == Mission._MissionClass.Support)
			{
				if (dictionary.ContainsKey(generatedMission.Key.PriorityWeight))
				{
					dictionary[generatedMission.Key.PriorityWeight].Add(generatedMission.Key);
					continue;
				}
				dictionary.Add(generatedMission.Key.PriorityWeight, new List<Mission>());
				dictionary[generatedMission.Key.PriorityWeight].Add(generatedMission.Key);
			}
		}
		_ = from item in dictionary.OrderBy(delegate(KeyValuePair<int, List<Mission>> item)
			{
				KeyValuePair<int, List<Mission>> keyValuePair = item;
				return keyValuePair.Key;
			})
			select (item);
		foreach (KeyValuePair<int, List<Mission>> item5 in dictionary)
		{
			foreach (Mission item4 in item5.Value)
			{
				if (CB_StartImmediately.Checked && decimal.Compare(NumUD_WaveFreq.Value, 0m) == 0)
				{
					item4.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Active);
				}
			}
		}
		base.DialogResult = DialogResult.OK;
		landingPlannerWindow.ForceClose = true;
		landingPlannerWindow.Close();
	}

	private void OrderConfiguration(object sender, EventArgs e)
	{
		ResetConfiguration();
	}

	private void RegisterConfiguration(object sender, EventArgs e)
	{
		ResetConfiguration();
	}

	private void ManageConfiguration(object sender, EventArgs e)
	{
		ResetConfiguration();
	}
}
