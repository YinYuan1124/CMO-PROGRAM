using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.KDTree;

public class KdNode
{
	internal readonly HPoint _ModelCollection;

	internal KdNode Left;

	internal KdNode Right;

	internal object m_AdvisorCollection;

	private bool m_CustomerCollection;

	public bool IsDeleted
	{
		get
		{
			return m_CustomerCollection;
		}
		set
		{
			m_CustomerCollection = value;
		}
	}

	private KdNode(HPoint hpoint_0, object object_0)
	{
		_ModelCollection = hpoint_0;
		m_AdvisorCollection = object_0;
		Left = null;
		Right = null;
		m_CustomerCollection = false;
	}

	public string ToString(int int_0)
	{
		string text = ((object)_ModelCollection)?.ToString() + "  " + m_AdvisorCollection?.ToString() + (m_CustomerCollection ? "*" : string.Empty);
		if (Left != null)
		{
			text = text + "\n" + SelectParameter(int_0) + "L " + Left.ToString(int_0 + 1);
		}
		if (Right != null)
		{
			text = text + "\n" + SelectParameter(int_0) + "R " + Right.ToString(int_0 + 1);
		}
		return text;
	}

	public static KdNode Insert(HPoint hpoint_0, object object_0, KdNode kdNode_0, int int_0, int int_1)
	{
		if (kdNode_0 == null)
		{
			kdNode_0 = new KdNode(hpoint_0, object_0);
		}
		else if (hpoint_0.Equals(kdNode_0._ModelCollection))
		{
			if (!kdNode_0.IsDeleted)
			{
				throw new KeyDuplicateException();
			}
			kdNode_0.IsDeleted = false;
			kdNode_0.m_AdvisorCollection = object_0;
		}
		else if (hpoint_0[int_0] <= kdNode_0._ModelCollection[int_0])
		{
			kdNode_0.Left = Insert(hpoint_0, object_0, kdNode_0.Left, (int_0 + 1) % int_1, int_1);
		}
		else
		{
			kdNode_0.Right = Insert(hpoint_0, object_0, kdNode_0.Right, (int_0 + 1) % int_1, int_1);
		}
		return kdNode_0;
	}

	public static KdNode Search(HPoint hpoint_0, KdNode kdNode_0, int int_0)
	{
		int num = 0;
		while (true)
		{
			if (kdNode_0 != null)
			{
				if (!kdNode_0.IsDeleted && hpoint_0.Equals(kdNode_0._ModelCollection))
				{
					break;
				}
				kdNode_0 = ((hpoint_0[num] <= kdNode_0._ModelCollection[num]) ? kdNode_0.Left : kdNode_0.Right);
				num = (num + 1) % int_0;
				continue;
			}
			return null;
		}
		return kdNode_0;
	}

	public static void SearchRange(HPoint hpoint_0, HPoint hpoint_1, KdNode kdNode_0, int int_0, int int_1, List<KdNode> list_0)
	{
		if (kdNode_0 != null)
		{
			if (hpoint_0[int_0] <= kdNode_0._ModelCollection[int_0])
			{
				SearchRange(hpoint_0, hpoint_1, kdNode_0.Left, (int_0 + 1) % int_1, int_1, list_0);
			}
			int i;
			for (i = 0; i < int_1 && hpoint_0[i] <= kdNode_0._ModelCollection[i] && hpoint_1[i] >= kdNode_0._ModelCollection[i]; i++)
			{
			}
			if (i == int_1)
			{
				list_0.Add(kdNode_0);
			}
			if (hpoint_1[int_0] > kdNode_0._ModelCollection[int_0])
			{
				SearchRange(hpoint_0, hpoint_1, kdNode_0.Right, (int_0 + 1) % int_1, int_1, list_0);
			}
		}
	}

