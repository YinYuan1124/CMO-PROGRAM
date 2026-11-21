using System.Drawing;

namespace ExWorldWind;

public class DrawArgs
{
	public static DrawArgs Instance;

	public WorldCamera WorldCamera = new WorldCamera();

	public static Point LastMousePosition;

	public static bool IsLeftMouseButtonDown;

	public static bool IsRightMouseButtonDown;

	public int XOffset;

	internal void AwakeThread(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		WorldCamera.RegisterThread(float_0, float_1, float_2, float_3, float_4, float_5);
	}

	static DrawArgs()
	{
		Instance = new DrawArgs();
		IsLeftMouseButtonDown = false;
		IsRightMouseButtonDown = false;
	}
}
