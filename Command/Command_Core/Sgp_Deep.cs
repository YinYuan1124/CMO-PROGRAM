using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Sgp_Deep
{
	public static double eqsq;

	public static double siniq;

	public static double cosiq;

	public static double rteqsq;

	public static double ao;

	public static double cosq2;

	public static double sinomo;

	public static double cosomo;

	public static double bsq;

	public static double xlldot;

	public static double omgdt;

	public static double xnodot;

	public static double xnodp;

	public static double xll;

	public static double omgasm;

	public static double xnodes;

	public static double em_d;

	public static double xinc;

	public static double xn;

	public static double t;

	[SpecialName]
	private static int _Int_0;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_0;

	[SpecialName]
	private static int _Int_1;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_1;

	[SpecialName]
	private static int _Int_2;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_2;

	[SpecialName]
	private static int _Int_3;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_3;

	[SpecialName]
	private static int _Int_4;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_4;

	[SpecialName]
	private static int _Int_5;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_5;

	[SpecialName]
	private static int _Int_6;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_6;

	[SpecialName]
	private static double _Double_20;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_7;

	[SpecialName]
	private static double _Double_21;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_8;

	[SpecialName]
	private static double _Double_22;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_9;

	[SpecialName]
	private static double _Double_23;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_10;

	[SpecialName]
	private static double _Double_24;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_11;

	[SpecialName]
	private static double _Double_25;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_12;

	[SpecialName]
	private static double _Double_26;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_13;

	[SpecialName]
	private static double _Double_27;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_14;

	[SpecialName]
	private static double _Double_28;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_15;

	[SpecialName]
	private static double _Double_29;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_16;

	[SpecialName]
	private static double _Double_30;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_17;

	[SpecialName]
	private static double _Double_31;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_18;

	[SpecialName]
	private static double _Double_32;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_19;

	[SpecialName]
	private static double _Double_33;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_20;

	[SpecialName]
	private static double _Double_34;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_21;

	[SpecialName]
	private static double _Double_35;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_22;

	[SpecialName]
	private static double _Double_36;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_23;

	[SpecialName]
	private static double _Double_37;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_24;

	[SpecialName]
	private static double _Double_38;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_25;

	[SpecialName]
	private static double _Double_39;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_26;

	[SpecialName]
	private static double _Double_40;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_27;

	[SpecialName]
	private static double _Double_41;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_28;

	[SpecialName]
	private static double _Double_42;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_29;

	[SpecialName]
	private static double _Double_43;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_30;

	[SpecialName]
	private static double _Double_44;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_31;

	[SpecialName]
	private static double _Double_45;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_32;

	[SpecialName]
	private static double _Double_46;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_33;

	[SpecialName]
	private static double _Double_47;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_34;

	[SpecialName]
	private static double _Double_48;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_35;

	[SpecialName]
	private static double _Double_49;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_36;

	[SpecialName]
	private static double _Double_50;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_37;

	[SpecialName]
	private static double _Double_51;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_38;

	[SpecialName]
	private static double _Double_52;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_39;

	[SpecialName]
	private static double _Double_53;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_40;

	[SpecialName]
	private static double _Double_54;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_41;

	[SpecialName]
	private static double _Double_55;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_42;

	[SpecialName]
	private static double _Double_56;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_43;

	[SpecialName]
	private static double _Double_57;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_44;

	[SpecialName]
	private static double _Double_58;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_45;

	[SpecialName]
	private static double _Double_59;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_46;

	[SpecialName]
	private static double _Double_60;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_47;

	[SpecialName]
	private static double _Double_61;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_48;

	[SpecialName]
	private static double _Double_62;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_49;

	[SpecialName]
	private static double _Double_63;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_50;

	[SpecialName]
	private static double _Double_64;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_51;

	[SpecialName]
	private static double _Double_65;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_52;

	[SpecialName]
	private static double _Double_66;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_53;

	[SpecialName]
	private static double _Double_67;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_54;

	[SpecialName]
	private static double _Double_68;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_55;

	[SpecialName]
	private static double _Double_69;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_56;

	[SpecialName]
	private static double _Double_70;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_57;

	[SpecialName]
	private static double _Double_71;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_58;

	[SpecialName]
	private static double _Double_72;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_59;

	[SpecialName]
	private static double _Double_73;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_60;

	[SpecialName]
	private static double _Double_74;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_61;

	[SpecialName]
	private static double _Double_75;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_62;

	[SpecialName]
	private static double _Double_76;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_63;

	[SpecialName]
	private static double _Double_77;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_64;

	[SpecialName]
	private static double _Double_78;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_65;

	[SpecialName]
	private static double _Double_79;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_66;

	[SpecialName]
	private static double _Double_80;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_67;

	[SpecialName]
	private static double _Double_81;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_68;

	[SpecialName]
	private static double _Double_82;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_69;

	[SpecialName]
	private static double _Double_83;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_70;

	[SpecialName]
	private static double _Double_84;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_71;

	[SpecialName]
	private static double _Double_85;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_72;

	[SpecialName]
	private static double _Double_86;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_73;

	[SpecialName]
	private static double _Double_87;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_74;

	[SpecialName]
	private static double _Double_88;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_75;

	[SpecialName]
	private static double _Double_89;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_76;

	[SpecialName]
	private static double _Double_90;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_77;

	[SpecialName]
	private static double _Double_91;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_78;

	[SpecialName]
	private static double _Double_92;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_79;

	[SpecialName]
	private static double _Double_93;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_80;

	[SpecialName]
	private static double _Double_94;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_81;

	[SpecialName]
	private static double _Double_95;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_82;

	[SpecialName]
	private static double _Double_96;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_83;

	[SpecialName]
	private static double _Double_97;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_84;

	[SpecialName]
	private static double _Double_98;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_85;

	[SpecialName]
	private static double _Double_99;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_86;

	[SpecialName]
	private static double _Double_100;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_87;

	[SpecialName]
	private static double _Double_101;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_88;

	[SpecialName]
	private static double _Double_102;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_89;

	[SpecialName]
	private static double _Double_103;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_90;

	[SpecialName]
	private static double _Double_104;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_91;

	[SpecialName]
	private static double _Double_105;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_92;

	[SpecialName]
	private static double _Double_106;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_93;

	[SpecialName]
	private static double _Double_107;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_94;

	[SpecialName]
	private static double _Double_108;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_95;

	[SpecialName]
	private static double _Double_109;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_96;

	[SpecialName]
	private static double _Double_110;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_97;

	[SpecialName]
	private static double _Double_111;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_98;

	[SpecialName]
	private static double _Double_112;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_99;

	[SpecialName]
	private static double _Double_113;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_100;

	[SpecialName]
	private static double _Double_114;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_101;

	[SpecialName]
	private static double _Double_115;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_102;

	[SpecialName]
	private static double _Double_116;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_103;

	[SpecialName]
	private static double _Double_117;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_104;

	[SpecialName]
	private static double _Double_118;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_105;

	[SpecialName]
	private static double _Double_119;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_106;

	[SpecialName]
	private static double _Double_120;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_107;

	[SpecialName]
	private static double _Double_121;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_108;

	[SpecialName]
	private static double _Double_122;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_109;

	[SpecialName]
	private static double _Double_123;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_110;

	[SpecialName]
	private static double _Double_124;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_111;

	[SpecialName]
	private static double _Double_125;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_112;

	[SpecialName]
	private static double _Double_126;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_113;

	[SpecialName]
	private static double _Double_127;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_114;

	[SpecialName]
	private static double _Double_128;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_115;

	[SpecialName]
	private static double _Double_129;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_116;

	[SpecialName]
	private static double _Double_130;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_117;

	[SpecialName]
	private static double _Double_131;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_118;

	[SpecialName]
	private static double _Double_132;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_119;

	[SpecialName]
	private static double _Double_133;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_120;

	[SpecialName]
	private static double _Double_134;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_121;

	[SpecialName]
	private static double _Double_135;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_122;

	[SpecialName]
	private static double _Double_136;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_123;

	[SpecialName]
	private static double _Double_137;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_124;

	[SpecialName]
	private static double _Double_138;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_125;

	[SpecialName]
	private static double _Double_139;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_126;

	[SpecialName]
	private static double _Double_140;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_127;

	[SpecialName]
	private static double _Double_141;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_128;

	[SpecialName]
	private static double _Double_142;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_129;

	[SpecialName]
	private static double _Double_143;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_130;

	[SpecialName]
	private static double _Double_144;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_131;

	[SpecialName]
	private static double _Double_145;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_132;

	[SpecialName]
	private static double _Double_146;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_133;

	[SpecialName]
	private static double _Double_147;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_134;

	[SpecialName]
	private static double _Double_148;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_135;

	[SpecialName]
	private static double _Double_149;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_136;

	[SpecialName]
	private static double _Double_150;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_137;

	[SpecialName]
	private static double _Double_151;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_138;

	[SpecialName]
	private static double _Double_152;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_139;

	[SpecialName]
	private static double _Double_153;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_140;

	[SpecialName]
	private static double _Double_154;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_141;

	[SpecialName]
	private static double _Double_155;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_142;

	[SpecialName]
	private static double _Double_156;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_143;

	[SpecialName]
	private static double _Double_157;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_144;

	[SpecialName]
	private static double _Double_158;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_145;

	[SpecialName]
	private static double _Double_159;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_146;

	[SpecialName]
	private static double _Double_160;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_147;

	[SpecialName]
	private static double _Double_161;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_148;

	[SpecialName]
	private static double _Double_162;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_149;

	[SpecialName]
	private static double _Double_163;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_150;

	[SpecialName]
	private static double _Double_164;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_151;

	[SpecialName]
	private static double _Double_165;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_152;

	[SpecialName]
	private static double _Double_166;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_153;

	[SpecialName]
	private static double _Double_167;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_154;

	[SpecialName]
	private static double _Double_168;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_155;

	[SpecialName]
	private static double _Double_169;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_156;

	[SpecialName]
	private static double _Double_170;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_157;

	[SpecialName]
	private static double _Double_171;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_158;

	[SpecialName]
	private static double _Double_172;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_159;

	[SpecialName]
	private static double _Double_173;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_160;

	[SpecialName]
	private static double _Double_174;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_161;

	[SpecialName]
	private static double _Double_175;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_162;

	[SpecialName]
	private static double _Double_176;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_163;

	[SpecialName]
	private static double _Double_177;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_164;

	[SpecialName]
	private static double _Double_178;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_165;

	[SpecialName]
	private static double _Double_179;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_166;

	[SpecialName]
	private static double _Double_180;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_167;

	[SpecialName]
	private static double _Double_181;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_168;

	[SpecialName]
	private static double _Double_182;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_169;

	[SpecialName]
	private static double _Double_183;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_170;

	[SpecialName]
	private static double _Double_184;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_171;

	[SpecialName]
	private static double _Double_185;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_172;

	[SpecialName]
	private static double _Double_186;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_173;

	[SpecialName]
	private static double _Double_187;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_174;

	[SpecialName]
	private static double _Double_188;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_175;

	[SpecialName]
	private static double _Double_189;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_176;

	[SpecialName]
	private static double _Double_190;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_177;

	[SpecialName]
	private static double _Double_191;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_178;

	[SpecialName]
	private static double _Double_192;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_179;

	[SpecialName]
	private static double _Double_193;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_180;

	[SpecialName]
	private static double _Double_194;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_181;

	[SpecialName]
	private static double _Double_195;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_182;

	[SpecialName]
	private static double _Double_196;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_183;

	[SpecialName]
	private static double _Double_197;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_184;

	[SpecialName]
	private static double _Double_198;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_185;

	[SpecialName]
	private static double _Double_199;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_186;

	[SpecialName]
	private static double _Double_200;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_187;

	[SpecialName]
	private static double _Double_201;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_188;

	[SpecialName]
	private static double _Double_202;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_189;

	[SpecialName]
	private static double _Double_203;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_190;

	[SpecialName]
	private static double _Double_204;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_191;

	[SpecialName]
	private static double _Double_205;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_192;

	[SpecialName]
	private static double _Double_206;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_193;

	[SpecialName]
	private static double _Double_207;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_194;

	[SpecialName]
	private static double _Double_208;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_195;

	[SpecialName]
	private static double _Double_209;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_196;

	[SpecialName]
	private static double _Double_210;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_197;

	[SpecialName]
	private static double _Double_211;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_198;

	[SpecialName]
	private static double _Double_212;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_199;

	[SpecialName]
	private static double _Double_213;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_200;

	[SpecialName]
	private static double _Double_214;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_201;

	[SpecialName]
	private static double _Double_215;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_202;

	[SpecialName]
	private static double _Double_216;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_203;

	[SpecialName]
	private static double _Double_217;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_204;

	[SpecialName]
	private static double _Double_218;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_205;

	[SpecialName]
	private static double _Double_219;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_206;

	[SpecialName]
	private static double _Double_220;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_207;

	[SpecialName]
	private static double _Double_221;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_208;

	[SpecialName]
	private static double _Double_222;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_209;

	[SpecialName]
	private static double _Double_223;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_210;

	[SpecialName]
	private static double _Double_224;

	[SpecialName]
	private static StaticLocalInitFlag _StaticLocalInitFlag_211;

	public static void call_dpinit(ref SxPxConstants.val_deep_init val_deep_init_0, ref SxPxConstants.sgp_data sgp_data_0)
	{
		eqsq = val_deep_init_0.eosq;
		siniq = val_deep_init_0.sinio;
		cosiq = val_deep_init_0.cosio;
		rteqsq = val_deep_init_0.betao;
		ao = val_deep_init_0.aodp;
		cosq2 = val_deep_init_0.theta2;
		sinomo = val_deep_init_0.sing;
		cosomo = val_deep_init_0.cosg;
		bsq = val_deep_init_0.betao2;
		xlldot = val_deep_init_0.xmdot;
		omgdt = val_deep_init_0.omgdot;
		xnodot = val_deep_init_0.xnodott;
		xnodp = val_deep_init_0.xnodpp;
		int int_ = 1;
		deep(ref int_, ref sgp_data_0);
		val_deep_init_0.eosq = eqsq;
		val_deep_init_0.sinio = siniq;
		val_deep_init_0.cosio = cosiq;
		val_deep_init_0.betao = rteqsq;
		val_deep_init_0.aodp = ao;
		val_deep_init_0.theta2 = cosq2;
		val_deep_init_0.sing = sinomo;
		val_deep_init_0.cosg = cosomo;
		val_deep_init_0.betao2 = bsq;
		val_deep_init_0.xmdot = xlldot;
		val_deep_init_0.omgdot = omgdt;
		val_deep_init_0.xnodott = xnodot;
		val_deep_init_0.xnodpp = xnodp;
	}

	public static void call_dpsec(ref SxPxConstants.val_deep_sec val_deep_sec_0, ref SxPxConstants.sgp_data sgp_data_0)
	{
		xll = val_deep_sec_0.xmdf;
		omgasm = val_deep_sec_0.omgadf;
		xnodes = val_deep_sec_0.xnode;
		em_d = val_deep_sec_0.emm;
		xinc = val_deep_sec_0.xincc;
		xn = val_deep_sec_0.xnn;
		t = val_deep_sec_0.tsince;
		int int_ = 2;
		deep(ref int_, ref sgp_data_0);
		val_deep_sec_0.xmdf = xll;
		val_deep_sec_0.omgadf = omgasm;
		val_deep_sec_0.xnode = xnodes;
		val_deep_sec_0.emm = em_d;
		val_deep_sec_0.xincc = xinc;
		val_deep_sec_0.xnn = xn;
		val_deep_sec_0.tsince = t;
	}

	public static void call_dpper(ref SxPxConstants.val_deep_per val_deep_per_0, ref SxPxConstants.sgp_data sgp_data_0)
	{
		em_d = val_deep_per_0.e;
		xinc = val_deep_per_0.xincc;
		omgasm = val_deep_per_0.omgadf;
		xnodes = val_deep_per_0.xnode;
		xll = val_deep_per_0.xmam;
		int int_ = 3;
		deep(ref int_, ref sgp_data_0);
		val_deep_per_0.e = em_d;
		val_deep_per_0.xincc = xinc;
		val_deep_per_0.omgadf = omgasm;
		val_deep_per_0.xnode = xnodes;
		val_deep_per_0.xmam = xll;
	}

	public static void deep(ref int int_0, ref SxPxConstants.sgp_data sgp_data_0)
	{
		if (_StaticLocalInitFlag_0 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_0, new StaticLocalInitFlag(), null);
		}
		bool lockTaken = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_0, ref lockTaken);
			if (_StaticLocalInitFlag_0.State == 0)
			{
				_StaticLocalInitFlag_0.State = 2;
				_Int_0 = 0;
			}
			else if (_StaticLocalInitFlag_0.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_0.State = 1;
			if (lockTaken)
			{
				Monitor.Exit(_StaticLocalInitFlag_0);
			}
		}
		if (_StaticLocalInitFlag_1 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_1, new StaticLocalInitFlag(), null);
		}
		bool lockTaken112 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_1, ref lockTaken112);
			if (_StaticLocalInitFlag_1.State == 0)
			{
				_StaticLocalInitFlag_1.State = 2;
				_Int_1 = 0;
			}
			else if (_StaticLocalInitFlag_1.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_1.State = 1;
			if (lockTaken112)
			{
				Monitor.Exit(_StaticLocalInitFlag_1);
			}
		}
		if (_StaticLocalInitFlag_2 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_2, new StaticLocalInitFlag(), null);
		}
		bool lockTaken136 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_2, ref lockTaken136);
			if (_StaticLocalInitFlag_2.State == 0)
			{
				_StaticLocalInitFlag_2.State = 2;
				_Int_2 = 0;
			}
			else if (_StaticLocalInitFlag_2.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_2.State = 1;
			if (lockTaken136)
			{
				Monitor.Exit(_StaticLocalInitFlag_2);
			}
		}
		if (_StaticLocalInitFlag_3 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_3, new StaticLocalInitFlag(), null);
		}
		bool lockTaken147 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_3, ref lockTaken147);
			if (_StaticLocalInitFlag_3.State == 0)
			{
				_StaticLocalInitFlag_3.State = 2;
				_Int_3 = 0;
			}
			else if (_StaticLocalInitFlag_3.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_3.State = 1;
			if (lockTaken147)
			{
				Monitor.Exit(_StaticLocalInitFlag_3);
			}
		}
		if (_StaticLocalInitFlag_4 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_4, new StaticLocalInitFlag(), null);
		}
		bool lockTaken158 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_4, ref lockTaken158);
			if (_StaticLocalInitFlag_4.State == 0)
			{
				_StaticLocalInitFlag_4.State = 2;
				_Int_4 = 0;
			}
			else if (_StaticLocalInitFlag_4.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_4.State = 1;
			if (lockTaken158)
			{
				Monitor.Exit(_StaticLocalInitFlag_4);
			}
		}
		if (_StaticLocalInitFlag_5 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_5, new StaticLocalInitFlag(), null);
		}
		bool lockTaken169 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_5, ref lockTaken169);
			if (_StaticLocalInitFlag_5.State == 0)
			{
				_StaticLocalInitFlag_5.State = 2;
				_Int_5 = 0;
			}
			else if (_StaticLocalInitFlag_5.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_5.State = 1;
			if (lockTaken169)
			{
				Monitor.Exit(_StaticLocalInitFlag_5);
			}
		}
		if (_StaticLocalInitFlag_6 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_6, new StaticLocalInitFlag(), null);
		}
		bool lockTaken180 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_6, ref lockTaken180);
			if (_StaticLocalInitFlag_6.State == 0)
			{
				_StaticLocalInitFlag_6.State = 2;
				_Int_6 = 0;
			}
			else if (_StaticLocalInitFlag_6.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_6.State = 1;
			if (lockTaken180)
			{
				Monitor.Exit(_StaticLocalInitFlag_6);
			}
		}
		if (_StaticLocalInitFlag_7 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_7, new StaticLocalInitFlag(), null);
		}
		bool lockTaken191 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_7, ref lockTaken191);
			if (_StaticLocalInitFlag_7.State == 0)
			{
				_StaticLocalInitFlag_7.State = 2;
				_Double_20 = 0.0;
			}
			else if (_StaticLocalInitFlag_7.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_7.State = 1;
			if (lockTaken191)
			{
				Monitor.Exit(_StaticLocalInitFlag_7);
			}
		}
		if (_StaticLocalInitFlag_8 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_8, new StaticLocalInitFlag(), null);
		}
		bool lockTaken202 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_8, ref lockTaken202);
			if (_StaticLocalInitFlag_8.State == 0)
			{
				_StaticLocalInitFlag_8.State = 2;
				_Double_21 = 0.0;
			}
			else if (_StaticLocalInitFlag_8.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_8.State = 1;
			if (lockTaken202)
			{
				Monitor.Exit(_StaticLocalInitFlag_8);
			}
		}
		if (_StaticLocalInitFlag_9 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_9, new StaticLocalInitFlag(), null);
		}
		bool lockTaken2 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_9, ref lockTaken2);
			if (_StaticLocalInitFlag_9.State == 0)
			{
				_StaticLocalInitFlag_9.State = 2;
				_Double_22 = 0.0;
			}
			else if (_StaticLocalInitFlag_9.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_9.State = 1;
			if (lockTaken2)
			{
				Monitor.Exit(_StaticLocalInitFlag_9);
			}
		}
		if (_StaticLocalInitFlag_10 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_10, new StaticLocalInitFlag(), null);
		}
		bool lockTaken13 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_10, ref lockTaken13);
			if (_StaticLocalInitFlag_10.State == 0)
			{
				_StaticLocalInitFlag_10.State = 2;
				_Double_23 = 0.0;
			}
			else if (_StaticLocalInitFlag_10.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_10.State = 1;
			if (lockTaken13)
			{
				Monitor.Exit(_StaticLocalInitFlag_10);
			}
		}
		if (_StaticLocalInitFlag_11 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_11, new StaticLocalInitFlag(), null);
		}
		bool lockTaken24 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_11, ref lockTaken24);
			if (_StaticLocalInitFlag_11.State == 0)
			{
				_StaticLocalInitFlag_11.State = 2;
				_Double_24 = 0.0;
			}
			else if (_StaticLocalInitFlag_11.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_11.State = 1;
			if (lockTaken24)
			{
				Monitor.Exit(_StaticLocalInitFlag_11);
			}
		}
		if (_StaticLocalInitFlag_12 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_12, new StaticLocalInitFlag(), null);
		}
		bool lockTaken35 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_12, ref lockTaken35);
			if (_StaticLocalInitFlag_12.State == 0)
			{
				_StaticLocalInitFlag_12.State = 2;
				_Double_25 = 0.0;
			}
			else if (_StaticLocalInitFlag_12.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_12.State = 1;
			if (lockTaken35)
			{
				Monitor.Exit(_StaticLocalInitFlag_12);
			}
		}
		if (_StaticLocalInitFlag_13 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_13, new StaticLocalInitFlag(), null);
		}
		bool lockTaken46 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_13, ref lockTaken46);
			if (_StaticLocalInitFlag_13.State == 0)
			{
				_StaticLocalInitFlag_13.State = 2;
				_Double_26 = 0.0;
			}
			else if (_StaticLocalInitFlag_13.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_13.State = 1;
			if (lockTaken46)
			{
				Monitor.Exit(_StaticLocalInitFlag_13);
			}
		}
		if (_StaticLocalInitFlag_14 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_14, new StaticLocalInitFlag(), null);
		}
		bool lockTaken57 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_14, ref lockTaken57);
			if (_StaticLocalInitFlag_14.State == 0)
			{
				_StaticLocalInitFlag_14.State = 2;
				_Double_27 = 0.0;
			}
			else if (_StaticLocalInitFlag_14.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_14.State = 1;
			if (lockTaken57)
			{
				Monitor.Exit(_StaticLocalInitFlag_14);
			}
		}
		if (_StaticLocalInitFlag_15 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_15, new StaticLocalInitFlag(), null);
		}
		bool lockTaken68 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_15, ref lockTaken68);
			if (_StaticLocalInitFlag_15.State == 0)
			{
				_StaticLocalInitFlag_15.State = 2;
				_Double_28 = 0.0;
			}
			else if (_StaticLocalInitFlag_15.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_15.State = 1;
			if (lockTaken68)
			{
				Monitor.Exit(_StaticLocalInitFlag_15);
			}
		}
		if (_StaticLocalInitFlag_16 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_16, new StaticLocalInitFlag(), null);
		}
		bool lockTaken79 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_16, ref lockTaken79);
			if (_StaticLocalInitFlag_16.State == 0)
			{
				_StaticLocalInitFlag_16.State = 2;
				_Double_29 = 0.0;
			}
			else if (_StaticLocalInitFlag_16.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_16.State = 1;
			if (lockTaken79)
			{
				Monitor.Exit(_StaticLocalInitFlag_16);
			}
		}
		if (_StaticLocalInitFlag_17 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_17, new StaticLocalInitFlag(), null);
		}
		bool lockTaken90 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_17, ref lockTaken90);
			if (_StaticLocalInitFlag_17.State == 0)
			{
				_StaticLocalInitFlag_17.State = 2;
				_Double_30 = 0.0;
			}
			else if (_StaticLocalInitFlag_17.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_17.State = 1;
			if (lockTaken90)
			{
				Monitor.Exit(_StaticLocalInitFlag_17);
			}
		}
		if (_StaticLocalInitFlag_18 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_18, new StaticLocalInitFlag(), null);
		}
		bool lockTaken101 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_18, ref lockTaken101);
			if (_StaticLocalInitFlag_18.State == 0)
			{
				_StaticLocalInitFlag_18.State = 2;
				_Double_31 = 0.0;
			}
			else if (_StaticLocalInitFlag_18.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_18.State = 1;
			if (lockTaken101)
			{
				Monitor.Exit(_StaticLocalInitFlag_18);
			}
		}
		if (_StaticLocalInitFlag_19 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_19, new StaticLocalInitFlag(), null);
		}
		bool lockTaken113 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_19, ref lockTaken113);
			if (_StaticLocalInitFlag_19.State == 0)
			{
				_StaticLocalInitFlag_19.State = 2;
				_Double_32 = 0.0;
			}
			else if (_StaticLocalInitFlag_19.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_19.State = 1;
			if (lockTaken113)
			{
				Monitor.Exit(_StaticLocalInitFlag_19);
			}
		}
		if (_StaticLocalInitFlag_20 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_20, new StaticLocalInitFlag(), null);
		}
		bool lockTaken124 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_20, ref lockTaken124);
			if (_StaticLocalInitFlag_20.State == 0)
			{
				_StaticLocalInitFlag_20.State = 2;
				_Double_33 = 0.0;
			}
			else if (_StaticLocalInitFlag_20.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_20.State = 1;
			if (lockTaken124)
			{
				Monitor.Exit(_StaticLocalInitFlag_20);
			}
		}
		if (_StaticLocalInitFlag_21 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_21, new StaticLocalInitFlag(), null);
		}
		bool lockTaken128 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_21, ref lockTaken128);
			if (_StaticLocalInitFlag_21.State == 0)
			{
				_StaticLocalInitFlag_21.State = 2;
				_Double_34 = 0.0;
			}
			else if (_StaticLocalInitFlag_21.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_21.State = 1;
			if (lockTaken128)
			{
				Monitor.Exit(_StaticLocalInitFlag_21);
			}
		}
		if (_StaticLocalInitFlag_22 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_22, new StaticLocalInitFlag(), null);
		}
		bool lockTaken129 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_22, ref lockTaken129);
			if (_StaticLocalInitFlag_22.State == 0)
			{
				_StaticLocalInitFlag_22.State = 2;
				_Double_35 = 0.0;
			}
			else if (_StaticLocalInitFlag_22.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_22.State = 1;
			if (lockTaken129)
			{
				Monitor.Exit(_StaticLocalInitFlag_22);
			}
		}
		if (_StaticLocalInitFlag_23 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_23, new StaticLocalInitFlag(), null);
		}
		bool lockTaken130 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_23, ref lockTaken130);
			if (_StaticLocalInitFlag_23.State == 0)
			{
				_StaticLocalInitFlag_23.State = 2;
				_Double_36 = 0.0;
			}
			else if (_StaticLocalInitFlag_23.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_23.State = 1;
			if (lockTaken130)
			{
				Monitor.Exit(_StaticLocalInitFlag_23);
			}
		}
		if (_StaticLocalInitFlag_24 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_24, new StaticLocalInitFlag(), null);
		}
		bool lockTaken131 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_24, ref lockTaken131);
			if (_StaticLocalInitFlag_24.State == 0)
			{
				_StaticLocalInitFlag_24.State = 2;
				_Double_37 = 0.0;
			}
			else if (_StaticLocalInitFlag_24.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_24.State = 1;
			if (lockTaken131)
			{
				Monitor.Exit(_StaticLocalInitFlag_24);
			}
		}
		if (_StaticLocalInitFlag_25 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_25, new StaticLocalInitFlag(), null);
		}
		bool lockTaken132 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_25, ref lockTaken132);
			if (_StaticLocalInitFlag_25.State == 0)
			{
				_StaticLocalInitFlag_25.State = 2;
				_Double_38 = 0.0;
			}
			else if (_StaticLocalInitFlag_25.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_25.State = 1;
			if (lockTaken132)
			{
				Monitor.Exit(_StaticLocalInitFlag_25);
			}
		}
		if (_StaticLocalInitFlag_26 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_26, new StaticLocalInitFlag(), null);
		}
		bool lockTaken133 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_26, ref lockTaken133);
			if (_StaticLocalInitFlag_26.State == 0)
			{
				_StaticLocalInitFlag_26.State = 2;
				_Double_39 = 0.0;
			}
			else if (_StaticLocalInitFlag_26.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_26.State = 1;
			if (lockTaken133)
			{
				Monitor.Exit(_StaticLocalInitFlag_26);
			}
		}
		if (_StaticLocalInitFlag_27 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_27, new StaticLocalInitFlag(), null);
		}
		bool lockTaken134 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_27, ref lockTaken134);
			if (_StaticLocalInitFlag_27.State == 0)
			{
				_StaticLocalInitFlag_27.State = 2;
				_Double_40 = 0.0;
			}
			else if (_StaticLocalInitFlag_27.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_27.State = 1;
			if (lockTaken134)
			{
				Monitor.Exit(_StaticLocalInitFlag_27);
			}
		}
		if (_StaticLocalInitFlag_28 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_28, new StaticLocalInitFlag(), null);
		}
		bool lockTaken135 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_28, ref lockTaken135);
			if (_StaticLocalInitFlag_28.State == 0)
			{
				_StaticLocalInitFlag_28.State = 2;
				_Double_41 = 0.0;
			}
			else if (_StaticLocalInitFlag_28.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_28.State = 1;
			if (lockTaken135)
			{
				Monitor.Exit(_StaticLocalInitFlag_28);
			}
		}
		if (_StaticLocalInitFlag_29 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_29, new StaticLocalInitFlag(), null);
		}
		bool lockTaken137 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_29, ref lockTaken137);
			if (_StaticLocalInitFlag_29.State == 0)
			{
				_StaticLocalInitFlag_29.State = 2;
				_Double_42 = 0.0;
			}
			else if (_StaticLocalInitFlag_29.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_29.State = 1;
			if (lockTaken137)
			{
				Monitor.Exit(_StaticLocalInitFlag_29);
			}
		}
		if (_StaticLocalInitFlag_30 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_30, new StaticLocalInitFlag(), null);
		}
		bool lockTaken138 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_30, ref lockTaken138);
			if (_StaticLocalInitFlag_30.State == 0)
			{
				_StaticLocalInitFlag_30.State = 2;
				_Double_43 = 0.0;
			}
			else if (_StaticLocalInitFlag_30.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_30.State = 1;
			if (lockTaken138)
			{
				Monitor.Exit(_StaticLocalInitFlag_30);
			}
		}
		if (_StaticLocalInitFlag_31 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_31, new StaticLocalInitFlag(), null);
		}
		bool lockTaken139 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_31, ref lockTaken139);
			if (_StaticLocalInitFlag_31.State == 0)
			{
				_StaticLocalInitFlag_31.State = 2;
				_Double_44 = 0.0;
			}
			else if (_StaticLocalInitFlag_31.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_31.State = 1;
			if (lockTaken139)
			{
				Monitor.Exit(_StaticLocalInitFlag_31);
			}
		}
		if (_StaticLocalInitFlag_32 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_32, new StaticLocalInitFlag(), null);
		}
		bool lockTaken140 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_32, ref lockTaken140);
			if (_StaticLocalInitFlag_32.State == 0)
			{
				_StaticLocalInitFlag_32.State = 2;
				_Double_45 = 0.0;
			}
			else if (_StaticLocalInitFlag_32.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_32.State = 1;
			if (lockTaken140)
			{
				Monitor.Exit(_StaticLocalInitFlag_32);
			}
		}
		if (_StaticLocalInitFlag_33 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_33, new StaticLocalInitFlag(), null);
		}
		bool lockTaken141 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_33, ref lockTaken141);
			if (_StaticLocalInitFlag_33.State == 0)
			{
				_StaticLocalInitFlag_33.State = 2;
				_Double_46 = 0.0;
			}
			else if (_StaticLocalInitFlag_33.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_33.State = 1;
			if (lockTaken141)
			{
				Monitor.Exit(_StaticLocalInitFlag_33);
			}
		}
		if (_StaticLocalInitFlag_34 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_34, new StaticLocalInitFlag(), null);
		}
		bool lockTaken142 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_34, ref lockTaken142);
			if (_StaticLocalInitFlag_34.State == 0)
			{
				_StaticLocalInitFlag_34.State = 2;
				_Double_47 = 0.0;
			}
			else if (_StaticLocalInitFlag_34.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_34.State = 1;
			if (lockTaken142)
			{
				Monitor.Exit(_StaticLocalInitFlag_34);
			}
		}
		if (_StaticLocalInitFlag_35 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_35, new StaticLocalInitFlag(), null);
		}
		bool lockTaken143 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_35, ref lockTaken143);
			if (_StaticLocalInitFlag_35.State == 0)
			{
				_StaticLocalInitFlag_35.State = 2;
				_Double_48 = 0.0;
			}
			else if (_StaticLocalInitFlag_35.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_35.State = 1;
			if (lockTaken143)
			{
				Monitor.Exit(_StaticLocalInitFlag_35);
			}
		}
		if (_StaticLocalInitFlag_36 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_36, new StaticLocalInitFlag(), null);
		}
		bool lockTaken144 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_36, ref lockTaken144);
			if (_StaticLocalInitFlag_36.State == 0)
			{
				_StaticLocalInitFlag_36.State = 2;
				_Double_49 = 0.0;
			}
			else if (_StaticLocalInitFlag_36.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_36.State = 1;
			if (lockTaken144)
			{
				Monitor.Exit(_StaticLocalInitFlag_36);
			}
		}
		if (_StaticLocalInitFlag_37 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_37, new StaticLocalInitFlag(), null);
		}
		bool lockTaken145 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_37, ref lockTaken145);
			if (_StaticLocalInitFlag_37.State == 0)
			{
				_StaticLocalInitFlag_37.State = 2;
				_Double_50 = 0.0;
			}
			else if (_StaticLocalInitFlag_37.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_37.State = 1;
			if (lockTaken145)
			{
				Monitor.Exit(_StaticLocalInitFlag_37);
			}
		}
		if (_StaticLocalInitFlag_38 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_38, new StaticLocalInitFlag(), null);
		}
		bool lockTaken146 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_38, ref lockTaken146);
			if (_StaticLocalInitFlag_38.State == 0)
			{
				_StaticLocalInitFlag_38.State = 2;
				_Double_51 = 0.0;
			}
			else if (_StaticLocalInitFlag_38.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_38.State = 1;
			if (lockTaken146)
			{
				Monitor.Exit(_StaticLocalInitFlag_38);
			}
		}
		if (_StaticLocalInitFlag_39 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_39, new StaticLocalInitFlag(), null);
		}
		bool lockTaken148 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_39, ref lockTaken148);
			if (_StaticLocalInitFlag_39.State == 0)
			{
				_StaticLocalInitFlag_39.State = 2;
				_Double_52 = 0.0;
			}
			else if (_StaticLocalInitFlag_39.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_39.State = 1;
			if (lockTaken148)
			{
				Monitor.Exit(_StaticLocalInitFlag_39);
			}
		}
		if (_StaticLocalInitFlag_40 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_40, new StaticLocalInitFlag(), null);
		}
		bool lockTaken149 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_40, ref lockTaken149);
			if (_StaticLocalInitFlag_40.State == 0)
			{
				_StaticLocalInitFlag_40.State = 2;
				_Double_53 = 0.0;
			}
			else if (_StaticLocalInitFlag_40.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_40.State = 1;
			if (lockTaken149)
			{
				Monitor.Exit(_StaticLocalInitFlag_40);
			}
		}
		if (_StaticLocalInitFlag_41 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_41, new StaticLocalInitFlag(), null);
		}
		bool lockTaken150 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_41, ref lockTaken150);
			if (_StaticLocalInitFlag_41.State == 0)
			{
				_StaticLocalInitFlag_41.State = 2;
				_Double_54 = 0.0;
			}
			else if (_StaticLocalInitFlag_41.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_41.State = 1;
			if (lockTaken150)
			{
				Monitor.Exit(_StaticLocalInitFlag_41);
			}
		}
		if (_StaticLocalInitFlag_42 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_42, new StaticLocalInitFlag(), null);
		}
		bool lockTaken151 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_42, ref lockTaken151);
			if (_StaticLocalInitFlag_42.State == 0)
			{
				_StaticLocalInitFlag_42.State = 2;
				_Double_55 = 0.0;
			}
			else if (_StaticLocalInitFlag_42.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_42.State = 1;
			if (lockTaken151)
			{
				Monitor.Exit(_StaticLocalInitFlag_42);
			}
		}
		if (_StaticLocalInitFlag_43 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_43, new StaticLocalInitFlag(), null);
		}
		bool lockTaken152 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_43, ref lockTaken152);
			if (_StaticLocalInitFlag_43.State == 0)
			{
				_StaticLocalInitFlag_43.State = 2;
				_Double_56 = 0.0;
			}
			else if (_StaticLocalInitFlag_43.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_43.State = 1;
			if (lockTaken152)
			{
				Monitor.Exit(_StaticLocalInitFlag_43);
			}
		}
		if (_StaticLocalInitFlag_44 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_44, new StaticLocalInitFlag(), null);
		}
		bool lockTaken153 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_44, ref lockTaken153);
			if (_StaticLocalInitFlag_44.State == 0)
			{
				_StaticLocalInitFlag_44.State = 2;
				_Double_57 = 0.0;
			}
			else if (_StaticLocalInitFlag_44.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_44.State = 1;
			if (lockTaken153)
			{
				Monitor.Exit(_StaticLocalInitFlag_44);
			}
		}
		if (_StaticLocalInitFlag_45 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_45, new StaticLocalInitFlag(), null);
		}
		bool lockTaken154 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_45, ref lockTaken154);
			if (_StaticLocalInitFlag_45.State == 0)
			{
				_StaticLocalInitFlag_45.State = 2;
				_Double_58 = 0.0;
			}
			else if (_StaticLocalInitFlag_45.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_45.State = 1;
			if (lockTaken154)
			{
				Monitor.Exit(_StaticLocalInitFlag_45);
			}
		}
		if (_StaticLocalInitFlag_46 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_46, new StaticLocalInitFlag(), null);
		}
		bool lockTaken155 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_46, ref lockTaken155);
			if (_StaticLocalInitFlag_46.State == 0)
			{
				_StaticLocalInitFlag_46.State = 2;
				_Double_59 = 0.0;
			}
			else if (_StaticLocalInitFlag_46.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_46.State = 1;
			if (lockTaken155)
			{
				Monitor.Exit(_StaticLocalInitFlag_46);
			}
		}
		if (_StaticLocalInitFlag_47 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_47, new StaticLocalInitFlag(), null);
		}
		bool lockTaken156 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_47, ref lockTaken156);
			if (_StaticLocalInitFlag_47.State == 0)
			{
				_StaticLocalInitFlag_47.State = 2;
				_Double_60 = 0.0;
			}
			else if (_StaticLocalInitFlag_47.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_47.State = 1;
			if (lockTaken156)
			{
				Monitor.Exit(_StaticLocalInitFlag_47);
			}
		}
		if (_StaticLocalInitFlag_48 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_48, new StaticLocalInitFlag(), null);
		}
		bool lockTaken157 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_48, ref lockTaken157);
			if (_StaticLocalInitFlag_48.State == 0)
			{
				_StaticLocalInitFlag_48.State = 2;
				_Double_61 = 0.0;
			}
			else if (_StaticLocalInitFlag_48.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_48.State = 1;
			if (lockTaken157)
			{
				Monitor.Exit(_StaticLocalInitFlag_48);
			}
		}
		if (_StaticLocalInitFlag_49 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_49, new StaticLocalInitFlag(), null);
		}
		bool lockTaken159 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_49, ref lockTaken159);
			if (_StaticLocalInitFlag_49.State == 0)
			{
				_StaticLocalInitFlag_49.State = 2;
				_Double_62 = 0.0;
			}
			else if (_StaticLocalInitFlag_49.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_49.State = 1;
			if (lockTaken159)
			{
				Monitor.Exit(_StaticLocalInitFlag_49);
			}
		}
		if (_StaticLocalInitFlag_50 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_50, new StaticLocalInitFlag(), null);
		}
		bool lockTaken160 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_50, ref lockTaken160);
			if (_StaticLocalInitFlag_50.State == 0)
			{
				_StaticLocalInitFlag_50.State = 2;
				_Double_63 = 0.0;
			}
			else if (_StaticLocalInitFlag_50.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_50.State = 1;
			if (lockTaken160)
			{
				Monitor.Exit(_StaticLocalInitFlag_50);
			}
		}
		if (_StaticLocalInitFlag_51 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_51, new StaticLocalInitFlag(), null);
		}
		bool lockTaken161 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_51, ref lockTaken161);
			if (_StaticLocalInitFlag_51.State == 0)
			{
				_StaticLocalInitFlag_51.State = 2;
				_Double_64 = 0.0;
			}
			else if (_StaticLocalInitFlag_51.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_51.State = 1;
			if (lockTaken161)
			{
				Monitor.Exit(_StaticLocalInitFlag_51);
			}
		}
		if (_StaticLocalInitFlag_52 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_52, new StaticLocalInitFlag(), null);
		}
		bool lockTaken162 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_52, ref lockTaken162);
			if (_StaticLocalInitFlag_52.State == 0)
			{
				_StaticLocalInitFlag_52.State = 2;
				_Double_65 = 0.0;
			}
			else if (_StaticLocalInitFlag_52.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_52.State = 1;
			if (lockTaken162)
			{
				Monitor.Exit(_StaticLocalInitFlag_52);
			}
		}
		if (_StaticLocalInitFlag_53 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_53, new StaticLocalInitFlag(), null);
		}
		bool lockTaken163 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_53, ref lockTaken163);
			if (_StaticLocalInitFlag_53.State == 0)
			{
				_StaticLocalInitFlag_53.State = 2;
				_Double_66 = 0.0;
			}
			else if (_StaticLocalInitFlag_53.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_53.State = 1;
			if (lockTaken163)
			{
				Monitor.Exit(_StaticLocalInitFlag_53);
			}
		}
		if (_StaticLocalInitFlag_54 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_54, new StaticLocalInitFlag(), null);
		}
		bool lockTaken164 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_54, ref lockTaken164);
			if (_StaticLocalInitFlag_54.State == 0)
			{
				_StaticLocalInitFlag_54.State = 2;
				_Double_67 = 0.0;
			}
			else if (_StaticLocalInitFlag_54.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_54.State = 1;
			if (lockTaken164)
			{
				Monitor.Exit(_StaticLocalInitFlag_54);
			}
		}
		if (_StaticLocalInitFlag_55 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_55, new StaticLocalInitFlag(), null);
		}
		bool lockTaken165 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_55, ref lockTaken165);
			if (_StaticLocalInitFlag_55.State == 0)
			{
				_StaticLocalInitFlag_55.State = 2;
				_Double_68 = 0.0;
			}
			else if (_StaticLocalInitFlag_55.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_55.State = 1;
			if (lockTaken165)
			{
				Monitor.Exit(_StaticLocalInitFlag_55);
			}
		}
		if (_StaticLocalInitFlag_56 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_56, new StaticLocalInitFlag(), null);
		}
		bool lockTaken166 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_56, ref lockTaken166);
			if (_StaticLocalInitFlag_56.State == 0)
			{
				_StaticLocalInitFlag_56.State = 2;
				_Double_69 = 0.0;
			}
			else if (_StaticLocalInitFlag_56.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_56.State = 1;
			if (lockTaken166)
			{
				Monitor.Exit(_StaticLocalInitFlag_56);
			}
		}
		if (_StaticLocalInitFlag_57 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_57, new StaticLocalInitFlag(), null);
		}
		bool lockTaken167 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_57, ref lockTaken167);
			if (_StaticLocalInitFlag_57.State == 0)
			{
				_StaticLocalInitFlag_57.State = 2;
				_Double_70 = 0.0;
			}
			else if (_StaticLocalInitFlag_57.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_57.State = 1;
			if (lockTaken167)
			{
				Monitor.Exit(_StaticLocalInitFlag_57);
			}
		}
		if (_StaticLocalInitFlag_58 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_58, new StaticLocalInitFlag(), null);
		}
		bool lockTaken168 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_58, ref lockTaken168);
			if (_StaticLocalInitFlag_58.State == 0)
			{
				_StaticLocalInitFlag_58.State = 2;
				_Double_71 = 0.0;
			}
			else if (_StaticLocalInitFlag_58.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_58.State = 1;
			if (lockTaken168)
			{
				Monitor.Exit(_StaticLocalInitFlag_58);
			}
		}
		if (_StaticLocalInitFlag_59 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_59, new StaticLocalInitFlag(), null);
		}
		bool lockTaken170 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_59, ref lockTaken170);
			if (_StaticLocalInitFlag_59.State == 0)
			{
				_StaticLocalInitFlag_59.State = 2;
				_Double_72 = 0.0;
			}
			else if (_StaticLocalInitFlag_59.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_59.State = 1;
			if (lockTaken170)
			{
				Monitor.Exit(_StaticLocalInitFlag_59);
			}
		}
		if (_StaticLocalInitFlag_60 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_60, new StaticLocalInitFlag(), null);
		}
		bool lockTaken171 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_60, ref lockTaken171);
			if (_StaticLocalInitFlag_60.State == 0)
			{
				_StaticLocalInitFlag_60.State = 2;
				_Double_73 = 0.0;
			}
			else if (_StaticLocalInitFlag_60.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_60.State = 1;
			if (lockTaken171)
			{
				Monitor.Exit(_StaticLocalInitFlag_60);
			}
		}
		if (_StaticLocalInitFlag_61 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_61, new StaticLocalInitFlag(), null);
		}
		bool lockTaken172 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_61, ref lockTaken172);
			if (_StaticLocalInitFlag_61.State == 0)
			{
				_StaticLocalInitFlag_61.State = 2;
				_Double_74 = 0.0;
			}
			else if (_StaticLocalInitFlag_61.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_61.State = 1;
			if (lockTaken172)
			{
				Monitor.Exit(_StaticLocalInitFlag_61);
			}
		}
		if (_StaticLocalInitFlag_62 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_62, new StaticLocalInitFlag(), null);
		}
		bool lockTaken173 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_62, ref lockTaken173);
			if (_StaticLocalInitFlag_62.State == 0)
			{
				_StaticLocalInitFlag_62.State = 2;
				_Double_75 = 0.0;
			}
			else if (_StaticLocalInitFlag_62.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_62.State = 1;
			if (lockTaken173)
			{
				Monitor.Exit(_StaticLocalInitFlag_62);
			}
		}
		if (_StaticLocalInitFlag_63 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_63, new StaticLocalInitFlag(), null);
		}
		bool lockTaken174 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_63, ref lockTaken174);
			if (_StaticLocalInitFlag_63.State == 0)
			{
				_StaticLocalInitFlag_63.State = 2;
				_Double_76 = 0.0;
			}
			else if (_StaticLocalInitFlag_63.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_63.State = 1;
			if (lockTaken174)
			{
				Monitor.Exit(_StaticLocalInitFlag_63);
			}
		}
		if (_StaticLocalInitFlag_64 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_64, new StaticLocalInitFlag(), null);
		}
		bool lockTaken175 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_64, ref lockTaken175);
			if (_StaticLocalInitFlag_64.State == 0)
			{
				_StaticLocalInitFlag_64.State = 2;
				_Double_77 = 0.0;
			}
			else if (_StaticLocalInitFlag_64.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_64.State = 1;
			if (lockTaken175)
			{
				Monitor.Exit(_StaticLocalInitFlag_64);
			}
		}
		if (_StaticLocalInitFlag_65 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_65, new StaticLocalInitFlag(), null);
		}
		bool lockTaken176 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_65, ref lockTaken176);
			if (_StaticLocalInitFlag_65.State == 0)
			{
				_StaticLocalInitFlag_65.State = 2;
				_Double_78 = 0.0;
			}
			else if (_StaticLocalInitFlag_65.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_65.State = 1;
			if (lockTaken176)
			{
				Monitor.Exit(_StaticLocalInitFlag_65);
			}
		}
		if (_StaticLocalInitFlag_66 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_66, new StaticLocalInitFlag(), null);
		}
		bool lockTaken177 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_66, ref lockTaken177);
			if (_StaticLocalInitFlag_66.State == 0)
			{
				_StaticLocalInitFlag_66.State = 2;
				_Double_79 = 0.0;
			}
			else if (_StaticLocalInitFlag_66.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_66.State = 1;
			if (lockTaken177)
			{
				Monitor.Exit(_StaticLocalInitFlag_66);
			}
		}
		if (_StaticLocalInitFlag_67 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_67, new StaticLocalInitFlag(), null);
		}
		bool lockTaken178 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_67, ref lockTaken178);
			if (_StaticLocalInitFlag_67.State == 0)
			{
				_StaticLocalInitFlag_67.State = 2;
				_Double_80 = 0.0;
			}
			else if (_StaticLocalInitFlag_67.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_67.State = 1;
			if (lockTaken178)
			{
				Monitor.Exit(_StaticLocalInitFlag_67);
			}
		}
		if (_StaticLocalInitFlag_68 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_68, new StaticLocalInitFlag(), null);
		}
		bool lockTaken179 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_68, ref lockTaken179);
			if (_StaticLocalInitFlag_68.State == 0)
			{
				_StaticLocalInitFlag_68.State = 2;
				_Double_81 = 0.0;
			}
			else if (_StaticLocalInitFlag_68.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_68.State = 1;
			if (lockTaken179)
			{
				Monitor.Exit(_StaticLocalInitFlag_68);
			}
		}
		if (_StaticLocalInitFlag_69 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_69, new StaticLocalInitFlag(), null);
		}
		bool lockTaken181 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_69, ref lockTaken181);
			if (_StaticLocalInitFlag_69.State == 0)
			{
				_StaticLocalInitFlag_69.State = 2;
				_Double_82 = 0.0;
			}
			else if (_StaticLocalInitFlag_69.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_69.State = 1;
			if (lockTaken181)
			{
				Monitor.Exit(_StaticLocalInitFlag_69);
			}
		}
		if (_StaticLocalInitFlag_70 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_70, new StaticLocalInitFlag(), null);
		}
		bool lockTaken182 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_70, ref lockTaken182);
			if (_StaticLocalInitFlag_70.State == 0)
			{
				_StaticLocalInitFlag_70.State = 2;
				_Double_83 = 0.0;
			}
			else if (_StaticLocalInitFlag_70.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_70.State = 1;
			if (lockTaken182)
			{
				Monitor.Exit(_StaticLocalInitFlag_70);
			}
		}
		if (_StaticLocalInitFlag_71 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_71, new StaticLocalInitFlag(), null);
		}
		bool lockTaken183 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_71, ref lockTaken183);
			if (_StaticLocalInitFlag_71.State == 0)
			{
				_StaticLocalInitFlag_71.State = 2;
				_Double_84 = 0.0;
			}
			else if (_StaticLocalInitFlag_71.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_71.State = 1;
			if (lockTaken183)
			{
				Monitor.Exit(_StaticLocalInitFlag_71);
			}
		}
		if (_StaticLocalInitFlag_72 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_72, new StaticLocalInitFlag(), null);
		}
		bool lockTaken184 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_72, ref lockTaken184);
			if (_StaticLocalInitFlag_72.State == 0)
			{
				_StaticLocalInitFlag_72.State = 2;
				_Double_85 = 0.0;
			}
			else if (_StaticLocalInitFlag_72.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_72.State = 1;
			if (lockTaken184)
			{
				Monitor.Exit(_StaticLocalInitFlag_72);
			}
		}
		if (_StaticLocalInitFlag_73 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_73, new StaticLocalInitFlag(), null);
		}
		bool lockTaken185 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_73, ref lockTaken185);
			if (_StaticLocalInitFlag_73.State == 0)
			{
				_StaticLocalInitFlag_73.State = 2;
				_Double_86 = 0.0;
			}
			else if (_StaticLocalInitFlag_73.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_73.State = 1;
			if (lockTaken185)
			{
				Monitor.Exit(_StaticLocalInitFlag_73);
			}
		}
		if (_StaticLocalInitFlag_74 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_74, new StaticLocalInitFlag(), null);
		}
		bool lockTaken186 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_74, ref lockTaken186);
			if (_StaticLocalInitFlag_74.State == 0)
			{
				_StaticLocalInitFlag_74.State = 2;
				_Double_87 = 0.0;
			}
			else if (_StaticLocalInitFlag_74.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_74.State = 1;
			if (lockTaken186)
			{
				Monitor.Exit(_StaticLocalInitFlag_74);
			}
		}
		if (_StaticLocalInitFlag_75 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_75, new StaticLocalInitFlag(), null);
		}
		bool lockTaken187 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_75, ref lockTaken187);
			if (_StaticLocalInitFlag_75.State == 0)
			{
				_StaticLocalInitFlag_75.State = 2;
				_Double_88 = 0.0;
			}
			else if (_StaticLocalInitFlag_75.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_75.State = 1;
			if (lockTaken187)
			{
				Monitor.Exit(_StaticLocalInitFlag_75);
			}
		}
		if (_StaticLocalInitFlag_76 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_76, new StaticLocalInitFlag(), null);
		}
		bool lockTaken188 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_76, ref lockTaken188);
			if (_StaticLocalInitFlag_76.State == 0)
			{
				_StaticLocalInitFlag_76.State = 2;
				_Double_89 = 0.0;
			}
			else if (_StaticLocalInitFlag_76.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_76.State = 1;
			if (lockTaken188)
			{
				Monitor.Exit(_StaticLocalInitFlag_76);
			}
		}
		if (_StaticLocalInitFlag_77 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_77, new StaticLocalInitFlag(), null);
		}
		bool lockTaken189 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_77, ref lockTaken189);
			if (_StaticLocalInitFlag_77.State == 0)
			{
				_StaticLocalInitFlag_77.State = 2;
				_Double_90 = 0.0;
			}
			else if (_StaticLocalInitFlag_77.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_77.State = 1;
			if (lockTaken189)
			{
				Monitor.Exit(_StaticLocalInitFlag_77);
			}
		}
		if (_StaticLocalInitFlag_78 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_78, new StaticLocalInitFlag(), null);
		}
		bool lockTaken190 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_78, ref lockTaken190);
			if (_StaticLocalInitFlag_78.State == 0)
			{
				_StaticLocalInitFlag_78.State = 2;
				_Double_91 = 0.0;
			}
			else if (_StaticLocalInitFlag_78.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_78.State = 1;
			if (lockTaken190)
			{
				Monitor.Exit(_StaticLocalInitFlag_78);
			}
		}
		if (_StaticLocalInitFlag_79 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_79, new StaticLocalInitFlag(), null);
		}
		bool lockTaken192 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_79, ref lockTaken192);
			if (_StaticLocalInitFlag_79.State == 0)
			{
				_StaticLocalInitFlag_79.State = 2;
				_Double_92 = 0.0;
			}
			else if (_StaticLocalInitFlag_79.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_79.State = 1;
			if (lockTaken192)
			{
				Monitor.Exit(_StaticLocalInitFlag_79);
			}
		}
		if (_StaticLocalInitFlag_80 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_80, new StaticLocalInitFlag(), null);
		}
		bool lockTaken193 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_80, ref lockTaken193);
			if (_StaticLocalInitFlag_80.State == 0)
			{
				_StaticLocalInitFlag_80.State = 2;
				_Double_93 = 0.0;
			}
			else if (_StaticLocalInitFlag_80.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_80.State = 1;
			if (lockTaken193)
			{
				Monitor.Exit(_StaticLocalInitFlag_80);
			}
		}
		if (_StaticLocalInitFlag_81 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_81, new StaticLocalInitFlag(), null);
		}
		bool lockTaken194 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_81, ref lockTaken194);
			if (_StaticLocalInitFlag_81.State == 0)
			{
				_StaticLocalInitFlag_81.State = 2;
				_Double_94 = 0.0;
			}
			else if (_StaticLocalInitFlag_81.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_81.State = 1;
			if (lockTaken194)
			{
				Monitor.Exit(_StaticLocalInitFlag_81);
			}
		}
		if (_StaticLocalInitFlag_82 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_82, new StaticLocalInitFlag(), null);
		}
		bool lockTaken195 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_82, ref lockTaken195);
			if (_StaticLocalInitFlag_82.State == 0)
			{
				_StaticLocalInitFlag_82.State = 2;
				_Double_95 = 0.0;
			}
			else if (_StaticLocalInitFlag_82.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_82.State = 1;
			if (lockTaken195)
			{
				Monitor.Exit(_StaticLocalInitFlag_82);
			}
		}
		if (_StaticLocalInitFlag_83 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_83, new StaticLocalInitFlag(), null);
		}
		bool lockTaken196 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_83, ref lockTaken196);
			if (_StaticLocalInitFlag_83.State == 0)
			{
				_StaticLocalInitFlag_83.State = 2;
				_Double_96 = 0.0;
			}
			else if (_StaticLocalInitFlag_83.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_83.State = 1;
			if (lockTaken196)
			{
				Monitor.Exit(_StaticLocalInitFlag_83);
			}
		}
		if (_StaticLocalInitFlag_84 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_84, new StaticLocalInitFlag(), null);
		}
		bool lockTaken197 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_84, ref lockTaken197);
			if (_StaticLocalInitFlag_84.State == 0)
			{
				_StaticLocalInitFlag_84.State = 2;
				_Double_97 = 0.0;
			}
			else if (_StaticLocalInitFlag_84.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_84.State = 1;
			if (lockTaken197)
			{
				Monitor.Exit(_StaticLocalInitFlag_84);
			}
		}
		if (_StaticLocalInitFlag_85 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_85, new StaticLocalInitFlag(), null);
		}
		bool lockTaken198 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_85, ref lockTaken198);
			if (_StaticLocalInitFlag_85.State == 0)
			{
				_StaticLocalInitFlag_85.State = 2;
				_Double_98 = 0.0;
			}
			else if (_StaticLocalInitFlag_85.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_85.State = 1;
			if (lockTaken198)
			{
				Monitor.Exit(_StaticLocalInitFlag_85);
			}
		}
		if (_StaticLocalInitFlag_86 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_86, new StaticLocalInitFlag(), null);
		}
		bool lockTaken199 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_86, ref lockTaken199);
			if (_StaticLocalInitFlag_86.State == 0)
			{
				_StaticLocalInitFlag_86.State = 2;
				_Double_99 = 0.0;
			}
			else if (_StaticLocalInitFlag_86.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_86.State = 1;
			if (lockTaken199)
			{
				Monitor.Exit(_StaticLocalInitFlag_86);
			}
		}
		if (_StaticLocalInitFlag_87 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_87, new StaticLocalInitFlag(), null);
		}
		bool lockTaken200 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_87, ref lockTaken200);
			if (_StaticLocalInitFlag_87.State == 0)
			{
				_StaticLocalInitFlag_87.State = 2;
				_Double_100 = 0.0;
			}
			else if (_StaticLocalInitFlag_87.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_87.State = 1;
			if (lockTaken200)
			{
				Monitor.Exit(_StaticLocalInitFlag_87);
			}
		}
		if (_StaticLocalInitFlag_88 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_88, new StaticLocalInitFlag(), null);
		}
		bool lockTaken201 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_88, ref lockTaken201);
			if (_StaticLocalInitFlag_88.State == 0)
			{
				_StaticLocalInitFlag_88.State = 2;
				_Double_101 = 0.0;
			}
			else if (_StaticLocalInitFlag_88.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_88.State = 1;
			if (lockTaken201)
			{
				Monitor.Exit(_StaticLocalInitFlag_88);
			}
		}
		if (_StaticLocalInitFlag_89 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_89, new StaticLocalInitFlag(), null);
		}
		bool lockTaken203 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_89, ref lockTaken203);
			if (_StaticLocalInitFlag_89.State == 0)
			{
				_StaticLocalInitFlag_89.State = 2;
				_Double_102 = 0.0;
			}
			else if (_StaticLocalInitFlag_89.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_89.State = 1;
			if (lockTaken203)
			{
				Monitor.Exit(_StaticLocalInitFlag_89);
			}
		}
		if (_StaticLocalInitFlag_90 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_90, new StaticLocalInitFlag(), null);
		}
		bool lockTaken204 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_90, ref lockTaken204);
			if (_StaticLocalInitFlag_90.State == 0)
			{
				_StaticLocalInitFlag_90.State = 2;
				_Double_103 = 0.0;
			}
			else if (_StaticLocalInitFlag_90.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_90.State = 1;
			if (lockTaken204)
			{
				Monitor.Exit(_StaticLocalInitFlag_90);
			}
		}
		if (_StaticLocalInitFlag_91 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_91, new StaticLocalInitFlag(), null);
		}
		bool lockTaken205 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_91, ref lockTaken205);
			if (_StaticLocalInitFlag_91.State == 0)
			{
				_StaticLocalInitFlag_91.State = 2;
				_Double_104 = 0.0;
			}
			else if (_StaticLocalInitFlag_91.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_91.State = 1;
			if (lockTaken205)
			{
				Monitor.Exit(_StaticLocalInitFlag_91);
			}
		}
		if (_StaticLocalInitFlag_92 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_92, new StaticLocalInitFlag(), null);
		}
		bool lockTaken206 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_92, ref lockTaken206);
			if (_StaticLocalInitFlag_92.State == 0)
			{
				_StaticLocalInitFlag_92.State = 2;
				_Double_105 = 0.0;
			}
			else if (_StaticLocalInitFlag_92.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_92.State = 1;
			if (lockTaken206)
			{
				Monitor.Exit(_StaticLocalInitFlag_92);
			}
		}
		if (_StaticLocalInitFlag_93 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_93, new StaticLocalInitFlag(), null);
		}
		bool lockTaken207 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_93, ref lockTaken207);
			if (_StaticLocalInitFlag_93.State == 0)
			{
				_StaticLocalInitFlag_93.State = 2;
				_Double_106 = 0.0;
			}
			else if (_StaticLocalInitFlag_93.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_93.State = 1;
			if (lockTaken207)
			{
				Monitor.Exit(_StaticLocalInitFlag_93);
			}
		}
		if (_StaticLocalInitFlag_94 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_94, new StaticLocalInitFlag(), null);
		}
		bool lockTaken208 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_94, ref lockTaken208);
			if (_StaticLocalInitFlag_94.State == 0)
			{
				_StaticLocalInitFlag_94.State = 2;
				_Double_107 = 0.0;
			}
			else if (_StaticLocalInitFlag_94.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_94.State = 1;
			if (lockTaken208)
			{
				Monitor.Exit(_StaticLocalInitFlag_94);
			}
		}
		if (_StaticLocalInitFlag_95 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_95, new StaticLocalInitFlag(), null);
		}
		bool lockTaken209 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_95, ref lockTaken209);
			if (_StaticLocalInitFlag_95.State == 0)
			{
				_StaticLocalInitFlag_95.State = 2;
				_Double_108 = 0.0;
			}
			else if (_StaticLocalInitFlag_95.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_95.State = 1;
			if (lockTaken209)
			{
				Monitor.Exit(_StaticLocalInitFlag_95);
			}
		}
		if (_StaticLocalInitFlag_96 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_96, new StaticLocalInitFlag(), null);
		}
		bool lockTaken210 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_96, ref lockTaken210);
			if (_StaticLocalInitFlag_96.State == 0)
			{
				_StaticLocalInitFlag_96.State = 2;
				_Double_109 = 0.0;
			}
			else if (_StaticLocalInitFlag_96.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_96.State = 1;
			if (lockTaken210)
			{
				Monitor.Exit(_StaticLocalInitFlag_96);
			}
		}
		if (_StaticLocalInitFlag_97 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_97, new StaticLocalInitFlag(), null);
		}
		bool lockTaken211 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_97, ref lockTaken211);
			if (_StaticLocalInitFlag_97.State == 0)
			{
				_StaticLocalInitFlag_97.State = 2;
				_Double_110 = 0.0;
			}
			else if (_StaticLocalInitFlag_97.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_97.State = 1;
			if (lockTaken211)
			{
				Monitor.Exit(_StaticLocalInitFlag_97);
			}
		}
		if (_StaticLocalInitFlag_98 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_98, new StaticLocalInitFlag(), null);
		}
		bool lockTaken212 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_98, ref lockTaken212);
			if (_StaticLocalInitFlag_98.State == 0)
			{
				_StaticLocalInitFlag_98.State = 2;
				_Double_111 = 0.0;
			}
			else if (_StaticLocalInitFlag_98.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_98.State = 1;
			if (lockTaken212)
			{
				Monitor.Exit(_StaticLocalInitFlag_98);
			}
		}
		if (_StaticLocalInitFlag_99 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_99, new StaticLocalInitFlag(), null);
		}
		bool lockTaken3 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_99, ref lockTaken3);
			if (_StaticLocalInitFlag_99.State == 0)
			{
				_StaticLocalInitFlag_99.State = 2;
				_Double_112 = 0.0;
			}
			else if (_StaticLocalInitFlag_99.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_99.State = 1;
			if (lockTaken3)
			{
				Monitor.Exit(_StaticLocalInitFlag_99);
			}
		}
		if (_StaticLocalInitFlag_100 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_100, new StaticLocalInitFlag(), null);
		}
		bool lockTaken4 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_100, ref lockTaken4);
			if (_StaticLocalInitFlag_100.State == 0)
			{
				_StaticLocalInitFlag_100.State = 2;
				_Double_113 = 0.0;
			}
			else if (_StaticLocalInitFlag_100.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_100.State = 1;
			if (lockTaken4)
			{
				Monitor.Exit(_StaticLocalInitFlag_100);
			}
		}
		if (_StaticLocalInitFlag_101 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_101, new StaticLocalInitFlag(), null);
		}
		bool lockTaken5 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_101, ref lockTaken5);
			if (_StaticLocalInitFlag_101.State == 0)
			{
				_StaticLocalInitFlag_101.State = 2;
				_Double_114 = 0.0;
			}
			else if (_StaticLocalInitFlag_101.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_101.State = 1;
			if (lockTaken5)
			{
				Monitor.Exit(_StaticLocalInitFlag_101);
			}
		}
		if (_StaticLocalInitFlag_102 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_102, new StaticLocalInitFlag(), null);
		}
		bool lockTaken6 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_102, ref lockTaken6);
			if (_StaticLocalInitFlag_102.State == 0)
			{
				_StaticLocalInitFlag_102.State = 2;
				_Double_115 = 0.0;
			}
			else if (_StaticLocalInitFlag_102.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_102.State = 1;
			if (lockTaken6)
			{
				Monitor.Exit(_StaticLocalInitFlag_102);
			}
		}
		if (_StaticLocalInitFlag_103 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_103, new StaticLocalInitFlag(), null);
		}
		bool lockTaken7 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_103, ref lockTaken7);
			if (_StaticLocalInitFlag_103.State == 0)
			{
				_StaticLocalInitFlag_103.State = 2;
				_Double_116 = 0.0;
			}
			else if (_StaticLocalInitFlag_103.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_103.State = 1;
			if (lockTaken7)
			{
				Monitor.Exit(_StaticLocalInitFlag_103);
			}
		}
		if (_StaticLocalInitFlag_104 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_104, new StaticLocalInitFlag(), null);
		}
		bool lockTaken8 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_104, ref lockTaken8);
			if (_StaticLocalInitFlag_104.State == 0)
			{
				_StaticLocalInitFlag_104.State = 2;
				_Double_117 = 0.0;
			}
			else if (_StaticLocalInitFlag_104.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_104.State = 1;
			if (lockTaken8)
			{
				Monitor.Exit(_StaticLocalInitFlag_104);
			}
		}
		if (_StaticLocalInitFlag_105 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_105, new StaticLocalInitFlag(), null);
		}
		bool lockTaken9 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_105, ref lockTaken9);
			if (_StaticLocalInitFlag_105.State == 0)
			{
				_StaticLocalInitFlag_105.State = 2;
				_Double_118 = 0.0;
			}
			else if (_StaticLocalInitFlag_105.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_105.State = 1;
			if (lockTaken9)
			{
				Monitor.Exit(_StaticLocalInitFlag_105);
			}
		}
		if (_StaticLocalInitFlag_106 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_106, new StaticLocalInitFlag(), null);
		}
		bool lockTaken10 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_106, ref lockTaken10);
			if (_StaticLocalInitFlag_106.State == 0)
			{
				_StaticLocalInitFlag_106.State = 2;
				_Double_119 = 0.0;
			}
			else if (_StaticLocalInitFlag_106.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_106.State = 1;
			if (lockTaken10)
			{
				Monitor.Exit(_StaticLocalInitFlag_106);
			}
		}
		if (_StaticLocalInitFlag_107 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_107, new StaticLocalInitFlag(), null);
		}
		bool lockTaken11 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_107, ref lockTaken11);
			if (_StaticLocalInitFlag_107.State == 0)
			{
				_StaticLocalInitFlag_107.State = 2;
				_Double_120 = 0.0;
			}
			else if (_StaticLocalInitFlag_107.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_107.State = 1;
			if (lockTaken11)
			{
				Monitor.Exit(_StaticLocalInitFlag_107);
			}
		}
		if (_StaticLocalInitFlag_108 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_108, new StaticLocalInitFlag(), null);
		}
		bool lockTaken12 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_108, ref lockTaken12);
			if (_StaticLocalInitFlag_108.State == 0)
			{
				_StaticLocalInitFlag_108.State = 2;
				_Double_121 = 0.0;
			}
			else if (_StaticLocalInitFlag_108.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_108.State = 1;
			if (lockTaken12)
			{
				Monitor.Exit(_StaticLocalInitFlag_108);
			}
		}
		if (_StaticLocalInitFlag_109 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_109, new StaticLocalInitFlag(), null);
		}
		bool lockTaken14 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_109, ref lockTaken14);
			if (_StaticLocalInitFlag_109.State == 0)
			{
				_StaticLocalInitFlag_109.State = 2;
				_Double_122 = 0.0;
			}
			else if (_StaticLocalInitFlag_109.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_109.State = 1;
			if (lockTaken14)
			{
				Monitor.Exit(_StaticLocalInitFlag_109);
			}
		}
		if (_StaticLocalInitFlag_110 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_110, new StaticLocalInitFlag(), null);
		}
		bool lockTaken15 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_110, ref lockTaken15);
			if (_StaticLocalInitFlag_110.State == 0)
			{
				_StaticLocalInitFlag_110.State = 2;
				_Double_123 = 0.0;
			}
			else if (_StaticLocalInitFlag_110.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_110.State = 1;
			if (lockTaken15)
			{
				Monitor.Exit(_StaticLocalInitFlag_110);
			}
		}
		if (_StaticLocalInitFlag_111 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_111, new StaticLocalInitFlag(), null);
		}
		bool lockTaken16 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_111, ref lockTaken16);
			if (_StaticLocalInitFlag_111.State == 0)
			{
				_StaticLocalInitFlag_111.State = 2;
				_Double_124 = 0.0;
			}
			else if (_StaticLocalInitFlag_111.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_111.State = 1;
			if (lockTaken16)
			{
				Monitor.Exit(_StaticLocalInitFlag_111);
			}
		}
		if (_StaticLocalInitFlag_112 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_112, new StaticLocalInitFlag(), null);
		}
		bool lockTaken17 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_112, ref lockTaken17);
			if (_StaticLocalInitFlag_112.State == 0)
			{
				_StaticLocalInitFlag_112.State = 2;
				_Double_125 = 0.0;
			}
			else if (_StaticLocalInitFlag_112.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_112.State = 1;
			if (lockTaken17)
			{
				Monitor.Exit(_StaticLocalInitFlag_112);
			}
		}
		if (_StaticLocalInitFlag_113 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_113, new StaticLocalInitFlag(), null);
		}
		bool lockTaken18 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_113, ref lockTaken18);
			if (_StaticLocalInitFlag_113.State == 0)
			{
				_StaticLocalInitFlag_113.State = 2;
				_Double_126 = 0.0;
			}
			else if (_StaticLocalInitFlag_113.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_113.State = 1;
			if (lockTaken18)
			{
				Monitor.Exit(_StaticLocalInitFlag_113);
			}
		}
		if (_StaticLocalInitFlag_114 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_114, new StaticLocalInitFlag(), null);
		}
		bool lockTaken19 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_114, ref lockTaken19);
			if (_StaticLocalInitFlag_114.State == 0)
			{
				_StaticLocalInitFlag_114.State = 2;
				_Double_127 = 0.0;
			}
			else if (_StaticLocalInitFlag_114.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_114.State = 1;
			if (lockTaken19)
			{
				Monitor.Exit(_StaticLocalInitFlag_114);
			}
		}
		if (_StaticLocalInitFlag_115 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_115, new StaticLocalInitFlag(), null);
		}
		bool lockTaken20 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_115, ref lockTaken20);
			if (_StaticLocalInitFlag_115.State == 0)
			{
				_StaticLocalInitFlag_115.State = 2;
				_Double_128 = 0.0;
			}
			else if (_StaticLocalInitFlag_115.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_115.State = 1;
			if (lockTaken20)
			{
				Monitor.Exit(_StaticLocalInitFlag_115);
			}
		}
		if (_StaticLocalInitFlag_116 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_116, new StaticLocalInitFlag(), null);
		}
		bool lockTaken21 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_116, ref lockTaken21);
			if (_StaticLocalInitFlag_116.State == 0)
			{
				_StaticLocalInitFlag_116.State = 2;
				_Double_129 = 0.0;
			}
			else if (_StaticLocalInitFlag_116.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_116.State = 1;
			if (lockTaken21)
			{
				Monitor.Exit(_StaticLocalInitFlag_116);
			}
		}
		if (_StaticLocalInitFlag_117 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_117, new StaticLocalInitFlag(), null);
		}
		bool lockTaken22 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_117, ref lockTaken22);
			if (_StaticLocalInitFlag_117.State == 0)
			{
				_StaticLocalInitFlag_117.State = 2;
				_Double_130 = 0.0;
			}
			else if (_StaticLocalInitFlag_117.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_117.State = 1;
			if (lockTaken22)
			{
				Monitor.Exit(_StaticLocalInitFlag_117);
			}
		}
		if (_StaticLocalInitFlag_118 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_118, new StaticLocalInitFlag(), null);
		}
		bool lockTaken23 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_118, ref lockTaken23);
			if (_StaticLocalInitFlag_118.State == 0)
			{
				_StaticLocalInitFlag_118.State = 2;
				_Double_131 = 0.0;
			}
			else if (_StaticLocalInitFlag_118.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_118.State = 1;
			if (lockTaken23)
			{
				Monitor.Exit(_StaticLocalInitFlag_118);
			}
		}
		if (_StaticLocalInitFlag_119 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_119, new StaticLocalInitFlag(), null);
		}
		bool lockTaken25 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_119, ref lockTaken25);
			if (_StaticLocalInitFlag_119.State == 0)
			{
				_StaticLocalInitFlag_119.State = 2;
				_Double_132 = 0.0;
			}
			else if (_StaticLocalInitFlag_119.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_119.State = 1;
			if (lockTaken25)
			{
				Monitor.Exit(_StaticLocalInitFlag_119);
			}
		}
		if (_StaticLocalInitFlag_120 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_120, new StaticLocalInitFlag(), null);
		}
		bool lockTaken26 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_120, ref lockTaken26);
			if (_StaticLocalInitFlag_120.State == 0)
			{
				_StaticLocalInitFlag_120.State = 2;
				_Double_133 = 0.0;
			}
			else if (_StaticLocalInitFlag_120.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_120.State = 1;
			if (lockTaken26)
			{
				Monitor.Exit(_StaticLocalInitFlag_120);
			}
		}
		if (_StaticLocalInitFlag_121 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_121, new StaticLocalInitFlag(), null);
		}
		bool lockTaken27 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_121, ref lockTaken27);
			if (_StaticLocalInitFlag_121.State == 0)
			{
				_StaticLocalInitFlag_121.State = 2;
				_Double_134 = 0.0;
			}
			else if (_StaticLocalInitFlag_121.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_121.State = 1;
			if (lockTaken27)
			{
				Monitor.Exit(_StaticLocalInitFlag_121);
			}
		}
		if (_StaticLocalInitFlag_122 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_122, new StaticLocalInitFlag(), null);
		}
		bool lockTaken28 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_122, ref lockTaken28);
			if (_StaticLocalInitFlag_122.State == 0)
			{
				_StaticLocalInitFlag_122.State = 2;
				_Double_135 = 0.0;
			}
			else if (_StaticLocalInitFlag_122.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_122.State = 1;
			if (lockTaken28)
			{
				Monitor.Exit(_StaticLocalInitFlag_122);
			}
		}
		if (_StaticLocalInitFlag_123 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_123, new StaticLocalInitFlag(), null);
		}
		bool lockTaken29 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_123, ref lockTaken29);
			if (_StaticLocalInitFlag_123.State == 0)
			{
				_StaticLocalInitFlag_123.State = 2;
				_Double_136 = 0.0;
			}
			else if (_StaticLocalInitFlag_123.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_123.State = 1;
			if (lockTaken29)
			{
				Monitor.Exit(_StaticLocalInitFlag_123);
			}
		}
		if (_StaticLocalInitFlag_124 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_124, new StaticLocalInitFlag(), null);
		}
		bool lockTaken30 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_124, ref lockTaken30);
			if (_StaticLocalInitFlag_124.State == 0)
			{
				_StaticLocalInitFlag_124.State = 2;
				_Double_137 = 0.0;
			}
			else if (_StaticLocalInitFlag_124.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_124.State = 1;
			if (lockTaken30)
			{
				Monitor.Exit(_StaticLocalInitFlag_124);
			}
		}
		if (_StaticLocalInitFlag_125 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_125, new StaticLocalInitFlag(), null);
		}
		bool lockTaken31 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_125, ref lockTaken31);
			if (_StaticLocalInitFlag_125.State == 0)
			{
				_StaticLocalInitFlag_125.State = 2;
				_Double_138 = 0.0;
			}
			else if (_StaticLocalInitFlag_125.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_125.State = 1;
			if (lockTaken31)
			{
				Monitor.Exit(_StaticLocalInitFlag_125);
			}
		}
		if (_StaticLocalInitFlag_126 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_126, new StaticLocalInitFlag(), null);
		}
		bool lockTaken32 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_126, ref lockTaken32);
			if (_StaticLocalInitFlag_126.State == 0)
			{
				_StaticLocalInitFlag_126.State = 2;
				_Double_139 = 0.0;
			}
			else if (_StaticLocalInitFlag_126.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_126.State = 1;
			if (lockTaken32)
			{
				Monitor.Exit(_StaticLocalInitFlag_126);
			}
		}
		if (_StaticLocalInitFlag_127 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_127, new StaticLocalInitFlag(), null);
		}
		bool lockTaken33 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_127, ref lockTaken33);
			if (_StaticLocalInitFlag_127.State == 0)
			{
				_StaticLocalInitFlag_127.State = 2;
				_Double_140 = 0.0;
			}
			else if (_StaticLocalInitFlag_127.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_127.State = 1;
			if (lockTaken33)
			{
				Monitor.Exit(_StaticLocalInitFlag_127);
			}
		}
		if (_StaticLocalInitFlag_128 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_128, new StaticLocalInitFlag(), null);
		}
		bool lockTaken34 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_128, ref lockTaken34);
			if (_StaticLocalInitFlag_128.State == 0)
			{
				_StaticLocalInitFlag_128.State = 2;
				_Double_141 = 0.0;
			}
			else if (_StaticLocalInitFlag_128.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_128.State = 1;
			if (lockTaken34)
			{
				Monitor.Exit(_StaticLocalInitFlag_128);
			}
		}
		if (_StaticLocalInitFlag_129 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_129, new StaticLocalInitFlag(), null);
		}
		bool lockTaken36 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_129, ref lockTaken36);
			if (_StaticLocalInitFlag_129.State == 0)
			{
				_StaticLocalInitFlag_129.State = 2;
				_Double_142 = 0.0;
			}
			else if (_StaticLocalInitFlag_129.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_129.State = 1;
			if (lockTaken36)
			{
				Monitor.Exit(_StaticLocalInitFlag_129);
			}
		}
		if (_StaticLocalInitFlag_130 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_130, new StaticLocalInitFlag(), null);
		}
		bool lockTaken37 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_130, ref lockTaken37);
			if (_StaticLocalInitFlag_130.State == 0)
			{
				_StaticLocalInitFlag_130.State = 2;
				_Double_143 = 0.0;
			}
			else if (_StaticLocalInitFlag_130.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_130.State = 1;
			if (lockTaken37)
			{
				Monitor.Exit(_StaticLocalInitFlag_130);
			}
		}
		if (_StaticLocalInitFlag_131 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_131, new StaticLocalInitFlag(), null);
		}
		bool lockTaken38 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_131, ref lockTaken38);
			if (_StaticLocalInitFlag_131.State == 0)
			{
				_StaticLocalInitFlag_131.State = 2;
				_Double_144 = 0.0;
			}
			else if (_StaticLocalInitFlag_131.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_131.State = 1;
			if (lockTaken38)
			{
				Monitor.Exit(_StaticLocalInitFlag_131);
			}
		}
		if (_StaticLocalInitFlag_132 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_132, new StaticLocalInitFlag(), null);
		}
		bool lockTaken39 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_132, ref lockTaken39);
			if (_StaticLocalInitFlag_132.State == 0)
			{
				_StaticLocalInitFlag_132.State = 2;
				_Double_145 = 0.0;
			}
			else if (_StaticLocalInitFlag_132.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_132.State = 1;
			if (lockTaken39)
			{
				Monitor.Exit(_StaticLocalInitFlag_132);
			}
		}
		if (_StaticLocalInitFlag_133 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_133, new StaticLocalInitFlag(), null);
		}
		bool lockTaken40 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_133, ref lockTaken40);
			if (_StaticLocalInitFlag_133.State == 0)
			{
				_StaticLocalInitFlag_133.State = 2;
				_Double_146 = 0.0;
			}
			else if (_StaticLocalInitFlag_133.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_133.State = 1;
			if (lockTaken40)
			{
				Monitor.Exit(_StaticLocalInitFlag_133);
			}
		}
		if (_StaticLocalInitFlag_134 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_134, new StaticLocalInitFlag(), null);
		}
		bool lockTaken41 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_134, ref lockTaken41);
			if (_StaticLocalInitFlag_134.State == 0)
			{
				_StaticLocalInitFlag_134.State = 2;
				_Double_147 = 0.0;
			}
			else if (_StaticLocalInitFlag_134.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_134.State = 1;
			if (lockTaken41)
			{
				Monitor.Exit(_StaticLocalInitFlag_134);
			}
		}
		if (_StaticLocalInitFlag_135 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_135, new StaticLocalInitFlag(), null);
		}
		bool lockTaken42 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_135, ref lockTaken42);
			if (_StaticLocalInitFlag_135.State == 0)
			{
				_StaticLocalInitFlag_135.State = 2;
				_Double_148 = 0.0;
			}
			else if (_StaticLocalInitFlag_135.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_135.State = 1;
			if (lockTaken42)
			{
				Monitor.Exit(_StaticLocalInitFlag_135);
			}
		}
		if (_StaticLocalInitFlag_136 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_136, new StaticLocalInitFlag(), null);
		}
		bool lockTaken43 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_136, ref lockTaken43);
			if (_StaticLocalInitFlag_136.State == 0)
			{
				_StaticLocalInitFlag_136.State = 2;
				_Double_149 = 0.0;
			}
			else if (_StaticLocalInitFlag_136.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_136.State = 1;
			if (lockTaken43)
			{
				Monitor.Exit(_StaticLocalInitFlag_136);
			}
		}
		if (_StaticLocalInitFlag_137 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_137, new StaticLocalInitFlag(), null);
		}
		bool lockTaken44 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_137, ref lockTaken44);
			if (_StaticLocalInitFlag_137.State == 0)
			{
				_StaticLocalInitFlag_137.State = 2;
				_Double_150 = 0.0;
			}
			else if (_StaticLocalInitFlag_137.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_137.State = 1;
			if (lockTaken44)
			{
				Monitor.Exit(_StaticLocalInitFlag_137);
			}
		}
		if (_StaticLocalInitFlag_138 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_138, new StaticLocalInitFlag(), null);
		}
		bool lockTaken45 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_138, ref lockTaken45);
			if (_StaticLocalInitFlag_138.State == 0)
			{
				_StaticLocalInitFlag_138.State = 2;
				_Double_151 = 0.0;
			}
			else if (_StaticLocalInitFlag_138.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_138.State = 1;
			if (lockTaken45)
			{
				Monitor.Exit(_StaticLocalInitFlag_138);
			}
		}
		if (_StaticLocalInitFlag_139 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_139, new StaticLocalInitFlag(), null);
		}
		bool lockTaken47 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_139, ref lockTaken47);
			if (_StaticLocalInitFlag_139.State == 0)
			{
				_StaticLocalInitFlag_139.State = 2;
				_Double_152 = 0.0;
			}
			else if (_StaticLocalInitFlag_139.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_139.State = 1;
			if (lockTaken47)
			{
				Monitor.Exit(_StaticLocalInitFlag_139);
			}
		}
		if (_StaticLocalInitFlag_140 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_140, new StaticLocalInitFlag(), null);
		}
		bool lockTaken48 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_140, ref lockTaken48);
			if (_StaticLocalInitFlag_140.State == 0)
			{
				_StaticLocalInitFlag_140.State = 2;
				_Double_153 = 0.0;
			}
			else if (_StaticLocalInitFlag_140.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_140.State = 1;
			if (lockTaken48)
			{
				Monitor.Exit(_StaticLocalInitFlag_140);
			}
		}
		if (_StaticLocalInitFlag_141 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_141, new StaticLocalInitFlag(), null);
		}
		bool lockTaken49 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_141, ref lockTaken49);
			if (_StaticLocalInitFlag_141.State == 0)
			{
				_StaticLocalInitFlag_141.State = 2;
				_Double_154 = 0.0;
			}
			else if (_StaticLocalInitFlag_141.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_141.State = 1;
			if (lockTaken49)
			{
				Monitor.Exit(_StaticLocalInitFlag_141);
			}
		}
		if (_StaticLocalInitFlag_142 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_142, new StaticLocalInitFlag(), null);
		}
		bool lockTaken50 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_142, ref lockTaken50);
			if (_StaticLocalInitFlag_142.State == 0)
			{
				_StaticLocalInitFlag_142.State = 2;
				_Double_155 = 0.0;
			}
			else if (_StaticLocalInitFlag_142.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_142.State = 1;
			if (lockTaken50)
			{
				Monitor.Exit(_StaticLocalInitFlag_142);
			}
		}
		if (_StaticLocalInitFlag_143 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_143, new StaticLocalInitFlag(), null);
		}
		bool lockTaken51 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_143, ref lockTaken51);
			if (_StaticLocalInitFlag_143.State == 0)
			{
				_StaticLocalInitFlag_143.State = 2;
				_Double_156 = 0.0;
			}
			else if (_StaticLocalInitFlag_143.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_143.State = 1;
			if (lockTaken51)
			{
				Monitor.Exit(_StaticLocalInitFlag_143);
			}
		}
		if (_StaticLocalInitFlag_144 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_144, new StaticLocalInitFlag(), null);
		}
		bool lockTaken52 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_144, ref lockTaken52);
			if (_StaticLocalInitFlag_144.State == 0)
			{
				_StaticLocalInitFlag_144.State = 2;
				_Double_157 = 0.0;
			}
			else if (_StaticLocalInitFlag_144.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_144.State = 1;
			if (lockTaken52)
			{
				Monitor.Exit(_StaticLocalInitFlag_144);
			}
		}
		if (_StaticLocalInitFlag_145 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_145, new StaticLocalInitFlag(), null);
		}
		bool lockTaken53 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_145, ref lockTaken53);
			if (_StaticLocalInitFlag_145.State == 0)
			{
				_StaticLocalInitFlag_145.State = 2;
				_Double_158 = 0.0;
			}
			else if (_StaticLocalInitFlag_145.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_145.State = 1;
			if (lockTaken53)
			{
				Monitor.Exit(_StaticLocalInitFlag_145);
			}
		}
		if (_StaticLocalInitFlag_146 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_146, new StaticLocalInitFlag(), null);
		}
		bool lockTaken54 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_146, ref lockTaken54);
			if (_StaticLocalInitFlag_146.State == 0)
			{
				_StaticLocalInitFlag_146.State = 2;
				_Double_159 = 0.0;
			}
			else if (_StaticLocalInitFlag_146.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_146.State = 1;
			if (lockTaken54)
			{
				Monitor.Exit(_StaticLocalInitFlag_146);
			}
		}
		if (_StaticLocalInitFlag_147 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_147, new StaticLocalInitFlag(), null);
		}
		bool lockTaken55 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_147, ref lockTaken55);
			if (_StaticLocalInitFlag_147.State == 0)
			{
				_StaticLocalInitFlag_147.State = 2;
				_Double_160 = 0.0;
			}
			else if (_StaticLocalInitFlag_147.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_147.State = 1;
			if (lockTaken55)
			{
				Monitor.Exit(_StaticLocalInitFlag_147);
			}
		}
		if (_StaticLocalInitFlag_148 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_148, new StaticLocalInitFlag(), null);
		}
		bool lockTaken56 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_148, ref lockTaken56);
			if (_StaticLocalInitFlag_148.State == 0)
			{
				_StaticLocalInitFlag_148.State = 2;
				_Double_161 = 0.0;
			}
			else if (_StaticLocalInitFlag_148.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_148.State = 1;
			if (lockTaken56)
			{
				Monitor.Exit(_StaticLocalInitFlag_148);
			}
		}
		if (_StaticLocalInitFlag_149 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_149, new StaticLocalInitFlag(), null);
		}
		bool lockTaken58 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_149, ref lockTaken58);
			if (_StaticLocalInitFlag_149.State == 0)
			{
				_StaticLocalInitFlag_149.State = 2;
				_Double_162 = 0.0;
			}
			else if (_StaticLocalInitFlag_149.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_149.State = 1;
			if (lockTaken58)
			{
				Monitor.Exit(_StaticLocalInitFlag_149);
			}
		}
		if (_StaticLocalInitFlag_150 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_150, new StaticLocalInitFlag(), null);
		}
		bool lockTaken59 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_150, ref lockTaken59);
			if (_StaticLocalInitFlag_150.State == 0)
			{
				_StaticLocalInitFlag_150.State = 2;
				_Double_163 = 0.0;
			}
			else if (_StaticLocalInitFlag_150.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_150.State = 1;
			if (lockTaken59)
			{
				Monitor.Exit(_StaticLocalInitFlag_150);
			}
		}
		if (_StaticLocalInitFlag_151 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_151, new StaticLocalInitFlag(), null);
		}
		bool lockTaken60 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_151, ref lockTaken60);
			if (_StaticLocalInitFlag_151.State == 0)
			{
				_StaticLocalInitFlag_151.State = 2;
				_Double_164 = 0.0;
			}
			else if (_StaticLocalInitFlag_151.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_151.State = 1;
			if (lockTaken60)
			{
				Monitor.Exit(_StaticLocalInitFlag_151);
			}
		}
		if (_StaticLocalInitFlag_152 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_152, new StaticLocalInitFlag(), null);
		}
		bool lockTaken61 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_152, ref lockTaken61);
			if (_StaticLocalInitFlag_152.State == 0)
			{
				_StaticLocalInitFlag_152.State = 2;
				_Double_165 = 0.0;
			}
			else if (_StaticLocalInitFlag_152.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_152.State = 1;
			if (lockTaken61)
			{
				Monitor.Exit(_StaticLocalInitFlag_152);
			}
		}
		if (_StaticLocalInitFlag_153 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_153, new StaticLocalInitFlag(), null);
		}
		bool lockTaken62 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_153, ref lockTaken62);
			if (_StaticLocalInitFlag_153.State == 0)
			{
				_StaticLocalInitFlag_153.State = 2;
				_Double_166 = 0.0;
			}
			else if (_StaticLocalInitFlag_153.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_153.State = 1;
			if (lockTaken62)
			{
				Monitor.Exit(_StaticLocalInitFlag_153);
			}
		}
		if (_StaticLocalInitFlag_154 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_154, new StaticLocalInitFlag(), null);
		}
		bool lockTaken63 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_154, ref lockTaken63);
			if (_StaticLocalInitFlag_154.State == 0)
			{
				_StaticLocalInitFlag_154.State = 2;
				_Double_167 = 0.0;
			}
			else if (_StaticLocalInitFlag_154.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_154.State = 1;
			if (lockTaken63)
			{
				Monitor.Exit(_StaticLocalInitFlag_154);
			}
		}
		if (_StaticLocalInitFlag_155 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_155, new StaticLocalInitFlag(), null);
		}
		bool lockTaken64 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_155, ref lockTaken64);
			if (_StaticLocalInitFlag_155.State == 0)
			{
				_StaticLocalInitFlag_155.State = 2;
				_Double_168 = 0.0;
			}
			else if (_StaticLocalInitFlag_155.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_155.State = 1;
			if (lockTaken64)
			{
				Monitor.Exit(_StaticLocalInitFlag_155);
			}
		}
		if (_StaticLocalInitFlag_156 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_156, new StaticLocalInitFlag(), null);
		}
		bool lockTaken65 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_156, ref lockTaken65);
			if (_StaticLocalInitFlag_156.State == 0)
			{
				_StaticLocalInitFlag_156.State = 2;
				_Double_169 = 0.0;
			}
			else if (_StaticLocalInitFlag_156.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_156.State = 1;
			if (lockTaken65)
			{
				Monitor.Exit(_StaticLocalInitFlag_156);
			}
		}
		if (_StaticLocalInitFlag_157 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_157, new StaticLocalInitFlag(), null);
		}
		bool lockTaken66 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_157, ref lockTaken66);
			if (_StaticLocalInitFlag_157.State == 0)
			{
				_StaticLocalInitFlag_157.State = 2;
				_Double_170 = 0.0;
			}
			else if (_StaticLocalInitFlag_157.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_157.State = 1;
			if (lockTaken66)
			{
				Monitor.Exit(_StaticLocalInitFlag_157);
			}
		}
		if (_StaticLocalInitFlag_158 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_158, new StaticLocalInitFlag(), null);
		}
		bool lockTaken67 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_158, ref lockTaken67);
			if (_StaticLocalInitFlag_158.State == 0)
			{
				_StaticLocalInitFlag_158.State = 2;
				_Double_171 = 0.0;
			}
			else if (_StaticLocalInitFlag_158.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_158.State = 1;
			if (lockTaken67)
			{
				Monitor.Exit(_StaticLocalInitFlag_158);
			}
		}
		if (_StaticLocalInitFlag_159 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_159, new StaticLocalInitFlag(), null);
		}
		bool lockTaken69 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_159, ref lockTaken69);
			if (_StaticLocalInitFlag_159.State == 0)
			{
				_StaticLocalInitFlag_159.State = 2;
				_Double_172 = 0.0;
			}
			else if (_StaticLocalInitFlag_159.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_159.State = 1;
			if (lockTaken69)
			{
				Monitor.Exit(_StaticLocalInitFlag_159);
			}
		}
		if (_StaticLocalInitFlag_160 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_160, new StaticLocalInitFlag(), null);
		}
		bool lockTaken70 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_160, ref lockTaken70);
			if (_StaticLocalInitFlag_160.State == 0)
			{
				_StaticLocalInitFlag_160.State = 2;
				_Double_173 = 0.0;
			}
			else if (_StaticLocalInitFlag_160.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_160.State = 1;
			if (lockTaken70)
			{
				Monitor.Exit(_StaticLocalInitFlag_160);
			}
		}
		if (_StaticLocalInitFlag_161 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_161, new StaticLocalInitFlag(), null);
		}
		bool lockTaken71 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_161, ref lockTaken71);
			if (_StaticLocalInitFlag_161.State == 0)
			{
				_StaticLocalInitFlag_161.State = 2;
				_Double_174 = 0.0;
			}
			else if (_StaticLocalInitFlag_161.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_161.State = 1;
			if (lockTaken71)
			{
				Monitor.Exit(_StaticLocalInitFlag_161);
			}
		}
		if (_StaticLocalInitFlag_162 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_162, new StaticLocalInitFlag(), null);
		}
		bool lockTaken72 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_162, ref lockTaken72);
			if (_StaticLocalInitFlag_162.State == 0)
			{
				_StaticLocalInitFlag_162.State = 2;
				_Double_175 = 0.0;
			}
			else if (_StaticLocalInitFlag_162.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_162.State = 1;
			if (lockTaken72)
			{
				Monitor.Exit(_StaticLocalInitFlag_162);
			}
		}
		if (_StaticLocalInitFlag_163 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_163, new StaticLocalInitFlag(), null);
		}
		bool lockTaken73 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_163, ref lockTaken73);
			if (_StaticLocalInitFlag_163.State == 0)
			{
				_StaticLocalInitFlag_163.State = 2;
				_Double_176 = 0.0;
			}
			else if (_StaticLocalInitFlag_163.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_163.State = 1;
			if (lockTaken73)
			{
				Monitor.Exit(_StaticLocalInitFlag_163);
			}
		}
		if (_StaticLocalInitFlag_164 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_164, new StaticLocalInitFlag(), null);
		}
		bool lockTaken74 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_164, ref lockTaken74);
			if (_StaticLocalInitFlag_164.State == 0)
			{
				_StaticLocalInitFlag_164.State = 2;
				_Double_177 = 0.0;
			}
			else if (_StaticLocalInitFlag_164.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_164.State = 1;
			if (lockTaken74)
			{
				Monitor.Exit(_StaticLocalInitFlag_164);
			}
		}
		if (_StaticLocalInitFlag_165 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_165, new StaticLocalInitFlag(), null);
		}
		bool lockTaken75 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_165, ref lockTaken75);
			if (_StaticLocalInitFlag_165.State == 0)
			{
				_StaticLocalInitFlag_165.State = 2;
				_Double_178 = 0.0;
			}
			else if (_StaticLocalInitFlag_165.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_165.State = 1;
			if (lockTaken75)
			{
				Monitor.Exit(_StaticLocalInitFlag_165);
			}
		}
		if (_StaticLocalInitFlag_166 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_166, new StaticLocalInitFlag(), null);
		}
		bool lockTaken76 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_166, ref lockTaken76);
			if (_StaticLocalInitFlag_166.State == 0)
			{
				_StaticLocalInitFlag_166.State = 2;
				_Double_179 = 0.0;
			}
			else if (_StaticLocalInitFlag_166.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_166.State = 1;
			if (lockTaken76)
			{
				Monitor.Exit(_StaticLocalInitFlag_166);
			}
		}
		if (_StaticLocalInitFlag_167 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_167, new StaticLocalInitFlag(), null);
		}
		bool lockTaken77 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_167, ref lockTaken77);
			if (_StaticLocalInitFlag_167.State == 0)
			{
				_StaticLocalInitFlag_167.State = 2;
				_Double_180 = 0.0;
			}
			else if (_StaticLocalInitFlag_167.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_167.State = 1;
			if (lockTaken77)
			{
				Monitor.Exit(_StaticLocalInitFlag_167);
			}
		}
		if (_StaticLocalInitFlag_168 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_168, new StaticLocalInitFlag(), null);
		}
		bool lockTaken78 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_168, ref lockTaken78);
			if (_StaticLocalInitFlag_168.State == 0)
			{
				_StaticLocalInitFlag_168.State = 2;
				_Double_181 = 0.0;
			}
			else if (_StaticLocalInitFlag_168.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_168.State = 1;
			if (lockTaken78)
			{
				Monitor.Exit(_StaticLocalInitFlag_168);
			}
		}
		if (_StaticLocalInitFlag_169 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_169, new StaticLocalInitFlag(), null);
		}
		bool lockTaken80 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_169, ref lockTaken80);
			if (_StaticLocalInitFlag_169.State == 0)
			{
				_StaticLocalInitFlag_169.State = 2;
				_Double_182 = 0.0;
			}
			else if (_StaticLocalInitFlag_169.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_169.State = 1;
			if (lockTaken80)
			{
				Monitor.Exit(_StaticLocalInitFlag_169);
			}
		}
		if (_StaticLocalInitFlag_170 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_170, new StaticLocalInitFlag(), null);
		}
		bool lockTaken81 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_170, ref lockTaken81);
			if (_StaticLocalInitFlag_170.State == 0)
			{
				_StaticLocalInitFlag_170.State = 2;
				_Double_183 = 0.0;
			}
			else if (_StaticLocalInitFlag_170.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_170.State = 1;
			if (lockTaken81)
			{
				Monitor.Exit(_StaticLocalInitFlag_170);
			}
		}
		if (_StaticLocalInitFlag_171 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_171, new StaticLocalInitFlag(), null);
		}
		bool lockTaken82 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_171, ref lockTaken82);
			if (_StaticLocalInitFlag_171.State == 0)
			{
				_StaticLocalInitFlag_171.State = 2;
				_Double_184 = 0.0;
			}
			else if (_StaticLocalInitFlag_171.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_171.State = 1;
			if (lockTaken82)
			{
				Monitor.Exit(_StaticLocalInitFlag_171);
			}
		}
		if (_StaticLocalInitFlag_172 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_172, new StaticLocalInitFlag(), null);
		}
		bool lockTaken83 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_172, ref lockTaken83);
			if (_StaticLocalInitFlag_172.State == 0)
			{
				_StaticLocalInitFlag_172.State = 2;
				_Double_185 = 0.0;
			}
			else if (_StaticLocalInitFlag_172.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_172.State = 1;
			if (lockTaken83)
			{
				Monitor.Exit(_StaticLocalInitFlag_172);
			}
		}
		if (_StaticLocalInitFlag_173 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_173, new StaticLocalInitFlag(), null);
		}
		bool lockTaken84 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_173, ref lockTaken84);
			if (_StaticLocalInitFlag_173.State == 0)
			{
				_StaticLocalInitFlag_173.State = 2;
				_Double_186 = 0.0;
			}
			else if (_StaticLocalInitFlag_173.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_173.State = 1;
			if (lockTaken84)
			{
				Monitor.Exit(_StaticLocalInitFlag_173);
			}
		}
		if (_StaticLocalInitFlag_174 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_174, new StaticLocalInitFlag(), null);
		}
		bool lockTaken85 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_174, ref lockTaken85);
			if (_StaticLocalInitFlag_174.State == 0)
			{
				_StaticLocalInitFlag_174.State = 2;
				_Double_187 = 0.0;
			}
			else if (_StaticLocalInitFlag_174.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_174.State = 1;
			if (lockTaken85)
			{
				Monitor.Exit(_StaticLocalInitFlag_174);
			}
		}
		if (_StaticLocalInitFlag_175 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_175, new StaticLocalInitFlag(), null);
		}
		bool lockTaken86 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_175, ref lockTaken86);
			if (_StaticLocalInitFlag_175.State == 0)
			{
				_StaticLocalInitFlag_175.State = 2;
				_Double_188 = 0.0;
			}
			else if (_StaticLocalInitFlag_175.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_175.State = 1;
			if (lockTaken86)
			{
				Monitor.Exit(_StaticLocalInitFlag_175);
			}
		}
		if (_StaticLocalInitFlag_176 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_176, new StaticLocalInitFlag(), null);
		}
		bool lockTaken87 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_176, ref lockTaken87);
			if (_StaticLocalInitFlag_176.State == 0)
			{
				_StaticLocalInitFlag_176.State = 2;
				_Double_189 = 0.0;
			}
			else if (_StaticLocalInitFlag_176.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_176.State = 1;
			if (lockTaken87)
			{
				Monitor.Exit(_StaticLocalInitFlag_176);
			}
		}
		if (_StaticLocalInitFlag_177 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_177, new StaticLocalInitFlag(), null);
		}
		bool lockTaken88 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_177, ref lockTaken88);
			if (_StaticLocalInitFlag_177.State == 0)
			{
				_StaticLocalInitFlag_177.State = 2;
				_Double_190 = 0.0;
			}
			else if (_StaticLocalInitFlag_177.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_177.State = 1;
			if (lockTaken88)
			{
				Monitor.Exit(_StaticLocalInitFlag_177);
			}
		}
		if (_StaticLocalInitFlag_178 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_178, new StaticLocalInitFlag(), null);
		}
		bool lockTaken89 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_178, ref lockTaken89);
			if (_StaticLocalInitFlag_178.State == 0)
			{
				_StaticLocalInitFlag_178.State = 2;
				_Double_191 = 0.0;
			}
			else if (_StaticLocalInitFlag_178.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_178.State = 1;
			if (lockTaken89)
			{
				Monitor.Exit(_StaticLocalInitFlag_178);
			}
		}
		if (_StaticLocalInitFlag_179 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_179, new StaticLocalInitFlag(), null);
		}
		bool lockTaken91 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_179, ref lockTaken91);
			if (_StaticLocalInitFlag_179.State == 0)
			{
				_StaticLocalInitFlag_179.State = 2;
				_Double_192 = 0.0;
			}
			else if (_StaticLocalInitFlag_179.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_179.State = 1;
			if (lockTaken91)
			{
				Monitor.Exit(_StaticLocalInitFlag_179);
			}
		}
		if (_StaticLocalInitFlag_180 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_180, new StaticLocalInitFlag(), null);
		}
		bool lockTaken92 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_180, ref lockTaken92);
			if (_StaticLocalInitFlag_180.State == 0)
			{
				_StaticLocalInitFlag_180.State = 2;
				_Double_193 = 0.0;
			}
			else if (_StaticLocalInitFlag_180.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_180.State = 1;
			if (lockTaken92)
			{
				Monitor.Exit(_StaticLocalInitFlag_180);
			}
		}
		if (_StaticLocalInitFlag_181 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_181, new StaticLocalInitFlag(), null);
		}
		bool lockTaken93 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_181, ref lockTaken93);
			if (_StaticLocalInitFlag_181.State == 0)
			{
				_StaticLocalInitFlag_181.State = 2;
				_Double_194 = 0.0;
			}
			else if (_StaticLocalInitFlag_181.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_181.State = 1;
			if (lockTaken93)
			{
				Monitor.Exit(_StaticLocalInitFlag_181);
			}
		}
		if (_StaticLocalInitFlag_182 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_182, new StaticLocalInitFlag(), null);
		}
		bool lockTaken94 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_182, ref lockTaken94);
			if (_StaticLocalInitFlag_182.State == 0)
			{
				_StaticLocalInitFlag_182.State = 2;
				_Double_195 = 0.0;
			}
			else if (_StaticLocalInitFlag_182.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_182.State = 1;
			if (lockTaken94)
			{
				Monitor.Exit(_StaticLocalInitFlag_182);
			}
		}
		if (_StaticLocalInitFlag_183 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_183, new StaticLocalInitFlag(), null);
		}
		bool lockTaken95 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_183, ref lockTaken95);
			if (_StaticLocalInitFlag_183.State == 0)
			{
				_StaticLocalInitFlag_183.State = 2;
				_Double_196 = 0.0;
			}
			else if (_StaticLocalInitFlag_183.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_183.State = 1;
			if (lockTaken95)
			{
				Monitor.Exit(_StaticLocalInitFlag_183);
			}
		}
		if (_StaticLocalInitFlag_184 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_184, new StaticLocalInitFlag(), null);
		}
		bool lockTaken96 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_184, ref lockTaken96);
			if (_StaticLocalInitFlag_184.State == 0)
			{
				_StaticLocalInitFlag_184.State = 2;
				_Double_197 = 0.0;
			}
			else if (_StaticLocalInitFlag_184.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_184.State = 1;
			if (lockTaken96)
			{
				Monitor.Exit(_StaticLocalInitFlag_184);
			}
		}
		if (_StaticLocalInitFlag_185 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_185, new StaticLocalInitFlag(), null);
		}
		bool lockTaken97 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_185, ref lockTaken97);
			if (_StaticLocalInitFlag_185.State == 0)
			{
				_StaticLocalInitFlag_185.State = 2;
				_Double_198 = 0.0;
			}
			else if (_StaticLocalInitFlag_185.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_185.State = 1;
			if (lockTaken97)
			{
				Monitor.Exit(_StaticLocalInitFlag_185);
			}
		}
		if (_StaticLocalInitFlag_186 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_186, new StaticLocalInitFlag(), null);
		}
		bool lockTaken98 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_186, ref lockTaken98);
			if (_StaticLocalInitFlag_186.State == 0)
			{
				_StaticLocalInitFlag_186.State = 2;
				_Double_199 = 0.0;
			}
			else if (_StaticLocalInitFlag_186.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_186.State = 1;
			if (lockTaken98)
			{
				Monitor.Exit(_StaticLocalInitFlag_186);
			}
		}
		if (_StaticLocalInitFlag_187 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_187, new StaticLocalInitFlag(), null);
		}
		bool lockTaken99 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_187, ref lockTaken99);
			if (_StaticLocalInitFlag_187.State == 0)
			{
				_StaticLocalInitFlag_187.State = 2;
				_Double_200 = 0.0;
			}
			else if (_StaticLocalInitFlag_187.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_187.State = 1;
			if (lockTaken99)
			{
				Monitor.Exit(_StaticLocalInitFlag_187);
			}
		}
		if (_StaticLocalInitFlag_188 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_188, new StaticLocalInitFlag(), null);
		}
		bool lockTaken100 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_188, ref lockTaken100);
			if (_StaticLocalInitFlag_188.State == 0)
			{
				_StaticLocalInitFlag_188.State = 2;
				_Double_201 = 0.0;
			}
			else if (_StaticLocalInitFlag_188.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_188.State = 1;
			if (lockTaken100)
			{
				Monitor.Exit(_StaticLocalInitFlag_188);
			}
		}
		if (_StaticLocalInitFlag_189 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_189, new StaticLocalInitFlag(), null);
		}
		bool lockTaken102 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_189, ref lockTaken102);
			if (_StaticLocalInitFlag_189.State == 0)
			{
				_StaticLocalInitFlag_189.State = 2;
				_Double_202 = 0.0;
			}
			else if (_StaticLocalInitFlag_189.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_189.State = 1;
			if (lockTaken102)
			{
				Monitor.Exit(_StaticLocalInitFlag_189);
			}
		}
		if (_StaticLocalInitFlag_190 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_190, new StaticLocalInitFlag(), null);
		}
		bool lockTaken103 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_190, ref lockTaken103);
			if (_StaticLocalInitFlag_190.State == 0)
			{
				_StaticLocalInitFlag_190.State = 2;
				_Double_203 = 0.0;
			}
			else if (_StaticLocalInitFlag_190.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_190.State = 1;
			if (lockTaken103)
			{
				Monitor.Exit(_StaticLocalInitFlag_190);
			}
		}
		if (_StaticLocalInitFlag_191 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_191, new StaticLocalInitFlag(), null);
		}
		bool lockTaken104 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_191, ref lockTaken104);
			if (_StaticLocalInitFlag_191.State == 0)
			{
				_StaticLocalInitFlag_191.State = 2;
				_Double_204 = 0.0;
			}
			else if (_StaticLocalInitFlag_191.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_191.State = 1;
			if (lockTaken104)
			{
				Monitor.Exit(_StaticLocalInitFlag_191);
			}
		}
		if (_StaticLocalInitFlag_192 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_192, new StaticLocalInitFlag(), null);
		}
		bool lockTaken105 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_192, ref lockTaken105);
			if (_StaticLocalInitFlag_192.State == 0)
			{
				_StaticLocalInitFlag_192.State = 2;
				_Double_205 = 0.0;
			}
			else if (_StaticLocalInitFlag_192.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_192.State = 1;
			if (lockTaken105)
			{
				Monitor.Exit(_StaticLocalInitFlag_192);
			}
		}
		if (_StaticLocalInitFlag_193 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_193, new StaticLocalInitFlag(), null);
		}
		bool lockTaken106 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_193, ref lockTaken106);
			if (_StaticLocalInitFlag_193.State == 0)
			{
				_StaticLocalInitFlag_193.State = 2;
				_Double_206 = 0.0;
			}
			else if (_StaticLocalInitFlag_193.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_193.State = 1;
			if (lockTaken106)
			{
				Monitor.Exit(_StaticLocalInitFlag_193);
			}
		}
		if (_StaticLocalInitFlag_194 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_194, new StaticLocalInitFlag(), null);
		}
		bool lockTaken107 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_194, ref lockTaken107);
			if (_StaticLocalInitFlag_194.State == 0)
			{
				_StaticLocalInitFlag_194.State = 2;
				_Double_207 = 0.0;
			}
			else if (_StaticLocalInitFlag_194.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_194.State = 1;
			if (lockTaken107)
			{
				Monitor.Exit(_StaticLocalInitFlag_194);
			}
		}
		if (_StaticLocalInitFlag_195 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_195, new StaticLocalInitFlag(), null);
		}
		bool lockTaken108 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_195, ref lockTaken108);
			if (_StaticLocalInitFlag_195.State == 0)
			{
				_StaticLocalInitFlag_195.State = 2;
				_Double_208 = 0.0;
			}
			else if (_StaticLocalInitFlag_195.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_195.State = 1;
			if (lockTaken108)
			{
				Monitor.Exit(_StaticLocalInitFlag_195);
			}
		}
		if (_StaticLocalInitFlag_196 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_196, new StaticLocalInitFlag(), null);
		}
		bool lockTaken109 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_196, ref lockTaken109);
			if (_StaticLocalInitFlag_196.State == 0)
			{
				_StaticLocalInitFlag_196.State = 2;
				_Double_209 = 0.0;
			}
			else if (_StaticLocalInitFlag_196.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_196.State = 1;
			if (lockTaken109)
			{
				Monitor.Exit(_StaticLocalInitFlag_196);
			}
		}
		if (_StaticLocalInitFlag_197 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_197, new StaticLocalInitFlag(), null);
		}
		bool lockTaken110 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_197, ref lockTaken110);
			if (_StaticLocalInitFlag_197.State == 0)
			{
				_StaticLocalInitFlag_197.State = 2;
				_Double_210 = 0.0;
			}
			else if (_StaticLocalInitFlag_197.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_197.State = 1;
			if (lockTaken110)
			{
				Monitor.Exit(_StaticLocalInitFlag_197);
			}
		}
		if (_StaticLocalInitFlag_198 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_198, new StaticLocalInitFlag(), null);
		}
		bool lockTaken111 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_198, ref lockTaken111);
			if (_StaticLocalInitFlag_198.State == 0)
			{
				_StaticLocalInitFlag_198.State = 2;
				_Double_211 = 0.0;
			}
			else if (_StaticLocalInitFlag_198.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_198.State = 1;
			if (lockTaken111)
			{
				Monitor.Exit(_StaticLocalInitFlag_198);
			}
		}
		if (_StaticLocalInitFlag_199 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_199, new StaticLocalInitFlag(), null);
		}
		bool lockTaken114 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_199, ref lockTaken114);
			if (_StaticLocalInitFlag_199.State == 0)
			{
				_StaticLocalInitFlag_199.State = 2;
				_Double_212 = 0.0;
			}
			else if (_StaticLocalInitFlag_199.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_199.State = 1;
			if (lockTaken114)
			{
				Monitor.Exit(_StaticLocalInitFlag_199);
			}
		}
		if (_StaticLocalInitFlag_200 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_200, new StaticLocalInitFlag(), null);
		}
		bool lockTaken115 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_200, ref lockTaken115);
			if (_StaticLocalInitFlag_200.State == 0)
			{
				_StaticLocalInitFlag_200.State = 2;
				_Double_213 = 0.0;
			}
			else if (_StaticLocalInitFlag_200.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_200.State = 1;
			if (lockTaken115)
			{
				Monitor.Exit(_StaticLocalInitFlag_200);
			}
		}
		if (_StaticLocalInitFlag_201 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_201, new StaticLocalInitFlag(), null);
		}
		bool lockTaken116 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_201, ref lockTaken116);
			if (_StaticLocalInitFlag_201.State == 0)
			{
				_StaticLocalInitFlag_201.State = 2;
				_Double_214 = 0.0;
			}
			else if (_StaticLocalInitFlag_201.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_201.State = 1;
			if (lockTaken116)
			{
				Monitor.Exit(_StaticLocalInitFlag_201);
			}
		}
		if (_StaticLocalInitFlag_202 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_202, new StaticLocalInitFlag(), null);
		}
		bool lockTaken117 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_202, ref lockTaken117);
			if (_StaticLocalInitFlag_202.State == 0)
			{
				_StaticLocalInitFlag_202.State = 2;
				_Double_215 = 0.0;
			}
			else if (_StaticLocalInitFlag_202.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_202.State = 1;
			if (lockTaken117)
			{
				Monitor.Exit(_StaticLocalInitFlag_202);
			}
		}
		if (_StaticLocalInitFlag_203 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_203, new StaticLocalInitFlag(), null);
		}
		bool lockTaken118 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_203, ref lockTaken118);
			if (_StaticLocalInitFlag_203.State == 0)
			{
				_StaticLocalInitFlag_203.State = 2;
				_Double_216 = 0.0;
			}
			else if (_StaticLocalInitFlag_203.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_203.State = 1;
			if (lockTaken118)
			{
				Monitor.Exit(_StaticLocalInitFlag_203);
			}
		}
		if (_StaticLocalInitFlag_204 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_204, new StaticLocalInitFlag(), null);
		}
		bool lockTaken119 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_204, ref lockTaken119);
			if (_StaticLocalInitFlag_204.State == 0)
			{
				_StaticLocalInitFlag_204.State = 2;
				_Double_217 = 0.0;
			}
			else if (_StaticLocalInitFlag_204.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_204.State = 1;
			if (lockTaken119)
			{
				Monitor.Exit(_StaticLocalInitFlag_204);
			}
		}
		if (_StaticLocalInitFlag_205 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_205, new StaticLocalInitFlag(), null);
		}
		bool lockTaken120 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_205, ref lockTaken120);
			if (_StaticLocalInitFlag_205.State == 0)
			{
				_StaticLocalInitFlag_205.State = 2;
				_Double_218 = 0.0;
			}
			else if (_StaticLocalInitFlag_205.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_205.State = 1;
			if (lockTaken120)
			{
				Monitor.Exit(_StaticLocalInitFlag_205);
			}
		}
		if (_StaticLocalInitFlag_206 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_206, new StaticLocalInitFlag(), null);
		}
		bool lockTaken121 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_206, ref lockTaken121);
			if (_StaticLocalInitFlag_206.State == 0)
			{
				_StaticLocalInitFlag_206.State = 2;
				_Double_219 = 0.0;
			}
			else if (_StaticLocalInitFlag_206.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_206.State = 1;
			if (lockTaken121)
			{
				Monitor.Exit(_StaticLocalInitFlag_206);
			}
		}
		if (_StaticLocalInitFlag_207 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_207, new StaticLocalInitFlag(), null);
		}
		bool lockTaken122 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_207, ref lockTaken122);
			if (_StaticLocalInitFlag_207.State == 0)
			{
				_StaticLocalInitFlag_207.State = 2;
				_Double_220 = 0.0;
			}
			else if (_StaticLocalInitFlag_207.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_207.State = 1;
			if (lockTaken122)
			{
				Monitor.Exit(_StaticLocalInitFlag_207);
			}
		}
		if (_StaticLocalInitFlag_208 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_208, new StaticLocalInitFlag(), null);
		}
		bool lockTaken123 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_208, ref lockTaken123);
			if (_StaticLocalInitFlag_208.State == 0)
			{
				_StaticLocalInitFlag_208.State = 2;
				_Double_221 = 0.0;
			}
			else if (_StaticLocalInitFlag_208.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_208.State = 1;
			if (lockTaken123)
			{
				Monitor.Exit(_StaticLocalInitFlag_208);
			}
		}
		if (_StaticLocalInitFlag_209 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_209, new StaticLocalInitFlag(), null);
		}
		bool lockTaken125 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_209, ref lockTaken125);
			if (_StaticLocalInitFlag_209.State == 0)
			{
				_StaticLocalInitFlag_209.State = 2;
				_Double_222 = 0.0;
			}
			else if (_StaticLocalInitFlag_209.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_209.State = 1;
			if (lockTaken125)
			{
				Monitor.Exit(_StaticLocalInitFlag_209);
			}
		}
		if (_StaticLocalInitFlag_210 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_210, new StaticLocalInitFlag(), null);
		}
		bool lockTaken126 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_210, ref lockTaken126);
			if (_StaticLocalInitFlag_210.State == 0)
			{
				_StaticLocalInitFlag_210.State = 2;
				_Double_223 = 0.0;
			}
			else if (_StaticLocalInitFlag_210.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_210.State = 1;
			if (lockTaken126)
			{
				Monitor.Exit(_StaticLocalInitFlag_210);
			}
		}
		if (_StaticLocalInitFlag_211 == null)
		{
			Interlocked.CompareExchange(ref _StaticLocalInitFlag_211, new StaticLocalInitFlag(), null);
		}
		bool lockTaken127 = false;
		try
		{
			Monitor.Enter(_StaticLocalInitFlag_211, ref lockTaken127);
			if (_StaticLocalInitFlag_211.State == 0)
			{
				_StaticLocalInitFlag_211.State = 2;
				_Double_224 = 0.0;
			}
			else if (_StaticLocalInitFlag_211.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_StaticLocalInitFlag_211.State = 1;
			if (lockTaken127)
			{
				Monitor.Exit(_StaticLocalInitFlag_211);
			}
		}
		switch (int_0)
		{
		case 1:
			_Double_153 = SxPxTime.PatchWatcher(ref sgp_data_0.epoch, ref _Double_224);
			_Double_63 = sgp_data_0.eo;
			_Double_187 = xnodp;
			_Double_32 = 1.0 / ao;
			_Double_190 = sgp_data_0.xincl;
			_Double_180 = sgp_data_0.xmo;
			_Double_189 = omgdt + xnodot;
			_Double_133 = Math.Sin(sgp_data_0.xnodeo);
			_Double_40 = Math.Cos(sgp_data_0.xnodeo);
			_Double_95 = sgp_data_0.omegao;
			_Double_53 = _Double_224 + 18261.5;
			if (_Double_53 != _Double_101)
			{
				_Double_101 = _Double_53;
				_Double_185 = 4.523602 - 0.00092422029 * _Double_53;
				_Double_147 = Math.Sin(_Double_185);
				_Double_41 = Math.Cos(_Double_185);
				_Double_208 = 0.91375164 - 0.03568096 * _Double_41;
				_Double_221 = Math.Sqrt(1.0 - _Double_208 * _Double_208);
				_Double_219 = 0.089683511 * _Double_147 / _Double_221;
				_Double_206 = Math.Sqrt(1.0 - _Double_219 * _Double_219);
				_Double_36 = 4.7199672 + 0.2299715 * _Double_53;
				_Double_94 = 5.8351514 + 0.001944368 * _Double_53;
				double double_ = _Double_36 - _Double_94;
				_Double_213 = SxPxMath.CloneWatcher(ref double_);
				_Double_222 = 0.39785416 * _Double_147 / _Double_221;
				_Double_223 = _Double_206 * _Double_41 + 0.91744867 * _Double_219 * _Double_147;
				_Double_222 = SxPxMath.MoveWatcher(ref _Double_222, ref _Double_223);
				_Double_222 = _Double_94 + _Double_222 - _Double_185;
				_Double_204 = Math.Cos(_Double_222);
				_Double_217 = Math.Sin(_Double_222);
				_Double_214 = 6.2565837 + 0.017201977 * _Double_53;
				_Double_214 = SxPxMath.CloneWatcher(ref _Double_214);
			}
			_Double_109 = 1E+20;
			_Double_203 = 0.1945905;
			_Double_216 = -0.98088458;
			_Double_207 = 0.91744867;
			_Double_220 = 0.39785416;
			_Double_205 = _Double_40;
			_Double_218 = _Double_133;
			_Double_37 = 2.9864797E-06;
			_Double_215 = 1.19459E-05;
			_Double_209 = 0.01675;
			_Double_212 = _Double_214;
			_Double_186 = 1.0 / _Double_187;
			_Int_5 = 30;
			_Int_6 = 0;
			while (_Int_6 < 2)
			{
				_Double_20 = _Double_203 * _Double_205 + _Double_216 * _Double_207 * _Double_218;
				_Double_22 = (0.0 - _Double_216) * _Double_205 + _Double_203 * _Double_207 * _Double_218;
				_Double_26 = (0.0 - _Double_203) * _Double_218 + _Double_216 * _Double_207 * _Double_205;
				_Double_27 = _Double_216 * _Double_220;
				_Double_28 = _Double_216 * _Double_218 + _Double_203 * _Double_207 * _Double_205;
				_Double_29 = _Double_203 * _Double_220;
				_Double_21 = cosiq * _Double_26 + siniq * _Double_27;
				_Double_23 = cosiq * _Double_28 + siniq * _Double_29;
				_Double_24 = (0.0 - siniq) * _Double_26 + cosiq * _Double_27;
				_Double_25 = (0.0 - siniq) * _Double_28 + cosiq * _Double_29;
				_Double_154 = _Double_20 * cosomo + _Double_21 * sinomo;
				_Double_155 = _Double_22 * cosomo + _Double_23 * sinomo;
				_Double_158 = (0.0 - _Double_20) * sinomo + _Double_21 * cosomo;
				_Double_159 = (0.0 - _Double_22) * sinomo + _Double_23 * cosomo;
				_Double_160 = _Double_24 * sinomo;
				_Double_161 = _Double_25 * sinomo;
				_Double_162 = _Double_24 * cosomo;
				_Double_163 = _Double_25 * cosomo;
				_Double_200 = 12.0 * _Double_154 * _Double_154 - 3.0 * _Double_158 * _Double_158;
				_Double_201 = 24.0 * _Double_154 * _Double_155 - 6.0 * _Double_158 * _Double_159;
				_Double_202 = 12.0 * _Double_155 * _Double_155 - 3.0 * _Double_159 * _Double_159;
				_Double_191 = 3.0 * (SxPxMath.CountWatcher(_Double_20) + SxPxMath.CountWatcher(_Double_21)) + _Double_200 * eqsq;
				_Double_195 = 6.0 * (_Double_20 * _Double_22 + _Double_21 * _Double_23) + _Double_201 * eqsq;
				_Double_199 = 3.0 * (_Double_22 * _Double_22 + _Double_23 * _Double_23) + _Double_202 * eqsq;
				_Double_192 = -6.0 * _Double_20 * _Double_24 + eqsq * (-24.0 * _Double_154 * _Double_162 - 6.0 * _Double_158 * _Double_160);
				_Double_193 = -6.0 * (_Double_20 * _Double_25 + _Double_22 * _Double_24) + eqsq * (-24.0 * (_Double_155 * _Double_162 + _Double_154 * _Double_163) - 6.0 * (_Double_158 * _Double_161 + _Double_159 * _Double_160));
				_Double_194 = -6.0 * _Double_22 * _Double_25 + eqsq * (-24.0 * _Double_155 * _Double_163 - 6.0 * _Double_159 * _Double_161);
				_Double_196 = 6.0 * _Double_21 * _Double_24 + eqsq * (24.0 * _Double_154 * _Double_160 - 6.0 * _Double_158 * _Double_162);
				_Double_197 = 6.0 * (_Double_23 * _Double_24 + _Double_21 * _Double_25) + eqsq * (24.0 * (_Double_155 * _Double_160 + _Double_154 * _Double_161) - 6.0 * (_Double_159 * _Double_162 + _Double_158 * _Double_163));
				_Double_198 = 6.0 * _Double_23 * _Double_25 + eqsq * (24.0 * _Double_155 * _Double_161 - 6.0 * _Double_159 * _Double_163);
				_Double_191 = _Double_191 + _Double_191 + bsq * _Double_200;
				_Double_195 = _Double_195 + _Double_195 + bsq * _Double_201;
				_Double_199 = _Double_199 + _Double_199 + bsq * _Double_202;
				_Double_104 = _Double_37 * _Double_186;
				_Double_103 = -0.5 * _Double_104 / rteqsq;
				_Double_105 = _Double_104 * rteqsq;
				_Double_102 = -15.0 * _Double_63 * _Double_105;
				_Double_106 = _Double_154 * _Double_158 + _Double_155 * _Double_159;
				_Double_107 = _Double_155 * _Double_158 + _Double_154 * _Double_159;
				_Double_108 = _Double_155 * _Double_159 - _Double_154 * _Double_158;
				_Double_110 = _Double_102 * _Double_215 * _Double_106;
				_Double_126 = _Double_103 * _Double_215 * (_Double_192 + _Double_194);
				_Double_136 = (0.0 - _Double_215) * _Double_104 * (_Double_191 + _Double_199 - 14.0 - 6.0 * eqsq);
				_Double_115 = _Double_105 * _Double_215 * (_Double_200 + _Double_202 - 6.0);
				_Double_121 = (0.0 - _Double_215) * _Double_103 * (_Double_196 + _Double_198);
				if (_Double_190 < 0.052359877)
				{
					_Double_121 = 0.0;
				}
				_Double_61 = 2.0 * _Double_102 * _Double_107;
				_Double_60 = 2.0 * _Double_102 * _Double_108;
				_Double_170 = 2.0 * _Double_103 * _Double_193;
				_Double_171 = 2.0 * _Double_103 * (_Double_194 - _Double_192);
				_Double_173 = -2.0 * _Double_104 * _Double_195;
				_Double_174 = -2.0 * _Double_104 * (_Double_199 - _Double_191);
				_Double_175 = -2.0 * _Double_104 * (-21.0 - 9.0 * eqsq) * _Double_209;
				_Double_165 = 2.0 * _Double_105 * _Double_201;
				_Double_166 = 2.0 * _Double_105 * (_Double_202 - _Double_200);
				_Double_167 = -18.0 * _Double_105 * _Double_209;
				_Double_168 = -2.0 * _Double_103 * _Double_197;
				_Double_169 = -2.0 * _Double_103 * (_Double_198 - _Double_196);
				if (_Int_5 == 30)
				{
					_Double_142 = _Double_110;
					_Double_145 = _Double_126;
					_Double_146 = _Double_136;
					_Double_144 = _Double_121 / siniq;
					_Double_143 = _Double_115 - cosiq * _Double_144;
					_Double_111 = _Double_61;
					_Double_127 = _Double_170;
					_Double_137 = _Double_173;
					_Double_116 = _Double_165;
					_Double_122 = _Double_168;
					_Double_112 = _Double_60;
					_Double_128 = _Double_171;
					_Double_138 = _Double_174;
					_Double_117 = _Double_166;
					_Double_123 = _Double_169;
					_Double_139 = _Double_175;
					_Double_118 = _Double_167;
					_Double_203 = _Double_204;
					_Double_216 = _Double_217;
					_Double_207 = _Double_208;
					_Double_220 = _Double_221;
					_Double_205 = _Double_206 * _Double_40 + _Double_219 * _Double_133;
					_Double_218 = _Double_133 * _Double_206 - _Double_40 * _Double_219;
					_Double_215 = 0.00015835218;
					_Double_37 = 4.7968065E-07;
					_Double_209 = 0.0549;
					_Double_212 = _Double_213;
					_Int_5 = 40;
				}
				_Int_6++;
			}
			_Double_142 += _Double_110;
			_Double_145 += _Double_126;
			_Double_146 += _Double_136;
			_Double_143 = _Double_143 + _Double_115 - cosiq / siniq * _Double_121;
			_Double_144 += _Double_121 / siniq;
			_Int_0 = 0;
			_Int_2 = 0;
			if ((_Double_187 < 0.0052359877) & (_Double_187 > 0.0034906585))
			{
				_Int_0 = 1;
				_Int_2 = 1;
				_Double_82 = 1.0 + eqsq * (-2.5 + 0.8125 * eqsq);
				_Double_86 = 1.0 + 2.0 * eqsq;
				_Double_85 = 1.0 + eqsq * (-6.0 + 6.60937 * eqsq);
				_Double_65 = 0.75 * (1.0 + cosiq) * (1.0 + cosiq);
				_Double_68 = 0.9375 * siniq * siniq * (1.0 + 3.0 * cosiq) - 0.75 * (1.0 + cosiq);
				_Double_71 = 1.0 + cosiq;
				_Double_71 = 1.875 * _Double_71 * _Double_71 * _Double_71;
				_Double_55 = 3.0 * _Double_187 * _Double_187 * _Double_32 * _Double_32;
				_Double_56 = 2.0 * _Double_55 * _Double_65 * _Double_82 * 1.7891679E-06;
				_Double_57 = 3.0 * _Double_55 * _Double_71 * _Double_85 * 2.2123015E-07 * _Double_32;
				_Double_55 = _Double_55 * _Double_68 * _Double_86 * 2.1460748E-06 * _Double_32;
				_Double_78 = 0.13130908;
				_Double_79 = 2.8843198;
				_Double_80 = 0.37448087;
				_Double_176 = _Double_180 + sgp_data_0.xnodeo + sgp_data_0.omegao - _Double_153;
				_Double_35 = xlldot + _Double_189 - 0.0043752691;
				_Double_35 = _Double_35 + _Double_146 + _Double_143 + _Double_144;
			}
			else if (_Double_187 >= 0.00826 && _Double_187 <= 0.00924 && _Double_63 >= 0.5)
			{
				_Int_0 = 1;
				_Double_62 = _Double_63 * eqsq;
				_Double_83 = -0.306 - (_Double_63 - 0.64) * 0.44;
				if (_Double_63 < 0.65)
				{
					_Double_84 = 3.616 - 13.247 * _Double_63 + 16.29 * eqsq;
					_Double_86 = -19.302 + 117.39 * _Double_63 - 228.419 * eqsq + 156.591 * _Double_62;
					_Double_87 = -18.9068 + 109.7927 * _Double_63 - 214.6334 * eqsq + 146.5816 * _Double_62;
					_Double_88 = -41.122 + 242.694 * _Double_63 - 471.094 * eqsq + 313.953 * _Double_62;
					_Double_89 = -146.407 + 841.88 * _Double_63 - 1629.014 * eqsq + 1083.435 * _Double_62;
					_Double_90 = -532.114 + 3017.977 * _Double_63 - 5740.0 * eqsq + 3708.276 * _Double_62;
				}
				else
				{
					_Double_84 = -72.099 + 331.819 * _Double_63 - 508.738 * eqsq + 266.724 * _Double_62;
					_Double_86 = -346.844 + 1582.851 * _Double_63 - 2415.925 * eqsq + 1246.113 * _Double_62;
					_Double_87 = -342.585 + 1554.908 * _Double_63 - 2366.899 * eqsq + 1215.972 * _Double_62;
					_Double_88 = -1052.797 + 4758.686 * _Double_63 - 7193.992 * eqsq + 3651.957 * _Double_62;
					_Double_89 = -3581.69 + 16178.11 * _Double_63 - 24462.77 * eqsq + 12422.52 * _Double_62;
					if (_Double_63 <= 0.715)
					{
						_Double_90 = 1464.74 - 4664.75 * _Double_63 + 3763.64 * eqsq;
					}
					else
					{
						_Double_90 = -5149.66 + 29936.92 * _Double_63 - 54087.36 * eqsq + 31324.56 * _Double_62;
					}
				}
				if (_Double_63 < 0.7)
				{
					_Double_93 = -919.2277 + 4988.61 * _Double_63 - 9064.77 * eqsq + 5542.21 * _Double_62;
					_Double_91 = -822.71072 + 4568.6173 * _Double_63 - 8491.4146 * eqsq + 5337.524 * _Double_62;
					_Double_92 = -853.666 + 4690.25 * _Double_63 - 8624.77 * eqsq + 5341.4 * _Double_62;
				}
				else
				{
					_Double_93 = -37995.78 + 161616.52 * _Double_63 - 229838.2 * eqsq + 109377.94 * _Double_62;
					_Double_91 = -51752.104 + 218913.95 * _Double_63 - 309468.16 * eqsq + 146349.42 * _Double_62;
					_Double_92 = -40023.88 + 170470.89 * _Double_63 - 242699.48 * eqsq + 115605.82 * _Double_62;
				}
				_Double_130 = siniq * siniq;
				_Double_65 = 0.75 * (1.0 + 2.0 * cosiq + cosq2);
				_Double_66 = 1.5 * _Double_130;
				_Double_69 = 1.875 * siniq * (1.0 - 2.0 * cosiq - 3.0 * cosq2);
				_Double_70 = -1.875 * siniq * (1.0 + 2.0 * cosiq - 3.0 * cosq2);
				_Double_72 = 35.0 * _Double_130 * _Double_65;
				_Double_73 = 39.375 * _Double_130 * _Double_130;
				_Double_74 = 9.84375 * siniq * (_Double_130 * (1.0 - 2.0 * cosiq - 5.0 * cosq2) + 0.33333333 * (-2.0 + 4.0 * cosiq + 6.0 * cosq2));
				_Double_75 = siniq * (4.92187512 * _Double_130 * (-2.0 - 4.0 * cosiq + 10.0 * cosq2) + 6.56250012 * (1.0 + 2.0 * cosiq - 3.0 * cosq2));
				_Double_76 = 29.53125 * siniq * (2.0 - 8.0 * cosiq + cosq2 * (-12.0 + 8.0 * cosiq + 10.0 * cosq2));
				_Double_77 = 29.53125 * siniq * (-2.0 - 8.0 * cosiq + cosq2 * (12.0 + 8.0 * cosiq - 10.0 * cosq2));
				_Double_184 = _Double_187 * _Double_187;
				_Double_30 = _Double_32 * _Double_32;
				_Double_152 = 3.0 * _Double_184 * _Double_30;
				_Double_151 = _Double_152 * 1.7891679E-06;
				_Double_42 = _Double_151 * _Double_65 * _Double_83;
				_Double_43 = _Double_151 * _Double_66 * _Double_84;
				_Double_152 *= _Double_32;
				_Double_151 = _Double_152 * 3.7393792E-07;
				_Double_44 = _Double_151 * _Double_69 * _Double_86;
				_Double_45 = _Double_151 * _Double_70 * _Double_87;
				_Double_152 *= _Double_32;
				_Double_151 = 2.0 * _Double_152 * 7.3636953E-09;
				_Double_46 = _Double_151 * _Double_72 * _Double_88;
				_Double_47 = _Double_151 * _Double_73 * _Double_89;
				_Double_152 *= _Double_32;
				_Double_151 = _Double_152 * 1.1428639E-07;
				_Double_48 = _Double_151 * _Double_74 * _Double_90;
				_Double_49 = _Double_151 * _Double_75 * _Double_92;
				_Double_151 = 2.0 * _Double_152 * 2.1765803E-09;
				_Double_50 = _Double_151 * _Double_76 * _Double_91;
				_Double_51 = _Double_151 * _Double_77 * _Double_93;
				_Double_176 = _Double_180 + 2.0 * sgp_data_0.xnodeo - _Double_153 - _Double_153;
				_Double_35 = xlldot + xnodot + xnodot - 0.0043752691 - 0.0043752691;
				_Double_35 = _Double_35 + _Double_146 + _Double_144 + _Double_144;
			}
			_Double_164 = _Double_35 - _Double_187;
			_Double_178 = _Double_176;
			_Double_183 = _Double_187;
			_Double_33 = 0.0;
			_Double_150 = 720.0;
			_Double_149 = -720.0;
			_Double_148 = 259200.0;
			break;
		case 2:
		{
			xll += _Double_146 * t;
			omgasm += _Double_143 * t;
			xnodes += _Double_144 * t;
			em_d = sgp_data_0.eo + _Double_142 * t;
			xinc = sgp_data_0.xincl + _Double_145 * t;
			if (xinc < 0.0)
			{
				xinc = 0.0 - xinc;
				xnodes += 3.14159265358979;
				omgasm -= 3.14159265358979;
			}
			if (_Int_0 == 0)
			{
				break;
			}
			_Int_6 = 0;
			_Int_1 = 0;
			int num = 0;
			do
			{
				if (_Int_1 == 0)
				{
					if (_Double_33 == 0.0)
					{
						if (t < 0.0)
						{
							_Double_58 = _Double_149;
						}
						else
						{
							_Double_58 = _Double_150;
						}
						_Double_33 = 0.0;
						_Double_183 = _Double_187;
						_Double_178 = _Double_176;
						_Int_1 = 1;
					}
					else if (Math.Abs(t) < Math.Abs(_Double_33))
					{
						_Double_58 = _Double_150;
						if (t >= 0.0)
						{
							_Double_58 = _Double_149;
						}
						_Int_3 = 100;
						_Int_1 = 0;
					}
					else
					{
						_Double_58 = _Double_149;
						if (t > 0.0)
						{
							_Double_58 = _Double_150;
						}
						_Int_1 = 1;
					}
				}
				if (_Int_1 == 1)
				{
					if (Math.Abs(t - _Double_33) <= _Double_150)
					{
						_Double_81 = t - _Double_33;
						_Int_4 = 140;
						_Int_1 = 1;
					}
					else
					{
						_Int_3 = 125;
						_Int_1 = 0;
					}
				}
				if (_Int_1 == 0)
				{
					_Int_4 = 165;
				}
				_Int_1 = 0;
				if (_Int_2 == 0)
				{
					_Double_188 = _Double_95 + omgdt * _Double_33;
					_Double_157 = _Double_188 + _Double_188;
					_Double_156 = _Double_178 + _Double_178;
					_Double_182 = _Double_42 * Math.Sin(_Double_157 + _Double_178 - 5.7686396) + _Double_43 * Math.Sin(_Double_178 - 5.7686396) + _Double_44 * Math.Sin(_Double_188 + _Double_178 - 0.95240898) + _Double_45 * Math.Sin(0.0 - _Double_188 + _Double_178 - 0.95240898) + _Double_46 * Math.Sin(_Double_157 + _Double_156 - 1.8014998) + _Double_47 * Math.Sin(_Double_156 - 1.8014998) + _Double_48 * Math.Sin(_Double_188 + _Double_178 - 1.050833) + _Double_49 * Math.Sin(0.0 - _Double_188 + _Double_178 - 1.050833) + _Double_50 * Math.Sin(_Double_188 + _Double_156 - 4.4108898) + _Double_51 * Math.Sin(0.0 - _Double_188 + _Double_156 - 4.4108898);
					_Double_181 = _Double_42 * Math.Cos(_Double_157 + _Double_178 - 5.7686396) + _Double_43 * Math.Cos(_Double_178 - 5.7686396) + _Double_44 * Math.Cos(_Double_188 + _Double_178 - 0.95240898) + _Double_45 * Math.Cos(0.0 - _Double_188 + _Double_178 - 0.95240898) + _Double_48 * Math.Cos(_Double_188 + _Double_178 - 1.050833) + _Double_49 * Math.Cos(0.0 - _Double_188 + _Double_178 - 1.050833) + 2.0 * (_Double_46 * Math.Cos(_Double_157 + _Double_156 - 1.8014998) + _Double_47 * Math.Cos(_Double_156 - 1.8014998) + _Double_50 * Math.Cos(_Double_188 + _Double_156 - 4.4108898) + _Double_51 * Math.Cos(0.0 - _Double_188 + _Double_156 - 4.4108898));
				}
				else
				{
					_Double_182 = _Double_55 * Math.Sin(_Double_178 - _Double_78) + _Double_56 * Math.Sin(2.0 * (_Double_178 - _Double_79)) + _Double_57 * Math.Sin(3.0 * (_Double_178 - _Double_80));
					_Double_181 = _Double_55 * Math.Cos(_Double_178 - _Double_78) + 2.0 * _Double_56 * Math.Cos(2.0 * (_Double_178 - _Double_79)) + 3.0 * _Double_57 * Math.Cos(3.0 * (_Double_178 - _Double_80));
				}
				_Double_177 = _Double_183 + _Double_164;
				_Double_181 *= _Double_177;
				switch (_Int_4)
				{
				case 165:
					_Int_1 = 0;
					break;
				case 140:
					xn = _Double_183 + _Double_182 * _Double_81 + _Double_181 * _Double_81 * _Double_81 * 0.5;
					_Double_172 = _Double_178 + _Double_177 * _Double_81 + _Double_182 * _Double_81 * _Double_81 * 0.5;
					_Double_151 = 0.0 - xnodes + _Double_153 + t * 0.0043752691;
					xll = _Double_172 - omgasm + _Double_151;
					if (_Int_2 == 0)
					{
						xll = _Double_172 + _Double_151 + _Double_151;
					}
					_Int_1 = 1;
					_Int_6 = 1;
					break;
				}
				if (_Int_1 == 0)
				{
					_Double_178 = _Double_178 + _Double_177 * _Double_58 + _Double_182 * _Double_148;
					_Double_183 = _Double_183 + _Double_182 * _Double_58 + _Double_181 * _Double_148;
					_Double_33 += _Double_58;
					switch (_Int_3)
					{
					case 125:
						_Int_1 = 1;
						break;
					case 100:
						_Int_1 = 0;
						break;
					}
				}
				num++;
			}
			while (_Int_6 != 0 && num < 150);
			break;
		}
		case 3:
			_Double_131 = Math.Sin(xinc);
			_Double_38 = Math.Cos(xinc);
			if (Math.Abs(_Double_109 - t) > 30.0)
			{
				_Double_109 = t;
				_Double_211 = _Double_214 + 1.19459E-05 * t;
				_Double_210 = _Double_211 + 0.0335 * Math.Sin(_Double_211);
				_Double_134 = Math.Sin(_Double_210);
				_Double_64 = 0.5 * _Double_134 * _Double_134 - 0.25;
				_Double_67 = -0.5 * _Double_134 * Math.Cos(_Double_210);
				_Double_114 = _Double_111 * _Double_64 + _Double_112 * _Double_67;
				_Double_135 = _Double_127 * _Double_64 + _Double_128 * _Double_67;
				_Double_141 = _Double_137 * _Double_64 + _Double_138 * _Double_67 + _Double_139 * _Double_134;
				_Double_120 = _Double_116 * _Double_64 + _Double_117 * _Double_67 + _Double_118 * _Double_134;
				_Double_125 = _Double_122 * _Double_64 + _Double_123 * _Double_67;
				_Double_211 = _Double_213 + 0.00015835218 * t;
				_Double_210 = _Double_211 + 0.1098 * Math.Sin(_Double_211);
				_Double_134 = Math.Sin(_Double_210);
				_Double_64 = 0.5 * _Double_134 * _Double_134 - 0.25;
				_Double_67 = -0.5 * _Double_134 * Math.Cos(_Double_210);
				_Double_113 = _Double_61 * _Double_64 + _Double_60 * _Double_67;
				_Double_129 = _Double_170 * _Double_64 + _Double_171 * _Double_67;
				_Double_140 = _Double_173 * _Double_64 + _Double_174 * _Double_67 + _Double_175 * _Double_134;
				_Double_119 = _Double_165 * _Double_64 + _Double_166 * _Double_67 + _Double_167 * _Double_134;
				_Double_124 = _Double_168 * _Double_64 + _Double_169 * _Double_67;
				_Double_96 = _Double_114 + _Double_113;
				_Double_99 = _Double_135 + _Double_129;
				_Double_100 = _Double_141 + _Double_140;
			}
			_Double_97 = _Double_120 + _Double_119;
			_Double_98 = _Double_125 + _Double_124;
			xinc += _Double_99;
			em_d += _Double_96;
			if (_Double_190 <= 0.2)
			{
				_Double_132 = Math.Sin(xnodes);
				_Double_39 = Math.Cos(xnodes);
				_Double_31 = _Double_131 * _Double_132;
				_Double_34 = _Double_131 * _Double_39;
				_Double_52 = _Double_98 * _Double_39 + _Double_99 * _Double_38 * _Double_132;
				_Double_54 = (0.0 - _Double_98) * _Double_132 + _Double_99 * _Double_38 * _Double_39;
				_Double_31 += _Double_52;
				_Double_34 += _Double_54;
				_Double_179 = xll + omgasm + _Double_38 * xnodes;
				_Double_59 = _Double_100 + _Double_97 - _Double_99 * xnodes * _Double_131;
				_Double_179 += _Double_59;
				xnodes = SxPxMath.MoveWatcher(ref _Double_31, ref _Double_34);
				xll += _Double_100;
				omgasm = _Double_179 - xll - Math.Cos(xinc) * xnodes;
			}
			else
			{
				_Double_98 /= siniq;
				_Double_97 -= cosiq * _Double_98;
				omgasm += _Double_97;
				xnodes += _Double_98;
				xll += _Double_100;
			}
			break;
		}
	}
}
