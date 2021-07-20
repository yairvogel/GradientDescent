
namespace GradientDescent.Functions
{
    using System;
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    class LeastSquares : IFunction
    {
        private readonly Matrix<double> X;
        private readonly Vector<double> y;

        public LeastSquares(Matrix<double> X, Vector<double> y)
        {
            this.X = X;
            this.y = y;
        }
        public double Evaluate(Vector<double> x)
        {
            return Math.Pow((y - X.Multiply(x.ToColumnMatrix()).Column(0)).L2Norm(), 2);
        }

        public Vector<double> Gradient(Vector<double> w)
        {
            Matrix<double> XtXw = X.Transpose().Multiply(X).Multiply(w.ToColumnMatrix());
            Matrix<double> Xty = X.Transpose().Multiply(y.ToColumnMatrix());
            Matrix<double> res = XtXw - Xty;
            if (res.ColumnCount > 1)
            {
                throw new ArithmeticException();
            }

            return res.Column(0);
        }
    }
}
