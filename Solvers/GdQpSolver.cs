
namespace GradientDescent.Solvers
{
    using System;
    using Functions;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;
    
    public static class GdQpSolver
    {
        public static Vector<double> Solve(Matrix<double> Q, Vector<double> b, double c, IPacer stepProvider)
        {
            if (Q.RowCount != Q.ColumnCount || Q.RowCount != b.Count)
            {
                throw new ArgumentException();
            }

            QPFunction qpFunc = new QPFunction(Q, b, c);
            return GdSolver.Solve(qpFunc, Q.RowCount, stepProvider);
        }
    }
}
