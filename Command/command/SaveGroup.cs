using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command;

[DesignerGenerated]
public sealed class SaveGroup : DarkSecondaryFormBase
{
	private IContainer m_UtilsPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_PredicatePredicate;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel m_AttrPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Notes")]
	private DarkUITextBox exporterPredicate;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_ComparatorPredicate;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton itemPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("SaveFileDialog1")]
	private SaveFileDialog _SetterPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("SaveAsTemplate")]
	private DarkUICheckBox m_CreatorPredicate;

	private Keys[] templatePredicate;

	private ReadOnlyCollection<Module_Unit.Unit> m_MappingPredicate;

	private bool m_MockPredicate;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_PredicatePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PredicatePredicate = value;
		}
	}

	[field: AccessedThroughProperty("TB_Name")]
	internal DarkUITextBox TB_Name
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TB_ValidFrom")]
	internal DarkUITextBox TB_ValidFrom
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return m_AttrPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrPredicate = value;
		}
	}

	[field: AccessedThroughProperty("TB_ValidUntil")]
	internal DarkUITextBox TB_ValidUntil
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TB_Notes
	{
		[CompilerGenerated]
		get
		{
			return exporterPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterPredicate = value;
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchInterruptibleResolver;
			DarkUIButton comparatorPredicate = m_ComparatorPredicate;
			if (comparatorPredicate != null)
			{
				comparatorPredicate.Click -= value2;
			}
			m_ComparatorPredicate = value;
			comparatorPredicate = m_ComparatorPredicate;
			if (comparatorPredicate != null)
			{
				comparatorPredicate.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return itemPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleResolver;
			DarkUIButton darkUIButton = itemPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			itemPredicate = value;
			darkUIButton = itemPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUICheckBox SaveAsTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = LoginInterruptibleResolver;
			DarkUICheckBox creatorPredicate = m_CreatorPredicate;
			if (creatorPredicate != null)
			{
				creatorPredicate.CheckedChanged -= value2;
			}
			m_CreatorPredicate = value;
			creatorPredicate = m_CreatorPredicate;
			if (creatorPredicate != null)
			{
				creatorPredicate.CheckedChanged += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog PopInterruptibleResolver()
	{
		return _SetterPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void InstantiateInterruptibleResolver(SaveFileDialog saveFileDialog_0)
	{
		_SetterPredicate = saveFileDialog_0;
	}

	public SaveGroup()
	{
		base.Load += ComputeInterruptibleResolver;
		base.KeyDown += ViewInterruptibleResolver;
		base.FormClosing += ValidateInterruptibleResolver;
		templatePredicate = new Keys[1] { Keys.Escape };
		m_MockPredicate = false;
		AddInterruptibleResolver();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_UtilsPredicate != null)
			{
				m_UtilsPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AddInterruptibleResolver()
	{
		Label1 = new DarkLabel();
		TB_Name = new DarkUITextBox();
		Label2 = new DarkLabel();
		TB_ValidFrom = new DarkUITextBox();
		Label3 = new DarkLabel();
		TB_ValidUntil = new DarkUITextBox();
		TB_Notes = new DarkUITextBox();
		Label4 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		InstantiateInterruptibleResolver(new SaveFileDialog());
		SaveAsTemplate = new DarkUICheckBox();
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(55, 17);
		Label1.TabIndex = 0;
		Label1.Text = "名称:";
		TB_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_Name.AutoCompleteCustomSource = null;
		TB_Name.AutoCompleteMode = AutoCompleteMode.None;
		TB_Name.AutoCompleteSource = AutoCompleteSource.None;
		TB_Name.BackColor = Color.Transparent;
		TB_Name.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Name.Image = null;
		TB_Name.Lines = null;
		TB_Name.Location = new Point(78, 13);
		TB_Name.MaxLength = 32767;
		TB_Name.Multiline = false;
		TB_Name.Name = "TB_Name";
		TB_Name.ReadOnly = false;
		TB_Name.ScrollBars = ScrollBars.None;
		TB_Name.SelectionStart = 0;
		TB_Name.Size = new Size(492, 27);
		TB_Name.TabIndex = 1;
		TB_Name.TextAlign = HorizontalAlignment.Left;
		TB_Name.UseSystemPasswordChar = false;
		TB_Name.WatermarkText = "";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(12, 39);
		Label2.Name = "Label2";
		Label2.Size = new Size(56, 26);
		Label2.TabIndex = 2;
		Label2.Text = "From:";
		TB_ValidFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_ValidFrom.AutoCompleteCustomSource = null;
		TB_ValidFrom.AutoCompleteMode = AutoCompleteMode.None;
		TB_ValidFrom.AutoCompleteSource = AutoCompleteSource.None;
		TB_ValidFrom.BackColor = Color.Transparent;
		TB_ValidFrom.ForeColor = Color.FromArgb(189, 189, 189);
		TB_ValidFrom.Image = null;
		TB_ValidFrom.Lines = null;
		TB_ValidFrom.Location = new Point(78, 36);
		TB_ValidFrom.MaxLength = 32767;
		TB_ValidFrom.Multiline = false;
		TB_ValidFrom.Name = "TB_ValidFrom";
		TB_ValidFrom.ReadOnly = false;
		TB_ValidFrom.ScrollBars = ScrollBars.None;
		TB_ValidFrom.SelectionStart = 0;
		TB_ValidFrom.Size = new Size(492, 30);
		TB_ValidFrom.TabIndex = 3;
		TB_ValidFrom.TextAlign = HorizontalAlignment.Left;
		TB_ValidFrom.UseSystemPasswordChar = false;
		TB_ValidFrom.WatermarkText = "";
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(13, 65);
		Label3.Name = "Label3";
		Label3.Size = new Size(59, 24);
		Label3.TabIndex = 4;
		Label3.Text = "Until:";
		TB_ValidUntil.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_ValidUntil.AutoCompleteCustomSource = null;
		TB_ValidUntil.AutoCompleteMode = AutoCompleteMode.None;
		TB_ValidUntil.AutoCompleteSource = AutoCompleteSource.None;
		TB_ValidUntil.BackColor = Color.Transparent;
		TB_ValidUntil.ForeColor = Color.FromArgb(189, 189, 189);
		TB_ValidUntil.Image = null;
		TB_ValidUntil.Lines = null;
		TB_ValidUntil.Location = new Point(78, 62);
		TB_ValidUntil.MaxLength = 32767;
		TB_ValidUntil.Multiline = false;
		TB_ValidUntil.Name = "TB_ValidUntil";
		TB_ValidUntil.ReadOnly = false;
		TB_ValidUntil.ScrollBars = ScrollBars.None;
		TB_ValidUntil.SelectionStart = 0;
		TB_ValidUntil.Size = new Size(491, 30);
		TB_ValidUntil.TabIndex = 5;
		TB_ValidUntil.TextAlign = HorizontalAlignment.Left;
		TB_ValidUntil.UseSystemPasswordChar = false;
		TB_ValidUntil.WatermarkText = "";
		TB_Notes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Notes.AutoCompleteCustomSource = null;
		TB_Notes.AutoCompleteMode = AutoCompleteMode.None;
		TB_Notes.AutoCompleteSource = AutoCompleteSource.None;
		TB_Notes.BackColor = Color.Transparent;
		TB_Notes.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Notes.Image = null;
		TB_Notes.Lines = null;
		TB_Notes.Location = new Point(78, 88);
		TB_Notes.MaxLength = 32767;
		TB_Notes.Multiline = true;
		TB_Notes.Name = "TB_Notes";
		TB_Notes.ReadOnly = false;
		TB_Notes.ScrollBars = ScrollBars.None;
		TB_Notes.SelectionStart = 0;
		TB_Notes.Size = new Size(491, 114);
		TB_Notes.TabIndex = 6;
		TB_Notes.TextAlign = HorizontalAlignment.Left;
		TB_Notes.UseSystemPasswordChar = false;
		TB_Notes.WatermarkText = "";
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(13, 89);
		Label4.Name = "Label4";
		Label4.Size = new Size(55, 21);
		Label4.TabIndex = 7;
		Label4.Text = "注意：";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(210, 209);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(70, 37);
		Button1.TabIndex = 8;
		Button1.Text = "保存";
		Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.Cancel;
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(466, 209);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(91, 37);
		Button2.TabIndex = 9;
		Button2.Text = "取消";
		PopInterruptibleResolver().DefaultExt = "inst";
		PopInterruptibleResolver().Filter = "Import/Export file (*.inst)|*.inst|All Files (*.*)|*.*";
		PopInterruptibleResolver().InitialDirectory = "Installations";
		SaveAsTemplate.BackColor = Color.Transparent;
		SaveAsTemplate.Checked = false;
		SaveAsTemplate.Cursor = Cursors.Hand;
		SaveAsTemplate.ForeColor = Color.FromArgb(209, 209, 209);
		SaveAsTemplate.Location = new Point(17, 209);
		SaveAsTemplate.Name = "SaveAsTemplate";
		SaveAsTemplate.Size = new Size(177, 18);
		SaveAsTemplate.TabIndex = 10;
		SaveAsTemplate.Text = "保存为模板";
		base.AutoScaleMode = AutoScaleMode.None;
		base.CancelButton = Button2;
		base.ClientSize = new Size(582, 267);
		base.Controls.Add(SaveAsTemplate);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label4);
		base.Controls.Add(TB_Notes);
		base.Controls.Add(TB_ValidUntil);
		base.Controls.Add(Label3);
		base.Controls.Add(TB_ValidFrom);
		base.Controls.Add(Label2);
		base.Controls.Add(TB_Name);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.Fixed3D;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SaveGroup";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "导出单元/编队到文件";
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = templatePredicate;
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

	private void DestroyInterruptibleResolver(object sender, EventArgs e)
	{
		Close();
	}

	private void ComputeInterruptibleResolver(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		m_MappingPredicate = Client.CurrentSide.SelectedUnits;
	}

	private void PatchInterruptibleResolver(object sender, EventArgs e)
	{
		try
		{
			ImportExportRecord importExportRecord = new ImportExportRecord();
			importExportRecord.Name = TB_Name.Text;
			importExportRecord.ValidFrom = TB_ValidFrom.Text;
			importExportRecord.ValidUntil = TB_ValidUntil.Text;
			importExportRecord.Comments = TB_Notes.Text;
			importExportRecord.DB_ID = Client.CurrentDB.DBID;
			importExportRecord.Template = m_MockPredicate;
			new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "    ",
				ConformanceLevel = ConformanceLevel.Auto
			};
			foreach (ActiveUnit item3 in m_MappingPredicate.Where((Module_Unit.Unit theU) => theU.IsActiveUnit).ToList())
			{
				if (item3.IsGroup)
				{
					ActiveUnit groupLead = ((Group)item3).GroupLead;
					ImportExportRecord.MemberRecord item = Client.CurrentScenario.ExportUnitsToIER(groupLead);
					importExportRecord.MemberRecords.Add(item);
					foreach (ActiveUnit value in ((Group)item3).Units.Values)
					{
						if (!value.IsGroupLead())
						{
							item = Client.CurrentScenario.ExportUnitsToIER(value);
							importExportRecord.MemberRecords.Add(item);
						}
					}
				}
				else
				{
					ImportExportRecord.MemberRecord item2 = Client.CurrentScenario.ExportUnitsToIER(item3);
					importExportRecord.MemberRecords.Add(item2);
				}
			}
			PopInterruptibleResolver().InitialDirectory = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport";
			if (m_MockPredicate)
			{
				PopInterruptibleResolver().InitialDirectory = PopInterruptibleResolver().InitialDirectory + Conversions.ToString(Path.DirectorySeparatorChar) + "Templates";
				if (!Directory.Exists(PopInterruptibleResolver().InitialDirectory))
				{
					Directory.CreateDirectory(PopInterruptibleResolver().InitialDirectory);
				}
			}
			if (PopInterruptibleResolver().ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(PopInterruptibleResolver().FileName);
				JsonSerializer val = new JsonSerializer();
				using (streamWriter)
				{
					JsonTextWriter val2 = new JsonTextWriter(streamWriter);
					val2.Formatting = Newtonsoft.Json.Formatting.Indented;
					using (val2)
					{
						val.Serialize(val2, importExportRecord);
					}
				}
				Close();
				DarkMessageBox.ShowInformation("INST exported successfully.", "");
			}
			else
			{
				DarkMessageBox.ShowError(PopInterruptibleResolver().ShowDialog().ToString(), "");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			MessageBox.Show(exception_.Message);
			exception_?.Data.Add("Error at 1000405673", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SelectInterruptibleResolver(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (Aircraft item2 in activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly)
		{
			int int_ = ((!Information.IsNothing(item2.Loadout)) ? item2.Loadout.DBID : 0);
			ImportExportRecord.HostedAircraftRecord item = new ImportExportRecord.HostedAircraftRecord(item2.Name, item2.DBID, int_, (int)Math.Round(item2.AirOps.ConditionTimer / 60f));
			memberRecord_0.HostedAircraftRecords.Add(item);
		}
	}

	private void CallInterruptibleResolver(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (activeUnit_0.DockingOps.EmbarkedBoats.Count <= 0)
		{
			return;
		}
		foreach (ActiveUnit embarkedBoat in activeUnit_0.DockingOps.EmbarkedBoats)
		{
			ImportExportRecord.EmbarkedBoatRecord item = new ImportExportRecord.EmbarkedBoatRecord(embarkedBoat.Name, embarkedBoat.DBID, (int)Math.Round(embarkedBoat.DockingOps.ConditionTimer / 60f), embarkedBoat.UnitType_String);
			memberRecord_0.EmbarkedBoatRecords.Add(item);
		}
	}

	private void LogoutInterruptibleResolver(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (!(activeUnit_0.IsFacility | activeUnit_0.IsShip | activeUnit_0.IsSubmarine))
		{
			return;
		}
		Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
		Magazine[] array = sharedMagazines;
		foreach (Magazine magazine in array)
		{
			ImportExportRecord.MagazineRecord magazineRecord = new ImportExportRecord.MagazineRecord(magazine.Name, magazine.DBID);
			foreach (WeaponRec weapon in magazine.Weapons)
			{
				ImportExportRecord.WeaponRecord item = new ImportExportRecord.WeaponRecord(weapon.Name, weapon.int_0, weapon.MaxLoad, weapon.Multiple, weapon.CurrentLoad, (int)Math.Round(weapon.ReloadTime));
				magazineRecord.WeaponRecords.Add(item);
			}
			memberRecord_0.MagazineRecords.Add(magazineRecord);
		}
	}

	private void ViewInterruptibleResolver(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ValidateInterruptibleResolver(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LoginInterruptibleResolver(object object_0)
	{
		m_MockPredicate = SaveAsTemplate.Checked;
	}
}
