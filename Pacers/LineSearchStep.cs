
namespace GradientDescent.Pacers
{
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    class LineSearchStep : IPacer
    {

        private double alpha;
        private double learningRate;

        public LineSearchStep(double alpha, double learningRate)
        {
            this.alpha = alpha;
            this.learningRate = learningRate;
        }

        public double GetNextStepSize(IFunction function, Vector<double> location)
        {
            double eta = 1;

            while (LinearApproximation(function, location, eta) < function.Evaluate(location + eta * -function.Gradient(location)))
            {
                eta *= learningRate;
            }

            return eta;
        }

        private double LinearApproximation(IFunction function, Vector<double> location, double stepSize)
        {
            var value = function.Evaluate(location);
            var gradient = function.Gradient(location);

            return value + (alpha * stepSize * gradient.DotProduct(-gradient));
        }
    }
}
