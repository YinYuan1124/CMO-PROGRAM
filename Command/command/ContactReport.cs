using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ContactReport : DarkSecondaryFormBase
{
	private IContainer _DefinitionValue;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitType")]
	private DarkLabel valValue;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_WrapperValue;

	[AccessedThroughProperty("LB_Emissions")]
	[CompilerGenerated]
	private DarkListView m_IssuerValue;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_Matches")]
	private DarkListView clientValue;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_DicValue;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl m_ConsumerValue;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage m_FacadeValue;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage proxyValue;

	[AccessedThroughProperty("SplitContainer1")]
	[CompilerGenerated]
	private SplitContainer m_PropertyValue;

	public Contact theContact;

	private GlobalVariables.ActiveUnitType m_ImporterValue;

	internal DarkLabel Label_UnitType
	{
		[CompilerGenerated]
		get
		{
			return valValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valValue = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WrapperValue = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkListView LB_Emissions
	{
		[CompilerGenerated]
		get
		{
			return m_IssuerValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IssuerValue = value;
		}
	}

	internal DarkListView LB_Matches
	{
		[CompilerGenerated]
		get
		{
			return clientValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListResolver;
			DarkListView darkListView = clientValue;
			if (darkListView != null)
			{
				darkListView.DoubleClick -= value2;
			}
			clientValue = value;
			darkListView = clientValue;
			if (darkListView != null)
			{
				darkListView.DoubleClick += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_DicValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DicValue = value;
		}
	}

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintResolver;
			DarkUITabControl consumerValue = m_ConsumerValue;
			if (consumerValue != null)
			{
				consumerValue.SelectedIndexChanged -= value2;
			}
			m_ConsumerValue = value;
			consumerValue = m_ConsumerValue;
			if (consumerValue != null)
			{
				consumerValue.SelectedIndexChanged += value2;
			}
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_FacadeValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FacadeValue = value;
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return proxyValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proxyValue = value;
		}
	}

	[field: AccessedThroughProperty("Label_HostedUnits")]
	internal DarkLabel Label_HostedUnits
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return m_PropertyValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PropertyValue = value;
		}
	}

	public ContactReport()
	{
		base.Shown += RunResolver;
		base.KeyDown += StartResolver;
		base.FormClosing += AssetResolver;
		base.Load += DefineResolver;
		VerifyResolver();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _DefinitionValue != null)
			{
				_DefinitionValue.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void VerifyResolver()
	{
		Label_UnitType = new DarkLabel();
		Label1 = new DarkLabel();
		Label3 = new DarkLabel();
		LB_Emissions = new DarkListView();
		LB_Matches = new DarkListView();
		Label2 = new DarkLabel();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		SplitContainer1 = new SplitContainer();
		TabPage2 = new TabPage();
		Label_HostedUnits = new DarkLabel();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		TabPage2.SuspendLayout();
		SuspendLayout();
		Label_UnitType.Location = new Point(2, 9);
		Label_UnitType.Name = "Label_UnitType";
		Label_UnitType.Size = new Size(52, 13);
		Label_UnitType.TabIndex = 0;
		Label_UnitType.Text = "单元类型：";
		Label1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label1.Location = new Point(3, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(121, 13);
		Label1.TabIndex = 3;
		Label1.Text = "探测到的辐射源：";
		Label3.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label3.Location = new Point(3, -1);
		Label3.Name = "Label3";
		Label3.Size = new Size(112, 13);
		Label3.TabIndex = 4;
		Label3.Text = "潜在匹配：";
		LB_Emissions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LB_Emissions.Location = new Point(6, 16);
		LB_Emissions.Name = "LB_Emissions";
		LB_Emissions.Size = new Size(606, 147);
		LB_Emissions.TabIndex = 5;
		LB_Matches.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LB_Matches.Location = new Point(3, 17);
		LB_Matches.Name = "LB_Matches";
		LB_Matches.Size = new Size(609, 199);
		LB_Matches.TabIndex = 6;
		Label2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Italic, GraphicsUnit.Point, 0);
		Label2.Location = new Point(121, -1);
		Label2.Name = "Label2";
		Label2.Size = new Size(123, 13);
		Label2.TabIndex = 7;
		Label2.Text = "（双击显示数据库信息）";
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Location = new Point(5, 36);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(630, 435);
		TabControl1.TabIndex = 8;
		TabPage1.BackColor = SystemColors.Control;
		TabPage1.Controls.Add(SplitContainer1);
		TabPage1.Location = new Point(4, 22);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(622, 409);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "辐射源";
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.Location = new Point(3, 3);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.Controls.Add(Label1);
		SplitContainer1.Panel1.Controls.Add(LB_Emissions);
		SplitContainer1.Panel2.Controls.Add(Label2);
		SplitContainer1.Panel2.Controls.Add(LB_Matches);
		SplitContainer1.Panel2.Controls.Add(Label3);
		SplitContainer1.Size = new Size(616, 403);
		SplitContainer1.SplitterDistance = 173;
		SplitContainer1.TabIndex = 8;
		TabPage2.BackColor = SystemColors.Control;
		TabPage2.Controls.Add(Label_HostedUnits);
		TabPage2.Location = new Point(4, 22);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(622, 409);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "发现托管单元";
		Label_HostedUnits.AutoSize = true;
		Label_HostedUnits.Location = new Point(6, 3);
		Label_HostedUnits.Name = "Label_HostedUnits";
		Label_HostedUnits.Size = new Size(97, 13);
		Label_HostedUnits.TabIndex = 0;
		Label_HostedUnits.Text = "Label_HostedUnits";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(636, 475);
		base.Controls.Add(TabControl1);
		base.Controls.Add(Label_UnitType);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ContactReport";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "目标报告";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel1.PerformLayout();
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.PerformLayout();
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		TabPage2.ResumeLayout(performLayout: false);
		TabPage2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ListResolver(object sender, EventArgs e)
	{
		string string_ = Misc.RunRequest(m_ImporterValue);
		int int_ = Conversions.ToInteger(LB_Matches.SelectedItems[0].Tag);
		Client.smethod_0(string_, int_);
	}

	private void ResolveResolver()
	{
		Text = "目标报告：" + theContact.Name;
		if (!Information.IsNothing(theContact.ActualUnit))
		{
			string text = "";
			if (theContact.ActualUnit.IsDecoy)
			{
				text = "[DECOY] ";
			}
			switch (theContact.IDStatus)
			{
			case Contact_Base.IdentificationStatus.Unknown:
			case Contact_Base.IdentificationStatus.KnownDomain:
				Label_UnitType.Text = "类型：未知";
				break;
			case Contact_Base.IdentificationStatus.KnownType:
				Label_UnitType.Text = "类型：" + theContact.ActualUnit.SubTypeDescription;
				break;
			case Contact_Base.IdentificationStatus.KnownClass:
				Label_UnitType.Text = text + "类别：" + theContact.ActualUnit.UnitClass;
				break;
			case Contact_Base.IdentificationStatus.PreciseID:
				Label_UnitType.Text = text + "识别为：" + theContact.ActualUnit.Name;
				break;
			}
		}
		LB_Emissions.Items.Clear();
		LB_Matches.Items.Clear();
		string text2 = "";
		EmissionContainer emissionContainer = null;
		if (theContact.HasDetectedEmissions)
		{
			List<int> list = theContact.DetectedEmissions.Keys.ToList();
			int num = 0;
			if (theContact.DetectedEmissions.Count <= 0)
			{
				LB_Emissions.Enabled = false;
				Label1.Text = "没有探测到辐射源";
			}
			else
			{
				LB_Emissions.Enabled = true;
				foreach (int item in list)
				{
					emissionContainer = theContact.DetectedEmissions[item];
					text2 = emissionContainer.GetID_Description(item, Client.CurrentScenario);
					LB_Emissions.Items.Add(new DarkListItem(text2 + "（持续：" + Misc.UpdateRequest((long)Math.Round(emissionContainer.Age), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "前）"));
					if (emissionContainer.PreciseID)
					{
						num++;
					}
				}
				Label1.Text = "探测到的辐射源（" + Conversions.ToString(num) + "发射器已识别）：";
			}
			if (num == 0)
			{
				LB_Matches.Enabled = false;
				Label3.Text = "没有已识别的发射器 - 无法缩小可能的匹配范围";
				return;
			}
			Label3.Text = "可能的匹配：";
			DataTable table = null;
			switch (theContact.Type)
			{
			case Contact_Base.ContactType.Air:
				m_ImporterValue = GlobalVariables.ActiveUnitType.Aircraft;
				table = DBFunctions.GetAllAircraft(Client.CurrentScenario.DBConnection);
				break;
			case Contact_Base.ContactType.Surface:
				m_ImporterValue = GlobalVariables.ActiveUnitType.Ship;
				table = DBFunctions.GetAllShips(Client.CurrentScenario.DBConnection);
				break;
			case Contact_Base.ContactType.Submarine:
				m_ImporterValue = GlobalVariables.ActiveUnitType.Submarine;
				table = DBFunctions.GetAllSubmarines(Client.CurrentScenario.DBConnection);
				break;
			case Contact_Base.ContactType.Orbital:
				m_ImporterValue = GlobalVariables.ActiveUnitType.Satellite;
				table = DBFunctions.GetAllSatellites(Client.CurrentScenario.DBConnection);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				m_ImporterValue = GlobalVariables.ActiveUnitType.Facility;
				table = DBFunctions.GetAllFacilities(Client.CurrentScenario.DBConnection);
				break;
			case Contact_Base.ContactType.Missile:
			case Contact_Base.ContactType.Torpedo:
				m_ImporterValue = GlobalVariables.ActiveUnitType.Weapon;
				table = DBFunctions.GetAllWeapons(Client.CurrentScenario.DBConnection);
				break;
			}
			List<int> possibleMatchesBasedOnEmissions = theContact.PossibleMatchesBasedOnEmissions;
			if (possibleMatchesBasedOnEmissions.Count <= 0)
			{
				LB_Matches.Enabled = false;
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			_ = possibleMatchesBasedOnEmissions.Count;
			stringBuilder.Append("(" + string.Join(",", possibleMatchesBasedOnEmissions) + ")");
			DataView dataView = new DataView(table);
			dataView.RowFilter = "ID IN " + stringBuilder.ToString();
			dataView.Sort = "LongName ASC";
			LB_Matches.Enabled = true;
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = dataView.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataRow row = ((DataRowView)enumerator2.Current).Row;
					DarkListItem darkListItem = new DarkListItem(Conversions.ToString(row["LongName"]));
					darkListItem.Tag = RuntimeHelpers.GetObjectValue(row["ID"]);
					LB_Matches.Items.Add(darkListItem);
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			LB_Matches.Refresh();
		}
		else
		{
			LB_Emissions.Enabled = false;
			Label1.Text = "没有探测到辐射源";
		}
	}

	private void PostResolver()
	{
		if (theContact.IncludeImporter(Client.CurrentSide).Count <= 0)
		{
			Label_HostedUnits.Text = "没有发现托管单元。";
			return;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		string text = null;
		foreach (Contact.HostedUnitReconRecord item in theContact.IncludeImporter(Client.CurrentSide))
		{
			switch (item.IDStatus)
			{
			case Contact_Base.IdentificationStatus.Unknown:
				text = "未知单元";
				break;
			case Contact_Base.IdentificationStatus.KnownDomain:
				try
				{
					ActiveUnit activeUnit2 = Client.CurrentScenario.ActiveUnits[item.UnitID];
					text = Misc.CollectRequest(activeUnit2.VisualSizeClass) + " " + activeUnit2.UnitType_String;
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at 999999", exception_4.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "未知单元";
					ProjectData.ClearProjectError();
				}
				break;
			case Contact_Base.IdentificationStatus.KnownType:
				try
				{
					ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[item.UnitID];
					text = Misc.CollectRequest(activeUnit.VisualSizeClass) + " " + activeUnit.SubTypeDescription;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200409", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "未知单元";
					ProjectData.ClearProjectError();
				}
				break;
			case Contact_Base.IdentificationStatus.KnownClass:
				try
				{
					text = Client.CurrentScenario.ActiveUnits[item.UnitID].UnitClass;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200410", exception_2.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "未知单元";
					ProjectData.ClearProjectError();
				}
				break;
			case Contact_Base.IdentificationStatus.PreciseID:
				try
				{
					text = Client.CurrentScenario.ActiveUnits[item.UnitID].Name;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200411", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "未知单元";
					ProjectData.ClearProjectError();
				}
				break;
			}
			text = text + "（最后一次侦察：" + ((item.ReconAge <= 0f) ? "Now)" : (Misc.UpdateRequest((long)Math.Round(item.ReconAge), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "前）"));
			if (dictionary.ContainsKey(text))
			{
				dictionary[text]++;
			}
			else
			{
				dictionary.Add(text, 1);
			}
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			list.Add(Conversions.ToString(item2.Value) + "x " + item2.Key);
		}
		Label_HostedUnits.Text = string.Join("\r\n", list);
	}

	private void RunResolver(object sender, EventArgs e)
	{
		ResolveResolver();
		PostResolver();
		TabControl1.SelectedIndex = Client._ProducerClass;
	}

	private void StartResolver(object sender, KeyEventArgs e)
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

	private void AssetResolver(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void PrintResolver(object sender, EventArgs e)
	{
		Client._ProducerClass = TabControl1.SelectedIndex;
	}

	private void DefineResolver(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
