using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Noding;

public class ScaledNoder : INoder
{
	private readonly bool _InstanceCollection;

	private readonly INoder _ObjectCollection;

	private readonly double _ParameterCollection;

	private readonly double expressionCollection;

	private readonly double _DispatcherCollection;

	[SpecialName]
	private bool AwakeObject()
	{
		return _DispatcherCollection == 1.0;
	}

	public ScaledNoder(INoder inoder_0, double double_0)
		: this(inoder_0, double_0, 0.0, 0.0)
	{
	}

	public ScaledNoder(INoder inoder_0, double double_0, double double_1, double double_2)
	{
		_ParameterCollection = double_1;
		expressionCollection = double_2;
		_ObjectCollection = inoder_0;
		_DispatcherCollection = double_0;
		_InstanceCollection = !AwakeObject();
	}

	public IList GetNodedSubstrings()
	{
		IList nodedSubstrings = _ObjectCollection.GetNodedSubstrings();
		if (_InstanceCollection)
		{
			AssetObject(nodedSubstrings);
		}
		return nodedSubstrings;
	}

	public void ComputeNodes(IList ilist_0)
	{
		IList ilist_ = ilist_0;
		if (_InstanceCollection)
		{
			ilist_ = RunObject(ilist_0);
		}
		_ObjectCollection.ComputeNodes(ilist_);
	}

	private IList RunObject(ICollection icollection_0)
	{
		return CollectionUtil.Transform(icollection_0, delegate(object object_0)
		{
			SegmentString segmentString = (SegmentString)object_0;
			return new SegmentString(StartObject(segmentString.Coordinates), segmentString.Data);
		});
	}

	private Coordinate[] StartObject(IList<Coordinate> ilist_0)
	{
		Coordinate[] array = new Coordinate[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			array[i] = new Coordinate(Math.Round((ilist_0[i].X - _ParameterCollection) * _DispatcherCollection), Math.Round((ilist_0[i].Y - expressionCollection) * _DispatcherCollection));
		}
		return array;
	}

	private void AssetObject(ICollection icollection_0)
	{
		CollectionUtil.Apply(icollection_0, delegate(object object_0)
		{
			SegmentString segmentString = (SegmentString)object_0;
			PrintObject(segmentString.Coordinates);
			return (object)null;
		});
	}

	private void PrintObject(IList<Coordinate> ilist_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			ilist_0[i].X = ilist_0[i].X / _DispatcherCollection + _ParameterCollection;
			ilist_0[i].Y = ilist_0[i].Y / _DispatcherCollection + expressionCollection;
		}
	}

	[CompilerGenerated]
	private object DefineObject(object object_0)
	{
		SegmentString segmentString = (SegmentString)object_0;
		return new SegmentString(StartObject(segmentString.Coordinates), segmentString.Data);
	}

	[CompilerGenerated]
	private object PublishObject(object object_0)
	{
		SegmentString segmentString = (SegmentString)object_0;
		PrintObject(segmentString.Coordinates);
		return null;
	}
}
