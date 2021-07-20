
namespace GradientDescent.Solvers
{
    using Functions;
    using Functions.Regularizations;
    using GradientDescent.Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    public static class GdLogitSolver
    {
        public static Vector<double> Solve(Matrix<double> X, Vector<double> y, double lambda, IPacer pacer)
        {
            IFunction function = new LogisticFunction(X, y);
            function = new L1Regularization(function, lambda);

            return GdSolver.Solve(function, y.Count, pacer);
        }
    }
}
