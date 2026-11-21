using System;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Algorithm;

public class ConvexHull
{
	private class SchemaPrototype : IComparer<Coordinate>
	{
		private readonly Coordinate utilsPrototype = Coordinate.Empty;

		public SchemaPrototype(Coordinate coordinate_0)
		{
			utilsPrototype = coordinate_0;
		}

		public int Compare(Coordinate x, Coordinate y)
		{
			return RevertInterruptibleMapping(utilsPrototype, x, y);
		}

		private static int RevertInterruptibleMapping(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
		{
			double num = coordinate_1.X - coordinate_0.X;
			double num2 = coordinate_1.Y - coordinate_0.Y;
			double num3 = coordinate_2.X - coordinate_0.X;
			double num4 = coordinate_2.Y - coordinate_0.Y;
			switch (CgAlgorithms.ComputeOrientation(coordinate_0, coordinate_1, coordinate_2))
			{
			case 1:
				return 1;
			default:
			{
				double num5 = num * num + num2 * num2;
				double num6 = num3 * num3 + num4 * num4;
				if (num5 < num6)
				{
					return -1;
				}
				if (num5 <= num6)
				{
					return 0;
				}
				return 1;
			}
			case -1:
				return -1;
			}
		}
	}

	private readonly IGeometryFactory parserInstance;

	private readonly Coordinate[] algoInstance;

	public ConvexHull(IGeometry igeometry_0)
		: this(DestroyExpression(igeometry_0), igeometry_0.Factory)
	{
	}

	public ConvexHull(Coordinate[] coordinate_0, IGeometryFactory igeometryFactory_0)
	{
		algoInstance = coordinate_0;
		parserInstance = igeometryFactory_0;
	}

	private static Coordinate[] DestroyExpression(IGeometry igeometry_0)
	{
		UniqueCoordinateArrayFilter uniqueCoordinateArrayFilter = new UniqueCoordinateArrayFilter();
		igeometry_0.Apply(uniqueCoordinateArrayFilter);
		return uniqueCoordinateArrayFilter.Coordinates;
	}

	public virtual IGeometry GetConvexHull()
	{
		if (algoInstance.Length == 0)
		{
			return parserInstance.CreateGeometryCollection(null);
		}
		if (algoInstance.Length == 1)
		{
			return parserInstance.CreatePoint(algoInstance[0]);
		}
		if (algoInstance.Length == 2)
		{
			return parserInstance.CreateLineString(algoInstance);
		}
		Coordinate[] object_ = algoInstance;
		if (algoInstance.Length > 50)
		{
			object_ = ComputeExpression(algoInstance);
		}
		Coordinate[] coordinate_ = SelectExpression(PatchExpression(object_)).ToArray();
		return LoginExpression(coordinate_);
	}

	private static Coordinate[] ComputeExpression(object object_0)
	{
		Coordinate[] array = ViewExpression(object_0);
		if (array == null)
		{
			return (Coordinate[])object_0;
		}
		SortedSet<Coordinate> sortedSet = new SortedSet<Coordinate>();
		for (int i = 0; i < array.Length; i++)
		{
			sortedSet.Add(array[i]);
		}
		for (int j = 0; j < ((Array)object_0).Length; j++)
		{
			if (!CgAlgorithms.IsPointInRing((Coordinate)((object[])object_0)[j], array))
			{
				sortedSet.Add((Coordinate)((object[])object_0)[j]);
			}
		}
		Coordinate[] array2 = new Coordinate[sortedSet.Count];
		sortedSet.CopyTo(array2, 0);
		return array2;
	}

	private static Coordinate[] PatchExpression(object object_0)
	{
		for (int i = 1; i < ((Array)object_0).Length; i++)
		{
			if (((Coordinate)((object[])object_0)[i]).Y < ((Coordinate)((object[])object_0)[0]).Y || (((Coordinate)((object[])object_0)[i]).Y == ((Coordinate)((object[])object_0)[0]).Y && ((Coordinate)((object[])object_0)[i]).X < ((Coordinate)((object[])object_0)[0]).X))
			{
				Coordinate coordinate = (Coordinate)((object[])object_0)[0];
				((object[])object_0)[0] = ((object[])object_0)[i];
				((object[])object_0)[i] = coordinate;
			}
		}
		Array.Sort((Coordinate[])object_0, 1, ((Array)object_0).Length - 1, new SchemaPrototype((Coordinate)((object[])object_0)[0]));
		return (Coordinate[])object_0;
	}

