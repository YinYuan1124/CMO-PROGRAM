using System;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public class NativeMethods
{
	public const int WEBP_DECODER_ABI_VERSION = 520;

	public const int WEBP_ENCODER_ABI_VERSION = 521;

	public const int WEBP_MAX_DIMENSION = 16383;

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPGetDecoderVersion();

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPGetInfo([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGBA([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeARGB([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGRA([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGB([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGR([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeYUV([In] IntPtr intptr_0, UIntPtr uintptr_0, ref int int_0, ref int int_1, ref IntPtr intptr_1, ref IntPtr intptr_2, ref int int_2, ref int int_3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGBAInto([In] IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeARGBInto([In] IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGRAInto([In] IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGBInto([In] IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGRInto([In] IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeYUVInto([In] IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_0, IntPtr intptr_2, UIntPtr uintptr_2, int int_1, IntPtr intptr_3, UIntPtr uintptr_3, int int_2);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPInitDecBufferInternal(ref WebPDecBuffer webPDecBuffer_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPFreeDecBuffer(ref WebPDecBuffer webPDecBuffer_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewDecoder(ref WebPDecBuffer webPDecBuffer_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewRGB(WEBP_CSP_MODE webp_CSP_MODE_0, IntPtr intptr_0, UIntPtr uintptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewYUVA(IntPtr intptr_0, UIntPtr uintptr_0, int int_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_1, IntPtr intptr_2, UIntPtr uintptr_2, int int_2, IntPtr intptr_3, UIntPtr uintptr_3, int int_3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewYUV(IntPtr intptr_0, UIntPtr uintptr_0, int int_0, IntPtr intptr_1, UIntPtr uintptr_1, int int_1, IntPtr intptr_2, UIntPtr uintptr_2, int int_2);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPIDelete(ref WebPIDecoder webPIDecoder_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPIAppend(ref WebPIDecoder webPIDecoder_0, [In] IntPtr intptr_0, UIntPtr uintptr_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPIUpdate(ref WebPIDecoder webPIDecoder_0, [In] IntPtr intptr_0, UIntPtr uintptr_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecGetRGB(ref WebPIDecoder webPIDecoder_0, ref int int_0, ref int int_1, ref int int_2, ref int int_3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecGetYUVA(ref WebPIDecoder webPIDecoder_0, ref int int_0, ref IntPtr intptr_0, ref IntPtr intptr_1, ref IntPtr intptr_2, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecodedArea(ref WebPIDecoder webPIDecoder_0, ref int int_0, ref int int_1, ref int int_2, ref int int_3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPGetFeaturesInternal([In] IntPtr intptr_0, UIntPtr uintptr_0, ref WebPBitstreamFeatures webPBitstreamFeatures_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPInitDecoderConfigInternal(ref WebPDecoderConfig webPDecoderConfig_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecode([In] IntPtr intptr_0, UIntPtr uintptr_0, ref WebPDecoderConfig webPDecoderConfig_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPDecode([In] IntPtr intptr_0, UIntPtr uintptr_0, ref WebPDecoderConfig webPDecoderConfig_0);

	public static bool WebPIsPremultipliedMode(WEBP_CSP_MODE webp_CSP_MODE_0)
	{
		if (webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_rgbA && webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_bgrA && webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_Argb)
		{
			return webp_CSP_MODE_0 == WEBP_CSP_MODE.MODE_rgbA_4444;
		}
		return true;
	}

	public static bool WebPIsRGBMode(WEBP_CSP_MODE webp_CSP_MODE_0)
	{
		return webp_CSP_MODE_0 < WEBP_CSP_MODE.MODE_YUV;
	}

	public static bool WebPIsAlphaMode(WEBP_CSP_MODE webp_CSP_MODE_0)
	{
		if (webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_RGBA && webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_BGRA && webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_ARGB && webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_RGBA_4444 && webp_CSP_MODE_0 != WEBP_CSP_MODE.MODE_YUVA)
		{
			return WebPIsPremultipliedMode(webp_CSP_MODE_0);
		}
		return true;
	}

	public static VP8StatusCode WebPGetFeatures(IntPtr intptr_0, UIntPtr uintptr_0, ref WebPBitstreamFeatures webPBitstreamFeatures_0)
	{
		return WebPGetFeaturesInternal(intptr_0, uintptr_0, ref webPBitstreamFeatures_0, 520);
	}

	public static int WebPInitDecoderConfig(ref WebPDecoderConfig webPDecoderConfig_0)
	{
		return WebPInitDecoderConfigInternal(ref webPDecoderConfig_0, 520);
	}

	public static int WebPInitDecBuffer(ref WebPDecBuffer webPDecBuffer_0)
	{
		return WebPInitDecBufferInternal(ref webPDecBuffer_0, 520);
	}

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPGetEncoderVersion();

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeRGB([In] IntPtr intptr_0, int int_0, int int_1, int int_2, float float_0, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeBGR([In] IntPtr intptr_0, int int_0, int int_1, int int_2, float float_0, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeRGBA([In] IntPtr intptr_0, int int_0, int int_1, int int_2, float float_0, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPEncodeBGRA([In] IntPtr intptr_0, int int_0, int int_1, int int_2, float float_0, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessRGB([In] IntPtr intptr_0, int int_0, int int_1, int int_2, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessBGR([In] IntPtr intptr_0, int int_0, int int_1, int int_2, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessRGBA([In] IntPtr intptr_0, int int_0, int int_1, int int_2, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessBGRA([In] IntPtr intptr_0, int int_0, int int_1, int int_2, ref IntPtr intptr_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPConfigInitInternal(ref WebPConfig webPConfig_0, WebPPreset webPPreset_0, float float_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPConfigLosslessPreset(ref WebPConfig webPConfig_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPValidateConfig(ref WebPConfig webPConfig_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPMemoryWriterInit(ref WebPMemoryWriter webPMemoryWriter_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPMemoryWriterClear(ref WebPMemoryWriter webPMemoryWriter_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPMemoryWrite([In] IntPtr intptr_0, UIntPtr uintptr_0, ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureInitInternal(ref WebPPicture webPPicture_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureAlloc(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPPictureFree(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureCopy(ref WebPPicture webPPicture_0, ref WebPPicture webPPicture_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureDistortion(ref WebPPicture webPPicture_0, ref WebPPicture webPPicture_1, int int_0, ref float float_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureCrop(ref WebPPicture webPPicture_0, int int_0, int int_1, int int_2, int int_3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureView(ref WebPPicture webPPicture_0, int int_0, int int_1, int int_2, int int_3, ref WebPPicture webPPicture_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureIsView(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureRescale(ref WebPPicture webPPicture_0, int int_0, int int_1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportRGB(ref WebPPicture webPPicture_0, [In] IntPtr intptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportRGBA(ref WebPPicture webPPicture_0, [In] IntPtr intptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureSmartARGBToYUVA(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportRGBX(ref WebPPicture webPPicture_0, [In] IntPtr intptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportBGR(ref WebPPicture webPPicture_0, [In] IntPtr intptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportBGRA(ref WebPPicture webPPicture_0, [In] IntPtr intptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportBGRX(ref WebPPicture webPPicture_0, [In] IntPtr intptr_0, int int_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureARGBToYUVA(ref WebPPicture webPPicture_0, WebPEncCSP webPEncCSP_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureYUVAToARGB(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPCleanupTransparentArea(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureHasTransparency(ref WebPPicture webPPicture_0);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPEncode(ref WebPConfig webPConfig_0, ref WebPPicture webPPicture_0);

	public static int WebPConfigInit(ref WebPConfig webPConfig_0)
	{
		return WebPConfigInitInternal(ref webPConfig_0, WebPPreset.WEBP_PRESET_DEFAULT, 75f, 521);
	}

	public static int WebPConfigPreset(ref WebPConfig webPConfig_0, WebPPreset webPPreset_0, float float_0)
	{
		return WebPConfigInitInternal(ref webPConfig_0, webPPreset_0, float_0, 521);
	}

	public static int WebPPictureInit(ref WebPPicture webPPicture_0)
	{
		return WebPPictureInitInternal(ref webPPicture_0, 521);
	}

	public static void WebPSafeFree(IntPtr intptr_0)
	{
		WebPFree(intptr_0);
	}

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPFree(IntPtr intptr_0);
}
