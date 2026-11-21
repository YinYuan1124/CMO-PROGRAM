using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ORBAT : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class QueueThreadBridge
	{
		public ORBAT Me;

		public TreeGridNode Local_theNode;

		internal void OrderInterruptibleRules()
		{
			Me.TGV_Contacts.Nodes.Remove(Local_theNode);
		}
	}

	[CompilerGenerated]
	private sealed class RequestProcessProducer
	{
		public ORBAT _003C_003E4__this;

		public Contact contact;

		internal void RegisterInterruptibleRules()
		{
			TreeGridNode treeGridNode = _003C_003E4__this.TGV_Contacts.Nodes.Add();
			_003C_003E4__this.ExcludeInterruptibleError(treeGridNode, contact);
			if (contact.ActualUnit.IsGroup && ((Group)contact.ActualUnit).IsLandInstallation)
			{
				treeGridNode.Nodes.Add("temp");
			}
		}
	}

	[CompilerGenerated]
	private sealed class FieldMap
	{
		public ORBAT _003C_003E4__this;

		public Contact contact;

		internal void ManageInterruptibleRules()
		{
			TreeGridNode treeGridNode = _003C_003E4__this.TGV_Contacts.Nodes.Add();
			_003C_003E4__this.ExcludeInterruptibleError(treeGridNode, contact);
			treeGridNode.Nodes.Add("temp");
		}
	}

	[CompilerGenerated]
	private sealed class QueueMap
	{
		public ORBAT _003C_003E4__this;

		public Scenario scenario_0;

		public string string_0;

		public string string_1;

		internal void RevertInterruptibleRules()
		{
			_003C_003E4__this.ConnectInterruptibleError(scenario_0, string_0, string_1);
		}

		internal bool CountInterruptibleMethod(Side s)
		{
			return Operators.CompareString(s.ObjectID, string_1, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class WorkerMerchantService
	{
		public ORBAT Me;

		public ActiveUnit Local_theAU;

		public DarkFilterTreeNode Local_theNode;

		internal void CustomizeInterruptibleMethod()
		{
			Local_theNode.Text = Me.WriteInterruptibleError(Local_theAU);
		}
	}

	[CompilerGenerated]
	private sealed class VisitorRegistryFilter
	{
		public ORBAT Me;

		public ActiveUnit Local_theAU;

		internal bool CloneInterruptibleMethod(DarkFilterTreeNode theNode)
		{
			return theNode.Tag == Local_theAU.GetParentGroup();
		}
	}

	[CompilerGenerated]
	private sealed class SpecificationListenerMapping
	{
		public DarkFilterTreeNode Local_NewNode;

		public ActiveUnit Local_UnitCurrentHost;

		public VisitorRegistryFilter CS_0024_003C_003E8__locals1;

		internal void ConnectInterruptibleMethod()
		{
			string text = CS_0024_003C_003E8__locals1.Me.WriteInterruptibleError(CS_0024_003C_003E8__locals1.Local_theAU);
			if (CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Nodes.Count == 0)
			{
				Local_NewNode = new DarkFilterTreeNode();
				Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
				Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
				Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
				Local_NewNode.Text = text;
				Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
				CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Nodes.Add(Local_NewNode);
				Local_NewNode.EnsureVisible();
			}
			else
			{
				foreach (DarkFilterTreeNode node in CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Nodes)
				{
					try
					{
						if (node.Text.CompareTo(text) > 0)
						{
							Local_NewNode = new DarkFilterTreeNode();
							Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
							Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
							Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
							Local_NewNode.Text = text;
							Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
							CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Nodes.Insert(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Nodes.IndexOf(node), Local_NewNode);
							Local_NewNode.EnsureVisible();
							break;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 523253955t751", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			CS_0024_003C_003E8__locals1.Me.TV_ByGroup.UpdateNodes();
		}

		internal void MoveInterruptibleMethod()
		{
			string text = CS_0024_003C_003E8__locals1.Me.WriteInterruptibleError(CS_0024_003C_003E8__locals1.Local_theAU);
			DarkFilterTreeNode darkFilterTreeNode = (from theNode in InterpreterObjectListener.DefineInterruptibleTask(CS_0024_003C_003E8__locals1.Me.TV_ByGroup)
				where theNode.Tag == CS_0024_003C_003E8__locals1.Local_theAU.GetParentGroup()
				select theNode).FirstOrDefault();
			if (darkFilterTreeNode == null)
			{
				return;
			}
			if (darkFilterTreeNode.Nodes.Count == 0)
			{
				Local_NewNode = new DarkFilterTreeNode();
				Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
				Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
				Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
				Local_NewNode.Text = text;
				Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
				darkFilterTreeNode.Nodes.Add(Local_NewNode);
			}
			else
			{
				bool flag = false;
				foreach (DarkFilterTreeNode node in darkFilterTreeNode.Nodes)
				{
					if (node.Text.CompareTo(text) > 0)
					{
						Local_NewNode = new DarkFilterTreeNode();
						Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
						Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
						Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
						Local_NewNode.Text = text;
						Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
						darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(node), Local_NewNode);
						Local_NewNode.EnsureVisible();
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Local_NewNode = new DarkFilterTreeNode();
					Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
					Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
					Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
					Local_NewNode.Text = text;
					Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
					darkFilterTreeNode.Nodes.Add(Local_NewNode);
					Local_NewNode.EnsureVisible();
				}
			}
			CS_0024_003C_003E8__locals1.Me.TV_ByGroup.UpdateNodes();
		}

		internal void DeleteInterruptibleMethod()
		{
			string text = CS_0024_003C_003E8__locals1.Me.WriteInterruptibleError(CS_0024_003C_003E8__locals1.Local_theAU);
			DarkFilterTreeNode darkFilterTreeNode = (from theNode in InterpreterObjectListener.DefineInterruptibleTask(CS_0024_003C_003E8__locals1.Me.TV_ByGroup)
				where theNode.Tag == Local_UnitCurrentHost
				select theNode).FirstOrDefault();
			if (darkFilterTreeNode == null)
			{
				return;
			}
			if (darkFilterTreeNode.Nodes.Count == 0)
			{
				Local_NewNode = new DarkFilterTreeNode();
				Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
				Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
				Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
				Local_NewNode.Text = text;
				Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
				darkFilterTreeNode.Nodes.Add(Local_NewNode);
				Local_NewNode.EnsureVisible();
			}
			else
			{
				bool flag = false;
				foreach (DarkFilterTreeNode node in darkFilterTreeNode.Nodes)
				{
					if (node.Text.CompareTo(text) > 0)
					{
						Local_NewNode = new DarkFilterTreeNode();
						Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
						Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
						Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
						Local_NewNode.Text = text;
						Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
						darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(node), Local_NewNode);
						Local_NewNode.EnsureVisible();
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Local_NewNode = new DarkFilterTreeNode();
					Local_NewNode.Tag = CS_0024_003C_003E8__locals1.Local_theAU;
					Local_NewNode.Font = new Font(CS_0024_003C_003E8__locals1.Me.TV_ByGroup.Font, FontStyle.Regular);
					Local_NewNode.ForeColor = CS_0024_003C_003E8__locals1.Me.GetUnitProficiencyColor(CS_0024_003C_003E8__locals1.Local_theAU);
					Local_NewNode.Text = text;
					Local_NewNode.ParentTree = CS_0024_003C_003E8__locals1.Me.TV_ByGroup;
					darkFilterTreeNode.Nodes.Add(Local_NewNode);
					Local_NewNode.EnsureVisible();
				}
			}
			CS_0024_003C_003E8__locals1.Me.TV_ByGroup.UpdateNodes();
		}

		internal bool AddInterruptibleMethod(DarkFilterTreeNode theNode)
		{
			return theNode.Tag == Local_UnitCurrentHost;
		}

		internal void DestroyInterruptibleMethod()
		{
			Local_NewNode.Expanded = true;
			CS_0024_003C_003E8__locals1.Me.TV_ByGroup.UpdateNodes();
		}
	}

	[CompilerGenerated]
	private sealed class RegMap
	{
		public DarkFilterTreeNode Local_NodeToRemove;

		public ORBAT Me;

		internal void ComputeInterruptibleMethod()
		{
			if (Information.IsNothing(Local_NodeToRemove.ParentNode))
			{
				Me.TV_ByGroup.Nodes.Remove(Local_NodeToRemove);
			}
			else
			{
				Local_NodeToRemove.ParentNode.Nodes.Remove(Local_NodeToRemove);
			}
			Me.TV_ByGroup.UpdateNodes();
		}
	}

	[CompilerGenerated]
	private sealed class ParamMap
	{
		public ORBAT Me;

		public DarkFilterTreeNode Local_NodeToRemove;

		internal void PatchInterruptibleMethod()
		{
			if (Information.IsNothing(Local_NodeToRemove.ParentNode))
			{
				Me.TV_ByMission.Nodes.Remove(Local_NodeToRemove);
			}
			else
			{
				Local_NodeToRemove.ParentNode.Nodes.Remove(Local_NodeToRemove);
			}
			Me.TV_ByMission.UpdateNodes();
		}
	}

	[CompilerGenerated]
	private sealed class PageMap
	{
		public ActiveUnit Local_theAU;

		public ORBAT Me;

		internal void SelectInterruptibleMethod()
		{
			DarkFilterTreeNode darkFilterTreeNode = null;
			_ = Local_theAU.UnitType;
			string text = Me.WriteInterruptibleError(Local_theAU);
			bool flag = false;
			DarkFilterTreeNode darkFilterTreeNode2 = (from theNode in InterpreterObjectListener.DefineInterruptibleTask(Me.TV_ByType)
				where theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == (int)Local_theAU.UnitType
				select theNode).FirstOrDefault();
			if (darkFilterTreeNode2 == null)
			{
				darkFilterTreeNode2 = new DarkFilterTreeNode
				{
					Tag = (int)Local_theAU.UnitType,
					Font = new Font(Me.TV_ByType.Font, FontStyle.Regular),
					ForeColor = Color.White,
					Text = Local_theAU.UnitType_String,
					ParentTree = Me.TV_ByType
				};
				flag = true;
			}
			DarkFilterTreeNode darkFilterTreeNode3 = darkFilterTreeNode2.Nodes.Where((DarkFilterTreeNode theNode) => theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == Local_theAU.SubType).FirstOrDefault();
			if (darkFilterTreeNode3 == null)
			{
				darkFilterTreeNode3 = new DarkFilterTreeNode
				{
					Tag = Local_theAU.SubType,
					Font = new Font(Me.TV_ByType.Font, FontStyle.Regular),
					ForeColor = Color.White,
					Text = Local_theAU.SubTypeDescription,
					ParentTree = Me.TV_ByType
				};
				darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
			}
			darkFilterTreeNode = new DarkFilterTreeNode
			{
				Tag = Local_theAU,
				Font = new Font(Me.TV_ByType.Font, FontStyle.Regular),
				ForeColor = Me.GetUnitProficiencyColor(Local_theAU),
				Text = text,
				ParentTree = Me.TV_ByType
			};
			darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode);
			if (flag)
			{
				Me.TV_ByType.Nodes.Add(darkFilterTreeNode2);
				darkFilterTreeNode2.EnsureVisible();
			}
		}

		internal bool CallInterruptibleMethod(DarkFilterTreeNode theNode)
		{
			if (theNode.Tag.GetType().IsPrimitive)
			{
				return Conversions.ToInteger(theNode.Tag) == (int)Local_theAU.UnitType;
			}
			return false;
		}

		internal bool LogoutInterruptibleMethod(DarkFilterTreeNode theNode)
		{
			if (theNode.Tag.GetType().IsPrimitive)
			{
				return Conversions.ToInteger(theNode.Tag) == Local_theAU.SubType;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RulesMap
	{
		public ORBAT Me;

		public DarkFilterTreeNode Local_NodeToRemove;

		internal void ViewInterruptibleMethod()
		{
			if (Information.IsNothing(Local_NodeToRemove.ParentNode))
			{
				Me.TV_ByType.Nodes.Remove(Local_NodeToRemove);
			}
			else
			{
				Local_NodeToRemove.ParentNode.Nodes.Remove(Local_NodeToRemove);
			}
			Me.TV_ByType.UpdateNodes();
		}
	}

	[CompilerGenerated]
	private sealed class MethodMap
	{
		public ORBAT _003C_003E4__this;

		public Scenario scenario_0;

		public string string_0;

		internal void ValidateInterruptibleMethod()
		{
			_003C_003E4__this.LogoutInterruptibleError(scenario_0, string_0);
		}
	}

	[CompilerGenerated]
	private sealed class PageCallbackCandidate
	{
		public ORBAT _003C_003E4__this;

		public Scenario scenario_0;

		public ActiveUnit activeUnit_0;

		internal void LoginInterruptibleMethod()
		{
			_003C_003E4__this.ViewInterruptibleError(scenario_0, activeUnit_0);
		}
	}

	[CompilerGenerated]
	private sealed class ProccesorObjectListener
	{
		public ActiveUnit Local_theAU;

		internal bool GetInterruptibleMethod(DarkFilterTreeNode theNode)
		{
			return Conversions.ToInteger(theNode.Tag) == (int)Local_theAU.UnitType;
		}

		internal bool WriteInterruptibleMethod(DarkFilterTreeNode theNode)
		{
			return Conversions.ToInteger(theNode.Tag) == Local_theAU.SubType;
		}
	}

	private IContainer _CandidateAdapter;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	private DarkUITabControl baseAdapter;

	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage m_BroadcasterAdapter;

	[AccessedThroughProperty("Label_SetUnitProficiency")]
	[CompilerGenerated]
	private DarkLabel printerAdapter;

	[AccessedThroughProperty("CB_Proficiency")]
	[CompilerGenerated]
	private DarkUIComboBox parserAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_ByGroup")]
	private DarkFilterTreeView m_AlgoAdapter;

	[AccessedThroughProperty("TV_ByMission")]
	[CompilerGenerated]
	private DarkFilterTreeView databaseAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_SearchOOB")]
	private DarkTextBox _MessageAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage3")]
	private TabPage productAdapter;

	[AccessedThroughProperty("TV_ByType")]
	[CompilerGenerated]
	private DarkFilterTreeView annotationAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage4")]
	private TabPage m_IteratorAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Contacts")]
	private DarkTreeGridView m_InitializerAdapter;

	[AccessedThroughProperty("ContactName")]
	[CompilerGenerated]
	private TreeGridColumn m_RoleAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("ContactPosture")]
	private DataGridViewTextBoxColumn m_AttributeAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("ContactBDA")]
	private DataGridViewTextBoxColumn m_EventAdapter;

	[AccessedThroughProperty("ContactHostedUnits")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_GlobalAdapter;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private System.Windows.Forms.Timer workerAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("btnEXPCOL")]
	private DarkUIButton accountAdapter;

	private bool stateAdapter;

	private bool _AuthenticationAdapter;

	private bool paramsAdapter;

	private bool m_InfoAdapter;

	private bool helperAdapter;

	private bool _MapperAdapter;

	private bool m_ManagerAdapter;

	private bool m_GetterAdapter;

	private object m_ProducerAdapter;

	private object procAdapter;

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return baseAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleError;
			DarkUITabControl darkUITabControl = baseAdapter;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged -= value2;
			}
			baseAdapter = value;
			darkUITabControl = baseAdapter;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BroadcasterAdapter = value;
		}
	}

	[field: AccessedThroughProperty("Label_Proficiency")]
	internal DarkLabel Label_Proficiency
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_SetUnitProficiency
	{
		[CompilerGenerated]
		get
		{
			return printerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerAdapter = value;
		}
	}

	internal DarkUIComboBox CB_Proficiency
	{
		[CompilerGenerated]
		get
		{
			return parserAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleError;
			DarkUIComboBox darkUIComboBox = parserAdapter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			parserAdapter = value;
			darkUIComboBox = parserAdapter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkFilterTreeView TV_ByGroup
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleError;
			DarkFilterTreeView algoAdapter = m_AlgoAdapter;
			if (algoAdapter != null)
			{
				algoAdapter.SelectedNodesChanged -= value2;
			}
			m_AlgoAdapter = value;
			algoAdapter = m_AlgoAdapter;
			if (algoAdapter != null)
			{
				algoAdapter.SelectedNodesChanged += value2;
			}
		}
	}

	internal DarkFilterTreeView TV_ByMission
	{
		[CompilerGenerated]
		get
		{
			return databaseAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleError;
			MouseEventHandler value3 = InterruptInterruptibleError;
			DarkFilterTreeView darkFilterTreeView = databaseAdapter;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged -= value2;
				darkFilterTreeView.MouseDoubleClick -= value3;
			}
			databaseAdapter = value;
			darkFilterTreeView = databaseAdapter;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged += value2;
				darkFilterTreeView.MouseDoubleClick += value3;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkTextBox TB_SearchOOB
	{
		[CompilerGenerated]
		get
		{
			return _MessageAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillInterruptibleError;
			KeyPressEventHandler value3 = CalculateInterruptibleError;
			DarkTextBox messageAdapter = _MessageAdapter;
			if (messageAdapter != null)
			{
				messageAdapter.TextChanged -= value2;
				messageAdapter.KeyPress -= value3;
			}
			_MessageAdapter = value;
			messageAdapter = _MessageAdapter;
			if (messageAdapter != null)
			{
				messageAdapter.TextChanged += value2;
				messageAdapter.KeyPress += value3;
			}
		}
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return productAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productAdapter = value;
		}
	}

	internal DarkFilterTreeView TV_ByType
	{
		[CompilerGenerated]
		get
		{
			return annotationAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleError;
			MouseEventHandler value3 = FindInterruptibleError;
			DarkFilterTreeView darkFilterTreeView = annotationAdapter;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged -= value2;
				darkFilterTreeView.MouseDoubleClick -= value3;
			}
			annotationAdapter = value;
			darkFilterTreeView = annotationAdapter;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged += value2;
				darkFilterTreeView.MouseDoubleClick += value3;
			}
		}
	}

	internal TabPage TabPage4
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IteratorAdapter = value;
		}
	}

	private DarkTreeGridView TGV_Contacts
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ExpandingEventHandler value2 = InstantiateInterruptibleError;
			EventHandler value3 = CreateInterruptibleError;
			DarkTreeGridView initializerAdapter = m_InitializerAdapter;
			if (initializerAdapter != null)
			{
				initializerAdapter.NodeExpanding -= value2;
				initializerAdapter.SelectionChanged -= value3;
			}
			m_InitializerAdapter = value;
			initializerAdapter = m_InitializerAdapter;
			if (initializerAdapter != null)
			{
				initializerAdapter.NodeExpanding += value2;
				initializerAdapter.SelectionChanged += value3;
			}
		}
	}

	internal TreeGridColumn ContactName
	{
		[CompilerGenerated]
		get
		{
			return m_RoleAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RoleAdapter = value;
		}
	}

	[field: AccessedThroughProperty("ContactType")]
	internal DataGridViewTextBoxColumn ContactType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ContactPosture
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeAdapter = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn_0
	{
		[CompilerGenerated]
		get
		{
			return m_EventAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventAdapter = value;
		}
	}

	internal DataGridViewTextBoxColumn ContactHostedUnits
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalAdapter = value;
		}
	}

	internal DarkUIButton DarkUIButton_0
	{
		[CompilerGenerated]
		get
		{
			return accountAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareInterruptibleError;
			DarkUIButton darkUIButton = accountAdapter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			accountAdapter = value;
			darkUIButton = accountAdapter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.Timer CallInterruptibleCode()
	{
		return workerAdapter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void LogoutInterruptibleCode(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = ReadInterruptibleError;
		System.Windows.Forms.Timer timer = workerAdapter;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		workerAdapter = timer_0;
		timer = workerAdapter;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	public ORBAT()
	{
		base.Load += ManageInterruptibleRef;
		base.Closing += RevertInterruptibleRef;
		base.KeyDown += EnableInterruptibleError;
		base.FormClosing += InitInterruptibleError;
		base.Shown += SetInterruptibleError;
		stateAdapter = true;
		_AuthenticationAdapter = true;
		paramsAdapter = true;
		m_InfoAdapter = false;
		helperAdapter = true;
		_MapperAdapter = true;
		m_ManagerAdapter = true;
		m_GetterAdapter = false;
		m_ProducerAdapter = RuntimeHelpers.GetObjectValue(new object());
		procAdapter = RuntimeHelpers.GetObjectValue(new object());
		RegisterInterruptibleRef();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _CandidateAdapter != null)
			{
				_CandidateAdapter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RegisterInterruptibleRef()
	{
		_CandidateAdapter = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TV_ByGroup = new DarkFilterTreeView();
		TabPage2 = new TabPage();
		TV_ByMission = new DarkFilterTreeView();
		TabPage3 = new TabPage();
		TV_ByType = new DarkFilterTreeView();
		TabPage4 = new TabPage();
		TGV_Contacts = new DarkTreeGridView();
		ContactName = new TreeGridColumn();
		ContactType = new DataGridViewTextBoxColumn();
		ContactPosture = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		ContactHostedUnits = new DataGridViewTextBoxColumn();
		Label_Proficiency = new DarkLabel();
		Label_SetUnitProficiency = new DarkLabel();
		CB_Proficiency = new DarkUIComboBox();
		DarkLabel1 = new DarkLabel();
		TB_SearchOOB = new DarkTextBox();
		LogoutInterruptibleCode(new System.Windows.Forms.Timer(_CandidateAdapter));
		DarkUIButton_0 = new DarkUIButton();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		TabPage2.SuspendLayout();
		TabPage3.SuspendLayout();
		TabPage4.SuspendLayout();
		((ISupportInitialize)TGV_Contacts).BeginInit();
		SuspendLayout();
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Controls.Add(TabPage4);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Font = new Font("Segoe UI", 8f);
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(0, 1);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(592, 374);
		TabControl1.TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(TV_ByGroup);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(584, 346);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "按组编队";
		TV_ByGroup.Dock = DockStyle.Fill;
		TV_ByGroup.Location = new Point(3, 3);
		TV_ByGroup.MaxDragChange = 20;
		TV_ByGroup.Name = "TV_ByGroup";
		TV_ByGroup.Size = new Size(578, 340);
		TV_ByGroup.TabIndex = 0;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(TV_ByMission);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(584, 346);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "按任务排序单元";
		TV_ByMission.Dock = DockStyle.Fill;
		TV_ByMission.Location = new Point(3, 3);
		TV_ByMission.MaxDragChange = 20;
		TV_ByMission.Name = "TV_ByMission";
		TV_ByMission.Size = new Size(578, 340);
		TV_ByMission.TabIndex = 0;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(TV_ByType);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(584, 346);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "按类型排序单元";
		TV_ByType.Dock = DockStyle.Fill;
		TV_ByType.Location = new Point(3, 3);
		TV_ByType.MaxDragChange = 20;
		TV_ByType.Name = "TV_ByType";
		TV_ByType.Size = new Size(578, 340);
		TV_ByType.TabIndex = 0;
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Controls.Add(TGV_Contacts);
		TabPage4.Location = new Point(4, 24);
		TabPage4.Name = "TabPage4";
		TabPage4.Padding = new Padding(3);
		TabPage4.Size = new Size(584, 346);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "目标";
		TGV_Contacts.AllowUserToAddRows = false;
		TGV_Contacts.AllowUserToDeleteRows = false;
		TGV_Contacts.AllowUserToOrderColumns = true;
		TGV_Contacts.BackgroundColor = Color.FromArgb(51, 51, 51);
		TGV_Contacts.BorderStyle = BorderStyle.Fixed3D;
		TGV_Contacts.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Contacts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_Contacts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_Contacts.Columns.AddRange(ContactName, ContactType, ContactPosture, DataGridViewTextBoxColumn_0, ContactHostedUnits);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(51, 51, 51);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_Contacts.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_Contacts.Dock = DockStyle.Fill;
		TGV_Contacts.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Contacts.EnableHeadersVisualStyles = false;
		TGV_Contacts.ImageList = null;
		TGV_Contacts.Location = new Point(3, 3);
		TGV_Contacts.Name = "TGV_Contacts";
		TGV_Contacts.RowHeadersVisible = false;
		TGV_Contacts.RowHeadersWidth = 20;
		TGV_Contacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Contacts.ShowLines = false;
		TGV_Contacts.Size = new Size(578, 340);
		TGV_Contacts.TabIndex = 8;
		ContactName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		ContactName.DefaultNodeImage = null;
		ContactName.HeaderText = "名称";
		ContactName.Name = "ContactName";
		ContactName.ReadOnly = true;
		ContactName.Resizable = DataGridViewTriState.True;
		ContactName.SortMode = DataGridViewColumnSortMode.NotSortable;
		ContactType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ContactType.HeaderText = "类型/类别";
		ContactType.Name = "ContactType";
		ContactType.ReadOnly = true;
		ContactType.SortMode = DataGridViewColumnSortMode.NotSortable;
		ContactType.Width = 64;
		ContactPosture.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		ContactPosture.DefaultCellStyle = dataGridViewCellStyle3;
		ContactPosture.HeaderText = "敌我";
		ContactPosture.Name = "ContactPosture";
		ContactPosture.ReadOnly = true;
		ContactPosture.SortMode = DataGridViewColumnSortMode.NotSortable;
		ContactPosture.Width = 50;
		DataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		DataGridViewTextBoxColumn_0.HeaderText = "战斗毁伤评估BDA";
		DataGridViewTextBoxColumn_0.Name = "ContactBDA";
		DataGridViewTextBoxColumn_0.ReadOnly = true;
		DataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		DataGridViewTextBoxColumn_0.Width = 32;
		ContactHostedUnits.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		ContactHostedUnits.DefaultCellStyle = dataGridViewCellStyle5;
		ContactHostedUnits.HeaderText = "发现的挂载单元";
		ContactHostedUnits.Name = "ContactHostedUnits";
		ContactHostedUnits.ReadOnly = true;
		ContactHostedUnits.SortMode = DataGridViewColumnSortMode.NotSortable;
		ContactHostedUnits.Width = 91;
		Label_Proficiency.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label_Proficiency.AutoSize = true;
		Label_Proficiency.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label_Proficiency.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Proficiency.Location = new Point(4, 416);
		Label_Proficiency.Name = "Label_Proficiency";
		Label_Proficiency.Size = new Size(47, 13);
		Label_Proficiency.TabIndex = 4;
		Label_Proficiency.Text = "一般";
		Label_SetUnitProficiency.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Label_SetUnitProficiency.AutoSize = true;
		Label_SetUnitProficiency.ForeColor = Color.FromArgb(220, 220, 220);
		Label_SetUnitProficiency.Location = new Point(265, 415);
		Label_SetUnitProficiency.Name = "Label_SetUnitProficiency";
		Label_SetUnitProficiency.Size = new Size(149, 15);
		Label_SetUnitProficiency.TabIndex = 5;
		Label_SetUnitProficiency.Text = "设置单元/编队熟练度：";
		CB_Proficiency.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CB_Proficiency.BackColor = Color.Transparent;
		CB_Proficiency.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Proficiency.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Proficiency.Font = new Font("Segoe UI", 7f);
		CB_Proficiency.FormattingEnabled = true;
		CB_Proficiency.Items.AddRange(new object[6] { "新手", "学生", "一般", "熟练", "高手", "继承自分方" });
		CB_Proficiency.Location = new Point(420, 414);
		CB_Proficiency.Name = "CB_Proficiency";
		CB_Proficiency.Size = new Size(165, 21);
		CB_Proficiency.TabIndex = 6;
		DarkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(4, 386);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(45, 15);
		DarkLabel1.TabIndex = 8;
		DarkLabel1.Text = "查找：";
		TB_SearchOOB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_SearchOOB.BackColor = Color.FromArgb(69, 73, 74);
		TB_SearchOOB.BorderStyle = BorderStyle.FixedSingle;
		TB_SearchOOB.ForeColor = Color.FromArgb(220, 220, 220);
		TB_SearchOOB.Location = new Point(52, 382);
		TB_SearchOOB.Name = "TB_SearchOOB";
		TB_SearchOOB.Size = new Size(391, 23);
		TB_SearchOOB.TabIndex = 9;
		CallInterruptibleCode().Interval = 500;
		DarkUIButton_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		DarkUIButton_0.BackColor = Color.Transparent;
		DarkUIButton_0.DialogResult = DialogResult.None;
		DarkUIButton_0.ForeColor = SystemColors.Control;
		DarkUIButton_0.Location = new Point(449, 382);
		DarkUIButton_0.Name = "btnEXPCOL";
		DarkUIButton_0.RoundRadius = 0;
		DarkUIButton_0.Size = new Size(136, 23);
		DarkUIButton_0.TabIndex = 10;
		DarkUIButton_0.Text = "收缩列表";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(592, 442);
		base.Controls.Add(DarkUIButton_0);
		base.Controls.Add(TB_SearchOOB);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(CB_Proficiency);
		base.Controls.Add(Label_SetUnitProficiency);
		base.Controls.Add(Label_Proficiency);
		base.Controls.Add(TabControl1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ORBAT";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "战斗序列 + 目标";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage2.ResumeLayout(performLayout: false);
		TabPage3.ResumeLayout(performLayout: false);
		TabPage4.ResumeLayout(performLayout: false);
		((ISupportInitialize)TGV_Contacts).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ManageInterruptibleRef(object sender, EventArgs e)
	{
		try
		{
			Scenario.UnitAdded += LogoutInterruptibleError;
			Scenario.UnitRemoved += ViewInterruptibleError;
			Scenario.UnitSideChanged += ConnectInterruptibleError;
			ActiveUnit_DockingOps.HostDockFacilityChanged += AddInterruptibleError;
			Aircraft_AirOps.HostAirFacilityChanged += AddInterruptibleError;
			ActiveUnit.ParentGroupChanged += DeleteInterruptibleError;
			ActiveUnit.NameChanged += MoveInterruptibleError;
			Side.ContactAdded += CustomizeInterruptibleError;
			Side.ContactRemoved += CountInterruptibleError;
			Side.BaseContactAdded += CloneInterruptibleError;
			Side.BaseContactRemoved += CountInterruptibleError;
			CallInterruptibleCode().Start();
			Refresh();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t67", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RevertInterruptibleRef(object sender, CancelEventArgs e)
	{
		try
		{
			Scenario.UnitAdded -= LogoutInterruptibleError;
			Scenario.UnitRemoved -= ViewInterruptibleError;
			Scenario.UnitSideChanged -= ConnectInterruptibleError;
			ActiveUnit_DockingOps.HostDockFacilityChanged -= AddInterruptibleError;
			Aircraft_AirOps.HostAirFacilityChanged -= AddInterruptibleError;
			ActiveUnit.ParentGroupChanged -= DeleteInterruptibleError;
			ActiveUnit.NameChanged -= MoveInterruptibleError;
			Side.ContactAdded -= CustomizeInterruptibleError;
			Side.ContactRemoved -= CountInterruptibleError;
			Side.BaseContactAdded -= CloneInterruptibleError;
			Side.BaseContactRemoved -= CountInterruptibleError;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t68", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CountInterruptibleError(string string_0, string string_1)
	{
		try
		{
			if (Client.CurrentSide == null || Operators.CompareString(string_0, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				return;
			}
			using IEnumerator<TreeGridNode> enumerator = TGV_Contacts.Nodes.GetEnumerator();
			TreeGridNode Local_theNode = null;
			ORBAT Me = null;
			while (enumerator.MoveNext())
			{
				Me = this;
				Local_theNode = enumerator.Current;
				if (Local_theNode.Tag != null && Operators.CompareString(Local_theNode.Tag.ToString(), string_1, TextCompare: true) == 0)
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						Me.TGV_Contacts.Nodes.Remove(Local_theNode);
					});
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t69", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CustomizeInterruptibleError(string string_0, string string_1)
	{
		try
		{
			if (Client.CurrentSide == null || Operators.CompareString(string_0, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				return;
			}
			Contact contact = Client.CurrentSide.Contacts[string_1];
			if (contact == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				if (contact.ActualUnit.IsGroupMember() && contact.ActualUnit.GetParentGroup().IsLandInstallation)
				{
					return;
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					TreeGridNode treeGridNode = TGV_Contacts.Nodes.Add();
					ExcludeInterruptibleError(treeGridNode, contact);
					if (contact.ActualUnit.IsGroup && ((Group)contact.ActualUnit).IsLandInstallation)
					{
						treeGridNode.Nodes.Add("temp");
					}
				});
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t70", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CloneInterruptibleError(string string_0, string string_1)
	{
		try
		{
			if (Client.CurrentSide == null || Operators.CompareString(string_0, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				return;
			}
			Contact contact = Client.CurrentSide.BaseContacts[string_1];
			if (contact == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				TreeGridNode treeGridNode = TGV_Contacts.Nodes.Add();
				ExcludeInterruptibleError(treeGridNode, contact);
				treeGridNode.Nodes.Add("temp");
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t71", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ConnectInterruptibleError(Scenario scenario_0, string string_0, string string_1)
	{
		if (base.InvokeRequired)
		{
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				ConnectInterruptibleError(scenario_0, string_0, string_1);
			});
			return;
		}
		bool flag = false;
		ActiveUnit activeUnit = null;
		if (scenario_0.ActiveUnits.TryGetValue(string_0, ref activeUnit))
		{
			flag = activeUnit.GetUnitSide() == Client.CurrentSide || scenario_0.Sides_ReadOnly.Where((Side s) => Operators.CompareString(s.ObjectID, string_1, TextCompare: true) == 0).First() == Client.CurrentSide;
		}
		if (flag)
		{
			DisableInterruptibleError(TabControl1.SelectedIndex, null);
			Refresh();
		}
	}

	private void MoveInterruptibleError(string string_0)
	{
		try
		{
			if (!base.Visible || !Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
			{
				return;
			}
			ActiveUnit Local_theAU = Client.CurrentScenario.ActiveUnits[string_0];
			if (Operators.CompareString(Local_theAU.GetUnitSide().ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				return;
			}
			using IEnumerator<DarkFilterTreeNode> enumerator = InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup).GetEnumerator();
			DarkFilterTreeNode Local_theNode = null;
			while (enumerator.MoveNext())
			{
				Local_theNode = enumerator.Current;
				if (Local_theNode.Tag == Local_theAU)
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						Local_theNode.Text = WriteInterruptibleError(Local_theAU);
					});
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t72", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DeleteInterruptibleError(string string_0)
	{
		try
		{
			if (base.Visible && Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
			{
				ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[string_0];
				if (Operators.CompareString(activeUnit.GetUnitSide().ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) == 0)
				{
					ComputeInterruptibleError(activeUnit);
					DestroyInterruptibleError(activeUnit);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t73", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AddInterruptibleError(string string_0)
	{
		ActiveUnit activeUnit = null;
		try
		{
			if (!base.Visible || !Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
			{
				return;
			}
			activeUnit = Client.CurrentScenario.ActiveUnits[string_0];
			if (Operators.CompareString(activeUnit.GetUnitSide().ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t74", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			DarkFilterTreeNode darkFilterTreeNode = null;
			foreach (DarkFilterTreeNode item in InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup))
			{
				foreach (DarkFilterTreeNode node in item.Nodes)
				{
					try
					{
						if (Operators.CompareString(((ActiveUnit)node.Tag).ObjectID, string_0, TextCompare: true) == 0)
						{
							darkFilterTreeNode = item;
							break;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			ActiveUnit activeUnit2 = (activeUnit.IsAircraft ? ((Aircraft)activeUnit).AirOps.CurrentHostUnit : activeUnit.DockingOps.CurrentHostUnit);
			if (!Information.IsNothing(darkFilterTreeNode))
			{
				string right = (Information.IsNothing(activeUnit2) ? string.Empty : activeUnit2.ObjectID);
				if (Operators.CompareString(((ActiveUnit)darkFilterTreeNode.Tag).ObjectID, right, TextCompare: true) == 0)
				{
					return;
				}
			}
			ComputeInterruptibleError(activeUnit);
			DestroyInterruptibleError(activeUnit);
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 523253955t75", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DestroyInterruptibleError(ActiveUnit activeUnit_0)
	{
		object producerAdapter = m_ProducerAdapter;
		ObjectFlowControl.CheckForSyncLockOnValueType(producerAdapter);
		bool lockTaken = false;
		try
		{
			ActiveUnit Local_UnitCurrentHost = null;
			Monitor.Enter(producerAdapter, ref lockTaken);
			try
			{
				Local_UnitCurrentHost = (activeUnit_0.IsAircraft ? ((Aircraft)activeUnit_0).AirOps.CurrentHostUnit : activeUnit_0.DockingOps.CurrentHostUnit);
				foreach (DarkFilterTreeNode item in InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup))
				{
					if (item.Tag != null && item.Tag == activeUnit_0)
					{
						return;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 523253955t75", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			DarkFilterTreeNode Local_NewNode = null;
			if (Local_UnitCurrentHost == null)
			{
				if (activeUnit_0.GetParentGroup() == null)
				{
					try
					{
						Invoke((VB_0024AnonymousDelegate_0)delegate
						{
							string strB3 = WriteInterruptibleError(activeUnit_0);
							if (TV_ByGroup.Nodes.Count == 0)
							{
								Local_NewNode = new DarkFilterTreeNode();
								Local_NewNode.Tag = activeUnit_0;
								Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
								Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
								Local_NewNode.Text = strB3;
								Local_NewNode.ParentTree = TV_ByGroup;
								TV_ByGroup.Nodes.Add(Local_NewNode);
								Local_NewNode.EnsureVisible();
							}
							else
							{
								foreach (DarkFilterTreeNode current3 in TV_ByGroup.Nodes)
								{
									try
									{
										if (current3.Text.CompareTo(strB3) > 0)
										{
											Local_NewNode = new DarkFilterTreeNode();
											Local_NewNode.Tag = activeUnit_0;
											Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
											Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
											Local_NewNode.Text = strB3;
											Local_NewNode.ParentTree = TV_ByGroup;
											TV_ByGroup.Nodes.Insert(TV_ByGroup.Nodes.IndexOf(current3), Local_NewNode);
											Local_NewNode.EnsureVisible();
											break;
										}
									}
									catch (Exception ex6)
									{
										ProjectData.SetProjectError(ex6);
										Exception exception_6 = ex6;
										exception_6?.Data.Add("Error at 523253955t751", "");
										GameGeneral.WriteExceptionsToLog(ref exception_6);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
							}
							TV_ByGroup.UpdateNodes();
						});
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 523253955t76", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						Invoke((VB_0024AnonymousDelegate_0)delegate
						{
							string strB2 = WriteInterruptibleError(activeUnit_0);
							DarkFilterTreeNode darkFilterTreeNode2 = (from theNode in InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup)
								where theNode.Tag == activeUnit_0.GetParentGroup()
								select theNode).FirstOrDefault();
							if (darkFilterTreeNode2 != null)
							{
								if (darkFilterTreeNode2.Nodes.Count == 0)
								{
									Local_NewNode = new DarkFilterTreeNode();
									Local_NewNode.Tag = activeUnit_0;
									Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
									Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
									Local_NewNode.Text = strB2;
									Local_NewNode.ParentTree = TV_ByGroup;
									darkFilterTreeNode2.Nodes.Add(Local_NewNode);
								}
								else
								{
									bool flag3 = false;
									foreach (DarkFilterTreeNode current2 in darkFilterTreeNode2.Nodes)
									{
										if (current2.Text.CompareTo(strB2) > 0)
										{
											Local_NewNode = new DarkFilterTreeNode();
											Local_NewNode.Tag = activeUnit_0;
											Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
											Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
											Local_NewNode.Text = strB2;
											Local_NewNode.ParentTree = TV_ByGroup;
											darkFilterTreeNode2.Nodes.Insert(darkFilterTreeNode2.Nodes.IndexOf(current2), Local_NewNode);
											Local_NewNode.EnsureVisible();
											flag3 = true;
											break;
										}
									}
									if (!flag3)
									{
										Local_NewNode = new DarkFilterTreeNode();
										Local_NewNode.Tag = activeUnit_0;
										Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
										Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
										Local_NewNode.Text = strB2;
										Local_NewNode.ParentTree = TV_ByGroup;
										darkFilterTreeNode2.Nodes.Add(Local_NewNode);
										Local_NewNode.EnsureVisible();
									}
								}
								TV_ByGroup.UpdateNodes();
							}
						});
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at 523253955t77", "");
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			else
			{
				try
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						string strB = WriteInterruptibleError(activeUnit_0);
						DarkFilterTreeNode darkFilterTreeNode = (from theNode in InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup)
							where theNode.Tag == Local_UnitCurrentHost
							select theNode).FirstOrDefault();
						if (darkFilterTreeNode != null)
						{
							if (darkFilterTreeNode.Nodes.Count == 0)
							{
								Local_NewNode = new DarkFilterTreeNode();
								Local_NewNode.Tag = activeUnit_0;
								Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
								Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
								Local_NewNode.Text = strB;
								Local_NewNode.ParentTree = TV_ByGroup;
								darkFilterTreeNode.Nodes.Add(Local_NewNode);
								Local_NewNode.EnsureVisible();
							}
							else
							{
								bool flag2 = false;
								foreach (DarkFilterTreeNode current in darkFilterTreeNode.Nodes)
								{
									if (current.Text.CompareTo(strB) > 0)
									{
										Local_NewNode = new DarkFilterTreeNode();
										Local_NewNode.Tag = activeUnit_0;
										Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
										Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
										Local_NewNode.Text = strB;
										Local_NewNode.ParentTree = TV_ByGroup;
										darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(current), Local_NewNode);
										Local_NewNode.EnsureVisible();
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									Local_NewNode = new DarkFilterTreeNode();
									Local_NewNode.Tag = activeUnit_0;
									Local_NewNode.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
									Local_NewNode.ForeColor = GetUnitProficiencyColor(activeUnit_0);
									Local_NewNode.Text = strB;
									Local_NewNode.ParentTree = TV_ByGroup;
									darkFilterTreeNode.Nodes.Add(Local_NewNode);
									Local_NewNode.EnsureVisible();
								}
							}
							TV_ByGroup.UpdateNodes();
						}
					});
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at 523253955t78", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				if (Local_NewNode == null || !activeUnit_0.IsGroup)
				{
					return;
				}
				foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
				{
					bool flag = false;
					foreach (DarkFilterTreeNode item2 in InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup))
					{
						try
						{
							if (Operators.CompareString(((ActiveUnit)item2.Tag).ObjectID, value.ObjectID, TextCompare: true) == 0)
							{
								flag = true;
								break;
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
					if (!flag)
					{
						ComputeInterruptibleError(value);
						DestroyInterruptibleError(value);
					}
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					Local_NewNode.Expanded = true;
					TV_ByGroup.UpdateNodes();
				});
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception exception_5 = ex5;
				exception_5?.Data.Add("Error at 523253955t79", "");
				GameGeneral.WriteExceptionsToLog(ref exception_5);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(producerAdapter);
			}
		}
	}

	private void ComputeInterruptibleError(ActiveUnit activeUnit_0)
	{
		try
		{
			DarkFilterTreeNode Local_NodeToRemove = null;
			foreach (DarkFilterTreeNode item in InterpreterObjectListener.DefineInterruptibleTask(TV_ByGroup))
			{
				if (item.Tag == activeUnit_0)
				{
					Local_NodeToRemove = item;
					break;
				}
			}
			if (Information.IsNothing(Local_NodeToRemove))
			{
				return;
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				if (Information.IsNothing(Local_NodeToRemove.ParentNode))
				{
					TV_ByGroup.Nodes.Remove(Local_NodeToRemove);
				}
				else
				{
					Local_NodeToRemove.ParentNode.Nodes.Remove(Local_NodeToRemove);
				}
				TV_ByGroup.UpdateNodes();
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t80", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PatchInterruptibleError(ActiveUnit activeUnit_0)
	{
		try
		{
			DarkFilterTreeNode Local_NodeToRemove = null;
			foreach (DarkFilterTreeNode item in InterpreterObjectListener.DefineInterruptibleTask(TV_ByMission))
			{
				if (item.Tag == activeUnit_0)
				{
					Local_NodeToRemove = item;
					break;
				}
			}
			if (Information.IsNothing(Local_NodeToRemove))
			{
				return;
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				if (Information.IsNothing(Local_NodeToRemove.ParentNode))
				{
					TV_ByMission.Nodes.Remove(Local_NodeToRemove);
				}
				else
				{
					Local_NodeToRemove.ParentNode.Nodes.Remove(Local_NodeToRemove);
				}
				TV_ByMission.UpdateNodes();
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t81", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SelectInterruptibleError(ActiveUnit activeUnit_0)
	{
		object obj = procAdapter;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				foreach (DarkFilterTreeNode item in InterpreterObjectListener.DefineInterruptibleTask(TV_ByType))
				{
					if (item.Tag != null && item.Tag == activeUnit_0)
					{
						return;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 523253955t81", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					DarkFilterTreeNode darkFilterTreeNode = null;
					_ = activeUnit_0.UnitType;
					string text = WriteInterruptibleError(activeUnit_0);
					bool flag = false;
					DarkFilterTreeNode darkFilterTreeNode2 = (from theNode in InterpreterObjectListener.DefineInterruptibleTask(TV_ByType)
						where theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == (int)activeUnit_0.UnitType
						select theNode).FirstOrDefault();
					if (darkFilterTreeNode2 == null)
					{
						darkFilterTreeNode2 = new DarkFilterTreeNode
						{
							Tag = (int)activeUnit_0.UnitType,
							Font = new Font(TV_ByType.Font, FontStyle.Regular),
							ForeColor = Color.White,
							Text = activeUnit_0.UnitType_String,
							ParentTree = TV_ByType
						};
						flag = true;
					}
					DarkFilterTreeNode darkFilterTreeNode3 = darkFilterTreeNode2.Nodes.Where((DarkFilterTreeNode theNode) => theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == activeUnit_0.SubType).FirstOrDefault();
					if (darkFilterTreeNode3 == null)
					{
						darkFilterTreeNode3 = new DarkFilterTreeNode
						{
							Tag = activeUnit_0.SubType,
							Font = new Font(TV_ByType.Font, FontStyle.Regular),
							ForeColor = Color.White,
							Text = activeUnit_0.SubTypeDescription,
							ParentTree = TV_ByType
						};
						darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
					}
					darkFilterTreeNode = new DarkFilterTreeNode
					{
						Tag = activeUnit_0,
						Font = new Font(TV_ByType.Font, FontStyle.Regular),
						ForeColor = GetUnitProficiencyColor(activeUnit_0),
						Text = text,
						ParentTree = TV_ByType
					};
					darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode);
					if (flag)
					{
						TV_ByType.Nodes.Add(darkFilterTreeNode2);
						darkFilterTreeNode2.EnsureVisible();
					}
				});
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 523253955t82", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private void CallInterruptibleError(ActiveUnit activeUnit_0)
	{
		object obj = procAdapter;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			ORBAT Me = this;
			try
			{
				DarkFilterTreeNode Local_NodeToRemove = null;
				foreach (DarkFilterTreeNode item in InterpreterObjectListener.DefineInterruptibleTask(TV_ByType))
				{
					if (item.Tag == activeUnit_0)
					{
						Local_NodeToRemove = item;
						break;
					}
				}
				if (Information.IsNothing(Local_NodeToRemove))
				{
					return;
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					if (Information.IsNothing(Local_NodeToRemove.ParentNode))
					{
						Me.TV_ByType.Nodes.Remove(Local_NodeToRemove);
					}
					else
					{
						Local_NodeToRemove.ParentNode.Nodes.Remove(Local_NodeToRemove);
					}
					Me.TV_ByType.UpdateNodes();
				});
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 523253955t83", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private void LogoutInterruptibleError(Scenario scenario_0, string string_0)
	{
		try
		{
			if (base.InvokeRequired)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					LogoutInterruptibleError(scenario_0, string_0);
				});
			}
			else
			{
				if (!base.Visible || !Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
				{
					return;
				}
				ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[string_0];
				if (Operators.CompareString(activeUnit.GetUnitSide().ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) == 0)
				{
					if (activeUnit.IsAircraft)
					{
						_ = ((Aircraft)activeUnit).AirOps.CurrentHostUnit;
					}
					else
					{
						_ = activeUnit.DockingOps.CurrentHostUnit;
					}
					DestroyInterruptibleError(activeUnit);
					SelectInterruptibleError(activeUnit);
					Refresh();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t84", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ViewInterruptibleError(Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		try
		{
			if (base.InvokeRequired)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					ViewInterruptibleError(scenario_0, activeUnit_0);
				});
			}
			else if (base.Visible)
			{
				ComputeInterruptibleError(activeUnit_0);
				PatchInterruptibleError(activeUnit_0);
				CallInterruptibleError(activeUnit_0);
				Refresh();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t85", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			Close();
			TV_ByGroup.Nodes.Clear();
			TV_ByMission.Nodes.Clear();
			TV_ByType.Nodes.Clear();
			TGV_Contacts.Nodes.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t86", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void BuildWindow()
	{
		try
		{
			switch (TabControl1.SelectedIndex)
			{
			case 0:
				NewInterruptibleError();
				TV_ByGroup.MouseDoubleClick += ValidateInterruptibleError;
				break;
			case 1:
				PushInterruptibleError();
				break;
			case 2:
				InvokeInterruptibleError();
				break;
			case 3:
				SetupInterruptibleError();
				break;
			}
			if (Client.CurrentSide != null)
			{
				Label_Proficiency.Text = Misc.TestRequest(Client.CurrentSide.Proficiency);
			}
			Label_SetUnitProficiency.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
			CB_Proficiency.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t87", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ValidateInterruptibleError(object sender, MouseEventArgs e)
	{
		ActiveUnit activeUnit_ = null;
		try
		{
			sender.ToString();
			if (sender.GetType() == typeof(DarkFilterTreeView))
			{
				activeUnit_ = (ActiveUnit)((DarkFilterTreeView)sender).SelectedNodes[0].Tag;
			}
			if (sender.GetType() == typeof(DarkTreeGridView))
			{
				activeUnit_ = (ActiveUnit)((DarkTreeGridView)sender).CurrentNode.Tag;
			}
			if (Client.SelectedUnit != null)
			{
				if (Client.SelectedUnit.IsActiveUnit)
				{
					activeUnit_ = (ActiveUnit)Client.SelectedUnit;
				}
				if (Client.SelectedUnit.DisableWriter())
				{
					activeUnit_ = ((Contact)Client.SelectedUnit).ActualUnit;
				}
				if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					activeUnit_ = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				Client.smethod_1(activeUnit_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t88", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private ReadOnlyCollection<DarkFilterTreeNode> method_0()
	{
		List<DarkFilterTreeNode> list = new List<DarkFilterTreeNode>();
		foreach (DarkFilterTreeNode node in TV_ByGroup.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			LoginInterruptibleError(node, list);
		}
		return list.AsReadOnly();
	}

	private void LoginInterruptibleError(DarkFilterTreeNode darkFilterTreeNode_0, List<DarkFilterTreeNode> list_0)
	{
		try
		{
			foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
			{
				if (!list_0.Contains(node))
				{
					list_0.Add(node);
				}
				LoginInterruptibleError(node, list_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t89", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void GetInterruptibleError(ActiveUnit activeUnit_0, bool bool_0)
	{
		try
		{
			if (activeUnit_0.GetUnitSide() != Client.CurrentSide)
			{
				return;
			}
			foreach (DarkFilterTreeNode item in method_0())
			{
				if (item.Tag == activeUnit_0)
				{
					if (Information.IsNothing(item.ParentNode))
					{
						TV_ByGroup.Nodes.Remove(item);
					}
					else
					{
						item.ParentNode.Nodes.Remove(item);
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t90", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Color GetUnitProficiencyColor(ActiveUnit activeUnit_0)
	{
		Color result = default(Color);
		try
		{
			if (activeUnit_0.IsGroup)
			{
				result = Color.LightGray;
				return result;
			}
			GlobalVariables.ProficiencyLevel? proficiency = activeUnit_0.Proficiency;
			int? num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				result = Color.Cyan;
				return result;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				result = Color.Lime;
				return result;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				result = Color.Yellow;
				return result;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				result = Color.Orange;
				return result;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
			{
				result = Color.IndianRed;
				return result;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t91", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private string WriteInterruptibleError(ActiveUnit activeUnit_0)
	{
		string result = null;
		try
		{
			string text;
			if (activeUnit_0.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				text = (Information.IsNothing(aircraft.Loadout) ? "" : (" , " + aircraft.Loadout.Name));
			}
			else
			{
				text = "";
			}
			string text2 = activeUnit_0.Name;
			if (!activeUnit_0.IsGroup)
			{
				text2 = text2 + " (" + Misc.ReadRequest(activeUnit_0.UnitClass) + text + ")";
			}
			result = text2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955t92", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void NewInterruptibleError()
	{
		TV_ByGroup.Nodes.Clear();
		foreach (ActiveUnit item in Client.CurrentSide.Units.Select((ActiveUnit theAU) => theAU).OrderBy((ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>()).ToList())
		{
			try
			{
				if (item.IsGroup)
				{
					DarkFilterTreeNode darkFilterTreeNode = new DarkFilterTreeNode(item.Name);
					darkFilterTreeNode.Tag = item;
					foreach (ActiveUnit item2 in ((Group)item).Units.Values.Select((ActiveUnit theAU) => theAU).OrderBy((ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>()).ToList())
					{
						DarkFilterTreeNode darkFilterTreeNode2 = new DarkFilterTreeNode(WriteInterruptibleError(item2));
						darkFilterTreeNode.Nodes.Add(darkFilterTreeNode2);
						darkFilterTreeNode2.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
						darkFilterTreeNode2.ForeColor = GetUnitProficiencyColor(item2);
						darkFilterTreeNode2.Tag = item2;
						foreach (ActiveUnit item3 in from theAU in item2.DockingOps.EmbarkedBoats.OrderBy((ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>())
							select (theAU))
						{
							DarkFilterTreeNode darkFilterTreeNode3 = new DarkFilterTreeNode(WriteInterruptibleError(item3));
							darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
							darkFilterTreeNode3.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
							darkFilterTreeNode3.ForeColor = GetUnitProficiencyColor(item3);
							darkFilterTreeNode3.Tag = item3;
						}
						foreach (Aircraft item4 in from theAC in item2.AirOps.EmbarkedAircraft_ReadOnly.OrderBy((Aircraft theActU) => theActU.Name, new NaturalSortComparer<string[]>())
							select (theAC))
						{
							DarkFilterTreeNode darkFilterTreeNode4 = new DarkFilterTreeNode(WriteInterruptibleError(item4));
							darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode4);
							darkFilterTreeNode4.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
							darkFilterTreeNode4.ForeColor = GetUnitProficiencyColor(item4);
							darkFilterTreeNode4.Tag = item4;
						}
						darkFilterTreeNode2.Expanded = true;
					}
					darkFilterTreeNode.Expanded = true;
					TV_ByGroup.Nodes.Add(darkFilterTreeNode);
				}
				if (!item.IsOperating() || !item.IsPlatform || item.IsGroup || item.IsGroupMember())
				{
					continue;
				}
				DarkFilterTreeNode darkFilterTreeNode5 = new DarkFilterTreeNode(WriteInterruptibleError(item));
				darkFilterTreeNode5.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
				darkFilterTreeNode5.ForeColor = GetUnitProficiencyColor(item);
				darkFilterTreeNode5.Tag = item;
				foreach (ActiveUnit item5 in from theAU in item.DockingOps.EmbarkedBoats.OrderBy((ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>())
					select (theAU))
				{
					DarkFilterTreeNode darkFilterTreeNode6 = new DarkFilterTreeNode(WriteInterruptibleError(item5));
					darkFilterTreeNode5.Nodes.Add(darkFilterTreeNode6);
					darkFilterTreeNode6.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
					darkFilterTreeNode6.ForeColor = GetUnitProficiencyColor(item5);
					darkFilterTreeNode6.Tag = item5;
				}
				foreach (Aircraft item6 in from theAC in item.AirOps.EmbarkedAircraft_ReadOnly.OrderBy((Aircraft theActU) => theActU.Name, new NaturalSortComparer<string[]>())
					select (theAC))
				{
					DarkFilterTreeNode darkFilterTreeNode7 = new DarkFilterTreeNode(WriteInterruptibleError(item6));
					darkFilterTreeNode5.Nodes.Add(darkFilterTreeNode7);
					darkFilterTreeNode7.Font = new Font(TV_ByGroup.Font, FontStyle.Regular);
					darkFilterTreeNode7.ForeColor = GetUnitProficiencyColor(item6);
					darkFilterTreeNode7.Tag = item6;
				}
				darkFilterTreeNode5.Expanded = true;
				TV_ByGroup.Nodes.Add(darkFilterTreeNode5);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 523253955t93", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void PushInterruptibleError()
	{
		TV_ByMission.Nodes.Clear();
		if (Information.IsNothing(Client.CurrentSide))
		{
			return;
		}
		foreach (Mission item in from theM in Client.CurrentSide.GetMissionsTotal(Client.CurrentScenario)
			orderby theM.Name
			select theM)
		{
			if (item.Category == Mission.MissionCategory.Mission)
			{
				DarkFilterTreeNode darkFilterTreeNode = new DarkFilterTreeNode(item.Name);
				try
				{
					TV_ByMission.Nodes.Add(darkFilterTreeNode);
					if (item.IsActive)
					{
						darkFilterTreeNode.ForeColor = Color.LightGreen;
					}
					else
					{
						darkFilterTreeNode.ForeColor = Color.IndianRed;
						darkFilterTreeNode.Font = new Font(Font, FontStyle.Italic);
					}
					darkFilterTreeNode.Tag = item;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 523253955t94", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				List<Aircraft> list = new List<Aircraft>();
				List<Aircraft> list3 = new List<Aircraft>();
				List<ActiveUnit> list4 = new List<ActiveUnit>();
				foreach (ActiveUnit unit in Client.CurrentSide.Units)
				{
					try
					{
						if ((unit.IsGroupMember() | (unit.IsWeapon && ((Weapon)unit).Type == Weapon._WeaponType.Sonobuoy)) || unit.AssignedMissionOrPackage() != item)
						{
							continue;
						}
						if (unit.IsAircraft)
						{
							if (Information.IsNothing(unit.Navigator.GetFlight()))
							{
								if (unit.IsGroupMember())
								{
									if (!Information.IsNothing(unit.GetParentGroup()) && !list4.Contains(unit.GetParentGroup()))
									{
										list4.Add(unit.GetParentGroup());
									}
								}
								else
								{
									list.Add((Aircraft)unit);
								}
							}
							else if (unit.IsGroupMember())
							{
								if (!Information.IsNothing(unit.GetParentGroup()) && !list4.Contains(unit.GetParentGroup()))
								{
									list4.Add(unit.GetParentGroup());
								}
							}
							else
							{
								list3.Add((Aircraft)unit);
							}
						}
						else if (!unit.IsSubmarine || !((Submarine)unit).IsTetheredROV)
						{
							list4.Add(unit);
						}
					}
					catch (Exception ex6)
					{
						ProjectData.SetProjectError(ex6);
						Exception exception_6 = ex6;
						exception_6?.Data.Add("Error at 523253955t95", "");
						GameGeneral.WriteExceptionsToLog(ref exception_6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				IOrderedEnumerable<Aircraft> orderedEnumerable = list.OrderBy((Aircraft theAC) => theAC.UnitClass).ThenBy((Aircraft aircraft_0) => IncludeInterruptibleError(aircraft_0));
				List<Aircraft> list5 = list3.Select((Aircraft theAC) => theAC).OrderBy((Aircraft theAirc) => theAirc.Navigator.GetFlight().Callsign, new NaturalSortComparer<string[]>()).ToList();
				IEnumerable<ActiveUnit> enumerable = list4.OrderBy((ActiveUnit theAU) => theAU.Name);
				foreach (Aircraft item2 in orderedEnumerable)
				{
					try
					{
						DarkFilterTreeNode darkFilterTreeNode12 = null;
						string unitClass = item2.UnitClass;
						foreach (DarkFilterTreeNode node in darkFilterTreeNode.Nodes)
						{
							if (Operators.CompareString(node.Tag.ToString(), unitClass, TextCompare: true) == 0)
							{
								darkFilterTreeNode12 = node;
							}
						}
						if (Information.IsNothing(darkFilterTreeNode12))
						{
							darkFilterTreeNode12 = new DarkFilterTreeNode(item2.UnitClass);
							darkFilterTreeNode.Nodes.Add(darkFilterTreeNode12);
							darkFilterTreeNode12.Tag = unitClass;
						}
						DarkFilterTreeNode darkFilterTreeNode13 = new DarkFilterTreeNode(SearchInterruptibleError(item2));
						darkFilterTreeNode12.Nodes.Add(darkFilterTreeNode13);
						darkFilterTreeNode13.Tag = item2;
						darkFilterTreeNode13.ForeColor = GetUnitProficiencyColor(item2);
						darkFilterTreeNode12.Text = Conversions.ToString(darkFilterTreeNode12.Nodes.Count) + "x " + Misc.ReadRequest(Conversions.ToString(darkFilterTreeNode12.Tag));
						darkFilterTreeNode12 = null;
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception exception_7 = ex7;
						exception_7?.Data.Add("Error at 523253955t96", "");
						GameGeneral.WriteExceptionsToLog(ref exception_7);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				foreach (ActiveUnit item3 in enumerable)
				{
					try
					{
						string text = item3.Name;
						if (item3.IsGroup)
						{
							Group group = (Group)item3;
							if (group.Type == Group.GroupType.AirGroup && group.Units.Values.Count > 0)
							{
								string text2 = (string.IsNullOrEmpty(group.Units.Values.ElementAtOrDefault(0).UnitClass) ? "" : (" " + group.Units.Values.ElementAtOrDefault(0).UnitClass));
								text = text + " (" + Conversions.ToString(group.Units.Count) + "x" + text2 + ")";
							}
						}
						DarkFilterTreeNode darkFilterTreeNode14 = new DarkFilterTreeNode(text);
						darkFilterTreeNode.Nodes.Add(darkFilterTreeNode14);
						darkFilterTreeNode14.Tag = item3;
						if (item3.IsGroup)
						{
							foreach (ActiveUnit value in ((Group)item3).Units.Values)
							{
								text = (value.IsAircraft ? SearchInterruptibleError((Aircraft)value) : value.Name);
								DarkFilterTreeNode darkFilterTreeNode15 = new DarkFilterTreeNode(text);
								darkFilterTreeNode14.Nodes.Add(darkFilterTreeNode15);
								darkFilterTreeNode15.ForeColor = GetUnitProficiencyColor(item3);
								darkFilterTreeNode15.Tag = value;
							}
						}
						else
						{
							darkFilterTreeNode14.ForeColor = GetUnitProficiencyColor(item3);
						}
					}
					catch (Exception ex8)
					{
						ProjectData.SetProjectError(ex8);
						Exception exception_8 = ex8;
						exception_8?.Data.Add("Error at 523253955t97", "");
						GameGeneral.WriteExceptionsToLog(ref exception_8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				foreach (Aircraft item4 in list5)
				{
					try
					{
						DarkFilterTreeNode darkFilterTreeNode16 = null;
						string callsign = item4.Navigator.GetFlight().Callsign;
						foreach (DarkFilterTreeNode node2 in darkFilterTreeNode.Nodes)
						{
							if (Operators.CompareString(node2.Tag.ToString(), callsign, TextCompare: true) == 0)
							{
								darkFilterTreeNode16 = node2;
							}
						}
						if (Information.IsNothing(darkFilterTreeNode16))
						{
							darkFilterTreeNode16 = new DarkFilterTreeNode(item4.UnitClass);
							darkFilterTreeNode.Nodes.Add(darkFilterTreeNode16);
							darkFilterTreeNode16.Tag = callsign;
						}
						DarkFilterTreeNode darkFilterTreeNode17 = new DarkFilterTreeNode(SearchInterruptibleError(item4));
						darkFilterTreeNode16.Nodes.Add(darkFilterTreeNode17);
						darkFilterTreeNode17.Tag = item4;
						darkFilterTreeNode17.ForeColor = GetUnitProficiencyColor(item4);
						darkFilterTreeNode16.Text = "飞行编队" + callsign + " (" + Conversions.ToString(darkFilterTreeNode16.Nodes.Count) + "x " + Misc.ReadRequest(item4.UnitClass) + ")";
						darkFilterTreeNode16 = null;
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception exception_9 = ex9;
						exception_9?.Data.Add("Error at 523253955t98", "");
						GameGeneral.WriteExceptionsToLog(ref exception_9);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				darkFilterTreeNode.Expanded = true;
			}
			else
			{
				if (item.Category != Mission.MissionCategory.TaskPool)
				{
					continue;
				}
				DarkFilterTreeNode darkFilterTreeNode18 = new DarkFilterTreeNode(item.Name);
				TV_ByMission.Nodes.Add(darkFilterTreeNode18);
				darkFilterTreeNode18.ForeColor = Color.LightGreen;
				darkFilterTreeNode18.Tag = item;
				List<Aircraft> list6 = new List<Aircraft>();
				List<ActiveUnit> list7 = new List<ActiveUnit>();
				foreach (ActiveUnit unit2 in Client.CurrentSide.Units)
				{
					try
					{
						if (!(unit2.IsGroupMember() | (unit2.IsWeapon && ((Weapon)unit2).Type == Weapon._WeaponType.Sonobuoy)) && Information.IsNothing(unit2.AssignedMissionOrPackage()) && unit2.AssignedTaskPool == item)
						{
							if (unit2.IsAircraft)
							{
								list6.Add((Aircraft)unit2);
							}
							else if (!unit2.IsSubmarine || !((Submarine)unit2).IsTetheredROV)
							{
								list7.Add(unit2);
							}
						}
					}
					catch (Exception ex10)
					{
						ProjectData.SetProjectError(ex10);
						Exception exception_10 = ex10;
						exception_10?.Data.Add("Error at 523253955t99", "");
						GameGeneral.WriteExceptionsToLog(ref exception_10);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				foreach (Mission package in ((TaskPool)item).PackageList)
				{
					DarkFilterTreeNode darkFilterTreeNode19 = new DarkFilterTreeNode(package.Name);
					try
					{
						darkFilterTreeNode18.Nodes.Add(darkFilterTreeNode19);
						if (package.IsActive)
						{
							darkFilterTreeNode19.ForeColor = Color.LightGreen;
						}
						else
						{
							darkFilterTreeNode19.ForeColor = Color.IndianRed;
							darkFilterTreeNode19.Font = new Font(Font, FontStyle.Italic);
						}
						darkFilterTreeNode19.Tag = package;
					}
					catch (Exception ex11)
					{
						ProjectData.SetProjectError(ex11);
						Exception exception_11 = ex11;
						exception_11?.Data.Add("Error at 523253955y00", "");
						GameGeneral.WriteExceptionsToLog(ref exception_11);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					List<Aircraft> list8 = new List<Aircraft>();
					List<Aircraft> list9 = new List<Aircraft>();
					List<ActiveUnit> list10 = new List<ActiveUnit>();
					foreach (ActiveUnit unit3 in Client.CurrentSide.Units)
					{
						try
						{
							if ((unit3.IsGroupMember() | (unit3.IsWeapon && ((Weapon)unit3).Type == Weapon._WeaponType.Sonobuoy)) || unit3.AssignedMissionOrPackage() != package)
							{
								continue;
							}
							if (unit3.IsAircraft)
							{
								if (Information.IsNothing(unit3.Navigator.GetFlight()))
								{
									if (unit3.IsGroupMember())
									{
										if (!Information.IsNothing(unit3.GetParentGroup()) && !list10.Contains(unit3.GetParentGroup()))
										{
											list10.Add(unit3.GetParentGroup());
										}
									}
									else
									{
										list8.Add((Aircraft)unit3);
									}
								}
								else if (unit3.IsGroupMember())
								{
									if (!Information.IsNothing(unit3.GetParentGroup()) && !list10.Contains(unit3.GetParentGroup()))
									{
										list10.Add(unit3.GetParentGroup());
									}
								}
								else
								{
									list9.Add((Aircraft)unit3);
								}
							}
							else if (!unit3.IsSubmarine || !((Submarine)unit3).IsTetheredROV)
							{
								list10.Add(unit3);
							}
						}
						catch (Exception ex12)
						{
							ProjectData.SetProjectError(ex12);
							Exception exception_12 = ex12;
							exception_12?.Data.Add("Error at 523253955y01", "");
							GameGeneral.WriteExceptionsToLog(ref exception_12);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					IOrderedEnumerable<Aircraft> orderedEnumerable2 = list8.OrderBy((Aircraft theAC) => theAC.UnitClass).ThenBy((Aircraft aircraft_0) => IncludeInterruptibleError(aircraft_0));
					List<Aircraft> list2 = list9.Select((Aircraft theAC) => theAC).OrderBy((Aircraft theAirc) => theAirc.Navigator.GetFlight().Callsign, new NaturalSortComparer<string[]>()).ToList();
					IEnumerable<ActiveUnit> enumerable2 = list10.OrderBy((ActiveUnit theAU) => theAU.Name);
					foreach (Aircraft item5 in orderedEnumerable2)
					{
						try
						{
							DarkFilterTreeNode darkFilterTreeNode2 = null;
							string unitClass2 = item5.UnitClass;
							foreach (DarkFilterTreeNode node3 in darkFilterTreeNode19.Nodes)
							{
								if (Operators.CompareString(node3.Tag.ToString(), unitClass2, TextCompare: true) == 0)
								{
									darkFilterTreeNode2 = node3;
								}
							}
							if (Information.IsNothing(darkFilterTreeNode2))
							{
								darkFilterTreeNode2 = new DarkFilterTreeNode(item5.UnitClass);
								darkFilterTreeNode19.Nodes.Add(darkFilterTreeNode2);
								darkFilterTreeNode2.Tag = unitClass2;
							}
							DarkFilterTreeNode darkFilterTreeNode3 = new DarkFilterTreeNode(SearchInterruptibleError(item5));
							darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
							darkFilterTreeNode3.Tag = item5;
							darkFilterTreeNode3.ForeColor = GetUnitProficiencyColor(item5);
							darkFilterTreeNode2.Text = Conversions.ToString(darkFilterTreeNode2.Nodes.Count) + "x " + Misc.ReadRequest(Conversions.ToString(darkFilterTreeNode2.Tag));
							darkFilterTreeNode2 = null;
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception exception_13 = ex13;
							exception_13?.Data.Add("Error at 523253955y02", "");
							GameGeneral.WriteExceptionsToLog(ref exception_13);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					foreach (ActiveUnit item6 in enumerable2)
					{
						string name = item6.Name;
						try
						{
							DarkFilterTreeNode darkFilterTreeNode4 = new DarkFilterTreeNode(string.IsNullOrEmpty(item6.UnitClass) ? name : (name + " (" + Misc.ReadRequest(item6.UnitClass) + ")"));
							darkFilterTreeNode19.Nodes.Add(darkFilterTreeNode4);
							darkFilterTreeNode4.Tag = item6;
							if (item6.IsGroup)
							{
								foreach (ActiveUnit value2 in ((Group)item6).Units.Values)
								{
									DarkFilterTreeNode darkFilterTreeNode5 = new DarkFilterTreeNode(value2.Name + " (" + Misc.ReadRequest(value2.UnitClass) + ")");
									darkFilterTreeNode4.Nodes.Add(darkFilterTreeNode5);
									darkFilterTreeNode5.ForeColor = GetUnitProficiencyColor(value2);
									darkFilterTreeNode5.Tag = value2;
								}
							}
							else
							{
								darkFilterTreeNode4.ForeColor = GetUnitProficiencyColor(item6);
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 523253955y02", "");
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					foreach (Aircraft item7 in list2)
					{
						try
						{
							DarkFilterTreeNode darkFilterTreeNode6 = null;
							string callsign2 = item7.Navigator.GetFlight().Callsign;
							foreach (DarkFilterTreeNode node4 in darkFilterTreeNode19.Nodes)
							{
								if (Operators.CompareString(node4.Tag.ToString(), callsign2, TextCompare: true) == 0)
								{
									darkFilterTreeNode6 = node4;
								}
							}
							if (Information.IsNothing(darkFilterTreeNode6))
							{
								darkFilterTreeNode6 = new DarkFilterTreeNode(item7.UnitClass);
								darkFilterTreeNode19.Nodes.Add(darkFilterTreeNode6);
								darkFilterTreeNode6.Tag = callsign2;
							}
							DarkFilterTreeNode darkFilterTreeNode7 = new DarkFilterTreeNode(SearchInterruptibleError(item7));
							darkFilterTreeNode6.Nodes.Add(darkFilterTreeNode7);
							darkFilterTreeNode7.Tag = item7;
							darkFilterTreeNode7.ForeColor = GetUnitProficiencyColor(item7);
							darkFilterTreeNode6.Text = "飞行编队" + callsign2 + " (" + Conversions.ToString(darkFilterTreeNode6.Nodes.Count) + "x " + Misc.ReadRequest(item7.UnitClass) + ")";
							darkFilterTreeNode6 = null;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception exception_3 = ex3;
							exception_3?.Data.Add("Error at 523253955y03", "");
							GameGeneral.WriteExceptionsToLog(ref exception_3);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					darkFilterTreeNode19.Expanded = true;
				}
				IOrderedEnumerable<Aircraft> orderedEnumerable3 = list6.OrderBy((Aircraft theAC) => theAC.UnitClass).ThenBy((Aircraft aircraft_0) => IncludeInterruptibleError(aircraft_0));
				IEnumerable<ActiveUnit> enumerable3 = list7.OrderBy((ActiveUnit theAU) => theAU.Name);
				foreach (Aircraft item8 in orderedEnumerable3)
				{
					try
					{
						DarkFilterTreeNode darkFilterTreeNode8 = null;
						string unitClass3 = item8.UnitClass;
						foreach (DarkFilterTreeNode node5 in darkFilterTreeNode18.Nodes)
						{
							if (Operators.CompareString(node5.Tag.ToString(), unitClass3, TextCompare: true) == 0)
							{
								darkFilterTreeNode8 = node5;
							}
						}
						if (Information.IsNothing(darkFilterTreeNode8))
						{
							darkFilterTreeNode8 = new DarkFilterTreeNode(item8.UnitClass);
							darkFilterTreeNode18.Nodes.Add(darkFilterTreeNode8);
							darkFilterTreeNode8.Tag = unitClass3;
						}
						DarkFilterTreeNode darkFilterTreeNode9 = new DarkFilterTreeNode(SearchInterruptibleError(item8));
						darkFilterTreeNode8.Nodes.Add(darkFilterTreeNode9);
						darkFilterTreeNode9.Tag = item8;
						darkFilterTreeNode9.ForeColor = GetUnitProficiencyColor(item8);
						darkFilterTreeNode8.Text = Conversions.ToString(darkFilterTreeNode8.Nodes.Count) + "x " + Misc.ReadRequest(Conversions.ToString(darkFilterTreeNode8.Tag));
						darkFilterTreeNode8 = null;
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at 523253955y04", "");
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				foreach (ActiveUnit item9 in enumerable3)
				{
					try
					{
						string name2 = item9.Name;
						DarkFilterTreeNode darkFilterTreeNode10 = new DarkFilterTreeNode(string.IsNullOrEmpty(item9.UnitClass) ? name2 : (name2 + " (" + Misc.ReadRequest(item9.UnitClass) + ")"));
						darkFilterTreeNode18.Nodes.Add(darkFilterTreeNode10);
						darkFilterTreeNode10.ForeColor = GetUnitProficiencyColor(item9);
						darkFilterTreeNode10.Tag = item9;
						if (!item9.IsGroup)
						{
							continue;
						}
						foreach (ActiveUnit value3 in ((Group)item9).Units.Values)
						{
							DarkFilterTreeNode darkFilterTreeNode11 = new DarkFilterTreeNode(WriteInterruptibleError(value3));
							darkFilterTreeNode10.Nodes.Add(darkFilterTreeNode11);
							darkFilterTreeNode11.ForeColor = GetUnitProficiencyColor(value3);
							darkFilterTreeNode11.Tag = value3;
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception exception_5 = ex5;
						exception_5?.Data.Add("Error at 523253955y05", "");
						GameGeneral.WriteExceptionsToLog(ref exception_5);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				darkFilterTreeNode18.Expanded = true;
			}
		}
	}

	private void InvokeInterruptibleError()
	{
		TV_ByType.Nodes.Clear();
		if (Information.IsNothing(Client.CurrentSide))
		{
			return;
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		list.AddRange(Client.CurrentSide.Units);
		List<ActiveUnit> list2 = list.OrderBy((ActiveUnit theU) => theU.Name).ToList();
		List<DarkFilterTreeNode> list3 = new List<DarkFilterTreeNode>();
		foreach (ActiveUnit Local_theAU in list2)
		{
			try
			{
				if (Local_theAU.UnitType == GlobalVariables.ActiveUnitType.None)
				{
					continue;
				}
				DarkFilterTreeNode darkFilterTreeNode = null;
				_ = Local_theAU.UnitType;
				string text = WriteInterruptibleError(Local_theAU);
				DarkFilterTreeNode darkFilterTreeNode2 = list3.Where((DarkFilterTreeNode theNode) => Conversions.ToInteger(theNode.Tag) == (int)Local_theAU.UnitType).FirstOrDefault();
				if (darkFilterTreeNode2 == null)
				{
					darkFilterTreeNode2 = new DarkFilterTreeNode();
					darkFilterTreeNode2.Tag = (int)Local_theAU.UnitType;
					darkFilterTreeNode2.Font = new Font(TV_ByType.Font, FontStyle.Regular);
					darkFilterTreeNode2.ForeColor = Color.White;
					darkFilterTreeNode2.Text = Local_theAU.UnitType_String;
					darkFilterTreeNode2.ParentTree = TV_ByType;
					list3.Add(darkFilterTreeNode2);
				}
				DarkFilterTreeNode darkFilterTreeNode3 = darkFilterTreeNode2.Nodes.Where((DarkFilterTreeNode theNode) => Conversions.ToInteger(theNode.Tag) == Local_theAU.SubType).FirstOrDefault();
				if (darkFilterTreeNode3 == null)
				{
					darkFilterTreeNode3 = new DarkFilterTreeNode();
					darkFilterTreeNode3.Tag = Local_theAU.SubType;
					darkFilterTreeNode3.Font = new Font(TV_ByType.Font, FontStyle.Regular);
					darkFilterTreeNode3.ForeColor = Color.White;
					if (Local_theAU.UnitType == GlobalVariables.ActiveUnitType.Facility)
					{
						Facility facility = (Facility)Local_theAU;
						darkFilterTreeNode3.Text = facility.Type_Description;
					}
					else
					{
						darkFilterTreeNode3.Text = Local_theAU.SubTypeDescription;
					}
					darkFilterTreeNode3.ParentTree = TV_ByType;
					darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
				}
				darkFilterTreeNode = new DarkFilterTreeNode();
				darkFilterTreeNode.Tag = Local_theAU;
				darkFilterTreeNode.Font = new Font(TV_ByType.Font, FontStyle.Regular);
				darkFilterTreeNode.ForeColor = GetUnitProficiencyColor(Local_theAU);
				darkFilterTreeNode.Text = text;
				darkFilterTreeNode.ParentTree = TV_ByType;
				darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 523253955y06", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		try
		{
			foreach (DarkFilterTreeNode item in list3)
			{
				TV_ByType.Nodes.Add(item);
				item.EnsureVisible();
			}
			InterpreterObjectListener.RunInterruptibleTask(TV_ByType);
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 523253955y07", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SetupInterruptibleError()
	{
		if (TGV_Contacts.Nodes.Count > 0)
		{
			TGV_Contacts.Nodes.Clear();
		}
		List<Contact> list = new List<Contact>(Client.CurrentSide.Contacts.Count + Client.CurrentSide.BaseContacts.Count);
		try
		{
			list.AddRange(Client.CurrentSide.Contacts_List);
			list.AddRange(Client.CurrentSide.BaseContacts_List);
			list = list.OrderBy((Contact theC) => theC.Name).ToList();
			foreach (Contact item in list)
			{
				if (!item.ActualUnit.IsGroupMember() || !item.ActualUnit.GetParentGroup().IsLandInstallation)
				{
					TreeGridNode treeGridNode = TGV_Contacts.Nodes.Add();
					ExcludeInterruptibleError(treeGridNode, item);
					if (item.ActualUnit.IsGroup)
					{
						treeGridNode.Nodes.Add("temp");
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y08", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ExcludeInterruptibleError(TreeGridNode treeGridNode_0, Contact contact_0)
	{
		try
		{
			if (contact_0.ActualUnit.IsGroup)
			{
				treeGridNode_0.SetValues(contact_0.Name, Contact.GeneralClassificationString(contact_0), contact_0.GetStance(Client.CurrentSide).ToString());
			}
			else
			{
				treeGridNode_0.SetValues(contact_0.Name, Contact.GeneralClassificationString(contact_0), contact_0.GetStance(Client.CurrentSide).ToString(), contact_0.BDA_StructuralIntegrity.HasValue ? (Misc.FlushRequest(contact_0.BDA_StructuralIntegrity) + " (" + (((long)Math.Round(contact_0.TimeSinceBDA) == 0L) ? "0 sec" : Misc.UpdateRequest((long)Math.Round(contact_0.TimeSinceBDA))) + "前）") : "---", CompareInterruptibleError(contact_0));
			}
			treeGridNode_0.Tag = contact_0.ActualUnit.ObjectID;
			treeGridNode_0.DefaultCellStyle.ForeColor = Client.GetColorFromStance(contact_0.GetStance(Client.CurrentSide));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y09", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string IncludeInterruptibleError(Aircraft aircraft_0)
	{
		string result = null;
		try
		{
			ActiveUnit currentHostUnit = aircraft_0.AirOps.CurrentHostUnit;
			if (Information.IsNothing(currentHostUnit))
			{
				result = "Airborne";
				return result;
			}
			result = currentHostUnit.Name;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y10", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private string SearchInterruptibleError(Aircraft aircraft_0)
	{
		string result = null;
		try
		{
			string string_ = null;
			string text;
			if (aircraft_0.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance)
			{
				text = "[不可用]" + aircraft_0.Name;
			}
			else
			{
				string text2 = (aircraft_0.IsOperating() ? "Airborne" : aircraft_0.AirOps.CurrentHostUnit.Name);
				string text3 = (Information.IsNothing(aircraft_0.Loadout) ? "" : (" (" + aircraft_0.Loadout.Name + ")"));
				text = aircraft_0.Name + text3 + " (" + text2 + ")";
			}
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y11", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void EnableInterruptibleError(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.Escape && base.Visible)
			{
				Close();
				return;
			}
			if (base.Visible)
			{
				if (e.KeyCode == Keys.Prior || e.KeyCode == Keys.Next || e.KeyCode == Keys.End || e.KeyCode == Keys.Home || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
				{
					return;
				}
				if (e.KeyCode == Keys.Add)
				{
					if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByMission", TextCompare: true) == 0)
					{
						InterpreterObjectListener.RunInterruptibleTask(TV_ByMission);
					}
					else if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByGroup", TextCompare: true) == 0)
					{
						InterpreterObjectListener.RunInterruptibleTask(TV_ByGroup);
					}
					else
					{
						InterpreterObjectListener.RunInterruptibleTask(TV_ByType);
					}
					e.Handled = true;
					e.SuppressKeyPress = true;
					return;
				}
				if (e.KeyCode == Keys.Subtract)
				{
					if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByMission", TextCompare: true) == 0)
					{
						InterpreterObjectListener.AssetInterruptibleTask(TV_ByMission);
					}
					else if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByGroup", TextCompare: true) == 0)
					{
						InterpreterObjectListener.AssetInterruptibleTask(TV_ByGroup);
					}
					else
					{
						InterpreterObjectListener.AssetInterruptibleTask(TV_ByType);
					}
					e.Handled = true;
					e.SuppressKeyPress = true;
					return;
				}
				if (e.KeyCode == Keys.Subtract || (e.KeyCode == Keys.C && e.Modifiers == Keys.Control) || (e.KeyCode == Keys.X && e.Modifiers == Keys.Control))
				{
					return;
				}
			}
			if (!TB_SearchOOB.Focused)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y12", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ChangeInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			GlobalVariables.ProficiencyLevel? proficiency = null;
			switch (CB_Proficiency.SelectedIndex)
			{
			case 0:
				proficiency = GlobalVariables.ProficiencyLevel.Novice;
				break;
			case 1:
				proficiency = GlobalVariables.ProficiencyLevel.Cadet;
				break;
			case 2:
				proficiency = GlobalVariables.ProficiencyLevel.Regular;
				break;
			case 3:
				proficiency = GlobalVariables.ProficiencyLevel.Veteran;
				break;
			case 4:
				proficiency = GlobalVariables.ProficiencyLevel.Ace;
				break;
			case 5:
				proficiency = null;
				break;
			}
			switch (TabControl1.SelectedIndex)
			{
			case 0:
			{
				foreach (DarkFilterTreeNode selectedNode in TV_ByGroup.SelectedNodes)
				{
					((ActiveUnit)selectedNode.Tag).Proficiency = proficiency;
					selectedNode.ForeColor = GetUnitProficiencyColor((ActiveUnit)selectedNode.Tag);
					if (!((ActiveUnit)selectedNode.Tag).IsGroup)
					{
						continue;
					}
					foreach (DarkFilterTreeNode node in selectedNode.Nodes)
					{
						node.ForeColor = GetUnitProficiencyColor((ActiveUnit)node.Tag);
					}
				}
				break;
			}
			case 1:
			{
				foreach (DarkFilterTreeNode selectedNode2 in TV_ByMission.SelectedNodes)
				{
					try
					{
						if (!((Module_Unit.Unit)selectedNode2.Tag).IsActiveUnit)
						{
							continue;
						}
						((ActiveUnit)selectedNode2.Tag).Proficiency = proficiency;
						selectedNode2.ForeColor = GetUnitProficiencyColor((ActiveUnit)selectedNode2.Tag);
						if (!((ActiveUnit)selectedNode2.Tag).IsGroup)
						{
							continue;
						}
						foreach (DarkFilterTreeNode node2 in selectedNode2.Nodes)
						{
							node2.ForeColor = GetUnitProficiencyColor((ActiveUnit)node2.Tag);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200402", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				break;
			}
			case 2:
			{
				foreach (DarkFilterTreeNode selectedNode3 in TV_ByType.SelectedNodes)
				{
					if (!selectedNode3.Tag.GetType().IsPrimitive)
					{
						((ActiveUnit)selectedNode3.Tag).Proficiency = proficiency;
						selectedNode3.ForeColor = GetUnitProficiencyColor((ActiveUnit)selectedNode3.Tag);
					}
				}
				break;
			}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 523253955y13", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InitInterruptibleError(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CheckInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			if (TV_ByGroup.SelectedNodes.Count != 1)
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)TV_ByGroup.SelectedNodes[0].Tag;
			if (activeUnit.IsOperating())
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
				Client.SelectThisUnit(activeUnit, bool_0: true);
			}
			else
			{
				Client.SelectThisUnit(activeUnit, bool_0: true);
			}
			GlobalVariables.ProficiencyLevel? proficiency = activeUnit.Proficiency;
			int? num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				CB_Proficiency.SelectedIndex = 0;
				return;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				CB_Proficiency.SelectedIndex = 1;
				return;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				CB_Proficiency.SelectedIndex = 2;
				return;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				CB_Proficiency.SelectedIndex = 3;
				return;
			}
			num = (int?)proficiency;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
			{
				CB_Proficiency.SelectedIndex = 4;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y14", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ConcatInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			if (TV_ByMission.SelectedNodes.Count != 1)
			{
				return;
			}
			try
			{
				if ((object)TV_ByMission.SelectedNodes[0].Tag.GetType().BaseType == typeof(Mission) || (object)TV_ByMission.SelectedNodes[0].Tag.GetType() == typeof(string) || !((Module_Unit.Unit)TV_ByMission.SelectedNodes[0].Tag).IsActiveUnit)
				{
					return;
				}
				ActiveUnit activeUnit = (ActiveUnit)TV_ByMission.SelectedNodes[0].Tag;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
				Client.SelectThisUnit(activeUnit, bool_0: true);
				GlobalVariables.ProficiencyLevel? proficiency = activeUnit.Proficiency;
				int? num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 0;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 1;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 2;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 3;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 4;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200401", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 523253955y15", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InterruptInterruptibleError(object sender, MouseEventArgs e)
	{
		try
		{
			ActiveUnit activeUnit_ = null;
			sender.ToString();
			if ((object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType().BaseType == typeof(Mission) || (object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType() == typeof(string))
			{
				return;
			}
			if (sender.GetType() == typeof(DarkFilterTreeView))
			{
				activeUnit_ = (ActiveUnit)((DarkFilterTreeView)sender).SelectedNodes[0].Tag;
			}
			if (sender.GetType() == typeof(DarkTreeGridView))
			{
				activeUnit_ = (ActiveUnit)((DarkTreeGridView)sender).CurrentNode.Tag;
			}
			if (Client.SelectedUnit != null)
			{
				if (Client.SelectedUnit.IsActiveUnit)
				{
					activeUnit_ = (ActiveUnit)Client.SelectedUnit;
				}
				if (Client.SelectedUnit.DisableWriter())
				{
					activeUnit_ = ((Contact)Client.SelectedUnit).ActualUnit;
				}
				if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					activeUnit_ = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				Client.smethod_1(activeUnit_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y16", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RemoveInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			if (TV_ByType.SelectedNodes.Count != 1 || TV_ByType.SelectedNodes[0].Tag.GetType().IsPrimitive)
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)TV_ByType.SelectedNodes[0].Tag;
			if (activeUnit.IsOperating())
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
				Client.SelectThisUnit(activeUnit, bool_0: true);
				GlobalVariables.ProficiencyLevel? proficiency = activeUnit.Proficiency;
				int? num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 0;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 1;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 2;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 3;
					return;
				}
				num = (int?)proficiency;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					CB_Proficiency.SelectedIndex = 4;
				}
			}
			else
			{
				Client.SelectThisUnit(activeUnit, bool_0: true);
				ActiveUnit activeUnit2 = null;
				activeUnit2 = ((activeUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft) ? ((Aircraft)activeUnit).AirOps.CurrentHostUnit : activeUnit.DockingOps.CurrentHostUnit);
				if (activeUnit2 != null)
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y17", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FindInterruptibleError(object sender, MouseEventArgs e)
	{
		try
		{
			ActiveUnit activeUnit_ = null;
			sender.ToString();
			if ((object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType() == typeof(string) || (object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType() == typeof(int))
			{
				return;
			}
			if (sender.GetType() == typeof(DarkFilterTreeView))
			{
				activeUnit_ = (ActiveUnit)((DarkFilterTreeView)sender).SelectedNodes[0].Tag;
			}
			if (sender.GetType() == typeof(DarkTreeGridView))
			{
				activeUnit_ = (ActiveUnit)((DarkTreeGridView)sender).CurrentNode.Tag;
			}
			if (Client.SelectedUnit != null)
			{
				if (Client.SelectedUnit.IsActiveUnit)
				{
					activeUnit_ = (ActiveUnit)Client.SelectedUnit;
				}
				if (Client.SelectedUnit.DisableWriter())
				{
					activeUnit_ = ((Contact)Client.SelectedUnit).ActualUnit;
				}
				if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					activeUnit_ = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				Client.smethod_1(activeUnit_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y18", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SetInterruptibleError(object sender, EventArgs e)
	{
		BuildWindow();
		TV_ByGroup.Focus();
	}

	private void FillInterruptibleError(object sender, EventArgs e)
	{
		PopInterruptibleError();
	}

	private void CalculateInterruptibleError(object sender, KeyPressEventArgs e)
	{
		PopInterruptibleError();
	}

	private void PopInterruptibleError()
	{
		try
		{
			TV_ByGroup.SetFilterString(TB_SearchOOB.Text);
			TV_ByMission.SetFilterString(TB_SearchOOB.Text);
			TV_ByType.SetFilterString(TB_SearchOOB.Text);
			foreach (TreeGridNode node in TGV_Contacts.Nodes)
			{
				if (node.Visible)
				{
					if (Conversions.ToString(((DataGridViewTextBoxCell)node.Cells[0]).Value).ToLower().Contains(TB_SearchOOB.Text.ToLower()))
					{
						node.DefaultCellStyle.BackColor = Color.DarkGreen;
					}
					else
					{
						node.DefaultCellStyle.BackColor = TGV_Contacts.DefaultCellStyle.BackColor;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y19", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InstantiateInterruptibleError(object sender, ExpandingEventArgs e)
	{
		try
		{
			Contact contact = Client.CurrentSide.BaseContacts[Conversions.ToString(e.Node.Tag)];
			if (contact == null)
			{
				return;
			}
			Group group = (Group)contact.ActualUnit;
			e.Node.Nodes.Clear();
			foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
			{
				if (contacts_.ActualUnit.IsGroupMember() && contacts_.ActualUnit.GetParentGroup() == group)
				{
					TreeGridNode treeGridNode = e.Node.Nodes.Add(contacts_.Name, contacts_.ContactType_String, contacts_.GetStance(Client.CurrentSide).ToString(), contacts_.BDA_StructuralIntegrity.HasValue ? (Misc.FlushRequest(contacts_.BDA_StructuralIntegrity) + " (" + Misc.UpdateRequest((long)Math.Round(contacts_.TimeSinceBDA)) + "前）") : "---", CompareInterruptibleError(contacts_));
					treeGridNode.Tag = contacts_.ActualUnit.ObjectID;
					treeGridNode.DefaultCellStyle.ForeColor = Client.GetColorFromStance(contacts_.GetStance(Client.CurrentSide));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y20", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CreateInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			if (TGV_Contacts.CurrentNode == null)
			{
				return;
			}
			string text = Conversions.ToString(TGV_Contacts.CurrentNode.Tag);
			if (Client.CurrentSide.Contacts.ContainsKey(text))
			{
				Contact contact = Client.CurrentSide.Contacts[text];
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(contact.GetLongitude(), contact.GetLatitude()));
				Client.SelectThisUnit(contact, bool_0: true);
				if (contact.ActualUnit.IsGroupMember() && Client.CurrentMapProfile.ViewMode == MapProfile.MapViewMode.GroupView)
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.SwitchView();
				}
			}
			else if (Client.CurrentSide.BaseContacts.ContainsKey(text))
			{
				Contact contact2 = Client.CurrentSide.BaseContacts[text];
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(contact2.GetLongitude(), contact2.GetLatitude()));
				Client.SelectThisUnit(contact2, bool_0: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y21", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string CompareInterruptibleError(Contact contact_0)
	{
		string result = null;
		try
		{
			if (contact_0.IncludeImporter(Client.CurrentSide).Count <= 0)
			{
				result = "---";
				return result;
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			string text = null;
			foreach (Contact.HostedUnitReconRecord item in contact_0.IncludeImporter(Client.CurrentSide))
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
			result = string.Join("\r\n", list);
			return result;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 523253955y22", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void ReadInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			if (Client.CurrentGame.Status != Game._GameStatus.Running)
			{
				return;
			}
			int num = TGV_Contacts.Nodes.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					TreeGridNode treeGridNode = TGV_Contacts.Nodes[i];
					Contact contact = null;
					if (Client.CurrentSide.Contacts.ContainsKey(treeGridNode.Tag.ToString()))
					{
						contact = Client.CurrentSide.Contacts[treeGridNode.Tag.ToString()];
					}
					else if (Client.CurrentSide.BaseContacts.ContainsKey(treeGridNode.Tag.ToString()))
					{
						contact = Client.CurrentSide.BaseContacts[treeGridNode.Tag.ToString()];
					}
					if (contact == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						ExcludeInterruptibleError(treeGridNode, contact);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y23", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DisableInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			switch (TabControl1.SelectedIndex)
			{
			case 0:
				NewInterruptibleError();
				break;
			case 1:
				PushInterruptibleError();
				break;
			case 2:
				InvokeInterruptibleError();
				break;
			case 3:
				SetupInterruptibleError();
				break;
			}
			UpdateInterruptibleError();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y24", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void UpdateInterruptibleError()
	{
		try
		{
			switch (TabControl1.SelectedIndex)
			{
			case 0:
				InsertInterruptibleError(stateAdapter);
				break;
			case 1:
				InsertInterruptibleError(_AuthenticationAdapter);
				break;
			case 2:
				InsertInterruptibleError(paramsAdapter);
				break;
			case 3:
				InsertInterruptibleError(m_InfoAdapter);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y25", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InsertInterruptibleError(bool bool_0)
	{
		try
		{
			if (bool_0)
			{
				DarkUIButton_0.Text = "收缩列表";
			}
			else
			{
				DarkUIButton_0.Text = "展开列表";
			}
			DarkUIButton_0.Refresh();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y26", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PrepareInterruptibleError(object sender, EventArgs e)
	{
		try
		{
			switch (TabControl1.SelectedIndex)
			{
			case 0:
			{
				helperAdapter = !helperAdapter;
				IEnumerator enumerator4 = null;
				try
				{
					enumerator4 = TabControl1.SelectedTab.Controls.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						Control control4 = (Control)enumerator4.Current;
						if (control4.GetType() == typeof(DarkFilterTreeView))
						{
							if (helperAdapter)
							{
								((DarkFilterTreeView)control4).ExpandAllItems();
								DarkUIButton_0.Text = "收缩列表";
							}
							else
							{
								((DarkFilterTreeView)control4).CollapseAllItem();
								DarkUIButton_0.Text = "展开列表";
							}
						}
					}
					break;
				}
				finally
				{
					if (enumerator4 is IDisposable)
					{
						(enumerator4 as IDisposable).Dispose();
					}
				}
			}
			case 1:
			{
				_MapperAdapter = !_MapperAdapter;
				IEnumerator enumerator3 = null;
				try
				{
					enumerator3 = TabControl1.SelectedTab.Controls.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						Control control3 = (Control)enumerator3.Current;
						if (control3.GetType() == typeof(DarkFilterTreeView))
						{
							if (_MapperAdapter)
							{
								((DarkFilterTreeView)control3).ExpandAllItems();
								DarkUIButton_0.Text = "收缩列表";
							}
							else
							{
								((DarkFilterTreeView)control3).CollapseAllItem();
								DarkUIButton_0.Text = "展开列表";
							}
						}
					}
					break;
				}
				finally
				{
					if (enumerator3 is IDisposable)
					{
						(enumerator3 as IDisposable).Dispose();
					}
				}
			}
			case 2:
			{
				m_ManagerAdapter = !m_ManagerAdapter;
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = TabControl1.SelectedTab.Controls.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						Control control2 = (Control)enumerator2.Current;
						if (control2.GetType() == typeof(DarkFilterTreeView))
						{
							if (m_ManagerAdapter)
							{
								((DarkFilterTreeView)control2).ExpandAllItems();
								DarkUIButton_0.Text = "收缩列表";
							}
							else
							{
								((DarkFilterTreeView)control2).CollapseAllItem();
								DarkUIButton_0.Text = "展开列表";
							}
						}
					}
					break;
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
			}
			case 3:
			{
				m_GetterAdapter = !m_GetterAdapter;
				IEnumerator enumerator = null;
				try
				{
					enumerator = TabControl1.SelectedTab.Controls.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Control control = (Control)enumerator.Current;
						if (control.GetType() == typeof(DarkTreeGridView))
						{
							if (m_GetterAdapter)
							{
								((DarkTreeGridView)control).ExpandAllItems();
								DarkUIButton_0.Text = "收缩列表";
							}
							else
							{
								((DarkTreeGridView)control).CollapseAllItem();
								DarkUIButton_0.Text = "展开列表";
							}
						}
					}
					break;
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 523253955y27", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private string ReflectInterruptibleError(Aircraft aircraft_0)
	{
		return IncludeInterruptibleError(aircraft_0);
	}

	[CompilerGenerated]
	private string VisitInterruptibleError(Aircraft aircraft_0)
	{
		return IncludeInterruptibleError(aircraft_0);
	}

	[CompilerGenerated]
	private string RestartInterruptibleError(Aircraft aircraft_0)
	{
		return IncludeInterruptibleError(aircraft_0);
	}
}
