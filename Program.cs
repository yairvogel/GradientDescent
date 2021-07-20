
namespace GradientDescent
{
    using System;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;
    using Pacers;
    using Solvers;

    class Program
    {
        static void Main(string[] args)
        {
            // create matrix inputs
            Matrix<double> X = CreateMatrix.DenseOfArray(new double[,] { { 1, 0, 1 }, { 0, 1, 0 }, { 1, 1, 1 } });
            Vector<double> y = CreateVector.DenseOfArray(new double[] { 1, 0, 1 });

            
            IPacer pacer = new LineSearchStep(.2, .9);

            var res = GdLogitSolver.Solve(X, y, .0, pacer);

            Console.WriteLine(res);
        }
    }
}
