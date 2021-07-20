
namespace GradientDescent.Interfaces
{
    using MathNet.Numerics.LinearAlgebra;
    public interface IPacer
    {
        double GetNextStepSize(IFunction function, Vector<double> location);
    }
}