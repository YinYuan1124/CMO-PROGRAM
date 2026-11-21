using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface IDoubleIntegrator
{
	double Integrate(MathFunctions.UnaryFunction<double> unaryFunction_0, double double_0, double double_1);
}
