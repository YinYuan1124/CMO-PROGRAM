using System;
using System.ComponentModel;
using OpenDis.Core;

namespace OpenDis.Enumerations;

[Serializable]
public enum Country : ushort
{
	[Description("Other")]
	[InternetDomainCode("Unknown")]
	Other = 0,
	[Description("Afghanistan")]
	[InternetDomainCode("AF")]
	Afghanistan = 1,
	[InternetDomainCode("AL")]
	[Description("Albania")]
	Albania = 2,
	[Description("Algeria")]
	[InternetDomainCode("DZ")]
	Algeria = 3,
	[Description("American Samoa (United States)")]
	[InternetDomainCode("Unknown")]
	AmericanSamoaUnitedStates = 4,
	[InternetDomainCode("AD")]
	[Description("Andorra")]
	Andorra = 5,
	[Description("Angola")]
	[InternetDomainCode("AO")]
	Angola = 6,
	[InternetDomainCode("AI")]
	[Description("Anguilla")]
	Anguilla = 7,
	[InternetDomainCode("Unknown")]
	[Description("Antarctica (International)")]
	AntarcticaInternational = 8,
	[InternetDomainCode("AG")]
	[Description("Antigua and Barbuda")]
	AntiguaAndBarbuda = 9,
	[Description("Argentina")]
	[InternetDomainCode("AR")]
	Argentina = 10,
	[InternetDomainCode("AM")]
	[Description("Armenia")]
	Armenia = 244,
	[InternetDomainCode("AW")]
	[Description("Aruba")]
	Aruba = 11,
	[InternetDomainCode("Unknown")]
	[Description("Ashmore and Cartier Islands (Australia)")]
	AshmoreAndCartierIslandsAustralia = 12,
	[InternetDomainCode("AU")]
	[Description("Australia")]
	Australia = 13,
	[InternetDomainCode("AT")]
	[Description("Austria")]
	Austria = 14,
	[InternetDomainCode("AZ")]
	[Description("Azerbaijan")]
	Azerbaijan = 245,
	[InternetDomainCode("BS")]
	[Description("Bahamas")]
	Bahamas = 15,
	[InternetDomainCode("BH")]
	[Description("Bahrain")]
	Bahrain = 16,
	[Description("Baker Island (United States)")]
	[InternetDomainCode("Unknown")]
	BakerIslandUnitedStates = 17,
	[InternetDomainCode("BD")]
	[Description("Bangladesh")]
	Bangladesh = 18,
	[InternetDomainCode("BB")]
	[Description("Barbados")]
	Barbados = 19,
	[InternetDomainCode("Unknown")]
	[Description("Bassas da India (France)")]
	BassasDaIndiaFrance = 20,
	[InternetDomainCode("BY")]
	[Description("Belarus")]
	Belarus = 246,
	[InternetDomainCode("BE")]
	[Description("Belgium")]
	Belgium = 21,
	[Description("Belize")]
	[InternetDomainCode("BZ")]
	Belize = 22,
	[InternetDomainCode("Unknown")]
	[Description("Benin (aka Dahomey)")]
	BeninAkaDahomey = 23,
	[InternetDomainCode("Unknown")]
	[Description("Bermuda (United Kingdom)")]
	BermudaUnitedKingdom = 24,
	[Description("Bhutan")]
	[InternetDomainCode("BT")]
	Bhutan = 25,
	[InternetDomainCode("BO")]
	[Description("Bolivia")]
	Bolivia = 26,
	[InternetDomainCode("Unknown")]
	[Description("Bosnia and Hercegovina")]
	BosniaAndHercegovina = 247,
	[InternetDomainCode("BW")]
	[Description("Botswana")]
	Botswana = 27,
	[Description("Bouvet Island (Norway)")]
	[InternetDomainCode("Unknown")]
	BouvetIslandNorway = 28,
	[InternetDomainCode("BR")]
	[Description("Brazil")]
	Brazil = 29,
	[Description("British Indian Ocean Territory (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	BritishIndianOceanTerritoryUnitedKingdom = 30,
	[InternetDomainCode("Unknown")]
	[Description("British Virgin Islands (United Kingdom)")]
	BritishVirginIslandsUnitedKingdom = 31,
	[Description("Brunei")]
	[InternetDomainCode("Unknown")]
	Brunei = 32,
	[InternetDomainCode("BG")]
	[Description("Bulgaria")]
	Bulgaria = 33,
	[InternetDomainCode("Unknown")]
	[Description("Burkina (aka Burkina Faso or Upper Volta)")]
	BurkinaAkaBurkinaFasoOrUpperVolta = 34,
	[InternetDomainCode("Unknown")]
	[Description("Burma (Myanmar)")]
	BurmaMyanmar = 35,
	[InternetDomainCode("BI")]
	[Description("Burundi")]
	Burundi = 36,
	[InternetDomainCode("Unknown")]
	[Description("Cambodia (aka Kampuchea)")]
	CambodiaAkaKampuchea = 37,
	[InternetDomainCode("CM")]
	[Description("Cameroon")]
	Cameroon = 38,
	[InternetDomainCode("CA")]
	[Description("Canada")]
	Canada = 39,
	[Description("Cape Verde, Republic of")]
	[InternetDomainCode("Unknown")]
	CapeVerdeRepublicOf = 40,
	[Description("Cayman Islands (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	CaymanIslandsUnitedKingdom = 41,
	[InternetDomainCode("CF")]
	[Description("Central African Republic")]
	CentralAfricanRepublic = 42,
	[InternetDomainCode("TD")]
	[Description("Chad")]
	Chad = 43,
	[Description("Chile")]
	[InternetDomainCode("CL")]
	Chile = 44,
	[Description("China, People's Republic of")]
	[InternetDomainCode("Unknown")]
	ChinaPeopleSRepublicOf = 45,
	[InternetDomainCode("Unknown")]
	[Description("Christmas Island (Australia)")]
	ChristmasIslandAustralia = 46,
	[Description("Clipperton Island (France)")]
	[InternetDomainCode("Unknown")]
	ClippertonIslandFrance = 248,
	[Description("Cocos (Keeling) Islands (Australia)")]
	[InternetDomainCode("Unknown")]
	CocosKeelingIslandsAustralia = 47,
	[InternetDomainCode("CO")]
	[Description("Colombia")]
	Colombia = 48,
	[InternetDomainCode("Unknown")]
	[Description("Commonwealth of Independent States")]
	CommonwealthOfIndependentStates = 222,
	[InternetDomainCode("KM")]
	[Description("Comoros")]
	Comoros = 49,
	[InternetDomainCode("Unknown")]
	[Description("Congo, Republic of")]
	CongoRepublicOf = 50,
	[InternetDomainCode("Unknown")]
	[Description("Cook Islands (New Zealand)")]
	CookIslandsNewZealand = 51,
	[Description("Coral Sea Islands (Australia)")]
	[InternetDomainCode("Unknown")]
	CoralSeaIslandsAustralia = 52,
	[Description("Costa Rica")]
	[InternetDomainCode("CR")]
	CostaRica = 53,
	[Description("(Cote D'Ivoire (aka Ivory Coast)")]
	[InternetDomainCode("Unknown")]
	CoteDIvoireAkaIvoryCoast = 107,
	[Description("Croatia")]
	[InternetDomainCode("Unknown")]
	Croatia = 249,
	[InternetDomainCode("CU")]
	[Description("Cuba")]
	Cuba = 54,
	[InternetDomainCode("CY")]
	[Description("Cyprus")]
	Cyprus = 55,
	[InternetDomainCode("Unknown")]
	[Description("Czechoslovakia (separating into Czech Republic and Slovak Republic)")]
	CzechoslovakiaSeparatingIntoCzechRepublicAndSlovakRepublic = 56,
	[Description("Dahomey (aka Benin)")]
	[InternetDomainCode("Unknown")]
	DahomeyAkaBenin = 23,
	[InternetDomainCode("DK")]
	[Description("Denmark")]
	Denmark = 57,
	[InternetDomainCode("DJ")]
	[Description("Djibouti")]
	Djibouti = 58,
	[Description("Dominica")]
	[InternetDomainCode("DM")]
	Dominica = 59,
	[InternetDomainCode("DO")]
	[Description("Dominican Republic")]
	DominicanRepublic = 60,
	[Description("Ecuador")]
	[InternetDomainCode("EC")]
	Ecuador = 61,
	[Description("Egypt")]
	[InternetDomainCode("EG")]
	Egypt = 62,
	[Description("El Salvador")]
	[InternetDomainCode("SV")]
	ElSalvador = 63,
	[Description("Equatorial Guinea")]
	[InternetDomainCode("GQ")]
	EquatorialGuinea = 64,
	[InternetDomainCode("EE")]
	[Description("Estonia")]
	Estonia = 250,
	[Description("Ethiopia")]
	[InternetDomainCode("ET")]
	Ethiopia = 65,
	[InternetDomainCode("Unknown")]
	[Description("Europa Island (France)")]
	EuropaIslandFrance = 66,
	[Description("Falkland Islands (aka Islas Malvinas) (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	FalklandIslandsAkaIslasMalvinasUnitedKingdom = 67,
	[Description("Faroe Islands (Denmark)")]
	[InternetDomainCode("Unknown")]
	FaroeIslandsDenmark = 68,
	[InternetDomainCode("FJ")]
	[Description("Fiji")]
	Fiji = 69,
	[InternetDomainCode("FI")]
	[Description("Finland")]
	Finland = 70,
	[Description("France")]
	[InternetDomainCode("FR")]
	France = 71,
	[InternetDomainCode("Unknown")]
	[Description("French Guiana (France)")]
	FrenchGuianaFrance = 72,
	[Description("French Polynesia (France)")]
	[InternetDomainCode("Unknown")]
	FrenchPolynesiaFrance = 73,
	[Description("French Southern and Antarctic Islands (France)")]
	[InternetDomainCode("Unknown")]
	FrenchSouthernAndAntarcticIslandsFrance = 74,
	[Description("Gabon")]
	[InternetDomainCode("GA")]
	Gabon = 75,
	[InternetDomainCode("Unknown")]
	[Description("Gambia, The")]
	GambiaThe = 76,
	[InternetDomainCode("Unknown")]
	[Description("Gaza Strip (Israel)")]
	GazaStripIsrael = 77,
	[InternetDomainCode("GE")]
	[Description("Georgia")]
	Georgia = 251,
	[Description("Germany")]
	[InternetDomainCode("DE")]
	Germany = 78,
	[InternetDomainCode("GH")]
	[Description("Ghana")]
	Ghana = 79,
	[InternetDomainCode("Unknown")]
	[Description("Gibraltar (United Kingdom)")]
	GibraltarUnitedKingdom = 80,
	[Description("Glorioso Islands (France)")]
	[InternetDomainCode("Unknown")]
	GloriosoIslandsFrance = 81,
	[InternetDomainCode("GR")]
	[Description("Greece")]
	Greece = 82,
	[InternetDomainCode("Unknown")]
	[Description("Greenland (Denmark)")]
	GreenlandDenmark = 83,
	[InternetDomainCode("GD")]
	[Description("Grenada")]
	Grenada = 84,
	[Description("Guadaloupe (France)")]
	[InternetDomainCode("Unknown")]
	GuadaloupeFrance = 85,
	[Description("Guam (United States)")]
	[InternetDomainCode("Unknown")]
	GuamUnitedStates = 86,
	[Description("Guatemala")]
	[InternetDomainCode("GT")]
	Guatemala = 87,
	[Description("Guernsey (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	GuernseyUnitedKingdom = 88,
	[Description("Guinea")]
	[InternetDomainCode("GN")]
	Guinea = 89,
	[InternetDomainCode("Unknown")]
	[Description("Guinea- Bissau")]
	GuineaBissau = 90,
	[Description("Guyana")]
	[InternetDomainCode("GY")]
	Guyana = 91,
	[Description("Haiti")]
	[InternetDomainCode("HT")]
	Haiti = 92,
	[InternetDomainCode("Unknown")]
	[Description("Heard Island and McDonald Islands (Australia)")]
	HeardIslandAndMcDonaldIslandsAustralia = 93,
	[InternetDomainCode("HN")]
	[Description("Honduras")]
	Honduras = 94,
	[Description("Hong Kong (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	HongKongUnitedKingdom = 95,
	[Description("Howland Island (United States)")]
	[InternetDomainCode("Unknown")]
	HowlandIslandUnitedStates = 96,
	[Description("Hungary")]
	[InternetDomainCode("HU")]
	Hungary = 97,
	[InternetDomainCode("IS")]
	[Description("Iceland")]
	Iceland = 98,
	[InternetDomainCode("IN")]
	[Description("India")]
	India = 99,
	[Description("Indonesia")]
	[InternetDomainCode("ID")]
	Indonesia = 100,
	[Description("Iran")]
	[InternetDomainCode("IR")]
	Iran = 101,
	[Description("Iraq")]
	[InternetDomainCode("IQ")]
	Iraq = 102,
	[Description("Ireland")]
	[InternetDomainCode("IE")]
	Ireland = 104,
	[InternetDomainCode("IL")]
	[Description("Israel")]
	Israel = 105,
	[InternetDomainCode("IT")]
	[Description("Italy")]
	Italy = 106,
	[Description("Ivory Coast (aka Cote D'Ivoire)")]
	[InternetDomainCode("Unknown")]
	IvoryCoastAkaCoteDIvoire = 107,
	[Description("Jamaica")]
	[InternetDomainCode("JM")]
	Jamaica = 108,
	[InternetDomainCode("Unknown")]
	[Description("Jan Mayen (Norway)")]
	JanMayenNorway = 109,
	[Description("Japan")]
	[InternetDomainCode("JP")]
	Japan = 110,
	[Description("Jarvis Island (United States)")]
	[InternetDomainCode("Unknown")]
	JarvisIslandUnitedStates = 111,
	[Description("Jersey (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	JerseyUnitedKingdom = 112,
	[InternetDomainCode("Unknown")]
	[Description("Johnston Atoll (United States)")]
	JohnstonAtollUnitedStates = 113,
	[Description("Jordan")]
	[InternetDomainCode("JO")]
	Jordan = 114,
	[Description("Juan de Nova Island")]
	[InternetDomainCode("Unknown")]
	JuanDeNovaIsland = 115,
	[Description("Kazakhstan")]
	[InternetDomainCode("KZ")]
	Kazakhstan = 252,
	[InternetDomainCode("KE")]
	[Description("Kenya")]
	Kenya = 116,
	[Description("Kingman Reef (United States)")]
	[InternetDomainCode("Unknown")]
	KingmanReefUnitedStates = 117,
	[Description("Kiribati")]
	[InternetDomainCode("KI")]
	Kiribati = 118,
	[Description("Korea, Democratic People's Republic of (North)")]
	[InternetDomainCode("Unknown")]
	KoreaDemocraticPeopleSRepublicOfNorth = 119,
	[Description("Korea, Republic of (South)")]
	[InternetDomainCode("Unknown")]
	KoreaRepublicOfSouth = 120,
	[InternetDomainCode("KW")]
	[Description("Kuwait")]
	Kuwait = 121,
	[InternetDomainCode("KG")]
	[Description("Kyrgyzstan")]
	Kyrgyzstan = 253,
	[InternetDomainCode("LA")]
	[Description("Laos")]
	Laos = 122,
	[Description("Latvia")]
	[InternetDomainCode("LV")]
	Latvia = 254,
	[Description("Lebanon")]
	[InternetDomainCode("LB")]
	Lebanon = 123,
	[Description("Lesotho")]
	[InternetDomainCode("LS")]
	Lesotho = 124,
	[Description("Liberia")]
	[InternetDomainCode("LR")]
	Liberia = 125,
	[InternetDomainCode("LY")]
	[Description("Libya")]
	Libya = 126,
	[Description("Liechtenstein")]
	[InternetDomainCode("LI")]
	Liechtenstein = 127,
	[Description("Lithuania")]
	[InternetDomainCode("LT")]
	Lithuania = 255,
	[Description("Luxembourg")]
	[InternetDomainCode("LU")]
	Luxembourg = 128,
	[InternetDomainCode("Unknown")]
	[Description("Macau (Portugal)")]
	MacauPortugal = 130,
	[Description("Macedonia")]
	[InternetDomainCode("MK")]
	Macedonia = 256,
	[Description("Madagascar")]
	[InternetDomainCode("MG")]
	Madagascar = 129,
	[InternetDomainCode("MW")]
	[Description("Malawi")]
	Malawi = 131,
	[InternetDomainCode("MY")]
	[Description("Malaysia")]
	Malaysia = 132,
	[Description("Maldives")]
	[InternetDomainCode("MV")]
	Maldives = 133,
	[Description("Mali")]
	[InternetDomainCode("ML")]
	Mali = 134,
	[Description("Malta")]
	[InternetDomainCode("MT")]
	Malta = 135,
	[Description("Man, Isle of (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	ManIsleOfUnitedKingdom = 136,
	[Description("Marshall Islands")]
	[InternetDomainCode("MH")]
	MarshallIslands = 137,
	[InternetDomainCode("Unknown")]
	[Description("Martinique (France)")]
	MartiniqueFrance = 138,
	[InternetDomainCode("MR")]
	[Description("Mauritania")]
	Mauritania = 139,
	[Description("Mauritius")]
	[InternetDomainCode("MU")]
	Mauritius = 140,
	[InternetDomainCode("Unknown")]
	[Description("Mayotte (France)")]
	MayotteFrance = 141,
	[Description("Mexico")]
	[InternetDomainCode("MX")]
	Mexico = 142,
	[InternetDomainCode("Unknown")]
	[Description("Micronesia, Federative States of")]
	MicronesiaFederativeStatesOf = 143,
	[Description("Midway Islands (United States)")]
	[InternetDomainCode("Unknown")]
	MidwayIslandsUnitedStates = 257,
	[Description("Moldova")]
	[InternetDomainCode("MD")]
	Moldova = 258,
	[InternetDomainCode("MC")]
	[Description("Monaco")]
	Monaco = 144,
	[InternetDomainCode("MN")]
	[Description("Mongolia")]
	Mongolia = 145,
	[InternetDomainCode("Unknown")]
	[Description("Montenegro")]
	Montenegro = 259,
	[InternetDomainCode("Unknown")]
	[Description("Montserrat (United Kingdom)")]
	MontserratUnitedKingdom = 146,
	[InternetDomainCode("MA")]
	[Description("Morocco")]
	Morocco = 147,
	[InternetDomainCode("MZ")]
	[Description("Mozambique")]
	Mozambique = 148,
	[Description("Myanmar (aka Burma)")]
	[InternetDomainCode("Unknown")]
	MyanmarAkaBurma = 35,
	[Description("Namibia (South West Africa)")]
	[InternetDomainCode("Unknown")]
	NamibiaSouthWestAfrica = 149,
	[InternetDomainCode("NR")]
	[Description("Nauru")]
	Nauru = 150,
	[Description("Navassa Island (United States)")]
	[InternetDomainCode("Unknown")]
	NavassaIslandUnitedStates = 151,
	[InternetDomainCode("NP")]
	[Description("Nepal")]
	Nepal = 152,
	[InternetDomainCode("NL")]
	[Description("Netherlands")]
	Netherlands = 153,
	[InternetDomainCode("Unknown")]
	[Description("Netherlands Antilles (Curacao, Bonaire, Saba, Sint Maarten Sint Eustatius)")]
	NetherlandsAntillesCuracaoBonaireSabaSintMaartenSintEustatius = 154,
	[InternetDomainCode("Unknown")]
	[Description("New Caledonia (France)")]
	NewCaledoniaFrance = 155,
	[Description("New Zealand")]
	[InternetDomainCode("Unknown")]
	NewZealand = 156,
	[InternetDomainCode("NI")]
	[Description("Nicaragua")]
	Nicaragua = 157,
	[Description("Niger")]
	[InternetDomainCode("NE")]
	Niger = 158,
	[InternetDomainCode("NG")]
	[Description("Nigeria")]
	Nigeria = 159,
	[InternetDomainCode("Unknown")]
	[Description("Niue (New Zealand)")]
	NiueNewZealand = 160,
	[Description("Norfolk Island (Australia)")]
	[InternetDomainCode("Unknown")]
	NorfolkIslandAustralia = 161,
	[Description("Northern Mariana Islands (United States)")]
	[InternetDomainCode("Unknown")]
	NorthernMarianaIslandsUnitedStates = 162,
	[InternetDomainCode("NO")]
	[Description("Norway")]
	Norway = 163,
	[InternetDomainCode("OM")]
	[Description("Oman")]
	Oman = 164,
	[Description("Pacific Islands, Trust Territory of the (Palau)")]
	[InternetDomainCode("Unknown")]
	PacificIslandsTrustTerritoryOfThePalau = 216,
	[InternetDomainCode("PK")]
	[Description("Pakistan")]
	Pakistan = 165,
	[InternetDomainCode("Unknown")]
	[Description("Palmyra Atoll (United States)")]
	PalmyraAtollUnitedStates = 166,
	[Description("Panama")]
	[InternetDomainCode("PA")]
	Panama = 168,
	[InternetDomainCode("PG")]
	[Description("Papua New Guinea")]
	PapuaNewGuinea = 169,
	[InternetDomainCode("Unknown")]
	[Description("Paracel Islands (International - Occupied by China, also claimed by Taiwan and Vietnam)")]
	ParacelIslandsInternationalOccupiedByChinaAlsoClaimedByTaiwanAndVietnam = 170,
	[Description("Paraguay")]
	[InternetDomainCode("PY")]
	Paraguay = 171,
	[InternetDomainCode("PE")]
	[Description("Peru")]
	Peru = 172,
	[InternetDomainCode("PH")]
	[Description("Philippines")]
	Philippines = 173,
	[InternetDomainCode("Unknown")]
	[Description("Pitcairn Islands (United Kingdom)")]
	PitcairnIslandsUnitedKingdom = 174,
	[Description("Poland")]
	[InternetDomainCode("PL")]
	Poland = 175,
	[Description("Portugal")]
	[InternetDomainCode("PT")]
	Portugal = 176,
	[InternetDomainCode("Unknown")]
	[Description("Puerto Rico (United States)")]
	PuertoRicoUnitedStates = 177,
	[Description("Qatar")]
	[InternetDomainCode("QA")]
	Qatar = 178,
	[Description("Reunion (France)")]
	[InternetDomainCode("Unknown")]
	ReunionFrance = 179,
	[InternetDomainCode("RO")]
	[Description("Romania")]
	Romania = 180,
	[InternetDomainCode("Unknown")]
	[Description("Russia")]
	Russia = 260,
	[Description("Rwanda")]
	[InternetDomainCode("RW")]
	Rwanda = 181,
	[Description("St. Helena (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	StHelenaUnitedKingdom = 183,
	[Description("St. Lucia")]
	[InternetDomainCode("Unknown")]
	StLucia = 184,
	[Description("St. Vincent and the Grenadines")]
	[InternetDomainCode("Unknown")]
	StVincentAndTheGrenadines = 186,
	[InternetDomainCode("Unknown")]
	[Description("St. Kitts and Nevis")]
	StKittsAndNevis = 182,
	[Description("St. Pierre and Miquelon (France)")]
	[InternetDomainCode("Unknown")]
	StPierreAndMiquelonFrance = 185,
	[InternetDomainCode("SM")]
	[Description("San Marino")]
	SanMarino = 187,
	[InternetDomainCode("ST")]
	[Description("Sao Tome and Principe")]
	SaoTomeAndPrincipe = 188,
	[InternetDomainCode("SA")]
	[Description("Saudi Arabia")]
	SaudiArabia = 189,
	[Description("Senegal")]
	[InternetDomainCode("SN")]
	Senegal = 190,
	[Description("Serbia and Montenegro (Montenegro to separate)")]
	[InternetDomainCode("Unknown")]
	SerbiaAndMontenegroMontenegroToSeparate = 261,
	[Description("Seychelles")]
	[InternetDomainCode("SC")]
	Seychelles = 191,
	[Description("Sierra Leone")]
	[InternetDomainCode("SL")]
	SierraLeone = 192,
	[InternetDomainCode("SG")]
	[Description("Singapore")]
	Singapore = 193,
	[InternetDomainCode("SI")]
	[Description("Slovenia")]
	Slovenia = 262,
	[InternetDomainCode("SB")]
	[Description("Solomon Islands")]
	SolomonIslands = 194,
	[Description("Somalia")]
	[InternetDomainCode("SO")]
	Somalia = 195,
	[InternetDomainCode("ZA")]
	[Description("South Africa")]
	SouthAfrica = 197,
	[InternetDomainCode("Unknown")]
	[Description("South Georgia and the South Sandwich Islands (United Kingdom)")]
	SouthGeorgiaAndTheSouthSandwichIslandsUnitedKingdom = 196,
	[InternetDomainCode("ES")]
	[Description("Spain")]
	Spain = 198,
	[Description("Spratly Islands (International - parts occupied and claimed by China,Malaysia, Philippines, Taiwan, Vietnam)")]
	[InternetDomainCode("Unknown")]
	SpratlyIslandsInternationalPartsOccupiedAndClaimedByChinaMalaysiaPhilippinesTaiwanVietnam = 199,
	[InternetDomainCode("LK")]
	[Description("Sri Lanka")]
	SriLanka = 200,
	[InternetDomainCode("SD")]
	[Description("Sudan")]
	Sudan = 201,
	[InternetDomainCode("SR")]
	[Description("Suriname")]
	Suriname = 202,
	[InternetDomainCode("Unknown")]
	[Description("Svalbard (Norway)")]
	SvalbardNorway = 203,
	[InternetDomainCode("SZ")]
	[Description("Swaziland")]
	Swaziland = 204,
	[InternetDomainCode("SE")]
	[Description("Sweden")]
	Sweden = 205,
	[InternetDomainCode("CH")]
	[Description("Switzerland")]
	Switzerland = 206,
	[InternetDomainCode("SY")]
	[Description("Syria")]
	Syria = 207,
	[Description("Taiwan")]
	[InternetDomainCode("TW")]
	Taiwan = 208,
	[Description("Tajikistan")]
	[InternetDomainCode("TJ")]
	Tajikistan = 263,
	[InternetDomainCode("TZ")]
	[Description("Tanzania")]
	Tanzania = 209,
	[Description("Thailand")]
	[InternetDomainCode("TH")]
	Thailand = 210,
	[Description("Togo")]
	[InternetDomainCode("TG")]
	Togo = 211,
	[InternetDomainCode("Unknown")]
	[Description("Tokelau (New Zealand)")]
	TokelauNewZealand = 212,
	[InternetDomainCode("TO")]
	[Description("Tonga")]
	Tonga = 213,
	[Description("Trinidad and Tobago")]
	[InternetDomainCode("TT")]
	TrinidadAndTobago = 214,
	[Description("Tromelin Island (France)")]
	[InternetDomainCode("Unknown")]
	TromelinIslandFrance = 215,
	[Description("Tunisia")]
	[InternetDomainCode("TN")]
	Tunisia = 217,
	[Description("Turkey")]
	[InternetDomainCode("TR")]
	Turkey = 218,
	[Description("Turkmenistan")]
	[InternetDomainCode("TM")]
	Turkmenistan = 264,
	[InternetDomainCode("Unknown")]
	[Description("Turks and Caicos Islands (United Kingdom)")]
	TurksAndCaicosIslandsUnitedKingdom = 219,
	[Description("Tuvalu")]
	[InternetDomainCode("TV")]
	Tuvalu = 220,
	[InternetDomainCode("UG")]
	[Description("Uganda")]
	Uganda = 221,
	[InternetDomainCode("UA")]
	[Description("Ukraine")]
	Ukraine = 265,
	[InternetDomainCode("AE")]
	[Description("United Arab Emirates")]
	UnitedArabEmirates = 223,
	[InternetDomainCode("UK")]
	[Description("United Kingdom")]
	UnitedKingdom = 224,
	[Description("United States")]
	[InternetDomainCode("US")]
	UnitedStates = 225,
	[InternetDomainCode("Unknown")]
	[Description("Upper Volta (aka Burkina or Burkina Faso)")]
	UpperVoltaAkaBurkinaOrBurkinaFaso = 34,
	[InternetDomainCode("UY")]
	[Description("Uruguay")]
	Uruguay = 226,
	[InternetDomainCode("UZ")]
	[Description("Uzbekistan")]
	Uzbekistan = 266,
	[Description("Vanuatu")]
	[InternetDomainCode("VU")]
	Vanuatu = 227,
	[Description("Vatican City (Holy See)")]
	[InternetDomainCode("Unknown")]
	VaticanCityHolySee = 228,
	[InternetDomainCode("VE")]
	[Description("Venezuela")]
	Venezuela = 229,
	[InternetDomainCode("Unknown")]
	[Description("Vietnam")]
	Vietnam = 230,
	[Description("Virgin Islands (United States)")]
	[InternetDomainCode("Unknown")]
	VirginIslandsUnitedStates = 231,
	[InternetDomainCode("Unknown")]
	[Description("Wake Island (United States)")]
	WakeIslandUnitedStates = 232,
	[Description("Wallis and Futuna (France)")]
	[InternetDomainCode("Unknown")]
	WallisAndFutunaFrance = 233,
	[InternetDomainCode("Unknown")]
	[Description("West Bank (Israel)")]
	WestBankIsrael = 235,
	[Description("Western Sahara")]
	[InternetDomainCode("EH")]
	WesternSahara = 234,
	[Description("Western Samoa")]
	[InternetDomainCode("Unknown")]
	WesternSamoa = 236,
	[InternetDomainCode("YE")]
	[Description("Yemen")]
	Yemen = 237,
	[InternetDomainCode("CS")]
	[Description("Serbia and Montenegro")]
	SerbiaAndMontenegro = 240,
	[InternetDomainCode("Unknown")]
	[Description("Zaire")]
	Zaire = 241,
	[InternetDomainCode("ZM")]
	[Description("Zambia")]
	Zambia = 242,
	[InternetDomainCode("ZW")]
	[Description("Zimbabwe")]
	Zimbabwe = 243
}
