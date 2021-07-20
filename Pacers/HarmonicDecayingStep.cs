
namespace GradientDescent.Pacers
{
    using Interfaces;
    using MathNet.Numerics.LinearAlgebra;

    public class HarmonicDecayingStep : IPacer
    {
        private double factor;
        private int iteration;

        public HarmonicDecayingStep(double multiplicativeFactor)
        {
            factor = multiplicativeFactor;
            iteration = 1;
        }
        public double GetNextStepSize(IFunction function, Vector<double> location)
        {
            double step = factor / iteration;
            iteration++;
            return step;
        }
    }
}
