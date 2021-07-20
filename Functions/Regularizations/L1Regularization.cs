
namespace GradientDescent.Functions.Regularizations
{
    using System.Linq;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    class L1Regularization : IFunction
    {
        private readonly IFunction innerFunction;
        private readonly double lambda;

        public L1Regularization(IFunction innerFunction, double lambda)
        {
            this.innerFunction = innerFunction;
            this.lambda = lambda;
        }
        public double Evaluate(Vector<double> x)
        {
            return innerFunction.Evaluate(x) + lambda * x.L1Norm();
        }

        public Vector<double> Gradient(Vector<double> w)
        {
            return innerFunction.Gradient(w) + GetLassoSubGradient(w);
        }

        private Vector<double> GetLassoSubGradient(Vector<double> w)
        {
            return CreateVector.DenseOfArray(w.Select(LassoSign).ToArray());
        }

        private double LassoSign(double entry)
        {
            if (entry > 0) return 1;
            if (entry < 0) return -1;
            return 0;
        }
    }
}
