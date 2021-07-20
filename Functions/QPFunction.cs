
namespace GradientDescent.Functions
{
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;
    using System;

    public class QPFunction : IFunction
    {
        private readonly Matrix<double> Q;
        private readonly Vector<double> b;
        private readonly double c;

        public QPFunction(Matrix<double> Q, Vector<double> b, double c)
        {
            this.Q = Q;
            this.b = b;
            this.c = c;
        }

        public Vector<double> Gradient(Vector<double> w)
        {
            Matrix<double> QTQ = Q.Transpose() + Q;
            return (QTQ.Multiply(w.ToColumnMatrix()) + b.ToColumnMatrix()).Column(0);
        }

        public double Evaluate(Vector<double> x)
        {
            var result = x.ToRowMatrix().Multiply(Q.Multiply(x.ToColumnMatrix())) + b.DotProduct(x) + c;
            if (result.RowCount > 1 || result.ColumnCount > 1)
            {
                throw new ArithmeticException();
            }
            return result.At(0, 0);
        }
    }
}
