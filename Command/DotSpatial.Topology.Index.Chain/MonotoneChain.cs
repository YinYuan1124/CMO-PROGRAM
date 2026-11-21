using System.Collections.Generic;

namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChain
{
	private readonly object m_IdentifierCollection;

	private readonly int m_PrinterCollection;

	private readonly IList<Coordinate> m_ParserCollection;

	private readonly int m_AlgoCollection;

	private Envelope databaseCollection;

	private int interceptorCollection;

	public virtual int Id
	{
		get
		{
			return interceptorCollection;
		}
		set
		{
			interceptorCollection = value;
		}
	}

	public virtual object Context => m_IdentifierCollection;

	public virtual Envelope Envelope
	{
		get
		{
			if (databaseCollection == null)
			{
				Coordinate coordinate_ = m_ParserCollection[m_AlgoCollection];
				Coordinate coordinate_2 = m_ParserCollection[m_PrinterCollection];
				databaseCollection = new Envelope(coordinate_, coordinate_2);
			}
			return databaseCollection;
		}
	}

	public virtual int StartIndex => m_AlgoCollection;

	public virtual int EndIndex => m_PrinterCollection;

	public virtual Coordinate[] Coordinates
	{
		get
		{
			Coordinate[] array = new Coordinate[m_PrinterCollection - m_AlgoCollection + 1];
			int num = 0;
			for (int i = m_AlgoCollection; i <= m_PrinterCollection; i++)
			{
				array[num++] = m_ParserCollection[i];
			}
			return array;
		}
	}

	public MonotoneChain(IList<Coordinate> ilist_0, int int_0, int int_1, object object_0)
	{
		m_ParserCollection = ilist_0;
		m_AlgoCollection = int_0;
		m_PrinterCollection = int_1;
		m_IdentifierCollection = object_0;
	}

	public virtual LineSegment GetLineSegment(int int_0)
	{
		return new LineSegment(m_ParserCollection[int_0], m_ParserCollection[int_0 + 1]);
	}

	public virtual void Select(IEnvelope ienvelope_0, MonotoneChainSelectAction monotoneChainSelectAction_0)
	{
		PopParameter(ienvelope_0, m_AlgoCollection, m_PrinterCollection, monotoneChainSelectAction_0);
	}

	private void PopParameter(IEnvelope ienvelope_0, int int_0, int int_1, MonotoneChainSelectAction monotoneChainSelectAction_0)
	{
		Coordinate coordinate_ = m_ParserCollection[int_0];
		Coordinate coordinate_2 = m_ParserCollection[int_1];
		monotoneChainSelectAction_0.TempEnv1.Init(coordinate_, coordinate_2);
		if (int_1 - int_0 == 1)
		{
			monotoneChainSelectAction_0.Select(this, int_0);
		}
		else if (ienvelope_0.Intersects(monotoneChainSelectAction_0.TempEnv1))
		{
			int num = (int_0 + int_1) / 2;
			if (int_0 < num)
			{
				PopParameter(ienvelope_0, int_0, num, monotoneChainSelectAction_0);
			}
			if (num < int_1)
			{
				PopParameter(ienvelope_0, num, int_1, monotoneChainSelectAction_0);
			}
		}
	}

	public virtual void ComputeOverlaps(MonotoneChain monotoneChain_0, MonotoneChainOverlapAction monotoneChainOverlapAction_0)
	{
		InstantiateParameter(m_AlgoCollection, m_PrinterCollection, monotoneChain_0, monotoneChain_0.m_AlgoCollection, monotoneChain_0.m_PrinterCollection, monotoneChainOverlapAction_0);
	}

	private void InstantiateParameter(int int_0, int int_1, MonotoneChain monotoneChain_0, int int_2, int int_3, MonotoneChainOverlapAction monotoneChainOverlapAction_0)
	{
		Coordinate coordinate_ = m_ParserCollection[int_0];
		Coordinate coordinate_2 = m_ParserCollection[int_1];
		Coordinate coordinate_3 = monotoneChain_0.m_ParserCollection[int_2];
		Coordinate coordinate_4 = monotoneChain_0.m_ParserCollection[int_3];
		if (int_1 - int_0 == 1 && int_3 - int_2 == 1)
		{
			monotoneChainOverlapAction_0.Overlap(this, int_0, monotoneChain_0, int_2);
			return;
		}
		monotoneChainOverlapAction_0.TempEnv1.Init(coordinate_, coordinate_2);
		monotoneChainOverlapAction_0.TempEnv2.Init(coordinate_3, coordinate_4);
		if (!monotoneChainOverlapAction_0.TempEnv1.Intersects(monotoneChainOverlapAction_0.TempEnv2))
		{
			return;
		}
		int num = (int_0 + int_1) / 2;
		int num2 = (int_2 + int_3) / 2;
		if (int_0 < num)
		{
			if (int_2 < num2)
			{
				InstantiateParameter(int_0, num, monotoneChain_0, int_2, num2, monotoneChainOverlapAction_0);
			}
			if (num2 < int_3)
			{
				InstantiateParameter(int_0, num, monotoneChain_0, num2, int_3, monotoneChainOverlapAction_0);
			}
		}
		if (num < int_1)
		{
			if (int_2 < num2)
			{
				InstantiateParameter(num, int_1, monotoneChain_0, int_2, num2, monotoneChainOverlapAction_0);
			}
			if (num2 < int_3)
			{
				InstantiateParameter(num, int_1, monotoneChain_0, num2, int_3, monotoneChainOverlapAction_0);
			}
		}
	}
}
