//#define DEBUG

#define PI 3.1415926538

// Must be multiple of 4 and set to same value in Main.cs
#define VS_CONSTANT_BUFFER_ARRAY_MAX 256
#define VS_CONSTANT_BUFFER_ARRAY_SIZE VS_CONSTANT_BUFFER_ARRAY_MAX / 4

#define OSM_RELIEF_LAYER 1
#define BMNGOSM_LAYER 2
#define LINE_LAYER 5
#define BING_LAYER 6
#define DAY_NIGHT_LAYER 7
#define STAMEN_LABELS_LAYER 8
#define ARRAY_LAYER 9
#define BLENDABLE_LINE_LAYER 10


static float4 RED = { 1.0f, 0.0f, 0.0f, 1.0f };
static float4 GREEN = { 0.0f, 1.0f, 0.0f, 1.0f };
static float4 YELLOW = { 1.0f, 1.0f, 0.0f, 1.0f };
static float4 CYAN = { 0.0f, 1.0f, 1.0f, 1.0f };


cbuffer constants : register(b0)
{
	row_major float4x4 worldViewProj;
	float u;
	float v;
	float uWidth;
	float vWidth;
	uint Level;
	uint Row;
	int Layer;
	float Hint;
};

cbuffer constantsArray : register(b1)
{
	uint Count;
	float3 Padding;
	float4 uArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	float4 vArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	float4 uWidthArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	float4 vWidthArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	uint4 LevelArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	uint4 RowArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	int4 LayerArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
	float4 HintArray[VS_CONSTANT_BUFFER_ARRAY_SIZE];
};


Texture2D gDiffuseMap : register(t0);
Texture2DArray texture2DArray : register(t1);

SamplerState samAnisotropic : register(s0);

struct vs_in
{
	float3 posL : POSITION;
	float4 color : COLOR;
	float2 texcoord : TEXCOORD;
};

struct vs_out
{
	float4 posH : SV_POSITION;
	float4 color : COLOR;
	float2 texcoord : TEXCOORD;
};

vs_out vs_main(vs_in input)
{
	vs_out output;

	output.posH = mul(float4(input.posL, 1.0f), worldViewProj);
	output.color = input.color;
	output.texcoord = input.texcoord;

	return output;
}

float4 ps_daynight(vs_out input) : SV_TARGET
{
	float longitude = input.texcoord[0] * 360 - 180;
	float latitude = input.texcoord[1] * -180 + 90;

	float julianDay = Hint;
	float time = julianDay - 2415018.5;
	float timeZone = 0; // UT

	float julianCentury = (julianDay - 2451545) / 36525;

	float geomMeanLongSun0 = 36000.76983 + julianCentury * 0.0003032;
	float geomMeanLongSun00 = julianCentury * geomMeanLongSun0;
	float geomMeanLongSun = (280.46646 + geomMeanLongSun00) % 360;

	float sunEqOfCtr = 0.4468;

	float sunTrueLon = geomMeanLongSun + sunEqOfCtr;

	float sunAppLong = sunTrueLon;

	float obliqCorr = 23.43849;

	float declination0 = sin(radians(obliqCorr));
	float declination1 = sin(radians(sunAppLong));
	float declination = asin(declination0 * declination1);
	declination = degrees(declination);

	float eqOfTime = -1.706308;

	float solarTime0 = time * 1440; // minutes
	float solarTime1 = 4 * longitude;
	float solarTime2 = 60 * timeZone;
	float solarTime = (solarTime0 + eqOfTime + solarTime1 - solarTime2) % 1440;

	float hourAngle = solarTime / 4;
	if (hourAngle < 0)
		hourAngle += 180;
	else
		hourAngle -= 180;

	float zenith0 = sin(radians(latitude));
	float zenith1 = sin(radians(declination));
	float zenith2 = cos(radians(latitude));
	float zenith3 = cos(radians(declination));
	float zenith4 = cos(radians(hourAngle));
	float zenith01 = zenith0 * zenith1;
	float zenith234 = zenith2 * zenith3 * zenith4;
	float zenith01234 = zenith01 + zenith234;
	float zenith = acos(zenith01234);
	zenith = degrees(zenith);

	float elevation = 90 - zenith;
	return max(0.2, ((elevation / 90) + 0.3)) * input.color;
}

