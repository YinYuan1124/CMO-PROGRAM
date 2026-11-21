using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class RBWQuadTree
{
	public enum TNorthOrSouth
	{
		North,
		South
	}

	public enum TEastOrWest
	{
		East,
		West
	}

	[Serializable]
	public struct TQPoint<T>
	{
		public double X;

		public double Y;

		public List<T> Data;
	}

	[Serializable]
	public struct TQuadPoint<T>
	{
		public double X;

		public double Y;

		public double Distance;

		public List<T> Data;
	}

	[Serializable]
	public struct GStruct2<T>
	{
		public double X;

		public double Y;

		public List<T> Data;
	}

	public enum TExpandDirection
	{
		edNorth,
		edSouth,
		edEast,
		edWest
	}

	[Serializable]
	public struct T2DBlock
	{
		public double XMin;

		public double XMax;

		public double YMin;

		public double YMax;
	}

	[Serializable]
	public sealed class TQTreeNode<T>
	{
		protected internal int FNumPts;

		protected TQTreeNode<T>[] Children;

		protected internal double Xmin;

		protected internal double Xmax;

		protected internal double Ymin;

		protected internal double Ymax;

		protected internal TQPoint<T>[] Pts;

		protected TQTreeNode<T> Parent;

		protected TRbwQuadTree<T> Tree;

		private static object object_0;

		protected internal int NumPts
		{
			get
			{
				return FNumPts;
			}
			set
			{
				method_1(value);
			}
		}

		public TQPoint<T> GetPoints(int int_0)
		{
			return method_2(int_0);
		}

		private void method_0()
		{
			if (Children[1] == null)
			{
				return;
			}
			int num = 0;
			TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
			do
			{
				TEastOrWest tEastOrWest = TEastOrWest.East;
				do
				{
					num += Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)].NumPts;
					tEastOrWest++;
				}
				while (tEastOrWest <= TEastOrWest.West);
				tNorthOrSouth++;
			}
			while (tNorthOrSouth <= TNorthOrSouth.South);
			NumPts = num;
		}

		private void method_1(int int_0)
		{
			if (FNumPts == int_0)
			{
				return;
			}
			int fNumPts = FNumPts;
			FNumPts = int_0;
			if ((FNumPts <= Tree.MaxPoints) & (fNumPts > Tree.MaxPoints))
			{
				Pts = new TQPoint<T>[Tree.MaxPoints - 1 + 1];
				int num = 0;
				TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
				do
				{
					TEastOrWest tEastOrWest = TEastOrWest.East;
					do
					{
						TQTreeNode<T> tQTreeNode = Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
						int num2 = tQTreeNode.NumPts - 1;
						for (int i = 0; i <= num2; i++)
						{
							Pts[num] = tQTreeNode.Pts[i];
							num++;
						}
						tQTreeNode.FNumPts = 0;
						tQTreeNode.Pts = new TQPoint<T>[0];
						tQTreeNode = null;
						Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)] = null;
						tEastOrWest++;
					}
					while (tEastOrWest <= TEastOrWest.West);
					tNorthOrSouth++;
				}
				while (tNorthOrSouth <= TNorthOrSouth.South);
			}
			if (Parent != null)
			{
				Parent.method_0();
			}
		}

		private TQPoint<T> method_2(int int_0)
		{
			TQPoint<T> result = default(TQPoint<T>);
			if (Children[0] == null)
			{
				return Pts[int_0];
			}
			TEastOrWest tEastOrWest = TEastOrWest.West;
			do
			{
				TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
				do
				{
					TQTreeNode<T> tQTreeNode = Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
					if (tQTreeNode.NumPts <= int_0)
					{
						int_0 -= tQTreeNode.NumPts;
						tNorthOrSouth++;
						continue;
					}
					return tQTreeNode.method_2(int_0);
				}
				while (tNorthOrSouth <= TNorthOrSouth.South);
				tEastOrWest += -1;
			}
			while (tEastOrWest >= TEastOrWest.East);
			return result;
		}

		private void method_3(double double_0, double double_1, int int_0, ref double double_2, ref TQTreeNode<T> tqtreeNode_0, ref List<TSelectNode<T>> list_0)
		{
			int num = -1;
			int num2 = tqtreeNode_0.NumPts - 1;
			for (int i = 0; i <= num2; i++)
			{
				TQPoint<T> point = tqtreeNode_0.Pts[i];
				double num3 = point.X - double_0;
				double num4 = point.Y - double_1;
				double num5 = Math.Sqrt(num3 * num3 + num4 * num4);
				if (!((list_0.Count < int_0) | (num5 <= double_2)))
				{
					continue;
				}
				TSelectNode<T> tSelectNode = new TSelectNode<T>();
				tSelectNode.Distance = num5;
				tSelectNode.Point = point;
				list_0.Add(tSelectNode);
				if (list_0.Count % int_0 != 0)
				{
					continue;
				}
				list_0.Sort(tSelectNode);
				if (list_0.Count >= int_0)
				{
					tSelectNode = list_0[int_0 - 1];
					double_2 = tSelectNode.Distance;
				}
				int num6 = list_0.Count - 1;
				for (int j = int_0; j <= num6; j++)
				{
					tSelectNode = list_0[j];
					if (tSelectNode.Distance > double_2)
					{
						num = j;
						break;
					}
				}
				if (num > -1)
				{
					list_0.RemoveRange(num, list_0.Count - num);
				}
			}
		}

		private void method_4(double double_0, double double_1, int int_0, ref double double_2, ref TQTreeNode<T> tqtreeNode_0, ref List<TSelectNode<T>> list_0)
		{
			int num = -1;
			int num2 = tqtreeNode_0.NumPts - 1;
			for (int i = 0; i <= num2; i++)
			{
				TQPoint<T> point = tqtreeNode_0.Pts[i];
				double num3 = Geodesic_Vincenty.RemoveInvocation(point.Y, point.X, double_1, double_0);
				if (!((list_0.Count < int_0) | (num3 <= double_2)))
				{
					continue;
				}
				TSelectNode<T> tSelectNode = new TSelectNode<T>();
				tSelectNode.Distance = num3;
				tSelectNode.Point = point;
				list_0.Add(tSelectNode);
				if (list_0.Count % int_0 != 0)
				{
					continue;
				}
				list_0.Sort(tSelectNode);
				if (list_0.Count >= int_0)
				{
					tSelectNode = list_0[int_0 - 1];
					double_2 = tSelectNode.Distance;
				}
				int num4 = list_0.Count - 1;
				for (int j = int_0; j <= num4; j++)
				{
					tSelectNode = list_0[j];
					if (tSelectNode.Distance > double_2)
					{
						num = j;
						break;
					}
				}
				if (num > -1)
				{
					list_0.RemoveRange(num, list_0.Count - num);
				}
			}
		}

		public void FindNearestPoints(double double_0, double double_1, int int_0, ref List<TSelectNode<T>> list_0)
		{
			Stack<TQTreeNode<T>> stack_ = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> tqtreeNode_ = LocateLeaf(double_0, double_1, ref stack_);
			double double_2 = 0.0;
			method_3(double_0, double_1, int_0, ref double_2, ref tqtreeNode_, ref list_0);
			while (stack_.Count > 0)
			{
				tqtreeNode_ = stack_.Pop();
				if ((list_0.Count < int_0) | ((double_0 + double_2 >= tqtreeNode_.Xmin) & (double_0 - double_2 <= tqtreeNode_.Xmax) & (double_1 + double_2 >= tqtreeNode_.Ymin) & (double_1 - double_2 <= tqtreeNode_.Ymax)))
				{
					tqtreeNode_ = tqtreeNode_.LocateLeaf(double_0, double_1, ref stack_);
					method_3(double_0, double_1, int_0, ref double_2, ref tqtreeNode_, ref list_0);
				}
			}
		}

		public void FindNearestPointsGC(double double_0, double double_1, int int_0, ref List<TSelectNode<T>> list_0)
		{
			Stack<TQTreeNode<T>> stack_ = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> tqtreeNode_ = LocateLeaf(double_0, double_1, ref stack_);
			double double_3 = 0.0;
			method_4(double_0, double_1, int_0, ref double_3, ref tqtreeNode_, ref list_0);
			double double_4 = 0.0;
			double double_5 = 0.0;
			double double_6 = 0.0;
			double double_7 = 0.0;
			double double_8 = 0.0;
			double double_9 = 0.0;
			double double_10 = 0.0;
			double double_2 = 0.0;
			while (stack_.Count > 0)
			{
				tqtreeNode_ = stack_.Pop();
				Geodesic_Vincenty.fw_vincenty_wgs84_2(double_1, double_0, ref double_4, ref double_5, 0.0, double_3);
				Geodesic_Vincenty.fw_vincenty_wgs84_2(double_1, double_0, ref double_6, ref double_7, 180.0, double_3);
				Geodesic_Vincenty.fw_vincenty_wgs84_2(double_1, double_0, ref double_8, ref double_9, 90.0, double_3);
				Geodesic_Vincenty.fw_vincenty_wgs84_2(double_1, double_0, ref double_10, ref double_2, 270.0, double_3);
				if ((list_0.Count < int_0) | ((double_9 >= tqtreeNode_.Xmin) & (double_2 <= tqtreeNode_.Xmax) & (double_4 >= tqtreeNode_.Ymin) & (double_6 <= tqtreeNode_.Ymax)))
				{
					tqtreeNode_ = tqtreeNode_.LocateLeaf(double_0, double_1, ref stack_);
					method_4(double_0, double_1, int_0, ref double_3, ref tqtreeNode_, ref list_0);
				}
			}
		}

		protected internal void AddPoint(double double_0, double double_1, T Data)
		{
			if (double_0 < Xmin)
			{
				ExpandBounds(double_0, TExpandDirection.edWest);
			}
			if (double_0 > Xmax)
			{
				ExpandBounds(double_0, TExpandDirection.edEast);
			}
			if (double_1 < Ymin)
			{
				ExpandBounds(double_1, TExpandDirection.edSouth);
			}
			if (double_1 > Ymax)
			{
				ExpandBounds(double_1, TExpandDirection.edNorth);
			}
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.NumPts >= Tree.MaxPoints)
			{
				double num = tQTreeNode.Xmid();
				double num2 = tQTreeNode.Ymid();
				TNorthOrSouth tNorthOrSouth;
				TEastOrWest tEastOrWest;
				if (tQTreeNode.Children[1] == null)
				{
					tQTreeNode.Children[1] = new TQTreeNode<T>(tQTreeNode.Xmin, num, num2, tQTreeNode.Ymax, tQTreeNode, Tree);
					tQTreeNode.Children[0] = new TQTreeNode<T>(num, tQTreeNode.Xmax, num2, tQTreeNode.Ymax, tQTreeNode, Tree);
					tQTreeNode.Children[3] = new TQTreeNode<T>(tQTreeNode.Xmin, num, tQTreeNode.Ymin, num2, tQTreeNode, Tree);
					tQTreeNode.Children[2] = new TQTreeNode<T>(num, tQTreeNode.Xmax, tQTreeNode.Ymin, num2, tQTreeNode, Tree);
					int num3 = tQTreeNode.NumPts - 1;
					for (int i = 0; i <= num3; i++)
					{
						TQPoint<T> tQPoint = tQTreeNode.Pts[i];
						tNorthOrSouth = ((tQPoint.Y <= num2) ? TNorthOrSouth.South : TNorthOrSouth.North);
						tEastOrWest = ((tQPoint.X <= num) ? TEastOrWest.West : TEastOrWest.East);
						TQTreeNode<T> tQTreeNode2 = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
						tQTreeNode2.Pts[tQTreeNode2.NumPts] = tQPoint;
						tQTreeNode2.FNumPts++;
					}
					tQTreeNode.Pts = new TQPoint<T>[0];
				}
				tNorthOrSouth = ((double_1 <= num2) ? TNorthOrSouth.South : TNorthOrSouth.North);
				tEastOrWest = ((double_0 <= num) ? TEastOrWest.West : TEastOrWest.East);
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			int num4 = tQTreeNode.NumPts - 1;
			for (int j = 0; j <= num4; j++)
			{
				if ((tQTreeNode.Pts[j].X == double_0) & (tQTreeNode.Pts[j].Y == double_1))
				{
					tQTreeNode.Pts[j].Data.Add(Data);
					return;
				}
			}
			tQTreeNode.Pts[tQTreeNode.NumPts].X = double_0;
			tQTreeNode.Pts[tQTreeNode.NumPts].Y = double_1;
			tQTreeNode.Pts[tQTreeNode.NumPts].Data = new List<T>();
			tQTreeNode.Pts[tQTreeNode.NumPts].Data.Add(Data);
			tQTreeNode.NumPts++;
		}

		protected internal void Clear()
		{
			if (Children[0] != null)
			{
				TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
				do
				{
					TEastOrWest tEastOrWest = TEastOrWest.East;
					do
					{
						Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)].Clear();
						Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)] = null;
						tEastOrWest++;
					}
					while (tEastOrWest <= TEastOrWest.West);
					tNorthOrSouth++;
				}
				while (tNorthOrSouth <= TNorthOrSouth.South);
			}
			else
			{
				int num = NumPts - 1;
				for (int i = 0; i <= num; i++)
				{
					Pts[i].Data = null;
				}
				FNumPts = 0;
			}
		}

		protected void CheckNearbyLeaves(TQTreeNode<T> tqtreeNode_0, ref TQTreeNode<T> tqtreeNode_1, double double_0, double double_1, ref int int_0, ref double double_2, ref double double_3)
		{
			if (tqtreeNode_0 == this)
			{
				return;
			}
			if (Children[1] == null)
			{
				int int_ = 0;
				double double_4 = 0.0;
				NearPointInLeaf(double_0, double_1, ref int_, ref double_4);
				if ((int_ > -1) & ((double_2 > double_4) | (int_0 < 0)))
				{
					double_2 = double_4;
					double_3 = Math.Sqrt(double_2);
					tqtreeNode_1 = this;
					int_0 = int_;
				}
				return;
			}
			double num = Xmid();
			double num2 = Ymid();
			if (((int_0 < 0) | (double_0 - double_3 <= num)) && ((double_1 - double_3 <= num2) | (int_0 < 0)))
			{
				Children[3].CheckNearbyLeaves(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2, ref double_3);
			}
			if (((int_0 < 0) | (double_0 - double_3 <= num)) && ((double_1 + double_3 > num2) | (int_0 < 0)))
			{
				Children[1].CheckNearbyLeaves(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2, ref double_3);
			}
			if (((int_0 < 0) | (double_0 + double_3 > num)) && ((double_1 - double_3 <= num2) | (int_0 < 0)))
			{
				Children[2].CheckNearbyLeaves(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2, ref double_3);
			}
			if (((int_0 < 0) | (double_0 + double_3 > num)) && ((double_1 + double_3 > num2) | (int_0 < 0)))
			{
				Children[0].CheckNearbyLeaves(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2, ref double_3);
			}
		}

		protected void CheckNearbyLeavesGC(TQTreeNode<T> tqtreeNode_0, ref TQTreeNode<T> tqtreeNode_1, double double_0, double double_1, ref int int_0, ref double double_2)
		{
			if (tqtreeNode_0 == this)
			{
				return;
			}
			if (Children[1] == null)
			{
				int int_ = 0;
				double double_3 = 0.0;
				NearPointInLeafGC(double_0, double_1, ref int_, ref double_3);
				if ((int_ > -1) & ((double_2 > double_3) | (int_0 < 0)))
				{
					double_2 = double_3;
					tqtreeNode_1 = this;
					int_0 = int_;
				}
				return;
			}
			double num = Xmid();
			double num2 = Ymid();
			if (((int_0 < 0) | (double_0 - double_2 <= num)) && ((double_1 - double_2 <= num2) | (int_0 < 0)))
			{
				Children[3].CheckNearbyLeavesGC(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2);
			}
			if (((int_0 < 0) | (double_0 - double_2 <= num)) && ((double_1 + double_2 > num2) | (int_0 < 0)))
			{
				Children[1].CheckNearbyLeavesGC(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2);
			}
			if (((int_0 < 0) | (double_0 + double_2 > num)) && ((double_1 - double_2 <= num2) | (int_0 < 0)))
			{
				Children[2].CheckNearbyLeavesGC(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2);
			}
			if (((int_0 < 0) | (double_0 + double_2 > num)) && ((double_1 + double_2 > num2) | (int_0 < 0)))
			{
				Children[0].CheckNearbyLeavesGC(tqtreeNode_0, ref tqtreeNode_1, double_0, double_1, ref int_0, ref double_2);
			}
		}

		public TQTreeNode(TRbwQuadTree<T> trbwQuadTree_0)
		{
			Children = new TQTreeNode<T>[4];
			Parent = null;
			Xmin = 0.0;
			Xmax = 0.0;
			Ymin = 0.0;
			Ymax = 0.0;
			Tree = trbwQuadTree_0;
			TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
			do
			{
				TEastOrWest tEastOrWest = TEastOrWest.East;
				do
				{
					Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)] = null;
					tEastOrWest++;
				}
				while (tEastOrWest <= TEastOrWest.West);
				tNorthOrSouth++;
			}
			while (tNorthOrSouth <= TNorthOrSouth.South);
			FNumPts = 0;
			Pts = new TQPoint<T>[Tree.MaxPoints - 1 + 1];
		}

		public TQTreeNode(double double_0, double double_1, double double_2, double double_3, TQTreeNode<T> tqtreeNode_0, TRbwQuadTree<T> trbwQuadTree_0)
			: this(trbwQuadTree_0)
		{
			if (!(double_0 <= double_1) || !(double_2 <= double_3))
			{
				throw new Exception("Error: attempt to create a TQtreeNode with an invalid range.");
			}
			Parent = tqtreeNode_0;
			Xmin = double_0;
			Xmax = double_1;
			Ymin = double_2;
			Ymax = double_3;
		}

		public void ExpandBounds(double double_0, TExpandDirection texpandDirection_0)
		{
			switch (texpandDirection_0)
			{
			case TExpandDirection.edNorth:
				Ymax = double_0;
				if (Children[0] != null)
				{
					Children[0].ExpandBounds(double_0, texpandDirection_0);
					Children[1].ExpandBounds(double_0, texpandDirection_0);
				}
				break;
			case TExpandDirection.edSouth:
				Ymin = double_0;
				if (Children[0] != null)
				{
					Children[2].ExpandBounds(double_0, texpandDirection_0);
					Children[3].ExpandBounds(double_0, texpandDirection_0);
				}
				break;
			case TExpandDirection.edEast:
				Xmax = double_0;
				if (Children[0] != null)
				{
					Children[0].ExpandBounds(double_0, texpandDirection_0);
					Children[2].ExpandBounds(double_0, texpandDirection_0);
				}
				break;
			case TExpandDirection.edWest:
				Xmin = double_0;
				if (Children[0] != null)
				{
					Children[1].ExpandBounds(double_0, texpandDirection_0);
					Children[3].ExpandBounds(double_0, texpandDirection_0);
				}
				break;
			}
		}

		internal TQPoint<T> FindClosestPoint(double double_0, double double_1)
		{
			Stack<TQTreeNode<T>> stack_ = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> tqtreeNode_ = LocateLeaf(double_0, double_1, ref stack_);
			int int_ = 0;
			double double_2 = 0.0;
			tqtreeNode_.NearPointInLeaf(double_0, double_1, ref int_, ref double_2);
			if (int_ < 0)
			{
				while (stack_.Count > 0)
				{
					tqtreeNode_ = stack_.Pop().LocateLeaf(double_0, double_1, ref stack_);
					tqtreeNode_.NearPointInLeaf(double_0, double_1, ref int_, ref double_2);
					if (int_ >= 0)
					{
						break;
					}
				}
			}
			double double_3 = Math.Sqrt(double_2);
			CheckNearbyLeaves(tqtreeNode_, ref tqtreeNode_, double_0, double_1, ref int_, ref double_2, ref double_3);
			return tqtreeNode_.Pts[int_];
		}

		internal TQPoint<T> FindClosestPointGC(double double_0, double double_1)
		{
			Stack<TQTreeNode<T>> stack_ = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> tqtreeNode_ = LocateLeaf(double_0, double_1, ref stack_);
			int int_ = 0;
			double double_2 = 0.0;
			tqtreeNode_.NearPointInLeafGC(double_0, double_1, ref int_, ref double_2);
			if (int_ < 0)
			{
				while (stack_.Count > 0)
				{
					tqtreeNode_ = stack_.Pop().LocateLeaf(double_0, double_1, ref stack_);
					tqtreeNode_.NearPointInLeafGC(double_0, double_1, ref int_, ref double_2);
					if (int_ >= 0)
					{
						break;
					}
				}
			}
			CheckNearbyLeavesGC(tqtreeNode_, ref tqtreeNode_, double_0, double_1, ref int_, ref double_2);
			return tqtreeNode_.Pts[int_];
		}

		public void FindPoint(ref double double_0, ref double double_1, ref T gparam_0)
		{
			TQPoint<T> tQPoint = FindClosestPoint(double_0, double_1);
			double_0 = tQPoint.X;
			double_1 = tQPoint.Y;
			if (tQPoint.Data != null && tQPoint.Data.Count > 0)
			{
				gparam_0 = tQPoint.Data[0];
			}
			else
			{
				gparam_0 = default(T);
			}
		}

		public void FindClosestPointsData(ref double double_0, ref double double_1, ref T[] gparam_0)
		{
			TQPoint<T> tQPoint = FindClosestPoint(double_0, double_1);
			double_0 = tQPoint.X;
			double_1 = tQPoint.Y;
			gparam_0 = new T[tQPoint.Data.Count - 1 + 1];
			int num = tQPoint.Data.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				gparam_0[i] = tQPoint.Data[i];
			}
		}

		internal TQTreeNode<T> LocateLeaf(double double_0, double double_1, ref Stack<TQTreeNode<T>> stack_0)
		{
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.Children[1] != null)
			{
				TNorthOrSouth tNorthOrSouth = ((double_1 <= tQTreeNode.Ymid()) ? TNorthOrSouth.South : TNorthOrSouth.North);
				TEastOrWest tEastOrWest = ((double_0 <= tQTreeNode.Xmid()) ? TEastOrWest.West : TEastOrWest.East);
				TNorthOrSouth tNorthOrSouth2 = TNorthOrSouth.North;
				do
				{
					TEastOrWest tEastOrWest2 = TEastOrWest.East;
					do
					{
						if (tNorthOrSouth2 != tNorthOrSouth || tEastOrWest2 != tEastOrWest)
						{
							stack_0.Push(tQTreeNode.Children[(int)((int)tNorthOrSouth2 * 2 + tEastOrWest2)]);
						}
						tEastOrWest2++;
					}
					while (tEastOrWest2 <= TEastOrWest.West);
					tNorthOrSouth2++;
				}
				while (tNorthOrSouth2 <= TNorthOrSouth.South);
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			return tQTreeNode;
		}

		internal TQTreeNode<T> LocateLeafGC(double double_0, double double_1, ref Stack<TQTreeNode<T>> stack_0)
		{
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.Children[1] != null)
			{
				TNorthOrSouth tNorthOrSouth = ((double_1 <= tQTreeNode.Ymid()) ? TNorthOrSouth.South : TNorthOrSouth.North);
				TEastOrWest tEastOrWest = ((double_0 <= tQTreeNode.Xmid()) ? TEastOrWest.West : TEastOrWest.East);
				TNorthOrSouth tNorthOrSouth2 = TNorthOrSouth.North;
				do
				{
					TEastOrWest tEastOrWest2 = TEastOrWest.East;
					do
					{
						if (tNorthOrSouth2 != tNorthOrSouth || tEastOrWest2 != tEastOrWest)
						{
							stack_0.Push(tQTreeNode.Children[(int)((int)tNorthOrSouth2 * 2 + tEastOrWest2)]);
						}
						tEastOrWest2++;
					}
					while (tEastOrWest2 <= TEastOrWest.West);
					tNorthOrSouth2++;
				}
				while (tNorthOrSouth2 <= TNorthOrSouth.South);
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			return tQTreeNode;
		}

		public void NearPointInLeaf(double double_0, double double_1, ref int int_0, ref double double_2)
		{
			double_2 = 0.0;
			int_0 = -1;
			if (NumPts <= 0)
			{
				return;
			}
			double num = double_0 - Pts[0].X;
			double num2 = double_1 - Pts[0].Y;
			double_2 = num * num + num2 * num2;
			int_0 = 0;
			int num3 = NumPts - 1;
			for (int i = 1; i <= num3; i++)
			{
				num = double_0 - Pts[i].X;
				num2 = double_1 - Pts[i].Y;
				double num4 = num * num + num2 * num2;
				if (double_2 > num4)
				{
					int_0 = i;
					double_2 = num4;
				}
			}
		}

		public void NearPointInLeafGC(double double_0, double double_1, ref int int_0, ref double double_2)
		{
			double_2 = 0.0;
			int_0 = -1;
			if (NumPts <= 0)
			{
				return;
			}
			double_2 = Geodesic_Vincenty.RemoveInvocation(double_1, double_0, Pts[0].Y, Pts[0].X);
			int_0 = 0;
			int num = NumPts - 1;
			for (int i = 1; i <= num; i++)
			{
				double num2 = Geodesic_Vincenty.RemoveInvocation(double_1, double_0, Pts[i].Y, Pts[i].X);
				if (double_2 > num2)
				{
					int_0 = i;
					double_2 = num2;
				}
			}
		}

		internal double Xmid()
		{
			if (Children[1] != null)
			{
				return Children[1].Xmax;
			}
			return (Xmax + Xmin) / 2.0;
		}

		internal double Ymid()
		{
			if (Children[0] == null)
			{
				return (Ymax + Ymin) / 2.0;
			}
			return Children[0].Ymin;
		}

		public void RemovePoint(double double_0, double double_1, T Data)
		{
			if ((double_0 < Xmin) | (double_0 > Xmax) | (double_1 < Ymin) | (double_1 > Ymax))
			{
				return;
			}
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.Children[1] != null)
			{
				double num = tQTreeNode.Xmid();
				double num2 = tQTreeNode.Ymid();
				TNorthOrSouth tNorthOrSouth = ((double_1 <= num2) ? TNorthOrSouth.South : TNorthOrSouth.North);
				TEastOrWest tEastOrWest = ((double_0 <= num) ? TEastOrWest.West : TEastOrWest.East);
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			int num3 = tQTreeNode.NumPts - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (!((tQTreeNode.Pts[i].X == double_0) & (tQTreeNode.Pts[i].Y == double_1)))
				{
					continue;
				}
				tQTreeNode.Pts[i].Data.Remove(Data);
				if (tQTreeNode.Pts[i].Data.Count == 0)
				{
					int num4 = i + 1;
					int num5 = tQTreeNode.NumPts - 1;
					for (int j = num4; j <= num5; j++)
					{
						tQTreeNode.Pts[j - 1] = tQTreeNode.Pts[j];
					}
					tQTreeNode.Pts[i].Data = null;
					tQTreeNode.NumPts--;
				}
				break;
			}
		}

		public void FindPointsInCircle(double double_0, double double_1, double double_2, double double_3, ref List<TQPoint<T>> list_0)
		{
			if (Children[1] == null)
			{
				bool flag;
				if (flag = NumPts > 4)
				{
					double num = Xmax - double_0;
					double num7 = Ymax - double_1;
					if (num * num + num7 * num7 > double_3)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num8 = Xmax - double_0;
					double num9 = Ymin - double_1;
					if (num8 * num8 + num9 * num9 > double_3)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num10 = Xmin - double_0;
					double num11 = Ymax - double_1;
					if (num10 * num10 + num11 * num11 > double_3)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num12 = Xmin - double_0;
					double num13 = Ymin - double_1;
					if (num12 * num12 + num13 * num13 > double_3)
					{
						flag = false;
					}
				}
				if (flag)
				{
					int num14 = NumPts - 1;
					for (int i = 0; i <= num14; i++)
					{
						list_0.Add(Pts[i]);
					}
					return;
				}
				int num2 = NumPts - 1;
				for (int j = 0; j <= num2; j++)
				{
					TQPoint<T> tQPoint = Pts[j];
					double num3 = tQPoint.X - double_0;
					double num4 = tQPoint.Y - double_1;
					if (num3 * num3 + num4 * num4 <= double_3)
					{
						list_0.Add(Pts[j]);
					}
				}
				return;
			}
			double num5 = Xmid();
			double num6 = Ymid();
			if (double_0 - double_2 <= num5)
			{
				if (double_1 - double_2 <= num6)
				{
					Children[3].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
				}
				if (double_1 + double_2 >= num6)
				{
					Children[1].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
				}
			}
			if (double_0 + double_2 >= num5)
			{
				if (double_1 - double_2 <= num6)
				{
					Children[2].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
				}
				if (double_1 + double_2 >= num6)
				{
					Children[0].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
				}
			}
		}

		public void FindPointsInCircleGC(double double_0, double double_1, double double_2, double double_3, ref List<TQPoint<T>> list_0)
		{
			if (Children[1] != null)
			{
				double num = Xmid();
				double num7 = Ymid();
				if (double_0 - double_2 <= num)
				{
					if (double_1 - double_2 <= num7)
					{
						Children[3].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
					}
					if (double_1 + double_2 >= num7)
					{
						Children[1].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
					}
				}
				if (double_0 + double_2 >= num)
				{
					if (double_1 - double_2 <= num7)
					{
						Children[2].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
					}
					if (double_1 + double_2 >= num7)
					{
						Children[0].FindPointsInCircle(double_0, double_1, double_2, double_3, ref list_0);
					}
				}
				return;
			}
			bool flag;
			if (flag = NumPts > 4)
			{
				double num8 = Xmax - double_0;
				double num9 = Ymax - double_1;
				if (num8 * num8 + num9 * num9 > double_3)
				{
					flag = false;
				}
			}
			if (flag)
			{
				double num10 = Xmax - double_0;
				double num11 = Ymin - double_1;
				if (num10 * num10 + num11 * num11 > double_3)
				{
					flag = false;
				}
			}
			if (flag)
			{
				double num12 = Xmin - double_0;
				double num13 = Ymax - double_1;
				if (num12 * num12 + num13 * num13 > double_3)
				{
					flag = false;
				}
			}
			if (flag)
			{
				double num14 = Xmin - double_0;
				double num2 = Ymin - double_1;
				if (num14 * num14 + num2 * num2 > double_3)
				{
					flag = false;
				}
			}
			if (!flag)
			{
				int num3 = NumPts - 1;
				for (int i = 0; i <= num3; i++)
				{
					TQPoint<T> tQPoint = Pts[i];
					double num4 = tQPoint.X - double_0;
					double num5 = tQPoint.Y - double_1;
					if (num4 * num4 + num5 * num5 <= double_3)
					{
						list_0.Add(Pts[i]);
					}
				}
			}
			else
			{
				int num6 = NumPts - 1;
				for (int j = 0; j <= num6; j++)
				{
					list_0.Add(Pts[j]);
				}
			}
		}

		public void FindPointsInBlock(T2DBlock t2DBlock_0, ref List<TQPoint<T>> list_0)
		{
			if (Children[1] == null)
			{
				if (!((t2DBlock_0.XMin <= Xmin) & (t2DBlock_0.XMax >= Xmax) & (t2DBlock_0.YMin <= Ymin) & (t2DBlock_0.YMax >= Ymax)))
				{
					int num = NumPts - 1;
					for (int i = 0; i <= num; i++)
					{
						TQPoint<T> tQPoint = Pts[i];
						if ((t2DBlock_0.XMin <= tQPoint.X) & (t2DBlock_0.XMax >= tQPoint.X) & (t2DBlock_0.YMin <= tQPoint.Y) & (t2DBlock_0.YMax >= tQPoint.Y))
						{
							list_0.Add(Pts[i]);
						}
					}
				}
				else
				{
					int num2 = NumPts - 1;
					for (int j = 0; j <= num2; j++)
					{
						list_0.Add(Pts[j]);
					}
				}
				return;
			}
			double num3 = Xmid();
			double num4 = Ymid();
			if (t2DBlock_0.XMin <= num3)
			{
				if (t2DBlock_0.YMin <= num4)
				{
					Children[3].FindPointsInBlock(t2DBlock_0, ref list_0);
				}
				if (t2DBlock_0.YMax >= num4)
				{
					Children[1].FindPointsInBlock(t2DBlock_0, ref list_0);
				}
			}
			if (t2DBlock_0.XMax >= num3)
			{
				if (t2DBlock_0.YMin <= num4)
				{
					Children[2].FindPointsInBlock(t2DBlock_0, ref list_0);
				}
				if (t2DBlock_0.YMax >= num4)
				{
					Children[0].FindPointsInBlock(t2DBlock_0, ref list_0);
				}
			}
		}
	}

	[Serializable]
	public sealed class TRbwQuadTree<T>
	{
		private TQTreeNode<T> viPnUjcgOtW;

		private int int_0;

		private static object object_0;

		public int Count => GetCount();

		public int MaxPoints
		{
			get
			{
				return int_0;
			}
			set
			{
				if (Count == 0)
				{
					if (value <= 0)
					{
						throw new Exception("The maximum number of points in a Quadtree must be greater than zero.");
					}
					int_0 = value;
					viPnUjcgOtW.Pts = new TQPoint<T>[int_0 - 1 + 1];
					return;
				}
				throw new Exception("You must set the number of points before adding any points to a Quadtree.");
			}
		}

		public double XMax
		{
			get
			{
				return method_0();
			}
			set
			{
				method_4(value);
			}
		}

		public double XMin
		{
			get
			{
				return method_1();
			}
			set
			{
				method_5(value);
			}
		}

		public double YMax
		{
			get
			{
				return method_2();
			}
			set
			{
				method_6(value);
			}
		}

		public double Ymin
		{
			get
			{
				return method_3();
			}
			set
			{
				method_7(value);
			}
		}

		private double method_0()
		{
			return viPnUjcgOtW.Xmax;
		}

		private double method_1()
		{
			return viPnUjcgOtW.Xmin;
		}

		private double method_2()
		{
			return viPnUjcgOtW.Ymax;
		}

		private double method_3()
		{
			return viPnUjcgOtW.Ymin;
		}

		private void method_4(double double_0)
		{
			if (Count != 0)
			{
				if (double_0 < XMax)
				{
					throw new Exception("Error: The maximum X value can not be decreased, only increased.");
				}
				viPnUjcgOtW.ExpandBounds(double_0, TExpandDirection.edWest);
			}
			else
			{
				viPnUjcgOtW.Xmax = double_0;
			}
		}

		private void method_5(double double_0)
		{
			if (Count != 0)
			{
				if (double_0 > XMin)
				{
					throw new Exception("Error: The minimum X value can not be increased, only decreased.");
				}
				viPnUjcgOtW.ExpandBounds(double_0, TExpandDirection.edEast);
			}
			else
			{
				viPnUjcgOtW.Xmin = double_0;
			}
		}

		private void method_6(double double_0)
		{
			if (Count == 0)
			{
				viPnUjcgOtW.Ymax = double_0;
				return;
			}
			if (double_0 < YMax)
			{
				throw new Exception("Error: The maximum Y value can not be decreased, only increased.");
			}
			viPnUjcgOtW.ExpandBounds(double_0, TExpandDirection.edNorth);
		}

		private void method_7(double double_0)
		{
			if (Count != 0)
			{
				if (double_0 > Ymin)
				{
					throw new Exception("Error: The minimum Y value can not be increased, only decreased.");
				}
				viPnUjcgOtW.ExpandBounds(double_0, TExpandDirection.edSouth);
			}
			else
			{
				viPnUjcgOtW.Ymin = double_0;
			}
		}

		internal int GetCount()
		{
			return viPnUjcgOtW.NumPts;
		}

		internal TQuadPoint<T> GetPoints(int int_1)
		{
			TQuadPoint<T> result = default(TQuadPoint<T>);
			if (int_1 < 0)
			{
				throw new Exception("Invalid point index < 0.");
			}
			if (int_1 >= Count)
			{
				throw new Exception("Invalid point index >= Count.");
			}
			TQPoint<T> points = viPnUjcgOtW.GetPoints(int_1);
			result.X = points.X;
			result.Y = points.Y;
			result.Distance = 0.0;
			result.Data = new List<T>(points.Data.Count);
			int num = points.Data.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				result.Data.Add(points.Data[i]);
			}
			return result;
		}

		public void AddPoint(double double_0, double double_1, T Data)
		{
			viPnUjcgOtW.AddPoint(double_0, double_1, Data);
		}

		public void Clear()
		{
			viPnUjcgOtW.Clear();
			viPnUjcgOtW.FNumPts = 0;
			viPnUjcgOtW.Pts = new TQPoint<T>[MaxPoints - 1 + 1];
		}

		public TRbwQuadTree()
		{
			int_0 = 100;
			viPnUjcgOtW = new TQTreeNode<T>(this);
		}

		public void FindClosestPointsData(double double_0, double double_1, ref T[] gparam_0)
		{
			if (viPnUjcgOtW.NumPts <= 0)
			{
				throw new Exception("Error: No data points in QuadTree.");
			}
			viPnUjcgOtW.FindClosestPointsData(ref double_0, ref double_1, ref gparam_0);
		}

		public void FindNearestPoints(double double_0, double double_1, int int_1, ref TQuadPoint<T>[] tquadPoint_0)
		{
			List<TSelectNode<T>> list_ = new List<TSelectNode<T>>();
			TSelectNode<T> comparer = new TSelectNode<T>();
			viPnUjcgOtW.FindNearestPoints(double_0, double_1, int_1, ref list_);
			list_.Sort(comparer);
			if (list_.Count > Count)
			{
				comparer = list_[int_1 - 1];
				double distance = comparer.Distance;
				int count = Count;
				int num = list_.Count - 1;
				for (int i = count; i <= num; i++)
				{
					comparer = list_[i];
					if (comparer.Distance > distance)
					{
						list_.RemoveRange(i, list_.Count - i);
						break;
					}
				}
			}
			tquadPoint_0 = new TQuadPoint<T>[list_.Count - 1 + 1];
			int num2 = list_.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				comparer = list_[j];
				TQPoint<T> point = comparer.Point;
				tquadPoint_0[j].X = point.X;
				tquadPoint_0[j].Y = point.Y;
				tquadPoint_0[j].Distance = comparer.Distance;
				tquadPoint_0[j].Data = new List<T>(point.Data.Count);
				int num3 = point.Data.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					tquadPoint_0[j].Data.Add(point.Data[k]);
				}
			}
		}

		public void FindNearestPointsGC(double double_0, double double_1, int int_1, ref TQuadPoint<T>[] tquadPoint_0)
		{
			List<TSelectNode<T>> list_ = new List<TSelectNode<T>>();
			TSelectNode<T> comparer = new TSelectNode<T>();
			viPnUjcgOtW.FindNearestPointsGC(double_0, double_1, int_1, ref list_);
			list_.Sort(comparer);
			if (list_.Count > Count)
			{
				comparer = list_[int_1 - 1];
				double distance = comparer.Distance;
				int count = Count;
				int num = list_.Count - 1;
				for (int i = count; i <= num; i++)
				{
					comparer = list_[i];
					if (comparer.Distance > distance)
					{
						list_.RemoveRange(i, list_.Count - i);
						break;
					}
				}
			}
			tquadPoint_0 = new TQuadPoint<T>[list_.Count - 1 + 1];
			int num2 = list_.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				comparer = list_[j];
				TQPoint<T> point = comparer.Point;
				tquadPoint_0[j].X = point.X;
				tquadPoint_0[j].Y = point.Y;
				tquadPoint_0[j].Distance = comparer.Distance;
				tquadPoint_0[j].Data = new List<T>(point.Data.Count);
				int num3 = point.Data.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					tquadPoint_0[j].Data.Add(point.Data[k]);
				}
			}
		}

		public void FindPointsInBlock(T2DBlock t2DBlock_0, ref GStruct2<T>[] gstruct2_0)
		{
			List<TQPoint<T>> list_ = new List<TQPoint<T>>();
			list_.Capacity = Count;
			viPnUjcgOtW.FindPointsInBlock(t2DBlock_0, ref list_);
			gstruct2_0 = new GStruct2<T>[list_.Count - 1 + 1];
			int num = list_.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				TQPoint<T> tQPoint = list_[i];
				gstruct2_0[i].X = tQPoint.X;
				gstruct2_0[i].Y = tQPoint.Y;
				gstruct2_0[i].Data = new List<T>(tQPoint.Data.Count);
				int num2 = tQPoint.Data.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					gstruct2_0[i].Data.Add(tQPoint.Data[j]);
				}
			}
		}

		public void FindPointsInCircle(double double_0, double double_1, double double_2, ref GStruct2<T>[] gstruct2_0)
		{
			List<TQPoint<T>> list_ = new List<TQPoint<T>>();
			viPnUjcgOtW.FindPointsInCircle(double_0, double_1, double_2, double_2 * double_2, ref list_);
			gstruct2_0 = new GStruct2<T>[list_.Count - 1 + 1];
			int num = list_.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				TQPoint<T> tQPoint = list_[i];
				gstruct2_0[i].X = tQPoint.X;
				gstruct2_0[i].Y = tQPoint.Y;
				gstruct2_0[i].Data = new List<T>(tQPoint.Data.Count);
				int num2 = tQPoint.Data.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					gstruct2_0[i].Data.Add(tQPoint.Data[j]);
				}
			}
		}

		public void FirstNearestPoint(ref double double_0, ref double double_1, ref T gparam_0)
		{
			if (viPnUjcgOtW.NumPts <= 0)
			{
				throw new Exception("Error: No data points in QuadTree.");
			}
			viPnUjcgOtW.FindPoint(ref double_0, ref double_1, ref gparam_0);
		}

		internal T NearestPointsFirstData(double double_0, double double_1)
		{
			T gparam_ = default(T);
			if (viPnUjcgOtW.NumPts > 0)
			{
				FirstNearestPoint(ref double_0, ref double_1, ref gparam_);
			}
			return gparam_;
		}

		public void RemovePoint(double double_0, double double_1, T Data)
		{
			viPnUjcgOtW.RemovePoint(double_0, double_1, Data);
		}
	}

	[Serializable]
	public sealed class TSelectNode<T> : IComparer<TSelectNode<T>>
	{
		public double Distance;

		public TQPoint<T> Point;

		private static object object_0;

		public int Compare(TSelectNode<T> x, TSelectNode<T> y)
		{
			double num = y.Distance - x.Distance;
			if (num > 0.0)
			{
				return -1;
			}
			if (num < 0.0)
			{
				return 1;
			}
			return 0;
		}
	}
}
