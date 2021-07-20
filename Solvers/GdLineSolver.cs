

namespace GradientDescent.Solvers
{
    using Functions;
    using Functions.Regularizations;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;
    using Pacers;

    /// <summary>
    /// Solver for linear regression
    /// </summary>
    public static class GdLinSolver
    {
        public static Vector<double> SolveRidge(Matrix<double> X, Vector<double> y, double lambda = 0, IPacer pacer = null)
        {
            IFunction function = new LeastSquares(X, y);
            function = new L2Regularization(function, lambda);

            if (pacer is null)
            {
                pacer = new LineSearchStep(.4, .7);
            }

            return GdSolver.Solve(function, X.ColumnCount, pacer);
        }

        public static Vector<double> SolveLasso(Matrix<double> X, Vector<double> y, double lambda = 0, IPacer pacer = null)
        {
            IFunction function = new LeastSquares(X, y);
            function = new L1Regularization(function, lambda);

            if (pacer is null)
            {
                pacer = new HarmonicDecayingStep(1);
            }

            return GdSolver.Solve(function, X.ColumnCount, pacer);
        }
    }
}
