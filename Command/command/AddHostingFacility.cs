using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddHostingFacility : DarkSecondaryFormBase
{
	public enum _EditHostingMode
	{
		AirFacs,
		BoatFacs
	}

	private IContainer threadProperty;

	[AccessedThroughProperty("LV_Facs")]
	[CompilerGenerated]
	private DarkListView ruleProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddSelected")]
	private DarkUIButton _CollectionProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Unit")]
	private DarkLabel instanceProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("BackgroundThread")]
	private BackgroundWorker objectProperty;

	private DataTable parameterProperty;

	private DataView _ExpressionProperty;

	private bool m_DispatcherProperty;

	public int Mode;

	public new Form ParentForm;

	public ActiveUnit theSelectedUnit;

	internal DarkListView LV_Facs
	{
		[CompilerGenerated]
		get
		{
			return ruleProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ruleProperty = value;
		}
	}

	internal DarkUIButton Button_AddSelected
	{
		[CompilerGenerated]
		get
		{
			return _CollectionProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = delegate
			{
				ReflectPool();
			};
			DarkUIButton collectionProperty = _CollectionProperty;
			if (collectionProperty != null)
			{
				collectionProperty.Click -= value2;
			}
			_CollectionProperty = value;
			collectionProperty = _CollectionProperty;
			if (collectionProperty != null)
			{
				collectionProperty.Click += value2;
			}
		}
	}

	internal DarkLabel Label_Unit
	{
		[CompilerGenerated]
		get
		{
			return instanceProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			instanceProperty = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker PostPool()
	{
		return objectProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RunPool(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = DisablePool;
		RunWorkerCompletedEventHandler value2 = UpdatePool;
		BackgroundWorker backgroundWorker = objectProperty;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		objectProperty = backgroundWorker_0;
		backgroundWorker = objectProperty;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public AddHostingFacility()
	{
		base.Load += delegate
		{
			if (Client._StateClass == 1f)
			{
				base.AutoScaleMode = AutoScaleMode.None;
			}
			PostPool().RunWorkerAsync();
			switch (Mode)
			{
			case 1:
				Label_Unit.Text = "Add docking facilities for: ";
				break;
			case 0:
				Label_Unit.Text = "Add air facilities for: ";
				break;
			}
			Label_Unit.Text += theSelectedUnit.Name;
		};
		base.FormClosing += ReadPool;
		base.KeyDown += PreparePool;
		m_DispatcherProperty = false;
		Mode = 0;
		ParentForm = null;
		CreatePool();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && threadProperty != null)
			{
				threadProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CreatePool()
	{
		RunPool(new BackgroundWorker());
		LV_Facs = new DarkListView();
		Button_AddSelected = new DarkUIButton();
		Label_Unit = new DarkLabel();
		SuspendLayout();
		LV_Facs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LV_Facs.Location = new Point(0, 28);
		LV_Facs.Name = "LV_Facs";
		LV_Facs.RelatedInfos = null;
		LV_Facs.Size = new Size(400, 394);
		LV_Facs.TabIndex = 23;
		Button_AddSelected.BackColor = Color.Transparent;
		Button_AddSelected.DialogResult = DialogResult.None;
		Button_AddSelected.Dock = DockStyle.Bottom;
		Button_AddSelected.Font = new Font("Segoe UI", 10f);
		Button_AddSelected.ForeColor = SystemColors.Control;
		Button_AddSelected.Location = new Point(0, 422);
		Button_AddSelected.Name = "Button_AddSelected";
		Button_AddSelected.RoundRadius = 0;
		Button_AddSelected.Size = new Size(400, 24);
		Button_AddSelected.TabIndex = 3;
		Button_AddSelected.Text = "添加所选项";
		Label_Unit.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
		Label_Unit.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Unit.Location = new Point(0, 4);
		Label_Unit.Name = "Label_Unit";
		Label_Unit.Size = new Size(503, 16);
		Label_Unit.TabIndex = 19;
		Label_Unit.Text = "Adding Facilities for: <Unit>";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(400, 446);
		base.Controls.Add(Label_Unit);
		base.Controls.Add(Button_AddSelected);
		base.Controls.Add(LV_Facs);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddHostingFacility";
		base.ShowIcon = false;
		Text = "Add Hosting Facility";
		ResumeLayout(performLayout: false);
	}

	private void ComparePool(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		PostPool().RunWorkerAsync();
		switch (Mode)
		{
		case 1:
			Label_Unit.Text = "Add docking facilities for: ";
			break;
		case 0:
			Label_Unit.Text = "Add air facilities for: ";
			break;
		}
		Label_Unit.Text += theSelectedUnit.Name;
	}

	private void ReadPool(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		if (ParentForm != null)
		{
			ParentForm.BringToFront();
		}
		theSelectedUnit = null;
	}

	private void DisablePool(object sender, DoWorkEventArgs e)
	{
		switch (Mode)
		{
		case 1:
			parameterProperty = DBFunctions.GetAllDockFacilities(Client.CurrentScenario.DBConnection);
			break;
		case 0:
			parameterProperty = DBFunctions.GetAllAirFacilities(Client.CurrentScenario.DBConnection);
			break;
		}
	}

	private void UpdatePool(object sender, RunWorkerCompletedEventArgs e)
	{
		InsertPool();
	}

	private void InsertPool()
	{
		int num = 0;
		int num2 = 0;
		AirFacility airFacility = null;
		DockFacility dockFacility = null;
		DarkListItem darkListItem = null;
		try
		{
			LV_Facs.Items.Clear();
			_ExpressionProperty = new DataView(parameterProperty);
			switch (Mode)
			{
			case 1:
				_ExpressionProperty.Sort = "Type, PhysicalSize, Capacity";
				break;
			case 0:
				_ExpressionProperty.Sort = "Type, PhysicalSize, Capacity, RunwayLength";
				break;
			}
			int num3 = _ExpressionProperty.Count - 1;
			for (num = 0; num <= num3; num++)
			{
				num2 = Conversions.ToInteger(_ExpressionProperty[num].Row["ID"]);
				switch (Mode)
				{
				case 1:
				{
					int int_2 = num2;
					SQLiteConnection sqliteConnection_2 = Client.CurrentScenario.DBConnection;
					dockFacility = DBFunctions.GetDockFacility(int_2, ref sqliteConnection_2);
					if (dockFacility != null)
					{
						darkListItem = new DarkListItem(dockFacility.Name);
						darkListItem.Tag = num2;
						LV_Facs.Items.Add(darkListItem);
					}
					break;
				}
				case 0:
				{
					int int_ = num2;
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					airFacility = DBFunctions.GetAirFacility(int_, ref sqliteConnection_);
					if (airFacility != null)
					{
						if (airFacility.AirFacType == AirFacility._AirFacType.Runway || airFacility.AirFacType == AirFacility._AirFacType.RunwayGrade_Taxiway)
						{
							airFacility.Name = airFacility.Name + " " + airFacility.RunwayString;
						}
						darkListItem = new DarkListItem(airFacility.Name);
						darkListItem.Tag = num2;
						LV_Facs.Items.Add(darkListItem);
					}
					break;
				}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void PreparePool(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void ReflectPool()
	{
		try
		{
			if (theSelectedUnit == null)
			{
				return;
			}
			List<DarkListItem> selectedItems = LV_Facs.SelectedItems;
			if (selectedItems.Count <= 0)
			{
				return;
			}
			switch (Mode)
			{
			case 1:
			{
				DockFacility dockFacility = null;
				int num2 = selectedItems.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int int_2 = Conversions.ToInteger(selectedItems[j].Tag);
					SQLiteConnection sqliteConnection_2 = Client.CurrentScenario.DBConnection;
					dockFacility = DBFunctions.GetDockFacility(int_2, ref sqliteConnection_2, theSelectedUnit);
					if (dockFacility != null)
					{
						theSelectedUnit.AddDockFacility(dockFacility);
					}
				}
				break;
			}
			case 0:
			{
				AirFacility airFacility = null;
				int num = selectedItems.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int int_ = Conversions.ToInteger(selectedItems[i].Tag);
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					airFacility = DBFunctions.GetAirFacility(int_, ref sqliteConnection_, theSelectedUnit);
					if (airFacility != null)
					{
						theSelectedUnit.AddAirFacility(airFacility);
					}
				}
				break;
			}
			}
			if (Client.CurrentGame.Status == Game._GameStatus.Paused)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
			}
			if (ParentForm != null)
			{
				if (ParentForm == ItemExporter.ConnectInterruptibleTemplate.clientTemplate && ItemExporter.ConnectInterruptibleTemplate.AirOps.Visible)
				{
					ItemExporter.ConnectInterruptibleTemplate.AirOps.RefreshForm();
					InterpreterObjectListener.PostInterruptibleTask(ItemExporter.ConnectInterruptibleTemplate.AirOps.TV_Facilities);
				}
				else if (ParentForm == ItemExporter.ConnectInterruptibleTemplate.m_ContainerTemplate && ItemExporter.ConnectInterruptibleTemplate.DockingOps.Visible)
				{
					ItemExporter.ConnectInterruptibleTemplate.DockingOps.RefreshForm();
					InterpreterObjectListener.PostInterruptibleTask(ItemExporter.ConnectInterruptibleTemplate.DockingOps.TV_Facilities);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void Button_AddSelected_Click(object sender, EventArgs e)
	{
		ReflectPool();
	}

	[CompilerGenerated]
	private void VisitPool(object sender, EventArgs e)
	{
		ReflectPool();
	}

	[CompilerGenerated]
	private void RestartPool(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		PostPool().RunWorkerAsync();
		switch (Mode)
		{
		case 1:
			Label_Unit.Text = "Add docking facilities for: ";
			break;
		case 0:
			Label_Unit.Text = "Add air facilities for: ";
			break;
		}
		Label_Unit.Text += theSelectedUnit.Name;
	}
}
