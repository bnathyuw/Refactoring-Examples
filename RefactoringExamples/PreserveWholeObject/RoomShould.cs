using NUnit.Framework;

namespace RefactoringExamples.PreserveWholeObject
{
    [TestFixture]
    public class RoomShould
    {
        private const int PlanHigh = 22;
        private const int PlanLow = 16;
        private HeatingPlan _heatingPlan;

        [SetUp]
        public void SetUp()
        {
            _heatingPlan = new HeatingPlan(new TempRange { High = PlanHigh, Low = PlanLow });
        }

        [TestCase(PlanHigh, PlanLow)]
        [TestCase(PlanHigh - 1, PlanLow)]
        [TestCase(PlanHigh, PlanLow + 1)]
        public void Be_within_plan_when_its_temperature_does_not_exceed_the_plan(int roomHigh, int roomLow)
        {
            var room = new Room(new TempRange {High = roomHigh, Low = roomLow});

            Assert.That(room.WithinPlan(_heatingPlan), Is.True);
        }

        [TestCase(PlanHigh + 1, PlanLow)]
        [TestCase(PlanHigh, PlanLow - 1)]
        [TestCase(PlanHigh + 1, PlanLow - 1)]
        public void Be_outwith_plan_when_its_temperature_does_exceed_the_plan(int roomHigh, int roomLow)
        {
            var room = new Room(new TempRange { High = roomHigh, Low = roomLow });

            Assert.That(room.WithinPlan(_heatingPlan), Is.False);
        }

    }
}