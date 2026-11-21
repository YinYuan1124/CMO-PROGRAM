using System;

namespace DotSpatial.Topology.Algorithm;

public class RobustDeterminant
{
	public static int SignOfDet2X2(double double_0, double double_1, double double_2, double double_3)
	{
		long num = 0L;
		int num4 = 1;
		if (double_0 != 0.0 && double_3 != 0.0)
		{
			if (double_1 != 0.0 && double_2 != 0.0)
			{
				if (0.0 < double_1)
				{
					if (0.0 < double_3)
					{
						if (double_1 > double_3)
						{
							num4 = -num4;
							double num5 = double_0;
							double_0 = double_2;
							double_2 = num5;
							double num6 = double_1;
							double_1 = double_3;
							double_3 = num6;
						}
					}
					else if (double_1 <= 0.0 - double_3)
					{
						num4 = -num4;
						double_2 = 0.0 - double_2;
						double_3 = 0.0 - double_3;
					}
					else
					{
						double num7 = double_0;
						double_0 = 0.0 - double_2;
						double_2 = num7;
						double num8 = double_1;
						double_1 = 0.0 - double_3;
						double_3 = num8;
					}
				}
				else if (0.0 < double_3)
				{
					if (0.0 - double_1 <= double_3)
					{
						num4 = -num4;
						double_0 = 0.0 - double_0;
						double_1 = 0.0 - double_1;
					}
					else
					{
						double num9 = 0.0 - double_0;
						double_0 = double_2;
						double_2 = num9;
						double num10 = 0.0 - double_1;
						double_1 = double_3;
						double_3 = num10;
					}
				}
				else if (double_1 < double_3)
				{
					num4 = -num4;
					double num11 = 0.0 - double_0;
					double_0 = 0.0 - double_2;
					double_2 = num11;
					double num2 = 0.0 - double_1;
					double_1 = 0.0 - double_3;
					double_3 = num2;
				}
				else
				{
					double_0 = 0.0 - double_0;
					double_1 = 0.0 - double_1;
					double_2 = 0.0 - double_2;
					double_3 = 0.0 - double_3;
				}
				if (0.0 < double_0)
				{
					if (!(0.0 < double_2))
					{
						return num4;
					}
					if (double_0 > double_2)
					{
						return num4;
					}
				}
				else
				{
					if (0.0 < double_2)
					{
						return -num4;
					}
					if (double_0 < double_2)
					{
						return -num4;
					}
					num4 = -num4;
					double_0 = 0.0 - double_0;
					double_2 = 0.0 - double_2;
				}
				while (true)
				{
					num++;
					double num3 = Math.Floor(double_2 / double_0);
					double_2 -= num3 * double_0;
					double_3 -= num3 * double_1;
					if (!(double_3 < 0.0))
					{
						if (!(double_3 <= double_1))
						{
							break;
						}
						if (double_0 <= double_2 + double_2)
						{
							if (!(double_1 <= double_3 + double_3))
							{
								return -num4;
							}
							double_2 = double_0 - double_2;
							double_3 = double_1 - double_3;
							num4 = -num4;
						}
						else if (!(double_1 >= double_3 + double_3))
						{
							return num4;
						}
						if (double_3 != 0.0)
						{
							if (double_2 != 0.0)
							{
								num3 = Math.Floor(double_0 / double_2);
								double_0 -= num3 * double_2;
								double_1 -= num3 * double_3;
								if (double_1 >= 0.0)
								{
									if (double_1 <= double_3)
									{
										if (double_2 <= double_0 + double_0)
										{
											if (!(double_3 <= double_1 + double_1))
											{
												return num4;
											}
											double_0 = double_2 - double_0;
											double_1 = double_3 - double_1;
											num4 = -num4;
										}
										else if (!(double_3 >= double_1 + double_1))
										{
											return -num4;
										}
										if (double_1 != 0.0)
										{
											if (double_0 == 0.0)
											{
												return -num4;
											}
											continue;
										}
										if (double_0 == 0.0)
										{
											return 0;
										}
										return num4;
									}
									return -num4;
								}
								return num4;
							}
							return num4;
						}
						if (double_2 == 0.0)
						{
							return 0;
						}
						return -num4;
					}
					return -num4;
				}
				return num4;
			}
			if (double_3 <= 0.0)
			{
				if (double_0 <= 0.0)
				{
					return num4;
				}
				return -num4;
			}
			if (double_0 <= 0.0)
			{
				return -num4;
			}
			return num4;
		}
		if (double_1 != 0.0 && double_2 != 0.0)
		{
			if (double_1 <= 0.0)
			{
				if (double_2 <= 0.0)
				{
					return -num4;
				}
				return num4;
			}
			if (double_2 <= 0.0)
			{
				return num4;
			}
			return -num4;
		}
		return 0;
	}
}
