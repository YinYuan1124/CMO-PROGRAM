using System.Collections.Generic;

namespace Simplifynet;

public interface ISimplifyUtility
{
	List<Point> Simplify(Point[] point_0, double double_0 = 0.3, bool bool_0 = false);
}