	public static void Nnbr(KdNode kdNode_0, HPoint hpoint_0, HRect hrect_0, double double_0, int int_0, int int_1, NearestNeighborList nearestNeighborList_0)
	{
		if (kdNode_0 == null)
		{
			return;
		}
		int int_2 = int_0 % int_1;
		HPoint modelCollection = kdNode_0._ModelCollection;
		double num = HPoint.SquareDistance(modelCollection, hpoint_0);
		HRect hRect = hrect_0.Copy();
		hrect_0.containerCollection[int_2] = modelCollection[int_2];
		hRect.m_ComposerCollection[int_2] = modelCollection[int_2];
		KdNode kdNode_;
		HRect hrect_;
		KdNode kdNode_2;
		HRect hRect2;
		if (hpoint_0[int_2] < modelCollection[int_2])
		{
			kdNode_ = kdNode_0.Left;
			hrect_ = hrect_0;
			kdNode_2 = kdNode_0.Right;
			hRect2 = hRect;
		}
		else
		{
			kdNode_ = kdNode_0.Right;
			hrect_ = hRect;
			kdNode_2 = kdNode_0.Left;
			hRect2 = hrect_0;
		}
		Nnbr(kdNode_, hpoint_0, hrect_, double_0, int_0 + 1, int_1, nearestNeighborList_0);
		double num2 = (nearestNeighborList_0.IsCapacityReached ? nearestNeighborList_0.MaxPriority : 1.79769E+30);
		double_0 = Math.Min(double_0, num2);
		if (HPoint.EuclideanDistance(hRect2.Closest(hpoint_0), hpoint_0) < Math.Sqrt(double_0))
		{
			if (num < num2)
			{
				num2 = num;
				if (!kdNode_0.IsDeleted)
				{
					nearestNeighborList_0.Insert(kdNode_0, num2);
				}
				double_0 = (nearestNeighborList_0.IsCapacityReached ? nearestNeighborList_0.MaxPriority : 1.79769E+30);
			}
			Nnbr(kdNode_2, hpoint_0, hRect2, double_0, int_0 + 1, int_1, nearestNeighborList_0);
			double maxPriority = nearestNeighborList_0.MaxPriority;
			if (maxPriority < num2)
			{
				num2 = maxPriority;
			}
		}
		else if (num < double_0)
		{
			num2 = num;
		}
	}

	public static void FarthestNeighbor(KdNode kdNode_0, HPoint hpoint_0, HRect hrect_0, double double_0, int int_0, int int_1, FarthestNeighborList farthestNeighborList_0)
	{
		if (kdNode_0 == null)
		{
			return;
		}
		int int_2 = int_0 % int_1;
		HPoint modelCollection = kdNode_0._ModelCollection;
		double num = HPoint.SquareDistance(modelCollection, hpoint_0);
		HRect hRect = hrect_0.Copy();
		hrect_0.containerCollection[int_2] = modelCollection[int_2];
		hRect.m_ComposerCollection[int_2] = modelCollection[int_2];
		KdNode kdNode_;
		HRect hRect2;
		KdNode kdNode_2;
		HRect hrect_;
		if (hpoint_0[int_2] < modelCollection[int_2])
		{
			kdNode_ = kdNode_0.Left;
			hRect2 = hrect_0;
			kdNode_2 = kdNode_0.Right;
			hrect_ = hRect;
		}
		else
		{
			kdNode_ = kdNode_0.Right;
			hRect2 = hRect;
			kdNode_2 = kdNode_0.Left;
			hrect_ = hrect_0;
		}
		FarthestNeighbor(kdNode_2, hpoint_0, hrect_, double_0, int_0 + 1, int_1, farthestNeighborList_0);
		double num2 = (farthestNeighborList_0.IsCapacityReached ? farthestNeighborList_0.MinimumPriority : 0.0);
		double_0 = Math.Max(double_0, num2);
		if (HPoint.EuclideanDistance(hRect2.Farthest(hpoint_0), hpoint_0) <= Math.Sqrt(double_0))
		{
			if (num < double_0)
			{
				num2 = num;
			}
			return;
		}
		if (num > num2)
		{
			num2 = num;
			if (!kdNode_0.IsDeleted)
			{
				farthestNeighborList_0.Insert(kdNode_0, num2);
			}
			double_0 = (farthestNeighborList_0.IsCapacityReached ? farthestNeighborList_0.MinimumPriority : 0.0);
		}
		FarthestNeighbor(kdNode_, hpoint_0, hRect2, double_0, int_0 + 1, int_1, farthestNeighborList_0);
		double minimumPriority = farthestNeighborList_0.MinimumPriority;
		if (minimumPriority > num2)
		{
			num2 = minimumPriority;
		}
	}

	private static string SelectParameter(int int_0)
	{
		string text = string.Empty;
		for (int i = 0; i < int_0; i++)
		{
			text += " ";
		}
		return text;
	}
}