float4 ps_tile(vs_out input) : SV_TARGET
{
#ifdef DEBUG
	float highlight = 1;
#endif
	float4 texColor = GREEN;
	float vVar = v;
	float vWidthVar = vWidth;
	if (input.texcoord[1] < vVar || vVar + vWidthVar < input.texcoord[1])
		clip(-1);

	float uVar = u;
	float uWidthVar = uWidth;
	if (input.texcoord[0] < uVar || uVar + uWidthVar < input.texcoord[0])
		clip(-1);

	uint LevelVar = Level;
	if (LevelVar == 0)
		clip(-1);

	int LayerVar = Layer;

	input.texcoord[0] = (input.texcoord[0] - uVar) / uWidthVar;

#ifdef DEBUG
	float4 center = RED;
	float4 left = RED;
	float4 top = GREEN;
#endif

	if (LayerVar == OSM_RELIEF_LAYER || LayerVar == BING_LAYER ||
		LayerVar == STAMEN_LABELS_LAYER || LayerVar == BMNGOSM_LAYER) {

#ifdef DEBUG
		center = YELLOW;
		left = YELLOW;
		top = CYAN;
#endif

		if (LevelVar < 13) {
			float vInRow = (input.texcoord[1] - vVar) / vWidthVar;
			uint RowVar = Row;
			float sinhval = sinh(PI -
				(2.0f * PI * (RowVar + vInRow)) /
				(1 << LevelVar));
			float latitude = (180.0f / PI) * atan(sinhval);
			float vLatitude = (90.0f - latitude) / 180.0f;
			input.texcoord[1] = input.texcoord[1] - (vLatitude - input.texcoord[1]);
		}
	}

	input.texcoord[1] = (input.texcoord[1] - vVar) / vWidthVar;

#ifdef DEBUG
	// center dot
	if (0.46f < input.texcoord[0] && input.texcoord[0] < 0.54f
		&& 0.46f < input.texcoord[1] && input.texcoord[1] < 0.54f) {
		return center;
	}

	// left side
	if (0.00f < input.texcoord[0] && input.texcoord[0] < 0.02f) {
		return left;
	}

	// top side
	if (0.00f < input.texcoord[1] && input.texcoord[1] < 0.02f) {
		return top;
	}

	// highlight = 1.5f;
#endif

	texColor = gDiffuseMap.Sample(samAnisotropic, input.texcoord);

	if (texColor.a == 0)
		clip(-1);

	float HintVar = Hint;
	if (LayerVar == STAMEN_LABELS_LAYER) {
		clip(texColor.a - HintVar);
		return texColor * 0.7f;
	} else {
		clip(texColor.a - HintVar);
#ifdef DEBUG
		return texColor * highlight;
#else
		return texColor;
#endif
	}

	return texColor;  // Compiler requires notional return path even after clip
}

float4 ps_array(vs_out input) : SV_TARGET
{
#ifdef DEBUG
	float highlight = 1;
#endif
	float4 texColor = GREEN;
	for (uint i = 0; i < Count; i++) {
		uint d1 = i >> 2;
		uint d2 = i & 3;
		float vVar = vArray[d1][d2];
		float vWidthVar = vWidthArray[d1][d2];
		if (input.texcoord[1] < vVar || vVar + vWidthVar < input.texcoord[1])
			continue;

		float uVar = uArray[d1][d2];
		float uWidthVar = uWidthArray[d1][d2];
		if (input.texcoord[0] < uVar || uVar + uWidthVar < input.texcoord[0])
			continue;

		uint LevelVar = LevelArray[d1][d2];
		if (LevelVar == 0)
			clip(-1);

		int LayerVar = LayerArray[d1][d2];

		input.texcoord[0] = (input.texcoord[0] - uVar) / uWidthVar;

#ifdef DEBUG
		float4 center = RED;
		float4 left = RED;
		float4 top = GREEN;
#endif

		if (LayerVar == OSM_RELIEF_LAYER || LayerVar == BING_LAYER ||
			LayerVar == STAMEN_LABELS_LAYER || LayerVar == BMNGOSM_LAYER) {

#ifdef DEBUG
			center = YELLOW;
			left = YELLOW;
			top = CYAN;
#endif

			if (LevelVar < 13) {
				float vInRow = (input.texcoord[1] - vVar) / vWidthVar;
				uint RowVar = RowArray[d1][d2];
				float sinhval = sinh(PI -
					(2.0f * PI * (RowVar + vInRow)) /
					(1 << LevelVar));
				float latitude = (180.0f / PI) * atan(sinhval);
				float vLatitude = (90.0f - latitude) / 180.0f;
				input.texcoord[1] = input.texcoord[1] - (vLatitude - input.texcoord[1]);
			}
		}

		input.texcoord[1] = (input.texcoord[1] - vVar) / vWidthVar;

#ifdef DEBUG
		// center dot
		if (0.46f < input.texcoord[0] && input.texcoord[0] < 0.54f
			&& 0.46f < input.texcoord[1] && input.texcoord[1] < 0.54f) {
			return center;
		}

		// left side
		if (0.00f < input.texcoord[0] && input.texcoord[0] < 0.02f) {
			return left;
		}

		// top side
		if (0.00f < input.texcoord[1] && input.texcoord[1] < 0.02f) {
			return top;
		}

		// highlight = 1.5f;
#endif

		float3 location = { input.texcoord[0], input.texcoord[1], i };
		texColor = texture2DArray.SampleLevel(samAnisotropic, location, 0);

		float HintVar = HintArray[d1][d2];
		if (LayerVar == STAMEN_LABELS_LAYER) {
			clip(texColor.a - HintVar);
			return texColor * 0.7f;
		} else {
			clip(texColor.a - HintVar);
#ifdef DEBUG
			return texColor * highlight;
#else
			return texColor;
#endif
		}
	}

	clip(-1); // Discard if nothing found in texture array
	return texColor;  // Compiler requires notional return path even after clip
}

float4 ps_line(vs_out input) : SV_TARGET
{
	return input.color;
}

float4 ps_blendable_line (vs_out input) : SV_TARGET
{
	input.color.a = Hint;
	return input.color;
}

float4 ps_main(vs_out input) : SV_TARGET
{
	float highlight = 1;
	float4 texColor = gDiffuseMap.Sample(samAnisotropic, input.texcoord);
	clip(texColor.a - Hint);
	return texColor * highlight;
}
