using NUnit.Framework;

namespace RefactoringExamples.InlineMethod
{
    [TestFixture]
    public class CourierShould
    {
        private const int Unreliable = 2;
        private const int Reliable = 1;

        [TestCase(6)]
        [TestCase(10)]
        [TestCase(100)]
        public void Be_rated_unreliable_when_they_have_many_late_deliveries(int numberOfLateDeliveries)
        {
            Assert.That(new Courier(numberOfLateDeliveries).GetRating(), Is.EqualTo(Unreliable));
        }


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        public void Be_rated_unreliable_when_they_have_many_few_deliveries(int numberOfLateDeliveries)
        {
            Assert.That(new Courier(numberOfLateDeliveries).GetRating(), Is.EqualTo(Reliable));
        }
    }
}