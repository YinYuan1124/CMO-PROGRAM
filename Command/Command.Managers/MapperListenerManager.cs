using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Managers;

[StandardModule]
internal sealed class MapperListenerManager
{
	public static string _ExceptionClass;

	public static string _AttrClass;

	public static string visitorClass;

	public static string m_ExporterClass;

	public static string _PrototypeClass;

	public static string m_ComparatorClass;

	static MapperListenerManager()
	{
		_ExceptionClass = "None";
		_AttrClass = "Personnel";
		visitorClass = "Small";
		m_ExporterClass = "Medium";
		_PrototypeClass = "Large";
		m_ComparatorClass = "Very Large";
	}

	public static string SearchStrategy(int int_0)
	{
		switch (int_0)
		{
		case 2000:
			return visitorClass;
		case 1000:
			return _AttrClass;
		case 0:
			return _ExceptionClass;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return _ExceptionClass;
		case 5000:
			return m_ComparatorClass;
		case 4000:
			return _PrototypeClass;
		case 3000:
			return m_ExporterClass;
		}
	}

	public static int EnableStrategy(string string_0)
	{
		if (Operators.CompareString(string_0, _ExceptionClass, TextCompare: true) == 0)
		{
			return 0;
		}
		if (Operators.CompareString(string_0, _AttrClass, TextCompare: true) == 0)
		{
			return 1000;
		}
		if (Operators.CompareString(string_0, visitorClass, TextCompare: true) == 0)
		{
			return 2000;
		}
		if (Operators.CompareString(string_0, m_ExporterClass, TextCompare: true) == 0)
		{
			return 3000;
		}
		if (Operators.CompareString(string_0, _PrototypeClass, TextCompare: true) == 0)
		{
			return 4000;
		}
		if (Operators.CompareString(string_0, m_ComparatorClass, TextCompare: true) == 0)
		{
			return 5000;
		}
		return 0;
	}

	public static List<Cargo> ChangeStrategy(object object_0)
	{
		List<Cargo> list = new List<Cargo>();
		if (object_0 != null)
		{
			if (((ScenarioObject)object_0).IsGroup)
			{
				foreach (ActiveUnit item in ((Group)object_0).Units.Values.ToList())
				{
					list.AddRange(item.OnboardCargo);
				}
				return list;
			}
			list.AddRange(((ActiveUnit)object_0).OnboardCargo);
		}
		return list;
	}

