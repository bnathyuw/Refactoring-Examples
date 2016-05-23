using NUnit.Framework;

namespace RefactoringExamples.SplitTemporaryVariable
{
    [TestFixture]
    public class HaggisShould
    {
        [TestCase(1, 1, 1, 1)]
        [TestCase(2, 2, 2, 2)]
        [TestCase(10, 10, 10, 10)]
        public void Travel_nowhere_in_no_time(double primaryForce, double mass, int delay, double secondaryForce)
        {
            var haggis = new Haggis(primaryForce, mass, delay, secondaryForce);

            var distanceTravelled = haggis.GetDistanceTravelled(0);

            Assert.That(distanceTravelled, Is.EqualTo(0));
        }

        [TestCase(5, 10, 10)]
        [TestCase(5, 10, 20)]
        public void Travel_at_constant_speed_when_no_secondary_force_kicks_in(double primaryForce, double mass, int time)
        {
            var delay = time;
            const int secondaryForce = 20;
            var haggis = new Haggis(primaryForce, mass, delay, secondaryForce);

            var distanceTravelled = haggis.GetDistanceTravelled(time);

            var expectedDistance = AccelerationDistance(primaryForce, mass, time);
            Assert.That(distanceTravelled, Is.EqualTo(expectedDistance));
        }

        [TestCase(8, 10, 20, 15)]
        [TestCase(8, 10, 20, 30)]
        public void Travel_at_constant_speed_when_secondary_force_kicks_in_immediately(double primaryForce, double mass, double secondaryForce, int time)
        {
            const int noDelay = 0;
            var haggis = new Haggis(primaryForce, mass, noDelay, secondaryForce);

            var distanceTravelled = haggis.GetDistanceTravelled(time);

            var expectedDistance = AccelerationDistance(primaryForce + secondaryForce, mass, time);
            Assert.That(distanceTravelled, Is.EqualTo(expectedDistance));
        }

        [TestCase(5, 10, 15, 20, 30)]
        public void Speed_up_half_way_through_when_another_force_is_applied(double primaryForce, double mass, int delay, double secondaryForce, int time)
        {
            var haggis = new Haggis(primaryForce, mass, delay, secondaryForce);

            var distanceTravelled = haggis.GetDistanceTravelled(time);

            var primaryDistance = AccelerationDistance(primaryForce, mass, delay);
            var continuingDistance = Acceleration(primaryForce,mass)*delay*(time - delay);
            var secondaryDistance = AccelerationDistance(primaryForce + secondaryForce, mass, time - delay);
            var expectedDistance = primaryDistance + continuingDistance + secondaryDistance;
            Assert.That(distanceTravelled, Is.EqualTo(expectedDistance));
        }

        private static double AccelerationDistance(double primaryForce, double mass, int time)
        {
            return .5*Acceleration(primaryForce, mass)*time*time;
        }

        private static double Acceleration(double primaryForce, double mass)
        {
            return primaryForce/mass;
        }
    }
}