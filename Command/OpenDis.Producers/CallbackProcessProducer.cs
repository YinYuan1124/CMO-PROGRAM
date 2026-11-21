using System.Drawing;

namespace OpenDis.Producers;

internal static class CallbackProcessProducer
{
	internal static Bitmap ViewListener(this object object_0, Color color_0)
	{
		Bitmap bitmap = new Bitmap(((Image)object_0).Width, ((Image)object_0).Height);
		for (int i = 0; i < ((Image)object_0).Width; i++)
		{
			for (int j = 0; j < ((Image)object_0).Height; j++)
			{
				if (((Bitmap)object_0).GetPixel(i, j).A > 0)
				{
					bitmap.SetPixel(i, j, color_0);
				}
			}
		}
		return bitmap;
	}

	internal static Bitmap ValidateListener(this object object_0, Color color_0, Color color_1)
	{
		Bitmap bitmap = new Bitmap(((Image)object_0).Width, ((Image)object_0).Height);
		for (int i = 0; i < ((Image)object_0).Width; i++)
		{
			for (int j = 0; j < ((Image)object_0).Height; j++)
			{
				if (((Bitmap)object_0).GetPixel(i, j) == color_0)
				{
					bitmap.SetPixel(i, j, color_1);
				}
			}
		}
		return bitmap;
	}
}
