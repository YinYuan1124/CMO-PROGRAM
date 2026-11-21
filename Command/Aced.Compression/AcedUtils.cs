namespace Aced.Compression;

public sealed class AcedUtils
{
	internal static uint RegisterObserver(uint uint_0, int int_0)
	{
		uint_0 = ((uint_0 & 0xFFFF) << 16) | (uint_0 >> 16);
		uint_0 = ((uint_0 & 0xFF00FF) << 8) | ((uint_0 & 0xFF00FF00u) >> 8);
		uint_0 = ((uint_0 & 0xF0F0F0F) << 4) | ((uint_0 & 0xF0F0F0F0u) >> 4);
		uint_0 = ((uint_0 & 0x33333333) << 2) | ((uint_0 & 0xCCCCCCCCu) >> 2);
		uint_0 = ((uint_0 & 0x55555555) << 1) | ((uint_0 & 0xAAAAAAAAu) >> 1);
		return uint_0 >> 32 - int_0;
	}

	public unsafe static int Adler32(byte[] byte_0, int int_0, int int_1)
	{
		if (byte_0 != null && int_1 != 0)
		{
			uint num = 1u;
			uint num2 = 0u;
			fixed (byte* ptr = &byte_0[int_0])
			{
				byte* ptr2 = ptr;
				while (int_1 > 0)
				{
					int num3 = ((int_1 < 5552) ? int_1 : 5552);
					int_1 -= num3;
					while (num3 >= 16)
					{
						num += *ptr2;
						num2 += num;
						num += ptr2[1];
						num2 += num;
						num += ptr2[2];
						num2 += num;
						num += ptr2[3];
						num2 += num;
						num += ptr2[4];
						num2 += num;
						num += ptr2[5];
						num2 += num;
						num += ptr2[6];
						num2 += num;
						num += ptr2[7];
						num2 += num;
						num += ptr2[8];
						num2 += num;
						num += ptr2[9];
						num2 += num;
						num += ptr2[10];
						num2 += num;
						num += ptr2[11];
						num2 += num;
						num += ptr2[12];
						num2 += num;
						num += ptr2[13];
						num2 += num;
						num += ptr2[14];
						num2 += num;
						num += ptr2[15];
						num2 += num;
						ptr2 += 16;
						num3 -= 16;
					}
					while (num3 > 0)
					{
						num += *ptr2;
						num2 += num;
						num3--;
						ptr2++;
					}
					num %= 65521u;
					num2 %= 65521u;
				}
			}
			return (int)(num | (num2 << 16));
		}
		return 1;
	}

	internal unsafe static void ManageObserver(byte* pByte_0, byte* pByte_1, int int_0)
	{
		while (int_0 >= 16)
		{
			*pByte_1 = *pByte_0;
			pByte_1[1] = pByte_0[1];
			pByte_1[2] = pByte_0[2];
			pByte_1[3] = pByte_0[3];
			pByte_1[4] = pByte_0[4];
			pByte_1[5] = pByte_0[5];
			pByte_1[6] = pByte_0[6];
			pByte_1[7] = pByte_0[7];
			pByte_1[8] = pByte_0[8];
			pByte_1[9] = pByte_0[9];
			pByte_1[10] = pByte_0[10];
			pByte_1[11] = pByte_0[11];
			pByte_1[12] = pByte_0[12];
			pByte_1[13] = pByte_0[13];
			pByte_1[14] = pByte_0[14];
			pByte_1[15] = pByte_0[15];
			int_0 -= 16;
			pByte_0 += 16;
			pByte_1 += 16;
		}
		while (int_0 >= 4)
		{
			*pByte_1 = *pByte_0;
			pByte_1[1] = pByte_0[1];
			pByte_1[2] = pByte_0[2];
			pByte_1[3] = pByte_0[3];
			int_0 -= 4;
			pByte_0 += 4;
			pByte_1 += 4;
		}
		if (int_0 < 2)
		{
			if (int_0 == 1)
			{
				*pByte_1 = *pByte_0;
			}
		}
		else if (int_0 == 2)
		{
			*pByte_1 = *pByte_0;
			pByte_1[1] = pByte_0[1];
		}
		else
		{
			*pByte_1 = *pByte_0;
			pByte_1[1] = pByte_0[1];
			pByte_1[2] = pByte_0[2];
		}
	}

	internal unsafe static void Fill(int int_0, int* pInt_0, int int_1)
	{
		while (int_1 >= 16)
		{
			*pInt_0 = int_0;
			pInt_0[1] = int_0;
			pInt_0[2] = int_0;
			pInt_0[3] = int_0;
			pInt_0[4] = int_0;
			pInt_0[5] = int_0;
			pInt_0[6] = int_0;
			pInt_0[7] = int_0;
			pInt_0[8] = int_0;
			pInt_0[9] = int_0;
			pInt_0[10] = int_0;
			pInt_0[11] = int_0;
			pInt_0[12] = int_0;
			pInt_0[13] = int_0;
			pInt_0[14] = int_0;
			pInt_0[15] = int_0;
			int_1 -= 16;
			pInt_0 += 16;
		}
		while (int_1 >= 4)
		{
			*pInt_0 = int_0;
			pInt_0[1] = int_0;
			pInt_0[2] = int_0;
			pInt_0[3] = int_0;
			int_1 -= 4;
			pInt_0 += 4;
		}
		if (int_1 < 2)
		{
			if (int_1 == 1)
			{
				*pInt_0 = int_0;
			}
		}
		else if (int_1 == 2)
		{
			*pInt_0 = int_0;
			pInt_0[1] = int_0;
		}
		else
		{
			*pInt_0 = int_0;
			pInt_0[1] = int_0;
			pInt_0[2] = int_0;
		}
	}

	private AcedUtils()
	{
	}
}
