using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class AboutBox1 : DarkSecondaryFormBase
{
	private IContainer annotationReader;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_version")]
	private DarkLabel iteratorReader;

	[AccessedThroughProperty("OKButton")]
	[CompilerGenerated]
	private DarkUIButton _InitializerReader;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_RoleReader;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Copyright")]
	private DarkLabel m_EventReader;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox m_GlobalReader;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox workerReader;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Licensing")]
	private DarkUITextBox m_AccountReader;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_License")]
	private DarkLabel stateReader;

	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	internal DarkLabel Label_version
	{
		[CompilerGenerated]
		get
		{
			return iteratorReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iteratorReader = value;
		}
	}

	internal DarkUIButton OKButton
	{
		[CompilerGenerated]
		get
		{
			return _InitializerReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = delegate
			{
				Close();
			};
			DarkUIButton initializerReader = _InitializerReader;
			if (initializerReader != null)
			{
				initializerReader.Click -= value2;
			}
			_InitializerReader = value;
			initializerReader = _InitializerReader;
			if (initializerReader != null)
			{
				initializerReader.Click += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_RoleReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RoleReader = value;
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_Copyright
	{
		[CompilerGenerated]
		get
		{
			return m_EventReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventReader = value;
		}
	}

	internal PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalReader = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return workerReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			workerReader = value;
		}
	}

	internal DarkUITextBox TB_Licensing
	{
		[CompilerGenerated]
		get
		{
			return m_AccountReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AccountReader = value;
		}
	}

	internal DarkLabel Label_License
	{
		[CompilerGenerated]
		get
		{
			return stateReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stateReader = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager temp = new ResourceManager("Command.AboutBox1", typeof(AboutBox1).Assembly);
				resourceMan = temp;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap PictureBox1_Image
	{
		get
		{
			object obj = ResourceManager.GetObject("PictureBox1.Image", resourceCulture);
			return (Bitmap)obj;
		}
	}

	public AboutBox1()
	{
		base.Load += delegate
		{
			Label_version.Text = GameGeneral.ProgramTitle;
			if (GameGeneral.LicenseTierContext == GameGeneral._ProLicenseTier.None)
			{
				string CancelListtext = "";
				if (Client.RunningInSteamMode)
				{
					CancelListtext += "Running in Steam mode.\r\n";
				}
				CancelListtext += "Licensed modules: \r\n";
				List<string> CancelListlist = new List<string>();
				foreach (KeyValuePair<Licensing.ModuleLicense, Licensing.InfoProcessResolver> CancelListitem in Licensing.PostRole())
				{
					if (Licensing.GetModuleIsLicensed(CancelListitem.Key))
					{
						CancelListlist.Add(CancelListitem.Value.m_ContainerMap);
					}
				}
				TB_Licensing.Visible = true;
				TB_Licensing.Text = CancelListtext + string.Join("\r\n", CancelListlist);
				Label_Copyright.Text = "(c) MatrixGames 2013-" + Conversions.ToString(DateTime.Now.Year);
			}
			else
			{
				TB_Licensing.Visible = false;
				Label_Copyright.Text = "(c) MatrixGames 2013-" + Conversions.ToString(DateTime.Now.Year);
			}
			StringBuilder CancelListstringBuilder = new StringBuilder();
			CancelListstringBuilder.Append("Geodesic model:\r\nCredits: T.Vincenty, \r\n'Direct and inverse solutions of geodesics of nested equations'. \r\nSurvey Review XXII, 176, April 1975. Pp.88-93.\r\nP.S.Zakatov. Kurs vysshei geodezii. 4th ed. M., 1976.\r\nU.S. Army Topographic Engineering Center, Geospatial Information Division 7701 Telegraph Road Alexandria, VA  22310-3864 - for TransMerc code\r\nGerald Evenden (proj code) and Frank Warmerdam (proj copyright holder)\r\nParts of code: (C) Dimitris V. Dranidis, 2009\r\nBrent minimization routine: AlgLib, (C) Bochkanov Sergey 09.04.2007\r\n\r\n");
			CancelListstringBuilder.Append("Weather model:\r\nThis module includes NOVAS 3.0f library from US Naval Observatory for astronomical calculations.\r\nBased on JPL ASCII ephemerides DE405 valid for 2000-2019 (will extend back to 1940s in the future)\r\nSources: ITU-R P.837 rainfall rate data\r\nDr. Tim Mitchell from UK Met.Office (Tyndall centre), CRU TS 2.1 (1901-2002 data)\r\nHansen's thermal anomaly data from http://data.giss.nasa.gov/gistemp/\r\n\r\n");
			CancelListstringBuilder.Append("Radar Model:\r\nRodney Spence and Glenn Feldhake of NASA (propagation code)\r\nProf. David C. Jenn of NPS (radjam code)\r\nMicrowaves101 - phased array plot\r\nRaafat Nasser (U.S. Dept of Commerce) - RCG-44\r\nW.L.Patterson, C.P.Hattan, G.E.Lindem, Richard A.Paulus,  H.V.Hitney, K.D.Anderson, Amalia E.Barrios  - EREPS V.3.0 user manual. Tech.Doc.2648. San Diego, May 1994.\r\nAmalia E. Barrios, W. L. Patterson. - Advanced Propagation Model  Ver.1.3.1 CSCI Documents Tech.Doc.3145. San Diego, August 2002.\r\nAREPS User Manual V.3.6. San Diego, December 2006.\r\nHerr Alfred Ochs (Peter-Behrens-Str. 14, D-6100 Darmstadt) - the neat rain attenuation model from  the COST 210 Hydrometeor Scatter Prediction Procedure\r\nSources: ITU-R F.1245-1; ITU-R M.1652, miscellaneous files from ITU-R\r\nH.T.Dougherty, E.J.Dutton, 1981 NTIA Report 81-69\r\nRadar Technology Encyclopedia, 1998. David K. Barton, Sergey A. Leonov (eds.) \r\nKuzmin, 1974\r\nF.B.Chernyi. Rasprostranenie radiovoln. 2nd ed. M., 1972\r\nA.I.Kupriyanov, A.V.Sakharov. Teoreticheskiye osnovy radioelektronnoy borby. M., 2007\r\nYu.P.Melnikov. Vozdushnaya radiotekhnicheskaya razvedka. M., 2005\r\nV.G.Radzievsky (ed.) Sovremennaya radioelectronnaya borba. M., 2006\r\nA.I.Kanaschenkov, V.I.Merkulov (eds.) Zaschita radiolokatsionnykh sistem ot pomekh. M., 2003\r\nMichale O. Kolawole (2002) Radar Systems, Peak Detection and Tracking. Oxford, UK. 388 p.\r\nRadar Handbook (2nd and 3rd eds.) Edited by Merrill I. Skolnik.\r\nElectronic Warfare and Radar Systems Engineering Handbook\r\nV.I.Borisov, V.M.Zinchuk, A.E.Limarev. Pomekhozaschischennost' sistem radiosvyazi s rasshireniyem spektra signalov metodom PPRCh. M., 2008.\r\n\r\n");
			CancelListstringBuilder.Append("Virtual Globe: (c)NASA WorldWind\r\n\r\n");
			CancelListstringBuilder.Append("\r\n");
			CancelListstringBuilder.Append("SRTM map layers & elevation data provided by NASA & based on Shuttle Radar Topography Mission.\r\n");
			CancelListstringBuilder.Append("Stamen Terrain & Stamen Roads & Cities map layers provided by Stamen Design & based on OpenStreetMap data.\r\n");
			CancelListstringBuilder.Append("Sentinel-2 map layer provided by EOX & based on ESA Copernicus Sentinel-2 missions.\r\n");
			CancelListstringBuilder.Append("Some of the sound effects included in Command have been acquired from http://www.freesfx.co.uk and are used under the site's terms of use.\r\n");
			CancelListstringBuilder.Append("Images & 3D models rights belong to respective IP holders unless property of MatrixGames.\r\n");
			CancelListstringBuilder.Append("\r\n");
			CancelListstringBuilder.Append("Thanks to our families & friends who supported us.\r\n\r\n");
			TextBox1.Text = CancelListstringBuilder.ToString();
		};
		base.KeyDown += delegate(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape && base.Visible)
			{
				Close();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		};
		base.FormClosing += delegate
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		};
		StopList();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && annotationReader != null)
		{
			annotationReader.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void StopList()
	{
		Label_License = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		Label_Copyright = new DarkLabel();
		PictureBox1 = new PictureBox();
		Label_version = new DarkLabel();
		OKButton = new DarkUIButton();
		TB_Licensing = new DarkUITextBox();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		Label_License.AutoSize = true;
		Label_License.BackColor = Color.Transparent;
		Label_License.ForeColor = Color.FromArgb(220, 220, 220);
		Label_License.Location = new Point(228, 41);
		Label_License.MaximumSize = new Size(400, 0);
		Label_License.Name = "Label_License";
		Label_License.Size = new Size(44, 13);
		Label_License.TabIndex = 9;
		Label_License.Text = "许可";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = SystemColors.Control;
		TextBox1.Font = new Font("Segoe UI", 8f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(13, 154);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = true;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(620, 255);
		TextBox1.TabIndex = 8;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(12, 138);
		Label3.Name = "Label3";
		Label3.Size = new Size(93, 30);
		Label3.TabIndex = 5;
		Label3.Text = "致谢：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(228, 120);
		Label2.Name = "Label2";
		Label2.Size = new Size(204, 13);
		Label2.TabIndex = 4;
		Label2.Text = "Copyright (c)2007-2021 MatrixGames";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(228, 92);
		Label1.Name = "Label1";
		Label1.Size = new Size(405, 27);
		Label1.TabIndex = 3;
		Label1.Text = "Developed by MatrixGames";
		Label_Copyright.AutoSize = true;
		Label_Copyright.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Copyright.Location = new Point(228, 120);
		Label_Copyright.Name = "Label_Copyright";
		Label_Copyright.Size = new Size(339, 32);
		Label_Copyright.TabIndex = 4;
		Label_Copyright.Text = "(c)2013-2021 MatrixGames";
		PictureBox1.Image = QResourceHelper.GetImage("PictureBox1.Image");
		PictureBox1.Location = new Point(13, 13);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(209, 120);
		PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		PictureBox1.TabIndex = 2;
		PictureBox1.TabStop = false;
		Label_version.AutoEllipsis = true;
		Label_version.AutoSize = true;
		Label_version.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label_version.ForeColor = Color.FromArgb(220, 220, 220);
		Label_version.Location = new Point(228, 13);
		Label_version.MaximumSize = new Size(400, 0);
		Label_version.Name = "Label_version";
		Label_version.Size = new Size(333, 60);
		Label_version.TabIndex = 0;
		Label_version.Text = "指挥 - 现代海空行动 Build x";
		OKButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		OKButton.BackColor = Color.Transparent;
		OKButton.DialogResult = DialogResult.None;
		OKButton.Font = new Font("Segoe UI", 10f);
		OKButton.ForeColor = SystemColors.Control;
		OKButton.Location = new Point(558, 415);
		OKButton.Name = "OKButton";
		OKButton.RoundRadius = 0;
		OKButton.Size = new Size(75, 23);
		OKButton.TabIndex = 1;
		OKButton.Text = "确定";
		TB_Licensing.AutoCompleteCustomSource = null;
		TB_Licensing.AutoCompleteMode = AutoCompleteMode.None;
		TB_Licensing.AutoCompleteSource = AutoCompleteSource.None;
		TB_Licensing.BackColor = SystemColors.Control;
		TB_Licensing.Font = new Font("Segoe UI", 8f);
		TB_Licensing.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Licensing.Image = null;
		TB_Licensing.Lines = null;
		TB_Licensing.Location = new Point(231, 29);
		TB_Licensing.MaxLength = 32767;
		TB_Licensing.Multiline = true;
		TB_Licensing.Name = "TB_Licensing";
		TB_Licensing.ReadOnly = true;
		TB_Licensing.ScrollBars = ScrollBars.Vertical;
		TB_Licensing.SelectionStart = 0;
		TB_Licensing.Size = new Size(402, 79);
		TB_Licensing.TabIndex = 9;
		TB_Licensing.TextAlign = HorizontalAlignment.Left;
		TB_Licensing.UseSystemPasswordChar = false;
		TB_Licensing.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(638, 442);
		base.Controls.Add(TB_Licensing);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label3);
		base.Controls.Add(Label_Copyright);
		base.Controls.Add(PictureBox1);
		base.Controls.Add(Label_version);
		base.Controls.Add(OKButton);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AboutBox1";
		base.Padding = new Padding(9);
		base.ShowIcon = false;
		Text = "关于Command";
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CancelList(object sender, EventArgs e)
	{
		Label_version.Text = GameGeneral.ProgramTitle;
		if (GameGeneral.LicenseTierContext == GameGeneral._ProLicenseTier.None)
		{
			string text = "";
			if (Client.RunningInSteamMode)
			{
				text += "Running in Steam mode.\r\n";
			}
			text += "Licensed modules: \r\n";
			List<string> list = new List<string>();
			foreach (KeyValuePair<Licensing.ModuleLicense, Licensing.InfoProcessResolver> item in Licensing.PostRole())
			{
				if (Licensing.GetModuleIsLicensed(item.Key))
				{
					list.Add(item.Value.m_ContainerMap);
				}
			}
			TB_Licensing.Visible = true;
			TB_Licensing.Text = text + string.Join("\r\n", list);
			Label_Copyright.Text = "(c) MatrixGames 2013-" + Conversions.ToString(DateTime.Now.Year);
		}
		else
		{
			TB_Licensing.Visible = false;
			Label_Copyright.Text = "(c) MatrixGames 2013-" + Conversions.ToString(DateTime.Now.Year);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Geodesic model:\r\nCredits: T.Vincenty, \r\n'Direct and inverse solutions of geodesics of nested equations'. \r\nSurvey Review XXII, 176, April 1975. Pp.88-93.\r\nP.S.Zakatov. Kurs vysshei geodezii. 4th ed. M., 1976.\r\nU.S. Army Topographic Engineering Center, Geospatial Information Division 7701 Telegraph Road Alexandria, VA  22310-3864 - for TransMerc code\r\nGerald Evenden (proj code) and Frank Warmerdam (proj copyright holder)\r\nParts of code: (C) Dimitris V. Dranidis, 2009\r\nBrent minimization routine: AlgLib, (C) Bochkanov Sergey 09.04.2007\r\n\r\n");
		stringBuilder.Append("Weather model:\r\nThis module includes NOVAS 3.0f library from US Naval Observatory for astronomical calculations.\r\nBased on JPL ASCII ephemerides DE405 valid for 2000-2019 (will extend back to 1940s in the future)\r\nSources: ITU-R P.837 rainfall rate data\r\nDr. Tim Mitchell from UK Met.Office (Tyndall centre), CRU TS 2.1 (1901-2002 data)\r\nHansen's thermal anomaly data from http://data.giss.nasa.gov/gistemp/\r\n\r\n");
		stringBuilder.Append("Radar Model:\r\nRodney Spence and Glenn Feldhake of NASA (propagation code)\r\nProf. David C. Jenn of NPS (radjam code)\r\nMicrowaves101 - phased array plot\r\nRaafat Nasser (U.S. Dept of Commerce) - RCG-44\r\nW.L.Patterson, C.P.Hattan, G.E.Lindem, Richard A.Paulus,  H.V.Hitney, K.D.Anderson, Amalia E.Barrios  - EREPS V.3.0 user manual. Tech.Doc.2648. San Diego, May 1994.\r\nAmalia E. Barrios, W. L. Patterson. - Advanced Propagation Model  Ver.1.3.1 CSCI Documents Tech.Doc.3145. San Diego, August 2002.\r\nAREPS User Manual V.3.6. San Diego, December 2006.\r\nHerr Alfred Ochs (Peter-Behrens-Str. 14, D-6100 Darmstadt) - the neat rain attenuation model from  the COST 210 Hydrometeor Scatter Prediction Procedure\r\nSources: ITU-R F.1245-1; ITU-R M.1652, miscellaneous files from ITU-R\r\nH.T.Dougherty, E.J.Dutton, 1981 NTIA Report 81-69\r\nRadar Technology Encyclopedia, 1998. David K. Barton, Sergey A. Leonov (eds.) \r\nKuzmin, 1974\r\nF.B.Chernyi. Rasprostranenie radiovoln. 2nd ed. M., 1972\r\nA.I.Kupriyanov, A.V.Sakharov. Teoreticheskiye osnovy radioelektronnoy borby. M., 2007\r\nYu.P.Melnikov. Vozdushnaya radiotekhnicheskaya razvedka. M., 2005\r\nV.G.Radzievsky (ed.) Sovremennaya radioelectronnaya borba. M., 2006\r\nA.I.Kanaschenkov, V.I.Merkulov (eds.) Zaschita radiolokatsionnykh sistem ot pomekh. M., 2003\r\nMichale O. Kolawole (2002) Radar Systems, Peak Detection and Tracking. Oxford, UK. 388 p.\r\nRadar Handbook (2nd and 3rd eds.) Edited by Merrill I. Skolnik.\r\nElectronic Warfare and Radar Systems Engineering Handbook\r\nV.I.Borisov, V.M.Zinchuk, A.E.Limarev. Pomekhozaschischennost' sistem radiosvyazi s rasshireniyem spektra signalov metodom PPRCh. M., 2008.\r\n\r\n");
		stringBuilder.Append("Virtual Globe: (c)NASA WorldWind\r\n\r\n");
		stringBuilder.Append("\r\n");
		stringBuilder.Append("SRTM map layers & elevation data provided by NASA & based on Shuttle Radar Topography Mission.\r\n");
		stringBuilder.Append("Stamen Terrain & Stamen Roads & Cities map layers provided by Stamen Design & based on OpenStreetMap data.\r\n");
		stringBuilder.Append("Sentinel-2 map layer provided by EOX & based on ESA Copernicus Sentinel-2 missions.\r\n");
		stringBuilder.Append("Some of the sound effects included in Command have been acquired from http://www.freesfx.co.uk and are used under the site's terms of use.\r\n");
		stringBuilder.Append("Images & 3D models rights belong to respective IP holders unless property of MatrixGames.\r\n");
		stringBuilder.Append("\r\n");
		stringBuilder.Append("Thanks to our families & friends who supported us.\r\n\r\n");
		TextBox1.Text = stringBuilder.ToString();
	}

	private void VerifyList(object sender, EventArgs e)
	{
		Close();
	}

	private void ListList(object sender, KeyEventArgs e)
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

	private void ResolveList(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
