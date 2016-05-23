using System;

namespace RefactoringExamples.SplitTemporaryVariable
{
    public class Haggis
    {
        private readonly double _primaryForce;
        private readonly double _mass;
        private readonly int _delay;
        private readonly double _secondaryForce;

        public Haggis(double primaryForce, double mass, int delay, double secondaryForce)
        {
            _primaryForce = primaryForce;
            _mass = mass;
            _delay = delay;
            _secondaryForce = secondaryForce;
        }

        public double GetDistanceTravelled(int time)
        {
            double result;
            var acc = _primaryForce/_mass;
            var primaryTime = Math.Min(time, _delay);
            result = 0.5*acc*primaryTime*primaryTime;
            var secondaryTime = time - _delay;
            if (secondaryTime > 0)
            {
                var primaryVel = acc*_delay;
                acc = (_primaryForce + _secondaryForce)/_mass;
                result += primaryVel*secondaryTime + 0.5*acc*secondaryTime*secondaryTime;
            }
            return result;
        }
    }
}