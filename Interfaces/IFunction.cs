namespace GradientDescent.Interfaces
{
    using MathNet.Numerics.LinearAlgebra;

    public interface IFunction
    {
        double Evaluate(Vector<double> x);

        Vector<double> Gradient(Vector<double> w);
    }
}