using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class WeaponPanel : UserControl
{
	private sealed class ReaderCollectionTask
	{
		[CompilerGenerated]
		private int m_ParamsMap;

		[CompilerGenerated]
		private string m_InfoMap;

		[CompilerGenerated]
		private int m_HelperMap;

		[CompilerGenerated]
		private int mapperMap;

		[CompilerGenerated]
		private string managerMap;

		public int Int32_0
		{
			[CompilerGenerated]
			get
			{
				return m_ParamsMap;
			}
			[CompilerGenerated]
			set
			{
				m_ParamsMap = value;
			}
		}

		public string WeaponName
		{
			[CompilerGenerated]
			get
			{
				return m_InfoMap;
			}
			[CompilerGenerated]
			set
			{
				m_InfoMap = value;
			}
		}

		public int Qty
		{
			[CompilerGenerated]
			get
			{
				return m_HelperMap;
			}
			[CompilerGenerated]
			set
			{
				m_HelperMap = value;
			}
		}

		public int Type
		{
			[CompilerGenerated]
			get
			{
				return mapperMap;
			}
			[CompilerGenerated]
			set
			{
				mapperMap = value;
			}
		}

		public string WeaponsQuickView
		{
			[CompilerGenerated]
			get
			{
				return managerMap;
			}
			[CompilerGenerated]
			set
			{
				managerMap = value;
			}
		}
	}

	[CompilerGenerated]
	private sealed class GetterMap
	{
		public WeaponRec Local_theWeaponRec;

		internal bool DefineInterruptibleMethod(ReaderCollectionTask theRec)
		{
			return theRec.Int32_0 == Local_theWeaponRec.int_0;
		}
	}

	[CompilerGenerated]
	private sealed class ProducerMap
	{
		public WeaponRec Local_theWeaponWeaponRec;

		internal bool PublishInterruptibleMethod(ReaderCollectionTask theRec)
		{
			return theRec.Int32_0 == Local_theWeaponWeaponRec.int_0;
		}
	}

	[CompilerGenerated]
	private sealed class InterceptorConfigObject
	{
		public WeaponRec Local_theWeaponRec;

		internal bool AwakeInterruptibleMethod(ReaderCollectionTask theRec)
		{
			return theRec.Int32_0 == Local_theWeaponRec.int_0;
		}
	}

	[CompilerGenerated]
	private sealed class ManagerProcessResolver
	{
		public WeaponRec Local_theWeaponRec;

		internal bool QueryInterruptibleMethod(ReaderCollectionTask theRec)
		{
			return theRec.Int32_0 == Local_theWeaponRec.int_0;
		}
	}

	private IContainer _ProxyExporter;

	[AccessedThroughProperty("TGV_WeaponsQuickView")]
	[CompilerGenerated]
	private DoubleBufferedDataGridView m_ReaderExporter;

	[AccessedThroughProperty("Type")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_RepositoryExporter;

	[AccessedThroughProperty("WeaponDBID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn invocationExporter;

	private List<ReaderCollectionTask> classExporter;

	private List<ReaderCollectionTask> _RequestExporter;

	private int ActualWidth;

	public bool UpdateData;

	public DoubleBufferedDataGridView TGV_WeaponsQuickView
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = PatchInterruptibleCreator;
			EventHandler value3 = SelectInterruptibleCreator;
			EventHandler value4 = CallInterruptibleCreator;
			DoubleBufferedDataGridView readerExporter = m_ReaderExporter;
			if (readerExporter != null)
			{
				readerExporter.CellContentClick -= value2;
				readerExporter.MouseEnter -= value3;
				readerExporter.MouseLeave -= value4;
			}
			m_ReaderExporter = value;
			readerExporter = m_ReaderExporter;
			if (readerExporter != null)
			{
				readerExporter.CellContentClick += value2;
				readerExporter.MouseEnter += value3;
				readerExporter.MouseLeave += value4;
			}
		}
	}

	[field: AccessedThroughProperty("WeaponsQuickView")]
	internal DataGridViewLinkColumn WeaponsQuickView
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("WeaponName")]
	internal DataGridViewTextBoxColumn WeaponName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Type
	{
		[CompilerGenerated]
		get
		{
			return m_RepositoryExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RepositoryExporter = value;
		}
	}

	[field: AccessedThroughProperty("Qty")]
	internal DataGridViewTextBoxColumn Qty
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn_0
	{
		[CompilerGenerated]
		get
		{
			return invocationExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			invocationExporter = value;
		}
	}

	public WeaponPanel()
	{
		base.Load += ViewInterruptibleCreator;
		classExporter = new List<ReaderCollectionTask>();
		ComputeInterruptibleCreator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ProxyExporter != null)
			{
				_ProxyExporter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ComputeInterruptibleCreator()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		TGV_WeaponsQuickView = new DoubleBufferedDataGridView();
		WeaponsQuickView = new DataGridViewLinkColumn();
		WeaponName = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		Qty = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		((ISupportInitialize)TGV_WeaponsQuickView).BeginInit();
		SuspendLayout();
		TGV_WeaponsQuickView.AllowUserToAddRows = false;
		TGV_WeaponsQuickView.AllowUserToDeleteRows = false;
		TGV_WeaponsQuickView.AllowUserToResizeColumns = false;
		TGV_WeaponsQuickView.AllowUserToResizeRows = false;
		TGV_WeaponsQuickView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_WeaponsQuickView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		TGV_WeaponsQuickView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		TGV_WeaponsQuickView.BackgroundColor = SystemColors.Control;
		TGV_WeaponsQuickView.BorderStyle = BorderStyle.None;
		TGV_WeaponsQuickView.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_WeaponsQuickView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		TGV_WeaponsQuickView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		TGV_WeaponsQuickView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		TGV_WeaponsQuickView.ColumnHeadersVisible = false;
		TGV_WeaponsQuickView.Columns.AddRange(WeaponsQuickView, WeaponName, Type, Qty, DataGridViewTextBoxColumn_0);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Window;
		dataGridViewCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		TGV_WeaponsQuickView.DefaultCellStyle = dataGridViewCellStyle;
		TGV_WeaponsQuickView.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_WeaponsQuickView.GridColor = Color.Gray;
		TGV_WeaponsQuickView.Location = new Point(0, 0);
		TGV_WeaponsQuickView.Margin = new Padding(0);
		TGV_WeaponsQuickView.MultiSelect = false;
		TGV_WeaponsQuickView.Name = "TGV_WeaponsQuickView";
		TGV_WeaponsQuickView.RowHeadersVisible = false;
		TGV_WeaponsQuickView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.ForeColor = SystemColors.Control;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
		TGV_WeaponsQuickView.RowsDefaultCellStyle = dataGridViewCellStyle2;
		TGV_WeaponsQuickView.ScrollBars = ScrollBars.Vertical;
		TGV_WeaponsQuickView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_WeaponsQuickView.Size = new Size(232, 142);
		TGV_WeaponsQuickView.TabIndex = 5;
		TGV_WeaponsQuickView.TabStop = false;
		WeaponsQuickView.ActiveLinkColor = Color.Blue;
		WeaponsQuickView.DataPropertyName = "WeaponsQuickView";
		WeaponsQuickView.HeaderText = "Weapons (click for detailed info)";
		WeaponsQuickView.Name = "WeaponsQuickView";
		WeaponsQuickView.ReadOnly = true;
		WeaponsQuickView.LinkColor = Color.LightBlue;
		WeaponsQuickView.Resizable = DataGridViewTriState.True;
		WeaponsQuickView.ToolTipText = "Click for weapon details.";
		WeaponsQuickView.VisitedLinkColor = Color.Blue;
		WeaponName.DataPropertyName = "WeaponName";
		WeaponName.HeaderText = "WeaponName";
		WeaponName.Name = "WeaponName";
		WeaponName.Visible = false;
		Type.DataPropertyName = "Type";
		Type.HeaderText = "类型";
		Type.Name = "Type";
		Type.Resizable = DataGridViewTriState.True;
		Type.SortMode = DataGridViewColumnSortMode.NotSortable;
		Type.Visible = false;
		Qty.DataPropertyName = "Qty";
		Qty.HeaderText = "数量";
		Qty.Name = "Qty";
		Qty.Visible = false;
		DataGridViewTextBoxColumn_0.DataPropertyName = "WeaponDBID";
		DataGridViewTextBoxColumn_0.HeaderText = "WeaponDBID";
		DataGridViewTextBoxColumn_0.Name = "WeaponDBID";
		DataGridViewTextBoxColumn_0.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(TGV_WeaponsQuickView);
		base.Name = "WeaponPanel";
		base.Size = new Size(234, 142);
		((ISupportInitialize)TGV_WeaponsQuickView).EndInit();
		ResumeLayout(performLayout: false);
	}

	public void RetreiveWeaponDetails(ActiveUnit activeUnit_0, bool bool_0, ref bool bool_1)
	{
		if (Information.IsNothing(activeUnit_0) || (activeUnit_0.IsShip && ((Ship)activeUnit_0).IsSinking))
		{
			return;
		}
		if (activeUnit_0.IsActiveUnit)
		{
			if (!activeUnit_0.IsAircraft && !activeUnit_0.IsShip && !activeUnit_0.IsSubmarine && !activeUnit_0.IsFacility && !activeUnit_0.IsSingleUnitAirbase && !activeUnit_0.IsGroup)
			{
				classExporter.Clear();
			}
			else
			{
				if (bool_0)
				{
					UpdateData = true;
					classExporter.Clear();
				}
				else
				{
					foreach (ReaderCollectionTask item in classExporter)
					{
						item.Qty = 0;
						item.WeaponsQuickView = "0x " + item.WeaponName;
					}
				}
				if (activeUnit_0.IsAircraft)
				{
					AddMountWeapons(activeUnit_0);
					AddLoadoutWeapons(activeUnit_0);
				}
				else if (!activeUnit_0.IsShip && !activeUnit_0.IsSubmarine && !activeUnit_0.IsFacility)
				{
					if (activeUnit_0.IsGroup && ((Group)activeUnit_0).Type == Group.GroupType.AirGroup)
					{
						foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
						{
							AddMountWeapons(value);
							AddLoadoutWeapons(value);
						}
					}
					else if (activeUnit_0.IsGroup)
					{
						foreach (ActiveUnit value2 in ((Group)activeUnit_0).Units.Values)
						{
							AddMountWeapons(value2);
							AddMagazineWeapons(value2);
						}
					}
				}
				else
				{
					AddMountWeapons(activeUnit_0);
					AddMagazineWeapons(activeUnit_0);
				}
				_RequestExporter = (from theRec in classExporter
					orderby theRec.Type, theRec.WeaponName
					select theRec).ToList();
			}
			if (classExporter.Count <= 10)
			{
				if (classExporter.Count == 0)
				{
					base.Height = 0;
				}
				else if (Client._StateClass == 1f)
				{
					base.Height = classExporter.Count * 19;
				}
				else
				{
					base.Height = Math.Max(60, (int)Math.Round((float)(classExporter.Count * 22) * Client._StateClass));
				}
			}
			else if (Client._StateClass == 1f)
			{
				base.Height = 190;
			}
			else
			{
				base.Height = (int)Math.Round(220f * Client._StateClass);
			}
			base.Visible = true;
		}
		else
		{
			base.Height = 0;
		}
		if (classExporter.Count <= 0)
		{
			bool_1 = false;
		}
		else
		{
			bool_1 = true;
		}
	}

	public void AddLoadoutWeapons(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
		WeaponRec[] array = weapons;
		foreach (WeaponRec Local_theWeaponRec in array)
		{
			if (Local_theWeaponRec.CurrentLoad <= 0)
			{
				continue;
			}
			Weapon referenceWeapon = Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario);
			switch (referenceWeapon.Type)
			{
			case Weapon._WeaponType.SensorPod:
				foreach (WeaponRec Local_theWeaponWeaponRec in referenceWeapon.WeaponWeapons)
				{
					if (Local_theWeaponWeaponRec.CurrentLoad > 0)
					{
						IEnumerable<ReaderCollectionTask> source2 = classExporter.Where((ReaderCollectionTask theRec) => theRec.Int32_0 == Local_theWeaponWeaponRec.int_0);
						if (source2.Count() <= 0)
						{
							ReaderCollectionTask readerCollectionTask3 = new ReaderCollectionTask();
							Weapon referenceWeapon3 = Local_theWeaponWeaponRec.GetReferenceWeapon(Client.CurrentScenario);
							readerCollectionTask3.Int32_0 = Local_theWeaponWeaponRec.int_0;
							readerCollectionTask3.WeaponName = referenceWeapon3.Name;
							readerCollectionTask3.Qty = Local_theWeaponWeaponRec.CurrentLoad;
							readerCollectionTask3.Type = (int)referenceWeapon3.Type;
							readerCollectionTask3.WeaponsQuickView = Conversions.ToString(Local_theWeaponWeaponRec.CurrentLoad) + "x " + referenceWeapon3.Name;
							classExporter.Add(readerCollectionTask3);
						}
						else
						{
							ReaderCollectionTask readerCollectionTask4 = source2.ElementAtOrDefault(0);
							readerCollectionTask4.Qty += Local_theWeaponWeaponRec.CurrentLoad;
							readerCollectionTask4.WeaponsQuickView = Conversions.ToString(readerCollectionTask4.Qty) + "x " + Local_theWeaponWeaponRec.GetReferenceWeapon(Client.CurrentScenario).Name;
						}
					}
				}
				break;
			default:
			{
				IEnumerable<ReaderCollectionTask> source = classExporter.Where((ReaderCollectionTask theRec) => theRec.Int32_0 == Local_theWeaponRec.int_0);
				if (source.Count() <= 0)
				{
					ReaderCollectionTask readerCollectionTask = new ReaderCollectionTask();
					Weapon referenceWeapon2 = Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario);
					readerCollectionTask.Int32_0 = Local_theWeaponRec.int_0;
					readerCollectionTask.WeaponName = referenceWeapon2.Name;
					readerCollectionTask.Qty = Local_theWeaponRec.CurrentLoad;
					readerCollectionTask.Type = (int)referenceWeapon2.Type;
					readerCollectionTask.WeaponsQuickView = Conversions.ToString(Local_theWeaponRec.CurrentLoad) + "x " + referenceWeapon2.Name;
					classExporter.Add(readerCollectionTask);
				}
				else
				{
					ReaderCollectionTask readerCollectionTask2 = source.ElementAtOrDefault(0);
					readerCollectionTask2.Qty += Local_theWeaponRec.CurrentLoad;
					readerCollectionTask2.WeaponsQuickView = Conversions.ToString(readerCollectionTask2.Qty) + "x " + Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario).Name;
				}
				break;
			}
			case Weapon._WeaponType.TrainingRound:
			case Weapon._WeaponType.DropTank:
			case Weapon._WeaponType.BuddyStore:
			case Weapon._WeaponType.FerryTank:
			case Weapon._WeaponType.HeliTowedPackage:
				break;
			}
		}
	}

	public void AddMagazineWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Magazine item in activeUnit_0.SharedMagazines.OrderBy((Magazine theM) => theM.Name))
		{
			if (item.IsAviationMag || item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec Local_theWeaponRec in item.Weapons)
			{
				if (Local_theWeaponRec.CurrentLoad > 0 && Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario).Type != Weapon._WeaponType.TrainingRound)
				{
					int currentLoad = Local_theWeaponRec.CurrentLoad;
					IEnumerable<ReaderCollectionTask> source = classExporter.Where((ReaderCollectionTask theRec) => theRec.Int32_0 == Local_theWeaponRec.int_0);
					if (source.Count() <= 0)
					{
						ReaderCollectionTask readerCollectionTask = new ReaderCollectionTask();
						Weapon referenceWeapon = Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario);
						readerCollectionTask.Int32_0 = Local_theWeaponRec.int_0;
						readerCollectionTask.WeaponName = referenceWeapon.Name;
						readerCollectionTask.Qty = currentLoad;
						readerCollectionTask.Type = (int)referenceWeapon.Type;
						readerCollectionTask.WeaponsQuickView = Conversions.ToString(currentLoad) + "x " + referenceWeapon.Name;
						classExporter.Add(readerCollectionTask);
					}
					else
					{
						ReaderCollectionTask readerCollectionTask2 = source.ElementAtOrDefault(0);
						readerCollectionTask2.Qty += currentLoad;
						readerCollectionTask2.WeaponsQuickView = Conversions.ToString(readerCollectionTask2.Qty) + "x " + Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario).Name;
					}
				}
			}
		}
	}

	public void AddMountWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Mount item in activeUnit_0.Mounts.OrderBy((Mount theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec Local_theWeaponRec in item.MountWeapons)
			{
				if (Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario).Type == Weapon._WeaponType.TrainingRound)
				{
					continue;
				}
				int num = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMountMagazine(item, Local_theWeaponRec.int_0);
				int currentLoad = Local_theWeaponRec.CurrentLoad;
				if (num > 0 || currentLoad > 0)
				{
					IEnumerable<ReaderCollectionTask> source = classExporter.Where((ReaderCollectionTask theRec) => theRec.Int32_0 == Local_theWeaponRec.int_0);
					if (source.Count() <= 0)
					{
						ReaderCollectionTask readerCollectionTask = new ReaderCollectionTask();
						Weapon referenceWeapon = Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario);
						readerCollectionTask.Int32_0 = Local_theWeaponRec.int_0;
						readerCollectionTask.WeaponName = referenceWeapon.Name;
						readerCollectionTask.Qty = currentLoad + num;
						readerCollectionTask.Type = (int)referenceWeapon.Type;
						readerCollectionTask.WeaponsQuickView = Conversions.ToString(currentLoad + num) + "x " + referenceWeapon.Name;
						classExporter.Add(readerCollectionTask);
					}
					else
					{
						ReaderCollectionTask readerCollectionTask2 = source.ElementAtOrDefault(0);
						readerCollectionTask2.Qty = readerCollectionTask2.Qty + currentLoad + num;
						readerCollectionTask2.WeaponsQuickView = Conversions.ToString(readerCollectionTask2.Qty) + "x " + Local_theWeaponRec.GetReferenceWeapon(Client.CurrentScenario).Name;
					}
				}
			}
		}
	}

	private void PatchInterruptibleCreator(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1)
		{
			int int_ = Conversions.ToInteger(TGV_WeaponsQuickView.Rows[e.RowIndex].Cells["WeaponDBID"].Value);
			Client.smethod_0("Weapon", int_);
		}
	}

	private void SelectInterruptibleCreator(object sender, EventArgs e)
	{
		UpdateData = false;
	}

	private void CallInterruptibleCreator(object sender, EventArgs e)
	{
		UpdateData = true;
	}

	private void LogoutInterruptibleCreator()
	{
		TGV_WeaponsQuickView.Rows.Clear();
		if (Information.IsNothing(_RequestExporter))
		{
			return;
		}
		foreach (ReaderCollectionTask item in _RequestExporter)
		{
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.CreateCells(TGV_WeaponsQuickView);
			dataGridViewRow.Cells[0].Value = item.WeaponsQuickView;
			dataGridViewRow.Cells[1].Value = item.WeaponName;
			dataGridViewRow.Cells[2].Value = item.Type;
			dataGridViewRow.Cells[3].Value = item.Qty;
			dataGridViewRow.Cells[4].Value = item.Int32_0;
			TGV_WeaponsQuickView.Rows.Add(dataGridViewRow);
		}
	}

	private void ViewInterruptibleCreator(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
