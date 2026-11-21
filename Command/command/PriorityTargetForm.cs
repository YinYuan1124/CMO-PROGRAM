using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class PriorityTargetForm : DarkSecondaryFormBase
{
	private IContainer _FilterSchema;

	[AccessedThroughProperty("CB_TargetUnitClass")]
	[CompilerGenerated]
	private DarkUIComboBox m_TestsSchema;

	[AccessedThroughProperty("CB_TargetSubtype")]
	[CompilerGenerated]
	private DarkUIComboBox _InterpreterSchema;

	[AccessedThroughProperty("CB_TargetType")]
	[CompilerGenerated]
	private DarkUIComboBox m_ContainerSchema;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_ComposerSchema;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel modelSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel advisorSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton customerSchema;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private DarkUIButton m_SerializerSchema;

	[AccessedThroughProperty("Check_ExistingTypes")]
	[CompilerGenerated]
	private DarkCheckBox _RefSchema;

	public Doctrine ParentDoctrine;

	public DoctrineForm MainDoctrineForm;

	public int InsertIndex;

	private bool errorSchema;

	internal virtual DarkUIComboBox CB_TargetUnitClass
	{
		[CompilerGenerated]
		get
		{
			return m_TestsSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleConnection;
			DarkUIComboBox testsSchema = m_TestsSchema;
			if (testsSchema != null)
			{
				testsSchema.SelectedIndexChanged -= value2;
			}
			m_TestsSchema = value;
			testsSchema = m_TestsSchema;
			if (testsSchema != null)
			{
				testsSchema.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetSubtype
	{
		[CompilerGenerated]
		get
		{
			return _InterpreterSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleConnection;
			DarkUIComboBox interpreterSchema = _InterpreterSchema;
			if (interpreterSchema != null)
			{
				interpreterSchema.SelectedIndexChanged -= value2;
			}
			_InterpreterSchema = value;
			interpreterSchema = _InterpreterSchema;
			if (interpreterSchema != null)
			{
				interpreterSchema.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetType
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptInterruptibleConnection;
			DarkUIComboBox containerSchema = m_ContainerSchema;
			if (containerSchema != null)
			{
				containerSchema.SelectedIndexChanged -= value2;
			}
			m_ContainerSchema = value;
			containerSchema = m_ContainerSchema;
			if (containerSchema != null)
			{
				containerSchema.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerSchema = value;
		}
	}

	internal virtual DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return modelSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelSchema = value;
		}
	}

	internal virtual DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return advisorSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			advisorSchema = value;
		}
	}

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return customerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleConnection;
			DarkUIButton darkUIButton = customerSchema;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			customerSchema = value;
			darkUIButton = customerSchema;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleConnection;
			DarkUIButton serializerSchema = m_SerializerSchema;
			if (serializerSchema != null)
			{
				serializerSchema.Click -= value2;
			}
			m_SerializerSchema = value;
			serializerSchema = m_SerializerSchema;
			if (serializerSchema != null)
			{
				serializerSchema.Click += value2;
			}
		}
	}

	internal virtual DarkCheckBox Check_ExistingTypes
	{
		[CompilerGenerated]
		get
		{
			return _RefSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleConnection;
			DarkCheckBox refSchema = _RefSchema;
			if (refSchema != null)
			{
				refSchema.CheckedChanged -= value2;
			}
			_RefSchema = value;
			refSchema = _RefSchema;
			if (refSchema != null)
			{
				refSchema.CheckedChanged += value2;
			}
		}
	}

	public PriorityTargetForm()
	{
		base.Load += delegate
		{
			PriorityTargetForm_Load();
		};
		InsertIndex = -1;
		errorSchema = false;
		SetupInterruptibleConnection();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _FilterSchema != null)
			{
				_FilterSchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SetupInterruptibleConnection()
	{
		Label4 = new DarkLabel();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Button_Cancel = new DarkUIButton();
		Button_OK = new DarkUIButton();
		CB_TargetUnitClass = new DarkUIComboBox();
		CB_TargetSubtype = new DarkUIComboBox();
		CB_TargetType = new DarkUIComboBox();
		Check_ExistingTypes = new DarkCheckBox();
		SuspendLayout();
		Label4.Anchor = AnchorStyles.Left;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(18, 106);
		Label4.Name = "Label4";
		Label4.Size = new Size(70, 15);
		Label4.TabIndex = 11;
		Label4.Text = "目标类型：";
		Label3.Anchor = AnchorStyles.Left;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(18, 74);
		Label3.Name = "Label3";
		Label3.Size = new Size(87, 15);
		Label3.TabIndex = 10;
		Label3.Text = "目标子类型：";
		Label2.Anchor = AnchorStyles.Left;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(18, 43);
		Label2.Name = "Label2";
		Label2.Size = new Size(68, 15);
		Label2.TabIndex = 9;
		Label2.Text = "目标类别：";
		Button_Cancel.Anchor = AnchorStyles.Bottom;
		Button_Cancel.BackColor = Color.Transparent;
		Button_Cancel.DialogResult = DialogResult.None;
		Button_Cancel.Font = new Font("Segoe UI", 10f);
		Button_Cancel.ForeColor = SystemColors.Control;
		Button_Cancel.Location = new Point(388, 165);
		Button_Cancel.Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		Button_Cancel.Size = new Size(104, 23);
		Button_Cancel.TabIndex = 16;
		Button_Cancel.Text = "取消";
		Button_OK.Anchor = AnchorStyles.Bottom;
		Button_OK.BackColor = Color.Transparent;
		Button_OK.DialogResult = DialogResult.None;
		Button_OK.Font = new Font("Segoe UI", 10f);
		Button_OK.ForeColor = SystemColors.Control;
		Button_OK.Location = new Point(213, 165);
		Button_OK.Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		Button_OK.Size = new Size(95, 23);
		Button_OK.TabIndex = 15;
		Button_OK.Text = "添加";
		CB_TargetUnitClass.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CB_TargetUnitClass.BackColor = Color.Transparent;
		CB_TargetUnitClass.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetUnitClass.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetUnitClass.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetUnitClass.FormattingEnabled = true;
		CB_TargetUnitClass.Location = new Point(107, 103);
		CB_TargetUnitClass.Name = "CB_TargetUnitClass";
		CB_TargetUnitClass.Size = new Size(571, 21);
		CB_TargetUnitClass.TabIndex = 14;
		CB_TargetSubtype.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CB_TargetSubtype.BackColor = Color.Transparent;
		CB_TargetSubtype.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetSubtype.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetSubtype.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetSubtype.FormattingEnabled = true;
		CB_TargetSubtype.Location = new Point(107, 71);
		CB_TargetSubtype.Name = "CB_TargetSubtype";
		CB_TargetSubtype.Size = new Size(571, 21);
		CB_TargetSubtype.TabIndex = 13;
		CB_TargetType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		CB_TargetType.BackColor = Color.Transparent;
		CB_TargetType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetType.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetType.FormattingEnabled = true;
		CB_TargetType.Items.AddRange(new object[8] { "无", "飞机", "水面舰艇", "潜艇", "地面设施", "-------", "武器", "卫星" });
		CB_TargetType.Location = new Point(107, 40);
		CB_TargetType.Name = "CB_TargetType";
		CB_TargetType.Size = new Size(571, 21);
		CB_TargetType.TabIndex = 12;
		Check_ExistingTypes.Anchor = AnchorStyles.Left;
		Check_ExistingTypes.Location = new Point(107, 133);
		Check_ExistingTypes.Name = "Check_ExistingTypes";
		Check_ExistingTypes.Size = new Size(337, 17);
		Check_ExistingTypes.TabIndex = 17;
		Check_ExistingTypes.Text = "Limit subtypes and classes to those present in this scenario";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(704, 201);
		base.Controls.Add(Check_ExistingTypes);
		base.Controls.Add(Button_Cancel);
		base.Controls.Add(Button_OK);
		base.Controls.Add(CB_TargetUnitClass);
		base.Controls.Add(CB_TargetSubtype);
		base.Controls.Add(CB_TargetType);
		base.Controls.Add(Label4);
		base.Controls.Add(Label3);
		base.Controls.Add(Label2);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(480, 240);
		base.Name = "PriorityTargetForm";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Add Priority Target Entry";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void PriorityTargetForm_Load()
	{
		if (ParentDoctrine == null)
		{
			Close();
			return;
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit && Client.CurrentGame.GameMode != Game._GameMode.MultiplayerScenEdit)
		{
			Check_ExistingTypes.Visible = false;
			errorSchema = false;
		}
		else
		{
			Check_ExistingTypes.Visible = true;
		}
		Check_ExistingTypes.Checked = errorSchema;
		RefreshForm();
	}

	private void ExcludeInterruptibleConnection()
	{
		Doctrine.PriorityTargetEntry.PopulateUnitTypeList(CB_TargetType);
		CB_TargetType.SelectedIndex = 0;
	}

	private GlobalVariables.ActiveUnitType IncludeInterruptibleConnection()
	{
		if (CB_TargetType.SelectedIndex >= 0 && CB_TargetType.DataSource != null)
		{
			return (GlobalVariables.ActiveUnitType)Conversions.ToByte(((DataTable)CB_TargetType.DataSource).Rows[CB_TargetType.SelectedIndex][0]);
		}
		return GlobalVariables.ActiveUnitType.None;
	}

	private int SearchInterruptibleConnection()
	{
		if (CB_TargetSubtype.SelectedIndex >= 0 && CB_TargetSubtype.DataSource != null)
		{
			return Conversions.ToInteger(((DataTable)CB_TargetSubtype.DataSource).Rows[CB_TargetSubtype.SelectedIndex][0]);
		}
		return 0;
	}

	private int EnableInterruptibleConnection()
	{
		if (CB_TargetUnitClass.SelectedIndex > 0 && CB_TargetUnitClass.DataSource != null)
		{
			return Conversions.ToInteger(((DataTable)CB_TargetUnitClass.DataSource).Rows[CB_TargetUnitClass.SelectedIndex][0]);
		}
		return 0;
	}

	private void ChangeInterruptibleConnection()
	{
		GlobalVariables.ActiveUnitType activeUnitType_ = IncludeInterruptibleConnection();
		Doctrine.PriorityTargetEntry.PopulateUnitSubTypeList(CB_TargetSubtype, activeUnitType_, Client.CurrentScenario, Check_ExistingTypes.Checked);
		CB_TargetSubtype.SelectedIndex = 0;
	}

	private void InitInterruptibleConnection()
	{
		GlobalVariables.ActiveUnitType activeUnitType_ = IncludeInterruptibleConnection();
		int int_ = SearchInterruptibleConnection();
		Doctrine.PriorityTargetEntry.PopulateDBIDList(CB_TargetUnitClass, activeUnitType_, int_, Client.CurrentScenario, Check_ExistingTypes.Checked);
		CB_TargetUnitClass.SelectedIndex = 0;
	}

	public void RefreshForm()
	{
		ExcludeInterruptibleConnection();
	}

	private void CheckInterruptibleConnection(object sender, EventArgs e)
	{
		GlobalVariables.ActiveUnitType activeUnitType_ = IncludeInterruptibleConnection();
		int int_ = SearchInterruptibleConnection();
		int int_2 = EnableInterruptibleConnection();
		ParentDoctrine.AddPriorityTargetListEntry(activeUnitType_, int_, int_2, InsertIndex);
		MainDoctrineForm.RefreshPriorityTargetList(ParentDoctrine, InsertIndex);
		Close();
	}

	private void ConcatInterruptibleConnection(object sender, EventArgs e)
	{
		Close();
	}

	private void InterruptInterruptibleConnection(object sender, EventArgs e)
	{
		ChangeInterruptibleConnection();
	}

	private void RemoveInterruptibleConnection(object sender, EventArgs e)
	{
		InitInterruptibleConnection();
	}

	private void FindInterruptibleConnection(object sender, EventArgs e)
	{
	}

	private void SetInterruptibleConnection(object sender, EventArgs e)
	{
		if (Check_ExistingTypes.Checked)
		{
			if (!errorSchema)
			{
				errorSchema = true;
				RefreshForm();
			}
		}
		else if (errorSchema)
		{
			errorSchema = false;
			RefreshForm();
		}
	}

	[CompilerGenerated]
	private void FillInterruptibleConnection(object sender, EventArgs e)
	{
		PriorityTargetForm_Load();
	}
}
