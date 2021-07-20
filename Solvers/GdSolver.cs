
namespace GradientDescent.Solvers
{
    using System;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    internal static class GdSolver
    {
        private static readonly double precision = Math.Pow(10, -3);

        internal static Vector<double> Solve(IFunction function, int dimension, IPacer stepProvider)
        {
            Vector<double> location = CreateVector.Random<double>(dimension) * 1;

            int i = 0;
            while (true)
            {
                i++;
                var gradient = function.Gradient(location);

                if (gradient.L2Norm() <= precision)
                {
                    Console.WriteLine($"finished after {i} steps");
                    return location;
                }

                var eta = stepProvider.GetNextStepSize(function, location);

                location -= eta * gradient;
            }
        }
    }
}
