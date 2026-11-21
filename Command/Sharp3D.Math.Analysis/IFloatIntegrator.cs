using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface IFloatIntegrator
{
	float Integrate(MathFunctions.UnaryFunction<float> unaryFunction_0, float float_0, float float_1);
}
