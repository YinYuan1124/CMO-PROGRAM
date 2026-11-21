using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
public sealed class AreaEditor : DarkUserControl, GInterface9
{
	private IContainer _TemplateRepository;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private DarkGroupBox mappingRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox1")]
	private DarkListView m_MockRepository;

	[AccessedThroughProperty("Button_AddHighlighted")]
	[CompilerGenerated]
	private DarkUIButton _TagRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ListUp")]
	private DarkButton fieldRepository;

	[AccessedThroughProperty("Button_ListDown")]
	[CompilerGenerated]
	private DarkButton m_QueueRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveSelected")]
	private DarkUIButton _RegRepository;

	[AccessedThroughProperty("Button_HighLightCenterOnSelected")]
	[CompilerGenerated]
	private DarkUIButton _ParamRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ValidateArea")]
	private DarkUIButton m_PageRepository;

	[AccessedThroughProperty("ButtonPickArea")]
	[CompilerGenerated]
	private DarkUIButton _RulesRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CreateArea")]
	private DarkUIButton serviceRepository;

	public List<ReferencePoint> AreaPoints;

	private string m_SystemRepository;

	internal DarkGroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return mappingRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingRepository = value;
		}
	}

	internal DarkListView ListBox1
	{
		[CompilerGenerated]
		get
		{
			return m_MockRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockRepository = value;
		}
	}

	internal DarkUIButton Button_AddHighlighted
	{
		[CompilerGenerated]
		get
		{
			return _TagRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapCustomer;
			DarkUIButton tagRepository = _TagRepository;
			if (tagRepository != null)
			{
				tagRepository.Click -= value2;
			}
			_TagRepository = value;
			tagRepository = _TagRepository;
			if (tagRepository != null)
			{
				tagRepository.Click += value2;
			}
		}
	}

	internal DarkButton Button_ListUp
	{
		[CompilerGenerated]
		get
		{
			return fieldRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcCustomer;
			DarkButton darkButton = fieldRepository;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			fieldRepository = value;
			darkButton = fieldRepository;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkButton Button_ListDown
	{
		[CompilerGenerated]
		get
		{
			return m_QueueRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateCustomer;
			DarkButton queueRepository = m_QueueRepository;
			if (queueRepository != null)
			{
				queueRepository.Click -= value2;
			}
			m_QueueRepository = value;
			queueRepository = m_QueueRepository;
			if (queueRepository != null)
			{
				queueRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveSelected
	{
		[CompilerGenerated]
		get
		{
			return _RegRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortCustomer;
			DarkUIButton regRepository = _RegRepository;
			if (regRepository != null)
			{
				regRepository.Click -= value2;
			}
			_RegRepository = value;
			regRepository = _RegRepository;
			if (regRepository != null)
			{
				regRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_HighLightCenterOnSelected
	{
		[CompilerGenerated]
		get
		{
			return _ParamRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushCustomer;
			DarkUIButton paramRepository = _ParamRepository;
			if (paramRepository != null)
			{
				paramRepository.Click -= value2;
			}
			_ParamRepository = value;
			paramRepository = _ParamRepository;
			if (paramRepository != null)
			{
				paramRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ValidateArea
	{
		[CompilerGenerated]
		get
		{
			return m_PageRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotCustomer;
			DarkUIButton pageRepository = m_PageRepository;
			if (pageRepository != null)
			{
				pageRepository.Click -= value2;
			}
			m_PageRepository = value;
			pageRepository = m_PageRepository;
			if (pageRepository != null)
			{
				pageRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton ButtonPickArea
	{
		[CompilerGenerated]
		get
		{
			return _RulesRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterCustomer;
			DarkUIButton rulesRepository = _RulesRepository;
			if (rulesRepository != null)
			{
				rulesRepository.Click -= value2;
			}
			_RulesRepository = value;
			rulesRepository = _RulesRepository;
			if (rulesRepository != null)
			{
				rulesRepository.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal DarkGroupBox DarkGroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_CreateArea
	{
		[CompilerGenerated]
		get
		{
			return serviceRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderCustomer;
			DarkUIButton darkUIButton = serviceRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			serviceRepository = value;
			darkUIButton = serviceRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public string Title
	{
		get
		{
			return m_SystemRepository;
		}
		set
		{
			m_SystemRepository = value;
			GroupBox1.Text = value;
		}
	}

	public AreaEditor()
	{
		base.Load += CollectCustomer;
		QueryCustomer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _TemplateRepository != null)
			{
				_TemplateRepository.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void QueryCustomer()
	{
		GroupBox1 = new DarkGroupBox();
		DarkGroupBox2 = new DarkGroupBox();
		Button_ListDown = new DarkButton();
		Button_ListUp = new DarkButton();
		ListBox1 = new DarkListView();
		Button_CreateArea = new DarkUIButton();
		ButtonPickArea = new DarkUIButton();
		Button_ValidateArea = new DarkUIButton();
		Button_HighLightCenterOnSelected = new DarkUIButton();
		Button_RemoveSelected = new DarkUIButton();
		Button_AddHighlighted = new DarkUIButton();
		GroupBox1.SuspendLayout();
		DarkGroupBox2.SuspendLayout();
		SuspendLayout();
		GroupBox1.Controls.Add(DarkGroupBox2);
		GroupBox1.Controls.Add(Button_ValidateArea);
		GroupBox1.Controls.Add(Button_HighLightCenterOnSelected);
		GroupBox1.Controls.Add(Button_RemoveSelected);
		GroupBox1.Controls.Add(Button_ListDown);
		GroupBox1.Controls.Add(Button_ListUp);
		GroupBox1.Controls.Add(Button_AddHighlighted);
		GroupBox1.Controls.Add(ListBox1);
		GroupBox1.Dock = DockStyle.Fill;
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(0, 0);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(351, 124);
		GroupBox1.TabIndex = 0;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "标题";
		DarkGroupBox2.Controls.Add(Button_CreateArea);
		DarkGroupBox2.Controls.Add(ButtonPickArea);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(6, 13);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(115, 105);
		DarkGroupBox2.TabIndex = 9;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "区域/参考点管理";
		Button_ListDown.BackColor = Color.Transparent;
		Button_ListDown.BackgroundImage = QResourceHelper.GetImage("Button_ListDown.BackgroundImage");
		Button_ListDown.Font = new Font("Segoe UI", 10f);
		Button_ListDown.Image = QResourceHelper.GetImage("Button_ListDown.Image");
		Button_ListDown.Location = new Point(222, 63);
		Button_ListDown.Name = "Button_ListDown";
		Button_ListDown.Padding = new Padding(5);
		Button_ListDown.Size = new Size(15, 24);
		Button_ListDown.TabIndex = 3;
		Button_ListUp.BackColor = Color.Transparent;
		Button_ListUp.BackgroundImage = QResourceHelper.GetImage("Button_ListUp.BackgroundImage");
		Button_ListUp.Font = new Font("Segoe UI", 10f);
		Button_ListUp.Image = QResourceHelper.GetImage("Button_ListUp.Image");
		Button_ListUp.Location = new Point(222, 33);
		Button_ListUp.Name = "Button_ListUp";
		Button_ListUp.Padding = new Padding(5);
		Button_ListUp.Size = new Size(15, 24);
		Button_ListUp.TabIndex = 2;
		ListBox1.BackColor = Color.FromArgb(70, 73, 75);
		ListBox1.Location = new Point(127, 11);
		ListBox1.MultiSelect = true;
		ListBox1.Name = "ListBox1";
		ListBox1.RelatedInfos = null;
		ListBox1.Size = new Size(90, 105);
		ListBox1.TabIndex = 0;
		Button_CreateArea.BackColor = Color.Transparent;
		Button_CreateArea.DialogResult = DialogResult.None;
		Button_CreateArea.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CreateArea.ForeColor = SystemColors.Control;
		Button_CreateArea.Location = new Point(3, 70);
		Button_CreateArea.Name = "Button_CreateArea";
		Button_CreateArea.RoundRadius = 0;
		Button_CreateArea.Size = new Size(106, 29);
		Button_CreateArea.TabIndex = 8;
		Button_CreateArea.Text = "创建区域";
		ButtonPickArea.BackColor = Color.Transparent;
		ButtonPickArea.DialogResult = DialogResult.None;
		ButtonPickArea.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ButtonPickArea.ForeColor = SystemColors.Control;
		ButtonPickArea.Location = new Point(3, 19);
		ButtonPickArea.Name = "ButtonPickArea";
		ButtonPickArea.RoundRadius = 0;
		ButtonPickArea.Size = new Size(106, 45);
		ButtonPickArea.TabIndex = 7;
		ButtonPickArea.Text = "选择区域";
		Button_ValidateArea.BackColor = Color.Transparent;
		Button_ValidateArea.DialogResult = DialogResult.None;
		Button_ValidateArea.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ValidateArea.ForeColor = SystemColors.Control;
		Button_ValidateArea.Location = new Point(241, 102);
		Button_ValidateArea.Name = "Button_ValidateArea";
		Button_ValidateArea.RoundRadius = 0;
		Button_ValidateArea.Size = new Size(107, 18);
		Button_ValidateArea.TabIndex = 6;
		Button_ValidateArea.Text = "验证区域";
		Button_HighLightCenterOnSelected.BackColor = Color.Transparent;
		Button_HighLightCenterOnSelected.DialogResult = DialogResult.None;
		Button_HighLightCenterOnSelected.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_HighLightCenterOnSelected.ForeColor = SystemColors.Control;
		Button_HighLightCenterOnSelected.Location = new Point(241, 56);
		Button_HighLightCenterOnSelected.Name = "Button_HighLightCenterOnSelected";
		Button_HighLightCenterOnSelected.RoundRadius = 0;
		Button_HighLightCenterOnSelected.Size = new Size(107, 28);
		Button_HighLightCenterOnSelected.TabIndex = 5;
		Button_HighLightCenterOnSelected.Text = "高亮并居中";
		Button_RemoveSelected.BackColor = Color.Transparent;
		Button_RemoveSelected.DialogResult = DialogResult.None;
		Button_RemoveSelected.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_RemoveSelected.ForeColor = SystemColors.Control;
		Button_RemoveSelected.Location = new Point(241, 85);
		Button_RemoveSelected.Name = "Button_RemoveSelected";
		Button_RemoveSelected.RoundRadius = 0;
		Button_RemoveSelected.Size = new Size(107, 16);
		Button_RemoveSelected.TabIndex = 4;
		Button_RemoveSelected.Text = "删除";
		Button_AddHighlighted.BackColor = Color.Transparent;
		Button_AddHighlighted.DialogResult = DialogResult.None;
		Button_AddHighlighted.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_AddHighlighted.ForeColor = SystemColors.Control;
		Button_AddHighlighted.Location = new Point(241, 11);
		Button_AddHighlighted.Name = "Button_AddHighlighted";
		Button_AddHighlighted.RoundRadius = 0;
		Button_AddHighlighted.Size = new Size(107, 43);
		Button_AddHighlighted.TabIndex = 1;
		Button_AddHighlighted.Text = "添加地图上高亮的点";
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(GroupBox1);
		base.Name = "AreaEditor";
		base.Size = new Size(351, 124);
		GroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	public void ReleaseReferences()
	{
		try
		{
			AreaPoints = null;
			ListBox1.Items.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshForm()
	{
		ResetCustomer();
	}

	private void ResetCustomer()
	{
		if (Information.IsNothing(AreaPoints))
		{
			return;
		}
		ListBox1.Items.Clear();
		foreach (ReferencePoint item in AreaPoints.ToList())
		{
			DarkListItem darkListItem = new DarkListItem(item.Name);
			darkListItem.Tag = item;
			ListBox1.Items.Add(darkListItem);
		}
	}

	private void MapCustomer(object sender, EventArgs e)
	{
		foreach (ReferencePoint refPoint in Client.CurrentSide.RefPoints)
		{
			if (refPoint.IsHighlighted && !Information.IsNothing(AreaPoints) && !AreaPoints.Contains(refPoint))
			{
				DarkListItem darkListItem = new DarkListItem(refPoint.Name);
				AreaPoints.Add(refPoint);
				darkListItem.Tag = refPoint;
				ListBox1.Items.Add(darkListItem);
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void SortCustomer(object sender, EventArgs e)
	{
		if (Information.IsNothing(AreaPoints))
		{
			return;
		}
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			AreaPoints.Remove((ReferencePoint)selectedItem.Tag);
		}
		ResetCustomer();
		Client.MustRefreshMainForm = true;
	}

	private void CalcCustomer(object sender, EventArgs e)
	{
		if (ListBox1.SelectedItems.Count <= 1)
		{
			if (ListBox1.SelectedIndices.Count != 0)
			{
				int num = ListBox1.SelectedIndices[0];
				if (num != -1 && num > 0)
				{
					DarkListItem item = ListBox1.Items[num];
					ReferencePoint item2 = AreaPoints[num];
					ListBox1.Items.RemoveAt(num);
					AreaPoints.RemoveAt(num);
					num--;
					AreaPoints.Insert(num, item2);
					ListBox1.Items.Insert(num, item);
					ListBox1.SelectItem(num);
					Client.MustRefreshMainForm = true;
				}
			}
		}
		else
		{
			DarkMessageBox.ShowError("一次只能重新排列一个参考点", "一次一点！");
		}
	}

	private void RateCustomer(object sender, EventArgs e)
	{
		if (ListBox1.SelectedItems.Count <= 1)
		{
			if (ListBox1.SelectedIndices.Count != 0)
			{
				int num = ListBox1.SelectedIndices[0];
				if (num != -1 && num < ListBox1.Items.Count - 1)
				{
					DarkListItem item = ListBox1.Items[num];
					ReferencePoint item2 = AreaPoints[num];
					ListBox1.Items.RemoveAt(num);
					AreaPoints.RemoveAt(num);
					num++;
					AreaPoints.Insert(num, item2);
					ListBox1.Items.Insert(num, item);
					ListBox1.SelectItem(num);
					Client.MustRefreshMainForm = true;
				}
			}
		}
		else
		{
			DarkMessageBox.ShowError("一次只能重新排列一个参考点", "一次一点！");
		}
	}

	private void FlushCustomer(object sender, EventArgs e)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		if (Information.IsNothing(AreaPoints))
		{
			return;
		}
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			list.Add((ReferencePoint)selectedItem.Tag);
		}
		switch (list.Count)
		{
		default:
		{
			GeoPoint geoPoint_ = Misc.Center(list).DisableInvocation();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, geoPoint_);
			break;
		}
		case 1:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, list[0]);
			break;
		case 0:
			return;
		}
		foreach (ReferencePoint item in list)
		{
			item.IsHighlighted = true;
		}
		Client.MustRefreshMainForm = true;
	}

	private void ForgotCustomer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(AreaPoints))
		{
			string string_ = null;
			if (ActiveUnit_Navigator.ValidateArea(ref AreaPoints, ref string_, null, Client.CurrentScenario, ""))
			{
				DarkMessageBox.ShowInformation("区域验证正确。", "");
			}
			else
			{
				DarkMessageBox.ShowWarning(string_, "");
			}
		}
	}

	private void CollectCustomer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void OrderCustomer(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.ReferencePointManager.Show();
	}

	private void RegisterCustomer(object sender, EventArgs e)
	{
		List<Zone> list_ = new List<Zone>();
		List<ActiveUnit> list_2 = null;
		List<ReferencePoint> list_3 = null;
		UnitSelection.CallDialog(bool_0: false, ref list_2, ref list_3, ref list_, UnitSelection.UnitSelectionConfig.DefaultZone());
		if (list_ != null && list_.Count > 0)
		{
			AreaPoints.Clear();
			AreaPoints.AddRange(list_.ElementAt(0).Area);
			ResetCustomer();
			Client.MustRefreshMainForm = true;
		}
	}
}
