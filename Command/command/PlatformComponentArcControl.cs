using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class PlatformComponentArcControl : DarkUserControl
{
	private IContainer listenerSchema;

	[AccessedThroughProperty("CB_PB1")]
	[CompilerGenerated]
	private DarkCheckBox _ConfigSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PB2")]
	private DarkCheckBox _RegistrySchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SB1")]
	private DarkCheckBox _DefinitionSchema;

	[AccessedThroughProperty("CB_SB2")]
	[CompilerGenerated]
	private DarkCheckBox valSchema;

	[AccessedThroughProperty("CB_PMF1")]
	[CompilerGenerated]
	private DarkCheckBox _WrapperSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PMF2")]
	private DarkCheckBox m_ObserverSchema;

	[AccessedThroughProperty("CB_SMF2")]
	[CompilerGenerated]
	private DarkCheckBox _IssuerSchema;

	[AccessedThroughProperty("CB_SMF1")]
	[CompilerGenerated]
	private DarkCheckBox clientSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PMA2")]
	private DarkCheckBox m_DicSchema;

	[AccessedThroughProperty("CB_PMA1")]
	[CompilerGenerated]
	private DarkCheckBox _ConsumerSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PS2")]
	private DarkCheckBox facadeSchema;

	[AccessedThroughProperty("CB_PS1")]
	[CompilerGenerated]
	private DarkCheckBox proxySchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SS2")]
	private DarkCheckBox readerSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SS1")]
	private DarkCheckBox _PropertySchema;

	[AccessedThroughProperty("CB_SMA1")]
	[CompilerGenerated]
	private DarkCheckBox _ImporterSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SMA2")]
	private DarkCheckBox _RepositorySchema;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox bridgeSchema;

	public PlatformComponent._Coverage theCoverage;

	internal DarkCheckBox CB_PB1
	{
		[CompilerGenerated]
		get
		{
			return _ConfigSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptInterruptibleCode;
			DarkCheckBox configSchema = _ConfigSchema;
			if (configSchema != null)
			{
				configSchema.CheckedChanged -= value2;
			}
			_ConfigSchema = value;
			configSchema = _ConfigSchema;
			if (configSchema != null)
			{
				configSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PB2
	{
		[CompilerGenerated]
		get
		{
			return _RegistrySchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleCode;
			DarkCheckBox registrySchema = _RegistrySchema;
			if (registrySchema != null)
			{
				registrySchema.CheckedChanged -= value2;
			}
			_RegistrySchema = value;
			registrySchema = _RegistrySchema;
			if (registrySchema != null)
			{
				registrySchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SB1
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeInterruptibleCode;
			DarkCheckBox definitionSchema = _DefinitionSchema;
			if (definitionSchema != null)
			{
				definitionSchema.CheckedChanged -= value2;
			}
			_DefinitionSchema = value;
			definitionSchema = _DefinitionSchema;
			if (definitionSchema != null)
			{
				definitionSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SB2
	{
		[CompilerGenerated]
		get
		{
			return valSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeInterruptibleCode;
			DarkCheckBox darkCheckBox = valSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			valSchema = value;
			darkCheckBox = valSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PMF1
	{
		[CompilerGenerated]
		get
		{
			return _WrapperSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleCode;
			DarkCheckBox wrapperSchema = _WrapperSchema;
			if (wrapperSchema != null)
			{
				wrapperSchema.CheckedChanged -= value2;
			}
			_WrapperSchema = value;
			wrapperSchema = _WrapperSchema;
			if (wrapperSchema != null)
			{
				wrapperSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PMF2
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleCode;
			DarkCheckBox observerSchema = m_ObserverSchema;
			if (observerSchema != null)
			{
				observerSchema.CheckedChanged -= value2;
			}
			m_ObserverSchema = value;
			observerSchema = m_ObserverSchema;
			if (observerSchema != null)
			{
				observerSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SMF2
	{
		[CompilerGenerated]
		get
		{
			return _IssuerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableInterruptibleCode;
			DarkCheckBox issuerSchema = _IssuerSchema;
			if (issuerSchema != null)
			{
				issuerSchema.CheckedChanged -= value2;
			}
			_IssuerSchema = value;
			issuerSchema = _IssuerSchema;
			if (issuerSchema != null)
			{
				issuerSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SMF1
	{
		[CompilerGenerated]
		get
		{
			return clientSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchInterruptibleCode;
			DarkCheckBox darkCheckBox = clientSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			clientSchema = value;
			darkCheckBox = clientSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PMA2
	{
		[CompilerGenerated]
		get
		{
			return m_DicSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateInterruptibleCode;
			DarkCheckBox dicSchema = m_DicSchema;
			if (dicSchema != null)
			{
				dicSchema.CheckedChanged -= value2;
			}
			m_DicSchema = value;
			dicSchema = m_DicSchema;
			if (dicSchema != null)
			{
				dicSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PMA1
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillInterruptibleCode;
			DarkCheckBox consumerSchema = _ConsumerSchema;
			if (consumerSchema != null)
			{
				consumerSchema.CheckedChanged -= value2;
			}
			_ConsumerSchema = value;
			consumerSchema = _ConsumerSchema;
			if (consumerSchema != null)
			{
				consumerSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PS2
	{
		[CompilerGenerated]
		get
		{
			return facadeSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptibleCode;
			DarkCheckBox darkCheckBox = facadeSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			facadeSchema = value;
			darkCheckBox = facadeSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_PS1
	{
		[CompilerGenerated]
		get
		{
			return proxySchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptibleCode;
			DarkCheckBox darkCheckBox = proxySchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			proxySchema = value;
			darkCheckBox = proxySchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SS2
	{
		[CompilerGenerated]
		get
		{
			return readerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleCode;
			DarkCheckBox darkCheckBox = readerSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			readerSchema = value;
			darkCheckBox = readerSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SS1
	{
		[CompilerGenerated]
		get
		{
			return _PropertySchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleCode;
			DarkCheckBox propertySchema = _PropertySchema;
			if (propertySchema != null)
			{
				propertySchema.CheckedChanged -= value2;
			}
			_PropertySchema = value;
			propertySchema = _PropertySchema;
			if (propertySchema != null)
			{
				propertySchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SMA1
	{
		[CompilerGenerated]
		get
		{
			return _ImporterSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleCode;
			DarkCheckBox importerSchema = _ImporterSchema;
			if (importerSchema != null)
			{
				importerSchema.CheckedChanged -= value2;
			}
			_ImporterSchema = value;
			importerSchema = _ImporterSchema;
			if (importerSchema != null)
			{
				importerSchema.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SMA2
	{
		[CompilerGenerated]
		get
		{
			return _RepositorySchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleCode;
			DarkCheckBox repositorySchema = _RepositorySchema;
			if (repositorySchema != null)
			{
				repositorySchema.CheckedChanged -= value2;
			}
			_RepositorySchema = value;
			repositorySchema = _RepositorySchema;
			if (repositorySchema != null)
			{
				repositorySchema.CheckedChanged += value2;
			}
		}
	}

	internal PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return bridgeSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleCode;
			PictureBox pictureBox = bridgeSchema;
			if (pictureBox != null)
			{
				pictureBox.DoubleClick -= value2;
			}
			bridgeSchema = value;
			pictureBox = bridgeSchema;
			if (pictureBox != null)
			{
				pictureBox.DoubleClick += value2;
			}
		}
	}

	public bool NoArcsSelected
	{
		get
		{
			if (theCoverage.SB1)
			{
				return false;
			}
			if (theCoverage.SB2)
			{
				return false;
			}
			if (theCoverage.SMF1)
			{
				return false;
			}
			if (theCoverage.SMF2)
			{
				return false;
			}
			if (theCoverage.SMA1)
			{
				return false;
			}
			if (theCoverage.SMA2)
			{
				return false;
			}
			if (theCoverage.SS1)
			{
				return false;
			}
			if (theCoverage.SS2)
			{
				return false;
			}
			if (theCoverage.PB1)
			{
				return false;
			}
			if (theCoverage.PB2)
			{
				return false;
			}
			if (theCoverage.PMF1)
			{
				return false;
			}
			if (theCoverage.PMF2)
			{
				return false;
			}
			if (theCoverage.PMA1)
			{
				return false;
			}
			if (theCoverage.PMA2)
			{
				return false;
			}
			if (theCoverage.PS1)
			{
				return false;
			}
			if (theCoverage.PS2)
			{
				return false;
			}
			return true;
		}
	}

	public bool AllArcsSelected
	{
		get
		{
			if (theCoverage.SB1)
			{
				if (theCoverage.SB2)
				{
					if (theCoverage.SMF1)
					{
						if (theCoverage.SMF2)
						{
							if (theCoverage.SMA1)
							{
								if (theCoverage.SMA2)
								{
									if (theCoverage.SS1)
									{
										if (theCoverage.SS2)
										{
											if (theCoverage.PB1)
											{
												if (theCoverage.PB2)
												{
													if (theCoverage.PMF1)
													{
														if (theCoverage.PMF2)
														{
															if (theCoverage.PMA1)
															{
																if (theCoverage.PMA2)
																{
																	if (theCoverage.PS1)
																	{
																		if (theCoverage.PS2)
																		{
																			return true;
																		}
																		return false;
																	}
																	return false;
																}
																return false;
															}
															return false;
														}
														return false;
													}
													return false;
												}
												return false;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public PlatformComponentArcControl()
	{
		base.DoubleClick += CreateInterruptibleCode;
		base.Load += InsertInterruptibleCode;
		theCoverage = new PlatformComponent._Coverage();
		SetupInterruptibleCode();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && listenerSchema != null)
			{
				listenerSchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SetupInterruptibleCode()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(PlatformComponentArcControl));
		CB_PB1 = new DarkCheckBox();
		CB_PB2 = new DarkCheckBox();
		CB_SB1 = new DarkCheckBox();
		CB_SB2 = new DarkCheckBox();
		CB_PMF1 = new DarkCheckBox();
		CB_PMF2 = new DarkCheckBox();
		CB_SMF2 = new DarkCheckBox();
		CB_SMF1 = new DarkCheckBox();
		CB_PMA2 = new DarkCheckBox();
		CB_PMA1 = new DarkCheckBox();
		CB_PS2 = new DarkCheckBox();
		CB_PS1 = new DarkCheckBox();
		CB_SS2 = new DarkCheckBox();
		CB_SS1 = new DarkCheckBox();
		CB_SMA1 = new DarkCheckBox();
		CB_SMA2 = new DarkCheckBox();
		PictureBox1 = new PictureBox();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		CB_PB1.Location = new Point(20, 8);
		CB_PB1.Name = "CB_PB1";
		CB_PB1.Size = new Size(15, 14);
		CB_PB1.TabIndex = 1;
		CB_PB2.Location = new Point(34, 4);
		CB_PB2.Name = "CB_PB2";
		CB_PB2.Size = new Size(15, 14);
		CB_PB2.TabIndex = 2;
		CB_SB1.Location = new Point(48, 4);
		CB_SB1.Name = "CB_SB1";
		CB_SB1.Size = new Size(15, 14);
		CB_SB1.TabIndex = 3;
		CB_SB2.Location = new Point(62, 7);
		CB_SB2.Name = "CB_SB2";
		CB_SB2.Size = new Size(15, 14);
		CB_SB2.TabIndex = 4;
		CB_PMF1.Location = new Point(5, 36);
		CB_PMF1.Name = "CB_PMF1";
		CB_PMF1.Size = new Size(15, 14);
		CB_PMF1.TabIndex = 5;
		CB_PMF2.Location = new Point(9, 22);
		CB_PMF2.Name = "CB_PMF2";
		CB_PMF2.Size = new Size(15, 14);
		CB_PMF2.TabIndex = 6;
		CB_SMF2.Location = new Point(78, 35);
		CB_SMF2.Name = "CB_SMF2";
		CB_SMF2.Size = new Size(15, 14);
		CB_SMF2.TabIndex = 7;
		CB_SMF1.Location = new Point(72, 21);
		CB_SMF1.Name = "CB_SMF1";
		CB_SMF1.Size = new Size(15, 14);
		CB_SMF1.TabIndex = 8;
		CB_PMA2.Location = new Point(5, 51);
		CB_PMA2.Name = "CB_PMA2";
		CB_PMA2.Size = new Size(15, 14);
		CB_PMA2.TabIndex = 9;
		CB_PMA1.Location = new Point(9, 65);
		CB_PMA1.Name = "CB_PMA1";
		CB_PMA1.Size = new Size(15, 14);
		CB_PMA1.TabIndex = 10;
		CB_PS2.Location = new Point(20, 79);
		CB_PS2.Name = "CB_PS2";
		CB_PS2.Size = new Size(15, 14);
		CB_PS2.TabIndex = 11;
		CB_PS1.Location = new Point(34, 82);
		CB_PS1.Name = "CB_PS1";
		CB_PS1.Size = new Size(15, 14);
		CB_PS1.TabIndex = 12;
		CB_SS2.Location = new Point(49, 82);
		CB_SS2.Name = "CB_SS2";
		CB_SS2.Size = new Size(15, 14);
		CB_SS2.TabIndex = 13;
		CB_SS1.Location = new Point(63, 77);
		CB_SS1.Name = "CB_SS1";
		CB_SS1.Size = new Size(15, 14);
		CB_SS1.TabIndex = 14;
		CB_SMA1.Location = new Point(78, 49);
		CB_SMA1.Name = "CB_SMA1";
		CB_SMA1.Size = new Size(15, 14);
		CB_SMA1.TabIndex = 15;
		CB_SMA2.Location = new Point(72, 63);
		CB_SMA2.Name = "CB_SMA2";
		CB_SMA2.Size = new Size(15, 14);
		CB_SMA2.TabIndex = 16;
		PictureBox1.Image = componentResourceManager.GetObject("PictureBox1.Image");
		PictureBox1.Location = new Point(22, 20);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(50, 61);
		PictureBox1.TabIndex = 17;
		PictureBox1.TabStop = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(CB_SMA2);
		base.Controls.Add(CB_SMA1);
		base.Controls.Add(CB_SS1);
		base.Controls.Add(CB_SS2);
		base.Controls.Add(CB_PS1);
		base.Controls.Add(CB_PS2);
		base.Controls.Add(CB_PMA1);
		base.Controls.Add(CB_PMA2);
		base.Controls.Add(CB_SMF1);
		base.Controls.Add(CB_SMF2);
		base.Controls.Add(CB_PMF2);
		base.Controls.Add(CB_PMF1);
		base.Controls.Add(CB_SB2);
		base.Controls.Add(CB_SB1);
		base.Controls.Add(CB_PB2);
		base.Controls.Add(CB_PB1);
		base.Controls.Add(PictureBox1);
		base.Name = "PlatformComponentArcControl";
		base.Size = new Size(100, 100);
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void ExcludeInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SB1 = CB_SB1.Checked;
	}

	private void IncludeInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SB2 = CB_SB2.Checked;
	}

	private void SearchInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SMF1 = CB_SMF1.Checked;
	}

	private void EnableInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SMF2 = CB_SMF2.Checked;
	}

	private void ChangeInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SMA1 = CB_SMA1.Checked;
	}

	private void InitInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SMA2 = CB_SMA2.Checked;
	}

	private void CheckInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SS1 = CB_SS1.Checked;
	}

	private void ConcatInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.SS2 = CB_SS2.Checked;
	}

	private void InterruptInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PB1 = CB_PB1.Checked;
	}

	private void RemoveInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PB2 = CB_PB2.Checked;
	}

	private void FindInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PMF1 = CB_PMF1.Checked;
	}

	private void SetInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PMF2 = CB_PMF2.Checked;
	}

	private void FillInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PMA1 = CB_PMA1.Checked;
	}

	private void CalculateInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PMA2 = CB_PMA2.Checked;
	}

	private void PopInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PS1 = CB_PS1.Checked;
	}

	private void InstantiateInterruptibleCode(object sender, EventArgs e)
	{
		theCoverage.PS2 = CB_PS2.Checked;
	}

	private void CreateInterruptibleCode(object sender, EventArgs e)
	{
		CompareInterruptibleCode();
	}

	private void CompareInterruptibleCode()
	{
		if (AllArcsSelected)
		{
			DisableInterruptibleCode();
		}
		else
		{
			ReadInterruptibleCode();
		}
	}

	private void ReadInterruptibleCode()
	{
		theCoverage.PB1 = true;
		theCoverage.PB2 = true;
		theCoverage.PMA1 = true;
		theCoverage.PMA2 = true;
		theCoverage.PMF1 = true;
		theCoverage.PMF2 = true;
		theCoverage.PS1 = true;
		theCoverage.PS2 = true;
		theCoverage.SB1 = true;
		theCoverage.SB2 = true;
		theCoverage.SMA1 = true;
		theCoverage.SMA2 = true;
		theCoverage.SMF1 = true;
		theCoverage.SMF2 = true;
		theCoverage.SS1 = true;
		theCoverage.SS2 = true;
		CB_PB1.Checked = true;
		CB_PB2.Checked = true;
		CB_PMA1.Checked = true;
		CB_PMA2.Checked = true;
		CB_PMF1.Checked = true;
		CB_PMF2.Checked = true;
		CB_PS1.Checked = true;
		CB_PS2.Checked = true;
		CB_SB1.Checked = true;
		CB_SB2.Checked = true;
		CB_SMA1.Checked = true;
		CB_SMA2.Checked = true;
		CB_SMF1.Checked = true;
		CB_SMF2.Checked = true;
		CB_SS1.Checked = true;
		CB_SS2.Checked = true;
		Refresh();
	}

	private void DisableInterruptibleCode()
	{
		theCoverage.PB1 = false;
		theCoverage.PB2 = false;
		theCoverage.PMA1 = false;
		theCoverage.PMA2 = false;
		theCoverage.PMF1 = false;
		theCoverage.PMF2 = false;
		theCoverage.PS1 = false;
		theCoverage.PS2 = false;
		theCoverage.SB1 = false;
		theCoverage.SB2 = false;
		theCoverage.SMA1 = false;
		theCoverage.SMA2 = false;
		theCoverage.SMF1 = false;
		theCoverage.SMF2 = false;
		theCoverage.SS1 = false;
		theCoverage.SS2 = false;
		CB_PB1.Checked = false;
		CB_PB2.Checked = false;
		CB_PMA1.Checked = false;
		CB_PMA2.Checked = false;
		CB_PMF1.Checked = false;
		CB_PMF2.Checked = false;
		CB_PS1.Checked = false;
		CB_PS2.Checked = false;
		CB_SB1.Checked = false;
		CB_SB2.Checked = false;
		CB_SMA1.Checked = false;
		CB_SMA2.Checked = false;
		CB_SMF1.Checked = false;
		CB_SMF2.Checked = false;
		CB_SS1.Checked = false;
		CB_SS2.Checked = false;
		Refresh();
	}

	private void UpdateInterruptibleCode(object sender, EventArgs e)
	{
		CompareInterruptibleCode();
	}

	private void InsertInterruptibleCode(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
