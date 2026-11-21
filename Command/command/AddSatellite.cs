using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddSatellite : DarkSecondaryFormBase
{
	private IContainer utilsProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TreeView1")]
	private DarkTreeView predicateProperty;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _SingletonProperty;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel recordProperty;

	private string exceptionProperty;

	private string m_AttrProperty;

	internal DarkTreeView TreeView1
	{
		[CompilerGenerated]
		get
		{
			return predicateProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			predicateProperty = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _SingletonProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetFilter;
			DarkUIButton singletonProperty = _SingletonProperty;
			if (singletonProperty != null)
			{
				singletonProperty.Click -= value2;
			}
			_SingletonProperty = value;
			singletonProperty = _SingletonProperty;
			if (singletonProperty != null)
			{
				singletonProperty.Click += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return recordProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			recordProperty = value;
		}
	}

	public AddSatellite()
	{
		base.Load += FindFilter;
		base.KeyDown += FillFilter;
		base.FormClosing += CalculateFilter;
		RemoveFilter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && utilsProperty != null)
			{
				utilsProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RemoveFilter()
	{
		TreeView1 = new DarkTreeView();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		SuspendLayout();
		TreeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TreeView1.Location = new Point(3, 3);
		TreeView1.MaxDragChange = 20;
		TreeView1.MultiSelect = true;
		TreeView1.Name = "TreeView1";
		TreeView1.Size = new Size(361, 458);
		TreeView1.TabIndex = 0;
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button1.Location = new Point(3, 467);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(114, 23);
		Button1.TabIndex = 1;
		Button1.Text = "添加所选项";
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(124, 472);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 2;
		Label1.Text = "Label1";
		Label1.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(367, 496);
		base.Controls.Add(Label1);
		base.Controls.Add(Button1);
		base.Controls.Add(TreeView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddSatellite";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "添加卫星";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void FindFilter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		TreeView1.Nodes.Clear();
		List<string> list = (from object theRow in Client.CurrentScenario.Cache_Satellites_DT.Rows
			select Conversions.ToString(NewLateBinding.LateIndexGet(theRow, new object[1] { "CountryString" }, null))).Distinct().ToList();
		list.Sort();
		foreach (string item in list)
		{
			DarkTreeNode darkTreeNode = new DarkTreeNode(item);
			darkTreeNode.Tag = "Country_" + item;
			TreeView1.Nodes.Add(darkTreeNode);
			PopulateNodesChildren(darkTreeNode);
		}
	}

	public void PopulateNodesChildren(DarkTreeNode darkTreeNode_0)
	{
		string text = Conversions.ToString(darkTreeNode_0.Tag);
		string left = text.Split('_')[0];
		if (Operators.CompareString(left, "Country", TextCompare: true) == 0)
		{
			exceptionProperty = text.Split('_')[1];
			{
				foreach (string item in (from object object_0 in Client.CurrentScenario.Cache_Satellites_DT.Rows
					where Operators.CompareString(Conversions.ToString(((DataRow)object_0)["CountryString"]), exceptionProperty, TextCompare: true) == 0
					select object_0 into theRow
					select Conversions.ToString(((DataRow)theRow)["TypeString"]) into theType
					orderby theType
					select theType).Distinct().ToList())
				{
					DarkTreeNode darkTreeNode = new DarkTreeNode(item);
					darkTreeNode.Tag = "Type_" + item;
					darkTreeNode_0.Nodes.Add(darkTreeNode);
					PopulateNodesChildren(darkTreeNode);
				}
				return;
			}
		}
		if (Operators.CompareString(left, "Type", TextCompare: true) == 0)
		{
			m_AttrProperty = text.Split('_')[1];
			{
				foreach (var valueTuple in (from object object_0 in Client.CurrentScenario.Cache_Satellites_DT.Rows
					where (Operators.CompareString(Conversions.ToString(((DataRow)object_0)["TypeString"]), m_AttrProperty, TextCompare: true) == 0) & (Operators.CompareString(Conversions.ToString(((DataRow)object_0)["CountryString"]), exceptionProperty, TextCompare: true) == 0)
					select object_0 into theRow
					select (Conversions.ToString(((DataRow)theRow)["Name"]), Conversions.ToInteger(((DataRow)theRow)["ID"])) into It
					orderby It.Item1
					select It).ToList())
				{
					DarkTreeNode darkTreeNode2 = new DarkTreeNode(valueTuple.Item1);
					darkTreeNode2.Tag = "SatClass_" + Conversions.ToString(valueTuple.Item2);
					darkTreeNode_0.Nodes.Add(darkTreeNode2);
					PopulateNodesChildren(darkTreeNode2);
				}
				return;
			}
		}
		if (Operators.CompareString(left, "SatClass", TextCompare: true) != 0)
		{
			return;
		}
		DataTable orbitsForThisSatellite = DBFunctions.GetOrbitsForThisSatellite(Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]), Client.CurrentScenario.DBConnection);
		IEnumerator enumerator3 = null;
		try
		{
			enumerator3 = orbitsForThisSatellite.Rows.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator3.Current;
				DarkTreeNode darkTreeNode3 = new DarkTreeNode(dataRow["MissonName"].ToString());
				DateTime dateTime = Conversions.ToDate(dataRow["LaunchDate"]);
				DateTime t = Conversions.ToDate(dataRow["DeOrbitingDate"]);
				if (DateTime.Compare(t, Client.CurrentScenario.Time) < 0 && DateTime.Compare(t, new DateTime(1900, 1, 1)) > 0)
				{
					darkTreeNode3.ForeColor = Color.Gray;
					darkTreeNode3.Text = Conversions.ToString(dataRow["MissonName"]) + "（不可用 - 已经离轨）";
				}
				else if (DateTime.Compare(dateTime, Client.CurrentScenario.Time) < 0)
				{
					darkTreeNode3.Text = Conversions.ToString(dataRow["MissonName"]) + "（在轨道上）";
				}
				else
				{
					darkTreeNode3.Text = string.Concat(str2: Misc.UpdateRequest((long)Math.Round((dateTime - Client.CurrentScenario.Time).TotalSeconds)), str0: Conversions.ToString(dataRow["MissonName"]), str1: "（将在", str3: ")");
				}
				darkTreeNode3.Tag = "Spacecraft_" + dataRow["ID"].ToString() + "_" + dataRow["ComponentNumber"].ToString();
				darkTreeNode_0.Nodes.Add(darkTreeNode3);
				PopulateNodesChildren(darkTreeNode3);
			}
		}
		finally
		{
			if (enumerator3 is IDisposable)
			{
				(enumerator3 as IDisposable).Dispose();
			}
		}
	}

	private void SetFilter(object sender, EventArgs e)
	{
		int num = 0;
		bool flag = false;
		foreach (DarkTreeNode selectedNode in TreeView1.SelectedNodes)
		{
			string text = Conversions.ToString(selectedNode.Tag);
			if (Information.IsNothing(text) || Operators.CompareString(text.Split('_')[0], "Spacecraft", TextCompare: true) != 0 || !(selectedNode.ForeColor != Color.Gray))
			{
				continue;
			}
			string text2 = text.Split('_')[1] + "_" + text.Split('_')[2];
			foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
			{
				if (!Information.IsNothing(activeUnits_) && activeUnits_.IsSatellite && string.CompareOrdinal(((Satellite)activeUnits_).SpacecraftID, text2) == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Client.CurrentScenario.AddNewSatellite(Client.CurrentSide, "", Conversions.ToInteger(text.Split('_')[1]), Conversions.ToInteger(text.Split('_')[2])).SpacecraftID = text2;
				num++;
			}
		}
		if (num > 0)
		{
			Label1.Visible = true;
			Label1.Text = Conversions.ToString(num) + "卫星被添加到想定中。";
			Client.MustRefreshMainForm = true;
		}
	}

	private void FillFilter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Space && e.KeyCode != Keys.Add && e.KeyCode != Keys.Subtract))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CalculateFilter(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	[CompilerGenerated]
	private bool PopFilter(object object_0)
	{
		return Operators.CompareString(Conversions.ToString(((DataRow)object_0)["CountryString"]), exceptionProperty, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool InstantiateFilter(object object_0)
	{
		return (Operators.CompareString(Conversions.ToString(((DataRow)object_0)["TypeString"]), m_AttrProperty, TextCompare: true) == 0) & (Operators.CompareString(Conversions.ToString(((DataRow)object_0)["CountryString"]), exceptionProperty, TextCompare: true) == 0);
	}
}
