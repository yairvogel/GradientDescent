using GradientDescent.Interfaces;
using MathNet.Numerics.LinearAlgebra;

namespace GradientDescent.Pacers
{
    class FixedStep : IPacer
    {
        private double eta;

        public FixedStep(double step)
        {
            eta = step;
        }

        public double GetNextStepSize(IFunction function, Vector<double> location)
        {
            return eta;
        }
    }
}