	public static void InitStrategy(DataGridView dataGridView_0, List<CargoManifestItem> list_0, List<Cargo> list_1, bool bool_0 = false, bool bool_1 = false)
	{
		int num = 0;
		int index = 0;
		int index2 = 1;
		int num2 = 1;
		int num3 = 2;
		int num4 = 3;
		bool flag;
		if (flag = dataGridView_0.ColumnCount > 4)
		{
			num2++;
			num3++;
			num4++;
		}
		foreach (CargoManifestItem item in list_0)
		{
			if (bool_1)
			{
				dataGridView_0.Rows.Insert(0, 1);
				num = 0;
			}
			else
			{
				num = dataGridView_0.Rows.Add();
			}
			DataGridViewRow dataGridViewRow = dataGridView_0.Rows[num];
			if (item.objectType != Cargo.CargoObjectType.Mount && item.quantity >= 2)
			{
				dataGridViewRow.Cells[index].Value = item.quantity + "x " + item.Name;
			}
			else
			{
				dataGridViewRow.Cells[index].Value = item.Name;
			}
			dataGridViewRow.Cells[index].ToolTipText = item.Name;
			dataGridViewRow.Tag = item;
			if (bool_0)
			{
				int num5 = list_1.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					Cargo cargo = list_1[i];
					if (cargo.InternalObjectType == item.objectType && cargo.CargoObjectDBID == item.DBID)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
						{
							dataGridViewRow.Cells[num2].Value = Cargo.DisplayValueMass(cargo.RequiredMass * (float)item.quantity, bool_0: true).ToString("N");
							dataGridViewRow.Cells[num3].Value = Cargo.DisplayValueArea(cargo.RequiredArea * (float)item.quantity, bool_0: true).ToString("N");
						}
						else
						{
							dataGridViewRow.Cells[num2].Value = (cargo.RequiredMass * (float)item.quantity).ToString("N");
							dataGridViewRow.Cells[num3].Value = (cargo.RequiredArea * (float)item.quantity).ToString("N");
						}
						dataGridViewRow.Cells[num4].Value = (cargo.RequiredCrewSpace * (float)item.quantity).ToString();
						if (flag)
						{
							dataGridViewRow.Cells[index2].Value = SearchStrategy((int)cargo.RequiredCargoType);
							dataGridViewRow.Cells[index2].Tag = (int)cargo.RequiredCargoType;
						}
						break;
					}
				}
				continue;
			}
			if (item.objectType == Cargo.CargoObjectType.Mount)
			{
				int num6 = list_1.Count - 1;
				for (int j = 0; j <= num6; j++)
				{
					Cargo cargo2 = list_1[j];
					if (cargo2.InternalObjectType == item.objectType && cargo2.CargoObjectDBID == item.DBID)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
						{
							dataGridViewRow.Cells[num2].Value = Cargo.DisplayValueMass(cargo2.RequiredMass * (float)item.quantity, bool_0: true).ToString("N");
							dataGridViewRow.Cells[num3].Value = Cargo.DisplayValueArea(cargo2.RequiredArea * (float)item.quantity, bool_0: true).ToString("N");
						}
						else
						{
							dataGridViewRow.Cells[num2].Value = (cargo2.RequiredMass * (float)item.quantity).ToString("N");
							dataGridViewRow.Cells[num3].Value = (cargo2.RequiredArea * (float)item.quantity).ToString("N");
						}
						dataGridViewRow.Cells[num4].Value = (cargo2.RequiredCrewSpace * (float)item.quantity).ToString();
						if (flag)
						{
							dataGridViewRow.Cells[index2].Value = SearchStrategy((int)cargo2.RequiredCargoType);
							dataGridViewRow.Cells[index2].Tag = (int)cargo2.RequiredCargoType;
						}
						break;
					}
				}
				continue;
			}
			int num7 = list_1.Count - 1;
			for (int k = 0; k <= num7; k++)
			{
				Cargo cargo3 = list_1[k];
				if (cargo3.InternalObjectType == item.objectType && cargo3.CargoObjectDBID == item.DBID && Operators.CompareString(cargo3.CargoObjectID, item.ObjectID, TextCompare: true) == 0)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
					{
						dataGridViewRow.Cells[num2].Value = Cargo.DisplayValueMass(cargo3.RequiredMass, bool_0: true).ToString("N");
						dataGridViewRow.Cells[num3].Value = Cargo.DisplayValueArea(cargo3.RequiredArea, bool_0: true).ToString("N");
					}
					else
					{
						dataGridViewRow.Cells[num2].Value = cargo3.RequiredMass.ToString("N");
						dataGridViewRow.Cells[num3].Value = cargo3.RequiredArea.ToString("N");
					}
					dataGridViewRow.Cells[num4].Value = cargo3.RequiredCrewSpace.ToString();
					if (flag)
					{
						dataGridViewRow.Cells[index2].Value = SearchStrategy((int)cargo3.RequiredCargoType);
						dataGridViewRow.Cells[index2].Tag = (int)cargo3.RequiredCargoType;
					}
					dataGridViewRow.Tag = cargo3;
				}
			}
		}
	}

	public static void CheckStrategy(object object_0, object object_1, List<Cargo> list_0, bool bool_0 = false)
	{
		int num = -1;
		if (((DataGridView)object_0).SelectedRows.Count > 0)
		{
			num = ((DataGridView)object_0).SelectedRows[0].Index;
		}
		((DataGridView)object_0).Rows.Clear();
		if (list_0 == null || list_0.Count < 1)
		{
			return;
		}
		bool flag = false;
		int num2 = -1;
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<Cargo> list2 = new List<Cargo>();
		if (object_1 == null)
		{
			list2.AddRange(list_0);
		}
		else if (((ScenarioObject)object_1).IsGroup)
		{
			list.AddRange(((Group)object_1).Units.Values);
			flag = true;
			list2.AddRange(list_0);
		}
		else
		{
			list.Add((ActiveUnit)object_1);
		}
		foreach (ActiveUnit item in list)
		{
			object_1 = item;
			if (object_1 == null || !(object_1 is ICargoHost))
			{
				continue;
			}
			List<CargoManifestItem> list4;
			if (flag)
			{
				List<Cargo> list3 = new List<Cargo>();
				foreach (Cargo item2 in list_0)
				{
					if (((ActiveUnit)object_1).OnboardCargo.Contains(item2))
					{
						list3.Add(item2);
						list2.Remove(item2);
					}
				}
				if (list3.Count > 0)
				{
					num2 = ((DataGridView)object_0).Rows.Add();
					DataGridViewRow dataGridViewRow = ((DataGridView)object_0).Rows[num2];
					dataGridViewRow.Cells[0].Value = ((ScenarioObject)object_1).Name + " [Group Member]";
					dataGridViewRow.Cells[0].ToolTipText = ((ScenarioObject)object_1).Name;
					dataGridViewRow.Tag = object_1;
				}
				list4 = Cargo.GenerateCargoManifest(list3, bool_0);
			}
			else
			{
				list4 = Cargo.GenerateCargoManifest(list_0, bool_0);
			}
			if (list4.Count > 0)
			{
				InitStrategy((DataGridView)object_0, list4, list_0, bool_0);
			}
		}
		if (list2.Count > 0)
		{
			List<CargoManifestItem> list_ = Cargo.GenerateCargoManifest(list2, bool_0);
			InitStrategy((DataGridView)object_0, list_, list2, bool_0, bool_1: true);
		}
		((Control)object_0).Refresh();
		if (((DataGridView)object_0).Rows.Count > 0 && num > -1)
		{
			((DataGridView)object_0).ClearSelection();
			if (num >= ((DataGridView)object_0).Rows.Count)
			{
				num = ((DataGridView)object_0).Rows.Count - 1;
			}
			((DataGridView)object_0).Rows[num].Selected = true;
		}
	}

	public static int ConcatStrategy(int int_0, int int_1)
	{
		return (((int_0 << 5) | (int_0 >>> 27)) + int_0) ^ int_1;
	}

	public static void InterruptStrategy(object object_0, Control control_0, object object_1, float float_0, object object_2, float float_1, object object_3, float float_2)
	{
		if (object_0 == null)
		{
			if (control_0 != null)
			{
				control_0.Text = "Max Size: Unlimted";
			}
			((Control)object_1).Text = "质量：" + float_0.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			((Control)object_1).ForeColor = Color.White;
			((Control)object_2).Text = "区域：" + float_1.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			((Control)object_2).ForeColor = Color.White;
			((Control)object_3).Text = "PAX: " + float_2 + " Pers.";
			((Control)object_3).ForeColor = Color.White;
			return;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (((ScenarioObject)object_0).IsGroup)
		{
			foreach (ActiveUnit value in ((Group)object_0).Units.Values)
			{
				if (value is ICargoHost)
				{
					ICargoHost cargoHost = (ICargoHost)value;
					if ((float)cargoHost.GetCargo_Type() > num)
					{
						num = (float)cargoHost.GetCargo_Type();
					}
					num2 += cargoHost.GetCargo_Mass();
					num3 += cargoHost.GetCargo_Area();
					num4 += cargoHost.GetCargo_Crew();
				}
			}
		}
		else if (object_0 is ICargoHost)
		{
			ICargoHost obj = (ICargoHost)object_0;
			num = (float)obj.GetCargo_Type();
			num2 = obj.GetCargo_Mass();
			num3 = obj.GetCargo_Area();
			num4 = obj.GetCargo_Crew();
		}
		if (control_0 != null)
		{
			control_0.Text = "Max Size: ";
			float num5 = num;
			if (num5 == 0f)
			{
				control_0.Text += CargoHostHelper.c0000;
			}
			else if (num5 == 1000f)
			{
				control_0.Text += CargoHostHelper.c1000;
			}
			else if (num5 == 2000f)
			{
				control_0.Text += CargoHostHelper.c2000;
			}
			else if (num5 == 3000f)
			{
				control_0.Text += CargoHostHelper.c3000;
			}
			else if (num5 == 4000f)
			{
				control_0.Text += CargoHostHelper.c4000;
			}
			else if (num5 == 5000f)
			{
				control_0.Text += CargoHostHelper.c5000;
			}
		}
		float num6 = num2;
		float num7 = Cargo.DisplayValueMass(num6 - float_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		float num8 = Cargo.DisplayValueMass(num6, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)object_1).Text = "质量：" + num7.ToString("N") + " / " + num8.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (num6 == 0f)
		{
			((DarkUIProgressBar)object_1).Value = 100;
		}
		else
		{
			((DarkUIProgressBar)object_1).Value = (int)Math.Round(100f * ((num6 - float_0) / num6));
		}
		if (float_0 == 0f)
		{
			((Control)object_1).ForeColor = Color.LightGray;
			((Control)object_1).Text = "[FULL] " + ((Control)object_1).Text;
		}
		else
		{
			((Control)object_1).ForeColor = Color.White;
		}
		num6 = num3;
		num7 = Cargo.DisplayValueArea(num6 - float_1, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		num8 = Cargo.DisplayValueArea(num6, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)object_2).Text = "区域：" + num7.ToString("N") + " / " + num8.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (num6 == 0f)
		{
			((DarkUIProgressBar)object_2).Value = 100;
		}
		else
		{
			((DarkUIProgressBar)object_2).Value = (int)Math.Round(100f * ((num6 - float_1) / num6));
		}
		if (float_1 == 0f)
		{
			((Control)object_2).ForeColor = Color.LightGray;
			((Control)object_2).Text = "[FULL] " + ((Control)object_2).Text;
		}
		else
		{
			((Control)object_2).ForeColor = Color.White;
		}
		num6 = num4;
		((Control)object_3).Text = "PAX: " + (num6 - float_2) + " / " + num6.ToString("N0") + " Pers.";
		if (num6 == 0f)
		{
			((DarkUIProgressBar)object_3).Value = 100;
		}
		else
		{
			((DarkUIProgressBar)object_3).Value = (int)Math.Round(100f * ((num6 - float_2) / num6));
		}
		if (float_2 == 0f)
		{
			((Control)object_3).ForeColor = Color.LightGray;
			((Control)object_3).Text = "[FULL] " + ((Control)object_3).Text;
		}
		else
		{
			((Control)object_3).ForeColor = Color.White;
		}
	}
}