	private static Stack<Coordinate> SelectExpression(object object_0)
	{
		Stack<Coordinate> stack = new Stack<Coordinate>(((Array)object_0).Length);
		stack.Push((Coordinate)((object[])object_0)[0]);
		stack.Push((Coordinate)((object[])object_0)[1]);
		stack.Push((Coordinate)((object[])object_0)[2]);
		for (int i = 3; i < ((Array)object_0).Length; i++)
		{
			Coordinate coordinate = stack.Pop();
			while (CgAlgorithms.ComputeOrientation(stack.Peek(), coordinate, (Coordinate)((object[])object_0)[i]) > 0)
			{
				coordinate = stack.Pop();
			}
			stack.Push(coordinate);
			stack.Push((Coordinate)((object[])object_0)[i]);
		}
		stack.Push((Coordinate)((object[])object_0)[0]);
		return stack;
	}

	private Stack<Coordinate> CallExpression(Stack<Coordinate> stack_0)
	{
		int count = stack_0.Count;
		Coordinate[] array = new Coordinate[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = stack_0.Pop();
		}
		Stack<Coordinate> stack = new Stack<Coordinate>(count);
		Coordinate[] array2 = array;
		Coordinate[] array3 = array2;
		foreach (Coordinate item in array3)
		{
			stack.Push(item);
		}
		return stack;
	}

	private static bool LogoutExpression(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		if (CgAlgorithms.ComputeOrientation(coordinate_0, coordinate_1, coordinate_2) == 0)
		{
			if (coordinate_0.X != coordinate_2.X)
			{
				if (coordinate_0.X <= coordinate_1.X && coordinate_1.X <= coordinate_2.X)
				{
					return true;
				}
				if (coordinate_2.X <= coordinate_1.X && coordinate_1.X <= coordinate_0.X)
				{
					return true;
				}
			}
			if (coordinate_0.Y != coordinate_2.Y)
			{
				if (coordinate_0.Y <= coordinate_1.Y && coordinate_1.Y <= coordinate_2.Y)
				{
					return true;
				}
				if (coordinate_2.Y <= coordinate_1.Y && coordinate_1.Y <= coordinate_0.Y)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private static Coordinate[] ViewExpression(object object_0)
	{
		Coordinate[] ienumerable_ = ValidateExpression(object_0);
		CoordinateList coordinateList = new CoordinateList { { ienumerable_, false } };
		if (coordinateList.Count < 3)
		{
			return null;
		}
		coordinateList.CloseRing();
		return coordinateList.ToCoordinateArray();
	}

	private static Coordinate[] ValidateExpression(object object_0)
	{
		Coordinate[] array = new Coordinate[8];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (Coordinate)((object[])object_0)[0];
		}
		for (int j = 1; j < ((Array)object_0).Length; j++)
		{
			if (((Coordinate)((object[])object_0)[j]).X < array[0].X)
			{
				array[0] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X - ((Coordinate)((object[])object_0)[j]).Y < array[1].X - array[1].Y)
			{
				array[1] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).Y > array[2].Y)
			{
				array[2] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X + ((Coordinate)((object[])object_0)[j]).Y > array[3].X + array[3].Y)
			{
				array[3] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X > array[4].X)
			{
				array[4] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X - ((Coordinate)((object[])object_0)[j]).Y > array[5].X - array[5].Y)
			{
				array[5] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).Y < array[6].Y)
			{
				array[6] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X + ((Coordinate)((object[])object_0)[j]).Y < array[7].X + array[7].Y)
			{
				array[7] = (Coordinate)((object[])object_0)[j];
			}
		}
		return array;
	}

	private IGeometry LoginExpression(Coordinate[] coordinate_0)
	{
		coordinate_0 = GetExpression(coordinate_0);
		if (coordinate_0.Length == 3)
		{
			return parserInstance.CreateLineString(new Coordinate[2]
			{
				coordinate_0[0],
				coordinate_0[1]
			});
		}
		ILinearRing ilinearRing_ = parserInstance.CreateLinearRing(coordinate_0);
		return parserInstance.CreatePolygon(ilinearRing_, null);
	}

	private static Coordinate[] GetExpression(object object_0)
	{
		object.Equals(((object[])object_0)[0], ((object[])object_0)[((Array)object_0).Length - 1]);
		List<Coordinate> list = new List<Coordinate>();
		Coordinate coordinate = Coordinate.Empty;
		for (int i = 0; i <= ((Array)object_0).Length - 2; i++)
		{
			Coordinate coordinate2 = (Coordinate)((object[])object_0)[i];
			Coordinate coordinate3 = (Coordinate)((object[])object_0)[i + 1];
			if (!coordinate2.Equals(coordinate3) && (coordinate.IsEmpty() || !LogoutExpression(coordinate, coordinate2, coordinate3)))
			{
				list.Add(coordinate2);
				coordinate = coordinate2;
			}
		}
		list.Add((Coordinate)((object[])object_0)[((Array)object_0).Length - 1]);
		return list.ToArray();
	}
}
