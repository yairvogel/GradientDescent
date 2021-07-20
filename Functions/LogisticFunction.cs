
namespace GradientDescent.Functions
{
    using System;
    using System.Linq;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    public class LogisticFunction : IFunction
    {
        private readonly Matrix<double> X;
        private readonly Vector<double> y;

        public LogisticFunction(Matrix<double> X, Vector<double> y)
        {
            this.X = X;
            this.y = y;
        }

        public double Evaluate(Vector<double> w)
        {
            return X.EnumerateRows().Zip(y).Select(pair =>
            {
                (Vector<double> xi, double yi) = pair;
                return -yi * xi.DotProduct(w) + Math.Log(1 + Math.Exp(xi.DotProduct(w)));
            }).Sum();
        }

        public Vector<double> Gradient(Vector<double> w)
        {
            return X.EnumerateRows().Zip(y).Select(pair =>
            {
                (Vector<double> xi, double yi) = pair;
                var exiw = Math.Exp(xi.DotProduct(w));
                return (-yi + (exiw / (1 + exiw))) * xi;
            }).Aggregate((vec1, vec2) => vec1 + vec2);
        }
    }
}
