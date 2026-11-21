using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface IDoubleDifferentiator
{
	double Differentiate(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0);
}
