
namespace GradientDescent.Functions.Regularizations
{
    using System;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    public class L2Regularization : IFunction
    {
        private readonly IFunction innerFunction;
        private readonly double lambda;

        public L2Regularization(IFunction innerFunction, double lambda)
        {
            this.innerFunction = innerFunction;
            this.lambda = lambda;
        }

        public double Evaluate(Vector<double> x)
        {
            var reg = lambda * Math.Pow(x.L2Norm(), 2);
            return innerFunction.Evaluate(x) + reg;
        }

        public Vector<double> Gradient(Vector<double> w)
        {
            return innerFunction.Gradient(w) + (lambda * w);
        }
    }
}
